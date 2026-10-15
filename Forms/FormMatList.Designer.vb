<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatList
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
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.vGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.popupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.lbOptions = New DevExpress.XtraEditors.ListBoxControl()
        Me.popupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl1.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.Controls.Add(Me.vGridControl1)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(486, 427, 250, 350)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(358, 396)
        Me.layoutControl1.TabIndex = 1
        Me.layoutControl1.Text = "layoutControl1"
        '
        'vGridControl1
        '
        Me.vGridControl1.BandsInterval = 1
        Me.vGridControl1.Location = New System.Drawing.Point(12, 12)
        Me.vGridControl1.Name = "vGridControl1"
        Me.vGridControl1.OptionsView.AutoScaleBands = True
        Me.vGridControl1.OptionsView.FixedLineWidth = 1
        Me.vGridControl1.RecordWidth = 150
        Me.vGridControl1.RowHeaderWidth = 150
        Me.vGridControl1.Size = New System.Drawing.Size(334, 372)
        Me.vGridControl1.TabIndex = 7
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem4})
        Me.layoutControlGroup1.Name = "layoutControlGroup1"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(358, 396)
        Me.layoutControlGroup1.TextVisible = False
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.vGridControl1
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(338, 376)
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem4.TextVisible = False
        '
        'tl
        '
        Me.tl.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.MainRoot})
        Me.tl.Location = New System.Drawing.Point(575, 12)
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
        Me.tl.TabIndex = 70
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
        'popupContainerEdit1
        '
        Me.popupContainerEdit1.Location = New System.Drawing.Point(364, 50)
        Me.popupContainerEdit1.Name = "popupContainerEdit1"
        Me.popupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.popupContainerEdit1.Properties.ShowPopupCloseButton = False
        Me.popupContainerEdit1.Properties.ShowPopupShadow = False
        Me.popupContainerEdit1.Properties.SuppressMouseEventOnOuterMouseClick = True
        Me.popupContainerEdit1.Size = New System.Drawing.Size(228, 20)
        Me.popupContainerEdit1.TabIndex = 72
        '
        'lbOptions
        '
        Me.lbOptions.Appearance.BackColor = System.Drawing.Color.White
        Me.lbOptions.Appearance.Options.UseBackColor = True
        Me.lbOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbOptions.Location = New System.Drawing.Point(364, 12)
        Me.lbOptions.Name = "lbOptions"
        Me.lbOptions.Size = New System.Drawing.Size(120, 21)
        Me.lbOptions.TabIndex = 71
        Me.lbOptions.Visible = False
        '
        'popupContainerControl1
        '
        Me.popupContainerControl1.Controls.Add(Me.TreeList1)
        Me.popupContainerControl1.Location = New System.Drawing.Point(284, 78)
        Me.popupContainerControl1.Name = "popupContainerControl1"
        Me.popupContainerControl1.Size = New System.Drawing.Size(299, 241)
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
        Me.TreeList1.Size = New System.Drawing.Size(299, 241)
        Me.TreeList1.TabIndex = 7
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
        'FormMatList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 396)
        Me.Controls.Add(Me.popupContainerControl1)
        Me.Controls.Add(Me.tl)
        Me.Controls.Add(Me.popupContainerEdit1)
        Me.Controls.Add(Me.lbOptions)
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "FormMatList"
        Me.Text = "FormMatList"
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl1.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private WithEvents vGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Private WithEvents layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private WithEvents layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Private WithEvents tl As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents popupContainerEdit1 As PopupContainerEdit
    Friend WithEvents lbOptions As ListBoxControl
    Private WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Private WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Public WithEvents popupContainerControl1 As PopupContainerControl
End Class
