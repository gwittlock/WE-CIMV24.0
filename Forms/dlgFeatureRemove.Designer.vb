<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFeatureRemove
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
        Me.lstFeatures = New DevExpress.XtraEditors.ListBoxControl()
        Me.dlgFeatureInsertConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        CType(Me.lstFeatures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dlgFeatureInsertConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dlgFeatureInsertConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstFeatures
        '
        Me.lstFeatures.Location = New System.Drawing.Point(12, 12)
        Me.lstFeatures.Name = "lstFeatures"
        Me.lstFeatures.Size = New System.Drawing.Size(142, 211)
        Me.lstFeatures.StyleController = Me.dlgFeatureInsertConvertedLayout
        Me.lstFeatures.TabIndex = 0
        '
        'dlgFeatureInsertConvertedLayout
        '
        Me.dlgFeatureInsertConvertedLayout.Controls.Add(Me.btnAccept)
        Me.dlgFeatureInsertConvertedLayout.Controls.Add(Me.lstFeatures)
        Me.dlgFeatureInsertConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dlgFeatureInsertConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.dlgFeatureInsertConvertedLayout.Name = "dlgFeatureInsertConvertedLayout"
        Me.dlgFeatureInsertConvertedLayout.Root = Me.LayoutControlGroup1
        Me.dlgFeatureInsertConvertedLayout.Size = New System.Drawing.Size(166, 261)
        Me.dlgFeatureInsertConvertedLayout.TabIndex = 6
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(12, 227)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(142, 22)
        Me.btnAccept.StyleController = Me.dlgFeatureInsertConvertedLayout
        Me.btnAccept.TabIndex = 4
        Me.btnAccept.Text = "Accept"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(166, 261)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnAccept
        Me.LayoutControlItem1.CustomizationFormText = "btnAcceptitem"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 215)
        Me.LayoutControlItem1.Name = "btnAcceptitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(146, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.lstFeatures
        Me.LayoutControlItem2.CustomizationFormText = "ListBoxControl1item"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "ListBoxControl1item"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(146, 215)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'dlgFeatureRemove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(166, 261)
        Me.Controls.Add(Me.dlgFeatureInsertConvertedLayout)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgFeatureRemove"
        Me.Text = "Remove Feature"
        CType(Me.lstFeatures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dlgFeatureInsertConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dlgFeatureInsertConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstFeatures As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents dlgFeatureInsertConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
End Class
