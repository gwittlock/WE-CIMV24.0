Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraVerticalGrid.Rows
Public Class frmCCS_FAB_Setup
    Dim cFirstCell As Cell = Nothing
    Dim cSecondCell As Cell = Nothing
    Public m_XLS_Name As String
    Dim m_job_name As String
    Public sMRP_DB As String
    Dim s_Machine As String = String.Empty
    Dim s_ToolSetup As String = String.Empty
    Dim s_LayerSetup As String = String.Empty
    Dim s_LeadSetup As String = String.Empty
    Private m_is_active As Boolean

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function
    Private Sub chkShowDialog_CheckStateChanged(sender As Object, e As EventArgs) Handles chkShowDialog.CheckStateChanged

        If (chkShowDialog.CheckState = CheckState.Checked) Then

            RegPutString("Global", "ShowDialog", "1")
        Else
            RegPutString("Global", "ShowDialog", "0")
        End If

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click

        bDo_MRP_Nesting = False

        Me.Close()

    End Sub

    Private Sub sbOK_Click(sender As Object, e As EventArgs) Handles sbOK.Click

        ' Try
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If (chkShowDialog.CheckState = CheckState.Checked) Then

            RegPutString("Global", "ShowDialog", "0")


        Else

            RegPutString("Global", "ShowDialog", "1")

        End If

        b_ShowDefaultsDialog = CBool(RegGetString("Global", "ShowDialog", "0"))

        SetToolSetup(cbeToolSetup.Text, TryCast(cbeToolSetup.SelectedItem, myItemData).ItemData.ToString())
        SetLayerSetup(cbeLayerSetup.Text, TryCast(cbeLayerSetup.SelectedItem, myItemData).ItemData.ToString())
        SetLeadSetup(cbeLeadSetup.Text, TryCast(cbeLeadSetup.SelectedItem, myItemData).ItemData.ToString())
        SetMachine(cbeMachine.Text, TryCast(cbeMachine.SelectedItem, myItemData).ItemData.ToString())
        SetCutBackTool(cbeCutBackTool.Text, TryCast(cbeCutBackTool.SelectedItem, myItemData).ItemData.ToString())

        'MessageBox.Show("The length of the path is " & Len(PathXLSGet()))

        SpreadsheetControl1.LoadDocument(PathXLSGet(), DocumentFormat.Xls)

        m_XLS_Name = PathXLSGet()

        GetSpreadSheet()


        PopulateDefaultSettings()

        GetPDBNames()


        PathPDB_Set(sMRP_DB)

        bDo_MRP_Nesting = True

        frmMain.doNesting()


        'Catch ex As Exception

        'MessageBox.Show("sbOk_Click: " & ex.Message)

        'End Try

        Windows.Forms.Cursor.Current = Cursors.Default

        Me.Close()

    End Sub

    Private Sub frmCCS_FAB_Setup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmCCS_FAB_Setup_FormClosing(ender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        m_is_active = False
        Me.Dispose()
    End Sub
    Private Sub frmCCS_FAB_Setup_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim machineID As Long
        'Dim ToolSetupID As Long
        'Dim layersetupID As Long
        'Dim leadSetupID As Long
        'Dim toolID As Long

        m_is_active = True
        Try


            If (bShowSplash = True) Then
                SplashScreenManager.CloseForm()
                bShowSplash = False
            End If
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            GetAndSetCCSDefaults(cbeMachine, cbeLayerSetup, cbeLeadSetup, cbeToolSetup, cbeCutBackTool)


            'machineID = RegGetString("Global", "MachineID", 0)
            'layersetupID = RegGetString("Global", "LayerSetupID", 0)
            'leadSetupID = RegGetString("Global", "LeadSetupID", 0)
            'ToolSetupID = RegGetString("Global", "ToolSetupID", 0)
            'toolID = RegGetString("Global", "CutBack Tool", 0)

            'modProject.InitMachineList(cbeMachine, machineID)
            'modProject.InitToolSetupList(cbeToolSetup, machineID, ToolSetupID)
            'modProject.InitLayerSetupList(cbeLayerSetup, machineID, layersetupID)
            'modProject.InitLeadSetupList(cbeLeadSetup, leadSetupID)
            'modProject.InitCutBackToolList(cbeCutBackTool, toolID, ToolSetupID)


            EnableOkButton()

            'Show the proper icon for the app
            lReturn = SetFormIcon(Me)

            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Update()


            If (IS_CCS_FAB_SILENT = True) Then
                'sbOK_Click(sender, New System.EventArgs())

            End If

        Catch ex As Exception

            MessageBox.Show("frmCCS_FAB_Setup_Load: " & ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub EnableOkButton()

        'NOTE: lcbLayerSetup[0] is "(None)"
        sbOK.Enabled = _
            ((cbeLayerSetup.SelectedIndex <> 0) And _
             (cbeToolSetup.Text <> ""))

    End Sub

    Private Sub cbeMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMachine.SelectedIndexChanged

        Try

            If (cbeMachine.SelectedIndex > -1) Then
                Dim machineid As Long = (TryCast(cbeMachine.SelectedItem, myItemData).ItemData.ToString())

                modProject.InitToolSetupList(cbeToolSetup, machineid, 0)
                modProject.InitLayerSetupList(cbeLayerSetup, machineid, 0)
            End If

            EnableOkButton()

        Catch ex As Exception

            MessageBox.Show("cbeMachine_SelectedIndexChanged: " & ex.Message)

        End Try

    End Sub

    Private Sub cbeLayerSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeLayerSetup.SelectedIndexChanged
        EnableOkButton()
    End Sub

    Private Sub cbeToolSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeToolSetup.SelectedIndexChanged
        Dim ToolSetupID As Long
        Dim toolid As Long

        Try

            If (cbeToolSetup.SelectedIndex > 0) Then

                ToolSetupID = (TryCast(cbeToolSetup.SelectedItem, myItemData).ItemData.ToString())

                toolid = RegGetString("Global", "CutBack Tool", 0)

                modProject.InitCutBackToolList(cbeCutBackTool, toolid, ToolSetupID)
            End If

            EnableOkButton()

        Catch ex As Exception

            MessageBox.Show("cbeToolSetup_SelectedIndexChanged: " & ex.Message)

        End Try
    End Sub

    Public Sub GetSpreadSheet()
        Dim workbook As IWorkbook = SpreadsheetControl1.Document
        Dim ni As Integer
        Dim sWorkSheetTable As String = "Pieces"
        Dim sFirstCell As String = "Material"
        Dim sSecondCell As String = "Gauge"

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            If (b_ShowDefaultsDialog = False) Then
                SplashScreenManager.Default.SetWaitFormDescription("Sorting Materials...")
            End If



            For ni = 0 To workbook.Worksheets.Count - 1

                If (workbook.Worksheets(ni).Name <> sWorkSheetTable) Then

                    workbook.Worksheets(ni).VisibilityType = WorksheetVisibilityType.VeryHidden

                End If
            Next
            workbook.Worksheets.ActiveWorksheet = workbook.Worksheets(sWorkSheetTable)
            workbook.Worksheets.ActiveWorksheet.Columns.AutoFit(0, workbook.Worksheets.ActiveWorksheet.Columns.LastUsedIndex)
            SpreadsheetControl1.Document.Worksheets(sWorkSheetTable).FreezeRows(0)

            SetFrozenRowColor()

            Dim worksheet As Worksheet = workbook.Worksheets(sWorkSheetTable)
            workbook.BeginUpdate()

            Dim dataRange As Range = worksheet.GetDataRange()
            Dim sortRange As Range = worksheet.Range.FromLTRB(dataRange.LeftColumnIndex, dataRange.TopRowIndex + 1, dataRange.RightColumnIndex, dataRange.BottomRowIndex)
            Dim sortCriteria As New List(Of SortField)()

            cFirstCell = worksheet.Search(sFirstCell).FirstOrDefault()
            sortCriteria.Add(New SortField() With {.ColumnOffset = cFirstCell.LeftColumnIndex, .Comparer = worksheet.Comparers.Ascending})

            cSecondCell = worksheet.Search(sSecondCell).FirstOrDefault()
            sortCriteria.Add(New SortField() With {.ColumnOffset = cSecondCell.LeftColumnIndex, .Comparer = worksheet.Comparers.Ascending})

            worksheet.Sort(sortRange, sortCriteria)
            workbook.EndUpdate()

        Catch ex As Exception

            MessageBox.Show("GetSpreadSheet: " & ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
    Public Sub GetPDBNames()

        Dim pdb_store_name As String = Nothing
        Dim pdb_name As String
        Dim pdb_path As String
        Dim pdb_Path_Filename As String = Nothing
        Dim LabelDBName As String
        Dim cat As ADOX.Catalog = New ADOX.Catalog()
        Dim ws As Worksheet
        Dim workbook As IWorkbook
        Dim cMyFirstCell As Cell
        Dim cMySecondCell As Cell
        Dim cMyThirdCell As Cell
        Dim cMyFourthCell As Cell
        Dim cMyFifthCell As Cell
        Dim sMyFirstCellText As String
        Dim sMySecondCellText As String
        Dim range As Range
        Dim pdb_info As NESTDBINFO
        Dim sResultPath As String
        Dim l_MachineID As Long
        Dim l_LayerSetupID As Long
        Dim l_LeadSetupID As Long
        Dim l_ToolSetupid As Long
        Dim l_Mat_ID As Long = -1
        Dim s_MatTypeDescrip As String
        Dim nSpreadSheetRowCnt As Long
        Dim nSi As Integer = 0

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            pdb_path = PathDriveFolder(m_XLS_Name) & "\"

            LabelDBName = NormalizePath(PathDriveFolder(m_XLS_Name)) & "labeldb.mdb"

            'Clean up labeldb file if needed
            If (FileExists(LabelDBName) = True) Then

                ConditionalFileDelete(LabelDBName)

            End If

            sReturn = PathCNC_Set(NormalizePath(PathDriveFolder(m_XLS_Name)))


            m_job_name = "Job " & PathFile(m_XLS_Name)

            sMRP_DB = NormalizePath(PathDriveFolder(m_XLS_Name)) & PathFile(m_XLS_Name) & ".mrp"

            If (FileExists(sMRP_DB) = True) Then

                ConditionalFileDelete(sMRP_DB)

            End If

            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                               "Data Source=" & sMRP_DB & ";" & _
                               "Jet OLEDB:Engine Type=5")

            cat.ActiveConnection.close()

            modNesting.MRPDBNAME = sMRP_DB

            CreateMRPTable(sMRP_DB)


            sResultPath = NormalizePath(PathDriveFolder(sMRP_DB))
            s_Machine = RegGetString("Global", "Machine", "")
            l_MachineID = GetMachineIDFromDescrip(s_Machine)
            s_ToolSetup = RegGetString("Global", "ToolSetup", "")
            l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)
            s_LeadSetup = RegGetString("Global", "LeadSetup", "None")
            l_LeadSetupID = GetLeadSetupID(s_LeadSetup)
            s_LayerSetup = RegGetString("Global", "LayerSetup", "None")
            l_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, l_MachineID)

            ws = SpreadsheetControl1.ActiveWorksheet
            workbook = SpreadsheetControl1.Document

            cMyFirstCell = ws.Search("Material").FirstOrDefault()
            cMySecondCell = ws.Search("Gauge").FirstOrDefault()
            cMyThirdCell = ws.Search("Length").FirstOrDefault()
            cMyFourthCell = ws.Search("Width").FirstOrDefault()
            cMyFifthCell = ws.Search("Thickness").FirstOrDefault()

            range = ws.GetDataRange()

            nSpreadSheetRowCnt = range.RowCount

            ProgressBarControl1.Properties.Maximum = nSpreadSheetRowCnt


            For i As Integer = range.TopRowIndex + 1 To range.BottomRowIndex

                nSi += 1

                ProgressBarControl1.EditValue = nSi
                ProgressBarControl1.Update()

                sMyFirstCellText = ws.Rows(i).Item(cMyFirstCell.ColumnIndex).Value.TextValue

                sMySecondCellText = ws.Rows(i).Item(cMySecondCell.ColumnIndex).Value.TextValue

                s_MatTypeDescrip = ws.Rows(i).Item(cMyFirstCell.ColumnIndex).Value.TextValue


                If (cMyThirdCell IsNot Nothing) Then
                    d_MatLength = CDbl(ws.Rows(i).Item(cMyThirdCell.ColumnIndex).Value.TextValue)
                End If

                If (cMyFourthCell IsNot Nothing) Then
                    d_MatWidth = CDbl(ws.Rows(i).Item(cMyFourthCell.ColumnIndex).Value.TextValue)
                End If


                If (cMyFourthCell IsNot Nothing) Then
                    d_MatThickness = CDbl(ws.Rows(i).Item(cMyFifthCell.ColumnIndex).Value.TextValue)
                End If


                If (i = 1) Then

                    ' If (IS_CCS_FAB = True) Then

                    pdb_store_name = sMyFirstCellText & " " & sMySecondCellText & " GA."

                    'End If

                    pdb_name = pdb_store_name
                    pdb_Path_Filename = pdb_path & Replace(pdb_name, ".", ".pdb")

                    AddPdbToTable(sMRP_DB, pdb_Path_Filename)

                    If (FileExists(pdb_Path_Filename) = True) Then

                        ConditionalFileDelete(pdb_Path_Filename)

                    End If

                    pdb_info = InitPdbInfo( _
                                pdb_Path_Filename, sResultPath, s_Machine, l_MachineID, _
                                s_ToolSetup, l_ToolSetupid, "", 0, _
                                s_LeadSetup, l_LeadSetupID, _
                                s_LayerSetup, l_LayerSetupID)

                    If (EstablishPDB(pdb_info) = String.Empty) Then

                        MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)

                    Else

                        l_Mat_ID = GetTheMaterialIDFromXlS(pdb_Path_Filename, s_MatTypeDescrip, d_MatLength, d_MatWidth, d_MatThickness)

                        If (l_Mat_ID > 0) Then
                            's_MatDescrip = GetMaterialDescription(l_Mat_ID)

                            AddMaterialToMaterialInventorys(pdb_Path_Filename, s_MatDescrip, l_Mat_ID, d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight, d_MatQty, d_MatCost)
                        End If

                        UpdateSetupTable(pdb_Path_Filename, vgNestDefaults, s_MatDescrip, False, False)

                    End If


                Else
                    pdb_name = sMyFirstCellText & " " & sMySecondCellText & " GA."

                    If (pdb_name <> pdb_store_name) Then

                        pdb_Path_Filename = pdb_path & Replace(pdb_name, ".", ".pdb")

                        PathPDB_Set(pdb_Path_Filename)

                        pdb_store_name = pdb_name

                        AddPdbToTable(sMRP_DB, pdb_Path_Filename)

                        If (FileExists(pdb_Path_Filename) = True) Then

                            ConditionalFileDelete(pdb_Path_Filename)

                        End If

                        pdb_info = InitPdbInfo( _
                                    pdb_Path_Filename, sResultPath, s_Machine, l_MachineID, _
                                    s_ToolSetup, l_ToolSetupid, "", 0, _
                                    s_LeadSetup, l_LeadSetupID, _
                                    s_LayerSetup, l_LayerSetupID)


                        If (EstablishPDB(pdb_info) = String.Empty) Then

                            MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)

                        Else

                            l_Mat_ID = GetTheMaterialIDFromXlS(pdb_Path_Filename, s_MatTypeDescrip, d_MatLength, d_MatWidth, d_MatThickness)

                            AddMaterialToMaterialInventorys(pdb_Path_Filename, s_MatDescrip, l_Mat_ID, d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight, d_MatQty, d_MatCost)

                            UpdateSetupTable(pdb_Path_Filename, vgNestDefaults, s_MatDescrip, False, False)
                        End If

                    End If

                End If

                If (l_Mat_ID > 0) Then
                    If (IS_CCS_FAB = True) Then
                        LabelControl1.Text = "Converting Part: " & ws.Rows(i).Item(0).Value.TextValue

                        LabelControl1.Update()

                        AddBMPart(pdb_Path_Filename, i, SpreadsheetControl1)

                    End If

                End If

            Next

        Catch ex As Exception

            MessageBox.Show("GetPDBNames: " & ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
    Private Sub CreateMRPTable(sMRP_DBName As String)
        Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & sMRP_DBName)
        Dim sTablename As String = "PDB_Files"
        Dim ds As New DataSet
        Dim dt1 As DataTable = ds.Tables("PDB_Files")
        Dim sql As String = "SELECT * FROM PDB_Files"

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            connection.Open()

            'Get database schema 
            Dim dbSchema As DataTable = connection.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, sTablename, "TABLE"})

            connection.Close()

            ' If the table exists, the count = 1 
            If dbSchema.Rows.Count > 0 Then
                ' do whatever you want to do if the table exists 
            Else
                'do whatever you want to do if the table does not exist 
                ' e.g. create a table 
                Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename & _
                                                  "] ([ID] AUTOINCREMENT , " & _
                                                  "[PDB_Name] TEXT(255) )", connection)
                connection.Open()
                cmd.ExecuteNonQuery()

                connection.Close()

            End If

        Catch ex As Exception

            MessageBox.Show("CreateMRPTable: " & ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub SetFrozenRowColor()

        Dim formatting As DevExpress.Spreadsheet.Formatting = SpreadsheetControl1.ActiveWorksheet.Rows(0).BeginUpdateFormatting()
        Dim skin As Skin = CommonSkins.GetSkin(UserLookAndFeel.Default)

        formatting.Fill.BackgroundColor = skin.Colors.GetColor(CommonColors.ReadOnly)

        SpreadsheetControl1.ActiveWorksheet.Rows(0).EndUpdateFormatting(formatting)

    End Sub
    Public Sub PopulateDefaultSettings()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim myMachineList As MachineListCombo = New MachineListCombo()
        Dim sDefaultName As String = Nothing

        Dim datfilename As String = Nothing
        Dim sTemplate As String = RegGetString("Nesting", "Template", "")

        Try
            If (b_ShowDefaultsDialog = False) Then

                SplashScreenManager.Default.SetWaitFormDescription("Loading the Nesting defaults...")

            End If

            vgNestDefaults.SuspendLayout()
            vgNestDefaults.Rows.Clear()
            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.Template", _
                                                                    "Template File", _
                                                                    sTemplate, _
                                                                    sTemplate, _
                                                                    "Template", _
                                                                    DB_HEADER, _
                                                                    0, _
                                                                    sEmpty, 0)

            currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgNestDefaults, _
                                                                    "glb.Template", _
                                                                    "Template", _
                                                                    sTemplate, _
                                                                    sTemplate, _
                                                                    "Template", _
                                                                    DB_FILE, _
                                                                    0, _
                                                                    "Template Files (*.template);*.template", 0))



            sDefaultName = RegGetString("MRP", "MRP_RESULT_FOLDER", App_Path & "\nests")

            currentCategoryRow.ChildRows.Add(CreateFileEditEditorRow(vgNestDefaults, _
                                                                     "glb.ResultPath", _
                                                                     "Result Path", _
                                                                     sDefaultName, _
                                                                     sDefaultName, _
                                                                     "Result Path", _
                                                                     DB_FOLDER, _
                                                                     0, _
                                                                     sEmpty, 0))

            arrMachine = PopulateComboList("SELECT * FROM [Machines]", True, False)

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.Machine", _
                                                                         "Machines", _
                                                                        s_Machine, _
                                                                        m_machine_id,
                                                                        "Machine ID", _
                                                                        DB_HEADER, _
                                                                        0, _
                                                                        sEmpty, 0)

            sDefaultName = RegGetString("Global", "Machine", "")

            s_Machine = sDefaultName

            m_machine_id = modMachine.GetMachineIDFromDescrip(s_Machine)

            If (m_machine_id < 1) Then
                s_Machine = "None"

            End If
            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults, _
                                                                         "glb.Machine", _
                                                                         "Machine", _
                                                                        s_Machine, _
                                                                        m_machine_id,
                                                                        "Machine ID", _
                                                                        DB_MACHINE, _
                                                                        0, _
                                                                        arrMachine, 0))


            arrToolSetup = PopulateComboList("SELECT * FROM [Tool Setups] " & _
                                             "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, False)

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.ToolSetupID", _
                                                                         "Tool_Setup", _
                                                                         s_ToolSetup, _
                                                                         0, _
                                                                         "Tool Setup ID", DB_HEADER, _
                                                                         0, sEmpty, 0)

            Dim n_ToolSetupID As Integer
            sDefaultName = RegGetString("Global", "ToolSetup", "")
            s_ToolSetup = sDefaultName
            n_ToolSetupID = modTranslate.GetToolSetupIDFromDescription(s_ToolSetup)

            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults, _
                                                                         "glb.ToolSetupID", _
                                                                         "Tool Setup", _
                                                                         s_ToolSetup, _
                                                                         n_ToolSetupID, _
                                                                         "Tool Setup ID", _
                                                                         DB_TOOLSETUP, _
                                                                         0, _
                                                                         arrToolSetup, 0))

            arrLayerSetup = PopulateComboList("SELECT * FROM [Layer Setups] " & _
                            "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, True)

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.LayerSetupID", _
                                                                         "Layer_Setup",
                                                                         s_LayerSetup, _
                                                                         0, _
                                                                         "Layer Setup ID", _
                                                                         DB_HEADER, _
                                                                         0, _
                                                                         sEmpty, 0)
            sDefaultName = RegGetString("Global", "LayerSetup", "None")

            Dim n_LayerSetupID As Integer = modTranslate.GetLayerSetupID(sDefaultName, m_machine_id)

            If (sDefaultName = String.Empty) Then
                sDefaultName = "None"
            End If

            s_LayerSetup = sDefaultName

            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults, _
                                                                         "glb.LayerSetupID", _
                                                                         "Layer Setup",
                                                                         s_LayerSetup, _
                                                                         n_LayerSetupID, _
                                                                         "Layer Setup ID", _
                                                                         DB_LAYERSETUP, _
                                                                         0, _
                                                                         arrLayerSetup, 0))

            arrLeadSetup = PopulateComboList("SELECT * FROM [Lead Setup] ORDER BY [Description]", False, True)

            sDefaultName = RegGetString("Global", "LeadSetup", "None")

            Dim n_LeadSetupID As Integer

            If (sDefaultName = String.Empty) Then
                sDefaultName = "None"
            End If

            s_LeadSetup = sDefaultName
            n_LeadSetupID = modTranslate.GetLeadSetupID(s_LeadSetup)

            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestDefaults, "glb.LeadSetupID", _
                                                                         "Lead Setup", _
                                                                         s_LeadSetup, _
                                                                         n_LeadSetupID, _
                                                                         "Lead Setup ID", _
                                                                         DB_LEADSETUP, _
                                                                         0, _
                                                                         arrLeadSetup, 0))


            If (FileExists(NormalizePath(App_Path) & s_Machine & ".dat") = True) Then
                datfilename = NormalizePath(App_Path) & s_Machine & ".dat"
            Else
                datfilename = RegGetDatFilePath()

            End If

            populateFromDatFile(vgNestDefaults, datfilename, currentCategoryRow, lbOptions)

            vgNestDefaults.BestFit()
            vgNestDefaults.ResumeLayout()

        Catch ex As Exception

            MessageBox.Show("PopulateDefaultSettings: " & ex.Message)

        End Try

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bDo_MRP_Nesting = False

    End Sub
End Class