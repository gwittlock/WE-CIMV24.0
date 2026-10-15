<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditToolLayer
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.grdToolLayer = New DevExpress.XtraGrid.GridControl()
        Me.gViewToolLayer = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.frmEditToolLayerConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.rgChangeTo = New DevExpress.XtraEditors.RadioGroup()
        Me.vgProcessParameters = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lstOptions = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmEditToolLayerConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmEditToolLayerConvertedLayout.SuspendLayout()
        CType(Me.rgChangeTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgProcessParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdToolLayer
        '
        Me.grdToolLayer.Cursor = System.Windows.Forms.Cursors.Default
        GridLevelNode1.RelationName = "Level1"
        Me.grdToolLayer.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdToolLayer.Location = New System.Drawing.Point(12, 85)
        Me.grdToolLayer.MainView = Me.gViewToolLayer
        Me.grdToolLayer.Name = "grdToolLayer"
        Me.grdToolLayer.Size = New System.Drawing.Size(272, 247)
        Me.grdToolLayer.TabIndex = 100
        Me.grdToolLayer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gViewToolLayer})
        '
        'gViewToolLayer
        '
        Me.gViewToolLayer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gViewToolLayer.GridControl = Me.grdToolLayer
        Me.gViewToolLayer.Name = "gViewToolLayer"
        Me.gViewToolLayer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gViewToolLayer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gViewToolLayer.OptionsBehavior.Editable = False
        Me.gViewToolLayer.OptionsView.ColumnAutoWidth = False
        Me.gViewToolLayer.OptionsView.ShowDetailButtons = False
        Me.gViewToolLayer.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.gViewToolLayer.OptionsView.ShowGroupPanel = False
        Me.gViewToolLayer.OptionsView.ShowIndicator = False
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(12, 442)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(272, 22)
        Me.cmdOk.StyleController = Me.frmEditToolLayerConvertedLayout
        Me.cmdOk.TabIndex = 99
        Me.cmdOk.Text = "Apply"
        '
        'frmEditToolLayerConvertedLayout
        '
        Me.frmEditToolLayerConvertedLayout.Controls.Add(Me.grdToolLayer)
        Me.frmEditToolLayerConvertedLayout.Controls.Add(Me.cmdOk)
        Me.frmEditToolLayerConvertedLayout.Controls.Add(Me.rgChangeTo)
        Me.frmEditToolLayerConvertedLayout.Controls.Add(Me.vgProcessParameters)
        Me.frmEditToolLayerConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmEditToolLayerConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmEditToolLayerConvertedLayout.Name = "frmEditToolLayerConvertedLayout"
        Me.frmEditToolLayerConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmEditToolLayerConvertedLayout.Size = New System.Drawing.Size(296, 476)
        Me.frmEditToolLayerConvertedLayout.TabIndex = 104
        '
        'rgChangeTo
        '
        Me.rgChangeTo.AutoSizeInLayoutControl = True
        Me.rgChangeTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rgChangeTo.EditValue = True
        Me.rgChangeTo.EnterMoveNextControl = True
        Me.rgChangeTo.Location = New System.Drawing.Point(24, 44)
        Me.rgChangeTo.Name = "rgChangeTo"
        Me.rgChangeTo.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "N/A"), New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Tool"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Layer")})
        Me.rgChangeTo.Size = New System.Drawing.Size(248, 25)
        Me.rgChangeTo.StyleController = Me.frmEditToolLayerConvertedLayout
        Me.rgChangeTo.TabIndex = 2
        '
        'vgProcessParameters
        '
        Me.vgProcessParameters.Location = New System.Drawing.Point(12, 336)
        Me.vgProcessParameters.Name = "vgProcessParameters"
        Me.vgProcessParameters.OptionsView.ShowButtons = False
        Me.vgProcessParameters.Size = New System.Drawing.Size(272, 102)
        Me.vgProcessParameters.TabIndex = 103
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlGroup2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(296, 476)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.grdToolLayer
        Me.LayoutControlItem1.CustomizationFormText = "grdToolLayeritem"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 73)
        Me.LayoutControlItem1.Name = "grdToolLayeritem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(276, 251)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdOk
        Me.LayoutControlItem2.CustomizationFormText = "cmdOkitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 430)
        Me.LayoutControlItem2.Name = "cmdOkitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(276, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Change To"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "GroupControl3item"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(276, 73)
        Me.LayoutControlGroup2.Text = "Change To"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.rgChangeTo
        Me.LayoutControlItem4.CustomizationFormText = "rgChangeToitem"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "rgChangeToitem"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(252, 29)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.vgProcessParameters
        Me.LayoutControlItem3.CustomizationFormText = "vgCodeGenVarsitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 324)
        Me.LayoutControlItem3.Name = "vgCodeGenVarsitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(276, 106)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'lstOptions
        '
        Me.lstOptions.Location = New System.Drawing.Point(88, 226)
        Me.lstOptions.Name = "lstOptions"
        Me.lstOptions.Size = New System.Drawing.Size(120, 25)
        Me.lstOptions.TabIndex = 105
        Me.lstOptions.Visible = False
        '
        'frmEditToolLayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(296, 476)
        Me.Controls.Add(Me.lstOptions)
        Me.Controls.Add(Me.frmEditToolLayerConvertedLayout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditToolLayer"
        Me.Text = "Edit Tool Layer"
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmEditToolLayerConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmEditToolLayerConvertedLayout.ResumeLayout(False)
        CType(Me.rgChangeTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgProcessParameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Private WithEvents grdToolLayer As DevExpress.XtraGrid.GridControl
    Private WithEvents gViewToolLayer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents frmEditToolLayerConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents rgChangeTo As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents vgProcessParameters As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lstOptions As DevExpress.XtraEditors.ListBoxControl
End Class
