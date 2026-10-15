Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports System.Data.OleDb
Imports System.IO



Public Class NewdlgLifeGear
    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MACHINE_ROOT_NODE As TreeListNode
    Private CFG_MACHINE_TYPE_NODE As Nodes.TreeListNode
    Private CFG_MACHINE_NODE As TreeListNode
    Private CFG_STATION_ROOT_NODE As TreeListNode
    Private CFG_TOOL_SETUP_ROOT_NODE As TreeListNode
    Private CFG_TOOL_SETUP_NODE As TreeListNode
    Private CFG_LAYER_SETUP_ROOT_NODE As TreeListNode
    Private CFG_LAYER_SETUP_NODE As TreeListNode
    Private CFG_LAYER_MAP_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private CFG_MATERIAL_NODE As TreeListNode
    Private CFG_OPERATION_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_PARAM_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_PARAM_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_SETUP_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_SETUP_NODE As TreeListNode
    Private Const TAG_ROOT_NODE = 0
    Private Const TAG_MACHINE_ROOT_NODE = -100
    Private Const TAG_MACHINE_NODE = -101
    Private Const TAG_STATION_ROOT_NODE = -102
    Private Const TAG_TOOL_SETUP_ROOT_NODE = -103
    Private Const TAG_TOOL_SETUP_NODE = -104
    Private Const TAG_LAYER_SETUP_ROOT_NODE = -105
    Private Const TAG_LAYER_SETUP_NODE = -106
    Private Const TAG_LAYER_MAP_NODE = -107
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Private Const TAG_OPERATION_ROOT_NODE = -300
    Private Const TAG_OPERATION_LEAD_ROOT_NODE = -301
    Private Const TAG_OPERATION_LEAD_PARAM_ROOT_NODE = -302
    Private Const TAG_OPERATION_LEAD_PARAM_NODE = -303
    Private Const TAG_OPERATION_LEAD_SETUP_ROOT_NODE = -304
    Private Const TAG_OPERATION_LEAD_SETUP_NODE = -305


    Private sPieces() As String
    Private sMatPieces() As String
    Private sMaterialWidth As String
    Private sMaterialLength As String
    Private sMaterialThickness As String
    Private bHeaderDone As Boolean


    Dim dCheckX As Double
    Dim dCheckY As Double
    Dim sUsage As String
    Private m_isVirginDB As Boolean

    Private m_active_workzone_index As Integer
    Private m_active_workzoneID As Long
    Private m_active_workzone_name As String
    Private m_g_LogRecord As Boolean
    Private sw As System.IO.StreamWriter
    Private s_Machine As String = String.Empty
    Private s_ToolSetup As String = String.Empty
    Private s_LayerSetup As String = String.Empty
    Private s_LeadSetup As String = String.Empty
    Private sSheetName As String
    Dim PDBFilename As String

    Protected Overloads Overrides Sub WndProc(ByRef m As Message)

        '//Prevent the user from moving the form

        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_MOVE) Then
            Exit Sub
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32() = HTCAPTION) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub
    Private Sub dlgLifeGear_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try

            If (bHeaderDone = True) Then
                sw.Close()
            End If


        Catch ex As Exception
            MessageBox.Show("dlgLifeGear_FormClosed: " & ex.Message)

        End Try


        frmMain.CloseFirstPanel()
        modView.ViewResize()
    End Sub

    Private Sub LifeGear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtMaterialType As DataTable = Nothing
        Dim dtMaterials As DataTable = Nothing
        Dim materialID As Long


        bHeaderDOne = False

        CreateMaterialTypeNodes(tl)


        popupContainerControl1.Controls.Add(tl)
        popupContainerEdit1.Properties.PopupControl = popupContainerControl1
        popupContainerEdit1.Properties.ShowPopupCloseButton = False
        AddHandler popupContainerEdit1.QueryDisplayText, AddressOf popupContainerEdit1_QueryDisplayText
        'AddHandler popupContainerEdit1.QueryResultValue, AddressOf popupContainerEdit1_QueryResultValue

        txtQty.Text = "1"

        FillToolListBasedOnType(15)

        rgProductType.SelectedIndex = 0

        sbCompile.Visible = m_debug_menu

        cbSpacing.Properties.Items.Add(New myItemData("0.5"" X  0.5""", 0, ".5"))
        cbSpacing.Properties.Items.Add(New myItemData("1.0"" X  1.0""", 1, "1.0"))
        cbSpacing.Properties.Items.Add(New myItemData("1.5"" X  1.5""", 2, "1.5"))

        cbSpacing.SelectedIndex = 1

        materialID = modProject.GetMaterialID()

        If (DoesMaterialExist(materialID) = False) Then

            materialID = 0

        End If

        'LoadMaterials()

        modProject.InitMaterialList(cbeMaterialType, materialID)
        rgProductType.SelectedIndex = 0

        rgLogo.SelectedIndex = 0
        rgNotch.SelectedIndex = 0
        rgPresser.SelectedIndex = 0
        cbeMaterialType.Focus()
        LoadMaterialTypes("PegBoard")
        cboRotation.SelectedIndex = 0
    End Sub
    'Private Sub popupContainerEdit1_QueryResultValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs)

    'End Sub

    'Private Sub LoadMaterials()
    '    Dim sql As String
    '    Dim ds As New DataSet
    '    Dim connection As OleDbConnection
    '    Dim oledbAdapter As OleDbDataAdapter
    '    Dim connetionString As String
    '    Dim sMatType As String

    '    Try

    '        sql = "Select [Material Types].* From [Material Types]"

    '        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

    '        connection = New OleDbConnection(connetionString)

    '        connection.Open()

    '        oledbAdapter = New OleDbDataAdapter(sql, connection)

    '        oledbAdapter.Fill(ds)

    '        oledbAdapter.Dispose()

    '        connection.Close()

    '        '' Add the column
    '        'tluMaterials.Columns.AddVisible("Materials")
    '        '' TreeList.AppendNode adds a new TreeListNode containing the specified values to the XtraTreeList.
    '        'For i As Integer = 0 To 4
    '        '    Dim parentNode As TreeListNode = tluMaterials.AppendNode(New Object() {"Root Node " & i.ToString()}, parentNode:=Nothing)
    '        '    For j As Integer = i + 1 To i + 3 - 1
    '        '        tluMaterials.AppendNode(New Object() {"Child Node " & j.ToString()}, parentNode)
    '        '    Next j
    '        'Next i


    '        'If (ds.Tables(0).Rows.Count > 0) Then

    '        '    For i = 0 To ds.Tables(0).Rows.Count - 1

    '        '        sMatType = ds.Tables(0).Rows(i).Item("Description")
    '        '        If (InStr(sMatType, "MagPanel") = True) Then
    '        '            tluMaterials.Properties.
    '        '        End If


    '        '    Next


    '        'End If

    '        If connection IsNot Nothing Then connection = Nothing
    '        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
    '        If ds IsNot Nothing Then ds = Nothing

    '    Catch ex As Exception

    '        MessageBox.Show("NewDlgLifeGear_LoadMaterials: " & ex.Message)

    '    End Try


    'End Sub

    Private Sub FillToolListBasedOnType(tlTypeId As Long)
        Dim sDisplayStr As String
        Dim nID As Integer
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim m_machineType As Long = 1
        Dim tlDia As Double

        cbDIa.Properties.Items.Clear()

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "SELECT [Tool Crib].* FROM ([Tool Types] INNER JOIN [Tool Crib] ON [Tool Types].ID = [Tool Crib].[Type ID]) INNER JOIN [Machine Tool Types] ON [Tool Types].ID = [Machine Tool Types].[Tool Type ID]" &
                " WHERE ((([Tool Types].ID)=" & tlTypeId & ") AND (([Machine Tool Types].[Machine Type ID])=" & m_machineType & ")) Order By [Tool Crib].Diameter"

        connection = New OleDbConnection(connetionString)

        Try
            InitFillDS(ds, Nothing, sql, connection)

            For i = 0 To ds.Tables(0).Rows.Count - 1
                sDisplayStr = CStr(ds.Tables(0).Rows(i).Item("Description"))
                nID = CInt(ds.Tables(0).Rows(i).Item("ID"))

                'cbDIa.Properties.Items.Add("0.141"" Diameter")
                'cbDIa.Properties.Items.Add("0.195"" Diameter")
                'cbDIa.Properties.Items.Add("0.265"" Diameter")
                'cbDIa.Properties.Items.Add("0.312"" Diameter")
                'cbDIa.Properties.Items.Add("0.380"" Diameter")
                'cbDIa.Properties.Items.Add("10mm Diameter (0.393""")
                'cbDIa.Properties.Items.Add("11mm Diameter (0.433""")
                'cbDIa.Properties.Items.Add("12mm Diameter (0.472""")
                'cbDIa.SelectedIndex = 2
                tlDia = ds.Tables(0).Rows(i).Item("Diameter")

                Select Case tlDia

                    Case 0.141, 0.195, 0.265, 0.312, 0.38, 0.393, 0.433, 0.472
                        cbDIa.Properties.Items.Add(New myItemData(sDisplayStr, nID, tlDia))


                End Select

            Next

            cbDIa.SelectedIndex = 2
            ds.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub rgProductType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgProductType.SelectedIndexChanged


        If (rgProductType.SelectedIndex = 0) Then

            gcNotch_Corners.Visible = True
            pcMagPanel.Visible = False
            gcHole.Visible = True
            rgLogo.SelectedIndex = 0
            rgNotch.SelectedIndex = 0
            rgPresser.SelectedIndex = 0

            LoadMaterialTypes("PegBoard")
            sUsage = "Pegboard"


        Else

            gcNotch_Corners.Visible = False
            pcMagPanel.Visible = True

            rgMountingHoles.SelectedIndex = 0
            rgCorner.SelectedIndex = 0
            rgPresser2.SelectedIndex = 0

            gcHole.Visible = False

            LoadMaterialTypes("MagPanel")
            sUsage = "MagPanel"

        End If

        cbeMaterialType.Focus()
        CreateMaterialTypeNodes(tl)

    End Sub

    Private Sub sbRun_Click(sender As Object, e As EventArgs) Handles sbRun.Click
        Dim nToolSetupID As Long = RegGetString("Global", "ToolSetupID", 0)
        Dim sFileName As String = App_Path & "\Models\Diamond.mm2"
        Dim nmachineID As Long = RegGetString("Global", "MachineID", 0)
        Dim nmaterialID As Long = modTranslate.GetMaterialIDFromDescription(cbBlankSize.Text)
        Dim dmaterialLength As Double = CDbl(modMaterial.GetMaterialLength(CLng(nmaterialID)))
        Dim dmaterialWidth As Double = CDbl(modMaterial.GetMaterialWidth(CLng(nmaterialID)))
        Dim dmaterialThickness As Double = CDbl(modMaterial.GetMaterialThickness(CLng(nmaterialID)))
        Dim sPanelCgFile As String
        Dim sCgFile As String
        Dim sNCFile As String
        Dim m_sPortalCommand As String
        Dim sSpecNCFile As String
        Dim sSpecNCFileFileInfo As FileInfo

        'sw.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, SplashFormStartPosition.Manual, New Point(Me.StartPosition()))
        SplashScreenManager.Default.SetWaitFormDescription("Creating Panel, Please Wait...")

        If (cbBlankSize.Text = "") Then
            MsgBox("Can Not Find Any Material For The Given Height and Length", MsgBoxStyle.Critical)

        Else

            sSpecNCFile = RegGetString("Customizations", "SpecNcFile", NormalizePath(Application.StartupPath) & "CNC\1234.LST")

            sSpecNCFileFileInfo = New FileInfo(RegGetString("Customizations", "SpecNcFile", NormalizePath(Application.StartupPath) & "CNC\1234.LST"))

            If (IsFileLocked(sSpecNCFileFileInfo) = False) Then

                If (FileExists(sSpecNCFile) = True) Then
                    Kill(sSpecNCFile)
                End If
            End If

            'PathLOG_Set("C:\Program Files (x86)\WE-CIM\22.0\Debug\Debug.log")

            'm_g_LogRecord = True

            'lReturn = PortalExecute("cmdlog:file=" & QStr(PathLOG()))

            'If (rgProductType.SelectedIndex = 0) Then
            '    sFileName = App_Path & "\Models\HPB_" & txtWidth.Text & "_" & txtHeight.Text & "_X.mm2"
            'Else
            '    sFileName = App_Path & "\Models\HMB_" & txtWidth.Text & "_" & txtHeight.Text & "_X.mm2"
            'End If

            sFileName = App_Path & "\Models\" & txtOrderNum.Text & "." & txtItemNum.Text & ".mm2"

            'UndoPrepare()

            sReturn = NewModel(sFileName, nmachineID, nToolSetupID, nmaterialID,
                               dmaterialLength, dmaterialWidth, dmaterialThickness)

            sPanelCgFile = RegGetString("Customizations", "PanelCgJava", NormalizePath(Application.StartupPath) & "CodeGen\TRUMPF2020_D.java")

            RegPutString("Customizations", "SpecJava", sPanelCgFile)

            sCgFile = RegGetString("Customizations", "SpecJava", NormalizePath(Application.StartupPath) & "CodeGen\TRUMPF2020_D.java")

            PathCG_Set(sCgFile)

            lReturn = HeaderStringSet("cgfile", sCgFile)

            lReturn = HeaderStringSet("DLifeName", sFileName)

            sNCFile = RegGetString("Customizations", "SpecNcFile", NormalizePath(Application.StartupPath) & "CNC\1234.LST")

            lReturn = HeaderStringSet("ncfile", sNCFile)

            lReturn = HeaderDoubleSet("mac.Dia", TryCast(cbDIa.Properties.Items(cbDIa.SelectedIndex), myItemData).sItemData)

            'MsgBox("the blank size length is < " & dCheckX & " > and The width is <" & dCheckY & " >")

            If (rgProductType.SelectedIndex = 0) Then

                CretePegBoardMX("Part")
                ViewRegen()
                ViewFull()

                'Me.Dispose()

            Else

                CreateMagPanel("Part")
                ViewRegen()
                ViewFull()

            End If

            frmMain.SynchronizeUI(modSelection.SelectedCount())

            'UndoCommit()

        End If

        'm_sPortalCommand = "codegen:generate:cgfile=" & Chr(34) & sCgFile & Chr(34) & ",ncfile=" & Chr(34) & sNCFile & Chr(34) & ",Subs=0,adv=0"


        'lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!
        'lReturn = PortalExecute(m_sPortalCommand)

        'lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!

        'frmCodeGen.LoadDialog()
        'frmCodeGen.OKButtonClick()

        SplashScreenManager.Default.SetWaitFormDescription("Process Compleate...")
        SplashScreenManager.CloseForm()

        m_g_LogRecord = False

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

            lReturn = HeaderIntSet("AllHolesFirst",
                            RegGetString("CodeGeneration", "AllHolesFirst", "0"))

            lReturn = HeaderIntSet("HolesByToolOrder",
                RegGetString("CodeGeneration", "HolesByToolOrder", "0"))

            lReturn = HeaderIntSet("ByCompletePart",
                RegGetString("CodeGeneration", "ByCompletePart", "0"))

            lReturn = HeaderIntSet("HolesAcrossLocalNest",
                RegGetString("CodeGeneration", "HolesAcrossLocalNest", "0"))

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
    Private Sub CretePegBoardMX(sPartMode As String)
        Dim cmd As String
        Dim m_sPortalCommand As String
        Dim s_cgfile As String
        Dim sCncFile As String
        Dim PegBoardJava As String
        Dim PegBoardJavaNoNotch As String


        sCncFile = RegGetString("Customizations", "SpecNcFile", App_Path & "\CNC\01234.LST")
        s_cgfile = RegGetString("Customizations", "SpecJava", App_Path & "\CodeGen\TRUMPF2020_D.java")


        If (sPartMode = "Nest") Then
            PegBoardJava = RegGetString("Customizations", "PegBoardNestJava", App_Path & "\Macros\PegBoardMXNest_R10.java")
        Else
            PegBoardJava = RegGetString("Customizations", "PegBoardJava", App_Path & "\Macros\PegBoardMX_R2.java")
        End If
        PegBoardJavaNoNotch = RegGetString("Customizations", "PegBoardJavaNoNotch", App_Path & "\Macros\PegBoardMX_NoNotch.java")

        'If (FileExists(sCncFile) = True) Then
        '    'Kill(sCncFile)
        '    My.Computer.FileSystem.RenameFile(sCncFile, "SecondTest.txt")

        'End If
        m_sPortalCommand = "codegen:generate:cgfile=" & QStr(s_cgfile)

        'This is not used when using Viewer or Sequence Order
        m_sPortalCommand = m_sPortalCommand & ",ncfile=" & QStr(sCncFile)

        m_sPortalCommand = m_sPortalCommand & ",Subs=0"
        m_sPortalCommand = m_sPortalCommand & ",adv=0"

        HeaderStringSet("cgfile", s_cgfile)

        HeaderStringSet("ncfile", sCncFile)


        'HeaderStringSet("mac.ProfLen2", "0.688")
        'HeaderStringSet("mac.Profwid2", "0.688")
        'HeaderStringSet("mac.notch45", "0.468")
        'HeaderStringSet("mac.proflen", txtWidth.Text)
        'HeaderStringSet("mac.ProfWid", txtHeight.Text)
        'HeaderStringSet("mac.qty", txtQty.Text)
        ''HeaderStringSet("mac.matid", cbBlankSize.EditValue)
        'HeaderStringSet("mac.matid", popupContainerEdit1.Tag)
        'HeaderStringSet("mac.Logo", IIf(rgLogo.SelectedIndex = 0, 1, 0))
        'HeaderStringSet("mac.notch", IIf((rgNotch.SelectedIndex = 0), 1, 0))
        ''HeaderStringSet("mac.notch", rgNotch.SelectedIndex)
        'HeaderStringSet("mac.presser", IIf(rgPresser.SelectedIndex = 0, 1, 0))
        'HeaderDoubleSet("mac.spaceing", (TryCast(cbSpacing.Properties.Items(cbSpacing.SelectedIndex), myItemData)).ItemData.ToString())
        HeaderStringSet("mac.ProfLen2", "0.688")
        HeaderStringSet("mac.Profwid2", "0.688")
        HeaderStringSet("mac.notch45", "0.468")
        HeaderStringSet("mac.proflen", txtWidth.Text)
        HeaderStringSet("mac.ProfWid", txtHeight.Text)
        HeaderStringSet("mac.qty", txtQty.Text)
        HeaderStringSet("mac.matid", popupContainerEdit1.Tag)

        If (rgLogo.SelectedIndex = 0) Then
            HeaderStringSet("mac.Logo", 1)
        Else
            HeaderStringSet("mac.Logo", 0)
        End If

        If (rgNotch.SelectedIndex = 0) Then

            HeaderStringSet("mac.notch", 1)
        Else
            HeaderStringSet("mac.notch", 0)
        End If
        If (rgPresser.SelectedIndex = 0) Then

            HeaderStringSet("mac.presser", 1)

        Else

            HeaderStringSet("mac.presser", 0)

        End If

        HeaderStringSet("mac.moutingholes", rgMountingHoles.SelectedIndex)
        HeaderStringSet("mac.roundedcorners", rgCorner.SelectedIndex)
        HeaderStringSet("DLifeFilename", RegGetString("Fabrication\FileOpen", "LastMM2", ""))

        HeaderDoubleSet("mac.spaceing", "1.0")
        HeaderDoubleSet("Clamp1Pos", 18.503)
        HeaderDoubleSet("Clamp2Pos", 44.0939)
        HeaderDoubleSet("mac.spaceing", (TryCast(cbSpacing.Properties.Items(cbSpacing.SelectedIndex), myItemData)).ItemData.ToString())

        'UndoPrepare()

        If (rgNotch.SelectedIndex = 0) Then
            'MsgBox("Thejava is " & PegBoardJava)

            cmd = "admin:macrorun: javafile=" & QStr(PegBoardJava)
        Else
            cmd = "admin:macrorun: javafile=" & QStr(PegBoardJavaNoNotch)

        End If

        lReturn = PortalExecute(cmd)
        'ExportMM2(PathMM2())

        'Lets be sure thera are no empty features lying around

        'lReturn = PortalExecute("create:empty:") ' get rid of empty feature

        'lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!
        'lReturn = PortalExecute(m_sPortalCommand)

        'lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!
        lReturn = PortalExecute("create:empty:") ' get rid of empty feature

        'UndoCommit()


    End Sub
    Private Sub CreateMagPanel(sPartMode As String)
        Dim cmd As String
        Dim MagPanelJava As String

        'MessageBox.Show(RegGetString("Customizations", "SpecJava", App_Path & "\CodeGen\TRUMPF2020_D.java"))

        HeaderStringSet("cgfile", RegGetString("Customizations", "SpecJava", App_Path & "\CodeGen\TRUMPF2020_D.java"))

        HeaderStringSet("ncfile", RegGetString("Customizations", "SpecNcFile", App_Path & "\CNC\01234.LST"))

        If (sPartMode = "Nest") Then
            MagPanelJava = RegGetString("Customizations", "MagPanelNestJava", App_Path & "\Macros\MagPanelNestR13.java")
        Else
            MagPanelJava = RegGetString("Customizations", "MagPanelJava", App_Path & "\Macros\MagPanelR13.java")
        End If


        HeaderStringSet("mac.ProfLen2", "0.688")
        HeaderStringSet("mac.Profwid2", "0.688")
        HeaderStringSet("mac.notch45", "0.468")
        HeaderStringSet("mac.proflen", txtWidth.Text)
        HeaderStringSet("mac.ProfWid", txtHeight.Text)
        HeaderStringSet("mac.qty", txtQty.Text)
        HeaderStringSet("mac.matid", popupContainerEdit1.Tag)
        HeaderStringSet("mac.Logo", rgLogo.SelectedIndex)
        HeaderStringSet("mac.notch", rgNotch.SelectedIndex)
        HeaderStringSet("mac.presser", rgPresser.SelectedIndex)
        HeaderStringSet("mac.moutingholes", rgMountingHoles.SelectedIndex)
        HeaderStringSet("mac.roundedcorners", rgCorner.SelectedIndex)
        HeaderStringSet("DLifeFilename", RegGetString("Fabrication\FileOpen", "LastMM2", ""))


        HeaderDoubleSet("mac.spaceing", "1.0")
        HeaderDoubleSet("Clamp1Pos", 18.503)
        HeaderDoubleSet("Clamp2Pos", 44.0939)
        HeaderDoubleSet("mac.spaceing", (TryCast(cbSpacing.Properties.Items(cbSpacing.SelectedIndex), myItemData)).ItemData.ToString())


        'MessageBox.Show("the java file is < " & MagPanelJava + " and we are saving it to " + HeaderStringGet("DLifeFileName", ""))

        cmd = "admin:macrorun: javafile=" & QStr(MagPanelJava)

        lReturn = PortalExecute(cmd)

        'Lets be sure thera are no empty features lying around

        lReturn = PortalExecute("create:empty:") ' get rid of empty feature

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Dispose()
    End Sub

    Private Sub dlgLifeGear_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cbeMaterialType.Focus()
    End Sub


    Private Sub cbeMaterialType_EditValueChanged(sender As Object, e As EventArgs) Handles cbeMaterialType.EditValueChanged
        FindBlank()
    End Sub

    Private Sub LoadMaterialTypes(s_CompareStr As String)
        Dim sql As String
        Dim dtMaterialType As DataTable = Nothing
        Dim n_MaterialID As Long
        Dim dtMaterials As DataTable = Nothing
        Dim s_MaterialCategory As String

        cbeMaterialType.Properties.Items.Clear()

        sql = "Select [Material Types].* From [Material Types] Where ([Material Types].ID > 0 ) Order By [Material Types].Display"
        dtMaterialType = ConnectToCMDB(sql)

        For i = 0 To dtMaterialType.Rows.Count - 1

            s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")
            n_MaterialID = dtMaterialType.Rows(i).Item("ID")

            If (InStr(s_MaterialCategory, s_CompareStr) > 0) Then

                cbeMaterialType.Properties.Items.Add(New myItemData(s_MaterialCategory, n_MaterialID))

            End If

        Next

        cbeMaterialType.SelectedIndex = 0

        DatabaseClose()

        dtMaterialType.Dispose()

        dtMaterialType = Nothing

        'rgProductType.SelectedIndex = 0

    End Sub
    Private Sub FindBlank()
        Dim sql As String
        Dim MatTypeID
        Dim dtMaterials As DataTable = Nothing
        Dim s_MaterialBlank As String
        Dim n_MaterialID As Integer

        If (rgProductType.SelectedIndex = 0) Then
            dCheckX = Val(txtWidth.Text) + (1.156 * 2)
            dCheckY = Val(txtHeight.Text) + (1.156 * 2)
        Else
            dCheckX = Val(txtWidth.Text)
            dCheckY = Val(txtHeight.Text)

        End If

        If (Val(txtHeight.Text) > 0 And Val(txtWidth.Text) > 0) Then

            cbBlankSize.Properties.Items.Clear()

            MatTypeID = TryCast(cbeMaterialType.Properties.Items(cbeMaterialType.SelectedIndex), myItemData).ItemData.ToString()

            sql = "Select * From [Material Inventory] " &
                        "Where ([Material Inventory].[Type ID] = " & MatTypeID &
                        ") And ([Material Inventory].[Length] >= " & dCheckX &
                        ") And ([Material Inventory].[Width] >= " & dCheckY & " )  Order By [Material Inventory].Width, [Material Inventory].Length"

            dtMaterials = ConnectToCMDB(sql)

            If dtMaterials.Rows.Count > 0 Then

                For i = 0 To dtMaterials.Rows.Count - 1

                    s_MaterialBlank = dtMaterials.Rows(i).Item("Description")
                    n_MaterialID = dtMaterials.Rows(i).Item("ID")

                    cbBlankSize.Properties.Items.Add(New myItemData(s_MaterialBlank, n_MaterialID))

                Next

            End If

            cbBlankSize.SelectedIndex = 0

            DatabaseClose()

            dtMaterials.Dispose()

            dtMaterials = Nothing
        End If

    End Sub

    Private Sub txtWidth_Enter(sender As Object, e As EventArgs) Handles txtWidth.Enter
        txtWidth.SelectAll()
    End Sub

    Private Sub txtWidth_LostFocus(sender As Object, e As EventArgs) Handles txtWidth.LostFocus
        FindBlank()
    End Sub

    Private Sub txtHeight_Enter(sender As Object, e As EventArgs) Handles txtHeight.Enter
        txtHeight.SelectAll()

    End Sub

    Private Sub txtHeight_LostFocus(sender As Object, e As EventArgs) Handles txtHeight.LostFocus
        FindBlank()
    End Sub

    Private Sub sbCompileOld_Click(sender As Object, e As EventArgs)
        Dim PegBoardJava As String
        Dim PegBoardJavaNoNotch As String
        Dim MagPanelJava As String
        Dim sTheJavaFile As String

        Try

            Dim cmd As String


            PegBoardJava = RegGetString("Customizations", "PegBoardJava", App_Path & "\Macros\PegBoardMX_R2.java")
            PegBoardJavaNoNotch = RegGetString("Customizations", "PegBoardJavaNoNotch", App_Path & "\Macros\PegBoardMX_NoNotch.java")
            MagPanelJava = RegGetString("Customizations", "MagPanelJava", App_Path & "\Macros\MagPanelR2.java")


            If (rgProductType.SelectedIndex = 0) Then

                If (rgNotch.SelectedIndex = 0) Then
                    'MsgBox("Thejava is " & PegBoardJava)
                    sTheJavaFile = PegBoardJava

                    cmd = "Admin:MacroCompile:" &
                              " javafile=" & QStr(PegBoardJava)
                Else
                    sTheJavaFile = PegBoardJavaNoNotch
                    cmd = "Admin:MacroCompile:" &
                              " javafile=" & QStr(PegBoardJavaNoNotch)

                End If
            Else
                sTheJavaFile = MagPanelJava
                cmd = "Admin:MacroCompile:" &
                             " javafile=" & QStr(MagPanelJava)

            End If
            'lReturn = MessageBox.Show(cmd, "Error")

            lReturn = PortalExecute(cmd)

            If (lReturn < 1) Then
                cmd = "The macro (" & sTheJavaFile & ") failed to compile."
                lReturn = MessageBox.Show(cmd, "Error")
            Else

                cmd = "The macro (" & sTheJavaFile & ") compiled Sucessfuly."
                lReturn = MessageBox.Show(cmd, "Compiled Succesfuly")

            End If

        Catch ex As Exception
            MessageBox.Show("sbCompile_Click: " & ex.Message)
        End Try
    End Sub

    Private Function CheckIfRepoNeeded() As Boolean

        Dim PanelLength As Double

        PanelLength = HeaderDoubleGet("mac.proflen", 0)

        If (PanelLength > 99) Then

            CheckIfRepoNeeded = True

        End If

        'MessageBox.Show("The panel length is " & PanelLength)
    End Function

    Private Sub txtHeight_EditValueChanged(sender As Object, e As EventArgs) Handles txtHeight.EditValueChanged

    End Sub

    Private Sub txtQty_EditValueChanged(sender As Object, e As EventArgs) Handles txtQty.EditValueChanged

    End Sub

    Private Sub txtQty_Enter(sender As Object, e As EventArgs) Handles txtQty.Enter
        txtQty.SelectAll()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Private Sub sbAdd_Click(sender As Object, e As EventArgs) Handles sbAdd.Click
        Dim sMaterialType As String
        Dim sMatDesignator As String = ""
        Dim sPrintfilename As System.IO.StreamWriter
        Dim sMaterialSize As String
        Dim iPanelType As Integer
        Dim iLogo As Integer
        Dim iNotch As Integer
        Dim iPresser As Integer
        Dim iCorners As Integer
        Dim iHoles As Integer
        Dim sPartNameIndex As String
        Dim nRotation As Integer
        Dim nPreRotation As Integer
        Dim nNestSequenceNum As Integer
        Dim result As Integer
        Dim sNamingMode As Integer
        Dim sMonth As String
        Dim sDay As String
        Dim sYear As String



        'We used the following format for filenaming
        'YYYY.MM.DD.X.TTT.#
        '•	YYYY = Year
        '•	MM = Month
        '•	DD = Day
        '•	X = Metal
        'o	"G" for Galvanized Steel
        'o	"B" for Brushed Aluminum
        'o	"S" for Stainless Steel
        'o	"D" for Diamond Plate
        'o	etc
        '•	TTT = Thickness
        'o	030 = 0.030" thickness 
        'o	045 = 0.045" thickness 
        'o	125 = 0.125" thickness
        'o	etc
        '•	# = Program number in sequential order
        'o	1,2,3,4,5, 

        If (popupContainerEdit1.Text = "") Then
            MessageBox.Show(frmMain, "You need to select the material used for nesting", "Error!", vbOKOnly, 16)
            Exit Sub
        End If

        result = String.Compare(GetCurrentDay(), GetSavedDateInReg())

        If (result <> 0) Then

            SetSaveDateInReg(GetCurrentDay())
            nNestSequenceNum = 1
            sReturn = RegPutString("Customizations", "NestSequenceNum", 0)



        End If

        sPieces = (Split(popupContainerEdit1.Text, ","))
        sMaterialType = sPieces(0)
        sMaterialSize = sPieces(1)

        sMatPieces = (Split(sMaterialSize, " X "))
        sMaterialWidth = FormatNumber(sMatPieces(0), 3)
        sMaterialLength = FormatNumber(sMatPieces(1), 3)
        sMaterialThickness = FormatNumber(sMatPieces(2), 3)


        Select Case UCase(sMaterialType)
            Case "PEGBOARDMX_STAINLESS"
                sMatDesignator = "S"

            Case "PEGBOARDMX_GALVANIZED"
                sMatDesignator = "G"

            Case "PEGBOARDMX_STEEL_COLORS"
                sMatDesignator = “G.COLOR”

            Case "PEGBOARDMX_BRUSHED_ALUM_040"
                sMatDesignator = "B"

            Case "PEGBOARDMX_DIAMOND_ALUM_045"
                sMatDesignator = "D"

            Case "PEGBOARDMX_ALUM_COLORS"
                sMatDesignator = “B.COLOR”

            Case "PEGBOARDMX_DIAMOND_ALUM_063"
                sMatDesignator = "D"

            Case "MAGPANEL_STAINLESS"
                sMatDesignator = "S"

            Case "MAGPANEL_GALVANIZED"
                sMatDesignator = "G"

            Case "MAGPANEL_STEEL_COLORS"
                sMatDesignator = “B.COLOR”

        End Select

        Select Case UCase(cboRotation.Text)
            Case "ANY"
                nRotation = -2
                nPreRotation = 0

            Case "RAIL WITH HEIGHT"
                nRotation = 1
                nPreRotation = 90

            Case "RAIL WITH WIDTH"
                nRotation = 1
                nPreRotation = 0

        End Select

        If (rgProductType.SelectedIndex = 0) Then

            iLogo = rgLogo.SelectedIndex
            iNotch = rgNotch.SelectedIndex
            iPresser = rgPresser.SelectedIndex
            iCorners = -1
            iHoles = -1


        Else

            iLogo = -1
            iNotch = -1
            iPresser = rgPresser.SelectedIndex
            iCorners = rgCorner.SelectedIndex
            iHoles = rgMountingHoles.SelectedIndex

        End If

        If sbAdd.Text = "Create Nest" Then


            nNestSequenceNum = Val(RegGetString("Customizations", "NestSequenceNum", 0)) + 1
            'nNestSequenceNum = nNestSequenceNum + 1
            sReturn = RegPutString("Customizations", "NestSequenceNum", (nNestSequenceNum + 1))


            PDBFilename = Application.StartupPath & "\Nests\" & GetSavedDateInReg() & sMatDesignator & "_" & sMaterialThickness & "_" & (nNestSequenceNum) & ".pdb"

            sSheetName = Application.StartupPath & "\Nests\" & GetSavedDateInReg() & sMatDesignator & "_" & sMaterialThickness & "_" & (nNestSequenceNum) & "01.nst"



            sbAdd.Text = "Add To Nest"

            PathPDB_Set(PDBFilename)

            CreatePDB(PDBFilename)

            PopulateDefaultSettings()
            UpdateSetupTable(PDBFilename)
        Else
            PDBFilename = Application.StartupPath & "\Nests\" & GetSavedDateInReg() & sMatDesignator & "_" & sMaterialThickness & "_" & (nNestSequenceNum) & ".pdb"

            sSheetName = Application.StartupPath & "\Nests\" & GetSavedDateInReg() & sMatDesignator & "_" & sMaterialThickness & "_" & (nNestSequenceNum) & "01.nst"



        End If

        sNamingMode = RegGetInt("Customizations", "NamingMode", "0")

        If (sNamingMode = 0) Then



            If (rgProductType.SelectedIndex = 0) Then
                sPartNameIndex = App_Path & "\Models\" & txtWidth.Text & "_" & txtHeight.Text & "_X_" & txtItemNum.Text & ".mm2"
            Else
                sPartNameIndex = App_Path & "\Models\" & txtWidth.Text & "_" & txtHeight.Text & "_X_" & txtItemNum.Text & ".mm2"
            End If
        Else

            sPartNameIndex = App_Path & "\Models\" & txtOrderNum.Text & "_" & txtItemNum.Text & ".mm2"

        End If

        CreateNestPart(PathPDB(), sPartNameIndex)

        txtItemNum.Text = CInt(txtItemNum.Text) + 1

    End Sub
    Private Sub CreatePDB(m_pdb_filename As String)
        Dim pdb_name As String
        Dim sResultPath As String
        Dim l_MachineID As Long
        Dim l_LayerSetupID As Long
        Dim l_LeadSetupID As Long
        Dim l_ToolSetupid As Long
        Dim s_Machine As String
        Dim s_ToolSetup As String
        Dim l_Mat_ID As Long = -1
        Dim s_MatTypeDescrip As String
        Dim s_LeadSetup As String
        Dim s_LayerSetup As String
        Dim pdb_info As NESTDBINFO
        Dim sMaterialSize As String
        Dim sMaterialType As String
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dtMaterials As DataTable = Nothing
        Dim n_MatTypeID As Integer
        Dim dMaterialThicness As Double
        Dim dMatVals() As Double
        Dim dMatwidth As Decimal
        Dim dMatLength As Decimal
        Dim dMatThickness As Decimal

        Dim dTemp As Decimal
        Dim sdTemp As Object

        If (FileExists(m_pdb_filename) = True) Then
            Kill(m_pdb_filename)
        End If

        sPieces = (Split(popupContainerEdit1.Text, ","))
        sMaterialType = sPieces(0)
        s_MatDescrip = sPieces(1)

        sPieces = (Split(popupContainerEdit1.Text, ","))
        sMaterialType = sPieces(0)
        sMaterialSize = sPieces(1)

        sMatPieces = (Split(sMaterialSize, " X "))
        sMaterialWidth = FormatNumber(sMatPieces(0), 3)
        sMaterialLength = FormatNumber(sMatPieces(1), 3)
        sMaterialThickness = FormatNumber(sMatPieces(2), 3)
        n_MatTypeID = GetMatlTypeIDFromTypesDescription(sMaterialType)


        sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].[Type ID] = " & n_MatTypeID &
        ") And ([Material Inventory].Length = " & sMaterialLength & " ) And ([Material Inventory].Width = " & sMaterialWidth &
        ") And ([Material Inventory].Thickness = " & sMaterialThickness & " )"

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(ds)

        oledbAdapter.Dispose()

        connection.Close()

        If (ds.Tables(0).Rows.Count > 0) Then

            For i = 0 To ds.Tables(0).Rows.Count - 1

                l_Mat_ID = ds.Tables(0).Rows(i).Item("ID")

            Next


        End If

        If connection IsNot Nothing Then connection = Nothing
        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
        If ds IsNot Nothing Then ds = Nothing

        StoreGlobalVars(m_pdb_filename)
        sResultPath = Application.StartupPath & "\Nests\"
        s_Machine = RegGetString("Global", "Machine", "")
        l_MachineID = GetMachineIDFromDescrip(s_Machine)
        s_ToolSetup = RegGetString("Global", "ToolSetup", "")
        l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)
        s_LeadSetup = RegGetString("Global", "LeadSetup", "None")
        l_LeadSetupID = GetLeadSetupID(s_LeadSetup)
        s_LayerSetup = RegGetString("Global", "LayerSetup", "None")
        l_LayerSetupID = RegGetString("Global", "LayerSetupID", "0")

        pdb_name = m_pdb_filename

        pdb_info = InitPdbInfo(
            pdb_name, sResultPath, s_Machine, l_MachineID,
            s_ToolSetup, l_ToolSetupid, "", 0,
            s_LeadSetup, l_LeadSetupID,
            s_LayerSetup, l_LayerSetupID)

        If (EstablishPDB(pdb_info) = String.Empty) Then
            MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)
        Else
            PathPDB_Set(pdb_name)

            m_isVirginDB = False

        End If

        d_MatWeight = modMaterial.CheckMaterialWeight(l_Mat_ID)
        d_MatCost = GetMaterialCost(l_Mat_ID)

        AddMaterialToMaterialInventorys(m_pdb_filename, s_MatDescrip, l_Mat_ID, sMaterialLength, sMaterialWidth, sMaterialThickness, d_MatWeight, -1, d_MatCost)

    End Sub

    Private Sub StoreGlobalVars(m_pdb_filename As String)

        Dim folder As String

        PathPDB_Set(m_pdb_filename)

        folder = PathDriveFolder(PathPDB())

        If Len(folder) <> 0 Then
            RegPutString("Nesting", "Database", folder)

        Else
            PathPDB_Set(NormalizePath(RegGetString("Nesting", "Database", App_Path & "\Database\")) & PathPDB())
        End If

    End Sub

    Private Sub sbNest_Click(sender As Object, e As EventArgs) Handles sbNest.Click
        Dim cmd As String
        Dim sTemp As String
        Dim m_Length As Double
        Dim m_Width As Double
        Dim m_Thickness As Double
        Dim m_Quantity As Long
        Dim b_No_mat As Boolean = False
        Dim materialID As Long
        Dim bDebugGraphics As Boolean
        Dim machineID As Long
        Dim ToolSetupID As Long
        Dim lCount As Integer
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim stock_vis As Boolean
        Dim pdb_Node As TreeListNode
        Dim bMessageResult As Long

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, SplashFormStartPosition.Manual, New Point(Me.StartPosition()))
        SplashScreenManager.Default.SetWaitFormDescription("Creating Nest, Please Wait...")
        sbAdd.Text = "Create Nest"

        machineID = RegGetString("Global", "MachineID", 0)
        ToolSetupID = RegGetString("Global", "ToolSetupID", 0)
        materialID = RegGetString("Global", "MaterialID", 0)

        RegPutString("Nesting", "CreatePDB", 0)

        sTemp = NewModel("<nesting>", machineID, ToolSetupID, materialID, sMaterialLength, sMaterialWidth, sMaterialThickness)

        cmd = "nest:true:" &
                          " configdb=" & QStr(PathCMDB()) &
                          ",partdb=" & QStr(PathPDB()) &
                          ",display=" & IIf(bDebugGraphics, 1, 0)

        lReturn = PortalExecute(cmd)

        lReturn = modNesting.NestPostProc()


        SplashScreenManager.Default.SetWaitFormDescription("Process Compleate...")
        SplashScreenManager.CloseForm()
        frmNestResults.ShowDialog(frmMain)

        modView.ViewActivate(VIEW_WIRE)

        sReturn = ImportFile(sSheetName, sSheetName)

        frmMain.ShowCombos(sSheetName)

        txtQty.Text = "1"


    End Sub

    Private Sub popupContainerEdit1_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles popupContainerEdit1.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")

    End Sub

    Private Sub CreateMaterialTypeNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        Dim sql As String
        Dim ds As New System.Data.DataSet

        Dim s_MaterialCategory As String
        Dim n_MaterialID As Integer
        Dim i As Integer
        Dim dtMaterialType As System.Data.DataTable


        tl.BeginUnboundLoad()

        tl.ClearNodes()

        CFG_ROOT_NODE = Nothing


        CFG_MATERIAL_ROOT_NODE = tl.AppendNode(New Object() {"Materials"}, CFG_ROOT_NODE, TAG_MATERIAL_ROOT_NODE)

        s_MaterialCategory = ""

        sql = "Select [Material Types].* From [Material Types]"

        Try

            dtMaterialType = ConnectToCMDB(sql)


            For i = 0 To dtMaterialType.Rows.Count - 1
                s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")

                If InStr(UCase(s_MaterialCategory), UCase(sUsage)) Then
                    n_MaterialID = dtMaterialType.Rows(i).Item("ID")

                    CFG_MATERIAL_CATEGORY_NODE = tl.AppendNode(New Object() {s_MaterialCategory}, CFG_MATERIAL_ROOT_NODE, TAG_MATERIAL_CATEGORY_NODE)

                    FillMaterialNodes(n_MaterialID)

                    dtMaterialType.Dispose()
                End If

            Next

            tl.EndUnboundLoad()

        Catch ex As Exception

            MessageBox.Show("CreateMaterialTypeNodes: " & ex.Message)

        End Try

    End Sub

    Private Sub FillMaterialNodes(n_MaterialID As Long)
        Dim sql As String
        Dim ds As New System.Data.DataSet
        Dim s_MaterialDescription As String
        Dim i As Integer
        Dim dtMaterialNode As System.Data.DataTable

        s_MaterialDescription = ""

        sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].[Type ID] = " & n_MaterialID & " )"

        Try

            dtMaterialNode = ConnectToCMDB(sql)

            For i = 0 To dtMaterialNode.Rows.Count - 1
                s_MaterialDescription = dtMaterialNode.Rows(i).Item("Description")

                n_MaterialID = dtMaterialNode.Rows(i).Item("ID")

                CFG_MATERIAL_NODE = tl.AppendNode(New Object() {s_MaterialDescription}, CFG_MATERIAL_CATEGORY_NODE, TAG_MATERIAL_NODE & "," & n_MaterialID)

            Next
            tl.ExpandAll()

            dtMaterialNode.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillMaterialNodes: " & ex.Message)

        End Try

    End Sub

    Private Sub tl_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tl.FocusedNodeChanged
        Dim itemtype As Long
        Dim nCurr_Node_Tag As Long
        Dim sCurr_Display As String
        Dim sMaterialType As String
        Dim nTestNode

        Try

            If (e.Node IsNot Nothing) Then


                If (e.Node.ParentNode IsNot Nothing) Then

                    sMaterialType = e.Node.ParentNode.GetDisplayText(tl.Columns(0))
                    sCurr_Display = sMaterialType & ", " & e.Node.GetDisplayText(tl.Columns(0))
                    nCurr_Node_Tag = e.Node.Tag

                    popupContainerEdit1.EditValue = sCurr_Display ' e.Node.ParentNode.GetDisplayText(tl.Columns(1))
                    popupContainerEdit1.ClosePopup()

                End If
            End If

        Catch ex As Exception

            MessageBox.Show("tl_FocusedNodeChanged: " & ex.Message)

        End Try
    End Sub

    Private Sub CreateNestPart(sPdbName As String, sPartName As String)
        Dim nToolSetupID As Long = RegGetString("Global", "ToolSetupID", 0)
        Dim sFileName As String = App_Path & "\Models\Diamond.mm2"
        Dim nmachineID As Long = RegGetString("Global", "MachineID", 0)
        Dim nmaterialID As Long = modTranslate.GetDiamondMaterialIDFromTypeLenWidThick(popupContainerEdit1.Text)
        Dim dmaterialLength As Double = CDbl(modMaterial.GetMaterialLength(CLng(nmaterialID)))
        Dim dmaterialWidth As Double = CDbl(modMaterial.GetMaterialWidth(CLng(nmaterialID)))
        Dim dmaterialThickness As Double = CDbl(modMaterial.GetMaterialThickness(CLng(nmaterialID)))
        Dim sCgFile As String
        Dim sNCFile As String
        Dim nRotation As Integer
        Dim nPreRotation As Integer
        Dim sPartExtens As String


        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, SplashFormStartPosition.Manual, New Point(Me.StartPosition()))
        SplashScreenManager.Default.SetWaitFormDescription("Creating Panel, Please Wait...")

        If (cbBlankSize.Text = "") Then
            MsgBox("Can Not Find Any Material For The Given Height and Length", MsgBoxStyle.Critical)

        Else
            PathLOG_Set("C:\Program Files (x86)\WE-CIM\22.0\Debug\Debug.log")

            m_g_LogRecord = True

            lReturn = PortalExecute("cmdlog:file=" & QStr(PathLOG()))

            If (rgProductType.SelectedIndex = 0) Then
                sFileName = sPartName  'App_Path & "\Models\HPB_" & txtWidth.Text & "_" & txtHeight.Text & "_X.mm2"
            Else
                sFileName = sPartName  'App_Path & "\Models\HMB_" & txtWidth.Text & "_" & txtHeight.Text & "_X.mm2"
            End If

            'UndoPrepare()

            sReturn = RegPutString("Customizations", "MM2FileName", sFileName)

            sReturn = NewModel(sFileName, nmachineID, nToolSetupID, nmaterialID, dmaterialLength, dmaterialWidth, dmaterialThickness)

            popupContainerEdit1.Tag = nmaterialID

            sCgFile = RegGetString("Customizations", "NestCgJava", NormalizePath(Application.StartupPath) & "CodeGen\TRUMPF2020_DNest.java")

            RegPutString("Customizations", "SpecJava", NormalizePath(Application.StartupPath) & "CodeGen\TRUMPF2020_DNest.java")

            lReturn = HeaderStringSet("cgfile", sCgFile)

            PathCG_Set(sCgFile)

            sNCFile = RegGetString("Customizations", "SpecNcFile", NormalizePath(Application.StartupPath) & "CNC\1234.LST")

            lReturn = HeaderStringSet("ncfile", sNCFile)

            lReturn = HeaderDoubleSet("mac.Dia", TryCast(cbDIa.Properties.Items(cbDIa.SelectedIndex), myItemData).sItemData)

            'MsgBox("the blank size length is < " & dCheckX & " > and The width is <" & dCheckY & " >")

            If (rgProductType.SelectedIndex = 0) Then
                'MsgBox("We are creating < " & sFileName & " > which Is A Pegboard")
                CretePegBoardMX("Nest")
                ViewRegen()
                ViewFull()

                '
                'Me.Dispose()

            Else
                ' MsgBox("We are creating < " & sFileName & " > which Is A MagPanel")
                CreateMagPanel("Nest")
                ViewRegen()
                ViewFull()


            End If
            Select Case UCase(cboRotation.Text)
                Case "ANY"
                    nRotation = -2
                    nPreRotation = 0

                Case "RAIL WITH HEIGHT"
                    nRotation = 1
                    nPreRotation = 90

                Case "RAIL WITH WIDTH"
                    nRotation = 1
                    nPreRotation = 0

            End Select

            sPartExtens = CalculateDimensionsJustXY()

            AddPartToTable(sPdbName, sFileName, txtQty.Text, 0, nRotation, 0, sPartExtens)

            frmMain.SynchronizeUI(modSelection.SelectedCount())

            SplashScreenManager.Default.SetWaitFormDescription("Part Compleate...")
            SplashScreenManager.CloseForm()

            UndoCommit()

        End If
    End Sub

    Private Sub sbReset_Click(sender As Object, e As EventArgs) Handles sbReset.Click
        'sw.Close()
    End Sub


    Private Sub PopulateDefaultSettings()
        Dim currentCategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Dim myMachineList As MachineListCombo = New MachineListCombo()
        Dim sDefaultName As String = Nothing
        Dim s_Machine As String
        Dim s_ToolSetup As String
        Dim sResultPath As String
        Dim l_MachineID As Long
        Dim l_LayerSetupID As Long
        Dim l_LeadSetupID As Long
        Dim l_ToolSetupid As Long
        Dim l_Mat_ID As Long = -1
        Dim s_MatTypeDescrip As String
        Dim datfilename As String = Nothing
        Dim sTemplate As String = RegGetString("Nesting", "Template", "")

        Try
            If (b_ShowDefaultsDialog = False) Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, SplashFormStartPosition.Manual, New Point(Me.StartPosition()))
                SplashScreenManager.Default.SetWaitFormDescription("Creating Panel, Please Wait...")


            End If

            s_Machine = RegGetString("Global", "Machine", "")
            l_MachineID = GetMachineIDFromDescrip(s_Machine)
            s_ToolSetup = RegGetString("Global", "ToolSetup", "")
            l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)
            s_LeadSetup = RegGetString("Global", "LeadSetup", "None")
            l_LeadSetupID = GetLeadSetupID(s_LeadSetup)
            s_LayerSetup = RegGetString("Global", "LayerSetup", "None")
            l_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, l_MachineID)

            vgNestDefaults.SuspendLayout()
            vgNestDefaults.Rows.Clear()
            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.Template",
                                                                    "Template File",
                                                                    sTemplate,
                                                                    sTemplate,
                                                                    "Template",
                                                                    DB_HEADER,
                                                                    0,
                                                                    sEmpty, 0)

            currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgNestDefaults,
                                                                    "glb.Template",
                                                                    "Template",
                                                                    sTemplate,
                                                                    sTemplate,
                                                                    "Template",
                                                                    DB_FILE,
                                                                    0,
                                                                    "Template Files (*.template);*.template", 0))



            sDefaultName = RegGetString("MRP", "MRP_RESULT_FOLDER", App_Path & "\nests")

            currentCategoryRow.ChildRows.Add(CreateFileEditEditorRow(vgNestDefaults,
                                                                     "glb.ResultPath",
                                                                     "Result Path",
                                                                     sDefaultName,
                                                                     sDefaultName,
                                                                     "Result Path",
                                                                     DB_FOLDER,
                                                                     0,
                                                                     sEmpty, 0))

            arrMachine = PopulateComboList("SELECT * FROM [Machines]", True, False)

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.Machine",
                                                                         "Machines",
                                                                        s_Machine,
                                                                        m_machine_id,
                                                                        "Machine ID",
                                                                        DB_HEADER,
                                                                        0,
                                                                        sEmpty, 0)

            sDefaultName = RegGetString("Global", "Machine", "")

            s_Machine = sDefaultName

            m_machine_id = modMachine.GetMachineIDFromDescrip(s_Machine)

            If (m_machine_id < 1) Then
                s_Machine = "None"

            End If
            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults,
                                                                         "glb.Machine",
                                                                         "Machine",
                                                                        s_Machine,
                                                                        m_machine_id,
                                                                        "Machine ID",
                                                                        DB_MACHINE,
                                                                        0,
                                                                        arrMachine, 0))


            arrToolSetup = PopulateComboList("SELECT * FROM [Tool Setups] " &
                                             "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, False)

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.ToolSetupID",
                                                                         "Tool_Setup",
                                                                         s_ToolSetup,
                                                                         0,
                                                                         "Tool Setup ID", DB_HEADER,
                                                                         0, sEmpty, 0)

            Dim n_ToolSetupID As Integer
            sDefaultName = RegGetString("Global", "ToolSetup", "")
            s_ToolSetup = sDefaultName
            n_ToolSetupID = modTranslate.GetToolSetupIDFromDescription(s_ToolSetup)

            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults,
                                                                         "glb.ToolSetupID",
                                                                         "Tool Setup",
                                                                         s_ToolSetup,
                                                                         n_ToolSetupID,
                                                                         "Tool Setup ID",
                                                                         DB_TOOLSETUP,
                                                                         0,
                                                                         arrToolSetup, 0))

            arrLayerSetup = PopulateComboList("SELECT * FROM [Layer Setups] " &
                            "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, True)

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.LayerSetupID",
                                                                         "Layer_Setup",
                                                                         s_LayerSetup,
                                                                         0,
                                                                         "Layer Setup ID",
                                                                         DB_HEADER,
                                                                         0,
                                                                         sEmpty, 0)
            sDefaultName = RegGetString("Global", "LayerSetup", "None")

            Dim n_LayerSetupID As Integer = modTranslate.GetLayerSetupID(sDefaultName, m_machine_id)

            If (sDefaultName = String.Empty) Then
                sDefaultName = "None"
            End If

            s_LayerSetup = sDefaultName

            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults,
                                                                         "glb.LayerSetupID",
                                                                         "Layer Setup",
                                                                         s_LayerSetup,
                                                                         n_LayerSetupID,
                                                                         "Layer Setup ID",
                                                                         DB_LAYERSETUP,
                                                                         0,
                                                                         arrLayerSetup, 0))

            arrLeadSetup = PopulateComboList("SELECT * FROM [Lead Setup] ORDER BY [Description]", False, True)

            sDefaultName = RegGetString("Global", "LeadSetup", "None")

            Dim n_LeadSetupID As Integer

            If (sDefaultName = String.Empty) Then
                sDefaultName = "None"
            End If

            s_LeadSetup = sDefaultName
            n_LeadSetupID = modTranslate.GetLeadSetupID(s_LeadSetup)

            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults, "glb.LeadSetupID",
                                                                         "Lead Setup",
                                                                         s_LeadSetup,
                                                                         n_LeadSetupID,
                                                                         "Lead Setup ID",
                                                                         DB_LEADSETUP,
                                                                         0,
                                                                         arrLeadSetup, 0))


            If (FileExists(NormalizePath(App_Path) & s_Machine & ".dat") = True) Then


                If (Val(sMaterialLength) < 73) Then

                    'MsgBox("The material length is " & sMaterialLength)
                    datfilename = NormalizePath(App_Path) & s_Machine & "_72.dat"

                Else

                    datfilename = NormalizePath(App_Path) & s_Machine & ".dat"

                End If


            Else
                datfilename = RegGetDatFilePath()

            End If

            populateFromDatFile(vgNestDefaults, datfilename, currentCategoryRow, lbOptions)

            vgNestDefaults.BestFit()
            vgNestDefaults.ResumeLayout()

            SplashScreenManager.Default.SetWaitFormDescription("Process Compleate...")
            SplashScreenManager.CloseForm()

        Catch ex As Exception

            MessageBox.Show("PopulateDefaultSettings: " & ex.Message)

        End Try

    End Sub

    Private Sub UpdateSetupTable(m_pdb_filename As String)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtSettings.NewRow()
        Dim connetionString As String
        Dim cmdGetID As New OleDbCommand
        Dim sFieldName As String = ""
        Dim sFieldValue As String = ""
        Dim sMyTag As String

        Try

            my_DatVarName = Nothing
            my_DialogDisplay = Nothing
            my_VBValue = Nothing
            my_CValue = Nothing
            my_CVarName = Nothing
            tbFieldNames.Text = Nothing
            tbFieldValues.Text = Nothing

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            For Each row As DevExpress.XtraVerticalGrid.Rows.CategoryRow In vgNestDefaults.Rows

                For Each childRow As DevExpress.XtraVerticalGrid.Rows.EditorRow In row.ChildRows

                    If (UCase(childRow.Properties.Caption) <> "ID") Then
                        sMyTag = childRow.Tag

                        If (UCase(childRow.Properties.Caption) = "COLOR") Then

                            sFieldValue = ColorTranslator.ToOle(childRow.Properties.Value)

                            my_CValue = sFieldValue
                            my_VBValue = sFieldValue

                        Else

                            my_VBValue = GetValueFromDelimitedData(sMyTag, "VBValue", 0)
                            my_CValue = GetValueFromDelimitedData(sMyTag, "CValue", 0)

                        End If

                        my_DatVarName = GetValueFromDelimitedData(sMyTag, "DatVarName", 0)
                        my_DialogDisplay = GetValueFromDelimitedData(sMyTag, "DialogDisplay", 0)
                        my_CVarName = GetValueFromDelimitedData(sMyTag, "CVarName", 0)
                        my_DataType = GetValueFromDelimitedData(sMyTag, "VarDataType", 0)

                    End If

                    tbFieldNames.Text = "DatVarName, DialogDisplay, VBValue, CValue, CVarName"
                    tbFieldValues.Text = "'" & my_DatVarName & "','" & my_DialogDisplay & "','" & my_VBValue & "','" & my_CValue & "','" & my_CVarName & "'"

                    sql = "INSERT INTO [Setup] (" & tbFieldNames.Text & " ) VALUES(" & tbFieldValues.Text & ")"

                    m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                    m_daSettings.InsertCommand.ExecuteNonQuery()



                Next childRow

            Next row

            m_cnSettings.Close()

        Catch ex As Exception

            MessageBox.Show("UpdateSetupTable " & ex.Message)

        End Try
    End Sub

    Private Sub sbAdvNest_Click(sender As Object, e As EventArgs) Handles sbAdvNest.Click
        lReturn = appMain.ExecuteFunction(505)
    End Sub

    Private Sub sbCompile_Click(sender As Object, e As EventArgs) Handles sbCompile.Click
        Dim PegBoardJava As String
        Dim PegBoardJavaNoNotch As String
        Dim MagPanelJava As String
        Dim sTheJavaFile As String

        Try

            Dim cmd As String


            PegBoardJava = RegGetString("Customizations", "PegBoardJava", App_Path & "\Macros\PegBoardMX_R2.java")
            PegBoardJavaNoNotch = RegGetString("Customizations", "PegBoardJavaNoNotch", App_Path & "\Macros\PegBoardMX_NoNotch.java")
            MagPanelJava = RegGetString("Customizations", "MagPanelJava", App_Path & "\Macros\MagPanelR2.java")


            If (rgProductType.SelectedIndex = 0) Then

                If (rgNotch.SelectedIndex = 0) Then
                    'MsgBox("Thejava is " & PegBoardJava)
                    sTheJavaFile = PegBoardJava

                    cmd = "Admin:MacroCompile:" &
                              " javafile=" & QStr(PegBoardJava)
                Else
                    sTheJavaFile = PegBoardJavaNoNotch
                    cmd = "Admin:MacroCompile:" &
                              " javafile=" & QStr(PegBoardJavaNoNotch)

                End If
            Else
                sTheJavaFile = MagPanelJava
                cmd = "Admin:MacroCompile:" &
                             " javafile=" & QStr(MagPanelJava)

            End If
            'lReturn = MessageBox.Show(cmd, "Error")

            lReturn = PortalExecute(cmd)

            If (lReturn < 1) Then
                cmd = "The macro (" & sTheJavaFile & ") failed to compile."
                lReturn = MessageBox.Show(cmd, "Error")
            Else

                cmd = "The macro (" & sTheJavaFile & ") compiled Sucessfuly."
                lReturn = MessageBox.Show(cmd, "Compiled Succesfuly")

            End If

        Catch ex As Exception
            MessageBox.Show("sbCompile_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub popupContainerEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles popupContainerEdit1.EditValueChanged

    End Sub
End Class