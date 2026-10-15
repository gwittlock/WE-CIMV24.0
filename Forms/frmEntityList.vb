Imports DevExpress.Utils
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.ViewInfo

Public Class frmEntityList
    Private CFG_ROOT_NODE = Nothing
    'Private m_multiTip As clsMultiTip
    Dim bUserClick As Boolean
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
        'IsActive = True
    End Function

    Private Sub frmEntityList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False

        frmMain.CloseFirstPanel()
        'm_multiTip = Nothing


    End Sub

    '    Private Sub frmEntityList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub frmEntityList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim white_background As Long

        tvwEntityList.ClearNodes()

        white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)

        If (white_background <> 0) Then
            m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Black)
            m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
        Else
            m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
            m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
        End If

        bUserClick = True ' enable "normal" processing
        InitFilterCombo()

        m_is_active = True




    End Sub

    Public Sub New()
        Dim white_background As Long

        m_is_active = False

        ' This call is required by the designer.
        InitializeComponent()
        m_is_active = True

        white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)

        If (white_background <> 0) Then
            m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
            m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Black)
        Else
            m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Black)
            m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
        End If

        Me.tvwEntityList.Appearance.Empty.BackColor = System.Drawing.ColorTranslator.FromWin32(m_bg_color)
        Me.tvwEntityList.Appearance.Empty.Options.UseBackColor = True

    End Sub

    Private Sub InitFilterCombo()

        ' Clearing the combobox
        cbeEntityList.Properties.Items.Clear()
        cbeEntityList.Properties.Items.Add("Everything")
        cbeEntityList.Properties.Items.Add("Toolpath")
        cbeEntityList.SelectedIndex = 0

    End Sub
    Public Sub SelectNodes()

        Dim entityID As Long
        Dim etype As Long = 0
        Dim my_node As TreeListNode = Nothing
        Dim node As TreeListNode


        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            For Each node In tvwEntityList.Nodes

                entityID = node.GetValue("currID")

                node.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

                If node.HasChildren = True Then

                    For Each child As TreeListNode In node.Nodes

                        entityID = child.GetValue("currID")

                        child.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

                        If child.HasChildren = True Then

                            For Each childSubNode As TreeListNode In child.Nodes

                                entityID = childSubNode.GetValue("currID")

                                childSubNode.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

                                If childSubNode.HasChildren = True Then

                                    For Each childSub2Node As TreeListNode In childSubNode.Nodes

                                        entityID = childSub2Node.GetValue("currID")

                                        childSub2Node.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

                                    Next

                                End If
                            Next

                        End If

                    Next

                End If

            Next node

            frmMain.statusSelection.Caption = "Selected ( " & SelectedCount() & " )"

            Windows.Forms.Cursor.Current = Cursors.Default

            Exit Sub

            For Each foo As TreeListNode In tvwEntityList.Nodes
                entityID = node.GetValue("currID")

                etype = GetEntityType(entityID)
                SetSelectionFilterByType(etype)

                'NOTE: Selecting a container-type entity
                'causes its children to be selected as well.
                lReturn = modSelection.SelectEntity(entityID)
                node.CheckState = CheckState.Checked

                If node.HasChildren = True Then
                    For Each child As TreeListNode In node.Nodes
                        child.CheckState = CheckState.Checked

                        For Each childnode As TreeListNode In child.Nodes
                            childnode.CheckState = CheckState.Checked

                            my_node = childnode

                            If (my_node.HasChildren = True) Then

                                For Each childnode1 As TreeListNode In my_node.Nodes
                                    childnode1.CheckState = CheckState.Checked

                                Next

                            End If

                        Next

                    Next

                End If

            Next foo

            frmMain.statusSelection.Caption = "Selected ( " & SelectedCount() & " )"

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Public Sub FillTreeView(Optional sFilter As String = "")
        Dim lCount As Long
        Dim Count As Long
        Dim entityID As Long
        Dim entitytype
        Dim lId As Long
        Dim lColor As Long
        Dim lParentID As Long
        Dim sName As String
        Dim lToolID As Long
        Dim sLayerName As String
        Dim objNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim objParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode

        Try

            If Not Me.Visible Then Exit Sub

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            'Clear the treeview

            tvwEntityList.ClearNodes()
            tvwEntityList.BeginUnboundLoad()


            ' Getting the number of entities
            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            ' initialize the filter combobox
            'bUserClick = False ' disable "normal" processing

            For lCounter = 0 To (lCount - 1)
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)

                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any

                lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                Count = PortalGetInt("count", 0)

                If (Count > 0) Then 'We check the child entities to see if they are part of the table graphics

                    lReturn = PortalExecute( _
                                "*Entity:Container:Get:" & _
                                " id=" & lId & _
                                ",index=1")
                    entityID = PortalGetInt("id", 0)
                    entitytype = GetEntityType(entityID)
                    lReturn = PortalExecute("*create:extract:id=" & entityID)

                    lToolID = PortalGetInt("toolid", 0)

                End If

                sLayerName = EntityStringGet(lToolID, "Name", "<error>")
                lColor = EntityIntGet(lId, "color", 16711680)


                If (sLayerName = "TableGraphics") Then GoTo skip 'We do not want to show tablegrahics in the list

                sName = GetDisplayName(lId)

                If sName = "Line" Then
                    Dim gary As Integer = 1
                End If
                ' does the filter entry already exist?
                If Not CheckEntryToList(sName, cbeEntityList) Then
                    cbeEntityList.Properties.Items.Add(sName)
                End If

                If (lColor = 0) Then
                    lColor = m_fg_color

                End If
                If (sName.Contains("Empty") = True) Then
                    'GoTo skip
                    lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & lId)
                    'lReturn = PortalExecute("Zone:Update: id=" & lId & ",delete=1")
                    'lReturn = PortalExecute("Create:Delete: id=" & lId)
                End If


                ' does the filter allow the addition of this entity?
                If Len(sFilter) = 0 Or _
                    sFilter = sName Or _
                        sFilter = "Everything" Or _
                        (sFilter = "Toolpath" And lToolID > 0) Then

                    If (sName <> "Feature(Empty)") Then
                        ' add entity to treeview
                        objParentNode = tvwEntityList.FindNodeByFieldValue(tvwEntityList.Columns(1).FieldName, lParentID)

                        If objParentNode IsNot Nothing Then

                            objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, objParentNode.Id, lColor}, objParentNode.Id, "uid_" & CStr(lId))

                        Else

                            objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, 0, lColor}, -1, "uid_" & CStr(lId))

                        End If
                    Else
                        'we do not want any empty features so we delte them to be sure
                        lReturn = PortalExecute("Create:Delete: id=" & lId)

                    End If

                End If
skip:

            Next
            tvwEntityList.Columns(1).Visible = False
            tvwEntityList.Columns(2).Visible = False
            tvwEntityList.Columns(3).Visible = False
            tvwEntityList.Columns(4).Visible = False



            tvwEntityList.EndUnboundLoad()
            SelectNodes()



            '
        Catch ex As Exception
            MessageBox.Show("FillTreView: " & ex.Message)
        End Try
    End Sub

    Private Sub cbeEntityList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeEntityList.SelectedIndexChanged

        If bUserClick Then FillTreeView(cbeEntityList.EditValue)

    End Sub

    Private Sub tvwEntityList_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tvwEntityList.AfterCheckNode
        Dim entityID As Long
        Dim etype As Long

        entityID = e.Node.GetValue("currID")
        etype = GetEntityType(entityID)
        SetSelectionFilterByType(etype)

        If (e.Node.CheckState = CheckState.Checked) Then

            lReturn = modSelection.SelectEntity(entityID)

        Else

            lReturn = modSelection.DeselectEntity(entityID)

        End If
        modView.ViewRefresh()

    End Sub

    Private Sub tvwEntityList_BeforeCheckNode(sender As Object, e As DevExpress.XtraTreeList.CheckNodeEventArgs) Handles tvwEntityList.BeforeCheckNode
        Dim entityID As Long
        Dim etype As Long

        entityID = e.Node.GetValue("currID")
        etype = GetEntityType(entityID)
        SetSelectionFilterByType(etype)

        If (e.Node.Selected = True) Then

            lReturn = modSelection.SelectEntity(entityID)

        Else

            lReturn = modSelection.DeselectEntity(entityID)

        End If
    End Sub

    Private Sub tvwEntityList_MouseMove(sender As Object, e As MouseEventArgs) Handles tvwEntityList.MouseMove
        Dim entityID As Long

        Dim hit As TreeListHitInfo = tvwEntityList.CalcHitInfo(e.Location)

        If (IsNothing(hit.Node) = False) Then

            entityID = hit.Node.GetValue("currID")

            lReturn = PortalExecute("!view:highlight:id=" & entityID)

        End If


    End Sub




    Private Sub tvwEntityList_NodeCellStyle(sender As Object, e As DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs) Handles tvwEntityList.NodeCellStyle
        e.Appearance.ForeColor = ColorTranslator.FromOle(CInt(e.Node.GetDisplayText(4)))

        e.Appearance.BackColor = Color.Black
        Me.tvwEntityList.Appearance.Empty.BackColor = System.Drawing.Color.Black
        Me.tvwEntityList.Appearance.Empty.Options.UseBackColor = True

    End Sub

    Private Sub bbAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        SelectNodes()

        modView.ViewRegen()
    End Sub

    Private Sub bbRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRemove.ItemClick
        UnselectNodes()
        modView.ViewRegen()
    End Sub

    Private Sub UnselectNodes()
        Dim entityID As Long
        Dim etype As Long

        Cursor.Current = Cursors.WaitCursor

        'Allow both parent and children to be deselected.
        SelectorRestrictions(False)

        For Each node As TreeListNode In tvwEntityList.Selection
            entityID = node.GetValue(currID)
            etype = GetEntityType(entityID)
            SetSelectionFilterByType(etype)

            'NOTE: Deselecting a container-type entity
            'causes its children to be deselected as well.
            lReturn = modSelection.DeselectEntity(entityID)
        Next

        frmMain.statusSelection.Caption = "Selected ( " & SelectedCount() & " )"

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub toolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipController1.GetActiveObjectInfo

        Dim nEntityID As Long

        Try
            If TypeOf e.SelectedControl Is DevExpress.XtraTreeList.TreeList Then
                Dim tree As TreeList = CType(e.SelectedControl, TreeList)
                Dim hit As TreeListHitInfo = tree.CalcHitInfo(e.ControlMousePosition)

                If (IsNothing(hit.Node) = False) Then
                    'If hit.HitInfoType = HitInfoType.Column Then
                    Dim cellInfo As Object = New TreeListCellToolTipInfo(hit.Node, hit.Column, Nothing)
                    nEntityID = hit.Node.GetValue("currID")

                    Dim toolTip As String = BuildTooltip(nEntityID)
                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip)
                    'End If
                End If

            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

End Class
