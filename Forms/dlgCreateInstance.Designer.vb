<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCreateInstance
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
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.dlgCreateInstanceConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.ltbPatternID = New FabV24_WIN8.lblTextBox()
        Me.lstPattern = New System.Windows.Forms.ListBox()
        Me.cboDefn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.vgProplist = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        CType(Me.dlgCreateInstanceConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dlgCreateInstanceConvertedLayout.SuspendLayout()
        CType(Me.cboDefn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgProplist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(12, 311)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(260, 22)
        Me.btnAccept.StyleController = Me.dlgCreateInstanceConvertedLayout
        Me.btnAccept.TabIndex = 3
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.ToolTip = "Applies the values for the current operation."
        '
        'dlgCreateInstanceConvertedLayout
        '
        Me.dlgCreateInstanceConvertedLayout.Controls.Add(Me.ltbPatternID)
        Me.dlgCreateInstanceConvertedLayout.Controls.Add(Me.lstPattern)
        Me.dlgCreateInstanceConvertedLayout.Controls.Add(Me.cboDefn)
        Me.dlgCreateInstanceConvertedLayout.Controls.Add(Me.btnAccept)
        Me.dlgCreateInstanceConvertedLayout.Controls.Add(Me.vgProplist)
        Me.dlgCreateInstanceConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dlgCreateInstanceConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.dlgCreateInstanceConvertedLayout.Name = "dlgCreateInstanceConvertedLayout"
        Me.dlgCreateInstanceConvertedLayout.Root = Me.LayoutControlGroup1
        Me.dlgCreateInstanceConvertedLayout.Size = New System.Drawing.Size(284, 345)
        Me.dlgCreateInstanceConvertedLayout.TabIndex = 12
        '
        'ltbPatternID
        '
        Me.ltbPatternID.BackColor = System.Drawing.Color.Transparent
        Me.ltbPatternID.Caption = "Pattern ID:"
        Me.ltbPatternID.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.ltbPatternID.Enabled = False
        Me.ltbPatternID.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsFixed
        Me.ltbPatternID.FieldWidth = 50
        Me.ltbPatternID.Location = New System.Drawing.Point(12, 12)
        Me.ltbPatternID.MaxLength = 32767
        Me.ltbPatternID.Name = "ltbPatternID"
        Me.ltbPatternID.Size = New System.Drawing.Size(106, 25)
        Me.ltbPatternID.TabIndex = 14
        '
        'lstPattern
        '
        Me.lstPattern.FormattingEnabled = True
        Me.lstPattern.Location = New System.Drawing.Point(12, 60)
        Me.lstPattern.Name = "lstPattern"
        Me.lstPattern.Size = New System.Drawing.Size(260, 82)
        Me.lstPattern.TabIndex = 13
        '
        'cboDefn
        '
        Me.cboDefn.EnterMoveNextControl = True
        Me.cboDefn.Location = New System.Drawing.Point(60, 36)
        Me.cboDefn.Name = "cboDefn"
        Me.cboDefn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDefn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboDefn.Size = New System.Drawing.Size(212, 20)
        Me.cboDefn.StyleController = Me.dlgCreateInstanceConvertedLayout
        Me.cboDefn.TabIndex = 8
        '
        'vgProplist
        '
        Me.vgProplist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgProplist.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgProplist.Location = New System.Drawing.Point(12, 151)
        Me.vgProplist.Name = "vgProplist"
        Me.vgProplist.OptionsView.ShowButtons = False
        Me.vgProplist.Size = New System.Drawing.Size(260, 156)
        Me.vgProplist.TabIndex = 2
        Me.vgProplist.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(284, 345)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "GroupControl1item"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(264, 325)
        Me.LayoutControlGroup2.Text = "LayoutControlGroup1"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboDefn
        Me.LayoutControlItem1.CustomizationFormText = "Definition"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem1.Name = "cboDefnitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(264, 24)
        Me.LayoutControlItem1.Text = "Definition"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnAccept
        Me.LayoutControlItem2.CustomizationFormText = "btnAcceptitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 299)
        Me.LayoutControlItem2.Name = "btnAcceptitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(264, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.vgProplist
        Me.LayoutControlItem3.CustomizationFormText = "vgProplistitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 139)
        Me.LayoutControlItem3.Name = "vgProplistitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(264, 160)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.lstPattern
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(264, 91)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ltbPatternID
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(264, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'dlgCreateInstance
        '
        Me.AcceptButton = Me.btnAccept
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.ClientSize = New System.Drawing.Size(284, 345)
        Me.Controls.Add(Me.dlgCreateInstanceConvertedLayout)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgCreateInstance"
        CType(Me.dlgCreateInstanceConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dlgCreateInstanceConvertedLayout.ResumeLayout(False)
        CType(Me.cboDefn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgProplist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dlgCreateInstanceConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents cboDefn As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents vgProplist As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents lstPattern As System.Windows.Forms.ListBox
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ltbPatternID As FabV24_WIN8.lblTextBox
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
