Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class frmPatternBump
    Private m_is_active As Boolean
    Private m_orientation As Double
    Private m_usage As Long  '(0) Move / (1) Copy

    Private m_is_view_initialized As Boolean

    Private m_instance_id As Long
    Private m_pattern_id As Long
    Private m_is_pattern As Boolean
    Private m_part_id As Long
    Private PatternData As List(Of ThePatternData)
    Dim sTransSheetName As String

    Private foo As Integer = 0
    Const MOVE_BUTTON = 0
    Const COPY_BUTTON = 1
    Private Const DESKTOPVERTRES As Integer = &H75
    Private Const DESKTOPHORZRES As Integer = &H76
    Private FromTransfer As Boolean

    <DllImport("gdi32.dll")> Private Shared Function GetDeviceCaps(ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer
    End Function
    Public Function ClientMouseUp() As Long

    End Function
    Public Class ThePatternData
        Private nPatid As Integer
        Public Property PatternID() As Integer
            Get
                Return nPatid
            End Get
            Set(ByVal value As Integer)
                nPatid = value
            End Set
        End Property
        Private dPatAng As Double
        Public Property PatternAngle() As Double
            Get
                Return dPatAng
            End Get
            Set(ByVal value As Double)
                dPatAng = value
            End Set
        End Property
        Private sPatLabel As String
        Public Property PatternLabel() As String
            Get
                Return sPatLabel
            End Get
            Set(ByVal value As String)
                sPatLabel = value
            End Set
        End Property
    End Class

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
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
    Public Function IsTransferPattern() As Boolean

        Try

            IsTransferPattern = False

            If (cbeSheets.Text <> PathCurrent() And FileTypeGet(PathExt(PathCurrent())) <> FILE_MM2) Then
                IsTransferPattern = True
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try


    End Function


    Private Sub frmPatternBump_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try

            cmdCancel_core()

            bIsPatternBumpLoaded = False

            frmMain.CloseFirstPanel()
            modView.ViewResize()
            m_is_active = False

            If (cmdCancel.Enabled) Then
                'cmdCancel_core()
            End If

            'Otherwise, cursor clipping does bad
            'things to cursor travel limits ;-(
            g_shape = Nothing

            bDraggingPattern = False

            modSelection.DeselectAll()

            modView.ViewActivate(VIEW_WIRE)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    '    Private Sub frmPatternBump_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub


    Private Sub frmPatternBump_Load(sender As Object, e As EventArgs) Handles Me.Load

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            bIsPatternBumpLoaded = True

            picPattern.Left = Me.nbcPatterns.Right - picPattern.Width
            picPattern.Top = Me.Top + 5

            Me.Width = 502


            Me.Refresh()

            Me.SuspendLayout()

            OptMoveCopy.SelectedIndex = 0
            g_shape = Nothing

            mtbOrientation.Text = m_orientation

            m_is_active = True

            Select Case FileTypeGet(PathExt(PathCurrent()))
                Case FILE_MM2

                    AddGroupItems(FILE_MM2)


                Case FILE_NST

                    cbeSheets.SelectedIndex = SheetComboPopulate(PathCurrent(), cbeSheets)

            End Select

            Me.ResumeLayout()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub


    Private Sub frmPatternBump_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        'Disable raising mtbOrientation_Change
        mtbOrientation.Suppressed = True

    End Sub

    Private Sub AddGroupItems(nFileType As Integer)
        Dim item As DevExpress.XtraNavBar.NavBarItem
        Dim ni As Integer
        Dim iMyImage As System.Drawing.Image
        Dim group As DevExpress.XtraNavBar.NavBarGroup
        Dim sLibIcon As String
        Dim pattern_name As String
        Dim pattern_id As Long
        Dim cnt As Long
        Dim indx As Long
        Dim partidnum As Long
        Dim pat_angle As Double
        Dim cmd As String
        Dim sImageName As String
        Dim TagString As String = Nothing

        Try

            frmMain.Cursor = Cursors.WaitCursor
            lstPattern.Items.Clear()

            nbcPatterns.Groups.Clear()

            ImageCollection1.Clear()

            'Dim dir As New System.IO.DirectoryInfo(App_Path & "\PatternImages\")
            Dim dir As New System.IO.DirectoryInfo(PathTempFolder() & "PatternImages\")
            Dim count As Integer = dir.GetFiles().Length

            If (count > 0) Then

                Kill(PathTempFolder() & "PatternImages\*.png")
            End If


            group = nbcPatterns.Groups.Add()

            group.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList
            group.Caption = "Current Patterns"



            nbcPatterns.ActiveGroup = group

            picPattern.Visible = True


            g_shape = Nothing
            lReturn = frmMain.Reinit()

            Dim sTheNestFile As String = PathCurrent()



            lReturn = PortalExecute("*Model:EntityCount: type=" & c_DBPATTERN)
            cnt = PortalGetInt("count", 0)

            If (cnt > 0) Then

                picPattern.Visible = True

                ni = 0

                For indx = 0 To (cnt - 1)
                    picPattern.Refresh()
                    lReturn = PortalExecute("*Model:Get2: indx=" & indx & ", type=" & c_DBPATTERN)
                    pattern_id = PortalGetInt("id", 0)
                    pattern_name = EntityStringGet(pattern_id, "_label", "<error>")

                    partidnum = EntityIntGet(pattern_id, "Part_ID", 0)

                    pat_angle = EntityDoubleGet(pattern_id, "part_angle", 0)

                    pat_angle = Radians2Degrees(pat_angle)


                    lReturn = GetPatternImage(pattern_id, True)

                    cmd = "nest:manual:instance: opt=" & BUMP_CANCEL

                    lReturn = PortalExecute(cmd)

                    lReturn = frmMain.Reinit()

                    sImageName = PathTempFolder() & "PatternImages\" & pattern_name & ".png"

                    lstPattern.Items.Add(sImageName)


                    iMyImage = Image.FromFile(sImageName, True)
                    ImageCollection1.Images.Add(iMyImage, pattern_name)

                    iMyImage.dispose()

                    sLibIcon = pattern_name
                    item = nbcPatterns.Items.Add()
                    item.Caption = "Pattern " & sLibIcon
                    item.Name = sLibIcon

                    If (nFileType = FILE_MM2) Then

                        TagString = CHR1 & "ImageName" & CHR2 & sImageName & _
                            CHR1 & "PatternName" & CHR2 & pattern_name & _
                            CHR1 & "PatternID" & CHR2 & pattern_id & _
                            CHR1 & "PartID" & CHR2 & partidnum & _
                            CHR1 & "PatternAngle" & CHR2 & pat_angle & _
                            CHR1 & "PartName" & CHR2 & pattern_name

                    ElseIf (nFileType = FILE_NST) Then

                        TagString = CHR1 & "ImageName" & CHR2 & sImageName & _
                            CHR1 & "PatternName" & CHR2 & pattern_name & _
                            CHR1 & "PatternID" & CHR2 & pattern_id & _
                            CHR1 & "PartID" & CHR2 & partidnum & _
                            CHR1 & "PatternAngle" & CHR2 & pat_angle & _
                            CHR1 & "PartName" & CHR2 & GetFilenameFromPatternID(partidnum)

                    End If


                    item.Tag = TagString


                    item.SmallImageIndex = ImageCollection1.Images.Keys.IndexOf(sLibIcon)

                    item.LargeImageIndex = item.SmallImageIndex

                    nbcPatterns.ActiveGroup.ItemLinks.Add(item)

                Next


                picPattern.Visible = False

                frmMain.Cursor = Cursors.Default



            End If



        Catch ex As Exception

            MessageBox.Show("AddGroupItems: " & ex.Message)

        End Try

    End Sub

    Private Sub OptMoveCopy_EditValueChanged(sender As Object, e As EventArgs) Handles OptMoveCopy.EditValueChanged
        m_usage = IIf((OptMoveCopy.SelectedIndex = 1), COPY_BUTTON, MOVE_BUTTON)
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        bDraggingPattern = False

        Me.chkbUseSelected.Checked = False
        chkbUseSelected.Invalidate()
        cmdCancel_core()
        chkbUseSelected.Checked = False

    End Sub
    Private Sub cmdCancel_core()

        Dim cmd As String
        Dim entity_id As Long

        Try

            cmdTransfer.Enabled = False

            If (m_is_pattern = True) Then
                entity_id = m_pattern_id
            Else
                entity_id = m_instance_id
            End If

            'The final positional attributes should be properly reflected in the dialog(?)
            cmd = "nest:manual:instance: opt=" & BUMP_CANCEL

            lReturn = PortalExecute(cmd)

            lReturn = Reinit()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Function Reinit() As Long

        m_instance_id = 0
        m_pattern_id = 0
        m_is_pattern = False

        pnlBumpSheetsPic.Refresh()

        g_shape = Nothing
        modSelection.DeselectAll()

        OptMoveCopy.Properties.Items(MOVE_BUTTON).Enabled = True
        OptMoveCopy.Properties.Items(COPY_BUTTON).Enabled = True

        EnableOkButton()

        Reinit = 1

    End Function
    Private Function GetPatternImage(entity_id As Long, is_pattern As Boolean) As Long
        'NOTE: is_pattern is True only when selecting from a list.
        Dim cmd As String
        Dim entity_type As Long
        Dim picH As Long
        'Dim bounds As Rectangle = picPattern.Bounds
        'Dim pt As Point = picPattern.PointToScreen(bounds.Location)
        'Dim myBitmap As New Bitmap(bounds.Width, bounds.Height)
        Dim sPattern_Name As String
        Dim sImageFilename As String



        Try

            GetPatternImage = 0  'assume failure.


            If ((g_shape Is Nothing) = True) Then

                lReturn = PortalExecute("*create:extract:id=" & entity_id)
                entity_type = PortalGetInt("type", c_INVALID)
                If ((entity_type <> c_DBCOMMAND) And _
                    (entity_type <> c_DBPATTERN)) Then
                    Exit Function
                End If

                'Selecting a new instance should clear the previous reference.
                g_shape = Nothing
                lReturn = modSelection.DeselectAll

                picH = picPattern.Handle


                If (bDo_BumpDrag = True) Then
                    'picPattern.Visible = False
                End If


                cmd = "nest:manual:instance:" & _
                    " opt=" & BUMP_INIT & _
                    ",id=" & entity_id & _
                    ",hwnd=" & picH


                If (is_pattern = True) Then
                    cmd = cmd & ",pattern=1"
                    m_instance_id = 0
                Else
                    m_instance_id = entity_id
                End If

                lReturn = PortalExecute(cmd)

                m_pattern_id = PortalGetInt("pattern_id", 0)

                sPattern_Name = EntityStringGet(m_pattern_id, "_label", "<error>")


                sImageFilename = PathTempFolder() & "PatternImages\" & sPattern_Name & ".png"

                If (m_pattern_id > 0 And FileExists(sImageFilename) = False) Then

                    'Using m_g As Graphics = Graphics.FromImage(myBitmap)

                    '    m_g.CopyFromScreen(New Point(pt.X - picPattern.Location.X, pt.Y - picPattern.Location.Y), Point.Empty, bounds.Size)

                    '    m_g.Dispose()

                    'End Using

                    ''myBitmap.Save(sImageFilename)

                    'myBitmap.Dispose()

                    g_shape = Nothing
                    g_shape = New clsShape

                    GetPatternImage = ((g_shape Is Nothing) = False)

                    '**********************************************
                    Dim Xscale As Double = 1.0
                    Dim Yscale As Double = 1.0

                    Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
                        Dim hDc As IntPtr = g.GetHdc
                        Xscale = (GetDeviceCaps(hDc, DESKTOPHORZRES) / Screen.PrimaryScreen.Bounds.Width)
                        Yscale = (GetDeviceCaps(hDc, DESKTOPVERTRES) / Screen.PrimaryScreen.Bounds.Height)
                        g.ReleaseHdc(hDc)
                    End Using

                    Dim picBounds As New Rectangle(Me.PointToScreen(picPattern.Location), picPattern.Size)
                    picBounds.X = CInt(picBounds.X * Xscale)
                    picBounds.Y = CInt(picBounds.Y * Yscale)
                    picBounds.Width = CInt(picBounds.Width * Xscale)
                    picBounds.Height = CInt(picBounds.Height * Yscale)

                    Using bm As New Bitmap(picBounds.Width, picBounds.Height)
                        Using g As Graphics = Graphics.FromImage(bm)
                            g.CopyFromScreen(picBounds.Location, Point.Empty, picBounds.Size, CopyPixelOperation.SourceCopy)
                            bm.Save(sImageFilename, Imaging.ImageFormat.Png)
                        End Using
                    End Using
                    '**********************************************

                End If

            End If


        Catch ex As Exception

            MessageBox.Show("GetPatternImage: " & ex.Message)

        End Try

    End Function

    Private Sub cbeSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeSheets.SelectedIndexChanged
        Dim hPicHandle As Long
        Dim lViewerID As Long
        Dim cmd As String
        'Dim directory As String = App_Path & "\PatternImages\"
        'Dim di As New IO.DirectoryInfo(directory)
        'Dim diar1 As IO.FileInfo()
        'Dim dra As IO.FileInfo

        Try


            If (cbeSheets.SelectedIndex >= 0) Then
                If (cbeSheets.Text = PathCurrent()) Then
                    GoTo AddThePatterns
                End If
                hPicHandle = pnlBumpSheetsPic.Handle

                lReturn = vbModelSwap(1)
                lReturn = PortalExecute("view:new:type=1,wnd=" & hPicHandle)

                'If (lReturn <> 0) Then
                lViewerID = PortalGetInt("id", 0)
                lReturn = PortalExecute("!view:select:id=" & lViewerID)

                cmd = "!view:mode:" & _
                              " id=" & lViewerID & _
                              ",profmark=0" & _
                            ",tooldash=0" & _
                            ",text=0" & _
                            ",mono=0" & _
                            ",legend=0" & _
                            ",handles=0" & _
                            ",stock=0" & _
                            ",workzones=0"

                lReturn = PortalExecute(cmd)


                lReturn = PortalExecute("*file:importmm2:file=" & QStr(cbeSheets.Text) & ",preview=1")

                modView.ViewFull()


            End If
AddThePatterns:


            'cmdCancel_core()

            'ViewActivate(VIEW_WIRE)
            If (cbeSheets.SelectedItem.ToString() <> PathCurrent()) Then
                modView.ViewActivate(VIEW_PREVIEW)
            Else
                modView.ViewActivate(VIEW_WIRE)
            End If
            AddGroupItems(FILE_NST)
        Finally
            'Catch ex As Exception

            'MessageBox.Show("cbeSheets_SelectedIndexChanged " & ex.Message)

        End Try

    End Sub

    Private Sub cbeSheets_TextChanged(sender As Object, e As EventArgs) Handles cbeSheets.TextChanged
        If (cbeSheets.Text = PathCurrent()) Then
            cmdTransfer.Enabled = False
        Else
            cmdTransfer.Enabled = True

        End If

    End Sub

    Private Sub chkbUseSelected_CheckedChanged(sender As Object, e As EventArgs) Handles chkbUseSelected.CheckedChanged
        If (chkbUseSelected.Checked = True) Then

            bDraggingPattern = False

            ' cmdCancel_core()
            m_pattern_id = 0
            OptMoveCopy.Properties.Items(MOVE_BUTTON).Enabled = True
            OptMoveCopy.Properties.Items(COPY_BUTTON).Enabled = True


        Else
            OptMoveCopy.Properties.Items(0).Enabled = False
        End If
    End Sub

    Private Sub nbcPatterns_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbcPatterns.LinkClicked

        bDraggingPattern = True
        If (cbeSheets.SelectedItem.ToString() <> PathCurrent()) Then
            modView.ViewActivate(VIEW_PREVIEW)
        Else
            modView.ViewActivate(VIEW_WIRE)
        End If
        OptMoveCopy.Properties.Items(MOVE_BUTTON).Enabled = False
        chkbUseSelected.Checked = False
        chkbUseSelected.Invalidate()
        Dim mytag As String = e.Link.Item.Tag
        Dim nPatId = GetValueFromDelimitedData(e.Link.Item.Tag, "PatternID", 0)

        lReturn = ShapeInit(nPatId, True)


    End Sub
    'NOTE: is_pattern is True only when selecting from a list.
    Public Function ShapeInit(entity_id As Long, is_pattern As Boolean) As Long
        Dim picH As Long
        Dim cmd As String
        Dim tmp As Double
        Dim entity_type As Long

        ShapeInit = 0  'assume failure.

        If ((g_shape Is Nothing) = True) Then

            '2005.11.26 (PE) -- Prior to this change, it was possible that a
            'mouse-up event (while dragging a part) returned the id of something
            'like a curve.  This caused the 'Drop' button to be inadvertantly
            'disabled.  This undesirable behavior might still be a problem if
            'the mouse-up event is received when the cursor is positioned over
            'the handle point of an instance.  I guess we'll solve that problem
            'when it arises :-(
            lReturn = PortalExecute("*create:extract:id=" & entity_id)
            entity_type = PortalGetInt("type", c_INVALID)
            If ((entity_type <> c_DBCOMMAND) And _
                (entity_type <> c_DBPATTERN)) Then
                Exit Function
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            'Selecting a new instance should clear the previous reference.
            g_shape = Nothing
            lReturn = modSelection.DeselectAll

            pnlBumpSheetsPic.Refresh()
            picH = pnlBumpSheetsPic.Handle


            cmd = "nest:manual:instance:" & _
                " opt=" & BUMP_INIT & _
                ",id=" & entity_id & _
                ",hwnd=" & picH

            If (is_pattern = True) Then
                cmd = cmd & ",pattern=1"
                m_instance_id = 0
            Else
                m_instance_id = entity_id
            End If

            lReturn = PortalExecute(cmd)

            m_pattern_id = PortalGetInt("pattern_id", 0)
            m_part_id = PortalGetInt("part_id", 0)

            If (m_pattern_id <> 0) Then

                m_is_pattern = is_pattern

                tmp = PortalGetDouble("xp", 0.0#)
                tbHandleX.Text = Round(tmp, Places.TenThousandths)

                tmp = PortalGetDouble("yp", 0.0#)
                tbHandleY.Text = Round(tmp, Places.TenThousandths)

                tmp = PortalGetDouble("part_angle", 0.0#)
                mtbOrientation.Text = Round((tmp * RAD2DEG), Places.Tenths)

                'CRITICAL: We must defer setting g_shape until after the
                'dialogs controls have been initialized. Otherwise, we crash
                'with the nasty (and difficult to diagnose) error:
                '
                '  Run-time error -2147417848 (80010108)
                '  Automation error.
                '  The object invoked has disconnected from its clients.
                '
                'This is true because the preceding statement:
                '  mtbOrientation.Text = Round((tmp * RAD2DEG), Tenths)
                'has the side effect of calling mtbOrientation_Change()
                '
                g_shape = New clsShape
                lReturn = g_shape.PartInit()

            End If

            Windows.Forms.Cursor.Current = Cursors.Default

            EnableOkButton()

            ShapeInit = ((g_shape Is Nothing) = False)

        End If

    End Function
    Private Sub EnableOkButton()
        Exit Sub
        cmdDrop.Enabled = ((g_shape Is Nothing) = False)
        cmdCancel.Enabled = cmdDrop.Enabled


        If (chkbUseSelected.Checked = True) Then
            cmdDelete.Enabled = cmdDrop.Enabled
        Else
            cmdDelete.Enabled = False
        End If

        mtbOrientation.Enabled = cmdDrop.Enabled
        nbcPatterns.Enabled = Not cmdDrop.Enabled

        If (cbeSheets.Text <> PathCurrent()) Then
            If (nbcPatterns.Groups(0).SelectedLinkIndex < 0) Then
                cmdTransfer.Enabled = False
            Else
                cmdTransfer.Enabled = True
            End If

            cmdDrop.Enabled = False
        End If

    End Sub
    Public Function EchoLocation(world_pt As clsCoord3d) As Long

        tbHandleX.Text = Round(Val(world_pt.x), Places.TenThousandths)
        tbHandleY.Text = Round(world_pt.y, Places.TenThousandths)

        'Arrrrrgh, VB does not update the text field unless we refresh.
        tbHandleX.Refresh()
        tbHandleY.Refresh()


        EchoLocation = 1 'fodder

    End Function

    Public Function EchoOrientation(degrees As Double) As Long

        'We suppress raising mtbOrientation_Change() because it calls g_shape.Rotate() again.
        mtbOrientation.Suppressed = True
        mtbOrientation.Text = Round(degrees, Places.Tenths)
        mtbOrientation.Suppressed = False

        'Arrrrrgh, VB does not update the text field unless we refresh.
        Refresh()

        EchoOrientation = 1 'fodder

    End Function

    Private Sub FindLengendTextAndUpdate(Part_ID As Long, NST_Name As String, Old_Qty As Integer, New_Qty As Long)
        Dim cnt As Long
        Dim indx As Long
        Dim sData As String
        Dim cmd_ID As Long
        Dim pdb_file As String
        Dim Part_Name As String = Nothing
        Dim srch_string As String
        Dim replace_string As String
        Dim New_Cmd_Text As String
        Dim cmd As String
        Dim mat_length As Double
        Dim mat_width As Double
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer


        pdb_file = HeaderStringGet("pdb_file", "")
        mat_length = HeaderDoubleGet("Length", 0)
        mat_width = HeaderDoubleGet("Width", 0)

        If (FileExists(pdb_file) = True) Then

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & pdb_file & "';"

            sql = "Select * From [Part Result] Where ([Part Result].[Sheet Filename] = '" & _
             PathNST() & "' ) And ([Part Result].[Part ID] = " & Part_ID & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(dsParts)

            oledbAdapter.Dispose()

            connection.Dispose()
            connection.Close()

            cnt2 = dsParts.Tables(0).Rows.Count

            If (cnt2 > 0) Then

                Part_Name = dsParts.Tables(0).Rows(0).Item("Part Name")

            End If

            dsParts.Dispose()

            If dsParts IsNot Nothing Then dsParts = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        End If

        lReturn = PortalExecute("*Model:EntityCount: type=" & c_DBCOMMAND)
        cnt = PortalGetInt("count", 0)

        For indx = 0 To (cnt - 1)

            lReturn = PortalExecute("*Model:Get2: indx=" & indx & ", type=" & c_DBCOMMAND)

            cmd_ID = PortalGetInt("id", 0)

            lReturn = PortalExecute("*create:extract:id=" & cmd_ID) ' Getting other info about entity

            sData = PortalGetString("text", "")

            If (InStr(1, sData, "Cutback") > 0) Then

                srch_string = Part_Name & " - " & Old_Qty
                replace_string = Part_Name & " - " & New_Qty


                If (InStr(1, sData, srch_string) > 0) Then
                    'Replace the string wit the new quantity
                    New_Cmd_Text = Trim(Replace(sData, srch_string, replace_string))

                    cmd = "create:command:id=" & cmd_ID & "," &
                        " x=" & mat_length &
                        ",y=" & mat_width &
                        ",z=0" &
                        ",pos=0" &
                        ",angle=0" &
                        ",cmd=" & QStr(New_Cmd_Text)
                Else
                    New_Cmd_Text = sData & " T. " & Part_Name & " - 1 of 1" & vbLf

                    cmd = "create:command:id=" & cmd_ID & "," &
                        " x=" & mat_length &
                        ",y=" & mat_width &
                        ",z=0" &
                        ",pos=0" &
                        ",angle=0" &
                        ",cmd=" & QStr(New_Cmd_Text)

                End If

                lReturn = PortalExecute(cmd)


                modView.ViewRegen()

            End If

        Next

    End Sub

    Private Function GetTravelFromPartID(partid As Long) As Double
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetTravelFromPartID = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Part ID] =" & partid & " )"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        oledbAdapter.Dispose()

        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetTravelFromPartID = dsParts.Tables(0).Rows(0).Item("Cut Travel Distance")

        End If

        dsParts.Dispose()

        connection.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing

    End Function

    Private Function GetAreaFromPartID(partid As Long) As Double
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetAreaFromPartID = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Part ID] =" & partid & " )"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        oledbAdapter.Dispose()

        connection.Dispose()
        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetAreaFromPartID = dsParts.Tables(0).Rows(0).Item("Area")

        End If

        dsParts.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing

    End Function
    Private Function GetCostFromPartID(partid As Long) As Double
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetCostFromPartID = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Part ID] =" & partid & " )"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        oledbAdapter.Dispose()

        connection.Dispose()
        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetCostFromPartID = dsParts.Tables(0).Rows(0).Item("Cost")

        End If

        dsParts.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing
    End Function

    Private Function GetFilenameFromPatternID(PartId As Long) As String
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetFilenameFromPatternID = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Part ID] =" & PartId & " )"
        sql = "Select Part.* From Part Where (Part.ID = " & PartId & " )"
        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        oledbAdapter.Dispose()

        connection.Dispose()
        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetFilenameFromPatternID = dsParts.Tables(0).Rows(0).Item("FileName")

        End If

        dsParts.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing

    End Function

    Private Function GetLegendIDFromPartID(partid As Long) As Long
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetLegendIDFromPartID = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Part ID] =" & partid & " )"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        oledbAdapter.Dispose()

        connection.Dispose()
        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetLegendIDFromPartID = dsParts.Tables(0).Rows(0).Item("Legend ID")

        End If

        dsParts.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing
    End Function


    Private Function GetNameFromPartID(partid As Long) As String
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetNameFromPartID = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select Part.* From Part Where (Part.ID = " & partid & " )"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        connection.Dispose()
        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetNameFromPartID = dsParts.Tables(0).Rows(0).Item("Filename")

        End If

        dsParts.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing

    End Function

    Private Function GetSheetIDFromName(nst_Sheet_Name As String) As Long
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dsParts As New DataSet
        Dim sql As String
        Dim cnt2 As Integer

        GetSheetIDFromName = -1

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

        sql = "Select [Sheet Result].* From [Sheet Result] " & _
                "Where ([Sheet Result].[Sheet Filename] = '" & nst_Sheet_Name & "' )"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        oledbAdapter.Dispose()

        connection.Dispose()
        connection.Close()

        cnt2 = dsParts.Tables(0).Rows.Count

        If (cnt2 > 0) Then

            GetSheetIDFromName = dsParts.Tables(0).Rows(0).Item("ID")

        End If

        dsParts.Dispose()

        If dsParts IsNot Nothing Then dsParts = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing

    End Function

    Private Sub TransferPattern(PatId As Long, patlabel As String, patangle As Double, partid As Long, PartName As String, sSheetFilename As String)
        Dim active_layer As ActiveLayerInfo
        Dim cmd As String
        Dim lPatternID As Long
        Dim sFileName As String

        If (PartName <> "") Then
            modView.ViewActivate(VIEW_WIRE)

            cmd = "Pattern:Create: file=" & QStr(PartName)

            active_layer = GetActiveLayer()

            SetActiveLayer("Instances", System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Yellow))

            lReturn = PortalExecute(cmd)

            lPatternID = PortalGetInt("id", 0)
            lReturn = SetEntityName(lPatternID, "_pattern" + CStr(lPatternID))

            lReturn = EntityStringSet(lPatternID, "_label", patlabel)
            lReturn = EntityDoubleSet(lPatternID, "_label_angle", 0)
            lReturn = EntityDoubleSet(lPatternID, "_label_dx", 0)
            lReturn = EntityDoubleSet(lPatternID, "_label_dy", 0)
            lReturn = EntityIntSet(lPatternID, "_label_size", 10)
            lReturn = EntityDoubleSet(lPatternID, "part_angle", (patangle * DEG2RAD))
            lReturn = EntityIntSet(lPatternID, "part_id", partid)
            lReturn = EntityIntSet(lPatternID, "part_mirror", 0)
            lReturn = EntityStringSet(lPatternID, "Type", ".")
            lReturn = EntityStringSet(lPatternID, "sSheetname", sSheetFilename)

            lReturn = PortalExecute("admin:regen:")

            SetActiveLayer(active_layer.Name, active_layer.Color)
            sFileName = PathCurrent()

            lReturn = modFileIO.ExportMM2(sFileName)

        End If


    End Sub


    Private Sub UpdatePartCountInPDB(Part_ID As Long, DoAdd As Boolean)
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim pdb_file As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim dsParts As New DataSet
        Dim cnt2 As Integer
        Dim sPartFile As String
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim n_New_Qty As Long
        Dim n_Old_Qty As Long
        Dim ni As Integer = 0
        Dim nFieldCnt As Integer
        Dim sColumnNames As String
        Dim nSheetID As Long
        Try
            pdb_file = HeaderStringGet("pdb_file", "")

            If (FileExists(pdb_file) = True) Then

                sPartFile = PathFile(GetNameFromPartID(Part_ID))

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                m_cnPart = New OleDbConnection(connetionString)

                m_cnPart.Open()

                sql = "Select * From [Part Result] Where ([Part Result].[Sheet Filename] = '" & _
                        PathNST() & "' ) And ([Part Result].[Part ID] = " & Part_ID & " )"

                oledbAdapter = New OleDbDataAdapter(sql, m_cnPart)

                oledbAdapter.Fill(dsParts)

                oledbAdapter.Dispose()

                If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                m_cnPart.Close()

                cnt2 = dsParts.Tables(0).Rows.Count

                If (cnt2 > 0) Then
                    'nSheetID = CLng(dsParts.Tables(0).Rows(0).Item("Sheet ID"))

                    n_Old_Qty = CLng(dsParts.Tables(0).Rows(0).Item("Quantity"))
                    If (DoAdd = True) Then
                        n_New_Qty = n_Old_Qty + 1
                    Else
                        n_New_Qty = n_Old_Qty - 1
                    End If
                    connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                    m_cnSettings = New OleDbConnection(connetionString)

                    m_cnSettings.Open()

                    If (n_New_Qty > 0) Then
                        'Select [Part Result].* From [Part Result] Where ([Part Result].[Sheet ID] = 1 ) And ([Part Result].Quantity = 5 )
                        sql = "UPDATE [Part Result] set [Part Result].Quantity = " & n_New_Qty & " Where ([Part Result].[Sheet Filename] = '" &
                        PathNST() & "' ) And ([Part Result].[Part ID] = " & Part_ID & " )"

                        'sql = "UPDATE [Part] set [Part].[Quantity] = " & dsParts.Tables(0).Rows(0).Item("Quantity") & " Where ([Part].[ID] =" & Part_ID & " )"

                        m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                        m_daSettings.InsertCommand.ExecuteNonQuery()

                        m_cnSettings.Close()
                    Else
                        sql = "delete [Part Result].* From [Part Result] Where ([Part Result].ID = " & Part_ID & ")"

                        m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                        m_daSettings.InsertCommand.ExecuteNonQuery()

                        m_cnSettings.Close()

                    End If

                Else
                    dsParts.Dispose()

                    sql = "Select [Part Result].* From [Part Result] Where ([Part Result].[Sheet Filename] = '" &
                            sTransSheetName & "' ) And ([Part Result].[Part ID] = " & Part_ID & " )"

                    oledbAdapter = New OleDbDataAdapter(sql, m_cnPart)
                    oledbAdapter.Fill(dsParts)

                    oledbAdapter.Dispose()

                    If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                    sFieldNames = sEmpty
                    sFieldValues = sEmpty
                    sColumnNames = sEmpty
                    nFieldCnt = dsParts.Tables(0).Columns.Count

                    'MessageBox.Show("The field count is < " & nFieldCnt & ">")

                    For ni = 1 To nFieldCnt - 1
                        If ni = 1 Then

                            sColumnNames = "[" & dsParts.Tables(0).Columns(ni).ColumnName & "]"

                            sFieldValues = "'" & PathCurrent() & "'"

                        ElseIf ni = 2 Then
                            sColumnNames = sColumnNames & ",[" & dsParts.Tables(0).Columns(ni).ColumnName & "]"

                            'nSheetID = CLng(dsParts.Tables(0).Rows(0).Item("Sheet ID"))

                            sFieldValues = sFieldValues & "," & GetSheetIDFromName(PathCurrent())

                        Else

                            sColumnNames = sColumnNames & ",[" & dsParts.Tables(0).Columns(ni).ColumnName & "]"

                            If (dsParts.Tables(0).Columns(ni).DataType = GetType(System.String)) Then

                                sFieldValues = sFieldValues & ",'" & dsParts.Tables(0).Rows(0).Item(ni) & "'"

                            Else

                                If (FromTransfer = True) Then
                                    If (dsParts.Tables(0).Columns(ni).ColumnName = "Quantity") Then
                                        sFieldValues = sFieldValues & ",1"
                                        FromTransfer = False
                                    Else
                                        sFieldValues = sFieldValues & "," & dsParts.Tables(0).Rows(0).Item(ni)
                                    End If

                                Else
                                    sFieldValues = sFieldValues & "," & dsParts.Tables(0).Rows(0).Item(ni)
                                End If

                            End If


                        End If

                    Next

                    'sFieldNames = "[Sheet Filename]," &
                    '                "[Sheet ID]," &
                    '                "[Part Name]," &
                    '                "[Part ID]," &
                    '                "[Legend ID]," &
                    '                "[Quantity]," &
                    '                "[Area]," &
                    '                "[Cost]," &
                    '                "[Part_Travel]," &
                    '                "[Part_Pierces]"

                    'sFieldValues = "'" & PathNST() & "'," &
                    '                GetSheetIDFromName(PathNST()) & "," &
                    '                "'" & sPartFile & "'" & "," &
                    '                Part_ID & "," &
                    '                GetLegendIDFromPartID(Part_ID) & "," &
                    '                "1," &
                    '                GetAreaFromPartID(Part_ID) & "," &
                    '                GetCostFromPartID(Part_ID) & "," &
                    '                GetTravelFromPartID(Part_ID) & "," &
                    '                GetTravelFromPartID(Part_ID)

                    sql = "INSERT INTO [Part Result] (" & sColumnNames & " ) VALUES(" & sFieldValues & ")"
                    'MessageBox.Show(sql)


                    connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathPDB() & "';"

                    m_cnPart = New OleDbConnection(connetionString)

                    m_cnPart.Open()

                    m_daPart.InsertCommand = New OleDbCommand(sql, m_cnPart)

                    m_daPart.InsertCommand.ExecuteNonQuery()
                    n_Old_Qty = 1
                    n_New_Qty = 1
                    m_cnPart.Close()
                End If

                FindLengendTextAndUpdate(Part_ID, PathNST(), n_Old_Qty, n_New_Qty)

            End If

            dsParts.Dispose()
            m_cnPart.Dispose()
            m_cnSettings.Dispose()

            If dsParts IsNot Nothing Then dsParts = Nothing

            If m_cnPart IsNot Nothing Then m_cnPart = Nothing

            If m_cnSettings IsNot Nothing Then m_cnSettings = Nothing

        Catch ex As Exception

            MessageBox.Show("UpdatePartCountInPDB: " & ex.Message)

        End Try


    End Sub

    Private Sub cmdDrop_Click(sender As Object, e As EventArgs) Handles cmdDrop.Click
        Dim cmd As String
        Dim move_copy As Long
        Dim entity_id As Long

        bDraggingPattern = False

        If (m_is_pattern = True) Then
            entity_id = m_pattern_id
            move_copy = BUMP_COPY  'must be careful not to affect the original pattern!!!

        Else
            entity_id = m_instance_id
            move_copy = IIf((OptMoveCopy.SelectedIndex = 1), BUMP_COPY, BUMP_MOVE)
        End If

        If move_copy = BUMP_COPY Then

            'If the part was copied we chould update the PDB to reflect the new count
            UpdatePartCountInPDB(m_part_id, True)

        End If

        'The final positional attributes should be properly reflected in the dialog(?)
        cmd = "nest:manual:instance:" & _
             " opt=" & move_copy & _
             ",xp=" & CDbl(tbHandleX.EditValue) & _
             ",yp=" & CDbl(tbHandleY.EditValue) & _
             ",ang=" & CDbl(mtbOrientation.Text)

        If (m_is_pattern = True) Then cmd = cmd & ",pattern=1"

        UndoPrepare()
        lReturn = PortalExecute(cmd)
        ExportMM2(PathCurrent())

        UndoCommit()

        'By selecting the Drop button, the end-user is committing an instance
        'of the current pattern to the current position. As such, we force
        'him to reselect a new pattern. Otherwise, the end-user can be fooled
        'into thinking he is dragging another instance when we get the next
        'series of drag events.
        lReturn = Reinit()


        cmdCancel_core()

        chkbUseSelected.Checked = False

        modView.ViewRegen()

    End Sub

    Private Sub cmdTransfer_Click(sender As Object, e As EventArgs) Handles cmdTransfer.Click
        Dim pattern_id As Long
        Dim pat_angle As Double
        Dim Part_ID As Long
        Dim pat_label As String
        Dim Part_Name As String
        Dim foo As String


        foo = nbcPatterns.SelectedLink.Item.Tag

        pattern_id = GetValueFromDelimitedData(foo, "PatternID", 0)
        Part_ID = GetValueFromDelimitedData(foo, "PartID", 0)
        Part_Name = GetValueFromDelimitedData(foo, "PartName", sEmpty)
        pat_angle = GetValueFromDelimitedData(foo, "PatternAngle", 0)
        pat_label = GetValueFromDelimitedData(foo, "PatternName", 0)
        Part_Name = GetFilenameFromPatternID(Part_ID)
        sTransSheetName = cbeSheets.SelectedItem.ToString

        'Part_ID = tlstPattern.ItemValues(tlstPattern.ListIndex, "Part ID")
        'Part_Name = GetFilenameFromPatternID(tlstPattern.ItemValues(tlstPattern.ListIndex, "Part ID"))
        'pat_angle = tlstPattern.ItemValues(tlstPattern.ListIndex, "Part Angle").Value
        'pat_label = tlstPattern.ItemValues(tlstPattern.ListIndex, "Pat Label").Value
        TransferPattern(pattern_id, pat_label, pat_angle, Part_ID, Part_Name, sTransSheetName)

        cmdCancel_core()
        FromTransfer = True
        MessageBox.Show("Transfer Complete.")

        cmdTransfer.Enabled = False
    End Sub


    Private Sub scPatternBump_Resize(sender As Object, e As EventArgs) Handles scPatternBump.Resize
        lstPattern.Width = scPatternBump.Panel2.Width - 15
    End Sub

    Private Sub mtbOrientation_Load(sender As Object, e As EventArgs) Handles mtbOrientation.Load

    End Sub

    Private Sub mtbOrientation_TextChanged(sender As Object, e As EventArgs) Handles mtbOrientation.TextChanged

        Try

            'NOTE: We should arrive here *only* when values are keyed-in.
            If ((g_shape Is Nothing) = False) Then

                'In case input is bad ...

                g_shape.OrientationSet(CDbl(mtbOrientation.Text))

                'We echo the location because rotating the part about an
                'anchor point that is *not* coincident with the handle
                'point causes the handle point to change.
                lReturn = EchoLocation(g_shape.GetLocation())

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        UpdatePartCountInPDB(m_part_id, False)
        lReturn = PortalExecute("Create:Delete: id=" & m_instance_id)
        bDraggingPattern = False

        Me.chkbUseSelected.Checked = False
        chkbUseSelected.Invalidate()
        cmdCancel_core()
        chkbUseSelected.Checked = False
        ViewRefresh()

    End Sub

End Class
