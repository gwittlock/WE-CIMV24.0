<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartUp
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartUp))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblRecentFiles = New DevExpress.XtraEditors.LabelControl()
        Me.lbRecentFiles = New DevExpress.XtraEditors.ListBoxControl()
        Me.grpModelFiles = New DevExpress.XtraEditors.GroupControl()
        Me.sbModelFilesOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.sbModelFilesNew = New DevExpress.XtraEditors.SimpleButton()
        Me.grpNesting = New DevExpress.XtraEditors.GroupControl()
        Me.sbNestingOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.sbNestingNew = New DevExpress.XtraEditors.SimpleButton()
        Me.grpMRPInterface = New DevExpress.XtraEditors.GroupControl()
        Me.sbConfigMan = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.sbMRP_Open = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCopyRight = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbRecentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpModelFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpModelFiles.SuspendLayout()
        CType(Me.grpNesting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNesting.SuspendLayout()
        CType(Me.grpMRPInterface, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMRPInterface.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(185, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(345, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'lblRecentFiles
        '
        Me.lblRecentFiles.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecentFiles.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblRecentFiles.Appearance.Options.UseFont = True
        Me.lblRecentFiles.Appearance.Options.UseForeColor = True
        Me.lblRecentFiles.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.lblRecentFiles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.lblRecentFiles.Location = New System.Drawing.Point(33, 312)
        Me.lblRecentFiles.Name = "lblRecentFiles"
        Me.lblRecentFiles.Size = New System.Drawing.Size(79, 18)
        Me.lblRecentFiles.TabIndex = 8
        Me.lblRecentFiles.Text = "Recent Files"
        '
        'lbRecentFiles
        '
        Me.lbRecentFiles.Location = New System.Drawing.Point(31, 333)
        Me.lbRecentFiles.Name = "lbRecentFiles"
        Me.lbRecentFiles.Size = New System.Drawing.Size(652, 85)
        Me.lbRecentFiles.TabIndex = 5
        '
        'grpModelFiles
        '
        Me.grpModelFiles.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModelFiles.AppearanceCaption.Options.UseFont = True
        Me.grpModelFiles.AppearanceCaption.Options.UseTextOptions = True
        Me.grpModelFiles.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grpModelFiles.ContentImage = CType(resources.GetObject("grpModelFiles.ContentImage"), System.Drawing.Image)
        Me.grpModelFiles.Controls.Add(Me.sbModelFilesOpen)
        Me.grpModelFiles.Controls.Add(Me.sbModelFilesNew)
        Me.grpModelFiles.Location = New System.Drawing.Point(27, 171)
        Me.grpModelFiles.Name = "grpModelFiles"
        Me.grpModelFiles.Size = New System.Drawing.Size(156, 135)
        Me.grpModelFiles.TabIndex = 9
        Me.grpModelFiles.Text = "Model Files"
        '
        'sbModelFilesOpen
        '
        Me.sbModelFilesOpen.ImageOptions.Image = CType(resources.GetObject("sbModelFilesOpen.ImageOptions.Image"), System.Drawing.Image)
        Me.sbModelFilesOpen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.sbModelFilesOpen.Location = New System.Drawing.Point(44, 80)
        Me.sbModelFilesOpen.Name = "sbModelFilesOpen"
        Me.sbModelFilesOpen.Size = New System.Drawing.Size(72, 36)
        Me.sbModelFilesOpen.TabIndex = 1
        Me.sbModelFilesOpen.Text = "SimpleButton2"
        '
        'sbModelFilesNew
        '
        Me.sbModelFilesNew.ImageOptions.Image = CType(resources.GetObject("sbModelFilesNew.ImageOptions.Image"), System.Drawing.Image)
        Me.sbModelFilesNew.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.sbModelFilesNew.Location = New System.Drawing.Point(44, 38)
        Me.sbModelFilesNew.Name = "sbModelFilesNew"
        Me.sbModelFilesNew.Size = New System.Drawing.Size(72, 36)
        Me.sbModelFilesNew.TabIndex = 0
        Me.sbModelFilesNew.Text = "SimpleButton1"
        '
        'grpNesting
        '
        Me.grpNesting.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNesting.AppearanceCaption.Options.UseFont = True
        Me.grpNesting.AppearanceCaption.Options.UseTextOptions = True
        Me.grpNesting.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grpNesting.ContentImage = CType(resources.GetObject("grpNesting.ContentImage"), System.Drawing.Image)
        Me.grpNesting.Controls.Add(Me.sbNestingOpen)
        Me.grpNesting.Controls.Add(Me.sbNestingNew)
        Me.grpNesting.Location = New System.Drawing.Point(194, 171)
        Me.grpNesting.Name = "grpNesting"
        Me.grpNesting.Size = New System.Drawing.Size(156, 135)
        Me.grpNesting.TabIndex = 10
        Me.grpNesting.Text = "Nesting"
        '
        'sbNestingOpen
        '
        Me.sbNestingOpen.ImageOptions.Image = CType(resources.GetObject("sbNestingOpen.ImageOptions.Image"), System.Drawing.Image)
        Me.sbNestingOpen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.sbNestingOpen.Location = New System.Drawing.Point(44, 80)
        Me.sbNestingOpen.Name = "sbNestingOpen"
        Me.sbNestingOpen.Size = New System.Drawing.Size(72, 36)
        Me.sbNestingOpen.TabIndex = 1
        Me.sbNestingOpen.Text = "SimpleButton3"
        '
        'sbNestingNew
        '
        Me.sbNestingNew.ImageOptions.Image = CType(resources.GetObject("sbNestingNew.ImageOptions.Image"), System.Drawing.Image)
        Me.sbNestingNew.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.sbNestingNew.Location = New System.Drawing.Point(44, 38)
        Me.sbNestingNew.Name = "sbNestingNew"
        Me.sbNestingNew.Size = New System.Drawing.Size(72, 36)
        Me.sbNestingNew.TabIndex = 0
        Me.sbNestingNew.Text = "SimpleButton4"
        '
        'grpMRPInterface
        '
        Me.grpMRPInterface.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMRPInterface.Appearance.Options.UseFont = True
        Me.grpMRPInterface.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMRPInterface.AppearanceCaption.Options.UseFont = True
        Me.grpMRPInterface.AppearanceCaption.Options.UseTextOptions = True
        Me.grpMRPInterface.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grpMRPInterface.ContentImage = CType(resources.GetObject("grpMRPInterface.ContentImage"), System.Drawing.Image)
        Me.grpMRPInterface.Controls.Add(Me.sbConfigMan)
        Me.grpMRPInterface.Location = New System.Drawing.Point(361, 171)
        Me.grpMRPInterface.Name = "grpMRPInterface"
        Me.grpMRPInterface.Size = New System.Drawing.Size(156, 135)
        Me.grpMRPInterface.TabIndex = 11
        Me.grpMRPInterface.Text = "Configuration Manager"
        '
        'sbConfigMan
        '
        Me.sbConfigMan.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.sbConfigMan.Appearance.Options.UseBackColor = True
        Me.sbConfigMan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.sbConfigMan.ImageOptions.Image = CType(resources.GetObject("sbConfigMan.ImageOptions.Image"), System.Drawing.Image)
        Me.sbConfigMan.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.sbConfigMan.Location = New System.Drawing.Point(45, 45)
        Me.sbConfigMan.Name = "sbConfigMan"
        Me.sbConfigMan.Size = New System.Drawing.Size(65, 65)
        Me.sbConfigMan.TabIndex = 1
        Me.sbConfigMan.Text = "SimpleButton5"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.ContentImage = CType(resources.GetObject("GroupControl1.ContentImage"), System.Drawing.Image)
        Me.GroupControl1.Controls.Add(Me.sbMRP_Open)
        Me.GroupControl1.Location = New System.Drawing.Point(528, 171)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(156, 135)
        Me.GroupControl1.TabIndex = 12
        Me.GroupControl1.Text = "MRP Interface"
        '
        'sbMRP_Open
        '
        Me.sbMRP_Open.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.sbMRP_Open.Appearance.Options.UseBackColor = True
        Me.sbMRP_Open.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.sbMRP_Open.ImageOptions.Image = CType(resources.GetObject("sbMRP_Open.ImageOptions.Image"), System.Drawing.Image)
        Me.sbMRP_Open.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.sbMRP_Open.Location = New System.Drawing.Point(46, 45)
        Me.sbMRP_Open.Name = "sbMRP_Open"
        Me.sbMRP_Open.Size = New System.Drawing.Size(65, 65)
        Me.sbMRP_Open.TabIndex = 1
        Me.sbMRP_Open.Text = "SimpleButton5"
        '
        'lblCopyRight
        '
        Me.lblCopyRight.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblCopyRight.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblCopyRight.Appearance.Options.UseFont = True
        Me.lblCopyRight.Appearance.Options.UseForeColor = True
        Me.lblCopyRight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.lblCopyRight.Location = New System.Drawing.Point(214, 152)
        Me.lblCopyRight.Name = "lblCopyRight"
        Me.lblCopyRight.Size = New System.Drawing.Size(287, 16)
        Me.lblCopyRight.TabIndex = 13
        Me.lblCopyRight.Text = "Copyright © Wittlock Engineering LLC 2001 - 2026"
        '
        'frmStartUp
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic
        Me.Appearance.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch
        Me.BackgroundImageStore = CType(resources.GetObject("$this.BackgroundImageStore"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(714, 456)
        Me.Controls.Add(Me.lblCopyRight)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.grpMRPInterface)
        Me.Controls.Add(Me.grpNesting)
        Me.Controls.Add(Me.grpModelFiles)
        Me.Controls.Add(Me.lbRecentFiles)
        Me.Controls.Add(Me.lblRecentFiles)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStartUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WELCOME"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbRecentFiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpModelFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpModelFiles.ResumeLayout(False)
        CType(Me.grpNesting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNesting.ResumeLayout(False)
        CType(Me.grpMRPInterface, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMRPInterface.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRecentFiles As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbRecentFiles As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents grpModelFiles As DevExpress.XtraEditors.GroupControl
    Friend WithEvents sbModelFilesOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbModelFilesNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpNesting As DevExpress.XtraEditors.GroupControl
    Friend WithEvents sbNestingOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbNestingNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpMRPInterface As DevExpress.XtraEditors.GroupControl
    Friend WithEvents sbConfigMan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents sbMRP_Open As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCopyRight As DevExpress.XtraEditors.LabelControl
End Class
