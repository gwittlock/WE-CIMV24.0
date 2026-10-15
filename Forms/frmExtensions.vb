Public Class frmExtensions

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sExtension As String
        sExtension = InputBox("Enter New Extension:", "Add Extension")

        If (sExtension <> "") Then
            ListBoxControl1.Items.Add(sExtension & " Files")

            RegPutString("CodeGeneration\CNCExtensions", sExtension, sExtension)
        End If


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim sExtension As String

        sExtension = ListBoxControl1.SelectedValue
        RegDeleteSetting("CodeGeneration", "CNCExtensions", "", sExtension)
        ListBoxControl1.Items.Remove(ListBoxControl1.SelectedIndex)

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Me.Close()

    End Sub

    '    Private Sub frmExtensions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub frmExtensions_Load(sender As Object, e As EventArgs) Handles Me.Load

        GetExtensions()

    End Sub

    Private Sub GetExtensions()
        Dim sExtensions As String()
        Dim ni As Integer

        ListBoxControl1.Items.Clear()
        sExtensions = EnumerateRegValues("CodeGeneration\\CNCExtensions\\")

        For ni = 0 To UBound(sExtensions)

            ListBoxControl1.Items.Add(sExtensions(ni))

        Next

    End Sub
End Class