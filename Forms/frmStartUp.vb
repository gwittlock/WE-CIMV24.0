Imports DevExpress.XtraSplashScreen

Public Class frmStartUp
    Private m_is_active As Boolean
    Private m_pdb_filename As String = Nothing
    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function

    Private Sub frmStartUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        m_is_active = False
    End Sub


    Private Sub frmStartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ni As Integer
        Dim sForm As Form

        bIstartUpLoaded = True

        sForm = SplashScreen1

        lReturn = SetFormIcon(Me)


        '#If (CCS_FAB) Then

        '        PictureBox1.Image = My.Resources.Resources.SmallBenchMarkTransLogo

        '#Else
        '        PictureBox1.Image = My.Resources.Resources.WE_CIM_StartUp

        '#End If

        For ni = 0 To frmMain.MRU_ListAray.Count - 1
            lbRecentFiles.Items.Add(frmMain.MRU_ListAray(ni).ToString)
        Next
        lbRecentFiles.SelectedIndex = -1

        m_is_active = True

        If (bShowSplash = True) Then
            SplashScreenManager.CloseForm()
            bShowSplash = False
        End If


    End Sub


    Private Sub suBtnNew_Click(sender As Object, e As EventArgs)
        appMain.ExecuteFunction(101)
    End Sub

    Private Sub suBtnOpen_Click(sender As Object, e As EventArgs)
        'frmMain.pnlPicmodeler.SuspendLayout()
        lReturn = appMain.ExecuteFunction(102)
        'frmMain.pnlPicmodeler.ResumeLayout()

    End Sub

    Private Sub suBtnNesting_Click(sender As Object, e As EventArgs)

        frmMain.doNesting()


    End Sub

    Private Sub lbRecentFiles_Click(sender As Object, e As EventArgs) Handles lbRecentFiles.Click
        Dim sTarget As String
        Dim sCandidate As String

        frmMain.Cursor = Cursors.WaitCursor
        sCandidate = lbRecentFiles.SelectedValue
        sTarget = sCandidate
        modView.ViewActivate(VIEW_WIRE)

        If (FileExists(sCandidate) = False) Then

            lReturn = MessageBox.Show("The File < " & sCandidate & " > Does not Exist! Would you like to remove it from the List?", "File Not Found", MessageBoxButtons.YesNo)

            If (lReturn = MsgBoxResult.Yes) Then

                lbRecentFiles.Items.Remove(lbRecentFiles.SelectedItem)

            End If

        Else

            'At this point, the user has committed to importing the file.
            sTarget = modFileIO.ImportFile(sCandidate, sTarget)
            lReturn = frmMain.AddToMru(sTarget, frmMain.MRU_ListAray)
            Me.Dispose()


        End If
        frmMain.Cursor = Cursors.Default

    End Sub


    Private Sub sbModelFilesNew_Click(sender As Object, e As EventArgs) Handles sbModelFilesNew.Click
        appMain.ExecuteFunction(101)
    End Sub

    Private Sub sbModelFilesOpen_Click(sender As Object, e As EventArgs) Handles sbModelFilesOpen.Click
        lReturn = appMain.ExecuteFunction(102)
    End Sub

    Private Sub sbNestingNew_Click(sender As Object, e As EventArgs) Handles sbNestingNew.Click
        Dim Pdb_FileSave As New SaveFileDialog

        Pdb_FileSave.Filter = "PDB files (*.pdb)|*.pdb"
        Pdb_FileSave.FilterIndex = 1
        Pdb_FileSave.RestoreDirectory = True
        Pdb_FileSave.InitialDirectory = PathNestFolder()

        If Pdb_FileSave.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            m_pdb_filename = Pdb_FileSave.FileName

            Pdb_FileSave.Dispose()

            ConditionalFileDelete(m_pdb_filename)

            PathPDB_Set(m_pdb_filename)


            frmNesting.CreateNewPDB()
            frmMain.doNesting()
            Me.Dispose()

        Else
            Me.Dispose()
        End If


    End Sub

    Private Sub sbNestingOpen_Click(sender As Object, e As EventArgs) Handles sbNestingOpen.Click

        bCameFromStartUp = True 'see frmNestingProtoType.OpenExistingPDB())

        If (bCameFromStartUp = True) Then
            frmMain.doNesting()
        End If

    End Sub

    Private Sub sbConfigMan_Click(sender As Object, e As EventArgs) Handles sbConfigMan.Click
        lReturn = appMain.ExecuteFunction(501)
    End Sub

    Private Sub sbMRP_Open_Click(sender As Object, e As EventArgs) Handles sbMRP_Open.Click
        lReturn = ExecuteMRP()

        If (bDo_MRP_Nesting = True) Then
            bCameFromStartUp = True

            frmMain.doNesting()
        End If


    End Sub

    Private Sub lbRecentFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbRecentFiles.SelectedIndexChanged

    End Sub

    Private Sub frmStartUp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        bIstartUpLoaded = False
    End Sub

    Private Sub frmStartUp_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub
End Class