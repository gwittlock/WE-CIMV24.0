

Imports System.ComponentModel

Public Class frmWorkZones
    Implements IDialogMouseUp

    Private Const COL_ID = 0
    Private Const COL_INDX = 1
    Private Const COL_XMIN = 2
    Private Const COL_XMAX = 3
    Private Const COL_XHOLD = 4
    Private Const COL_YHOLD = 5
    Private Const COL_REPO = 6

    Private m_selected_row As Long
    Private m_workzone_id As Long

    Private m_is_active As Boolean

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

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function


    Public Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp

        Dim the_value As Double
        Dim the_row As Long
        Dim the_col As Long
        Dim view = grdWorkZonesView
        Dim index = view.FocusedRowHandle

        the_row = GetSelectedRow()

        the_col = view.FocusedColumn.AbsoluteIndex

        If (the_row > 0) Then

            m_workzone_id = grdWorkZonesView.GetRowCellValue(index, view.Columns(COL_ID))

            If (g_shape Is Nothing) Then

                If ((the_col = COL_XMIN) Or
                    (the_col = COL_XMAX)) Then

                    the_value = Round(PortalGetDouble("px", 0.0#))
                    view.SetFocusedRowCellValue(the_col, the_value)

                    lReturn = SetZoneAttributes(m_workzone_id)

                ElseIf (the_col = COL_XHOLD) Then

                    the_value = Round(PortalGetDouble("px", 0.0#))
                    view.SetFocusedRowCellValue(the_col, the_value)
                    lReturn = SetRepoHoldDown(m_workzone_id)

                ElseIf (the_col = COL_YHOLD) Then

                    the_value = Round(PortalGetDouble("py", 0.0#))
                    view.SetFocusedRowCellValue(the_col, the_value)
                    lReturn = SetRepoHoldDown(m_workzone_id)

                End If

            End If

        End If

    End Function

    Private Sub frmWorkZones_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        m_is_active = False
    End Sub

    Private Sub frmWorkZones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bIsWorkZoneLoaded = False
        lReturn = modSelection.DeselectAll()

        m_is_active = False
        frmMain.CloseFirstPanel()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frmWorkZones_Load(sender As Object, e As EventArgs) Handles Me.Load

        FillWorkZones()

        m_is_active = True

        bIsWorkZoneLoaded = True
    End Sub
    Private Sub RepoEnd()

        Dim cmd As String

        'We are going to stop dragging.
        cmdHold.Text = "Drag"

        cmd = "nest:manual:instance: opt=" & BUMP_CANCEL

        lReturn = PortalExecute(cmd)

        g_shape = Nothing

        ButtonsEnable()

    End Sub

    Private Sub ButtonsEnable()

        Dim can_enable As Boolean

        If ((g_shape Is Nothing) = False) Then

            'We are in the process of dragging the holddowns.
            cmdAdd.Enabled = False
            cmdRemove.Enabled = False
            cmdAssign.Enabled = False
            cmdHold.Enabled = True
            cmdCancel.Enabled = True



        Else

            can_enable = (grdWorkZonesView.RowCount > 0)

            cmdAdd.Enabled = True
            cmdRemove.Enabled = can_enable
            cmdAssign.Enabled = can_enable
            cmdHold.Enabled = can_enable
            cmdCancel.Enabled = False



        End If

    End Sub

    Private Sub grdWorkZonesView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdWorkZonesView.CellValueChanged
        Dim cmd As String
        Dim the_row As Long
        Dim the_col As Long
        Dim view = grdWorkZonesView
        Dim index As Integer = view.FocusedRowHandle

        the_row = GetSelectedRow()


        index = view.FocusedRowHandle
        the_col = view.FocusedColumn.AbsoluteIndex


        If ((view.RowCount > 0) And (index >= 0)) Then


            lReturn = SetZoneAttributes(view.GetRowCellValue(the_row, view.Columns(COL_ID)))

            cmd = "!view:highlight:id=" & view.GetRowCellValue(the_row, view.Columns(COL_ID))

            lReturn = PortalExecute(cmd)

            If ((the_col = COL_XHOLD) Or (the_col = COL_YHOLD) Or (the_col = COL_REPO)) Then
                lReturn = SetRepoHoldDown(m_workzone_id)
            End If

        End If
    End Sub

    Private Sub grdWorkZonesView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdWorkZonesView.CustomDrawRowIndicator

        If (Not e.Info.IsRowIndicator) Then
            e.Info.DisplayText = "Zone"
        Else
            e.Info.DisplayText = e.RowHandle + 1

        End If

    End Sub

    Private Sub cmdAssign_Click(sender As Object, e As EventArgs) Handles cmdAssign.Click
        Dim old_color As Boolean


        'Dim row As Integer = (grdWorkZonesView.GetSelectedRows()(i))
        Dim row As Integer = grdWorkZonesView.FocusedRowHandle

        Dim obj As clsWorkZones = TryCast(grdWorkZonesView.GetRow(row), clsWorkZones)
        If obj Is Nothing Then
            Return
        End If

        m_workzone_id = obj.WorkZoneID.ToString

        UndoPrepare()

        lReturn = modFeature.FeatureAddSelected(m_workzone_id)

        UndoCommit()

        'Introduced with V18 to give visual feedback to user.
        old_color = modView.SelectionColorSet(System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White), True)

        If (bIsSeqMoveLoaded = True) Then frmSeqMove.FillSeqList()
        If (bIsEntityLoaded = True) Then frmEntityList.FillTreeView()
    End Sub


    Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        Dim view = grdWorkZonesView
        Dim index = view.FocusedRowHandle
        Dim zone_id As Long
        Dim Cnt As Integer
        Dim bMessageResult As Long



        zone_id = m_workzone_id


        UndoPrepare()
        lReturn = PortalExecute("*Entity:Container:Count:id=" & m_workzone_id)

        Cnt = PortalGetInt("count", 0)

        If Cnt > 0 Then

            bMessageResult = MessageBox.Show("This WorkZone has " & Cnt & " entities in it. Deleteting the WorkZone will Also delete the entities. Do you want to contniue?", "Warning", MessageBoxButtons.YesNo)

            If (bMessageResult = System.Windows.Forms.DialogResult.Yes) Then

                lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & zone_id)
                lReturn = PortalExecute("Zone:Update: id=" & zone_id & ",delete=1")

                view.DeleteRow(index)


                lReturn = SetZoneAttributes(-1)

                modView.ViewRegen()


            End If
        Else

            lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & zone_id)
            lReturn = PortalExecute("Zone:Update: id=" & zone_id & ",delete=1")

            view.DeleteRow(index)


            lReturn = SetZoneAttributes(-1)

            modView.ViewRegen()

        End If


        UndoCommit()
    End Sub
    Private grdWorkZoneData As BindingList(Of clsWorkZones)
    Private bs As BindingSource

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FillWorkZones()
        Dim Hold_Point As PortalPoint
        Dim repo_amt As Double
        Dim cnt As Long
        Dim indx As Long
        Dim have_hold_downs As Boolean
        Dim Zone_ID As Integer
        Dim Zone_Num As Integer
        Dim Zone_Min As Double
        Dim Zone_Max As Double
        Dim bestwidth As Integer


        grdWorkZoneData = New BindingList(Of clsWorkZones)

        'grdWorkZoneData.Clear()
        grdWorkZones.DataSource = Nothing

        grdWorkZonesView.Columns.Clear()



        lReturn = PortalExecute("zone:count:")
        cnt = PortalGetInt("count", 0)


        For indx = 1 To cnt

            Zone_Num = PortalExecute("zone:get:_zone_num=" & indx)

            If (lReturn > 0) Then


                Zone_ID = Round(PortalGetInt("ID", 0))

                Hold_Point.dx = PortalGetDouble("_hold_x", UNDEFINED)
                Hold_Point.dy = PortalGetDouble("_hold_y", UNDEFINED)

                Zone_Min = PortalGetDouble("_zone_left", 0.0#)
                Zone_Max = PortalGetDouble("_zone_right", 0.0#)


                have_hold_downs = ((Hold_Point.dx < UNDEFINED) And (Hold_Point.dy < UNDEFINED))

                If (have_hold_downs = True) Then

                    repo_amt = PortalGetDouble("_zone_repo", UNDEFINED)

                    Hold_Point.dZ = 0.0#

                    lReturn = vbWorldToRef(Hold_Point)
                Else
                    Hold_Point.dx = 0.0
                    Hold_Point.dy = 0.0
                    repo_amt = 0.0
                End If



            End If
            grdWorkZoneData.Add(New clsWorkZones(Zone_ID, indx, repo_amt, Hold_Point.dx, Hold_Point.dy, Zone_Max, Zone_Min))

        Next

        bs = New BindingSource()
        bs.DataSource = grdWorkZoneData

        grdWorkZones.DataSource = bs
        'grdWorkZones.DataSource = grdWorkZoneData

        grdWorkZonesView.Columns(COL_ID).Caption = "ID"

        grdWorkZonesView.Columns(COL_ID).Visible = False

        grdWorkZonesView.Columns(COL_INDX).Caption = "#"

        grdWorkZonesView.Columns(COL_INDX).Visible = False

        grdWorkZonesView.Columns(COL_XMIN).Caption = "Start X"

        grdWorkZonesView.Columns(COL_XMAX).Caption = "End X"

        grdWorkZonesView.Columns(COL_XHOLD).Caption = "Hold X"

        grdWorkZonesView.Columns(COL_YHOLD).Caption = "Hold Y"

        grdWorkZonesView.Columns(COL_REPO).Caption = "Repo"

        grdWorkZones.SuspendLayout()

        For Each col In grdWorkZonesView.Columns

            bestwidth = col.GetBestWidth()
            col.MinWidth = bestwidth
        Next


        grdWorkZones.ResumeLayout()



        RepoEnd()
    End Sub

    'ASSUMPTION: When workzone_id > 0 a valid row is selected.
    Private Function SetZoneAttributes(workzone_id As Long) As Long

        Dim cmd As String
        Dim stmp As String
        Dim pt As PortalPoint
        Dim hold_x As Double
        Dim hold_y As Double
        Dim the_row As Long
        Dim hold_type As Long
        Dim indx As Long
        Dim view = grdWorkZonesView
        Dim index = view.FocusedRowHandle
        Dim dStartX As Double
        Dim dEndX As Double
        Dim nZoneNum As Integer


        On Error GoTo Skip
        UndoPrepare()
        workzone_id = DirectCast(view.GetFocusedRow, FabV24_WIN8.clsWorkZones).WorkZoneID
        dEndX = CDbl(DirectCast(view.GetFocusedRow, FabV24_WIN8.clsWorkZones).WorkZoneXMax)
        dStartX = CDbl(DirectCast(view.GetFocusedRow, FabV24_WIN8.clsWorkZones).WorkZoneXMin)
        nZoneNum = CInt(DirectCast(view.GetFocusedRow, FabV24_WIN8.clsWorkZones).WorkZoneNum)

        If (workzone_id = -1) Then

            For indx = 0 To view.RowCount


                lReturn = PortalExecute("!view:erase:id=" & workzone_id)

                'We need only to update the zone number.
                cmd = "zone:update:" &
                    " id=" & workzone_id &
                    ",_zone_num=" & indx

                SetZoneAttributes = PortalExecute(cmd)

                lReturn = PortalExecute("!view:draw:id=" & workzone_id)
            Next

        Else

            the_row = GetSelectedRow()


            lReturn = PortalExecute("!view:erase:id=" & workzone_id)

            '2006.09.25 (PE) -- We must be very careful with the
            'hold down data. The data should be deleted if-and-only-if
            'both the X & Y hold down positions are undefined.
            hold_type = HeaderIntGet("hold_type", UNDEFINED)
            If (hold_type < UNDEFINED) Then

                stmp = CDbl(DirectCast(view.GetFocusedRow, FabV24_WIN8.clsWorkZones).WorkZoneXHold)
                If (stmp = "") Then
                    hold_x = UNDEFINED
                Else
                    hold_x = CDbl(stmp)
                End If

                stmp = CDbl(DirectCast(view.GetFocusedRow, FabV24_WIN8.clsWorkZones).WorkZoneYHold)
                If (stmp = "") Then
                    hold_y = UNDEFINED
                Else
                    hold_y = CDbl(stmp)
                End If

                If ((hold_x >= UNDEFINED) And (hold_y >= UNDEFINED)) Then

                    'Were removing the hold down. Nothing else to do
                    'because the portal expects hold_type greater-than-zero
                    'and both hold ordinates to be UNDEFINED.

                ElseIf ((hold_x < UNDEFINED) Or (hold_y < UNDEFINED)) Then

                    'We're changing the hold down position.
                    pt.DX = 0
                    pt.DY = hold_y
                    pt.dZ = 0
                    lReturn = vbRefToWorld(pt)
                    hold_y = pt.DY

                End If

            Else

                hold_x = UNDEFINED
                hold_y = UNDEFINED

            End If

            cmd = "zone:update:" &
                  " id=" & workzone_id &
                  ",_zone_bottom=" & HeaderDoubleGet("Width", 0.0#) &
                  ",_zone_left=" & dStartX &
                  ",_zone_num=" & nZoneNum &
                  ",_zone_right=" & dEndX &
                  ",_zone_top=0" &
                  ",hold_type=" & hold_type &
                  ",_hold_x=" & hold_x &
                  ",_hold_y=" & hold_y

            SetZoneAttributes = PortalExecute(cmd)


            modView.ViewRegen()

        End If
Skip:

        UndoCommit()

        modView.ViewRefresh()

    End Function

    Private Function GetSelectedRow() As Integer

        Dim view = grdWorkZonesView

        For indx As Integer = 0 To view.SelectedRowsCount - 1

            GetSelectedRow = (view.GetSelectedRows()(indx))

        Next indx
    End Function

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim lFeatureID As Long
        Dim view = grdWorkZonesView
        Dim rCount As Integer

        UndoPrepare()

        rCount = view.RowCount + 1

        lReturn = PortalExecute(
            "zone:update:" &
            "_zone_num=" & rCount &
            ",_zone_bottom=" & HeaderDoubleGet("Width", 0) &
            ",_zone_left=0" &
            ",_zone_right=0" &
            ",_zone_top=0")

        lFeatureID = PortalGetInt("ID", 0)

        If (bIsEntityLoaded = True) Then frmEntityList.FillTreeView()

        grdWorkZoneData.Add(New clsWorkZones(lFeatureID, rCount - 1, 0, 0, 0, 0, 0))

        FillWorkZones()

        UndoCommit()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        RepoEnd()
    End Sub

    Private Sub SpinEdit1_Spin(sender As Object, e As Controls.SpinEventArgs) Handles SpinEdit1.Spin
        Dim Hold_PointX1 As Double
        Dim Hold_PointY1 As Double
        Dim repo_amt1 As Double
        Dim Zone_ID1 As Integer
        Dim Zone_Num1 As Integer
        Dim Zone_Min1 As Double
        Dim Zone_Max1 As Double

        Dim Hold_PointX2 As Double
        Dim Hold_PointY2 As Double
        Dim repo_amt2 As Double
        Dim indx2 As Long
        Dim Zone_ID2 As Integer
        Dim Zone_Num2 As Integer
        Dim Zone_Min2 As Double
        Dim Zone_Max2 As Double
        Dim row1 As clsWorkZones
        Dim row2 As clsWorkZones
        Dim the_row As Long

        Dim view = grdWorkZonesView

        the_row = GetSelectedRow()

        Dim index As Integer = view.FocusedRowHandle

        view.GridControl.Focus()
        index = view.FocusedRowHandle

        If (e.IsSpinUp = True) Then

            If (index = 0) Then Exit Sub


            row1 = view.GetRow(index)
            row2 = view.GetRow(index - 1)
            indx2 = index - 1

        Else
            If (index >= view.DataRowCount - 1) Then Exit Sub

            row1 = view.GetRow(index)
            row2 = view.GetRow(index + 1)
            indx2 = index + 1
        End If

        Hold_PointX1 = row1.WorkZoneXHold
        Hold_PointY1 = row1.WorkZoneYHold
        repo_amt1 = row1.WorkZoneRepoAmt
        Zone_ID1 = row1.WorkZoneID
        Zone_Num1 = row1.WorkZoneNum
        Zone_Min1 = row1.WorkZoneXMin
        Zone_Max1 = row1.WorkZoneXMax

        Hold_PointX2 = row2.WorkZoneXHold
        Hold_PointY2 = row2.WorkZoneYHold
        repo_amt2 = row2.WorkZoneRepoAmt
        Zone_ID2 = row2.WorkZoneID
        Zone_Num2 = row2.WorkZoneNum
        Zone_Min2 = row2.WorkZoneXMin
        Zone_Max2 = row2.WorkZoneXMax

        row1.WorkZoneXHold = Hold_PointX2
        row1.WorkZoneYHold = Hold_PointY2
        row1.WorkZoneRepoAmt = repo_amt2
        row1.WorkZoneID = Zone_ID2
        row1.WorkZoneNum = Zone_Num2
        row1.WorkZoneXMin = Zone_Min2
        row1.WorkZoneXMax = Zone_Max2


        row2.WorkZoneXHold = Hold_PointX1
        row2.WorkZoneYHold = Hold_PointY1
        row2.WorkZoneRepoAmt = repo_amt1
        row2.WorkZoneID = Zone_ID1
        row2.WorkZoneNum = Zone_Num1
        row2.WorkZoneXMin = Zone_Min1
        row2.WorkZoneXMax = Zone_Max1

        view.FocusedRowHandle = indx2


    End Sub

    Private Sub RepoBegin()

        'We are going to start dragging.
        cmdHold.Text = "Drop"

        g_shape = New clsShape
        lReturn = g_shape.HoldDownInit(m_workzone_id)

        ButtonsEnable()

    End Sub
    Private Function SetRepoHoldDown(workzone_id As Long) As Long

        Dim pt As PortalPoint
        Dim cmd As String
        Dim xhold As String
        Dim yhold As String
        Dim zrepo As String
        Dim the_row As Long
        Dim view = grdWorkZonesView
        Dim index As Integer = view.FocusedRowHandle


        SetRepoHoldDown = 0  'assume failure

        the_row = GetSelectedRow()

        view.GridControl.Focus()
        index = view.FocusedRowHandle

        If (workzone_id > 0) Then

            xhold = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(COL_XHOLD))
            yhold = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(COL_YHOLD))
            zrepo = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(COL_REPO))



            If (xhold = "") Then
                lReturn = modAttribs.EntityDoubleDelete(workzone_id, "_hold_x")
            End If

            If (yhold = "") Then
                lReturn = modAttribs.EntityDoubleDelete(workzone_id, "_hold_y")
            End If

            If (zrepo = "") Then
                lReturn = modAttribs.EntityDoubleDelete(workzone_id, "_zone_repo")
            End If

            If ((xhold <> "") And (yhold <> "")) Then

                UndoPrepare()

                pt.DX = xhold
                pt.DY = yhold
                pt.dZ = 0

                lReturn = vbRefToWorld(pt)

                cmd = "zone:update:" &
                     " id =" & workzone_id &
                     ",hold_type=" & HeaderIntGet("hold_type", UNDEFINED) &
                     ",_zone_num=" & view.GetRowCellValue(the_row, view.Columns(COL_INDX)) &
                     ",_hold_x=" & pt.dx &
                     ",_hold_y=" & pt.dy

                If (zrepo <> "") Then cmd = cmd & ",_zone_repo=" & zrepo

                SetRepoHoldDown = PortalExecute(cmd)

                UndoCommit()

                modView.ViewRegen()

            End If

        End If

    End Function


    Private Sub cmdHold_Click(sender As Object, e As EventArgs) Handles cmdHold.Click
        Dim the_row As Long

        the_row = grdWorkZonesView.FocusedRowHandle

        If (the_row >= 0) Then

            If ((g_shape Is Nothing) = False) Then
                grdWorkZonesView.SetRowCellValue(the_row, COL_XHOLD, Round(g_shape.GetLocation().x))
                grdWorkZonesView.SetRowCellValue(the_row, COL_YHOLD, Round(g_shape.GetLocation().y))
                RepoEnd()

                lReturn = SetRepoHoldDown(m_workzone_id)

            Else

                RepoBegin()

                lReturn = PortalExecute("!view:highlight:id=" & m_workzone_id)

            End If
        End If

    End Sub

    Private Sub grdWorkZonesView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdWorkZonesView.FocusedRowChanged
        Dim row As Integer = grdWorkZonesView.FocusedRowHandle

        Dim obj As clsWorkZones = TryCast(grdWorkZonesView.GetRow(row), clsWorkZones)
        If obj Is Nothing Then
            Return
        End If

        m_workzone_id = obj.WorkZoneID.ToString

    End Sub
End Class