Imports DevExpress.XtraTreeList.Nodes
Imports System.Data.OleDb
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraTreeList
Imports System.ComponentModel
Imports System
Imports System.IO

Public Class frmFilemaintenance

    Private bIs_Active As Boolean = False
    Private m_is_active As Boolean
    Private nMajorMarkID As Long
    Private nFooBarCounter As Long = 0
    Private nMinorMarkID As Long

    Private _hitInfo As TreeListHitInfo

    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_JOB_NODE As TreeListNode
    Private CFG_JOB_BATCH_NODE As TreeListNode
    Private CFG_SHEET_ROOT_NODE As TreeListNode
    Private CFG_SHEET_NODE As TreeListNode
    Private CFG_MAJOR_ROOT_NODE As TreeListNode
    Private CFG_MAJOR_NODE As TreeListNode
    Private CFG_MINOR_ROOT_NODE As TreeListNode
    Private CFG_MINOR_NODE As TreeListNode

    Private Const TAG_CFG_ROOT_NODE = 0
    Private Const TAG_CFG_JOB_NODE = -100
    Private Const TAG_CFG_JOB_BATCH_NODE = -101
    Private Const TAG_CFG_SHEET_ROOT_NODE = -102
    Private Const TAG_CFG_SHEET_NODE = -103
    Private Const TAG_CFG_MAJOR_ROOT_NODE = -104
    Private Const TAG_CFG_MAJOR_NODE = -105
    Private Const TAG_CFG_MINOR_ROOT_NODE = -106
    Private Const TAG_CFG_MINOR_NODE = -107

    Private nSheetNodeID As Long
    Private nBatchNodeID As Long
    Private Const MODECOPY_COPY = 0
    Private Const MODECOPY_MOVE = 1
    Private Const MODECOPY_ARCHIVE = 2
    Private Const MODECOPY_DELETE = 3

    Dim nMajorMark_NodeID As Integer
    Dim nSheetID As Long
    Dim bFromHideControls As Boolean
    Dim sPaintGalv As String
    Dim nJobindex As Long
    'PURPOSE:  Creates an instance of the User class.
    Dim myUsers As New Users
    Dim bJobNotFound As Boolean = False
    Dim nTheMode As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Public Sub InitGridData()
        Dim DBFileName As String = String.Empty

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "\Database\sh_cfgman.accdb")
        If DBFileName <> String.Empty Then
            InitMDBData("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DBFileName)
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub InitMDBData(ByVal connectionString As String)
        Dim ds As New DataSet()
        Dim oleDbDataAdapter As New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Jobs]", connectionString)
        oleDbDataAdapter.Fill(ds, "[Jobs]")


        Dim dvManager As New DataViewManager(ds)
        Dim dv As DataView = dvManager.CreateDataView(ds.Tables("[Jobs]"))

        grdJobs.DataSource = dv

    End Sub

    Private Sub frmFilemaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        m_is_active = False
    End Sub


    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function

    Private Sub frmFilemaintenance_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        m_is_active = True
    End Sub


    Private Sub grdJobs_DoubleClick(sender As Object, e As EventArgs) Handles grdJobs.DoubleClick
        Dim sTodaysDate As Date = Now


        m_JobNum = gvJobs.GetFocusedRowCellValue("JobNum").ToString
        m_JobLocation = gvJobs.GetFocusedRowCellValue("JobLocation").ToString
        m_JobPlant = gvJobs.GetFocusedRowCellValue("JobPlant").ToString
        m_JobName = gvJobs.GetFocusedRowCellValue("JobName").ToString
        sJobBOMBy = gvJobs.GetFocusedRowCellValue("JobBOMBy").ToString
        m_JobID = CInt(gvJobs.GetFocusedRowCellValue("ID").ToString)

    End Sub

    Private Sub frmFilemaintenance_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            InitGridData()
            cboCopyMove.SelectedIndex = 0

            GetRegSettings()

            xtcJobs.SelectedTabPage = xtpFileManagement
            Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception

            MessageBox.Show("frmFilemaintenance_Load: " & ex.Message)

        End Try

    End Sub
    Private Sub GetRegSettings()

        Try
            beCopyMoveMM2.Text = RegGetString("Fabrication\FileMgr", "sCopyMM2Folder", App_Path)
            beCopyMoveNST.Text = RegGetString("Fabrication\FileMgr", "sCopyNSTFolder", App_Path)
            beCopyMoveCNC.Text = RegGetString("Fabrication\FileMgr", "sCopyCNCFolder", App_Path)
            beCopyMoveCad.Text = RegGetString("Fabrication\FileMgr", "sCopyCADFolder", App_Path)
            beCopyMovePDB.Text = RegGetString("Fabrication\FileMgr", "sCopyPDBFolder", App_Path)
            beCopyMoveRPT.Text = RegGetString("Fabrication\FileMgr", "sCopyRPTFolder", App_Path)


            beMM2ToFolder.Text = RegGetString("Fabrication\FileMgr", "sArchiveMM2Folder", NormalizePath(App_Path))
            beNSTToFolder.Text = RegGetString("Fabrication\FileMgr", "sArchiveNSTFolder", NormalizePath(App_Path))
            beCNCToFolder.Text = RegGetString("Fabrication\FileMgr", "sArchiveCNCFolder", NormalizePath(App_Path))
            beCADToFolder.Text = RegGetString("Fabrication\FileMgr", "sArchiveCADFolder", NormalizePath(App_Path))
            bePDBToFolder.Text = RegGetString("Fabrication\FileMgr", "sArchivePDBFolder", NormalizePath(App_Path))
            beRPTToFolder.Text = RegGetString("Fabrication\FileMgr", "sArchiveRPTFolder", NormalizePath(App_Path))



        Catch ex As Exception
            MessageBox.Show("GetRegSettings: " & ex.Message)
        End Try
    End Sub
    Private Sub bbiFIleManagement_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiFileManagement.ItemClick
        xtcJobs.SelectedTabPage = xtpFileManagement

    End Sub

    Private Sub bbiShipping_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiShipping.ItemClick
        xtcJobs.SelectedTabPage = xtpShipping

    End Sub


    Private Sub bbiFInd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiFInd.ItemClick
        xtcJobs.SelectedTabPage = xtpFind
    End Sub

    Private Sub bbiRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRefresh.ItemClick
        xtcJobs.SelectedTabPage = xtpJobs
    End Sub


    Private Sub sbCopyMoveExecute_Click(sender As Object, e As EventArgs) Handles sbCopyMoveExecute.Click
        Dim FileLastModDate As Date

        Try

            FileLastModDate = New Date(2013, 5, 17)
            Dim fromDate As Date = New Date(2013, 5, 17)
            Dim toDate As Date = New Date(2013, 5, 17)


            RegPutString("Fabrication\FileMgr", "sCopyMM2Folder", beCopyMoveMM2.Text)
            RegPutString("Fabrication\FileMgr", "sCopyNSTFolder", beCopyMoveNST.Text)
            RegPutString("Fabrication\FileMgr", "sCopyCNCFolder", beCopyMoveCNC.Text)
            RegPutString("Fabrication\FileMgr", "sCopyCADFolder", beCopyMoveCad.Text)
            RegPutString("Fabrication\FileMgr", "sCopyPDBFolder", beCopyMovePDB.Text)
            RegPutString("Fabrication\FileMgr", "sCopyRPTFolder", beCopyMoveRPT.Text)
            RegPutString("Fabrication\FileMgr", "sCopyToFolderNstFolder", beMM2ToFolder.Text)

            RegPutString("Fabrication\FileMgr", "chkCopyMoveMM2", chkCopyMoveMM2.CheckState)
            RegPutString("Fabrication\FileMgr", "chkCopyMoveNST", chkCopyMoveNST.CheckState)
            RegPutString("Fabrication\FileMgr", "chkCopyMoveCNC", chkCopyMoveCNC.CheckState)
            RegPutString("Fabrication\FileMgr", "chkCopyMoveCad", chkCopyMoveCad.CheckState)
            RegPutString("Fabrication\FileMgr", "chkCopyMovePDB", chkCopyMovePDB.CheckState)
            RegPutString("Fabrication\FileMgr", "chkCopyMoveRPT", chkCopyMoveRPT.CheckState)

            RegPutString("Fabrication\FileMgr", "sArchiveMM2Folder", beMM2ToFolder.Text)
            RegPutString("Fabrication\FileMgr", "sArchiveNSTFolder", beNSTToFolder.Text)
            RegPutString("Fabrication\FileMgr", "sArchiveCNCFolder", beCNCToFolder.Text)
            RegPutString("Fabrication\FileMgr", "sArchiveCADFolder", beCADToFolder.Text)
            RegPutString("Fabrication\FileMgr", "sArchivePDBFolder", bePDBToFolder.Text)
            RegPutString("Fabrication\FileMgr", "sArchiveRPTFolder", beRPTToFolder.Text)

            Select Case nTheMode
                Case MODECOPY_COPY

                    If (chkCopyMoveMM2.CheckState = CheckState.Checked) Then

                        CopyFiles("*.mm2", beMM2ToFolder)
                    End If

                    If (chkCopyMoveCad.CheckState = CheckState.Checked) Then

                        CopyFiles("*.dxf", beCADToFolder)
                        CopyFiles("*.dwg", beCADToFolder)

                    End If

                    If (chkCopyMoveCNC.CheckState = CheckState.Checked) Then

                        CopyFiles("*.lst", beCNCToFolder)
                        CopyFiles("*.cnc", beCNCToFolder)

                    End If

                    If (chkCopyMoveNST.CheckState = CheckState.Checked) Then

                        CopyFiles("*.nst", beNSTToFolder)

                    End If

                    If (chkCopyMovePDB.CheckState = CheckState.Checked) Then

                        CopyFiles("*.pdb", bePDBToFolder)

                    End If

                    If (chkCopyMoveRPT.CheckState = CheckState.Checked) Then

                        CopyFiles("*.pdf", beRPTToFolder)

                    End If


                Case MODECOPY_MOVE

                    If (chkCopyMoveMM2.CheckState = CheckState.Checked) Then

                        MoveFiles("*.mm2", beMM2ToFolder)
                    End If

                    If (chkCopyMoveCad.CheckState = CheckState.Checked) Then

                        MoveFiles("*.dxf", beCADToFolder)
                        MoveFiles("*.dwg", beCADToFolder)

                    End If

                    If (chkCopyMoveCNC.CheckState = CheckState.Checked) Then

                        MoveFiles("*.lst", beCNCToFolder)
                        MoveFiles("*.cnc", beCNCToFolder)

                    End If

                    If (chkCopyMoveNST.CheckState = CheckState.Checked) Then

                        MoveFiles("*.nst", beNSTToFolder)

                    End If

                    If (chkCopyMovePDB.CheckState = CheckState.Checked) Then

                        MoveFiles("*.pdb", bePDBToFolder)

                    End If

                    If (chkCopyMoveRPT.CheckState = CheckState.Checked) Then

                        MoveFiles("*.pdf", beRPTToFolder)

                    End If


                Case MODECOPY_DELETE


                    If (chkCopyMoveMM2.CheckState = CheckState.Checked) Then

                        DeleteFiles("*.mm2", beMM2ToFolder)
                    End If

                    If (chkCopyMoveCad.CheckState = CheckState.Checked) Then

                        DeleteFiles("*.dxf", beCADToFolder)
                        DeleteFiles("*.dwg", beCADToFolder)

                    End If

                    If (chkCopyMoveCNC.CheckState = CheckState.Checked) Then

                        DeleteFiles("*.lst", beCNCToFolder)
                        DeleteFiles("*.cnc", beCNCToFolder)

                    End If

                    If (chkCopyMoveNST.CheckState = CheckState.Checked) Then

                        DeleteFiles("*.nst", beNSTToFolder)

                    End If

                    If (chkCopyMovePDB.CheckState = CheckState.Checked) Then

                        DeleteFiles("*.pdb", bePDBToFolder)

                    End If

                    If (chkCopyMoveRPT.CheckState = CheckState.Checked) Then

                        DeleteFiles("*.pdf", beRPTToFolder)

                    End If

                Case MODECOPY_ARCHIVE



            End Select

        Catch ex As Exception

            MessageBox.Show("frmFilemaintenance_Load: " & ex.Message)
        End Try

    End Sub

    Private Sub cboCopyMove_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCopyMove.SelectedIndexChanged

        Try

            Select Case cboCopyMove.SelectedIndex
                Case 0
                    nTheMode = MODECOPY_COPY

                Case 1
                    nTheMode = MODECOPY_MOVE

                Case 2
                    nTheMode = MODECOPY_ARCHIVE
                    MessageBox.Show("This feature is unavailable at this time.", "Feature Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Case 3
                    nTheMode = MODECOPY_DELETE


            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SurroundingSub()
        Dim startDate As DateTime = DateTime.Now.AddMonths(-1)
        Dim endDate As DateTime = DateTime.Now
        Dim directory = "C:\Laser\Steel-Stls Stl Parts\Parts"
        Dim di As DirectoryInfo = New DirectoryInfo(directory)
        Dim files As FileInfo() = di.GetFiles("*.mm2", IO.SearchOption.AllDirectories)
        Dim toMove As List(Of String) = files.Where(Function(fi) fi.CreationTime >= startDate AndAlso fi.CreationTime <= endDate).[Select](Function(fi) fi.FullName).ToList()

        For Each file As String In toMove
        Next
    End Sub


    Private Sub sbArchiveExecute_Click(sender As Object, e As EventArgs)
        Dim FileLastModDate As Date

        Try
            'RegPutString("Fabrication\FileMgr", "sArchiveMM2Folder", beArchiveMM2.Text)
            'RegPutString("Fabrication\FileMgr", "sArchiveNSTFolder", beArchiveNST.Text)
            'RegPutString("Fabrication\FileMgr", "sArchiveCNCFolder", beArchiveCNC.Text)
            'RegPutString("Fabrication\FileMgr", "sArchiveCADFolder", beArchiveCAD.Text)
            'RegPutString("Fabrication\FileMgr", "sArchivePDBFolder", beArchivePDB.Text)
            'RegPutString("Fabrication\FileMgr", "sArchiveRPTFolder", beArchiveRPT.Text)
            'RegPutString("Fabrication\FileMgr", "sArchiveToFolderNstFolder", beArchiveToFolder.Text)

            'RegPutString("Fabrication\FileMgr", "chkArchiveMM2", chkArchiveMM2.CheckState)
            'RegPutString("Fabrication\FileMgr", "chkArchiveNST", chkArchiveNST.CheckState)
            'RegPutString("Fabrication\FileMgr", "chkArchiveCNC", chkArchiveCNC.CheckState)
            'RegPutString("Fabrication\FileMgr", "chkArchiveCAD", chkArchiveCAD.CheckState)
            'RegPutString("Fabrication\FileMgr", "chkArchivePDB", chkArchivePDB.CheckState)
            'RegPutString("Fabrication\FileMgr", "chkArchiveRPT", chkArchiveRPT.CheckState)

            Select Case nTheMode
                Case MODECOPY_COPY
                    FileLastModDate = New Date(2013, 5, 17)
                    Dim fromDate As Date = New Date(2013, 5, 17)
                    Dim toDate As Date = New Date(2013, 5, 17)

                    'If (fromDate <= questionableDate) AndAlso (questionableDate <= toDate) Then
                    '    MsgBox("between")
                    'Else
                    '    MsgBox("not between")
                    'End If

                    Dim directory = "C:\Laser\Steel-Stls Stl Parts\Parts"
                    Dim files() As System.IO.FileInfo
                    Dim dirinfo As New System.IO.DirectoryInfo(directory)
                    files = dirinfo.GetFiles("*.mm2", IO.SearchOption.AllDirectories)
                    For Each file In files
                        FileLastModDate = file.LastWriteTime


                        'ListBoxControl1.Items.Add(file.DirectoryName.ToString & "\" & file.ToString & " " & file.LastWriteTime.ToString)
                    Next
                    'Dim files() As IO.FileInfo = New IO.DirectoryInfo("C:\Laser\Steel-Stls Stl Parts\Parts\*.mm2").GetFiles.OrderByDescending(Function(fi) fi.LastAccessTime).ToArray

                    'Dim myfiles() As String = Directory.GetFiles("C:\Laser\Steel-Stls Stl Parts\Parts", "*.mm2") _
                    '                        .Select(Function(x) New FileInfo(x)) _
                    '                        .OrderByDescending(Function(x) x.LastWriteTime) _
                    '                        .Select(Function(x) x.FullName).ToArray

                    'For Each path As String In myfiles
                    '    Dim readText As String = File.ReadAllText(path)
                    '    ListBoxControl1.Items.Add(path)
                    '    TextBox1.Text += readText
                    'Next

                Case MODECOPY_MOVE
                Case MODECOPY_DELETE

            End Select

        Catch ex As Exception

            MessageBox.Show("sbArchiveExecute_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub beCopyMoveCad_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCopyMoveCad.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try
            m_folderDialog.SelectedPath = NormalizePath(beCopyMoveCad.Text)

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                beCopyMoveCad.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMoveCad_ButtonClick: " & ex.Message)
        End Try
    End Sub

    Private Sub beCopyMoveCNC_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCopyMoveCNC.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try

            m_folderDialog.SelectedPath = NormalizePath(beCopyMoveCNC.Text)

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                beCopyMoveCNC.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMoveCNC_ButtonClick: " & ex.Message)
        End Try

    End Sub

    Private Sub beCopyMoveMM2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCopyMoveMM2.ButtonClick


        Dim m_folderDialog As New FolderBrowserDialog()

        Try

            m_folderDialog.SelectedPath = NormalizePath(beCopyMoveMM2.Text)

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                beCopyMoveMM2.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMoveMM2_ButtonClick: " & ex.Message)
        End Try

    End Sub

    Private Sub beCopyMoveNST_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCopyMoveNST.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try
            m_folderDialog.SelectedPath = NormalizePath(beCopyMoveNST.Text)

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                beCopyMoveNST.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMoveNST_ButtonClick: " & ex.Message)
        End Try

    End Sub

    Private Sub beCopyMovePDB_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCopyMovePDB.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try
            m_folderDialog.SelectedPath = NormalizePath(beCopyMovePDB.Text)

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                beCopyMovePDB.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMovePDB_ButtonClick: " & ex.Message)
        End Try
    End Sub

    Private Sub beCopyMoveRPT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCopyMoveRPT.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try
            m_folderDialog.SelectedPath = NormalizePath(beCopyMoveRPT.Text)

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                beCopyMoveRPT.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMoveRPT_ButtonClick: " & ex.Message)
        End Try
    End Sub

    Private Sub CopyFiles(sExt As String, c_FolderCtrl As ButtonEdit)
        Dim FileLastModDate As Date


        Try

            Dim directory = beCopyMoveMM2.Text

            Dim files() As System.IO.FileInfo
            Dim dirinfo As New System.IO.DirectoryInfo(directory)
            files = dirinfo.GetFiles(sExt, IO.SearchOption.AllDirectories)

            For Each file In files
                FileLastModDate = file.LastWriteTime

                My.Computer.FileSystem.CopyFile(file.DirectoryName.ToString & "\" & file.ToString,
                                                        NormalizePath(c_FolderCtrl.Text) & file.ToString, overwrite:=True)
                lbcCopyMove.Items.Add(file.DirectoryName.ToString & "\" & file.ToString & " " & file.LastWriteTime.ToString)
            Next

        Catch ex As Exception

            MessageBox.Show("File_Maintenace: CopyFiles: " & ex.Message)

        End Try
    End Sub

    Private Sub MoveFiles(sExt As String, c_FolderCtrl As ButtonEdit)
        Dim FileLastModDate As Date


        Try

            Dim directory = beCopyMoveMM2.Text

            Dim files() As System.IO.FileInfo
            Dim dirinfo As New System.IO.DirectoryInfo(directory)
            files = dirinfo.GetFiles(sExt, IO.SearchOption.AllDirectories)

            For Each file In files
                FileLastModDate = file.LastWriteTime

                My.Computer.FileSystem.MoveFile(file.DirectoryName.ToString & "\" & file.ToString,
                                                 NormalizePath(c_FolderCtrl.Text) & file.ToString, FileIO.UIOption.AllDialogs)


                lbcCopyMove.Items.Add(file.DirectoryName.ToString & "\" & file.ToString & " " & file.LastWriteTime.ToString)
            Next

        Catch ex As Exception

            MessageBox.Show("File_Maintenace: MoveFiles: " & ex.Message)

        End Try
    End Sub

    

    Private Sub DeleteFiles(sExt As String, c_FolderCtrl As ButtonEdit)
        Dim FileLastModDate As Date


        Try

            Dim directory = beCopyMoveMM2.Text

            Dim files() As System.IO.FileInfo
            Dim dirinfo As New System.IO.DirectoryInfo(directory)
            files = dirinfo.GetFiles(sExt, IO.SearchOption.AllDirectories)

            For Each file In files
                FileLastModDate = file.LastWriteTime

                My.Computer.FileSystem.DeleteFile(
                                                  file.DirectoryName.ToString & "\" & file.ToString,
                                                  FileIO.UIOption.AllDialogs,
                                                  FileIO.RecycleOption.SendToRecycleBin,
                                                  FileIO.UICancelOption.ThrowException)


                lbcCopyMove.Items.Add(file.DirectoryName.ToString & "\" & file.ToString & " " & file.LastWriteTime.ToString)
            Next

        Catch ex As Exception

            MessageBox.Show("File_Maintenace: DeleteFiles: " & ex.Message)

        End Try
    End Sub

    Private Sub ArchiveFiles()

    End Sub
    Private Sub beMM2ToFolder_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beMM2ToFolder.ButtonClick
        Try

            beMM2ToFolder.Text = ShowFolderDialog(NormalizePath(beMM2ToFolder.Text), beMM2ToFolder)


        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try
    End Sub

    Private Function ShowFolderDialog(s_SelectedPath As String, c_FolderCtrl As ButtonEdit) As String
        ShowFolderDialog = Nothing
        Try

            Dim m_folderDialog As New XtraFolderBrowserDialog

            m_folderDialog.SelectedPath = s_SelectedPath


            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                ShowFolderDialog = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try

        Return ShowFolderDialog

    End Function



    Private Sub beNSTToFolder_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beNSTToFolder.ButtonClick
        Try

            beNSTToFolder.Text = ShowFolderDialog(NormalizePath(beNSTToFolder.Text), beNSTToFolder)


        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try
    End Sub



    Private Sub beCNCToFolder_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCNCToFolder.ButtonClick
        Try

            beCNCToFolder.Text = ShowFolderDialog(NormalizePath(beCNCToFolder.Text), beCNCToFolder)


        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try
    End Sub


    Private Sub beCADToFolder_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCADToFolder.ButtonClick
        Try

            beCADToFolder.Text = ShowFolderDialog(NormalizePath(beCADToFolder.Text), beCADToFolder)


        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try
    End Sub


    Private Sub bePDBToFolder_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles bePDBToFolder.ButtonClick
        Try

            bePDBToFolder.Text = ShowFolderDialog(NormalizePath(bePDBToFolder.Text), bePDBToFolder)


        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try
    End Sub


    Private Sub beRPTToFolder_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beRPTToFolder.ButtonClick
        Try

            beRPTToFolder.Text = ShowFolderDialog(NormalizePath(beRPTToFolder.Text), beRPTToFolder)


        Catch ex As Exception

            MessageBox.Show("beCopyMoveToFolder_ButtonClick: " & ex.Message)
        End Try
    End Sub


End Class