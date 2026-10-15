Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmSelectLayer
    Private edit As RepositoryItemCheckEdit

    Private Sub frmSelectLayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadLayersListview()

    End Sub
    Public Sub LoadLayersListview()

        Dim lCount As Long
        Dim indx As Long
        Dim lLayerID As Long
        Dim lLayerColor As Long
        Dim sLayerName As String
        Dim lHidden As Long
        Dim type_id As Long
        Dim lst As New List(Of TheTools)()
        Dim bestwidth As Integer

        grdToolLayer.DataSource = Nothing

        gViewToolLayer.Columns.Clear()

        edit = New RepositoryItemCheckEdit()
        edit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio

        lReturn = PortalExecute("*Model:EntityCount: type=" & c_DBTOOL)
        lCount = PortalGetInt("count", 0)

        If lCount > 0 Then

            For indx = 0 To (lCount - 1)

                lReturn = PortalExecute( _
                            "*Model:Get2:" & _
                            " indx=" & indx & _
                            ",type=" & c_DBTOOL)

                lLayerID = PortalGetInt("id", 0)

                'NOTE: Only tools have a Type_ID attribute.
                type_id = EntityIntGet(lLayerID, "Type_ID", UNDEFINED)
                If (type_id = UNDEFINED) Then

                    sLayerName = EntityStringGet(lLayerID, "name", "<error>")
                    If (UCase$(sLayerName) <> "STOCK" And UCase(sLayerName) <> "TABLEGRAPHICS") Then

                        lLayerColor = EntityIntGet(lLayerID, "color", ColorTranslator.ToOle(Color.White))

                        lHidden = -1 ' initialize variable
                        lReturn = PortalExecute("*entity:ishidden:id=" & lLayerID)
                        lHidden = PortalGetInt("val", 0)

                        lst.Add(New TheTools() With {.ToolHidden = IIf(lHidden, True, False),
                                                     .ToolNumber = lLayerID,
                                                     .ToolName = sLayerName,
                                                      .ToolColor = System.Drawing.ColorTranslator.FromOle(lLayerColor)})

                    End If

                End If

            Next indx

        End If


        grdToolLayer.DataSource = lst
        gViewToolLayer.Columns("ToolHidden").Caption = "Visible"
        gViewToolLayer.Columns("ToolHidden").ColumnEdit = edit
        gViewToolLayer.Columns("ToolColor").Visible = False
        gViewToolLayer.Columns("ToolNumber").Visible = False
        gViewToolLayer.Columns("ToolName").Caption = "Layer Name"

        grdToolLayer.SuspendLayout()

        For Each col In gViewToolLayer.Columns

            bestwidth = col.GetBestWidth()
            col.MinWidth = bestwidth
        Next


        grdToolLayer.ResumeLayout()
        AddHandler gViewToolLayer.RowStyle, AddressOf gViewToolLayer_RowStyle
    End Sub

    Public Class TheTools
        Private privateToolHidden As Boolean
        Public Property ToolHidden() As Boolean
            Get
                Return privateToolHidden
            End Get
            Set(ByVal value As Boolean)
                privateToolHidden = value
            End Set
        End Property
        Private privateToolNumber As Integer
        Public Property ToolNumber() As Integer
            Get
                Return privateToolNumber
            End Get
            Set(ByVal value As Integer)
                privateToolNumber = value
            End Set
        End Property
        Private privateToolName As String
        Public Property ToolName() As String
            Get
                Return privateToolName
            End Get
            Set(ByVal value As String)
                privateToolName = value
            End Set
        End Property
        Private privateToolColor As System.Drawing.Color
        Public Property ToolColor() As System.Drawing.Color
            Get
                Return privateToolColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                privateToolColor = value
            End Set
        End Property
    End Class
    Private PrevCheckedRow As Integer ' this is the selected row's handle
    Private CheckedRow As Object ' this is a DataRowView instance
    Private Sub gViewToolLayer_Click(sender As Object, e As EventArgs) Handles gViewToolLayer.Click
        Dim view As GridView = TryCast(sender, GridView)
        Dim hit As GridHitInfo = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition))
        If hit.InRowCell AndAlso hit.Column.FieldName = "Visible" AndAlso hit.RowHandle <> PrevCheckedRow Then
            CheckedRow = view.GetRow(hit.RowHandle)
            view.RefreshRow(PrevCheckedRow)
            PrevCheckedRow = hit.RowHandle
            view.RefreshRow(PrevCheckedRow)
        End If
    End Sub

    Private Sub gViewToolLayer_CustomUnboundColumnData(sender As Object, e As Views.Base.CustomColumnDataEventArgs) Handles gViewToolLayer.CustomUnboundColumnData
        If e.Column.FieldName = "Visible" Then
            If e.IsGetData Then
                e.Value = (e.Row Is CheckedRow)
            End If
        End If
    End Sub

    Private Sub gViewToolLayer_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gViewToolLayer.RowStyle
        Dim lst As List(Of TheTools)
        Dim item As TheTools

        If (e.RowHandle < 0) Then

            Return

        End If

        lst = CType(gViewToolLayer.DataSource, List(Of TheTools))
        item = lst(e.RowHandle)
        e.Appearance.ForeColor = item.ToolColor
        e.Appearance.BackColor = Color.Black
    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click

        Me.Close()

    End Sub

    Private Sub sbOk_Click(sender As Object, e As EventArgs) Handles sbOk.Click
        Dim lCount As Long
        Dim m_FocusedHandle As Long

        m_FocusedHandle = gViewToolLayer.FocusedRowHandle


        If (m_FocusedHandle < 0) Then

            Call MsgBox("Please select a 'Layer'.", vbExclamation, App_Path)

        Else

            Dim nLayerId As Long

            nLayerId = gViewToolLayer.GetRowCellValue(m_FocusedHandle, gViewToolLayer.Columns("ToolNumber"))

            lReturn = SetSelectionFilters( _
                (SELECTION_FILTER.SEL_LINE Or SELECTION_FILTER.SEL_ARC Or SELECTION_FILTER.SEL_HOLE Or SELECTION_FILTER.SEL_POINT Or _
                    SELECTION_FILTER.SEL_COMMAND Or SELECTION_FILTER.SEL_PROFILE Or SELECTION_FILTER.SEL_FEATURE))

            lCount = SelectAllRefsTo(nLayerId)

            frmMain.SynchronizeUI(lCount)

            Me.Dispose()

        End If
    End Sub

    Private Sub frmSelectLayer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        grdToolLayer.Width = Me.Width - 24


    End Sub
End Class