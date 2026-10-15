Imports System.Data.OleDb

Public Class dlgRemnantControl

    Private Sub dlgRemnantControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cmd As OleDbCommand = Nothing

        sql = "Select [Remnant Control].* From [Remnant Control]"


        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    ltbMinRemLength.Text = ds.Tables(0).Rows(i).Item("Remnant Length")
                    ltbMinRemnantWidth.Text = ds.Tables(0).Rows(i).Item("Remnant Width")
                    ltbMinRemnantArea.Text = ds.Tables(0).Rows(i).Item("Remnant Area")
                    ltbRemnantDigits.Text = ds.Tables(0).Rows(i).Item("Remnant Digits")

                    If IsDBNull(ds.Tables(0).Rows(i).Item("Remnant Path")) = True Then
                        fcbRemnantPath.Text = NormalizePath(App_Path) & "Remnants"
                    Else
                        fcbRemnantPath.Text = ds.Tables(0).Rows(i).Item("Remnant Path")
                    End If

                    If ds.Tables(0).Rows(i).Item("Remnant First") = True Then
                        chkRemnantsFirst.CheckState = CheckState.Checked
                    Else
                        chkRemnantsFirst.CheckState = CheckState.Unchecked
                    End If
                Next


            End If

            If connection IsNot Nothing Then connection = Nothing
            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
            If ds IsNot Nothing Then ds = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub sbOKButton_Click(sender As Object, e As EventArgs) Handles sbOKButton.Click
        Me.Close()
    End Sub

    Private Sub cmdRemnantEditUpdate_Click(sender As Object, e As EventArgs) Handles cmdRemnantEditUpdate.Click
        Dim sql As String = Nothing
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim connetionString As String = Nothing
        Dim n_Workplane_Type As Long = 0
        Dim n_Units As Long = 0
        Dim CTG_Name As String = Nothing
        Dim cmd As OleDbCommand


        Try
            If cmdRemnantEditUpdate.Text = "Edit" = True Then
                cmdRemnantEditUpdate.Text = "Apply"
                ltbMinRemLength.Enabled = True
                ltbMinRemnantWidth.Enabled = True
                ltbMinRemnantArea.Enabled = True
                ltbRemnantDigits.Enabled = True
                chkRemnantsFirst.Enabled = True

                fcbRemnantPath.Enabled = True


            Else

                cmdRemnantEditUpdate.Text = "Edit"

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

                connection = New OleDbConnection(connetionString)

                connection.Open()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Remnant Length] = '" & ltbMinRemLength.Text & "'"

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Remnant Width] = '" & ltbMinRemnantWidth.Text & "'"

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Remnant Area] = '" & ltbMinRemnantArea.Text & "'"

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Remnant Digits] = '" & ltbRemnantDigits.Text & "'"

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Remnant Path] = '" & fcbRemnantPath.Text & "'"

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Remnant First] = " & chkRemnantsFirst.CheckState

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                sql = "UPDATE [Remnant Control] set [Remnant Control].[Cutback] = " & False

                cmd = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                connection.Close()

                sReturn = RegPutString("Nesting", "Remnant Path", fcbRemnantPath.Text)

                ltbMinRemLength.Enabled = False
                ltbMinRemnantWidth.Enabled = False
                ltbMinRemnantArea.Enabled = False
                ltbRemnantDigits.Enabled = False
                chkRemnantsFirst.Enabled = False

                fcbRemnantPath.Enabled = False

            End If
        Catch ex As Exception

            MessageBox.Show("cmdRemnantEditUpdate_Clickd Error: " & ex.Message)
        End Try

    End Sub

    Private Sub fcbRemnantPath_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles fcbRemnantPath.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try

            m_folderDialog.SelectedPath = fcbRemnantPath.Text

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                fcbRemnantPath.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("fcbRemnantPath_ButtonClick Error: " & ex.Message)

        End Try

    End Sub

    Private Sub fcbRemnantPath_EditValueChanged(sender As Object, e As EventArgs) Handles fcbRemnantPath.EditValueChanged

    End Sub
End Class