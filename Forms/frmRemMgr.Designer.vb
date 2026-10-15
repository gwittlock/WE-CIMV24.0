
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemMgr
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
        Me.picPreview = New System.Windows.Forms.Panel()
        Me.sbRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.sbRemnantSettings = New DevExpress.XtraEditors.SimpleButton()
        Me.sbClose = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCommit = New DevExpress.XtraEditors.SimpleButton()
        Me.sbOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.chkFlipRemnant = New DevExpress.XtraEditors.CheckEdit()
        Me.sbLoadPdb = New DevExpress.XtraEditors.SimpleButton()
        Me.sbLoadModel = New DevExpress.XtraEditors.SimpleButton()
        Me.vsfRemData = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.ubgRemnants = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl()
        Me.ubgRemnantsView = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView()
        Me.cdlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.lbcMM2Files = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.chkFlipRemnant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vsfRemData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ubgRemnants, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ubgRemnantsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcMM2Files, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picPreview
        '
        Me.picPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic
        Me.picPreview.BackColor = System.Drawing.Color.Black
        Me.picPreview.CausesValidation = False
        Me.picPreview.Location = New System.Drawing.Point(413, 199)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(259, 211)
        Me.picPreview.TabIndex = 0
        '
        'sbRemove
        '
        Me.sbRemove.Location = New System.Drawing.Point(169, 12)
        Me.sbRemove.Name = "sbRemove"
        Me.sbRemove.Size = New System.Drawing.Size(75, 23)
        Me.sbRemove.TabIndex = 0
        Me.sbRemove.Text = "Remove"
        '
        'sbRemnantSettings
        '
        Me.sbRemnantSettings.AutoSize = True
        Me.sbRemnantSettings.Location = New System.Drawing.Point(278, 12)
        Me.sbRemnantSettings.Name = "sbRemnantSettings"
        Me.sbRemnantSettings.Size = New System.Drawing.Size(94, 22)
        Me.sbRemnantSettings.TabIndex = 1
        Me.sbRemnantSettings.Text = "Remnant Settings"
        '
        'sbClose
        '
        Me.sbClose.Location = New System.Drawing.Point(597, 485)
        Me.sbClose.Name = "sbClose"
        Me.sbClose.Size = New System.Drawing.Size(75, 23)
        Me.sbClose.TabIndex = 2
        Me.sbClose.Text = "Done"
        '
        'sbCommit
        '
        Me.sbCommit.Location = New System.Drawing.Point(413, 424)
        Me.sbCommit.Name = "sbCommit"
        Me.sbCommit.Size = New System.Drawing.Size(75, 23)
        Me.sbCommit.TabIndex = 0
        Me.sbCommit.Text = "Commit"
        '
        'sbOpen
        '
        Me.sbOpen.Location = New System.Drawing.Point(597, 424)
        Me.sbOpen.Name = "sbOpen"
        Me.sbOpen.Size = New System.Drawing.Size(75, 23)
        Me.sbOpen.TabIndex = 5
        Me.sbOpen.Text = "Open"
        '
        'chkFlipRemnant
        '
        Me.chkFlipRemnant.Location = New System.Drawing.Point(507, 426)
        Me.chkFlipRemnant.Name = "chkFlipRemnant"
        Me.chkFlipRemnant.Properties.AutoWidth = True
        Me.chkFlipRemnant.Properties.Caption = "Flip Remnant"
        Me.chkFlipRemnant.Size = New System.Drawing.Size(84, 19)
        Me.chkFlipRemnant.TabIndex = 6
        '
        'sbLoadPdb
        '
        Me.sbLoadPdb.Location = New System.Drawing.Point(12, 387)
        Me.sbLoadPdb.Name = "sbLoadPdb"
        Me.sbLoadPdb.Size = New System.Drawing.Size(75, 23)
        Me.sbLoadPdb.TabIndex = 7
        Me.sbLoadPdb.Text = "Load PDB"
        '
        'sbLoadModel
        '
        Me.sbLoadModel.Location = New System.Drawing.Point(125, 387)
        Me.sbLoadModel.Name = "sbLoadModel"
        Me.sbLoadModel.Size = New System.Drawing.Size(75, 23)
        Me.sbLoadModel.TabIndex = 8
        Me.sbLoadModel.Text = "Load Model"
        '
        'vsfRemData
        '
        Me.vsfRemData.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vsfRemData.Location = New System.Drawing.Point(71, 416)
        Me.vsfRemData.Name = "vsfRemData"
        Me.vsfRemData.OptionsBehavior.Editable = False
        Me.vsfRemData.OptionsView.AutoScaleBands = True
        Me.vsfRemData.OptionsView.ShowButtons = False
        Me.vsfRemData.Size = New System.Drawing.Size(237, 107)
        Me.vsfRemData.TabIndex = 9
        '
        'ubgRemnants
        '
        Me.ubgRemnants.Cursor = System.Windows.Forms.Cursors.Default
        Me.ubgRemnants.Location = New System.Drawing.Point(8, 41)
        Me.ubgRemnants.MainView = Me.ubgRemnantsView
        Me.ubgRemnants.Name = "ubgRemnants"
        Me.ubgRemnants.Size = New System.Drawing.Size(664, 152)
        Me.ubgRemnants.TabIndex = 10
        Me.ubgRemnants.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ubgRemnantsView})
        '
        'ubgRemnantsView
        '
        Me.ubgRemnantsView.ActiveFilterEnabled = False
        Me.ubgRemnantsView.GridControl = Me.ubgRemnants
        Me.ubgRemnantsView.Name = "ubgRemnantsView"
        Me.ubgRemnantsView.OptionsCustomization.AllowColumnMoving = False
        Me.ubgRemnantsView.OptionsCustomization.AllowFilter = False
        Me.ubgRemnantsView.OptionsCustomization.AllowGroup = False
        Me.ubgRemnantsView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ubgRemnantsView.OptionsCustomization.AllowSort = False
        Me.ubgRemnantsView.OptionsDetail.ShowDetailTabs = False
        Me.ubgRemnantsView.OptionsNavigation.EnterMoveNextColumn = True
        Me.ubgRemnantsView.OptionsView.ShowDetailButtons = False
        Me.ubgRemnantsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ubgRemnantsView.OptionsView.ShowGroupPanel = False
        Me.ubgRemnantsView.OptionsView.ShowIndicator = False
        '
        'lbcMM2Files
        '
        Me.lbcMM2Files.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbcMM2Files.Location = New System.Drawing.Point(12, 199)
        Me.lbcMM2Files.Name = "lbcMM2Files"
        Me.lbcMM2Files.Size = New System.Drawing.Size(385, 177)
        Me.lbcMM2Files.TabIndex = 11
        '
        'frmRemMgr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 527)
        Me.Controls.Add(Me.lbcMM2Files)
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.ubgRemnants)
        Me.Controls.Add(Me.vsfRemData)
        Me.Controls.Add(Me.sbLoadModel)
        Me.Controls.Add(Me.sbLoadPdb)
        Me.Controls.Add(Me.chkFlipRemnant)
        Me.Controls.Add(Me.sbOpen)
        Me.Controls.Add(Me.sbCommit)
        Me.Controls.Add(Me.sbClose)
        Me.Controls.Add(Me.sbRemnantSettings)
        Me.Controls.Add(Me.sbRemove)
        Me.Name = "frmRemMgr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRemMgr"
        CType(Me.chkFlipRemnant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vsfRemData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ubgRemnants, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ubgRemnantsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcMM2Files, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbRemnantSettings As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbCommit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkFlipRemnant As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents sbLoadPdb As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbLoadModel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents vsfRemData As DevExpress.XtraVerticalGrid.VGridControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_file_paths = New clsStringArray

    End Sub
    Friend WithEvents ubgRemnants As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl
    Friend WithEvents ubgRemnantsView As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView
    Friend WithEvents cdlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbcMM2Files As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents picPreview As System.Windows.Forms.Panel

End Class
