<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgPatternDelete
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
        Me.lstPattern = New DevExpress.XtraEditors.ListBoxControl()
        Me.dlgPatternDeleteConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.ltbPatternID = New FabV24_WIN8.lblTextBox()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dlgPatternDeleteConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dlgPatternDeleteConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstPattern
        '
        Me.lstPattern.Location = New System.Drawing.Point(12, 36)
        Me.lstPattern.Name = "lstPattern"
        Me.lstPattern.Size = New System.Drawing.Size(176, 150)
        Me.lstPattern.StyleController = Me.dlgPatternDeleteConvertedLayout
        Me.lstPattern.TabIndex = 0
        '
        'dlgPatternDeleteConvertedLayout
        '
        Me.dlgPatternDeleteConvertedLayout.Controls.Add(Me.btnAccept)
        Me.dlgPatternDeleteConvertedLayout.Controls.Add(Me.ltbPatternID)
        Me.dlgPatternDeleteConvertedLayout.Controls.Add(Me.lstPattern)
        Me.dlgPatternDeleteConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dlgPatternDeleteConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.dlgPatternDeleteConvertedLayout.Name = "dlgPatternDeleteConvertedLayout"
        Me.dlgPatternDeleteConvertedLayout.Root = Me.LayoutControlGroup1
        Me.dlgPatternDeleteConvertedLayout.Size = New System.Drawing.Size(200, 224)
        Me.dlgPatternDeleteConvertedLayout.TabIndex = 5
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(12, 190)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(176, 22)
        Me.btnAccept.StyleController = Me.dlgPatternDeleteConvertedLayout
        Me.btnAccept.TabIndex = 4
        Me.btnAccept.Text = "Accept"
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
        Me.ltbPatternID.TabIndex = 1
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(200, 224)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnAccept
        Me.LayoutControlItem1.CustomizationFormText = "btnAcceptitem"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 178)
        Me.LayoutControlItem1.Name = "btnAcceptitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(180, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ltbPatternID
        Me.LayoutControlItem2.CustomizationFormText = "lblTextBoxitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "lblTextBoxitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(180, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lstPattern
        Me.LayoutControlItem3.CustomizationFormText = "lstPatternitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "lstPatternitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(180, 154)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'dlgPatternDelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 224)
        Me.Controls.Add(Me.dlgPatternDeleteConvertedLayout)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgPatternDelete"
        Me.Text = "Delete Pattern"
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dlgPatternDeleteConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dlgPatternDeleteConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstPattern As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents ltbPatternID As FabV24_WIN8.lblTextBox
    Friend WithEvents dlgPatternDeleteConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
End Class
