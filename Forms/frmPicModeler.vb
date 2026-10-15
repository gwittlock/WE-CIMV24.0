Public Class frmPicModeler
    Private beginLocation As Point
    Private m_figure As New VDFigure



    'To be called by a docking form (during its activation).
    Public Sub SetCurrentDialog(dlg As Form)
        m_curr_dlg = dlg
    End Sub

    Public Sub SuppressViewActivate(suppress As Boolean)
        m_suppress_view_activate = suppress
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub frmPicModeler_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        m_figure = Nothing
    End Sub

    Private Sub frmPicModeler_Load(sender As Object, e As EventArgs) Handles Me.Load
        fPicModelerForm = Me
        m_figure = New VDFigure

        'm_multiTip = New clsMultiTip
        g_shape = Nothing

        ViewSystemInvalidate()
        ViewSystemInit()
        ViewCreate(VIEW_WIRE, fPicModelerForm.picModeler.Handle)
        'lReturn = PortalExecute("admin:errors:level=1")

        m_suppress_view_activate = False

        modView.SetViewModes(VIEW_WIRE)
        modView.ViewActivate(VIEW_WIRE)

        'Show the proper icon for the app
        lReturn = SetFormIcon(Me)

    End Sub

    Private Sub frmPicModeler_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim world_pt As PortalPoint
        Dim local_pt As PortalPoint
        Dim cmd As String


        world_pt = modView.WorldPointGet(e.X, e.Y)

        local_pt = modView.MouseMove(world_pt, 1)

        cmd = "Status " & ": X " & Round(local_pt.dx, 5) & _
                "  Y " & Round(local_pt.dy, 5) & "  Z " & Round(DefaultZ)

        sbStausBarStatus.Text = cmd


    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        modModeMgmt.ModeMgmtInit()
        'ModesReset

        modMeasure.MeasureInit()

        m_curr_dlg = Nothing

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmPicModeler_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim DX As Long
        Dim DY As Long
        Dim white_background As Long
        On Error Resume Next

        Me.WindowState = FormWindowState.Maximized
        If Me.WindowState <> FormWindowState.Maximized And Me.Height > 0 And Me.Width > 0 Then

            white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)
            If (white_background <> 0) Then
                m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
                m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Black)
                picModeler.BackColor = System.Drawing.Color.White
                picModeler.ForeColor = System.Drawing.Color.Blue

            Else
                m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Black)
                m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
                picModeler.BackColor = System.Drawing.Color.Blue
                picModeler.ForeColor = System.Drawing.Color.White


            End If

            picModeler.Height = Me.Height - sbStatusBar.Height - BORDER_WIDTH
            picModeler.Top = 0
            picModeler.Left = 0
            picModeler.Width = Me.Width - BORDER_WIDTH

            'I am not sure why we have to subtract a little from the size but it gives a better pic
            'The values wee just from experimenting IE:200 and 30
            DY = picModeler.Height - Me.sbStatusBar.Height - 200
            If (DY <= 0) Then DY = picModeler.Height 'prevent crash
            picPrint.Height = DY

            DX = picModeler.Width - 30
            If (DX <= 0) Then DX = picModeler.Width
            picPrint.Width = DX  'prevent crash

            picPrint.Top = 0 '(picModeler.Height - picPrint.Height) / 2
            picPrint.Left = 0 'picModeler.Left

        End If


    End Sub

    Private Sub mnuPopupDeleteSelection_Click()
        lReturn = AppMain.ExecuteFunction(2003)
    End Sub

    Private Sub mnuPopUpEntityList_Click()
        lReturn = AppMain.ExecuteFunction(208)
    End Sub

    Private Sub mnuPopupFull_Click()
        lReturn = AppMain.ExecuteFunction(204)
    End Sub

    Private Sub mnuPopupHotSpot_Click()
        lReturn = modModeMgmt.HotDotToggle()
    End Sub

    Private Sub mnuPopupMeasure_Click()
        lReturn = ModeBegin(MODE_MEASURE)
    End Sub

    Private Sub mnuPopUpPrevious_Click()
        modView.ViewPrevious()
    End Sub

    Private Sub mnuPopupProperties_Click()
        lReturn = ModeBegin(MODE_INQUIRE)
    End Sub

    Private Sub mnuPopUpRedraw_Click()
        modView.ViewRegen()
    End Sub

    Private Sub mnuPopUpWin_Click()

        'In case we are restarting a windowing operation ...
        modView.BoxCancel()
        lReturn = ModeEnd(MODE_WINDOW)

        lReturn = ModeBegin(MODE_WINDOW)

    End Sub

    Private Sub picModeler_MouseClick(sender As Object, e As MouseEventArgs) Handles picModeler.MouseClick
        bMyButton = e.Button
    End Sub

    Private Sub picModeler_MouseDown(sender As Object, e As MouseEventArgs) Handles picModeler.MouseDown
        Dim world_pt As PortalPoint
        Dim local_pt As PortalPoint

        Try
            If (e.Button = Windows.Forms.MouseButtons.Left) Then

                'NOTE: Added by Gary Because Our User
                'are Used to holding the mouse down and then Dragging
                If (IsModeActive(MODE_WINDOW) = True) Then

                    If (modView.BoxPointCount() = 0) Then
                        world_pt = modView.WorldPointGet(e.X, e.Y)
                        lReturn = modView.BoxStart(world_pt)
                    Else
                        lReturn = modView.BoxEnd(world_pt)
                        If (modSelection.IsBoxSelectActive() = True) Then
                            lReturn = modSelection.BoxSelect( _
                                modView.BoxPointGet(0), modView.BoxPointGet(1))
                        Else
                            ''LockWindowUpdate(pnlPicmodeler.Handle)

                            lReturn = modView.ViewWindow( _
                                modView.BoxPointGet(0), modView.BoxPointGet(1))
                            ''LockWindowUpdate(0&)


                        End If
                        lReturn = ModeEnd(MODE_WINDOW)
                    End If

                ElseIf ((g_shape Is Nothing) = False) Then

                    world_pt = modView.WorldPointGet(e.X, e.Y)
                    local_pt = modView.MouseMove(world_pt, 0)

                    If (e.Button = 0) Then
                        g_shape.AnchorSet(local_pt.dx, local_pt.dy)
                    End If

                End If

                'ElseIf (Button = vbMiddleButton) Then

                If (AllowPan(e.Button, Control.ModifierKeys) = True) Then
                    If (IsModeActive(MODE_PAN) = False) Then
                        lReturn = ModeBegin(MODE_PAN)
                        lReturn = modView.ViewPanBegin(CDbl(e.X), CDbl(e.Y))
                    End If
                End If

#If ORIGINAL_CODE Then
        If (IsDialogActive() = True) Then
            If (m_curr_dlg.Name = "dlgEntity") Then lReturn = dlgEntity.Execute()
        End If
#End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub picModeler_MouseUp(sender As Object, e As MouseEventArgs) Handles picModeler.MouseUp
        Dim world_pt As PortalPoint
        Dim PopUpPoint As Point

        bMyButton = e.Button

        Try
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left

                    world_pt = modView.WorldPointGet(e.X, e.Y)

                    If (IsModeActive(MODE_WINDOW) = True) Then


                        If (modView.BoxPointCount() = 0) Then
                            lReturn = modView.BoxStart(world_pt)
                        Else
                            lReturn = modView.BoxEnd(world_pt)
                            If (modSelection.IsBoxSelectActive() = True) Then
                                lReturn = modSelection.BoxSelect( _
                                    modView.BoxPointGet(0), modView.BoxPointGet(1))
                                'We do not call ModeEnd(MODE_WINDOW) here because
                                'we want Select By Box to be modal.
                            Else
                                lReturn = modView.ViewWindow( _
                                    modView.BoxPointGet(0), modView.BoxPointGet(1))
                                lReturn = ModeEnd(MODE_WINDOW)
                            End If
                        End If

                    ElseIf (IsModeActive(MODE_PAN) = True) Then

                        'lReturn = modView.ViewPanUpdate(CDbl(X), CDbl(Y))

                        'NOTE: This statement has been commented-out because pan
                        'behavior seems more intuitive as a modal feature.  As
                        'such, you must <escape> out of pan mode.
                        lReturn = ModeEnd(MODE_PAN)
                        modView.ViewPanCancel()

                    ElseIf (IsModeActive(MODE_MEASURE) = True) Then

                        If (modMeasure.MeasurePointCount() = 0) Then
                            lReturn = modMeasure.MeasureBegin(world_pt)

                        Else
                            sReturn = modMeasure.MeasureEnd(world_pt)
                            beginLocation = e.Location
                            ExecuteMeasure(sReturn)

                        End If

                    ElseIf (IsModeActive(MODE_INQUIRE) = True) Then
                        beginLocation = e.Location
                        'We have a special branch here only because we want to
                        'prevent sending the event the any dialog that may be open.
                        ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)

                    ElseIf (IsDialogActive() = True) Then

                        '2007.03.05 (PE) -- When using forms like Edit/Zones/Manage, we must
                        'be sure that no mode is active, otherwise frmWorkZones will intercept
                        'the action (and things like entity selection will not work).
                        If (IsAnyModeActive() = True) Then

                            ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)

                        ElseIf (bIsWorkZoneLoaded = True) Then

                            lReturn = frmWorkZones.ClientMouseUp()

                        Else

                            ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)


                            If (bIsPatternBumpLoaded = False) Then

                                'Icky. frmPatternBump.ClientMouseUp() is restricted
                                'to responding to the middle mouse button (aka. accept)


                                'lReturn = m_curr_dlg.ClientMouseUp
                                lReturn = CType(m_curr_dlg, IDialogMouseUp).ClientMouseUp
                            End If

                        End If

                    Else

                        ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)


                        If (m_curr_dlg IsNot Nothing) Then
                            lReturn = CType(m_curr_dlg, IDialogMouseUp).ClientMouseUp
                        End If

                    End If

                Case Windows.Forms.MouseButtons.Right
                    PopUpPoint.X = System.Windows.Forms.Cursor.Position.X

                    PopUpPoint.Y = System.Windows.Forms.Cursor.Position.Y

                    'super incattation of right mose click for popups
                    mnuPopUp.ShowPopup(PopUpPoint)


                Case Windows.Forms.MouseButtons.Middle
                    If (IsDialogActive() = True) Then
                        If (m_curr_dlg.Name = "dlgEntity") Then lReturn = dlgEntity.Execute()
                    End If

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub ExecuteFunction(Button As Integer, Shift As Integer, x As Single, y As Single)

        Dim scrPoint As PortalPoint
        Dim lGE_RecNo As Long
        Dim start_id As Long
        Dim higher_id As Long
        Dim ConvertedPoint As PortalPoint
        Dim pick_side As Long
        Dim ent_type As Long
        Dim sToolTipText As String

        Try
            'Get the screen pick point.
            scrPoint.dx = x
            scrPoint.dy = y
            scrPoint.dZ = 0

            'Convert to model-space.
            lReturn = PortalScreenToWorld(scrPoint)

            'Get the actual model-space coordinates.  The values may
            'differ from those of scrPoint if snap behavior is active.
            lReturn = PortalExecute("!view:pick:x=" & scrPoint.dx & ",y=" & scrPoint.dy)
            m_pickX = PortalGetDouble("px", 0.0#)
            m_pickY = PortalGetDouble("py", 0.0#)
            m_pickZ = PortalGetDouble("pz", 0.0#)

            'Limit the number of digits that are displayed in a form when set
            'via ReturnClickToControl().  Note, the modeler's precision is 1.e-6.
            m_pickX = CDbl(Round(m_pickX, modMath.Places.Millionths))
            m_pickY = CDbl(Round(m_pickY, modMath.Places.Millionths))
            m_pickZ = CDbl(Round(m_pickZ, modMath.Places.Millionths))

            ConvertedPoint.dx = m_pickX
            ConvertedPoint.dy = m_pickY
            ConvertedPoint.dZ = m_pickZ

            'Get some attributes from the selected entity.
            start_id = PortalGetInt("id", 0)
            ent_type = PortalGetInt("type", c_INVALID)
            m_figure.Init(start_id, ent_type)

            pick_side = PortalGetInt("end", 0)
            PickInfoInit()
            modPick.SetPickInfo(m_figure, ConvertedPoint, 0, pick_side, CLng(Shift))

            If (IsModeActive(MODE_INQUIRE) = True) Then

                If (start_id > 0) Then

                    sToolTipText = BuildTooltip(start_id)

                    Dim args As New DevExpress.Utils.ToolTipControllerShowEventArgs()
                    'setup the SuperToolTip...
                    'args.SuperTip = superToolTip1
                    args.ToolTipType = DevExpress.Utils.ToolTipType.Standard
                    args.ToolTip = sToolTipText
                    args.ShowBeak = True
                    args.RoundRadius = 7
                    args.Rounded = True

                    Me.defaultToolTipController1.DefaultController.ShowHint(args)


                End If
            End If

            ReturnClickToControl(m_pickX, m_pickY, m_pickZ, start_id, pick_side, start_id)

            If (bIsCodeGenLoaded = True) Then

                lReturn = frmCodeGen.EchoLocation(m_pickX, m_pickY)

            ElseIf (bIsGraphicsEditorLoaded = True) Then

                higher_id = PortalGetInt("id", 0)

                'Obtain the record number of the first clfile record
                'that references the given entity. We do this because
                'the relationship between an entity and the blocks of
                'cnc code can be one-to-many.
                lReturn = PortalExecute("*codegen:xrefrecno:id=" & higher_id)
                lGE_RecNo = PortalGetInt("recno", 0)

                'NOTE: As a side effect of setting the list index,
                'frmGraphicsEditor.lstGraphicsEditor_Click() is called,
                'in turn behaving as if you selected a block of cnc code.
                If (lGE_RecNo >= 0) And (lGE_RecNo < frmGraphicsEditor.lstGraphicsEditor.Items.Count) And (lReturn = 1) Then
                    frmGraphicsEditor.lstGraphicsEditor.SelectedIndex = CInt(lGE_RecNo)
                Else
                    frmGraphicsEditor.lstGraphicsEditor.SelectedIndex = 0
                End If

            End If

            If ((modSelection.IsActive() = True) And
                 (bIsCodeGenLoaded = False)) Then

                If (start_id <> 0 And Shift <> Keys.Control) Then

                    'TODO: If frmSeqMove is open, should restrict selections to
                    'those entities that are in the currently selected work-zone.
                    lReturn = SelectEntity(start_id)

                    If (lReturn = 1) Then
                        'higher_id = PortalGetInt("id", 0)
                        If (IsSelected(start_id) = True) Then SynchronizeUI(SelectedCount())
                    End If

                ElseIf (start_id <> 0 And Shift = Keys.Control) Then
                    lReturn = DeselectEntity(start_id)
                    lReturn = PortalExecute("selector:empty:")

                    SynchronizeUI(SelectedCount())
                End If

            End If

            m_lastX = m_pickX
            m_lastY = m_pickY
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ExecuteMeasure(sToolTipText As String)

        Dim args As New DevExpress.Utils.ToolTipControllerShowEventArgs()

        Try
            args.ToolTipType = DevExpress.Utils.ToolTipType.Standard
            args.ToolTip = sToolTipText
            args.ShowBeak = True
            args.RoundRadius = 7
            args.Rounded = True

            Me.defaultToolTipController1.DefaultController.ShowHint(args)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Function IsDialogActive() As Boolean
        IsDialogActive = ((m_curr_dlg Is Nothing) = False)
    End Function

    Public Sub SynchronizeUI(Count As Long)
        Try

            If (bIsEntityLoaded = True) Then

                frmEntityList.SelectNodes()

            End If

            If (bIsSeqMoveLoaded = True) Then

                frmSeqMove.SelectSynchronize()

            End If

            modView.ViewRegen()

            SelectionStatusUpdate(Count)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub SelectionStatusUpdate(Count As Long)
        sbStatusBarSelection.Text = "Selected ( " & Count & " )"
    End Sub



    Private Sub mnuPopUpHotSpot_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpHotSpot.ItemClick

        If (mnuPopUpHotSpot.ImageIndex = 28) Then
            mnuPopUpHotSpot.ImageIndex = 149 '"Hot Spot " & IIf(modModeMgmt.IsHotDotEnabled(), "(Disable)", "(Enable)")
        Else
            mnuPopUpHotSpot.ImageIndex = 28
        End If

        lReturn = modModeMgmt.HotDotToggle()

    End Sub

    Private Sub mnuPopUpDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpDelete.ItemClick
        lReturn = appMain.ExecuteFunction(2003)
    End Sub

    Private Sub mnuPopUpEntityList_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpEntityList.ItemClick
        lReturn = appMain.ExecuteFunction(208)
    End Sub

    Private Sub mnuPopUpFull_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpFull.ItemClick
        lReturn = appMain.ExecuteFunction(204)
    End Sub

    Private Sub mnuPopUpMeasure_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpMeasure.ItemClick
        lReturn = ModeBegin(MODE_MEASURE)
    End Sub

    Private Sub mnuPopUpPrevious_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpPrevious.ItemClick
        modView.ViewPrevious()
    End Sub

    Private Sub mnuPopUpProperties_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpProperties.ItemClick
        lReturn = ModeBegin(MODE_INQUIRE)
    End Sub

    Private Sub mnuPopUpRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpRefresh.ItemClick
        modView.ViewRegen()
    End Sub

    Private Sub mnuPopUpWindow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuPopUpWindow.ItemClick
        'In case we are restarting a windowing operation ...
        modView.BoxCancel()
        lReturn = ModeEnd(MODE_WINDOW)

        lReturn = ModeBegin(MODE_WINDOW)
    End Sub

    Private Sub picModeler_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles picModeler.PreviewKeyDown

        If (e.KeyCode = Keys.Escape) Then
            MultiTipClear()
            ModeCancelCurrent()
        Else
            lReturn = appMain.ProcessKeyPress(e.KeyCode, ModifierKeys)
        End If
    End Sub
    Private Sub MultiTipClear()

        If ((IsModeActive(MODE_INQUIRE) = True) Or
            (IsModeActive(MODE_MEASURE) = True)) Then

            'm_multiTip.Clear()

        End If

    End Sub

    Private Sub picModeler_MouseMove(sender As Object, e As MouseEventArgs) Handles picModeler.MouseMove
        Dim world_pt As PortalPoint
        Dim local_pt As PortalPoint
        Dim cmd As String

        Try

            If Math.Abs(beginLocation.X - e.Location.X) > 30 OrElse Math.Abs(beginLocation.Y - e.Location.Y) > 30 Then
                Me.defaultToolTipController1.DefaultController.HideHint()
            End If

            world_pt = modView.WorldPointGet(e.X, e.Y)

            'local_pt = ViewMouseMove(world_pt, 1)

            If (IsModeActive(MODE_PAN) = True) Then

                If (AllowPan(e.Button, Control.ModifierKeys) = False) Then
                    lReturn = ModeEnd(MODE_PAN)

                    modView.ViewPanCancel()

                End If

            End If

            If (IsModeActive(MODE_PAN) = True) Then
                If (AllowPan(e.Button, Control.ModifierKeys) = False) Then
                    lReturn = ModeEnd(MODE_PAN)
                    modView.ViewPanCancel()
                End If
            End If

            If (IsModeActive(MODE_WINDOW) = True) Then

                'NOTE: This branch will be active when for any operation requiring
                'a rubberband box, like windowing and selecting entities by box.

                lReturn = modView.BoxUpdate(world_pt)


            ElseIf (IsModeActive(MODE_PAN) = True) Then

                'NOTE: The left mouse button should be down but
                'I don't think we have to check for that condition.
                'lReturn = modView.ViewPanUpdate(world_pt)
                lReturn = modView.ViewPanUpdate(CDbl(e.X), CDbl(e.Y))

            ElseIf ((g_shape Is Nothing) = False) Then

                'We use this call only to update the coordinate readout.
                local_pt = modView.MouseMove(world_pt, 0)
                lReturn = ShapeDrag(e.Button, Control.ModifierKeys, local_pt)

            Else

                local_pt = modView.MouseMove(world_pt, 1)

            End If

            cmd = "Status " & ": X " & Round(local_pt.dx, 5) &
       "  Y " & Round(local_pt.dy, 5) & "  Z " & Round(DefaultZ)

            'statusLocation.Caption = cmd


        Catch ex As Exception

        End Try

    End Sub
    Private Function ShapeDrag(Button As Integer, Shift As Integer, local_pt As PortalPoint) As Long

        Try
            If (Button = Windows.Forms.MouseButtons.Left) Then

                If (bIsPatternBumpLoaded = True) Then

                    If (frmPatternBump.IsTransferPattern = False) Then

                        If (Shift = Keys.Shift) Then
                            lReturn = g_shape.Rotate(local_pt.dx, local_pt.dy)
                            lReturn = frmPatternBump.EchoOrientation(g_shape.GetOrientation())
                        Else
                            g_shape.Move(local_pt.dx, local_pt.dy)
                        End If


                        'We execute this statement here (instead of just inside the else clause)
                        'because rotating the part about an anchor point that is *not* coincident
                        'with the handle point causes the handle point to change.
                        lReturn = frmPatternBump.EchoLocation(g_shape.GetLocation())
                    End If

                ElseIf (bIsWorkZoneLoaded = True) Then

                    g_shape.Move(local_pt.dx, local_pt.dy)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Sub picModeler_MouseWheel(sender As Object, e As MouseEventArgs) Handles picModeler.MouseWheel
        Dim pt As PortalPoint
        Dim cmd As String
        Dim factor As Double

        Try
            If ((My.Computer.Keyboard.CtrlKeyDown) And _
                (My.Computer.Keyboard.ShiftKeyDown)) Then

                lReturn = IsModeActive(MODE_ZOOM) = True

                If (IsModeActive(MODE_ZOOM) = False) Then
                    lReturn = ModeBegin(MODE_ZOOM)
                End If

                'Hack to get around conversion of Xpos,Ypos (which I don't know how to do).
                pt = modView.MousePosition()
                lReturn = PortalLocalToWorld(pt)

                'factor = IIf((Rotation > 0), VIEW_ZOOM_FACTOR, (1# / VIEW_ZOOM_FACTOR))
                factor = IIf((e.Delta > 0), (1.0# / VIEW_ZOOM_FACTOR), VIEW_ZOOM_FACTOR)

                LockWindowUpdate(frmMain.pnlPicmodeler.Handle)
                cmd = "!View:Zoom: " & _
                      " factor=" & factor & _
                      ",x=" & pt.dx & _
                      ",y=" & pt.dy

                lReturn = PortalExecute(cmd)
                LockWindowUpdate(0&)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub picModeler_Paint(sender As Object, e As PaintEventArgs) Handles picModeler.Paint
        modView.ViewShow()
    End Sub

    Private Sub picModeler_Resize(sender As Object, e As EventArgs) Handles picModeler.Resize
        modView.ViewResize()
    End Sub

    Public Sub HideCombos()
        'fraCombos.visible = False
    End Sub

End Class