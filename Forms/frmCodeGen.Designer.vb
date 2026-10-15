<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodeGen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodeGen))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCompile = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCNCFileExtensions = New DevExpress.XtraEditors.SimpleButton()
        Me.fcbCodeGenFile = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblCodeGenerationFile = New DevExpress.XtraEditors.LabelControl()
        Me.fcbExportTo = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkCreateMasterFile = New DevExpress.XtraEditors.CheckEdit()
        Me.vgCodeGenVars = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.chkSubRoutines = New DevExpress.XtraEditors.CheckEdit()
        Me.lstExtensions = New DevExpress.XtraEditors.ListBoxControl()
        Me.lstOptions = New DevExpress.XtraEditors.ListBoxControl()
        Me.lblExportTo = New DevExpress.XtraEditors.LabelControl()
        Me.cbfOptimizeToolpath = New FabV24_WIN8.WindowsApplication234.ChkBoxFrame()
        Me.lcbGridSequence = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblSticky = New DevExpress.XtraEditors.LabelControl()
        Me.lblSequnceBy = New DevExpress.XtraEditors.LabelControl()
        Me.cmdFlowchart = New DevExpress.XtraEditors.SimpleButton()
        Me.chkZigZag = New DevExpress.XtraEditors.CheckEdit()
        Me.txtSticky = New DevExpress.XtraEditors.SpinEdit()
        Me.rgOptMode = New DevExpress.XtraEditors.RadioGroup()
        Me.gcStartConer = New DevExpress.XtraEditors.GroupControl()
        Me.btnSlice8 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice7 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice6 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice5 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice4 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice3 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice2 = New DevExpress.XtraEditors.CheckButton()
        Me.btnSlice1 = New DevExpress.XtraEditors.CheckButton()
        Me.gcClosestPoint = New DevExpress.XtraEditors.GroupControl()
        Me.mtbStartPointY = New DevExpress.XtraEditors.TextEdit()
        Me.mtbStartPointX = New DevExpress.XtraEditors.TextEdit()
        Me.lblLoctionY = New DevExpress.XtraEditors.LabelControl()
        Me.lblLocationX = New DevExpress.XtraEditors.LabelControl()
        CType(Me.fcbCodeGenFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbExportTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCreateMasterFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgCodeGenVars, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSubRoutines.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstExtensions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbfOptimizeToolpath.SuspendLayout()
        CType(Me.lcbGridSequence.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkZigZag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSticky.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgOptMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcStartConer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcStartConer.SuspendLayout()
        CType(Me.gcClosestPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcClosestPoint.SuspendLayout()
        CType(Me.mtbStartPointY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mtbStartPointX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(422, 331)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 28)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(617, 334)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 28)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdCompile
        '
        Me.cmdCompile.Location = New System.Drawing.Point(519, 298)
        Me.cmdCompile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCompile.Name = "cmdCompile"
        Me.cmdCompile.Size = New System.Drawing.Size(87, 28)
        Me.cmdCompile.TabIndex = 2
        Me.cmdCompile.Text = "Compile"
        '
        'cmdCNCFileExtensions
        '
        Me.cmdCNCFileExtensions.Location = New System.Drawing.Point(199, 15)
        Me.cmdCNCFileExtensions.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCNCFileExtensions.Name = "cmdCNCFileExtensions"
        Me.cmdCNCFileExtensions.Size = New System.Drawing.Size(152, 28)
        Me.cmdCNCFileExtensions.TabIndex = 3
        Me.cmdCNCFileExtensions.Text = "CNC Extensions"
        Me.cmdCNCFileExtensions.ToolTip = "Click on this button to add the extension needed  for the CNC file."
        '
        'fcbCodeGenFile
        '
        Me.fcbCodeGenFile.EditValue = ""
        Me.fcbCodeGenFile.Location = New System.Drawing.Point(14, 328)
        Me.fcbCodeGenFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fcbCodeGenFile.Name = "fcbCodeGenFile"
        Me.fcbCodeGenFile.Properties.Appearance.Options.UseTextOptions = True
        Me.fcbCodeGenFile.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.fcbCodeGenFile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbCodeGenFile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.fcbCodeGenFile.Size = New System.Drawing.Size(376, 20)
        Me.fcbCodeGenFile.TabIndex = 5
        Me.fcbCodeGenFile.ToolTip = "Click on the ... to select the Java file for your machine"
        '
        'lblCodeGenerationFile
        '
        Me.lblCodeGenerationFile.Location = New System.Drawing.Point(14, 305)
        Me.lblCodeGenerationFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCodeGenerationFile.Name = "lblCodeGenerationFile"
        Me.lblCodeGenerationFile.Size = New System.Drawing.Size(100, 13)
        Me.lblCodeGenerationFile.TabIndex = 6
        Me.lblCodeGenerationFile.Text = "Code Generation File"
        '
        'fcbExportTo
        '
        Me.fcbExportTo.Location = New System.Drawing.Point(14, 377)
        Me.fcbExportTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fcbExportTo.Name = "fcbExportTo"
        Me.fcbExportTo.Properties.Appearance.Options.UseTextOptions = True
        Me.fcbExportTo.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.fcbExportTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbExportTo.Size = New System.Drawing.Size(376, 20)
        Me.fcbExportTo.TabIndex = 7
        Me.fcbExportTo.ToolTip = "Click on the .. to select the folder and name of the CNC file to be created."
        '
        'chkCreateMasterFile
        '
        Me.chkCreateMasterFile.Location = New System.Drawing.Point(490, 377)
        Me.chkCreateMasterFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkCreateMasterFile.Name = "chkCreateMasterFile"
        Me.chkCreateMasterFile.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkCreateMasterFile.Properties.Appearance.Options.UseFont = True
        Me.chkCreateMasterFile.Properties.Caption = "Create Master File"
        Me.chkCreateMasterFile.Size = New System.Drawing.Size(184, 19)
        Me.chkCreateMasterFile.TabIndex = 9
        Me.chkCreateMasterFile.ToolTip = "Checking this creates 1 CNC File with all the nested sheets in that file."
        '
        'vgCodeGenVars
        '
        Me.vgCodeGenVars.Location = New System.Drawing.Point(422, 50)
        Me.vgCodeGenVars.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.vgCodeGenVars.Name = "vgCodeGenVars"
        Me.vgCodeGenVars.OptionsView.MinRowAutoHeight = 12
        Me.vgCodeGenVars.OptionsView.ShowButtons = False
        Me.vgCodeGenVars.RecordWidth = 117
        Me.vgCodeGenVars.RowHeaderWidth = 117
        Me.vgCodeGenVars.Size = New System.Drawing.Size(282, 234)
        Me.vgCodeGenVars.TabIndex = 10
        '
        'chkSubRoutines
        '
        Me.chkSubRoutines.Location = New System.Drawing.Point(30, 17)
        Me.chkSubRoutines.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSubRoutines.Name = "chkSubRoutines"
        Me.chkSubRoutines.Properties.Caption = "Create Sub Routines"
        Me.chkSubRoutines.Size = New System.Drawing.Size(159, 19)
        Me.chkSubRoutines.TabIndex = 11
        '
        'lstExtensions
        '
        Me.lstExtensions.Location = New System.Drawing.Point(14, 290)
        Me.lstExtensions.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstExtensions.Name = "lstExtensions"
        Me.lstExtensions.Size = New System.Drawing.Size(74, 18)
        Me.lstExtensions.TabIndex = 12
        Me.lstExtensions.Visible = False
        '
        'lstOptions
        '
        Me.lstOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstOptions.Location = New System.Drawing.Point(98, 290)
        Me.lstOptions.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstOptions.Name = "lstOptions"
        Me.lstOptions.Size = New System.Drawing.Size(44, 18)
        Me.lstOptions.TabIndex = 50
        Me.lstOptions.Visible = False
        '
        'lblExportTo
        '
        Me.lblExportTo.Location = New System.Drawing.Point(14, 356)
        Me.lblExportTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblExportTo.Name = "lblExportTo"
        Me.lblExportTo.Size = New System.Drawing.Size(51, 13)
        Me.lblExportTo.TabIndex = 8
        Me.lblExportTo.Text = "Export To:"
        '
        'cbfOptimizeToolpath
        '
        Me.cbfOptimizeToolpath.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.cbfOptimizeToolpath.Caption = "Optimize Toolpath"
        Me.cbfOptimizeToolpath.CaptionColor = System.Drawing.Color.Silver
        Me.cbfOptimizeToolpath.Checked = True
        Me.cbfOptimizeToolpath.Controls.Add(Me.lcbGridSequence)
        Me.cbfOptimizeToolpath.Controls.Add(Me.lblSticky)
        Me.cbfOptimizeToolpath.Controls.Add(Me.lblSequnceBy)
        Me.cbfOptimizeToolpath.Controls.Add(Me.cmdFlowchart)
        Me.cbfOptimizeToolpath.Controls.Add(Me.chkZigZag)
        Me.cbfOptimizeToolpath.Controls.Add(Me.txtSticky)
        Me.cbfOptimizeToolpath.Controls.Add(Me.rgOptMode)
        Me.cbfOptimizeToolpath.Controls.Add(Me.gcStartConer)
        Me.cbfOptimizeToolpath.Controls.Add(Me.gcClosestPoint)
        Me.cbfOptimizeToolpath.Location = New System.Drawing.Point(10, 50)
        Me.cbfOptimizeToolpath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbfOptimizeToolpath.MinimumSize = New System.Drawing.Size(291, 234)
        Me.cbfOptimizeToolpath.Name = "cbfOptimizeToolpath"
        Me.cbfOptimizeToolpath.Padding = New System.Windows.Forms.Padding(0, 14, 0, 0)
        Me.cbfOptimizeToolpath.Size = New System.Drawing.Size(405, 234)
        Me.cbfOptimizeToolpath.TabIndex = 4
        '
        'lcbGridSequence
        '
        Me.lcbGridSequence.Location = New System.Drawing.Point(84, 187)
        Me.lcbGridSequence.Name = "lcbGridSequence"
        Me.lcbGridSequence.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lcbGridSequence.Properties.Items.AddRange(New Object() {"Preset Tool Order", "Containment Order", "Process FlowChart"})
        Me.lcbGridSequence.Size = New System.Drawing.Size(136, 20)
        Me.lcbGridSequence.TabIndex = 12
        '
        'lblSticky
        '
        Me.lblSticky.Location = New System.Drawing.Point(14, 156)
        Me.lblSticky.Name = "lblSticky"
        Me.lblSticky.Size = New System.Drawing.Size(64, 13)
        Me.lblSticky.TabIndex = 11
        Me.lblSticky.Text = "Linear Trend:"
        '
        'lblSequnceBy
        '
        Me.lblSequnceBy.Location = New System.Drawing.Point(12, 190)
        Me.lblSequnceBy.Name = "lblSequnceBy"
        Me.lblSequnceBy.Size = New System.Drawing.Size(66, 13)
        Me.lblSequnceBy.TabIndex = 10
        Me.lblSequnceBy.Text = "Sequence By:"
        '
        'cmdFlowchart
        '
        Me.cmdFlowchart.AutoSize = True
        Me.cmdFlowchart.ImageOptions.Image = CType(resources.GetObject("cmdFlowchart.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdFlowchart.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdFlowchart.Location = New System.Drawing.Point(235, 182)
        Me.cmdFlowchart.Name = "cmdFlowchart"
        Me.cmdFlowchart.Size = New System.Drawing.Size(31, 29)
        Me.cmdFlowchart.TabIndex = 7
        '
        'chkZigZag
        '
        Me.chkZigZag.Location = New System.Drawing.Point(272, 188)
        Me.chkZigZag.Name = "chkZigZag"
        Me.chkZigZag.Properties.AutoWidth = True
        Me.chkZigZag.Properties.Caption = "Zig Zag Pattern"
        Me.chkZigZag.Size = New System.Drawing.Size(95, 19)
        Me.chkZigZag.TabIndex = 6
        '
        'txtSticky
        '
        Me.txtSticky.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSticky.Location = New System.Drawing.Point(84, 153)
        Me.txtSticky.Name = "txtSticky"
        Me.txtSticky.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtSticky.Size = New System.Drawing.Size(46, 20)
        Me.txtSticky.TabIndex = 3
        '
        'rgOptMode
        '
        Me.rgOptMode.AutoSizeInLayoutControl = True
        Me.rgOptMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rgOptMode.EnterMoveNextControl = True
        Me.rgOptMode.Location = New System.Drawing.Point(4, 32)
        Me.rgOptMode.Name = "rgOptMode"
        Me.rgOptMode.Properties.ColumnIndent = 2
        Me.rgOptMode.Properties.Columns = 3
        Me.rgOptMode.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Grid Mode"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Closest Pt Mode"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Progressive Mode")})
        Me.rgOptMode.Size = New System.Drawing.Size(398, 28)
        Me.rgOptMode.TabIndex = 1
        '
        'gcStartConer
        '
        Me.gcStartConer.Controls.Add(Me.btnSlice8)
        Me.gcStartConer.Controls.Add(Me.btnSlice7)
        Me.gcStartConer.Controls.Add(Me.btnSlice6)
        Me.gcStartConer.Controls.Add(Me.btnSlice5)
        Me.gcStartConer.Controls.Add(Me.btnSlice4)
        Me.gcStartConer.Controls.Add(Me.btnSlice3)
        Me.gcStartConer.Controls.Add(Me.btnSlice2)
        Me.gcStartConer.Controls.Add(Me.btnSlice1)
        Me.gcStartConer.Location = New System.Drawing.Point(2, 65)
        Me.gcStartConer.Name = "gcStartConer"
        Me.gcStartConer.Size = New System.Drawing.Size(400, 71)
        Me.gcStartConer.TabIndex = 9
        Me.gcStartConer.Text = "Start Corner and Direction"
        '
        'btnSlice8
        '
        Me.btnSlice8.AutoSize = True
        Me.btnSlice8.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice8.GroupIndex = 1
        Me.btnSlice8.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NEUpperLeftY
        Me.btnSlice8.Location = New System.Drawing.Point(282, 22)
        Me.btnSlice8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice8.Name = "btnSlice8"
        Me.btnSlice8.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice8.TabIndex = 23
        Me.btnSlice8.TabStop = False
        Me.btnSlice8.Tag = "7"
        '
        'btnSlice7
        '
        Me.btnSlice7.AutoSize = True
        Me.btnSlice7.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice7.GroupIndex = 1
        Me.btnSlice7.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NEUpperRightY
        Me.btnSlice7.Location = New System.Drawing.Point(242, 22)
        Me.btnSlice7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice7.Name = "btnSlice7"
        Me.btnSlice7.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice7.TabIndex = 22
        Me.btnSlice7.TabStop = False
        Me.btnSlice7.Tag = "6"
        '
        'btnSlice6
        '
        Me.btnSlice6.AutoSize = True
        Me.btnSlice6.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice6.GroupIndex = 1
        Me.btnSlice6.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NELowerRightY
        Me.btnSlice6.Location = New System.Drawing.Point(202, 22)
        Me.btnSlice6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice6.Name = "btnSlice6"
        Me.btnSlice6.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice6.TabIndex = 21
        Me.btnSlice6.TabStop = False
        Me.btnSlice6.Tag = "5"
        '
        'btnSlice5
        '
        Me.btnSlice5.AutoSize = True
        Me.btnSlice5.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice5.GroupIndex = 1
        Me.btnSlice5.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NELowerLeftY
        Me.btnSlice5.Location = New System.Drawing.Point(162, 22)
        Me.btnSlice5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice5.Name = "btnSlice5"
        Me.btnSlice5.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice5.TabIndex = 20
        Me.btnSlice5.TabStop = False
        Me.btnSlice5.Tag = "4"
        '
        'btnSlice4
        '
        Me.btnSlice4.AutoSize = True
        Me.btnSlice4.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice4.GroupIndex = 1
        Me.btnSlice4.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NEUpperLeftX
        Me.btnSlice4.Location = New System.Drawing.Point(122, 22)
        Me.btnSlice4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice4.Name = "btnSlice4"
        Me.btnSlice4.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice4.TabIndex = 19
        Me.btnSlice4.TabStop = False
        Me.btnSlice4.Tag = "3"
        '
        'btnSlice3
        '
        Me.btnSlice3.AutoSize = True
        Me.btnSlice3.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice3.GroupIndex = 1
        Me.btnSlice3.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NEUpperRightX
        Me.btnSlice3.Location = New System.Drawing.Point(82, 22)
        Me.btnSlice3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice3.Name = "btnSlice3"
        Me.btnSlice3.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice3.TabIndex = 18
        Me.btnSlice3.TabStop = False
        Me.btnSlice3.Tag = "2"
        '
        'btnSlice2
        '
        Me.btnSlice2.AutoSize = True
        Me.btnSlice2.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice2.GroupIndex = 1
        Me.btnSlice2.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NELowerRightX
        Me.btnSlice2.Location = New System.Drawing.Point(42, 22)
        Me.btnSlice2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice2.Name = "btnSlice2"
        Me.btnSlice2.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice2.TabIndex = 17
        Me.btnSlice2.TabStop = False
        Me.btnSlice2.Tag = "1"
        '
        'btnSlice1
        '
        Me.btnSlice1.AutoSize = True
        Me.btnSlice1.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSlice1.GroupIndex = 1
        Me.btnSlice1.ImageOptions.Image = Global.FabV24_WIN8.My.Resources.Resources.NELowerLeftX
        Me.btnSlice1.Location = New System.Drawing.Point(2, 22)
        Me.btnSlice1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSlice1.Name = "btnSlice1"
        Me.btnSlice1.Size = New System.Drawing.Size(40, 47)
        Me.btnSlice1.TabIndex = 16
        Me.btnSlice1.TabStop = False
        Me.btnSlice1.Tag = "0"
        '
        'gcClosestPoint
        '
        Me.gcClosestPoint.Controls.Add(Me.mtbStartPointY)
        Me.gcClosestPoint.Controls.Add(Me.mtbStartPointX)
        Me.gcClosestPoint.Controls.Add(Me.lblLoctionY)
        Me.gcClosestPoint.Controls.Add(Me.lblLocationX)
        Me.gcClosestPoint.Location = New System.Drawing.Point(4, 66)
        Me.gcClosestPoint.Name = "gcClosestPoint"
        Me.gcClosestPoint.Size = New System.Drawing.Size(398, 70)
        Me.gcClosestPoint.TabIndex = 8
        Me.gcClosestPoint.Text = "Approximate Starting Point"
        '
        'mtbStartPointY
        '
        Me.mtbStartPointY.Location = New System.Drawing.Point(206, 34)
        Me.mtbStartPointY.Name = "mtbStartPointY"
        Me.mtbStartPointY.Size = New System.Drawing.Size(100, 20)
        Me.mtbStartPointY.TabIndex = 5
        '
        'mtbStartPointX
        '
        Me.mtbStartPointX.Location = New System.Drawing.Point(72, 34)
        Me.mtbStartPointX.Name = "mtbStartPointX"
        Me.mtbStartPointX.Size = New System.Drawing.Size(100, 20)
        Me.mtbStartPointX.TabIndex = 4
        '
        'lblLoctionY
        '
        Me.lblLoctionY.Location = New System.Drawing.Point(190, 37)
        Me.lblLoctionY.Name = "lblLoctionY"
        Me.lblLoctionY.Size = New System.Drawing.Size(10, 13)
        Me.lblLoctionY.TabIndex = 3
        Me.lblLoctionY.Text = "Y:"
        '
        'lblLocationX
        '
        Me.lblLocationX.Location = New System.Drawing.Point(10, 37)
        Me.lblLocationX.Name = "lblLocationX"
        Me.lblLocationX.Size = New System.Drawing.Size(56, 13)
        Me.lblLocationX.TabIndex = 2
        Me.lblLocationX.Text = "Location X: "
        '
        'frmCodeGen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(714, 430)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstOptions)
        Me.Controls.Add(Me.lstExtensions)
        Me.Controls.Add(Me.chkSubRoutines)
        Me.Controls.Add(Me.vgCodeGenVars)
        Me.Controls.Add(Me.chkCreateMasterFile)
        Me.Controls.Add(Me.lblExportTo)
        Me.Controls.Add(Me.fcbExportTo)
        Me.Controls.Add(Me.lblCodeGenerationFile)
        Me.Controls.Add(Me.fcbCodeGenFile)
        Me.Controls.Add(Me.cmdCNCFileExtensions)
        Me.Controls.Add(Me.cmdCompile)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cbfOptimizeToolpath)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCodeGen"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export CNC file"
        CType(Me.fcbCodeGenFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbExportTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCreateMasterFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgCodeGenVars, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSubRoutines.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstExtensions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbfOptimizeToolpath.ResumeLayout(False)
        Me.cbfOptimizeToolpath.PerformLayout()
        CType(Me.lcbGridSequence.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkZigZag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSticky.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgOptMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcStartConer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcStartConer.ResumeLayout(False)
        Me.gcStartConer.PerformLayout()
        CType(Me.gcClosestPoint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcClosestPoint.ResumeLayout(False)
        Me.gcClosestPoint.PerformLayout()
        CType(Me.mtbStartPointY.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mtbStartPointX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCompile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCNCFileExtensions As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbfOptimizeToolpath As FabV24_WIN8.WindowsApplication234.ChkBoxFrame
    Friend WithEvents fcbCodeGenFile As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblCodeGenerationFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents fcbExportTo As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents chkCreateMasterFile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rgOptMode As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents chkZigZag As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSticky As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cmdFlowchart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents vgCodeGenVars As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents gcClosestPoint As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkSubRoutines As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lstExtensions As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lstOptions As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents gcStartConer As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnSlice8 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice7 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice6 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice5 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice4 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice3 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice2 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents btnSlice1 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lcbGridSequence As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblSticky As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSequnceBy As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblExportTo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLocationX As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLoctionY As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mtbStartPointX As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mtbStartPointY As DevExpress.XtraEditors.TextEdit

End Class
