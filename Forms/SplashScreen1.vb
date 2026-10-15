Public Class SplashScreen1
    Sub New

        InitializeComponent()
        '#If CCS_FAB Then
        '        pictureEdit2.Image = My.Resources.Resources.BenchMarkTransLogo
        '#Else
        pictureEdit2.Image = My.Resources.Resources.WE_CIM_CAD_CAM_All_V24_Text

        '#End If


    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub SplashScreen1_Load(sender As Object, e As EventArgs) Handles Me.Load
        bShowSplash = True

#If ADVROTOR Then
        PictureEdit1 .Visible =true 
#Else
        pictureEdit2.Visible = True
#End If
    End Sub

    Private Sub pictureEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles pictureEdit2.EditValueChanged

    End Sub
End Class
