Imports DevExpress.XtraBars
Imports System.Data.OleDb

Public Class dlgCustomMacros
    Private sIconFilename As String
    Private sJavaFileName As String
    Private sMenuName As String

    Private Sub beMacroIcon_Click(sender As Object, e As EventArgs) Handles beMacroIcon.Click

        Try

            dlgOpenDialog.Title = "Open Icon File"
            dlgOpenDialog.Filter = "Icon Files (*.ico)|*.ico"
            dlgOpenDialog.InitialDirectory = NormalizePath(App_Path) & "Icons"
            dlgOpenDialog.ShowDialog(Me)

            If Len(dlgOpenDialog.FileName) = 0 Then

                Exit Sub

            Else

                beMacroIcon.Text = TrimToFit(dlgOpenDialog.FileName, 30)
                picIcon.Image = System.Drawing.Image.FromFile(dlgOpenDialog.FileName)
                sIconFilename = dlgOpenDialog.FileName

            End If

        Catch ex As Exception

            MessageBox.Show("beMacroIcon_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub beMacroFile_Click(sender As Object, e As EventArgs) Handles beMacroFile.Click

        Try

            dlgOpenDialog.Title = "Open Java File"
            dlgOpenDialog.Filter = "Java Files (*.java)|*.java"
            dlgOpenDialog.InitialDirectory = NormalizePath(App_Path) & "macros"
            dlgOpenDialog.ShowDialog(Me)

            If Len(dlgOpenDialog.FileName) = 0 Then

                Exit Sub

            Else

                beMacroFile.Text = TrimToFit(dlgOpenDialog.FileName, 30)
                sJavaFileName = dlgOpenDialog.FileName

            End If

        Catch ex As Exception

            MessageBox.Show("beMacroFile_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub sbDone_Click(sender As Object, e As EventArgs) Handles sbDone.Click

        Me.Dispose()

    End Sub

    Private Sub sbApply_Click(sender As Object, e As EventArgs) Handles sbApply.Click
        Dim NewBarButtonItem As BarButtonItem = New BarButtonItem()

        Try

            NewBarButtonItem.PaintStyle = BarItemPaintStyle.Standard
            NewBarButtonItem.Caption = sMenuName
            NewBarButtonItem.LargeGlyph = System.Drawing.Image.FromFile(sIconFilename)
            NewBarButtonItem.Tag = sJavaFileName

            frmMain.rpgCustomMacros.ItemLinks.Add(NewBarButtonItem)

            lstMacros.Items.Add(sMenuName)

            AddButtonToAppDB()

        Catch ex As Exception

            MessageBox.Show("sbApply_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub teMenuName_TextChanged(sender As Object, e As EventArgs) Handles teMenuName.TextChanged
        sMenuName = teMenuName.Text

    End Sub

    Private Sub AddButtonToAppDB()
        Dim m_cnMacro As New OleDb.OleDbConnection
        Dim m_daMacro As OleDb.OleDbDataAdapter
        Dim m_cbMacro As OleDb.OleDbCommandBuilder
        Dim m_dtMacro As New DataTable
        Dim sql As String
        Dim drNewRow As DataRow = m_dtMacro.NewRow()

        Try

            sql = "SELECT [Icon].* FROM [Icon]"

            m_cnMacro.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathAppDB()
            m_cnMacro.Close()
            m_cnMacro.Dispose()
            m_cnMacro.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathAppDB()
            m_cnMacro.Open()
            m_daMacro = New OleDb.OleDbDataAdapter(sql, m_cnMacro)
            m_cbMacro = New OleDb.OleDbCommandBuilder(m_daMacro)
            m_daMacro.Fill(m_dtMacro)


            drNewRow("ID") = (GetHighestId())
            drNewRow("Display") = teMenuName.Text
            drNewRow("ToolBarID") = "1500"
            drNewRow("Icon_FilePath") = sIconFilename
            drNewRow("Macro_FilePath") = sJavaFileName
            drNewRow("Show_Dialog") = chkShowDialog.Checked


            m_dtMacro.Rows.Add(drNewRow)
            m_daMacro.Update(m_dtMacro)

            m_dtMacro.Dispose()
            m_daMacro.Dispose()

            m_cnMacro.Close()

            If m_cnMacro IsNot Nothing Then m_cnMacro = Nothing

            If m_daMacro IsNot Nothing Then m_daMacro = Nothing

            If m_dtMacro IsNot Nothing Then m_dtMacro = Nothing

        Catch ex As Exception

            MessageBox.Show("AddButtonToAppDB: " & ex.Message)

        End Try
    End Sub
    Private Function GetHighestId() As Long
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim n_Highest_ID As Long

        Try

            n_Highest_ID = 1500

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            sql = "SELECT * FROM Icon WHERE (Icon.ToolBarID = 1500 )"

            connection = New OleDbConnection(connetionString)
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                If (ds.Tables(0).Rows(i).Item("ID") > n_Highest_ID) Then

                    n_Highest_ID = ds.Tables(0).Rows(i).Item("ID")

                End If


            Next

            GetHighestId = n_Highest_ID + 1
            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        Catch ex As Exception

            MessageBox.Show("GetHighestId: " & ex.Message)

        End Try

    End Function

    Private Sub LoadIconList()
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String

        lstMacros.Items.Clear()

        Try
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            sql = "SELECT * FROM Icon WHERE (Icon.ToolBarID = 1500 )"

            connection = New OleDbConnection(connetionString)


            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                lstMacros.Items.Add(New myItemData(ds.Tables(0).Rows(i).Item("Display"), ds.Tables(0).Rows(i).Item("ID")))

            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing


        Catch ex As Exception

            MessageBox.Show("GetHighestId: " & ex.Message)

        Finally



        End Try
    End Sub

    Private Sub dlgCustomMacros_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadIconList()

    End Sub

    Private Sub sbRemoveMacro_Click(sender As Object, e As EventArgs) Handles sbRemoveMacro.Click
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim cmd As OleDbCommand
        Dim n_SelIndex As Long
        Dim lid As Long

        Try
            n_SelIndex = lstMacros.SelectedIndex

            lid = (TryCast(lstMacros.Items(n_SelIndex), myItemData)).ItemData.ToString()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            sql = "Delete Icon.* From Icon Where (Icon.ID = '" & lid & "' )"

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            connection.Close()

            LoadIconList()


        Catch ex As Exception

            MessageBox.Show("sbRemoveMacro_Click: " & ex.Message)


        End Try


    End Sub

    Private Sub lstMacros_Click(sender As Object, e As EventArgs) Handles lstMacros.Click
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim n_SelIndex As Long
        Dim lid As Long

        Try
            n_SelIndex = lstMacros.SelectedIndex

            lid = (TryCast(lstMacros.Items(n_SelIndex), myItemData)).ItemData.ToString()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            connection = New OleDbConnection(connetionString)

            sql = "Select Icon.* From Icon Where (Icon.ID = '" & lid & "' )"

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then


                For i = 0 To ds.Tables(0).Rows.Count - 1

                    beMacroFile.Text = ds.Tables(0).Rows(i).Item("Macro_FilePath")
                    teMenuName.Text = ds.Tables(0).Rows(i).Item("Display")
                    beMacroIcon.Text = ds.Tables(0).Rows(i).Item("Icon_FilePath")
                    chkShowDialog.CheckState = ds.Tables(0).Rows(i).Item("Show_Dialog")
                    picIcon.Image = System.Drawing.Image.FromFile(ds.Tables(0).Rows(i).Item("Icon_FilePath"))

                Next

            End If

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing
            If connection IsNot Nothing Then connection = Nothing
            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        Catch ex As Exception

            MessageBox.Show("lstMacros_Click: " & ex.Message)

        End Try

    End Sub
End Class
