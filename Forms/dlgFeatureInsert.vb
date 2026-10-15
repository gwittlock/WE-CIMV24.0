Public Class dlgFeatureInsert
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

    End Function

    Private Sub dlgFeatureInsert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim featureID As Long
        Dim n_SelIndex As Integer

        Try

            n_SelIndex = Me.lstFeatures.SelectedIndex

            featureID = (TryCast(lstFeatures.Items(n_SelIndex), myItemData)).ItemData.ToString()

            UndoPrepare()

            lReturn = FeatureAddSelected(featureID)

            UndoCommit()


            If (bIsEntityLoaded = True) Then frmEntityList.FillTreeView()

            'TOD V21 frmPicModeler.SynchronizeUI(SelectedCount)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dlgFeatureInsert_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim lFeatureCount As Long
        Dim nI As Integer
        Dim lFeatureID As Long
        Dim sFeatureName As String

        lstFeatures.Items.Clear()

        Try

            lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBFEATURE)
            lFeatureCount = PortalGetInt("count", 0)

            For nI = 0 To lFeatureCount - 1
                lReturn = PortalExecute("*Model:Get2:indx=" & nI & ",type=" & c_DBFEATURE)
                lFeatureID = PortalGetInt("id", 0)
                sFeatureName = EntityStringGet(lFeatureID, "name", "")
                If InStr(1, UCase(sFeatureName), "WORKZONE") = 0 And InStr(1, UCase(sFeatureName), "REPO_ZONE") = 0 Then
                    lstFeatures.Items.Add(New myItemData(sFeatureName, lFeatureID))
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstFeatures_MouseMove(sender As Object, e As MouseEventArgs) Handles lstFeatures.MouseMove
        Dim lFeatureID As Long
        Dim listBoxControl As ListBoxControl = TryCast(sender, ListBoxControl)
        Dim nItemIndex As Integer = listBoxControl.IndexFromPoint(New Point(e.X, e.Y))

        If nItemIndex > 0 Then

            lFeatureID = (TryCast(lstFeatures.Items(nItemIndex), myItemData)).ItemData.ToString()
            lReturn = PortalExecute("!view:highlight:id=" & lFeatureID)
        End If
    End Sub
End Class