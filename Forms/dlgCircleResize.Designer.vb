<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgCircleResize
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.grpCurrDia = New DevExpress.XtraEditors.GroupControl()
        Me.lblMaxDia = New DevExpress.XtraEditors.LabelControl()
        Me.teMaxDia = New DevExpress.XtraEditors.TextEdit()
        Me.lblMinDia = New DevExpress.XtraEditors.LabelControl()
        Me.teMinDia = New DevExpress.XtraEditors.TextEdit()
        Me.grpNewDia = New DevExpress.XtraEditors.GroupControl()
        Me.lblNewDia = New DevExpress.XtraEditors.LabelControl()
        Me.teNewDia = New DevExpress.XtraEditors.TextEdit()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.sbAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.xtcToolLayer = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpTools = New DevExpress.XtraTab.XtraTabPage()
        Me.xtpLayers = New DevExpress.XtraTab.XtraTabPage()
        Me.grdToolLayer = New DevExpress.XtraGrid.GridControl()
        Me.gViewToolLayer = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.grpCurrDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCurrDia.SuspendLayout()
        CType(Me.teMaxDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teMinDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpNewDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNewDia.SuspendLayout()
        CType(Me.teNewDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtcToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcToolLayer.SuspendLayout()
        Me.xtpTools.SuspendLayout()
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCurrDia
        '
        Me.grpCurrDia.Controls.Add(Me.lblMaxDia)
        Me.grpCurrDia.Controls.Add(Me.teMaxDia)
        Me.grpCurrDia.Controls.Add(Me.lblMinDia)
        Me.grpCurrDia.Controls.Add(Me.teMinDia)
        Me.grpCurrDia.Location = New System.Drawing.Point(12, 12)
        Me.grpCurrDia.Name = "grpCurrDia"
        Me.grpCurrDia.Size = New System.Drawing.Size(245, 98)
        Me.grpCurrDia.TabIndex = 0
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
        'grpNewDia
        '
        Me.grpNewDia.Controls.Add(Me.lblNewDia)
        Me.grpNewDia.Controls.Add(Me.teNewDia)
        Me.grpNewDia.Location = New System.Drawing.Point(12, 116)
        Me.grpNewDia.Name = "grpNewDia"
        Me.grpNewDia.Size = New System.Drawing.Size(245, 65)
        Me.grpNewDia.TabIndex = 1
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
        'sbCancel
        '
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Location = New System.Drawing.Point(101, 523)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 12
        Me.sbCancel.Text = "Cancel"
        '
        'sbAccept
        '
        Me.sbAccept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.sbAccept.Location = New System.Drawing.Point(182, 523)
        Me.sbAccept.Name = "sbAccept"
        Me.sbAccept.Size = New System.Drawing.Size(75, 23)
        Me.sbAccept.TabIndex = 13
        Me.sbAccept.Text = "Accept"
        '
        'xtcToolLayer
        '
        Me.xtcToolLayer.Location = New System.Drawing.Point(12, 207)
        Me.xtcToolLayer.Name = "xtcToolLayer"
        Me.xtcToolLayer.SelectedTabPage = Me.xtpTools
        Me.xtcToolLayer.Size = New System.Drawing.Size(245, 300)
        Me.xtcToolLayer.TabIndex = 14
        Me.xtcToolLayer.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpTools, Me.xtpLayers})
        '
        'xtpTools
        '
        Me.xtpTools.Controls.Add(Me.grdToolLayer)
        Me.xtpTools.Name = "xtpTools"
        Me.xtpTools.Size = New System.Drawing.Size(240, 275)
        Me.xtpTools.Text = "Tools"
        '
        'xtpLayers
        '
        Me.xtpLayers.Name = "xtpLayers"
        Me.xtpLayers.Size = New System.Drawing.Size(240, 275)
        Me.xtpLayers.Text = "layers"
        '
        'grdToolLayer
        '
        Me.grdToolLayer.Cursor = System.Windows.Forms.Cursors.Default
        GridLevelNode1.RelationName = "Level1"
        Me.grdToolLayer.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdToolLayer.Location = New System.Drawing.Point(11, 3)
        Me.grdToolLayer.MainView = Me.gViewToolLayer
        Me.grdToolLayer.Name = "grdToolLayer"
        Me.grdToolLayer.Size = New System.Drawing.Size(233, 243)
        Me.grdToolLayer.TabIndex = 105
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
        'dlgCircleResize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 637)
        Me.Controls.Add(Me.xtcToolLayer)
        Me.Controls.Add(Me.sbAccept)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.grpNewDia)
        Me.Controls.Add(Me.grpCurrDia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgCircleResize"
        Me.Text = "Circle Resize"
        CType(Me.grpCurrDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCurrDia.ResumeLayout(False)
        Me.grpCurrDia.PerformLayout()
        CType(Me.teMaxDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teMinDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpNewDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNewDia.ResumeLayout(False)
        Me.grpNewDia.PerformLayout()
        CType(Me.teNewDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtcToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcToolLayer.ResumeLayout(False)
        Me.xtpTools.ResumeLayout(False)
        CType(Me.grdToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gViewToolLayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpCurrDia As GroupControl
    Friend WithEvents grpNewDia As GroupControl
    Friend WithEvents lblMaxDia As LabelControl
    Friend WithEvents teMaxDia As TextEdit
    Friend WithEvents lblMinDia As LabelControl
    Friend WithEvents teMinDia As TextEdit
    Friend WithEvents lblNewDia As LabelControl
    Friend WithEvents teNewDia As TextEdit
    Friend WithEvents sbCancel As SimpleButton
    Friend WithEvents sbAccept As SimpleButton
    Friend WithEvents xtcToolLayer As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpTools As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtpLayers As DevExpress.XtraTab.XtraTabPage
    Private WithEvents grdToolLayer As DevExpress.XtraGrid.GridControl
    Private WithEvents gViewToolLayer As DevExpress.XtraGrid.Views.Grid.GridView
End Class
