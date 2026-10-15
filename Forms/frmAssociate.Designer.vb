<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssociate
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
        Me.grdToolLayer = New DevExpress.XtraGrid.GridControl()
        Me.gViewToolLayer = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.vgProcessParameters = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraForm7ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.lstOptions = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgProcessParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraForm7ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraForm7ConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdToolLayer
        '
        Me.grdToolLayer.Location = New System.Drawing.Point(12, 12)
        Me.grdToolLayer.MainView = Me.gViewToolLayer
        Me.grdToolLayer.Name = "grdToolLayer"
        Me.grdToolLayer.Size = New System.Drawing.Size(308, 215)
        Me.grdToolLayer.TabIndex = 1
        Me.grdToolLayer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gViewToolLayer})
        '
        'gViewToolLayer
        '
        Me.gViewToolLayer.GridControl = Me.grdToolLayer
        Me.gViewToolLayer.Name = "gViewToolLayer"
        Me.gViewToolLayer.OptionsView.ShowDetailButtons = False
        Me.gViewToolLayer.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.gViewToolLayer.OptionsView.ShowGroupPanel = False
        Me.gViewToolLayer.OptionsView.ShowIndicator = False
        '
        'vgProcessParameters
        '
        Me.vgProcessParameters.Location = New System.Drawing.Point(12, 231)
        Me.vgProcessParameters.Name = "vgProcessParameters"
        Me.vgProcessParameters.OptionsView.ShowButtons = False
        Me.vgProcessParameters.Size = New System.Drawing.Size(308, 231)
        Me.vgProcessParameters.TabIndex = 104
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(12, 466)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(308, 22)
        Me.cmdOk.StyleController = Me.XtraForm7ConvertedLayout
        Me.cmdOk.TabIndex = 105
        Me.cmdOk.Text = "Apply"
        '
        'XtraForm7ConvertedLayout
        '
        Me.XtraForm7ConvertedLayout.Controls.Add(Me.cmdOk)
        Me.XtraForm7ConvertedLayout.Controls.Add(Me.vgProcessParameters)
        Me.XtraForm7ConvertedLayout.Controls.Add(Me.grdToolLayer)
        Me.XtraForm7ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraForm7ConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.XtraForm7ConvertedLayout.Name = "XtraForm7ConvertedLayout"
        Me.XtraForm7ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.XtraForm7ConvertedLayout.Size = New System.Drawing.Size(332, 500)
        Me.XtraForm7ConvertedLayout.TabIndex = 106
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(332, 500)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdOk
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 454)
        Me.LayoutControlItem1.Name = "cmdOkitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(312, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.vgProcessParameters
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 219)
        Me.LayoutControlItem2.Name = "vgProcessParametersitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(312, 235)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.grdToolLayer
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "grdToolLayeritem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(312, 219)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'lstOptions
        '
        Me.lstOptions.Location = New System.Drawing.Point(106, 224)
        Me.lstOptions.Name = "lstOptions"
        Me.lstOptions.Size = New System.Drawing.Size(120, 25)
        Me.lstOptions.TabIndex = 107
        Me.lstOptions.Visible = False
        '
        'frmAssociate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 500)
        Me.Controls.Add(Me.lstOptions)
        Me.Controls.Add(Me.XtraForm7ConvertedLayout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssociate"
        Me.Text = "Create Associate"
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgProcessParameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraForm7ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraForm7ConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grdToolLayer As DevExpress.XtraGrid.GridControl
    Private WithEvents gViewToolLayer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents vgProcessParameters As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraForm7ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents lstOptions As DevExpress.XtraEditors.ListBoxControl
End Class
