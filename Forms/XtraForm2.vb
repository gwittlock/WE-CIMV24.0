Imports System.Data.OleDb
Imports System.IO

Public Class XtraForm2
    Private Sub sbSearch_Click(sender As Object, e As EventArgs) Handles sbSearch.Click
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim nI As Integer
        Dim sMyNCCodeNumber As String
        Dim lMyStationID As Long
        Dim sMyToolDescription As String
        Dim lMyOrderID As Long
        Dim lMyToolID As Long
        Dim dMyIndexAngle As Double
        Dim bMyFixedSation As Boolean
        Dim tableNumber = 0
        Dim stempfilename As System.IO.StreamWriter

        If (FileExists("C:\1wittlockeng\Customers\APIHeatTransfer\Docs\tooling.csv") = True) Then
            Kill("C:\1wittlockeng\Customers\APIHeatTransfer\Docs\tooling.csv")

        End If
        stempfilename = My.Computer.FileSystem.OpenTextFileWriter("C:\1wittlockeng\Customers\APIHeatTransfer\Docs\tooling.csv", True)

        lstTools.Items.Clear()
        lstStations.Items.Clear()


        sql = "Select [Tool Setups].* From [Tool Setups] Where ([Tool Setups].[Machine ID] = 15 )"

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        connection = New OleDbConnection(connetionString)

        Try
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()



            For i = 0 To ds.Tables(0).Rows.Count - 1

                sql = "SELECT [Tool Setup Members].[Tool Setup ID], [Tool Setup Members].[Index Angle]," &
                "[Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[Tool ID]," &
                "[Tool Setup Members].[Station ID], [Tool Setup Members].[Fixed Station], [Tool Setup Members].ID" &
                " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] ON " &
                "[Station Configuration].ID = [Tool Setup Members].[Station ID]) ON [Tool Crib].ID = " &
                "[Tool Setup Members].[Tool ID] WHERE ((([Tool Setup Members].[Tool Setup ID])=" &
                 ds.Tables(0).Rows(i).Item("ID") & " ))" & " ORDER BY [Tool Setup Members].ID"

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(ds2)

                oledbAdapter.Dispose()

                For nI = 0 To ds2.Tables(0).Rows.Count - 1
                    sMyNCCodeNumber = Convert.ToString(ds2.Tables(tableNumber).Rows(i)("NC Code Number"))
                    lMyStationID = ds2.Tables(tableNumber).Rows(i)("Station ID")
                    sMyToolDescription = Convert.ToString(ds2.Tables(tableNumber).Rows(i)("Description"))
                    lMyOrderID = ds2.Tables(tableNumber).Rows(i)("ID")
                    lMyToolID = ds2.Tables(tableNumber).Rows(i)("Tool ID")
                    dMyIndexAngle = ds2.Tables(tableNumber).Rows(i)("Index Angle")
                    bMyFixedSation = ds2.Tables(tableNumber).Rows(i)("Fixed Station")

                    If (CheckEntryToListBox(sMyToolDescription, lstTools) = False) Then
                        lstTools.Items.Add(sMyToolDescription)
                        lstStations.Items.Add(sMyNCCodeNumber)

                        stempfilename.WriteLine(sMyNCCodeNumber & "," & sMyToolDescription)
                    End If
                Next
            Next

            ds.Dispose()
            connection.Dispose()
            connection.Close()
            stempfilename.Close()
            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        Catch ex As Exception

            MessageBox.Show("FillDefnCombo: " & ex.Message)

        Finally

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing

        End Try
    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Close()
    End Sub

    Private Sub XtraForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim nI As Integer
        Dim s_AppDBName As String
        Dim sMyDescription As String

        For Each item In fgList.Items
            If (item.selected = True) Then

                s_AppDBName = fldrVw.SelectedNode.Path & "\" & item.DisplayName

                MessageBox.Show("The file is < " & s_AppDBName & " > ")


                sql = "Select Icon.* From Icon Where (Icon.ID > '0' )"

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & s_AppDBName & "';"

                connection = New OleDbConnection(connetionString)

                Try
                    connection.Open()

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    oledbAdapter.Fill(ds)

                    oledbAdapter.Dispose()

                    For i = 0 To ds.Tables(0).Rows.Count - 1

                        sMyDescription = Convert.ToString(ds.Tables(0).Rows(i)("Icon_FilePath"))

                        MessageBox.Show("The Icon_FilePath is < " & sMyDescription & " > ")
                    Next

                    'ubgPartsView.AppendRow(New Object() {ltbDefaultQTY.Text, 0, ltbDefaultRotation.Text, lcbRepresentation.List(lcbRepresentation.ListIndex), item.DisplayName, sPartname})

                    'Dim my_rowHandle = ubgPartsView.FocusedRowHandle

                    'For i = 6 To ubgPartsView.Columns.Count - 1

                    '    TheValue = GetValueFromDelimitedData(ubgPartsView.Columns(i).Tag, "VBValue", 0)
                    '    sDatVarName = GetValueFromDelimitedData(ubgPartsView.Columns(i).Tag, "DatVarName", Nothing)
                    '    ubgPartsView.SetRowCellValue(my_rowHandle, sDatVarName, TheValue)

                    'Next

                    'cmdOk.Enabled = True
                Catch ex As Exception

                    MessageBox.Show("FillDefnCombo: " & ex.Message)

                End Try

            End If

        Next



        '    For i = 0 To ds.Tables(0).Rows.Count - 1

        '        sql = "SELECT [Tool Setup Members].[Tool Setup ID], [Tool Setup Members].[Index Angle]," &
        '        "[Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[Tool ID]," &
        '        "[Tool Setup Members].[Station ID], [Tool Setup Members].[Fixed Station], [Tool Setup Members].ID" &
        '        " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] ON " &
        '        "[Station Configuration].ID = [Tool Setup Members].[Station ID]) ON [Tool Crib].ID = " &
        '        "[Tool Setup Members].[Tool ID] WHERE ((([Tool Setup Members].[Tool Setup ID])=" &
        '         ds.Tables(0).Rows(i).Item("ID") & " ))" & " ORDER BY [Tool Setup Members].ID"

        '        oledbAdapter = New OleDbDataAdapter(sql, connection)

        '        oledbAdapter.Fill(ds2)

        '        oledbAdapter.Dispose()

        '        For nI = 0 To ds2.Tables(0).Rows.Count - 1
        '            sMyNCCodeNumber = Convert.ToString(ds2.Tables(tableNumber).Rows(i)("NC Code Number"))
        '            lMyStationID = ds2.Tables(tableNumber).Rows(i)("Station ID")
        '            sMyToolDescription = Convert.ToString(ds2.Tables(tableNumber).Rows(i)("Description"))
        '            lMyOrderID = ds2.Tables(tableNumber).Rows(i)("ID")
        '            lMyToolID = ds2.Tables(tableNumber).Rows(i)("Tool ID")
        '            dMyIndexAngle = ds2.Tables(tableNumber).Rows(i)("Index Angle")
        '            bMyFixedSation = ds2.Tables(tableNumber).Rows(i)("Fixed Station")

        '            If (CheckEntryToListBox(sMyToolDescription, lstTools) = False) Then
        '                lstTools.Items.Add(sMyToolDescription)
        '                lstStations.Items.Add(sMyNCCodeNumber)

        '                stempfilename.WriteLine(sMyNCCodeNumber & "," & sMyToolDescription)
        '            End If
        '        Next
        '    Next

        '    ds.Dispose()
        '    connection.Dispose()
        '    connection.Close()
        '    stempfilename.Close()

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
    End Sub
End Class