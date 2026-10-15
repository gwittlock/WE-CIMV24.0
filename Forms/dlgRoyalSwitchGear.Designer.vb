<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRoyalSwitchGear
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgRoyalSwitchGear))
        Me.SpreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.beXlsxFIle = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraOpenFileDialog1 = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        Me.sbConvert = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.beXlsxFIle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpreadsheetControl1
        '
        Me.SpreadsheetControl1.Location = New System.Drawing.Point(12, 89)
        Me.SpreadsheetControl1.Name = "SpreadsheetControl1"
        Me.SpreadsheetControl1.Options.Behavior.Column.AutoFit = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Behavior.Column.Resize = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Import.Csv.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Csv.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.Import.Txt.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Txt.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.View.ShowColumnHeaders = False
        Me.SpreadsheetControl1.Options.View.ShowPrintArea = False
        Me.SpreadsheetControl1.ReadOnly = True
        Me.SpreadsheetControl1.Size = New System.Drawing.Size(377, 123)
        Me.SpreadsheetControl1.TabIndex = 65
        Me.SpreadsheetControl1.Text = "SpreadsheetControl1"
        '
        'beXlsxFIle
        '
        Me.beXlsxFIle.Location = New System.Drawing.Point(12, 12)
        Me.beXlsxFIle.Name = "beXlsxFIle"
        Me.beXlsxFIle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beXlsxFIle.Size = New System.Drawing.Size(307, 20)
        Me.beXlsxFIle.TabIndex = 66
        '
        'XtraOpenFileDialog1
        '
        Me.XtraOpenFileDialog1.AllowDragDrop = False
        Me.XtraOpenFileDialog1.FileName = "XtraOpenFileDialog1"
        Me.XtraOpenFileDialog1.Filter = "*.xlsx"
        '
        'sbConvert
        '
        Me.sbConvert.Location = New System.Drawing.Point(314, 218)
        Me.sbConvert.Name = "sbConvert"
        Me.sbConvert.Size = New System.Drawing.Size(75, 23)
        Me.sbConvert.TabIndex = 67
        Me.sbConvert.Text = "Convert"
        '
        'sbCancel
        '
        Me.sbCancel.Location = New System.Drawing.Point(233, 218)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 68
        Me.sbCancel.Text = "Cancel"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(12, 65)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(307, 18)
        Me.LabelControl1.TabIndex = 76
        Me.LabelControl1.Text = "Part"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(12, 38)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Properties.Step = 1
        Me.ProgressBarControl1.Size = New System.Drawing.Size(307, 21)
        Me.ProgressBarControl1.TabIndex = 75
        '
        'dlgRoyalSwitchGear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 247)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbConvert)
        Me.Controls.Add(Me.beXlsxFIle)
        Me.Controls.Add(Me.SpreadsheetControl1)
        Me.DoubleBuffered = True
        Me.Name = "dlgRoyalSwitchGear"
        Me.Text = "dlgRoyalSwitchGear"
        CType(Me.beXlsxFIle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents SpreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
    Friend WithEvents beXlsxFIle As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents sbConvert As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
End Class
