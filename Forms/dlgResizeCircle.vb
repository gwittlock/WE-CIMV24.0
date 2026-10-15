Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base

Public Class dlgResizeCircle

    Private edit As RepositoryItemCheckEdit
    Private editLayer As RepositoryItemCheckEdit
    Private sPieces() As String
    Private m_colToolSubset As ToolSetup

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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

    Public Sub LoadToolSetupListview()
        Dim lst As New List(Of MyTheTools)()
        Dim clsToolData As ToolData
        Dim bestwidth As Integer

        grdToolLayer.DataSource = Nothing

        gViewToolLayer.Columns.Clear()

        Try

            edit = New RepositoryItemCheckEdit()
            edit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio

            g_DescripChar_len = 0

            If Not g_colToolSetup Is Nothing Then
                For Each clsToolData In g_colToolSetup
                    With clsToolData
                        If UCase$(.Workplane) = UCase$(GetCurrentWorkplane()) Then

                            If (Len(.Description) > g_DescripChar_len) Then

                                g_DescripChar_len = Len(.Description)

                            End If
                            lst.Add(New MyTheTools() With {.ToolHidden = IIf((clsToolData.show), False, True),
                                                         .ToolNumber = clsToolData.NC_Code_Number,
                                                         .ToolName = clsToolData.Description,
                                                         .ToolColor = System.Drawing.ColorTranslator.FromOle(clsToolData.TlColor)})
                        End If
                    End With
                Next

                grdToolLayer.DataSource = lst
                gViewToolLayer.Columns("ToolHidden").Caption = " "
                gViewToolLayer.Columns("ToolHidden").ColumnEdit = edit
                gViewToolLayer.Columns("ToolColor").Visible = False
                gViewToolLayer.Columns("ToolNumber").Visible = True

                For Each col In gViewToolLayer.Columns

                    bestwidth = col.GetBestWidth()
                    col.MinWidth = bestwidth
                Next

                'vgProcessParameters.Refresh()

                AddHandler gViewToolLayer.RowStyle, AddressOf gViewToolLayer_RowStyle

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub gViewToolLayer_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles gViewToolLayer.FocusedRowChanged
        Dim clsToolData As ToolData
        Dim View As Views.Grid.GridView
        View = CType(sender, Views.Grid.GridView)

        Dim col As Object = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ToolNumber"))

        Try

            m_colToolSubset = Nothing
            m_colToolSubset = New ToolSetup

            Load_Tool_Params(col)

            clsToolData = m_colToolSubset(1)

            'LoadToolData(clsToolData)

            clsToolData = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Load_Tool_Params(sCol As String)

        Dim clsToolData As ToolData
        Dim clsToolCopy As ToolData

        Try

            ' add tool to collection
            clsToolData = m_colToolSubset.Add

            ' copy the attributes
            clsToolCopy = g_colToolSetup("T" & sCol)

            lReturn = clsToolData.ParamsCopy(clsToolCopy)

            clsToolData = m_colToolSubset(1)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub gViewToolLayer_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gViewToolLayer.RowStyle
        If e.RowHandle < 0 Then
            Return
        End If
        Dim lst As List(Of MyTheTools)

        Try

            lst = CType(gViewToolLayer.DataSource, List(Of MyTheTools))
            Dim item As MyTheTools = lst(e.RowHandle)
            e.Appearance.ForeColor = item.ToolColor
            e.Appearance.BackColor = Color.Black

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dlgResizeCircle_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmMain.CloseFirstPanel()
    End Sub

    Private Sub dlgResizeCircle_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_colToolSubset = New ToolSetup

        LoadToolSetupListview()
        LoadLayersListview()
    End Sub
    Private Sub CreateRandomLayer(sLayerName As String, lLayerColor As System.Drawing.Color)
        Dim sTemp As String
        Dim colLayers As New Collection
        Dim nI As Integer
        Dim bFound As Boolean
        Dim Index As Integer

        Try

            For nI = 0 To gViewLayer.RowCount - 1
                sTemp = UCase$(gViewLayer.GetRowCellValue(nI, gViewLayer.Columns(2)))
                'If (sTemp.Substring(0, 6) = "LAYER_") Then
                colLayers.Add(sTemp)
                'End If

            Next

            nI = 0

            Do
                bFound = False
                nI = nI + 1

                For Index = 1 To colLayers.Count
                    sTemp = colLayers.Item(Index)

                    If UCase$(gViewLayer.GetRowCellValue(nI, gViewLayer.Columns(1))) = CStr(nI) Then bFound = True

                Next Index
            Loop Until (bFound = False)

            sLayerName = "Layer_" & nI

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

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

        grdLayer.DataSource = Nothing

        gViewLayer.Columns.Clear()

        Try

            editLayer = New RepositoryItemCheckEdit()
            editLayer.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio

            lReturn = PortalExecute("*Model:EntityCount: type=" & c_DBTOOL)
            lCount = PortalGetInt("count", 0)

            If lCount > 0 Then

                For indx = 0 To (lCount - 1)

                    lReturn = PortalExecute(
                                "*Model:Get2:" &
                                " indx=" & indx &
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

                            lst.Add(New TheTools() With {.ToolHidden = IIf((lHidden = 0), True, False),
                                                         .ToolNumber = lLayerID,
                                                         .ToolName = sLayerName,
                                                         .ToolColor = System.Drawing.ColorTranslator.FromOle(lLayerColor)})

                        End If

                    End If

                Next indx

            End If


            grdLayer.DataSource = lst
            gViewLayer.Columns("ToolHidden").Caption = "Visible"
            gViewLayer.Columns("ToolHidden").ColumnEdit = edit
            gViewLayer.Columns("ToolColor").Visible = False
            gViewLayer.Columns("ToolNumber").Visible = False
            gViewLayer.Columns("ToolName").Caption = "Layer Name"

            grdLayer.SuspendLayout()

            For Each col In gViewLayer.Columns

                bestwidth = col.GetBestWidth()
                col.MinWidth = bestwidth
            Next


            grdLayer.ResumeLayout()

            grdLayer.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub gViewLayer_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles gViewLayer.RowCellClick
        Dim nLayerId As Long

        Try

            If (e.Column.Name = "colToolHidden") Then
                nLayerId = gViewLayer.GetRowCellValue(e.RowHandle, gViewLayer.Columns("ToolNumber"))


                gViewLayer.SetRowCellValue(e.RowHandle, e.Column, IIf(e.CellValue = True, False, True))

                If (e.CellValue = False) Then

                    lReturn = PortalExecute("entity:hide:id=" & nLayerId)
                Else
                    lReturn = PortalExecute("entity:show:id=" & nLayerId)
                End If

                modView.ViewRegen()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub gViewLayer_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gViewLayer.RowStyle
        Dim lst As List(Of TheTools)
        Dim item As TheTools

        If (e.RowHandle < 0) Then

            Return

        End If

        lst = CType(gViewLayer.DataSource, List(Of TheTools))
        item = lst(e.RowHandle)
        e.Appearance.ForeColor = item.ToolColor
        e.Appearance.BackColor = Color.Black
    End Sub

    Private Sub dlgResizeCircle_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        xtcToolLayer.Width = Me.Width - 25
        xtcToolLayer.Width = Me.Width - 25
        grdLayer.Width = xtcToolLayer.Width - 25
        grdToolLayer.Width = xtcToolLayer.Width - 25
    End Sub

    Friend Class MyTheTools
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

    Private Sub sbOk_Click(sender As Object, e As EventArgs) Handles sbOk.Click
        Dim lCount As Long
        Dim CircleCount As Long = 0
        Dim entityID As Long
        Dim entitytype
        Dim lId As Long
        Dim lColor As Long
        Dim sName As String
        Dim lToolID As Long
        Dim sLayerName As String
        Dim stemp As String
        Dim dx As Double
        Dim dy As Double
        Dim dZ As Double
        Dim dx1 As Double
        Dim dy1 As Double
        Dim dZ1 As Double
        Dim dx2 As Double
        Dim dy2 As Double
        Dim dZ2 As Double
        Dim IsCircle As Boolean = False
        Dim dTemp As Double
        Dim theTool As Integer
        Dim name As String
        Dim cmd As String
        Dim entity_id As Integer
        Dim sncs As Integer
        Dim delim As String
        Dim nCircleID As Integer
        Dim dWorkzone As Integer
        Dim Zone_ID As Integer
        Dim start_ang As Double
        Dim end_ang As Double
        Dim _start_ang As Double
        Dim _end_ang As Double
        Dim lParentID As Long
        Dim lTemp As Long
        Dim minDia As Double
        Dim maxDia As Double
        Dim newDia As Double
        Dim grdToolCount As Long
        Dim grdLayerCount As Long
        Dim indx As Long
        Dim sToolLayerName As String
        Dim sToolLayerDesc As String
        Dim bToolHidden As Boolean
        Dim bProcessArc As Boolean
        Dim lCounter As Long


        Try
            UndoPrepare()
            lbcIsVisible.Items.Clear()

            For indx = 0 To gViewToolLayer.RowCount - 1

                bToolHidden = gViewToolLayer.GetRowCellValue(indx, gViewToolLayer.Columns("ToolHidden"))

                If bToolHidden = True Then

                    sToolLayerName = gViewToolLayer.GetRowCellValue(indx, gViewLayer.Columns("ToolName"))
                    lbcIsVisible.Items.Add(sToolLayerName)

                End If

            Next

            For indx = 0 To gViewLayer.RowCount - 1


                bToolHidden = gViewLayer.GetRowCellValue(indx, gViewLayer.Columns("ToolHidden"))

                If bToolHidden = True Then

                    sToolLayerName = gViewLayer.GetRowCellValue(indx, gViewLayer.Columns("ToolName"))
                    lbcIsVisible.Items.Add(sToolLayerName)

                End If

            Next

            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            'For lCounter = 0 To (lCount - 1)
            For lCounter = lCount - 1 To 0 Step -1
                'For lCounter = lCount - 1 To 0 Step -1
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)
                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity

                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any
                sToolLayerDesc = GetToolDescriptionFromID(lId)
                If UCase(sToolLayerDesc) = "<ERROR>" Then
                    GoTo skip
                End If
                stemp = PortalGetString("text", "")
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID

                entitytype = GetEntityType(lId)

                If (entitytype = c_DBARC) Then


                    bProcessArc = CheckEntryToListBox(sToolLayerDesc, lbcIsVisible)

                    If bProcessArc = False Then
                        ' GoTo skip
                    End If
                    SetActiveLayer(sToolLayerDesc, lColor)

                    lReturn = PortalExecute("*create:extract:id=" & lId)
                    dx = PortalGetDouble("sx", 0)
                    dy = PortalGetDouble("sy", 0)
                    dZ = PortalGetDouble("sz", 0)

                    dx1 = PortalGetDouble("ex", 0)
                    dy1 = PortalGetDouble("ey", 0)
                    dZ1 = PortalGetDouble("ez", 0)

                    dx2 = PortalGetDouble("cx", 0)
                    dy2 = PortalGetDouble("cy", 0)
                    dZ2 = PortalGetDouble("cz", 0)

                    lTemp = PortalGetInt("dir", 0)

                    dTemp = Dist2D(dx, dx2, dy, dy2)

                    If (Dist2D(dx, dx1, dy, dy1) < 0.000001) Then

                        IsCircle = True
                        ' CircleCount = CircleCount + 1

                        lTemp = PortalGetInt("dir", 0)

                        start_ang = ATan2(dy - dy2, dx - dx2)
                        end_ang = ATan2(dy1 - dy2, dx1 - dx2)
                        'dTemp = Round(Dist2D(dx, dx2, dy, dy2) * 2)
                        dTemp = Round(Dist2D(dx, dx2, dy, dy2))
                        dTemp = dTemp * 2
                        minDia = CDbl(teMinDia.Text)
                        maxDia = CDbl(teMaxDia.Text)

                        If dTemp >= minDia And dTemp <= maxDia Then
                            CircleCount = CircleCount + 1
                            newDia = (CDbl(teNewDia.EditValue) / 2)

                            cmd = "create:arc: action=0,sncs=201,id=0,xc=" & dx2 & ",yc=" & dy2 & ",zc=0,rad=" & newDia & ",dir=1"
                            lReturn = PortalExecute(cmd)


                            If chkDeleteOrg.Checked = True Then
                                lReturn = PortalExecute("Create:Delete: id=" & lId)
                            End If


                        End If


                        End If

                End If

skip:
            Next
            modView.ViewRegen()

            MessageBox.Show("Process complete. " & CircleCount & " Circles processed", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            UndoCommit()

        Catch ex As Exception
            MessageBox.Show("Circle Resize: sbAccept_Click: " & ex.Message)
        End Try
        'MessageBox.Show("Greg, almost Implemented!", "Surprise!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Dispose()

    End Sub

End Class