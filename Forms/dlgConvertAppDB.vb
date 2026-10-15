Imports DevExpress.XtraEditors.Controls
Imports System.Data.OleDb
Imports System.Windows.Forms.OpenFileDialog

Public Class dlgConvertAppDB
    Dim sOldAppDBPath As String
    Private m_is_active As Boolean

    Public Function IsActive() As Boolean
        IsActive = m_is_active
    End Function

    Private Sub beIconPath_Click(sender As Object, e As EventArgs) Handles beIconPath.Click
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            beIconPath.Text = m_folderDialog.SelectedPath
            beIconPath.Tag = m_folderDialog.SelectedPath

        End If
    End Sub

    Private Sub beNewMacroPath_Click(sender As Object, e As EventArgs) Handles beNewMacroPath.Click
        Dim m_folderDialog As New FolderBrowserDialog()

        If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            beNewMacroPath.Text = m_folderDialog.SelectedPath
            beNewMacroPath.Tag = m_folderDialog.SelectedPath

        End If
    End Sub
    Private Function SaveFileAs()
        Dim sResultname As String


        SaveFileDialog1.Filter = "MDB Files (*.mdb)|*.mdb"

        SaveFileAs = ""

        If (beNewAppDBName.Text) = "" Then
            SaveFileDialog1.InitialDirectory = Application.StartupPath & "\Database\"
            SaveFileDialog1.FileName = Application.StartupPath & "\Database\AppDB.mdb"
            'frmMain.SaveFileDialog1.DefaultExt = LCase$(sExt)

        Else

            SaveFileDialog1.InitialDirectory = NormalizePath(PathDriveFolder(beNewAppDBName.Text))
            SaveFileDialog1.FileName = PathFile(beNewAppDBName.Text)
            'frmMain.SaveFileDialog1.DefaultExt = "mm2"

        End If

        SaveFileDialog1.ShowDialog()

        sResultname = SaveFileDialog1.FileName

        SaveFileAs = sResultname

    End Function
    Private Sub sbOk_Click(sender As Object, e As EventArgs) Handles sbOk.Click
        Dim ds As New DataSet
        Dim dsParts As DataSet

        Dim connection As New OleDbConnection
        Dim oledbAdapter As New OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim connection2 As New OleDbConnection
        Dim oledbAdapte2r As New OleDbDataAdapter
        Dim connetionString2 As String
        Dim sql2 As String
        Dim oldAppDB As String
        Dim NewAppdb As String = Application.StartupPath & "\Database\appdb.mdb"
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim sID As String
        Dim sDispaly As String

        Dim sToolBarId As Long
        Dim sIcon_FilePath As String
        Dim sIconFileName As String
        Dim sMacroFileName As String
        Dim sMacroFilePath As String
        Dim bShow_Dialog As Boolean
        Dim m_cnPart As New OleDb.OleDbConnection
        Dim m_daPart As New OleDb.OleDbDataAdapter
        Dim m_dtPart As New DataTable
        Dim cmdGetID As New OleDbCommand
        Dim m_cnPart2 As New OleDb.OleDbConnection
        Dim m_daPart2 As New OleDb.OleDbDataAdapter
        Dim m_dtPart2 As New DataTable
        Dim cmdGetID2 As New OleDbCommand
        Dim lCounter As Long = 0
        Dim lCount As Long = 0
        Dim cnt As Long
        Dim sNewAppDBPath As String

        sNewAppDBPath = beNewAppDBName.Text

        FileCopy(Application.StartupPath & "\database\appdb.mdb", sNewAppDBPath)


        sFieldNames = "[ID]," &
           "[Display]," &
          "[ToolBarId]," &
          "[Icon_FilePath]," &
          "[Macro_FilePath]," &
          "[Show_Dialog]"

        oldAppDB = beOldAppDBPath.Tag

        'sql = "Select Icon.* From Icon Where (Icon.ToolBarID = 1500 )"

        sql = "SELECT [Icon].* FROM [Icon]"

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & oldAppDB & "';"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)


        dsParts = New DataSet

        oledbAdapter.Fill(dsParts)

        oledbAdapter.Dispose()

        cnt = dsParts.Tables(0).Rows.Count

        If cnt > 0 Then

            For lCounter = cnt - 1 To 0 Step -1

                'dsParts.Tables(0).Rows(cnt - 1).Delete()
                dsParts.Tables(0).Rows.RemoveAt(lCounter - 1)
                If lCounter = 80 Then
                    GoTo Skip
                    MessageBox.Show("we hit 80")
                End If

            Next
            'For i = 0 To cnt - 1

            'If (IsDBNull(dsParts.Tables(0).Rows(i).Item("Icon_FilePath")) = False) Then
            '    'MessageBox.Show("Into If")

            '    sID = dsParts.Tables(0).Rows(i).Item("ID")
            '    'MessageBox.Show("Get ID " & sID)

            '    sDispaly = dsParts.Tables(0).Rows(i).Item("Display")
            '    'MessageBox.Show("Get sDispaly " & sDispaly)

            '    sToolBarId = dsParts.Tables(0).Rows(i).Item("ToolBarId")
            '    'MessageBox.Show("Get sToolBarId " & sToolBarId)

            '    sIcon_FilePath = dsParts.Tables(0).Rows(i).Item("Icon_FilePath")
            '    'MessageBox.Show("Get sIcon_FilePath " & sIcon_FilePath)

            '    sIconFileName = NormalizePath(beIconPath.Text) & PathFileExt(sIcon_FilePath)
            '    'MessageBox.Show("Get sIconFileName " & sIconFileName)

            '    sMacroFilePath = dsParts.Tables(0).Rows(i).Item("Macro_FilePath")
            '    'MessageBox.Show("Get sMacroFilePath " & sMacroFilePath)

            '    sMacroFileName = NormalizePath(beNewMacroPath.Text) & PathFileExt(sMacroFilePath)
            '    'MessageBox.Show("Get sMacroFileName " & sMacroFileName)

            '    bShow_Dialog = dsParts.Tables(0).Rows(i).Item("Show_Dialog")
            '    'MessageBox.Show("Get bShow_Dialog " & bShow_Dialog)

            '    sFieldValues = "'" & sID & "','" & sDispaly & "'," & sToolBarId & ",'" & sIconFileName & "','" & sMacroFileName & "'," & bShow_Dialog

            '    sql2 = "INSERT INTO [Icon] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

            '    'MessageBox.Show("The command is " & sql2)

            '    connetionString2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & NewAppdb & "';"

            '    m_cnPart2 = New OleDbConnection(connetionString2)

            '    m_cnPart2.Open()

            '    m_daPart2.InsertCommand = New OleDbCommand(sql2, m_cnPart2)

            '    m_daPart2.InsertCommand.ExecuteNonQuery()

            '    cmdGetID2.Connection = m_cnPart2

            '    cmdGetID2.CommandText = "SELECT MAX(ID) FROM [Part]"

            '    m_cnPart2.Dispose()

            '    m_cnPart2.Close()
        End If
        'Next
        ' End If
Skip:
        RegPutString("Convert AppDB", "oldAppDB", beOldAppDBPath.Tag)
        sReturn = RegPutString("Convert AppDB", "sIcon_FilePath", beIconPath.Tag)
        sReturn = RegPutString("Convert AppDB", "sMacroFilePath", beNewMacroPath.Tag)
        sReturn = RegPutString("Convert AppDB", "sNewAppDBPath", beNewAppDBName.Tag)

        m_dtPart.Dispose()
        m_cnPart.Dispose()
        m_cnPart.Close()

        If m_dtPart IsNot Nothing Then m_dtPart = Nothing

        If m_daPart IsNot Nothing Then m_daPart = Nothing

        If m_cnPart IsNot Nothing Then m_cnPart = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If dsParts IsNot Nothing Then dsParts = Nothing

        If connection IsNot Nothing Then connection = Nothing
        MessageBox.Show("Process Complete!")

        lReturn = SetAppDBVersion("24.021")

    End Sub

    Private Sub beOldAppDBPath_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beOldAppDBPath.ButtonClick
        Try

            dlgOpenDialog.Title = "Open AppDB File"
            dlgOpenDialog.Filter = "AppDB Files (*.mdb)|*.mdb"
            dlgOpenDialog.InitialDirectory = NormalizePath(App_Path) & "macros"
            dlgOpenDialog.ShowDialog(Me)

            If Len(dlgOpenDialog.FileName) = 0 Then

                Exit Sub

            Else

                beOldAppDBPath.Text = TrimToFit(dlgOpenDialog.FileName, 30)
                sOldAppDBPath = dlgOpenDialog.FileName
                beOldAppDBPath.Tag = sOldAppDBPath
            End If

        Catch ex As Exception

            MessageBox.Show("beOldAppDBPath_ButtonClick: " & ex.Message)

        End Try
    End Sub

    Private Sub beNewAppDBName_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beNewAppDBName.ButtonClick
        beNewAppDBName.Text = SaveFileAs()
        beNewAppDBName.Tag = beNewAppDBName.Text
    End Sub

    Private Sub dlgConvertAppDB_Load(sender As Object, e As EventArgs) Handles Me.Load
        beOldAppDBPath.Text = RegGetString("Convert AppDb", "oldAppDB", "")
        beIconPath.Text = RegGetString("Convert AppDB", "sIcon_FilePath", "")
        beNewMacroPath.Text = RegGetString("Convert AppDB", "sMacroFilePath", "")
        beNewAppDBName.Text = RegGetString("Convert Appdb", "sNewAppDBPath", "")
        beOldAppDBPath.Tag = RegGetString("Convert AppDb", "oldAppDB", "")
        beIconPath.Tag = RegGetString("Convert AppDB", "sIcon_FilePath", "")
        beNewMacroPath.Tag = RegGetString("Convert AppDB", "sMacroFilePath", "")
        beNewAppDBName.Tag = RegGetString("Convert Appdb", "sNewAppDBPath", "")

        m_is_active = True
    End Sub


    Private Sub dlgConvertAppDB_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        m_is_active = False
        frmMain.CloseFirstPanel()
        modView.ViewRegen()
    End Sub
End Class