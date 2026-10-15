Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports System.IO


Public Class dlgAddMulti
    Private Structure tValuePair
        'Stucture for storing the file extions used in dialogs such as The file Open
        Public filter_text As String
        Public filter_value As Long
    End Structure
    Public m_mode As EXPLORER_OPTION
    Private Const ROW_HEADER = 0
    Private Const COL_QTY = 0
    Private Const COL_IO = 1   'initial orientation (degrees)
    Private Const COL_PO = 2    'possible orientations (count)
    Private Const COL_REPR = 3
    Private Const COL_PARTNAME = 4
    Private Const COL_FULLPATH = 5


    'The recipient (clients) file list.
    Private m_clients_data As clsStringArray
    Private ReadOnly m_temp_data As clsStringArray
    Private m_table(0 To 3) As tValuePair

    Private ReadOnly sPieces() As String
    Private m_part_data() As clsNestingPartData
    Private m_Nest_Var_Data() As clsNestTemplateVars

    Private m_filters As Long
    Private m_file_filters As String

    Private m_file_type As Long
    Private m_FileName As String

    Private m_caption As String

    Private m_preview As Boolean


    Private m_pre_rotate As Double
    Private m_strip_layers As Boolean
    Private m__debug_click_event As Boolean

    Private m_is_view_initialized As Boolean
    Private m_curr_file_filter As String
    Private m_initializing As Boolean
    Private _Tbl As DataTable
    Private TblMultiPartView As DataTable
    Private m_count As Long
    Private ritem As New RepositoryItemComboBox()

    Delegate Sub FocusTextHandler(ByRef XtraGrid)

    Private Sub dlgAddMulti_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        modView.ViewDestroy(VIEW_PREVIEW)
        modView.ViewActivate(VIEW_WIRE)
        modView.ViewRefresh()

        modFileIO.AllowMessages(True)

    End Sub

    Private Sub dlgAddMulti_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim last_used_file_type As Long
        Dim filters As Long

        Try
            If (m_is_view_initialized = False) Then

                modView.ViewCreate(VIEW_PREVIEW, Me.picPreview1.Handle)
                modView.ViewActivate(VIEW_PREVIEW)
                m_is_view_initialized = True

            End If



            last_used_file_type = RegGetString("Fabrication\FileOpen", "LastEXT", FILE_MM2)

            fldrVw.SelectNode(GetFolder(m_curr_file_filter), True)
            fldrVw.SelectedNode.EnsureVisible()

            filters = FILE_MM2 + FILE_DXF + FILE_DWG + FILE_PSM
            m_filters = filters
            InitFilterList()

            teDefaultQTY.Text = 1
            teDefaultRotation.Text = 4
            cboRepresentation.Properties.Items.Add("Actual Part")
            cboRepresentation.Properties.Items.Add("Bounding Box")
            cboRepresentation.Properties.Items.Add("Rubberband Box")
            cboRepresentation.SelectedIndex = 0

            'If (cePreviewPart.Checked = True) Then
            '    Me.Width = GroupControl1.Width + sccPartBrowser.SplitterPosition + 25
            'Else
            '    Me.Width = sccPartBrowser.SplitterPosition

            'End If

        Catch ex As Exception

            MessageBox.Show("dlgPartBrowser_Load: " & ex.Message)

        End Try

    End Sub

    Private Sub InitFilterList()

        Dim last_used_file_type As Long
        Dim list_index As Long
        Dim indx As Long

        Try

            'Assume failure.
            list_index = -1

            InitFilterData()

            'Get the extension last used with this dialog.  This allows
            'us to open the dialog, displaying the last accessed file
            'type and folder.  The purpose of this action is to
            'minimize folder navigation.
            '
            last_used_file_type = RegGetString("Fabrication\FileOpen", "LastEXT", FILE_MM2)

            For indx = 0 To UBound(m_table)

                If ((m_filters And m_table(indx).filter_value) > 0) Then

                    cboFileType.Properties.Items.Add(New myItemData(m_table(indx).filter_text, m_table(indx).filter_value))

                    If (m_table(indx).filter_value = last_used_file_type) Then
                        list_index = cboFileType.Properties.Items.Count - 1
                    End If

                End If

            Next

            If (list_index < 0) Then
                'Punt.
                list_index = 0
            End If

            m_file_type = cboFileType.Tag = list_index
            cboFileType.SelectedIndex = list_index

        Catch ex As Exception

            MessageBox.Show("InitFilterList: " & ex.Message)

        End Try

    End Sub
    Public Sub InitFilterData()

        ReDim m_table(0 To 13)

        m_table(0).filter_text = "Model Files (*.mm2)"
        m_table(0).filter_value = FILE_MM2

        m_table(1).filter_text = "Nested Files (*.nst)"
        m_table(1).filter_value = FILE_NST

        m_table(2).filter_text = "DXF Cad Files (*.dxf)"
        m_table(2).filter_value = FILE_DXF

        m_table(3).filter_text = "DWG Cad Files (*.dwg)"
        m_table(3).filter_value = FILE_DWG

        m_table(4).filter_text = "SmartCAM Files (*.pm4)"
        m_table(4).filter_value = FILE_PM4

        m_table(5).filter_text = "CNC Files (*.cnc)"
        m_table(5).filter_value = FILE_CNC

        m_table(6).filter_text = "PDB Files (*.pdb)"
        m_table(6).filter_value = FILE_PDB

        m_table(7).filter_text = "MDB Files (*.mdb)"
        m_table(7).filter_value = FILE_MDB

        m_table(8).filter_text = "All Files (*.*)"
        m_table(8).filter_value = FILE_ALL

        m_table(9).filter_text = "PSM Files (*.psm)"
        m_table(9).filter_value = FILE_PSM

        m_table(10).filter_text = "REM Files (*.rem)"
        m_table(10).filter_value = FILE_REM

        m_table(11).filter_text = "CTG Files (*.ctg)"
        m_table(11).filter_value = FILE_CTG

        m_table(12).filter_text = "Table Files (*.tbg)"
        m_table(12).filter_value = FILE_TABLE

        m_table(13).filter_text = "Template Files (*.template)"
        m_table(13).filter_value = FILE_TEMPLATE

    End Sub

    Private Function GetFolder(ByVal filter_type As String) As String
        Dim last_file_name As String

        GetFolder = Nothing

        Try

            m_file_type = modPath.FileTypeGet(Mid$(filter_type, 3, 3))

            ceStripLayers.Visible = False

            Select Case m_file_type
                Case FILE_MM2
                    last_file_name = PathMM2()
                Case FILE_NST
                    last_file_name = PathNST()
                Case FILE_DXF

                    last_file_name = PathDXF()
                    If (m_mode = EXPLORER_OPTION.EXPLORER_OPEN) Then
                        ceStripLayers.Visible = True
                    Else
                        'if we are saving a dxf we do not need to see the frame
                        ceStripLayers.Visible = False
                    End If

                    ceStripLayers.Checked = RegGetString("Global", "StripLayers", "0")

                Case FILE_DWG

                    last_file_name = PathDWG()
                    ceStripLayers.Visible = True

                    ceStripLayers.Checked = RegGetString("Global", "StripLayers", "0")

                Case FILE_PM4
                    last_file_name = PathPM4()
                Case FILE_PDB
                    last_file_name = PathPDB()
                Case FILE_MDB
                    last_file_name = PathCMDB()
                Case FILE_PSM

                    last_file_name = PathPSM()
                    ceStripLayers.Visible = True

                    ceStripLayers.Checked = RegGetString("Global", "StripLayers", "0")

                Case Else
                    last_file_name = App_Path & "\Models\*.*"
            End Select

            GetFolder = NormalizePath(PathDriveFolder(last_file_name))

        Catch ex As Exception

            MessageBox.Show("GetFolder: " & ex.Message)

        End Try

    End Function

    Private Sub ubgPartsView_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles ubgPartsView.CustomRowCellEdit
        Dim Choices As String

        Try
            Choices = GetValueFromDelimitedData(e.Column.Tag, "Options", Nothing)

            If (Len(Choices) > 0) Then

                ritem = New RepositoryItemComboBox

                Dim strings() As String
                strings = Choices.Split("|")

                For i As Integer = 0 To strings.Length - 1
                    ritem.Items.Add(strings(i))
                Next i


                e.RepositoryItem = ritem

            End If

        Catch ex As Exception

            MessageBox.Show("ubgPartsView_CustomRowCellEdit: " & ex.Message)

        End Try
    End Sub

    'Private Sub ubgPartsView_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs)
    '    Dim Choices As String

    '    Choices = GetValueFromDelimitedData(e.Column.Tag, "Options", Nothing)

    '    If (Len(Choices) > 0) Then

    '        ritem = New RepositoryItemComboBox()

    '        Dim strings() As String = {}
    '        strings = Choices.Split("|")

    '        For i As Integer = 0 To strings.Length - 1
    '            ritem.Items.Add(strings(i))
    '        Next i


    '        e.RepositoryItem = ritem

    '    End If
    'End Sub
    Private Sub ubgPartsView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ubgPartsView.ShowingEditor
        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)
    End Sub

    Private Sub sbRemovePart_Click(sender As Object, e As EventArgs) Handles sbRemovePart.Click
        Try

            ubgPartsView.DeleteRow(ubgPartsView.FocusedRowHandle)

        Catch ex As Exception

            MessageBox.Show("sbRemovePart_Click: " & ex.Message)

        End Try
    End Sub

    Private Sub FocusText(ByRef TheGrid)
        Try
            Dim edit As TextEdit = CType(Me.ubgPartsView.ActiveEditor, TextEdit)
            If ((edit) IsNot Nothing) Then
                edit.SelectionStart = 0
                edit.SelectionLength = edit.EditValue.ToString.Length
            End If
        Catch ex As Exception
            MessageBox.Show("FocusText: " & ex.Message)

        End Try
    End Sub

    Private Function CreateTable() As Long
        Dim m_nesting_Template As String

        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_indx As Integer
        Dim my_sOptions As String
        Dim my_RecodID As Integer
        Dim indx As Long

        Dim sOptions As String

        Dim bShowCol As Boolean

        Try
            m_nesting_Template = RegGetString("Nesting", "Template", "")

            my_DialogDisplay = "Qty"
            my_DatVarName = "Qty"
            my_VBValue = 1
            my_CValue = 1
            my_CVarName = "QTY"
            my_DataType = DB_INT
            my_RecodID = COL_QTY
            my_sOptions = Nothing
            my_indx = -1
            bShowCol = True
            indx = COL_QTY
            sOptions = Nothing


            CreateGridColumn(ubgPartsView, my_DialogDisplay, _
                             my_DatVarName, my_VBValue, _
                             my_CValue, my_CVarName, _
                             my_DataType, my_RecodID, _
                             my_sOptions, 0, bShowCol)

            my_DialogDisplay = "Initial Orientation"
            my_DatVarName = "IO"
            my_VBValue = 0
            my_CValue = 0
            my_CVarName = "IO"
            my_DataType = DB_DBL
            my_RecodID = COL_IO
            my_sOptions = Nothing
            my_indx = -1
            bShowCol = True
            indx = COL_IO
            sOptions = Nothing

            CreateGridColumn(ubgPartsView, my_DialogDisplay, _
                             my_DatVarName, my_VBValue, _
                             my_CValue, my_CVarName, _
                             my_DataType, my_RecodID, _
                             my_sOptions, 0, bShowCol)

            my_DialogDisplay = "# Rotations"
            my_DatVarName = "PO"
            my_VBValue = 4
            my_CValue = 4
            my_CVarName = "PO"
            my_DataType = DB_DBL
            my_RecodID = COL_PO
            my_sOptions = Nothing
            my_indx = -1
            bShowCol = True
            indx = COL_PO
            sOptions = Nothing

            CreateGridColumn(ubgPartsView, my_DialogDisplay, _
                             my_DatVarName, my_VBValue, _
                             my_CValue, my_CVarName, _
                             my_DataType, my_RecodID, _
                             my_sOptions, 0, bShowCol)

            my_DialogDisplay = "Representation"
            my_DatVarName = "rep"
            my_VBValue = "Actual Part"
            my_CValue = 0
            my_CVarName = "rep"
            my_DataType = DB_COMBO
            my_RecodID = COL_REPR
            my_sOptions = "Actual Part|Bounding Box|Rubberband Box"
            my_indx = -1
            bShowCol = True
            indx = COL_REPR
            sOptions = Nothing

            CreateGridColumn(ubgPartsView, my_DialogDisplay, _
                             my_DatVarName, my_VBValue, _
                             my_CValue, my_CVarName, _
                             my_DataType, my_RecodID, _
                             my_sOptions, 0, bShowCol)


            my_DialogDisplay = "Part"
            my_DatVarName = "Part"
            my_VBValue = ""
            my_CValue = ""
            my_CVarName = "Part"
            my_DataType = DB_STR
            my_RecodID = COL_PARTNAME
            my_sOptions = Nothing
            my_indx = -1
            bShowCol = True
            indx = COL_PARTNAME
            sOptions = Nothing

            CreateGridColumn(ubgPartsView, my_DialogDisplay, _
                             my_DatVarName, my_VBValue, _
                             my_CValue, my_CVarName, _
                             my_DataType, my_RecodID, _
                             my_sOptions, 0, bShowCol)

            my_DialogDisplay = "FullPath"
            my_DatVarName = "FullPath"
            my_VBValue = ""
            my_CValue = ""
            my_CVarName = "FullPAth"
            my_DataType = DB_STR
            my_RecodID = COL_FULLPATH
            my_sOptions = Nothing
            my_indx = -1
            bShowCol = False
            indx = COL_FULLPATH
            sOptions = Nothing

            CreateGridColumn(ubgPartsView, my_DialogDisplay, _
                             my_DatVarName, my_VBValue, _
                             my_CValue, my_CVarName, _
                             my_DataType, my_RecodID, _
                             my_sOptions, 0, bShowCol)



        Catch ex As Exception

            MessageBox.Show("CreateTable: " & ex.Message)

        End Try

    End Function

    Private Function GetFileFilter() As String
        'We get the file patter fron the text of the combo box
        'so we can update the file list to only show those files
        Dim Filter As String
        Dim nLen As Long
        Dim indx As Long

        GetFileFilter = Nothing

        Try

            Filter = cboFileType.Text

            nLen = Len(Filter)

            indx = InStr(1, Filter, ".")
            indx = IIf((indx <= 0), 1, indx + 1)

            GetFileFilter = "*." & Mid$(Filter, indx, (nLen - indx))

        Catch ex As Exception

            MessageBox.Show("GetFileFilter: " & ex.Message)

        End Try

    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ubgPartsView.BestFitColumns()
        CreateTable()

    End Sub

    Public Function FileCount() As Long
        FileCount = m_count
    End Function

    Public Function GetPartData() As clsNestingPartData()
        GetPartData = m_part_data
    End Function
    Public Function GetUserVarData() As clsNestTemplateVars()
        GetUserVarData = m_Nest_Var_Data
    End Function

    Public Function GetStripLayers() As Boolean
        GetStripLayers = m_strip_layers
    End Function

    Public Sub SetFileArray(clients_data As clsStringArray)
        m_clients_data = clients_data
    End Sub

    Public Sub SetFileFilters(file_filters As String)
        m_file_filters = file_filters
    End Sub


    Private Function GetTemplateRows(s_template As String) As Long
        Dim sline As String

        GetTemplateRows = 0

        Try

            Using sr As New StreamReader(s_template)

                sline = sr.ReadLine()

                While (sr.EndOfStream = False)

                    GetTemplateRows = GetTemplateRows + 1

                End While

                sr.Dispose()

            End Using

        Catch ex As Exception

            MessageBox.Show("GetTemplateRows: " & ex.Message)

        End Try

    End Function

    Private Function CreateGridColumn(ByVal gridview As GridView, _
                                        ByVal DialogDisplay As String, _
                                        ByVal DatVarName As String, _
                                        ByVal VBValue As String, _
                                        ByVal CValue As String, _
                                        ByVal CVArName As String, _
                                        ByVal DataType As Integer, _
                                        ByVal RecodID As Integer, _
                                        ByVal sOptions As String, _
                                        ByVal nDefnID As Integer, _
                                        ByVal IsVisible As Boolean) _
                                        As DevExpress.XtraGrid.Columns.GridColumn

        Dim nColtype As DevExpress.Data.UnboundColumnType

        CreateGridColumn = Nothing

        Try

            Select Case DataType

                Case DB_STR
                    nColtype = DevExpress.Data.UnboundColumnType.String

                Case DB_INT

                    nColtype = DevExpress.Data.UnboundColumnType.Integer

                Case DB_DBL

                    nColtype = DevExpress.Data.UnboundColumnType.Decimal

                Case DB_COMBO, DB_DCOMBO

                    nColtype = DevExpress.Data.UnboundColumnType.String

                Case DB_BOOL

                    nColtype = DevExpress.Data.UnboundColumnType.Boolean

            End Select

            Dim gc As DevExpress.XtraGrid.Columns.GridColumn = gridview.Columns.Add()
            Dim nColWid As Integer

            gc.Caption = DialogDisplay
            gc.VisibleIndex = RecodID

            gc.FieldName = DatVarName
            gc.Visible = IsVisible

            gc.OptionsColumn.AllowEdit = True
            gc.UnboundType = nColtype

            nColWid = gc.GetBestWidth

            gc.Tag = EncodeTag(DatVarName, DialogDisplay, VBValue, CValue, CVArName, DataType, RecodID, sOptions, nDefnID)



            ubgPartsView.BestFitColumns(True)

            CreateGridColumn = gc

        Catch ex As Exception

            MessageBox.Show("CreateGridColumn: " & ex.Message)

        End Try


    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub

    Private Sub ceStripLayers_Click(sender As Object, e As EventArgs) Handles ceStripLayers.Click
        m_strip_layers = ceStripLayers.CheckState
    End Sub

    Private Sub cboFileType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFileType.SelectedValueChanged
        Dim Filter As String

        Try

            Filter = GetFileFilter()

            fgList.FilePattern = Filter

            If (Filter <> m_curr_file_filter) Then
                m_curr_file_filter = Filter

                fldrVw.SelectNode(GetFolder(m_curr_file_filter), True)
                fldrVw.SelectedNode.EnsureVisible()

            End If

        Catch ex As Exception

            MessageBox.Show("lcbFileType_TextChange: " & ex.Message)

        End Try

    End Sub

    Private Sub sbAddSelectedFiles_Click(sender As Object, e As EventArgs) Handles sbAddSelectedFiles.Click
        Dim sPartname As String
        Dim sDatVarName As String
        Dim TheValue As Object

        Try

            For Each item In fgList.Items
                If (item.selected = True) Then

                    sPartname = fldrVw.SelectedNode.Path & "\" & item.DisplayName


                    ubgPartsView.AppendRow(New Object() {teDefaultQTY.Text, 0, teDefaultRotation.Text, cboRepresentation.Text, item.DisplayName, sPartname})

                    Dim my_rowHandle = ubgPartsView.FocusedRowHandle

                    For i = 6 To ubgPartsView.Columns.Count - 1

                        TheValue = GetValueFromDelimitedData(ubgPartsView.Columns(i).Tag, "VBValue", 0)
                        sDatVarName = GetValueFromDelimitedData(ubgPartsView.Columns(i).Tag, "DatVarName", Nothing)
                        ubgPartsView.SetRowCellValue(my_rowHandle, sDatVarName, TheValue)

                    Next

                    cmdOk.Enabled = True

                End If

            Next

            ubgPartsView.BestFitColumns(True)


        Catch ex As Exception

            MessageBox.Show("sbAddSelectedFiles_Click: " & ex.Message)

        End Try


    End Sub

    Private Sub sbAddSelectedFolder_Click(sender As Object, e As EventArgs) Handles sbAddSelectedFolder.Click
        Dim sPartname As String
        Dim sDatVarName As String
        Dim TheValue As Object


        Try
            For Each item In fgList.Items


                sPartname = fldrVw.SelectedNode.Path & "\" & item.DisplayName


                'ubgPartsView.AppendRow(New Object() {1, 0, 4, "Actual Part", item.DisplayName, sPartname})

                ubgPartsView.AppendRow(New Object() {teDefaultQTY.Text, 0, teDefaultRotation.Text, cboRepresentation.Text, item.DisplayName, sPartname})

                Dim my_rowHandle = ubgPartsView.FocusedRowHandle

                For i = 6 To ubgPartsView.Columns.Count - 1

                    TheValue = GetValueFromDelimitedData(ubgPartsView.Columns(i).Tag, "VBValue", 0)
                    sDatVarName = GetValueFromDelimitedData(ubgPartsView.Columns(i).Tag, "DatVarName", Nothing)
                    ubgPartsView.SetRowCellValue(my_rowHandle, sDatVarName, TheValue)

                Next

            Next

            cmdOk.Enabled = True

        Catch ex As Exception

            MessageBox.Show("sbAddSelectedFolder_Click: " & ex.Message)
        End Try

    End Sub
    Private Sub RegUpdate()

        Dim sFileName As String
        Dim ext As String
        Try
            If (ubgPartsView.RowCount > 0) Then

                ' sFileName = UCase$(PathExt(CStr(ubgPartsView.GetRowCellValue(1, ubgPartsView.Columns(COL_FULLPATH)).ToString())))

                sFileName = CStr(ubgPartsView.GetRowCellValue(0, ubgPartsView.Columns(COL_FULLPATH)).ToString())

                ext = UCase$(PathExt(sFileName))
                m_file_type = FileTypeGet(ext)

                RegPutString("Fabrication\FileOpen", "LastEXT", m_file_type)

                Select Case m_file_type
                    Case FILE_MM2 : PathMM2_Set(sFileName)
                    Case FILE_NST : PathNST_Set(sFileName)
                    Case FILE_DXF : PathDXF_Set(sFileName)
                    Case FILE_DWG : PathDWG_Set(sFileName)
                    Case FILE_PM4 : PathPM4_Set(sFileName)
                    Case FILE_PDB : PathPDB_Set(sFileName)
                    Case FILE_MDB : PathCMDB_Set(sFileName)
                    Case FILE_PSM : PathPSM_Set(sFileName)

                End Select
            End If

        Catch ex As Exception

            MessageBox.Show("RegUpdate: " & ex.Message)

        End Try
    End Sub
    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim cnt As Long
        Dim indx As Long
        Dim tmp As clsNestingPartData

        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_DataType As Integer
        Dim my_sOptions As String
        Dim nUserVarCount As Integer


        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            cnt = ubgPartsView.RowCount

            nUserVarCount = ubgPartsView.Columns.Count - (COL_FULLPATH + 1)

            RegUpdate()

            'ext = UCase$(PathExt(CStr(ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(COL_FULLPATH)).ToString())))
            'm_file_type = FileTypeGet(ext)

            RegPutString("Fabrication\FileOpen", "LastEXT", m_file_type)


            ReDim m_part_data(0 To cnt)

            If (nUserVarCount > 0) Then
                ReDim m_Nest_Var_Data(0 To cnt)
            End If


            For indx = 0 To (cnt - 1)

                m_part_data(indx) = New clsNestingPartData

                If (nUserVarCount > 0) Then
                    m_Nest_Var_Data(indx) = New clsNestTemplateVars
                End If

                m_part_data(indx).qty = CStr(ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(COL_QTY)).ToString())
                m_part_data(indx).io = CStr(ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(COL_IO)).ToString())
                m_part_data(indx).po = CStr(ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(COL_PO)).ToString())
                m_part_data(indx).Path = CStr(ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(COL_FULLPATH)).ToString())

                Select Case UCase(CStr(ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(COL_REPR)).ToString()))

                    Case "ACTUAL PART"
                        m_part_data(indx).repr = 0

                    Case "BOUNDING BOX"
                        m_part_data(indx).repr = 1

                    Case "RUBBERBAND BOX"
                        m_part_data(indx).repr = 2


                End Select


                For indx2 = (ubgPartsView.Columns.Count - 1) To (COL_FULLPATH + 1) Step -1

                    my_DialogDisplay = GetValueFromDelimitedData(ubgPartsView.Columns(indx2).Tag, "DialogDisplay", 0)
                    my_DatVarName = GetValueFromDelimitedData(ubgPartsView.Columns(indx2).Tag, "DatVarName", Nothing)
                    my_DataType = GetValueFromDelimitedData(ubgPartsView.Columns(indx2).Tag, "VarDataType", Nothing)
                    my_VBValue = ubgPartsView.GetRowCellValue(indx, ubgPartsView.Columns(my_DatVarName))

                    my_sOptions = GetValueFromDelimitedData(ubgPartsView.Columns(indx2).Tag, "Options", Nothing)

                    tmp = m_part_data(indx)

                    lReturn = tmp.Add_Var_Data(my_DatVarName, my_DataType, my_DialogDisplay, my_VBValue, my_sOptions)


                Next

            Next


            m_count = cnt

        Catch ex As Exception

            MessageBox.Show("CmdOK: " & ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

        Me.Close()



    End Sub

    Private Sub fgList_GotFocus(sender As Object, e As EventArgs) Handles fgList.GotFocus

    End Sub

    Private Sub fgList_ItemClick(sender As Object, e As LogicNP.FileViewControl.FileViewEventArgs) Handles fgList.ItemClick
    End Sub

    Private Sub fgList_MouseDown(sender As Object, e As MouseEventArgs) Handles fgList.MouseDown
        Dim sFileName As String
        Dim Filter As Long

        Exit Sub

        If (My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CtrlKeyDown) Then

            Exit Sub

        End If

        m__debug_click_event = (InStr(1, Command(), "~e") > 0)

        'Set the text in the filename to the file selected
        'lblFilename.Text = PathFileExt(e.Item.Path)
        'ltbAddress.Text = SelectedFile()
        sReturn = fldrVw.SelectedNode.Path & "\" & fgList.FocusedItem.Text

        Filter = CLng(cboFileType.SelectedIndex)

        If (Filter < FILE_NO_GRAPHICS) Then

            'Dim the buttons while the app is processing ...
            cmdCancel.Enabled = False
            cmdOk.Enabled = False

            Windows.Forms.Cursor.Current = Cursors.WaitCursor


            If (m__debug_click_event = True) Then

                MsgBox("Creating Temp Folder")

            End If
            PathTempFolderCreate()

            If (m__debug_click_event = True) Then

                MsgBox("Finished Temp Folder")

            End If


            If (m__debug_click_event = True) Then

                MsgBox("Setting Conversion Parameters")

            End If

            lReturn = modConversion.ConversionParametersSet( _
                0, False, False)

            If (m__debug_click_event = True) Then

                MsgBox("Finished Conversion Parameters")

            End If


            'Because we are previewing the file, the intermediate
            'file is always written to the users my documents temp folder instead of
            'appdir\temp\preview.mm2 because of vista
            sFileName = modFileIO.ImportFile( _
            sReturn, (PathTempFolder() & "preview.mm2"))

            If (m__debug_click_event = True) Then

                MsgBox("Calculate the dimensions")

            End If

            'CalculateDimensions()
            Dim sPartExtent As String = CalculateDimensionsJustXY()

            Windows.Forms.Cursor.Current = Cursors.Default

            If (m__debug_click_event = True) Then

                MsgBox("Finished Import File")

            End If


            If (m__debug_click_event = True) Then

                MsgBox("Refresh The preview")

            End If

            MaterialExtents()

            ViewRefresh()

            'sPartExtent = CalculateDimensionsJustXY()
            lblDimensions.Text = "Model extents: " & sPartExtent


            cmdCancel.Enabled = True
            cmdOk.Enabled = True

        End If



    End Sub

    Private Sub fgList_AfterSelectionChange(sender As Object, e As LogicNP.FileViewControl.FileViewEventArgs) Handles fgList.AfterSelectionChange
        Dim sFileName As String
        Dim Filter As Long

        Try
            If (My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CtrlKeyDown) Then

                Exit Sub

            End If

            m__debug_click_event = (InStr(1, Command(), "~e") > 0)

            'Set the text in the filename to the file selected
            'lblFilename.Text = PathFileExt(e.Item.Path)
            'ltbAddress.Text = SelectedFile()
            sReturn = fldrVw.SelectedNode.Path & "\" & fgList.FocusedItem.Text

            Filter = CLng(cboFileType.SelectedIndex)

            If (Filter < FILE_NO_GRAPHICS) Then

                'Dim the buttons while the app is processing ...
                cmdCancel.Enabled = False
                cmdOk.Enabled = False

                Windows.Forms.Cursor.Current = Cursors.WaitCursor


                If (m__debug_click_event = True) Then

                    MsgBox("Creating Temp Folder")

                End If
                PathTempFolderCreate()

                If (m__debug_click_event = True) Then

                    MsgBox("Finished Temp Folder")

                End If


                If (m__debug_click_event = True) Then

                    MsgBox("Setting Conversion Parameters")

                End If

                lReturn = modConversion.ConversionParametersSet(
                    0, False, False)

                If (m__debug_click_event = True) Then

                    MsgBox("Finished Conversion Parameters")

                End If


                'Because we are previewing the file, the intermediate
                'file is always written to the users my documents temp folder instead of
                'appdir\temp\preview.mm2 because of vista
                sFileName = modFileIO.ImportFile(
                sReturn, (PathTempFolder() & "preview.mm2"))

                If (m__debug_click_event = True) Then

                    MsgBox("Calculate the dimensions")

                End If

                'CalculateDimensions()
                Dim sPartExtent As String = CalculateDimensionsJustXY()

                Windows.Forms.Cursor.Current = Cursors.Default

                If (m__debug_click_event = True) Then

                    MsgBox("Finished Import File")

                End If


                If (m__debug_click_event = True) Then

                    MsgBox("Refresh The preview")

                End If

                MaterialExtents()

                ViewRefresh()

                'sPartExtent = CalculateDimensionsJustXY()
                lblDimensions.Text = "Model extents: " & sPartExtent


                cmdCancel.Enabled = True
                cmdOk.Enabled = True

            End If
        Catch ex As Exception

            MessageBox.Show("fgList_AfterSelectionChange: " & ex.Message)

        End Try


    End Sub


End Class