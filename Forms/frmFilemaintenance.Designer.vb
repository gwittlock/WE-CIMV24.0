<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFilemaintenance
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFilemaintenance))
        Dim SimpleContextButton12 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton13 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton14 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton15 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton16 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton17 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton18 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton19 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton20 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton21 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Dim SimpleContextButton22 As DevExpress.Utils.SimpleContextButton = New DevExpress.Utils.SimpleContextButton()
        Me.rbcDataEntry = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbiJObsNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiJObsOpen = New DevExpress.XtraBars.BarButtonItem()
        Me.biiJobsDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiFileManagement = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiShipping = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiFInd = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.rpgJobManagement = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgJobs = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgProcess = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgFind = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemSearchControl1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchControl()
        Me.grdJobs = New DevExpress.XtraGrid.GridControl()
        Me.gvJobs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdcJobName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcFIleManage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcPlantLoc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcPlant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcBOMBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcBOMDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcEnteredBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcEnteredDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcJobID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcJobNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.repositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.repositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.repositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.xtcJobs = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpJobs = New DevExpress.XtraTab.XtraTabPage()
        Me.xtpFileManagement = New DevExpress.XtraTab.XtraTabPage()
        Me.grpcCopyTo = New DevExpress.XtraEditors.GroupControl()
        Me.beRPTToFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblRPTToFolder = New DevExpress.XtraEditors.LabelControl()
        Me.bePDBToFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblPDBToFolder = New DevExpress.XtraEditors.LabelControl()
        Me.beCADToFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblCADToFolder = New DevExpress.XtraEditors.LabelControl()
        Me.beCNCToFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblCNCToFolder = New DevExpress.XtraEditors.LabelControl()
        Me.beNSTToFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblNSTToFolder = New DevExpress.XtraEditors.LabelControl()
        Me.lbcCopyMove = New DevExpress.XtraEditors.ListBoxControl()
        Me.beMM2ToFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.sbCopyMoveExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.lblMM2ToFolder = New DevExpress.XtraEditors.LabelControl()
        Me.beCopyMoveRPT = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCopyMoveRPT = New DevExpress.XtraEditors.CheckEdit()
        Me.beCopyMoveCNC = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCopyMoveCNC = New DevExpress.XtraEditors.CheckEdit()
        Me.beCopyMovePDB = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCopyMovePDB = New DevExpress.XtraEditors.CheckEdit()
        Me.beCopyMoveNST = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCopyMoveNST = New DevExpress.XtraEditors.CheckEdit()
        Me.beCopyMoveCad = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCopyMoveCad = New DevExpress.XtraEditors.CheckEdit()
        Me.beCopyMoveMM2 = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCopyMoveMM2 = New DevExpress.XtraEditors.CheckEdit()
        Me.lblCopyMove = New DevExpress.XtraEditors.LabelControl()
        Me.cboCopyMove = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.xtpShipping = New DevExpress.XtraTab.XtraTabPage()
        Me.gcShippingPurchaser = New DevExpress.XtraEditors.GroupControl()
        Me.vgridShippingPurchaser = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.rowPurchCustomer = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.RowPurchAdd1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPurchAdd2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPurchCity = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPurchStateProv = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPurchPostalCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPurchCountry = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPurchPhone = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.gcShippingInfo = New DevExpress.XtraEditors.GroupControl()
        Me.vgridShippingInfo = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.rowShipJobNum = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipCustomer = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipAdd1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipAdd2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipCity = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipStateProv = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipPostalCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipCountry = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipAttn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipPhone = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipCarrier = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipTruckNum = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipPo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShipFreight = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.xtpFind = New DevExpress.XtraTab.XtraTabPage()
        Me.SpreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.DateEdit4 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit5 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit3 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.lblDateModifiedTo = New DevExpress.XtraEditors.LabelControl()
        Me.deModified_1 = New DevExpress.XtraEditors.DateEdit()
        Me.lblDateModify = New DevExpress.XtraEditors.LabelControl()
        Me.icLarge = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.rbcDataEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtcJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcJobs.SuspendLayout()
        Me.xtpJobs.SuspendLayout()
        Me.xtpFileManagement.SuspendLayout()
        CType(Me.grpcCopyTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpcCopyTo.SuspendLayout()
        CType(Me.beRPTToFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bePDBToFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCADToFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCNCToFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beNSTToFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcCopyMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beMM2ToFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCopyMoveRPT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopyMoveRPT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCopyMoveCNC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopyMoveCNC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCopyMovePDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopyMovePDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCopyMoveNST.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopyMoveNST.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCopyMoveCad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopyMoveCad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCopyMoveMM2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopyMoveMM2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCopyMove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtpShipping.SuspendLayout()
        CType(Me.gcShippingPurchaser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcShippingPurchaser.SuspendLayout()
        CType(Me.vgridShippingPurchaser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcShippingInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcShippingInfo.SuspendLayout()
        CType(Me.vgridShippingInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtpFind.SuspendLayout()
        CType(Me.DateEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit5.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deModified_1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deModified_1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbcDataEntry
        '
        Me.rbcDataEntry.AllowMinimizeRibbon = False
        Me.rbcDataEntry.ExpandCollapseItem.Id = 0
        Me.rbcDataEntry.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.rbcDataEntry.ExpandCollapseItem, Me.bbiJObsNew, Me.bbiJObsOpen, Me.biiJobsDelete, Me.bbiFileManagement, Me.bbiShipping, Me.bbiFInd, Me.bbiRefresh})
        Me.rbcDataEntry.Location = New System.Drawing.Point(0, 0)
        Me.rbcDataEntry.MaxItemId = 20
        Me.rbcDataEntry.Name = "rbcDataEntry"
        Me.rbcDataEntry.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpgJobManagement})
        Me.rbcDataEntry.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemComboBox2, Me.RepositoryItemTextEdit2, Me.RepositoryItemSearchControl1})
        Me.rbcDataEntry.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rbcDataEntry.ShowCategoryInCaption = False
        Me.rbcDataEntry.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rbcDataEntry.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rbcDataEntry.ShowQatLocationSelector = False
        Me.rbcDataEntry.ShowToolbarCustomizeItem = False
        Me.rbcDataEntry.Size = New System.Drawing.Size(1068, 147)
        Me.rbcDataEntry.StatusBar = Me.RibbonStatusBar
        Me.rbcDataEntry.Toolbar.ShowCustomizeItem = False
        '
        'bbiJObsNew
        '
        Me.bbiJObsNew.Caption = "New"
        Me.bbiJObsNew.Id = 7
        Me.bbiJObsNew.ImageOptions.Image = CType(resources.GetObject("bbiJObsNew.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiJObsNew.ImageOptions.LargeImage = CType(resources.GetObject("bbiJObsNew.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiJObsNew.Name = "bbiJObsNew"
        '
        'bbiJObsOpen
        '
        Me.bbiJObsOpen.Caption = "Open"
        Me.bbiJObsOpen.Id = 8
        Me.bbiJObsOpen.ImageOptions.Image = CType(resources.GetObject("bbiJObsOpen.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiJObsOpen.ImageOptions.LargeImage = CType(resources.GetObject("bbiJObsOpen.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiJObsOpen.Name = "bbiJObsOpen"
        '
        'biiJobsDelete
        '
        Me.biiJobsDelete.Caption = "Delete"
        Me.biiJobsDelete.Id = 9
        Me.biiJobsDelete.ImageOptions.Image = CType(resources.GetObject("biiJobsDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.biiJobsDelete.ImageOptions.LargeImage = CType(resources.GetObject("biiJobsDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.biiJobsDelete.Name = "biiJobsDelete"
        '
        'bbiFileManagement
        '
        Me.bbiFileManagement.Caption = "FIle Management"
        Me.bbiFileManagement.Id = 10
        Me.bbiFileManagement.ImageOptions.LargeImage = Global.FabV24_WIN8.My.Resources.Resources.cabinet_icon_9272
        Me.bbiFileManagement.Name = "bbiFileManagement"
        '
        'bbiShipping
        '
        Me.bbiShipping.Caption = "Shipping"
        Me.bbiShipping.Id = 11
        Me.bbiShipping.ImageOptions.LargeImage = CType(resources.GetObject("bbiShipping.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiShipping.Name = "bbiShipping"
        Me.bbiShipping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiFInd
        '
        Me.bbiFInd.Caption = "Find"
        Me.bbiFInd.Id = 17
        Me.bbiFInd.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.find_16x16
        Me.bbiFInd.ImageOptions.LargeImage = Global.FabV24_WIN8.My.Resources.Resources.find_32x321
        Me.bbiFInd.Name = "bbiFInd"
        '
        'bbiRefresh
        '
        Me.bbiRefresh.Caption = "Show/Refresh List"
        Me.bbiRefresh.Id = 19
        Me.bbiRefresh.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.refresh_16x16
        Me.bbiRefresh.ImageOptions.LargeImage = Global.FabV24_WIN8.My.Resources.Resources.refresh_32x32
        Me.bbiRefresh.Name = "bbiRefresh"
        '
        'rpgJobManagement
        '
        Me.rpgJobManagement.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgJobs, Me.rpgProcess, Me.rpgFind})
        Me.rpgJobManagement.Name = "rpgJobManagement"
        Me.rpgJobManagement.Text = "Job Management"
        '
        'rpgJobs
        '
        Me.rpgJobs.ItemLinks.Add(Me.bbiJObsNew)
        Me.rpgJobs.ItemLinks.Add(Me.bbiJObsOpen)
        Me.rpgJobs.ItemLinks.Add(Me.biiJobsDelete)
        Me.rpgJobs.ItemLinks.Add(Me.bbiRefresh)
        Me.rpgJobs.Name = "rpgJobs"
        Me.rpgJobs.Text = "Jobs"
        Me.rpgJobs.Visible = False
        '
        'rpgProcess
        '
        Me.rpgProcess.ItemLinks.Add(Me.bbiFileManagement)
        Me.rpgProcess.ItemLinks.Add(Me.bbiShipping)
        Me.rpgProcess.Name = "rpgProcess"
        Me.rpgProcess.Text = "Process"
        '
        'rpgFind
        '
        Me.rpgFind.ItemLinks.Add(Me.bbiFInd)
        Me.rpgFind.Name = "rpgFind"
        Me.rpgFind.Text = "FInd"
        Me.rpgFind.Visible = False
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        SimpleContextButton12.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton12.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton12.Caption = "Job Name"
        SimpleContextButton12.Id = New System.Guid("5b25c471-b79d-4cc4-88f5-abd7332ea4a2")
        SimpleContextButton12.Name = "simpleContextButton1"
        SimpleContextButton13.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton13.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton13.Caption = "File Manage Type"
        SimpleContextButton13.Id = New System.Guid("37b36689-7f2b-4a06-bb55-524ef735c1af")
        SimpleContextButton13.Name = "simpleContextButton2"
        SimpleContextButton14.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton14.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton14.Caption = "File Mange Date"
        SimpleContextButton14.Id = New System.Guid("497c028c-ddee-415a-bd43-bcf2d2778261")
        SimpleContextButton14.Name = "simpleContextButton3"
        SimpleContextButton15.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton15.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton15.Caption = "Job Number"
        SimpleContextButton15.Id = New System.Guid("01c09bfe-b4b1-4a0a-a353-9208cb5af677")
        SimpleContextButton15.Name = "simpleContextButton4"
        SimpleContextButton16.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton16.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton16.Caption = "Project Location"
        SimpleContextButton16.Id = New System.Guid("8648fc3c-43be-45da-9bb0-1440da937ef0")
        SimpleContextButton16.Name = "simpleContextButton5"
        SimpleContextButton17.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton17.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton17.Caption = "Plant"
        SimpleContextButton17.Id = New System.Guid("f28fd494-0526-4a78-b41a-77639f3b7db5")
        SimpleContextButton17.Name = "simpleContextButton6"
        SimpleContextButton18.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton18.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton18.Caption = "BOM By"
        SimpleContextButton18.Id = New System.Guid("e42d4e18-95c8-458f-95e7-b54fca1b3b0d")
        SimpleContextButton18.Name = "simpleContextButton7"
        SimpleContextButton19.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton19.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton19.Caption = "BOM Date"
        SimpleContextButton19.Id = New System.Guid("5a644cd3-4746-4cbf-a6fe-ef2b831bd0d7")
        SimpleContextButton19.Name = "simpleContextButton8"
        SimpleContextButton20.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton20.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton20.Caption = "Entered By"
        SimpleContextButton20.Id = New System.Guid("f391c2a5-24d2-4349-b571-4aa7e1dec681")
        SimpleContextButton20.Name = "simpleContextButton9"
        SimpleContextButton21.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton21.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton21.Caption = "Entered Date"
        SimpleContextButton21.Id = New System.Guid("8b8d229f-1220-4c44-ab53-92ebdbff4248")
        SimpleContextButton21.Name = "simpleContextButton10"
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton12)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton13)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton14)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton15)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton16)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton17)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton18)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton19)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton20)
        Me.RepositoryItemComboBox1.ContextButtons.Add(SimpleContextButton21)
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        SimpleContextButton22.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        SimpleContextButton22.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        SimpleContextButton22.Caption = "JOb Number"
        SimpleContextButton22.Id = New System.Guid("a8173b69-b1ef-4cfd-88e3-febb1f2874fc")
        SimpleContextButton22.Name = "simpleContextButton1"
        Me.RepositoryItemComboBox2.ContextButtons.Add(SimpleContextButton22)
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"Job Name", "File Manage Type", "File Mange Date", "Job Number", "Project Location", "Plant", "BOM By", "BOM Date", "Entered By", "Entered Date"})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.Padding = New System.Windows.Forms.Padding(75)
        Me.RepositoryItemTextEdit2.ValidateOnEnterKey = True
        '
        'RepositoryItemSearchControl1
        '
        Me.RepositoryItemSearchControl1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.RepositoryItemSearchControl1.Client = Me.grdJobs
        Me.RepositoryItemSearchControl1.Items.AddRange(New Object() {"BOM By", "BOM Date", "Entered By", "Entered Date", "File Manage Type", "File Mange Date", "Job Name", "Job Number", "Plant", "Project Location"})
        Me.RepositoryItemSearchControl1.Name = "RepositoryItemSearchControl1"
        Me.RepositoryItemSearchControl1.PopupFormMinSize = New System.Drawing.Size(150, 0)
        Me.RepositoryItemSearchControl1.PopupFormSize = New System.Drawing.Size(150, 0)
        Me.RepositoryItemSearchControl1.PopupSizeable = True
        Me.RepositoryItemSearchControl1.Sorted = True
        '
        'grdJobs
        '
        Me.grdJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdJobs.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdJobs.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdJobs.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.grdJobs.Location = New System.Drawing.Point(0, 0)
        Me.grdJobs.MainView = Me.gvJobs
        Me.grdJobs.Name = "grdJobs"
        Me.grdJobs.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemLookUpEdit1, Me.repositoryItemCalcEdit1, Me.repositoryItemSpinEdit1, Me.repositoryItemTextEdit1})
        Me.grdJobs.Size = New System.Drawing.Size(1063, 438)
        Me.grdJobs.TabIndex = 6
        Me.grdJobs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvJobs})
        '
        'gvJobs
        '
        Me.gvJobs.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvJobs.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.gvJobs.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.gvJobs.Appearance.EvenRow.Options.UseBackColor = True
        Me.gvJobs.Appearance.EvenRow.Options.UseFont = True
        Me.gvJobs.Appearance.EvenRow.Options.UseForeColor = True
        Me.gvJobs.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gvJobs.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.gvJobs.Appearance.OddRow.Options.UseBackColor = True
        Me.gvJobs.Appearance.OddRow.Options.UseForeColor = True
        Me.gvJobs.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdcJobName, Me.grdcFIleManage, Me.grdcPlantLoc, Me.grdcPlant, Me.grdcBOMBy, Me.grdcBOMDate, Me.grdcEnteredBy, Me.grdcEnteredDate, Me.grdcJobID, Me.grdcJobNumber})
        Me.gvJobs.GridControl = Me.grdJobs
        Me.gvJobs.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderID", Nothing, "")})
        Me.gvJobs.Name = "gvJobs"
        Me.gvJobs.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvJobs.OptionsBehavior.Editable = False
        Me.gvJobs.OptionsBehavior.ReadOnly = True
        Me.gvJobs.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted
        Me.gvJobs.OptionsCustomization.AllowFilter = False
        Me.gvJobs.OptionsCustomization.AllowGroup = False
        Me.gvJobs.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvJobs.OptionsView.EnableAppearanceEvenRow = True
        Me.gvJobs.OptionsView.EnableAppearanceOddRow = True
        Me.gvJobs.OptionsView.ShowDetailButtons = False
        Me.gvJobs.OptionsView.ShowGroupPanel = False
        '
        'grdcJobName
        '
        Me.grdcJobName.Caption = "Job Name"
        Me.grdcJobName.FieldName = "JobName"
        Me.grdcJobName.Name = "grdcJobName"
        Me.grdcJobName.Visible = True
        Me.grdcJobName.VisibleIndex = 0
        Me.grdcJobName.Width = 230
        '
        'grdcFIleManage
        '
        Me.grdcFIleManage.Caption = "FIle Managed Date"
        Me.grdcFIleManage.Name = "grdcFIleManage"
        Me.grdcFIleManage.Visible = True
        Me.grdcFIleManage.VisibleIndex = 1
        Me.grdcFIleManage.Width = 117
        '
        'grdcPlantLoc
        '
        Me.grdcPlantLoc.Caption = "Project Location"
        Me.grdcPlantLoc.FieldName = "JobLocation"
        Me.grdcPlantLoc.Name = "grdcPlantLoc"
        Me.grdcPlantLoc.Visible = True
        Me.grdcPlantLoc.VisibleIndex = 3
        Me.grdcPlantLoc.Width = 134
        '
        'grdcPlant
        '
        Me.grdcPlant.Caption = "Plant"
        Me.grdcPlant.FieldName = "JobPlant"
        Me.grdcPlant.Name = "grdcPlant"
        Me.grdcPlant.Visible = True
        Me.grdcPlant.VisibleIndex = 4
        Me.grdcPlant.Width = 134
        '
        'grdcBOMBy
        '
        Me.grdcBOMBy.Caption = "BOM By"
        Me.grdcBOMBy.FieldName = "JobBOMBy"
        Me.grdcBOMBy.Name = "grdcBOMBy"
        Me.grdcBOMBy.Visible = True
        Me.grdcBOMBy.VisibleIndex = 5
        Me.grdcBOMBy.Width = 54
        '
        'grdcBOMDate
        '
        Me.grdcBOMDate.Caption = "BOM Date"
        Me.grdcBOMDate.FieldName = "JobBOMCreated"
        Me.grdcBOMDate.GroupFormat.FormatString = "d"
        Me.grdcBOMDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.grdcBOMDate.Name = "grdcBOMDate"
        Me.grdcBOMDate.Visible = True
        Me.grdcBOMDate.VisibleIndex = 6
        Me.grdcBOMDate.Width = 70
        '
        'grdcEnteredBy
        '
        Me.grdcEnteredBy.Caption = "Entered By"
        Me.grdcEnteredBy.FieldName = "JobEnteredBy"
        Me.grdcEnteredBy.Name = "grdcEnteredBy"
        Me.grdcEnteredBy.Visible = True
        Me.grdcEnteredBy.VisibleIndex = 7
        Me.grdcEnteredBy.Width = 68
        '
        'grdcEnteredDate
        '
        Me.grdcEnteredDate.Caption = "Entered Date"
        Me.grdcEnteredDate.FieldName = "JobEnteredDate"
        Me.grdcEnteredDate.GroupFormat.FormatString = "d"
        Me.grdcEnteredDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.grdcEnteredDate.Name = "grdcEnteredDate"
        Me.grdcEnteredDate.Visible = True
        Me.grdcEnteredDate.VisibleIndex = 8
        Me.grdcEnteredDate.Width = 192
        '
        'grdcJobID
        '
        Me.grdcJobID.Caption = "ID"
        Me.grdcJobID.FieldName = "ID"
        Me.grdcJobID.Name = "grdcJobID"
        '
        'grdcJobNumber
        '
        Me.grdcJobNumber.Caption = "Job Number"
        Me.grdcJobNumber.FieldName = "JobNum"
        Me.grdcJobNumber.Name = "grdcJobNumber"
        Me.grdcJobNumber.Visible = True
        Me.grdcJobNumber.VisibleIndex = 2
        Me.grdcJobNumber.Width = 125
        '
        'repositoryItemLookUpEdit1
        '
        Me.repositoryItemLookUpEdit1.AutoHeight = False
        Me.repositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Product Name")})
        Me.repositoryItemLookUpEdit1.DisplayMember = "ProductName"
        Me.repositoryItemLookUpEdit1.DropDownRows = 10
        Me.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1"
        Me.repositoryItemLookUpEdit1.PopupWidth = 220
        Me.repositoryItemLookUpEdit1.ValueMember = "ProductID"
        '
        'repositoryItemCalcEdit1
        '
        Me.repositoryItemCalcEdit1.AutoHeight = False
        Me.repositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemCalcEdit1.Mask.EditMask = "c"
        Me.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1"
        '
        'repositoryItemSpinEdit1
        '
        Me.repositoryItemSpinEdit1.AutoHeight = False
        Me.repositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.repositoryItemSpinEdit1.IsFloatValue = False
        Me.repositoryItemSpinEdit1.Mask.EditMask = "N00"
        Me.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1"
        '
        'repositoryItemTextEdit1
        '
        Me.repositoryItemTextEdit1.AutoHeight = False
        Me.repositoryItemTextEdit1.Mask.EditMask = "p"
        Me.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 610)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.rbcDataEntry
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1068, 23)
        '
        'xtcJobs
        '
        Me.xtcJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xtcJobs.HeaderButtons = DevExpress.XtraTab.TabButtons.None
        Me.xtcJobs.Location = New System.Drawing.Point(0, 147)
        Me.xtcJobs.Name = "xtcJobs"
        Me.xtcJobs.SelectedTabPage = Me.xtpJobs
        Me.xtcJobs.Size = New System.Drawing.Size(1068, 463)
        Me.xtcJobs.TabIndex = 10
        Me.xtcJobs.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpJobs, Me.xtpFileManagement, Me.xtpShipping, Me.xtpFind})
        '
        'xtpJobs
        '
        Me.xtpJobs.Controls.Add(Me.grdJobs)
        Me.xtpJobs.Name = "xtpJobs"
        Me.xtpJobs.PageVisible = False
        Me.xtpJobs.Size = New System.Drawing.Size(1063, 438)
        Me.xtpJobs.Text = "Jobs"
        '
        'xtpFileManagement
        '
        Me.xtpFileManagement.Controls.Add(Me.grpcCopyTo)
        Me.xtpFileManagement.Name = "xtpFileManagement"
        Me.xtpFileManagement.Size = New System.Drawing.Size(1063, 438)
        Me.xtpFileManagement.Text = "File Management"
        '
        'grpcCopyTo
        '
        Me.grpcCopyTo.Controls.Add(Me.beRPTToFolder)
        Me.grpcCopyTo.Controls.Add(Me.lblRPTToFolder)
        Me.grpcCopyTo.Controls.Add(Me.bePDBToFolder)
        Me.grpcCopyTo.Controls.Add(Me.lblPDBToFolder)
        Me.grpcCopyTo.Controls.Add(Me.beCADToFolder)
        Me.grpcCopyTo.Controls.Add(Me.lblCADToFolder)
        Me.grpcCopyTo.Controls.Add(Me.beCNCToFolder)
        Me.grpcCopyTo.Controls.Add(Me.lblCNCToFolder)
        Me.grpcCopyTo.Controls.Add(Me.beNSTToFolder)
        Me.grpcCopyTo.Controls.Add(Me.lblNSTToFolder)
        Me.grpcCopyTo.Controls.Add(Me.lbcCopyMove)
        Me.grpcCopyTo.Controls.Add(Me.beMM2ToFolder)
        Me.grpcCopyTo.Controls.Add(Me.sbCopyMoveExecute)
        Me.grpcCopyTo.Controls.Add(Me.lblMM2ToFolder)
        Me.grpcCopyTo.Controls.Add(Me.beCopyMoveRPT)
        Me.grpcCopyTo.Controls.Add(Me.chkCopyMoveRPT)
        Me.grpcCopyTo.Controls.Add(Me.beCopyMoveCNC)
        Me.grpcCopyTo.Controls.Add(Me.chkCopyMoveCNC)
        Me.grpcCopyTo.Controls.Add(Me.beCopyMovePDB)
        Me.grpcCopyTo.Controls.Add(Me.chkCopyMovePDB)
        Me.grpcCopyTo.Controls.Add(Me.beCopyMoveNST)
        Me.grpcCopyTo.Controls.Add(Me.chkCopyMoveNST)
        Me.grpcCopyTo.Controls.Add(Me.beCopyMoveCad)
        Me.grpcCopyTo.Controls.Add(Me.chkCopyMoveCad)
        Me.grpcCopyTo.Controls.Add(Me.beCopyMoveMM2)
        Me.grpcCopyTo.Controls.Add(Me.chkCopyMoveMM2)
        Me.grpcCopyTo.Controls.Add(Me.lblCopyMove)
        Me.grpcCopyTo.Controls.Add(Me.cboCopyMove)
        Me.grpcCopyTo.Location = New System.Drawing.Point(12, 18)
        Me.grpcCopyTo.Name = "grpcCopyTo"
        Me.grpcCopyTo.Size = New System.Drawing.Size(1044, 262)
        Me.grpcCopyTo.TabIndex = 14
        Me.grpcCopyTo.Text = "Copy/Move To?"
        '
        'beRPTToFolder
        '
        Me.beRPTToFolder.Location = New System.Drawing.Point(621, 183)
        Me.beRPTToFolder.MenuManager = Me.rbcDataEntry
        Me.beRPTToFolder.Name = "beRPTToFolder"
        Me.beRPTToFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beRPTToFolder.Size = New System.Drawing.Size(418, 20)
        Me.beRPTToFolder.TabIndex = 12
        '
        'lblRPTToFolder
        '
        Me.lblRPTToFolder.Location = New System.Drawing.Point(531, 186)
        Me.lblRPTToFolder.Name = "lblRPTToFolder"
        Me.lblRPTToFolder.Size = New System.Drawing.Size(84, 13)
        Me.lblRPTToFolder.TabIndex = 27
        Me.lblRPTToFolder.Text = "Report  To Folder"
        '
        'bePDBToFolder
        '
        Me.bePDBToFolder.Location = New System.Drawing.Point(621, 157)
        Me.bePDBToFolder.MenuManager = Me.rbcDataEntry
        Me.bePDBToFolder.Name = "bePDBToFolder"
        Me.bePDBToFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.bePDBToFolder.Size = New System.Drawing.Size(418, 20)
        Me.bePDBToFolder.TabIndex = 10
        '
        'lblPDBToFolder
        '
        Me.lblPDBToFolder.Location = New System.Drawing.Point(545, 160)
        Me.lblPDBToFolder.Name = "lblPDBToFolder"
        Me.lblPDBToFolder.Size = New System.Drawing.Size(67, 13)
        Me.lblPDBToFolder.TabIndex = 25
        Me.lblPDBToFolder.Text = "PDB To Folder"
        '
        'beCADToFolder
        '
        Me.beCADToFolder.Location = New System.Drawing.Point(621, 131)
        Me.beCADToFolder.MenuManager = Me.rbcDataEntry
        Me.beCADToFolder.Name = "beCADToFolder"
        Me.beCADToFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCADToFolder.Size = New System.Drawing.Size(418, 20)
        Me.beCADToFolder.TabIndex = 8
        '
        'lblCADToFolder
        '
        Me.lblCADToFolder.Location = New System.Drawing.Point(545, 134)
        Me.lblCADToFolder.Name = "lblCADToFolder"
        Me.lblCADToFolder.Size = New System.Drawing.Size(69, 13)
        Me.lblCADToFolder.TabIndex = 23
        Me.lblCADToFolder.Text = "CAD To Folder"
        '
        'beCNCToFolder
        '
        Me.beCNCToFolder.Location = New System.Drawing.Point(621, 105)
        Me.beCNCToFolder.MenuManager = Me.rbcDataEntry
        Me.beCNCToFolder.Name = "beCNCToFolder"
        Me.beCNCToFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCNCToFolder.Size = New System.Drawing.Size(418, 20)
        Me.beCNCToFolder.TabIndex = 6
        '
        'lblCNCToFolder
        '
        Me.lblCNCToFolder.Location = New System.Drawing.Point(545, 108)
        Me.lblCNCToFolder.Name = "lblCNCToFolder"
        Me.lblCNCToFolder.Size = New System.Drawing.Size(69, 13)
        Me.lblCNCToFolder.TabIndex = 21
        Me.lblCNCToFolder.Text = "CNC To Folder"
        '
        'beNSTToFolder
        '
        Me.beNSTToFolder.Location = New System.Drawing.Point(621, 78)
        Me.beNSTToFolder.MenuManager = Me.rbcDataEntry
        Me.beNSTToFolder.Name = "beNSTToFolder"
        Me.beNSTToFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beNSTToFolder.Size = New System.Drawing.Size(418, 20)
        Me.beNSTToFolder.TabIndex = 4
        '
        'lblNSTToFolder
        '
        Me.lblNSTToFolder.Location = New System.Drawing.Point(545, 81)
        Me.lblNSTToFolder.Name = "lblNSTToFolder"
        Me.lblNSTToFolder.Size = New System.Drawing.Size(67, 13)
        Me.lblNSTToFolder.TabIndex = 19
        Me.lblNSTToFolder.Text = "NST To Folder"
        '
        'lbcCopyMove
        '
        Me.lbcCopyMove.Location = New System.Drawing.Point(12, 357)
        Me.lbcCopyMove.Name = "lbcCopyMove"
        Me.lbcCopyMove.Size = New System.Drawing.Size(234, 45)
        Me.lbcCopyMove.TabIndex = 18
        Me.lbcCopyMove.Visible = False
        '
        'beMM2ToFolder
        '
        Me.beMM2ToFolder.Location = New System.Drawing.Point(621, 52)
        Me.beMM2ToFolder.MenuManager = Me.rbcDataEntry
        Me.beMM2ToFolder.Name = "beMM2ToFolder"
        Me.beMM2ToFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beMM2ToFolder.Size = New System.Drawing.Size(418, 20)
        Me.beMM2ToFolder.TabIndex = 2
        '
        'sbCopyMoveExecute
        '
        Me.sbCopyMoveExecute.Location = New System.Drawing.Point(313, 218)
        Me.sbCopyMoveExecute.Name = "sbCopyMoveExecute"
        Me.sbCopyMoveExecute.Size = New System.Drawing.Size(418, 23)
        Me.sbCopyMoveExecute.TabIndex = 13
        Me.sbCopyMoveExecute.Text = "Execute"
        '
        'lblMM2ToFolder
        '
        Me.lblMM2ToFolder.Location = New System.Drawing.Point(545, 55)
        Me.lblMM2ToFolder.Name = "lblMM2ToFolder"
        Me.lblMM2ToFolder.Size = New System.Drawing.Size(70, 13)
        Me.lblMM2ToFolder.TabIndex = 15
        Me.lblMM2ToFolder.Text = "MM2 To Folder"
        '
        'beCopyMoveRPT
        '
        Me.beCopyMoveRPT.Location = New System.Drawing.Point(108, 182)
        Me.beCopyMoveRPT.MenuManager = Me.rbcDataEntry
        Me.beCopyMoveRPT.Name = "beCopyMoveRPT"
        Me.beCopyMoveRPT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCopyMoveRPT.Size = New System.Drawing.Size(418, 20)
        Me.beCopyMoveRPT.TabIndex = 11
        '
        'chkCopyMoveRPT
        '
        Me.chkCopyMoveRPT.AutoSizeInLayoutControl = True
        Me.chkCopyMoveRPT.Location = New System.Drawing.Point(12, 182)
        Me.chkCopyMoveRPT.MenuManager = Me.rbcDataEntry
        Me.chkCopyMoveRPT.Name = "chkCopyMoveRPT"
        Me.chkCopyMoveRPT.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkCopyMoveRPT.Properties.Appearance.Options.UseBackColor = True
        Me.chkCopyMoveRPT.Properties.Caption = "Report FIles"
        Me.chkCopyMoveRPT.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkCopyMoveRPT.Size = New System.Drawing.Size(90, 19)
        Me.chkCopyMoveRPT.TabIndex = 12
        '
        'beCopyMoveCNC
        '
        Me.beCopyMoveCNC.Location = New System.Drawing.Point(108, 104)
        Me.beCopyMoveCNC.MenuManager = Me.rbcDataEntry
        Me.beCopyMoveCNC.Name = "beCopyMoveCNC"
        Me.beCopyMoveCNC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCopyMoveCNC.Size = New System.Drawing.Size(418, 20)
        Me.beCopyMoveCNC.TabIndex = 5
        '
        'chkCopyMoveCNC
        '
        Me.chkCopyMoveCNC.Location = New System.Drawing.Point(27, 105)
        Me.chkCopyMoveCNC.MenuManager = Me.rbcDataEntry
        Me.chkCopyMoveCNC.Name = "chkCopyMoveCNC"
        Me.chkCopyMoveCNC.Properties.Caption = "CNC files"
        Me.chkCopyMoveCNC.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkCopyMoveCNC.Size = New System.Drawing.Size(75, 19)
        Me.chkCopyMoveCNC.TabIndex = 10
        '
        'beCopyMovePDB
        '
        Me.beCopyMovePDB.Location = New System.Drawing.Point(108, 156)
        Me.beCopyMovePDB.MenuManager = Me.rbcDataEntry
        Me.beCopyMovePDB.Name = "beCopyMovePDB"
        Me.beCopyMovePDB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCopyMovePDB.Size = New System.Drawing.Size(418, 20)
        Me.beCopyMovePDB.TabIndex = 9
        '
        'chkCopyMovePDB
        '
        Me.chkCopyMovePDB.Location = New System.Drawing.Point(27, 156)
        Me.chkCopyMovePDB.MenuManager = Me.rbcDataEntry
        Me.chkCopyMovePDB.Name = "chkCopyMovePDB"
        Me.chkCopyMovePDB.Properties.Caption = "PDB FIles"
        Me.chkCopyMovePDB.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkCopyMovePDB.Size = New System.Drawing.Size(75, 19)
        Me.chkCopyMovePDB.TabIndex = 8
        '
        'beCopyMoveNST
        '
        Me.beCopyMoveNST.Location = New System.Drawing.Point(108, 78)
        Me.beCopyMoveNST.MenuManager = Me.rbcDataEntry
        Me.beCopyMoveNST.Name = "beCopyMoveNST"
        Me.beCopyMoveNST.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCopyMoveNST.Size = New System.Drawing.Size(418, 20)
        Me.beCopyMoveNST.TabIndex = 3
        '
        'chkCopyMoveNST
        '
        Me.chkCopyMoveNST.Location = New System.Drawing.Point(27, 78)
        Me.chkCopyMoveNST.MenuManager = Me.rbcDataEntry
        Me.chkCopyMoveNST.Name = "chkCopyMoveNST"
        Me.chkCopyMoveNST.Properties.Caption = "NST Files"
        Me.chkCopyMoveNST.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkCopyMoveNST.Size = New System.Drawing.Size(75, 19)
        Me.chkCopyMoveNST.TabIndex = 6
        '
        'beCopyMoveCad
        '
        Me.beCopyMoveCad.Location = New System.Drawing.Point(108, 130)
        Me.beCopyMoveCad.MenuManager = Me.rbcDataEntry
        Me.beCopyMoveCad.Name = "beCopyMoveCad"
        Me.beCopyMoveCad.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCopyMoveCad.Size = New System.Drawing.Size(418, 20)
        Me.beCopyMoveCad.TabIndex = 7
        '
        'chkCopyMoveCad
        '
        Me.chkCopyMoveCad.Location = New System.Drawing.Point(25, 130)
        Me.chkCopyMoveCad.MenuManager = Me.rbcDataEntry
        Me.chkCopyMoveCad.Name = "chkCopyMoveCad"
        Me.chkCopyMoveCad.Properties.Caption = "CAD FIles"
        Me.chkCopyMoveCad.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkCopyMoveCad.Size = New System.Drawing.Size(77, 19)
        Me.chkCopyMoveCad.TabIndex = 4
        '
        'beCopyMoveMM2
        '
        Me.beCopyMoveMM2.Location = New System.Drawing.Point(108, 52)
        Me.beCopyMoveMM2.MenuManager = Me.rbcDataEntry
        Me.beCopyMoveMM2.Name = "beCopyMoveMM2"
        Me.beCopyMoveMM2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCopyMoveMM2.Size = New System.Drawing.Size(418, 20)
        Me.beCopyMoveMM2.TabIndex = 1
        '
        'chkCopyMoveMM2
        '
        Me.chkCopyMoveMM2.Location = New System.Drawing.Point(27, 52)
        Me.chkCopyMoveMM2.MenuManager = Me.rbcDataEntry
        Me.chkCopyMoveMM2.Name = "chkCopyMoveMM2"
        Me.chkCopyMoveMM2.Properties.Caption = "MM2 Files"
        Me.chkCopyMoveMM2.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkCopyMoveMM2.Size = New System.Drawing.Size(75, 19)
        Me.chkCopyMoveMM2.TabIndex = 2
        '
        'lblCopyMove
        '
        Me.lblCopyMove.Location = New System.Drawing.Point(454, 28)
        Me.lblCopyMove.Name = "lblCopyMove"
        Me.lblCopyMove.Size = New System.Drawing.Size(30, 13)
        Me.lblCopyMove.TabIndex = 1
        Me.lblCopyMove.Text = "Mode:"
        '
        'cboCopyMove
        '
        Me.cboCopyMove.Location = New System.Drawing.Point(490, 25)
        Me.cboCopyMove.MenuManager = Me.rbcDataEntry
        Me.cboCopyMove.Name = "cboCopyMove"
        Me.cboCopyMove.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCopyMove.Properties.Items.AddRange(New Object() {"Copy", "Move", "Archive", "Delete"})
        Me.cboCopyMove.Size = New System.Drawing.Size(100, 20)
        Me.cboCopyMove.TabIndex = 0
        '
        'xtpShipping
        '
        Me.xtpShipping.Controls.Add(Me.gcShippingPurchaser)
        Me.xtpShipping.Controls.Add(Me.gcShippingInfo)
        Me.xtpShipping.Name = "xtpShipping"
        Me.xtpShipping.PageVisible = False
        Me.xtpShipping.Size = New System.Drawing.Size(1063, 438)
        Me.xtpShipping.Text = "Shipping"
        '
        'gcShippingPurchaser
        '
        Me.gcShippingPurchaser.Controls.Add(Me.vgridShippingPurchaser)
        Me.gcShippingPurchaser.Location = New System.Drawing.Point(526, 14)
        Me.gcShippingPurchaser.Name = "gcShippingPurchaser"
        Me.gcShippingPurchaser.Size = New System.Drawing.Size(450, 309)
        Me.gcShippingPurchaser.TabIndex = 1
        Me.gcShippingPurchaser.Text = "Purchaser Information"
        '
        'vgridShippingPurchaser
        '
        Me.vgridShippingPurchaser.Cursor = System.Windows.Forms.Cursors.Default
        Me.vgridShippingPurchaser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgridShippingPurchaser.Location = New System.Drawing.Point(2, 22)
        Me.vgridShippingPurchaser.Name = "vgridShippingPurchaser"
        Me.vgridShippingPurchaser.RecordWidth = 334
        Me.vgridShippingPurchaser.RowHeaderWidth = 104
        Me.vgridShippingPurchaser.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPurchCustomer, Me.RowPurchAdd1, Me.rowPurchAdd2, Me.rowPurchCity, Me.rowPurchStateProv, Me.rowPurchPostalCode, Me.rowPurchCountry, Me.rowPurchPhone})
        Me.vgridShippingPurchaser.Size = New System.Drawing.Size(446, 285)
        Me.vgridShippingPurchaser.TabIndex = 0
        '
        'rowPurchCustomer
        '
        Me.rowPurchCustomer.Name = "rowPurchCustomer"
        Me.rowPurchCustomer.Properties.Caption = "Customer"
        '
        'RowPurchAdd1
        '
        Me.RowPurchAdd1.Name = "RowPurchAdd1"
        Me.RowPurchAdd1.Properties.Caption = "Adress 1"
        '
        'rowPurchAdd2
        '
        Me.rowPurchAdd2.Name = "rowPurchAdd2"
        Me.rowPurchAdd2.Properties.Caption = "Adress 2"
        '
        'rowPurchCity
        '
        Me.rowPurchCity.Name = "rowPurchCity"
        Me.rowPurchCity.Properties.Caption = "City"
        '
        'rowPurchStateProv
        '
        Me.rowPurchStateProv.Name = "rowPurchStateProv"
        Me.rowPurchStateProv.Properties.Caption = "State/Province"
        '
        'rowPurchPostalCode
        '
        Me.rowPurchPostalCode.Name = "rowPurchPostalCode"
        Me.rowPurchPostalCode.Properties.Caption = "Zip/PostalCode"
        '
        'rowPurchCountry
        '
        Me.rowPurchCountry.Name = "rowPurchCountry"
        Me.rowPurchCountry.Properties.Caption = "Country"
        '
        'rowPurchPhone
        '
        Me.rowPurchPhone.Name = "rowPurchPhone"
        Me.rowPurchPhone.Properties.Caption = "Phone"
        '
        'gcShippingInfo
        '
        Me.gcShippingInfo.Controls.Add(Me.vgridShippingInfo)
        Me.gcShippingInfo.Location = New System.Drawing.Point(11, 14)
        Me.gcShippingInfo.Name = "gcShippingInfo"
        Me.gcShippingInfo.Size = New System.Drawing.Size(450, 311)
        Me.gcShippingInfo.TabIndex = 0
        Me.gcShippingInfo.Text = "Shipping Information"
        '
        'vgridShippingInfo
        '
        Me.vgridShippingInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.vgridShippingInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgridShippingInfo.Location = New System.Drawing.Point(2, 22)
        Me.vgridShippingInfo.Name = "vgridShippingInfo"
        Me.vgridShippingInfo.RecordWidth = 300
        Me.vgridShippingInfo.RowHeaderWidth = 138
        Me.vgridShippingInfo.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowShipJobNum, Me.rowShipDate, Me.rowShipCustomer, Me.rowShipAdd1, Me.rowShipAdd2, Me.rowShipCity, Me.rowShipStateProv, Me.rowShipPostalCode, Me.rowShipCountry, Me.rowShipAttn, Me.rowShipPhone, Me.rowShipCarrier, Me.rowShipTruckNum, Me.rowShipPo, Me.rowShipFreight})
        Me.vgridShippingInfo.Size = New System.Drawing.Size(446, 287)
        Me.vgridShippingInfo.TabIndex = 0
        '
        'rowShipJobNum
        '
        Me.rowShipJobNum.Name = "rowShipJobNum"
        Me.rowShipJobNum.Properties.Caption = "Our Job Number"
        '
        'rowShipDate
        '
        Me.rowShipDate.Name = "rowShipDate"
        Me.rowShipDate.Properties.Caption = "Date"
        '
        'rowShipCustomer
        '
        Me.rowShipCustomer.Name = "rowShipCustomer"
        Me.rowShipCustomer.Properties.Caption = "Customer"
        '
        'rowShipAdd1
        '
        Me.rowShipAdd1.Name = "rowShipAdd1"
        Me.rowShipAdd1.Properties.Caption = "Address 1"
        '
        'rowShipAdd2
        '
        Me.rowShipAdd2.Name = "rowShipAdd2"
        Me.rowShipAdd2.Properties.Caption = "Adress 2"
        '
        'rowShipCity
        '
        Me.rowShipCity.Name = "rowShipCity"
        Me.rowShipCity.Properties.Caption = "City"
        '
        'rowShipStateProv
        '
        Me.rowShipStateProv.Name = "rowShipStateProv"
        Me.rowShipStateProv.Properties.Caption = "State/Province"
        '
        'rowShipPostalCode
        '
        Me.rowShipPostalCode.Name = "rowShipPostalCode"
        Me.rowShipPostalCode.Properties.Caption = "Zip/Postal Code"
        '
        'rowShipCountry
        '
        Me.rowShipCountry.Name = "rowShipCountry"
        Me.rowShipCountry.Properties.Caption = "Country"
        '
        'rowShipAttn
        '
        Me.rowShipAttn.Name = "rowShipAttn"
        Me.rowShipAttn.Properties.Caption = "Attn:"
        '
        'rowShipPhone
        '
        Me.rowShipPhone.Name = "rowShipPhone"
        Me.rowShipPhone.Properties.Caption = "Phone"
        '
        'rowShipCarrier
        '
        Me.rowShipCarrier.Name = "rowShipCarrier"
        Me.rowShipCarrier.Properties.Caption = "Carrier"
        '
        'rowShipTruckNum
        '
        Me.rowShipTruckNum.Name = "rowShipTruckNum"
        Me.rowShipTruckNum.Properties.Caption = "Truck#"
        '
        'rowShipPo
        '
        Me.rowShipPo.Name = "rowShipPo"
        Me.rowShipPo.Properties.Caption = "Customer PO"
        '
        'rowShipFreight
        '
        Me.rowShipFreight.Name = "rowShipFreight"
        Me.rowShipFreight.Properties.Caption = "Freight"
        '
        'xtpFind
        '
        Me.xtpFind.Controls.Add(Me.SpreadsheetControl1)
        Me.xtpFind.Controls.Add(Me.DateEdit4)
        Me.xtpFind.Controls.Add(Me.LabelControl3)
        Me.xtpFind.Controls.Add(Me.DateEdit5)
        Me.xtpFind.Controls.Add(Me.LabelControl4)
        Me.xtpFind.Controls.Add(Me.DateEdit2)
        Me.xtpFind.Controls.Add(Me.LabelControl1)
        Me.xtpFind.Controls.Add(Me.DateEdit3)
        Me.xtpFind.Controls.Add(Me.LabelControl2)
        Me.xtpFind.Controls.Add(Me.DateEdit1)
        Me.xtpFind.Controls.Add(Me.lblDateModifiedTo)
        Me.xtpFind.Controls.Add(Me.deModified_1)
        Me.xtpFind.Controls.Add(Me.lblDateModify)
        Me.xtpFind.Name = "xtpFind"
        Me.xtpFind.PageVisible = False
        Me.xtpFind.Size = New System.Drawing.Size(1063, 438)
        Me.xtpFind.Text = "Find"
        '
        'SpreadsheetControl1
        '
        Me.SpreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SpreadsheetControl1.Location = New System.Drawing.Point(314, 0)
        Me.SpreadsheetControl1.MenuManager = Me.rbcDataEntry
        Me.SpreadsheetControl1.Name = "SpreadsheetControl1"
        Me.SpreadsheetControl1.Options.Import.Csv.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Csv.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.Import.Txt.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Txt.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Size = New System.Drawing.Size(749, 438)
        Me.SpreadsheetControl1.TabIndex = 12
        Me.SpreadsheetControl1.Text = "SpreadsheetControl1"
        '
        'DateEdit4
        '
        Me.DateEdit4.EditValue = Nothing
        Me.DateEdit4.Location = New System.Drawing.Point(187, 161)
        Me.DateEdit4.MenuManager = Me.rbcDataEntry
        Me.DateEdit4.Name = "DateEdit4"
        Me.DateEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit4.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit4.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit4.TabIndex = 11
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(167, 164)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(14, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "To"
        '
        'DateEdit5
        '
        Me.DateEdit5.EditValue = Nothing
        Me.DateEdit5.Location = New System.Drawing.Point(61, 161)
        Me.DateEdit5.MenuManager = Me.rbcDataEntry
        Me.DateEdit5.Name = "DateEdit5"
        Me.DateEdit5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit5.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit5.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit5.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(98, 142)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(144, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Date Copy/Move/Archied"
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(187, 104)
        Me.DateEdit2.MenuManager = Me.rbcDataEntry
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit2.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(167, 107)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(14, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "To"
        '
        'DateEdit3
        '
        Me.DateEdit3.EditValue = Nothing
        Me.DateEdit3.Location = New System.Drawing.Point(61, 104)
        Me.DateEdit3.MenuManager = Me.rbcDataEntry
        Me.DateEdit3.Name = "DateEdit3"
        Me.DateEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit3.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(137, 85)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Date Created"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(187, 43)
        Me.DateEdit1.MenuManager = Me.rbcDataEntry
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit1.TabIndex = 3
        '
        'lblDateModifiedTo
        '
        Me.lblDateModifiedTo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDateModifiedTo.Appearance.Options.UseFont = True
        Me.lblDateModifiedTo.Location = New System.Drawing.Point(167, 46)
        Me.lblDateModifiedTo.Name = "lblDateModifiedTo"
        Me.lblDateModifiedTo.Size = New System.Drawing.Size(14, 13)
        Me.lblDateModifiedTo.TabIndex = 2
        Me.lblDateModifiedTo.Text = "To"
        '
        'deModified_1
        '
        Me.deModified_1.EditValue = Nothing
        Me.deModified_1.Location = New System.Drawing.Point(61, 43)
        Me.deModified_1.MenuManager = Me.rbcDataEntry
        Me.deModified_1.Name = "deModified_1"
        Me.deModified_1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deModified_1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deModified_1.Size = New System.Drawing.Size(100, 20)
        Me.deModified_1.TabIndex = 1
        '
        'lblDateModify
        '
        Me.lblDateModify.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDateModify.Appearance.Options.UseFont = True
        Me.lblDateModify.Location = New System.Drawing.Point(137, 24)
        Me.lblDateModify.Name = "lblDateModify"
        Me.lblDateModify.Size = New System.Drawing.Size(75, 13)
        Me.lblDateModify.TabIndex = 0
        Me.lblDateModify.Text = "Date Modifed"
        '
        'icLarge
        '
        Me.icLarge.ImageStream = CType(resources.GetObject("icLarge.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.icLarge.Images.SetKeyName(0, "cabinet-icon-9272.png")
        '
        'frmFilemaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 633)
        Me.Controls.Add(Me.xtcJobs)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.rbcDataEntry)
        Me.Name = "frmFilemaintenance"
        Me.Ribbon = Me.rbcDataEntry
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "File and Job Management"
        CType(Me.rbcDataEntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdJobs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvJobs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtcJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcJobs.ResumeLayout(False)
        Me.xtpJobs.ResumeLayout(False)
        Me.xtpFileManagement.ResumeLayout(False)
        CType(Me.grpcCopyTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpcCopyTo.ResumeLayout(False)
        Me.grpcCopyTo.PerformLayout()
        CType(Me.beRPTToFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bePDBToFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCADToFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCNCToFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beNSTToFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcCopyMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beMM2ToFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCopyMoveRPT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopyMoveRPT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCopyMoveCNC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopyMoveCNC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCopyMovePDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopyMovePDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCopyMoveNST.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopyMoveNST.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCopyMoveCad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopyMoveCad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCopyMoveMM2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopyMoveMM2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCopyMove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtpShipping.ResumeLayout(False)
        CType(Me.gcShippingPurchaser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcShippingPurchaser.ResumeLayout(False)
        CType(Me.vgridShippingPurchaser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcShippingInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcShippingInfo.ResumeLayout(False)
        CType(Me.vgridShippingInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtpFind.ResumeLayout(False)
        Me.xtpFind.PerformLayout()
        CType(Me.DateEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit5.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deModified_1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deModified_1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icLarge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rbcDataEntry As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rpgJobManagement As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgJobs As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents xtcJobs As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpFileManagement As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtpJobs As DevExpress.XtraTab.XtraTabPage
    Private WithEvents grdJobs As DevExpress.XtraGrid.GridControl
    Private WithEvents gvJobs As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents grdcJobName As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grdcJobNumber As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grdcPlantLoc As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grdcPlant As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grdcBOMBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcBOMDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcEnteredBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcEnteredDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcJobID As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents repositoryItemLookUpEdit1 As Repository.RepositoryItemLookUpEdit
    Private WithEvents repositoryItemCalcEdit1 As Repository.RepositoryItemCalcEdit
    Private WithEvents repositoryItemSpinEdit1 As Repository.RepositoryItemSpinEdit
    Private WithEvents repositoryItemTextEdit1 As Repository.RepositoryItemTextEdit
    Friend WithEvents xtpShipping As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcShippingPurchaser As GroupControl
    Friend WithEvents vgridShippingPurchaser As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents rowPurchCustomer As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents RowPurchAdd1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPurchAdd2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPurchCity As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPurchStateProv As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPurchPostalCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPurchCountry As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPurchPhone As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents gcShippingInfo As GroupControl
    Friend WithEvents vgridShippingInfo As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents rowShipJobNum As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipCustomer As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipAdd1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipAdd2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipCity As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipStateProv As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipPostalCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipCountry As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipAttn As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipPhone As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipCarrier As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipTruckNum As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipPo As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowShipFreight As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents icLarge As DevExpress.Utils.ImageCollection
    Friend WithEvents grdcFIleManage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grpcCopyTo As GroupControl
    Friend WithEvents lblCopyMove As LabelControl
    Friend WithEvents cboCopyMove As ComboBoxEdit
    Friend WithEvents beCopyMoveRPT As ButtonEdit
    Friend WithEvents chkCopyMoveRPT As CheckEdit
    Friend WithEvents beCopyMoveCNC As ButtonEdit
    Friend WithEvents chkCopyMoveCNC As CheckEdit
    Friend WithEvents beCopyMovePDB As ButtonEdit
    Friend WithEvents chkCopyMovePDB As CheckEdit
    Friend WithEvents beCopyMoveNST As ButtonEdit
    Friend WithEvents chkCopyMoveNST As CheckEdit
    Friend WithEvents beCopyMoveCad As ButtonEdit
    Friend WithEvents chkCopyMoveCad As CheckEdit
    Friend WithEvents beCopyMoveMM2 As ButtonEdit
    Friend WithEvents chkCopyMoveMM2 As CheckEdit
    Friend WithEvents bbiJObsNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiJObsOpen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents biiJobsDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiFileManagement As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgProcess As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiShipping As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgFind As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RepositoryItemComboBox1 As Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemComboBox2 As Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemSearchControl1 As Repository.RepositoryItemSearchControl
    Friend WithEvents RepositoryItemTextEdit2 As Repository.RepositoryItemTextEdit
    Friend WithEvents bbiFInd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents xtpFind As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DateEdit4 As DateEdit
    Friend WithEvents LabelControl3 As LabelControl
    Friend WithEvents DateEdit5 As DateEdit
    Friend WithEvents LabelControl4 As LabelControl
    Friend WithEvents DateEdit2 As DateEdit
    Friend WithEvents LabelControl1 As LabelControl
    Friend WithEvents DateEdit3 As DateEdit
    Friend WithEvents LabelControl2 As LabelControl
    Friend WithEvents DateEdit1 As DateEdit
    Friend WithEvents lblDateModifiedTo As LabelControl
    Friend WithEvents deModified_1 As DateEdit
    Friend WithEvents lblDateModify As LabelControl
    Friend WithEvents SpreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
    Friend WithEvents lblMM2ToFolder As LabelControl
    'Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents sbCopyMoveExecute As SimpleButton
    Friend WithEvents beMM2ToFolder As ButtonEdit
    Friend WithEvents lbcCopyMove As ListBoxControl
    Friend WithEvents beRPTToFolder As ButtonEdit
    Friend WithEvents lblRPTToFolder As LabelControl
    Friend WithEvents bePDBToFolder As ButtonEdit
    Friend WithEvents lblPDBToFolder As LabelControl
    Friend WithEvents beCADToFolder As ButtonEdit
    Friend WithEvents lblCADToFolder As LabelControl
    Friend WithEvents beCNCToFolder As ButtonEdit
    Friend WithEvents lblCNCToFolder As LabelControl
    Friend WithEvents beNSTToFolder As ButtonEdit
    Friend WithEvents lblNSTToFolder As LabelControl
End Class
