<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRemnantControl
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
        Me.chkRemnantsFirst = New DevExpress.XtraEditors.CheckEdit()
        Me.fcbRemnantPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblPath = New DevExpress.XtraEditors.LabelControl()
        Me.cmdRemnantEditUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.sbOKButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ltbRemnantDigits = New FabV24_WIN8.lblTextBox()
        Me.ltbMinRemnantArea = New FabV24_WIN8.lblTextBox()
        Me.ltbMinRemnantWidth = New FabV24_WIN8.lblTextBox()
        Me.ltbMinRemLength = New FabV24_WIN8.lblTextBox()
        CType(Me.chkRemnantsFirst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbRemnantPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkRemnantsFirst
        '
        Me.chkRemnantsFirst.Enabled = False
        Me.chkRemnantsFirst.Location = New System.Drawing.Point(75, 137)
        Me.chkRemnantsFirst.Name = "chkRemnantsFirst"
        Me.chkRemnantsFirst.Properties.AutoWidth = True
        Me.chkRemnantsFirst.Properties.Caption = "Nest on Remnants First"
        Me.chkRemnantsFirst.Size = New System.Drawing.Size(133, 19)
        Me.chkRemnantsFirst.TabIndex = 4
        '
        'fcbRemnantPath
        '
        Me.fcbRemnantPath.Enabled = False
        Me.fcbRemnantPath.Location = New System.Drawing.Point(42, 162)
        Me.fcbRemnantPath.Name = "fcbRemnantPath"
        Me.fcbRemnantPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbRemnantPath.Size = New System.Drawing.Size(230, 20)
        Me.fcbRemnantPath.TabIndex = 5
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(14, 165)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(22, 13)
        Me.lblPath.TabIndex = 6
        Me.lblPath.Text = "Path"
        '
        'cmdRemnantEditUpdate
        '
        Me.cmdRemnantEditUpdate.Location = New System.Drawing.Point(197, 188)
        Me.cmdRemnantEditUpdate.Name = "cmdRemnantEditUpdate"
        Me.cmdRemnantEditUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemnantEditUpdate.TabIndex = 7
        Me.cmdRemnantEditUpdate.Text = "Edit"
        '
        'sbOKButton
        '
        Me.sbOKButton.Location = New System.Drawing.Point(197, 217)
        Me.sbOKButton.Name = "sbOKButton"
        Me.sbOKButton.Size = New System.Drawing.Size(75, 23)
        Me.sbOKButton.TabIndex = 8
        Me.sbOKButton.Text = "Close"
        '
        'ltbRemnantDigits
        '
        Me.ltbRemnantDigits.BackColor = System.Drawing.Color.Transparent
        Me.ltbRemnantDigits.Caption = "Digits"
        Me.ltbRemnantDigits.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.ltbRemnantDigits.Enabled = False
        Me.ltbRemnantDigits.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.ltbRemnantDigits.FieldWidth = 100
        Me.ltbRemnantDigits.Location = New System.Drawing.Point(140, 105)
        Me.ltbRemnantDigits.MaxLength = 32767
        Me.ltbRemnantDigits.Name = "ltbRemnantDigits"
        Me.ltbRemnantDigits.Size = New System.Drawing.Size(80, 25)
        Me.ltbRemnantDigits.TabIndex = 3
        '
        'ltbMinRemnantArea
        '
        Me.ltbMinRemnantArea.BackColor = System.Drawing.Color.Transparent
        Me.ltbMinRemnantArea.Caption = "Min. Remnant Area"
        Me.ltbMinRemnantArea.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.ltbMinRemnantArea.Enabled = False
        Me.ltbMinRemnantArea.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.ltbMinRemnantArea.FieldWidth = 100
        Me.ltbMinRemnantArea.Location = New System.Drawing.Point(74, 74)
        Me.ltbMinRemnantArea.MaxLength = 32767
        Me.ltbMinRemnantArea.Name = "ltbMinRemnantArea"
        Me.ltbMinRemnantArea.Size = New System.Drawing.Size(146, 25)
        Me.ltbMinRemnantArea.TabIndex = 2
        '
        'ltbMinRemnantWidth
        '
        Me.ltbMinRemnantWidth.BackColor = System.Drawing.Color.Transparent
        Me.ltbMinRemnantWidth.Caption = "Min. Remnant Width"
        Me.ltbMinRemnantWidth.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.ltbMinRemnantWidth.Enabled = False
        Me.ltbMinRemnantWidth.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.ltbMinRemnantWidth.FieldWidth = 100
        Me.ltbMinRemnantWidth.Location = New System.Drawing.Point(69, 43)
        Me.ltbMinRemnantWidth.MaxLength = 32767
        Me.ltbMinRemnantWidth.Name = "ltbMinRemnantWidth"
        Me.ltbMinRemnantWidth.Size = New System.Drawing.Size(151, 25)
        Me.ltbMinRemnantWidth.TabIndex = 1
        '
        'ltbMinRemLength
        '
        Me.ltbMinRemLength.BackColor = System.Drawing.Color.Transparent
        Me.ltbMinRemLength.Caption = "Min. Remnant Length"
        Me.ltbMinRemLength.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.ltbMinRemLength.Enabled = False
        Me.ltbMinRemLength.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.ltbMinRemLength.FieldWidth = 100
        Me.ltbMinRemLength.Location = New System.Drawing.Point(64, 12)
        Me.ltbMinRemLength.MaxLength = 32767
        Me.ltbMinRemLength.Name = "ltbMinRemLength"
        Me.ltbMinRemLength.Size = New System.Drawing.Size(156, 25)
        Me.ltbMinRemLength.TabIndex = 0
        '
        'dlgRemnantControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 248)
        Me.Controls.Add(Me.sbOKButton)
        Me.Controls.Add(Me.cmdRemnantEditUpdate)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.fcbRemnantPath)
        Me.Controls.Add(Me.chkRemnantsFirst)
        Me.Controls.Add(Me.ltbRemnantDigits)
        Me.Controls.Add(Me.ltbMinRemnantArea)
        Me.Controls.Add(Me.ltbMinRemnantWidth)
        Me.Controls.Add(Me.ltbMinRemLength)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgRemnantControl"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remnant Control"
        Me.TopMost = True
        CType(Me.chkRemnantsFirst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbRemnantPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ltbMinRemLength As FabV24_WIN8.lblTextBox
    Friend WithEvents ltbMinRemnantWidth As FabV24_WIN8.lblTextBox
    Friend WithEvents ltbMinRemnantArea As FabV24_WIN8.lblTextBox
    Friend WithEvents ltbRemnantDigits As FabV24_WIN8.lblTextBox
    Friend WithEvents chkRemnantsFirst As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents fcbRemnantPath As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdRemnantEditUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbOKButton As DevExpress.XtraEditors.SimpleButton
End Class
