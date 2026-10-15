<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegDataUserNew
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.tlDataUserEntry = New DevExpress.XtraTreeList.TreeList()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.sbCompile = New DevExpress.XtraEditors.SimpleButton()
        Me.sbExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.vgMacro = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.popupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.fcbMacroFilename = New DevExpress.XtraEditors.ButtonEdit()
        Me.lstOptions = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.tlDataUserEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.vgMacro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl1.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbMacroFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.tlDataUserEntry)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(274, 524)
        Me.PanelControl1.TabIndex = 0
        '
        'tlDataUserEntry
        '
        Me.tlDataUserEntry.Appearance.HeaderPanelBackground.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tlDataUserEntry.Appearance.HeaderPanelBackground.Options.UseBackColor = True
        Me.tlDataUserEntry.Caption = "Reg Data User"
        Me.tlDataUserEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlDataUserEntry.Location = New System.Drawing.Point(2, 2)
        Me.tlDataUserEntry.Name = "tlDataUserEntry"
        Me.tlDataUserEntry.OptionsView.ShowCaption = True
        Me.tlDataUserEntry.Size = New System.Drawing.Size(270, 480)
        Me.tlDataUserEntry.TabIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.sbCompile)
        Me.PanelControl2.Controls.Add(Me.sbExecute)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(2, 482)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(270, 40)
        Me.PanelControl2.TabIndex = 0
        '
        'sbCompile
        '
        Me.sbCompile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sbCompile.Location = New System.Drawing.Point(5, 5)
        Me.sbCompile.Name = "sbCompile"
        Me.sbCompile.Size = New System.Drawing.Size(96, 22)
        Me.sbCompile.TabIndex = 40
        Me.sbCompile.Text = "Compile"
        '
        'sbExecute
        '
        Me.sbExecute.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sbExecute.Location = New System.Drawing.Point(169, 6)
        Me.sbExecute.Name = "sbExecute"
        Me.sbExecute.Size = New System.Drawing.Size(96, 22)
        Me.sbExecute.TabIndex = 39
        Me.sbExecute.Text = "Execute"
        '
        'vgMacro
        '
        Me.vgMacro.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgMacro.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgMacro.Location = New System.Drawing.Point(303, 15)
        Me.vgMacro.MinimumSize = New System.Drawing.Size(255, 0)
        Me.vgMacro.Name = "vgMacro"
        Me.vgMacro.RecordWidth = 96
        Me.vgMacro.RowHeaderWidth = 104
        Me.vgMacro.Size = New System.Drawing.Size(255, 404)
        Me.vgMacro.TabIndex = 68
        Me.vgMacro.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'popupContainerControl1
        '
        Me.popupContainerControl1.Controls.Add(Me.TreeList1)
        Me.popupContainerControl1.Location = New System.Drawing.Point(693, 103)
        Me.popupContainerControl1.Name = "popupContainerControl1"
        Me.popupContainerControl1.Size = New System.Drawing.Size(299, 162)
        Me.popupContainerControl1.TabIndex = 73
        '
        'TreeList1
        '
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn1})
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.AutoChangeParent = False
        Me.TreeList1.OptionsBehavior.AutoNodeHeight = False
        Me.TreeList1.OptionsBehavior.AutoSelectAllInEditor = False
        Me.TreeList1.OptionsBehavior.CloseEditorOnLostFocus = False
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsBehavior.ResizeNodes = False
        Me.TreeList1.OptionsBehavior.SmartMouseHover = False
        Me.TreeList1.OptionsMenu.EnableFooterMenu = False
        Me.TreeList1.OptionsPrint.PrintHorzLines = False
        Me.TreeList1.OptionsPrint.PrintVertLines = False
        Me.TreeList1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.TreeList1.OptionsSelection.KeepSelectedOnClick = False
        Me.TreeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None
        Me.TreeList1.OptionsView.ShowIndicator = False
        Me.TreeList1.Size = New System.Drawing.Size(299, 162)
        Me.TreeList1.TabIndex = 8
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.AllNodesSummary = True
        Me.TreeListColumn1.Caption = "Materials"
        Me.TreeListColumn1.FieldName = "Key"
        Me.TreeListColumn1.MinWidth = 33
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.TreeListColumn1.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.TreeListColumn1.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count
        Me.TreeListColumn1.SummaryFooterStrFormat = "Count keys = {0}"
        Me.TreeListColumn1.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 0
        Me.TreeListColumn1.Width = 235
        '
        'tl
        '
        Me.tl.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.MainRoot})
        Me.tl.Location = New System.Drawing.Point(691, 271)
        Me.tl.Name = "tl"
        Me.tl.OptionsBehavior.AutoChangeParent = False
        Me.tl.OptionsBehavior.AutoNodeHeight = False
        Me.tl.OptionsBehavior.AutoSelectAllInEditor = False
        Me.tl.OptionsBehavior.CloseEditorOnLostFocus = False
        Me.tl.OptionsBehavior.Editable = False
        Me.tl.OptionsBehavior.ResizeNodes = False
        Me.tl.OptionsBehavior.SmartMouseHover = False
        Me.tl.OptionsMenu.EnableFooterMenu = False
        Me.tl.OptionsPrint.PrintHorzLines = False
        Me.tl.OptionsPrint.PrintVertLines = False
        Me.tl.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tl.OptionsSelection.KeepSelectedOnClick = False
        Me.tl.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None
        Me.tl.OptionsView.ShowIndicator = False
        Me.tl.Size = New System.Drawing.Size(299, 137)
        Me.tl.TabIndex = 72
        Me.tl.Visible = False
        '
        'MainRoot
        '
        Me.MainRoot.AllNodesSummary = True
        Me.MainRoot.Caption = "Materials"
        Me.MainRoot.FieldName = "Key"
        Me.MainRoot.MinWidth = 33
        Me.MainRoot.Name = "MainRoot"
        Me.MainRoot.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.MainRoot.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.MainRoot.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count
        Me.MainRoot.SummaryFooterStrFormat = "Count keys = {0}"
        Me.MainRoot.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.MainRoot.Width = 235
        '
        'fcbMacroFilename
        '
        Me.fcbMacroFilename.Location = New System.Drawing.Point(691, 12)
        Me.fcbMacroFilename.Name = "fcbMacroFilename"
        Me.fcbMacroFilename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbMacroFilename.Size = New System.Drawing.Size(245, 20)
        Me.fcbMacroFilename.TabIndex = 71
        '
        'lstOptions
        '
        Me.lstOptions.Location = New System.Drawing.Point(693, 38)
        Me.lstOptions.Name = "lstOptions"
        Me.lstOptions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstOptions.Size = New System.Drawing.Size(200, 59)
        Me.lstOptions.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.lstOptions.TabIndex = 70
        Me.lstOptions.Visible = False
        '
        'frmRegDataUserNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 529)
        Me.Controls.Add(Me.popupContainerControl1)
        Me.Controls.Add(Me.tl)
        Me.Controls.Add(Me.fcbMacroFilename)
        Me.Controls.Add(Me.lstOptions)
        Me.Controls.Add(Me.vgMacro)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmRegDataUserNew"
        Me.Text = "frmRegDataUserNew"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.tlDataUserEntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.vgMacro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl1.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbMacroFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As PanelControl
    Friend WithEvents PanelControl2 As PanelControl
    Friend WithEvents sbExecute As SimpleButton
    Friend WithEvents tlDataUserEntry As DevExpress.XtraTreeList.TreeList
    Friend WithEvents sbCompile As SimpleButton
    Friend WithEvents vgMacro As DevExpress.XtraVerticalGrid.VGridControl
    Private WithEvents popupContainerControl1 As PopupContainerControl
    Private WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Private WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents tl As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Public WithEvents fcbMacroFilename As ButtonEdit
    Friend WithEvents lstOptions As ListBoxControl
End Class
