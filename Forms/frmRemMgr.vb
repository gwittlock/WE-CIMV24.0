Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class frmRemMgr
    <DllImport("user32.dll")>
    Public Shared Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
    End Function
    Private bInitialized As Boolean
    Private lReturn As Long
    Private lViewerID As Long
    Private lPlaneID As Long
    Private MouseViewX As Double
    Private MouseViewY As Double
    Private MousePickX As Double
    Private MousePickY As Double
    Private CurrentFunction As String
    Private ctlParentCancel As Control
    'Default Property Values:
    Const m_def_DisplayUtilities = True
    Const m_def_ModelFilename = ""
    Const m_def_ShowPartExtents = True
    Const m_def_ShowProfileMarkers = False
    Const m_def_ShowStock = True
    Const m_def_ShowTextCommands = False
    Const m_def_ShowToolpathDashed = False
    Const m_def_ViewMonochrome = False
    'Property Variables:
    Dim m_DisplayUtilities As Boolean
    Dim m_ModelFilename As String
    Dim m_ShowPartExtents As Boolean
    Dim m_ShowProfileMarkers As Boolean
    Dim m_ShowStock As Boolean
    Dim m_ShowTextCommands As Boolean
    Dim m_ShowToolpathDashed As Boolean
    Dim m_ViewMonochrome As Boolean
    Dim ModelFilename As String

    'For use with cmdLoadModels.
    Private m_file_paths As clsStringArray

    Private m_machine_id As Long
    Private m_model_file As String
    Private m_rem_length As Double
    Private m_rem_width As Double
    Private m_rem_area As Double
    Private m_rem_thickness As Double
    Private m_rem_date As String
    Private m_materialName As String
    Private m_is_view_initialized As Boolean
    Dim gridDataList As New BindingList(Of clsRemnantVar)

    Public Sub SetMachine(machine_id As Long)
        m_machine_id = machine_id
    End Sub

    Private Sub sbRemnantSettings_Click(sender As Object, e As EventArgs) Handles sbRemnantSettings.Click
        dlgRemnantControl.ShowDialog(Me)
    End Sub

    Private Sub sbClose_Click(sender As Object, e As EventArgs) Handles sbClose.Click

        Me.Close()

    End Sub

    Private Sub frmRemMgr_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        lReturn = vbModelSwap(0)

        If bInitialized Then
            lReturn = PortalExecute("!view:delete:id=" & lViewerID)
            bInitialized = False
        End If


        m_machine_id = 0
        modView.ViewActivate(VIEW_WIRE)
    End Sub

    Private Sub frmRemMgr_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub

    Private Sub frmRemMgr_Load(sender As Object, e As EventArgs) Handles Me.Load

        InitRemnants()
        InitViewer()


    End Sub
    Private Sub InitRemnants()
        Dim sql As String
        Dim ds As New DataSet
        Dim sFieldName As String
        Dim i As Integer
        Dim indx As Integer
        Dim bShowCol As Boolean
        Dim sColCaption As String
        Dim tColType As DevExpress.Data.UnboundColumnType
        Dim dtInitRemnants As DataTable = Nothing
        Dim material_name As String = Nothing

        Try

            If (lbcMM2Files.Items.Count > 0) Then
                lbcMM2Files.Items.Clear()


            End If

            vsfRemData.Rows.Clear()

            sFieldName = ""
            ubgRemnantsView.Columns.Clear()

            ubgRemnants.DataSource.Clear()


            sql = "Select RemnantVar.* From RemnantVar Where (RemnantVar.RemnantID = 0 )"



            dtInitRemnants = ConnectToCMDB(sql)

            For i = 0 To dtInitRemnants.Rows.Count - 1


                sFieldName = UCase(dtInitRemnants.Rows(i).Item("InternalName"))
                sColCaption = sFieldName

                Select Case UCase(sFieldName)

                    Case "NAME"

                        indx = 0
                        bShowCol = False
                        sColCaption = "RemnantID"
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                        CreateGridColumn(ubgRemnantsView, sColCaption, "REMNANTID", indx, bShowCol, tColType)

                        indx = 1
                        bShowCol = True
                        sColCaption = "Name"
                        tColType = DevExpress.Data.UnboundColumnType.String

                    Case "COUNT"
                        indx = 2
                        bShowCol = True
                        sColCaption = "Count"
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                    Case "MATERIAL"
                        indx = 3
                        bShowCol = True
                        sColCaption = "Material"
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                    Case "LENGTH"
                        indx = 4
                        bShowCol = True
                        sColCaption = "Length"
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "WIDTH"
                        indx = 5
                        bShowCol = True
                        sColCaption = "Width"
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "THICKNESS"
                        indx = 6
                        bShowCol = True
                        sColCaption = "Thickness"
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "AREA"
                        indx = 7
                        bShowCol = True
                        sColCaption = "Area"
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "CREATION_DATE"
                        indx = 8
                        sColCaption = "Creation Date"
                        bShowCol = True
                        tColType = DevExpress.Data.UnboundColumnType.String

                End Select

                CreateGridColumn(ubgRemnantsView, sColCaption, sFieldName, indx, bShowCol, tColType)


            Next

            CreateRemnantRows()

            ubgRemnantsView.BestFitColumns()

            'AddStationRows(m_machineID)

            dtInitRemnants.Dispose()




        Catch ex As Exception

            MessageBox.Show("InitRemnants: " & ex.Message)

        End Try

    End Sub

    Private Function CreateGridColumn(ByVal gridview As GridView, _
                                              ByVal caption As String, _
                                              ByVal field As String, _
                                              ByVal visibleindex As Integer, _
                                              ByVal IsVisible As Boolean, _
                                              ByVal colType As DevExpress.Data.UnboundColumnType) As DevExpress.XtraGrid.Columns.GridColumn

        Dim gc As DevExpress.XtraGrid.Columns.GridColumn = gridview.Columns.Add()

        gc.Caption = caption
        gc.VisibleIndex = visibleindex

        gc.FieldName = field
        gc.Visible = IsVisible

        gc.OptionsColumn.AllowEdit = True
        gc.UnboundType = colType

        Return gc

    End Function

    Private Sub CreateRemnantRows()
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
        Dim rem_qty As Long
        Dim rem_area As Double
        Dim Rem_Date As String = Nothing
        Dim rem_material As String
        Dim material_name As String = Nothing
        Dim materialID As Long
        Dim rem_Name_Holder As String = Nothing

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

                        Case "COUNT"
                            rem_qty = dtRemnantInv.Rows(ni).Item("Value")

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

                my_VBValue = Rem_Name
                my_DatVarName = "Remnant"

                ubgRemnantsView.AppendRow(New Object() {Rem_ID, Rem_Name, rem_qty, material_name, rem_length, _
                                                         rem_width, rem_thickness, rem_area, Rem_Date})

            Next

        Catch ex As Exception

            MessageBox.Show("CreateRemnantRows: " & ex.Message)

        End Try


    End Sub
    Private Sub junk()
        Dim sql As String
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim dtRemnants As DataTable = Nothing
        Dim dtRemnantInv As DataTable = Nothing
        Dim nRemIDHolder As Long
        Dim nRemID As Long
        Dim Rem_Name As String = Nothing
        Dim rem_length As Double
        Dim rem_width As Double
        Dim rem_thickness As Double
        Dim rem_area As Double
        Dim Rem_Date As String
        Dim rem_material As String
        Dim rem_count As String
        Dim material_name As String = Nothing
        Dim materialID As Long

        Try

            nRemIDHolder = -1

            gridDataList.Clear()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            sql = "SELECT * FROM Remnant WHERE (Remnant.MachineID > 0 )"

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dtRemnants)

            oledbAdapter.Dispose()

            For i = 0 To dtRemnants.Rows.Count - 1

                sql = "Select RemnantVar.* From RemnantVar Where (RemnantVar.RemnantID > 0 )"

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(dtRemnantInv)

                oledbAdapter.Dispose()

                For ni = 0 To dtRemnantInv.Rows.Count - 1
                    nRemID = dtRemnantInv.Rows(ni).Item("RemnantID")

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

                        Case "COUNT"
                            rem_count = dtRemnantInv.Rows(ni).Item("Value")

                        Case "CREATION_DATE"
                            Rem_Date = dtRemnantInv.Rows(ni).Item("Value")

                        Case "MATERIAL"
                            rem_material = dtRemnantInv.Rows(ni).Item("Value")
                            materialID = GetMaterialTypeIDFromDescription(rem_material)
                            material_name = GetMaterialTypeName(materialID)

                    End Select

                Next

                If (nRemIDHolder <> nRemID) Then

                End If
                dtRemnantInv.Dispose()

                oledbAdapter.Dispose()

            Next


            connection.Dispose()

            connection.Close()

            If dtRemnantInv IsNot Nothing Then dtRemnantInv = Nothing

            If dtRemnants IsNot Nothing Then dtRemnants = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("frmRemMgr_Load " & ex.Message)

        End Try


    End Sub

    Private Sub sbRemove_Click(sender As Object, e As EventArgs) Handles sbRemove.Click
        Dim connetionString As String
        Dim sql As String
        Dim m_cnMaterial As New OleDb.OleDbConnection
        Dim cmd As OleDbCommand
        Dim remnant_name As String
        Dim remnant_id As Long

        Try
            remnant_name = NormalizePath(PathRemnants()) & ubgRemnantsView.GetFocusedRowCellValue("NAME") & ".rem"

            remnant_id = FindRemnant(ubgRemnantsView.GetFocusedRowCellValue("NAME"))

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            m_cnMaterial = New OleDbConnection(connetionString)

            m_cnMaterial.Open()

            sql = "DELETE * FROM RemnantVar WHERE (RemnantID=" & remnant_id & ")"

            cmd = New OleDbCommand(sql, m_cnMaterial)

            cmd.ExecuteNonQuery()

            sql = "DELETE * FROM Remnant WHERE (ID=" & remnant_id & ")"

            cmd = New OleDbCommand(sql, m_cnMaterial)

            cmd.ExecuteNonQuery()

            m_cnMaterial.Close()

            If m_cnMaterial IsNot Nothing Then m_cnMaterial = Nothing

            InitRemnants()



        Catch ex As Exception

            MessageBox.Show("sbRemove_Click " & ex.Message)

        End Try
    End Sub
    Private Function FindRemnant(remnant_name As String) As Long

        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter

        FindRemnant = -1 'assume failure

        Try
            sql = "Select [RemnantVar].* From [RemnantVar] Where ([RemnantVar].[InternalName] = 'Name' ) And ([RemnantVar].[Value] = '" & remnant_name & "' )"

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then

                FindRemnant = ds.Tables(0).Rows(0).Item("RemnantID")
            Else
                FindRemnant = -1
            End If

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("FindRemnant: " & ex.Message)
        End Try

    End Function

    Private Sub PreviewRefresh()

        lReturn = PortalExecute("!view:materialextents: regen=0")

    End Sub

    Private Sub ubgRemnantsView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ubgRemnantsView.FocusedRowChanged
        Dim sRemName As String

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        sRemName = NormalizePath(PathRemnants()) & ubgRemnantsView.GetFocusedRowCellValue("NAME") & ".rem"

        LoadModel(sRemName)

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub sbLoadPdb_Click(sender As Object, e As EventArgs) Handles sbLoadPdb.Click
        Dim dialog As New OpenFileDialog()
        Dim sql As String
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim sPDBFile As String
        Dim indx As Integer
        Dim bShowCol As Boolean
        Dim sColCaption As String
        Dim tColType As DevExpress.Data.UnboundColumnType

        Try
            lbcMM2Files.Items.Clear()

            dialog.Multiselect = False
            dialog.DefaultExt = "PDB"
            dialog.Title = "Select PDB file"
            dialog.Filter = "PDB files (*.pdb)|*.pdb"

            dialog.InitialDirectory = PathDriveFolder(PathPDB())

            If dialog.ShowDialog(Me) = DialogResult.OK Then

                indx = 0
                bShowCol = True
                sColCaption = "Model"
                tColType = DevExpress.Data.UnboundColumnType.String

                sPDBFile = dialog.FileName

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sPDBFile & "';"

                sql = "SELECT * FROM [Sheet Result]"

                connection = New OleDbConnection(connetionString)
                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(ds)

                oledbAdapter.Dispose()

                connection.Close()

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    lbcMM2Files.Items.Add(ds.Tables(0).Rows(i).Item("Sheet Filename"))

                Next

                If ds IsNot Nothing Then ds = Nothing

                If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                If connection IsNot Nothing Then connection = Nothing

            End If


        Catch ex As Exception

            MessageBox.Show("sbLoadPdb_Click: " & ex.Message)

        End Try
    End Sub

    Private Function InitViewer() As Long

        Dim cmd As String
        Dim white_background As Long
        Dim lHwnd As Long

        lHwnd = picPreview.Handle

        'CRITICAL: Swap to the preview model so that the new
        'view tracks the correct model on the C++ side of things.
        lReturn = vbModelSwap(1)
        lReturn = PortalExecute("!view:new:type=1,wnd=" & lHwnd)

        If (lReturn <> 0) Then
            lViewerID = PortalGetInt("id", 0)
            lReturn = PortalExecute("!view:select:id=" & lViewerID)

            'NOTE: Tom-foolery
            'So the picture box "appears" to have the proper background color.
            'The actual color is handled by ogl when an image is drawn.
            white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)
            If (white_background <> 0) Then
                picPreview.BackColor = System.Drawing.Color.White
            Else
                picPreview.BackColor = System.Drawing.Color.Black
            End If

            cmd = "!view:mode:" & _
                  " id=" & lViewerID & _
                  ",white_bg=" & white_background

            lReturn = PortalExecute(cmd)

            bInitialized = True

            cmd = "!view:mode:" & _
                  " id=" & lViewerID & _
                  ",profmark=0" & _
                ",tooldash=0" & _
                ",text=0" & _
                ",mono=" & CLng(m_ViewMonochrome)

            lReturn = PortalExecute(cmd)

            ClearViewer()
            InitViewer = lViewerID
        End If

        CurrentFunction = "None"

    End Function

    Private Sub ClearViewer()

        If bInitialized Then modAdmin.ModelReset()

    End Sub
    Private Function UpdateRemData(m_modelFile As String) As Long
        Dim rowParameters As New CategoryRow("Rem. Parameters")

        Try

            lReturn = PortalExecute("Nest:RemnantStats:")

            If (lReturn > 0) Then

                m_rem_length = PortalGetDouble("rem_length", 0.0#)
                m_rem_width = PortalGetDouble("rem_width", 0.0#)
                m_rem_area = PortalGetDouble("rem_area", 0.0#)
                m_rem_thickness = PortalGetDouble("rem_thickness", 0.0#)


                m_rem_date = Now.ToShortDateString()

                vsfRemData.Rows.Clear()

                vsfRemData.Rows.Add(rowParameters)

                Dim editorRow As New EditorRow()

                ' assigning the name and caption to the created editor row
                editorRow.Properties.Caption = "Rem. Length"
                editorRow.Properties.Value = FormatNumber(m_rem_length, 4)
                editorRow.Tag = EncodeTag("Length", "Length", FormatNumber(m_rem_length, 4), FormatNumber(m_rem_length, 4), "Length", DB_DBL, 0, sEmpty, 0)

                rowParameters.ChildRows.Add(editorRow)

                Dim reCalcEdit As New RepositoryItemCalcEdit()

                vsfRemData.RepositoryItems.Add(reCalcEdit)
                editorRow.Properties.RowEdit = reCalcEdit

                editorRow = New EditorRow()

                ' assigning the name and caption to the created editor row
                editorRow.Properties.Caption = "Rem. Width"
                editorRow.Properties.Value = FormatNumber(m_rem_width, 4)
                editorRow.Tag = EncodeTag("Width", "Width", FormatNumber(m_rem_width, 4), FormatNumber(m_rem_width, 4), "Width", DB_DBL, 0, sEmpty, 0)

                rowParameters.ChildRows.Add(editorRow)

                reCalcEdit = New RepositoryItemCalcEdit()

                vsfRemData.RepositoryItems.Add(reCalcEdit)
                editorRow.Properties.RowEdit = reCalcEdit

                editorRow = New EditorRow()

                ' assigning the name and caption to the created editor row
                editorRow.Properties.Caption = "Rem. Thickness"
                editorRow.Properties.Value = FormatNumber(m_rem_thickness, 4)
                editorRow.Tag = EncodeTag("Thickness", "Thickness", FormatNumber(m_rem_thickness, 4), FormatNumber(m_rem_thickness, 4), "Thickness", DB_DBL, 0, sEmpty, 0)

                rowParameters.ChildRows.Add(editorRow)

                reCalcEdit = New RepositoryItemCalcEdit()

                vsfRemData.RepositoryItems.Add(reCalcEdit)
                editorRow.Properties.RowEdit = reCalcEdit

                editorRow = New EditorRow()

                ' assigning the name and caption to the created editor row
                editorRow.Properties.Caption = "Rem. Area"
                editorRow.Properties.Value = FormatNumber(m_rem_area, 4)
                editorRow.Tag = EncodeTag("Area", "Area", FormatNumber(m_rem_area, 4), FormatNumber(m_rem_area, 4), "Area", DB_DBL, 0, sEmpty, 0)

                rowParameters.ChildRows.Add(editorRow)

                reCalcEdit = New RepositoryItemCalcEdit()

                vsfRemData.RepositoryItems.Add(reCalcEdit)
                editorRow.Properties.RowEdit = reCalcEdit

                vsfRemData.BestFit()

            End If


        Catch ex As Exception

            MessageBox.Show("UpdateRemData: " & ex.Message)

        End Try





        'vsfRemData.TextMatrix(0, 0) = "Rem. Length"
        'vsfRemData.TextMatrix(1, 0) = "Rem. Width"
        'vsfRemData.TextMatrix(2, 0) = "Rem. Thickness"
        'vsfRemData.TextMatrix(3, 0) = "Rem. Area"
        'vsfRemData.TextMatrix(0, 1) = Round(m_rem_length, Thousandths, False)
        'vsfRemData.TextMatrix(1, 1) = Round(m_rem_width, Thousandths, False)
        'vsfRemData.TextMatrix(2, 1) = Round(m_rem_thickness, Thousandths, False)
        'vsfRemData.TextMatrix(3, 1) = Round(m_rem_area, Thousandths, False)

    End Function
    Private Function LoadModel(sFileName As String) As Boolean


        If bInitialized Then
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ClearViewer()
            lReturn = PortalExecute("*file:importmm2:file=" & QStr(sFileName) & ",preview=1")
            LoadModel = CBool(lReturn)

            If lReturn = 0 Then

                'lblDimensions.Caption = "Problem encountered with file: " & PathFileExt(sFileName)
                ModelFilename = ""
            Else
                m_materialName = HeaderStringGet("Matcfg", "")
                ModelFilename = sFileName
                ' show that part
                'LockWindowUpdate(picPreview.Handle)

                SetWorkplane("TOP")
                SetViewplane("VTOP")
                m_ShowStock = True

                lReturn = PortalExecute("!view:materialextents: regen=0")

                lReturn = UpdateRemData(m_model_file)

                ' LockWindowUpdate(0&)
            End If
            Windows.Forms.Cursor.Current = Cursors.Default
        End If
    End Function
    Private Sub SetWorkplane(ByVal sPlaneName As String)

        On Error Resume Next

        If bInitialized Then
            lReturn = PortalExecute("*admin:lookup:name=" & QStr(sPlaneName))
            lPlaneID = PortalGetInt("id", 0)

            If lPlaneID > 0 Then
                lReturn = PortalExecute("*create:plane:id=" & lPlaneID)
            End If
        End If

    End Sub

    Private Sub SetViewplane(ByVal sViewName As String)

        Dim lViewID As Long

        On Error Resume Next

        If bInitialized Then
            lReturn = PortalExecute("*admin:lookup:name=" & QStr(sViewName))
            lViewID = PortalGetInt("id", 0)

            If lViewID > 0 Then
                lReturn = PortalExecute("!view:plane:id=" & lViewID)
            End If
        End If

    End Sub

    Private Sub ubgModelView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        ' m_model_file = ubgModelView.GetFocusedRowCellValue("Model")

        LoadModel(m_model_file)

    End Sub

    Private Sub sbCommit_Click(sender As Object, e As EventArgs) Handles sbCommit.Click
        Dim cmd As String
        Dim base_file_name As String
        Dim remnant_file_name As String
        Dim parent_id As Long
        Dim okay As Boolean

        base_file_name = modPath.PathFile(m_model_file)
        remnant_file_name = modPath.PathRemnants() & "\" & base_file_name & ".rem"

        cmd = "Nest:RemnantCommit:" & _
              " nst=" & QStr(m_model_file) & _
              ",rem=" & QStr(remnant_file_name) & _
              ",rem_id=" & GetNextRemnantID() & _
              ",flip=" & IIf((chkFlipRemnant.Checked = True), 1, 0)

        lReturn = modPortal.PortalExecute(cmd)

        If (lReturn > 0) Then

            'parent_id will be greater-than-zero when then
            'current remnant has been derived from another remnant.
            parent_id = modPortal.PortalGetInt("parent_id", 0)

            lReturn = CommitRemnant(base_file_name, parent_id)

            InitRemnants()

            If (chkFlipRemnant.Checked = True) Then
                okay = LoadModel(m_model_file)
            End If

        End If

        'Revert the 'flip' checkbox, forcing the user to take explicit action.
        chkFlipRemnant.Checked = False
    End Sub
    Private Function GetNextRemnantID() As Long
        Dim sql As String
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet

        Try
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            sql = "SELECT * FROM Remnant"

            connection = New OleDbConnection(connetionString)
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    GetNextRemnantID = ds.Tables(0).Rows(i).Item("ID").ToString + 1

                Next

            Else

                GetNextRemnantID = 0

            End If

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing


        Catch ex As Exception

            MessageBox.Show("GetNextRemnantID: " & ex.Message)

        End Try

    End Function

    Private Function CommitRemnant( _
                    remnant_name As String, _
                    parent_id As Long) As Long

        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim ds As New DataSet
        Dim rec_data As tStdVarRec
        Dim data As String
        Dim remnant_id As Long
        Dim cnt As Long
        Dim materialName As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)
            connection.Open()

            If (parent_id > 0) Then

                'We given remnant has been derived from another remnant.
                'As such, decrement the count of the parent remnant.
                cnt = RemnantUpdate(connection, parent_id, -1)

            End If

            cnt = ConditionalRemnantUpdate(connection, remnant_name)

            ' UpdateRemnantTable()

            ' GoTo Skip


            If (cnt = 0) Then
                'This is a new remnant, so ...
                'TODO: WE should loop over all the machines selected in the checkbox list
                'First update the Remnant table.
                'iname|display|value|type|flags|link_name|link_value|options
                data = "Remnant|RemnantName|RemnantName|<empty>|str|1|MachineID|" & modProject.GetMachineID()

                rec_data = InitStdVarRec(data)
                remnant_id = AddStdVarRec(connection, rec_data)

                'And then the RemnantVar table.
                'iname|display|value|type|flags|link_name|link_value|options
                data = "RemnantVar|Name|Name|" & remnant_name & "|str|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                'Get the material name to store in db
                'TODO Make sure we get the material of the actual remnant and not what the material
                'is for the currenttly load file in picmodeler
                materialName = HeaderStringGet("MatCfg", "")

                data = "RemnantVar|Material|Material|" & materialName & "|str|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                data = "RemnantVar|Count|Count|1|int|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                data = "RemnantVar|length|Length|" & Round(m_rem_length, Places.Thousandths, False) & "|dbl|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                data = "RemnantVar|Width|Width|" & Round(m_rem_width, Places.Thousandths, False) & "|dbl|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                data = "RemnantVar|Thickness|Thickness|" & Round(m_rem_thickness, Places.Thousandths, False) & "|dbl|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                data = "RemnantVar|Area|Area|" & Round(m_rem_area, Places.Thousandths, False) & "|dbl|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

                data = "RemnantVar|Creation_Date|Creation Date|" & m_rem_date & "|str|1|RemnantID|" & remnant_id
                rec_data = InitStdVarRec(data)
                lReturn = AddStdVarRec(connection, rec_data)

            End If

            connection.Close()
Skip:

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing


        Catch ex As Exception

            MessageBox.Show("CommitRemnant: " & ex.Message)

        End Try



    End Function

    Private Function RemnantUpdate( _
                    cmdb_connection As OleDbConnection, _
                    remnant_id As Long, _
                    Delta As Long) As Long

        Dim oledbAdapter As OleDbDataAdapter
        Dim sql As String
        Dim ds As New DataSet

        Try

            sql = "SELECT * FROM RemnantVar WHERE " & _
                    "((InternalName=" & QStr("Count") & ") AND" & _
                    " (RemnantID=" & remnant_id & "))"

            oledbAdapter = New OleDbDataAdapter(sql, cmdb_connection)

            oledbAdapter.Fill(ds)

            If (ds.Tables(0).Rows.Count - 1 > 0) Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    RemnantUpdate = ds.Tables(0).Rows(i).Item("Value").Value + Delta

                Next

            End If

            oledbAdapter.Dispose()

            sql = "UPDATE [RemnantVar] set [RemnantVar].[Value] = " & RemnantUpdate & " WHERE " & _
                    "((InternalName=" & QStr("Count") & ") AND" & _
                    " (RemnantID=" & remnant_id & "))"

            Dim cmd As OleDbCommand = New OleDbCommand(sql, cmdb_connection)

            cmd.ExecuteNonQuery()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing


        Catch ex As Exception

            MessageBox.Show("RemnantUpdate: " & ex.Message)

        End Try

    End Function

    Private Function ConditionalRemnantUpdate( _
                    cmdb_connection As OleDbConnection, _
                    remnant_name As String) As Long

        Dim remnant_id As Long = 0
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet



        Try
            Dim sql As String

            sql = "SELECT * FROM RemnantVar WHERE " & _
                  "((InternalName=" & QStr("Name") & ") AND" & _
                  " (Value=" & QStr(remnant_name) & "))"


            oledbAdapter = New OleDbDataAdapter(sql, cmdb_connection)

            oledbAdapter.Fill(ds)

            If (ds.Tables(0).Rows.Count - 1 > 0) Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    remnant_id = ds.Tables(0).Rows(i).Item("RemnantID").Value

                Next

            End If

            oledbAdapter.Dispose()


            If (remnant_id > 0) Then
                'Increment the count of this existing remnant.
                ConditionalRemnantUpdate = RemnantUpdate(cmdb_connection, remnant_id, 1)
            Else
                ConditionalRemnantUpdate = 0
            End If

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing



        Catch ex As Exception

            MessageBox.Show("RemnantUpdate: " & ex.Message)

        End Try

    End Function

    Private Sub sbOpen_Click(sender As Object, e As EventArgs) Handles sbOpen.Click
        'Just because ... we are processing a .rem file.
        lReturn = modConversion.ConversionParametersSet(0.0#, False, False)

        lReturn = vbModelSwap(0)
        sReturn = modFileIO.ImportFile(m_model_file, "")

        Me.Close()

    End Sub

    Private Sub lbcMM2Files_MouseClick(sender As Object, e As MouseEventArgs) Handles lbcMM2Files.MouseClick

        If (lbcMM2Files.Items.Count > 0) Then

            LoadModel(lbcMM2Files.Items(lbcMM2Files.SelectedIndex).ToString)

        End If

    End Sub
    Private Sub lbcMM2Files_SelectedValueChanged(sender As Object, e As EventArgs) Handles lbcMM2Files.SelectedValueChanged

        If (lbcMM2Files.Items.Count > 0) Then

            LoadModel(lbcMM2Files.Items(lbcMM2Files.SelectedIndex).ToString)
            m_model_file = lbcMM2Files.Items(lbcMM2Files.SelectedIndex).ToString
        End If

    End Sub

    Private Sub sbLoadModel_Click(sender As Object, e As EventArgs) Handles sbLoadModel.Click
        Dim dialog As New OpenFileDialog()
        Dim ds As New DataSet

        Try

            lbcMM2Files.Items.Clear()

            dialog.Multiselect = False
            dialog.DefaultExt = "mm2"
            dialog.Title = "Select Model file"
            dialog.Filter = "Model Files(*.mm2)|*.mm2|Nest Files (*.nst)|*.nst|Remnant Files (*.rem)|*.rem"

            dialog.InitialDirectory = PathDriveFolder(PathMM2())

            If dialog.ShowDialog(Me) = DialogResult.OK Then

                m_model_file = dialog.FileName

                lbcMM2Files.Items.Add(m_model_file)

            End If

        Catch ex As Exception

            MessageBox.Show("sbLoadModel_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub UpdateRemnantTable()
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
        Dim sFieldNames As String
        Dim sFieldValues As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            sFieldNames = "[InternalName]," & _
                      "[Display]," & _
                      "[Value]," & _
                      "[Type]," & _
                      "[Options]," & _
                      "[Flags]," & _
                      "[MachineID]," & _
                      "[PID]"

            sFieldValues = "'RemnantName', 'RemnantName', """",'3' ,"""",'1','1', '0'"
            sql = "INSERT INTO [Remnant] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            m_cnSettings.Close()

        Catch ex As Exception

            MessageBox.Show("UpdateRemnantTable " & ex.Message)

        End Try
    End Sub

    'Private Sub ubgRemnants_Click(sender As Object, e As EventArgs) Handles ubgRemnants.Click
    '    Dim model_file As String

    '    model_file = PathExt(CStr(ubgRemnantsView.GetRowCellValue(ubgRemnantsView.FocusedRowHandle, ubgRemnantsView.Columns(0)).ToString()))
    'End Sub

    Private Sub lbcMM2Files_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lbcMM2Files_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lbcMM2Files.SelectedIndexChanged

    End Sub
End Class