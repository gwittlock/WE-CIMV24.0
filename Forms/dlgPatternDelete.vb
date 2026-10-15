Public Class dlgPatternDelete
    Implements IDialogMouseUp

    Public Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp

        ClientMouseUp = 1

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

    Private Sub dlgPatternDelete_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub

    '    Private Sub dlgPatternDelete_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub


    Private Sub dlgPatternDelete_Load(sender As Object, e As EventArgs) Handles Me.Load

        FillPatternList()

    End Sub
    Private Sub FillPatternList()
        Dim lPatternCount As Long
        Dim nI As Integer
        Dim lPatID As Long
        Dim sPatName As String

        lstPattern.Items.Clear()

        Try

            lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBPATTERN)
            lPatternCount = PortalGetInt("count", 0)

            For nI = 0 To lPatternCount - 1
                lReturn = PortalExecute("*Model:Get2:indx=" & nI & ",type=" & c_DBPATTERN)
                lPatID = PortalGetInt("id", 0)

                sPatName = EntityStringGet(lPatID, "_label", "<error>")

                lstPattern.Items.Add(New myItemData(sPatName, lPatID))

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub lstPattern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPattern.SelectedIndexChanged
        Dim n_SelIndex As Integer

        Try

            n_SelIndex = Me.lstPattern.SelectedIndex

            If (n_SelIndex >= 0) Then
                ltbPatternID.Text = (TryCast(lstPattern.Items(n_SelIndex), myItemData)).ItemData.ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("lstPattern_SelectedIndexChanged() : " & ex.Message)
        End Try

    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click

        Try

            UndoPrepare()

            lReturn = PortalExecute("create:delete:id=" & ltbPatternID.Text)

            FillPatternList()

            frmMain.PatternComboShow()

            UndoCommit()

            modView.ViewRefresh()

        Catch ex As Exception

            MessageBox.Show(DirectCast(sender, DevExpress.XtraEditors.SimpleButton).Name & " " & ex.Message)
        End Try

    End Sub
End Class