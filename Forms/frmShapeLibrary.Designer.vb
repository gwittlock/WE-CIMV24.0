Imports DevExpress.XtraEditors.Repository

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmShapeLibrary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShapeLibrary))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.pnlMacroVars = New DevExpress.XtraEditors.PanelControl()
        Me.MacVarLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.sbExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.fcbMacroFilename = New DevExpress.XtraEditors.ButtonEdit()
        Me.vgMacro = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.sbCompile = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lblMacFilename = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.pnlMacroIcons = New DevExpress.XtraEditors.PanelControl()
        Me.navShapeLibrary = New DevExpress.XtraNavBar.NavBarControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.popupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.popupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.picMacroDrawing = New DevExpress.XtraEditors.PictureEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.lstOptions = New DevExpress.XtraEditors.ListBoxControl()
        Me.ImageCollDWG = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.pnlMacroVars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMacroVars.SuspendLayout()
        CType(Me.MacVarLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MacVarLayout.SuspendLayout()
        CType(Me.fcbMacroFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgMacro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMacFilename, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMacroIcons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMacroIcons.SuspendLayout()
        CType(Me.navShapeLibrary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl1.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMacroDrawing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollDWG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.SplitContainerControl1.MinimumSize = New System.Drawing.Size(277, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.pnlMacroVars)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.pnlMacroIcons)
        Me.SplitContainerControl1.Panel1.MinSize = 200
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.popupContainerControl1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.tl)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.popupContainerEdit1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.picMacroDrawing)
        Me.SplitContainerControl1.Panel2.MinSize = 15
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(952, 556)
        Me.SplitContainerControl1.SplitterPosition = 495
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'pnlMacroVars
        '
        Me.pnlMacroVars.Controls.Add(Me.MacVarLayout)
        Me.pnlMacroVars.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMacroVars.Location = New System.Drawing.Point(150, 0)
        Me.pnlMacroVars.MinimumSize = New System.Drawing.Size(150, 0)
        Me.pnlMacroVars.Name = "pnlMacroVars"
        Me.pnlMacroVars.Size = New System.Drawing.Size(345, 556)
        Me.pnlMacroVars.TabIndex = 8
        '
        'MacVarLayout
        '
        Me.MacVarLayout.Controls.Add(Me.sbExecute)
        Me.MacVarLayout.Controls.Add(Me.fcbMacroFilename)
        Me.MacVarLayout.Controls.Add(Me.vgMacro)
        Me.MacVarLayout.Controls.Add(Me.sbCompile)
        Me.MacVarLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MacVarLayout.Location = New System.Drawing.Point(2, 2)
        Me.MacVarLayout.Name = "MacVarLayout"
        Me.MacVarLayout.Root = Me.LayoutControlGroup2
        Me.MacVarLayout.Size = New System.Drawing.Size(341, 552)
        Me.MacVarLayout.TabIndex = 36
        '
        'sbExecute
        '
        Me.sbExecute.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sbExecute.Location = New System.Drawing.Point(207, 523)
        Me.sbExecute.Name = "sbExecute"
        Me.sbExecute.Size = New System.Drawing.Size(127, 22)
        Me.sbExecute.StyleController = Me.MacVarLayout
        Me.sbExecute.TabIndex = 36
        Me.sbExecute.Text = "Execute"
        '
        'fcbMacroFilename
        '
        Me.fcbMacroFilename.Location = New System.Drawing.Point(88, 7)
        Me.fcbMacroFilename.Name = "fcbMacroFilename"
        Me.fcbMacroFilename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbMacroFilename.Size = New System.Drawing.Size(246, 20)
        Me.fcbMacroFilename.StyleController = Me.MacVarLayout
        Me.fcbMacroFilename.TabIndex = 30
        '
        'vgMacro
        '
        Me.vgMacro.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgMacro.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgMacro.Location = New System.Drawing.Point(7, 31)
        Me.vgMacro.MinimumSize = New System.Drawing.Size(255, 0)
        Me.vgMacro.Name = "vgMacro"
        Me.vgMacro.RecordWidth = 92
        Me.vgMacro.RowHeaderWidth = 108
        Me.vgMacro.Size = New System.Drawing.Size(327, 488)
        Me.vgMacro.TabIndex = 34
        Me.vgMacro.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'sbCompile
        '
        Me.sbCompile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sbCompile.Location = New System.Drawing.Point(7, 523)
        Me.sbCompile.Name = "sbCompile"
        Me.sbCompile.Size = New System.Drawing.Size(96, 22)
        Me.sbCompile.StyleController = Me.MacVarLayout
        Me.sbCompile.TabIndex = 31
        Me.sbCompile.Text = "Compile"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lblMacFilename, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(341, 552)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'lblMacFilename
        '
        Me.lblMacFilename.Control = Me.fcbMacroFilename
        Me.lblMacFilename.CustomizationFormText = "Macro Filename:"
        Me.lblMacFilename.Location = New System.Drawing.Point(0, 0)
        Me.lblMacFilename.Name = "lblMacFilename"
        Me.lblMacFilename.Size = New System.Drawing.Size(331, 24)
        Me.lblMacFilename.Text = "Macro Filename:"
        Me.lblMacFilename.TextSize = New System.Drawing.Size(78, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.vgMacro
        Me.LayoutControlItem3.CustomizationFormText = "vgMacroitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "vgMacroitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(331, 492)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.sbCompile
        Me.LayoutControlItem4.CustomizationFormText = "sbCompileitem"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 516)
        Me.LayoutControlItem4.Name = "sbCompileitem"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(100, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(100, 516)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(100, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.sbExecute
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(200, 516)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(131, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'pnlMacroIcons
        '
        Me.pnlMacroIcons.Controls.Add(Me.navShapeLibrary)
        Me.pnlMacroIcons.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMacroIcons.Location = New System.Drawing.Point(0, 0)
        Me.pnlMacroIcons.MinimumSize = New System.Drawing.Size(150, 0)
        Me.pnlMacroIcons.Name = "pnlMacroIcons"
        Me.pnlMacroIcons.Size = New System.Drawing.Size(150, 556)
        Me.pnlMacroIcons.TabIndex = 7
        '
        'navShapeLibrary
        '
        Me.navShapeLibrary.AllowDrop = False
        Me.navShapeLibrary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.navShapeLibrary.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None
        Me.navShapeLibrary.LargeImages = Me.ImageCollection1
        Me.navShapeLibrary.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInGroup
        Me.navShapeLibrary.Location = New System.Drawing.Point(2, 2)
        Me.navShapeLibrary.Name = "navShapeLibrary"
        Me.navShapeLibrary.NavigationPaneOverflowPanelUseSmallImages = False
        Me.navShapeLibrary.OptionsNavPane.ExpandedWidth = 146
        Me.navShapeLibrary.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.SideBar
        Me.navShapeLibrary.Size = New System.Drawing.Size(146, 552)
        Me.navShapeLibrary.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar
        Me.navShapeLibrary.SmallImages = Me.ImageCollection1
        Me.navShapeLibrary.TabIndex = 1
        Me.navShapeLibrary.Text = "NavBarControl1"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageSize = New System.Drawing.Size(48, 48)
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "9001.png")
        Me.ImageCollection1.Images.SetKeyName(1, "9002.png")
        Me.ImageCollection1.Images.SetKeyName(2, "9003.png")
        Me.ImageCollection1.Images.SetKeyName(3, "9004.png")
        Me.ImageCollection1.Images.SetKeyName(4, "9005.png")
        Me.ImageCollection1.Images.SetKeyName(5, "9006.png")
        Me.ImageCollection1.Images.SetKeyName(6, "9007.png")
        Me.ImageCollection1.Images.SetKeyName(7, "9008.png")
        Me.ImageCollection1.Images.SetKeyName(8, "9009.png")
        Me.ImageCollection1.Images.SetKeyName(9, "9010.png")
        Me.ImageCollection1.Images.SetKeyName(10, "9011.png")
        Me.ImageCollection1.Images.SetKeyName(11, "9012.png")
        Me.ImageCollection1.Images.SetKeyName(12, "9013.png")
        Me.ImageCollection1.Images.SetKeyName(13, "9014.png")
        Me.ImageCollection1.Images.SetKeyName(14, "9015.png")
        Me.ImageCollection1.Images.SetKeyName(15, "9101.png")
        Me.ImageCollection1.Images.SetKeyName(16, "9102.png")
        Me.ImageCollection1.Images.SetKeyName(17, "9103.png")
        Me.ImageCollection1.Images.SetKeyName(18, "9104.png")
        Me.ImageCollection1.Images.SetKeyName(19, "9105.png")
        Me.ImageCollection1.Images.SetKeyName(20, "9106.png")
        Me.ImageCollection1.Images.SetKeyName(21, "9107.png")
        Me.ImageCollection1.Images.SetKeyName(22, "9108.png")
        Me.ImageCollection1.Images.SetKeyName(23, "9109.png")
        Me.ImageCollection1.Images.SetKeyName(24, "9110.png")
        Me.ImageCollection1.Images.SetKeyName(25, "9111.png")
        Me.ImageCollection1.Images.SetKeyName(26, "9112.png")
        Me.ImageCollection1.Images.SetKeyName(27, "9113.png")
        Me.ImageCollection1.Images.SetKeyName(28, "9201.png")
        Me.ImageCollection1.Images.SetKeyName(29, "9202.png")
        Me.ImageCollection1.Images.SetKeyName(30, "9203.png")
        Me.ImageCollection1.Images.SetKeyName(31, "9204.png")
        Me.ImageCollection1.Images.SetKeyName(32, "9205.png")
        Me.ImageCollection1.Images.SetKeyName(33, "9206.png")
        Me.ImageCollection1.Images.SetKeyName(34, "9207.png")
        Me.ImageCollection1.Images.SetKeyName(35, "9208.png")
        Me.ImageCollection1.Images.SetKeyName(36, "9209.png")
        Me.ImageCollection1.Images.SetKeyName(37, "9210.png")
        Me.ImageCollection1.Images.SetKeyName(38, "9211.png")
        Me.ImageCollection1.Images.SetKeyName(39, "9212.png")
        Me.ImageCollection1.Images.SetKeyName(40, "9213.png")
        Me.ImageCollection1.Images.SetKeyName(41, "9214.png")
        Me.ImageCollection1.Images.SetKeyName(42, "9215.png")
        Me.ImageCollection1.Images.SetKeyName(43, "9216.png")
        Me.ImageCollection1.Images.SetKeyName(44, "9301.png")
        Me.ImageCollection1.Images.SetKeyName(45, "9302.png")
        Me.ImageCollection1.Images.SetKeyName(46, "9303.png")
        Me.ImageCollection1.Images.SetKeyName(47, "9401.png")
        Me.ImageCollection1.Images.SetKeyName(48, "9402.png")
        Me.ImageCollection1.Images.SetKeyName(49, "9403.png")
        Me.ImageCollection1.Images.SetKeyName(50, "9404.png")
        Me.ImageCollection1.Images.SetKeyName(51, "9405.png")
        Me.ImageCollection1.Images.SetKeyName(52, "9406.png")
        Me.ImageCollection1.Images.SetKeyName(53, "9407.png")
        '
        'popupContainerControl1
        '
        Me.popupContainerControl1.Controls.Add(Me.TreeList1)
        Me.popupContainerControl1.Location = New System.Drawing.Point(69, 143)
        Me.popupContainerControl1.Name = "popupContainerControl1"
        Me.popupContainerControl1.Size = New System.Drawing.Size(299, 241)
        Me.popupContainerControl1.TabIndex = 68
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
        Me.tl.Location = New System.Drawing.Point(8, 8)
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
        Me.tl.TabIndex = 54
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
        'popupContainerEdit1
        '
        Me.popupContainerEdit1.Location = New System.Drawing.Point(219, 268)
        Me.popupContainerEdit1.Name = "popupContainerEdit1"
        Me.popupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.popupContainerEdit1.Properties.ShowPopupCloseButton = False
        Me.popupContainerEdit1.Properties.ShowPopupShadow = False
        Me.popupContainerEdit1.Properties.SuppressMouseEventOnOuterMouseClick = True
        Me.popupContainerEdit1.Size = New System.Drawing.Size(228, 20)
        Me.popupContainerEdit1.TabIndex = 53
        Me.popupContainerEdit1.Visible = False
        '
        'picMacroDrawing
        '
        Me.picMacroDrawing.Location = New System.Drawing.Point(0, 0)
        Me.picMacroDrawing.MinimumSize = New System.Drawing.Size(510, 210)
        Me.picMacroDrawing.Name = "picMacroDrawing"
        Me.picMacroDrawing.Size = New System.Drawing.Size(510, 556)
        Me.picMacroDrawing.TabIndex = 0
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(348, 458)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lstOptions
        '
        Me.lstOptions.Location = New System.Drawing.Point(155, 249)
        Me.lstOptions.Name = "lstOptions"
        Me.lstOptions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstOptions.Size = New System.Drawing.Size(200, 59)
        Me.lstOptions.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.lstOptions.TabIndex = 59
        Me.lstOptions.Visible = False
        '
        'ImageCollDWG
        '
        Me.ImageCollDWG.ImageSize = New System.Drawing.Size(502, 502)
        Me.ImageCollDWG.ImageStream = CType(resources.GetObject("ImageCollDWG.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollDWG.Images.SetKeyName(0, "9001.gif")
        Me.ImageCollDWG.Images.SetKeyName(1, "9002.gif")
        Me.ImageCollDWG.Images.SetKeyName(2, "9003.gif")
        Me.ImageCollDWG.Images.SetKeyName(3, "9004.gif")
        Me.ImageCollDWG.Images.SetKeyName(4, "9005.gif")
        Me.ImageCollDWG.Images.SetKeyName(5, "9006.gif")
        Me.ImageCollDWG.Images.SetKeyName(6, "9007.gif")
        Me.ImageCollDWG.Images.SetKeyName(7, "9008.gif")
        Me.ImageCollDWG.Images.SetKeyName(8, "9009.gif")
        Me.ImageCollDWG.Images.SetKeyName(9, "9010.gif")
        Me.ImageCollDWG.Images.SetKeyName(10, "9011.gif")
        Me.ImageCollDWG.Images.SetKeyName(11, "9012.gif")
        Me.ImageCollDWG.Images.SetKeyName(12, "9013.gif")
        Me.ImageCollDWG.Images.SetKeyName(13, "9014.gif")
        Me.ImageCollDWG.Images.SetKeyName(14, "9015.gif")
        Me.ImageCollDWG.Images.SetKeyName(15, "9101.gif")
        Me.ImageCollDWG.Images.SetKeyName(16, "9102.gif")
        Me.ImageCollDWG.Images.SetKeyName(17, "9103.gif")
        Me.ImageCollDWG.Images.SetKeyName(18, "9104.gif")
        Me.ImageCollDWG.Images.SetKeyName(19, "9105.gif")
        Me.ImageCollDWG.Images.SetKeyName(20, "9106.gif")
        Me.ImageCollDWG.Images.SetKeyName(21, "9107.gif")
        Me.ImageCollDWG.Images.SetKeyName(22, "9108.gif")
        Me.ImageCollDWG.Images.SetKeyName(23, "9109.gif")
        Me.ImageCollDWG.Images.SetKeyName(24, "9110.gif")
        Me.ImageCollDWG.Images.SetKeyName(25, "9111.gif")
        Me.ImageCollDWG.Images.SetKeyName(26, "9112.gif")
        Me.ImageCollDWG.Images.SetKeyName(27, "9113.gif")
        Me.ImageCollDWG.Images.SetKeyName(28, "9201.gif")
        Me.ImageCollDWG.Images.SetKeyName(29, "9202.gif")
        Me.ImageCollDWG.Images.SetKeyName(30, "9203.gif")
        Me.ImageCollDWG.Images.SetKeyName(31, "9204.gif")
        Me.ImageCollDWG.Images.SetKeyName(32, "9205.gif")
        Me.ImageCollDWG.Images.SetKeyName(33, "9206.gif")
        Me.ImageCollDWG.Images.SetKeyName(34, "9207.gif")
        Me.ImageCollDWG.Images.SetKeyName(35, "9208.gif")
        Me.ImageCollDWG.Images.SetKeyName(36, "9209.gif")
        Me.ImageCollDWG.Images.SetKeyName(37, "9210.gif")
        Me.ImageCollDWG.Images.SetKeyName(38, "9211.gif")
        Me.ImageCollDWG.Images.SetKeyName(39, "9212.gif")
        Me.ImageCollDWG.Images.SetKeyName(40, "9213.gif")
        Me.ImageCollDWG.Images.SetKeyName(41, "9214.gif")
        Me.ImageCollDWG.Images.SetKeyName(42, "9215.gif")
        Me.ImageCollDWG.Images.SetKeyName(43, "9216.gif")
        Me.ImageCollDWG.Images.SetKeyName(44, "9301.gif")
        Me.ImageCollDWG.Images.SetKeyName(45, "9302.gif")
        Me.ImageCollDWG.Images.SetKeyName(46, "9303.gif")
        Me.ImageCollDWG.Images.SetKeyName(47, "9401.gif")
        Me.ImageCollDWG.Images.SetKeyName(48, "9402.gif")
        Me.ImageCollDWG.Images.SetKeyName(49, "9403.gif")
        Me.ImageCollDWG.Images.SetKeyName(50, "9404.gif")
        Me.ImageCollDWG.Images.SetKeyName(51, "9405.gif")
        Me.ImageCollDWG.Images.SetKeyName(52, "9406.gif")
        Me.ImageCollDWG.Images.SetKeyName(53, "9407.gif")
        '
        'frmShapeLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 556)
        Me.Controls.Add(Me.lstOptions)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(277, 47)
        Me.Name = "frmShapeLibrary"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Shape Library"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.pnlMacroVars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMacroVars.ResumeLayout(False)
        CType(Me.MacVarLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MacVarLayout.ResumeLayout(False)
        CType(Me.fcbMacroFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgMacro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMacFilename, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMacroIcons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMacroIcons.ResumeLayout(False)
        CType(Me.navShapeLibrary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl1.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMacroDrawing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollDWG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents pnlMacroVars As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlMacroIcons As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picMacroDrawing As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'AddNavGroups()

        ' Add any initialization after the InitializeComponent() call.
        rbPropSettings = New RepositoryItemButtonEdit()
    End Sub
    Friend WithEvents navShapeLibrary As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MacVarLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents sbExecute As DevExpress.XtraEditors.SimpleButton
    Public WithEvents fcbMacroFilename As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents vgMacro As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents sbCompile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lblMacFilename As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents lstOptions As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents ImageCollDWG As DevExpress.Utils.ImageCollection
    Private WithEvents popupContainerEdit1 As PopupContainerEdit
    Private WithEvents tl As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents popupContainerControl1 As PopupContainerControl
    Private WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Private WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
