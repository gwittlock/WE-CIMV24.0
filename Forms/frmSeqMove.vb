Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes

Public Class frmSeqMove
    Implements IDialogMouseUp
    Private m_descrip As String
    Private m_insertID As Integer

    Private m_active_workzone_index As Integer
    Private m_active_workzoneID As Long
    Private m_active_workzone_name As String

    Private m_tree_index As Long

    Private nInsertBackColorStore As Color
    Private nInsertForeColorStore As Color
    Private nInsertListIndex As Integer
    Private m_is_active As Boolean
    Private MyMouseX As Integer
    Private MyMouseY As Integer

    Private Const UNDO_ENABLE = False

    Private SEQ_ROOT_NODE As TreeListNode
    Private SEQ_ZONE_NODE As TreeListNode
    Private _hitInfo As TreeListHitInfo
    Private kShiftOrControl As System.Windows.Forms.Keys
    Private bSortAssending As Boolean = True
    Const VALUE_ENTITY = "ENITY"
    Const VALUE_TOOL = "TOOL"
    Const VALUE_ENTID = "ENT_ID"
    Const VALUE_SEQNUM = "SEQ"
    Private Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp
        'This function is just to support the mouse up event of the picmodeler
        'no action is required
    End Function
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

    Public Sub FillSeqList()

        Dim nSeqID As Long
        Dim nSeqColor As Long
        Dim nSeqTool As Long
        Dim sTemp As String
        Dim nSeqType As Long
        Dim nSeqOrderID As Integer

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        TListWin1.Clear()
        TListWin1.MultiSelect = 3
        TListWin1.DefItemCellDef.Picture = Image1.Images("UnChecked")
        TListWin1.DefItemCellDef.PictureSelected = Image1.Images("Checked")

        nSeqOrderID = 1

        'lReturn = PortalExecute("Seq:Init:")
        If (m_active_workzone_index = 0) Then
            lReturn = PortalExecute("*Seq:Iter_init:ID=0")
        Else
            'lReturn = PortalExecute("Seq:Iter_init:ID=" & sstSeqMove.Nodes(m_active_workzone_index).DataKey)
            lReturn = PortalExecute("*Seq:Iter_init:ID=" & m_active_workzoneID)
        End If


        '******************************
        '* The Checked Listbox Sample
        '******************************

        'Building a ListBox through code

        'Set InvStyle to highlight entire cells when selected

        TListWin1.InvStyle = 3

        'Important *** Setting Redraw to False to prevent updates while
        TListWin1.Redraw = False

        TListWin1.Grid.Cols = 5

        TListWin1.Grid.ShowColTitles = True

        TListWin1.Grid.ShowRowTitles = False

        'Specify column titles and formatting
        'Note Row 0 holds column titles and we set values and formatting for columns 1, 2, 3.

        TListWin1.Grid.Cells(0, 1).Value.Data = "Entity"
        TListWin1.Grid.Cells(0, 2).Value.Data = "Tool"
        TListWin1.Grid.Cells(0, 3).Value.Data = "Seq"
        TListWin1.Grid.Cells(0, 4).Value.Data = "Ent_ID"
        TListWin1.Grid.RowDefs.Item(0).CellDef.ForeColor = System.Drawing.Color.Black
        TListWin1.Grid.ColDefs.Item(1).Width = 100
        TListWin1.Grid.ColDefs.Item(2).Width = 50
        TListWin1.Grid.ColDefs.Item(3).Width = 50
        TListWin1.Grid.ColDefs.Item(4).Width = 50
        'Begin Adding Data
        TListWin1.ColDelimiter = 94


        nSeqID = PortalGetInt("id", 0)

        If nSeqID = 0 Then
            Dim nGary As Integer = nSeqID
        End If
        Do While (nSeqID > 0)

            nSeqColor = PortalGetInt("color", 0)
            nSeqTool = PortalGetInt("tool", 0)
            nSeqID = PortalGetInt("id", 0)
            nSeqType = PortalGetInt("type", 0)

            sTemp = GetDisplayName(nSeqID)
            If sTemp <> "" Then
                GetToolNumber(nSeqTool)
                'TListWin1.AddItem("Idling jet^$12.00^9874830", ParentIndex)
                TListWin1.AddItem(sTemp & "^" & m_descrip & "^" & nSeqOrderID & "^" & nSeqID, -1)
                TListWin1.Grid.RowDefs.Item(TListWin1.NewIndex + 1).CellDef.ForeColor = System.Drawing.ColorTranslator.FromOle(nSeqColor)
                TListWin1.Grid.RowDefs.Item(TListWin1.NewIndex + 1).CellDef.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
                TListWin1.ItemTag(TListWin1.NewIndex) = nSeqID

                If (modSelection.IsSelected(nSeqID) = True) Then
                    TListWin1.Node(TListWin1.NewIndex).Selected = True
                End If

                'TListWin1.Grid.Cells(TListWin1.NewIndex + 1, 0).CellDef.ForeColor = nSeqColor
                'TListWin1.Grid.Cells(TListWin1.NewIndex + 1, 1).CellDef.ForeColor = nSeqColor
                'TListWin1.Grid.Cells(TListWin1.NewIndex + 1, 2).CellDef.ForeColor = nSeqColor
                'TListWin1.Grid.Cells(TListWin1.NewIndex + 1, 3).CellDef.ForeColor = nSeqColor
                'TListWin1.Grid.Cells(TListWin1.NewIndex + 1, 4).CellDef.ForeColor = nSeqColor

                'TListWin1.ItemTag(TListWin1.NewIndex) = nSeqID
                nSeqOrderID = nSeqOrderID + 1
            End If

            lReturn = PortalExecute("*Seq:Iter_next:")
            nSeqID = PortalGetInt("id", 0)

        Loop

        'TListWin1.Width = 2600
        'TListWin1.Grid.SortingStyle = TL_SORT_NUMBERS_SORT
        'TListWin1.Grid.SortingKey = 3
        'TListWin1.Grid.SortingMethod = 0

        'TListWin1.Grid.RowHeight(0) = 300
        'TListWin1.EditingMode = EDITMODE_NONE

        'TODO: Maybe entity selection-state should be moved into
        'the preceding loop?  This may improve performance.
        'SelectSynchronize()

        'Update the screen display now that we are done with manipulations
        TListWin1.Redraw = True
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub


    Private Sub frmSeqMove_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False
        bIsSeqMoveLoaded = False
        frmMain.CloseFirstPanel()

    End Sub

    Private Sub frmSeqMove_Load(sender As Object, e As EventArgs) Handles Me.Load


        frmMain.SetCurrentDialog(Me)
        m_is_active = True
        modView.ViewAll()
        bIsSeqMoveLoaded = True

    End Sub

    Public Sub New()
        Dim nSeqID As Long
        Dim nSeqColor As Long
        Dim nSeqLevel As Long
        Dim nSeqTool As Long
        Dim sTemp As String
        Dim nSeqType As Long
        Dim nZoneNumber As Integer
        Dim white_background As Long


        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Add any initialization after the InitializeComponent() call.
        white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)

        If (white_background <> 0) Then
            m_bg_color = System.Drawing.ColorTranslator.ToOle(Color.White)
            m_fg_color = System.Drawing.ColorTranslator.ToOle(Color.Black)
        Else
            m_bg_color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            m_fg_color = System.Drawing.ColorTranslator.ToOle(Color.White)
        End If

        If (white_background <> 0) Then
            tl_SeqOrder.Appearance.Empty.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
            tl_SeqOrder.Appearance.Empty.ForeColor = System.Drawing.ColorTranslator.FromOle(m_fg_color)
            tl_SeqOrder.Columns(0).AppearanceCell.ForeColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
            tl_SeqOrder.Columns(0).AppearanceCell.BackColor = System.Drawing.ColorTranslator.FromOle(m_fg_color)

        Else
            tl_SeqOrder.Appearance.Empty.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
            tl_SeqOrder.Appearance.Empty.ForeColor = System.Drawing.Color.Yellow
            tl_SeqOrder.Columns(0).AppearanceCell.ForeColor = Color.Yellow
            tl_SeqOrder.Columns(0).AppearanceCell.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)


        End If


        m_active_workzone_index = 0
        m_active_workzoneID = 0

        m_tree_index = -1

        nZoneNumber = 0

        'set the insert ID to bogus value for trapping
        m_insertID = -1

        tl_SeqOrder.ClearNodes()

        tl_SeqOrder.BeginUnboundLoad()


        SEQ_ROOT_NODE = tl_SeqOrder.AppendNode(New Object() {PathFile(PathCurrent)}, 0)

        lReturn = PortalExecute("*Seq:Init:")
        lReturn = PortalExecute("*Seq:Iter_init:ID=0")

        nSeqID = PortalGetInt("id", 0)
        Do While (nSeqID > 0)

            nSeqColor = PortalGetInt("color", 0)
            nSeqLevel = PortalGetInt("level", 0)
            nSeqTool = PortalGetInt("tool", 0)
            nSeqType = PortalGetInt("type", 0)

            nZoneNumber = nZoneNumber + 1

            sTemp = "WorkZone " & CStr(nZoneNumber)

            SEQ_ZONE_NODE = tl_SeqOrder.AppendNode(New Object() {sTemp}, SEQ_ROOT_NODE, nSeqID)

            lReturn = PortalExecute("*Seq:Iter_Next:")
            nSeqID = PortalGetInt("id", 0)

        Loop
        tl_SeqOrder.EndUnboundLoad()
        tl_SeqOrder.ExpandAll()

        tl_SeqOrder.EndUpdate()

        tl_SeqOrder.Refresh()
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub sbDone_Click(sender As Object, e As EventArgs) Handles cmdDone.Click
        Me.Close()

    End Sub
    Public Sub PostOptimizeUpdate()

        If (m_active_workzone_index > 0) Then
            FillSeqList()
        End If
        'Call mnuPopUpJumpTo_Click()

    End Sub
    Private Sub sbOptimize_Click(sender As Object, e As EventArgs) Handles cmdOptimize.Click
        Dim insertID As Long
        Dim opt_state As Long

        EnableControls(False)


        insertID = EntityIntGet(m_active_workzoneID, "_insert_id", 0)
        opt_state = EntityIntGet(insertID, "_insert_ba", INSERT_AFTER)

        frmCodeGen.SetSeqOrderMode(opt_state)
        frmCodeGen.Init(CODE_OPTION.SEQUENCE_ORDER)

        'The dialog is modeless because we need the ability to get an
        'approximate start location from a user-pick in the graphics window.
        '  frmCodeGen.show vbModal, Me
        frmCodeGen.ShowDialog(Me)


        FillSeqList()

        EnableControls(True)
    End Sub

    Private Sub EnableControls(enable As Boolean)

        pnlOptimize.Enabled = enable
        cmdOptimize.Enabled = enable
        cmdDone.Enabled = enable

    End Sub

    Public Sub SelectSynchronize()
        Dim nIndex As Integer
        Dim entityID As Long
        Dim etype As Long

        Windows.Forms.Cursor.Current = Cursors.WaitCursor


        TListWin1.Redraw = False
        For nIndex = 0 To TListWin1.ListCount - 1
            entityID = CLng(TListWin1.ItemTag(nIndex))
            TListWin1.Selected(nIndex) = IsSelected(entityID)
            etype = GetEntityType(entityID)
            ' SetSelectionFilterByType(etype)
            'modSelection.SelectEntity(entityID)
        Next nIndex

        TListWin1.Redraw = True

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub


    Private Sub sbSeqMove_Click(sender As Object, e As EventArgs) Handles cmdSeqMove.Click
        Dim Mode As Long

        If (UNDO_ENABLE) Then UndoPrepare()

        Mode = IIf((optSeqMove.Properties.Items(0).Value = True), INSERT_BEFORE, INSERT_AFTER)

        lReturn = PortalExecute( _
                    "Seq:Move:" & _
                    " id=" & m_active_workzoneID & _
                    ",mode=" & Mode)

        If (UNDO_ENABLE) Then UndoCommit()

        FillSeqList()

        'Call mnuPopUpJumpTo_Click()
    End Sub




    Private Sub mnuPopUpInsertAfter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpInsertAfter.ItemClick

        If (UNDO_ENABLE) Then UndoPrepare()

        lReturn = PortalExecute( _
            "Seq:Insert:" & _
            " seqid=" & m_active_workzoneID & _
                    ",refid=" & m_insertID & _
                    ",refba=1")

        If (UNDO_ENABLE) Then UndoCommit()

        FillSeqList()

        ' mnuJumpTo(sender, e)
    End Sub

    Public Sub mnuJumpTo(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim indx As Long
        Dim limit As Long
        Dim insertID As Long

        'NOTE: It is possible for the list to be
        'empty if the root node is selected.
        If (TListWin1.ListCount > 1) Then

            insertID = EntityIntGet(m_active_workzoneID, "_insert_id", 0)

            limit = TListWin1.ListCount - 1
            For indx = 1 To limit
                If (TListWin1.ItemTag(indx) = insertID) Then Exit For
            Next

            'When possible, position this insert position such
            'that it appears one down from top of list.
            ' TListWin1.Visible = False
            'TListWin1.ListIndex = 0

            If (indx = 1) Then
                TListWin1.ListIndex = 1
            ElseIf (indx <= limit) Then
                TListWin1.ListIndex = indx - 1
            End If

            'TListWin1.Visible = True

        End If
    End Sub

    Private Sub mnuPopUpJumpTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpJumpTo.ItemClick
        mnuJumpTo(sender, e)

    End Sub

    Private Sub mnuPopUpInsertBefore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpInsertBefore.ItemClick

        If (UNDO_ENABLE) Then UndoPrepare()

        lReturn = PortalExecute( _
                    "Seq:Insert:" & _
                    " seqid=" & m_active_workzoneID & _
                    ",refid=" & m_insertID & _
                    ",refba=0")

        If (UNDO_ENABLE) Then UndoCommit()

        FillSeqList()

        ' mnuJumpTo(sender, e)

    End Sub

    Private Sub optSeqMove_EditValueChanged(sender As Object, e As EventArgs) Handles optSeqMove.EditValueChanged

    End Sub

    Private Sub ChangeInsertPositionText(sTheText As String)

        Dim insertID As Long
        Dim nI As Integer

        insertID = EntityIntGet(m_active_workzoneID, "_insert_id", 0)
        For nI = 0 To TListWin1.ListCount - 1
            If TListWin1.ItemTag(nI) = insertID Then
                TListWin1.Grid.Cells(nI + 1, 1).Value.Data = sTheText
                Exit For
            End If
        Next

    End Sub

    Sub GetToolNumber(nMySeqToolNumber As Long)
        Dim clsToolData As ToolData

        'On Error Resume Next  <--- do not want to mask any errors!

        If Not g_colToolSetup Is Nothing Then
            For Each clsToolData In g_colToolSetup
                With clsToolData
                    If nMySeqToolNumber = .NC_Code_Number Then
                        m_descrip = CStr(.NC_Code_Number) '& " - (" & .Description & ")"
                    End If
                End With
            Next
        End If
    End Sub

    Private Function My_Mouse_UP(ByVal GridCell As BTIS.TList.GridCellClickArgs, ByVal Button As Integer, m_ItemIndex As Long) As Long
        Dim Item_Index
        Dim nI As Long
        Dim entityID As Long
        Dim etype As Long
        Dim PopUpPoint As Point


        Item_Index = m_ItemIndex

        If (Item_Index < 0) Then
            Exit Function
        End If

        If (Button = MouseButtons.Right) Then

            m_insertID = TListWin1.ItemTag(Item_Index)
            nInsertBackColorStore = TListWin1.ItemBackColor(Item_Index)
            nInsertForeColorStore = TListWin1.ItemForeColor(Item_Index)
            nInsertListIndex = Item_Index
            TListWin1.ItemBackColor(Item_Index) = TListWin1.SelBackColor
            TListWin1.ItemForeColor(Item_Index) = TListWin1.SelForeColor

            If (m_insertID > -1) Then
                PopUpPoint.X = System.Windows.Forms.Cursor.Position.X
                PopUpPoint.Y = System.Windows.Forms.Cursor.Position.Y

                mnuPopUp.Show(PopUpPoint)

            End If
        Else
            If (GetKeyState(Keys.ControlKey) < 0) Then

                entityID = CLng(TListWin1.ItemTag(Item_Index))
                etype = GetEntityType(entityID)
                SetSelectionFilterByType(etype)

                If (TListWin1.Selected(Item_Index) = True) Then 'TODO: SHould be checking the checked value
                    'as opposed to the Selected Value
                    modSelection.SelectEntity(entityID)
                Else
                    modSelection.DeselectEntity(entityID)
                    lReturn = PortalExecute("selector:empty:")
                End If
            Else

                If (TListWin1.Selected(Item_Index) = True) Then

                    'Doing things this way minimize ui refreshing operations.
                    lReturn = PortalExecute("*selector:clear:")
                    entityID = CLng(TListWin1.ItemTag(Item_Index))
                    etype = GetEntityType(entityID)
                    SetSelectionFilterByType(etype)
                    modSelection.SelectEntity(entityID)

                    If (GetKeyState(Keys.ShiftKey) < 0) Then
                        For nI = 0 To (TListWin1.SelItemCount - 1)
                            Item_Index = TListWin1.SelItemIndex(nI)
                            entityID = CLng(TListWin1.ItemTag(Item_Index))
                            etype = GetEntityType(entityID)
                            SetSelectionFilterByType(etype)
                            modSelection.SelectEntity(entityID)
                        Next
                    End If

                    '                'Refresh this form and the gview.
                    'SelectSynchronize()
                    'Else
                    ' modSelection.DeselectEntity(entityID)
                    'lReturn = PortalExecute("selector:empty:")

                End If
            End If

            '        'Restore the previously active selection filters.
            '        'modSelector.SetSelectionFilters (previous_state)

            frmMain.SelectionStatusUpdate(modSelection.SelectedCount())
            modView.ViewRegen()

        End If



    End Function

    Private Sub tl_SeqOrder_FocusedNodeChanged_1(sender As Object, e As FocusedNodeChangedEventArgs) Handles tl_SeqOrder.FocusedNodeChanged
        Dim nNodeID As Long

        If IsNothing(e.Node) Then
            Exit Sub
        End If

        nNodeID = e.Node.Tag

        If (nNodeID = Nothing) Then

            TListWin1.Clear()

        End If

        If (m_active_workzone_index = m_tree_index) Then Exit Sub

        If (nNodeID > 1) Then

            m_active_workzone_index = e.Node.Id
            m_active_workzone_name = e.Node.GetDisplayText(0)

            m_active_workzoneID = e.Node.Tag
            m_SeqOrderWorkZoneID = e.Node.Tag
            FillSeqList()
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TListWin1_GridCellClick(sender As Object, e As BTIS.TList.GridCellClickArgs) Handles TListWin1.GridCellClick
        Dim sMyGridCell As String
        Dim Item_Index As Long

        If TListWin1.ListCount < 1 Then
            Exit Sub
        End If


        If (My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CtrlKeyDown) Then

            Exit Sub

        End If

        Item_Index = e.Grid.RowToItemIndex(e.Row)

        lReturn = My_Mouse_UP(e, e.Button, Item_Index)

        If (e.Col = -1) Then
            sMyGridCell = ""
        Else
            sMyGridCell = e.Grid.ColTitleCellDef.Text
        End If

        Select Case sMyGridCell
            Case "Entity"
                'TListWin1.Redraw = False
                'If TListWin1.Grid.SortingMethod = 0 Then
                '    TListWin1.Grid.SortingMethod = 1
                'Else
                '    TListWin1.Grid.SortingMethod = 0
                'End If

                'TListWin1.Grid.SortingKey = 1

                'TListWin1.Grid.SortingStyle = TL_SORT_IGNORE_CASE + TL_SORT_STRING_SORT
                'TListWin1.Redraw = True
                'TListWin1.RefreshItems(0, TListWin1.ListCount - 1)
                'TListWin1.ListIndex = 0


            Case "Tool"
                'TListWin1.Redraw = False
                'If TListWin1.Grid.SortingMethod = 0 Then
                '    TListWin1.Grid.SortingMethod = 1
                'Else
                '    TListWin1.Grid.SortingMethod = 0
                'End If

                'TListWin1.Grid.SortingKey = 2

                'TListWin1.Grid.SortingStyle = TL_SORT_NUMBERS_SORT
                'TListWin1.Redraw = True
                'TListWin1.RefreshItems(0, TListWin1.ListCount - 1)
                'TListWin1.ListIndex = 0

            Case "Seq"
                'TListWin1.Redraw = False
                'If TListWin1.Grid.SortingMethod = 0 Then
                '    TListWin1.Grid.SortingMethod = 1
                'Else
                '    TListWin1.Grid.SortingMethod = 0
                'End If

                'TListWin1.Grid.SortingKey = 3

                'TListWin1.Grid.SortingStyle = TL_SORT_NUMBERS_SORT
                'TListWin1.Redraw = True
                'TListWin1.RefreshItems(0, TListWin1.ListCount - 1)
                'TListWin1.ListIndex = 0

        End Select

        If TListWin1.ListIndex >= 0 Then
            If InStr(1, TListWin1.List(TListWin1.ListIndex), "Ins.") > 0 Then
                TListWin1.Selected(TListWin1.ListIndex) = False
            End If
        End If

    End Sub

    Private Sub TListWin1_MouseDown(sender As Object, e As MouseEventArgs) Handles TListWin1.MouseDown
        Dim nx
        Dim ny
        Dim nType
        Dim Item_Index

        nx = e.X
        ny = e.Y
        nType = 1
        Item_Index = TListWin1.GetItemByXY(nx, ny, nType)

        TListWin1.EditingMode = IIf((Item_Index > 0), BTIS.TList.EditingMode.StartOnClick, BTIS.TList.EditingMode.None)

    End Sub


    Private Sub TListWin1_MouseHover(sender As Object, e As EventArgs) Handles TListWin1.MouseHover
        Dim start_id As Long
        Dim Item_Index
        Item_Index = TListWin1.GetItemByXY(MyMouseX, MyMouseY, BTIS.TList.FindByXYOptions.Item)

        If (Item_Index > -1) Then
            start_id = CLng(TListWin1.ItemTag(Item_Index))


        End If

    End Sub

    Private Sub TListWin1_MouseMove(sender As Object, e As MouseEventArgs) Handles TListWin1.MouseMove
        Dim Item_Index
        Dim sKey As String

        MyMouseX = e.X
        MyMouseY = e.Y

        Item_Index = TListWin1.GetItemByXY(e.X, e.Y, BTIS.TList.FindByXYOptions.Item)
        If (Item_Index > -1) Then

            sKey = TListWin1.ItemTag(Item_Index)
            lReturn = PortalExecute("!view:highlight:id=" & sKey)
            ToolTipController1.ReshowDelay = 5

        End If
    End Sub

    Private Sub mnuInsertAfter_Click(sender As Object, e As EventArgs) Handles mnuInsertAfter.Click
        If (UNDO_ENABLE) Then UndoPrepare()

        lReturn = PortalExecute( _
                    "Seq:Insert:" & _
                    " seqid=" & m_active_workzoneID & _
                    ",refid=" & m_insertID & _
                    ",refba=1")

        If (UNDO_ENABLE) Then UndoCommit()

        FillSeqList()

    End Sub


    Private Sub mnuInstertBefore_Click(sender As Object, e As EventArgs) Handles mnuInstertBefore.Click
        If (UNDO_ENABLE) Then UndoPrepare()

        lReturn = PortalExecute( _
                    "Seq:Insert:" & _
                    " seqid=" & m_active_workzoneID & _
                    ",refid=" & m_insertID & _
                    ",refba=0")

        If (UNDO_ENABLE) Then UndoCommit()

        FillSeqList()
    End Sub

    Private Sub mnuJumpToInsert_Click(sender As Object, e As EventArgs) Handles mnuJumpToInsert.Click
        Dim indx As Long
        Dim limit As Long
        Dim insertID As Long

        'NOTE: It is possible for the list to be
        'empty if the root node is selected.
        If (TListWin1.ListCount > 1) Then

            insertID = EntityIntGet(m_active_workzoneID, "_insert_id", 0)

            limit = TListWin1.ListCount - 1
            For indx = 1 To limit
                If (TListWin1.ItemTag(indx) = insertID) Then Exit For
            Next

            'When possible, position this insert position such
            'that it appears one down from top of list.
            ' TListWin1.Visible = False
            'TListWin1.ListIndex = 0

            If (indx = 1) Then
                TListWin1.ListIndex = 1
            ElseIf (indx <= limit) Then
                TListWin1.ListIndex = indx
            End If

            'TListWin1.Visible = True

        End If

    End Sub

    Private Sub optSeqMove_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optSeqMove.SelectedIndexChanged
        Dim Text As String
        Dim Mode As Long


        If (optSeqMove.SelectedIndex = INSERT_BEFORE) Then
            Mode = INSERT_BEFORE
            Text = "Ins. Before"
        Else
            Mode = INSERT_AFTER
            Text = "Ins. After"
        End If

        lReturn = PortalExecute( _
            "Seq:Insert:" & _
            " seqid=" & m_active_workzoneID & _
            ",insba=" & Mode)

        ChangeInsertPositionText(Text)
    End Sub

    Private Sub TListWin1_Click(sender As Object, e As EventArgs) Handles TListWin1.Click

    End Sub

    Private Sub sbExplode_Click(sender As Object, e As EventArgs) Handles sbExplode.Click

        Dim nSeqID As Long
        Dim nSeqColor As Long
        Dim nSeqLevel As Long
        Dim nSeqTool As Long
        Dim sTemp As String
        Dim nSeqType As Long
        Dim nZoneNumber As Integer
        Dim white_background As Long

        UndoPrepare()

        lReturn = PortalExecute("Pattern:Explode:all=1")

        UndoCommit()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor


        ' Add any initialization after the InitializeComponent() call.

        ' Add any initialization after the InitializeComponent() call.
        white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)

        If (white_background <> 0) Then
            m_bg_color = System.Drawing.ColorTranslator.ToOle(Color.White)
            m_fg_color = System.Drawing.ColorTranslator.ToOle(Color.Black)
        Else
            m_bg_color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            m_fg_color = System.Drawing.ColorTranslator.ToOle(Color.White)
        End If

        If (white_background <> 0) Then
            tl_SeqOrder.Appearance.Empty.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
            tl_SeqOrder.Appearance.Empty.ForeColor = System.Drawing.ColorTranslator.FromOle(m_fg_color)
            tl_SeqOrder.Columns(0).AppearanceCell.ForeColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
            tl_SeqOrder.Columns(0).AppearanceCell.BackColor = System.Drawing.ColorTranslator.FromOle(m_fg_color)

        Else
            tl_SeqOrder.Appearance.Empty.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)
            tl_SeqOrder.Appearance.Empty.ForeColor = System.Drawing.Color.Yellow
            tl_SeqOrder.Columns(0).AppearanceCell.ForeColor = Color.Yellow
            tl_SeqOrder.Columns(0).AppearanceCell.BackColor = System.Drawing.ColorTranslator.FromOle(m_bg_color)


        End If


        m_active_workzone_index = 0
        m_active_workzoneID = 0

        m_tree_index = -1

        nZoneNumber = 0

        m_insertID = -1

        tl_SeqOrder.ClearNodes()

        tl_SeqOrder.BeginUnboundLoad()


        SEQ_ROOT_NODE = tl_SeqOrder.AppendNode(New Object() {PathFile(PathCurrent)}, 0)

        lReturn = PortalExecute("*Seq:Init:")
        lReturn = PortalExecute("*Seq:Iter_init:ID=0")

        nSeqID = PortalGetInt("id", 0)
        Do While (nSeqID > 0)

            nSeqColor = PortalGetInt("color", 0)
            nSeqLevel = PortalGetInt("level", 0)
            nSeqTool = PortalGetInt("tool", 0)
            nSeqType = PortalGetInt("type", 0)

            nZoneNumber = nZoneNumber + 1

            sTemp = "WorkZone " & CStr(nZoneNumber)

            SEQ_ZONE_NODE = tl_SeqOrder.AppendNode(New Object() {sTemp}, SEQ_ROOT_NODE, nSeqID)

            lReturn = PortalExecute("*Seq:Iter_Next:")
            nSeqID = PortalGetInt("id", 0)

        Loop
        tl_SeqOrder.EndUnboundLoad()
        tl_SeqOrder.ExpandAll()

        tl_SeqOrder.EndUpdate()

        tl_SeqOrder.Refresh()
        Windows.Forms.Cursor.Current = Cursors.Default


    End Sub
End Class
