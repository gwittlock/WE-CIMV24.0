Public Class frmGraphicsEditor
    Private m_currRecordID As Long
    Private m_searchString As String
    Private m_searchIndex As Integer

    Private m_code_gen As String
    Private m_ncfile As String
    Private m_is_active As Boolean
    Private sPortalCommand As String
    Public Sub SetPortalCommand(sCmd As String)
        sPortalCommand = sCmd

    End Sub

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
        bIsGraphicsEditorLoaded = True
    End Function

    Public Sub CodeGenPurge()
        m_code_gen = NEED_CODEGEN
    End Sub

    Private Sub frmGraphicsEditor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        lReturn = PortalExecute("*codegen:xrefdestroy:")
        lReturn = PortalExecute("!view:highlight:id=0")
        lReturn = PortalExecute("Admin:GlobalModel:")  'for safety

        modSelection.DeselectAll()
        If (m_ncfile <> "") Then lReturn = HeaderStringSet("ncfile", m_ncfile)

        bIsGraphicsEditorLoaded = False
        m_is_active = False
        frmMain.CloseFirstPanel()
    End Sub

    '    Private Sub frmGraphicsEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '
    '    End Sub

    Private Sub frmGraphicsEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lReturn = PortalExecute("*codegen:xrefcreate:")

        Windows.Forms.Cursor.Current = Cursors.Default

        UpdateButtons(m_code_gen)
        m_ncfile = ""

        m_currRecordID = 0
        m_searchString = ""
        m_searchIndex = -1

        m_is_active = True
        m_curr_dlg = Me
        bIsGraphicsEditorLoaded = True


    End Sub
    Public Sub UpdateButtons(the_code_gen As String)

        If (the_code_gen = sEmpty) Then
            m_code_gen = "<Select Code Generator>"
        Else
            m_code_gen = the_code_gen
        End If


        cmdCodeGenFile.Text = TrimToFit(m_code_gen, 40)

        cmdGraphicsEditorRefresh.Enabled = (m_code_gen <> NEED_CODEGEN)
        cmdGraphicsEditorStep.Enabled = (m_code_gen <> NEED_CODEGEN)

    End Sub

    Private Sub cmdCodeGenFile_Click(sender As Object, e As EventArgs) Handles cmdCodeGenFile.Click
        frmCodeGen.Init(CODE_OPTION.CODE_VIEWER)

        '2006.11.19 (PE) -- The dialog is modeless so as to allow
        'coordinate information to be returned from frmPicModeler
        'to the c2dStartPt control.

        frmCodeGen.ShowDialog(Me)

    End Sub

    Private Sub cmdGraphicsEditorRefresh_Click(sender As Object, e As EventArgs) Handles cmdGraphicsEditorRefresh.Click
        If (PartsAreZoned() = False) Then Exit Sub

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lstGraphicsEditor.Items.Clear()
        lstGraphicsEditor.Refresh()


        'NOTE: We must remember the 'ncfile' value so that we can
        'reset it upon leaving the code viewer.  Otherwise, said
        'value will be set to "", and then the file name will not
        'appear next time you try to export a physical cnc file.
        If (m_ncfile = "") Then m_ncfile = HeaderStringGet("ncfile", "")

        lReturn = PortalExecute("Admin:GlobalModel:")  'CRITICAL!

        ShowCode()

        Windows.Forms.Cursor.Current = Cursors.Default


    End Sub
    Private Sub ShowCode()

        Dim lNumRecs As Long
        Dim sCodeLine As String
        Dim iGE_CNT As Integer
        Dim lTempRec As Long

        If (m_code_gen = NEED_CODEGEN) Then Exit Sub

        lstGraphicsEditor.Items.Clear()


        lReturn = PortalExecute(sPortalCommand)

        lReturn = PortalExecute("*codegen:xrefcount:")
        lNumRecs = PortalGetInt("count", 0)

        For iGE_CNT = 0 To lNumRecs - 1

            lTempRec = CLng(iGE_CNT)
            lReturn = PortalExecute("*codegen:xreffetch:recno=" & lTempRec)

            sCodeLine = PortalGetString("text", "")
            lTempRec = PortalGetInt("id", 0)


            lstGraphicsEditor.Items.Add(New myItemData(sCodeLine, lTempRec))

        Next iGE_CNT

    End Sub

    Private Sub cmdGraphicsEditorStep_Click(sender As Object, e As EventArgs) Handles cmdGraphicsEditorStep.Click
        Dim dInterval As Double

        If cmdGraphicsEditorStep.Text = "Step" Then
            dInterval = CInt(1) / 8
            Timer1.Interval = dInterval * 500
            Timer1.Enabled = True
            cmdGraphicsEditorStep.Text = "Pause"
        Else
            Timer1.Enabled = False
            cmdGraphicsEditorStep.Text = "Step"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim lIndex As Long

        lIndex = lstGraphicsEditor.SelectedIndex + 1


        If lIndex > lstGraphicsEditor.Items.Count - 1 Then
            Timer1.Enabled = False
            cmdGraphicsEditorStep.Text = "Step"

            HighLightEntity()

        Else
            lstGraphicsEditor.SelectedIndex = lIndex
        End If
        HighLightEntity()
    End Sub
    Private Sub HighLightEntity()
        If (lstGraphicsEditor.SelectedIndex > 0) Then

            'In order to support the display of clamp avoidance moves we have
            'changed the way we access records are accessed. This should be a
            'safe thing to do because the blocks of code displayed in the
            'control are one-to-one with those in the CCodeGeoXref object.
            lReturn = PortalExecute("*codegen:highlight:rec=" & lstGraphicsEditor.SelectedIndex)
            'So that we can restart the search from the
            'most recently selected output block
            m_searchIndex = lstGraphicsEditor.SelectedIndex

        End If
    End Sub

    Private Sub lstGraphicsEditor_KeyUp(sender As Object, e As KeyEventArgs) Handles lstGraphicsEditor.KeyUp

        If (e.KeyCode = Keys.F3) Then
            ExecuteSearch()
        End If
    End Sub


    Private Sub lstGraphicsEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles lstGraphicsEditor.MouseDown
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            StartSearch()
        End If
    End Sub
    Public Sub StartSearch()

        Dim searchString As String

        searchString = UCase$(InputBox("Enter Search String:", "Search", m_searchString))
        If (searchString <> "") Then
            m_searchString = searchString
            ExecuteSearch()
        End If

    End Sub

    Public Sub ExecuteSearch()

        Dim indx As Long

        If (m_searchString <> "") Then

            If ((m_searchIndex < 0) Or (m_searchIndex >= lstGraphicsEditor.ItemCount)) Then
                m_searchIndex = 0
            End If

            For indx = m_searchIndex To lstGraphicsEditor.ItemCount - 1

                If (InStr(1, UCase(lstGraphicsEditor.Items(indx).ToString), m_searchString) > 0) Then
                    lstGraphicsEditor.SelectedIndex = indx
                    m_searchIndex = indx + 1
                    Exit For
                End If

            Next

        End If

        'Set up to restart search from top.
        If (indx >= lstGraphicsEditor.ItemCount) Then m_searchIndex = -1

    End Sub

    Private Sub lstGraphicsEditor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGraphicsEditor.SelectedIndexChanged
        HighLightEntity()

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

    Private Sub frmGraphicsEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        modView.ViewRefresh()
    End Sub
End Class