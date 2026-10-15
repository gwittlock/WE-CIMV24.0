Public Class dlgPatternExplode
    Implements IDialogMouseUp

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

    Public Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp

        ClientMouseUp = 1

    End Function

    Private Sub dlgPatternExplode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub

    '    Private Sub dlgPatternExplode_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub dlgPatternExplode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lPatternCount As Long
        Dim nI As Integer
        Dim lPatID As Long
        Dim sPatName As String

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

    'Private Sub btnAccept_Click(sender As Object, e As EventArgs)

    '    Try

    '        If chkExplodeAll.CheckState = CheckState.Unchecked Then

    '            UndoPrepare()

    '            lReturn = PortalExecute("Pattern:Explode:id=" & Me.ltbPatternID.Text)
    '            lReturn = PortalExecute("admin:regen:")

    '            UndoCommit()

    '            frmEntityList.FillTreeView()

    '            MsgBox("Explode Complete.", vbOKOnly)
    '        Else

    '            Windows.Forms.Cursor.Current = Cursors.WaitCursor

    '            UndoPrepare()

    '            lReturn = PortalExecute("Pattern:Explode:all=1")
    '            MsgBox("Explode Complete.", vbOKOnly)

    '            UndoCommit()

    '            Windows.Forms.Cursor.Current = Cursors.Default


    '        End If

    '        modView.ViewRegen()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub



    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click

        Try

            If (chkExplodeAll.CheckState = CheckState.Unchecked) Then

                UndoPrepare()

                lReturn = PortalExecute("Pattern:Explode:id=" & Me.ltbPatternID.Text)
                lReturn = PortalExecute("admin:regen:")

                UndoCommit()

                frmEntityList.FillTreeView()

                MessageBox.Show("Explode complete", "Explode", MessageBoxButtons.OK)

            Else

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                UndoPrepare()

                lReturn = PortalExecute("Pattern:Explode:all=1")

                UndoCommit()


                Windows.Forms.Cursor.Current = Cursors.Default

                MessageBox.Show("Explode complete", "Explode", MessageBoxButtons.OK)

            End If

            modView.ViewRegen()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstPattern_Click(sender As Object, e As EventArgs) Handles lstPattern.Click
        Dim n_SelIndex As Integer

        Try

            n_SelIndex = Me.lstPattern.SelectedIndex

            If (n_SelIndex >= 0) Then
                ltbPatternID.Text = (TryCast(lstPattern.Items(n_SelIndex), myItemData)).ItemData.ToString()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lstPattern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPattern.SelectedIndexChanged

    End Sub
End Class