Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class dlgCircleResize
    Private edit As RepositoryItemCheckEdit

    Private sPieces() As String
    Private WithEvents rbProcessParameters As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private bToolMode As Boolean
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

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click

        Me.Dispose()
    End Sub

    Private Sub sbAccept_Click(sender As Object, e As EventArgs) Handles sbAccept.Click
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


        Try
            UndoPrepare()


            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            For lCounter = 0 To (lCount - 1)
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)
                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity

                stemp = PortalGetString("text", "")
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any
                entitytype = GetEntityType(lId)

                If (entitytype = c_DBARC) Then

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

                    dTemp = Dist2D(dx, dx2, dy, dy2)

                    If (Dist2D(dx, dx1, dy, dy1) < 0.000001) Then

                        IsCircle = True
                        ' CircleCount = CircleCount + 1

                        lTemp = PortalGetInt("dir", 0)

                        start_ang = ATan2(dy - dy2, dx - dx2)
                        end_ang = ATan2(dy1 - dy2, dx1 - dx2)
                        dTemp = Round(Dist2D(dx, dx2, dy, dy2) * 2)
                        minDia = CDbl(teMinDia.Text) * 2
                        maxDia = CDbl(teMaxDia.Text) * 2

                        If dTemp >= minDia And dTemp <= maxDia Then
                            CircleCount = CircleCount + 1

                        End If


                    End If

                End If

skip:
            Next

            MessageBox.Show("We Found a Circle with a radius of " & dTemp & " !, That Makes " & CircleCount & " Circles Found!", "Surprise!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            UndoCommit()

        Catch ex As Exception
            MessageBox.Show("Circle Resize: sbAccept_Click: " & ex.Message)
        End Try
        MessageBox.Show("Greg, almost Implemented!", "Surprise!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub dlgCircleResize_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'LoadLayersListview()
        LoadToolSetupListview()
    End Sub


    Private Sub dlgCircleResize_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        xtcToolLayer.Width = Me.Width - 24
        grdToolLayer.Width = xtcToolLayer.Width - 24
        'gcLayers.Width = xtcToolLayer.Width - 24


    End Sub

    Private Sub dlgCircleResize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub


    Private Sub gViewToolLayer_ShownEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gViewToolLayer.ShownEditor
        LoadToolSetupListview()
    End Sub

    Private Sub grdToolLayer_GotFocus(sender As Object, e As EventArgs) Handles grdToolLayer.GotFocus
        Dim bestwidth As Integer
        grdToolLayer.SuspendLayout()

        For Each col In gViewToolLayer.Columns

            bestwidth = col.GetBestWidth()
            col.MinWidth = bestwidth
        Next

        grdToolLayer.ResumeLayout()
    End Sub

    Private Sub LoadToolSetupListview()
        Dim lst As New List(Of TheTools)()
        Dim clsToolData As ToolData
        Dim bestwidth As Integer

        bToolMode = True

        grdToolLayer.DataSource = Nothing

        gViewToolLayer.Columns.Clear()

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
                        lst.Add(New TheTools() With {.ToolHidden = IIf((clsToolData.show), True, False),
                                                     .ToolNumber = clsToolData.NC_Code_Number,
                                                     .ToolName = clsToolData.Description,
                                                     .ToolColor = System.Drawing.ColorTranslator.FromOle(clsToolData.TlColor)})
                    End If
                End With
            Next

            grdToolLayer.DataSource = lst
            gViewToolLayer.Columns("ToolHidden").Caption = "Hidden "
            gViewToolLayer.Columns("ToolHidden").ColumnEdit = edit
            gViewToolLayer.Columns("ToolColor").Visible = False
            gViewToolLayer.Columns("ToolNumber").Visible = True


            grdToolLayer.SuspendLayout()

            For Each col In gViewToolLayer.Columns

                bestwidth = col.GetBestWidth()
                col.MinWidth = bestwidth
            Next


            grdToolLayer.ResumeLayout()
            AddHandler gViewToolLayer.RowStyle, AddressOf gViewToolLayer_RowStyle

        End If

    End Sub

    Private Sub gViewToolLayer_Click(sender As Object, e As EventArgs) Handles gViewToolLayer.Click
        Dim clsToolData As ToolData
        Dim View As Views.Grid.GridView

        View = CType(sender, Views.Grid.GridView)

        Dim col As Object = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ToolNumber"))
        clsToolData = g_colToolSetup("T" & col.ToString())

        clsToolData = Nothing
    End Sub

    Private Sub gViewToolLayer_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gViewToolLayer.RowStyle
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



    Private Sub gViewToolLayer_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gViewToolLayer.ShowingEditor
        Dim View As Views.Grid.GridView

        View = CType(sender, Views.Grid.GridView)

        If (View.FocusedColumn.Name = "colToolName" Or View.FocusedColumn.Name = "colToolNumber") Then

            e.Cancel = True

        End If
    End Sub


End Class