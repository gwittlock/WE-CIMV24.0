Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.Data.OleDb
Imports System.IO
Imports System.Data
Imports System
Imports DevExpress.XtraEditors.Controls

Public Class XtraForm3
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
    Private SYSTEM_MACHINE_NAME_NODE As TreeListNode
    Private SYSTEM_MACHINE_HOLDDOWN_CTG_NODE As TreeListNode
    Private SYSTEM_MACHINE_CLAMP_CTG_NODE As TreeListNode
    Private SYSTEM_MACHINE_TABLE_CTG_NODE As TreeListNode
    Private SYSTEM_MACHINE_CNCFOLDER_NODE As TreeListNode

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
    Private Const TAG_MACHINE_NAME_NODE = -1300
    Private Const TAG_MACHINE_HOLDDOWN_NODE = -1400
    Private Const TAG_MACHINE_CLAMP_NODE = -1500
    Private Const TAG_MACHINE_TABLE_NODE = -1600
    Private Const TAG_MACHINE_CNCFOLDER_NODE = -1700


    Private Const XLS_TYPE = 0
    Private Const MDB_TYPE = 1
    Private Const TAB_TYPE = 2
    Private Const CSV_TYPE = 3
    Private Const SEMICOLON_TYPE = 4

    Private m_usage As Long

    Private sPieces() As String
    Private m_pdb_filename As String = Nothing
    Dim sMDBFile As String
    Dim sMRP_File As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim skin As Skin = CommonSkins.GetSkin(UserLookAndFeel.Default)

        DnDHighlightHelper1.AppearanceHighlight.BackColor = skin.Colors.GetColor(CommonColors.Highlight)

        ' Add any initialization after the InitializeComponent() call.
        AddHandler UserLookAndFeel.Default.StyleChanged, AddressOf Default_StyleChanged


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
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadData()

        MsgBox("The database is finished")

        Me.Close()

    End Sub

    Private Sub XtraForm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        rgMrpFileType.SelectedIndex = 0
        'GetMachineFIelds(TV_MachineSystem)

        'LoadTheForm()

    End Sub

    Private Sub LoadTheForm()
        Dim sTablename As String = "PLasma_Params"
        Dim sMDBFilename As String = "C:\1wittlockeng\Customers\longsin\ProcessParameters\Plasma_Params.mdb"

        Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & sMDBFilename)


        'sMaterial,sClass,sThickness,Kerf,dFeedrate,sDiameter,sPierceHeight,sPierceDelay,sCutHeight
        Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename &
                                            "] ([ID] AUTOINCREMENT , " &
                                            "[sMaterial] TEXT(255), " &
                                            "[sClass] TEXT(255), " &
                                            "[sThickness] FLOAT, " &
                                            "[Kerf] FLOAT, " &
                                            "[dFeedrate] Float, " &
                                            "[sDiameter] FLOAT, " &
                                            "[sPierceHeight] TEXT(255), " &
                                            "[sPierceDelay] FLOAT, " &
                                            "[sCutHeight] FLOAT)", connection)


        connection.Open()
        cmd.ExecuteNonQuery()

        connection.Close()

        'LoadData()



    End Sub

    Private Sub MatProps_Load(sender As Object, e As EventArgs) Handles MatProps.Load

    End Sub

    Sub LoadData()
        Dim objStreamReader As StreamReader = File.OpenText("C:\1wittlockeng\Customers\longsin\ProcessParameters\Plasma_Params.csv")
        While objStreamReader.Peek() <> -1
            Dim Str1() As String = Split(objStreamReader.ReadLine(), ",")

            If Str1(5) = "*" Then Str1(5) = "-1"

            AddRecord(Str1(0), Str1(1), Round(CDbl(Val(Str1(2))), 4), Round(CDbl(Val(Str1(3))), 4), Round(CDbl(Val(Str1(4))), 4), Round(CDbl(Val(Str1(5))), 4), Str1(6), Round(CDbl(Val(Str1(7))), 4), Round(CDbl(Val(Str1(8))), 4))
        End While
        objStreamReader.Close()
    End Sub
    Sub AddRecord(ByVal sMaterial As String, ByVal sClass As String, ByVal sThickness As Double, ByVal Kerf As Double, ByVal dFeedrate As Double, ByVal sDiameter As Double, ByVal sPierceHeight As String, ByVal sPierceDelay As Double, ByVal sCutHeight As Double)
        Dim objConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1wittlockeng\Customers\longsin\ProcessParameters\Plasma_Params.mdb")
        objConnection.Open()
        Dim SQL As String = "INSERT INTO [Plasma_Params](sMaterial,sClass,sThickness,Kerf,dFeedrate,sDiameter,sPierceHeight,sPierceDelay,sCutHeight) VALUES ('" & sMaterial & "','" & sClass & "','" & sThickness & "','" & Kerf & "','" & dFeedrate & "','" & sDiameter & "','" & sPierceHeight & "','" & sPierceDelay & "','" & sCutHeight & "')"


        Dim objCommand As OleDbCommand
        objCommand = New OleDbCommand(SQL, objConnection)
        objCommand.ExecuteNonQuery()
        objConnection.Close()
    End Sub

    Private Sub beMRPFilename_EditValueChanged(sender As Object, e As EventArgs)

        Try

            Select Case m_usage
                Case XLS_TYPE
                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Xls)
                        'PopulateSheetCombo(cboSheetTable)

                    End If
                    'cboSheetTable.SelectedIndex = 0

                Case CSV_TYPE
                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Csv)
                        'PopulateSheetCombo(cboSheetTable)
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

                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Text)
                        'PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case SEMICOLON_TYPE

                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Text)
                        'PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case MDB_TYPE
                    If (beMRPFilename.Text <> "") Then

                        PopulateMDB_Tables_To_Combo(beMRPFilename.Text)

                    End If

                    cboSheetTable.SelectedIndex = 0

            End Select



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub PopulateSheetCombo(cboComboBox As DevExpress.XtraEditors.ComboBoxEdit)
        Dim sWorkSheetName As String
        Dim workbook As IWorkbook = SpreadsheetControl1.Document

        For ni = 0 To workbook.Worksheets.Count - 1

            sWorkSheetName = workbook.Worksheets(ni).Name

            cboComboBox.Properties.Items.Add(sWorkSheetName)

        Next

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

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Close()

    End Sub

    Private Sub beMRPFilename_EditValueChanged_1(sender As Object, e As EventArgs) Handles beMRPFilename.EditValueChanged


        Try

            Select Case m_usage
                Case XLS_TYPE
                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Xls)

                        PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 1

                Case CSV_TYPE
                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Csv)
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

                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Text)
                        PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case SEMICOLON_TYPE

                    If (beMRPFilename.Text <> "") Then

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Text)
                        PopulateSheetCombo(cboSheetTable)

                    End If
                    cboSheetTable.SelectedIndex = 0

                Case MDB_TYPE
                    If (beMRPFilename.Text <> "") Then

                        PopulateMDB_Tables_To_Combo(beMRPFilename.Text)

                    End If

                    cboSheetTable.SelectedIndex = 0

            End Select


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub beMRPFilename_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beMRPFilename.ButtonClick

        Dim sMRP_FileOpen As New OpenFileDialog

        cboSheetTable.Properties.Items.Clear()

        Try

            SpreadsheetControl1.CreateNewDocument()

            Select Case m_usage
                Case XLS_TYPE

                    sMRP_FileOpen.Filter = "XLS files (*.xls)|*.xls|XLSX Files (*.xlsx)|*.xlsx"
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

            End Select


            If sMRP_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sMRP_File = sMRP_FileOpen.FileName
                beMRPFilename.Text = sMRP_File

                beMRPFilename.ToolTip = sMRP_File

                Select Case m_usage

                    Case XLS_TYPE
                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Xlsx)
                        SpreadsheetControl2.LoadDocument(beMRPFilename.Text, DocumentFormat.Xlsx)
                    Case CSV_TYPE, SEMICOLON_TYPE

                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Csv)

                    Case TAB_TYPE
                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Text)
                    Case MDB_TYPE
                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Xls)

                    Case SEMICOLON_TYPE
                        SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Csv)


                End Select
                'If m_usage = CSV_TYPE Then

                '    SpreadsheetControl1.LoadDocument(beMRPFilename.Text, DocumentFormat.Csv)
                '    PopulateSheetCombo(cboSheetTable)
                '    cboSheetTable.SelectedIndex = 0
                'End If


            End If
            PopulateSheetCombo(cboSheetTable)
            cboSheetTable.SelectedIndex = 1

            SpreadsheetControl1.ActiveWorksheet.Cells.AutoFitColumns

            SpreadsheetControl1.Refresh()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub beOutputDB_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beOutputDB.ButtonClick
        Dim sMDBFilename As New OpenFileDialog


        sMDBFilename.Filter = "MDB files (*.mdb)|*.mdb"
        sMDBFilename.FilterIndex = 1
        sMDBFilename.RestoreDirectory = True


        If sMDBFilename.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            sMDBFile = sMDBFilename.FileName
            beOutputDB.Text = sMDBFile

            beOutputDB.ToolTip = sMDBFile
        End If

    End Sub

    Private Sub rgMrpFileType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgMrpFileType.SelectedIndexChanged
        m_usage = rgMrpFileType.SelectedIndex
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

            SpreadsheetControl1.Refresh()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub sbNext_Click(sender As Object, e As EventArgs) Handles sbNext.Click
        Dim sLinksFromReg As String

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            sbBack.Enabled = False
            sbNext.Enabled = True

            xtcResults.SelectedTabPageIndex = xtcResults.SelectedTabPageIndex + 1

            Select Case xtcResults.SelectedTabPageIndex
                Case 0
                Case 1
                    Select Case m_usage
                        Case XLS_TYPE
                            RegPutString("MRP", "MRP_TEMPLATE", "XLS")

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

                    If (ceMachines.CheckState = CheckState.Unchecked) Then

                        Select_Mach_Tool_Mat.Init(CREATE_TABLE_MODE.MACHINE_MODE)

                        Select_Mach_Tool_Mat.ShowDialog(Me)
                        Select_Mach_Tool_Mat.Refresh()

                    End If
                    sbBack.Enabled = True

                Case 2
                    'GetSpreadSheetFields(TV_UserFields)
                    'GetSystemfields()

                    'Dim sUserFieldName As String

                    'sUserFieldName = RegGetString("MRP", "USER_FIELD", "")

                    'If (sUserFieldName <> "") Then
                    '    For ni = 0 To cboFieldName.Properties.Items.Count - 1
                    '        If (sUserFieldName = cboFieldName.Properties.Items.Item(ni).ToString) Then
                    '            cboFieldName.SelectedIndex = ni
                    '        End If
                    '    Next
                    'End If


                    'TV_MappedFields.Nodes.Clear()

                    'sLinksFromReg = GetLinksFromReg(m_templateName)
                    'sPieces = Split(sLinksFromReg, ",")

                    'Me.TV_MappedFields.BeginUnboundLoad()
                    'Dim parentForRootNodes As TreeListNode = Nothing
                    'Dim resultData As String = String.Empty

                    'For ni = 0 To UBound(sPieces)
                    '    resultData = sPieces(ni)
                    '    Dim rootNode As TreeListNode = Me.TV_MappedFields.AppendNode(New Object() {resultData}, parentForRootNodes)


                    'Next

                    'Me.TV_MappedFields.EndUnboundLoad()

                    If (ceMachines.CheckState = CheckState.Unchecked) Then


                    End If

                    sbBack.Enabled = True

                Case 3
                    sbBack.Enabled = True


                Case 4
                    sbBack.Enabled = True

                    'FillPartDefaultGrid()

                Case 5

                    sbBack.Enabled = True

                    'PopulateDefaultSettings()

                    sbFinish.Enabled = True
                    sbNext.Enabled = False
            End Select


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
    Private Sub GetMachineFIelds(tvlist As DevExpress.XtraTreeList.TreeList)


        tvlist.ClearNodes()

        SYSTEM_ROOT_NODE = tvlist.AppendNode(New Object() {"Machine Parameters"}, SYSTEM_ROOT_NODE, 0)
        SYSTEM_ROOT_NODE.Tag = 0
        SYSTEM_MACHINE_NAME_NODE = tvlist.AppendNode(New Object() {"Machine_Name"}, SYSTEM_ROOT_NODE, TAG_MACHINE_NAME_NODE)
        SYSTEM_MACHINE_HOLDDOWN_CTG_NODE = tvlist.AppendNode(New Object() {"Hold Down CTG"}, SYSTEM_ROOT_NODE, TAG_MACHINE_HOLDDOWN_NODE)
        SYSTEM_MACHINE_CLAMP_CTG_NODE = tvlist.AppendNode(New Object() {"Clamp CTG"}, SYSTEM_ROOT_NODE, TAG_MACHINE_CLAMP_NODE)
        SYSTEM_MACHINE_TABLE_CTG_NODE = tvlist.AppendNode(New Object() {"Table CTG"}, SYSTEM_ROOT_NODE, TAG_MACHINE_TABLE_NODE)
        SYSTEM_MACHINE_CNCFOLDER_NODE = tvlist.AppendNode(New Object() {"CNC Folder"}, SYSTEM_ROOT_NODE, TAG_MACHINE_CNCFOLDER_NODE)

    End Sub

    Private Sub GetSpreadSheetFields(tvList As DevExpress.XtraTreeList.TreeList)
        Dim workbook As IWorkbook = SpreadsheetControl1.Document
        Dim my_WorkSheet As Worksheet = workbook.Worksheets(cboSheetTable.Text)
        Dim ni As Integer
        Dim sUserFieldName As String
        Dim sIndextext As String = sEmpty

        USER_FIELDS_NODE = Nothing

        For ni = 0 To my_WorkSheet.GetUsedRange().ColumnCount - 1

            sUserFieldName = my_WorkSheet.Cells(ni).DisplayText
            If (sUserFieldName <> "") Then


                USER_FIELDS_ROOT_NODE = tvList.AppendNode(New Object() {sUserFieldName}, USER_FIELDS_NODE, 0)

            End If


        Next

    End Sub

    Private Sub cboSheetTable_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' GetSpreadSheetFields(TV_UserFields)


    End Sub
    Private Function GetDragNode(ByVal data As IDataObject) As TreeListNode
        Return DirectCast(data.GetData(GetType(TreeListNode)), TreeListNode)
    End Function
    Private Overloads Sub OnDragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        Dim list As TreeList = DirectCast(sender, TreeList)
        Dim node As TreeListNode = GetDragNode(e.Data)
        If node IsNot Nothing AndAlso node.TreeList IsNot list Then
            e.Effect = DragDropEffects.Link

        End If
    End Sub
    Private Sub XtraForm3_AutoValidateChanged(sender As Object, e As EventArgs) Handles Me.AutoValidateChanged

    End Sub
    Private Overloads Sub OnDragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
        'Dim node As TreeListNode = GetDragNode(e.Data)
        'If node Is Nothing Then
        '    Return
        'End If
        'Dim list As TreeList = DirectCast(sender, TreeList)
        'If list Is node.TreeList Then
        '    Return
        'End If

        'Dim info As TreeListHitInfo = list.CalcHitInfo(list.PointToClient(New Point(e.X, e.Y)))

        'If info.Node IsNot Nothing Then

        '    Me.TV_MappedFields.BeginUnboundLoad()
        '    Dim parentForRootNodes As TreeListNode = Nothing

        '    Dim resultData As String = String.Empty
        '    Dim firstData As Object = node.GetValue(Me.TV_UserFields.Columns(0))
        '    Dim secondData As Object = info.Node.GetValue(Me.TV_MachineSystem.Columns(0))
        '    If firstData IsNot Nothing Then
        '        resultData &= firstData.ToString() & " = "
        '    End If

        '    If secondData IsNot Nothing Then
        '        resultData &= secondData.ToString()
        '    End If
        '    Dim rootNode As TreeListNode = Me.TV_MappedFields.AppendNode(New Object() {resultData}, parentForRootNodes)
        '    Me.TV_MappedFields.EndUnboundLoad()
        '    DnDHighlightHelper1.prevNode = Nothing
        '    DnDHighlightHelper1.hotTrackNode_Renamed = Nothing
        'End If

    End Sub

    ' Private Overloads Sub TV_UserFields_DragDrop(sender As Object, e As DragEventArgs) Handles TV_UserFields.DragDrop
    'Dim node As TreeListNode = GetDragNode(e.Data)
    'If node Is Nothing Then
    '    Return
    'End If
    'Dim list As TreeList = DirectCast(sender, TreeList)
    'If list Is node.TreeList Then
    '    Return
    'End If

    'Dim info As TreeListHitInfo = list.CalcHitInfo(list.PointToClient(New Point(e.X, e.Y)))

    'If info.Node IsNot Nothing Then

    '    Me.TV_MappedFields.BeginUnboundLoad()
    '    Dim parentForRootNodes As TreeListNode = Nothing

    '    Dim resultData As String = String.Empty
    '    Dim firstData As Object = node.GetValue(Me.TV_UserFields.Columns(0))
    '    Dim secondData As Object = info.Node.GetValue(Me.TV_MachineSystem.Columns(0))
    '    If firstData IsNot Nothing Then
    '        resultData &= firstData.ToString() & " = "
    '    End If

    '    If secondData IsNot Nothing Then
    '        resultData &= secondData.ToString()
    '    End If
    '    Dim rootNode As TreeListNode = Me.TV_MappedFields.AppendNode(New Object() {resultData}, parentForRootNodes)
    '    Me.TV_MappedFields.EndUnboundLoad()
    '    DnDHighlightHelper1.prevNode = Nothing
    '    DnDHighlightHelper1.hotTrackNode_Renamed = Nothing
    'End If


    'End Sub

    Private Sub sbBack_Click(sender As Object, e As EventArgs) Handles sbBack.Click

        sbNext.Enabled = True
        sbFinish.Enabled = False

        If (xtcResults.SelectedTabPageIndex > 0) Then

            xtcResults.SelectedTabPageIndex = xtcResults.SelectedTabPageIndex - 1
            If (xtcResults.SelectedTabPageIndex = 0) Then
                sbBack.Enabled = False
            Else
                sbBack.Enabled = True
            End If
        End If
        If (xtcResults.SelectedTabPageIndex > 1) Then

        End If


    End Sub

    Private Sub beOutputDB_EditValueChanged(sender As Object, e As EventArgs) Handles beOutputDB.EditValueChanged

    End Sub

    Private Sub beOutputDB_ControlRemoved(sender As Object, e As ControlEventArgs) Handles beOutputDB.ControlRemoved

    End Sub
End Class