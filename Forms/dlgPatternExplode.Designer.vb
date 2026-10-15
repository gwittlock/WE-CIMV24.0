<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgPatternExplode
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
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.dlgPatternExplodeConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.ltbPatternID = New DevExpress.XtraEditors.TextEdit()
        Me.lstPattern = New DevExpress.XtraEditors.ListBoxControl()
        Me.chkExplodeAll = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.dlgPatternExplodeConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dlgPatternExplodeConvertedLayout.SuspendLayout()
        CType(Me.ltbPatternID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExplodeAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(12, 237)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(188, 22)
        Me.btnAccept.StyleController = Me.dlgPatternExplodeConvertedLayout
        Me.btnAccept.TabIndex = 13
        Me.btnAccept.Text = "Execute"
        '
        'dlgPatternExplodeConvertedLayout
        '
        Me.dlgPatternExplodeConvertedLayout.Controls.Add(Me.ltbPatternID)
        Me.dlgPatternExplodeConvertedLayout.Controls.Add(Me.btnAccept)
        Me.dlgPatternExplodeConvertedLayout.Controls.Add(Me.lstPattern)
        Me.dlgPatternExplodeConvertedLayout.Controls.Add(Me.chkExplodeAll)
        Me.dlgPatternExplodeConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dlgPatternExplodeConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.dlgPatternExplodeConvertedLayout.Name = "dlgPatternExplodeConvertedLayout"
        Me.dlgPatternExplodeConvertedLayout.Root = Me.LayoutControlGroup1
        Me.dlgPatternExplodeConvertedLayout.Size = New System.Drawing.Size(212, 271)
        Me.dlgPatternExplodeConvertedLayout.TabIndex = 15
        '
        'ltbPatternID
        '
        Me.ltbPatternID.Enabled = False
        Me.ltbPatternID.Location = New System.Drawing.Point(149, 12)
        Me.ltbPatternID.Name = "ltbPatternID"
        Me.ltbPatternID.Size = New System.Drawing.Size(51, 20)
        Me.ltbPatternID.StyleController = Me.dlgPatternExplodeConvertedLayout
        Me.ltbPatternID.TabIndex = 11
        '
        'lstPattern
        '
        Me.lstPattern.Location = New System.Drawing.Point(12, 36)
        Me.lstPattern.Name = "lstPattern"
        Me.lstPattern.Size = New System.Drawing.Size(188, 197)
        Me.lstPattern.StyleController = Me.dlgPatternExplodeConvertedLayout
        Me.lstPattern.TabIndex = 12
        '
        'chkExplodeAll
        '
        Me.chkExplodeAll.Location = New System.Drawing.Point(12, 12)
        Me.chkExplodeAll.Name = "chkExplodeAll"
        Me.chkExplodeAll.Properties.Caption = "Explode All"
        Me.chkExplodeAll.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkExplodeAll.Size = New System.Drawing.Size(80, 19)
        Me.chkExplodeAll.StyleController = Me.dlgPatternExplodeConvertedLayout
        Me.chkExplodeAll.TabIndex = 10
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(212, 271)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ltbPatternID
        Me.LayoutControlItem1.CustomizationFormText = "Pattern ID"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(84, 0)
        Me.LayoutControlItem1.Name = "ltbPatternIDitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(108, 24)
        Me.LayoutControlItem1.Text = "Pattern ID"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(50, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnAccept
        Me.LayoutControlItem2.CustomizationFormText = "btnAcceptitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 225)
        Me.LayoutControlItem2.Name = "btnAcceptitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lstPattern
        Me.LayoutControlItem3.CustomizationFormText = "lstPatternitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "lstPatternitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(192, 201)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.chkExplodeAll
        Me.LayoutControlItem4.CustomizationFormText = "chkExplodeAllitem"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "chkExplodeAllitem"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(84, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'dlgPatternExplode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 271)
        Me.Controls.Add(Me.dlgPatternExplodeConvertedLayout)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgPatternExplode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pattern Explode"
        CType(Me.dlgPatternExplodeConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dlgPatternExplodeConvertedLayout.ResumeLayout(False)
        CType(Me.ltbPatternID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExplodeAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents btnAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dlgPatternExplodeConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ltbPatternID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lstPattern As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents chkExplodeAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
