<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgResizeCircle
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.grpNewDia = New DevExpress.XtraEditors.GroupControl()
        Me.lblNewDia = New DevExpress.XtraEditors.LabelControl()
        Me.teNewDia = New DevExpress.XtraEditors.TextEdit()
        Me.grpCurrDia = New DevExpress.XtraEditors.GroupControl()
        Me.lblMaxDia = New DevExpress.XtraEditors.LabelControl()
        Me.teMaxDia = New DevExpress.XtraEditors.TextEdit()
        Me.lblMinDia = New DevExpress.XtraEditors.LabelControl()
        Me.teMinDia = New DevExpress.XtraEditors.TextEdit()
        Me.xtcToolLayer = New DevExpress.XtraTab.XtraTabControl()
        Me.xtypTools = New DevExpress.XtraTab.XtraTabPage()
        Me.grdToolLayer = New DevExpress.XtraGrid.GridControl()
        Me.gViewToolLayer = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdLayer = New DevExpress.XtraGrid.GridControl()
        Me.gViewLayer = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.sbOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lbcIsVisible = New DevExpress.XtraEditors.ListBoxControl()
        Me.chkDeleteOrg = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.grpNewDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNewDia.SuspendLayout()
        CType(Me.teNewDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpCurrDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCurrDia.SuspendLayout()
        CType(Me.teMaxDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teMinDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtcToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcToolLayer.SuspendLayout()
        Me.xtypTools.SuspendLayout()
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.grdLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gViewLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcIsVisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDeleteOrg.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpNewDia
        '
        Me.grpNewDia.Controls.Add(Me.lblNewDia)
        Me.grpNewDia.Controls.Add(Me.teNewDia)
        Me.grpNewDia.Location = New System.Drawing.Point(12, 116)
        Me.grpNewDia.Name = "grpNewDia"
        Me.grpNewDia.Size = New System.Drawing.Size(256, 65)
        Me.grpNewDia.TabIndex = 3
        Me.grpNewDia.Text = "New Diameter"
        '
        'lblNewDia
        '
        Me.lblNewDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNewDia.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblNewDia.Appearance.Options.UseFont = True
        Me.lblNewDia.Location = New System.Drawing.Point(12, 29)
        Me.lblNewDia.Name = "lblNewDia"
        Me.lblNewDia.Size = New System.Drawing.Size(79, 13)
        Me.lblNewDia.TabIndex = 5
        Me.lblNewDia.Text = "New Diameter"
        '
        'teNewDia
        '
        Me.teNewDia.EnterMoveNextControl = True
        Me.teNewDia.Location = New System.Drawing.Point(98, 26)
        Me.teNewDia.Name = "teNewDia"
        Me.teNewDia.Size = New System.Drawing.Size(135, 20)
        Me.teNewDia.TabIndex = 6
        '
        'grpCurrDia
        '
        Me.grpCurrDia.Controls.Add(Me.lblMaxDia)
        Me.grpCurrDia.Controls.Add(Me.teMaxDia)
        Me.grpCurrDia.Controls.Add(Me.lblMinDia)
        Me.grpCurrDia.Controls.Add(Me.teMinDia)
        Me.grpCurrDia.Location = New System.Drawing.Point(12, 12)
        Me.grpCurrDia.Name = "grpCurrDia"
        Me.grpCurrDia.Size = New System.Drawing.Size(256, 98)
        Me.grpCurrDia.TabIndex = 2
        Me.grpCurrDia.Text = "Current Diameters"
        '
        'lblMaxDia
        '
        Me.lblMaxDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMaxDia.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMaxDia.Appearance.Options.UseFont = True
        Me.lblMaxDia.Location = New System.Drawing.Point(12, 58)
        Me.lblMaxDia.Name = "lblMaxDia"
        Me.lblMaxDia.Size = New System.Drawing.Size(80, 13)
        Me.lblMaxDia.TabIndex = 5
        Me.lblMaxDia.Text = "Max Diameter"
        '
        'teMaxDia
        '
        Me.teMaxDia.EnterMoveNextControl = True
        Me.teMaxDia.Location = New System.Drawing.Point(98, 55)
        Me.teMaxDia.Name = "teMaxDia"
        Me.teMaxDia.Size = New System.Drawing.Size(135, 20)
        Me.teMaxDia.TabIndex = 6
        '
        'lblMinDia
        '
        Me.lblMinDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMinDia.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMinDia.Appearance.Options.UseFont = True
        Me.lblMinDia.Location = New System.Drawing.Point(15, 35)
        Me.lblMinDia.Name = "lblMinDia"
        Me.lblMinDia.Size = New System.Drawing.Size(76, 13)
        Me.lblMinDia.TabIndex = 3
        Me.lblMinDia.Text = "Min Diameter"
        '
        'teMinDia
        '
        Me.teMinDia.EnterMoveNextControl = True
        Me.teMinDia.Location = New System.Drawing.Point(98, 32)
        Me.teMinDia.Name = "teMinDia"
        Me.teMinDia.Size = New System.Drawing.Size(135, 20)
        Me.teMinDia.TabIndex = 4
        '
        'xtcToolLayer
        '
        Me.xtcToolLayer.Location = New System.Drawing.Point(8, 225)
        Me.xtcToolLayer.Name = "xtcToolLayer"
        Me.xtcToolLayer.SelectedTabPage = Me.xtypTools
        Me.xtcToolLayer.Size = New System.Drawing.Size(260, 269)
        Me.xtcToolLayer.TabIndex = 4
        Me.xtcToolLayer.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtypTools, Me.XtraTabPage2})
        '
        'xtypTools
        '
        Me.xtypTools.Controls.Add(Me.grdToolLayer)
        Me.xtypTools.Name = "xtypTools"
        Me.xtypTools.Size = New System.Drawing.Size(255, 244)
        Me.xtypTools.Text = "Tools"
        '
        'grdToolLayer
        '
        Me.grdToolLayer.Location = New System.Drawing.Point(11, 3)
        Me.grdToolLayer.MainView = Me.gViewToolLayer
        Me.grdToolLayer.Name = "grdToolLayer"
        Me.grdToolLayer.Size = New System.Drawing.Size(241, 215)
        Me.grdToolLayer.TabIndex = 2
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
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.grdLayer)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(255, 244)
        Me.XtraTabPage2.Text = "Layers"
        '
        'grdLayer
        '
        Me.grdLayer.Cursor = System.Windows.Forms.Cursors.Default
        GridLevelNode1.RelationName = "Level1"
        Me.grdLayer.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdLayer.Location = New System.Drawing.Point(14, 3)
        Me.grdLayer.MainView = Me.gViewLayer
        Me.grdLayer.Name = "grdLayer"
        Me.grdLayer.Size = New System.Drawing.Size(238, 237)
        Me.grdLayer.TabIndex = 103
        Me.grdLayer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gViewLayer})
        '
        'gViewLayer
        '
        Me.gViewLayer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gViewLayer.GridControl = Me.grdLayer
        Me.gViewLayer.Name = "gViewLayer"
        Me.gViewLayer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gViewLayer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gViewLayer.OptionsBehavior.Editable = False
        Me.gViewLayer.OptionsView.ColumnAutoWidth = False
        Me.gViewLayer.OptionsView.ShowDetailButtons = False
        Me.gViewLayer.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.gViewLayer.OptionsView.ShowGroupPanel = False
        Me.gViewLayer.OptionsView.ShowIndicator = False
        '
        'sbCancel
        '
        Me.sbCancel.Location = New System.Drawing.Point(106, 496)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 105
        Me.sbCancel.Text = "Cancel"
        '
        'sbOk
        '
        Me.sbOk.Location = New System.Drawing.Point(193, 496)
        Me.sbOk.Name = "sbOk"
        Me.sbOk.Size = New System.Drawing.Size(75, 23)
        Me.sbOk.TabIndex = 104
        Me.sbOk.Text = "Ok"
        '
        'lbcIsVisible
        '
        Me.lbcIsVisible.Location = New System.Drawing.Point(5, 545)
        Me.lbcIsVisible.Name = "lbcIsVisible"
        Me.lbcIsVisible.Size = New System.Drawing.Size(260, 63)
        Me.lbcIsVisible.TabIndex = 106
        Me.lbcIsVisible.Visible = False
        '
        'chkDeleteOrg
        '
        Me.chkDeleteOrg.EditValue = True
        Me.chkDeleteOrg.Location = New System.Drawing.Point(12, 187)
        Me.chkDeleteOrg.Name = "chkDeleteOrg"
        Me.chkDeleteOrg.Properties.Caption = "Delete Original"
        Me.chkDeleteOrg.Size = New System.Drawing.Size(75, 19)
        Me.chkDeleteOrg.TabIndex = 107
        '
        'dlgResizeCircle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 611)
        Me.Controls.Add(Me.chkDeleteOrg)
        Me.Controls.Add(Me.lbcIsVisible)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbOk)
        Me.Controls.Add(Me.xtcToolLayer)
        Me.Controls.Add(Me.grpNewDia)
        Me.Controls.Add(Me.grpCurrDia)
        Me.Name = "dlgResizeCircle"
        Me.Text = "dlgResizeCircle"
        CType(Me.grpNewDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNewDia.ResumeLayout(False)
        Me.grpNewDia.PerformLayout()
        CType(Me.teNewDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpCurrDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCurrDia.ResumeLayout(False)
        Me.grpCurrDia.PerformLayout()
        CType(Me.teMaxDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teMinDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtcToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcToolLayer.ResumeLayout(False)
        Me.xtypTools.ResumeLayout(False)
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.grdLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gViewLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcIsVisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDeleteOrg.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpNewDia As GroupControl
    Friend WithEvents lblNewDia As LabelControl
    Friend WithEvents teNewDia As TextEdit
    Friend WithEvents grpCurrDia As GroupControl
    Friend WithEvents lblMaxDia As LabelControl
    Friend WithEvents teMaxDia As TextEdit
    Friend WithEvents lblMinDia As LabelControl
    Friend WithEvents teMinDia As TextEdit
    Friend WithEvents xtcToolLayer As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtypTools As DevExpress.XtraTab.XtraTabPage
    Private WithEvents grdToolLayer As DevExpress.XtraGrid.GridControl
    Private WithEvents gViewToolLayer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents grdLayer As DevExpress.XtraGrid.GridControl
    Private WithEvents gViewLayer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sbCancel As SimpleButton
    Friend WithEvents sbOk As SimpleButton
    Friend WithEvents lbcIsVisible As ListBoxControl
    Friend WithEvents chkDeleteOrg As CheckEdit
End Class
