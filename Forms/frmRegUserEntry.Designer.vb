<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegUserEntry
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
        Me.components = New System.ComponentModel.Container()
        Me.vgMacro = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.sbExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.frmRegUserEntryLayoutControl1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.popupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.fcbMacroFilename = New DevExpress.XtraEditors.ButtonEdit()
        Me.lstOptions = New DevExpress.XtraEditors.ListBoxControl()
        Me.sbCompile = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.GroupControl1item = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.PanelControl1item = New DevExpress.XtraLayout.LayoutControlItem()
        Me.sbExecuteitem = New DevExpress.XtraLayout.LayoutControlItem()
        Me.sbCompileitem = New DevExpress.XtraLayout.LayoutControlItem()
        Me.vgMacroitem = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        CType(Me.vgMacro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmRegUserEntryLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl1.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbMacroFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbExecuteitem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbCompileitem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgMacroitem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vgMacro
        '
        Me.vgMacro.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgMacro.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgMacro.Location = New System.Drawing.Point(12, 12)
        Me.vgMacro.MinimumSize = New System.Drawing.Size(255, 0)
        Me.vgMacro.Name = "vgMacro"
        Me.vgMacro.RecordWidth = 96
        Me.vgMacro.RowHeaderWidth = 104
        Me.vgMacro.Size = New System.Drawing.Size(354, 510)
        Me.vgMacro.TabIndex = 35
        Me.vgMacro.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'sbExecute
        '
        Me.sbExecute.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sbExecute.Location = New System.Drawing.Point(181, 526)
        Me.sbExecute.Name = "sbExecute"
        Me.sbExecute.Size = New System.Drawing.Size(185, 22)
        Me.sbExecute.StyleController = Me.frmRegUserEntryLayoutControl1ConvertedLayout
        Me.sbExecute.TabIndex = 38
        Me.sbExecute.Text = "Execute"
        '
        'frmRegUserEntryLayoutControl1ConvertedLayout
        '
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Controls.Add(Me.PanelControl1)
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Controls.Add(Me.sbExecute)
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Controls.Add(Me.sbCompile)
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Controls.Add(Me.vgMacro)
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Name = "frmRegUserEntryLayoutControl1ConvertedLayout"
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.Size = New System.Drawing.Size(982, 560)
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.TabIndex = 41
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.popupContainerControl1)
        Me.PanelControl1.Controls.Add(Me.tl)
        Me.PanelControl1.Controls.Add(Me.fcbMacroFilename)
        Me.PanelControl1.Controls.Add(Me.lstOptions)
        Me.PanelControl1.Location = New System.Drawing.Point(370, 12)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(600, 536)
        Me.PanelControl1.TabIndex = 39
        '
        'popupContainerControl1
        '
        Me.popupContainerControl1.Controls.Add(Me.TreeList1)
        Me.popupContainerControl1.Location = New System.Drawing.Point(301, 20)
        Me.popupContainerControl1.Name = "popupContainerControl1"
        Me.popupContainerControl1.Size = New System.Drawing.Size(299, 241)
        Me.popupContainerControl1.TabIndex = 69
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
        Me.TreeList1.Size = New System.Drawing.Size(299, 241)
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
        Me.tl.Location = New System.Drawing.Point(296, 290)
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
        Me.tl.Size = New System.Drawing.Size(299, 241)
        Me.tl.TabIndex = 62
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
        Me.fcbMacroFilename.Location = New System.Drawing.Point(33, 59)
        Me.fcbMacroFilename.Name = "fcbMacroFilename"
        Me.fcbMacroFilename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbMacroFilename.Size = New System.Drawing.Size(245, 20)
        Me.fcbMacroFilename.TabIndex = 61
        '
        'lstOptions
        '
        Me.lstOptions.Location = New System.Drawing.Point(78, 104)
        Me.lstOptions.Name = "lstOptions"
        Me.lstOptions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstOptions.Size = New System.Drawing.Size(200, 59)
        Me.lstOptions.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.lstOptions.TabIndex = 60
        Me.lstOptions.Visible = False
        '
        'sbCompile
        '
        Me.sbCompile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sbCompile.Location = New System.Drawing.Point(12, 526)
        Me.sbCompile.Name = "sbCompile"
        Me.sbCompile.Size = New System.Drawing.Size(165, 22)
        Me.sbCompile.StyleController = Me.frmRegUserEntryLayoutControl1ConvertedLayout
        Me.sbCompile.TabIndex = 37
        Me.sbCompile.Text = "Compile"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.GroupControl1item})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(982, 560)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'GroupControl1item
        '
        Me.GroupControl1item.GroupBordersVisible = False
        Me.GroupControl1item.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.PanelControl1item, Me.sbExecuteitem, Me.sbCompileitem, Me.vgMacroitem})
        Me.GroupControl1item.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1item.Name = "GroupControl1item"
        Me.GroupControl1item.Size = New System.Drawing.Size(962, 540)
        Me.GroupControl1item.Text = "LayoutControlGroup1"
        '
        'PanelControl1item
        '
        Me.PanelControl1item.Control = Me.PanelControl1
        Me.PanelControl1item.Location = New System.Drawing.Point(358, 0)
        Me.PanelControl1item.Name = "PanelControl1item"
        Me.PanelControl1item.Size = New System.Drawing.Size(604, 540)
        Me.PanelControl1item.TextSize = New System.Drawing.Size(0, 0)
        Me.PanelControl1item.TextVisible = False
        '
        'sbExecuteitem
        '
        Me.sbExecuteitem.Control = Me.sbExecute
        Me.sbExecuteitem.Location = New System.Drawing.Point(169, 514)
        Me.sbExecuteitem.Name = "sbExecuteitem"
        Me.sbExecuteitem.Size = New System.Drawing.Size(189, 26)
        Me.sbExecuteitem.TextSize = New System.Drawing.Size(0, 0)
        Me.sbExecuteitem.TextVisible = False
        '
        'sbCompileitem
        '
        Me.sbCompileitem.Control = Me.sbCompile
        Me.sbCompileitem.Location = New System.Drawing.Point(0, 514)
        Me.sbCompileitem.Name = "sbCompileitem"
        Me.sbCompileitem.Size = New System.Drawing.Size(169, 26)
        Me.sbCompileitem.TextSize = New System.Drawing.Size(0, 0)
        Me.sbCompileitem.TextVisible = False
        '
        'vgMacroitem
        '
        Me.vgMacroitem.Control = Me.vgMacro
        Me.vgMacroitem.Location = New System.Drawing.Point(0, 0)
        Me.vgMacroitem.Name = "vgMacroitem"
        Me.vgMacroitem.Size = New System.Drawing.Size(358, 514)
        Me.vgMacroitem.TextSize = New System.Drawing.Size(0, 0)
        Me.vgMacroitem.TextVisible = False
        '
        'frmRegUserEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 560)
        Me.Controls.Add(Me.frmRegUserEntryLayoutControl1ConvertedLayout)
        Me.Name = "frmRegUserEntry"
        Me.Text = "frmRegUserEntry"
        CType(Me.vgMacro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmRegUserEntryLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmRegUserEntryLayoutControl1ConvertedLayout.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl1.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbMacroFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbExecuteitem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbCompileitem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgMacroitem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents vgMacro As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents sbExecute As SimpleButton
    Friend WithEvents frmRegUserEntryLayoutControl1ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PanelControl1 As PanelControl
    Friend WithEvents sbCompile As SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GroupControl1item As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PanelControl1item As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sbExecuteitem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sbCompileitem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents vgMacroitem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents lstOptions As ListBoxControl
    Public WithEvents fcbMacroFilename As ButtonEdit
    Private WithEvents tl As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents popupContainerControl1 As PopupContainerControl
    Private WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Private WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
