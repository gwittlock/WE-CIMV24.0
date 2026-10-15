Public Class dlgDegMagSplash
    Sub New
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Private Sub dlgDegMagSplash_Load(sender As Object, e As EventArgs) Handles Me.Load
        'pictureEdit2.Image = My.Resources.DemagStatorStartup
        'pictureEdit2.Image = My.Resources.DemagRotorStartup
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum
End Class
