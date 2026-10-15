<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCCS_FAB_Setup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCCS_FAB_Setup))
        Me.chkShowDialog = New DevExpress.XtraEditors.CheckEdit()
        Me.sbOK = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cbeLayerSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLayerSetup = New DevExpress.XtraEditors.LabelControl()
        Me.cbeToolSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblToolSetup = New DevExpress.XtraEditors.LabelControl()
        Me.lblMachine = New DevExpress.XtraEditors.LabelControl()
        Me.cbeMachine = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbeLeadSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadSetup = New DevExpress.XtraEditors.LabelControl()
        Me.cbeCutBackTool = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblCutBackTool = New DevExpress.XtraEditors.LabelControl()
        Me.SpreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.vgNestDefaults = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.catNestDefaults = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lbOptions = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.chkShowDialog.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeLayerSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeToolSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeLeadSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeCutBackTool.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgNestDefaults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkShowDialog
        '
        Me.chkShowDialog.Location = New System.Drawing.Point(95, 210)
        Me.chkShowDialog.Name = "chkShowDialog"
        Me.chkShowDialog.Properties.Caption = "Do not show this dialog again"
        Me.chkShowDialog.Size = New System.Drawing.Size(221, 19)
        Me.chkShowDialog.TabIndex = 5
        '
        'sbOK
        '
        Me.sbOK.Location = New System.Drawing.Point(340, 72)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.Size = New System.Drawing.Size(75, 23)
        Me.sbOK.TabIndex = 6
        Me.sbOK.Text = "Ok"
        '
        'sbCancel
        '
        Me.sbCancel.Location = New System.Drawing.Point(340, 101)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 7
        Me.sbCancel.Text = "Cancel"
        '
        'cbeLayerSetup
        '
        Me.cbeLayerSetup.Location = New System.Drawing.Point(95, 151)
        Me.cbeLayerSetup.Name = "cbeLayerSetup"
        Me.cbeLayerSetup.Properties.AutoHeight = False
        Me.cbeLayerSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeLayerSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeLayerSetup.Size = New System.Drawing.Size(228, 22)
        Me.cbeLayerSetup.TabIndex = 3
        '
        'lblLayerSetup
        '
        Me.lblLayerSetup.Location = New System.Drawing.Point(18, 156)
        Me.lblLayerSetup.Name = "lblLayerSetup"
        Me.lblLayerSetup.Size = New System.Drawing.Size(71, 13)
        Me.lblLayerSetup.TabIndex = 59
        Me.lblLayerSetup.Text = "* Layer Setup:"
        '
        'cbeToolSetup
        '
        Me.cbeToolSetup.Location = New System.Drawing.Point(95, 95)
        Me.cbeToolSetup.Name = "cbeToolSetup"
        Me.cbeToolSetup.Properties.AutoHeight = False
        Me.cbeToolSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeToolSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeToolSetup.Size = New System.Drawing.Size(228, 22)
        Me.cbeToolSetup.TabIndex = 1
        '
        'lblToolSetup
        '
        Me.lblToolSetup.Location = New System.Drawing.Point(25, 100)
        Me.lblToolSetup.Name = "lblToolSetup"
        Me.lblToolSetup.Size = New System.Drawing.Size(64, 13)
        Me.lblToolSetup.TabIndex = 58
        Me.lblToolSetup.Text = "* Tool Setup:"
        '
        'lblMachine
        '
        Me.lblMachine.Location = New System.Drawing.Point(37, 72)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(52, 13)
        Me.lblMachine.TabIndex = 57
        Me.lblMachine.Text = "* Machine:"
        '
        'cbeMachine
        '
        Me.cbeMachine.Location = New System.Drawing.Point(95, 69)
        Me.cbeMachine.Name = "cbeMachine"
        Me.cbeMachine.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMachine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeMachine.Size = New System.Drawing.Size(228, 20)
        Me.cbeMachine.TabIndex = 0
        '
        'cbeLeadSetup
        '
        Me.cbeLeadSetup.Location = New System.Drawing.Point(95, 123)
        Me.cbeLeadSetup.Name = "cbeLeadSetup"
        Me.cbeLeadSetup.Properties.AutoHeight = False
        Me.cbeLeadSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeLeadSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeLeadSetup.Size = New System.Drawing.Size(228, 22)
        Me.cbeLeadSetup.TabIndex = 2
        '
        'lblLeadSetup
        '
        Me.lblLeadSetup.Location = New System.Drawing.Point(31, 128)
        Me.lblLeadSetup.Name = "lblLeadSetup"
        Me.lblLeadSetup.Size = New System.Drawing.Size(58, 13)
        Me.lblLeadSetup.TabIndex = 61
        Me.lblLeadSetup.Text = "Lead Setup:"
        '
        'cbeCutBackTool
        '
        Me.cbeCutBackTool.Location = New System.Drawing.Point(95, 179)
        Me.cbeCutBackTool.Name = "cbeCutBackTool"
        Me.cbeCutBackTool.Properties.AutoHeight = False
        Me.cbeCutBackTool.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeCutBackTool.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeCutBackTool.Size = New System.Drawing.Size(228, 22)
        Me.cbeCutBackTool.TabIndex = 4
        '
        'lblCutBackTool
        '
        Me.lblCutBackTool.Location = New System.Drawing.Point(20, 184)
        Me.lblCutBackTool.Name = "lblCutBackTool"
        Me.lblCutBackTool.Size = New System.Drawing.Size(69, 13)
        Me.lblCutBackTool.TabIndex = 63
        Me.lblCutBackTool.Text = "Cut Back Tool:"
        '
        'SpreadsheetControl1
        '
        Me.SpreadsheetControl1.Location = New System.Drawing.Point(38, 81)
        Me.SpreadsheetControl1.Name = "SpreadsheetControl1"
        Me.SpreadsheetControl1.Options.Behavior.Column.AutoFit = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Behavior.Column.Resize = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Import.Csv.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Csv.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.Import.Txt.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Txt.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.View.ShowColumnHeaders = False
        Me.SpreadsheetControl1.Options.View.ShowPrintArea = False
        Me.SpreadsheetControl1.Options.View.ShowRowHeaders = False
        Me.SpreadsheetControl1.Size = New System.Drawing.Size(285, 97)
        Me.SpreadsheetControl1.TabIndex = 64
        Me.SpreadsheetControl1.Text = "SpreadsheetControl1"
        Me.SpreadsheetControl1.Visible = False
        '
        'vgNestDefaults
        '
        Me.vgNestDefaults.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vgNestDefaults.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgNestDefaults.Location = New System.Drawing.Point(329, 58)
        Me.vgNestDefaults.Name = "vgNestDefaults"
        Me.vgNestDefaults.OptionsBehavior.AutoFocusNewRecord = True
        Me.vgNestDefaults.OptionsBehavior.UseEnterAsTab = True
        Me.vgNestDefaults.OptionsView.AutoScaleBands = True
        Me.vgNestDefaults.OptionsView.ShowButtons = False
        Me.vgNestDefaults.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catNestDefaults})
        Me.vgNestDefaults.Size = New System.Drawing.Size(115, 154)
        Me.vgNestDefaults.TabIndex = 72
        Me.vgNestDefaults.Visible = False
        '
        'catNestDefaults
        '
        Me.catNestDefaults.Height = 19
        Me.catNestDefaults.Name = "catNestDefaults"
        Me.catNestDefaults.Properties.Caption = "Enter any Nesting Defaults that are not included in the import file."
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(23, 12)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Properties.Step = 1
        Me.ProgressBarControl1.Size = New System.Drawing.Size(459, 21)
        Me.ProgressBarControl1.TabIndex = 73
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(25, 39)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(457, 13)
        Me.LabelControl1.TabIndex = 74
        Me.LabelControl1.Text = "Part"
        '
        'lbOptions
        '
        Me.lbOptions.Appearance.BackColor = System.Drawing.Color.White
        Me.lbOptions.Appearance.Options.UseBackColor = True
        Me.lbOptions.Location = New System.Drawing.Point(85, 46)
        Me.lbOptions.MaximumSize = New System.Drawing.Size(0, 50)
        Me.lbOptions.Name = "lbOptions"
        Me.lbOptions.Size = New System.Drawing.Size(73, 20)
        Me.lbOptions.TabIndex = 76
        Me.lbOptions.Visible = False
        '
        'frmCCS_FAB_Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 235)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.cbeCutBackTool)
        Me.Controls.Add(Me.lblCutBackTool)
        Me.Controls.Add(Me.cbeLeadSetup)
        Me.Controls.Add(Me.lblLeadSetup)
        Me.Controls.Add(Me.cbeLayerSetup)
        Me.Controls.Add(Me.lblLayerSetup)
        Me.Controls.Add(Me.cbeToolSetup)
        Me.Controls.Add(Me.lblToolSetup)
        Me.Controls.Add(Me.lblMachine)
        Me.Controls.Add(Me.cbeMachine)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOK)
        Me.Controls.Add(Me.chkShowDialog)
        Me.Controls.Add(Me.lbOptions)
        Me.Controls.Add(Me.vgNestDefaults)
        Me.Controls.Add(Me.SpreadsheetControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCCS_FAB_Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Default Settings"
        CType(Me.chkShowDialog.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeLayerSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeToolSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeLeadSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeCutBackTool.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgNestDefaults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkShowDialog As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents sbOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbeLayerSetup As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLayerSetup As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeToolSetup As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblToolSetup As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMachine As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeMachine As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbeLeadSetup As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadSetup As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeCutBackTool As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblCutBackTool As DevExpress.XtraEditors.LabelControl
    Friend WithEvents vgNestDefaults As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catNestDefaults As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbOptions As DevExpress.XtraEditors.ListBoxControl
    Public WithEvents SpreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
End Class
