Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Spreadsheet
Imports System.IO

Public Class dlgRoyalSwitchGear
    Private initialPath As String = String.Empty

    Private Sub beXlsxFIle_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles beXlsxFIle.ButtonClick
        Dim edit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Using dialog = New DevExpress.XtraEditors.XtraOpenFileDialog()
            dialog.InitialDirectory = initialPath
            dialog.Filter = "XLSX files (*.xlsx)|*.xlsx"
            Dim dialogResult = dialog.ShowDialog()
            If dialogResult = System.Windows.Forms.DialogResult.OK Then
                beXlsxFIle.Text = dialog.FileName
            End If
        End Using

        If (FileExists(beXlsxFIle.Text) = True) Then
            SpreadsheetControl1.LoadDocument(beXlsxFIle.Text, DocumentFormat.Xlsx)

            Dim workbook As IWorkbook = SpreadsheetControl1.Document
            Dim sWorkSheetTable As String = "Cut"

            workbook.Worksheets.ActiveWorksheet = workbook.Worksheets(sWorkSheetTable)
            workbook.Worksheets.ActiveWorksheet.Columns.AutoFit(0, workbook.Worksheets.ActiveWorksheet.Columns.LastUsedIndex)
            SpreadsheetControl1.Document.Worksheets(sWorkSheetTable).FreezeRows(1)

            SetFrozenRowColor()

            Dim worksheet As Worksheet = workbook.Worksheets(sWorkSheetTable)
        End If
    End Sub
    Private Sub SetFrozenRowColor()

        Dim formatting As DevExpress.Spreadsheet.Formatting = SpreadsheetControl1.ActiveWorksheet.Rows(0).BeginUpdateFormatting()
        Dim skin As Skin = CommonSkins.GetSkin(UserLookAndFeel.Default)

        formatting.Fill.BackgroundColor = skin.Colors.GetColor(CommonColors.ReadOnly)

        SpreadsheetControl1.ActiveWorksheet.Rows(0).EndUpdateFormatting(formatting)

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        Me.initialPath = RegGetString("Global", "XLSXPath", App_Path)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dlgRoyalSwitchGear_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If (FileExists(beXlsxFIle.Text) = True) Then
            RegPutString("Global", "XLSXPath", beXlsxFIle.Text)
        End If

    End Sub

    Private Sub sbConvert_Click(sender As Object, e As EventArgs) Handles sbConvert.Click
        Dim ni As Integer
        Dim range As Range
        Dim nSpreadSheetRowCnt As Long
        Dim ws As Worksheet
        Dim workbook As IWorkbook
        Dim sPartFilename As String
        Dim sPartText As String
        Dim sDxfFileName As String
        Dim sDXFMM2Filename As String
        Dim nSi As Integer = 0
        Dim sNewMM2 As String
        Dim m_sPortalCommand As String
        Dim s_ConvertedMM2 As String

        Try
DoNext:

            ws = SpreadsheetControl1.ActiveWorksheet
            workbook = SpreadsheetControl1.Document

            range = ws.GetDataRange()

            nSpreadSheetRowCnt = range.RowCount

            ProgressBarControl1.Properties.Maximum = nSpreadSheetRowCnt

            For ni = range.TopRowIndex + 1 To range.BottomRowIndex

                nSi = nSi + 1

                ' If (nSi > 2368) Then

                ProgressBarControl1.EditValue = nSi
                ProgressBarControl1.Update()

                ' MessageBox.Show("The row count is " & nSpreadSheetRowCnt & ". And The i value is " & ni)
                sPartFilename = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\New_MM2_Files\" & ws.Rows(ni).Item(0).Value.TextValue()
                sNewMM2 = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\New_MM2_Files\" & ws.Rows(ni).Item(0).Value.TextValue()
                sPartText = ws.Rows(ni).Item(1).Value.ToString

                sDxfFileName = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\DXF_Files\" & sPartText & ".dxf"
                sDXFMM2Filename = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_DXF\" & sPartText & ".mm2"

                s_ConvertedMM2 = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_mm2\" & PathFileExt(sPartFilename)

                LabelControl1.Text = "Converting Part: " & PathFileExt(sPartFilename)
                LabelControl1.Update()

                'CreateLetterDXF(sPartText & ".dxf")

                ImportFile(s_ConvertedMM2, s_ConvertedMM2)

                SetValuesInHeader("C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_CNC\" & PathFile(sPartFilename) & ".cnc")

                m_sPortalCommand = "codegen:generate:cgfile=" & QStr("C:\Program Files (x86)\WE-CIM\22.0\CodeGen\DynaTorch5.java") & _
                ",ncfile=" & QStr("C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_CNC\" & PathFile(sPartFilename) & ".cnc") & _
                ",Subs=0,adv=0,Optalgorithm=1,Slice_Opt=0,Sticky=0,BiDir=1,Seq_Opt=0"

                lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!

                lReturn = PortalExecute(m_sPortalCommand)

                lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!

                'GetWorkZoneBoundingBox(sPartFilename, sDXFMM2Filename)

                'sToolSetup = HeaderStringGet("MachCfg", "")

                'If (sToolSetup = "") Then GoTo Proceed


                'nToolSetupID = GetToolSetupIDFromDescription(sToolSetup)

                ''lReturn = PortalExecute( _
                ''        "model:toolsupdate:" & _
                ''        " db=" & QStr(PathCMDB()) & _
                ''        ",toolsetupid=" & nToolSetupID)

                ''lReturn = PortalExecute("admin:regen:")

                ''GetToolsFromModel()

                ''lReturn = modFileIO.ExportMM2(sNewMM2)

                'materialName = "Generic"

                'machineID = modTranslate.GetMachineID(sToolSetup)
                'smachineName = GetMachineDescription(machineID)
                'materialID = modTranslate.GetMaterialIDFromDescription("Generic")
                'layersetup_id = modTranslate.GetLayerSetupID(sToolSetup, machineID)


                'modConversion.ConversionParametersSet(0, False, False)

                'RegPutString("Global", "LayerSetup", sToolSetup)
                'RegPutString("Global", "LayerSetupID", CStr(layersetup_id))

                'RegPutString("Global", "ToolSetupID", nToolSetupID)
                'RegPutString("Global", "ToolSetup", sToolSetup)
                'RegPutString("Global", "MaterialID", 6)
                'RegPutString("Global", "Material", "Generic")
                'RegPutString("Global", "Machine", "Dynatorch")
                'RegPutString("Global", "MachineID", 5)


                'modAdmin.ModelDirtyClear()

                'ImportDXF(sDxfFileName, sDXFMM2Filename)
                'lReturn = modFileIO.ExportMM2(sDXFMM2Filename)

                'ViewFull()
                'End If

Proceed:

            Next
        Catch ex As Exception
            GoTo DoNext
        End Try


    End Sub
    Private Sub CreateLetterDXF(sDxfFilename As String)
        Dim sDxfText As String = PathFile(sDxfFilename)
        Dim sr As New StreamReader(App_Path & "\DXFTEMPLATE.dxf")
        Dim text As String = sr.ReadToEnd()
        sr.Close()

        Dim sw As New StreamWriter("C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\DXF_Files\" & sDxfFilename)
        sw.WriteLine(text & sDxfText) ' Add original content back
        sw.WriteLine("0")
        sw.WriteLine("ENDSEC")
        sw.WriteLine("0")
        sw.WriteLine("EOF")

        sw.Close()

        'Dim line As String = Nothing
        'Using sw As StreamWriter = File.AppendText(Path)
        '    sw.WriteLine("This")
        '    sw.WriteLine("is Extra")
        '    sw.WriteLine("Text")
        'End Using
        'Using sr As StreamReader = New StreamReader(sDxfFilename)
        '    line = sr.ReadLine()

        '    While (line <> Nothing)
        '        If (InStr(1, line, "//=") > 0) Then

        '        End If
        '    End While
        'End Using
    End Sub
    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Close()

    End Sub

    Private Sub dlgRoyalSwitchGear_Load(sender As Object, e As EventArgs) Handles Me.Load
        ProgressBarControl1.EditValue = 0
        ProgressBarControl1.Update()
    End Sub

    Private Sub GetWorkZoneBoundingBox(sPartFilename As String, sMergeFile As String)
        Dim cnt As Long
        Dim indx As Long
        Dim Zone_ID As Integer
        Dim Zone_Num As Integer
        Dim Zone_Min As Double
        Dim Zone_Max As Double
        Dim Zone_Center_X As Double
        Dim Zone_Center_Y As Double
        Dim Zone_Bottom As Double
        Dim Zone_Top As Double
        Dim sExportedMM2 As String
        Dim nRoyalToolID As Long
        Dim lCount As Long
        Dim dZone_offset As Double = 6.6875
        Dim dNew_Offset As Double
        Dim m_workzone_id As Long

        lReturn = PortalExecute("zone:count:")
        cnt = PortalGetInt("count", 0)


        For indx = 1 To cnt

            Zone_Num = PortalExecute("zone:get:_zone_num=" & indx)

            If (lReturn > 0) Then


                Zone_ID = Round(PortalGetInt("ID", indx))

                If (indx = 1) Then
                    m_workzone_id = Zone_ID
                End If

                Zone_Min = PortalGetDouble("_zone_left", 0.0#)
                Zone_Max = PortalGetDouble("_zone_right", 0.0#)
                Zone_Bottom = PortalGetDouble("_zone_bottom", 0.0#)
                Zone_Top = PortalGetDouble("_zone_top", 0.0#)

                If (Zone_Max > UNDEFINED) Then
                    lReturn = PortalExecute("*model:partextent:")
                    Zone_Min = PortalGetDouble("xmin", 0)
                    Zone_Max = PortalGetDouble("xmax", 0)
                    Zone_Bottom = PortalGetDouble("ymin", 0)
                    Zone_Top = PortalGetDouble("ymax", 0)

                End If


                If (indx = 1) Then
                    dNew_Offset = 0
                Else
                    dNew_Offset = dZone_offset * (indx - 1)
                End If


                Zone_Center_X = (((Zone_Max - Zone_Min) / 2) - 0.6) + dNew_Offset
                Zone_Center_Y = (Zone_Top / 2) - 0.875

                UndoPrepare()

                lReturn = PortalExecute( _
                    "file:mergemm2:" & _
                    " file=" & QStr(sMergeFile) & _
                    ",ox=" & Zone_Center_X & _
                    ",oy=" & Zone_Center_Y & _
                    ",oz=0")

                UndoCommit()

            End If

            '"C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_DXF\" & sPartText & ".mm2"
        Next


        sExportedMM2 = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_mm2\" & PathFileExt(sPartFilename)

        ImportFile(sExportedMM2, sExportedMM2)

        UndoPrepare()

        lReturn = PortalExecute("create:empty:") ' get rid of empty feature

        lReturn = PortalExecute("model:purge:") ' get rid of unused tools

        UndoCommit()

        GetToolsFromModel()

        For Each clsToolData In g_colToolSetup

            If clsToolData.NC_Code_Number = 3 Then

                nRoyalToolID = clsToolData.model_id
                Exit For
            End If
        Next


        lReturn = SetSelectionFilters( _
                (SELECTION_FILTER.SEL_LINE Or SELECTION_FILTER.SEL_ARC Or SELECTION_FILTER.SEL_HOLE Or SELECTION_FILTER.SEL_POINT Or _
                    SELECTION_FILTER.SEL_COMMAND Or SELECTION_FILTER.SEL_PROFILE Or SELECTION_FILTER.SEL_FEATURE))

        lCount = SelectAllRefsTo(nRoyalToolID)

        lReturn = modFeature.FeatureAddSelected(m_workzone_id)


        ' sExportedMM2 = "C:\1wittlockeng\Customers\Royal_SwitchGear\MM2 FILES\Converted_mm2\" & PathFileExt(sPartFilename)

        modFileIO.ExportMM2(sExportedMM2)

    End Sub

    Private Sub SetValuesInHeader(ncfile As String)

        Try

            lReturn = HeaderStringSet("cgfile", "C:\Program Files (x86)\WE-CIM\22.0\CodeGen\DynaTorch5.java")

            lReturn = HeaderStringSet("ncfile", ncfile)

            lReturn = HeaderIntSet("subs", 0)

            lReturn = HeaderIntSet("opttoolpath", 1)

            lReturn = HeaderIntSet("OptAlgorithm", 1)

            lReturn = HeaderIntSet("Sticky", 0)

            lReturn = HeaderIntSet("seq_opt", 0)

            lReturn = HeaderIntSet("bidir", 1)

            lReturn = HeaderIntSet("AllHolesFirst", _
                            RegGetString("CodeGeneration", "AllHolesFirst", "0"))

            lReturn = HeaderIntSet("HolesByToolOrder", _
                RegGetString("CodeGeneration", "HolesByToolOrder", "0"))

            lReturn = HeaderIntSet("ByCompletePart", _
                RegGetString("CodeGeneration", "ByCompletePart", "0"))

            lReturn = HeaderIntSet("HolesAcrossLocalNest", _
                RegGetString("CodeGeneration", "HolesAcrossLocalNest", "0"))

            lReturn = HeaderStringSet("cg.feed", "100")

            lReturn = HeaderStringSet("cg.fanon", "M08")

            lReturn = HeaderStringSet("cg.fanoff", "M09")

            lReturn = HeaderStringSet("cg.markon", "M62")

            lReturn = HeaderStringSet("cg.markoff", "M63")

            lReturn = HeaderStringSet("cg.markup", "M61")

            lReturn = HeaderStringSet("cg.markdown", "M60")

            lReturn = HeaderIntSet("OptAlgorithm", 1)

            'CRITICAL! Record the Java Filename
            '?lReturn = HeaderStringSet("cgfile", fcbCodeGenFile.Tag)

            'Record the NC Filename
            '?If (m_context = CODE_OPTION.CODE_FILE) Then
            '?lReturn = HeaderStringSet("ncfile", fcbExportTo.Tag)
            '?Else
            'Commentted out the following line because if the user
            'Went to Code Viewer just to check the code
            'This line overwrites the cnc filename stored in the header
            'By overwriting the var, the user would have to recode the file
            'in order to get the var set correcttly again
            'Overwriting the var in the viewer screws up printing
            'lReturn = HeaderStringSet("ncfile", "")
            '?End If

            'Record the checkbox for subs
            '? lReturn = HeaderIntSet("subs", If(chkSubRoutines.Checked = True, 1, 0))

            'Record the checkbox for optimizing the toolpath
            '?lReturn = HeaderIntSet("opttoolpath", IIf(cbfOptimizeToolpath.Checked = True, 1, 0))

            'Record the optimization mode.
            'The radio button order is Grid/Closest/Progressive
            '?If (rgOptMode.SelectedIndex = 0) Then
            '?lReturn = HeaderIntSet("OptAlgorithm", PROGRESSIVE_MODE)
            '?ElseIf (rgOptMode.SelectedIndex = 1) Then
            '?lReturn = HeaderIntSet("OptAlgorithm", CLOSEST_PT_MODE)
            '?Else
            '?lReturn = HeaderIntSet("OptAlgorithm", GRID_MODE)
            '?End If


            'TODO V21
            ''Record the start corner and direction
            'For nI = 1 To Toolbar1.buttons.Count
            '    If (Toolbar1.buttons(nI).Value = tbrPressed) Then
            '        lReturn = HeaderIntSet("slice_opt", (nI - 1))
            '    End If
            'Next

            'Record the Linear Trend Value
            '?lReturn = HeaderIntSet("Sticky", CLng(txtSticky.Text))

            'Record Sequence By Mode (Preset Tool Order,Containment Order,Process Flowchart)
            '?lReturn = HeaderIntSet("seq_opt", lcbGridSequence.ListIndex)

            'Record Zig Zag Checkbox
            '?lReturn = HeaderIntSet("bidir", IIf(chkZigZag.Checked = True, 1, 0))

            'NOTE: It is CRITCAL that SetDefaultsInReg() is called prior to these.
            'The alternate is to add quary functions to frmFlowChart.

            '?lReturn = HeaderIntSet("AllHolesFirst", _
            '?   RegGetString("CodeGeneration", "AllHolesFirst", "0"))

            '?lReturn = HeaderIntSet("HolesByToolOrder", _
            '?   RegGetString("CodeGeneration", "HolesByToolOrder", "0"))

            '?lReturn = HeaderIntSet("ByCompletePart", _
            '?   RegGetString("CodeGeneration", "ByCompletePart", "0"))

            '?lReturn = HeaderIntSet("HolesAcrossLocalNest", _
            '?   RegGetString("CodeGeneration", "HolesAcrossLocalNest", "0"))

            '?If (m_context <> CODE_OPTION.SEQUENCE_ORDER) Then

            'Save the codegen Vars to the header
            '?SaveVariables()

            '?End If


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub beXlsxFIle_EditValueChanged(sender As Object, e As EventArgs) Handles beXlsxFIle.EditValueChanged

    End Sub
End Class