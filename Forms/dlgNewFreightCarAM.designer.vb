<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgNewFreightCarAM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgNewFreightCarAM))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.FileMain = New DevExpress.XtraBars.Bar()
        Me.bsiFile = New DevExpress.XtraBars.BarSubItem()
        Me.bbNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbOpen = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bsiSaveAs = New DevExpress.XtraBars.BarSubItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.teScodeLabelSize = New DevExpress.XtraEditors.TextEdit()
        Me.lblScodeLabelSize = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.teProgression = New DevExpress.XtraEditors.TextEdit()
        Me.lcProgression = New DevExpress.XtraEditors.LabelControl()
        Me.sbMakeSame = New DevExpress.XtraEditors.SimpleButton()
        Me.sbReset = New DevExpress.XtraEditors.SimpleButton()
        Me.ugcGags = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl()
        Me.ugvGags = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView()
        Me.gcGags = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcY_loc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcPunchSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.sbRun = New DevExpress.XtraEditors.SimpleButton()
        Me.lblExportTo = New DevExpress.XtraEditors.LabelControl()
        Me.lblCodeGenerationFile = New DevExpress.XtraEditors.LabelControl()
        Me.beExportTo = New DevExpress.XtraEditors.ButtonEdit()
        Me.fcbScodeFile = New DevExpress.XtraEditors.ButtonEdit()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.ubgStations = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl()
        Me.ubgStationsView = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView()
        Me.colX_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colY_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGagNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.xgStations = New DevExpress.XtraGrid.GridControl()
        Me.ToolSetupView = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teScodeLabelSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.teProgression.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugcGags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugvGags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.beExportTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbScodeFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.ubgStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ubgStationsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.xgStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolSetupView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.FileMain})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bsiFile, Me.bsiSaveAs, Me.bbNew, Me.bbOpen, Me.bbClose, Me.bbiSave})
        Me.BarManager1.MaxItemId = 14
        '
        'FileMain
        '
        Me.FileMain.BarName = "Custom 2"
        Me.FileMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.FileMain.DockCol = 0
        Me.FileMain.DockRow = 0
        Me.FileMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.FileMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bsiFile, True)})
        Me.FileMain.OptionsBar.AllowQuickCustomization = False
        Me.FileMain.OptionsBar.DrawDragBorder = False
        Me.FileMain.OptionsBar.UseWholeRow = True
        Me.FileMain.Text = "Custom 2"
        '
        'bsiFile
        '
        Me.bsiFile.Caption = "&File"
        Me.bsiFile.Id = 1
        Me.bsiFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbNew, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbOpen), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiSave), New DevExpress.XtraBars.LinkPersistInfo(Me.bsiSaveAs), New DevExpress.XtraBars.LinkPersistInfo(Me.bbClose, True)})
        Me.bsiFile.Name = "bsiFile"
        '
        'bbNew
        '
        Me.bbNew.Caption = "&New"
        Me.bbNew.Description = "Create New Nesting Database"
        Me.bbNew.Hint = "Create New Nesting Database"
        Me.bbNew.Id = 6
        Me.bbNew.ImageOptions.ImageIndex = 6
        Me.bbNew.Name = "bbNew"
        '
        'bbOpen
        '
        Me.bbOpen.Caption = "&Open"
        Me.bbOpen.Description = "Open Existing Nesting Database"
        Me.bbOpen.Hint = "Open Existing Nesting Database"
        Me.bbOpen.Id = 7
        Me.bbOpen.ImageOptions.ImageIndex = 7
        Me.bbOpen.Name = "bbOpen"
        '
        'bbiSave
        '
        Me.bbiSave.Caption = "Save"
        Me.bbiSave.Id = 13
        Me.bbiSave.Name = "bbiSave"
        '
        'bsiSaveAs
        '
        Me.bsiSaveAs.Caption = "Save As.."
        Me.bsiSaveAs.Id = 2
        Me.bsiSaveAs.Name = "bsiSaveAs"
        '
        'bbClose
        '
        Me.bbClose.Caption = "&Close"
        Me.bbClose.Description = "Close Nesting Database"
        Me.bbClose.Hint = "Close Nesting Database"
        Me.bbClose.Id = 11
        Me.bbClose.ImageOptions.ImageIndex = 27
        Me.bbClose.Name = "bbClose"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(917, 29)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 674)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(917, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 29)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 645)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(917, 29)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 645)
        '
        'Bar1
        '
        Me.Bar1.BarName = "Main menu"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bsiFile)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.MultiLine = True
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Main menu"
        '
        'teScodeLabelSize
        '
        Me.teScodeLabelSize.EditValue = "12"
        Me.teScodeLabelSize.Location = New System.Drawing.Point(104, 36)
        Me.teScodeLabelSize.Name = "teScodeLabelSize"
        Me.teScodeLabelSize.Size = New System.Drawing.Size(100, 20)
        Me.teScodeLabelSize.TabIndex = 13
        '
        'lblScodeLabelSize
        '
        Me.lblScodeLabelSize.Location = New System.Drawing.Point(9, 39)
        Me.lblScodeLabelSize.Name = "lblScodeLabelSize"
        Me.lblScodeLabelSize.Size = New System.Drawing.Size(89, 13)
        Me.lblScodeLabelSize.TabIndex = 12
        Me.lblScodeLabelSize.Text = "S-Code Label Size:"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl3)
        Me.PanelControl1.Controls.Add(Me.ugcGags)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 29)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(335, 645)
        Me.PanelControl1.TabIndex = 15
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.teScodeLabelSize)
        Me.PanelControl3.Controls.Add(Me.lblScodeLabelSize)
        Me.PanelControl3.Controls.Add(Me.teProgression)
        Me.PanelControl3.Controls.Add(Me.lcProgression)
        Me.PanelControl3.Controls.Add(Me.sbMakeSame)
        Me.PanelControl3.Controls.Add(Me.sbReset)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(331, 100)
        Me.PanelControl3.TabIndex = 6
        '
        'teProgression
        '
        Me.teProgression.Location = New System.Drawing.Point(104, 10)
        Me.teProgression.Name = "teProgression"
        Me.teProgression.Size = New System.Drawing.Size(100, 20)
        Me.teProgression.TabIndex = 8
        '
        'lcProgression
        '
        Me.lcProgression.Location = New System.Drawing.Point(38, 13)
        Me.lcProgression.Name = "lcProgression"
        Me.lcProgression.Size = New System.Drawing.Size(60, 13)
        Me.lcProgression.TabIndex = 7
        Me.lcProgression.Text = "Progression:"
        '
        'sbMakeSame
        '
        Me.sbMakeSame.AutoSize = True
        Me.sbMakeSame.Location = New System.Drawing.Point(13, 62)
        Me.sbMakeSame.Name = "sbMakeSame"
        Me.sbMakeSame.Size = New System.Drawing.Size(138, 22)
        Me.sbMakeSame.TabIndex = 5
        Me.sbMakeSame.Text = "Make Punch Size The Same"
        '
        'sbReset
        '
        Me.sbReset.AutoSize = True
        Me.sbReset.Location = New System.Drawing.Point(194, 62)
        Me.sbReset.Name = "sbReset"
        Me.sbReset.Size = New System.Drawing.Size(110, 22)
        Me.sbReset.TabIndex = 6
        Me.sbReset.Text = "Reset All Punch Sizes"
        '
        'ugcGags
        '
        Me.ugcGags.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ugcGags.Location = New System.Drawing.Point(2, 104)
        Me.ugcGags.MainView = Me.ugvGags
        Me.ugcGags.Name = "ugcGags"
        Me.ugcGags.Size = New System.Drawing.Size(331, 539)
        Me.ugcGags.TabIndex = 5
        Me.ugcGags.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ugvGags})
        '
        'ugvGags
        '
        Me.ugvGags.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.ugvGags.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcGags, Me.gcY_loc, Me.gcPunchSize})
        Me.ugvGags.GridControl = Me.ugcGags
        Me.ugvGags.Name = "ugvGags"
        Me.ugvGags.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ugvGags.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ugvGags.OptionsView.ShowDetailButtons = False
        Me.ugvGags.OptionsView.ShowGroupPanel = False
        Me.ugvGags.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[True]
        Me.ugvGags.OptionsView.ShowIndicator = False
        '
        'gcGags
        '
        Me.gcGags.Caption = "Gag #"
        Me.gcGags.FieldName = "gcGags"
        Me.gcGags.Name = "gcGags"
        Me.gcGags.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.gcGags.Visible = True
        Me.gcGags.VisibleIndex = 0
        '
        'gcY_loc
        '
        Me.gcY_loc.Caption = "Y Location"
        Me.gcY_loc.FieldName = "gcY_loc"
        Me.gcY_loc.Name = "gcY_loc"
        Me.gcY_loc.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.gcY_loc.Visible = True
        Me.gcY_loc.VisibleIndex = 1
        '
        'gcPunchSize
        '
        Me.gcPunchSize.Caption = "Punch Size"
        Me.gcPunchSize.FieldName = "GridColumn1"
        Me.gcPunchSize.Name = "gcPunchSize"
        Me.gcPunchSize.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.gcPunchSize.Visible = True
        Me.gcPunchSize.VisibleIndex = 2
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.sbRun)
        Me.PanelControl5.Controls.Add(Me.lblExportTo)
        Me.PanelControl5.Controls.Add(Me.lblCodeGenerationFile)
        Me.PanelControl5.Controls.Add(Me.beExportTo)
        Me.PanelControl5.Controls.Add(Me.fcbScodeFile)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl5.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(578, 100)
        Me.PanelControl5.TabIndex = 0
        '
        'sbRun
        '
        Me.sbRun.Location = New System.Drawing.Point(423, 20)
        Me.sbRun.Name = "sbRun"
        Me.sbRun.Size = New System.Drawing.Size(112, 64)
        Me.sbRun.TabIndex = 19
        Me.sbRun.Text = "Run"
        '
        'lblExportTo
        '
        Me.lblExportTo.Location = New System.Drawing.Point(4, 49)
        Me.lblExportTo.Name = "lblExportTo"
        Me.lblExportTo.Size = New System.Drawing.Size(51, 13)
        Me.lblExportTo.TabIndex = 23
        Me.lblExportTo.Text = "Export To:"
        '
        'lblCodeGenerationFile
        '
        Me.lblCodeGenerationFile.Location = New System.Drawing.Point(4, 4)
        Me.lblCodeGenerationFile.Name = "lblCodeGenerationFile"
        Me.lblCodeGenerationFile.Size = New System.Drawing.Size(100, 13)
        Me.lblCodeGenerationFile.TabIndex = 22
        Me.lblCodeGenerationFile.Text = "Code Generation File"
        '
        'beExportTo
        '
        Me.beExportTo.Location = New System.Drawing.Point(4, 64)
        Me.beExportTo.Name = "beExportTo"
        Me.beExportTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beExportTo.Size = New System.Drawing.Size(372, 20)
        Me.beExportTo.TabIndex = 21
        '
        'fcbScodeFile
        '
        Me.fcbScodeFile.Location = New System.Drawing.Point(4, 23)
        Me.fcbScodeFile.Name = "fcbScodeFile"
        Me.fcbScodeFile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbScodeFile.Size = New System.Drawing.Size(372, 20)
        Me.fcbScodeFile.TabIndex = 20
        '
        'PanelControl6
        '
        Me.PanelControl6.Controls.Add(Me.xgStations)
        Me.PanelControl6.Controls.Add(Me.ubgStations)
        Me.PanelControl6.Controls.Add(Me.ListBox3)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl6.Location = New System.Drawing.Point(2, 102)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(571, 541)
        Me.PanelControl6.TabIndex = 1
        '
        'ubgStations
        '
        Me.ubgStations.Cursor = System.Windows.Forms.Cursors.Default
        Me.ubgStations.Location = New System.Drawing.Point(23, 123)
        Me.ubgStations.MainView = Me.ubgStationsView
        Me.ubgStations.Name = "ubgStations"
        Me.ubgStations.Size = New System.Drawing.Size(337, 210)
        Me.ubgStations.TabIndex = 17
        Me.ubgStations.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ubgStationsView})
        '
        'ubgStationsView
        '
        Me.ubgStationsView.ActiveFilterEnabled = False
        Me.ubgStationsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colX_Value, Me.colY_Value, Me.colGagNumber})
        Me.ubgStationsView.GridControl = Me.ubgStations
        Me.ubgStationsView.Name = "ubgStationsView"
        Me.ubgStationsView.OptionsCustomization.AllowColumnMoving = False
        Me.ubgStationsView.OptionsCustomization.AllowFilter = False
        Me.ubgStationsView.OptionsCustomization.AllowGroup = False
        Me.ubgStationsView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ubgStationsView.OptionsCustomization.AllowSort = False
        Me.ubgStationsView.OptionsDetail.ShowDetailTabs = False
        Me.ubgStationsView.OptionsNavigation.EnterMoveNextColumn = True
        Me.ubgStationsView.OptionsView.EnableAppearanceEvenRow = True
        Me.ubgStationsView.OptionsView.ShowDetailButtons = False
        Me.ubgStationsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ubgStationsView.OptionsView.ShowGroupPanel = False
        Me.ubgStationsView.OptionsView.ShowIndicator = False
        '
        'colX_Value
        '
        Me.colX_Value.Caption = "X_Value"
        Me.colX_Value.DisplayFormat.FormatString = "###.###"
        Me.colX_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colX_Value.FieldName = "X_Value"
        Me.colX_Value.Name = "colX_Value"
        Me.colX_Value.Visible = True
        Me.colX_Value.VisibleIndex = 0
        '
        'colY_Value
        '
        Me.colY_Value.Caption = "Y_Value"
        Me.colY_Value.DisplayFormat.FormatString = "###.###"
        Me.colY_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colY_Value.FieldName = "YLoc"
        Me.colY_Value.Name = "colY_Value"
        Me.colY_Value.Visible = True
        Me.colY_Value.VisibleIndex = 1
        '
        'colGagNumber
        '
        Me.colGagNumber.Caption = "GAGNumber"
        Me.colGagNumber.DisplayFormat.FormatString = "###.###"
        Me.colGagNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colGagNumber.FieldName = "GagNumber"
        Me.colGagNumber.Name = "colGagNumber"
        Me.colGagNumber.Visible = True
        Me.colGagNumber.VisibleIndex = 2
        '
        'ListBox3
        '
        Me.ListBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(366, 2)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(203, 537)
        Me.ListBox3.TabIndex = 16
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.PanelControl6)
        Me.PanelControl4.Controls.Add(Me.PanelControl5)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl4.Location = New System.Drawing.Point(335, 29)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(582, 645)
        Me.PanelControl4.TabIndex = 16
        '
        'xgStations
        '
        Me.xgStations.AllowDrop = True
        Me.xgStations.Cursor = System.Windows.Forms.Cursors.Default
        Me.xgStations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xgStations.Location = New System.Drawing.Point(2, 2)
        Me.xgStations.MainView = Me.ToolSetupView
        Me.xgStations.Name = "xgStations"
        Me.xgStations.Size = New System.Drawing.Size(364, 537)
        Me.xgStations.TabIndex = 18
        Me.xgStations.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ToolSetupView})
        '
        'ToolSetupView
        '
        Me.ToolSetupView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ToolSetupView.GridControl = Me.xgStations
        Me.ToolSetupView.Name = "ToolSetupView"
        Me.ToolSetupView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToolSetupView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToolSetupView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToolSetupView.OptionsCustomization.AllowColumnMoving = False
        Me.ToolSetupView.OptionsCustomization.AllowFilter = False
        Me.ToolSetupView.OptionsCustomization.AllowGroup = False
        Me.ToolSetupView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ToolSetupView.OptionsCustomization.AllowSort = False
        Me.ToolSetupView.OptionsMenu.EnableColumnMenu = False
        Me.ToolSetupView.OptionsMenu.EnableFooterMenu = False
        Me.ToolSetupView.OptionsMenu.EnableGroupPanelMenu = False
        Me.ToolSetupView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.ToolSetupView.OptionsSelection.UseIndicatorForSelection = False
        Me.ToolSetupView.OptionsView.AllowHtmlDrawGroups = False
        Me.ToolSetupView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.ToolSetupView.OptionsView.ShowDetailButtons = False
        Me.ToolSetupView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ToolSetupView.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.ToolSetupView.OptionsView.ShowGroupPanel = False
        Me.ToolSetupView.OptionsView.ShowViewCaption = True
        Me.ToolSetupView.ViewCaption = "Gag Hits"
        '
        'dlgNewFreightCarAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 674)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgNewFreightCarAM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dlgNewFreightCarAM"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teScodeLabelSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.teProgression.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugcGags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugvGags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.beExportTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbScodeFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        CType(Me.ubgStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ubgStationsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.xgStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolSetupView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents bsiFile As DevExpress.XtraBars.BarSubItem
    Friend WithEvents bbNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbOpen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bsiSaveAs As DevExpress.XtraBars.BarSubItem
    Friend WithEvents teScodeLabelSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblScodeLabelSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ugcGags As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl
    Friend WithEvents ugvGags As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView
    Friend WithEvents gcGags As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcY_loc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcPunchSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents sbRun As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblExportTo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCodeGenerationFile As DevExpress.XtraEditors.LabelControl
    Public WithEvents beExportTo As DevExpress.XtraEditors.ButtonEdit
    Public WithEvents fcbScodeFile As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents ubgStations As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl
    Friend WithEvents ubgStationsView As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents bbiSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileMain As DevExpress.XtraBars.Bar
    Friend WithEvents colX_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colY_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGagNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents teProgression As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcProgression As DevExpress.XtraEditors.LabelControl
    Friend WithEvents sbMakeSame As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbReset As DevExpress.XtraEditors.SimpleButton
    Private WithEvents xgStations As DevExpress.XtraGrid.GridControl
    Private WithEvents ToolSetupView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
