<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConvertAppDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgConvertAppDB))
        Me.lblNewIconPath = New DevExpress.XtraEditors.LabelControl()
        Me.lblNewMacroPath = New DevExpress.XtraEditors.LabelControl()
        Me.beIconPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.beNewMacroPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.sbOk = New DevExpress.XtraEditors.SimpleButton()
        Me.beOldAppDBPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblOldAppDBPath = New DevExpress.XtraEditors.LabelControl()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.dlgOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.beNewAppDBName = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblNewAppDBName = New DevExpress.XtraEditors.LabelControl()
        CType(Me.beIconPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beNewMacroPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beOldAppDBPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beNewAppDBName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNewIconPath
        '
        Me.lblNewIconPath.Location = New System.Drawing.Point(144, 71)
        Me.lblNewIconPath.Name = "lblNewIconPath"
        Me.lblNewIconPath.Size = New System.Drawing.Size(93, 13)
        Me.lblNewIconPath.TabIndex = 2
        Me.lblNewIconPath.Text = "New Icon File Path:"
        '
        'lblNewMacroPath
        '
        Me.lblNewMacroPath.Location = New System.Drawing.Point(155, 97)
        Me.lblNewMacroPath.Name = "lblNewMacroPath"
        Me.lblNewMacroPath.Size = New System.Drawing.Size(82, 13)
        Me.lblNewMacroPath.TabIndex = 3
        Me.lblNewMacroPath.Text = "New Macro Path:"
        '
        'beIconPath
        '
        Me.beIconPath.Location = New System.Drawing.Point(243, 68)
        Me.beIconPath.Name = "beIconPath"
        Me.beIconPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beIconPath.Size = New System.Drawing.Size(478, 20)
        Me.beIconPath.TabIndex = 2
        Me.beIconPath.ToolTip = "Select a icon form your local drive to display for the macro."
        '
        'beNewMacroPath
        '
        Me.beNewMacroPath.Location = New System.Drawing.Point(243, 94)
        Me.beNewMacroPath.Name = "beNewMacroPath"
        Me.beNewMacroPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beNewMacroPath.Size = New System.Drawing.Size(478, 20)
        Me.beNewMacroPath.TabIndex = 3
        Me.beNewMacroPath.ToolTip = "Select a icon form your local drive to display for the macro."
        '
        'sbCancel
        '
        Me.sbCancel.Location = New System.Drawing.Point(377, 120)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 5
        Me.sbCancel.Text = "Cancel"
        '
        'sbOk
        '
        Me.sbOk.Location = New System.Drawing.Point(464, 120)
        Me.sbOk.Name = "sbOk"
        Me.sbOk.Size = New System.Drawing.Size(75, 23)
        Me.sbOk.TabIndex = 4
        Me.sbOk.Text = "Ok"
        '
        'beOldAppDBPath
        '
        Me.beOldAppDBPath.Location = New System.Drawing.Point(243, 12)
        Me.beOldAppDBPath.Name = "beOldAppDBPath"
        Me.beOldAppDBPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beOldAppDBPath.Size = New System.Drawing.Size(478, 20)
        Me.beOldAppDBPath.TabIndex = 1
        Me.beOldAppDBPath.ToolTip = "Select a icon form your local drive to display for the macro."
        '
        'lblOldAppDBPath
        '
        Me.lblOldAppDBPath.Location = New System.Drawing.Point(17, 15)
        Me.lblOldAppDBPath.Name = "lblOldAppDBPath"
        Me.lblOldAppDBPath.Size = New System.Drawing.Size(220, 13)
        Me.lblOldAppDBPath.TabIndex = 108
        Me.lblOldAppDBPath.Text = "Old App DB Fully Qualified Path And Filename:"
        '
        'dlgOpenDialog
        '
        Me.dlgOpenDialog.FileName = "dlgOpenDialog"
        '
        'beNewAppDBName
        '
        Me.beNewAppDBName.Location = New System.Drawing.Point(243, 42)
        Me.beNewAppDBName.Name = "beNewAppDBName"
        Me.beNewAppDBName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beNewAppDBName.Size = New System.Drawing.Size(478, 20)
        Me.beNewAppDBName.TabIndex = 109
        Me.beNewAppDBName.ToolTip = "Select a icon form your local drive to display for the macro."
        '
        'lblNewAppDBName
        '
        Me.lblNewAppDBName.Location = New System.Drawing.Point(9, 45)
        Me.lblNewAppDBName.Name = "lblNewAppDBName"
        Me.lblNewAppDBName.Size = New System.Drawing.Size(228, 13)
        Me.lblNewAppDBName.TabIndex = 110
        Me.lblNewAppDBName.Text = "New App DB  Fully Qualified Path And Filename:"
        '
        'dlgConvertAppDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 155)
        Me.Controls.Add(Me.beNewAppDBName)
        Me.Controls.Add(Me.lblNewAppDBName)
        Me.Controls.Add(Me.beOldAppDBPath)
        Me.Controls.Add(Me.lblOldAppDBPath)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOk)
        Me.Controls.Add(Me.beNewMacroPath)
        Me.Controls.Add(Me.beIconPath)
        Me.Controls.Add(Me.lblNewMacroPath)
        Me.Controls.Add(Me.lblNewIconPath)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlgConvertAppDB"
        Me.Text = "App DB Convert"
        CType(Me.beIconPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beNewMacroPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beOldAppDBPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beNewAppDBName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNewIconPath As LabelControl
    Friend WithEvents lblNewMacroPath As LabelControl
    Friend WithEvents beIconPath As ButtonEdit
    Friend WithEvents beNewMacroPath As ButtonEdit
    Friend WithEvents sbCancel As SimpleButton
    Friend WithEvents sbOk As SimpleButton
    Friend WithEvents beOldAppDBPath As ButtonEdit
    Friend WithEvents lblOldAppDBPath As LabelControl
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents dlgOpenDialog As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents beNewAppDBName As ButtonEdit
    Friend WithEvents lblNewAppDBName As LabelControl
End Class
