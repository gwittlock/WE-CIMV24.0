<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewMRP
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
        Dim SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewMRP))
        Me.gcMainButtons = New DevExpress.XtraEditors.GroupControl()
        Me.lstPDBNames = New DevExpress.XtraEditors.ListBoxControl()
        Me.tbFieldValues = New System.Windows.Forms.TextBox()
        Me.tbFieldNames = New System.Windows.Forms.TextBox()
        Me.lbOptions = New DevExpress.XtraEditors.ListBoxControl()
        Me.sbFinish = New DevExpress.XtraEditors.SimpleButton()
        Me.sbNext = New DevExpress.XtraEditors.SimpleButton()
        Me.sbBack = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.xtcMRP = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.tebOderPO = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.tebCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeLeadSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeLayerSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeMaterial = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeToolSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeMachine = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GroupControl7 = New DevExpress.XtraEditors.GroupControl()
        Me.fcbImportFIle = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblMRPImportFile = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.cboSheetTable = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.fcbSourceFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.lcbFileType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkAppendMat = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCopySource = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHasPath = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHeader = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControl8 = New DevExpress.XtraEditors.GroupControl()
        Me.rgMrpFileType = New DevExpress.XtraEditors.RadioGroup()
        Me.gcSpacer = New DevExpress.XtraEditors.GroupControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.SpreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiUnlink = New DevExpress.XtraBars.BarButtonItem()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.TV_MappedFields = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TV_NestConfig = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TV_UserFields = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.GroupControl9 = New DevExpress.XtraEditors.GroupControl()
        Me.ceMaterialToLayerSetup = New DevExpress.XtraEditors.CheckEdit()
        Me.ceMaterialToToolSetup = New DevExpress.XtraEditors.CheckEdit()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.gcFileFromMRP = New DevExpress.XtraEditors.GroupControl()
        Me.lbcFilesFromMrp = New DevExpress.XtraEditors.ListBoxControl()
        Me.GroupControl10 = New DevExpress.XtraEditors.GroupControl()
        Me.ListBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
        Me.lbcFilesNotFound = New DevExpress.XtraEditors.ListBoxControl()
        Me.GroupControl11 = New DevExpress.XtraEditors.GroupControl()
        Me.lbcFoundFiles = New DevExpress.XtraEditors.ListBoxControl()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl17 = New DevExpress.XtraEditors.GroupControl()
        Me.optPDBName = New DevExpress.XtraEditors.RadioGroup()
        Me.teImportFilename = New DevExpress.XtraEditors.TextEdit()
        Me.teProvidedName = New DevExpress.XtraEditors.TextEdit()
        Me.cboFieldName = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GroupControl18 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeAndThenBy = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeThenBy = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeSortBy = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeAndThenBy2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkAndThenBy = New DevExpress.XtraEditors.CheckEdit()
        Me.chkThenBy = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSortBy = New DevExpress.XtraEditors.CheckEdit()
        Me.chkAndThenBy2 = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControl19 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.fcbMM2Source = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.fcbResultsDirectory = New DevExpress.XtraEditors.ButtonEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.XtraTabPage6 = New DevExpress.XtraTab.XtraTabPage()
        Me.vgPartDefaults = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.catPartDefaultInfo = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.XtraTabPage7 = New DevExpress.XtraTab.XtraTabPage()
        Me.vgNestDefaults = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.catNestDefaults = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.DnDHighlightHelper1 = New FabV24_WIN8.WindowsApplication1.DnDHighlightHelper()
        CType(Me.gcMainButtons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcMainButtons.SuspendLayout()
        CType(Me.lstPDBNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtcMRP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcMRP.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebOderPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeLeadSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeLayerSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeToolSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl7.SuspendLayout()
        CType(Me.fcbImportFIle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSheetTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbSourceFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcbFileType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAppendMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCopySource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHasPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHeader.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl8.SuspendLayout()
        CType(Me.rgMrpFileType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcSpacer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.TV_MappedFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TV_NestConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TV_UserFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl9.SuspendLayout()
        CType(Me.ceMaterialToLayerSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceMaterialToToolSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.gcFileFromMRP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcFileFromMRP.SuspendLayout()
        CType(Me.lbcFilesFromMrp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl10.SuspendLayout()
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcFilesNotFound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl11.SuspendLayout()
        CType(Me.lbcFoundFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.GroupControl17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl17.SuspendLayout()
        CType(Me.optPDBName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teImportFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teProvidedName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFieldName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl18.SuspendLayout()
        CType(Me.cbeAndThenBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeThenBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeSortBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeAndThenBy2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAndThenBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkThenBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSortBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAndThenBy2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl19.SuspendLayout()
        CType(Me.fcbMM2Source.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbResultsDirectory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage6.SuspendLayout()
        CType(Me.vgPartDefaults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage7.SuspendLayout()
        CType(Me.vgNestDefaults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager1
        '
        SplashScreenManager1.ClosingDelay = 500
        '
        'gcMainButtons
        '
        Me.gcMainButtons.Controls.Add(Me.lstPDBNames)
        Me.gcMainButtons.Controls.Add(Me.tbFieldValues)
        Me.gcMainButtons.Controls.Add(Me.tbFieldNames)
        Me.gcMainButtons.Controls.Add(Me.lbOptions)
        Me.gcMainButtons.Controls.Add(Me.sbFinish)
        Me.gcMainButtons.Controls.Add(Me.sbNext)
        Me.gcMainButtons.Controls.Add(Me.sbBack)
        Me.gcMainButtons.Controls.Add(Me.sbCancel)
        Me.gcMainButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gcMainButtons.Location = New System.Drawing.Point(0, 528)
        Me.gcMainButtons.Name = "gcMainButtons"
        Me.gcMainButtons.ShowCaption = False
        Me.gcMainButtons.Size = New System.Drawing.Size(862, 46)
        Me.gcMainButtons.TabIndex = 0
        Me.gcMainButtons.Text = "GroupControl1"
        '
        'lstPDBNames
        '
        Me.lstPDBNames.Location = New System.Drawing.Point(193, 43)
        Me.lstPDBNames.Name = "lstPDBNames"
        Me.lstPDBNames.Size = New System.Drawing.Size(80, 21)
        Me.lstPDBNames.TabIndex = 88
        Me.lstPDBNames.Visible = False
        '
        'tbFieldValues
        '
        Me.tbFieldValues.Location = New System.Drawing.Point(21, 42)
        Me.tbFieldValues.Name = "tbFieldValues"
        Me.tbFieldValues.Size = New System.Drawing.Size(80, 21)
        Me.tbFieldValues.TabIndex = 86
        Me.tbFieldValues.Visible = False
        '
        'tbFieldNames
        '
        Me.tbFieldNames.Location = New System.Drawing.Point(107, 42)
        Me.tbFieldNames.Name = "tbFieldNames"
        Me.tbFieldNames.Size = New System.Drawing.Size(80, 21)
        Me.tbFieldNames.TabIndex = 85
        Me.tbFieldNames.Visible = False
        '
        'lbOptions
        '
        Me.lbOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbOptions.Appearance.BackColor = System.Drawing.Color.White
        Me.lbOptions.Appearance.Options.UseBackColor = True
        Me.lbOptions.Location = New System.Drawing.Point(279, 21)
        Me.lbOptions.MaximumSize = New System.Drawing.Size(0, 50)
        Me.lbOptions.Name = "lbOptions"
        Me.lbOptions.Size = New System.Drawing.Size(0, 21)
        Me.lbOptions.TabIndex = 87
        Me.lbOptions.Visible = False
        '
        'sbFinish
        '
        Me.sbFinish.Enabled = False
        Me.sbFinish.Location = New System.Drawing.Point(624, 8)
        Me.sbFinish.Name = "sbFinish"
        Me.sbFinish.Size = New System.Drawing.Size(226, 22)
        Me.sbFinish.TabIndex = 14
        Me.sbFinish.Text = "Finish"
        '
        'sbNext
        '
        Me.sbNext.Location = New System.Drawing.Point(438, 8)
        Me.sbNext.Name = "sbNext"
        Me.sbNext.Size = New System.Drawing.Size(182, 22)
        Me.sbNext.TabIndex = 13
        Me.sbNext.Text = "Next >"
        '
        'sbBack
        '
        Me.sbBack.Enabled = False
        Me.sbBack.Location = New System.Drawing.Point(228, 8)
        Me.sbBack.Name = "sbBack"
        Me.sbBack.Size = New System.Drawing.Size(206, 22)
        Me.sbBack.TabIndex = 12
        Me.sbBack.Text = "< Back"
        '
        'sbCancel
        '
        Me.sbCancel.Location = New System.Drawing.Point(16, 8)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(208, 22)
        Me.sbCancel.TabIndex = 11
        Me.sbCancel.Text = "Cancel"
        '
        'GroupControl2
        '
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        Me.GroupControl2.Size = New System.Drawing.Size(862, 24)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "GroupControl1"
        '
        'xtcMRP
        '
        Me.xtcMRP.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.xtcMRP.Appearance.Options.UseFont = True
        Me.xtcMRP.AppearancePage.Header.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!)
        Me.xtcMRP.AppearancePage.Header.Options.UseFont = True
        Me.xtcMRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xtcMRP.Location = New System.Drawing.Point(0, 24)
        Me.xtcMRP.Margin = New System.Windows.Forms.Padding(50)
        Me.xtcMRP.Name = "xtcMRP"
        Me.xtcMRP.Padding = New System.Windows.Forms.Padding(50)
        Me.xtcMRP.SelectedTabPage = Me.XtraTabPage1
        Me.xtcMRP.Size = New System.Drawing.Size(862, 504)
        Me.xtcMRP.TabIndex = 4
        Me.xtcMRP.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3, Me.XtraTabPage4, Me.XtraTabPage5, Me.XtraTabPage6, Me.XtraTabPage7})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GroupControl6)
        Me.XtraTabPage1.Controls.Add(Me.GroupControl7)
        Me.XtraTabPage1.Controls.Add(Me.GroupControl8)
        Me.XtraTabPage1.Controls.Add(Me.gcSpacer)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage1.Text = "MRP Settings"
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.LabelControl2)
        Me.GroupControl6.Controls.Add(Me.DateEdit1)
        Me.GroupControl6.Controls.Add(Me.LabelControl3)
        Me.GroupControl6.Controls.Add(Me.tebOderPO)
        Me.GroupControl6.Controls.Add(Me.LabelControl4)
        Me.GroupControl6.Controls.Add(Me.tebCustomer)
        Me.GroupControl6.Controls.Add(Me.LabelControl5)
        Me.GroupControl6.Controls.Add(Me.cbeLeadSetup)
        Me.GroupControl6.Controls.Add(Me.LabelControl6)
        Me.GroupControl6.Controls.Add(Me.cbeLayerSetup)
        Me.GroupControl6.Controls.Add(Me.LabelControl7)
        Me.GroupControl6.Controls.Add(Me.cbeMaterial)
        Me.GroupControl6.Controls.Add(Me.LabelControl8)
        Me.GroupControl6.Controls.Add(Me.cbeToolSetup)
        Me.GroupControl6.Controls.Add(Me.LabelControl9)
        Me.GroupControl6.Controls.Add(Me.cbeMachine)
        Me.GroupControl6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl6.Location = New System.Drawing.Point(0, 289)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(857, 177)
        Me.GroupControl6.TabIndex = 74
        Me.GroupControl6.Text = "GroupControl6"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(120, 116)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl2.TabIndex = 71
        Me.LabelControl2.Text = "Due Date:"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(175, 114)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(209, 20)
        Me.DateEdit1.TabIndex = 79
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(458, 116)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl3.TabIndex = 80
        Me.LabelControl3.Text = "Order P/O #:"
        '
        'tebOderPO
        '
        Me.tebOderPO.EditValue = "<Enter PO or Work Order>"
        Me.tebOderPO.Location = New System.Drawing.Point(528, 114)
        Me.tebOderPO.Name = "tebOderPO"
        Me.tebOderPO.Properties.AutoHeight = False
        Me.tebOderPO.Size = New System.Drawing.Size(293, 20)
        Me.tebOderPO.TabIndex = 78
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(472, 93)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl4.TabIndex = 81
        Me.LabelControl4.Text = "Customer:"
        '
        'tebCustomer
        '
        Me.tebCustomer.EditValue = "<Enter Custome Name>"
        Me.tebCustomer.Location = New System.Drawing.Point(528, 90)
        Me.tebCustomer.Name = "tebCustomer"
        Me.tebCustomer.Properties.AutoHeight = False
        Me.tebCustomer.Size = New System.Drawing.Size(293, 20)
        Me.tebCustomer.TabIndex = 77
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(111, 93)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl5.TabIndex = 82
        Me.LabelControl5.Text = "Lead Setup:"
        '
        'cbeLeadSetup
        '
        Me.cbeLeadSetup.Location = New System.Drawing.Point(175, 90)
        Me.cbeLeadSetup.Name = "cbeLeadSetup"
        Me.cbeLeadSetup.Properties.AutoHeight = False
        Me.cbeLeadSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeLeadSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeLeadSetup.Size = New System.Drawing.Size(209, 20)
        Me.cbeLeadSetup.TabIndex = 76
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(451, 73)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl6.TabIndex = 83
        Me.LabelControl6.Text = "* Layer Setup:"
        '
        'cbeLayerSetup
        '
        Me.cbeLayerSetup.Location = New System.Drawing.Point(528, 66)
        Me.cbeLayerSetup.Name = "cbeLayerSetup"
        Me.cbeLayerSetup.Properties.AutoHeight = False
        Me.cbeLayerSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeLayerSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeLayerSetup.Size = New System.Drawing.Size(293, 20)
        Me.cbeLayerSetup.TabIndex = 75
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(118, 69)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl7.TabIndex = 84
        Me.LabelControl7.Text = "* Material:"
        '
        'cbeMaterial
        '
        Me.cbeMaterial.Location = New System.Drawing.Point(175, 66)
        Me.cbeMaterial.Name = "cbeMaterial"
        Me.cbeMaterial.Properties.AutoHeight = False
        Me.cbeMaterial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeMaterial.Size = New System.Drawing.Size(209, 20)
        Me.cbeMaterial.TabIndex = 74
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(458, 45)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl8.TabIndex = 85
        Me.LabelControl8.Text = "* Tool Setup:"
        '
        'cbeToolSetup
        '
        Me.cbeToolSetup.Location = New System.Drawing.Point(528, 42)
        Me.cbeToolSetup.Name = "cbeToolSetup"
        Me.cbeToolSetup.Properties.AutoHeight = False
        Me.cbeToolSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeToolSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeToolSetup.Size = New System.Drawing.Size(293, 20)
        Me.cbeToolSetup.TabIndex = 73
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(117, 45)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl9.TabIndex = 86
        Me.LabelControl9.Text = "* Machine:"
        '
        'cbeMachine
        '
        Me.cbeMachine.Location = New System.Drawing.Point(175, 42)
        Me.cbeMachine.Name = "cbeMachine"
        Me.cbeMachine.Properties.AutoHeight = False
        Me.cbeMachine.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMachine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeMachine.Size = New System.Drawing.Size(209, 20)
        Me.cbeMachine.TabIndex = 72
        '
        'GroupControl7
        '
        Me.GroupControl7.Controls.Add(Me.fcbImportFIle)
        Me.GroupControl7.Controls.Add(Me.lblMRPImportFile)
        Me.GroupControl7.Controls.Add(Me.LabelControl10)
        Me.GroupControl7.Controls.Add(Me.cboSheetTable)
        Me.GroupControl7.Controls.Add(Me.LabelControl11)
        Me.GroupControl7.Controls.Add(Me.fcbSourceFolder)
        Me.GroupControl7.Controls.Add(Me.LabelControl12)
        Me.GroupControl7.Controls.Add(Me.lcbFileType)
        Me.GroupControl7.Controls.Add(Me.chkAppendMat)
        Me.GroupControl7.Controls.Add(Me.chkCopySource)
        Me.GroupControl7.Controls.Add(Me.chkHasPath)
        Me.GroupControl7.Controls.Add(Me.chkHeader)
        Me.GroupControl7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl7.Location = New System.Drawing.Point(0, 110)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.Size = New System.Drawing.Size(857, 179)
        Me.GroupControl7.TabIndex = 73
        Me.GroupControl7.Text = "General Import Settings"
        '
        'fcbImportFIle
        '
        Me.fcbImportFIle.Location = New System.Drawing.Point(178, 58)
        Me.fcbImportFIle.Name = "fcbImportFIle"
        Me.fcbImportFIle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbImportFIle.Size = New System.Drawing.Size(643, 20)
        Me.fcbImportFIle.TabIndex = 78
        '
        'lblMRPImportFile
        '
        Me.lblMRPImportFile.Location = New System.Drawing.Point(90, 61)
        Me.lblMRPImportFile.Name = "lblMRPImportFile"
        Me.lblMRPImportFile.Size = New System.Drawing.Size(79, 13)
        Me.lblMRPImportFile.TabIndex = 76
        Me.lblMRPImportFile.Text = "MRP Import File:"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(107, 87)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl10.TabIndex = 65
        Me.LabelControl10.Text = "Sheet/Table:"
        '
        'cboSheetTable
        '
        Me.cboSheetTable.Location = New System.Drawing.Point(175, 84)
        Me.cboSheetTable.Name = "cboSheetTable"
        Me.cboSheetTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSheetTable.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboSheetTable.Size = New System.Drawing.Size(646, 20)
        Me.cboSheetTable.TabIndex = 67
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(35, 108)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(137, 13)
        Me.LabelControl11.TabIndex = 68
        Me.LabelControl11.Text = "Import File(s) Source Folder:"
        '
        'fcbSourceFolder
        '
        Me.fcbSourceFolder.Location = New System.Drawing.Point(175, 108)
        Me.fcbSourceFolder.Name = "fcbSourceFolder"
        Me.fcbSourceFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbSourceFolder.Size = New System.Drawing.Size(646, 20)
        Me.fcbSourceFolder.TabIndex = 66
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(87, 135)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl12.TabIndex = 69
        Me.LabelControl12.Text = "Import File Type:"
        '
        'lcbFileType
        '
        Me.lcbFileType.EditValue = "MM2"
        Me.lcbFileType.Location = New System.Drawing.Point(175, 132)
        Me.lcbFileType.Name = "lcbFileType"
        Me.lcbFileType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lcbFileType.Properties.Items.AddRange(New Object() {"MM2", "DWG", "DXF", "PM4"})
        Me.lcbFileType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.lcbFileType.Size = New System.Drawing.Size(646, 20)
        Me.lcbFileType.TabIndex = 74
        '
        'chkAppendMat
        '
        Me.chkAppendMat.Location = New System.Drawing.Point(615, 27)
        Me.chkAppendMat.Name = "chkAppendMat"
        Me.chkAppendMat.Properties.Caption = "Append Material Name to MM2 Source"
        Me.chkAppendMat.Size = New System.Drawing.Size(206, 19)
        Me.chkAppendMat.TabIndex = 73
        '
        'chkCopySource
        '
        Me.chkCopySource.Location = New System.Drawing.Point(35, 27)
        Me.chkCopySource.Name = "chkCopySource"
        Me.chkCopySource.Properties.Caption = "Copy Source File To MM2 Folder"
        Me.chkCopySource.Size = New System.Drawing.Size(177, 19)
        Me.chkCopySource.TabIndex = 72
        '
        'chkHasPath
        '
        Me.chkHasPath.Location = New System.Drawing.Point(389, 27)
        Me.chkHasPath.Name = "chkHasPath"
        Me.chkHasPath.Properties.Caption = "Does File Contain Full Path To Source File"
        Me.chkHasPath.Size = New System.Drawing.Size(222, 19)
        Me.chkHasPath.TabIndex = 71
        '
        'chkHeader
        '
        Me.chkHeader.Location = New System.Drawing.Point(216, 27)
        Me.chkHeader.Name = "chkHeader"
        Me.chkHeader.Properties.Caption = "Does File Contain Header Row"
        Me.chkHeader.Size = New System.Drawing.Size(169, 19)
        Me.chkHeader.TabIndex = 70
        '
        'GroupControl8
        '
        Me.GroupControl8.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl8.Controls.Add(Me.rgMrpFileType)
        Me.GroupControl8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl8.Location = New System.Drawing.Point(0, 24)
        Me.GroupControl8.Name = "GroupControl8"
        Me.GroupControl8.Size = New System.Drawing.Size(857, 86)
        Me.GroupControl8.TabIndex = 72
        Me.GroupControl8.Text = "MRP File Type"
        '
        'rgMrpFileType
        '
        Me.rgMrpFileType.Location = New System.Drawing.Point(35, 23)
        Me.rgMrpFileType.Name = "rgMrpFileType"
        Me.rgMrpFileType.Properties.Columns = 3
        Me.rgMrpFileType.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.rgMrpFileType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "MS Excel XLS", True, "MSExcel"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "MS Acess", True, "MSAcess"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Tab Delimited", True, "TabDelimited"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Comma Delimited", True, "CommaDelimited"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Semi-Colon Delimited", True, "SemiColonDelimited"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "MS Excel XLSX ", True, "MSExcelXLSX")})
        Me.rgMrpFileType.Size = New System.Drawing.Size(786, 40)
        Me.rgMrpFileType.TabIndex = 3
        '
        'gcSpacer
        '
        Me.gcSpacer.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcSpacer.Location = New System.Drawing.Point(0, 0)
        Me.gcSpacer.Name = "gcSpacer"
        Me.gcSpacer.ShowCaption = False
        Me.gcSpacer.Size = New System.Drawing.Size(857, 24)
        Me.gcSpacer.TabIndex = 0
        Me.gcSpacer.Text = "GroupControl1"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Appearance.PageClient.BackColor = System.Drawing.Color.Maroon
        Me.XtraTabPage2.Appearance.PageClient.ForeColor = System.Drawing.Color.Fuchsia
        Me.XtraTabPage2.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage2.Appearance.PageClient.Options.UseForeColor = True
        Me.XtraTabPage2.Controls.Add(Me.SpreadsheetControl1)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage2.Text = "Preview"
        '
        'SpreadsheetControl1
        '
        Me.SpreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpreadsheetControl1.Location = New System.Drawing.Point(0, 0)
        Me.SpreadsheetControl1.MenuManager = Me.BarManager1
        Me.SpreadsheetControl1.Name = "SpreadsheetControl1"
        Me.SpreadsheetControl1.Options.Behavior.Column.AutoFit = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Behavior.Column.Resize = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Behavior.Row.AutoFit = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled
        Me.SpreadsheetControl1.Options.Cells.AutoFitMergedCellRowHeight = True
        Me.SpreadsheetControl1.Options.Cells.KeepCellAlignmentOnShowFormulas = True
        Me.SpreadsheetControl1.Options.Import.Csv.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Csv.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.Import.Txt.Encoding = CType(resources.GetObject("SpreadsheetControl1.Options.Import.Txt.Encoding"), System.Text.Encoding)
        Me.SpreadsheetControl1.Options.View.ShowColumnHeaders = False
        Me.SpreadsheetControl1.Options.View.ShowPrintArea = False
        Me.SpreadsheetControl1.Options.View.ShowRowHeaders = False
        Me.SpreadsheetControl1.Size = New System.Drawing.Size(857, 477)
        Me.SpreadsheetControl1.TabIndex = 4
        Me.SpreadsheetControl1.Text = "SpreadsheetControl1"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiUnlink})
        Me.BarManager1.MaxItemId = 1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(862, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 574)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(862, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 574)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(862, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 574)
        '
        'bbiUnlink
        '
        Me.bbiUnlink.Caption = "Un-Map Link"
        Me.bbiUnlink.Id = 0
        Me.bbiUnlink.Name = "bbiUnlink"
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.PanelControl5)
        Me.XtraTabPage3.Controls.Add(Me.GroupControl9)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage3.Text = "Mappings"
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.TV_MappedFields)
        Me.PanelControl5.Controls.Add(Me.TV_NestConfig)
        Me.PanelControl5.Controls.Add(Me.TV_UserFields)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl5.Location = New System.Drawing.Point(0, 66)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(857, 411)
        Me.PanelControl5.TabIndex = 5
        '
        'TV_MappedFields
        '
        Me.TV_MappedFields.ActiveFilterEnabled = False
        Me.TV_MappedFields.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn3})
        Me.TV_MappedFields.Cursor = System.Windows.Forms.Cursors.Default
        Me.TV_MappedFields.Dock = System.Windows.Forms.DockStyle.Left
        Me.TV_MappedFields.Location = New System.Drawing.Point(551, 2)
        Me.TV_MappedFields.MenuManager = Me.BarManager1
        Me.TV_MappedFields.Name = "TV_MappedFields"
        Me.TV_MappedFields.OptionsBehavior.AllowExpandOnDblClick = False
        Me.TV_MappedFields.OptionsBehavior.AutoChangeParent = False
        Me.TV_MappedFields.OptionsBehavior.AutoPopulateColumns = False
        Me.TV_MappedFields.OptionsBehavior.AutoSelectAllInEditor = False
        Me.TV_MappedFields.OptionsBehavior.Editable = False
        Me.TV_MappedFields.OptionsMenu.EnableColumnMenu = False
        Me.TV_MappedFields.OptionsMenu.EnableFooterMenu = False
        Me.TV_MappedFields.OptionsMenu.ShowAutoFilterRowItem = False
        Me.TV_MappedFields.OptionsSelection.InvertSelection = True
        Me.TV_MappedFields.OptionsView.ShowButtons = False
        Me.TV_MappedFields.OptionsView.ShowIndicator = False
        Me.TV_MappedFields.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor
        Me.TV_MappedFields.Size = New System.Drawing.Size(302, 407)
        Me.TV_MappedFields.TabIndex = 6
        '
        'TreeListColumn3
        '
        Me.TreeListColumn3.Caption = "Mapped Fields"
        Me.TreeListColumn3.FieldName = "Mapped Fields"
        Me.TreeListColumn3.Name = "TreeListColumn3"
        Me.TreeListColumn3.Visible = True
        Me.TreeListColumn3.VisibleIndex = 0
        '
        'TV_NestConfig
        '
        Me.TV_NestConfig.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn2})
        Me.TV_NestConfig.Cursor = System.Windows.Forms.Cursors.Default
        Me.TV_NestConfig.Dock = System.Windows.Forms.DockStyle.Left
        Me.TV_NestConfig.Location = New System.Drawing.Point(258, 2)
        Me.TV_NestConfig.Name = "TV_NestConfig"
        Me.TV_NestConfig.OptionsBehavior.Editable = False
        Me.TV_NestConfig.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.[Single]
        Me.TV_NestConfig.OptionsView.ShowIndicator = False
        Me.TV_NestConfig.Size = New System.Drawing.Size(293, 407)
        Me.TV_NestConfig.TabIndex = 5
        '
        'TreeListColumn2
        '
        Me.TreeListColumn2.Caption = "System Fields"
        Me.TreeListColumn2.FieldName = "System Fields"
        Me.TreeListColumn2.Name = "TreeListColumn2"
        Me.TreeListColumn2.Visible = True
        Me.TreeListColumn2.VisibleIndex = 0
        '
        'TV_UserFields
        '
        Me.TV_UserFields.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn1})
        Me.TV_UserFields.Cursor = System.Windows.Forms.Cursors.Default
        Me.TV_UserFields.Dock = System.Windows.Forms.DockStyle.Left
        Me.TV_UserFields.Location = New System.Drawing.Point(2, 2)
        Me.TV_UserFields.Name = "TV_UserFields"
        Me.TV_UserFields.OptionsBehavior.Editable = False
        Me.TV_UserFields.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.[Single]
        Me.TV_UserFields.OptionsView.ShowButtons = False
        Me.TV_UserFields.OptionsView.ShowIndicator = False
        Me.TV_UserFields.Size = New System.Drawing.Size(256, 407)
        Me.TV_UserFields.TabIndex = 4
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.Caption = "User Fields"
        Me.TreeListColumn1.FieldName = "User Fields"
        Me.TreeListColumn1.MinWidth = 88
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 0
        Me.TreeListColumn1.Width = 147
        '
        'GroupControl9
        '
        Me.GroupControl9.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl9.Controls.Add(Me.ceMaterialToLayerSetup)
        Me.GroupControl9.Controls.Add(Me.ceMaterialToToolSetup)
        Me.GroupControl9.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl9.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl9.Name = "GroupControl9"
        Me.GroupControl9.Size = New System.Drawing.Size(857, 66)
        Me.GroupControl9.TabIndex = 4
        Me.GroupControl9.Text = "Tool and Layer Setup Naming"
        '
        'ceMaterialToLayerSetup
        '
        Me.ceMaterialToLayerSetup.Location = New System.Drawing.Point(471, 24)
        Me.ceMaterialToLayerSetup.Name = "ceMaterialToLayerSetup"
        Me.ceMaterialToLayerSetup.Properties.Caption = "Use Material Name For Layer Setup"
        Me.ceMaterialToLayerSetup.Size = New System.Drawing.Size(191, 19)
        Me.ceMaterialToLayerSetup.TabIndex = 21
        '
        'ceMaterialToToolSetup
        '
        Me.ceMaterialToToolSetup.Location = New System.Drawing.Point(195, 24)
        Me.ceMaterialToToolSetup.Name = "ceMaterialToToolSetup"
        Me.ceMaterialToToolSetup.Properties.Caption = "Use Material Name For Tool Setup"
        Me.ceMaterialToToolSetup.Size = New System.Drawing.Size(184, 19)
        Me.ceMaterialToToolSetup.TabIndex = 20
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.SplitContainerControl2)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage4.Text = "FIles Processed"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.gcFileFromMRP)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.GroupControl10)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.GroupControl11)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(857, 477)
        Me.SplitContainerControl2.SplitterPosition = 553
        Me.SplitContainerControl2.TabIndex = 4
        Me.SplitContainerControl2.Text = "SplitContainerControl1"
        '
        'gcFileFromMRP
        '
        Me.gcFileFromMRP.Controls.Add(Me.lbcFilesFromMrp)
        Me.gcFileFromMRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.gcFileFromMRP.Location = New System.Drawing.Point(0, 0)
        Me.gcFileFromMRP.Name = "gcFileFromMRP"
        Me.gcFileFromMRP.Size = New System.Drawing.Size(270, 477)
        Me.gcFileFromMRP.TabIndex = 5
        Me.gcFileFromMRP.Text = "Files From MRP"
        '
        'lbcFilesFromMrp
        '
        Me.lbcFilesFromMrp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcFilesFromMrp.Location = New System.Drawing.Point(2, 22)
        Me.lbcFilesFromMrp.Name = "lbcFilesFromMrp"
        Me.lbcFilesFromMrp.Size = New System.Drawing.Size(266, 453)
        Me.lbcFilesFromMrp.TabIndex = 0
        '
        'GroupControl10
        '
        Me.GroupControl10.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl10.Controls.Add(Me.ListBoxControl1)
        Me.GroupControl10.Controls.Add(Me.lbcFilesNotFound)
        Me.GroupControl10.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupControl10.Location = New System.Drawing.Point(283, 0)
        Me.GroupControl10.Name = "GroupControl10"
        Me.GroupControl10.Size = New System.Drawing.Size(270, 477)
        Me.GroupControl10.TabIndex = 4
        Me.GroupControl10.Text = "Files Not Found Or Wrong Revision"
        '
        'ListBoxControl1
        '
        Me.ListBoxControl1.Location = New System.Drawing.Point(178, 77)
        Me.ListBoxControl1.Name = "ListBoxControl1"
        Me.ListBoxControl1.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxControl1.TabIndex = 4
        Me.ListBoxControl1.Visible = False
        '
        'lbcFilesNotFound
        '
        Me.lbcFilesNotFound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcFilesNotFound.Location = New System.Drawing.Point(2, 22)
        Me.lbcFilesNotFound.Name = "lbcFilesNotFound"
        Me.lbcFilesNotFound.Size = New System.Drawing.Size(266, 453)
        Me.lbcFilesNotFound.TabIndex = 3
        '
        'GroupControl11
        '
        Me.GroupControl11.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl11.Controls.Add(Me.lbcFoundFiles)
        Me.GroupControl11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl11.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl11.Name = "GroupControl11"
        Me.GroupControl11.Size = New System.Drawing.Size(298, 477)
        Me.GroupControl11.TabIndex = 3
        Me.GroupControl11.Text = "Files Found"
        '
        'lbcFoundFiles
        '
        Me.lbcFoundFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcFoundFiles.Location = New System.Drawing.Point(2, 22)
        Me.lbcFoundFiles.Name = "lbcFoundFiles"
        Me.lbcFoundFiles.Size = New System.Drawing.Size(294, 453)
        Me.lbcFoundFiles.TabIndex = 1
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.GroupControl17)
        Me.XtraTabPage5.Controls.Add(Me.GroupControl18)
        Me.XtraTabPage5.Controls.Add(Me.GroupControl19)
        Me.XtraTabPage5.Controls.Add(Me.GroupControl1)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage5.Text = "Sorting"
        '
        'GroupControl17
        '
        Me.GroupControl17.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl17.Controls.Add(Me.optPDBName)
        Me.GroupControl17.Controls.Add(Me.teImportFilename)
        Me.GroupControl17.Controls.Add(Me.teProvidedName)
        Me.GroupControl17.Controls.Add(Me.cboFieldName)
        Me.GroupControl17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl17.Location = New System.Drawing.Point(0, 291)
        Me.GroupControl17.Name = "GroupControl17"
        Me.GroupControl17.Size = New System.Drawing.Size(857, 177)
        Me.GroupControl17.TabIndex = 9
        Me.GroupControl17.Text = "DefineJob Name"
        '
        'optPDBName
        '
        Me.optPDBName.Location = New System.Drawing.Point(35, 23)
        Me.optPDBName.Name = "optPDBName"
        Me.optPDBName.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Use Import Filename"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Set Job Name"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Use Field Name")})
        Me.optPDBName.Size = New System.Drawing.Size(278, 131)
        Me.optPDBName.TabIndex = 78
        '
        'teImportFilename
        '
        Me.teImportFilename.Enabled = False
        Me.teImportFilename.Location = New System.Drawing.Point(317, 23)
        Me.teImportFilename.Name = "teImportFilename"
        Me.teImportFilename.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.teImportFilename.Properties.ReadOnly = True
        Me.teImportFilename.Size = New System.Drawing.Size(504, 18)
        Me.teImportFilename.TabIndex = 79
        Me.teImportFilename.Visible = False
        '
        'teProvidedName
        '
        Me.teProvidedName.Location = New System.Drawing.Point(317, 45)
        Me.teProvidedName.Name = "teProvidedName"
        Me.teProvidedName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.teProvidedName.Size = New System.Drawing.Size(504, 18)
        Me.teProvidedName.TabIndex = 80
        Me.teProvidedName.Visible = False
        '
        'cboFieldName
        '
        Me.cboFieldName.Location = New System.Drawing.Point(317, 67)
        Me.cboFieldName.Name = "cboFieldName"
        Me.cboFieldName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cboFieldName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFieldName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboFieldName.Size = New System.Drawing.Size(504, 18)
        Me.cboFieldName.TabIndex = 81
        Me.cboFieldName.Visible = False
        '
        'GroupControl18
        '
        Me.GroupControl18.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl18.Controls.Add(Me.LabelControl16)
        Me.GroupControl18.Controls.Add(Me.cbeAndThenBy)
        Me.GroupControl18.Controls.Add(Me.LabelControl17)
        Me.GroupControl18.Controls.Add(Me.cbeThenBy)
        Me.GroupControl18.Controls.Add(Me.LabelControl18)
        Me.GroupControl18.Controls.Add(Me.cbeSortBy)
        Me.GroupControl18.Controls.Add(Me.LabelControl19)
        Me.GroupControl18.Controls.Add(Me.cbeAndThenBy2)
        Me.GroupControl18.Controls.Add(Me.chkAndThenBy)
        Me.GroupControl18.Controls.Add(Me.chkThenBy)
        Me.GroupControl18.Controls.Add(Me.chkSortBy)
        Me.GroupControl18.Controls.Add(Me.chkAndThenBy2)
        Me.GroupControl18.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl18.Location = New System.Drawing.Point(0, 169)
        Me.GroupControl18.Name = "GroupControl18"
        Me.GroupControl18.Size = New System.Drawing.Size(857, 122)
        Me.GroupControl18.TabIndex = 8
        Me.GroupControl18.Text = "Sorting Method"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(104, 64)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl16.TabIndex = 9
        Me.LabelControl16.Text = "And Then By:"
        '
        'cbeAndThenBy
        '
        Me.cbeAndThenBy.Location = New System.Drawing.Point(175, 63)
        Me.cbeAndThenBy.Name = "cbeAndThenBy"
        Me.cbeAndThenBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeAndThenBy.Size = New System.Drawing.Size(122, 20)
        Me.cbeAndThenBy.TabIndex = 14
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(126, 42)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl17.TabIndex = 15
        Me.LabelControl17.Text = "Then By:"
        '
        'cbeThenBy
        '
        Me.cbeThenBy.Location = New System.Drawing.Point(175, 39)
        Me.cbeThenBy.Name = "cbeThenBy"
        Me.cbeThenBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeThenBy.Size = New System.Drawing.Size(122, 20)
        Me.cbeThenBy.TabIndex = 12
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(130, 18)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl18.TabIndex = 17
        Me.LabelControl18.Text = "Sort By:"
        '
        'cbeSortBy
        '
        Me.cbeSortBy.Location = New System.Drawing.Point(175, 15)
        Me.cbeSortBy.Name = "cbeSortBy"
        Me.cbeSortBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeSortBy.Size = New System.Drawing.Size(122, 20)
        Me.cbeSortBy.TabIndex = 10
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(104, 87)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl19.TabIndex = 19
        Me.LabelControl19.Text = "And Then By:"
        '
        'cbeAndThenBy2
        '
        Me.cbeAndThenBy2.Location = New System.Drawing.Point(175, 87)
        Me.cbeAndThenBy2.Name = "cbeAndThenBy2"
        Me.cbeAndThenBy2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeAndThenBy2.Size = New System.Drawing.Size(122, 20)
        Me.cbeAndThenBy2.TabIndex = 18
        '
        'chkAndThenBy
        '
        Me.chkAndThenBy.Enabled = False
        Me.chkAndThenBy.Location = New System.Drawing.Point(319, 61)
        Me.chkAndThenBy.Name = "chkAndThenBy"
        Me.chkAndThenBy.Properties.Caption = "Append This Field Value To PDB Name"
        Me.chkAndThenBy.Size = New System.Drawing.Size(520, 19)
        Me.chkAndThenBy.TabIndex = 16
        '
        'chkThenBy
        '
        Me.chkThenBy.Enabled = False
        Me.chkThenBy.Location = New System.Drawing.Point(319, 39)
        Me.chkThenBy.Name = "chkThenBy"
        Me.chkThenBy.Properties.Caption = "Append This Field Value To PDB Name"
        Me.chkThenBy.Size = New System.Drawing.Size(520, 19)
        Me.chkThenBy.TabIndex = 13
        '
        'chkSortBy
        '
        Me.chkSortBy.EditValue = True
        Me.chkSortBy.Enabled = False
        Me.chkSortBy.Location = New System.Drawing.Point(319, 15)
        Me.chkSortBy.Name = "chkSortBy"
        Me.chkSortBy.Properties.Caption = "Append This Field Value To PDB Name"
        Me.chkSortBy.Size = New System.Drawing.Size(520, 19)
        Me.chkSortBy.TabIndex = 11
        '
        'chkAndThenBy2
        '
        Me.chkAndThenBy2.Enabled = False
        Me.chkAndThenBy2.Location = New System.Drawing.Point(319, 84)
        Me.chkAndThenBy2.Name = "chkAndThenBy2"
        Me.chkAndThenBy2.Properties.Caption = "Append This Field Value To PDB Name"
        Me.chkAndThenBy2.Size = New System.Drawing.Size(520, 19)
        Me.chkAndThenBy2.TabIndex = 20
        '
        'GroupControl19
        '
        Me.GroupControl19.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl19.Controls.Add(Me.LabelControl20)
        Me.GroupControl19.Controls.Add(Me.fcbMM2Source)
        Me.GroupControl19.Controls.Add(Me.LabelControl21)
        Me.GroupControl19.Controls.Add(Me.fcbResultsDirectory)
        Me.GroupControl19.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl19.Location = New System.Drawing.Point(0, 65)
        Me.GroupControl19.Name = "GroupControl19"
        Me.GroupControl19.Size = New System.Drawing.Size(857, 104)
        Me.GroupControl19.TabIndex = 7
        Me.GroupControl19.Text = "Define Results Folders"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(35, 54)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(124, 13)
        Me.LabelControl20.TabIndex = 12
        Me.LabelControl20.Text = "Result MM2 File(s) Folder:"
        '
        'fcbMM2Source
        '
        Me.fcbMM2Source.Location = New System.Drawing.Point(175, 54)
        Me.fcbMM2Source.Name = "fcbMM2Source"
        Me.fcbMM2Source.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbMM2Source.Size = New System.Drawing.Size(646, 20)
        Me.fcbMM2Source.TabIndex = 14
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(35, 30)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(111, 13)
        Me.LabelControl21.TabIndex = 15
        Me.LabelControl21.Text = "Nesting Results Folder:"
        '
        'fcbResultsDirectory
        '
        Me.fcbResultsDirectory.Location = New System.Drawing.Point(175, 30)
        Me.fcbResultsDirectory.Name = "fcbResultsDirectory"
        Me.fcbResultsDirectory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbResultsDirectory.Size = New System.Drawing.Size(646, 20)
        Me.fcbResultsDirectory.TabIndex = 13
        '
        'GroupControl1
        '
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.ShowCaption = False
        Me.GroupControl1.Size = New System.Drawing.Size(857, 65)
        Me.GroupControl1.TabIndex = 6
        Me.GroupControl1.Text = "GroupControl1"
        '
        'XtraTabPage6
        '
        Me.XtraTabPage6.Controls.Add(Me.vgPartDefaults)
        Me.XtraTabPage6.Name = "XtraTabPage6"
        Me.XtraTabPage6.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage6.Text = "Part Defaults"
        Me.XtraTabPage6.UseWaitCursor = True
        '
        'vgPartDefaults
        '
        Me.vgPartDefaults.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.vgPartDefaults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgPartDefaults.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgPartDefaults.Location = New System.Drawing.Point(0, 0)
        Me.vgPartDefaults.Name = "vgPartDefaults"
        Me.vgPartDefaults.OptionsBehavior.AutoFocusNewRecord = True
        Me.vgPartDefaults.OptionsBehavior.UseEnterAsTab = True
        Me.vgPartDefaults.OptionsView.AutoScaleBands = True
        Me.vgPartDefaults.OptionsView.ShowButtons = False
        Me.vgPartDefaults.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catPartDefaultInfo})
        Me.vgPartDefaults.Size = New System.Drawing.Size(857, 477)
        Me.vgPartDefaults.TabIndex = 67
        Me.vgPartDefaults.UseWaitCursor = True
        '
        'catPartDefaultInfo
        '
        Me.catPartDefaultInfo.Height = 19
        Me.catPartDefaultInfo.Name = "catPartDefaultInfo"
        Me.catPartDefaultInfo.Properties.Caption = "Enter any Part Defaults that are not included in the imprt file."
        '
        'XtraTabPage7
        '
        Me.XtraTabPage7.Controls.Add(Me.vgNestDefaults)
        Me.XtraTabPage7.Name = "XtraTabPage7"
        Me.XtraTabPage7.Size = New System.Drawing.Size(857, 477)
        Me.XtraTabPage7.Text = "Nesting Defaults"
        '
        'vgNestDefaults
        '
        Me.vgNestDefaults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgNestDefaults.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgNestDefaults.Location = New System.Drawing.Point(0, 0)
        Me.vgNestDefaults.Name = "vgNestDefaults"
        Me.vgNestDefaults.OptionsBehavior.AutoFocusNewRecord = True
        Me.vgNestDefaults.OptionsBehavior.UseEnterAsTab = True
        Me.vgNestDefaults.OptionsView.AutoScaleBands = True
        Me.vgNestDefaults.OptionsView.ShowButtons = False
        Me.vgNestDefaults.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catNestDefaults})
        Me.vgNestDefaults.Size = New System.Drawing.Size(857, 477)
        Me.vgNestDefaults.TabIndex = 71
        '
        'catNestDefaults
        '
        Me.catNestDefaults.Height = 19
        Me.catNestDefaults.Name = "catNestDefaults"
        Me.catNestDefaults.Properties.Caption = "Enter any Nesting Defaults that are not included in the import file."
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiUnlink)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'DnDHighlightHelper1
        '
        Me.DnDHighlightHelper1.SelectedTreeList = Nothing
        '
        'frmNewMRP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 574)
        Me.Controls.Add(Me.xtcMRP)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.gcMainButtons)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmNewMRP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MRP Interface"
        CType(Me.gcMainButtons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcMainButtons.ResumeLayout(False)
        Me.gcMainButtons.PerformLayout()
        CType(Me.lstPDBNames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtcMRP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcMRP.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        Me.GroupControl6.PerformLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebOderPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeLeadSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeLayerSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeToolSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl7.ResumeLayout(False)
        Me.GroupControl7.PerformLayout()
        CType(Me.fcbImportFIle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSheetTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbSourceFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcbFileType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAppendMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCopySource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHasPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHeader.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl8.ResumeLayout(False)
        CType(Me.rgMrpFileType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcSpacer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        CType(Me.TV_MappedFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TV_NestConfig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TV_UserFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl9.ResumeLayout(False)
        CType(Me.ceMaterialToLayerSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceMaterialToToolSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage4.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.gcFileFromMRP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcFileFromMRP.ResumeLayout(False)
        CType(Me.lbcFilesFromMrp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl10.ResumeLayout(False)
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcFilesNotFound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl11.ResumeLayout(False)
        CType(Me.lbcFoundFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage5.ResumeLayout(False)
        CType(Me.GroupControl17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl17.ResumeLayout(False)
        CType(Me.optPDBName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teImportFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teProvidedName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFieldName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl18.ResumeLayout(False)
        Me.GroupControl18.PerformLayout()
        CType(Me.cbeAndThenBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeThenBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeSortBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeAndThenBy2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAndThenBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkThenBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSortBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAndThenBy2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl19.ResumeLayout(False)
        Me.GroupControl19.PerformLayout()
        CType(Me.fcbMM2Source.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbResultsDirectory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage6.ResumeLayout(False)
        CType(Me.vgPartDefaults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage7.ResumeLayout(False)
        CType(Me.vgNestDefaults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gcMainButtons As GroupControl
    Friend WithEvents sbFinish As SimpleButton
    Friend WithEvents sbNext As SimpleButton
    Friend WithEvents sbBack As SimpleButton
    Friend WithEvents sbCancel As SimpleButton
    Friend WithEvents lstPDBNames As ListBoxControl
    Friend WithEvents tbFieldValues As TextBox
    Friend WithEvents tbFieldNames As TextBox
    Friend WithEvents lbOptions As ListBoxControl
    Friend WithEvents GroupControl2 As GroupControl
    Friend WithEvents xtcMRP As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl6 As GroupControl
    Friend WithEvents LabelControl2 As LabelControl
    Friend WithEvents DateEdit1 As DateEdit
    Friend WithEvents LabelControl3 As LabelControl
    Friend WithEvents tebOderPO As TextEdit
    Friend WithEvents LabelControl4 As LabelControl
    Friend WithEvents tebCustomer As TextEdit
    Friend WithEvents LabelControl5 As LabelControl
    Friend WithEvents cbeLeadSetup As ComboBoxEdit
    Friend WithEvents LabelControl6 As LabelControl
    Friend WithEvents cbeLayerSetup As ComboBoxEdit
    Friend WithEvents LabelControl7 As LabelControl
    Friend WithEvents cbeMaterial As ComboBoxEdit
    Friend WithEvents LabelControl8 As LabelControl
    Friend WithEvents cbeToolSetup As ComboBoxEdit
    Friend WithEvents LabelControl9 As LabelControl
    Friend WithEvents cbeMachine As ComboBoxEdit
    Friend WithEvents GroupControl7 As GroupControl
    Friend WithEvents lblMRPImportFile As LabelControl
    Friend WithEvents LabelControl10 As LabelControl
    Friend WithEvents cboSheetTable As ComboBoxEdit
    Friend WithEvents LabelControl11 As LabelControl
    Friend WithEvents fcbSourceFolder As ButtonEdit
    Friend WithEvents LabelControl12 As LabelControl
    Friend WithEvents lcbFileType As ComboBoxEdit
    Friend WithEvents chkAppendMat As CheckEdit
    Friend WithEvents chkCopySource As CheckEdit
    Friend WithEvents chkHasPath As CheckEdit
    Friend WithEvents chkHeader As CheckEdit
    Friend WithEvents GroupControl8 As GroupControl
    Friend WithEvents rgMrpFileType As RadioGroup
    Friend WithEvents gcSpacer As GroupControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SpreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl5 As PanelControl
    Friend WithEvents GroupControl9 As GroupControl
    Friend WithEvents ceMaterialToLayerSetup As CheckEdit
    Friend WithEvents ceMaterialToToolSetup As CheckEdit
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl2 As SplitContainerControl
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl17 As GroupControl
    Friend WithEvents optPDBName As RadioGroup
    Friend WithEvents teImportFilename As TextEdit
    Friend WithEvents teProvidedName As TextEdit
    Friend WithEvents cboFieldName As ComboBoxEdit
    Friend WithEvents GroupControl18 As GroupControl
    Friend WithEvents LabelControl16 As LabelControl
    Friend WithEvents cbeAndThenBy As ComboBoxEdit
    Friend WithEvents LabelControl17 As LabelControl
    Friend WithEvents cbeThenBy As ComboBoxEdit
    Friend WithEvents LabelControl18 As LabelControl
    Friend WithEvents cbeSortBy As ComboBoxEdit
    Friend WithEvents LabelControl19 As LabelControl
    Friend WithEvents cbeAndThenBy2 As ComboBoxEdit
    Friend WithEvents chkAndThenBy As CheckEdit
    Friend WithEvents chkThenBy As CheckEdit
    Friend WithEvents chkSortBy As CheckEdit
    Friend WithEvents chkAndThenBy2 As CheckEdit
    Friend WithEvents GroupControl19 As GroupControl
    Friend WithEvents LabelControl20 As LabelControl
    Friend WithEvents fcbMM2Source As ButtonEdit
    Friend WithEvents LabelControl21 As LabelControl
    Friend WithEvents fcbResultsDirectory As ButtonEdit
    Friend WithEvents GroupControl1 As GroupControl
    Friend WithEvents XtraTabPage6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents vgPartDefaults As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catPartDefaultInfo As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents XtraTabPage7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents vgNestDefaults As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catNestDefaults As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiUnlink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents DnDHighlightHelper1 As WindowsApplication1.DnDHighlightHelper
    Friend WithEvents fcbImportFIle As ButtonEdit
    Private WithEvents TV_MappedFields As DevExpress.XtraTreeList.TreeList
    Friend WithEvents TreeListColumn3 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents TV_NestConfig As DevExpress.XtraTreeList.TreeList
    Friend WithEvents TreeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents TV_UserFields As DevExpress.XtraTreeList.TreeList
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents gcFileFromMRP As GroupControl
    Friend WithEvents lbcFilesFromMrp As ListBoxControl
    Friend WithEvents GroupControl10 As GroupControl
    Friend WithEvents ListBoxControl1 As ListBoxControl
    Friend WithEvents lbcFilesNotFound As ListBoxControl
    Friend WithEvents GroupControl11 As GroupControl
    Friend WithEvents lbcFoundFiles As ListBoxControl
End Class
