<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCfgMan3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCfgMan3))
        Me.sccCfgMan = New DevExpress.XtraEditors.SplitContainerControl()
        Me.TV_Config = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.pnlLeadSetupInfo = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.cboLeadExtArcOut = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadExtArcOut = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadExtArcIn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadExtArcIn = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadExtLineOut = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadExtLineOut = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadExtLineIn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadExtLineIn = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadIntArcOut = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadIntArcOut = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadIntArcIn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadIntArcIn = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadIntLineOut = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadIntLineOut = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadIntLineIn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadIntLineIn = New DevExpress.XtraEditors.LabelControl()
        Me.pnlLeadParameters = New System.Windows.Forms.GroupBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRadius = New DevExpress.XtraEditors.TextEdit()
        Me.CFG_Man_BarMan = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.bbAddMaterial = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRemoveMaterialType = New DevExpress.XtraBars.BarButtonItem()
        Me.bbADD_MACHINE = New DevExpress.XtraBars.BarButtonItem()
        Me.MachineRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.MachineCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.MachineRename = New DevExpress.XtraBars.BarButtonItem()
        Me.StationsAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.StationsRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.ToolSetupAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.ToolSetupRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.ToolSetupCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.ToolSetupRename = New DevExpress.XtraBars.BarButtonItem()
        Me.LayerSetupAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.LayerAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.LayerRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.LayerAnalyze = New DevExpress.XtraBars.BarButtonItem()
        Me.LayerNameRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.AddMaterialType = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSpecificMaterialRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbLeadParamAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.bbLeadParamRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbLeadSetupAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.LeadSetupRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.txtLeadIncludedAngle = New DevExpress.XtraEditors.TextEdit()
        Me.txtLeadDistance = New DevExpress.XtraEditors.TextEdit()
        Me.txtLeadAngle = New DevExpress.XtraEditors.TextEdit()
        Me.txtLeadLength = New DevExpress.XtraEditors.TextEdit()
        Me.cboLeadJunction = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboLeadType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboSplitLocation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboLeadLocation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblRadius = New DevExpress.XtraEditors.LabelControl()
        Me.lblLeadIncludedAngle = New DevExpress.XtraEditors.LabelControl()
        Me.lblLeadDistance = New DevExpress.XtraEditors.LabelControl()
        Me.lblLeadAngle = New DevExpress.XtraEditors.LabelControl()
        Me.lblLeadLength = New DevExpress.XtraEditors.LabelControl()
        Me.lblJunction = New DevExpress.XtraEditors.LabelControl()
        Me.lblLeadType = New DevExpress.XtraEditors.LabelControl()
        Me.lblSplitLocation = New DevExpress.XtraEditors.LabelControl()
        Me.lblLeadLocation = New DevExpress.XtraEditors.LabelControl()
        Me.cbfLeadParam = New FabV24_WIN8.WindowsApplication234.ChkBoxFrame()
        Me.txtLeadToolDia = New DevExpress.XtraEditors.TextEdit()
        Me.lblLeadToolDia = New DevExpress.XtraEditors.LabelControl()
        Me.cboLeadToolType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLeadToolType = New DevExpress.XtraEditors.LabelControl()
        Me.txtPierceDistance = New DevExpress.XtraEditors.TextEdit()
        Me.lblPierceDistance = New DevExpress.XtraEditors.LabelControl()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.pnlAnalyze = New System.Windows.Forms.GroupBox()
        Me.cmdLayerSetupAnalyzeOk = New DevExpress.XtraEditors.SimpleButton()
        Me.vgLayerAnalyze = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.dsAnalyzeLayer = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.pnlMaterialInfo = New System.Windows.Forms.GroupBox()
        Me.vgMaterialInfo = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.catMaterialInfo = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.pnlToolSetups = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.xgStations = New DevExpress.XtraGrid.GridControl()
        Me.ToolSetupView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlToolingParameters = New System.Windows.Forms.GroupBox()
        Me.vgToolParameters = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.ToolParams = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.tbToolCribParamValues = New System.Windows.Forms.TextBox()
        Me.tbToolCribParamFields = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdMoveToolUp = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMoveToolDown = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRemoveTool = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.pnlAvailableTooling = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboToolSetupAvailTools = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lstToolSetupAvailTools = New DevExpress.XtraEditors.ListBoxControl()
        Me.fraToolCrib = New System.Windows.Forms.GroupBox()
        Me.cmdToolCribRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdToolCribEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdToolCribAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlMachSettings = New System.Windows.Forms.GroupBox()
        Me.Form1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.pnlCtgs = New System.Windows.Forms.Panel()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.beCodeGen = New DevExpress.XtraEditors.ButtonEdit()
        Me.beCNC_Path = New DevExpress.XtraEditors.ButtonEdit()
        Me.pnlMachineSettings = New System.Windows.Forms.Panel()
        Me.vgMachSettings = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.MachSettings = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.pnlStations = New System.Windows.Forms.GroupBox()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ubgStations = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl()
        Me.ubgStationsView = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView()
        Me.sbRemoveStation = New DevExpress.XtraEditors.SimpleButton()
        Me.sbAddStation = New DevExpress.XtraEditors.SimpleButton()
        Me.cbfAutoFillStations = New FabV24_WIN8.WindowsApplication234.ChkBoxFrame()
        Me.lbtAutoFill = New FabV24_WIN8.lblTextBox()
        Me.pnlLayerGlobal = New System.Windows.Forms.GroupBox()
        Me.vgGlobalLayerInfo = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.catGlobalLayerInfo = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.pnlPreamble = New System.Windows.Forms.GroupBox()
        Me.memoInfo = New DevExpress.XtraEditors.MemoEdit()
        Me.pnlLayerSetup = New System.Windows.Forms.GroupBox()
        Me.cbLayerTools = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.vgLayerInfo = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.catLayerInformation = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.PopUp_TV_Config = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.barButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.sbHtmlAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.sccCfgMan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sccCfgMan.SuspendLayout()
        CType(Me.TV_Config, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeadSetupInfo.SuspendLayout()
        CType(Me.cboLeadExtArcOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadExtArcIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadExtLineOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadExtLineIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadIntArcOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadIntArcIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadIntLineOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadIntLineIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeadParameters.SuspendLayout()
        CType(Me.txtRadius.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFG_Man_BarMan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeadIncludedAngle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeadDistance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeadAngle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeadLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadJunction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSplitLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbfLeadParam.SuspendLayout()
        CType(Me.txtLeadToolDia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadToolType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPierceDistance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAnalyze.SuspendLayout()
        CType(Me.vgLayerAnalyze, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMaterialInfo.SuspendLayout()
        CType(Me.vgMaterialInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlToolSetups.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.xgStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolSetupView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlToolingParameters.SuspendLayout()
        CType(Me.vgToolParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.pnlAvailableTooling.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cboToolSetupAvailTools.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstToolSetupAvailTools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraToolCrib.SuspendLayout()
        Me.pnlMachSettings.SuspendLayout()
        CType(Me.Form1ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Form1ConvertedLayout.SuspendLayout()
        Me.pnlCtgs.SuspendLayout()
        CType(Me.beCodeGen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCNC_Path.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMachineSettings.SuspendLayout()
        CType(Me.vgMachSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStations.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ubgStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ubgStationsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbfAutoFillStations.SuspendLayout()
        Me.pnlLayerGlobal.SuspendLayout()
        CType(Me.vgGlobalLayerInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreamble.SuspendLayout()
        CType(Me.memoInfo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLayerSetup.SuspendLayout()
        CType(Me.cbLayerTools.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgLayerInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopUp_TV_Config, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sccCfgMan
        '
        Me.sccCfgMan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sccCfgMan.Location = New System.Drawing.Point(0, 0)
        Me.sccCfgMan.Name = "sccCfgMan"
        Me.sccCfgMan.Panel1.Controls.Add(Me.TV_Config)
        Me.sccCfgMan.Panel1.Text = "Panel1"
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlLeadSetupInfo)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlLeadParameters)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlAnalyze)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlMaterialInfo)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlToolSetups)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlMachSettings)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlStations)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlLayerGlobal)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlPreamble)
        Me.sccCfgMan.Panel2.Controls.Add(Me.pnlLayerSetup)
        Me.sccCfgMan.Panel2.Text = "Panel2"
        Me.sccCfgMan.Size = New System.Drawing.Size(997, 561)
        Me.sccCfgMan.SplitterPosition = 197
        Me.sccCfgMan.TabIndex = 6
        Me.sccCfgMan.Text = "SplitContainerControl1"
        '
        'TV_Config
        '
        Me.TV_Config.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.MainRoot})
        Me.TV_Config.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_Config.Location = New System.Drawing.Point(0, 0)
        Me.TV_Config.Name = "TV_Config"
        Me.TV_Config.OptionsBehavior.AutoChangeParent = False
        Me.TV_Config.OptionsBehavior.AutoNodeHeight = False
        Me.TV_Config.OptionsBehavior.AutoSelectAllInEditor = False
        Me.TV_Config.OptionsBehavior.CloseEditorOnLostFocus = False
        Me.TV_Config.OptionsBehavior.Editable = False
        Me.TV_Config.OptionsBehavior.ResizeNodes = False
        Me.TV_Config.OptionsBehavior.SmartMouseHover = False
        Me.TV_Config.OptionsMenu.EnableFooterMenu = False
        Me.TV_Config.OptionsPrint.PrintHorzLines = False
        Me.TV_Config.OptionsPrint.PrintVertLines = False
        Me.TV_Config.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.TV_Config.OptionsSelection.KeepSelectedOnClick = False
        Me.TV_Config.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None
        Me.TV_Config.OptionsView.ShowHorzLines = False
        Me.TV_Config.OptionsView.ShowIndicator = False
        Me.TV_Config.OptionsView.ShowVertLines = False
        Me.TV_Config.Size = New System.Drawing.Size(197, 561)
        Me.TV_Config.TabIndex = 6
        '
        'MainRoot
        '
        Me.MainRoot.AllNodesSummary = True
        Me.MainRoot.Caption = "Configuratin Data"
        Me.MainRoot.FieldName = "Key"
        Me.MainRoot.MinWidth = 33
        Me.MainRoot.Name = "MainRoot"
        Me.MainRoot.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count
        Me.MainRoot.SummaryFooterStrFormat = "Count keys = {0}"
        Me.MainRoot.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.MainRoot.Visible = True
        Me.MainRoot.VisibleIndex = 0
        Me.MainRoot.Width = 235
        '
        'pnlLeadSetupInfo
        '
        Me.pnlLeadSetupInfo.Controls.Add(Me.ListBox1)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadExtArcOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadExtArcOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadExtArcIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadExtArcIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadExtLineOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadExtLineOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadExtLineIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadExtLineIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadIntArcOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadIntArcOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadIntArcIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadIntArcIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadIntLineOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadIntLineOut)
        Me.pnlLeadSetupInfo.Controls.Add(Me.cboLeadIntLineIn)
        Me.pnlLeadSetupInfo.Controls.Add(Me.lblLeadIntLineIn)
        Me.pnlLeadSetupInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeadSetupInfo.Name = "pnlLeadSetupInfo"
        Me.pnlLeadSetupInfo.Size = New System.Drawing.Size(421, 482)
        Me.pnlLeadSetupInfo.TabIndex = 29
        Me.pnlLeadSetupInfo.TabStop = False
        Me.pnlLeadSetupInfo.Text = "Lead Setup Information"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 382)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 13
        Me.ListBox1.Visible = False
        '
        'cboLeadExtArcOut
        '
        Me.cboLeadExtArcOut.Location = New System.Drawing.Point(127, 227)
        Me.cboLeadExtArcOut.Name = "cboLeadExtArcOut"
        Me.cboLeadExtArcOut.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadExtArcOut.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadExtArcOut.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadExtArcOut.TabIndex = 35
        '
        'lblLeadExtArcOut
        '
        Me.lblLeadExtArcOut.Location = New System.Drawing.Point(15, 230)
        Me.lblLeadExtArcOut.Name = "lblLeadExtArcOut"
        Me.lblLeadExtArcOut.Size = New System.Drawing.Size(106, 13)
        Me.lblLeadExtArcOut.TabIndex = 34
        Me.lblLeadExtArcOut.Text = "Arc External Lead Out"
        '
        'cboLeadExtArcIn
        '
        Me.cboLeadExtArcIn.Location = New System.Drawing.Point(127, 201)
        Me.cboLeadExtArcIn.Name = "cboLeadExtArcIn"
        Me.cboLeadExtArcIn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadExtArcIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadExtArcIn.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadExtArcIn.TabIndex = 33
        '
        'lblLeadExtArcIn
        '
        Me.lblLeadExtArcIn.Location = New System.Drawing.Point(23, 204)
        Me.lblLeadExtArcIn.Name = "lblLeadExtArcIn"
        Me.lblLeadExtArcIn.Size = New System.Drawing.Size(98, 13)
        Me.lblLeadExtArcIn.TabIndex = 32
        Me.lblLeadExtArcIn.Text = "Arc External Lead In"
        '
        'cboLeadExtLineOut
        '
        Me.cboLeadExtLineOut.Location = New System.Drawing.Point(127, 175)
        Me.cboLeadExtLineOut.Name = "cboLeadExtLineOut"
        Me.cboLeadExtLineOut.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadExtLineOut.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadExtLineOut.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadExtLineOut.TabIndex = 31
        '
        'lblLeadExtLineOut
        '
        Me.lblLeadExtLineOut.Location = New System.Drawing.Point(12, 178)
        Me.lblLeadExtLineOut.Name = "lblLeadExtLineOut"
        Me.lblLeadExtLineOut.Size = New System.Drawing.Size(109, 13)
        Me.lblLeadExtLineOut.TabIndex = 30
        Me.lblLeadExtLineOut.Text = "Line External Lead Out"
        '
        'cboLeadExtLineIn
        '
        Me.cboLeadExtLineIn.Location = New System.Drawing.Point(127, 149)
        Me.cboLeadExtLineIn.Name = "cboLeadExtLineIn"
        Me.cboLeadExtLineIn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadExtLineIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadExtLineIn.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadExtLineIn.TabIndex = 29
        '
        'lblLeadExtLineIn
        '
        Me.lblLeadExtLineIn.Location = New System.Drawing.Point(20, 152)
        Me.lblLeadExtLineIn.Name = "lblLeadExtLineIn"
        Me.lblLeadExtLineIn.Size = New System.Drawing.Size(101, 13)
        Me.lblLeadExtLineIn.TabIndex = 28
        Me.lblLeadExtLineIn.Text = "Line External Lead In"
        '
        'cboLeadIntArcOut
        '
        Me.cboLeadIntArcOut.Location = New System.Drawing.Point(127, 123)
        Me.cboLeadIntArcOut.Name = "cboLeadIntArcOut"
        Me.cboLeadIntArcOut.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadIntArcOut.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadIntArcOut.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadIntArcOut.TabIndex = 27
        '
        'lblLeadIntArcOut
        '
        Me.lblLeadIntArcOut.Location = New System.Drawing.Point(17, 126)
        Me.lblLeadIntArcOut.Name = "lblLeadIntArcOut"
        Me.lblLeadIntArcOut.Size = New System.Drawing.Size(104, 13)
        Me.lblLeadIntArcOut.TabIndex = 26
        Me.lblLeadIntArcOut.Text = "Arc Internal Lead Out"
        '
        'cboLeadIntArcIn
        '
        Me.cboLeadIntArcIn.Location = New System.Drawing.Point(127, 97)
        Me.cboLeadIntArcIn.Name = "cboLeadIntArcIn"
        Me.cboLeadIntArcIn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadIntArcIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadIntArcIn.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadIntArcIn.TabIndex = 25
        '
        'lblLeadIntArcIn
        '
        Me.lblLeadIntArcIn.Location = New System.Drawing.Point(25, 100)
        Me.lblLeadIntArcIn.Name = "lblLeadIntArcIn"
        Me.lblLeadIntArcIn.Size = New System.Drawing.Size(96, 13)
        Me.lblLeadIntArcIn.TabIndex = 24
        Me.lblLeadIntArcIn.Text = "Arc Internal Lead In"
        '
        'cboLeadIntLineOut
        '
        Me.cboLeadIntLineOut.Location = New System.Drawing.Point(127, 71)
        Me.cboLeadIntLineOut.Name = "cboLeadIntLineOut"
        Me.cboLeadIntLineOut.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadIntLineOut.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadIntLineOut.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadIntLineOut.TabIndex = 23
        '
        'lblLeadIntLineOut
        '
        Me.lblLeadIntLineOut.Location = New System.Drawing.Point(14, 74)
        Me.lblLeadIntLineOut.Name = "lblLeadIntLineOut"
        Me.lblLeadIntLineOut.Size = New System.Drawing.Size(107, 13)
        Me.lblLeadIntLineOut.TabIndex = 22
        Me.lblLeadIntLineOut.Text = "Line Internal Lead Out"
        '
        'cboLeadIntLineIn
        '
        Me.cboLeadIntLineIn.Location = New System.Drawing.Point(127, 45)
        Me.cboLeadIntLineIn.Name = "cboLeadIntLineIn"
        Me.cboLeadIntLineIn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadIntLineIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadIntLineIn.Size = New System.Drawing.Size(277, 20)
        Me.cboLeadIntLineIn.TabIndex = 21
        '
        'lblLeadIntLineIn
        '
        Me.lblLeadIntLineIn.Location = New System.Drawing.Point(22, 48)
        Me.lblLeadIntLineIn.Name = "lblLeadIntLineIn"
        Me.lblLeadIntLineIn.Size = New System.Drawing.Size(99, 13)
        Me.lblLeadIntLineIn.TabIndex = 20
        Me.lblLeadIntLineIn.Text = "Line Internal Lead In"
        '
        'pnlLeadParameters
        '
        Me.pnlLeadParameters.Controls.Add(Me.LabelControl1)
        Me.pnlLeadParameters.Controls.Add(Me.txtRadius)
        Me.pnlLeadParameters.Controls.Add(Me.txtLeadIncludedAngle)
        Me.pnlLeadParameters.Controls.Add(Me.txtLeadDistance)
        Me.pnlLeadParameters.Controls.Add(Me.txtLeadAngle)
        Me.pnlLeadParameters.Controls.Add(Me.txtLeadLength)
        Me.pnlLeadParameters.Controls.Add(Me.cboLeadJunction)
        Me.pnlLeadParameters.Controls.Add(Me.cboLeadType)
        Me.pnlLeadParameters.Controls.Add(Me.cboSplitLocation)
        Me.pnlLeadParameters.Controls.Add(Me.cboLeadLocation)
        Me.pnlLeadParameters.Controls.Add(Me.lblRadius)
        Me.pnlLeadParameters.Controls.Add(Me.lblLeadIncludedAngle)
        Me.pnlLeadParameters.Controls.Add(Me.lblLeadDistance)
        Me.pnlLeadParameters.Controls.Add(Me.lblLeadAngle)
        Me.pnlLeadParameters.Controls.Add(Me.lblLeadLength)
        Me.pnlLeadParameters.Controls.Add(Me.lblJunction)
        Me.pnlLeadParameters.Controls.Add(Me.lblLeadType)
        Me.pnlLeadParameters.Controls.Add(Me.lblSplitLocation)
        Me.pnlLeadParameters.Controls.Add(Me.lblLeadLocation)
        Me.pnlLeadParameters.Controls.Add(Me.cbfLeadParam)
        Me.pnlLeadParameters.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeadParameters.Name = "pnlLeadParameters"
        Me.pnlLeadParameters.Size = New System.Drawing.Size(406, 489)
        Me.pnlLeadParameters.TabIndex = 28
        Me.pnlLeadParameters.TabStop = False
        Me.pnlLeadParameters.Text = "Lead Parameters"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.Red
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.LabelControl1.Appearance.Options.UseBackColor = True
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 286)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(314, 13)
        Me.LabelControl1.TabIndex = 28
        Me.LabelControl1.Text = "INCLUDE PIERCE IS ONLY USED FOR PUNCHES AND DRILLS"
        '
        'txtRadius
        '
        Me.txtRadius.Location = New System.Drawing.Point(122, 245)
        Me.txtRadius.MenuManager = Me.CFG_Man_BarMan
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.Size = New System.Drawing.Size(100, 20)
        Me.txtRadius.TabIndex = 27
        '
        'CFG_Man_BarMan
        '
        Me.CFG_Man_BarMan.Categories.AddRange(New DevExpress.XtraBars.BarManagerCategory() {New DevExpress.XtraBars.BarManagerCategory("MachineTypeNode", New System.Guid("9185aabe-6328-4c33-96f1-ad6e45f2f809")), New DevExpress.XtraBars.BarManagerCategory("Material", New System.Guid("c8118de2-955e-499f-8d22-706a8eedcb4e")), New DevExpress.XtraBars.BarManagerCategory("MachineNode", New System.Guid("c17395fb-cdb5-4bc1-93a3-e0d4c0362a3c")), New DevExpress.XtraBars.BarManagerCategory("Stations", New System.Guid("f9585cfb-7b2d-4f33-b8c6-224d92ba00c1")), New DevExpress.XtraBars.BarManagerCategory("ToolSetupRootNode", New System.Guid("ca24cb53-ed1e-44e8-9e49-b55ffb8e2610")), New DevExpress.XtraBars.BarManagerCategory("ToolSetupNode", New System.Guid("7a9a3c21-a7f3-4afa-bf20-7df14c4e5711")), New DevExpress.XtraBars.BarManagerCategory("LayerSetupRootNode", New System.Guid("35914a7d-438c-4662-a7c0-afba771e5cdd")), New DevExpress.XtraBars.BarManagerCategory("LayerSetupNode", New System.Guid("32b4cf6f-1a25-47eb-b766-3dd5f76477de")), New DevExpress.XtraBars.BarManagerCategory("LayerNode", New System.Guid("e06cba09-9261-4535-a7b4-fdc91bc33e4b")), New DevExpress.XtraBars.BarManagerCategory("MaterialType", New System.Guid("869085f7-f4b9-4859-adcc-5159e88bdc2e")), New DevExpress.XtraBars.BarManagerCategory("SpecificMaterial", New System.Guid("dee01ec4-a41b-43f3-894d-8d46ce7e10b5")), New DevExpress.XtraBars.BarManagerCategory("LeadParamAdd", New System.Guid("081a7177-e86b-4bae-8a42-8449a306f394")), New DevExpress.XtraBars.BarManagerCategory("LeadParamRemove", New System.Guid("f477a8db-182e-443e-8441-392415d5dd50")), New DevExpress.XtraBars.BarManagerCategory("LeadSetupAdd", New System.Guid("7ec2c57b-61a8-4024-87d4-c4b6ed481ac8")), New DevExpress.XtraBars.BarManagerCategory("LeadSetupRemove", New System.Guid("b96c2642-3615-403c-94f0-19ab7d797ec1"))})
        Me.CFG_Man_BarMan.DockControls.Add(Me.barDockControlTop)
        Me.CFG_Man_BarMan.DockControls.Add(Me.barDockControlBottom)
        Me.CFG_Man_BarMan.DockControls.Add(Me.barDockControlLeft)
        Me.CFG_Man_BarMan.DockControls.Add(Me.barDockControlRight)
        Me.CFG_Man_BarMan.Form = Me
        Me.CFG_Man_BarMan.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarStaticItem1, Me.bbAddMaterial, Me.bbRemoveMaterialType, Me.bbADD_MACHINE, Me.MachineRemove, Me.MachineCopy, Me.MachineRename, Me.StationsAdd, Me.StationsRemove, Me.ToolSetupAdd, Me.ToolSetupRemove, Me.ToolSetupCopy, Me.ToolSetupRename, Me.LayerSetupAdd, Me.LayerAdd, Me.LayerRemove, Me.LayerAnalyze, Me.LayerNameRemove, Me.AddMaterialType, Me.bbSpecificMaterialRemove, Me.bbLeadParamAdd, Me.bbLeadParamRemove, Me.bbLeadSetupAdd, Me.LeadSetupRemove})
        Me.CFG_Man_BarMan.MaxItemId = 45
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.CFG_Man_BarMan
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlTop.Size = New System.Drawing.Size(997, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 561)
        Me.barDockControlBottom.Manager = Me.CFG_Man_BarMan
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(997, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.CFG_Man_BarMan
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 561)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(997, 0)
        Me.barDockControlRight.Manager = Me.CFG_Man_BarMan
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 561)
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Id = 0
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'bbAddMaterial
        '
        Me.bbAddMaterial.Caption = "Add Material"
        Me.bbAddMaterial.CategoryGuid = New System.Guid("c8118de2-955e-499f-8d22-706a8eedcb4e")
        Me.bbAddMaterial.Id = 7
        Me.bbAddMaterial.ImageOptions.Image = CType(resources.GetObject("bbAddMaterial.ImageOptions.Image"), System.Drawing.Image)
        Me.bbAddMaterial.Name = "bbAddMaterial"
        '
        'bbRemoveMaterialType
        '
        Me.bbRemoveMaterialType.Caption = " Remove Material Type"
        Me.bbRemoveMaterialType.CategoryGuid = New System.Guid("c8118de2-955e-499f-8d22-706a8eedcb4e")
        Me.bbRemoveMaterialType.Id = 8
        Me.bbRemoveMaterialType.ImageOptions.Image = CType(resources.GetObject("bbRemoveMaterialType.ImageOptions.Image"), System.Drawing.Image)
        Me.bbRemoveMaterialType.Name = "bbRemoveMaterialType"
        '
        'bbADD_MACHINE
        '
        Me.bbADD_MACHINE.Caption = "Add machine"
        Me.bbADD_MACHINE.CategoryGuid = New System.Guid("9185aabe-6328-4c33-96f1-ad6e45f2f809")
        Me.bbADD_MACHINE.Id = 15
        Me.bbADD_MACHINE.ImageOptions.Image = CType(resources.GetObject("bbADD_MACHINE.ImageOptions.Image"), System.Drawing.Image)
        Me.bbADD_MACHINE.Name = "bbADD_MACHINE"
        '
        'MachineRemove
        '
        Me.MachineRemove.Caption = "Remove Machine"
        Me.MachineRemove.CategoryGuid = New System.Guid("c17395fb-cdb5-4bc1-93a3-e0d4c0362a3c")
        Me.MachineRemove.Id = 17
        Me.MachineRemove.ImageOptions.Image = CType(resources.GetObject("MachineRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.MachineRemove.Name = "MachineRemove"
        '
        'MachineCopy
        '
        Me.MachineCopy.Caption = "Copy Machine"
        Me.MachineCopy.CategoryGuid = New System.Guid("c17395fb-cdb5-4bc1-93a3-e0d4c0362a3c")
        Me.MachineCopy.Id = 18
        Me.MachineCopy.ImageOptions.Image = CType(resources.GetObject("MachineCopy.ImageOptions.Image"), System.Drawing.Image)
        Me.MachineCopy.Name = "MachineCopy"
        '
        'MachineRename
        '
        Me.MachineRename.Caption = "Rename Machine"
        Me.MachineRename.CategoryGuid = New System.Guid("c17395fb-cdb5-4bc1-93a3-e0d4c0362a3c")
        Me.MachineRename.Id = 19
        Me.MachineRename.ImageOptions.Image = CType(resources.GetObject("MachineRename.ImageOptions.Image"), System.Drawing.Image)
        Me.MachineRename.Name = "MachineRename"
        '
        'StationsAdd
        '
        Me.StationsAdd.Caption = "Add Station(s)"
        Me.StationsAdd.CategoryGuid = New System.Guid("f9585cfb-7b2d-4f33-b8c6-224d92ba00c1")
        Me.StationsAdd.Id = 20
        Me.StationsAdd.ImageOptions.Image = CType(resources.GetObject("StationsAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.StationsAdd.Name = "StationsAdd"
        '
        'StationsRemove
        '
        Me.StationsRemove.Caption = "Remove Station"
        Me.StationsRemove.CategoryGuid = New System.Guid("f9585cfb-7b2d-4f33-b8c6-224d92ba00c1")
        Me.StationsRemove.Id = 21
        Me.StationsRemove.ImageOptions.Image = CType(resources.GetObject("StationsRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.StationsRemove.Name = "StationsRemove"
        '
        'ToolSetupAdd
        '
        Me.ToolSetupAdd.Caption = "Add Toolsetup"
        Me.ToolSetupAdd.CategoryGuid = New System.Guid("ca24cb53-ed1e-44e8-9e49-b55ffb8e2610")
        Me.ToolSetupAdd.Id = 22
        Me.ToolSetupAdd.ImageOptions.Image = CType(resources.GetObject("ToolSetupAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.ToolSetupAdd.Name = "ToolSetupAdd"
        '
        'ToolSetupRemove
        '
        Me.ToolSetupRemove.Caption = "Remove Tool Setup"
        Me.ToolSetupRemove.CategoryGuid = New System.Guid("7a9a3c21-a7f3-4afa-bf20-7df14c4e5711")
        Me.ToolSetupRemove.Id = 23
        Me.ToolSetupRemove.ImageOptions.Image = CType(resources.GetObject("ToolSetupRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.ToolSetupRemove.Name = "ToolSetupRemove"
        '
        'ToolSetupCopy
        '
        Me.ToolSetupCopy.Caption = "Copy Tool Setup"
        Me.ToolSetupCopy.CategoryGuid = New System.Guid("7a9a3c21-a7f3-4afa-bf20-7df14c4e5711")
        Me.ToolSetupCopy.Id = 24
        Me.ToolSetupCopy.ImageOptions.Image = CType(resources.GetObject("ToolSetupCopy.ImageOptions.Image"), System.Drawing.Image)
        Me.ToolSetupCopy.Name = "ToolSetupCopy"
        '
        'ToolSetupRename
        '
        Me.ToolSetupRename.Caption = "Rename Toolsetup"
        Me.ToolSetupRename.CategoryGuid = New System.Guid("7a9a3c21-a7f3-4afa-bf20-7df14c4e5711")
        Me.ToolSetupRename.Id = 25
        Me.ToolSetupRename.ImageOptions.Image = CType(resources.GetObject("ToolSetupRename.ImageOptions.Image"), System.Drawing.Image)
        Me.ToolSetupRename.Name = "ToolSetupRename"
        '
        'LayerSetupAdd
        '
        Me.LayerSetupAdd.Caption = "Add Layer Setup"
        Me.LayerSetupAdd.CategoryGuid = New System.Guid("35914a7d-438c-4662-a7c0-afba771e5cdd")
        Me.LayerSetupAdd.Id = 32
        Me.LayerSetupAdd.ImageOptions.Image = CType(resources.GetObject("LayerSetupAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.LayerSetupAdd.Name = "LayerSetupAdd"
        '
        'LayerAdd
        '
        Me.LayerAdd.Caption = "Add Layer"
        Me.LayerAdd.CategoryGuid = New System.Guid("32b4cf6f-1a25-47eb-b766-3dd5f76477de")
        Me.LayerAdd.Id = 33
        Me.LayerAdd.ImageOptions.Image = CType(resources.GetObject("LayerAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.LayerAdd.Name = "LayerAdd"
        '
        'LayerRemove
        '
        Me.LayerRemove.Caption = "Remove Layer Setup"
        Me.LayerRemove.CategoryGuid = New System.Guid("32b4cf6f-1a25-47eb-b766-3dd5f76477de")
        Me.LayerRemove.Id = 34
        Me.LayerRemove.ImageOptions.Image = CType(resources.GetObject("LayerRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.LayerRemove.Name = "LayerRemove"
        '
        'LayerAnalyze
        '
        Me.LayerAnalyze.Caption = "Analyze Layers"
        Me.LayerAnalyze.CategoryGuid = New System.Guid("32b4cf6f-1a25-47eb-b766-3dd5f76477de")
        Me.LayerAnalyze.Id = 35
        Me.LayerAnalyze.ImageOptions.Image = CType(resources.GetObject("LayerAnalyze.ImageOptions.Image"), System.Drawing.Image)
        Me.LayerAnalyze.ImageOptions.LargeImage = CType(resources.GetObject("LayerAnalyze.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.LayerAnalyze.Name = "LayerAnalyze"
        '
        'LayerNameRemove
        '
        Me.LayerNameRemove.Caption = "Remove Layer"
        Me.LayerNameRemove.CategoryGuid = New System.Guid("e06cba09-9261-4535-a7b4-fdc91bc33e4b")
        Me.LayerNameRemove.Id = 36
        Me.LayerNameRemove.ImageOptions.Image = CType(resources.GetObject("LayerNameRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.LayerNameRemove.Name = "LayerNameRemove"
        '
        'AddMaterialType
        '
        Me.AddMaterialType.Caption = "Add New Material Type"
        Me.AddMaterialType.CategoryGuid = New System.Guid("869085f7-f4b9-4859-adcc-5159e88bdc2e")
        Me.AddMaterialType.Id = 37
        Me.AddMaterialType.ImageOptions.Image = CType(resources.GetObject("AddMaterialType.ImageOptions.Image"), System.Drawing.Image)
        Me.AddMaterialType.Name = "AddMaterialType"
        '
        'bbSpecificMaterialRemove
        '
        Me.bbSpecificMaterialRemove.Caption = "Remove"
        Me.bbSpecificMaterialRemove.CategoryGuid = New System.Guid("dee01ec4-a41b-43f3-894d-8d46ce7e10b5")
        Me.bbSpecificMaterialRemove.Id = 39
        Me.bbSpecificMaterialRemove.ImageOptions.Image = CType(resources.GetObject("bbSpecificMaterialRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.bbSpecificMaterialRemove.Name = "bbSpecificMaterialRemove"
        '
        'bbLeadParamAdd
        '
        Me.bbLeadParamAdd.Caption = "Add Lead Parameter"
        Me.bbLeadParamAdd.CategoryGuid = New System.Guid("081a7177-e86b-4bae-8a42-8449a306f394")
        Me.bbLeadParamAdd.Id = 40
        Me.bbLeadParamAdd.ImageOptions.Image = CType(resources.GetObject("bbLeadParamAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.bbLeadParamAdd.Name = "bbLeadParamAdd"
        '
        'bbLeadParamRemove
        '
        Me.bbLeadParamRemove.Caption = "Remove"
        Me.bbLeadParamRemove.CategoryGuid = New System.Guid("f477a8db-182e-443e-8441-392415d5dd50")
        Me.bbLeadParamRemove.Id = 42
        Me.bbLeadParamRemove.ImageOptions.Image = CType(resources.GetObject("bbLeadParamRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.bbLeadParamRemove.Name = "bbLeadParamRemove"
        '
        'bbLeadSetupAdd
        '
        Me.bbLeadSetupAdd.Caption = "Add Lead Setup"
        Me.bbLeadSetupAdd.CategoryGuid = New System.Guid("7ec2c57b-61a8-4024-87d4-c4b6ed481ac8")
        Me.bbLeadSetupAdd.Id = 43
        Me.bbLeadSetupAdd.ImageOptions.Image = CType(resources.GetObject("bbLeadSetupAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.bbLeadSetupAdd.Name = "bbLeadSetupAdd"
        '
        'LeadSetupRemove
        '
        Me.LeadSetupRemove.Caption = "Remove"
        Me.LeadSetupRemove.CategoryGuid = New System.Guid("b96c2642-3615-403c-94f0-19ab7d797ec1")
        Me.LeadSetupRemove.Id = 44
        Me.LeadSetupRemove.ImageOptions.Image = CType(resources.GetObject("LeadSetupRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.LeadSetupRemove.ImageOptions.LargeImage = CType(resources.GetObject("LeadSetupRemove.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.LeadSetupRemove.Name = "LeadSetupRemove"
        '
        'txtLeadIncludedAngle
        '
        Me.txtLeadIncludedAngle.Location = New System.Drawing.Point(122, 219)
        Me.txtLeadIncludedAngle.MenuManager = Me.CFG_Man_BarMan
        Me.txtLeadIncludedAngle.Name = "txtLeadIncludedAngle"
        Me.txtLeadIncludedAngle.Size = New System.Drawing.Size(100, 20)
        Me.txtLeadIncludedAngle.TabIndex = 26
        '
        'txtLeadDistance
        '
        Me.txtLeadDistance.Location = New System.Drawing.Point(122, 193)
        Me.txtLeadDistance.MenuManager = Me.CFG_Man_BarMan
        Me.txtLeadDistance.Name = "txtLeadDistance"
        Me.txtLeadDistance.Size = New System.Drawing.Size(100, 20)
        Me.txtLeadDistance.TabIndex = 25
        '
        'txtLeadAngle
        '
        Me.txtLeadAngle.Location = New System.Drawing.Point(122, 167)
        Me.txtLeadAngle.MenuManager = Me.CFG_Man_BarMan
        Me.txtLeadAngle.Name = "txtLeadAngle"
        Me.txtLeadAngle.Size = New System.Drawing.Size(100, 20)
        Me.txtLeadAngle.TabIndex = 24
        '
        'txtLeadLength
        '
        Me.txtLeadLength.Location = New System.Drawing.Point(122, 141)
        Me.txtLeadLength.MenuManager = Me.CFG_Man_BarMan
        Me.txtLeadLength.Name = "txtLeadLength"
        Me.txtLeadLength.Size = New System.Drawing.Size(100, 20)
        Me.txtLeadLength.TabIndex = 23
        '
        'cboLeadJunction
        '
        Me.cboLeadJunction.Location = New System.Drawing.Point(122, 115)
        Me.cboLeadJunction.Name = "cboLeadJunction"
        Me.cboLeadJunction.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadJunction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadJunction.Size = New System.Drawing.Size(153, 20)
        Me.cboLeadJunction.TabIndex = 22
        '
        'cboLeadType
        '
        Me.cboLeadType.Location = New System.Drawing.Point(122, 89)
        Me.cboLeadType.Name = "cboLeadType"
        Me.cboLeadType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadType.Size = New System.Drawing.Size(153, 20)
        Me.cboLeadType.TabIndex = 21
        '
        'cboSplitLocation
        '
        Me.cboSplitLocation.Location = New System.Drawing.Point(122, 63)
        Me.cboSplitLocation.Name = "cboSplitLocation"
        Me.cboSplitLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSplitLocation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboSplitLocation.Size = New System.Drawing.Size(153, 20)
        Me.cboSplitLocation.TabIndex = 20
        '
        'cboLeadLocation
        '
        Me.cboLeadLocation.Location = New System.Drawing.Point(122, 37)
        Me.cboLeadLocation.Name = "cboLeadLocation"
        Me.cboLeadLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadLocation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadLocation.Size = New System.Drawing.Size(153, 20)
        Me.cboLeadLocation.TabIndex = 19
        '
        'lblRadius
        '
        Me.lblRadius.Location = New System.Drawing.Point(84, 248)
        Me.lblRadius.Name = "lblRadius"
        Me.lblRadius.Size = New System.Drawing.Size(32, 13)
        Me.lblRadius.TabIndex = 18
        Me.lblRadius.Text = "Radius"
        '
        'lblLeadIncludedAngle
        '
        Me.lblLeadIncludedAngle.Location = New System.Drawing.Point(45, 222)
        Me.lblLeadIncludedAngle.Name = "lblLeadIncludedAngle"
        Me.lblLeadIncludedAngle.Size = New System.Drawing.Size(71, 13)
        Me.lblLeadIncludedAngle.TabIndex = 17
        Me.lblLeadIncludedAngle.Text = "Included Angle"
        '
        'lblLeadDistance
        '
        Me.lblLeadDistance.Location = New System.Drawing.Point(72, 196)
        Me.lblLeadDistance.Name = "lblLeadDistance"
        Me.lblLeadDistance.Size = New System.Drawing.Size(41, 13)
        Me.lblLeadDistance.TabIndex = 16
        Me.lblLeadDistance.Text = "Distance"
        '
        'lblLeadAngle
        '
        Me.lblLeadAngle.Location = New System.Drawing.Point(86, 170)
        Me.lblLeadAngle.Name = "lblLeadAngle"
        Me.lblLeadAngle.Size = New System.Drawing.Size(27, 13)
        Me.lblLeadAngle.TabIndex = 15
        Me.lblLeadAngle.Text = "Angle"
        '
        'lblLeadLength
        '
        Me.lblLeadLength.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLeadLength.Appearance.Options.UseTextOptions = True
        Me.lblLeadLength.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblLeadLength.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLeadLength.LineLocation = DevExpress.XtraEditors.LineLocation.Right
        Me.lblLeadLength.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal
        Me.lblLeadLength.Location = New System.Drawing.Point(46, 145)
        Me.lblLeadLength.Name = "lblLeadLength"
        Me.lblLeadLength.Size = New System.Drawing.Size(67, 13)
        Me.lblLeadLength.TabIndex = 14
        Me.lblLeadLength.Text = "Tab Thickness"
        '
        'lblJunction
        '
        Me.lblJunction.Location = New System.Drawing.Point(73, 118)
        Me.lblJunction.Name = "lblJunction"
        Me.lblJunction.Size = New System.Drawing.Size(40, 13)
        Me.lblJunction.TabIndex = 13
        Me.lblJunction.Text = "Junction"
        '
        'lblLeadType
        '
        Me.lblLeadType.Location = New System.Drawing.Point(89, 92)
        Me.lblLeadType.Name = "lblLeadType"
        Me.lblLeadType.Size = New System.Drawing.Size(24, 13)
        Me.lblLeadType.TabIndex = 12
        Me.lblLeadType.Text = "Type"
        '
        'lblSplitLocation
        '
        Me.lblSplitLocation.Location = New System.Drawing.Point(50, 67)
        Me.lblSplitLocation.Name = "lblSplitLocation"
        Me.lblSplitLocation.Size = New System.Drawing.Size(63, 13)
        Me.lblSplitLocation.TabIndex = 11
        Me.lblSplitLocation.Text = "Split Location"
        '
        'lblLeadLocation
        '
        Me.lblLeadLocation.Location = New System.Drawing.Point(50, 40)
        Me.lblLeadLocation.Name = "lblLeadLocation"
        Me.lblLeadLocation.Size = New System.Drawing.Size(66, 13)
        Me.lblLeadLocation.TabIndex = 10
        Me.lblLeadLocation.Text = "Lead Location"
        '
        'cbfLeadParam
        '
        Me.cbfLeadParam.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.cbfLeadParam.Caption = "Include Pierce Hole (Used only for Punches and/or Drills)"
        Me.cbfLeadParam.CaptionColor = System.Drawing.Color.Silver
        Me.cbfLeadParam.Checked = False
        Me.cbfLeadParam.Controls.Add(Me.txtLeadToolDia)
        Me.cbfLeadParam.Controls.Add(Me.lblLeadToolDia)
        Me.cbfLeadParam.Controls.Add(Me.cboLeadToolType)
        Me.cbfLeadParam.Controls.Add(Me.lblLeadToolType)
        Me.cbfLeadParam.Controls.Add(Me.txtPierceDistance)
        Me.cbfLeadParam.Controls.Add(Me.lblPierceDistance)
        Me.cbfLeadParam.Controls.Add(Me.RadioGroup1)
        Me.cbfLeadParam.ForeColor = System.Drawing.Color.Black
        Me.cbfLeadParam.Location = New System.Drawing.Point(12, 301)
        Me.cbfLeadParam.Margin = New System.Windows.Forms.Padding(4)
        Me.cbfLeadParam.Name = "cbfLeadParam"
        Me.cbfLeadParam.Padding = New System.Windows.Forms.Padding(0, 11, 0, 0)
        Me.cbfLeadParam.Size = New System.Drawing.Size(324, 163)
        Me.cbfLeadParam.TabIndex = 9
        '
        'txtLeadToolDia
        '
        Me.txtLeadToolDia.Location = New System.Drawing.Point(74, 134)
        Me.txtLeadToolDia.MenuManager = Me.CFG_Man_BarMan
        Me.txtLeadToolDia.Name = "txtLeadToolDia"
        Me.txtLeadToolDia.Size = New System.Drawing.Size(67, 20)
        Me.txtLeadToolDia.TabIndex = 33
        '
        'lblLeadToolDia
        '
        Me.lblLeadToolDia.Location = New System.Drawing.Point(22, 137)
        Me.lblLeadToolDia.Name = "lblLeadToolDia"
        Me.lblLeadToolDia.Size = New System.Drawing.Size(74, 13)
        Me.lblLeadToolDia.TabIndex = 32
        Me.lblLeadToolDia.Text = "Pierce Tool Dia."
        '
        'cboLeadToolType
        '
        Me.cboLeadToolType.Location = New System.Drawing.Point(74, 106)
        Me.cboLeadToolType.Name = "cboLeadToolType"
        Me.cboLeadToolType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadToolType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboLeadToolType.Size = New System.Drawing.Size(136, 20)
        Me.cboLeadToolType.TabIndex = 31
        '
        'lblLeadToolType
        '
        Me.lblLeadToolType.Location = New System.Drawing.Point(40, 109)
        Me.lblLeadToolType.Name = "lblLeadToolType"
        Me.lblLeadToolType.Size = New System.Drawing.Size(47, 13)
        Me.lblLeadToolType.TabIndex = 30
        Me.lblLeadToolType.Text = "Tool Type"
        '
        'txtPierceDistance
        '
        Me.txtPierceDistance.Location = New System.Drawing.Point(74, 78)
        Me.txtPierceDistance.MenuManager = Me.CFG_Man_BarMan
        Me.txtPierceDistance.Name = "txtPierceDistance"
        Me.txtPierceDistance.Size = New System.Drawing.Size(67, 20)
        Me.txtPierceDistance.TabIndex = 29
        '
        'lblPierceDistance
        '
        Me.lblPierceDistance.Location = New System.Drawing.Point(22, 81)
        Me.lblPierceDistance.Name = "lblPierceDistance"
        Me.lblPierceDistance.Size = New System.Drawing.Size(73, 13)
        Me.lblPierceDistance.TabIndex = 28
        Me.lblPierceDistance.Text = "Pierce Distance"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(52, 28)
        Me.RadioGroup1.MenuManager = Me.CFG_Man_BarMan
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RadioGroup1.Properties.Appearance.Options.UseForeColor = True
        Me.RadioGroup1.Properties.Columns = 2
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "With Lead"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Without Lead")})
        Me.RadioGroup1.Size = New System.Drawing.Size(114, 38)
        Me.RadioGroup1.TabIndex = 1
        '
        'pnlAnalyze
        '
        Me.pnlAnalyze.Controls.Add(Me.cmdLayerSetupAnalyzeOk)
        Me.pnlAnalyze.Controls.Add(Me.vgLayerAnalyze)
        Me.pnlAnalyze.Location = New System.Drawing.Point(0, 0)
        Me.pnlAnalyze.Name = "pnlAnalyze"
        Me.pnlAnalyze.Size = New System.Drawing.Size(370, 368)
        Me.pnlAnalyze.TabIndex = 26
        Me.pnlAnalyze.TabStop = False
        Me.pnlAnalyze.Text = "Analyze Layers In CAD File"
        '
        'cmdLayerSetupAnalyzeOk
        '
        Me.cmdLayerSetupAnalyzeOk.Location = New System.Drawing.Point(278, 334)
        Me.cmdLayerSetupAnalyzeOk.Name = "cmdLayerSetupAnalyzeOk"
        Me.cmdLayerSetupAnalyzeOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdLayerSetupAnalyzeOk.TabIndex = 12
        Me.cmdLayerSetupAnalyzeOk.Text = "OK"
        '
        'vgLayerAnalyze
        '
        Me.vgLayerAnalyze.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vgLayerAnalyze.Dock = System.Windows.Forms.DockStyle.Left
        Me.vgLayerAnalyze.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgLayerAnalyze.Location = New System.Drawing.Point(3, 17)
        Me.vgLayerAnalyze.Name = "vgLayerAnalyze"
        Me.vgLayerAnalyze.OptionsBehavior.UseEnterAsTab = True
        Me.vgLayerAnalyze.OptionsView.AutoScaleBands = True
        Me.vgLayerAnalyze.RecordWidth = 154
        Me.vgLayerAnalyze.RowHeaderWidth = 46
        Me.vgLayerAnalyze.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.dsAnalyzeLayer})
        Me.vgLayerAnalyze.Size = New System.Drawing.Size(362, 348)
        Me.vgLayerAnalyze.TabIndex = 11
        '
        'dsAnalyzeLayer
        '
        Me.dsAnalyzeLayer.Name = "dsAnalyzeLayer"
        Me.dsAnalyzeLayer.Properties.Caption = "Analyze Layers"
        '
        'pnlMaterialInfo
        '
        Me.pnlMaterialInfo.Controls.Add(Me.vgMaterialInfo)
        Me.pnlMaterialInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMaterialInfo.Name = "pnlMaterialInfo"
        Me.pnlMaterialInfo.Size = New System.Drawing.Size(259, 494)
        Me.pnlMaterialInfo.TabIndex = 27
        Me.pnlMaterialInfo.TabStop = False
        Me.pnlMaterialInfo.Text = "Material Information"
        '
        'vgMaterialInfo
        '
        Me.vgMaterialInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgMaterialInfo.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgMaterialInfo.Location = New System.Drawing.Point(3, 17)
        Me.vgMaterialInfo.Name = "vgMaterialInfo"
        Me.vgMaterialInfo.OptionsBehavior.AutoFocusNewRecord = True
        Me.vgMaterialInfo.OptionsBehavior.UseEnterAsTab = True
        Me.vgMaterialInfo.OptionsView.AutoScaleBands = True
        Me.vgMaterialInfo.OptionsView.ShowButtons = False
        Me.vgMaterialInfo.RecordWidth = 92
        Me.vgMaterialInfo.RowHeaderWidth = 108
        Me.vgMaterialInfo.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catMaterialInfo})
        Me.vgMaterialInfo.Size = New System.Drawing.Size(253, 474)
        Me.vgMaterialInfo.TabIndex = 2
        '
        'catMaterialInfo
        '
        Me.catMaterialInfo.Height = 19
        Me.catMaterialInfo.Name = "catMaterialInfo"
        Me.catMaterialInfo.Properties.Caption = "Material Information"
        '
        'pnlToolSetups
        '
        Me.pnlToolSetups.Controls.Add(Me.SplitContainer1)
        Me.pnlToolSetups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlToolSetups.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolSetups.Name = "pnlToolSetups"
        Me.pnlToolSetups.Size = New System.Drawing.Size(794, 561)
        Me.pnlToolSetups.TabIndex = 13
        Me.pnlToolSetups.TabStop = False
        Me.pnlToolSetups.Text = "Tool Setup Information"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(788, 541)
        Me.SplitContainer1.SplitterDistance = 358
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.xgStations)
        Me.SplitContainer2.Panel1.Controls.Add(Me.pnlToolingParameters)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer2.Size = New System.Drawing.Size(358, 541)
        Me.SplitContainer2.SplitterDistance = 452
        Me.SplitContainer2.TabIndex = 0
        '
        'xgStations
        '
        Me.xgStations.AllowDrop = True
        Me.xgStations.Cursor = System.Windows.Forms.Cursors.Default
        Me.xgStations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xgStations.Location = New System.Drawing.Point(0, 0)
        Me.xgStations.MainView = Me.ToolSetupView
        Me.xgStations.Name = "xgStations"
        Me.xgStations.Size = New System.Drawing.Size(358, 452)
        Me.xgStations.TabIndex = 2
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
        Me.ToolSetupView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.ToolSetupView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.ToolSetupView.OptionsView.ShowDetailButtons = False
        Me.ToolSetupView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ToolSetupView.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.ToolSetupView.OptionsView.ShowGroupPanel = False
        Me.ToolSetupView.OptionsView.ShowViewCaption = True
        Me.ToolSetupView.ViewCaption = "Station Information"
        '
        'pnlToolingParameters
        '
        Me.pnlToolingParameters.Controls.Add(Me.vgToolParameters)
        Me.pnlToolingParameters.Controls.Add(Me.tbToolCribParamValues)
        Me.pnlToolingParameters.Controls.Add(Me.tbToolCribParamFields)
        Me.pnlToolingParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlToolingParameters.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolingParameters.Name = "pnlToolingParameters"
        Me.pnlToolingParameters.Size = New System.Drawing.Size(358, 452)
        Me.pnlToolingParameters.TabIndex = 19
        Me.pnlToolingParameters.TabStop = False
        Me.pnlToolingParameters.Text = "Tooling Parameters"
        '
        'vgToolParameters
        '
        Me.vgToolParameters.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vgToolParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgToolParameters.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgToolParameters.Location = New System.Drawing.Point(3, 17)
        Me.vgToolParameters.Name = "vgToolParameters"
        Me.vgToolParameters.OptionsBehavior.UseEnterAsTab = True
        Me.vgToolParameters.OptionsView.AutoScaleBands = True
        Me.vgToolParameters.RecordWidth = 154
        Me.vgToolParameters.RowHeaderWidth = 46
        Me.vgToolParameters.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.ToolParams})
        Me.vgToolParameters.Size = New System.Drawing.Size(352, 432)
        Me.vgToolParameters.TabIndex = 12
        '
        'ToolParams
        '
        Me.ToolParams.Height = 15
        Me.ToolParams.Name = "ToolParams"
        Me.ToolParams.Properties.Caption = "Tool Parameters"
        '
        'tbToolCribParamValues
        '
        Me.tbToolCribParamValues.Location = New System.Drawing.Point(34, 274)
        Me.tbToolCribParamValues.Name = "tbToolCribParamValues"
        Me.tbToolCribParamValues.Size = New System.Drawing.Size(345, 21)
        Me.tbToolCribParamValues.TabIndex = 15
        Me.tbToolCribParamValues.Visible = False
        '
        'tbToolCribParamFields
        '
        Me.tbToolCribParamFields.Location = New System.Drawing.Point(34, 301)
        Me.tbToolCribParamFields.Name = "tbToolCribParamFields"
        Me.tbToolCribParamFields.Size = New System.Drawing.Size(345, 21)
        Me.tbToolCribParamFields.TabIndex = 14
        Me.tbToolCribParamFields.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdMoveToolUp, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdMoveToolDown, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdRemoveTool, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.MaximumSize = New System.Drawing.Size(0, 102)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(358, 85)
        Me.TableLayoutPanel2.TabIndex = 16
        '
        'cmdMoveToolUp
        '
        Me.cmdMoveToolUp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmdMoveToolUp.Location = New System.Drawing.Point(195, 22)
        Me.cmdMoveToolUp.Name = "cmdMoveToolUp"
        Me.cmdMoveToolUp.Size = New System.Drawing.Size(94, 23)
        Me.cmdMoveToolUp.TabIndex = 37
        Me.cmdMoveToolUp.Text = "Move Tool Up"
        '
        'cmdMoveToolDown
        '
        Me.cmdMoveToolDown.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmdMoveToolDown.Location = New System.Drawing.Point(95, 22)
        Me.cmdMoveToolDown.Name = "cmdMoveToolDown"
        Me.cmdMoveToolDown.Size = New System.Drawing.Size(94, 23)
        Me.cmdMoveToolDown.TabIndex = 32
        Me.cmdMoveToolDown.Text = "Move Tool Down"
        '
        'cmdRemoveTool
        '
        Me.cmdRemoveTool.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmdRemoveTool.Location = New System.Drawing.Point(3, 22)
        Me.cmdRemoveTool.Name = "cmdRemoveTool"
        Me.cmdRemoveTool.Size = New System.Drawing.Size(86, 23)
        Me.cmdRemoveTool.TabIndex = 28
        Me.cmdRemoveTool.Text = "Remove Tool"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.pnlAvailableTooling)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.fraToolCrib)
        Me.SplitContainer3.Size = New System.Drawing.Size(426, 541)
        Me.SplitContainer3.SplitterDistance = 454
        Me.SplitContainer3.TabIndex = 0
        '
        'pnlAvailableTooling
        '
        Me.pnlAvailableTooling.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlAvailableTooling.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAvailableTooling.Location = New System.Drawing.Point(0, 0)
        Me.pnlAvailableTooling.MaximumSize = New System.Drawing.Size(700, 700)
        Me.pnlAvailableTooling.MinimumSize = New System.Drawing.Size(375, 0)
        Me.pnlAvailableTooling.Name = "pnlAvailableTooling"
        Me.pnlAvailableTooling.Size = New System.Drawing.Size(426, 454)
        Me.pnlAvailableTooling.TabIndex = 0
        Me.pnlAvailableTooling.TabStop = False
        Me.pnlAvailableTooling.Text = "Available Tooling"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.26027!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboToolSetupAvailTools, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lstToolSetupAvailTools, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.552083!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.44791!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(420, 434)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'cboToolSetupAvailTools
        '
        Me.cboToolSetupAvailTools.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboToolSetupAvailTools.Location = New System.Drawing.Point(3, 3)
        Me.cboToolSetupAvailTools.Name = "cboToolSetupAvailTools"
        Me.cboToolSetupAvailTools.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboToolSetupAvailTools.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboToolSetupAvailTools.Size = New System.Drawing.Size(414, 20)
        Me.cboToolSetupAvailTools.TabIndex = 0
        '
        'lstToolSetupAvailTools
        '
        Me.lstToolSetupAvailTools.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstToolSetupAvailTools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstToolSetupAvailTools.Location = New System.Drawing.Point(3, 35)
        Me.lstToolSetupAvailTools.Name = "lstToolSetupAvailTools"
        Me.lstToolSetupAvailTools.Size = New System.Drawing.Size(414, 396)
        Me.lstToolSetupAvailTools.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.lstToolSetupAvailTools.TabIndex = 1
        '
        'fraToolCrib
        '
        Me.fraToolCrib.Controls.Add(Me.cmdToolCribRemove)
        Me.fraToolCrib.Controls.Add(Me.cmdToolCribEdit)
        Me.fraToolCrib.Controls.Add(Me.cmdToolCribAdd)
        Me.fraToolCrib.Location = New System.Drawing.Point(6, 3)
        Me.fraToolCrib.Name = "fraToolCrib"
        Me.fraToolCrib.Size = New System.Drawing.Size(272, 47)
        Me.fraToolCrib.TabIndex = 3
        Me.fraToolCrib.TabStop = False
        Me.fraToolCrib.Text = "Tool Crib"
        '
        'cmdToolCribRemove
        '
        Me.cmdToolCribRemove.Enabled = False
        Me.cmdToolCribRemove.Location = New System.Drawing.Point(17, 20)
        Me.cmdToolCribRemove.Name = "cmdToolCribRemove"
        Me.cmdToolCribRemove.Size = New System.Drawing.Size(78, 20)
        Me.cmdToolCribRemove.TabIndex = 2
        Me.cmdToolCribRemove.Text = "Remove"
        '
        'cmdToolCribEdit
        '
        Me.cmdToolCribEdit.Enabled = False
        Me.cmdToolCribEdit.Location = New System.Drawing.Point(187, 20)
        Me.cmdToolCribEdit.Name = "cmdToolCribEdit"
        Me.cmdToolCribEdit.Size = New System.Drawing.Size(78, 20)
        Me.cmdToolCribEdit.TabIndex = 1
        Me.cmdToolCribEdit.Text = "Edit"
        '
        'cmdToolCribAdd
        '
        Me.cmdToolCribAdd.Location = New System.Drawing.Point(102, 20)
        Me.cmdToolCribAdd.Name = "cmdToolCribAdd"
        Me.cmdToolCribAdd.Size = New System.Drawing.Size(78, 20)
        Me.cmdToolCribAdd.TabIndex = 0
        Me.cmdToolCribAdd.Text = "Add"
        '
        'pnlMachSettings
        '
        Me.pnlMachSettings.Controls.Add(Me.Form1ConvertedLayout)
        Me.pnlMachSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMachSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlMachSettings.Name = "pnlMachSettings"
        Me.pnlMachSettings.Padding = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlMachSettings.Size = New System.Drawing.Size(794, 561)
        Me.pnlMachSettings.TabIndex = 4
        Me.pnlMachSettings.TabStop = False
        Me.pnlMachSettings.Text = "Machine Settings"
        '
        'Form1ConvertedLayout
        '
        Me.Form1ConvertedLayout.Controls.Add(Me.pnlCtgs)
        Me.Form1ConvertedLayout.Controls.Add(Me.pnlMachineSettings)
        Me.Form1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Form1ConvertedLayout.Location = New System.Drawing.Point(3, 17)
        Me.Form1ConvertedLayout.Name = "Form1ConvertedLayout"
        Me.Form1ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.Form1ConvertedLayout.Size = New System.Drawing.Size(776, 541)
        Me.Form1ConvertedLayout.TabIndex = 18
        '
        'pnlCtgs
        '
        Me.pnlCtgs.Controls.Add(Me.LabelControl2)
        Me.pnlCtgs.Controls.Add(Me.LabelControl3)
        Me.pnlCtgs.Controls.Add(Me.beCodeGen)
        Me.pnlCtgs.Controls.Add(Me.beCNC_Path)
        Me.pnlCtgs.Location = New System.Drawing.Point(2, 470)
        Me.pnlCtgs.Name = "pnlCtgs"
        Me.pnlCtgs.Size = New System.Drawing.Size(772, 69)
        Me.pnlCtgs.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(46, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "CNC Path: "
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 38)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Code Generator: "
        '
        'beCodeGen
        '
        Me.beCodeGen.Location = New System.Drawing.Point(105, 34)
        Me.beCodeGen.MenuManager = Me.CFG_Man_BarMan
        Me.beCodeGen.Name = "beCodeGen"
        Me.beCodeGen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCodeGen.Size = New System.Drawing.Size(310, 20)
        Me.beCodeGen.TabIndex = 7
        '
        'beCNC_Path
        '
        Me.beCNC_Path.Location = New System.Drawing.Point(105, 8)
        Me.beCNC_Path.MenuManager = Me.CFG_Man_BarMan
        Me.beCNC_Path.Name = "beCNC_Path"
        Me.beCNC_Path.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.beCNC_Path.Size = New System.Drawing.Size(310, 20)
        Me.beCNC_Path.TabIndex = 6
        '
        'pnlMachineSettings
        '
        Me.pnlMachineSettings.Controls.Add(Me.vgMachSettings)
        Me.pnlMachineSettings.Location = New System.Drawing.Point(2, 2)
        Me.pnlMachineSettings.Name = "pnlMachineSettings"
        Me.pnlMachineSettings.Size = New System.Drawing.Size(772, 464)
        Me.pnlMachineSettings.TabIndex = 2
        '
        'vgMachSettings
        '
        Me.vgMachSettings.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vgMachSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgMachSettings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgMachSettings.Location = New System.Drawing.Point(0, 0)
        Me.vgMachSettings.Name = "vgMachSettings"
        Me.vgMachSettings.OptionsBehavior.AutoSelectAllInEditor = False
        Me.vgMachSettings.OptionsBehavior.CopyToClipboardWithRowHeaders = False
        Me.vgMachSettings.OptionsBehavior.UseDefaultEditorsCollection = False
        Me.vgMachSettings.OptionsBehavior.UseEnterAsTab = True
        Me.vgMachSettings.OptionsMenu.EnableContextMenu = False
        Me.vgMachSettings.OptionsView.AutoScaleBands = True
        Me.vgMachSettings.RecordWidth = 154
        Me.vgMachSettings.RowHeaderWidth = 46
        Me.vgMachSettings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.MachSettings})
        Me.vgMachSettings.Size = New System.Drawing.Size(772, 464)
        Me.vgMachSettings.TabIndex = 10
        '
        'MachSettings
        '
        Me.MachSettings.Name = "MachSettings"
        Me.MachSettings.Properties.Caption = "Machine Settings"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(776, 541)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.pnlCtgs
        Me.LayoutControlItem2.CustomizationFormText = "pnlCtgsitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 468)
        Me.LayoutControlItem2.Name = "pnlCtgsitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(776, 73)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.pnlMachineSettings
        Me.LayoutControlItem3.CustomizationFormText = "pnlMachineSettingsitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "pnlMachineSettingsitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(776, 468)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'pnlStations
        '
        Me.pnlStations.Controls.Add(Me.SplitContainerControl1)
        Me.pnlStations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStations.Location = New System.Drawing.Point(0, 0)
        Me.pnlStations.Name = "pnlStations"
        Me.pnlStations.Size = New System.Drawing.Size(794, 561)
        Me.pnlStations.TabIndex = 15
        Me.pnlStations.TabStop = False
        Me.pnlStations.Text = "Stations"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ubgStations)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.sbRemoveStation)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.sbAddStation)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.cbfAutoFillStations)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(788, 541)
        Me.SplitContainerControl1.SplitterPosition = 302
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ubgStations
        '
        Me.ubgStations.Cursor = System.Windows.Forms.Cursors.Default
        Me.ubgStations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ubgStations.Location = New System.Drawing.Point(0, 0)
        Me.ubgStations.MainView = Me.ubgStationsView
        Me.ubgStations.Name = "ubgStations"
        Me.ubgStations.Size = New System.Drawing.Size(788, 302)
        Me.ubgStations.TabIndex = 9
        Me.ubgStations.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ubgStationsView})
        '
        'ubgStationsView
        '
        Me.ubgStationsView.ActiveFilterEnabled = False
        Me.ubgStationsView.GridControl = Me.ubgStations
        Me.ubgStationsView.Name = "ubgStationsView"
        Me.ubgStationsView.OptionsCustomization.AllowColumnMoving = False
        Me.ubgStationsView.OptionsCustomization.AllowFilter = False
        Me.ubgStationsView.OptionsCustomization.AllowGroup = False
        Me.ubgStationsView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ubgStationsView.OptionsCustomization.AllowSort = False
        Me.ubgStationsView.OptionsDetail.ShowDetailTabs = False
        Me.ubgStationsView.OptionsNavigation.EnterMoveNextColumn = True
        Me.ubgStationsView.OptionsView.ShowDetailButtons = False
        Me.ubgStationsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ubgStationsView.OptionsView.ShowGroupPanel = False
        Me.ubgStationsView.OptionsView.ShowIndicator = False
        '
        'sbRemoveStation
        '
        Me.sbRemoveStation.Location = New System.Drawing.Point(172, 7)
        Me.sbRemoveStation.Name = "sbRemoveStation"
        Me.sbRemoveStation.Size = New System.Drawing.Size(120, 25)
        Me.sbRemoveStation.TabIndex = 11
        Me.sbRemoveStation.Text = "Remove Station"
        '
        'sbAddStation
        '
        Me.sbAddStation.Location = New System.Drawing.Point(298, 7)
        Me.sbAddStation.Name = "sbAddStation"
        Me.sbAddStation.Size = New System.Drawing.Size(120, 25)
        Me.sbAddStation.TabIndex = 10
        Me.sbAddStation.Text = "Add Station(s)"
        '
        'cbfAutoFillStations
        '
        Me.cbfAutoFillStations.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.cbfAutoFillStations.Caption = "Auto Fill Stations"
        Me.cbfAutoFillStations.CaptionColor = System.Drawing.Color.Silver
        Me.cbfAutoFillStations.Checked = False
        Me.cbfAutoFillStations.Controls.Add(Me.lbtAutoFill)
        Me.cbfAutoFillStations.Location = New System.Drawing.Point(6, 7)
        Me.cbfAutoFillStations.Margin = New System.Windows.Forms.Padding(4)
        Me.cbfAutoFillStations.Name = "cbfAutoFillStations"
        Me.cbfAutoFillStations.Padding = New System.Windows.Forms.Padding(0, 11, 0, 0)
        Me.cbfAutoFillStations.Size = New System.Drawing.Size(160, 55)
        Me.cbfAutoFillStations.TabIndex = 9
        '
        'lbtAutoFill
        '
        Me.lbtAutoFill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lbtAutoFill.BackColor = System.Drawing.Color.Transparent
        Me.lbtAutoFill.Caption = "Auto Fill Stations"
        Me.lbtAutoFill.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.lbtAutoFill.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.lbtAutoFill.FieldWidth = 100
        Me.lbtAutoFill.Location = New System.Drawing.Point(6, 24)
        Me.lbtAutoFill.Margin = New System.Windows.Forms.Padding(4)
        Me.lbtAutoFill.MaxLength = 32767
        Me.lbtAutoFill.Name = "lbtAutoFill"
        Me.lbtAutoFill.Size = New System.Drawing.Size(150, 25)
        Me.lbtAutoFill.TabIndex = 1
        '
        'pnlLayerGlobal
        '
        Me.pnlLayerGlobal.Controls.Add(Me.vgGlobalLayerInfo)
        Me.pnlLayerGlobal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayerGlobal.Location = New System.Drawing.Point(0, 0)
        Me.pnlLayerGlobal.Name = "pnlLayerGlobal"
        Me.pnlLayerGlobal.Size = New System.Drawing.Size(794, 561)
        Me.pnlLayerGlobal.TabIndex = 23
        Me.pnlLayerGlobal.TabStop = False
        Me.pnlLayerGlobal.Text = "Global Layer Information"
        '
        'vgGlobalLayerInfo
        '
        Me.vgGlobalLayerInfo.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vgGlobalLayerInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgGlobalLayerInfo.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgGlobalLayerInfo.Location = New System.Drawing.Point(3, 17)
        Me.vgGlobalLayerInfo.Name = "vgGlobalLayerInfo"
        Me.vgGlobalLayerInfo.OptionsView.AutoScaleBands = True
        Me.vgGlobalLayerInfo.OptionsView.ShowButtons = False
        Me.vgGlobalLayerInfo.RecordWidth = 92
        Me.vgGlobalLayerInfo.RowHeaderWidth = 108
        Me.vgGlobalLayerInfo.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catGlobalLayerInfo})
        Me.vgGlobalLayerInfo.Size = New System.Drawing.Size(788, 541)
        Me.vgGlobalLayerInfo.TabIndex = 1
        '
        'catGlobalLayerInfo
        '
        Me.catGlobalLayerInfo.Name = "catGlobalLayerInfo"
        Me.catGlobalLayerInfo.Properties.Caption = "Global Layer Information"
        '
        'pnlPreamble
        '
        Me.pnlPreamble.Controls.Add(Me.memoInfo)
        Me.pnlPreamble.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreamble.Location = New System.Drawing.Point(0, 0)
        Me.pnlPreamble.Name = "pnlPreamble"
        Me.pnlPreamble.Size = New System.Drawing.Size(794, 561)
        Me.pnlPreamble.TabIndex = 16
        Me.pnlPreamble.TabStop = False
        Me.pnlPreamble.Text = "What's This"
        '
        'memoInfo
        '
        Me.memoInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.memoInfo.Location = New System.Drawing.Point(3, 17)
        Me.memoInfo.Name = "memoInfo"
        Me.memoInfo.Properties.AllowFocused = False
        Me.memoInfo.Properties.AllowMouseWheel = False
        Me.memoInfo.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.memoInfo.Size = New System.Drawing.Size(788, 541)
        Me.memoInfo.TabIndex = 5
        '
        'pnlLayerSetup
        '
        Me.pnlLayerSetup.Controls.Add(Me.cbLayerTools)
        Me.pnlLayerSetup.Controls.Add(Me.vgLayerInfo)
        Me.pnlLayerSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayerSetup.Location = New System.Drawing.Point(0, 0)
        Me.pnlLayerSetup.Name = "pnlLayerSetup"
        Me.pnlLayerSetup.Size = New System.Drawing.Size(794, 561)
        Me.pnlLayerSetup.TabIndex = 25
        Me.pnlLayerSetup.TabStop = False
        Me.pnlLayerSetup.Text = "Layer Information"
        '
        'cbLayerTools
        '
        Me.cbLayerTools.Location = New System.Drawing.Point(22, 305)
        Me.cbLayerTools.MenuManager = Me.CFG_Man_BarMan
        Me.cbLayerTools.Name = "cbLayerTools"
        Me.cbLayerTools.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbLayerTools.Size = New System.Drawing.Size(104, 20)
        Me.cbLayerTools.TabIndex = 15
        Me.cbLayerTools.Visible = False
        '
        'vgLayerInfo
        '
        Me.vgLayerInfo.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vgLayerInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgLayerInfo.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgLayerInfo.Location = New System.Drawing.Point(3, 17)
        Me.vgLayerInfo.Name = "vgLayerInfo"
        Me.vgLayerInfo.OptionsView.AutoScaleBands = True
        Me.vgLayerInfo.OptionsView.ShowButtons = False
        Me.vgLayerInfo.RecordWidth = 92
        Me.vgLayerInfo.RowHeaderWidth = 108
        Me.vgLayerInfo.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catLayerInformation})
        Me.vgLayerInfo.Size = New System.Drawing.Size(788, 541)
        Me.vgLayerInfo.TabIndex = 13
        '
        'catLayerInformation
        '
        Me.catLayerInformation.Height = 15
        Me.catLayerInformation.Name = "catLayerInformation"
        Me.catLayerInformation.Properties.Caption = "Layer Information"
        '
        'PopUp_TV_Config
        '
        Me.PopUp_TV_Config.Manager = Me.CFG_Man_BarMan
        Me.PopUp_TV_Config.Name = "PopUp_TV_Config"
        '
        'barButtonItem1
        '
        Me.barButtonItem1.Caption = "barButtonItem1"
        Me.barButtonItem1.CategoryGuid = New System.Guid("35914a7d-438c-4662-a7c0-afba771e5cdd")
        Me.barButtonItem1.Id = 26
        Me.barButtonItem1.Name = "barButtonItem1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(70, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'sbHtmlAdd
        '
        Me.sbHtmlAdd.Location = New System.Drawing.Point(0, 0)
        Me.sbHtmlAdd.Name = "sbHtmlAdd"
        Me.sbHtmlAdd.Size = New System.Drawing.Size(75, 23)
        Me.sbHtmlAdd.TabIndex = 16
        Me.sbHtmlAdd.Text = "html list populate"
        Me.sbHtmlAdd.Visible = False
        '
        'frmCfgMan3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 561)
        Me.Controls.Add(Me.sbHtmlAdd)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.sccCfgMan)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmCfgMan3"
        Me.Text = "Configuration Manager"
        CType(Me.sccCfgMan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sccCfgMan.ResumeLayout(False)
        CType(Me.TV_Config, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeadSetupInfo.ResumeLayout(False)
        Me.pnlLeadSetupInfo.PerformLayout()
        CType(Me.cboLeadExtArcOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadExtArcIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadExtLineOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadExtLineIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadIntArcOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadIntArcIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadIntLineOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadIntLineIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeadParameters.ResumeLayout(False)
        Me.pnlLeadParameters.PerformLayout()
        CType(Me.txtRadius.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFG_Man_BarMan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeadIncludedAngle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeadDistance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeadAngle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeadLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadJunction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSplitLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbfLeadParam.ResumeLayout(False)
        Me.cbfLeadParam.PerformLayout()
        CType(Me.txtLeadToolDia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadToolType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPierceDistance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAnalyze.ResumeLayout(False)
        CType(Me.vgLayerAnalyze, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMaterialInfo.ResumeLayout(False)
        CType(Me.vgMaterialInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolSetups.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.xgStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolSetupView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolingParameters.ResumeLayout(False)
        Me.pnlToolingParameters.PerformLayout()
        CType(Me.vgToolParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.pnlAvailableTooling.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.cboToolSetupAvailTools.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstToolSetupAvailTools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraToolCrib.ResumeLayout(False)
        Me.pnlMachSettings.ResumeLayout(False)
        CType(Me.Form1ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Form1ConvertedLayout.ResumeLayout(False)
        Me.pnlCtgs.ResumeLayout(False)
        Me.pnlCtgs.PerformLayout()
        CType(Me.beCodeGen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCNC_Path.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMachineSettings.ResumeLayout(False)
        CType(Me.vgMachSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStations.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ubgStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ubgStationsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbfAutoFillStations.ResumeLayout(False)
        Me.pnlLayerGlobal.ResumeLayout(False)
        CType(Me.vgGlobalLayerInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreamble.ResumeLayout(False)
        CType(Me.memoInfo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLayerSetup.ResumeLayout(False)
        CType(Me.cbLayerTools.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgLayerInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopUp_TV_Config, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sccCfgMan As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents pnlPreamble As System.Windows.Forms.GroupBox
    Friend WithEvents memoInfo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents pnlStations As System.Windows.Forms.GroupBox
    Friend WithEvents pnlToolSetups As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlAvailableTooling As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboToolSetupAvailTools As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lstToolSetupAvailTools As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents fraToolCrib As System.Windows.Forms.GroupBox
    Friend WithEvents cmdToolCribRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdToolCribEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdToolCribAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlMachSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Form1ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents pnlCtgs As System.Windows.Forms.Panel
    Friend WithEvents pnlMachineSettings As System.Windows.Forms.Panel
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Private WithEvents TV_Config As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents MachSettings As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents CFG_Man_BarMan As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bbAddMaterial As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbRemoveMaterialType As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbADD_MACHINE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopUp_TV_Config As DevExpress.XtraBars.PopupMenu
    Friend WithEvents MachineRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MachineCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MachineRename As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents StationsAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents StationsRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ToolSetupAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ToolSetupRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ToolSetupCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ToolSetupRename As DevExpress.XtraBars.BarButtonItem
    Private WithEvents xgStations As DevExpress.XtraGrid.GridControl
    Private WithEvents ToolSetupView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdMoveToolDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRemoveTool As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlToolingParameters As System.Windows.Forms.GroupBox
    Private WithEvents vgToolParameters As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents ToolParams As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents ubgStations As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl
    Friend WithEvents ubgStationsView As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView
    Friend WithEvents sbRemoveStation As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbAddStation As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbfAutoFillStations As FabV24_WIN8.WindowsApplication234.ChkBoxFrame
    Friend WithEvents lbtAutoFill As FabV24_WIN8.lblTextBox
    Friend WithEvents pnlLayerGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents vgGlobalLayerInfo As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catGlobalLayerInfo As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents pnlLayerSetup As System.Windows.Forms.GroupBox
    Private WithEvents vgLayerInfo As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catLayerInformation As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents cbLayerTools As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayerSetupAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayerAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayerRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayerAnalyze As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayerNameRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlAnalyze As System.Windows.Forms.GroupBox
    Friend WithEvents tbToolCribParamValues As System.Windows.Forms.TextBox
    Friend WithEvents tbToolCribParamFields As System.Windows.Forms.TextBox
    Friend WithEvents AddMaterialType As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlMaterialInfo As System.Windows.Forms.GroupBox
    Friend WithEvents vgMaterialInfo As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catMaterialInfo As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents bbSpecificMaterialRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbLeadParamAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlLeadParameters As System.Windows.Forms.GroupBox
    Friend WithEvents cbfLeadParam As FabV24_WIN8.WindowsApplication234.ChkBoxFrame
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents txtRadius As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLeadIncludedAngle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLeadDistance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLeadAngle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLeadLength As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboLeadJunction As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboLeadType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboSplitLocation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboLeadLocation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblRadius As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLeadIncludedAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLeadDistance As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLeadAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLeadLength As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblJunction As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLeadType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSplitLocation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLeadLocation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPierceDistance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPierceDistance As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadToolType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadToolType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLeadToolDia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblLeadToolDia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bbLeadParamRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlLeadSetupInfo As System.Windows.Forms.GroupBox
    Friend WithEvents bbLeadSetupAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cboLeadExtArcOut As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadExtArcOut As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadExtArcIn As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadExtArcIn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadExtLineOut As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadExtLineOut As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadExtLineIn As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadExtLineIn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadIntArcOut As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadIntArcOut As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadIntArcIn As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadIntArcIn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadIntLineOut As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadIntLineOut As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLeadIntLineIn As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLeadIntLineIn As DevExpress.XtraEditors.LabelControl
    Private WithEvents vgLayerAnalyze As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents dsAnalyzeLayer As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents cmdLayerSetupAnalyzeOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents vgMachSettings As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LeadSetupRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdMoveToolUp As SimpleButton
    Friend WithEvents LabelControl2 As LabelControl
    Friend WithEvents LabelControl3 As LabelControl
    Friend WithEvents beCodeGen As ButtonEdit
    Friend WithEvents beCNC_Path As ButtonEdit
    Friend WithEvents sbHtmlAdd As SimpleButton
End Class
