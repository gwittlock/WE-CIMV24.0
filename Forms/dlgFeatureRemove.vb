Public Class dlgFeatureRemove
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

    Private Sub dlgFeatureRemove_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim nEntityCount As Long
        Dim nFeatureID As Long
        Dim nEntityID As Long
        Dim nI As Long
        Dim n_SelIndex As Integer

        Try

            n_SelIndex = Me.lstFeatures.SelectedIndex

            nFeatureID = (TryCast(lstFeatures.Items(n_SelIndex), myItemData)).ItemData.ToString()


            UndoPrepare()

            nEntityCount = FeatureCount(nFeatureID)

            lReturn = SelectorPush()

            lReturn = modSelection.DeselectAll()

            For nI = nEntityCount - 1 To 0 Step -1
                nEntityID = FeatureEntityGet(nFeatureID, nI)
                lReturn = SelectEntity(nEntityID)
            Next

            lReturn = FeatureOrphanSelected()

            lReturn = SelectorPop()

            lReturn = PortalExecute("Create:Delete: id=" & nFeatureID)

            UndoCommit()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dlgFeatureRemove_Load(sender As Object, e As EventArgs) Handles Me.Load
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
End Class