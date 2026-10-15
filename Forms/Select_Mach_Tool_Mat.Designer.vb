<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Select_Mach_Tool_Mat
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
        Me.lcTitle = New DevExpress.XtraEditors.LabelControl()
        Me.sbOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lcInputTitle = New DevExpress.XtraEditors.LabelControl()
        Me.cbDropDown = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.cbDropDown.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lcTitle
        '
        Me.lcTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.lcTitle.Appearance.Options.UseFont = True
        Me.lcTitle.Location = New System.Drawing.Point(48, 12)
        Me.lcTitle.Name = "lcTitle"
        Me.lcTitle.Size = New System.Drawing.Size(299, 29)
        Me.lcTitle.TabIndex = 0
        Me.lcTitle.Text = "You Must Select Tool Setup!"
        '
        'sbOk
        '
        Me.sbOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.sbOk.Location = New System.Drawing.Point(228, 93)
        Me.sbOk.Name = "sbOk"
        Me.sbOk.Size = New System.Drawing.Size(75, 23)
        Me.sbOk.TabIndex = 3
        Me.sbOk.Text = "Ok"
        '
        'lcInputTitle
        '
        Me.lcInputTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lcInputTitle.Appearance.Options.UseTextOptions = True
        Me.lcInputTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lcInputTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lcInputTitle.LineLocation = DevExpress.XtraEditors.LineLocation.Right
        Me.lcInputTitle.Location = New System.Drawing.Point(9, 70)
        Me.lcInputTitle.MinimumSize = New System.Drawing.Size(100, 0)
        Me.lcInputTitle.Name = "lcInputTitle"
        Me.lcInputTitle.Size = New System.Drawing.Size(100, 13)
        Me.lcInputTitle.TabIndex = 4
        Me.lcInputTitle.Text = "Tool Setup:"
        '
        'cbDropDown
        '
        Me.cbDropDown.Location = New System.Drawing.Point(115, 67)
        Me.cbDropDown.Name = "cbDropDown"
        Me.cbDropDown.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbDropDown.Size = New System.Drawing.Size(232, 20)
        Me.cbDropDown.TabIndex = 2
        '
        'Select_Mach_Tool_Mat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 128)
        Me.Controls.Add(Me.lcInputTitle)
        Me.Controls.Add(Me.sbOk)
        Me.Controls.Add(Me.cbDropDown)
        Me.Controls.Add(Me.lcTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Select_Mach_Tool_Mat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select "
        CType(Me.cbDropDown.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lcTitle As LabelControl
    Friend WithEvents sbOk As SimpleButton
    Friend WithEvents lcInputTitle As LabelControl
    Friend WithEvents cbDropDown As ComboBoxEdit
End Class
