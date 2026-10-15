Public Class frmAboutBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmAboutBox_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Dispose()
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String

        Try


#If ADVROTOR Then
            PictureBox1.Image = My.Resources.DemagLaminationCropped
            'PictureBox1.Image = My.Resources.DemagSplashStator_Cropped
#Else
            PictureBox1.Image = My.Resources.WE_CIM_ADVFAB
#End If
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Me.Text = String.Format("About {0}", ApplicationTitle)
            ' Initialize all of the text displayed on the About Box.
            ' TODO: Customize the application's assembly information in the "Application" pane of the project 
            '    properties dialog (under the "Project" menu).
            Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
            Me.LabelCopyright.Text = My.Application.Info.Copyright
            Me.LabelCompanyName.Text = My.Application.Info.CompanyName

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub sbOk_Click(sender As Object, e As EventArgs) Handles sbOk.Click
        Me.Dispose()

    End Sub

End Class