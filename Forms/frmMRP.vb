Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.XtraEditors.Repository

Public Class frmMRP
    Private nToolSetupRowId As BaseRow
    Private nLayerSetupRowID As BaseRow
    Private editValue As String

    Private nRowIndx As Integer
    Private nRowId As BaseRow


    Private SelectedMachineName As String
    Private SelectedToolSetupName As String
    Private SelectedLayerSetupName As String

    Private USER_FIELDS_ROOT_NODE As TreeListNode
    Private USER_FIELDS_NODE As TreeListNode
    Private SYSTEM_ROOT_NODE As TreeListNode
    Private SYSTEM_PART_ROOT_NODE As TreeListNode
    Private SYSTEM_PART_NODE As TreeListNode
    Private SYSTEM_NESTING_ROOT_NODE As TreeListNode
    Private SYSTEM_NESTING_NODE As TreeListNode
    Private SYSTEM_MATERIAL_ROOT_NODE As TreeListNode
    Private SYSTEM_MATERIAL_NAME_NODE As TreeListNode
    Private SYSTEM_MATERIAL_LENGTH_NODE As TreeListNode
    Private SYSTEM_MATERIAL_WIDTH_NODE As TreeListNode
    Private SYSTEM_MATERIAL_THICKNESS_NODE As TreeListNode

    Private Const TAG_ROOT_NODE = -100
    Private Const TAG_PART_ROOT_NODE = -200
    Private Const TAG_PART_NODE = -300
    Private Const TAG_NESTING_ROOT_NODE = -400
    Private Const TAG_NESTING_NODE = -500
    Private Const TAG_MATERIAL_ROOT_NODE = -600
    Private Const TAG_MATERIAL_NAME_NODE = -700
    Private Const TAG_MATERIAL_LENGTH_NODE = -800
    Private Const TAG_MATERIAL_WIDTH_NODE = -900
    Private Const TAG_MATERIAL_THICKNESS_NODE = -1000
    Private Const TAG_USER_ROOT_NODE = -1100
    Private Const TAG_USER_FIELDS_NODE = -1200

    Private Const XLS_TYPE = 0
    Private Const MDB_TYPE = 1
    Private Const TAB_TYPE = 2
    Private Const CSV_TYPE = 3
    Private Const SEMICOLON_TYPE = 4
    Private Const XLSX_TYPE = 5

    Private m_usage As Long

    Private m_pdb_filename As String = Nothing
    Private m_folderDialog As New FolderBrowserDialog()
    Private m_NestResults_Folder As String
    Private m_templateName As String
    Private intImportType As Long

    Private s_Machine As String = String.Empty
    Private s_ToolSetup As String = String.Empty
    Private s_LayerSetup As String = String.Empty
    Private s_LeadSetup As String = String.Empty
    Private cFirstCell As Cell = Nothing
    Private cSecondCell As Cell = Nothing
    Private cThridCell As Cell = Nothing
    Private cFourthCell As Cell = Nothing
    Private m_XLS_Name As String
    Private m_job_name As String
    Private m_is_nesting As Boolean
    Private Const m_col_FileName = 0
    Private Const m_col_Material_type = 1
    Private Const m_col_Material_width = 3
    Private Const m_col_Material_length = 4
    Private Const m_col_Material_Thickness = 5
    Private Const m_col_MirrorPart = 7
    Private Const m_col_PreNest = 8
    Private Const m_col_Part_Quantity = 9
    Private Const m_col_Rotation_NUM = 10
    Private Const m_col_Rotation_start = 11
    Private Const m_col_Part_Priority = 12
    Private Const m_col_Cost_Per_Part = 13
    Private Const m_col_Representation = 14
    Private m_Search_Col As Integer
    Private sMRP_DB As String
    Private sMergePartsFilename As String
    Dim sTempMDB As String
    Dim sTempUserFolder As String
    Dim l_MachineID As Long
    Dim l_ToolSetupid As Long
    Dim workplane_type As Integer
    Dim l_Mat_ID As Long = -1
    Dim sMRP_DBSave_Folder As String
    Dim nPartID As Integer
    Public i_num_Pierces As Integer
    Public d_CutTravel As Double

    Public sCodeColName As String
    Private WithEvents repositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click

        bDo_MRP_Nesting = False

        Me.Close()
    End Sub
    Private Sub SearchForFiles()

        Dim ni As Integer

        For ni = 0 To ListBoxControl1.Items.Count - 1
            FindAllFiles(fcbSourceFolder.Text, lbcFilesFromMrp.Items(ni).ToString & "*.*", lbcFoundFiles, lbcFilesNotFound, "")
        Next

        'Dim sw As New StreamWriter(Application.StartupPath & "\DeBug\ApiCopyFIles.bat", True)
        'For ni = 0 To lbcFoundFiles.Items.Count - 1
        '    sw.WriteLine("copy " & QStr(lbcFoundFiles.Items(ni).ToString) & " " & QStr(Application.StartupPath & "\Debug"))
        'Next
        'sw.Close()

    End Sub
    Private Sub sbNext_Click(sender As Object, e As EventArgs) Handles sbNext.Click
        Dim sLinksFromReg As String
        Dim sTempMachine As String

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            sbBack.Enabled = False
            sbNext.Enabled = False

            xtcMRP.SelectedTabPageIndex = xtcMRP.SelectedTabPageIndex + 1

            m_templateName = RegGetString("MRP", "MRP_TEMPLATE", "")

            Select Case UCase(xtcMRP.SelectedTabPage.Name)
                Case "TAbMRPSorting"

                    sbNext.Enabled = True
                    sbBack.Enabled = True


                Case "TABMRPPREVIEW"
#If APIHeatTransfer Then
                    If InStr(1, UCase(cbeMachine.EditValue), "VIPROS") > 0 Then
                        RegPutString("CodeGeneration", "NCFileExt", "cnc")
                    Else
                        RegPutString("CodeGeneration", "NCFileExt", "LCD")
                    End If


#End If
                    Select Case m_usage
                        Case XLS_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "XLS")

                            GetSpreadSheet()

                        Case XLSX_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "XLSX")

                            GetSpreadSheet()

                        Case CSV_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "COMMA")

                        Case TAB_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "TAB")

                        Case SEMICOLON_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "SEMICOLON")

                        Case MDB_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "MDB")

                            'ExportOneTable(fcbImportFile.Text, cboSheetTable.EditValue)

                            'SpreadsheetControl1.LoadDocument(PathTempFolder() & PathFile(fcbImportFile.Text) & ".xls", DocumentFormat.Xls)


                    End Select

                    SPreadSheetRowsCols()

                    sbNext.Enabled = True
                    sbBack.Enabled = True

                Case "TABMRPMAPPING"

                    TV_MappedFields.Nodes.Clear()
                    TV_UserFields.Nodes.Clear()
                    TV_NestConfig.Nodes.Clear()


#If APIHeatTransfer Then
                    sTempMDB = sTempUserFolder & "\temapipmdb.mdb"
                    ' sTempMDB = "C:\Laser\temapipmdb.mdb"

                    ' MessageBox.Show("Create NestDB < ImportFile" & fcbImportFile.Text & " > " & " <NestDB " & sTempMDB & "> " & " <Table " & cboSheetTable.Text)
                    ConvertXLSToMDB(fcbImportFile.Text, sTempMDB, cboSheetTable.Text)
                    'DebugShowColumnsInMDB(cboSheetTable.Text)
                    ' MessageBox.Show("After ConvertXlsToMdb")
#End If

                    ' MessageBox.Show("Before GetUserFields")
                    GetUserFields()
                    'MessageBox.Show("After GetUserFields")

                    'MessageBox.Show("Before GetSystemfields")
                    GetSystemfields()
                    'MessageBox.Show("After GetSystemfields")

                    Dim sUserFieldName As String

                    sUserFieldName = RegGetString(" MRP", " USER_FIELD", "")

                    If (sUserFieldName <> "") Then
                        For ni = 0 To cboFieldName.Properties.Items.Count - 1
                            If (sUserFieldName = cboFieldName.Properties.Items.Item(ni).ToString) Then
                                cboFieldName.SelectedIndex = ni
                            End If
                        Next
                    End If

                    'MessageBox.Show("Before Get links")
                    sLinksFromReg = GetLinksFromReg(m_templateName)

                    sPieces = Split(sLinksFromReg, ";")

                    Me.TV_MappedFields.BeginUnboundLoad()
                    Dim parentForRootNodes As TreeListNode = Nothing
                    Dim resultData As String = String.Empty

                    For ni = 0 To UBound(sPieces) - 1

                        resultData = sPieces(ni)
                        Dim rootNode As TreeListNode = Me.TV_MappedFields.AppendNode(New Object() {resultData}, parentForRootNodes)

                    Next

                    Me.TV_MappedFields.EndUnboundLoad()
                    sbNext.Enabled = True
                    sbBack.Enabled = True
                    'MessageBox.Show("After get links")

                Case "TABMRPFILESPROCESSED"
                    lbcFilesNotFound.Items.Clear()
                    lbcFoundFiles.Items.Clear()
                    sbBack.Enabled = True

#If APIHeatTransfer Then

                    fcbResultsDirectory.Text = IO.Path.GetDirectoryName(fcbSourceFolder.Text) & "\Nest\"
                    fcbMM2Source.Text = IO.Path.GetDirectoryName(fcbSourceFolder.Text) & "\Parts\"
                    BuildFileList()
                    gcFileNotFOund.Text = "(" & lbcFilesNotFound.Items.Count & ") " & "Files Not Found Or Wrong Revision"
                    gcFilesFOund.Text = "( " & lbcFoundFiles.Items.Count & " ) " & "Files Found"
                    gcFileFromMRP.Text = "(" & lbcFilesFromMrp.Items.Count & ") Files To Process."
#End If
                    'xtcMRP.SelectedTabPageIndex = xtcMRP.SelectedTabPageIndex + 1
                    DebugShowColumnsAndFirstRow(cboSheetTable.Text)

                    sbNext.Enabled = True
                    sbBack.Enabled = True




                Case "TABMRPSORTING"
                    sbNext.Enabled = True
                    sbBack.Enabled = True


                Case "TABMRPPARTDEFAULTS"

                    FillPartDefaultGrid()

                    sbNext.Enabled = True
                    sbBack.Enabled = True

                Case "TABMRPNESTDEFAULTS"


                    PopulateDefaultSettings()

                    sbFinish.Enabled = True

                    sbBack.Enabled = True
                    sbNext.Enabled = False

            End Select

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub


    Private Sub BuildFileList()
        Dim workbook As IWorkbook = SpreadsheetControl1.Document
        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim ni As Integer
        Dim sPartFilename As String
        Dim nPartColIndex As Integer = -1
        Dim nRevColIndex As Integer = -1
        Dim nRMPartColIndex As Integer = -1
        Dim sTempStr As String
        Dim sPartMappedField As String = ""
        Dim sRevMappedField As String = ""
        Dim sPieces() As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection = Nothing
        Dim oledbAdapter As OleDbDataAdapter = Nothing
        Dim connetionString As String
        Dim sql As String
        Dim sCoLName As String

        Try
            lbcFoundFiles.Items.Clear()
            lbcFilesNotFound.Items.Clear()

            sSteelMainFolder = NormalizePath(RegGetString("Customizations\APIHeatTransfer", "SteelCopyTo", ""))
            sAlumMainFolder = NormalizePath(RegGetString("Customizations\APIHeatTransfer", "AlumCopyTo", ""))

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sTempMDB & "';"
            sql = "SELECT * FROM [" & cboSheetTable.Text & "]"

            connection = New OleDbConnection(connetionString)
            connection.Open()
            oledbAdapter = New OleDbDataAdapter(sql, connection)
            oledbAdapter.Fill(ds)
            oledbAdapter.Dispose()
            connection.Close()

            '----- Cleaned versions of the column names -----
            ' Original: "Code (Part_Qty_RM_Desc)"  or  "Code (Part_Qty_RM Desc)"
            ' Cleaned : "Code__Part_Qty_RM_Desc_"  or  "Code__Part_Qty_RM_Desc_"
            Dim sCodeColName1 As String = CleanName("Code (Part_Qty_RM_Desc)")
            Dim sCodeColName2 As String = CleanName("Code (Part_Qty_RM Desc)")

            Dim sRMNameCol As String = CleanName("RM Name")          ' → RM_Name
            Dim sRMPartCol As String = CleanName("RM PART")          ' → RM_PART
            Dim sCompRevCol As String = CleanName("COMP REV")        ' → COMP_REV

            ' Decide which Code column exists
            If DoesFieldExist(sTempMDB, cboSheetTable.Text, sCodeColName1) Then
                sCodeColName = sCodeColName1
            ElseIf DoesFieldExist(sTempMDB, cboSheetTable.Text, sCodeColName2) Then
                sCodeColName = sCodeColName2
            Else
                ' Fallback – try to find any column that contains "Code" and "Part_Qty"
                sCodeColName = FindColumnContaining(ds.Tables(0), "Code", "Part_Qty")
            End If

            '----- Map fields from the TreeView -----
            For ni = 0 To TV_MappedFields.Nodes.Count - 1
                sTempStr = TV_MappedFields.Nodes.Item(ni).GetDisplayText(0)
                sPieces = Split(sTempStr, "=")
                Dim sTempStrUpper As String = UCase(sTempStr)

                ' Look for the Code column
                If InStr(sTempStrUpper, UCase(sCodeColName)) > 0 OrElse
               InStr(sTempStrUpper, "CODE (PART_QTY_RM") > 0 Then

                    sPartMappedField = Trim(sPieces(0))

                    ' Find the column index in the DataTable
                    For i = 0 To ds.Tables(0).Columns.Count - 1
                        sCoLName = ds.Tables(0).Columns(i).ColumnName
                        If String.Compare(sCoLName, sPartMappedField, True) = 0 OrElse
                       String.Compare(sCoLName, CleanName(sPartMappedField), True) = 0 Then
                            nRMPartColIndex = i
                            Exit For
                        End If
                    Next

                    nPartColIndex = GetColIndexFromText(sPartMappedField, worksheet)
                    If nPartColIndex = -1 Then nPartColIndex = ni
                End If

                ' COMP REV
                If InStr(sTempStrUpper, "COMP REV") > 0 Then
                    sRevMappedField = Trim(sPieces(0))
                    nRevColIndex = GetColIndexFromText(sRevMappedField, worksheet)
                End If

                ' RM PART
                If InStr(sTempStrUpper, "RM PART") > 0 Then
                    nRMPartColIndex = GetColIndexFromText("RM PART", worksheet)
                End If

                If nPartColIndex <> -1 AndAlso nRevColIndex <> -1 Then
                    Exit For
                End If
            Next

            '----- Process rows -----
            lbcFilesFromMrp.Items.Clear()

            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim rmNameValue As String = ""

                ' Safely get RM Name (cleaned column name)
                If ds.Tables(0).Columns.Contains(sRMNameCol) Then
                    rmNameValue = ds.Tables(0).Rows(i).Item(sRMNameCol).ToString()
                ElseIf ds.Tables(0).Columns.Contains("RM Name") Then
                    rmNameValue = ds.Tables(0).Rows(i).Item("RM Name").ToString()
                End If

                If InStr(rmNameValue, "STL") > 0 Then
                    sMRP_DBSave_Folder = sSteelFolder
                    sMainFolder = NormalizePath(RegGetString("MRP", "SteelFolder", ""))
                    sMainFolder = sMainFolder & sSteelFolder & "\" & sMRPPartsFolder & "\"
                Else
                    sMRP_DBSave_Folder = sAlumFolder
                    sMainFolder = NormalizePath(RegGetString("MRP", "LaserFolder", ""))
                    sMainFolder = sMainFolder & sAlumFolder & "\" & sMRPPartsFolder & "\"
                End If

                ' Get the part filename from the mapped column
                Dim partValue As String = ""
                If nRMPartColIndex >= 0 AndAlso nRMPartColIndex < ds.Tables(0).Columns.Count Then
                    partValue = ds.Tables(0).Rows(i).Item(nRMPartColIndex).ToString()
                End If

                sPieces = Split(partValue, ",")
                sPartFilename = sPieces(0).Trim()

                lbcFilesFromMrp.Items.Add(sPartFilename)
                FindAllFiles(sMainFolder, sPartFilename, lbcFoundFiles, lbcFilesNotFound, sMRP_DBSave_Folder)
            Next

            lbcFoundFiles.SelectedIndex = -1
            lbcFilesNotFound.SelectedIndex = -1
            lbcFilesFromMrp.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("BuildFileList: " & ex.Message)
        Finally
            If oledbAdapter IsNot Nothing Then oledbAdapter.Dispose()
            If connection IsNot Nothing Then
                If connection.State = ConnectionState.Open Then connection.Close()
                connection.Dispose()
            End If
            If ds IsNot Nothing Then ds.Dispose()
        End Try
    End Sub

    '--------------------------------------------------------------
    ' Helper: applies the same cleaning that MakeValidColumnName does
    '--------------------------------------------------------------
    Private Function CleanName(name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Return "Column"
        Dim clean = System.Text.RegularExpressions.Regex.Replace(name, "[^\w]", "_")
        Return clean
    End Function

    '--------------------------------------------------------------
    ' Helper: finds a column that contains certain keywords
    '--------------------------------------------------------------
    Private Function FindColumnContaining(dt As DataTable, ParamArray keywords() As String) As String
        For Each col As DataColumn In dt.Columns
            Dim colNameUpper = col.ColumnName.ToUpper()
            Dim allFound As Boolean = True
            For Each kw In keywords
                If InStr(colNameUpper, kw.ToUpper()) = 0 Then
                    allFound = False
                    Exit For
                End If
            Next
            If allFound Then Return col.ColumnName
        Next
        Return ""
    End Function

    ''' <summary>
    ''' Debug helper – shows all column names in the specified table of the temp MDB
    ''' </summary>
    Private Sub DebugShowColumnsInMDB(Optional tableName As String = Nothing)
        Try
            If String.IsNullOrWhiteSpace(sTempMDB) OrElse Not IO.File.Exists(sTempMDB) Then
                MessageBox.Show("Temp MDB not found: " & sTempMDB)
                Return
            End If

            If String.IsNullOrWhiteSpace(tableName) Then
                tableName = cboSheetTable.Text
            End If

            Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sTempMDB & "';"

            Using conn As New OleDb.OleDbConnection(connStr)
                conn.Open()

                ' Get the list of columns
                Dim schemaTable As DataTable = conn.GetOleDbSchemaTable(
                OleDb.OleDbSchemaGuid.Columns,
                New Object() {Nothing, Nothing, tableName, Nothing})

                If schemaTable Is Nothing OrElse schemaTable.Rows.Count = 0 Then
                    MessageBox.Show("No columns found in table: " & tableName)
                    Return
                End If

                Dim sb As New System.Text.StringBuilder()
                sb.AppendLine("Table: " & tableName)
                sb.AppendLine("MDB  : " & sTempMDB)
                sb.AppendLine(New String("-"c, 50))
                sb.AppendLine("Column names found in the MDB:")
                sb.AppendLine()

                ' Sort by ordinal position
                Dim rows = schemaTable.Select("", "ORDINAL_POSITION ASC")

                For Each row As DataRow In rows
                    Dim colName As String = row("COLUMN_NAME").ToString()
                    Dim colType As String = row("DATA_TYPE").ToString()
                    sb.AppendLine("• " & colName)
                Next

                sb.AppendLine()
                sb.AppendLine("Total columns: " & rows.Length)

                ' Show in a message box (or change to a listbox if you prefer)
                MessageBox.Show(sb.ToString(), "Debug - Columns in MDB", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

        Catch ex As Exception
            MessageBox.Show("DebugShowColumnsInMDB error:" & Environment.NewLine & ex.Message)
        End Try
    End Sub


    'Private Sub BuildFileList()
    '    Dim workbook As IWorkbook = SpreadsheetControl1.Document
    '    Dim worksheet As Worksheet = workbook.Worksheets(0)

    '    Dim ni As Integer
    '    Dim sPartFilename As String

    '    Dim nPartColIndex As Integer = -1
    '    Dim nRevColIndex As Integer = -1
    '    Dim nRMPartColIndex As Integer = -1
    '    Dim sTempStr As String

    '    Dim sPartMappedField As String
    '    Dim sRevMappedField As String
    '    Dim sPieces() As String
    '    Dim ds As New DataSet
    '    Dim connection As New OleDbConnection
    '    Dim oledbAdapter As New OleDbDataAdapter
    '    Dim connetionString As String
    '    Dim sql As String
    '    Dim sCoLName As String
    '    Dim indx As Integer


    '    Try

    '        lbcFoundFiles.Items.Clear()
    '        lbcFilesNotFound.Items.Clear()

    '        sSteelMainFolder = NormalizePath(RegGetString("Customizations\APIHeatTransfer", "SteelCopyTo", ""))

    '        sAlumMainFolder = NormalizePath(RegGetString("Customizations\APIHeatTransfer", "AlumCopyTo", ""))


    '        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sTempMDB & "';"

    '        sql = "SELECT * FROM [" & cboSheetTable.Text & "]"

    '        connection = New OleDbConnection(connetionString)
    '        connection.Open()

    '        oledbAdapter = New OleDbDataAdapter(sql, connection)

    '        oledbAdapter.Fill(ds)

    '        oledbAdapter.Dispose()

    '        connection.Close()

    '        If (DoesFieldExist(sTempMDB, cboSheetTable.Text, "Code (Part_Qty_RM_Desc)") = True) Then
    '            sCodeColName = UCase("Code (Part_Qty_RM_Desc)")
    '        Else
    '            sCodeColName = UCase("Code (Part_Qty_RM Desc)")
    '        End If



    '        'indx = InStr(1, sCodeColName, "must be certified to ASTM A1011")

    '        'If (indx > 0) Then
    '        '    MessageBox.Show("We found must be certified to ASTM A1011")
    '        'End If

    '        For ni = 0 To TV_MappedFields.Nodes.Count - 1


    '            sTempStr = TV_MappedFields.Nodes.Item(ni).GetDisplayText(0)
    '            sPieces = Split(sTempStr, "=")

    '            sTempStr = UCase(sTempStr)
    '            ' Dim sCodeColName = UCase("Code (Part_Qty_RM_Desc)")

    '            If (InStr(sTempStr, sCodeColName) > 0) Then
    '                sPartMappedField = Trim(sPieces(0))

    '                For i = 0 To ds.Tables(0).Columns.Count - 1
    '                    sCoLName = ds.Tables(0).Columns(i).ColumnName
    '                    If (sCoLName = sPartMappedField) Then
    '                        nRMPartColIndex = i
    '                        Exit For
    '                    End If
    '                Next

    '                nPartColIndex = GetColIndexFromText(sPartMappedField, worksheet)
    '                If (nPartColIndex = -1) Then
    '                    nPartColIndex = ni
    '                End If
    '            End If
    '            If (InStr(UCase(sTempStr), "COMP REV") > 0) Then
    '                sRevMappedField = Trim(sPieces(0))
    '                nRevColIndex = GetColIndexFromText(sRevMappedField, worksheet)
    '            End If

    '            If (InStr(UCase(sTempStr), "RM PART") > 0) Then

    '                nRMPartColIndex = GetColIndexFromText("RM PART", worksheet)

    '            End If
    '            If (nPartColIndex <> -1 And nRevColIndex <> -1) Then
    '                Exit For
    '            End If
    '        Next

    '        lbcFilesFromMrp.Items.Clear()

    '        For i = 0 To ds.Tables(0).Rows.Count - 1

    '            If (InStr(ds.Tables(0).Rows(i).Item("RM Name").ToString, "STL")) Then
    '                sMRP_DBSave_Folder = sSteelFolder
    '                sMainFolder = NormalizePath(RegGetString("MRP", "SteelFolder", ""))

    '                sMainFolder = NormalizePath(RegGetString("MRP", "SteelFolder", ""))
    '                'If (sMainFolder = "\") Then
    '                '    sMainFolder = "C:\"
    '                'End If

    '                sMainFolder = sMainFolder & sSteelFolder & "\" & sMRPPartsFolder & "\"
    '                'sMainFolder = "T:\mm2_laser\"
    '            Else
    '                sMRP_DBSave_Folder = sAlumFolder
    '                sMainFolder = NormalizePath(RegGetString("MRP", "LaserFolder", ""))

    '                'If (sMainFolder = "\") Then
    '                '    sMainFolder = "C:\"
    '                'End If
    '                sMainFolder = sMainFolder & sAlumFolder & "\" & sMRPPartsFolder & "\"
    '            End If


    '            ' sMainFolder = NormalizePath(PathDriveFolder(fcbSourceFolder.Text))

    '            'MessageBox.Show("The main Folder is < " & sMainFolder & "> " & " The file name is < " & sPartFilename & ">")
    '            Dim unused As String = ds.Tables(0).Rows(i).Item(nRMPartColIndex).ToString
    '            sPieces = Split(unused, ",")

    '            sPartFilename = sPieces(0)
    '            lbcFilesFromMrp.Items.Add(sPartFilename)

    '            FindAllFiles(sMainFolder, sPartFilename, lbcFoundFiles, lbcFilesNotFound, sMRP_DBSave_Folder)
    '        Next

    '        lbcFoundFiles.SelectedIndex = -1
    '        lbcFilesNotFound.SelectedIndex = -1
    '        lbcFilesFromMrp.SelectedIndex = -1


    '    Catch ex As Exception

    '        MessageBox.Show("BuildFileList: " & ex.Message)

    '    End Try

    '    ' MessageBox.Show("BuildFIleList_3")
    '    If connection IsNot Nothing Then connection = Nothing
    '    If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
    '    If ds IsNot Nothing Then ds = Nothing

    'End Sub
    Private Sub FillPartDefaultGrid()
        Dim sData As String
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim m_nesting_Template As String
        Dim sChoices As New Collection
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim sql As String
        Dim ni As Integer

        Try

            catPartDefaultInfo.ChildRows.Clear()

            my_DatVarName = "Part Quantity"
            my_DialogDisplay = "Part Quantity"
            my_VBValue = 1
            my_CValue = 1
            my_CVarName = "Part Quantity"
            my_DataType = DB_INT
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateIntegerEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            my_DatVarName = "Fill Part"
            my_DialogDisplay = "Fill Part"
            my_VBValue = 0
            my_CValue = 0
            my_CVarName = "Fill Part"
            my_DataType = DB_BOOL
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateBooleanEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            my_DatVarName = "Rotation Num"
            my_DialogDisplay = "Rotations/360"
            my_VBValue = 1
            my_CValue = 1
            my_CVarName = "Rotation Num"
            my_DataType = DB_INT
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateIntegerEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            my_DatVarName = "Rotation Start"
            my_DialogDisplay = "Pre-Rotate"
            my_VBValue = 0
            my_CValue = 0
            my_CVarName = "Rotation Start"
            my_DataType = DB_DBL
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateDoubleEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            my_DatVarName = "Part Pass"
            my_DialogDisplay = "Priority"
            my_VBValue = 1
            my_CValue = 1
            my_CVarName = "Part Pass"
            my_DataType = DB_INT
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateIntegerEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            my_DatVarName = "Cost Per Part"
            my_DialogDisplay = "Cost Per Part"
            my_VBValue = 0
            my_CValue = 0
            my_CVarName = "Cost Per Part"
            my_DataType = DB_DBL
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateDoubleEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            sChoices.Clear()
            sChoices.Add("Actual Part")
            sChoices.Add("Bounding Box")
            sChoices.Add("Rubberband Box")

            my_DatVarName = "Representation"
            my_DialogDisplay = "Representation"
            my_VBValue = "Actual Part"
            my_CValue = 0
            my_CVarName = "Representation"
            my_DataType = DB_DCOMBO
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateComboBoxEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_RecodID, my_VBValue, sChoices))

            my_DatVarName = "MirrorPart"
            my_DialogDisplay = "Mirroring"
            my_VBValue = 0
            my_CValue = 0
            my_CVarName = "MirrorPart"
            my_DataType = DB_INT
            my_RecodID = 0
            my_sOptions = sEmpty

            catPartDefaultInfo.ChildRows.Add(CreateIntegerEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            vgPartDefaults.RowHeaderWidth = 100
            vgPartDefaults.Appearance.RowHeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far


            m_nesting_Template = RegGetString("Nesting", "Template", "")

            If (FileExists(m_nesting_Template)) Then

                Using sr As New StreamReader(m_nesting_Template)

                    While (sr.EndOfStream = False)

                        sData = sr.ReadLine()

                        sPieces = Split(sData, "|")
                        If (sData <> "") Then
                            my_DatVarName = sPieces(2)
                            my_DialogDisplay = sPieces(2)
                            my_VBValue = sPieces(3)
                            my_CValue = sPieces(3)
                            my_CVarName = sPieces(2)

                            Select Case ConvertDatTypeToDBType(sPieces(1))

                                Case DB_STR
                                    catPartDefaultInfo.ChildRows.Add(CreateStringEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                                Case DB_BOOL
                                    catPartDefaultInfo.ChildRows.Add(CreateBooleanEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                                Case DB_INT
                                    catPartDefaultInfo.ChildRows.Add(CreateIntegerEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                                Case DB_DBL
                                    catPartDefaultInfo.ChildRows.Add(CreateDoubleEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                                Case DB_CRIB
                                    MessageBox.Show("We should have loaded the tools")
                                Case DB_TOOL
                                    Dim nToolSetupID As Long = RegGetString("Global", "ToolSetupID", 0)


                                    my_CValue = 0
                                    my_VBValue = "None"
                                    my_RecodID = 0

                                    sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" &
                                    " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " &
                                    "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " &
                                    "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" &
                                    " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & nToolSetupID & "))" &
                                    " ORDER BY [Station Configuration].[NC Code Number]"

                                    arrOptions = PopulateComboList(sql, False, True)

                                    catPartDefaultInfo.ChildRows.Add(CreateComboBoxListEditorRow(vgPartDefaults,
                                                                           my_DatVarName,
                                                                        my_DialogDisplay,
                                                                        my_VBValue,
                                                                        my_CValue,
                                                                        my_CVarName,
                                                                        my_DataType,
                                                                        my_RecodID,
                                                                        arrOptions, 0))


                                Case DB_DCOMBO

                                    sChoices.Clear()

                                    For ni = 4 To UBound(sPieces)
                                        sChoices.Add(sPieces(ni))
                                    Next

                                    my_DatVarName = sPieces(2)
                                    my_DialogDisplay = sPieces(2)
                                    my_VBValue = sPieces(3)
                                    my_CValue = sPieces(3)
                                    my_CVarName = sPieces(2)
                                    my_DataType = DB_DCOMBO
                                    my_RecodID = 0
                                    my_sOptions = sEmpty

                                    catPartDefaultInfo.ChildRows.Add(CreateComboBoxEditorRow(vgPartDefaults, my_DatVarName, my_DialogDisplay, my_RecodID, my_VBValue, sChoices))


                            End Select
                        End If

                    End While

                    sr.Dispose()
                End Using

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub PopulateDefaultSettings()
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim myMachineList As MachineListCombo = New MachineListCombo()
        Dim sDefaultName As String = Nothing

        Dim datfilename As String = Nothing

        Dim sTemplate As String = RegGetString("Nesting", "Template", "")

        Try

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

            s_Machine = cbeMachine.Text
            m_machine_id = modMachine.GetMachineIDFromDescrip(s_Machine)

            If (m_machine_id <1) Then
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
            s_ToolSetup = cbeToolSetup.Text

            currentCategoryRow = CreateCategoryRow(vgNestDefaults, "glb.ToolSetupID",
                                                                         "Tool_Setup",
                                                                         s_ToolSetup,
                                                                         0,
                                                                         "Tool Setup ID", DB_HEADER,
                                                                         0, sEmpty, 0)

            Dim n_ToolSetupID As Integer
            sDefaultName = cbeToolSetup.Text ' RegGetString("Global", "ToolSetup", "")
            s_ToolSetup = cbeToolSetup.Text
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
            'sDefaultName = RegGetString("Global", "LayerSetup", "None")

            sDefaultName = cbeLayerSetup.Text

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

            'sDefaultName = RegGetString("Global", "LeadSetup", "None")
            sDefaultName = cbeLeadSetup.Text

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
                datfilename = NormalizePath(App_Path) & s_Machine & ".dat"
            Else
                datfilename = RegGetDatFilePath()
            End If

            populateFromDatFile(vgNestDefaults, datfilename, currentCategoryRow, lbOptions)

            vgNestDefaults.BestFit()
            vgNestDefaults.ResumeLayout()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Function GetLinksFromReg(sTemplateName As String) As String


        GetLinksFromReg = RegGetString("MRP\MRP_TEMPLATE\" & sTemplateName, "Links", "")
        ceMaterialToToolSetup.Checked = RegGetString("MRP\MRP_TEMPLATE\" & sTemplateName, "MaterialToTooletup", 0)
        ceMaterialToLayerSetup.Checked = RegGetString("MRP\MRP_TEMPLATE\" & sTemplateName, "MaterialToLayeretup", 0)

    End Function

    Sub GetSystemfields()
        Dim m_nesting_Template As String
        Dim sDatFileName As String
        Dim sData As String


        SYSTEM_ROOT_NODE = Nothing

        Try

            TV_NestConfig.ClearNodes()

            SYSTEM_MATERIAL_ROOT_NODE = TV_NestConfig.AppendNode(New Object() {"Material Vars"}, SYSTEM_ROOT_NODE, 0)
            SYSTEM_MATERIAL_ROOT_NODE.Tag = 0
            SYSTEM_MATERIAL_NAME_NODE = TV_NestConfig.AppendNode(New Object() {"Material_Name"}, SYSTEM_MATERIAL_ROOT_NODE, TAG_MATERIAL_NAME_NODE)
            SYSTEM_MATERIAL_LENGTH_NODE = TV_NestConfig.AppendNode(New Object() {"Material_Length"}, SYSTEM_MATERIAL_ROOT_NODE, TAG_MATERIAL_LENGTH_NODE)
            SYSTEM_MATERIAL_WIDTH_NODE = TV_NestConfig.AppendNode(New Object() {"Material_Width"}, SYSTEM_MATERIAL_ROOT_NODE, TAG_MATERIAL_WIDTH_NODE)
            SYSTEM_MATERIAL_THICKNESS_NODE = TV_NestConfig.AppendNode(New Object() {"Material_Thickness"}, SYSTEM_MATERIAL_ROOT_NODE, TAG_MATERIAL_THICKNESS_NODE)

            SYSTEM_NESTING_ROOT_NODE = TV_NestConfig.AppendNode(New Object() {"Nesting Vars"}, SYSTEM_ROOT_NODE, 0)

            If (FileExists(CStr(cbeMachine.Text) & ".dat") = True) Then

                sDatFileName = App_Path & "\" & cbeMachine.Text & ".dat"

            Else

                sDatFileName = RegGetDatFilePath()

            End If

            Using sr As StreamReader = New StreamReader(sDatFileName)

                While (sr.EndOfStream = False)

                    sData = sr.ReadLine()

                    sPieces = Split(sData, "|")

                    If (UBound(sPieces) > 1) Then

                        SYSTEM_NESTING_NODE = TV_NestConfig.AppendNode(New Object() {sPieces(2)}, SYSTEM_NESTING_ROOT_NODE, TAG_NESTING_NODE)

                    End If

                End While

                sr.Dispose()

            End Using


            SYSTEM_PART_ROOT_NODE = TV_NestConfig.AppendNode(New Object() {"Part Vars"}, SYSTEM_ROOT_NODE, 0)
            SYSTEM_PART_ROOT_NODE.Tag = 0
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Part Name"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Part Quantity"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Fill Part"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Rotations"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Pre-Rotate"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Priority"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Cost Per Part"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Representation"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Mirroring"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {"Pre-Nest"}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)

            m_nesting_Template = RegGetString("Nesting", "Template", "")

            If (FileExists(m_nesting_Template)) Then

                Add_User_Vars_Destination(m_nesting_Template)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub Add_User_Vars_Destination(s_template As String)
        Dim sData As String


        Try

            If (FileExists(s_template) = True) Then

                Using sr As StreamReader = New StreamReader(s_template)

                    While (sr.EndOfStream = False)

                        sData = sr.ReadLine()

                        If (sData <> "") Then
                            sPieces = Split(sData, "|")

                            SYSTEM_PART_NODE = TV_NestConfig.AppendNode(New Object() {sPieces(2)}, SYSTEM_PART_ROOT_NODE, TAG_PART_ROOT_NODE)
                        End If

                    End While

                    sr.Dispose()
                End Using

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Sub GetUserFields()
        Dim workbook As IWorkbook = SpreadsheetControl1.Document
        Dim my_WorkSheet As Worksheet = workbook.Worksheets(cboSheetTable.Text)
        Dim ni As Integer
        Dim sUserFieldName As String
        Dim sIndextext As String = sEmpty
        Dim datfilename As String
        Dim lCount As Integer
        Dim nCounter As Integer
        Dim sData As String

        USER_FIELDS_NODE = Nothing

        cbeSortBy.Properties.Items.Clear()
        cbeThenBy.Properties.Items.Clear()
        cbeAndThenBy.Properties.Items.Clear()
        cbeAndThenBy2.Properties.Items.Clear()


        chkThenBy.Enabled = False
        chkAndThenBy.Enabled = False
        chkAndThenBy2.Enabled = False

        cbeSortBy.SelectedIndex = -1
        cbeThenBy.SelectedIndex = -1
        cbeAndThenBy.SelectedIndex = -1
        cbeAndThenBy2.SelectedIndex = -1

        Try
            datfilename = RegGetString("Nesting", "Template", "")

            Dim datString As String = "" & datfilename & ""
            Dim datqualifier As String = "" & "glb" & ""
            Dim sClass As String = "glb"
            lReturn = PortalExecute("admin:javavarsextract:" &
           " file=" & QStr(datfilename) & ",class=" & QStr(sClass))

            lCount = PortalGetInt("count", 0)

            TV_UserFields.ClearNodes()

            For nCounter = 1 To lCount
                lReturn = PortalExecute("*admin:javavarget:index=" & nCounter - 1)

                sData = PortalGetString("data", "")

                ' parse out the data
                SplitVariableData(sData)

                'SER_FIELDS_ROOT_NODE = TV_UserFields.AppendNode(New Object() {sPieces(3)}, USER_FIELDS_NODE, 0)
            Next

            For ni = 0 To my_WorkSheet.GetUsedRange().ColumnCount - 1

                sUserFieldName = my_WorkSheet.Cells(ni).DisplayText
                If (sUserFieldName <> "") Then


                    USER_FIELDS_ROOT_NODE = TV_UserFields.AppendNode(New Object() {sUserFieldName}, USER_FIELDS_NODE, 0)

                    cbeSortBy.Properties.Items.Add(sUserFieldName)
                    cbeThenBy.Properties.Items.Add(sUserFieldName)
                    cbeAndThenBy.Properties.Items.Add(sUserFieldName)
                    cbeAndThenBy2.Properties.Items.Add(sUserFieldName)
                    cboFieldName.Properties.Items.Add(sUserFieldName)
                End If


            Next


            If (cbeSortBy.Properties.Items.Count > -1) Then
                sIndextext = RegGetString("MRP\Sorting", "SortBy", sEmpty)

                For ni = 0 To cbeSortBy.Properties.Items.Count - 1
                    If (UCase(sIndextext) = UCase(cbeSortBy.Properties.Items(ni).ToString)) Then
                        cbeSortBy.SelectedIndex = ni
                    End If

                Next
            End If

            If (cbeThenBy.Properties.Items.Count > -1) Then
                chkThenBy.Enabled = True
                sIndextext = RegGetString("MRP\Sorting", "ThenBy", sEmpty)

                For ni = 0 To cbeThenBy.Properties.Items.Count - 1
                    If (UCase(sIndextext) = UCase(cbeThenBy.Properties.Items(ni).ToString)) Then
                        cbeThenBy.SelectedIndex = ni
                    End If

                Next
            End If

            If (cbeAndThenBy.Properties.Items.Count > -1) Then
                chkAndThenBy.Enabled = True
                sIndextext = RegGetString("MRP\Sorting", "AndThenBy", sEmpty)

                For ni = 0 To cbeAndThenBy.Properties.Items.Count - 1
                    If (UCase(sIndextext) = UCase(cbeAndThenBy.Properties.Items(ni).ToString)) Then
                        cbeAndThenBy.SelectedIndex = ni
                    End If

                Next
            End If

            If (cbeAndThenBy2.Properties.Items.Count > -1) Then
                chkAndThenBy2.Enabled = True
                sIndextext = RegGetString("MRP\Sorting", "AndThenBy2", sEmpty)

                For ni = 0 To cbeAndThenBy2.Properties.Items.Count - 1
                    If (UCase(sIndextext) = UCase(cbeAndThenBy2.Properties.Items(ni).ToString)) Then
                        cbeAndThenBy2.SelectedIndex = ni
                    End If

                Next

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub sbBack_Click(sender As Object, e As EventArgs) Handles sbBack.Click

        sbNext.Enabled = True
        sbFinish.Enabled = False

        If (xtcMRP.SelectedTabPageIndex > 0) Then

            xtcMRP.SelectedTabPageIndex = xtcMRP.SelectedTabPageIndex - 1
            If (xtcMRP.SelectedTabPageIndex = 0) Then
                sbBack.Enabled = False
            Else
                sbBack.Enabled = True
            End If
        End If
        If (xtcMRP.SelectedTabPageIndex > 1) Then

        End If


    End Sub

    Private Sub fcbImportFile_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles fcbImportFile.ButtonClick
        Dim sMRP_File As String
        Dim sMRP_FileOpen As New OpenFileDialog



        cboSheetTable.Properties.Items.Clear()

        Try

            SpreadsheetControl1.CreateNewDocument()

            Select Case m_usage
                Case XLS_TYPE

                    sMRP_FileOpen.Filter = "XLS files (*.xls)|*.xls"
                    sMRP_FileOpen.FilterIndex = 1
                    sMRP_FileOpen.RestoreDirectory = True

                Case CSV_TYPE

                    sMRP_FileOpen.Filter = "CSV files (*.cs)|*.csv"
                    sMRP_FileOpen.FilterIndex = 1
                    sMRP_FileOpen.RestoreDirectory = True

                Case TAB_TYPE

                    sMRP_FileOpen.Filter = "TAB Delimited files (*.txt)|*.txt"
                    sMRP_FileOpen.FilterIndex = 1
                    sMRP_FileOpen.RestoreDirectory = True

                Case SEMICOLON_TYPE

                    sMRP_FileOpen.Filter = "Semi Colon files (*.txt)|*.txt"
                    sMRP_FileOpen.FilterIndex = 1
                    sMRP_FileOpen.RestoreDirectory = True
                Case MDB_TYPE

                    sMRP_FileOpen.Filter = "MDB files (*.mdb)|*.mdb"
                    sMRP_FileOpen.FilterIndex = 1
                    sMRP_FileOpen.RestoreDirectory = True

                Case XLSX_TYPE

                    sMRP_FileOpen.Filter = "XLSX files (*.xlsx)|*.xlsx"
                    sMRP_FileOpen.FilterIndex = 1
                    sMRP_FileOpen.RestoreDirectory = True

            End Select


            If sMRP_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sMRP_File = sMRP_FileOpen.FileName
                fcbImportFile.Text = sMRP_File

                fcbImportFile.ToolTip = sMRP_File

                Select Case m_usage

                    Case XLS_TYPE

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Xls)
                    Case CSV_TYPE, SEMICOLON_TYPE

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Csv)


                    Case TAB_TYPE
                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Text)
                    Case MDB_TYPE
                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Xls)

                    Case SEMICOLON_TYPE
                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Csv)

                    Case XLSX_TYPE

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Xlsx)


                End Select
                'If m_usage = CSV_TYPE Then

                '    SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Csv)
                '    PopulateSheetCombo(cboSheetTable)
                '    cboSheetTable.SelectedIndex = 0
                'End If


            End If
            PopulateSheetCombo(cboSheetTable)
            cboSheetTable.SelectedIndex = 0

            'SpreadsheetControl1.ActiveWorksheet.Cells.AutoFitColumns

            'SpreadsheetControl1.Refresh()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub frmMRP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub

    Private Sub frmMRP_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim machineID As Long
        Dim ToolSetupID As Long
        Dim materialID As Long
        Dim layersetupID As Long
        Dim LeadSetupID As Long
        Dim sLeadsetup As String
        Dim ni As Integer

        sTempUserFolder = My.Computer.FileSystem.SpecialDirectories.Temp

        fcbImportFile.Text = ""

        cboSheetTable.Properties.Items.Clear()

        cbeLeadSetup.Properties.Items.Clear()


        Try

#If DIAMOND Then
            lcbFileType.Properties.Items.Add("DiamondLife")
#End If

            sMergePartsFilename = NormalizePath(sTempUserFolder) & "_merpart.txt"

            rgMrpFileType.SelectedIndex = RegGetString("MRP", "MRP_TYPE", "0")

            machineID = modProject.GetMachineID()

            If (DoesMachineExists(machineID) = True) Then

                ToolSetupID = modProject.GetToolSetupID()
                layersetupID = modProject.GetLayerSetupID

            Else

                machineID = 0
                ToolSetupID = 0
                layersetupID = 0

            End If

            materialID = modProject.GetMaterialID()

            If (DoesMaterialExist(materialID) = False) Then

                materialID = 0

            End If

            sLeadsetup = RegGetString("Global", "LeadSetup", "")
            LeadSetupID = GetLeadSetupID(sLeadsetup)


            modProject.InitMachineList(cbeMachine, machineID)
            modProject.InitToolSetupList(cbeToolSetup, machineID, ToolSetupID)
            modProject.InitMaterialList(cbeMaterial, materialID)
            modProject.InitLayerSetupList(cbeLayerSetup, machineID, layersetupID)

            arrLeadSetup = PopulateComboList("SELECT * FROM [Lead Setup] ORDER BY [Description]", False, True)

            For ni = 1 To arrLeadSetup.Count

                cbeLeadSetup.Properties.Items.Add(arrLeadSetup.Item(ni).description)

                If sLeadsetup = arrLeadSetup.Item(ni).description Then
                    cbeLeadSetup.SelectedItem = sLeadsetup
                End If

            Next

            ' cbeLeadSetup.SelectedIndex = 0


            optPDBName.SelectedIndex = 0

            DateEdit1.EditValue = Now
            GetDefaultsFromRegistry()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub GetDefaultsFromRegistry()
        Dim ni As Integer
        Dim sSheetTableName As String

        Try

            chkHeader.CheckState = IIf(RegGetString("MRP", "MRP_HAS_HEADER", "0") = True, 1, 0)
            chkHasPath.CheckState = IIf(RegGetString("MRP", "MRP_HAS_PATH", "0") = True, 1, 0)
            chkAppendMat.CheckState = IIf(RegGetString("MRP", "MRP_APPEND_MATERIAL", "0") = True, 1, 0)
            chkCopySource.CheckState = IIf(RegGetString("MRP", "MRP_COPY_SOURCE", "0") = True, 1, 0)


            fcbSourceFolder.Text = RegGetString("MRP", "MRP_SOURCE_FOLDER", "")
            fcbResultsDirectory.Text = RegGetString("MRP", "MRP_RESULT_FOLDER", "")
            fcbMM2Source.Text = RegGetString("MRP", "MM2_SOURCE_FOLDER", "")
            sSheetTableName = RegGetString("MRP", "MRP_WORKSHEET", "")


            intImportType = RegGetString("MRP", "MRP_TYPE", "0")

            rgMrpFileType.SelectedIndex = intImportType


            fcbImportFile.Text = RegGetString("MRP", "MRP_FILE", "")

            lcbFileType.SelectedIndex = RegGetString("MRP", "MRP_SOURCE_TYPE", "0")

            optPDBName.SelectedIndex = RegGetString("MRP", "optPDBName", "0")

            'fcbImportFile.Enabled = False

            teProvidedName.Enabled = False

            cboFieldName.Enabled = False



            Select Case optPDBName.SelectedIndex
                Case 0
                    fcbImportFile.Enabled = True
                    teImportFilename.Text = PathFile(fcbImportFile.Text)

                Case 1
                    teProvidedName.Enabled = True
                    teProvidedName.Text = "<Enter Job Name>"
                Case 2
                    cboFieldName.Enabled = True



            End Select
            If (fcbImportFile.Text <> "") Then

                For ni = 0 To cboSheetTable.Properties.Items.Count - 1
                    If (cboSheetTable.Properties.Items(ni).ToString = sSheetTableName) Then
                        cboSheetTable.SelectedIndex = ni
                    End If
                Next

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub fcbImportFile_EditValueChanged(sender As Object, e As EventArgs) Handles fcbImportFile.EditValueChanged

        Try

            Select Case m_usage
                Case XLS_TYPE
                    If (fcbImportFile.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Xls)
                        PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = -1

                Case CSV_TYPE
                    If (fcbImportFile.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Csv)
                        PopulateSheetCombo(cboSheetTable)
                        'Dim myTable As Table = SpreadsheetControl1.ActiveWorksheet.Tables(0)

                        'myTable.ShowHeaders = True
                        'myTable.ShowTotals = True
                        '' Apply banded column formatting to the table.
                        'myTable.ShowTableStyleRowStripes = False
                        'myTable.ShowTableStyleColumnStripes = True

                        ''ApplyInitialBuiltInTableStyle()

                        'PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case TAB_TYPE

                    If (fcbImportFile.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Text)
                        PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case SEMICOLON_TYPE

                    If (fcbImportFile.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Text)
                        PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case MDB_TYPE
                    If (fcbImportFile.Text <> "") Then

                        PopulateMDB_Tables_To_Combo(fcbImportFile.Text)

                    End If

                    cboSheetTable.SelectedIndex = 0

                Case XLSX_TYPE

                    SpreadsheetControl1.LoadDocument(fcbImportFile.Text, DocumentFormat.Xlsx)
                    PopulateSheetCombo(cboSheetTable)

                    cboSheetTable.SelectedIndex = -1

            End Select

            teImportFilename.Text = PathFile(fcbImportFile.Text)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub ApplyInitialBuiltInTableStyle()
        '            #Region "#ApplyInitialBuiltInTableStyle"
        SpreadsheetControl1.BeginUpdate()
        ' Access the workbook's collection of table styles.
        Dim tableStyles As TableStyleCollection = SpreadsheetControl1.Document.TableStyles
        ' Access the built-in table style from the collection by its Id.
        Dim tableStyle As TableStyle = tableStyles(BuiltInTableStyleId.TableStyleDark9)

        ' Apply the table style to the existing table.
        Dim myTable As Table = SpreadsheetControl1.ActiveWorksheet.Tables(0)
        myTable.Style = tableStyle

        ' Show header and total rows.
        myTable.ShowHeaders = True
        myTable.ShowTotals = True
        ' Apply banded column formatting to the table.
        myTable.ShowTableStyleRowStripes = False
        myTable.ShowTableStyleColumnStripes = True

        SpreadsheetControl1.EndUpdate()
        '            #End Region ' #ApplyInitialBuiltInTableStyle
    End Sub
    Private Sub SetDefaultsInRegistry()
        Dim nToolSetupId As Long
        Dim nLayerSetupId As Long
        Dim nLeadSetupId As Long
        Dim nMachineSetupId As Long
        Dim nMaterialSetupId As Long

        Try

            nMachineSetupId = GetMachineIDFromDescrip(cbeMachine.Text)

            nToolSetupId = GetToolSetupIDFromDescription(cbeToolSetup.Text)

            nLayerSetupId = modTranslate.GetLayerSetupID(cbeLayerSetup.Text, nMachineSetupId)

            nLeadSetupId = GetLeadSetupID(cbeLeadSetup.Text)

            nMaterialSetupId = GetMaterialIDFromDescription(cbeMaterial.Text)

            SetToolSetup(cbeToolSetup.Text, nToolSetupId)

            SetLayerSetup(cbeLayerSetup.Text, nLayerSetupId)

            SetLeadSetup(cbeLeadSetup.Text, nLeadSetupId)

            SetMachine(cbeMachine.Text, nMachineSetupId)
            SetMaterial(cbeMaterial.Text, nMaterialSetupId)

            RegPutString("MRP", "MRP_FILE", fcbImportFile.Text)
            RegPutString("MRP", "MRP_TYPE", rgMrpFileType.SelectedIndex)
            RegPutString("MRP", "MRP_WORKSHEET", cboSheetTable.Text)
            RegPutString("MRP", "MRP_HAS_HEADER", chkHeader.Checked)
            RegPutString("MRP", "MRP_HAS_PATH", chkHasPath.Checked)
            RegPutString("MRP", "MRP_APPEND_MATERIAL", chkAppendMat.Checked)
            RegPutString("MRP", "MRP_COPY_SOURCE", chkCopySource.Checked)
            RegPutString("MRP", "MRP_SOURCE_TYPE", lcbFileType.SelectedIndex)
            RegPutString("MRP", "MRP_SOURCE_FOLDER", fcbSourceFolder.Text)
            RegPutString("MRP", "MRP_RESULT_FOLDER", fcbResultsDirectory.Text)
            RegPutString("MRP", "MM2_SOURCE_FOLDER", fcbMM2Source.Text)

            RegPutString("MRP", "optPDBName", optPDBName.SelectedIndex)

            If (cboFieldName.SelectedIndex > -1) Then

                RegPutString("MRP", "USER_FIELD", cboFieldName.Properties.Items.Item(cboFieldName.SelectedIndex).ToString)

            Else

                RegPutString("MRP", "USER_FIELD", -1)

            End If

            If (cbeSortBy.SelectedIndex > -1) Then
                RegPutString("MRP\Sorting", "SortBy", cbeSortBy.Text)
            End If

            If (cbeThenBy.SelectedIndex > -1) Then
                RegPutString("MRP\Sorting", "ThenBy", cbeThenBy.Text)
            End If

            If (cbeAndThenBy.SelectedIndex > -1) Then
                RegPutString("MRP\Sorting", "AndThenBy", cbeAndThenBy.Text)
            End If

            If (cbeAndThenBy2.SelectedIndex > -1) Then
                RegPutString("MRP\Sorting", "AndThenBy2", cbeAndThenBy2.Text)
            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub cboSheetTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheetTable.SelectedIndexChanged

        Try

            Select Case m_usage
                Case XLS_TYPE

                Case TAB_TYPE

                Case SEMICOLON_TYPE

                Case MDB_TYPE
                    If (fcbImportFile.Text <> "") Then
                        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fcbImportFile.Text

                        ' Create the dataset and add the Categories table to it:
                        Dim myAccessConn As OleDbConnection = Nothing
                        Try
                            myAccessConn = New OleDbConnection(connectionString)
                        Catch ex As Exception
                            MessageBox.Show("Error: Failed to create a database connection. " & Constants.vbCrLf & ex.Message, "Error")
                            Return
                        End Try
                        Try
                            myAccessConn.Open()

                            SpreadsheetControl1.BeginUpdate()
                            SpreadsheetControl1.Document.CreateNewDocument()
                            ' We only want user tables, not system tables
                            Dim restrictions(3) As String
                            restrictions(3) = "Table"
                            ' Get list of user tables
                            Dim userTables As DataTable = myAccessConn.GetSchema("Tables", restrictions)
                            ' Getting the data for every user tables

                            Dim currentTableName As String = cboSheetTable.Text  'userTablesRow("TABLE_NAME").ToString()

                            Using cmd As New OleDbCommand(String.Format("SELECT * FROM [{0}]", currentTableName), myAccessConn)

                                Using adapter As New OleDbDataAdapter(cmd)
                                    Dim currentDataTable As New DataTable(currentTableName)
                                    adapter.Fill(currentDataTable)
                                    LoadDataTableContentIntoSpreadsheetControl(currentDataTable)
                                End Using


                            End Using

                            SpreadsheetControl1.EndUpdate()

                        Catch ex As Exception
                            MessageBox.Show("Error: Failed to retrieve the required data from the DataBase." & Constants.vbCrLf & ex.Message, "Error")
                            Return

                        Finally
                            myAccessConn.Close()

                        End Try

                    End If

            End Select

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub LoadDataTableContentIntoSpreadsheetControl(ByVal currentTable As DataTable)
        Dim workSheet As Worksheet = SpreadsheetControl1.Document.Worksheets(0)

        Try

            SpreadsheetControl1.Document.Worksheets(0).Name = currentTable.TableName

            For i As Integer = 0 To currentTable.Columns.Count - 1
                workSheet.Cells(0, i).Value = currentTable.Columns(i).ColumnName
            Next i

            For i As Integer = 0 To currentTable.Columns.Count - 1
                For j As Integer = 0 To currentTable.Rows.Count - 1
                    workSheet.Cells(j + 2, i).Value = currentTable.Rows(j)(i).ToString()
                Next j
            Next i
            Dim table As Table = workSheet.Tables.Add(workSheet.GetDataRange(), True)
            table.Style = SpreadsheetControl1.Document.TableStyles(BuiltInTableStyleId.TableStyleLight1)
            workSheet.Columns.AutoFit(0, workSheet.Columns.LastUsedIndex)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub fcbSourceFolder_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles fcbSourceFolder.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            fcbSourceFolder.Text = m_folderDialog.SelectedPath

        End If

    End Sub

    Private Sub fcbResultsDirectory_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs)
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            fcbResultsDirectory.Text = m_folderDialog.SelectedPath

        End If
    End Sub

    Private Sub fcbMM2Source_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs)
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            fcbMM2Source.Text = m_folderDialog.SelectedPath

        End If
    End Sub

    Private Sub cbeMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMachine.SelectedIndexChanged

        If (cbeMachine.SelectedIndex > -1) Then

            Dim machineid As Long = (TryCast(cbeMachine.SelectedItem, myItemData).ItemData.ToString())

            modProject.InitToolSetupList(cbeToolSetup, machineid, 0)
            modProject.InitLayerSetupList(cbeLayerSetup, machineid, 0)
            SetMachine(cbeMachine.Text, machineid)


        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        bDo_MRP_Nesting = False

        repositoryItemButtonEdit = New RepositoryItemButtonEdit()

        Dim skin As Skin = CommonSkins.GetSkin(UserLookAndFeel.Default)

        DnDHighlightHelper1.AppearanceHighlight.BackColor = skin.Colors.GetColor(CommonColors.Highlight)

        ' Add any initialization after the InitializeComponent() call.
        AddHandler UserLookAndFeel.Default.StyleChanged, AddressOf Default_StyleChanged

        xtcMRP.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False

    End Sub
    Private Sub Default_StyleChanged(sender As Object, e As EventArgs)
        SetFrozenRowColor()
    End Sub

    Private Sub SetFrozenRowColor()

        Dim formatting As Formatting = SpreadsheetControl1.ActiveWorksheet.Rows(0).BeginUpdateFormatting()
        Dim skin As Skin = CommonSkins.GetSkin(UserLookAndFeel.Default)

        formatting.Fill.BackgroundColor = skin.Colors.GetColor(CommonColors.ReadOnly)

        SpreadsheetControl1.ActiveWorksheet.Rows(0).EndUpdateFormatting(formatting)

    End Sub
    Private Sub SaveLinkData()

        m_templateName = RegGetString("MRP", "MRP_TEMPLATE", "")

        RegPutString("MRP\MRP_TEMPLATE\" & m_templateName, "Links", CreateStringFromLinks())
        RegPutString("MRP\MRP_TEMPLATE\" & m_templateName, "MaterialToTooletup", ceMaterialToToolSetup.Checked)
        RegPutString("MRP\MRP_TEMPLATE\" & m_templateName, "MaterialToLayeretup", ceMaterialToLayerSetup.Checked)


    End Sub

    Private Function CreateStringFromLinks() As String

        CreateStringFromLinks = ""

        For ni = 0 To TV_MappedFields.Nodes.Count - 1

            CreateStringFromLinks = CreateStringFromLinks & TV_MappedFields.Nodes.Item(ni).GetDisplayText(0) & ";"

        Next

        If Mid$(CreateStringFromLinks, Len(CreateStringFromLinks), 1) = "," Then
            CreateStringFromLinks = Mid$(CreateStringFromLinks, 1, Len(CreateStringFromLinks) - 1)
        End If

    End Function


    Private Sub sbFinish_Click(sender As Object, e As EventArgs) Handles sbFinish.Click
        Dim ni As Integer
        Dim sWorkSheetTable As String = sEmpty
        Dim workbook As IWorkbook = SpreadsheetControl1.Document

        Try
            'MessageBox.Show("If clicked on finish")
            ' SplashScreenManager.ShowForm(GetType(WaitForm1))
            Windows.Forms.Cursor.Current = Cursors.WaitCursor


            sWorkSheetTable = cboSheetTable.Text

            Dim worksheet As Worksheet = workbook.Worksheets(sWorkSheetTable)
            workbook.BeginUpdate()

            Dim dataRange As Range = worksheet.GetDataRange()
            Dim sortRange As Range = worksheet.Range.FromLTRB(dataRange.LeftColumnIndex, dataRange.TopRowIndex + 1, dataRange.RightColumnIndex, dataRange.BottomRowIndex)
            Dim sortCriteria As New List(Of SortField)()

            If (cbeSortBy.SelectedIndex > -1) Then
                cFirstCell = worksheet.Search(cbeSortBy.Text).FirstOrDefault()
                sortCriteria.Add(New SortField() With {.ColumnOffset = cFirstCell.LeftColumnIndex, .Comparer = worksheet.Comparers.Ascending})
            End If

            If (cbeThenBy.SelectedIndex > -1) Then
                cSecondCell = worksheet.Search(cbeThenBy.Text).FirstOrDefault()
                sortCriteria.Add(New SortField() With {.ColumnOffset = cSecondCell.LeftColumnIndex, .Comparer = worksheet.Comparers.Ascending})
            End If

            If (cbeAndThenBy.SelectedIndex > -1) Then
                cThridCell = worksheet.Search(cbeAndThenBy.Text).FirstOrDefault()
                sortCriteria.Add(New SortField() With {.ColumnOffset = cThridCell.LeftColumnIndex, .Comparer = worksheet.Comparers.Ascending})
            End If

            If (cbeAndThenBy2.SelectedIndex > -1) Then
                cFourthCell = worksheet.Search(cbeAndThenBy2.Text).FirstOrDefault()
                sortCriteria.Add(New SortField() With {.ColumnOffset = cFourthCell.LeftColumnIndex, .Comparer = worksheet.Comparers.Ascending})
            End If

            worksheet.Sort(sortRange, sortCriteria)
            workbook.EndUpdate()

            For ni = 1 To worksheet.Rows.LastUsedIndex

            Next

            SetDefaultsInRegistry()

#If APIHeatTransfer Then


            CreateMasterPDBaNdSubPDBs()

#Else
            GetPDBNames()

            FillPartListInPDBs()

#End If

            PathPDB_Set(sMRP_DB)

            bDo_MRP_Nesting = True

            Windows.Forms.Cursor.Current = Cursors.Default

            'SplashScreenManager.CloseForm()

            MessageBox.Show("Conversion completed!", "Conversion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Cursors.Default

            MessageBox.Show("Conversion Failed!", "Conversion Failed! " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub CreateMasterPDBaNdSubPDBs()
        ' ... existing variable declarations ...

        Dim pdb_store_name As String = Nothing
        Dim pdb_name As String
        Dim pdb_Path_Filename As String = Nothing
        Dim cat As ADOX.Catalog = New ADOX.Catalog()
        Dim sMySecondCellText As String = Nothing
        Dim pdb_info As NESTDBINFO
        Dim sResultPath As String
        Dim l_LayerSetupID As Long
        Dim l_LeadSetupID As Long
        Dim l_Mat_Type_ID As Long = -1
        Dim s_MatTypeDescrip As String
        Dim sConstructedPDBName As String = Nothing
        Dim b_UseMatForToolSetup As Boolean
        Dim b_UseMatForLayerSetup As Boolean
        Dim sSearchText As String = Nothing

        Dim nCounter As Integer = 1
        Dim sMySQL As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sMatCode As String
        Dim sFullPartName As String
        Dim sMRP_DBPath As String

        Try
            SaveLinkData()
            m_XLS_Name = fcbImportFile.Text
            m_job_name = cboSheetTable.Text
            pdb_store_name = Nothing
            s_Machine = cbeMachine.Text
            l_MachineID = GetMachineIDFromDescrip(s_Machine)
            s_ToolSetup = cbeToolSetup.Text
            l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)
            s_LeadSetup = cbeLeadSetup.Text
            l_LeadSetupID = GetLeadSetupID(s_LeadSetup)
            s_LayerSetup = cbeLayerSetup.Text
            l_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, l_MachineID)
            sSubFolder = m_job_name.Substring(0, 2)

            If (sMRP_DBSave_Folder = sSteelFolder) Then
                sMRP_DB = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & ".mrp"
            Else
                sMRP_DB = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & ".mrp"
            End If

            sMRP_DBPath = GetFilePath(sMRP_DB)
            If (FolderExists(sMRP_DBPath) = False) Then
                My.Computer.FileSystem.CreateDirectory(sMRP_DBPath)
            End If
            If (FileExists(sMRP_DB) = True) Then
                Kill(sMRP_DB)
            End If

            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" &
                   "Data Source=" & sMRP_DB & ";" &
                   "Jet OLEDB:Engine Type=5")
            cat.ActiveConnection.Close()
            modNesting.MRPDBNAME = sMRP_DB
            CreateMRPTable(sMRP_DB)

            '----- Cleaned column names -----
            Dim colRMPart As String = CleanName("RM Part")   ' → RM_Part
            Dim colRMName As String = CleanName("RM Name")   ' → RM_Name

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sTempMDB & "';"

            ' Updated ORDER BY to use cleaned name
            sMySQL = "SELECT * FROM [" & cboSheetTable.Text & "] ORDER BY [" & colRMPart & "]"

            connection = New OleDbConnection(connetionString)
            oledbAdapter = New OleDbDataAdapter(sMySQL, connection)
            oledbAdapter.Fill(ds)
            oledbAdapter.Dispose()
            connection.Close()
            connection.Dispose()

            ProgressBarControl1.Properties.Maximum = ds.Tables(0).Rows.Count - 1

            For i = 0 To ds.Tables(0).Rows.Count - 1
                ProgressBarControl1.EditValue = i
                ProgressBarControl1.Update()

                '----- Use cleaned column names -----
                sFullPartName = GetFieldValue(ds.Tables(0).Rows(i), colRMName)
                sMatCode = GetFieldValue(ds.Tables(0).Rows(i), colRMPart)

                pdb_name = sMatCode
                l_Mat_Type_ID = GetMaterialTypeIDFromDisplay(sMatCode)
                l_Mat_ID = Get1stMaterialID(l_Mat_Type_ID)
                s_MatTypeDescrip = sFullPartName          ' already retrieved above

                If (InStr(UCase(s_MatTypeDescrip), "ALUM") > 0) Then
                    pdb_Path_Filename = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & sMatCode & ".pdb"
                    sResultPath = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\"
                Else
                    pdb_Path_Filename = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & sMatCode & ".pdb"
                    sResultPath = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\"
                End If

                d_MatLength = modMaterial.GetMaterialLength(l_Mat_ID)
                d_MatWidth = modMaterial.GetMaterialWidth(l_Mat_ID)
                d_MatThickness = modMaterial.GetMaterialThickness(l_Mat_ID)
                d_MatQty = modMaterial.GetMaterialQty(l_Mat_ID)
                d_MatWeight = modMaterial.CheckMaterialWeight(l_Mat_ID)
                d_MatCost = modMaterial.GetMaterialCost(l_Mat_ID)

                If (UCase(Trim(pdb_name)) <> UCase(Trim(pdb_store_name))) Then
                    PathPDB_Set(pdb_Path_Filename)
                    pdb_store_name = pdb_name
                    AddPdbToTable(sMRP_DB, pdb_Path_Filename)

                    If (FileExists(pdb_Path_Filename) = True) Then
                        ConditionalFileDelete(pdb_Path_Filename)
                    End If

                    pdb_info = InitPdbInfo(
                            pdb_Path_Filename, sResultPath, s_Machine, l_MachineID,
                            s_ToolSetup, l_ToolSetupid, s_MatTypeDescrip, l_Mat_ID,
                            s_LeadSetup, l_LeadSetupID,
                            s_LayerSetup, l_LayerSetupID)

                    If (EstablishPDB(pdb_info) = String.Empty) Then
                        MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)
                    Else
                        modMRP.AddMaterialToMaterialInventorys(pdb_Path_Filename, s_MatTypeDescrip, l_Mat_Type_ID,
                                                          d_MatLength, d_MatWidth, d_MatThickness,
                                                          d_MatWeight, d_MatQty, d_MatCost)
                        UpdateSetupTable(pdb_Path_Filename, vgNestDefaults, s_MatTypeDescrip,
                                     b_UseMatForToolSetup, b_UseMatForLayerSetup)
                    End If
                End If

                If (l_Mat_ID > 0) Then
#If APIHeatTransfer Then
                    AddAPIHeatPart(pdb_Path_Filename, l_Mat_Type_ID, sMatCode, s_MatTypeDescrip,
                               d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight,
                               d_MatQty, d_MatCost, ds, i)
#Else
                'AddNormalPart(...)
#End If
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("CreateMasterPDBaNdSubPDBs: " & ex.Message)
        Finally
            If oledbAdapter IsNot Nothing Then oledbAdapter.Dispose()
            If connection IsNot Nothing Then
                If connection.State = ConnectionState.Open Then connection.Close()
                connection.Dispose()
            End If
            If ds IsNot Nothing Then ds.Dispose()
            If cat IsNot Nothing Then
                Try
                    cat.ActiveConnection = Nothing
                Catch
                End Try
                cat = Nothing
            End If
        End Try
    End Sub



    '    Private Sub CreateMasterPDBaNdSubPDBs()
    '        Dim pdb_store_name As String = Nothing
    '        Dim pdb_name As String
    '        Dim pdb_Path_Filename As String = Nothing
    '        Dim cat As ADOX.Catalog = New ADOX.Catalog()
    '        Dim sMySecondCellText As String = Nothing
    '        Dim pdb_info As NESTDBINFO
    '        Dim sResultPath As String
    '        Dim l_LayerSetupID As Long
    '        Dim l_LeadSetupID As Long
    '        Dim l_Mat_Type_ID As Long = -1
    '        Dim s_MatTypeDescrip As String
    '        Dim sConstructedPDBName As String = Nothing
    '        Dim b_UseMatForToolSetup As Boolean
    '        Dim b_UseMatForLayerSetup As Boolean
    '        Dim sSearchText As String = Nothing

    '        Dim nCounter As Integer = 1
    '        Dim sMySQL As String
    '        Dim ds As New DataSet
    '        Dim connection As OleDbConnection
    '        Dim oledbAdapter As OleDbDataAdapter
    '        Dim connetionString As String
    '        Dim sMatCode As String
    '        Dim sFullPartName As String
    '        Dim sMRP_DBPath As String


    '        Try
    '            SaveLinkData()

    '            m_XLS_Name = fcbImportFile.Text

    '            m_job_name = cboSheetTable.Text

    '            pdb_store_name = Nothing

    '            s_Machine = cbeMachine.Text
    '            l_MachineID = GetMachineIDFromDescrip(s_Machine)


    '            s_ToolSetup = cbeToolSetup.Text

    '            l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)
    '            s_LeadSetup = cbeLeadSetup.Text
    '            l_LeadSetupID = GetLeadSetupID(s_LeadSetup)
    '            s_LayerSetup = cbeLayerSetup.Text
    '            l_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, l_MachineID)

    '            sSubFolder = m_job_name.Substring(0, 2)


    '            If (sMRP_DBSave_Folder = sSteelFolder) Then

    '                sMRP_DB = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & ".mrp"
    '            Else
    '                sMRP_DB = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & ".mrp"
    '            End If

    '            sMRP_DBPath = GetFilePath(sMRP_DB)

    '            If (FolderExists(sMRP_DBPath) = False) Then
    '                My.Computer.FileSystem.CreateDirectory(sMRP_DBPath)
    '            End If
    '            If (FileExists(sMRP_DB) = True) Then

    '                Kill(sMRP_DB)


    '            End If

    '            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" &
    '                               "Data Source=" & sMRP_DB & ";" &
    '                               "Jet OLEDB:Engine Type=5")

    '            cat.ActiveConnection.close()

    '            modNesting.MRPDBNAME = sMRP_DB

    '            CreateMRPTable(sMRP_DB)

    '            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sTempMDB & "';"

    '            sMySQL = "Select* From [" & cboSheetTable.Text & "] Order By [RM Part]"

    '            connection = New OleDbConnection(connetionString)

    '            oledbAdapter = New OleDbDataAdapter(sMySQL, connection)

    '            oledbAdapter.Fill(ds)

    '            oledbAdapter.Dispose()

    '            connection.Dispose()
    '            connection.Close()

    '            ProgressBarControl1.Properties.Maximum = ds.Tables(0).Rows.Count - 1

    '            For i = 0 To ds.Tables(0).Rows.Count - 1

    '                ProgressBarControl1.EditValue = i
    '                ProgressBarControl1.Update()

    '                sFullPartName = ds.Tables(0).Rows(i).Item("RM Name").ToString

    '                sMatCode = ds.Tables(0).Rows(i).Item("RM Part").ToString
    '                pdb_name = sMatCode



    '                l_Mat_Type_ID = GetMaterialTypeIDFromDisplay(sMatCode)

    '                l_Mat_ID = Get1stMaterialID(l_Mat_Type_ID)

    '                s_MatTypeDescrip = ds.Tables(0).Rows(i).Item("RM Name").ToString

    '                'pdb_name= 
    '                If (InStr(UCase(s_MatTypeDescrip), "ALUM") > 0) Then

    '                    pdb_Path_Filename = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & sMatCode & ".pdb"

    '                    sResultPath = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\"
    '                Else

    '                    pdb_Path_Filename = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & sMatCode & ".pdb"

    '                    sResultPath = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\"
    '                End If

    '                'l_Mat_ID = modTranslate.GetMaterialIDFromDescription(s_MatTypeDescrip)

    '                'l_Mat_Type_ID = GetMaterialTypeIDFromDescription(s_MatTypeDescrip)
    '                'l_Mat_Type_ID = GetMaterialTypeIDFromDisplay(sMatCode)

    '                d_MatLength = modMaterial.GetMaterialLength(l_Mat_ID)

    '                d_MatWidth = modMaterial.GetMaterialWidth(l_Mat_ID)

    '                d_MatThickness = modMaterial.GetMaterialThickness(l_Mat_ID)

    '                d_MatQty = modMaterial.GetMaterialQty(l_Mat_ID)

    '                d_MatWeight = modMaterial.CheckMaterialWeight(l_Mat_ID)

    '                d_MatCost = modMaterial.GetMaterialCost(l_Mat_ID)

    '                If (UCase(Trim(pdb_name)) = UCase(Trim(pdb_store_name)) = False) Then
    '                    PathPDB_Set(pdb_Path_Filename)

    '                    pdb_store_name = pdb_name

    '                    AddPdbToTable(sMRP_DB, pdb_Path_Filename)

    '                    If (FileExists(pdb_Path_Filename) = True) Then

    '                        ConditionalFileDelete(pdb_Path_Filename)

    '                    End If

    '                    'SplashScreenManager.Default.SetWaitFormDescription("Creating Nesting Database" & pdb_store_name)

    '                    pdb_info = InitPdbInfo(
    '                                pdb_Path_Filename, sResultPath, s_Machine, l_MachineID,
    '                                s_ToolSetup, l_ToolSetupid, s_MatTypeDescrip, l_Mat_ID,
    '                                s_LeadSetup, l_LeadSetupID,
    '                                s_LayerSetup, l_LayerSetupID)


    '                    If (EstablishPDB(pdb_info) = String.Empty) Then
    '                        MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)
    '                    Else

    '                        modMRP.AddMaterialToMaterialInventorys(pdb_Path_Filename, s_MatTypeDescrip, l_Mat_Type_ID, d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight, d_MatQty, d_MatCost)

    '                        UpdateSetupTable(pdb_Path_Filename, vgNestDefaults, s_MatTypeDescrip, b_UseMatForToolSetup, b_UseMatForLayerSetup)
    '                    End If

    '                End If


    '                If (l_Mat_ID > 0) Then
    '#If APIHeatTransfer Then
    '                    'MessageBox.Show("Before adding the part")
    '                    AddAPIHeatPart(pdb_Path_Filename, l_Mat_Type_ID, sMatCode, s_MatTypeDescrip, d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight, d_MatQty, d_MatCost, ds, i)
    '#Else

    '                                        'AddNormalPart(pdb_Path_Filename, niPart, SpreadsheetControl1)
    '#End If

    '                End If

    '            Next
    '            ds.Dispose()

    '            If connection IsNot Nothing Then connection = Nothing
    '            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
    '            If ds IsNot Nothing Then ds = Nothing

    '        Catch ex As Exception

    '            MessageBox.Show("CreateMasterPDBaNdSubPDBs: " & ex.Message)

    '        End Try

    '    End Sub
    Private Sub FillPartListInPDBs()
        Dim sPartName As String
        Dim sFields As String
        Dim sValues As String
        Dim sdata As String
        Dim sPieces() As String

        Using sr As StreamReader = New StreamReader(sMergePartsFilename)

            While (sr.EndOfStream = False)
                sdata = sr.ReadLine

                If (sdata <> " ") Then
                    Dim m_cnPart As New OleDb.OleDbConnection
                    Dim m_daPart As New OleDb.OleDbDataAdapter
                    Dim m_dtPart As New DataTable
                    Dim connetionString As String
                    Dim sql As String


                    sPieces = Split(sdata, "|")
                    sPartName = sPieces(1)
                    sFields = "[Filename],[Part Quantity],[Fill Part],[Rotation Num], [MirrorPart],[Rotation Start],[Part Pass],[Part Priority],[Cost Per Part], [Representation],[Special Priority],[Hold ID], [PreNest], [Part_Extents]"
                    sValues = sPieces(2)

                    connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPieces(0) & " ';"

                    m_cnPart = New OleDbConnection(connetionString)

                    m_cnPart.Open()

                    sql = "INSERT INTO [Part] (" & sFields & " ) VALUES(" & sValues & ")"


                    m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

                    lReturn = m_daPart.InsertCommand.ExecuteNonQuery()

                    m_daPart.Dispose()
                    m_daPart = Nothing
                    m_cnPart.Dispose()
                    m_cnPart = Nothing
                End If


            End While
            sr.Dispose()
        End Using

    End Sub
    Private Sub PopulateSheetCombo(cboComboBox As DevExpress.XtraEditors.ComboBoxEdit)
        Dim sWorkSheetName As String
        Dim workbook As IWorkbook = SpreadsheetControl1.Document

        For ni = 0 To workbook.Worksheets.Count - 1

            sWorkSheetName = workbook.Worksheets(ni).Name

            cboComboBox.Properties.Items.Add(sWorkSheetName)

        Next

    End Sub

    Private Overloads Sub OnDragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TV_NestConfig.DragDrop, TV_UserFields.DragDrop
        Dim node As TreeListNode = GetDragNode(e.Data)
        If node Is Nothing Then
            Return
        End If
        Dim list As TreeList = DirectCast(sender, TreeList)
        If list Is node.TreeList Then
            Return
        End If

        Dim info As TreeListHitInfo = list.CalcHitInfo(list.PointToClient(New Point(e.X, e.Y)))

        If info.Node IsNot Nothing Then

            Me.TV_MappedFields.BeginUnboundLoad()
            Dim parentForRootNodes As TreeListNode = Nothing

            Dim resultData As String = String.Empty
            Dim firstData As Object = node.GetValue(Me.TV_UserFields.Columns(0))
            Dim secondData As Object = info.Node.GetValue(Me.TV_NestConfig.Columns(0))
            If firstData IsNot Nothing Then
                resultData &= firstData.ToString() & " = "
            End If

            If secondData IsNot Nothing Then
                resultData &= secondData.ToString()
            End If
            Dim rootNode As TreeListNode = Me.TV_MappedFields.AppendNode(New Object() {resultData}, parentForRootNodes)
            Me.TV_MappedFields.EndUnboundLoad()
            DnDHighlightHelper1.prevNode = Nothing
            DnDHighlightHelper1.hotTrackNode_Renamed = Nothing
        End If

    End Sub

    Private Function GetDragNode(ByVal data As IDataObject) As TreeListNode
        Return DirectCast(data.GetData(GetType(TreeListNode)), TreeListNode)
    End Function

    Private Overloads Sub OnDragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TV_UserFields.DragEnter, TV_NestConfig.DragEnter
        Dim list As TreeList = DirectCast(sender, TreeList)
        Dim node As TreeListNode = GetDragNode(e.Data)
        If node IsNot Nothing AndAlso node.TreeList IsNot list Then
            e.Effect = DragDropEffects.Link

        End If
    End Sub

    Private Sub cbeSortBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeSortBy.SelectedIndexChanged
        If (cbeSortBy.Text <> "None") Then
            chkSortBy.Enabled = True
        End If
    End Sub

    Private Sub cbeThenBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeThenBy.SelectedIndexChanged
        If (cbeThenBy.Text <> "None") Then
            cbeThenBy.Enabled = True
        End If
    End Sub

    Private Sub cbeAndThenBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeAndThenBy.SelectedIndexChanged
        If (cbeAndThenBy.Text <> "None") Then
            cbeAndThenBy.Enabled = True
        End If
    End Sub

    Private Sub ExportOneTable(sMDB_Name As String, sMDB_Table As String)
        Dim connetionString As String
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim strExcelFile As String

        Dim sql As String

        strExcelFile = PathTempFolder() & PathFile(sMDB_Name) & ".xls"

        Try
            ConditionalFileDelete(strExcelFile)


            sql = "SELECT * INTO [" & sMDB_Table & "] IN '" & strExcelFile & "' 'Excel 8.0;' FROM " & sMDB_Table

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sMDB_Name & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            m_daSettings.SelectCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.SelectCommand.ExecuteNonQuery()

            m_cnSettings.Dispose()
            m_cnSettings.Close()
            m_cnSettings.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub PopulateMDB_Tables_To_Combo(sMDB_Name As String)
        Dim userTables As DataTable = Nothing

        Dim i As Integer

        Dim restrictions() As String = New String(3) {}

        Try

            restrictions(3) = "Table"

            Dim connection As New OleDbConnection

            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sMDB_Name

            'Populate a DataTable with a list of all tables in the connected database.
            connection.Open()

            userTables = connection.GetSchema("Tables", restrictions)

            connection.Close()

            For i = 0 To userTables.Rows.Count - 1

                cboSheetTable.Properties.Items.Add(userTables.Rows(i)(2).ToString())

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub rgMrpFileType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgMrpFileType.SelectedIndexChanged
        m_usage = rgMrpFileType.SelectedIndex
        RegPutString("MRP", "MRP_TYPE", m_usage)
    End Sub

    Private Sub GetSpreadSheet()
        Dim workbook As IWorkbook = SpreadsheetControl1.Document
        Dim ni As Integer

        Try

            For ni = 0 To workbook.Worksheets.Count - 1

                If (workbook.Worksheets(ni).Name <> cboSheetTable.EditValue) Then

                    workbook.Worksheets(ni).VisibilityType = WorksheetVisibilityType.VeryHidden

                End If
            Next

            workbook.Worksheets.ActiveWorksheet = workbook.Worksheets(CStr(cboSheetTable.EditValue))
            workbook.Worksheets.ActiveWorksheet.Columns.AutoFit(0, workbook.Worksheets.ActiveWorksheet.Columns.LastUsedIndex)
            SpreadsheetControl1.Document.Worksheets(CStr(cboSheetTable.EditValue)).FreezeRows(0)

            SetFrozenRowColor()
            'SpreadsheetControl1.Refresh()

            'MessageBox.Show("Debug #1")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Function GetColIndexFromText(sSearchText As String, wsActiveWorkSheet As DevExpress.Spreadsheet.Worksheet) As Integer
        Dim ni As Integer
        Dim lastCol = wsActiveWorkSheet.Columns.LastUsedIndex
        Dim m_DisplayText As String

        ' Dim range As Range = wsActiveWorkSheet.Range.FromLTRB(0, 0, lastCol, 0)

        sSearchText = UCase(sSearchText)
        GetColIndexFromText = -1

        For ni = 0 To lastCol
            m_DisplayText = UCase(wsActiveWorkSheet.Cells(0, ni).DisplayText)
            sSearchText = UCase(sSearchText)

            If m_DisplayText = sSearchText Then
                GetColIndexFromText = ni
                Exit For

            End If
        Next

    End Function

    Private Sub fcbResultsDirectory_ButtonClick1(sender As Object, e As Controls.ButtonPressedEventArgs) Handles fcbResultsDirectory.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            fcbResultsDirectory.Text = m_folderDialog.SelectedPath

        End If

    End Sub

    Private Sub fcbMM2Source_ButtonClick1(sender As Object, e As Controls.ButtonPressedEventArgs) Handles fcbMM2Source.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            fcbMM2Source.Text = m_folderDialog.SelectedPath

        End If

    End Sub

    Private Sub TV_MappedFields_MouseClick(sender As Object, e As MouseEventArgs) Handles TV_MappedFields.MouseClick

        If (e.Button = Windows.Forms.MouseButtons.Right) Then

            PopupMenu1.ShowPopup(Control.MousePosition)

        End If
    End Sub

    Private Sub cbeToolSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeToolSetup.SelectedIndexChanged

        If (cbeToolSetup.SelectedIndex > -1) Then

            Dim ntoolsetupid As Long = (TryCast(cbeToolSetup.SelectedItem, myItemData).ItemData.ToString())

            SetToolSetup(cbeToolSetup.Text, ntoolsetupid)

        End If

    End Sub

    Private Sub cbeMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMaterial.SelectedIndexChanged

        If (cbeMaterial.SelectedIndex > -1) Then

            Dim nMaterialID As Long = (TryCast(cbeMaterial.SelectedItem, myItemData).ItemData.ToString())
            SetMaterial(cbeMaterial.Text, nMaterialID)

        End If

    End Sub

    Private Sub fcbResultsDirectory_TextChanged(sender As Object, e As EventArgs) Handles fcbResultsDirectory.TextChanged
        RegPutString("MRP", "MRP_RESULT_FOLDER", fcbResultsDirectory.Text)

    End Sub

    Private Sub optPDBName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optPDBName.SelectedIndexChanged

        '        fcbImportFile.Visible = False
        teProvidedName.Visible = False
        cboFieldName.Visible = False

        Select Case optPDBName.SelectedIndex
            Case 0
                fcbImportFile.Visible = True
                fcbImportFile.Enabled = True
            Case 1
                teProvidedName.Visible = True
                teProvidedName.Enabled = True
            Case 2
                cboFieldName.Visible = True
                cboFieldName.Enabled = True
        End Select

    End Sub


    Private Sub CreateMRPTable(sMRP_DBName As String)

        'MessageBox.Show("The sMRP_DBName fle is < " & sMRP_DB & " >")
        Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & sMRP_DBName)
        Dim sTablename As String = "PDB_Files"
        Dim ds As New DataSet
        Dim dt1 As DataTable = ds.Tables("PDB_Files")
        Dim sql As String = "SELECT * FROM PDB_Files"

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
                Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename &
                                                  "] ([ID] AUTOINCREMENT , " &
                                                  "[PDB_Name] TEXT(255) )", connection)
                connection.Open()
                cmd.ExecuteNonQuery()

                connection.Close()

            End If

        Catch ex As Exception

            MessageBox.Show("CreateMRPTable: " & ex.Message)

        End Try

    End Sub

    Private Sub GetPDBNames()
        'Dim workbook As IWorkbook = SpreadsheetControl1.Document
        'Dim worksheet As Worksheet = workbook.Worksheets(0)
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
        Dim sMySecondCellText As String = Nothing
        Dim range As Range
        Dim pdb_info As NESTDBINFO
        Dim sResultPath As String

        Dim l_LayerSetupID As Long
        Dim l_LeadSetupID As Long


        Dim l_Mat_Type_ID As Long = -1
        Dim s_MatTypeDescrip As String
        Dim sConstructedPDBName As String = Nothing
        Dim nSpreadSheetRowCnt As Long
        Dim b_UseMatForToolSetup As Boolean
        Dim b_UseMatForLayerSetup As Boolean
        Dim sMappedString As String
        Dim sSearchText As String = Nothing
        Dim npos As Integer
        Dim sMappedName As String
        Dim niPart As Integer
        Dim nStartRange As Integer
        Dim nEndRange As Integer
        Dim nCounter As Integer = 1

        Try
            SaveLinkData()

            sMappedString = GetLinksFromReg(m_templateName)

            sMappedName = "Material_Name"

            sPieces = Split(sMappedString, ",")

            For ni = 0 To UBound(sPieces)

                npos = InStr(sPieces(ni), sMappedName)

                If (npos > 0) Then

                    sSearchText = Mid(sPieces(ni), 1, npos - 4)

                    Exit For

                End If

            Next

            ConditionalFileDelete(sMergePartsFilename)

            m_XLS_Name = fcbImportFile.Text
            pdb_path = PathDriveFolder(m_XLS_Name) & "\"


            'If (Dir(NormalizePath(PathDriveFolder(m_XLS_Name)) & "*.pdb") <> "") Then

            '    answer = MsgBox("Do you want to keep the existing part toolpaths and nesting results?", vbYesNo)

            'End If

            LabelDBName = NormalizePath(PathDriveFolder(m_XLS_Name)) & "labeldb.mdb"

            'Clean up labeldb file if needed
            If (FileExists(LabelDBName) = True) Then

                ConditionalFileDelete(LabelDBName)

            End If

            sReturn = PathCNC_Set(NormalizePath(PathDriveFolder(m_XLS_Name)))

            If (IS_CCS_FAB = True) Then

                m_job_name = "Job " & PathFile(m_XLS_Name)

            Else

                Select Case optPDBName.SelectedIndex

                    Case 0
                        m_job_name = PathFile(m_XLS_Name)
                        sConstructedPDBName = PathFile(PathRemoveExt(m_XLS_Name))
                    Case 1
                        m_job_name = teProvidedName.Text
                        sConstructedPDBName = teProvidedName.Text
                        'MessageBox.Show("We should use the entered jobname")

                    Case 2
                        m_job_name = cboSheetTable.Text

                        'MessageBox.Show("We should be using the field name selected Which is < " & cboFieldName.Text & " >")
                End Select

            End If

            'If (optPDBName.SelectedIndex = 0) Then

            'm_job_name = "Job " & PathFile(m_XLS_Name)

            'End If

            'sMRP_DB = NormalizePath(PathDriveFolder(m_XLS_Name)) & PathFile(m_XLS_Name) & ".mrp"
            sMRP_DB = NormalizePath(PathDriveFolder(m_XLS_Name)) & m_job_name & ".mrp"

            If (FileExists(sMRP_DB) = True) Then

                ConditionalFileDelete(sMRP_DB)

            End If

            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" &
                               "Data Source=" & sMRP_DB & ";" &
                               "Jet OLEDB:Engine Type=5")

            cat.ActiveConnection.close()

            modNesting.MRPDBNAME = sMRP_DB

            CreateMRPTable(sMRP_DB)

            sResultPath = fcbResultsDirectory.Text


            s_Machine = cbeMachine.Text
            l_MachineID = GetMachineIDFromDescrip(s_Machine)


            s_ToolSetup = cbeToolSetup.Text

            l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)
            s_LeadSetup = cbeLeadSetup.Text
            l_LeadSetupID = GetLeadSetupID(s_LeadSetup)
            s_LayerSetup = cbeLayerSetup.Text
            l_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, l_MachineID)

            ws = SpreadsheetControl1.ActiveWorksheet

            workbook = SpreadsheetControl1.Document

            cMyFirstCell = ws.Search(sSearchText).FirstOrDefault()
            cMySecondCell = ws.Search("Gauge").FirstOrDefault()
            cMyThirdCell = ws.Search("Length").FirstOrDefault()
            cMyFourthCell = ws.Search("Width").FirstOrDefault()
            cMyFifthCell = ws.Search("Thickness").FirstOrDefault()

            range = ws.GetDataRange()

            Dim nRMPartColIndex As Integer = GetColIndexFromText("RM PART", ws)
            Dim nPartNoColIndex As Integer = GetColIndexFromText("Part No", ws)
            ws.Sort(range, nRMPartColIndex)

            nSpreadSheetRowCnt = range.RowCount

            If (chkHeader.CheckState = CheckState.Checked) Then
                nStartRange = 1
                nEndRange = nSpreadSheetRowCnt - 1
            Else
                nStartRange = 0
                nEndRange = nSpreadSheetRowCnt - 1

            End If
            For niPart = nStartRange To nEndRange
                MsgBox("Adding Part number < " & nCounter & " > ")
                nCounter = nCounter + 1


#If APIHeatTransfer Then
                IS_APIHEATTRANSFER = True




                m_job_name = ws.Cells(niPart, nPartNoColIndex).DisplayText


                Dim sMatCode As String = ws.Cells(niPart, nRMPartColIndex).DisplayText

                ' worksheet.Cells(ni, nRMPartColIndex).DisplayText
                ' MessageBox.Show("the row value is " & ws.Rows(niPart).Item(0).Value.TextValue & "_|" & ws.Rows(niPart).Item(1).Value.TextValue & "|_" & ws.Rows(niPart).Item(2).Value.TextValue)
                sConstructedPDBName = m_job_name & "_" & sMatCode
                'If (ws.Rows(niPart).Item(1).Value.IsNumeric = True) Then
                '    MessageBox.Show("The qty is " & ws.Rows(niPart).Item(1).Value.NumericValue & " for part number " & nCounter)
                '    nCounter = nCounter + 1


                'End If
                'MessageBox.Show("The qty is " & ws.Rows(niPart).Item(1).Value.TextValue)
                sMyFirstCellText = ws.Rows(niPart).Item(cMyFirstCell.ColumnIndex).Value.TextValue

                'If (ceMaterialToToolSetup.CheckState = CheckState.Checked) Then
                '    b_UseMatForToolSetup = True
                'Else
                '    b_UseMatForToolSetup = False
                'End If
#End If


                If (ceMaterialToLayerSetup.CheckState = CheckState.Checked) Then

                    b_UseMatForLayerSetup = True
                Else
                    b_UseMatForLayerSetup = False

                End If

                If (cMySecondCell IsNot Nothing) Then
                    sMySecondCellText = ws.Rows(niPart).Item(cMySecondCell.ColumnIndex).Value.TextValue
                End If

                s_MatTypeDescrip = ws.Rows(niPart).Item(cMyFirstCell.ColumnIndex).Value.TextValue

                If (IS_CCS_FAB = False) Then

                    l_Mat_ID = modTranslate.GetMaterialIDFromDescription(s_MatTypeDescrip)

                    l_Mat_Type_ID = GetMaterialTypeIDFromDescription(s_MatTypeDescrip)


                    d_MatLength = modMaterial.GetMaterialLength(l_Mat_ID)

                    d_MatWidth = modMaterial.GetMaterialWidth(l_Mat_ID)

                    d_MatThickness = modMaterial.GetMaterialThickness(l_Mat_ID)

                    d_MatQty = modMaterial.GetMaterialQty(l_Mat_ID)

                    d_MatWeight = modMaterial.CheckMaterialWeight(l_Mat_ID)

                    d_MatCost = modMaterial.GetMaterialCost(l_Mat_ID)

                End If

                If (cMyThirdCell IsNot Nothing) Then
                    d_MatLength = CDbl(ws.Rows(niPart).Item(cMyThirdCell.ColumnIndex).Value.TextValue)
                End If

                If (cMyFourthCell IsNot Nothing) Then
                    d_MatWidth = CDbl(ws.Rows(niPart).Item(cMyFourthCell.ColumnIndex).Value.TextValue)
                End If


                If (cMyFourthCell IsNot Nothing) Then
                    d_MatThickness = CDbl(ws.Rows(niPart).Item(cMyFifthCell.ColumnIndex).Value.TextValue)
                End If



                'If (niPart = 10) Then
                '    If (IS_CCS_FAB = True) Then

                '        pdb_store_name = sMyFirstCellText & " " & sMySecondCellText & " GA."

                '    ElseIf (IS_APIHEATTRANSFER) Then
                '        pdb_store_name = sConstructedPDBName
                '    Else

                '        If (chkSortBy.CheckState = CheckState.Checked) Then
                '            pdb_store_name = sMyFirstCellText & "."
                '        End If

                '    End If

                '    pdb_name = pdb_store_name

                '    If (IS_CCS_FAB = True) Then
                '        pdb_Path_Filename = pdb_path & Replace(pdb_name, ".", ".pdb")
                '    Else
                '        pdb_Path_Filename = pdb_path & sConstructedPDBName & ".pdb"
                '    End If


                '    If (FileExists(pdb_Path_Filename) = True) Then

                '        ConditionalFileDelete(pdb_Path_Filename)

                '    End If

                '    'SplashScreenManager.Default.SetWaitFormDescription("Creating Nesting Database" & pdb_store_name)

                '    pdb_info = InitPdbInfo(
                '                pdb_Path_Filename, sResultPath, s_Machine, l_MachineID,
                '                s_ToolSetup, l_ToolSetupid, "", 0,
                '                s_LeadSetup, l_LeadSetupID,
                '                s_LayerSetup, l_LayerSetupID)

                '    If (EstablishPDB(pdb_info) = String.Empty) Then
                '        MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)
                '    Else
                '        l_Mat_ID = GetTheMaterialIDFromXlS(pdb_Path_Filename, s_MatTypeDescrip, d_MatLength, d_MatWidth, d_MatThickness)

                '        If (l_Mat_ID > 0) Then


                '            modMRP.AddMaterialToMaterialInventorys(pdb_Path_Filename, s_MatTypeDescrip, l_Mat_Type_ID, d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight, d_MatQty, d_MatCost)
                '        End If

                '        UpdateSetupTable(pdb_Path_Filename, vgNestDefaults, s_MatTypeDescrip, b_UseMatForToolSetup, b_UseMatForLayerSetup)

                '        'AddPdbToTable(sMRP_DB, pdb_Path_Filename)

                '    End If


                'Else

#If APIHeatTransfer Then
                pdb_name = sConstructedPDBName
#Else
                    pdb_name = sMyFirstCellText ' & " " & sMySecondCellText

#End If
                'pdb_name = sMyFirstCellText ' & " " & sMySecondCellText

                If (ceMaterialToToolSetup.CheckState = CheckState.Checked) Then

                    s_ToolSetup = sMyFirstCellText
                    l_ToolSetupid = GetToolSetupIDFromDescription(s_ToolSetup)

                End If


                If (ceMaterialToLayerSetup.CheckState = CheckState.Checked) Then

                    s_LayerSetup = sMyFirstCellText
                    l_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, l_MachineID)

                End If

                If (String.Equals(Trim(pdb_name), Trim(pdb_store_name))) Then
                    'MessageBox.Show(pdb_name & " is equal to " & pdb_store_name)
                Else
                    'MessageBox.Show(pdb_name & " is not equal to " & pdb_store_name)
                End If

                If (UCase(Trim(pdb_name)) = UCase(Trim(pdb_store_name)) = False) Then

                    If (IS_CCS_FAB = True) Then

                        pdb_Path_Filename = pdb_path & pdb_name & ".pdb"

                    Else

                        If (InStr(pdb_name, ".pdb") > 0) Then
                            pdb_Path_Filename = pdb_path & sConstructedPDBName & "_" & Replace(pdb_name, ".", ".pdb")
                        Else
                            pdb_Path_Filename = pdb_path & pdb_name & ".pdb"
                        End If
                        'MessageBox.Show("The nesting DB Is < " & pdb_Path_Filename & " >")

                    End If



                    PathPDB_Set(pdb_Path_Filename)

                    pdb_store_name = pdb_name

                    AddPdbToTable(sMRP_DB, pdb_Path_Filename)

                    If (FileExists(pdb_Path_Filename) = True) Then

                        ConditionalFileDelete(pdb_Path_Filename)

                    End If

                    'SplashScreenManager.Default.SetWaitFormDescription("Creating Nesting Database" & pdb_store_name)

                    pdb_info = InitPdbInfo(
                                pdb_Path_Filename, sResultPath, s_Machine, l_MachineID,
                                s_ToolSetup, l_ToolSetupid, "", 0,
                                s_LeadSetup, l_LeadSetupID,
                                s_LayerSetup, l_LayerSetupID)


                    If (EstablishPDB(pdb_info) = String.Empty) Then
                        MsgBox("Unable to create nesting database. " & vbCrLf & pdb_name)
                    Else

                        If (IS_CCS_FAB = False) Then

                            'l_Mat_ID = GetMaterialTypeIDFromDisplay(sMatCode)



                            'l_Mat_Type_ID = Get1stMaterialID(l_Mat_ID)


                            'd_MatLength = modMaterial.Get1stMaterialLength(l_Mat_ID)

                            'd_MatWidth = modMaterial.Get1stMaterialWidth(l_Mat_ID)

                            'd_MatThickness = modMaterial.Get1stMaterialThickness(l_Mat_ID)

                            'd_MatQty = modMaterial.Get1stMaterialQty(l_Mat_ID)

                            'd_MatWeight = modMaterial.CheckMaterialWeight(l_Mat_ID)

                            'd_MatCost = modMaterial.Get1stMaterialCost(l_Mat_ID)

                        End If

                        'l_Mat_ID = GetMaterialTypeID(s_MatTypeDescrip)

                        modMRP.AddMaterialToMaterialInventorys(pdb_Path_Filename, s_MatTypeDescrip, l_Mat_Type_ID, d_MatLength, d_MatWidth, d_MatThickness, d_MatWeight, d_MatQty, d_MatCost)

                        UpdateSetupTable(pdb_Path_Filename, vgNestDefaults, s_MatTypeDescrip, b_UseMatForToolSetup, b_UseMatForLayerSetup)
                    End If

                End If

                'End If

                If (l_Mat_ID > 0) Then

#If APIHeatTransfer Then
                    'AddAPIHeatPart(pdb_Path_Filename, niPart, SpreadsheetControl1)
#Else
                    AddNormalPart(pdb_Path_Filename, niPart, SpreadsheetControl1)
#End If
                End If


            Next

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub AddAPIHeatPart(sPdbName As String,
                           s_Mat_Type_ID As String,
                           s_MatCode As String,
                           s_MatTypeDescrip As String,
                           dLength As Double,
                           dWidth As Double,
                           dThickness As Double,
                           dWeight As Double,
                           iQuantity As Integer,
                           dCostPerUnit As Double,
                           dtDS As DataSet,
                           dtRow As Integer)

        Dim m_cnPart As OleDb.OleDbConnection = Nothing
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim cmdGetID As New OleDbCommand

        Dim sFieldNames As String = ""
        Dim sFieldValues As String = ""
        Dim Sqlstatement As String = ""
        Dim connetionString As String = ""

        Dim sFileToConvert As String = Nothing
        Dim sPartName As String = Nothing
        Dim sPartPath As String = ""
        Dim pdb_Path_Filename As String = ""
        Dim sResultPath As String = ""
        Dim sFullPartName As String = ""
        Dim sDxfFilename As String = ""
        Dim sTempPartName As String = ""
        Dim sFileExist As String = Nothing
        Dim sPieces() As String

        ' Default values for numeric fields
        Dim s_My_Part_Quantity As String = "1"
        Dim s_My_Fill_Part As String = "0"
        Dim s_My_Rotation_Num As String = "1"
        Dim s_My_MirrorPart As String = "0"
        Dim s_My_Rotation_Start As String = "0"
        Dim s_My_Part_Pass As String = "0"
        Dim s_My_Cost_Per_Part As String = "0"
        Dim s_My_Representation As String = "0"
        Dim s_My_PreNest As String = "0"

        Try
            '----- Cleaned column names -----
            Dim colRMPart As String = CleanName("RM Part")         ' RM_Part
            Dim colRMName As String = CleanName("RM Name")         ' RM_Name
            Dim colCompRev As String = CleanName("Comp rev")       ' Comp_rev
            Dim colCompName As String = CleanName("Comp Name")     ' Comp_Name
            Dim colTechTable As String = CleanName("Tech Table")   ' Tech_Table

            '--------------------------------------------------
            ' Determine paths
            '--------------------------------------------------
            If sMRP_DBSave_Folder = sSteelFolder Then
                sPartPath = sSteelMainFolder & sSteelFolder & "\" & sMRPPartsFolder & "\"
                pdb_Path_Filename = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & s_MatCode & ".pdb"
                sResultPath = sSteelMainFolder & sSteelFolder & "\" & sMRPResultsFolder & "\" & sSubFolder
            Else
                sPartPath = sAlumMainFolder & sAlumFolder & "\" & sMRPPartsFolder & "\"
                pdb_Path_Filename = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & s_MatCode & ".pdb"
                sResultPath = sAlumMainFolder & sAlumFolder & "\" & sMRPResultsFolder & "\" & sSubFolder
            End If

            '--------------------------------------------------
            ' Get Code column value (PartName, Quantity, ...)
            '--------------------------------------------------
            Dim codeValue As String = GetFieldValue(dtDS.Tables(0).Rows(dtRow), sCodeColName)
            sPieces = Split(codeValue, ",")

            If sPieces.Length > 0 Then
                sTempPartName = sPieces(0).Trim()
            End If
            If sPieces.Length > 1 AndAlso IsNumeric(sPieces(1).Trim()) Then
                s_My_Part_Quantity = sPieces(1).Trim()
            End If

            sSubFolder = m_job_name.Substring(0, 2)

            Dim currentRMName As String = GetFieldValue(dtDS.Tables(0).Rows(dtRow), colRMName)

            sFullPartName = sPartPath & sTempPartName & ".mm2"
            sDxfFilename = sPartPath & sTempPartName & ".dxf"

            If FileExists(sDxfFilename) Then
                modFileIO.ImportDXF(sDxfFilename, sFullPartName)
            End If

            '--------------------------------------------------
            ' Import the part based on extension
            '--------------------------------------------------
            Select Case UCase(PathExt(sFullPartName))
                Case "DXF"
                    sFileToConvert = sFullPartName
                    If Not FileExists(sFileToConvert) Then
                        sFileExist = "The File < " & sFileToConvert & " > Does Not exist! The part will Not be added to the nesting database!"
                        GoTo SkipPart
                    End If
                    sPartName = PathReplaceExt(sFileToConvert, "MM2")
                    modFileIO.ImportDXF(sFileToConvert, sPartName)

                Case "DWG"
                    sFileToConvert = sFullPartName
                    sPartName = PathReplaceExt(sFileToConvert, "MM2")
                    modFileIO.ImportDWG(sFileToConvert, sPartName)

                Case "MM2"
                    sFileToConvert = sFullPartName
                    If InStr(sFileToConvert, "/") > 0 Then
                        sPartName = Replace(sFileToConvert, "/", "-")
                        sPartName = PathReplaceExt(sPartName, "MM2")
                    Else
                        sPartName = PathReplaceExt(sFileToConvert, "MM2")
                    End If

                    modFileIO.ImportMM2(sPartName)

                    s_Machine = cbeMachine.Text
                    l_MachineID = GetMachineIDFromDescrip(s_Machine)
                    lReturn = PortalExecute("Model:MachineUpdate: db=" & QStr(PathCMDB()) & ",machineid=" & l_MachineID)
                    LoadMachineAttributes(l_MachineID)
                    lReturn = HeaderIntSet("WorkplaneType", modMachine.GetMachineAttributes().workplane_type)

                    s_ToolSetup = cbeToolSetup.Text
                    l_ToolSetupid = modTranslate.GetToolSetupIDFromDescription(s_ToolSetup)
                    lReturn = PortalExecute("model:toolsupdate: db=" & QStr(PathCMDB()) & ",toolsetupid=" & l_ToolSetupid)
                    GetToolsFromModel()
                    workplane_type = HeaderIntGet("WorkplaneType", 0)

                    sReturn = HeaderStringSet("MatCatName", s_MatCode)
                    sReturn = HeaderStringSet("MatCatID", s_Mat_Type_ID)
                    lReturn = HeaderStringSet("MatCfg", currentRMName)
                    lReturn = PortalExecute("file:exportmm2: file=" & QStr(sFullPartName))

                Case "PM4"
                    sFileToConvert = sFullPartName
                    sPartName = PathReplaceExt(sFileToConvert, "MM2")
                    modFileIO.ImportPM4(sFileToConvert, sPartName)

                Case "DIAMONDLIFE"
                    ' Macro based on panel type
            End Select

            '--------------------------------------------------
            ' Read mapped fields (using cleaned names)
            '--------------------------------------------------
            Dim sColName As String

            sColName = GetStandardMappedField("Quantity")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Part_Quantity = val
            End If

            sColName = GetStandardMappedField("Fill Part")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Fill_Part = val
            End If

            sColName = GetStandardMappedField("Rotations")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Rotation_Num = val
            End If

            sColName = GetStandardMappedField("Pre-Rotate")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Rotation_Start = val
            End If

            sColName = GetStandardMappedField("Priority")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Part_Pass = val
            End If

            sColName = GetStandardMappedField("Cost Per Part")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Cost_Per_Part = val
            End If

            sColName = GetStandardMappedField("Representation")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_Representation = val
            End If

            sColName = GetStandardMappedField("Mirroring")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_MirrorPart = val
            End If

            sColName = GetStandardMappedField("Pre-Nest")
            If sColName <> "USE DEFAULT" Then
                Dim val = GetFieldValue(dtDS.Tables(0).Rows(dtRow), CleanName(sColName))
                If IsNumeric(val) Then s_My_PreNest = val
            End If

            '============================================================
            ' Final safety – never allow empty numeric values
            '============================================================
            If String.IsNullOrWhiteSpace(s_My_Part_Quantity) OrElse Not IsNumeric(s_My_Part_Quantity) Then s_My_Part_Quantity = "1"
            If String.IsNullOrWhiteSpace(s_My_Fill_Part) OrElse Not IsNumeric(s_My_Fill_Part) Then s_My_Fill_Part = "0"
            If String.IsNullOrWhiteSpace(s_My_Rotation_Num) OrElse Not IsNumeric(s_My_Rotation_Num) Then s_My_Rotation_Num = "1"
            If String.IsNullOrWhiteSpace(s_My_MirrorPart) OrElse Not IsNumeric(s_My_MirrorPart) Then s_My_MirrorPart = "0"
            If String.IsNullOrWhiteSpace(s_My_Rotation_Start) OrElse Not IsNumeric(s_My_Rotation_Start) Then s_My_Rotation_Start = "0"
            If String.IsNullOrWhiteSpace(s_My_Part_Pass) OrElse Not IsNumeric(s_My_Part_Pass) Then s_My_Part_Pass = "0"
            If String.IsNullOrWhiteSpace(s_My_Cost_Per_Part) OrElse Not IsNumeric(s_My_Cost_Per_Part) Then s_My_Cost_Per_Part = "0"
            If String.IsNullOrWhiteSpace(s_My_Representation) OrElse Not IsNumeric(s_My_Representation) Then s_My_Representation = "0"
            If String.IsNullOrWhiteSpace(s_My_PreNest) OrElse Not IsNumeric(s_My_PreNest) Then s_My_PreNest = "0"

            If String.IsNullOrWhiteSpace(sPartName) Then
                sPartName = sTempPartName
            End If
            sPartName = PathReplaceExt(sPartName, "MM2")

            Dim safePartName As String = sPartName.Replace("'", "''")

            '============================================================
            ' Build INSERT statement
            '============================================================
            sFieldNames = "[Filename]," &
                      "[Part Quantity]," &
                      "[Fill Part]," &
                      "[Rotation Num]," &
                      "[MirrorPart]," &
                      "[Rotation Start]," &
                      "[Part Pass]," &
                      "[Part Priority]," &
                      "[Cost Per Part]," &
                      "[Representation]," &
                      "[Special Priority]," &
                      "[Hold ID]," &
                      "[PreNest]," &
                      "[Part_Extents]"

            sFieldValues = "'" & safePartName & "'," &
                       s_My_Part_Quantity & "," &
                       s_My_Fill_Part & "," &
                       s_My_Rotation_Num & "," &
                       s_My_MirrorPart & "," &
                       s_My_Rotation_Start & "," &
                       "1," &                          ' Part Pass
                       "0," &                          ' Part Priority
                       s_My_Cost_Per_Part & "," &
                       s_My_Representation & "," &
                       "0," &                          ' Special Priority
                       "0," &                          ' Hold ID
                       s_My_PreNest & "," &
                       "'0'"                           ' Part_Extents

            Sqlstatement = "INSERT INTO [Part] (" & sFieldNames & ") VALUES (" & sFieldValues & ")"

            '============================================================
            ' Execute INSERT
            '============================================================
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"
            m_cnPart = New OleDbConnection(connetionString)
            m_cnPart.Open()

            m_daPart.InsertCommand = New OleDbCommand(Sqlstatement, m_cnPart)
            lReturn = m_daPart.InsertCommand.ExecuteNonQuery()

            PathPDB_Set(sPdbName)

            cmdGetID.Connection = m_cnPart
            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Part]"
            nPartID = CInt(cmdGetID.ExecuteScalar())

#If APIHeatTransfer Then
            PathCurrent_Set(sPartName)
            lReturn = GetTotalPartTravel()

            addRecordToUserVarTable(nPartID, GetFieldValue(dtDS.Tables(0).Rows(dtRow), sCodeColName), sCodeColName)
            addRecordToUserVarTable(nPartID, GetFieldValue(dtDS.Tables(0).Rows(dtRow), colCompRev), "Comp Rev")
            addRecordToUserVarTable(nPartID, GetFieldValue(dtDS.Tables(0).Rows(dtRow), colCompName), "Comp Name")
            addRecordToUserVarTable(nPartID, GetFieldValue(dtDS.Tables(0).Rows(dtRow), colRMPart), "RM Part")
            addRecordToUserVarTable(nPartID, GetFieldValue(dtDS.Tables(0).Rows(dtRow), colRMName), "RM Name")
            addRecordToUserVarTable(nPartID, GetFieldValue(dtDS.Tables(0).Rows(dtRow), colTechTable), "Tech Table")
            addRecordToUserVarTable(nPartID, g_CutTravel, "Part Travel")
            addRecordToUserVarTable(nPartID, g_num_Pierces, "Part Pierces")

            modAdmin.ModelReset()
#End If

SkipPart:

        Catch ex As Exception
            MessageBox.Show("AddAPIHeatPart: " & ex.Message & Environment.NewLine & Environment.NewLine &
                        "SQL: " & Sqlstatement)
        Finally
            If m_cnPart IsNot Nothing Then
                If m_cnPart.State = ConnectionState.Open Then m_cnPart.Close()
                m_cnPart.Dispose()
            End If
        End Try
    End Sub
    ''' <summary>
    ''' Debug helper - shows all columns in the temp MDB + first row values
    ''' </summary>
    Private Sub DebugShowColumnsAndFirstRow(Optional tableName As String = Nothing)
        Try
            If String.IsNullOrWhiteSpace(sTempMDB) OrElse Not IO.File.Exists(sTempMDB) Then
                MessageBox.Show("Temp MDB not found:" & Environment.NewLine & sTempMDB)
                Return
            End If

            If String.IsNullOrWhiteSpace(tableName) Then
                tableName = cboSheetTable.Text
            End If

            Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sTempMDB & "';"

            Using conn As New OleDb.OleDbConnection(connStr)
                conn.Open()

                Dim sql As String = "SELECT * FROM [" & tableName & "]"
                Dim dt As New DataTable()

                Using da As New OleDb.OleDbDataAdapter(sql, conn)
                    da.Fill(dt)
                End Using

                If dt.Columns.Count = 0 Then
                    MessageBox.Show("No columns found in table: " & tableName)
                    Return
                End If

                Dim sb As New System.Text.StringBuilder()
                sb.AppendLine("Table : " & tableName)
                sb.AppendLine("MDB   : " & sTempMDB)
                sb.AppendLine("Rows  : " & dt.Rows.Count)
                sb.AppendLine(New String("-"c, 70))
                sb.AppendLine(String.Format("{0,-35} {1,-25} {2}", "Column Name in MDB", "CleanName()", "First Row Value"))
                sb.AppendLine(New String("-"c, 70))

                For Each col As DataColumn In dt.Columns
                    Dim colName As String = col.ColumnName
                    Dim cleaned As String = CleanName(colName)
                    Dim firstValue As String = ""

                    If dt.Rows.Count > 0 Then
                        Dim val = dt.Rows(0)(col)
                        If val IsNot DBNull.Value AndAlso val IsNot Nothing Then
                            firstValue = val.ToString()
                            If firstValue.Length > 40 Then
                                firstValue = firstValue.Substring(0, 37) & "..."
                            End If
                        Else
                            firstValue = "(null)"
                        End If
                    End If

                    sb.AppendLine(String.Format("{0,-35} {1,-25} {2}", colName, cleaned, firstValue))
                Next

                sb.AppendLine(New String("-"c, 70))
                sb.AppendLine("Total columns: " & dt.Columns.Count)

                ' Show result
                'MessageBox.Show(sb.ToString(), "Debug - Columns & First Row", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Optional: also copy to clipboard for easy pasting
                Try
                    Clipboard.SetText(sb.ToString())
                Catch
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("DebugShowColumnsAndFirstRow error:" & Environment.NewLine & ex.Message)
        End Try
    End Sub


    '    Private Sub AddAPIHeatPart(sPdbName As String, s_Mat_Type_ID As String,
    '                               s_MatCode As String,
    '                               s_MatTypeDescrip As String,
    '                               dLength As Double,
    '                               dWidth As Double,
    '                               dThickness As Double,
    '                               dWeight As Double,
    '                               iQuantity As Integer,
    '                               dCostPerUnit As Double,
    '                               dtDS As DataSet,
    '                               dtRow As Integer)
    '        Dim m_cnPart As New OleDb.OleDbConnection
    '        Dim m_daPart As New OleDb.OleDbDataAdapter
    '        Dim m_dtPart As New DataTable
    '        Dim cmdGetID As New OleDbCommand
    '        Dim sFieldNames As String
    '        Dim sFieldValues As String
    '        Dim sFileToConvert As String = Nothing
    '        Dim sPartName As String = Nothing
    '        Dim sPartPath As String
    '        Dim Sqlstatement As String
    '        Dim s_My_Part_Quantity As String
    '        Dim s_My_Fill_Part As String
    '        Dim s_My_Rotation_Num As String
    '        Dim s_My_MirrorPart As String
    '        Dim s_My_Rotation_Start As String
    '        Dim s_My_Part_Pass As String
    '        Dim s_My_Cost_Per_Part As String
    '        Dim s_My_Representation As String
    '        Dim s_My_Special_Priority As String
    '        Dim s_My_Hold_ID As String
    '        Dim s_My_PreNest As String
    '        Dim sFileExist As String = Nothing
    '        Dim connetionString As String
    '        Dim pdb_Path_Filename As String
    '        Dim sFullPartName As String
    '        Dim sMatCode As String
    '        Dim sResultPath As String
    '        Dim sColName As String
    '        Dim sTempPartName As String
    '        Dim sDxfFilename As String

    '        Try

    '            If (sMRP_DBSave_Folder = sSteelFolder) Then

    '                sPartPath = sSteelMainFolder & sSteelFolder & "\" & sMRPPartsFolder & "\"

    '                '            MessageBox.Show("The part path is < " & sPartPath & " >")

    '                pdb_Path_Filename = sSteelMainFolder & sSteelFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & s_MatCode & ".pdb"
    '                sResultPath = sSteelMainFolder & sSteelFolder & "\" & sMRPResultsFolder & "\" & sSubFolder

    '            Else
    '                sPartPath = sAlumMainFolder & sAlumFolder & "\" & sMRPPartsFolder & "\"


    '                pdb_Path_Filename = sAlumMainFolder & sAlumFolder & "\" & sMRPNestFolder & "\" & sSubFolder & "\" & m_job_name & "_" & sMatCode & ".pdb"
    '                sResultPath = sAlumMainFolder & sAlumFolder & "\" & sMRPResultsFolder & "\" & sSubFolder

    '            End If

    '            Dim unused As String = dtDS.Tables(0).Rows(dtRow).Item(sCodeColName).ToString
    '            sPieces = Split(unused, ",")

    '            sTempPartName = sPieces(0)

    '            'MessageBox.Show("The filename is < " & sTempPartName & " > ")
    '            s_My_Part_Quantity = sPieces(1)

    '            sSubFolder = m_job_name.Substring(0, 2)
    '            sMatCode = dtDS.Tables(0).Rows(dtRow).Item("RM Part").ToString


    '            sFullPartName = sPartPath & sTempPartName & ".mm2"
    '            sDxfFilename = sPartPath & sTempPartName & ".dxf"

    '            'MessageBox.Show(" The full Part name is < " & sFullPartName & " >")

    '            If (FileExists(sDxfFilename) = True) Then
    '                '.Show("WE should convert < " & sDxfFilename & " > to < " & sFullPartName & " >")

    '                modFileIO.ImportDXF(sDxfFilename, sFullPartName)
    '            End If
    '            'sPartPath = NormalizePath(fcbSourceFolder.Text)

    '            Select Case UCase(PathExt(sFullPartName))
    '                Case "DXF"
    '                    sFileToConvert = sFullPartName
    '                    'MessageBox.Show("Converting dxf")
    '                    If (FileExists(sFileToConvert) = False) Then
    '                        sFileExist = "The FIle < " & sFileToConvert & " > Does Not exist! The part will Not be added to the nesting database!"

    '                        'MessageBox.Show(sFileExist, "Part Does Not Exist!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '                        GoTo SkipPart

    '                    End If

    '                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")

    '                    sPartName = PathReplaceExt(sFileToConvert, "MM2")

    '                    modFileIO.ImportDXF(sFileToConvert, sPartName)

    '                    'UpdateMM2EditProject(sPartName,)

    '                Case "DWG"
    '                    sFileToConvert = sFullPartName

    '                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")

    '                    sPartName = PathReplaceExt(sFileToConvert, "MM2")

    '                    modFileIO.ImportDWG(sFileToConvert, sPartName)


    '                Case "MM2"
    '                    ' sFileToConvert = sPartPath & GetUserValues("Part Name", nRow)
    '                    sFileToConvert = sFullPartName

    '                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")
    '                    If (InStr(sFileToConvert, "/")) Then
    '                        sPartName = Replace(sFileToConvert, "/", "-")
    '                        sPartName = PathReplaceExt(sPartName, "MM2")
    '                    Else
    '                        sPartName = PathReplaceExt(sFileToConvert, "MM2")
    '                    End If

    '                    'MessageBox.Show("The sPartName is < " & sPartName & " >")
    '                    modFileIO.ImportMM2(sPartName)

    '                    s_Machine = cbeMachine.Text
    '                    l_MachineID = GetMachineIDFromDescrip(s_Machine)

    '                    lReturn = PortalExecute(
    '                            "Model:MachineUpdate:" &
    '                            " db=" & QStr(PathCMDB()) &
    '                            ",machineid=" & l_MachineID)

    '                    LoadMachineAttributes(l_MachineID)

    '                    lReturn = HeaderIntSet("WorkplaneType",
    '                    modMachine.GetMachineAttributes().workplane_type)

    '                    s_ToolSetup = cbeToolSetup.Text
    '                    l_ToolSetupid = modTranslate.GetToolSetupIDFromDescription(s_ToolSetup)
    '                    lReturn = PortalExecute(
    '                            "model:toolsupdate:" &
    '                            " db=" & QStr(PathCMDB()) &
    '                            ",toolsetupid=" & l_ToolSetupid)

    '                    GetToolsFromModel()

    '                    workplane_type = HeaderIntGet("WorkplaneType", 0)

    '                    s_MatTypeDescrip = dtDS.Tables(0).Rows(dtRow).Item("RM Name").ToString

    '                    'lReturn = PortalExecute(
    '                    '        "model:stockupdate:" &
    '                    '        " dx=" & dLength &
    '                    '        ",dy=" & dWidth &
    '                    '        ",dz=" & dThickness &
    '                    '        ",wp=" & workplane_type)

    '                    Dim sMatType As String = Nothing

    '                    sReturn = HeaderStringSet("MatCatName", s_MatCode)
    '                    sReturn = HeaderStringSet("MatCatID", s_Mat_Type_ID)
    '                    lReturn = HeaderStringSet("MatCfg", s_MatTypeDescrip)

    '                    lReturn = PortalExecute("file:exportmm2: file=" & QStr(sFullPartName))



    '                Case "PM4"
    '                    sFileToConvert = sFileToConvert '= sFullPartName

    '                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")

    '                    sPartName = PathReplaceExt(sFileToConvert, "MM2")

    '                    modFileIO.ImportPM4(sFileToConvert, sPartName)

    '                Case "DIAMONDLIFE"
    '                    'MessageBox.Show("We Should run the macro based on the panel type")

    '            End Select

    '            sColName = GetStandardMappedField("Quantity")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Part_Quantity = dtDS.Tables(0).Rows(dtRow).Item("Quantity").ToString
    '            Else
    '                s_My_Part_Quantity = 1
    '            End If

    '            sColName = GetStandardMappedField("Fill Part")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Fill_Part = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_Fill_Part = "0"
    '            End If

    '            sColName = GetStandardMappedField("Rotations")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Rotation_Num = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_Rotation_Num = "1"
    '            End If

    '            sColName = GetStandardMappedField("Pre-Rotate")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Rotation_Start = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_Rotation_Start = "0"
    '            End If

    '            sColName = GetStandardMappedField("Priority")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Part_Pass = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_Part_Pass = "0"
    '            End If

    '            sColName = GetStandardMappedField("Cost Per Part")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Cost_Per_Part = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_Cost_Per_Part = "0"
    '            End If

    '            sColName = GetStandardMappedField("Representation")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_Representation = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_Representation = "0"
    '            End If

    '            s_My_Special_Priority = 0
    '            s_My_Hold_ID = 0

    '            sColName = GetStandardMappedField("Mirroring")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_MirrorPart = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_MirrorPart = "0"
    '            End If

    '            sColName = GetStandardMappedField("Pre-Nest")

    '            If (sColName <> "USE DEFAULT") Then
    '                s_My_PreNest = dtDS.Tables(0).Rows(dtRow).Item(sColName).ToString
    '            Else
    '                s_My_PreNest = "0"
    '            End If



    '            sFieldNames = sEmpty
    '            sFieldValues = sEmpty

    '            sPartName = PathReplaceExt(sPartName, "MM2")

    '            sFieldNames = "[Filename]," &
    '                                "[Part Quantity]," &
    '                                "[Fill Part]," &
    '                                "[Rotation Num]," &
    '                                "[MirrorPart]," &
    '                                "[Rotation Start]," &
    '                                "[Part Pass]," &
    '                                "[Part Priority]," &
    '                                "[Cost Per Part]," &
    '                                "[Representation]," &
    '                                "[Special Priority]," &
    '                                "[Hold ID]," &
    '                                "[PreNest]," &
    '                                "[Part_Extents]"

    '            sFieldValues = "'" & sPartName & "'," &
    '                                s_My_Part_Quantity & "," &
    '                                s_My_Fill_Part & "," &
    '                                s_My_Rotation_Num & "," &
    '                                s_My_MirrorPart & "," &
    '                                s_My_Rotation_Start & "," &
    '                                1 & "," &
    '                                0 & "," &
    '                                s_My_Cost_Per_Part & "," &
    '                                s_My_Representation & "," &
    '                                "0," &
    '                                "0," &
    '                                s_My_PreNest & "," &
    '                                "'" & 0 & "'"

    '            Sqlstatement = "INSERT INTO [Part] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

    '            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

    '            m_cnPart = New OleDbConnection(connetionString)

    '            m_cnPart.Open()

    '            m_daPart.InsertCommand = New OleDbCommand(Sqlstatement, m_cnPart)

    '            lReturn = m_daPart.InsertCommand.ExecuteNonQuery()

    '            PathPDB_Set(sPdbName)

    '            cmdGetID.Connection = m_cnPart

    '            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Part]"

    '            nPartID = cmdGetID.ExecuteScalar

    '#If APIHeatTransfer Then
    '            'glb.Code|str|Code (Part_Qty_RM Desc)|<Enter Value> 
    '            'glb.CompRev|str|Comp rev|<Enter Value> 
    '            'glb.CompName|str|Comp Name|<Enter Value> 
    '            'glb.RMPart|str|RM Part|<Enter Value> 
    '            'glb.RMName|str|RM Name|<Enter Value> 
    '            'glb.TechTable|str|Tech Table|<Enter Value> 
    '            'glb.PartTravel|dbl|Part Travel|0.0
    '            'glb.PartPierces|int|Part Pierces|0
    '            'glb.PartArea|dbl|Part Area| 0.0
    '            PathCurrent_Set(sPartName)
    '            lReturn = GetTotalPartTravel()
    '            addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item(sCodeColName).ToString, sCodeColName)
    '            addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item("Comp rev").ToString, "Comp Rev")
    '            addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item("Comp Name").ToString, "Comp Name")
    '            addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item("RM Part").ToString, "RM Part")
    '            addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item("RM Name").ToString, "RM Name")
    '            addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item("Tech Table").ToString, "Tech Table")
    '            addRecordToUserVarTable(nPartID, g_CutTravel, "Part Travel")
    '            addRecordToUserVarTable(nPartID, g_num_Pierces, "Part Pierces")
    '            'addRecordToUserVarTable(nPartID, dtDS.Tables(0).Rows(dtRow).Item("Part Area").ToString, "Part Area")

    '            modAdmin.ModelReset()
    '#End If


    '            'AddPartUserVarsToNestDb()

    'SkipPart:

    '            dtDS.Dispose()
    '            dtDS = Nothing

    '        Catch ex As Exception
    '            MessageBox.Show("AddAPIHeatPart: " & ex.Message)
    '        End Try

    '    End Sub
    Private Sub AddNormalPart(sPdbName As String, nRow As Integer, sSpreadsheetControl As DevExpress.XtraSpreadsheet.SpreadsheetControl)
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim cmdGetID As New OleDbCommand
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim ws As Worksheet
        Dim workbook As IWorkbook
        Dim sFileToConvert As String = Nothing
        Dim sPartName As String = Nothing
        Dim sPartPath As String
        Dim Sqlstatement As String
        Dim s_My_Part_Quantity As String
        Dim s_My_Fill_Part As String
        Dim s_My_Rotation_Num As String
        Dim s_My_MirrorPart As String
        Dim s_My_Rotation_Start As String
        Dim s_My_Part_Pass As String
        Dim s_My_Part_Priority As String
        Dim s_My_Cost_Per_Part As String
        Dim s_My_Representation As String
        Dim s_My_Special_Priority As String
        Dim s_My_Hold_ID As String
        Dim s_My_PreNest As String
        Dim s_My_Part_Extents As String
        Dim stempfilename As System.IO.StreamWriter
        Dim sFileExist As String = Nothing
        Dim connetionString As String

        Try

            stempfilename = My.Computer.FileSystem.OpenTextFileWriter(sMergePartsFilename, True)

            ws = sSpreadsheetControl.ActiveWorksheet
            workbook = sSpreadsheetControl.Document

            sPartPath = NormalizePath(fcbSourceFolder.Text)

            Select Case UCase(lcbFileType.Text)
                Case "DXF"
                    sFileToConvert = sPartPath & ws.Rows(nRow).Item(m_col_FileName).Value.TextValue & ".dxf"

                    If (FileExists(sFileToConvert) = False) Then
                        sFileExist = "The FIle < " & sFileToConvert & " > Does Not exist! The part will Not be added to the nesting database!"

                        MessageBox.Show(sFileExist, "Part Does Not Exist!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        GoTo SkipPart

                    End If

                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")

                    sPartName = PathReplaceExt(sFileToConvert, "MM2")

                    modFileIO.ImportDXF(sFileToConvert, sPartName)


                Case "DWG"
                    sFileToConvert = sPartPath & ws.Rows(nRow).Item(m_col_FileName).Value.TextValue & ".dwg"

                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")

                    sPartName = PathReplaceExt(sFileToConvert, "MM2")

                    modFileIO.ImportDWG(sFileToConvert, sPartName)


                Case "MM2"
                    sFileToConvert = sPartPath & GetUserValues("Part Name", nRow)

                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")
                    If (InStr(sFileToConvert, "/")) Then
                        sPartName = Replace(sFileToConvert, "/", "-")
                        sPartName = PathReplaceExt(sPartName, "MM2")
                    Else
                        sPartName = PathReplaceExt(sFileToConvert, "MM2")
                    End If


                    modFileIO.ImportMM2(sPartName)


                Case "PM4"
                    sFileToConvert = sPartPath & ws.Rows(nRow).Item(m_col_FileName).Value.TextValue & ".pm4"

                    'SplashScreenManager.Default.SetWaitFormDescription("Importing < " & sFileToConvert & " >")

                    sPartName = PathReplaceExt(sFileToConvert, "MM2")

                    modFileIO.ImportPM4(sFileToConvert, sPartName)

                Case "DIAMONDLIFE"
                    MessageBox.Show("We Should run the macro based on the panel type")

            End Select


            'SplashScreenManager.Default.SetWaitFormDescription("Setting Part Values < " & sFileToConvert & " >")
            s_My_Part_Quantity = GetUserValues("Part Quantity", nRow)
            s_My_Fill_Part = GetUserValues("Fill Part", nRow)
            s_My_Rotation_Num = GetUserValues("Rotations/360", nRow)
            s_My_MirrorPart = GetUserValues("Mirroring", nRow)
            s_My_Rotation_Start = GetUserValues("Pre-Rotate", nRow)
            s_My_Part_Pass = 1
            s_My_Part_Priority = GetUserValues("Priority", nRow)
            s_My_Cost_Per_Part = GetUserValues("Cost Per Part", nRow)
            s_My_Representation = 0 '"'" & GetUserValues("Representation", nRow) & "'"
            s_My_Special_Priority = 0
            s_My_Hold_ID = 0
            s_My_PreNest = 0
            s_My_Part_Extents = 0


            sFieldNames = sEmpty
            sFieldValues = sEmpty

            sPartName = PathReplaceExt(sPartName, "MM2")

            sFieldNames = "[Filename]," &
                                "[Part Quantity]," &
                                "[Fill Part]," &
                                "[Rotation Num]," &
                                "[MirrorPart]," &
                                "[Rotation Start]," &
                                "[Part Pass]," &
                                "[Part Priority]," &
                                "[Cost Per Part]," &
                                "[Representation]," &
                                "[Special Priority]," &
                                "[Hold ID]," &
                                "[PreNest]," &
                                "[Part_Extents]"


            sFieldValues = "'" & sPartName & "'," &
                                s_My_Part_Quantity & "," &
                                "0," &
                                s_My_Rotation_Num & "," &
                                s_My_MirrorPart & "," &
                                s_My_Rotation_Start & "," &
                                s_My_Part_Pass & "," &
                                s_My_Part_Priority & "," &
                                s_My_Cost_Per_Part & "," &
                                s_My_Representation & "," &
                                "0," &
                                "0," &
                                "0," &
                                "'" & 0 & "'"


            stempfilename.WriteLine(sPdbName & "|" & sPartName & "|" & sFieldValues)
            'stempfilename.WriteLine(sPartName)
            'stempfilename.WriteLine(sFieldNames)
            'stempfilename.WriteLine(sFieldValues)
            'stempfilename.WriteLine(" ")

            Sqlstatement = "INSERT INTO [Part] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPdbName & "';"

            m_cnPart = New OleDbConnection(connetionString)

            m_cnPart.Open()

            m_daPart.InsertCommand = New OleDbCommand(Sqlstatement, m_cnPart)

            lReturn = m_daPart.InsertCommand.ExecuteNonQuery()
SkipPart:

            stempfilename.Close()


        Catch ex As Exception

            MessageBox.Show("AddBMPart: " & ex.Message)

        End Try

        m_daPart.Dispose()
        m_daPart = Nothing

        m_cnPart.Dispose()

        m_cnPart.Close()
        m_cnPart = Nothing

        'MessageBox.Show("Check PDB")

    End Sub


    Private Sub cbeLayerSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeLayerSetup.SelectedIndexChanged
        If (cbeLayerSetup.SelectedIndex > -1) Then
            Dim nLayerSetupId As Long = modTranslate.GetLayerSetupID(cbeLayerSetup.Text, RegGetString("Global", "MachineID", 0))

            SetLayerSetup(cbeLayerSetup.Text, nLayerSetupId)

        End If
    End Sub

    Private Sub cbeLeadSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeLeadSetup.SelectedIndexChanged
        If (cbeLeadSetup.SelectedIndex > -1) Then
            Dim l_leadSetupID As Long = GetLeadSetupID(cbeLeadSetup.Text)
            SetLeadSetup(cbeLeadSetup.Text, l_leadSetupID)

        End If
    End Sub

    Private Sub bbiUnlink_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiUnlink.ItemClick
        Dim nTheNode As TreeListNode

        nTheNode = TV_MappedFields.FocusedNode

        If (nTheNode IsNot Nothing) Then
            TV_MappedFields.Nodes.Remove(nTheNode)
        End If
    End Sub
    Private Function GetStandardMappedField(sMappedName As String) As String
        Dim sMappedString As String
        Dim sSearchText As String
        Dim npos As Integer
        Dim sFields() As String

        GetStandardMappedField = "USE DEFAULT"

        Try
            m_templateName = RegGetString("MRP", "MRP_TEMPLATE", "")

            sMappedString = GetLinksFromReg(m_templateName)
            sPieces = Split(sMappedString, ",")

            For ni = 0 To UBound(sPieces)

                npos = InStr(Trim(sPieces(ni)), sMappedName)

                If (npos > 0) Then

                    sSearchText = Mid(sPieces(ni), 1)
                    sFields = Split(sSearchText, "=")
                    GetStandardMappedField = Trim(sFields(0))
                    Exit Function

                End If

            Next
        Catch ex As Exception
            MessageBox.Show("GetStandardMappedField: " & ex.Message)
        End Try
    End Function



    Private Function IsMapped(sMappedName As String) As Integer
        Dim sMappedString As String
        Dim ws As Worksheet
        Dim sSearchText As String
        Dim npos As Integer

        IsMapped = -1

        Try
            ws = SpreadsheetControl1.ActiveWorksheet

            m_templateName = RegGetString("MRP", "MRP_TEMPLATE", "")

            sMappedString = GetLinksFromReg(m_templateName)
            sPieces = Split(sMappedString, ",")

            For ni = 0 To UBound(sPieces)

                npos = InStr(sPieces(ni), sMappedName)

                If (npos > 0) Then

                    sSearchText = Mid(sPieces(ni), 1, npos - 4)
                    m_Search_Col = GetColIndexFromText(sSearchText, ws)
                    IsMapped = m_Search_Col

                    Exit Function

                End If

            Next
        Catch ex As Exception
            MessageBox.Show("IsMapped: " & ex.Message)
        End Try
    End Function

    Private Function GetRowByCaption(ByVal s As String, vg_TheGrid As DevExpress.XtraVerticalGrid.VGridControl) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vg_TheGrid.Rows
            r = GetRowByCaptionChild(row, s)
            If r IsNot Nothing Then
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
        For Each cRow As BaseRow In row.ChildRows
            r = GetRowByCaptionChild(cRow, s)
            If r IsNot Nothing Then
                Return r
            End If
        Next cRow
        Return Nothing
    End Function

    Private Function GetMappedOrDefaultValues(sRowCaption As String, nRow As Integer) As String
        Dim ws As Worksheet
        Dim workbook As IWorkbook
        Dim childrow As BaseRow

        GetMappedOrDefaultValues = Nothing

        Try



            ws = SpreadsheetControl1.ActiveWorksheet
            workbook = SpreadsheetControl1.Document

            If (IsMapped(sRowCaption)) Then
                GetMappedOrDefaultValues = ws.Rows(nRow).Item(m_Search_Col).Value.ToString
            Else

                childrow = GetRowByCaption(sRowCaption, vgPartDefaults)
                GetMappedOrDefaultValues = vgPartDefaults.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value()

            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function GetUserValues(sRowCaption As String, nRow As Integer) As String
        Dim ws As Worksheet
        Dim workbook As IWorkbook
        Dim childrow As BaseRow

        ws = SpreadsheetControl1.ActiveWorksheet
        workbook = SpreadsheetControl1.Document

        If (IsMapped(sRowCaption) > -1) Then

            Return ws.Rows(nRow).Item(m_Search_Col).Value.ToString

        Else

            childrow = GetRowByCaption(sRowCaption, vgPartDefaults)
            Return vgPartDefaults.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value()


        End If



    End Function
    Private Sub SPreadSheetRowsCols()
        Dim sDataTypefilename As System.IO.StreamWriter
        Dim sTempFile As String
        Dim workbook As IWorkbook
        Dim columns As ColumnCollection

        sTempFile = Application.StartupPath & "\debug\SDataTypes.text"

        If (FileExists(sTempFile)) Then

            Kill(sTempFile)

        End If

        sDataTypefilename = My.Computer.FileSystem.OpenTextFileWriter(sTempFile, True)

        workbook = SpreadsheetControl1.Document

        ' Access a collection of columns.
        columns = workbook.Worksheets(0).Columns

        'SpreadsheetControl1.SaveDocument(sTempXLS, DocumentFormat.Xlsx)

        Dim worksheet As Worksheet = SpreadsheetControl1.ActiveWorksheet
        Dim usedRange As Range = worksheet.GetUsedRange()
        Dim topRowIndex As Integer = usedRange.TopRowIndex
        Dim headerRange As Range = worksheet.Range.FromLTRB(usedRange.LeftColumnIndex, topRowIndex, usedRange.RightColumnIndex, topRowIndex)
        Dim rowIndexWithData As Integer = headerRange.BottomRowIndex + 1
        Dim dataRange As Range = worksheet.Range.FromLTRB(usedRange.LeftColumnIndex, rowIndexWithData, usedRange.RightColumnIndex, usedRange.BottomRowIndex)

        For columnIndex As Integer = 0 To dataRange.ColumnCount - 1
            Dim definedColumnName = headerRange(columnIndex).Value
            Dim sColoumnName = definedColumnName.GetType

            If (definedColumnName.TextValue = sCodeColName) Then
                sDataTypefilename.WriteLine("[Actual Part Name] ")
            Else
                sDataTypefilename.WriteLine("[" & definedColumnName.TextValue & "] ")
            End If

        Next


        sDataTypefilename.Close()

    End Sub

    Private Sub gcMrpSettings_Resize(sender As Object, e As EventArgs) Handles gcMrpSettings.Resize
        xtcMRP.Width = gcMrpSettings.Width - 10

    End Sub
    Private Sub SaveTravelAndPierces()
        g_CutTravel = 0
        g_num_Pierces = 0

        lReturn = PortalExecute("Model:StatisticsGet: file=" & QStr(PathCurrent()))
        d_CutTravel = PortalGetDouble("travel", 0)
        i_num_Pierces = PortalGetInt("pierces", 0)
    End Sub

    Private Sub addRecordToUserVarTable(nid As Integer, my_VBValue As String, my_DialogDisplay As String)
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand


        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

            'MessageBox.Show("The variable is < " & my_DialogDisplay & " >  and the value is < " & my_VBValue & " > ")

            sql = "INSERT INTO [Part Variables] ([Part ID], [Value], [Description] ) VALUES(" & nid & ", '" & my_VBValue & "', '" & my_DialogDisplay & "')"

            m_cnPart = New OleDbConnection(connetionString)

            m_cnPart.Open()

            m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

            m_daPart.InsertCommand.ExecuteNonQuery()

            m_cnPart.Dispose()
            m_cnPart.Close()

        Catch ex As Exception

            MessageBox.Show("addRecordToUserVarTable: " & ex.Message)

        End Try
    End Sub

    Private Sub vgNestDefaults_CustomRecordCellEdit(sender As Object, e As GetCustomRowCellEditEventArgs) Handles vgNestDefaults.CustomRecordCellEdit
        Dim nTemp As Integer

        If (e.Row.Tag IsNot Nothing) Then
            nTemp = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0))

            If (nTemp = DB_FILE Or nTemp = DB_FOLDER) Then
                e.RepositoryItem = repositoryItemButtonEdit
            End If
        End If
    End Sub

    Private Sub vgNestDefaults_ShownEditor(sender As Object, e As EventArgs) Handles vgNestDefaults.ShownEditor
        Dim edit As ComboBoxEdit = TryCast(vgNestDefaults.ActiveEditor, ComboBoxEdit)
        Dim indx As Integer
        ' Dim DB_TOOLSETUP As Integer = 8
        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long
        Dim s_LayerSetup As String

        Dim sDefaultName As String
        Dim sOptions As String = sEmpty

        sDefaultName = RegGetString("Global", "LayerSetup", "None")

        Dim n_LayerSetupID As Integer = modTranslate.GetLayerSetupID(sDefaultName, m_machine_id)

        If nToolSetupRowId IsNot Nothing Then

            If vgNestDefaults.FocusedRow Is nToolSetupRowId Then

                edit.Properties.Items.Clear()

                arrToolSetup = PopulateComboList("SELECT * FROM [Tool Setups] " &
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

                    edit.Properties.Tag = EncodeTag("glb.ToolSetupID",
                                                                     "Tool Setup",
                                                                     s_ToolSetup,
                                                                     n_ToolSetupID,
                                                                     "Tool Setup ID",
                                                                     DB_TOOLSETUP,
                                                                     0,
                                                                     sOptions, 0)
                End If
            End If
        End If



        If nLayerSetupRowID IsNot Nothing Then

            If vgNestDefaults.FocusedRow Is nLayerSetupRowID Then

                edit.Properties.Items.Clear()

                edit.EditValue = ""



                arrLayerSetup = PopulateComboList("Select * From [Layer Setups] " &
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

                    n_LayerSetupID = modTranslate.GetLayerSetupID(s_LayerSetup, m_machine_id)


                    edit.EditValue = s_LayerSetup

                    edit.Properties.Tag = EncodeTag("glb.LayerSetupID",
                                                                     "Layer Setup",
                                                                     s_LayerSetup,
                                                                     n_LayerSetupID,
                                                                     "Layer Setup ID",
                                                                     DB_LAYERSETUP,
                                                                     0,
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

        If (vgNestDefaults.FocusedRow.Properties.Caption = "Machine") Then

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

            m_daSettings.Dispose()
            m_cnSettings.Dispose()

            m_cnSettings.Close()

            If m_daSettings IsNot Nothing Then m_daSettings = Nothing
            If m_cnSettings IsNot Nothing Then m_cnSettings = Nothing

            modProject.SetMachine(VbVarValue, m_machine_id)

            PopulateDefaultSettings()

            nToolSetupRowId = GetRowByCaption("Tool Setup")

            If (IsNothing(nToolSetupRowId) = False) Then
                nRowIndx = nToolSetupRowId.Index

                vgNestDefaults.Rows(nToolSetupRowId.ParentRow.Index).ChildRows(nToolSetupRowId.Index).Properties.Value = ""

                vgNestDefaults.FocusedRow = vgNestDefaults.Rows(nToolSetupRowId.ParentRow.Index).ChildRows(nToolSetupRowId.Index)
                'vgNestDefaults.FocusedRow.Properties.Value = ""
                'vgNestDefaults.ShowEditor()
            End If


        End If

        If (vgNestDefaults.FocusedRow.Properties.Caption = "Tool Setup") Then

            SelectedToolSetupName = edit.EditValue.ToString
            m_toolsetup_id = GetToolSetupIDFromDescription(SelectedToolSetupName)

            nLayerSetupRowID = GetRowByCaption("Layer Setup")

            If (IsNothing(nLayerSetupRowID) = False) Then
                nRowIndx = nLayerSetupRowID.Index

                vgNestDefaults.Rows(nLayerSetupRowID.ParentRow.Index).ChildRows(nLayerSetupRowID.Index).Properties.Value = ""

                If (m_toolsetup_id <> 0) Then

                    vgNestDefaults.FocusedRow = vgNestDefaults.Rows(nLayerSetupRowID.ParentRow.Index).ChildRows(nLayerSetupRowID.Index)
                End If

            End If

        End If


    End Sub


    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vgNestDefaults.Rows
            r = GetRowByCaptionChild(row, s)
            If Not r Is Nothing Then
                Return r
            End If
        Next row
        Return Nothing
    End Function

    Private Sub sbNext_Disposed(sender As Object, e As EventArgs) Handles sbNext.Disposed

    End Sub

    Private Sub repositoryItemButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles repositoryItemButtonEdit.ButtonClick
        Dim edit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim sFilename As String
        Dim dialog As New OpenFileDialog()
        Dim m_folderDialog As New FolderBrowserDialog()
        Dim FocusedRow As BaseRow = vgNestDefaults.FocusedRow
        Dim iname As String
        Dim m_fieldType As Integer
        Dim sFilter As String

        Try
            m_fieldType = CInt(GetValueFromDelimitedData(vgNestDefaults.FocusedRow.Tag, "VarDataType", 0))

            Select Case m_fieldType

                Case DB_FILE

                    sFilter = GetValueFromDelimitedData(vgNestDefaults.FocusedRow.Tag, "Options", sEmpty)
                    sFilter = Replace(sFilter, ";", "|")

                    dialog.Multiselect = False
                    dialog.Title = "Select " & vgNestDefaults.FocusedRow.Properties.Caption

                    dialog.Filter = sFilter

                    If dialog.ShowDialog(Me) = DialogResult.OK Then
                        edit.EditValue = TrimToFit(dialog.FileName, 35)

                        sFilename = (dialog.FileName)

                        vgNestDefaults.BeginDataUpdate()
                        vgNestDefaults.SetCellValue(FocusedRow, vgNestDefaults.FocusedRecord, sFilename)
                        vgNestDefaults.EndDataUpdate()

                        iname = GetValueFromDelimitedData(vgNestDefaults.FocusedRow.Tag, "DatVarName", "")

                        lReturn = UpdateAccumulatorDirect(vgNestDefaults, iname, sFilename)

                    End If

                Case DB_FOLDER

                    m_folderDialog.SelectedPath = NormalizePath(vgNestDefaults.FocusedRow.Properties.Value)


                    If (m_folderDialog.ShowDialog() = DialogResult.OK) Then

                        'vgSettingsProplist.BeginDataUpdate()
                        vgNestDefaults.SetCellValue(FocusedRow, vgNestDefaults.FocusedRecord, m_folderDialog.SelectedPath)

                        'vgSettingsProplist.EndDataUpdate()

                        iname = GetValueFromDelimitedData(vgNestDefaults.FocusedRow.Tag, "DatVarName", "")

                        lReturn = UpdateAccumulatorDirect(vgNestDefaults, iname, m_folderDialog.SelectedPath)


                    End If
            End Select

        Catch ex As Exception

            MessageBox.Show("rbPropSettings_ButtonClick: " & ex.Message)

        End Try

    End Sub

    Private Sub vgNestDefaults_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgNestDefaults.CellValueChanged
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
        Dim sDialogDisplay As String


        Try

            sFieldName = GetValueFromDelimitedData(e.Row.Tag, "DatVarName", sEmpty)

            nDataType = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", sEmpty))

            If (UCase(sFieldName) = "GLB.PONUM") Then

                m_PONum = e.Value

            End If

            If (UCase(sFieldName) = "GLB.CUSTOMER") Then
                m_Customer = e.Value
            End If

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

            m_daSettings.Dispose()
            m_cnSettings.Dispose()
            m_cnSettings.Close()

            Select Case nDataType

                Case DB_MACHINE

                    modProject.SetMachine(VbVarValue, CVarValue)

                    'CheckIfBuildEnabled()

                Case DB_TOOLSETUP

                    modProject.SetToolSetup(VbVarValue, CVarValue)
                    'CheckIfBuildEnabled()

                Case DB_LAYERSETUP

                    modProject.SetLayerSetup(VbVarValue, CVarValue)

                Case DB_LEADSETUP

                    modProject.SetLeadSetup(VbVarValue, CVarValue)

            End Select

            If m_daSettings IsNot Nothing Then m_daSettings = Nothing

            If m_cnSettings IsNot Nothing Then m_cnSettings = Nothing

        Catch ex As Exception

            MessageBox.Show("vgNestDefaults_CellValueChanged: " & ex.Message)

        End Try

    End Sub

    Private Function GetFieldValue(row As DataRow, columnName As String) As String
        If row.Table.Columns.Contains(columnName) Then
            Dim val = row(columnName)
            If val Is DBNull.Value OrElse val Is Nothing Then Return ""
            Return val.ToString()
        End If
        Return ""
    End Function
End Class