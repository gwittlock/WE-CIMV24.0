Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Nodes.Operations
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.Data.OleDb
Public Class frmNestingProtoType
    Private WithEvents repositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private m_pdb_filename As String = Nothing
    Private m_last_Mode As Long
    Public m_code_gen As String
    Private m_is_active As Boolean
    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_SETTINGS_NODE As TreeListNode
    Private CFG_PARAMETERS_NODE As TreeListNode
    Private CFG_PARTS_NODE As TreeListNode
    Private CFG_MATERIAL_NODE As TreeListNode
    Private CFG_RESULTS_NODE As TreeListNode
    Private CFG_RESULT_MAT_NODE As TreeListNode
    Private CFG_RESULTS_SHEET As TreeListNode
    Private CFG_RESULTS_PART As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode


    Private Const TAG_ROOT_NODE = 0
    Private Const TAG_SETTINGS_NODE = -100
    Private Const TAG_PARAMETERS_NODE = -101
    Private Const TAG_PARTS_NODE = -102
    Private Const TAG_MATERIAL_NODE = -103
    Private Const TAG_RESULTS_NODE = -104
    Private Const TAG_RESULTS_MAT_NODE = -105
    Private Const TAG_RESULTS_SHEET = -106
    Private Const TAG_RESULTS_PART = -107
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201

    Public arrMachine As Collection
    Public arrToolSetup As Collection
    Public arrLeadSetup As Collection
    Public arrLayerSetup As Collection
    Public arrOptions As Collection
    Public rowRemnantInentory As CategoryRow

    Private s_Machine As String = String.Empty
    Private s_ToolSetup As String = String.Empty
    Private s_LayerSetup As String = String.Empty
    Private s_LeadSetup As String = String.Empty

    Private m_isVirginDB As Boolean
    Private bFromCreateNodes As Boolean
    Private m_current_part As String

    Private m_is_view_initialized As Boolean
    Private bFromAddButton As Boolean
    Private bEmptyPdb As Boolean

    Private editValue As String
    Private nRowIndx As Integer
    Private nRowId As BaseRow
    Private nToolSetupRowId As BaseRow
    Private nLayerSetupRowID As BaseRow
    Private SelectedMachineName As String
    Private SelectedToolSetupName As String
    Private SelectedLayerSetupName As String
    Private ArePartsLoaded As Boolean

    Delegate Sub FocusTextHandler(ByRef VerticalGrid)
    Private m_currRecordID As Long
    Private m_searchString As String
    Private m_searchIndex As Integer

    Private bFromMrp As Boolean
    Private m_ncfile As String

    Private sPortalCommand As String
    Public Sub SetPortalCommand(sCmd As String)
        sPortalCommand = sCmd

    End Sub
    Public Sub CodeGenPurge()
        m_code_gen = NEED_CODEGEN
    End Sub

    Private Sub frmNestingProtoType_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMain.CloseFirstPanel()
        m_is_nesting = False


    End Sub


    Public Sub New()

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        ' This call is required by the designer.
        InitializeComponent()
        repositoryItemButtonEdit = New RepositoryItemButtonEdit()
        ' Add any initialization after the InitializeComponent() call.

        pcPDBSettings.Visible = False
        pcParts.Visible = False
        pcMaterial.Visible = False
        pcResults.Visible = False
        m_is_view_initialized = False
        bEmptyPdb = False
        m_is_nesting = True
        Me.SuspendLayout()

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If (IS_CCS_FAB = False) Then

            pnlXLSFilename.Visible = False

            'frmCCS_FAB_Setup.ShowDialog(frmMain)

        End If

        m_pdb_filename = PathPDB()

        If (FileExists(m_pdb_filename) = True) Then

            m_isVirginDB = False

            LoadPDB(m_pdb_filename)
        Else

            'Dim result = MessageBox.Show("Nesting Database: " & m_pdb_filename & _
            '                            " Does Not Exist!" & Environment.NewLine & Environment.NewLine & _
            '                           "Would you like to create a new database?", _
            '                          "Nest Databse Does Not Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            '
            'If (result = DialogResult.No) Then

            'bEmptyPdb = True
            'Else
            'CreateNewPDB()
            'End If


        End If

        m_is_active = True

        Me.ResumeLayout()

        Windows.Forms.Cursor.Current = Cursors.Default

        Me.Focus()

    End Sub

    Private Sub bbNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Dim Pdb_FileSave As New SaveFileDialog

        Pdb_FileSave.Filter = "PDB files (*.pdb)|*.pdb"
        Pdb_FileSave.FilterIndex = 1
        'Pdb_FileSave.RestoreDirectory = True
        Pdb_FileSave.InitialDirectory = PathNestFolder()

        If Pdb_FileSave.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            m_pdb_filename = Pdb_FileSave.FileName

            Pdb_FileSave.Dispose()

            ConditionalFileDelete(m_pdb_filename)

            PathPDB_Set(m_pdb_filename)


            CreateNewPDB()
            frmMain.doNesting()


        Else
            Me.Dispose()
        End If



    End Sub

    Private Sub CreateRootNodes(ByVal tl As DevExpress.XtraTreeList.TreeList, sPDB_Name As String)
        Dim pdb_displayname As String
        Dim sPdb_Name_Tag As String



        pdb_displayname = PathFileExt(sPDB_Name)

        bFromCreateNodes = True
        tl.ClearNodes()

        CFG_ROOT_NODE = tl.AppendNode(New Object() {"Job(s)"}, 0)
        CFG_ROOT_NODE.Tag = 0

        'use the tag field to store boithe the node type tag and the pdb filename.
        ' we will then parse out the pdbname from the tag when needed for opening the database

        sPdb_Name_Tag = TAG_SETTINGS_NODE & "," & sPDB_Name

        CFG_SETTINGS_NODE = tl.AppendNode(New Object() {pdb_displayname}, CFG_ROOT_NODE, sPdb_Name_Tag)

        CFG_PARTS_NODE = tl.AppendNode(New Object() {"Parts"}, CFG_SETTINGS_NODE, TAG_PARTS_NODE)
        CFG_MATERIAL_NODE = tl.AppendNode(New Object() {"Material"}, CFG_SETTINGS_NODE, TAG_MATERIAL_NODE)
        CFG_RESULTS_NODE = tl.AppendNode(New Object() {"Results (Pending)"}, CFG_SETTINGS_NODE, TAG_RESULTS_NODE)

        For Each column As DevExpress.XtraTreeList.Columns.TreeListColumn In TV_NestConfig.Columns
            column.OptionsColumn.AllowMove = False
        Next

        CFG_ROOT_NODE.Expanded = True
        CFG_SETTINGS_NODE.Expanded = True
        tl.FocusedNode = CFG_SETTINGS_NODE


        Dim crPartVarHeader As CategoryRow = Nothing
        vgPartVars.Rows.Clear()

        crPartVarHeader = CreateCategoryRow(vgPartVars, "Part Varables", "Part Variables", "Part Variables", "Part Variables", "Part Variables", DB_HEADER, 0, sEmpty, 0)

        CreatePartDefaultValues(crPartVarHeader, 0, 0, True)

        Dim crPartResultVarHeader As CategoryRow = Nothing
        vgPartResults.Rows.Clear()

        crPartResultVarHeader = CreateCategoryRow(vgPartResults, "Part Varables", "Part Variables", "Part Variables", "Part Variables", "Part Variables", DB_HEADER, 0, sEmpty, 0)

        CreatePartResultValues(crPartResultVarHeader, 0, 0, True)

    End Sub

    Private Function TreeItemType(nNode As TreeListNode) As Long

        Dim Parent As TreeListNode
        Dim itemTag As Long
        Dim sPieces() As String

        Try

            Parent = nNode.ParentNode

            'If the parent node is the pdb name node then we need to parse the node type and full pdb name
            sPieces = Split(Parent.Tag, ",")

            If (sPieces.Length > 1) Then
                itemTag = sPieces(0)
            Else

                itemTag = Parent.Tag

            End If

            itemTag = itemTag '- 1

            TreeItemType = itemTag

        Catch ex As ArgumentException

            MessageBox.Show(ex.Message)

        End Try


    End Function

    Private Sub HideControls(nTheMode As Long)

        Dim sNestedSheetName As String
        Dim spieces() As String
        Dim er_SelectedMaterialRow As EditorRow

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        pcCodeViewer.Visible = False
        pcPDBSettings.Visible = False
        pcParts.Visible = False
        pcMaterial.Visible = False
        pcResults.Visible = False
        pcPartResults.Visible = False
        sbTestingButton.Enabled = False
        sbExportCNC.Enabled = False
        sbCodeViewer.Enabled = False


        Select Case nTheMode

            Case TAG_ROOT_NODE

                cmdBuild.Text = "Build All"
                sbExportCNC.Enabled = True

            Case TAG_SETTINGS_NODE
                cmdBuild.Text = "Build Current"
                sbExportCNC.Enabled = True

                CFG_SETTINGS_NODE = TV_NestConfig.FocusedNode

                spieces = Split(TV_NestConfig.FocusedNode.Tag, ",")

                If (spieces.Length > 1) Then
                    m_pdb_filename = spieces(1)

                    PathPDB_Set(m_pdb_filename)

                    modNesting.SetupInfoGet(PathPDB())

                    PopulateDefaultSettings()
                    GetSetupValuesFromPDB()


                End If

                pcPDBSettings.Visible = True

            Case TAG_PARTS_NODE
                sbExportCNC.Enabled = False

                Dim crPartVarHeader As CategoryRow = Nothing
                vgPartVars.Rows.Clear()

                crPartVarHeader = CreateCategoryRow(vgPartVars, "Part Varables", "Part Variables", "Part Variables", "Part Variables", "Part Variables", DB_HEADER, 0, sEmpty, 0)

                CreatePartDefaultValues(crPartVarHeader, 0, 0, True)

                pcParts.Visible = True

                If (ArePartsLoaded = False Or bFromMrp = True) Then

                    spieces = Split(TV_NestConfig.FocusedNode.ParentNode.Tag, ",")

                    If (spieces.Length > 1) Then

                        m_pdb_filename = spieces(1)
                        PathPDB_Set(m_pdb_filename)

                    End If

                    LoadPartsFromDB()

                    ArePartsLoaded = True
                End If


            Case TAG_MATERIAL_NODE
                sbExportCNC.Enabled = False
                spieces = Split(TV_NestConfig.FocusedNode.ParentNode.Tag, ",")

                If (spieces.Length > 1) Then

                    m_pdb_filename = spieces(1)
                    PathPDB_Set(m_pdb_filename)

                End If


                LoadMaterials()

                LoadMaterialFromDB()

                er_SelectedMaterialRow = Nothing

                PopulateMaterialParameters(er_SelectedMaterialRow)
                pcMaterial.Visible = True

                cmdBuild.Text = "Build Current"

            Case TAG_RESULTS_NODE


            Case TAG_RESULTS_SHEET
                pcResults.Visible = True

                spieces = Split(TV_NestConfig.FocusedNode.Tag, ",")

                If (spieces.Length > 1) Then
                    sNestedSheetName = spieces(1)
                Else

                    sNestedSheetName = Nothing

                End If

                ShowSheetResults(TV_NestConfig.FocusedNode.Tag)


                sNestedSheetName = ImportFile(sNestedSheetName, sNestedSheetName)

                sbTestingButton.Enabled = False
                sbExportCNC.Enabled = True
                sbCodeViewer.Enabled = True

            Case TAG_RESULTS_PART
                pcPartResults.Visible = True

                FillPartResultsGrid(TV_NestConfig.FocusedNode.Tag)


        End Select

        m_last_Mode = nTheMode

        Windows.Forms.Cursor.Current = Cursors.Default

        frmMain.Focus()

    End Sub


    Private Sub PopulateMaterialParameters(sActualMaterial As EditorRow)
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsMaterial As New DataSet
        Dim sql As String
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim iQuantity As Integer
        Dim dWeight As Double
        Dim dCostPerUnit As Double
        Dim nTypeID As Long
        Dim sDescription As String = ""
        Dim nMatID As Long

        vgMatVars.Rows.Clear()
        Dim rowParameters As New CategoryRow("Parameters")

        vgMatVars.Rows.Add(rowParameters)
        If (sActualMaterial IsNot Nothing) Then


            nMatID = CLng(GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "MatID", 0))

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            sql = "Select * From [Material Inventory] Where (ID = " & nMatID & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsMaterial)

            oledbAdapter.Dispose()

            For i = 0 To dsMaterial.Tables(0).Rows.Count - 1

                sDescription = vgMaterial.FocusedRow.Properties.Caption
                dLength = dsMaterial.Tables(0).Rows(i).Item("Length")
                dWidth = dsMaterial.Tables(0).Rows(i).Item("Width")
                dThickness = dsMaterial.Tables(0).Rows(i).Item("Thickness")
                iQuantity = dsMaterial.Tables(0).Rows(i).Item("Quantity")
                dWeight = dsMaterial.Tables(0).Rows(i).Item("Weight")
                dCostPerUnit = dsMaterial.Tables(0).Rows(i).Item("Cost Per Unit")
                nTypeID = GetMaterialTypeIDFromDescription(vgMaterial.FocusedRow.Properties.Caption)

                lReturn = SetParameterValues(rowParameters, dLength, dWidth, dThickness, iQuantity, dWeight, dCostPerUnit, sDescription, nMatID)
            Next

            connection.Close()


        Else
            sDescription = ""
            dLength = 0
            dWidth = 0
            dThickness = 0
            iQuantity = 0
            dWeight = 0
            dCostPerUnit = 0
            nMatID = -1
            nTypeID = -1

            lReturn = SetParameterValues(rowParameters, dLength, dWidth, dThickness, iQuantity, dWeight, dCostPerUnit, sDescription, nMatID)

        End If

    End Sub
    Private Sub PopulateDefaultSettings()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim myMachineList As MachineListCombo = New MachineListCombo()
        Dim sDefaultName As String = Nothing

        Dim datfilename As String = Nothing
        Dim sTemplate As String = RegGetString("Nesting", "Template", "")


        vgSettingsProplist.SuspendLayout()
        vgSettingsProplist.Rows.Clear()
        currentCategoryRow = CreateCategoryRow(vgSettingsProplist, "glb.Template", _
                                                                "Template File", _
                                                                sTemplate, _
                                                                sTemplate, _
                                                                "Template", _
                                                                DB_HEADER, _
                                                                0, _
                                                                sEmpty, 0)

        currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgSettingsProplist, _
                                                                "glb.Template", _
                                                                "Template", _
                                                                sTemplate, _
                                                                sTemplate, _
                                                                "Template", _
                                                                DB_FILE, _
                                                                0, _
                                                                "Template Files (*.template);*.template", 0))



        sDefaultName = RegGetString("Global", "NestResultPath", App_Path & "\nests")
        currentCategoryRow.ChildRows.Add(CreateFileEditEditorRow(vgSettingsProplist, _
                                                                 "glb.ResultPath", _
                                                                 "Result Path", _
                                                                 sDefaultName, _
                                                                 sDefaultName, _
                                                                 "Result Path", _
                                                                 DB_FOLDER, _
                                                                 0, _
                                                                 sEmpty, 0))

        arrMachine = PopulateComboList("SELECT * FROM [Machines]", True, False)

        currentCategoryRow = CreateCategoryRow(vgSettingsProplist, "glb.Machine", _
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
        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgSettingsProplist, _
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

        currentCategoryRow = CreateCategoryRow(vgSettingsProplist, "glb.ToolSetupID", _
                                                                     "Tool_Setup", _
                                                                     s_ToolSetup, _
                                                                     0, _
                                                                     "Tool Setup ID", DB_HEADER, _
                                                                     0, sEmpty, 0)

        Dim n_ToolSetupID As Integer
        sDefaultName = RegGetString("Global", "ToolSetup", "")
        s_ToolSetup = sDefaultName
        n_ToolSetupID = modTranslate.GetToolSetupIDFromDescription(s_ToolSetup)

        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgSettingsProplist, _
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

        currentCategoryRow = CreateCategoryRow(vgSettingsProplist, "glb.LayerSetupID", _
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

        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgSettingsProplist, _
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

        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgSettingsProplist, "glb.LeadSetupID", _
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

        populateFromDatFile(vgSettingsProplist, datfilename, currentCategoryRow, lbOptions)

        GetRemnantControlValues()

        vgSettingsProplist.BestFit()
        vgSettingsProplist.ResumeLayout()


    End Sub

    Private Sub StoreGlobalVars()

        Dim folder As String

        PathPDB_Set(m_pdb_filename)

        folder = PathDriveFolder(PathPDB())

        If Len(folder) <> 0 Then
            RegPutString("Nesting", "Database", folder)

        Else
            PathPDB_Set(NormalizePath(RegGetString("Nesting", "Database", App_Path & "\Database\")) & PathPDB())
        End If

    End Sub

    Private Sub CreatePDB()
        Dim pdb_name As String
        Dim sResultPath As String
        Dim l_MachineID As Long
        Dim l_LayerSetupID As Long
        Dim l_LeadSetupID As Long
        Dim l_ToolSetupid As Long
        Dim pdb_info As NESTDBINFO

        StoreGlobalVars()

        sResultPath = RegGetString("Global", "NestResultPath", App_Path & "\nests")
        l_MachineID = RegGetString("Global", "MachineID", 0)
        l_LayerSetupID = RegGetString("Global", "LayerSetupID", 0)
        l_LeadSetupID = RegGetString("Global", "LeadSetupID", 0)
        l_ToolSetupid = RegGetString("Global", "ToolSetupID", 0)

        pdb_name = m_pdb_filename

        pdb_info = InitPdbInfo( _
            pdb_name, sResultPath, s_Machine, l_MachineID, _
            s_ToolSetup, l_ToolSetupid, "", 0, _
            s_LeadSetup, l_LeadSetupID, _
            s_LayerSetup, l_LayerSetupID)

        If (EstablishPDB(pdb_info) = String.Empty) Then
            MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)
        Else
            PathPDB_Set(pdb_name)

            m_isVirginDB = False
        End If

    End Sub
    Private Sub UpdateSetupTable()
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

            For Each row As CategoryRow In vgSettingsProplist.Rows

                For Each childRow As EditorRow In row.ChildRows

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
    Private Sub GetSetupValuesFromPDB()
        Dim dsSetup As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim my_VBValue As String
        Dim my_CVarValue As String
        Dim my_CVarName As String
        Dim sDialogDisplay As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            sql = "Select * From [Setup]"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsSetup)

            oledbAdapter.Dispose()

            For Each row As CategoryRow In vgSettingsProplist.Rows

                For Each childRow As EditorRow In row.ChildRows

                    sql = "Select Setup.* From Setup Where (Setup.DialogDisplay = '" & childRow.Properties.Caption & "' )"

                    connection = New OleDbConnection(connetionString)

                    connection.Open()

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    oledbAdapter.Fill(dsSetup)

                    oledbAdapter.Dispose()

                    If (dsSetup.Tables(0).Rows.Count > 0) Then

                        sDialogDisplay = dsSetup.Tables(0).Rows(0).Item("DialogDisplay").ToString
                        my_VBValue = dsSetup.Tables(0).Rows(0).Item("VBValue")
                        my_CVarName = dsSetup.Tables(0).Rows(0).Item("CVarName").ToString()
                        my_CVarValue = dsSetup.Tables(0).Rows(0).Item("CValue").ToString

                        Select Case UCase(sDialogDisplay)

                            Case "MACHINE"
                                modProject.SetMachine(my_VBValue, my_CVarValue)

                            Case "TOOL SETUP"
                                modProject.SetToolSetup(my_VBValue, my_CVarValue)

                            Case "LAYER SETUP"
                                modProject.SetLayerSetup(my_VBValue, my_CVarValue)

                            Case "LEAD SETUP"
                                modProject.SetLeadSetup(my_VBValue, my_CVarValue)

                            Case "AUTOCODE"
                                sReturn = RegPutString("Global", "AutoCode", my_CVarValue)

                        End Select
                        If (my_CVarName = "Template") Then

                            s_NestingTemplate = my_VBValue
                            sReturn = RegPutString("Nesting", "Template", s_NestingTemplate)

                        End If

                        Dim rowType As Type = childRow.Properties.RowType

                        If (rowType.Name = "Boolean") Then
                            If (my_VBValue = True) Then


                                childRow.Properties.Value = True
                            Else

                                childRow.Properties.Value = False

                            End If
                        Else

                            childRow.Properties.Value = my_VBValue

                        End If

                    End If

                    dsSetup.Tables.Clear()

                Next

            Next

            connection.Close()
            connection.Dispose()

            vgSettingsProplist.BestFit()

            'Catch ex As Exception

            'MessageBox.Show("GetSetupValuesFromPDB " & ex.Message)
        Finally
        End Try
    End Sub

    Private Sub TV_NestConfig_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles TV_NestConfig.FocusedNodeChanged
        Dim itemtype As Long
        Dim nCurr_Node_Tag As Long
        Dim sCurr_Node_Tag As String
        Dim sCurr_Display As String
        Dim nTestNode
        Dim sPieces() As String

        Try

            ' node will be nothing if the user had open a pdb and then went to either create a new or open another pdb
            ' so in that case we exit the sub so that the tree can be populated with the new data
            If (IsNothing(e.Node)) Then

                Exit Sub

            End If

            sPieces = Split(e.Node.Tag, ",")


            If (sPieces.Length > 1) Then

                itemtype = sPieces(0)
                sCurr_Node_Tag = sPieces(1)

            Else

                itemtype = e.Node.Tag
                nCurr_Node_Tag = e.Node.Tag

            End If

            sCurr_Display = e.Node.GetDisplayText(TV_NestConfig.Columns(0))

            If (e.Node.ParentNode IsNot Nothing) Then
                nTestNode = e.Node.ParentNode.GetDisplayText(TV_NestConfig.Columns(0))
            End If

            HideControls(itemtype)


        Catch ex As Exception

            MessageBox.Show("TV_NestConfig_FocusedNodeChanged: " & ex.Message)
        End Try

    End Sub

    Private Sub repositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit.ButtonClick
        Dim edit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim sFilename As String
        Dim dialog As New OpenFileDialog()
        Dim m_folderDialog As New FolderBrowserDialog()
        Dim FocusedRow As BaseRow = vgSettingsProplist.FocusedRow
        Dim iname As String
        Dim m_fieldType As Integer
        Dim sFilter As String

        Try
            m_fieldType = CInt(GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "VarDataType", 0))

            Select Case m_fieldType

                Case DB_FILE

                    sFilter = GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "Options", sEmpty)
                    sFilter = Replace(sFilter, ";", "|")

                    dialog.Multiselect = False
                    dialog.Title = "Select " & vgSettingsProplist.FocusedRow.Properties.Caption

                    dialog.Filter = sFilter

                    If dialog.ShowDialog(Me) = DialogResult.OK Then
                        edit.EditValue = TrimToFit(dialog.FileName, 35)

                        sFilename = (dialog.FileName)

                        vgSettingsProplist.BeginDataUpdate()
                        vgSettingsProplist.SetCellValue(FocusedRow, vgSettingsProplist.FocusedRecord, sFilename)
                        vgSettingsProplist.EndDataUpdate()

                        iname = GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "DatVarName", "")

                        lReturn = UpdateAccumulatorDirect(vgSettingsProplist, iname, sFilename)

                    End If

                Case DB_FOLDER

                    m_folderDialog.SelectedPath = NormalizePath(vgSettingsProplist.FocusedRow.Properties.Value)


                    If (m_folderDialog.ShowDialog() = DialogResult.OK) Then

                        vgSettingsProplist.BeginDataUpdate()
                        vgSettingsProplist.SetCellValue(FocusedRow, vgSettingsProplist.FocusedRecord, m_folderDialog.SelectedPath)
                        vgSettingsProplist.EndDataUpdate()

                        iname = GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "DatVarName", "")

                        lReturn = UpdateAccumulatorDirect(vgSettingsProplist, iname, m_folderDialog.SelectedPath)


                    End If
            End Select

        Catch ex As Exception

            MessageBox.Show("rbPropSettings_ButtonClick: " & ex.Message)

        End Try

    End Sub

    Private Sub vgSettingsProplist_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgSettingsProplist.CellValueChanged
        Dim sPdbName As String
        Dim spieces() As String
        Dim sFieldName As String
        Dim VbVarValue As Object
        Dim CVarValue As Object
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim nDataType As Integer


        Try

            sFieldName = GetValueFromDelimitedData(e.Row.Tag, "DatVarName", sEmpty)
            nDataType = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", sEmpty))

            If (Trim(e.Row.Properties.Caption) = "Result Path") Then

                RegPutString("Global", "NestResultPath", e.Value)

            End If

            VbVarValue = e.Row.Properties.Value

            spieces = Split(TV_NestConfig.FocusedNode.Tag, ",")
            sPdbName = spieces(1)

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            sql = "UPDATE [Setup] set [Setup].[VbValue] = '" & VbVarValue & "' Where ([Setup].[DatVarName] ='" & sFieldName & "' )"

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            CVarValue = GetCValueBasedOnVarType(nDataType, VbVarValue, e.Row.Tag)

            sql = "UPDATE [Setup] set [Setup].[CValue] = '" & CVarValue & "' Where ([Setup].[DatVarName] ='" & sFieldName & "' )"

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            m_cnSettings.Close()

            Select Case nDataType

                Case DB_MACHINE

                    modProject.SetMachine(VbVarValue, CVarValue)

                    CheckIfBuildEnabled()

                Case DB_TOOLSETUP

                    modProject.SetToolSetup(VbVarValue, CVarValue)
                    CheckIfBuildEnabled()

                Case DB_LAYERSETUP

                    modProject.SetLayerSetup(VbVarValue, CVarValue)

                Case DB_LEADSETUP

                    modProject.SetLeadSetup(VbVarValue, CVarValue)

            End Select

        Catch ex As Exception

            MessageBox.Show("vgSettingsProplist_CellValueChanged: " & ex.Message)

        End Try


    End Sub

    Private Sub vgSettingsProplist_CustomRecordCellEdit(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs) Handles vgSettingsProplist.CustomRecordCellEdit
        Dim nTemp As Integer

        If (e.Row.Tag IsNot Nothing) Then
            nTemp = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0))

            If (nTemp = DB_FILE Or nTemp = DB_FOLDER) Then
                e.RepositoryItem = repositoryItemButtonEdit
            End If
        End If

    End Sub

    Private Sub CreatePartDefaultValues(currentCategoryRow As CategoryRow, sPartExtents As String, nid As Integer, AddVarRecord As Boolean)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String

        my_DatVarName = "Part Quantity"
        my_DialogDisplay = "Quantity"
        my_VBValue = 1
        my_CValue = 1
        my_CVarName = "Part Quantity"
        my_DataType = DB_INT
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))

        my_DatVarName = "Fill Part"
        my_DialogDisplay = "Filler"
        my_VBValue = False
        my_CValue = 0
        my_CVarName = "Fill Part"
        my_DataType = DB_BOOL
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))

        my_DatVarName = "Rotation Num"
        my_DialogDisplay = "Rotation"
        my_VBValue = 1
        my_CValue = 1
        my_CVarName = "Rotation Num"
        my_DataType = DB_INT
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))

        my_DatVarName = "Rotation Start"
        my_DialogDisplay = "Pre Rotate"
        my_VBValue = 0
        my_CValue = 0
        my_CVarName = "Rotation Start"
        my_DataType = DB_DBL
        my_RecodID = 0
        my_sOptions = sEmpty


        currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgParts, _
                                                               my_DatVarName, _
                                                               my_DialogDisplay, _
                                                               my_VBValue, _
                                                               my_CValue, _
                                                               my_CVarName, _
                                                               my_DataType, _
                                                               my_RecodID, _
                                                               my_sOptions, 0))

        my_DatVarName = "PreNest"
        my_DialogDisplay = "Pre Nest"
        my_VBValue = False
        my_CValue = 0
        my_CVarName = "PreNest"
        my_DataType = DB_BOOL
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))

        lbOptions.Items.Clear()

        lbOptions.Items.Add("None")
        lbOptions.Items.Add("Allow")
        lbOptions.Items.Add("Pre Mirror")

        arrOptions = PopulateComboListFromDat(lbOptions)

        my_DatVarName = "MirrorPart"
        my_DialogDisplay = "Mirroring"
        my_VBValue = "None"
        my_CValue = 0
        my_CVarName = "MirrorPart"
        my_DataType = DB_DCOMBO
        my_RecodID = 0


        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgParts, _
                                                                        my_DatVarName, _
                                                                        my_DialogDisplay, _
                                                                        my_VBValue, _
                                                                        my_CValue, _
                                                                        my_CVarName, _
                                                                        my_DataType, _
                                                                        my_RecodID, _
                                                                        arrOptions, 0))

        my_DatVarName = "Part Priority"
        my_DialogDisplay = "Priority"
        my_VBValue = 1
        my_CValue = 1
        my_CVarName = "Part Priority"
        my_DataType = DB_INT
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))

        my_DatVarName = "Cost Per Part"
        my_DialogDisplay = "Cost Per Part"
        my_VBValue = 0
        my_CValue = 0
        my_CVarName = "Cost Per Part"
        my_DataType = DB_DBL
        my_RecodID = 0
        my_sOptions = sEmpty


        currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgParts, _
                                                               my_DatVarName, _
                                                               my_DialogDisplay, _
                                                               my_VBValue, _
                                                               my_CValue, _
                                                               my_CVarName, _
                                                               my_DataType, _
                                                               my_RecodID, _
                                                               my_sOptions, 0))


        lbOptions.Items.Clear()

        lbOptions.Items.Add("Actual Part")
        lbOptions.Items.Add("Bounding Box")
        lbOptions.Items.Add("Rubberband Box")

        arrOptions = PopulateComboListFromDat(lbOptions)
        my_DatVarName = "Representation"
        my_DialogDisplay = "Representation"
        my_VBValue = "Actual Part"
        my_CValue = 0
        my_CVarName = "Representation"
        my_DataType = DB_DCOMBO
        my_RecodID = 0


        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgParts, _
                                                                        my_DatVarName, _
                                                                        my_DialogDisplay, _
                                                                        my_VBValue, _
                                                                        my_CValue, _
                                                                        my_CVarName, _
                                                                        my_DataType, _
                                                                        my_RecodID, _
                                                                        arrOptions, 0))


        my_DatVarName = "Part_Extents"
        my_DialogDisplay = "Part Extents"
        my_VBValue = sPartExtents
        my_CValue = sPartExtents
        my_CVarName = "Part_Extents"
        my_DataType = DB_STR
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgParts, _
                                                               my_DatVarName, _
                                                               my_DialogDisplay, _
                                                               my_VBValue, _
                                                               my_CValue, _
                                                               my_CVarName, _
                                                               my_DataType, _
                                                               my_RecodID, _
                                                               my_sOptions, 0))
        currentCategoryRow.Properties.ReadOnly = True

        If (AddVarRecord = True) Then
            CreateUserVarsForParts(currentCategoryRow, nid)
        End If

    End Sub
    Private Sub CreatePartResultValues(currentCategoryRow As CategoryRow, sPartExtents As String, nid As Integer, AddVarRecord As Boolean)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String

        my_DatVarName = "Part Quantity"
        my_DialogDisplay = "Quantity"
        my_VBValue = 1
        my_CValue = 1
        my_CVarName = "Part Quantity"
        my_DataType = DB_INT
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))


        my_DatVarName = "Part ID"
        my_DialogDisplay = "Part ID"
        my_VBValue = 1
        my_CValue = 1
        my_CVarName = "Part Id"
        my_DataType = DB_INT
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgParts, _
                                                                my_DatVarName, _
                                                                my_DialogDisplay, _
                                                                my_VBValue, _
                                                                my_CValue, _
                                                                my_CVarName, _
                                                                my_DataType, _
                                                                my_RecodID, _
                                                                my_sOptions, 0))

        my_DatVarName = "Area"
        my_DialogDisplay = "Area"
        my_VBValue = 0
        my_CValue = 0
        my_CVarName = "Area"
        my_DataType = DB_DBL
        my_RecodID = 0
        my_sOptions = sEmpty


        currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgParts, _
                                                               my_DatVarName, _
                                                               my_DialogDisplay, _
                                                               my_VBValue, _
                                                               my_CValue, _
                                                               my_CVarName, _
                                                               my_DataType, _
                                                               my_RecodID, _
                                                               my_sOptions, 0))


    End Sub

    Private Sub CreateUserVarsForParts(currentCategoryRow As CategoryRow, nid As Integer)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim iPartLastIndex As Integer
        Dim iUserLastIndex As Integer
        Dim ni As Integer

        my_DatVarName = "Part Quantity"
        my_DialogDisplay = "Quantity"
        my_VBValue = 1
        my_CValue = 1
        my_CVarName = "Part Quantity"
        my_DataType = DB_INT
        my_RecodID = 0
        my_sOptions = sEmpty

        iPartLastIndex = currentCategoryRow.Properties.Row.ChildRows.LastVisible.Index

        populateFromDatFile(vgParts, RegGetString("Nesting", "Template", ""), currentCategoryRow, lbOptions)

        iUserLastIndex = currentCategoryRow.Properties.Row.ChildRows.LastVisible.Index

        For ni = iPartLastIndex + 1 To iUserLastIndex

            my_VBValue = GetValueFromDelimitedData(currentCategoryRow.ChildRows(ni).Tag, "VBValue", "None")
            my_DialogDisplay = GetValueFromDelimitedData(currentCategoryRow.ChildRows(ni).Tag, "DialogDisplay", 0)

        Next

    End Sub

    Private Sub addRecordToUserVarTable(nid As Integer, my_VBValue As String, my_DialogDisplay As String)
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand
        Dim sPdbName As String

        Try

            sPdbName = m_pdb_filename

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

            sql = "INSERT INTO [Part Variables] ([Part ID], [Value], [Description] ) VALUES(" & nid & ", '" & my_VBValue & "', '" & my_DialogDisplay & "')"

            m_cnPart = New OleDbConnection(connetionString)

            m_cnPart.Open()

            m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

            m_daPart.InsertCommand.ExecuteNonQuery()

            m_cnPart.Close()

        Catch ex As Exception

            MessageBox.Show("addRecordToUserVarTable: " & ex.Message)

        End Try
    End Sub
    Private Sub FocusText(ByRef TheVerticalGrid)
        If TypeOf TheVerticalGrid.ActiveEditor Is TextEdit Then
            Dim edit As TextEdit = TryCast(TheVerticalGrid.ActiveEditor, TextEdit)
            edit.SelectionStart = 0
            edit.SelectionLength = (CStr(edit.EditValue)).Length

        End If
    End Sub
    Private Sub LoadMaterialParams()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim sql As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim dtMaterialType As DataTable = Nothing
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim iQuantity As Integer
        Dim dWeight As Double
        Dim dCostPerUnit As Double
        Dim nTypeID As Long
        Dim sDescription As String = ""
        Dim nMatID As Long

        vgMatVars.Rows.Clear()

        nMatID = CLng(GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "MatID", 0))

        sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & nMatID & " )"

        dtMaterialType = ConnectToCMDB(sql)

        Dim rowParameters As New CategoryRow("Parameters")

        vgMatVars.Rows.Add(rowParameters)

        For i = 0 To dtMaterialType.Rows.Count - 1
            sDescription = vgMaterial.FocusedRow.Properties.Caption
            dLength = dtMaterialType.Rows(i).Item("Length")
            dWidth = dtMaterialType.Rows(i).Item("Width")
            iQuantity = dtMaterialType.Rows(i).Item("Quantity")
            dWeight = dtMaterialType.Rows(i).Item("Weight")
            dCostPerUnit = dtMaterialType.Rows(i).Item("Cost Per Unit")
            dThickness = dtMaterialType.Rows(i).Item("Thickness")
            nTypeID = GetMaterialTypeIDFromDescription(vgMaterial.FocusedRow.Properties.Caption)

            lReturn = SetParameterValues(rowParameters, dLength, dWidth, dThickness, iQuantity, dWeight, dCostPerUnit, sDescription, nMatID)

        Next
        DatabaseClose()

    End Sub
    Private Sub LoadMaterials()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim sql As String
        Dim ds As New DataSet
        Dim s_MaterialCategory As String
        Dim n_MaterialID As Integer
        Dim i As Integer
        Dim dtMaterialType As DataTable = Nothing

        vgMaterial.Rows.Clear()

        currentCategoryRow = CreateCategoryRow(vgMaterial, "Process Order", "ProcessOrder", "ProcessOrder", "ProcessOrder", "ProcessOrder", DB_HEADER, 0, sEmpty, 0)

        Dim rowMaterialInentory As New CategoryRow("Material Inventory")

        vgMaterial.Rows.Add(rowMaterialInentory)

        DatabaseClose()

        s_MaterialCategory = ""

        sql = "SELECT * FROM [Material Types] ORDER BY Display"

        Try

            dtMaterialType = ConnectToCMDB(sql)

            For i = 0 To dtMaterialType.Rows.Count - 1
                s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")


                n_MaterialID = dtMaterialType.Rows(i).Item("ID")

                Dim rowMaterialType As New EditorRow(s_MaterialCategory)

                rowMaterialType.Properties.Caption = s_MaterialCategory
                rowMaterialInentory.ChildRows.Add(rowMaterialType)

                FillMaterialNodes(n_MaterialID, currentCategoryRow, rowMaterialType)

                dtMaterialType.Dispose()

            Next


            Dim rowRemnantInentory As New CategoryRow("Remnant Inventory")
            vgMaterial.Rows.Add(rowRemnantInentory)

            DatabaseClose()

            FillRemnantInventoryTree(rowRemnantInentory)

            vgMaterial.ExpandAllRows()

            vgMaterial.BestFit()

        Catch ex As Exception

            MessageBox.Show("LoadMaterials: " & ex.Message)

        End Try

    End Sub
    Public Sub FillRemnantInventoryTree(nRemRow As CategoryRow)
        Dim Sql2 As String
        Dim sql As String
        Dim dtRemnants As DataTable = Nothing
        Dim dtRemnantInv As DataTable = Nothing
        Dim my_DatVarName As String
        Dim my_VBValue As String
        Dim Rem_ID As Long
        Dim Rem_Name As String = Nothing
        Dim rem_length As Double
        Dim rem_width As Double
        Dim rem_thickness As Double
        Dim rem_area As Double
        Dim Rem_Date As String
        Dim rem_material As String
        Dim material_name As String = Nothing
        Dim materialID As Long
        Dim rem_Name_Holder As String = Nothing
        Dim rowRemnantInentory As EditorRow = Nothing

        Try


            sql = "SELECT * FROM Remnant WHERE (Remnant.MachineID > 0 )"
            dtRemnants = ConnectToCMDB(sql)

            For i = 0 To dtRemnants.Rows.Count - 1

                Rem_ID = dtRemnants.Rows(i).Item("ID")

                Sql2 = "SELECT * FROM RemnantVar WHERE (RemnantID = " & Rem_ID & " )"

                dtRemnantInv = ConnectToCMDB(Sql2)

                For ni = 0 To dtRemnantInv.Rows.Count - 1

                    Select Case UCase(dtRemnantInv.Rows(ni).Item("InternalName"))
                        Case "NAME"
                            Rem_Name = dtRemnantInv.Rows(ni).Item("Value")

                        Case "LENGTH"
                            rem_length = dtRemnantInv.Rows(ni).Item("Value")

                        Case "WIDTH"
                            rem_width = dtRemnantInv.Rows(ni).Item("Value")

                        Case "THICKNESS"
                            rem_thickness = dtRemnantInv.Rows(ni).Item("Value")

                        Case "AREA"
                            rem_area = dtRemnantInv.Rows(ni).Item("Value")

                        Case "CREATION_DATE"
                            Rem_Date = dtRemnantInv.Rows(ni).Item("Value")

                        Case "MATERIAL"
                            rem_material = dtRemnantInv.Rows(ni).Item("Value")
                            materialID = GetMaterialTypeIDFromDescription(rem_material)
                            material_name = GetMaterialTypeName(materialID)

                    End Select


                Next

                DatabaseClose()

                If (materialID > 0) Then
                    If (material_name <> rem_Name_Holder) Then
                        rowRemnantInentory = New EditorRow(material_name)
                        rowRemnantInentory.Properties.Caption = material_name
                        rowRemnantInentory.Tag = CHR1 & "IsRem" & CHR2 & True & _
                                                CHR1 & "RemID" & CHR2 & Rem_ID & _
                                                CHR1 & "MatID" & CHR2 & materialID

                        nRemRow.ChildRows.Add(rowRemnantInentory)

                        rem_Name_Holder = material_name

                    End If

                    my_VBValue = Rem_Name
                    my_DatVarName = "Remnant"

                    Dim sActualMaterial As New EditorRow(my_DatVarName)
                    sActualMaterial.Properties.Caption = my_VBValue
                    sActualMaterial.Tag = CHR1 & "IsRem" & CHR2 & True & _
                                                CHR1 & "RemID" & CHR2 & Rem_ID & _
                                                CHR1 & "MatID" & CHR2 & materialID

                    rowRemnantInentory.ChildRows.Add(sActualMaterial)
                End If

            Next

        Catch ex As Exception

            MessageBox.Show("FillRemnantInventoryTree: " & ex.Message)

        End Try


    End Sub
    Private Sub LoadRemnantParams()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim sql As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim dtMaterialType As DataTable = Nothing
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim iQuantity As Integer
        Dim dArea As Double
        Dim dWeight As Double
        Dim dCostPerUnit As Double
        Dim nTypeID As Long
        Dim sDescription As String = Nothing
        Dim sCreationDate As String = Nothing
        Dim nMatID As Long
        Dim sMaterial As String
        Dim sRem_fileName As String = Nothing


        vgMatVars.Rows.Clear()

        sql = "Select [RemnantVar].* From [RemnantVar] Where ([RemnantVar].[RemnantID] = " & GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "RemID", 0) & " )"

        nMatID = GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "MatID", 0)

        dtMaterialType = ConnectToCMDB(sql)

        Dim rowParameters As New CategoryRow("Parameters")

        vgMatVars.Rows.Add(rowParameters)

        For i = 0 To dtMaterialType.Rows.Count - 1
            Select Case UCase(dtMaterialType.Rows(i).Item("InternalName"))
                Case "NAME"
                    sDescription = dtMaterialType.Rows(i).Item("Value")

                    sRem_fileName = PathRemnants() & "\" & sDescription & ".rem"

                Case "LENGTH"
                    dLength = dtMaterialType.Rows(i).Item("Value")

                Case "WIDTH"
                    dWidth = dtMaterialType.Rows(i).Item("Value")

                Case "THICKNESS"
                    dThickness = dtMaterialType.Rows(i).Item("Value")

                Case "AREA"
                    dArea = dtMaterialType.Rows(i).Item("Value")

                Case "CREATION_DATE"
                    sCreationDate = dtMaterialType.Rows(i).Item("Value")

                Case "MATERIAL"
                    sMaterial = dtMaterialType.Rows(i).Item("Value")
                    nTypeID = GetMaterialTypeIDFromDescription(sMaterial)

                Case "QUANTITY"
                    iQuantity = CInt(dtMaterialType.Rows(i).Item("Value"))

            End Select


        Next

        lReturn = SetRemParameterValues(rowParameters, dLength, dWidth, dThickness, iQuantity, sRem_fileName, sCreationDate, dWeight, dCostPerUnit, nTypeID, sDescription, nMatID)

        DatabaseClose()

    End Sub

    Private Sub FillMaterialNodes(n_MaterialID As Long, currentCategoryRow As CategoryRow, rowMaterialType As EditorRow)
        Dim sql As String
        Dim s_MaterialCategory As String
        Dim dtMaterials As DataTable = Nothing
        Dim i As Integer
        Dim sID As String
        Dim sTheTypeID As String
        Dim my_DatVarName As String
        Dim my_VBValue As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer

        Try
            sql = "SELECT * FROM [Material Inventory] WHERE " & _
                "([Type ID] = " & n_MaterialID & " ) ORDER BY Thickness"

            dtMaterials = ConnectToCMDB(sql)

            For i = 0 To dtMaterials.Rows.Count - 1

                s_MaterialCategory = dtMaterials.Rows(i).Item("Description")
                sID = dtMaterials.Rows(i).Item("ID")

                sTheTypeID = dtMaterials.Rows(i).Item("Type ID")

                my_DatVarName = "Description"
                my_VBValue = s_MaterialCategory
                my_DataType = DB_STR
                my_RecodID = sID

                Dim sActualMaterial As New EditorRow(my_DatVarName)
                sActualMaterial.Properties.Caption = my_VBValue
                sActualMaterial.Tag = CHR1 & "IsRem" & CHR2 & False & _
                                            CHR1 & "MatID" & CHR2 & sID

                ' adding the Material row to the Material Type row's child collection 
                rowMaterialType.ChildRows.Add(sActualMaterial)


            Next

            vgMaterial.ExpandAllRows()

            vgMaterial.BestFit()

            DatabaseClose()

        Catch ex As Exception

            MessageBox.Show("FillMaterialNodes: " & ex.Message)

        End Try

    End Sub
    Private Function AddMaterialToMaterialInventorys(sDescription As String, _
                                                    nTypeID As Integer, _
                                                    dLength As Double, _
                                                    dWidth As Double, _
                                                    dThickness As Double, _
                                                    dWeight As Double, _
                                                    iQuantity As Integer, _
                                                    dCostPerUnit As Double) As Long

        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand
        Dim sPieces() As String
        Dim sPdbName As String

        Try
            AddMaterialToMaterialInventorys = -1

            sPieces = Split(TV_NestConfig.FocusedNode.ParentNode.Tag, ",")
            sPdbName = sPieces(1)


            tbFieldNames.Clear()
            tbFieldValues.Clear()

            tbFieldNames.Text = "[Description]," & _
                                "[TYpe ID]," & _
                                "[Length]," & _
                                "[Width]," & _
                                "[Thickness]," & _
                                "[Weight]," & _
                                "[Quantity]," & _
                                "[Cost Per Unit]"

            tbFieldValues.Text = "'" & sDescription & "'," & _
                                "'" & nTypeID & "'," & _
                                "'" & dLength & "'," & _
                                "'" & dWidth & "'," & _
                                "'" & dThickness & "'," & _
                                "'" & dWeight & "'," & _
                                "'" & iQuantity & "'," & _
                                "'" & dCostPerUnit & "'"


            sql = "INSERT INTO [Material Inventory] (" & tbFieldNames.Text & " ) VALUES(" & tbFieldValues.Text & ")"

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

            m_cnPart = New OleDbConnection(connetionString)

            m_cnPart.Open()

            m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

            m_daPart.InsertCommand.ExecuteNonQuery()

            cmdGetID.Connection = m_cnPart

            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Material Inventory]"

            AddMaterialToMaterialInventorys = cmdGetID.ExecuteScalar

            m_cnPart.Close()

        Catch ex As Exception

            MessageBox.Show("AddMaterialToMaterialInventorys: " & ex.Message)

        End Try

    End Function

    Private Function AddRemnantToMaterialInventorys(sDescription As String, _
                                                nTypeID As Integer, _
                                                dLength As Double, _
                                                dWidth As Double, _
                                                dThickness As Double, _
                                                dArea As Double, _
                                                dWeight As Double, _
                                                iQuantity As Integer, _
                                                dCostPerUnit As Double, _
                                                sCreationDate As String) As Long
        'AddRemnantToMaterialInventorys(Rem_Name, sCMDB_MatID, rem_length, rem_width, rem_thickness, rem_area, rem_weight, rem_qty, rem_cost, Rem_Date)
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand
        Dim sPieces() As String
        Dim sPdbName As String

        Try
            AddRemnantToMaterialInventorys = -1

            sPieces = Split(TV_NestConfig.FocusedNode.ParentNode.Tag, ",")
            sPdbName = sPieces(1)


            tbFieldNames.Clear()
            tbFieldValues.Clear()

            tbFieldNames.Text = "[ID]," & _
                                "[Filename]," & _
                                "[Type ID]," & _
                                "[Length]," & _
                                "[Width]," & _
                                "[Thickness]," & _
                                "[Area]," & _
                                "[Weight]," & _
                                "[Quantity]," & _
                                "[Cost Per Unit]," & _
                                "[Creation Date]"

            tbFieldValues.Text = "'" & nTypeID & "'," & _
                                "'" & NormalizePath(PathRemnants()) & sDescription & ".rem'," & _
                                "'" & nTypeID & "'," & _
                                "'" & dLength & "'," & _
                                "'" & dWidth & "'," & _
                                "'" & dThickness & "'," & _
                                "'" & dArea & "'," & _
                                "'" & dWeight & "'," & _
                                "'" & iQuantity & "'," & _
                                "'" & dCostPerUnit & "'," & _
                                "'" & sCreationDate & "'"


            sql = "INSERT INTO [Remnant Inventory] (" & tbFieldNames.Text & " ) VALUES(" & tbFieldValues.Text & ")"

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

            m_cnPart = New OleDbConnection(connetionString)

            m_cnPart.Open()

            m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

            m_daPart.InsertCommand.ExecuteNonQuery()

            cmdGetID.Connection = m_cnPart

            'cmdGetID.CommandText = "SELECT MAX(ID) FROM [Remnant Inventory]"

            AddRemnantToMaterialInventorys = nTypeID

            sql = "UPDATE [Remnant Inventory] set [Remnant Inventory].[ID ] = '" & nTypeID & "' Where ([Remnant Inventory].[ID] = " & AddRemnantToMaterialInventorys & " ) "

            m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

            m_daPart.InsertCommand.ExecuteNonQuery()


            m_cnPart.Close()

        Catch ex As Exception

            AddRemnantToMaterialInventorys = -1

            MessageBox.Show("AddRemnantToMaterialInventorys: " & ex.Message)

        End Try

    End Function
    Private Sub bbOpen_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbOpen.ItemClick

        bCameFromStartUp = False
        OpenExistingPDB()

    End Sub
    Public Function OpenExistingPDB() As Long

        Dim Pdb_FileOpen As New OpenFileDialog
        Dim currentCategoryRow As CategoryRow = Nothing

        Try
            TV_NestConfig.ClearNodes()
            OpenExistingPDB = 0

            If (bCameFromStartUp = False) Then
                Pdb_FileOpen.Filter = "PDB files (*.pdb)|*.pdb|MRP files (*.MRP)|*.MRP"
                Pdb_FileOpen.FilterIndex = 1
                Pdb_FileOpen.RestoreDirectory = True
                Pdb_FileOpen.InitialDirectory = PathDriveFolder(PathPDB()) & "\"

                If (FileExists(PathPDB()) = True) Then
                    Pdb_FileOpen.FileName = PathFileExt(PathPDB())

                End If

                If Pdb_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    OpenExistingPDB = 1
                    Windows.Forms.Cursor.Current = Cursors.WaitCursor
                    m_pdb_filename = Pdb_FileOpen.FileName

                    PathPDB_Set(m_pdb_filename)
                    LoadPDB(m_pdb_filename)

                End If
            Else

                If (FileExists(PathPDB()) = True) Then
                    Pdb_FileOpen.FileName = PathPDB()

                End If
                OpenExistingPDB = 1
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                m_pdb_filename = Pdb_FileOpen.FileName

                PathPDB_Set(m_pdb_filename)
                LoadPDB(m_pdb_filename)
                bCameFromStartUp = False
            End If

            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception

            MessageBox.Show("bbOpen_ItemClick: " & ex.Message)

        End Try
    End Function
    Private Sub cmdBuild_Click(sender As Object, e As EventArgs) Handles cmdBuild.Click
        Dim cmd As String
        Dim sTemp As String
        Dim m_Length As Double
        Dim m_Width As Double
        Dim m_Thickness As Double
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

        Try
            'first we decide if we are running all of the PDB's
            'Or just one. The easiest way to do this is by
            'checking the caption of the button because this is handle
            'by clicking the node of the tree.

            If (cmdBuild.Text = "Build All") Then
                'cleare the results from the tree
                'in case the user ran the nest already
                Dim operation As New MyIterator
                TV_NestConfig.NodesIterator.DoOperation(operation)

                RunAllPDBs()

                Exit Sub
            Else
                pdb_Node = TV_NestConfig.FocusedNode

                DeleteResultsForselectedNode(pdb_Node)

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                If (DoesTableExist("Sheet Result", PathPDB()) = True) Then

                    RemoveExistingResults()

                End If

                sql = "SELECT * FROM [Material Inventory]"

                connection = New OleDbConnection(connetionString)

                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(ds)

                oledbAdapter.Dispose()

                connection.Close()

                If (ds.Tables(0).Rows.Count > 0) Then

                    m_Length = ds.Tables(0).Rows(0).Item("Length")
                    m_Width = ds.Tables(0).Rows(0).Item("Width")
                    m_Thickness = ds.Tables(0).Rows(0).Item("Thickness")
                    materialID = GetMaterialIDFromDescription(Trim(ds.Tables(0).Rows(0).Item("Description")))

                    ds.Dispose()

                Else

                    sql = "SELECT * FROM [Remnant Inventory]"""

                    connection.Open()

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    oledbAdapter.Fill(ds)

                    oledbAdapter.Dispose()

                    connection.Close()

                    If (ds.Tables(0).Rows.Count > 0) Then

                        m_Length = ds.Tables(0).Rows(0).Item("Length")
                        m_Width = ds.Tables(0).Rows(0).Item("Width")
                        m_Thickness = ds.Tables(0).Rows(0).Item("Thickness")
                        materialID = ds.Tables(0).Rows(0).Item("[Type ID]")

                    End If

                    ds.Dispose()

                End If

                machineID = modProject.GetMachineID()

                ToolSetupID = modProject.GetToolSetupID()

                bDebugGraphics = True

                m_is_nesting = True

                stock_vis = modView.StockLayerVisible(True)
                modView.SetViewModes(VIEW_WIRE)

                sTemp = NewModel("<nesting>", machineID, ToolSetupID, materialID, m_Length, m_Width, m_Thickness)

                'If (IS_CCS_FAB = True) Then

                '    cmd = "nest:true:ccs=1," & _
                '          " configdb=" & QStr(PathCMDB()) & _
                '          ",partdb=" & QStr(PathPDB()) & _
                '          ",display=" & IIf(bDebugGraphics, 1, 0)

                'Else

                cmd = "nest:true:" & _
                      " configdb=" & QStr(PathCMDB()) & _
                      ",partdb=" & QStr(PathPDB()) & _
                      ",display=" & IIf(bDebugGraphics, 1, 0)
                'End If

                lReturn = PortalExecute(cmd)

                lCount = PortalGetInt("sheet count", 0)

                'Restore the previous stock layer visibility state.
                stock_vis = modView.StockLayerVisible(stock_vis)

                m_is_nesting = False

                '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

                If (lCount > 0) Then

                    NestResults()


                    TV_NestConfig.FocusedNode.Expanded = True

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("CmdBuild: " & ex.Message)
        End Try

    End Sub
    Private Sub RunAllPDBs()
        Dim cmd As String
        Dim sTemp As String
        Dim m_Length As Double
        Dim m_Width As Double
        Dim m_Thickness As Double
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
        Dim nParentNode As TreeListNode
        Dim spieces() As String

        nParentNode = TV_NestConfig.Nodes(0)

        For Each childnode In nParentNode.Nodes

            If childnode.level = 1 Then

                TV_NestConfig.FocusedNode = childnode
                CFG_SETTINGS_NODE = childnode


                spieces = Split(TV_NestConfig.FocusedNode.Tag, ",")

                If (spieces.Length > 1) Then
                    m_pdb_filename = spieces(1)

                    PathPDB_Set(m_pdb_filename)

                End If

                'PathPDB_Set(TV_NestConfig.FocusedNode.Tag)

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                sql = "SELECT * FROM [Material Inventory]"

                connection = New OleDbConnection(connetionString)

                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(ds)

                oledbAdapter.Dispose()

                connection.Close()

                If (ds.Tables(0).Rows.Count > 0) Then

                    m_Length = ds.Tables(0).Rows(0).Item("Length")
                    m_Width = ds.Tables(0).Rows(0).Item("Width")
                    m_Thickness = ds.Tables(0).Rows(0).Item("Thickness")
                    materialID = GetMaterialIDFromDescription(Trim(ds.Tables(0).Rows(0).Item("Description")))

                    ds.Dispose()

                Else

                    sql = "SELECT * FROM [Remnant Inventory]"""

                    connection.Open()

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    oledbAdapter.Fill(ds)

                    oledbAdapter.Dispose()

                    connection.Close()

                    If (ds.Tables(0).Rows.Count > 0) Then

                        m_Length = ds.Tables(0).Rows(0).Item("Length")
                        m_Width = ds.Tables(0).Rows(0).Item("Width")
                        m_Thickness = ds.Tables(0).Rows(0).Item("Thickness")
                        materialID = ds.Tables(0).Rows(0).Item("[Type ID]")

                    End If

                    ds.Dispose()

                End If

                machineID = modProject.GetMachineID()

                ToolSetupID = modProject.GetToolSetupID()

                bDebugGraphics = True

                m_is_nesting = True

                stock_vis = modView.StockLayerVisible(True)
                modView.SetViewModes(VIEW_WIRE)

                sTemp = NewModel("<nesting>", machineID, ToolSetupID, materialID, m_Length, m_Width, m_Thickness)

                'If (IS_CCS_FAB = True) Then

                '    cmd = "nest:true:ccs=1," & _
                '          " configdb=" & QStr(PathCMDB()) & _
                '          ",partdb=" & QStr(PathPDB()) & _
                '          ",display=" & IIf(bDebugGraphics, 1, 0)

                'Else

                cmd = "nest:true:" & _
                      " configdb=" & QStr(PathCMDB()) & _
                      ",partdb=" & QStr(PathPDB()) & _
                      ",display=" & IIf(bDebugGraphics, 1, 0)
                'End If

                lReturn = PortalExecute(cmd)

                lCount = PortalGetInt("sheet count", 0)

                'Restore the previous stock layer visibility state.
                stock_vis = modView.StockLayerVisible(stock_vis)

                m_is_nesting = False

                '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

                If (lCount > 0) Then

                    NestResults()


                    TV_NestConfig.FocusedNode.Expanded = True

                End If

            End If

        Next
    End Sub
    Private Sub DeleteResultsForselectedNode(m_PDB_Node As TreeListNode)

        If m_PDB_Node.HasChildren = True Then

            For Each child As TreeListNode In m_PDB_Node.Nodes

                If child.HasChildren = True Then

                    child.Nodes.Clear()
                    child(0) = "Results (Pending)"

                End If

            Next
        End If

    End Sub

    Private Function GetResultNode(m_pdb_Node As TreeListNode) As TreeListNode
        GetResultNode = Nothing

        If m_pdb_Node.HasChildren = True Then

            For Each child As TreeListNode In m_pdb_Node.Nodes

                If (child(0) = "Results (Pending)") Then

                    GetResultNode = child
                    Exit Function

                End If
                If child.HasChildren = True Then
                    GetResultNode = child
                    child.Nodes.Clear()
                    child(0) = "Results (Pending)"
                    Exit Function

                End If

            Next
        End If

    End Function
    Private Sub NestResults()

        'See also comments at NestPostProc()
        lReturn = modNesting.NestPostProc()


        frmNestResults.ShowDialog(frmMain)

        modView.ViewActivate(VIEW_WIRE)

        If (frmNestResults.CompletionStatus() = vbCancel) Then

            DeleteNestResults()
            modView.ViewActivate(VIEW_WIRE)

        Else
            TV_NestConfig.SuspendLayout()

            LoadResultsIntoTree(m_pdb_filename)

            TV_NestConfig.ResumeLayout()

        End If

    End Sub
    Private Sub PreviewRefresh()

        lReturn = PortalExecute("!view:materialextents: regen=0")

    End Sub
    Private Sub cmdAddMulti_Click(sender As Object, e As EventArgs) Handles cmdAddMulti.Click
        Dim cnt As Integer
        Dim indx As Integer
        Dim sFileName As String
        Dim sExt As String
        Dim sCandidate As String
        Dim part_data() As clsNestingPartData
        Dim part_user_var_data() As clsNestTemplateVars
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim indx2 As Integer

        Try
            If (m_debug_tempdir = True) Then
                MessageBox.Show("Into Add Multi")
            End If

            vgParts.Visible = False

            dlgPartBrowser.ShowDialog(Me)

            part_data = dlgPartBrowser.GetPartData
            part_user_var_data = dlgPartBrowser.GetUserVarData

            cnt = dlgPartBrowser.FileCount()

            If (m_debug_tempdir = True) Then
                MessageBox.Show("The Add Multi Part Count Is " & cnt)
            End If

            If (cnt > 0) Then

                For indx = 0 To cnt - 1

                    sCandidate = part_data(indx).Path

                    If (m_debug_tempdir = True) Then
                        MessageBox.Show("The Canidate is " & sCandidate)
                    End If

                    If (sCandidate <> "") Then

                        If (m_debug_tempdir = True) Then
                            MessageBox.Show("Check the file extension of the Canidate to determine how the file should be converted")
                        End If

                        sExt = UCase$(PathExt(sCandidate))
                        If (sExt = "MM2") Then

                            'The corresponding MM2 file name.
                            m_current_part = sCandidate

                        Else

                            'The selected file is a CAD file
                            m_current_part = modFileIO.GetTargetName(sCandidate)

                            If (m_debug_tempdir = True) Then
                                MessageBox.Show("The file is a CAD file so we have toConvert it")

                                MessageBox.Show("The file is a filename is " & m_current_part)
                            End If

                        End If

                        If (m_current_part <> "") Then

                            'Because only frmExplorer provides the Pre-Rotate option.
                            lReturn = modConversion.ConversionParametersSet( _
                                0.0#, False, dlgPartBrowser.GetStripLayers())

                            'At this point, the user has committed to importing the file.
                            modFileIO.AllowMessages(False)

                            If (m_debug_tempdir = True) Then
                                MessageBox.Show("We should be converting " & sCandidate & " to " & m_current_part)
                            End If

                            sFileName = modFileIO.ImportFile(sCandidate, m_current_part)

                            modFileIO.AllowMessages(True)

                        End If

                        If (m_current_part <> "") Then

                            Dim sPartExtent As String = CalculateDimensionsJustXY()
                            Dim sPdbName As String
                            Dim spieces() As String
                            Dim nid As Long

                            spieces = Split(TV_NestConfig.FocusedNode.ParentNode.Tag, ",")
                            sPdbName = spieces(1)

                            part_data(indx).part_extents = sPartExtent

                            nid = AddPartToTable(sPdbName, _
                                                 m_current_part, _
                                                part_data(indx).qty, _
                                                part_data(indx).io, _
                                                part_data(indx).po, _
                                                part_data(indx).repr, _
                                                part_data(indx).part_extents)

                            currentCategoryRow = CreateCategoryRow(vgParts, "Filename", PathFile(m_current_part), m_current_part, m_current_part, "Filename", DB_HEADER, nid, sEmpty, 0)


                            If (part_user_var_data IsNot Nothing) Then
                                indx2 = part_data(indx).Var_Data_Count()
                            End If
                            lReturn = GetTotalPartTravel()
                            Dim indx3 As Long = 0

                            DeletePartVars(nid)

                            For indx3 = 0 To indx2 - 1

                                Select Case UCase(part_data(indx).Get_Var_Data_Descrip(indx2))

                                    Case "PIERCES"
                                        lReturn = modNesting.AddPartUserVarsToNestDb(nid, _
                                                                                        part_data(indx).Get_Var_Data_Descrip(indx2), _
                                                                                        CStr(g_num_Pierces))

                                    Case "BURN TRAVEL"
                                        lReturn = modNesting.AddPartUserVarsToNestDb(nid, _
                                                                                        part_data(indx).Get_Var_Data_Descrip(indx2), _
                                                                                        CStr(Round(g_CutTravel, Places.TenThousandths)))

                                    Case Else
                                        lReturn = modNesting.AddPartUserVarsToNestDb(nid, _
                                                                                        part_data(indx).Get_Var_Data_Descrip(indx2), _
                                                                                        part_data(indx).Get_Var_Data_Value(indx2))

                                End Select

                            Next


                        End If

                    End If

                Next

            End If

            modView.ViewActivate(VIEW_WIRE)
            modView.ViewRefresh()

            modFileIO.AllowMessages(True)

            vgParts.CollapseAllRows()

            vgParts.Visible = True


            dlgPartBrowser.Dispose()

        Catch ex As Exception

            MessageBox.Show("cmdAddMulti_Click: " & ex.Message)

        End Try


    End Sub

    Private Sub cmdAddParts_Click(sender As Object, e As EventArgs) Handles cmdAddParts.Click
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim sCandidate As String
        Dim sFileName As String
        Dim sExt As String
        Dim pre_rotate As Double
        Dim strip_layers As Boolean
        Dim sPdbName As String
        Dim spieces() As String
        Dim nid As Long
        Dim indx As Integer
        Dim sValue As String
        Dim sFieldName As String
        Dim nFieldType As Integer


        m_current_part = ""

        Try

            sCandidate = modFileIO.ImportFileBrowse(Me)

            If (sCandidate <> "") Then

                sExt = UCase$(PathExt(sCandidate))
                If (sExt = "MM2") Then

                    'The corresponding MM2 file name.
                    m_current_part = sCandidate

                Else

                    'The selected file is a CAD file
                    m_current_part = modFileIO.GetTargetName(sCandidate)

                End If

                If (m_current_part <> "") Then

                    pre_rotate = frmExplorer.GetPreRotate()
                    strip_layers = frmExplorer.GetStripLayers()

                    lReturn = modConversion.ConversionParametersSet( _
                        pre_rotate, False, strip_layers)

                    'At this point, the user has committed to importing the file.
                    modFileIO.AllowMessages(False)

                    sFileName = modFileIO.ImportFile(sCandidate, m_current_part)

                    modFileIO.AllowMessages(True)

                    'set the dirty flag to false to avoid the
                    '"Do You wnat to save" message
                    'from appearing on each add
                    ModelDirtyClear()

                End If

            End If


            If (m_current_part <> "") Then

                bFromAddButton = True

                Dim sPartExtent As String = CalculateDimensionsJustXY()

                spieces = Split(TV_NestConfig.FocusedNode.ParentNode.Tag, ",")
                sPdbName = spieces(1)



                nid = AddPartToTable(sPdbName, _
                                                 m_current_part, _
                                               1, _
                                                0, _
                                                4, _
                                                0, _
                                                sPartExtent)

                If (vgPartVars.Rows(0).ChildRows.Count > 9) Then

                    For indx = 10 To vgPartVars.Rows(0).ChildRows.Count - 1
                        nFieldType = GetValueFromDelimitedData(vgPartVars.Rows(0).ChildRows(indx).Tag, "VarDataType", 0)
                        sFieldName = GetValueFromDelimitedData(vgPartVars.Rows(0).ChildRows(indx).Tag, "DialogDisplay", 0)
                        sValue = vgPartVars.Rows(0).ChildRows(indx).Properties.Value

                        If (sValue = "") Then

                            sValue = 0

                        End If

                        Select Case nFieldType

                            Case DB_STR, DB_COMBO, DB_DCOMBO, DB_FILE, DB_FOLDER
                                sValue = sValue

                        End Select

                        AddPartUserVarsToNestDb(nid, sFieldName, sValue)

                    Next

                End If

                currentCategoryRow = CreateCategoryRow(vgParts, "Filename", PathFile(m_current_part), m_current_part, m_current_part, "Filename", DB_HEADER, nid, sEmpty, 0)


                ShowPartAndFillGrid()

                vgParts.FocusedRow = currentCategoryRow


            End If
            bFromAddButton = False

        Catch ex As Exception
            MessageBox.Show("CmdAddParts: " & ex.Message)
        End Try

    End Sub

    Private Sub vgParts_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgParts.CellValueChanged
        Dim sFieldName As String
        Dim nPartID As Integer
        Dim CVarValue As Object
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim nDataType As Integer

        Try
            If (bFromAddButton = False) Then
                nPartID = GetValueFromDelimitedData(vgParts.FocusedRow.Tag, "ID", 0)
                sFieldName = GetValueFromDelimitedData(e.Row.Tag, "DatVarName", sEmpty)
                nDataType = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", sEmpty))

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

                m_cnSettings = New OleDbConnection(connetionString)

                m_cnSettings.Open()

                CVarValue = GetCValueBasedOnVarType(nDataType, e.Row.Properties.Value, e.Row.Tag)

                sql = "UPDATE [Part] set [Part].[" & sFieldName & "] = " & CVarValue & " Where ([Part].[ID] =" & nPartID & " )"

                m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                m_daSettings.InsertCommand.ExecuteNonQuery()

                m_cnSettings.Close()
            End If

        Catch ex As Exception

            MessageBox.Show("vgPartVars_CellValueChanged: " & ex.Message)

        End Try


    End Sub

    Private Sub vgParts_CustomDrawRowHeaderCell(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CustomDrawRowHeaderCellEventArgs) Handles vgParts.CustomDrawRowHeaderCell
        If e.Row.GetType() Is GetType(CategoryRow) AndAlso vgParts.FocusedRow Is e.Row Then
            e.Appearance.BackColor = Color.Gold
        End If
    End Sub
    Private Sub vgParts_FocusedRowChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs) Handles vgParts.FocusedRowChanged
        ShowPartAndFillGrid()
    End Sub
    Private Sub vgParts_KeyUp(sender As Object, e As KeyEventArgs) Handles vgParts.KeyUp

        If (e.KeyCode = Windows.Forms.Keys.Delete) Then

            DeletePart()

        End If
    End Sub


    Private Function DeleteChildNodesByText(ByRef m_TreeList As TreeList, sTextToFind As String) As Long
        Dim op As New TreeListOperationFindNodeByText(sTextToFind)

        DeleteChildNodesByText = -1

        m_TreeList.NodesIterator.DoOperation(op)

        If op.Node IsNot Nothing Then

            op.Node.Selected = True

            If op.Node.HasChildren Then

                Dim i As Integer = 0

                Do While i < op.Node.Nodes.Count

                    op.Node.Nodes.RemoveAt(i)

                Loop

                DeleteChildNodesByText = 1

                m_TreeList.Refresh()

                m_TreeList.Focus()

            End If

        End If

    End Function
    Friend Class TreeListOperationFindNodeByText
        Inherits TreeListOperation
        Private resultNode As TreeListNode

        Private text As String
        Public Sub New(ByVal text As String)
            MyBase.New()
            Me.text = text
        End Sub
        Public Overrides Sub Execute(ByVal node As TreeListNode)

            For Each col As TreeListColumn In node.TreeList.Columns

                If node(col).ToString() = text Then

                    If resultNode Is Nothing Then

                        resultNode = node

                    End If

                End If

            Next col

        End Sub
        Public ReadOnly Property Node() As TreeListNode
            Get
                Return resultNode

            End Get

        End Property

    End Class
    Private Sub LoadResultsIntoTree(sPdbName As String)
        Dim dsSheets As DataSet
        Dim dsParts As DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim SheetFileName As String
        Dim sSheetTag As String
        Dim cnt As Integer
        Dim cnt2 As Integer
        Dim i As Integer
        Dim i2 As Integer
        Dim sql As String
        Dim tl As TreeList
        Dim nPartId As Integer
        Dim sPartName As String
        Dim sFullSheetName As String = Nothing
        Try
            tl = TV_NestConfig

            Dim currentCategoryRow As CategoryRow = Nothing

            If (DoesTableExist("Sheet Result", sPdbName) = True) Then

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

                sql = "SELECT * FROM [Sheet Result]"

                connection = New OleDbConnection(connetionString)

                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                dsSheets = New DataSet

                oledbAdapter.Fill(dsSheets)

                oledbAdapter.Dispose()

                connection.Close()

                cnt = dsSheets.Tables(0).Rows.Count

                If (cnt > 0) Then

                    CFG_RESULTS_NODE = GetResultNode(CFG_SETTINGS_NODE)
                    CFG_RESULTS_NODE(0) = "Results Completed"



                    For i = 0 To cnt - 1
                        frmMain.NestingImageCollection.Images.Clear()


                        SheetFileName = dsSheets.Tables(0).Rows(i).Item("Sheet Filename")

                        If (i = 0) Then
                            sFullSheetName = SheetFileName
                        End If

                        sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Sheet Filename] = '" & SheetFileName & "' )"

                        sSheetTag = TAG_RESULTS_SHEET & "," & SheetFileName

                        SheetFileName = PathFile(SheetFileName)

                        CFG_RESULTS_SHEET = tl.AppendNode(New Object() {SheetFileName}, CFG_RESULTS_NODE, sSheetTag)

                        If (DoesTableExist("Part Result", sPdbName) = True) Then
                            connection = New OleDbConnection(connetionString)

                            connection.Open()

                            oledbAdapter = New OleDbDataAdapter(sql, connection)

                            dsParts = New DataSet

                            oledbAdapter.Fill(dsParts)

                            oledbAdapter.Dispose()

                            connection.Close()
                            'tl.FocusedNode = CFG_RESULTS_SHEET

                            cnt2 = dsParts.Tables(0).Rows.Count

                            If (cnt2 > 0) Then

                                For i2 = 0 To cnt2 - 1

                                    sPartName = dsParts.Tables(0).Rows(i2).Item("Part Name")

                                    nPartId = dsParts.Tables(0).Rows(i2).Item("Part ID")

                                    SheetFileName = dsParts.Tables(0).Rows(i2).Item("Sheet Filename")

                                    sSheetTag = TAG_RESULTS_PART & "," & sPartName & "," & sPdbName & "," & SheetFileName


                                    CFG_RESULTS_PART = tl.AppendNode(New Object() {sPartName}, CFG_RESULTS_SHEET, sSheetTag)

                                Next

                                dsParts.Dispose()
                                dsParts = Nothing

                            End If
                        End If


                    Next
                    dsSheets.Dispose()


                End If

            End If


            frmMain.ShowCombos(sFullSheetName)




        Catch ex As Exception

            MessageBox.Show("LoadResultsIntoTree: " & ex.Message)

        End Try
    End Sub

    Private Sub ShowSheetResults(sSheetTag As String)
        Dim sPieces() As String
        Dim sSheetFilename As String
        Dim dsSheets As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim the_PDB_Node_Name As String

        Try

            vgResults.Rows.Clear()
            vgResults.SuspendLayout()

            sPieces = Split(TV_NestConfig.FocusedNode.ParentNode.ParentNode.Tag, ",")

            the_PDB_Node_Name = sPieces(1)

            sPieces = Split(TV_NestConfig.FocusedNode.Tag, ",")

            sSheetFilename = sPieces(1)

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & the_PDB_Node_Name & "';"

            sql = "Select * From [Sheet Result] Where ([Sheet Result].[Sheet Filename] = '" & sSheetFilename & "' )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsSheets)

            oledbAdapter.Dispose()

            Dim SheetCategoryRow As New CategoryRow

            SheetCategoryRow = CreateCategoryRow(vgResults, "Sheet Fileename", "Sheet Infromation", sSheetFilename, sSheetFilename, "Sheet Filename", DB_HEADER, 0, sEmpty, 0)

            For Each Row As DataRow In dsSheets.Tables(0).Rows

                For Each Coll As DataColumn In dsSheets.Tables(0).Columns

                    Dim sValue As String = Row(Coll.ColumnName).ToString()

                    'We do not want to show the interal fields such as ID  so skip over tem
                    If (Coll.Ordinal > 3) Then

                        If (IsNumeric(sValue)) Then

                            sValue = String.Format("{0:N3}", Double.Parse(sValue))

                        End If

                        If (Coll.ColumnName <> "Image") Then
                            SheetCategoryRow.ChildRows.Add(CreateStringEditorRow(vgResults, _
                                                                       Coll.ColumnName, _
                                                                      Coll.ColumnName, _
                                                                      sValue, _
                                                                      sValue, _
                                                                       Coll.ColumnName, _
                                                                      DB_STR, _
                                                                      0, _
                                                                      sEmpty, 0))
                        End If
                    End If

                Next

            Next

            vgResults.BestFit()

            vgResults.ResumeLayout()


            connection.Close()

        Catch ex As Exception

            MessageBox.Show("ShowSheetResults: " & ex.Message)

        End Try

    End Sub
    Private Function GetColumnNamesInTable(ByVal connectionString As String, ByVal tableName As String) As List(Of String)
        Dim connection As OleDbConnection = New OleDbConnection(connectionString)
        Dim restrictions As String() = New String() {Nothing, Nothing, tableName, Nothing}

        connection.Open()

        Dim dataTable As DataTable = connection.GetSchema("Columns", restrictions)

        connection.Close()

        Dim returnList As List(Of String) = New List(Of String)

        For Each dataRow As DataRow In dataTable.Rows

            returnList.Add(dataRow("Column_Name"))

        Next

        Return returnList

    End Function

    Private Sub LoadPartsFromDB()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim dsParts As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cnt As Integer
        Dim i As Integer
        Dim sql As String
        Dim sPartName As String
        Dim nID As Integer

        Try

            vgParts.Rows.Clear()

            currentCategoryRow = CreateCategoryRow(vgParts, "Part List", "Part List", "Part List", "Part List", "Part List", DB_HEADER, 0, sEmpty, 0)

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            sql = "Select * From Part"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsParts)

            oledbAdapter.Dispose()

            connection.Close()

            cnt = dsParts.Tables(0).Rows.Count

            If (cnt > 0) Then
                frmMain.NestingImageCollection.Clear()

                For i = 0 To cnt - 1

                    sPartName = dsParts.Tables(0).Rows(i).Item("Filename")

                    nID = dsParts.Tables(0).Rows(i).Item("ID")

                    currentCategoryRow = CreateCategoryRow(vgParts, "Filename", PathFile(sPartName), sPartName, sPartName, "Filename", DB_HEADER, nID, sEmpty, 0)

                Next

                vgParts.FocusedRow = vgParts.Rows(1)
                vgPartVars.Enabled = True

            End If


        Catch ex As Exception

            MessageBox.Show("LoadPartsFromDB: " & ex.Message)

        End Try

    End Sub

    Private Sub FillPartGridWithValues(nPartID As Integer)
        Dim dsParts As New DataSet
        Dim dsPartVars As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cnt As Integer
        Dim sFieldName As String
        Dim nFieldType As Integer
        Dim sql As String
        Dim m_Temp_Value
        Dim m_Options As String


        Try
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            sql = "Select * From Part Where (Part.ID = " & nPartID & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsParts)

            oledbAdapter.Dispose()

            cnt = dsParts.Tables(0).Rows.Count

            If (cnt > 0) Then

                For Each row As CategoryRow In vgPartVars.Rows

                    For Each childRow As EditorRow In row.ChildRows

                        'We stop at 10 because that defines satndard fields.
                        'anything over 10 will be a user var and must be filled by the partvars table


                        nFieldType = GetValueFromDelimitedData(childRow.Tag, "VarDataType", 0)
                        m_Options = GetValueFromDelimitedData(childRow.Tag, "Options", "")

                        If (childRow.Index < 10) Then

                            sFieldName = GetValueFromDelimitedData(childRow.Tag, "DatVarName", 0)

                            m_Temp_Value = dsParts.Tables(0).Rows(0).Item(sFieldName)

                        Else

                            sFieldName = GetValueFromDelimitedData(childRow.Tag, "DialogDisplay", 0)

                            sql = "Select * From [Part Variables] Where ([Part Variables].[Part ID] = " & nPartID & " )"
                            sql = "Select * From [Part Variables] Where ([Part Variables].[Part ID] = " & nPartID & " )" & _
                                    "And ([Part Variables].Description = '" & sFieldName & "' )"

                            oledbAdapter = New OleDbDataAdapter(sql, connection)

                            oledbAdapter.Fill(dsPartVars)

                            oledbAdapter.Dispose()

                            If (dsPartVars.Tables(0).Rows.Count > 0) Then

                                m_Temp_Value = dsPartVars.Tables(0).Rows(0).Item("Value")
                                dsPartVars.Clear()
                                dsPartVars.Dispose()

                            Else
                                dsPartVars.Clear()
                                dsPartVars.Dispose()
                                GoTo EarlyExit

                            End If
                        End If

                        Select Case nFieldType

                            Case DB_DCOMBO
                                If (childRow.Index < 10) Then
                                    m_Temp_Value = GetOptionText(";", m_Options, m_Temp_Value)
                                End If


                            Case DB_BOOL

                                If (m_Temp_Value = 0) Then

                                    m_Temp_Value = False

                                Else

                                    m_Temp_Value = True

                                End If

                        End Select

                        childRow.Properties.Value = m_Temp_Value

                        m_Temp_Value = sEmpty


                    Next
                Next

            End If

EarlyExit:
            connection.Close()

        Catch ex As Exception

            MessageBox.Show("FillPartGridWithValues: " & ex.Message)

        End Try

    End Sub

    Private Sub vgPartVars_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgPartVars.CellValueChanged
        Dim sql As String
        Dim ds As New DataSet

        Dim connetionString As String
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable

        Dim s_DatVarName As String
        Dim n_Part_ID As Long
        Dim sRow_Value As String
        Dim sEdit_Value As String
        Dim nDataType As String

        sEdit_Value = Nothing

        Try
            sRow_Value = e.Row.Properties.Value

            nDataType = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", sEmpty))

            n_Part_ID = GetValueFromDelimitedData(vgParts.FocusedRow.Tag, "nRecordID", 0)

            s_DatVarName = GetValueFromDelimitedData(e.Row.Tag, "DatVarName", 0)

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            If (e.Row.VisibleIndex < 10) Then ' we edit the standard part variables

                Select Case UCase(s_DatVarName)

                    Case "PART QUANTITY", "ROTATION NUM", "ROTATION START", "PART PRIORITY", "COST PER PART", "PRENEST", "FILL PART"

                        sEdit_Value = sRow_Value

                    Case "REPRESENTATION"

                        Select Case UCase(sRow_Value)

                            Case "ACTUAL PART"
                                sEdit_Value = 0

                            Case "BOUNDING BOX"
                                sEdit_Value = 1

                            Case "RUBBERBAND BOX"
                                sEdit_Value = 2
                        End Select

                    Case "MIRRORPART"

                        Select Case UCase(sRow_Value)

                            Case "NONE"
                                sEdit_Value = 0

                            Case "ALLOW"
                                sEdit_Value = 1

                            Case "PRE MIRROR"
                                sEdit_Value = 2

                        End Select



                End Select

                sql = "UPDATE [Part] set [Part].[" & s_DatVarName & "] = " & sEdit_Value & " Where ([Part].[ID] =" & n_Part_ID & " )"

                m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                m_daSettings.InsertCommand.ExecuteNonQuery()
            Else

                sql = "UPDATE [Part Variables] set [Part Variables].[Value] = '" & sRow_Value & _
                    "'  Where ([Part Variables].[Part ID] = " & n_Part_ID & " ) And ([Part Variables].[Description] = '" & e.Row.Properties.Caption & "' )"

                m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                m_daSettings.InsertCommand.ExecuteNonQuery()


            End If
        Catch ex As Exception

            MessageBox.Show("vgPartVars_CellValueChanged: " & ex.Message)

        End Try

        m_cnSettings.Close()

    End Sub

    Private Sub vgPartVars_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles vgPartVars.ShowingEditor
        If (vgPartVars.FocusedRow.Properties.Caption = "Part Extents") Then

            vgPartVars.FocusedRow.Properties.ReadOnly = True

        Else

            BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)

        End If

    End Sub

    Private Sub vgSettingsProplist_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles vgSettingsProplist.ShowingEditor

        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)

    End Sub

    Private Function CheckIfBuildEnabled() As Boolean
        Dim dsRecords As New DataSet
        Dim dsSetup As New DataSet
        Dim dsToolSetup As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cnt As Integer
        Dim sql As String
        Dim bHasMaterial As Boolean
        Dim bHasMachine As Boolean
        Dim bHasToolSetup As Boolean
        Dim bHasParts As Boolean
        Dim n_MachineID As Integer
        Dim n_Toolsetup As Integer

        bHasMachine = False
        bHasMaterial = False
        bHasToolSetup = False
        bHasParts = False

        CheckIfBuildEnabled = False

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            sql = "Select Setup.* From Setup Where (Setup.DialogDisplay = 'Machine' )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsSetup)

            oledbAdapter.Dispose()

            cnt = dsSetup.Tables(0).Rows.Count


            If (cnt > 0) Then
                n_MachineID = dsSetup.Tables(0).Rows(0).Item("CValue")

                If (n_MachineID > 0) Then

                    bHasMachine = True

                End If
            End If

            dsSetup.Dispose()


            sql = "Select * From [Material Inventory]"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsRecords)

            oledbAdapter.Dispose()

            cnt = dsRecords.Tables(0).Rows.Count

            If (cnt > 0) Then

                bHasMaterial = True

            End If

            dsRecords.Dispose()

            sql = "Select * From [Part]"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsRecords)

            oledbAdapter.Dispose()

            cnt = dsRecords.Tables(0).Rows.Count

            If (cnt > 0) Then

                bHasParts = True

            End If

            dsRecords.Dispose()


            sql = "Select Setup.* From Setup Where (Setup.DialogDisplay = 'Tool Setup' )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsToolSetup)

            oledbAdapter.Dispose()

            cnt = dsToolSetup.Tables(0).Rows.Count


            If (cnt > 0) Then

                n_Toolsetup = dsToolSetup.Tables(0).Rows(0).Item("CValue")

                If (n_Toolsetup > 0) Then

                    bHasToolSetup = True

                End If
            End If

            dsToolSetup.Dispose()

            connection.Close()

            If (bHasMachine = True And bHasToolSetup = True And bHasMaterial = True And bHasParts = True) Then

                CheckIfBuildEnabled = True

            End If

        Catch ex As Exception

            MessageBox.Show("CheckIfBuildEnabled: " & ex.Message)

        End Try
    End Function

    Private Sub ShowPartAndFillGrid()
        Dim sMm2Filename As String
        Dim nPartID As Integer

        Try

            If (TypeOf vgParts.FocusedRow Is CategoryRow) Then

                sMm2Filename = GetValueFromDelimitedData(vgParts.FocusedRow.Tag, "CValue", "")

                If (Not bFromAddButton) Then

                    sMm2Filename = ImportFile(sMm2Filename, sMm2Filename)

                    bFromAddButton = False

                End If


                nPartID = GetValueFromDelimitedData(vgParts.FocusedRow.Tag, "nRecordID", 0)

                If (nPartID > 0) Then

                    FillPartGridWithValues(nPartID)

                    Me.cmdDelete.Enabled = True

                Else

                    Me.cmdDelete.Enabled = False

                End If

            End If

            vgPartVars.Enabled = cmdDelete.Enabled

        Catch ex As Exception

            MessageBox.Show("ShowPartAndFillGrid: " & ex.Message)

        End Try
    End Sub

    Private Sub DeletePart()
        Dim nPartID As Integer
        Dim connetionString As String
        Dim sql As String
        Dim m_dtPart As New DataTable
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim nCurrentRow As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim nCurrentRowIndex As Integer

        Try

            nPartID = GetValueFromDelimitedData(vgParts.FocusedRow.Tag, "nRecordID", 0)

            If (nPartID > 0) Then

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

                sql = "DELETE Part.* From Part Where (Part.ID = " & nPartID & " )"

                m_cnPart = New OleDbConnection(connetionString)

                m_cnPart.Open()

                m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

                m_daPart.InsertCommand.ExecuteNonQuery()

                m_cnPart.Close()

                nCurrentRow = vgParts.FocusedRow

                nCurrentRowIndex = nCurrentRow.Index

                vgParts.Rows.Remove(vgParts.FocusedRow)

                If ((nCurrentRowIndex - 1) < vgParts.Rows.Count - 1) Then

                    vgParts.FocusedRow = vgParts.Rows(nCurrentRowIndex - 1)

                    ShowPartAndFillGrid()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show("DeletePart: " & ex.Message)
        End Try

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        DeletePart()
        vgPartVars.Enabled = False

        If (vgParts.Rows.Count > 0) Then
            vgParts.FocusedRow = vgParts.Rows.LastVisible

        End If

    End Sub
    Private Sub LoadMaterialFromDB()
        Dim cnt As Integer
        Dim connetionString As String
        Dim sql As String
        Dim m_dtMaterial As New DataTable
        Dim m_dsMaterial As New DataSet
        Dim m_cnMaterial As New OleDb.OleDbConnection
        Dim m_daPMaterial As New OleDb.OleDbDataAdapter
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim iQuantity As Integer
        Dim dWeight As Double
        Dim dCostPerUnit As Double
        Dim nID As Long
        Dim sDescription As String
        Dim Rem_ID As Long

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            m_cnMaterial = New OleDbConnection(connetionString)

            m_cnMaterial.Open()

            sql = "Select * From [Material Inventory]"

            m_daPMaterial = New OleDbDataAdapter(sql, m_cnMaterial)

            m_daPMaterial.Fill(m_dsMaterial)

            m_daPMaterial.Dispose()

            cnt = m_dsMaterial.Tables(0).Rows.Count

            If (cnt > 0) Then

                For i = 0 To cnt - 1


                    nID = m_dsMaterial.Tables(0).Rows(i).Item("ID")

                    sDescription = m_dsMaterial.Tables(0).Rows(i).Item("Description")

                    Dim sActualMaterial As New EditorRow()

                    sActualMaterial.Properties.Caption = sDescription
                    sActualMaterial.Tag = CHR1 & "IsRem" & CHR2 & False & _
                                            CHR1 & "MatID" & CHR2 & nID

                    ' adding the Material row to the Material Type row's child collection 
                    vgMaterial.Rows(0).ChildRows.Add(sActualMaterial)


                    dLength = m_dsMaterial.Tables(0).Rows(i).Item("Length")
                    dWidth = m_dsMaterial.Tables(0).Rows(i).Item("Width")
                    dThickness = m_dsMaterial.Tables(0).Rows(i).Item("Thickness")
                    iQuantity = m_dsMaterial.Tables(0).Rows(i).Item("Quantity")
                    dWeight = m_dsMaterial.Tables(0).Rows(i).Item("Weight")
                    dCostPerUnit = m_dsMaterial.Tables(0).Rows(i).Item("Cost Per Unit")

                Next

            End If

            m_dsMaterial.Dispose()

            sql = "Select * From [Remnant Inventory]"

            m_daPMaterial = New OleDbDataAdapter(sql, m_cnMaterial)

            m_daPMaterial.Fill(m_dsMaterial)

            m_daPMaterial.Dispose()

            cnt = m_dsMaterial.Tables(0).Rows.Count

            If (cnt > 0) Then

                For i = 0 To cnt - 1
                    If (IsDBNull(m_dsMaterial.Tables(0).Rows(i).Item("FileName")) = False) Then

                        sDescription = PathFile(m_dsMaterial.Tables(0).Rows(i).Item("FileName"))

                        Rem_ID = m_dsMaterial.Tables(0).Rows(i).Item("Type Id")

                        nID = GetRemnantMaterialType(Rem_ID)

                        Dim sActualMaterial As New EditorRow()

                        sActualMaterial.Properties.Caption = sDescription
                        sActualMaterial.Tag = CHR1 & "IsRem" & CHR2 & True & _
                                            CHR1 & "RemID" & CHR2 & Rem_ID & _
                                            CHR1 & "MatID" & CHR2 & nID

                        ' adding the Material row to the Material Type row's child collection 
                        vgMaterial.Rows(0).ChildRows.Add(sActualMaterial)
                    End If

                Next

            End If

            m_cnMaterial.Close()

            vgMaterial.BestFit()


        Catch ex As Exception

            MessageBox.Show("LoadMaterialFromDB: " & ex.Message)

        End Try
    End Sub

    Private Function GetRemnantMaterialType(nRemID As Long) As Long
        Dim Sql2 As String
        Dim dtRemnantInv As DataTable = Nothing
        Dim rem_material As String

        Try
            GetRemnantMaterialType = -1

            Sql2 = "SELECT * FROM RemnantVar WHERE (RemnantID = " & nRemID & " )"

            dtRemnantInv = ConnectToCMDB(Sql2)

            For ni = 0 To dtRemnantInv.Rows.Count - 1

                Select Case UCase(dtRemnantInv.Rows(ni).Item("InternalName"))

                    Case "MATERIAL"
                        rem_material = dtRemnantInv.Rows(ni).Item("Value")
                        GetRemnantMaterialType = GetMaterialTypeIDFromDescription(rem_material)

                        Exit For

                End Select


            Next

        Catch ex As Exception

            MessageBox.Show("LoadMaterialFromDB: " & ex.Message)

        End Try

        DatabaseClose()

    End Function
    Public Sub LoadPDB(m_pdb_filename As String)


        If (FileExists(m_pdb_filename) = True) Then
            ArePartsLoaded = False

            modAdmin.ModelReset()

            vgResults.Rows.Clear()
            vgMaterial.Rows.Clear()
            vgParts.Rows.Clear()

            m_isVirginDB = False

            Select Case UCase(PathExt(m_pdb_filename))
                Case "PDB"
                    modNesting.SetupInfoGet(m_pdb_filename)

                    TV_NestConfig.SuspendLayout()

                    CreateRootNodes(TV_NestConfig, m_pdb_filename)

                    PopulateDefaultSettings()
                    GetSetupValuesFromPDB()


                    LoadResultsIntoTree(m_pdb_filename)

                    TV_NestConfig.ResumeLayout()

                    frmMain.ShowCombos("")

                    bFromAddButton = False

                    DeleteRemantInventory()

                    bFromMrp = False

                Case "MRP"

                    CreateMRPRootNodes(TV_NestConfig, m_pdb_filename)
                    bCameFromStartUp = False


                    TV_NestConfig.Visible = True
                    TV_NestConfig.ExpandToLevel(2)
                    bFromMrp = True

                    If (IS_CCS_FAB = True) Then

                        Me.fcbXlsName.Text = PathXLSGet()

                    End If

            End Select

            modView.ViewActivate(VIEW_WIRE)

        End If

    End Sub
    Sub DeleteRemantInventory()
        Dim connetionString As String
        Dim sql As String
        Dim m_cnMaterial As New OleDb.OleDbConnection
        Dim cmd As OleDbCommand
        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

        m_cnMaterial = New OleDbConnection(connetionString)

        m_cnMaterial.Open()

        Sql = "DELETE * FROM [Remnant Inventory]"

        cmd = New OleDbCommand(Sql, m_cnMaterial)

        cmd.ExecuteNonQuery()

        m_cnMaterial.Close()


    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function

    Public Sub VirginStatusSet(is_virgin As Boolean)
        m_isVirginDB = is_virgin
    End Sub

    Private Sub frmNestingProtoType_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        m_is_active = False
        '        Me.Dispose()

    End Sub

    Private Sub frmNestingProtoType_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If (e.KeyCode = System.Windows.Forms.Keys.Escape) Then
            'DefaultToolTipController1.DefaultController.HideHint()
            ModeCancelCurrent()
        End If

    End Sub

    Private Sub vgMaterial_DoubleClick1(sender As Object, e As EventArgs) Handles vgMaterial.DoubleClick
        Dim sMatInvenotryCap
        Dim sMatRemnantCap
        Dim dtMaterialType As DataTable = Nothing
        Dim sql As String
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim iQuantity As Integer
        Dim dWeight As Double
        Dim dCostPerUnit As Double
        Dim nTypeID As Long
        Dim sDescription As String
        Dim nMatID As Long
        Dim sCMDB_MatID As Long
        Dim nFocusIndex As Integer
        Dim dtRemnantInv As DataTable = Nothing
        Dim Rem_Name As String = Nothing
        Dim rem_length As Double
        Dim rem_width As Double
        Dim rem_thickness As Double
        Dim rem_qty As Long = 1
        Dim rem_area As Double
        Dim Rem_Date As String = Nothing
        Dim rem_material As String
        Dim rem_weight As Double = 0
        Dim rem_cost As Double = 0

        Try


            If (vgMaterial.FocusedRow.Level = 2) Then

                sMatInvenotryCap = vgMaterial.FocusedRow.ParentRow.ParentRow.Properties.Caption

                sMatRemnantCap = vgMaterial.FocusedRow.ParentRow.ParentRow.Properties.Caption

                If (sMatInvenotryCap = "Material Inventory" Or sMatRemnantCap = "Remnant Inventory") Then
                    nTypeID = GetMaterialTypeIDFromDescription(vgMaterial.FocusedRow.Properties.Caption)

                    sDescription = vgMaterial.FocusedRow.Properties.Caption

                    Dim sActualMaterial As New EditorRow

                    sActualMaterial.Properties.Caption = vgMaterial.FocusedRow.Properties.Caption

                    sCMDB_MatID = CLng(GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "MatID", 0))

                    sActualMaterial.Tag = vgMaterial.FocusedRow.Tag

                    ' adding the Material row to the Material Type row's child collection 
                    nFocusIndex = vgMaterial.Rows(0).ChildRows.Add(sActualMaterial)

                    vgMatVars.Rows.Clear()

                    Dim rowParameters As New CategoryRow("Parameters")

                    vgMatVars.Rows.Add(rowParameters)

                    If (sMatInvenotryCap = "Material Inventory") Then

                        sql = "Select * From [Material Inventory] Where (ID = " & sCMDB_MatID & " )"

                        dtMaterialType = ConnectToCMDB(sql)

                        For i = 0 To dtMaterialType.Rows.Count - 1

                            dLength = dtMaterialType.Rows(i).Item("Length")
                            dWidth = dtMaterialType.Rows(i).Item("Width")
                            iQuantity = dtMaterialType.Rows(i).Item("Quantity")
                            dWeight = dtMaterialType.Rows(i).Item("Weight")
                            dCostPerUnit = dtMaterialType.Rows(i).Item("Cost Per Unit")
                            dThickness = dtMaterialType.Rows(i).Item("Thickness")


                            nMatID = AddMaterialToMaterialInventorys(sDescription, nTypeID, dLength, dWidth, dThickness, dWeight, iQuantity, dCostPerUnit)

                            lReturn = SetParameterValues(rowParameters, dLength, dWidth, dThickness, iQuantity, dWeight, dCostPerUnit, sDescription, nMatID)


                            Dim nmaybe As EditorRow = vgMaterial.Rows(0).ChildRows.LastVisible

                            vgMaterial.FocusedRow = nmaybe

                        Next

                    ElseIf (sMatRemnantCap = "Remnant Inventory") Then

                        sCMDB_MatID = CLng(GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "RemID", 0))

                        sql = "SELECT * FROM RemnantVar WHERE (RemnantID = " & sCMDB_MatID & " )"

                        dtRemnantInv = ConnectToCMDB(sql)

                        For ni = 0 To dtRemnantInv.Rows.Count - 1

                            Select Case UCase(dtRemnantInv.Rows(ni).Item("InternalName"))
                                Case "NAME"
                                    Rem_Name = dtRemnantInv.Rows(ni).Item("Value")

                                Case "LENGTH"
                                    rem_length = dtRemnantInv.Rows(ni).Item("Value")

                                Case "WIDTH"
                                    rem_width = dtRemnantInv.Rows(ni).Item("Value")

                                Case "THICKNESS"
                                    rem_thickness = dtRemnantInv.Rows(ni).Item("Value")

                                Case "AREA"
                                    rem_area = dtRemnantInv.Rows(ni).Item("Value")

                                Case "CREATION_DATE"
                                    Rem_Date = dtRemnantInv.Rows(ni).Item("Value")

                                Case "MATERIAL"
                                    rem_material = dtRemnantInv.Rows(ni).Item("Value")


                            End Select


                        Next

                        nMatID = AddRemnantToMaterialInventorys(Rem_Name, sCMDB_MatID, rem_length, rem_width, rem_thickness, rem_area, rem_weight, rem_qty, rem_cost, Rem_Date)

                        lReturn = SetParameterValues(rowParameters, dLength, dWidth, dThickness, iQuantity, dWeight, dCostPerUnit, sDescription, nMatID)
                        'sActualMaterial.Tag = nMatID

                        Dim nmaybe As EditorRow = vgMaterial.Rows(0).ChildRows.LastVisible

                        vgMaterial.FocusedRow = nmaybe

                        DatabaseClose()

                    End If

                    vgMaterial.BestFit()

                    cmdBuild.Text = "Build Current"
                    cmdBuild.Enabled = CheckIfBuildEnabled()

                    DatabaseClose()

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("vgMaterial_DoubleClick: " & ex.Message)

        End Try

    End Sub

    Private Sub vgMaterial_KeyUp(sender As Object, e As KeyEventArgs) Handles vgMaterial.KeyUp
        Dim nID As Long
        Dim rTheCurrentRow As Long

        Dim row As DevExpress.XtraVerticalGrid.Rows.BaseRow = vgMaterial.FocusedRow


        If (e.KeyCode = Windows.Forms.Keys.Delete) Then
            rTheCurrentRow = vgMaterial.FocusedRow.Index

            If (vgMaterial.FocusedRow.ParentRow.Index = 0) Then 'We are under the Process order node

                If (vgMaterial.Rows(0).HasChildren = True) Then

                    nID = GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "nRecordID", 0)

                    row.ParentRow.ChildRows.Remove(row)

                End If

            End If

        End If
    End Sub

    Private Sub vgMaterial_MouseClick(sender As Object, e As MouseEventArgs) Handles vgMaterial.MouseClick


        If (IsNothing(vgMaterial.FocusedRow.ParentRow) = False) Then
            If (e.Button = Windows.Forms.MouseButtons.Right And vgMaterial.FocusedRow.ParentRow.Index = 0) Then 'We are under the Process order node) Then

                PopUp_TV_Config.ItemLinks.Clear()

                For Each item As BarItem In CFG_Man_BarMan.Items

                    If item.Category.Name = "Material" Then

                        PopUp_TV_Config.AddItem(item)

                    End If
                Next

                PopUp_TV_Config.ShowPopup(Control.MousePosition)

            End If
        End If
    End Sub

    Private Sub bbRemoveMat_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbRemoveMat.ItemClick
        Dim nID As Long
        Dim rTheCurrentRow As Long
        Dim sql As String
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim cmd As OleDbCommand

        Dim row As DevExpress.XtraVerticalGrid.Rows.BaseRow = vgMaterial.FocusedRow

        rTheCurrentRow = vgMaterial.FocusedRow.Index

        If (vgMaterial.FocusedRow.ParentRow.Index = 0) Then 'We are under the Process order node

            nID = GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "MatID", 0)

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            sql = "DELETE * From [Material Inventory] Where ([Material Inventory].ID =" & nID & " )"

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            connection.Close()

            row.ParentRow.ChildRows.Remove(row)

        End If

    End Sub

    Private Function SetParameterValues(rowParameters As CategoryRow, _
                                        dLength As Double, _
                                        dWidth As Double, _
                                        dThickness As Double, _
                                        iQuantity As Integer, _
                                        dWeight As Double, _
                                        dCostPerUnit As Double, _
                                        sDescription As String, _
                                        nMatID As Integer) As Long

        Dim editorRow As New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Length"
        editorRow.Properties.Value = dLength
        editorRow.Tag = EncodeTag("Length", "Length", dLength, dLength, "Length", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        Dim reCalcEdit As New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Width"
        editorRow.Properties.Value = dWidth
        editorRow.Tag = EncodeTag("Width", "Width", dWidth, dWidth, "Width", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        reCalcEdit = New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Thickness"
        editorRow.Properties.Value = dThickness
        editorRow.Tag = EncodeTag("Thickness", "Thickness", dLength, dLength, "Thickness", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        reCalcEdit = New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Quantity"
        editorRow.Properties.Value = iQuantity
        editorRow.Tag = EncodeTag("Quantity", "Quantity", iQuantity, iQuantity, "Quantity", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        reCalcEdit = New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

    End Function
    Private Function SetRemParameterValues(rowParameters As CategoryRow, _
                                     dLength As Double, _
                                     dWidth As Double, _
                                     dThickness As Double, _
                                     iQuantity As Integer, _
                                     sFilename As String, _
                                     sCreationDate As String, _
                                     dWeight As Double, _
                                     dCostPerUnit As Double, _
                                     nTypeId As Integer, _
                                     sDescription As String, _
                                     nMatID As Integer) As Long

        Dim editorRow As New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Length"
        editorRow.Properties.Value = dLength
        editorRow.Tag = EncodeTag("Length", "Length", dLength, dLength, "Length", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        Dim reCalcEdit As New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Width"
        editorRow.Properties.Value = dWidth
        editorRow.Tag = EncodeTag("Width", "Width", dWidth, dWidth, "Width", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        reCalcEdit = New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Thickness"
        editorRow.Properties.Value = dThickness
        editorRow.Tag = EncodeTag("Thickness", "Thickness", dLength, dLength, "Thickness", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        reCalcEdit = New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Quantity"
        editorRow.Properties.Value = 1
        editorRow.Tag = EncodeTag("Quantity", "Quantity", 1, 1, "Quantity", DB_INT, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        reCalcEdit = New RepositoryItemCalcEdit()

        vgMatVars.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Filename"
        editorRow.Properties.Value = sFilename
        editorRow.Tag = EncodeTag("Filename", "Filename", sFilename, sFilename, "Filename", DB_STR, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

        editorRow = New EditorRow()

        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = "Creation Date"
        editorRow.Properties.Value = sCreationDate
        editorRow.Tag = EncodeTag("Creation Date", "Creation Date", sCreationDate, sCreationDate, "Creation Date", DB_STR, nMatID, sEmpty, 0)

        rowParameters.ChildRows.Add(editorRow)

    End Function

    Private Sub vgMaterial_MouseUp(sender As Object, e As MouseEventArgs) Handles vgMaterial.MouseUp
        Dim dtMaterialType As DataTable = Nothing
        Dim indx As Integer
        Dim sActualMaterial As New EditorRow()
        Dim bIsRem As Boolean

        sActualMaterial.Properties.Caption = vgMaterial.FocusedRow.Properties.Caption

        sActualMaterial.Tag = vgMaterial.FocusedRow.Tag

        If (vgMaterial.FocusedRow.Level = 1) Then

            indx = vgMaterial.FocusedRow.Index

            If (indx >= 0 And vgMaterial.Rows(0).HasChildren = True) Then


                bIsRem = CBool(GetValueFromDelimitedData(vgMaterial.FocusedRow.Tag, "IsRem", False))

                If (bIsRem = True) Then

                    LoadRemnantParams()
                    Dim childRows As VGridRows = vgMatVars.Rows(0).ChildRows

                    For Each childRow As EditorRow In childRows

                        childRow.Properties.ReadOnly = True

                    Next

                Else

                    PopulateMaterialParameters(sActualMaterial)

                End If

            End If

        ElseIf (vgMaterial.FocusedRow.Level = 2) Then

            If (vgMaterial.FocusedRow.Properties.FieldName = "Remnant") Then

                LoadRemnantParams()

            Else

                LoadMaterialParams()

            End If

            Dim childRows As VGridRows = vgMatVars.Rows(0).ChildRows

            For Each childRow As EditorRow In childRows

                childRow.Properties.ReadOnly = True

            Next
        End If

    End Sub

    Private Sub cmdAddKit_Click(sender As Object, e As EventArgs) Handles cmdAddKit.Click
        Dim Pdb_FileOpen As New OpenFileDialog
        Dim currentCategoryRow As CategoryRow = Nothing

        Try

            Pdb_FileOpen.Filter = "PDB files (*.pdb)|*.pdb"
            Pdb_FileOpen.FilterIndex = 1
            Pdb_FileOpen.RestoreDirectory = True
            Pdb_FileOpen.InitialDirectory = PathNestFolder()

            If Pdb_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                m_pdb_filename = Pdb_FileOpen.FileName

                LoadPDB(m_pdb_filename)

            End If

            Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception

            MessageBox.Show("cmdAddKit_Click: " & ex.Message)

        End Try

    End Sub


    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Private Sub RemoveExistingResults()
        Dim sql As String = Nothing
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim cmd As OleDbCommand = New OleDbCommand


        Try
            If (DoesTableExist("SheetTooling", PathPDB()) = True) Then

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                connection = New OleDbConnection(connetionString)

                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                cmd = New OleDbCommand(sql, connection)

                cmd.CommandText = "DROP TABLE [SheetTooling]"

                cmd.ExecuteNonQuery()

                connection.Close()

                connection.Dispose()

            End If

        Catch ex As Exception

            MessageBox.Show("RemoveExistingResults: " & ex.Message)

        End Try


    End Sub

    Private Sub sbPrint_Click(sender As Object, e As EventArgs) Handles sbPrint.Click

        frmPrintNestReport.ShowDialog(Me)

    End Sub

    Private Sub sbExportCNC_Click(sender As Object, e As EventArgs) Handles sbExportCNC.Click


        g_bNestingAutoCode = True

        'frmCodeGen.Init(CODE_OPTION.CODE_FILE)
        frmCodeGen.Init(CODE_OPTION.CCSFAB)
        frmCodeGen.ShowDialog(frmMain)

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        'TODO: V21 Set up a loop to code all the sheets

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub DeletePartVars(ByVal nPartID As Integer)
        Dim sql As String = Nothing
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim cmd As OleDbCommand = New OleDbCommand

        Try
            If (DoesTableExist("SheetTooling", PathPDB()) = True) Then

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                connection = New OleDbConnection(connetionString)

                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                cmd = New OleDbCommand(sql, connection)

                cmd.CommandText = "DELETE [Part Variables].* From [Part Variables] Where ([Part Variables].[Part ID] =" & nPartID & ")"

                cmd.ExecuteNonQuery()

                connection.Close()

                connection.Dispose()

            End If

        Catch ex As Exception

            MessageBox.Show("DeletePartVars: " & ex.Message)

        End Try
    End Sub

    Private Sub vgParts_MouseUp(sender As Object, e As MouseEventArgs) Handles vgParts.MouseUp
        Dim hitInfo = vgParts.CalcHitInfo(New Point(e.X, e.Y))

        vgParts.FocusedRow = hitInfo.Row

    End Sub

    Public Sub CreateNewPDB()
        Dim Pdb_FileSave As New SaveFileDialog
        Dim currentCategoryRow As CategoryRow = Nothing

        TV_NestConfig.ClearNodes()

        m_pdb_filename = PathPDB()

        'ConditionalFileDelete(m_pdb_filename)

        ArePartsLoaded = False
        vgResults.Rows.Clear()
        vgMaterial.Rows.Clear()
        vgParts.Rows.Clear()


        PathPDB_Set(m_pdb_filename)

        m_isVirginDB = True

        Me.SuspendLayout()


        CreatePDB()

        CreateRootNodes(TV_NestConfig, m_pdb_filename)

        PopulateDefaultSettings()
        UpdateSetupTable()

        Me.ResumeLayout()

        cmdBuild.Enabled = False

        'End If

        If (m_pdb_filename <> "") Then
            lReturn = frmMain.AddToMru(m_pdb_filename, frmMain.MRU_ListAray)

        End If

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub



    Private Sub frmNestingProtoType_MouseWheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        Dim pt As PortalPoint
        Dim cmd As String
        Dim factor As Double

        If ((My.Computer.Keyboard.CtrlKeyDown) And _
            (My.Computer.Keyboard.ShiftKeyDown)) Then

            lReturn = IsModeActive(MODE_ZOOM) = True

            If (IsModeActive(MODE_ZOOM) = False) Then
                lReturn = ModeBegin(MODE_ZOOM)
            End If

            'Hack to get around conversion of Xpos,Ypos (which I don't know how to do).
            pt = modView.MousePosition()
            lReturn = PortalLocalToWorld(pt)

            'factor = IIf((Rotation > 0), VIEW_ZOOM_FACTOR, (1# / VIEW_ZOOM_FACTOR))
            factor = IIf((e.Delta > 0), (1.0# / VIEW_ZOOM_FACTOR), VIEW_ZOOM_FACTOR)

            LockWindowUpdate(frmMain.pnlPicmodeler.Handle)
            cmd = "!View:Zoom: " & _
                  " factor=" & factor & _
                  ",x=" & pt.dx & _
                  ",y=" & pt.dy

            lReturn = PortalExecute(cmd)
            LockWindowUpdate(0&)
        End If
    End Sub

    Private Sub frmNestingProtoType_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Windows.Forms.Cursor.Current = Cursors.Default
        If (bEmptyPdb = True) Then
            Me.Close()
        Else
            vgSettingsProplist.BestFit()
            vgSettingsProplist.Refresh()

        End If

    End Sub

    Private Sub bbClearAllMats_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbClearAllMats.ItemClick
        Dim nID As Long
        Dim sql As String
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim cmd As OleDbCommand
        Dim childRows As VGridRows = vgMatVars.Rows(0).ChildRows


        If (vgMaterial.FocusedRow.ParentRow.Index = 0) Then 'We are under the Process order node

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            For Each childRow As EditorRow In vgMaterial.Rows(0).ChildRows
                nID = childRow.Tag

                sql = "DELETE * From [Material Inventory] Where ([Material Inventory].ID =" & nID & " )"

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

            Next

            If (vgMaterial.Rows(0).ChildRows.Count > 0) Then

                vgMaterial.Rows(0).ChildRows.Clear()

            End If

            connection.Close()

        End If

    End Sub

    Private Sub vgSettingsProplist_ShownEditor(sender As Object, e As EventArgs) Handles vgSettingsProplist.ShownEditor
        Dim edit As ComboBoxEdit = TryCast(vgSettingsProplist.ActiveEditor, ComboBoxEdit)
        Dim indx As Integer
        ' Dim DB_TOOLSETUP As Integer = 8
        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long
        Dim s_LayerSetup As String
        Dim n_LayerSetupID As Long

        Dim sOptions As String = sEmpty

        If nToolSetupRowId IsNot Nothing Then

            If vgSettingsProplist.FocusedRow Is nToolSetupRowId Then

                edit.Properties.Items.Clear()

                arrToolSetup = PopulateComboList("SELECT * FROM [Tool Setups] " & _
                                                   "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, False)

                For indx = 1 To arrToolSetup.Count

                    edit.Properties.Items.Add(New ComboBoxItem(arrToolSetup(indx).Description))

                    If (indx = 1) Then
                        sOptions = arrToolSetup(indx).Description
                    Else
                        sOptions = sOptions & ";" & arrToolSetup(indx).Description
                    End If

                Next


                If (arrToolSetup.Count > 0) Then
                    s_ToolSetup = arrToolSetup(1).description

                    n_ToolSetupID = GetToolSetupIDFromDescription(s_ToolSetup)

                    m_toolsetup_id = n_ToolSetupID
                    edit.EditValue = s_ToolSetup

                    edit.Properties.Tag = EncodeTag("glb.ToolSetupID", _
                                                                     "Tool Setup", _
                                                                     s_ToolSetup, _
                                                                     n_ToolSetupID, _
                                                                     "Tool Setup ID", _
                                                                     DB_TOOLSETUP, _
                                                                     0, _
                                                                     sOptions, 0)
                End If
            End If
        End If

        If nLayerSetupRowID IsNot Nothing Then

            If vgSettingsProplist.FocusedRow Is nLayerSetupRowID Then

                edit.Properties.Items.Clear()

                edit.EditValue = ""



                arrLayerSetup = PopulateComboList("Select * From [Layer Setups] " & _
                                                  "Where ([Layer Setups].[Machine ID] = " & m_machine_id & " ) Order By [Layer Setups].Description", False, True)

                For indx = 1 To arrLayerSetup.Count

                    edit.Properties.Items.Add(New ComboBoxItem(arrLayerSetup(indx).Description))

                    If (indx = 1) Then
                        sOptions = arrLayerSetup(indx).Description
                    Else
                        sOptions = sOptions & ";" & arrLayerSetup(indx).Description
                    End If


                Next

                If (arrLayerSetup.Count > 0) Then
                    s_LayerSetup = arrLayerSetup(1).description

                    n_LayerSetupID = GetToolSetupIDFromDescription(s_LayerSetup)

                    edit.EditValue = s_LayerSetup

                    edit.Properties.Tag = EncodeTag("glb.LayerSetupID", _
                                                                     "Layer Setup", _
                                                                     s_LayerSetup, _
                                                                     n_LayerSetupID, _
                                                                     "Layer Setup ID", _
                                                                     DB_LAYERSETUP, _
                                                                     0, _
                                                                     sOptions, 0)
                End If

            End If
        End If

        If edit IsNot Nothing Then
            AddHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
        End If


    End Sub

    Private Sub edit_EditValueChanged(sender As Object, e As EventArgs)
        Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
        nToolSetupRowId = Nothing
        nLayerSetupRowID = Nothing
        Dim datfilename As String = Nothing
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim VbVarValue As Object
        Dim CVarValue As Object
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim nDataType As Integer


        editValue = edit.EditValue.ToString()

        If (vgSettingsProplist.FocusedRow.Properties.Caption = "Machine") Then

            SelectedMachineName = edit.EditValue.ToString()
            m_machine_id = GetMachineIDFromDescrip(SelectedMachineName)

            VbVarValue = SelectedMachineName 'e.Row.Properties.Value

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            sql = "UPDATE [Setup] set [Setup].[VbValue] = '" & VbVarValue & "' Where ([Setup].[DatVarName] ='glb.Machine' )"

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            CVarValue = GetCValueBasedOnVarType(nDataType, VbVarValue, m_machine_id)

            sql = "UPDATE [Setup] set [Setup].[CValue] = '" & m_machine_id & "'Where ([Setup].[DatVarName] ='glb.Machine' )"

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            m_cnSettings.Close()

            modProject.SetMachine(VbVarValue, m_machine_id)



            'For value As Integer = vgSettingsProplist.Rows.Count - 1 To 6 Step -1

            'vgSettingsProplist.Rows.RemoveAt(value)

            'Next

            PopulateDefaultSettings()

            'GetSetupValuesFromPDB()



            nToolSetupRowId = GetRowByCaption("Tool Setup")

            If (IsNothing(nToolSetupRowId) = False) Then
                nRowIndx = nToolSetupRowId.Index

                vgSettingsProplist.Rows(nToolSetupRowId.ParentRow.Index).ChildRows(nToolSetupRowId.Index).Properties.Value = ""

                vgSettingsProplist.FocusedRow = vgSettingsProplist.Rows(nToolSetupRowId.ParentRow.Index).ChildRows(nToolSetupRowId.Index)
                'vgSettingsProplist.FocusedRow.Properties.Value = ""
                'vgSettingsProplist.ShowEditor()
            End If


        End If

        If (vgSettingsProplist.FocusedRow.Properties.Caption = "Tool Setup") Then

            SelectedToolSetupName = edit.EditValue.ToString
            m_toolsetup_id = GetToolSetupIDFromDescription(SelectedToolSetupName)

            nLayerSetupRowID = GetRowByCaption("Layer Setup")

            If (IsNothing(nLayerSetupRowID) = False) Then
                nRowIndx = nLayerSetupRowID.Index

                vgSettingsProplist.Rows(nLayerSetupRowID.ParentRow.Index).ChildRows(nLayerSetupRowID.Index).Properties.Value = ""

                If (m_toolsetup_id <> 0) Then

                    vgSettingsProplist.FocusedRow = vgSettingsProplist.Rows(nLayerSetupRowID.ParentRow.Index).ChildRows(nLayerSetupRowID.Index)
                End If

            End If

        End If

    End Sub

    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vgSettingsProplist.Rows
            r = GetRowByCaptionChild(row, s)
            If Not r Is Nothing Then
                Return r
            End If
        Next row
        Return Nothing
    End Function

    Private Function GetRowByCaptionChild(ByVal row As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        If row.Properties.Caption = s Then
            Return row
        End If
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For Each cRow As DevExpress.XtraVerticalGrid.Rows.BaseRow In row.ChildRows
            r = GetRowByCaptionChild(cRow, s)
            If Not r Is Nothing Then
                Return r
            End If
        Next cRow
        Return Nothing
    End Function

    Private Sub vgMatVars_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgMatVars.CellValueChanged

        Dim sFieldName As String
        Dim VbVarValue As Object
        Dim CVarValue As Object
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim nDataType As Integer
        Dim nSheetID As Long


        Try

            sFieldName = GetValueFromDelimitedData(e.Row.Tag, "DatVarName", sEmpty)
            nDataType = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", sEmpty))
            nSheetID = CLng(GetValueFromDelimitedData(e.Row.Tag, "nRecordID", sEmpty))
            VbVarValue = e.Row.Properties.Value

            CVarValue = GetCValueBasedOnVarType(nDataType, VbVarValue, e.Row.Tag)

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()
            sql = "UPDATE [Material Inventory] set [Material Inventory].[" & sFieldName & " ] = '" & CVarValue & "' Where ([Material Inventory].ID = " & nSheetID & " ) "

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            m_cnSettings.Close()
        Catch ex As Exception

            MessageBox.Show("vgMatVars_CellValueChanged: " & ex.Message)

        End Try
    End Sub

    Private Sub sbCodeViewer_Click(sender As Object, e As EventArgs) Handles sbCodeViewer.Click
        pcResults.Visible = False
        pcCodeViewer.Visible = True
        ceCloseViewer.CheckState = CheckState.Unchecked
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lReturn = PortalExecute("*codegen:xrefcreate:")

        Windows.Forms.Cursor.Current = Cursors.Default

        UpdateButtons(m_code_gen)
        m_ncfile = ""

        m_currRecordID = 0
        m_searchString = ""
        m_searchIndex = -1
        sbExportCNC.Enabled = False
    End Sub
    Public Sub UpdateButtons(the_code_gen As String)

        If (the_code_gen = sEmpty) Then
            m_code_gen = "<Select Code Generator>"
        Else
            m_code_gen = the_code_gen
        End If


        cmdCodeGenFile.Text = TrimToFit(m_code_gen, 40)

        cmdGraphicsEditorRefresh.Enabled = (m_code_gen <> NEED_CODEGEN)
        cmdGraphicsEditorStep.Enabled = (m_code_gen <> NEED_CODEGEN)

    End Sub

    Private Sub ceCloseViewer_CheckedChanged(sender As Object, e As EventArgs) Handles ceCloseViewer.CheckedChanged
        If (ceCloseViewer.CheckState = CheckState.Checked) Then

            lReturn = PortalExecute("*codegen:xrefdestroy:")
            lReturn = PortalExecute("!view:highlight:id=0")
            lReturn = PortalExecute("Admin:GlobalModel:")  'for safety

            modSelection.DeselectAll()
            If (m_ncfile <> "") Then lReturn = HeaderStringSet("ncfile", m_ncfile)

            m_is_active = False
            pcResults.Visible = True
            pcCodeViewer.Visible = False
            sbExportCNC.Enabled = True
        End If
    End Sub

    Private Sub cmdCodeGenFile_Click(sender As Object, e As EventArgs) Handles cmdCodeGenFile.Click
        frmCodeGen.Init(CODE_OPTION.FROM_NESTING)
        frmCodeGen.ShowDialog(Me)
    End Sub

    Private Sub cmdGraphicsEditorRefresh_Click(sender As Object, e As EventArgs) Handles cmdGraphicsEditorRefresh.Click
        If (PartsAreZoned() = False) Then Exit Sub

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lstGraphicsEditor.Items.Clear()
        lstGraphicsEditor.Refresh()

        'NOTE: We must remember the 'ncfile' value so that we can
        'reset it upon leaving the code viewer.  Otherwise, said
        'value will be set to "", and then the file name will not
        'appear next time you try to export a physical cnc file.
        If (m_ncfile = "") Then m_ncfile = HeaderStringGet("ncfile", "")

        lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!

        ShowCode()

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
    Private Sub ShowCode()

        Dim lNumRecs As Long
        Dim sCodeLine As String
        Dim iGE_CNT As Integer
        Dim lTempRec As Long

        If (m_code_gen = NEED_CODEGEN) Then Exit Sub


        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lstGraphicsEditor.Items.Clear()


        lReturn = PortalExecute(sPortalCommand)

        lReturn = PortalExecute("*codegen:xrefcount:")
        lNumRecs = PortalGetInt("count", 0)

        For iGE_CNT = 0 To lNumRecs - 1

            lTempRec = CLng(iGE_CNT)
            lReturn = PortalExecute("*codegen:xreffetch:recno=" & lTempRec)

            sCodeLine = PortalGetString("text", "")
            lTempRec = PortalGetInt("id", 0)


            lstGraphicsEditor.Items.Add(New myItemData(sCodeLine, lTempRec))

        Next iGE_CNT

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub cmdGraphicsEditorStep_Click(sender As Object, e As EventArgs) Handles cmdGraphicsEditorStep.Click
        Dim dInterval As Double

        If cmdGraphicsEditorStep.Text = "Step" Then
            dInterval = CInt(1) / 8
            Timer1.Interval = dInterval * 1000
            Timer1.Enabled = True
            cmdGraphicsEditorStep.Text = "Pause"
        Else
            Timer1.Enabled = False
            cmdGraphicsEditorStep.Text = "Step"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim lIndex As Long

        lIndex = lstGraphicsEditor.SelectedIndex + 1


        If lIndex > lstGraphicsEditor.Items.Count - 1 Then
            Timer1.Enabled = False
            cmdGraphicsEditorStep.Text = "Step"

            HighLightEntity()

        Else
            lstGraphicsEditor.SelectedIndex = lIndex
        End If
        HighLightEntity()
    End Sub
    Private Sub HighLightEntity()
        If (lstGraphicsEditor.SelectedIndex > 0) Then

            'In order to support the display of clamp avoidance moves we have
            'changed the way we access records are accessed. This should be a
            'safe thing to do because the blocks of code displayed in the
            'control are one-to-one with those in the CCodeGeoXref object.
            lReturn = PortalExecute("*codegen:highlight:rec=" & lstGraphicsEditor.SelectedIndex)
            'So that we can restart the search from the
            'most recently selected output block
            m_searchIndex = lstGraphicsEditor.SelectedIndex

        End If
    End Sub

    Private Sub lstGraphicsEditor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGraphicsEditor.SelectedIndexChanged
        HighLightEntity()
    End Sub
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
    Private Sub chkApplyCutback_CheckStateChanged(sender As Object, e As EventArgs) Handles chkApplyCutback.CheckStateChanged
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            sql = "Update [Remnant Control] set  [Remnant Control].[CutBack] =  " & chkApplyCutback.CheckState & ""

            connection = New OleDbConnection(connetionString)

            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


            cmd.ExecuteNonQuery()

            connection.Close()


        Catch ex As Exception

            MessageBox.Show("chkApplyCutback_CheckStateChanged : " & ex.Message)
        End Try

    End Sub
    Private Sub GetRemnantControlValues()
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cmd As OleDbCommand = Nothing

        sql = "Select * FROM [Remnant Control]"

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        connection = New OleDbConnection(connetionString)

        Try
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then
                Me.chkApplyCutback.Checked = ds.Tables(0).Rows(0).Item("CutBack")
                Me.chkCreateRemnant.Checked = ds.Tables(0).Rows(0).Item("Remnant")

            End If


        Catch ex As Exception

            MessageBox.Show("GetRemnantControlValues_" & ex.Message)

        End Try
        ds.Dispose()

    End Sub

    Private Sub CreateMRPRootNodes(ByVal tl As DevExpress.XtraTreeList.TreeList, sMRPDB_Name As String)
        Dim pdb_displayname As String
        Dim sPdb_Name_Tag As String
        Dim dsPDBs As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cnt As Integer
        Dim i As Integer
        Dim nID As Integer
        Dim sql As String

        pdb_displayname = PathFileExt(sMRPDB_Name)
        tl.ClearNodes()

        TV_NestConfig.Visible = False

        tl.SuspendLayout()

        bFromCreateNodes = True


        CFG_ROOT_NODE = tl.AppendNode(New Object() {"Job(s) <" & pdb_displayname & ">"}, 0)
        CFG_ROOT_NODE.Tag = 0

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_pdb_filename & "';"

        sql = "Select * From PDB_Files"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsPDBs)

        oledbAdapter.Dispose()

        connection.Close()

        cnt = dsPDBs.Tables(0).Rows.Count

        If (cnt > 0) Then
            frmMain.NestingImageCollection.Clear()

            For i = 0 To cnt - 1

                pdb_displayname = dsPDBs.Tables(0).Rows(i).Item("PDB_Name")

                nID = dsPDBs.Tables(0).Rows(i).Item("ID")

                sPdb_Name_Tag = TAG_SETTINGS_NODE & "," & pdb_displayname

                CFG_SETTINGS_NODE = tl.AppendNode(New Object() {PathFile(pdb_displayname)}, CFG_ROOT_NODE, sPdb_Name_Tag)

                CFG_PARTS_NODE = tl.AppendNode(New Object() {"Parts"}, CFG_SETTINGS_NODE, TAG_PARTS_NODE)
                CFG_MATERIAL_NODE = tl.AppendNode(New Object() {"Material"}, CFG_SETTINGS_NODE, TAG_MATERIAL_NODE)
                CFG_RESULTS_NODE = tl.AppendNode(New Object() {"Results (Pending)"}, CFG_SETTINGS_NODE, TAG_RESULTS_NODE)

                LoadResultsIntoTree(pdb_displayname)


                For Each column As DevExpress.XtraTreeList.Columns.TreeListColumn In TV_NestConfig.Columns
                    column.OptionsColumn.AllowMove = False
                Next

            Next

        End If

        'tl.ResumeLayout()

    End Sub

    Private Sub FillPartResultsGrid(s_MM2File As String)
        Dim nQty As Integer
        Dim dsPartVars As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cnt As Integer
        Dim i As Integer
        Dim nID As Integer
        Dim dArea As Double
        Dim sql As String
        Dim sPieces() As String
        Dim the_PDB_Node_Name As String
        Dim m_Temp_Value = Nothing
        Dim sCandidate As String
        Dim sql2 As String
        Dim dsPart As New DataSet

        sPieces = Split(TV_NestConfig.FocusedNode.Tag, ",")

        the_PDB_Node_Name = sPieces(2)

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & the_PDB_Node_Name & "';"

        sql = "SELECT * FROM [Part Result] WHERE " & _
        "([Part Name] = '" & sPieces(1) & "') AND " & _
        "([Sheet Filename] = '" & sPieces(3) & "')"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsPartVars)

        oledbAdapter.Dispose()


        cnt = dsPartVars.Tables(0).Rows.Count

        If (cnt > 0) Then

            For i = 0 To cnt - 1

                nQty = dsPartVars.Tables(0).Rows(i).Item("Quantity")

                nID = dsPartVars.Tables(0).Rows(i).Item("Part ID")

                dArea = dsPartVars.Tables(0).Rows(i).Item("Area")

                sql2 = "Select Part.* From Part Where (Part.ID = " & nID & " )"

                oledbAdapter = New OleDbDataAdapter(sql2, connection)

                oledbAdapter.Fill(dsPart)

                oledbAdapter.Dispose()

                If (dsPart.Tables(0).Rows.Count > 0) Then

                    sCandidate = dsPart.Tables(0).Rows(i).Item("Filename")

                    sReturn = modFileIO.ImportMM2(sCandidate)

                End If


            Next


            For Each row As CategoryRow In vgPartResults.Rows

                For Each childRow As EditorRow In row.ChildRows

                    Select Case UCase(GetValueFromDelimitedData(childRow.Tag, "DialogDisplay", 0))

                        Case "QUANTITY"
                            m_Temp_Value = nQty

                        Case "PART ID"
                            m_Temp_Value = nID

                        Case "AREA"
                            m_Temp_Value = dArea

                    End Select
                    childRow.Properties.Value = m_Temp_Value

                    m_Temp_Value = sEmpty

                Next
            Next

        End If

        connection.Close()

    End Sub

    Private Sub ClearResultTree()
        Dim ni As Integer = 0
        Dim nIndex As Long = 0
        Dim node As TreeListNode

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            For Each node In TV_NestConfig.Nodes

                If (node.HasChildren = True) Then

                    For Each child As TreeListNode In node.Nodes
                        TV_NestConfig.Nodes.Remove(child)

                    Next
                End If
            Next

        Catch ex As Exception

            MessageBox.Show("Clear Nesting Results Failed" & ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub chkCreateRemnant_CheckStateChanged(sender As Object, e As EventArgs) Handles chkCreateRemnant.CheckStateChanged
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            sql = "Update [Remnant Control] set  [Remnant Control].[Remnant] =  " & chkCreateRemnant.CheckState & ""

            connection = New OleDbConnection(connetionString)

            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


            cmd.ExecuteNonQuery()

            connection.Close()


        Catch ex As Exception

            MessageBox.Show("chkApplyCutback_CheckStateChanged : " & ex.Message)
        End Try
    End Sub

    Private Sub vgMaterial_Click(sender As Object, e As EventArgs) Handles vgMaterial.Click

    End Sub

    Private Sub vgPartResults_Click(sender As Object, e As EventArgs) Handles vgPartResults.Click

    End Sub
End Class
'Public Class MyIterator
'    Inherits TreeListOperation
'    Private _text As String = "Results Completed"

'    Public Overrides Sub Execute(node As TreeListNode)

'        If node(0).ToString() = _text Then

'            node.Nodes.Clear()
'            node.SetValue(0, "Results (Pending)")

'        End If

'    End Sub

'End Class