<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAboutBox
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAboutBox))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.sbOk = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelVersion = New DevExpress.XtraEditors.LabelControl()
        Me.LabelCopyright = New DevExpress.XtraEditors.LabelControl()
        Me.LabelCompanyName = New DevExpress.XtraEditors.LabelControl()
        Me.labelPhone = New DevExpress.XtraEditors.LabelControl()
        Me.HyperLinkEdit1 = New DevExpress.XtraEditors.HyperLinkEdit()
        Me.meProductDescription = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HyperLinkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meProductDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.FabV24_WIN8.My.Resources.Resources.DemagLaminationCropped
        Me.PictureBox1.Location = New System.Drawing.Point(25, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(540, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'sbOk
        '
        Me.sbOk.Location = New System.Drawing.Point(504, 367)
        Me.sbOk.Name = "sbOk"
        Me.sbOk.Size = New System.Drawing.Size(75, 23)
        Me.sbOk.TabIndex = 7
        Me.sbOk.Text = "Ok"
        '
        'LabelVersion
        '
        Me.LabelVersion.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.Appearance.Options.UseFont = True
        Me.LabelVersion.Location = New System.Drawing.Point(25, 201)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(49, 17)
        Me.LabelVersion.TabIndex = 8
        Me.LabelVersion.Text = "Version:"
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCopyright.Appearance.Options.UseFont = True
        Me.LabelCopyright.Location = New System.Drawing.Point(25, 229)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(65, 17)
        Me.LabelCopyright.TabIndex = 9
        Me.LabelCopyright.Text = "CopyRight:"
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCompanyName.Appearance.Options.UseFont = True
        Me.LabelCompanyName.Location = New System.Drawing.Point(25, 257)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(92, 17)
        Me.LabelCompanyName.TabIndex = 10
        Me.LabelCompanyName.Text = "CompanyName"
        '
        'labelPhone
        '
        Me.labelPhone.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPhone.Appearance.Options.UseFont = True
        Me.labelPhone.Location = New System.Drawing.Point(25, 285)
        Me.labelPhone.Name = "labelPhone"
        Me.labelPhone.Size = New System.Drawing.Size(89, 17)
        Me.labelPhone.TabIndex = 11
        Me.labelPhone.Text = "(256) 737-3075"
        '
        'HyperLinkEdit1
        '
        Me.HyperLinkEdit1.EditValue = "www.wittlockeng.com"
        Me.HyperLinkEdit1.Location = New System.Drawing.Point(25, 367)
        Me.HyperLinkEdit1.Name = "HyperLinkEdit1"
        Me.HyperLinkEdit1.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HyperLinkEdit1.Properties.Appearance.Options.UseFont = True
        Me.HyperLinkEdit1.Size = New System.Drawing.Size(184, 24)
        Me.HyperLinkEdit1.TabIndex = 12
        '
        'meProductDescription
        '
        Me.meProductDescription.EditValue = resources.GetString("meProductDescription.EditValue")
        Me.meProductDescription.Location = New System.Drawing.Point(345, 200)
        Me.meProductDescription.Name = "meProductDescription"
        Me.meProductDescription.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meProductDescription.Properties.Appearance.Options.UseFont = True
        Me.meProductDescription.Properties.ReadOnly = True
        Me.meProductDescription.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.meProductDescription.ShowToolTips = False
        Me.meProductDescription.Size = New System.Drawing.Size(220, 161)
        Me.meProductDescription.TabIndex = 13
        '
        'frmAboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 402)
        Me.Controls.Add(Me.meProductDescription)
        Me.Controls.Add(Me.HyperLinkEdit1)
        Me.Controls.Add(Me.labelPhone)
        Me.Controls.Add(Me.LabelCompanyName)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.sbOk)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAboutBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAbout"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HyperLinkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meProductDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents sbOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCopyright As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCompanyName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents labelPhone As DevExpress.XtraEditors.LabelControl
    Friend WithEvents HyperLinkEdit1 As DevExpress.XtraEditors.HyperLinkEdit
    Friend WithEvents meProductDescription As DevExpress.XtraEditors.MemoEdit
End Class
