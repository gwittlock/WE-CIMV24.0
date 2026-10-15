<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeqMove
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeqMove))
        Me.pnlSeqMove = New DevExpress.XtraEditors.PanelControl()
        Me.SplitSeqMove = New DevExpress.XtraEditors.SplitContainerControl()
        Me.tl_SeqOrder = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TListWin1 = New BTIS.TList.TListWin()
        Me.pnlBeforeAfter = New DevExpress.XtraEditors.PanelControl()
        Me.grpcSeqMove = New DevExpress.XtraEditors.GroupControl()
        Me.cmdSeqMove = New DevExpress.XtraEditors.SimpleButton()
        Me.optSeqMove = New DevExpress.XtraEditors.RadioGroup()
        Me.SplitOptimize = New DevExpress.XtraEditors.SplitContainerControl()
        Me.pnlOptimize = New DevExpress.XtraEditors.PanelControl()
        Me.cmdDone = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOptimize = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.frmSeqMoveConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tvwPopUp = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuPopUpInsertBefore = New DevExpress.XtraBars.BarStaticItem()
        Me.mnuPopUpInsertAfter = New DevExpress.XtraBars.BarStaticItem()
        Me.mnuPopUpJumpTo = New DevExpress.XtraBars.BarStaticItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Image1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.mnuPopUp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuInstertBefore = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsertAfter = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJumpToInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbExplode = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.pnlSeqMove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSeqMove.SuspendLayout()
        CType(Me.SplitSeqMove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitSeqMove.SuspendLayout()
        CType(Me.tl_SeqOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBeforeAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBeforeAfter.SuspendLayout()
        CType(Me.grpcSeqMove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpcSeqMove.SuspendLayout()
        CType(Me.optSeqMove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitOptimize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitOptimize.SuspendLayout()
        CType(Me.pnlOptimize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOptimize.SuspendLayout()
        CType(Me.frmSeqMoveConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmSeqMoveConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvwPopUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPopUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSeqMove
        '
        Me.pnlSeqMove.Controls.Add(Me.SplitSeqMove)
        Me.pnlSeqMove.Location = New System.Drawing.Point(12, 12)
        Me.pnlSeqMove.Name = "pnlSeqMove"
        Me.pnlSeqMove.Size = New System.Drawing.Size(475, 284)
        Me.pnlSeqMove.TabIndex = 2
        '
        'SplitSeqMove
        '
        Me.SplitSeqMove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitSeqMove.Location = New System.Drawing.Point(2, 2)
        Me.SplitSeqMove.Name = "SplitSeqMove"
        Me.SplitSeqMove.Panel1.Controls.Add(Me.tl_SeqOrder)
        Me.SplitSeqMove.Panel1.Text = "Panel1"
        Me.SplitSeqMove.Panel2.Controls.Add(Me.TListWin1)
        Me.SplitSeqMove.Panel2.Text = "Panel2"
        Me.SplitSeqMove.Size = New System.Drawing.Size(471, 280)
        Me.SplitSeqMove.SplitterPosition = 199
        Me.SplitSeqMove.TabIndex = 0
        Me.SplitSeqMove.Text = "SplitSeqMove"
        '
        'tl_SeqOrder
        '
        Me.tl_SeqOrder.Appearance.BandPanel.Options.UseBackColor = True
        Me.tl_SeqOrder.Appearance.BandPanel.Options.UseForeColor = True
        Me.tl_SeqOrder.Appearance.Empty.BackColor = System.Drawing.Color.Black
        Me.tl_SeqOrder.Appearance.Empty.Options.UseBackColor = True
        Me.tl_SeqOrder.Appearance.Row.Options.UseBackColor = True
        Me.tl_SeqOrder.Appearance.Row.Options.UseForeColor = True
        Me.tl_SeqOrder.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.MainRoot})
        Me.tl_SeqOrder.Cursor = System.Windows.Forms.Cursors.Default
        Me.tl_SeqOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tl_SeqOrder.Location = New System.Drawing.Point(0, 0)
        Me.tl_SeqOrder.Name = "tl_SeqOrder"
        Me.tl_SeqOrder.OptionsBehavior.Editable = False
        Me.tl_SeqOrder.OptionsBehavior.SmartMouseHover = False
        Me.tl_SeqOrder.OptionsSelection.MultiSelect = True
        Me.tl_SeqOrder.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus
        Me.tl_SeqOrder.OptionsView.ShowIndicator = False
        Me.tl_SeqOrder.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.[Default]
        Me.tl_SeqOrder.Size = New System.Drawing.Size(199, 280)
        Me.tl_SeqOrder.TabIndex = 1
        '
        'MainRoot
        '
        Me.MainRoot.AllowIncrementalSearch = False
        Me.MainRoot.AppearanceCell.Options.UseBackColor = True
        Me.MainRoot.Caption = "Manual ToolPath Sequence"
        Me.MainRoot.FieldName = "Manual ToolPath Sequence"
        Me.MainRoot.Name = "MainRoot"
        Me.MainRoot.OptionsColumn.AllowEdit = False
        Me.MainRoot.OptionsColumn.AllowSort = False
        Me.MainRoot.OptionsColumn.ShowInCustomizationForm = False
        Me.MainRoot.OptionsColumn.ShowInExpressionEditor = False
        Me.MainRoot.OptionsFilter.AllowAutoFilter = False
        Me.MainRoot.OptionsFilter.AllowFilter = False
        Me.MainRoot.OptionsFilter.ShowEmptyDateFilter = False
        Me.MainRoot.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor
        Me.MainRoot.Visible = True
        Me.MainRoot.VisibleIndex = 0
        '
        'TListWin1
        '
        Me.TListWin1.BackColor = System.Drawing.Color.Black
        Me.TListWin1.Caption = Nothing
        Me.TListWin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TListWin1.ForeColor = System.Drawing.Color.White
        Me.TListWin1.ItemImageDefHeight = 15
        Me.TListWin1.ItemImageDefWidth = 15
        Me.TListWin1.Location = New System.Drawing.Point(0, 0)
        Me.TListWin1.MultiSelect = BTIS.TList.MultiSelect.Extended
        Me.TListWin1.Name = "TListWin1"
        Me.TListWin1.ShiftStep = 20
        Me.TListWin1.Size = New System.Drawing.Size(267, 280)
        Me.TListWin1.TabIndex = 4
        Me.TListWin1.Text = Nothing
        Me.TListWin1.ToolTipsBackColor = System.Drawing.Color.Gold
        Me.TListWin1.TreeLinesColor = System.Drawing.Color.White
        Me.TListWin1.TreeLinesHighlightColor = System.Drawing.Color.White
        Me.TListWin1.TreeLinesShadowColor = System.Drawing.Color.Yellow
        '
        'pnlBeforeAfter
        '
        Me.pnlBeforeAfter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBeforeAfter.Controls.Add(Me.grpcSeqMove)
        Me.pnlBeforeAfter.Location = New System.Drawing.Point(12, 300)
        Me.pnlBeforeAfter.Name = "pnlBeforeAfter"
        Me.pnlBeforeAfter.Size = New System.Drawing.Size(184, 121)
        Me.pnlBeforeAfter.TabIndex = 6
        '
        'grpcSeqMove
        '
        Me.grpcSeqMove.Controls.Add(Me.cmdSeqMove)
        Me.grpcSeqMove.Controls.Add(Me.optSeqMove)
        Me.grpcSeqMove.Location = New System.Drawing.Point(4, 4)
        Me.grpcSeqMove.MaximumSize = New System.Drawing.Size(160, 115)
        Me.grpcSeqMove.MinimumSize = New System.Drawing.Size(160, 115)
        Me.grpcSeqMove.Name = "grpcSeqMove"
        Me.grpcSeqMove.Size = New System.Drawing.Size(160, 115)
        Me.grpcSeqMove.TabIndex = 8
        Me.grpcSeqMove.Text = "Sequence Move"
        '
        'cmdSeqMove
        '
        Me.cmdSeqMove.Location = New System.Drawing.Point(11, 84)
        Me.cmdSeqMove.Name = "cmdSeqMove"
        Me.cmdSeqMove.Size = New System.Drawing.Size(138, 22)
        Me.cmdSeqMove.TabIndex = 10
        Me.cmdSeqMove.Text = "Move"
        '
        'optSeqMove
        '
        Me.optSeqMove.Location = New System.Drawing.Point(11, 23)
        Me.optSeqMove.Name = "optSeqMove"
        Me.optSeqMove.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Before Insert Position"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "After Insert Position")})
        Me.optSeqMove.Size = New System.Drawing.Size(138, 55)
        Me.optSeqMove.TabIndex = 5
        '
        'SplitOptimize
        '
        Me.SplitOptimize.Location = New System.Drawing.Point(200, 300)
        Me.SplitOptimize.Name = "SplitOptimize"
        Me.SplitOptimize.Panel1.Text = "Panel1"
        Me.SplitOptimize.Panel2.Controls.Add(Me.pnlOptimize)
        Me.SplitOptimize.Panel2.Text = "Panel2"
        Me.SplitOptimize.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
        Me.SplitOptimize.Size = New System.Drawing.Size(287, 121)
        Me.SplitOptimize.TabIndex = 8
        Me.SplitOptimize.Text = "SplitContainerControl1"
        '
        'pnlOptimize
        '
        Me.pnlOptimize.Controls.Add(Me.sbExplode)
        Me.pnlOptimize.Controls.Add(Me.cmdDone)
        Me.pnlOptimize.Controls.Add(Me.cmdOptimize)
        Me.pnlOptimize.Location = New System.Drawing.Point(18, 0)
        Me.pnlOptimize.MaximumSize = New System.Drawing.Size(400, 250)
        Me.pnlOptimize.MinimumSize = New System.Drawing.Size(101, 73)
        Me.pnlOptimize.Name = "pnlOptimize"
        Me.pnlOptimize.Size = New System.Drawing.Size(269, 118)
        Me.pnlOptimize.TabIndex = 4
        '
        'cmdDone
        '
        Me.cmdDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDone.Location = New System.Drawing.Point(151, 85)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(115, 25)
        Me.cmdDone.TabIndex = 1
        Me.cmdDone.Text = "Done"
        '
        'cmdOptimize
        '
        Me.cmdOptimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOptimize.Location = New System.Drawing.Point(3, 85)
        Me.cmdOptimize.Name = "cmdOptimize"
        Me.cmdOptimize.Size = New System.Drawing.Size(115, 25)
        Me.cmdOptimize.TabIndex = 0
        Me.cmdOptimize.Text = "Optimize"
        '
        'frmSeqMoveConvertedLayout
        '
        Me.frmSeqMoveConvertedLayout.Controls.Add(Me.SplitOptimize)
        Me.frmSeqMoveConvertedLayout.Controls.Add(Me.pnlBeforeAfter)
        Me.frmSeqMoveConvertedLayout.Controls.Add(Me.pnlSeqMove)
        Me.frmSeqMoveConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmSeqMoveConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmSeqMoveConvertedLayout.Name = "frmSeqMoveConvertedLayout"
        Me.frmSeqMoveConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmSeqMoveConvertedLayout.Size = New System.Drawing.Size(499, 433)
        Me.frmSeqMoveConvertedLayout.TabIndex = 9
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(499, 433)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SplitOptimize
        Me.LayoutControlItem1.CustomizationFormText = "SplitOptimizeitem"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(188, 288)
        Me.LayoutControlItem1.Name = "SplitOptimizeitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(291, 125)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.pnlBeforeAfter
        Me.LayoutControlItem2.CustomizationFormText = "pnlBeforeAfteritem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 288)
        Me.LayoutControlItem2.Name = "pnlBeforeAfteritem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(188, 125)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.pnlSeqMove
        Me.LayoutControlItem3.CustomizationFormText = "pnlSeqMoveitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "pnlSeqMoveitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(479, 288)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'tvwPopUp
        '
        Me.tvwPopUp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, Me.mnuPopUpInsertBefore, "", False, False, True, 0), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpInsertAfter), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpJumpTo)})
        Me.tvwPopUp.Manager = Me.BarManager1
        Me.tvwPopUp.Name = "tvwPopUp"
        '
        'mnuPopUpInsertBefore
        '
        Me.mnuPopUpInsertBefore.Caption = "Set Insert Position Before Entity"
        Me.mnuPopUpInsertBefore.Id = 0
        Me.mnuPopUpInsertBefore.Name = "mnuPopUpInsertBefore"
        '
        'mnuPopUpInsertAfter
        '
        Me.mnuPopUpInsertAfter.Caption = "Set Insert Position After Entity"
        Me.mnuPopUpInsertAfter.Id = 1
        Me.mnuPopUpInsertAfter.Name = "mnuPopUpInsertAfter"
        '
        'mnuPopUpJumpTo
        '
        Me.mnuPopUpJumpTo.Caption = "Jump To Insert Position"
        Me.mnuPopUpJumpTo.Id = 2
        Me.mnuPopUpJumpTo.Name = "mnuPopUpJumpTo"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.mnuPopUpInsertBefore, Me.mnuPopUpInsertAfter, Me.mnuPopUpJumpTo})
        Me.BarManager1.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(499, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 433)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(499, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 433)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(499, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 433)
        '
        'Image1
        '
        Me.Image1.ImageStream = CType(resources.GetObject("Image1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.Image1.Images.SetKeyName(0, "CHECKED")
        Me.Image1.Images.SetKeyName(1, "UNCHECKED")
        '
        'mnuPopUp
        '
        Me.mnuPopUp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInstertBefore, Me.mnuInsertAfter, Me.mnuJumpToInsert})
        Me.mnuPopUp.Name = "ContextMenuStrip1"
        Me.mnuPopUp.Size = New System.Drawing.Size(239, 70)
        '
        'mnuInstertBefore
        '
        Me.mnuInstertBefore.Name = "mnuInstertBefore"
        Me.mnuInstertBefore.Size = New System.Drawing.Size(238, 22)
        Me.mnuInstertBefore.Text = "Set Insert Position Before Entity"
        '
        'mnuInsertAfter
        '
        Me.mnuInsertAfter.Name = "mnuInsertAfter"
        Me.mnuInsertAfter.Size = New System.Drawing.Size(238, 22)
        Me.mnuInsertAfter.Text = "Set Insert Position After Entity"
        '
        'mnuJumpToInsert
        '
        Me.mnuJumpToInsert.Name = "mnuJumpToInsert"
        Me.mnuJumpToInsert.Size = New System.Drawing.Size(238, 22)
        Me.mnuJumpToInsert.Text = "Jump To Insert Position"
        '
        'sbExplode
        '
        Me.sbExplode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExplode.Location = New System.Drawing.Point(77, 14)
        Me.sbExplode.Name = "sbExplode"
        Me.sbExplode.Size = New System.Drawing.Size(115, 25)
        Me.sbExplode.TabIndex = 2
        Me.sbExplode.Text = "Explode Pattern"
        '
        'frmSeqMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 433)
        Me.Controls.Add(Me.frmSeqMoveConvertedLayout)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSeqMove"
        Me.Text = "Toolpath Sequence "
        CType(Me.pnlSeqMove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSeqMove.ResumeLayout(False)
        CType(Me.SplitSeqMove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitSeqMove.ResumeLayout(False)
        CType(Me.tl_SeqOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBeforeAfter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBeforeAfter.ResumeLayout(False)
        CType(Me.grpcSeqMove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpcSeqMove.ResumeLayout(False)
        CType(Me.optSeqMove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitOptimize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitOptimize.ResumeLayout(False)
        CType(Me.pnlOptimize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOptimize.ResumeLayout(False)
        CType(Me.frmSeqMoveConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmSeqMoveConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvwPopUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPopUp.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSeqMove As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SplitSeqMove As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents pnlBeforeAfter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents grpcSeqMove As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdSeqMove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents optSeqMove As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents SplitOptimize As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents pnlOptimize As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdDone As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOptimize As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents frmSeqMoveConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents tvwPopUp As DevExpress.XtraBars.PopupMenu
    Friend WithEvents mnuPopUpInsertBefore As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuPopUpInsertAfter As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents mnuPopUpJumpTo As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents Image1 As DevExpress.Utils.ImageCollection
    Friend WithEvents tl_SeqOrder As DevExpress.XtraTreeList.TreeList
    Friend WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TListWin1 As BTIS.TList.TListWin
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents mnuPopUp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuInstertBefore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInsertAfter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuJumpToInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sbExplode As SimpleButton
End Class
