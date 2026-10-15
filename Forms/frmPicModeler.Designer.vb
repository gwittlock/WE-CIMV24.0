<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPicModeler
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPicModeler))
        Me.sbStatusBar = New System.Windows.Forms.StatusStrip()
        Me.sbStausBarStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbStatusActiveTool = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbStatusBarSelection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbStatusBarSpacer2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbStatusDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbStatusTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.picModeler = New System.Windows.Forms.PictureBox()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ribbonImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.mnuPopUpWindow = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpFull = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpPrevious = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpMeasure = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpProperties = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpEntityList = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuPopUpHotSpot = New DevExpress.XtraBars.BarButtonItem()
        Me.BarToggleSwitchItem1 = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.ribbonImageCollectionLarge = New DevExpress.Utils.ImageCollection(Me.components)
        Me.picPrint = New System.Windows.Forms.PictureBox()
        Me.defaultToolTipController1 = New DevExpress.Utils.DefaultToolTipController(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ImageCollection2 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.mnuPopUp = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.sbStatusBar.SuspendLayout()
        CType(Me.picModeler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picModeler.SuspendLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbonImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbonImageCollectionLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuPopUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sbStatusBar
        '
        Me.defaultToolTipController1.SetAllowHtmlText(Me.sbStatusBar, DevExpress.Utils.DefaultBoolean.[Default])
        Me.sbStatusBar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.sbStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbStausBarStatus, Me.sbStatusActiveTool, Me.sbStatusBarSelection, Me.sbStatusBarSpacer2, Me.sbStatusDate, Me.sbStatusTime})
        Me.sbStatusBar.Location = New System.Drawing.Point(0, 447)
        Me.sbStatusBar.Name = "sbStatusBar"
        Me.sbStatusBar.Size = New System.Drawing.Size(937, 22)
        Me.sbStatusBar.TabIndex = 0
        Me.sbStatusBar.Text = "StatusStrip1"
        '
        'sbStausBarStatus
        '
        Me.sbStausBarStatus.AutoSize = False
        Me.sbStausBarStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sbStausBarStatus.Name = "sbStausBarStatus"
        Me.sbStausBarStatus.Size = New System.Drawing.Size(250, 17)
        Me.sbStausBarStatus.Text = "Status"
        Me.sbStausBarStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbStatusActiveTool
        '
        Me.sbStatusActiveTool.AutoSize = False
        Me.sbStatusActiveTool.Name = "sbStatusActiveTool"
        Me.sbStatusActiveTool.Size = New System.Drawing.Size(200, 17)
        Me.sbStatusActiveTool.Text = "Active Tool:"
        Me.sbStatusActiveTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbStatusBarSelection
        '
        Me.sbStatusBarSelection.AutoSize = False
        Me.sbStatusBarSelection.Name = "sbStatusBarSelection"
        Me.sbStatusBarSelection.Size = New System.Drawing.Size(200, 17)
        Me.sbStatusBarSelection.Text = "Selection"
        Me.sbStatusBarSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbStatusBarSpacer2
        '
        Me.sbStatusBarSpacer2.Name = "sbStatusBarSpacer2"
        Me.sbStatusBarSpacer2.Size = New System.Drawing.Size(0, 17)
        '
        'sbStatusDate
        '
        Me.sbStatusDate.AutoSize = False
        Me.sbStatusDate.Name = "sbStatusDate"
        Me.sbStatusDate.Size = New System.Drawing.Size(150, 17)
        Me.sbStatusDate.Text = "Date:"
        Me.sbStatusDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbStatusTime
        '
        Me.sbStatusTime.Name = "sbStatusTime"
        Me.sbStatusTime.Size = New System.Drawing.Size(37, 17)
        Me.sbStatusTime.Text = "Time:"
        '
        'Button1
        '
        Me.defaultToolTipController1.SetAllowHtmlText(Me.Button1, DevExpress.Utils.DefaultBoolean.[Default])
        Me.Button1.Location = New System.Drawing.Point(379, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'picModeler
        '
        Me.defaultToolTipController1.SetAllowHtmlText(Me.picModeler, DevExpress.Utils.DefaultBoolean.[Default])
        Me.picModeler.BackColor = System.Drawing.Color.Blue
        Me.picModeler.Controls.Add(Me.barDockControlLeft)
        Me.picModeler.Controls.Add(Me.barDockControlRight)
        Me.picModeler.Controls.Add(Me.barDockControlBottom)
        Me.picModeler.Controls.Add(Me.barDockControlTop)
        Me.picModeler.Location = New System.Drawing.Point(12, 12)
        Me.picModeler.Name = "picModeler"
        Me.picModeler.Size = New System.Drawing.Size(773, 336)
        Me.picModeler.TabIndex = 2
        Me.picModeler.TabStop = False
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 336)
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me.picModeler
        Me.BarManager1.Images = Me.ribbonImageCollection
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.mnuPopUpWindow, Me.mnuPopUpFull, Me.mnuPopUpPrevious, Me.mnuPopUpRefresh, Me.mnuPopUpMeasure, Me.mnuPopUpProperties, Me.mnuPopUpDelete, Me.mnuPopUpEntityList, Me.mnuPopUpHotSpot, Me.BarToggleSwitchItem1, Me.BarCheckItem1})
        Me.BarManager1.MaxItemId = 11
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(773, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 336)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(773, 0)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(773, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 336)
        '
        'ribbonImageCollection
        '
        Me.ribbonImageCollection.ImageStream = CType(resources.GetObject("ribbonImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(9, "1_13.png")
        Me.ribbonImageCollection.Images.SetKeyName(10, "opentoolbox.png")
        Me.ribbonImageCollection.Images.SetKeyName(11, "imagesCA00WBPL.jpg")
        Me.ribbonImageCollection.Images.SetKeyName(12, "modifyEntity.png")
        Me.ribbonImageCollection.Images.SetKeyName(13, "dropdoor.png")
        Me.ribbonImageCollection.Images.SetKeyName(14, "circle-red.png")
        Me.ribbonImageCollection.Images.SetKeyName(15, "circle-green.png")
        Me.ribbonImageCollection.Images.SetKeyName(16, "green_circle16.png")
        Me.ribbonImageCollection.Images.SetKeyName(17, "diskette.gif")
        Me.ribbonImageCollection.Images.SetKeyName(18, "Relationship.png")
        Me.ribbonImageCollection.Images.SetKeyName(19, "flowchart.jpg")
        Me.ribbonImageCollection.Images.SetKeyName(20, "entitylist.png")
        Me.ribbonImageCollection.Images.SetKeyName(21, "entitylist16.png")
        Me.ribbonImageCollection.Images.SetKeyName(22, "delete.png")
        Me.ribbonImageCollection.Images.SetKeyName(23, "delete16.png")
        Me.ribbonImageCollection.Images.SetKeyName(24, "properties.png")
        Me.ribbonImageCollection.Images.SetKeyName(25, "properties16.png")
        Me.ribbonImageCollection.Images.SetKeyName(26, "measure.png")
        Me.ribbonImageCollection.Images.SetKeyName(27, "measure16.png")
        Me.ribbonImageCollection.Images.SetKeyName(28, "hotdot16.png")
        Me.ribbonImageCollection.Images.SetKeyName(29, "hotdot.png")
        Me.ribbonImageCollection.Images.SetKeyName(30, "zoomin16.png")
        Me.ribbonImageCollection.Images.SetKeyName(31, "zoomprevious16.png")
        Me.ribbonImageCollection.Images.SetKeyName(32, "zoomout16.png")
        Me.ribbonImageCollection.Images.SetKeyName(33, "zoomrefresh16.png")
        Me.ribbonImageCollection.Images.SetKeyName(34, "zoomwindow16.png")
        Me.ribbonImageCollection.Images.SetKeyName(35, "zoomfull16.png")
        Me.ribbonImageCollection.Images.SetKeyName(36, "zoomfull.png")
        Me.ribbonImageCollection.Images.SetKeyName(37, "zoomin.png")
        Me.ribbonImageCollection.Images.SetKeyName(38, "zoomout.png")
        Me.ribbonImageCollection.Images.SetKeyName(39, "zoomprevious.png")
        Me.ribbonImageCollection.Images.SetKeyName(40, "zoomrefresh.png")
        Me.ribbonImageCollection.Images.SetKeyName(41, "zoomwindow.png")
        Me.ribbonImageCollection.Images.SetKeyName(42, "zones.png")
        Me.ribbonImageCollection.Images.SetKeyName(43, "projects.png")
        Me.ribbonImageCollection.Images.SetKeyName(44, "PartOutline.png")
        Me.ribbonImageCollection.Images.SetKeyName(45, "chamfer.png")
        Me.ribbonImageCollection.Images.SetKeyName(46, "tools.png")
        Me.ribbonImageCollection.Images.SetKeyName(47, "layers.png")
        Me.ribbonImageCollection.Images.SetKeyName(48, "dropStop.jpg")
        Me.ribbonImageCollection.Images.SetKeyName(49, "FeatureRemove.png")
        Me.ribbonImageCollection.Images.SetKeyName(50, "featureInsert.png")
        Me.ribbonImageCollection.Images.SetKeyName(51, "FeatureExtract.png")
        Me.ribbonImageCollection.Images.SetKeyName(52, "FeatureAdd.png")
        Me.ribbonImageCollection.Images.SetKeyName(53, "tnt.png")
        Me.ribbonImageCollection.Images.SetKeyName(54, "editlabel.png")
        Me.ribbonImageCollection.Images.SetKeyName(55, "hole_pattern.png")
        Me.ribbonImageCollection.Images.SetKeyName(56, "edit_entity.png")
        Me.ribbonImageCollection.Images.SetKeyName(57, "attributes.png")
        Me.ribbonImageCollection.Images.SetKeyName(58, "Tool_Layer.png")
        Me.ribbonImageCollection.Images.SetKeyName(59, "trash_full.png")
        Me.ribbonImageCollection.Images.SetKeyName(60, "redo.png")
        Me.ribbonImageCollection.Images.SetKeyName(61, "undo.png")
        Me.ribbonImageCollection.Images.SetKeyName(62, "redo1 (2).png")
        Me.ribbonImageCollection.Images.SetKeyName(63, "DocumentImport.png")
        Me.ribbonImageCollection.Images.SetKeyName(64, "Undo1 (1).png")
        Me.ribbonImageCollection.Images.SetKeyName(65, "RecordDel.png")
        Me.ribbonImageCollection.Images.SetKeyName(66, "blX.gif")
        Me.ribbonImageCollection.Images.SetKeyName(67, "blY.gif")
        Me.ribbonImageCollection.Images.SetKeyName(68, "brX.gif")
        Me.ribbonImageCollection.Images.SetKeyName(69, "brY.gif")
        Me.ribbonImageCollection.Images.SetKeyName(70, "tlX.gif")
        Me.ribbonImageCollection.Images.SetKeyName(71, "tlY.gif")
        Me.ribbonImageCollection.Images.SetKeyName(72, "trX.gif")
        Me.ribbonImageCollection.Images.SetKeyName(73, "trY.gif")
        Me.ribbonImageCollection.Images.SetKeyName(74, "zones.ico")
        Me.ribbonImageCollection.Images.SetKeyName(75, "PartOutline.ico")
        Me.ribbonImageCollection.Images.SetKeyName(76, "chamfer.ico")
        Me.ribbonImageCollection.Images.SetKeyName(77, "undo.ico")
        Me.ribbonImageCollection.Images.SetKeyName(78, "redo.ico")
        Me.ribbonImageCollection.Images.SetKeyName(79, "Print_tool_Report.ico")
        Me.ribbonImageCollection.Images.SetKeyName(80, "16x16_Open_Pdb.ico")
        Me.ribbonImageCollection.Images.SetKeyName(81, "24x24_openPDB.ico")
        Me.ribbonImageCollection.Images.SetKeyName(82, "zoomout.ico")
        Me.ribbonImageCollection.Images.SetKeyName(83, "ZoomIn.ico")
        Me.ribbonImageCollection.Images.SetKeyName(84, "offset.ico")
        Me.ribbonImageCollection.Images.SetKeyName(85, "Unchain.ico")
        Me.ribbonImageCollection.Images.SetKeyName(86, "Split.ico")
        Me.ribbonImageCollection.Images.SetKeyName(87, "Fillet.ico")
        Me.ribbonImageCollection.Images.SetKeyName(88, "TrimExtend.ico")
        Me.ribbonImageCollection.Images.SetKeyName(89, "delete.ico")
        Me.ribbonImageCollection.Images.SetKeyName(90, "editholepattern.ico")
        Me.ribbonImageCollection.Images.SetKeyName(91, "explode.ico")
        Me.ribbonImageCollection.Images.SetKeyName(92, "Change_tool.ico")
        Me.ribbonImageCollection.Images.SetKeyName(93, "Copy.ico")
        Me.ribbonImageCollection.Images.SetKeyName(94, "array.ico")
        Me.ribbonImageCollection.Images.SetKeyName(95, "mirror.ico")
        Me.ribbonImageCollection.Images.SetKeyName(96, "changelayer.ico")
        Me.ribbonImageCollection.Images.SetKeyName(97, "Scale.ico")
        Me.ribbonImageCollection.Images.SetKeyName(98, "reverseorder.ico")
        Me.ribbonImageCollection.Images.SetKeyName(99, "Rotate.ico")
        Me.ribbonImageCollection.Images.SetKeyName(100, "Chain.ico")
        Me.ribbonImageCollection.Images.SetKeyName(101, "Move.ico")
        Me.ribbonImageCollection.Images.SetKeyName(102, "SelectByWindow.ico")
        Me.ribbonImageCollection.Images.SetKeyName(103, "SelectByFeature.ico")
        Me.ribbonImageCollection.Images.SetKeyName(104, "SelectProfileFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(105, "HotSpot.ico")
        Me.ribbonImageCollection.Images.SetKeyName(106, "deselectall.ico")
        Me.ribbonImageCollection.Images.SetKeyName(107, "EnableSelection.ico")
        Me.ribbonImageCollection.Images.SetKeyName(108, "SelectAll.ico")
        Me.ribbonImageCollection.Images.SetKeyName(109, "deselectAllByFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(110, "SelectAllbyFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(111, "SelectCommandFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(112, "SelectPointFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(113, "SelectToolFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(114, "SelectLayerFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(115, "SelectLineFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(116, "SelectArcFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(117, "SelectHoleFilter.ico")
        Me.ribbonImageCollection.Images.SetKeyName(118, "Arborimage.ico")
        Me.ribbonImageCollection.Images.SetKeyName(119, "Code Preview.ico")
        Me.ribbonImageCollection.Images.SetKeyName(120, "ShapeLibrary.ico")
        Me.ribbonImageCollection.Images.SetKeyName(121, "Code Generation.ico")
        Me.ribbonImageCollection.Images.SetKeyName(122, "Configuration Manager.ico")
        Me.ribbonImageCollection.Images.SetKeyName(123, "CreateHole.ico")
        Me.ribbonImageCollection.Images.SetKeyName(124, "CreateArc.ico")
        Me.ribbonImageCollection.Images.SetKeyName(125, "Create Line.ico")
        Me.ribbonImageCollection.Images.SetKeyName(126, "Nesting.ico")
        Me.ribbonImageCollection.Images.SetKeyName(127, "Barcode (2).ico")
        Me.ribbonImageCollection.Images.SetKeyName(128, "Hammer (3).ico")
        Me.ribbonImageCollection.Images.SetKeyName(129, "Folder (4).ico")
        Me.ribbonImageCollection.Images.SetKeyName(130, "Chart Down.ico")
        Me.ribbonImageCollection.Images.SetKeyName(131, "New.ico")
        Me.ribbonImageCollection.Images.SetKeyName(132, "Eraser (3).ico")
        Me.ribbonImageCollection.Images.SetKeyName(133, "OK (6).ico")
        Me.ribbonImageCollection.Images.SetKeyName(134, "Book Search (2).ico")
        Me.ribbonImageCollection.Images.SetKeyName(135, "Gear (2).ico")
        Me.ribbonImageCollection.Images.SetKeyName(136, "Floppy - 3½ Disk.ico")
        Me.ribbonImageCollection.Images.SetKeyName(137, "Blocks.ico")
        Me.ribbonImageCollection.Images.SetKeyName(138, "Molecule Box.ico")
        Me.ribbonImageCollection.Images.SetKeyName(139, "Flash Drive.ico")
        Me.ribbonImageCollection.Images.SetKeyName(140, "config.ico")
        Me.ribbonImageCollection.Images.SetKeyName(141, "Gear (32).ico")
        Me.ribbonImageCollection.Images.SetKeyName(142, "Folder (1) (open).ico")
        Me.ribbonImageCollection.Images.SetKeyName(143, "LayoutParagraph.ico")
        Me.ribbonImageCollection.Images.SetKeyName(144, "Notepad (4).ico")
        Me.ribbonImageCollection.Images.SetKeyName(145, "Lightning.ico")
        Me.ribbonImageCollection.Images.SetKeyName(146, "Explorer.ico")
        Me.ribbonImageCollection.Images.SetKeyName(147, "Flash Drive.ico")
        Me.ribbonImageCollection.Images.SetKeyName(148, "Blank_Blue.png")
        Me.ribbonImageCollection.Images.SetKeyName(149, "No_Button.png")
        '
        'mnuPopUpWindow
        '
        Me.mnuPopUpWindow.Caption = "Window"
        Me.mnuPopUpWindow.Id = 0
        Me.mnuPopUpWindow.ImageOptions.ImageIndex = 36
        Me.mnuPopUpWindow.Name = "mnuPopUpWindow"
        '
        'mnuPopUpFull
        '
        Me.mnuPopUpFull.Caption = "Full"
        Me.mnuPopUpFull.Id = 1
        Me.mnuPopUpFull.ImageOptions.ImageIndex = 34
        Me.mnuPopUpFull.Name = "mnuPopUpFull"
        '
        'mnuPopUpPrevious
        '
        Me.mnuPopUpPrevious.Caption = "Previous"
        Me.mnuPopUpPrevious.Id = 2
        Me.mnuPopUpPrevious.ImageOptions.ImageIndex = 39
        Me.mnuPopUpPrevious.Name = "mnuPopUpPrevious"
        '
        'mnuPopUpRefresh
        '
        Me.mnuPopUpRefresh.Caption = "Refresh"
        Me.mnuPopUpRefresh.Id = 3
        Me.mnuPopUpRefresh.ImageOptions.ImageIndex = 39
        Me.mnuPopUpRefresh.Name = "mnuPopUpRefresh"
        '
        'mnuPopUpMeasure
        '
        Me.mnuPopUpMeasure.Caption = "Measure"
        Me.mnuPopUpMeasure.Id = 4
        Me.mnuPopUpMeasure.ImageOptions.ImageIndex = 26
        Me.mnuPopUpMeasure.Name = "mnuPopUpMeasure"
        '
        'mnuPopUpProperties
        '
        Me.mnuPopUpProperties.Caption = "Properties"
        Me.mnuPopUpProperties.Id = 5
        Me.mnuPopUpProperties.ImageOptions.ImageIndex = 24
        Me.mnuPopUpProperties.Name = "mnuPopUpProperties"
        '
        'mnuPopUpDelete
        '
        Me.mnuPopUpDelete.Caption = "Delete"
        Me.mnuPopUpDelete.Id = 6
        Me.mnuPopUpDelete.ImageOptions.ImageIndex = 6
        Me.mnuPopUpDelete.Name = "mnuPopUpDelete"
        '
        'mnuPopUpEntityList
        '
        Me.mnuPopUpEntityList.Caption = "Entity List"
        Me.mnuPopUpEntityList.Id = 7
        Me.mnuPopUpEntityList.ImageOptions.ImageIndex = 21
        Me.mnuPopUpEntityList.Name = "mnuPopUpEntityList"
        '
        'mnuPopUpHotSpot
        '
        Me.mnuPopUpHotSpot.Caption = "Hot Spot"
        Me.mnuPopUpHotSpot.Id = 8
        Me.mnuPopUpHotSpot.ImageOptions.ImageIndex = 28
        Me.mnuPopUpHotSpot.Name = "mnuPopUpHotSpot"
        '
        'BarToggleSwitchItem1
        '
        Me.BarToggleSwitchItem1.Caption = "Hot Spot"
        Me.BarToggleSwitchItem1.Id = 9
        Me.BarToggleSwitchItem1.Name = "BarToggleSwitchItem1"
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.Caption = "Hot Spot"
        Me.BarCheckItem1.Id = 10
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'ribbonImageCollectionLarge
        '
        Me.ribbonImageCollectionLarge.ImageSize = New System.Drawing.Size(32, 32)
        Me.ribbonImageCollectionLarge.ImageStream = CType(resources.GetObject("ribbonImageCollectionLarge.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(9, "1_13.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(10, "opentoolbox.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(11, "imagesCA00WBPL.jpg")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(12, "modifyEntity.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(13, "dropdoor.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(14, "Relationship.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(15, "flowchart.jpg")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(16, "entitylist.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(17, "delete.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(18, "properties.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(19, "measure.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(20, "hotdot.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(21, "zoomfull.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(22, "zoomin.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(23, "zoomout.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(24, "zoomprevious.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(25, "zoomrefresh.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(26, "zoomwindow.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(27, "zones.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(28, "projects.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(29, "PartOutline.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(30, "chamfer.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(31, "tools.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(32, "layers.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(33, "dropStop.jpg")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(34, "FeatureRemove.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(35, "featureInsert.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(36, "FeatureExtract.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(37, "FeatureAdd.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(38, "tnt.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(39, "editlabel.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(40, "hole_pattern.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(41, "edit_entity.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(42, "attributes.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(43, "Tool_Layer.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(44, "trash_full.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(45, "redo.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(46, "undo.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(47, "redo1 (2).png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(48, "DocumentImport.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(49, "Undo1 (1).png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(50, "RecordDel.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(51, "zones.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(52, "PartOutline.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(53, "chamfer.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(54, "undo.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(55, "redo.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(56, "Print_tool_Report.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(57, "16x16_Open_Pdb.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(58, "24x24_openPDB.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(59, "zoomout.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(60, "ZoomIn.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(61, "offset.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(62, "Unchain.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(63, "Split.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(64, "Fillet.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(65, "TrimExtend.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(66, "delete.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(67, "editholepattern.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(68, "explode.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(69, "Change_tool.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(70, "Copy.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(71, "array.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(72, "mirror.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(73, "changelayer.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(74, "Scale.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(75, "reverseorder.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(76, "Rotate.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(77, "Chain.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(78, "Move.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(79, "SelectByWindow.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(80, "SelectByFeature.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(81, "SelectProfileFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(82, "HotSpot.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(83, "deselectall.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(84, "EnableSelection.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(85, "SelectAll.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(86, "deselectAllByFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(87, "SelectAllbyFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(88, "SelectCommandFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(89, "SelectPointFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(90, "SelectToolFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(91, "SelectLayerFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(92, "SelectLineFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(93, "SelectArcFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(94, "SelectHoleFilter.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(95, "Arborimage.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(96, "Code Preview.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(97, "ShapeLibrary.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(98, "Code Generation.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(99, "Configuration Manager.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(100, "CreateHole.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(101, "CreateArc.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(102, "Nesting.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(103, "Barcode (2).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(104, "line.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(105, "Hammer (3).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(106, "Folder (4).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(107, "Chart Down.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(108, "New.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(109, "Eraser (3).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(110, "OK (6).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(111, "Book Search (2).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(112, "Gear (2).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(113, "Floppy - 3½ Disk.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(114, "Blocks.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(115, "Molecule Box.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(116, "Flash Drive.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(117, "config.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(118, "Gear (32).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(119, "Folder (1) (open).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(120, "LayoutParagraph.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(121, "Notepad (4).ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(122, "Lightning.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(123, "Explorer.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(124, "DocumentFromTemplate.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(126, "delete.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(127, "icon_magic[1].png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(128, "disassociate.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(129, "Zoom11.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(130, "zoomnext.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(131, "SearchDocument.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(132, "TravelDistance.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(133, "highway_icon.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(134, "monitor.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(135, "line.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(136, "arc.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(137, "hole.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(138, "point.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(139, "rubberband.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(140, "boundingbox.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(141, "Associate.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(142, "autotool.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(143, "LayerMap.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(144, "manual_leadin.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(145, "AutoLead.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(146, "notch.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(147, "shakertab.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(148, "Command.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(149, "Slit.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(150, "linearclear.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(151, "areaclear.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(152, "ShapeLibrary.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(153, "cutback.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(154, "dropstop.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(155, "chaincut.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(156, "champher.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(157, "fillert.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(158, "bump.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(159, "Rotate.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(160, "zones.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(161, "mirror.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(162, "Split.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(163, "TrimExtend.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(164, "Copy.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(165, "Move.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(166, "Scale.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(167, "extract.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(168, "clamps.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(169, "reposition.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(170, "editProject.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(171, "IndvHits.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(172, "Unchain.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(173, "Chain.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(174, "reverseorder.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(175, "sequenceorder.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(176, "ConfigMan.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(177, "Nesting.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(178, "CodePreview.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(179, "CadToCode.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(180, "Remnant.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(181, "MacExecute.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(182, "MacConfig.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(183, "CreatePattern.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(184, "CreateInstance.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(185, "GridNest.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(186, "StaggerNest.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(187, "SkeletonCutOff.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(188, "NestSettings.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(189, "EWM.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(190, "48X48DumpTruck.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(191, "player_play (1).png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(192, "player_stop.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(193, "player_record.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(194, "portal.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(195, "softwarebug.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(196, "ManPushingPuzzle.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(197, "bump4.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(198, "Layers.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(199, "ToolBox.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(200, "welcome.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(201, "welcome_title.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(202, "welcome_icon.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(203, "Wood_Welcome.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(204, "450px-imagem_2.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(205, "Auto_nesting3.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(206, "DeActivateLicense.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(207, "bm.ico")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(208, "Blank_Blue.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(209, "No_Button.png")
        '
        'picPrint
        '
        Me.defaultToolTipController1.SetAllowHtmlText(Me.picPrint, DevExpress.Utils.DefaultBoolean.[Default])
        Me.picPrint.BackColor = System.Drawing.Color.Black
        Me.picPrint.Location = New System.Drawing.Point(388, 200)
        Me.picPrint.Name = "picPrint"
        Me.picPrint.Size = New System.Drawing.Size(100, 50)
        Me.picPrint.TabIndex = 3
        Me.picPrint.TabStop = False
        '
        'defaultToolTipController1
        '
        '
        '
        '
        Me.defaultToolTipController1.DefaultController.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.defaultToolTipController1.DefaultController.Appearance.ForeColor = System.Drawing.Color.Black
        Me.defaultToolTipController1.DefaultController.Appearance.Options.UseBackColor = True
        Me.defaultToolTipController1.DefaultController.Appearance.Options.UseForeColor = True
        Me.defaultToolTipController1.DefaultController.Appearance.Options.UseTextOptions = True
        Me.defaultToolTipController1.DefaultController.AutoPopDelay = 8000
        Me.defaultToolTipController1.DefaultController.CloseOnClick = DevExpress.Utils.DefaultBoolean.[True]
        Me.defaultToolTipController1.DefaultController.Rounded = True
        Me.defaultToolTipController1.DefaultController.ShowBeak = True
        Me.defaultToolTipController1.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip
        '
        'Label1
        '
        Me.defaultToolTipController1.SetAllowHtmlText(Me.Label1, DevExpress.Utils.DefaultBoolean.[Default])
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(102, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(513, 55)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tghis Is frmPicmodeler"
        '
        'Bar1
        '
        Me.Bar1.BarName = "Custom 2"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Text = "Custom 2"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "Ribbon_New_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "Ribbon_Open_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "Ribbon_Close_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(3, "Ribbon_Find_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(4, "Ribbon_Save_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(6, "Ribbon_Exit_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(7, "Ribbon_Content_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(8, "Ribbon_Info_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(9, "1_13.png")
        Me.ImageCollection1.Images.SetKeyName(10, "opentoolbox.png")
        Me.ImageCollection1.Images.SetKeyName(11, "imagesCA00WBPL.jpg")
        Me.ImageCollection1.Images.SetKeyName(12, "modifyEntity.png")
        Me.ImageCollection1.Images.SetKeyName(13, "dropdoor.png")
        Me.ImageCollection1.Images.SetKeyName(14, "circle-red.png")
        Me.ImageCollection1.Images.SetKeyName(15, "circle-green.png")
        Me.ImageCollection1.Images.SetKeyName(16, "green_circle16.png")
        Me.ImageCollection1.Images.SetKeyName(17, "diskette.gif")
        Me.ImageCollection1.Images.SetKeyName(18, "Relationship.png")
        Me.ImageCollection1.Images.SetKeyName(19, "flowchart.jpg")
        Me.ImageCollection1.Images.SetKeyName(20, "entitylist.png")
        Me.ImageCollection1.Images.SetKeyName(21, "entitylist16.png")
        Me.ImageCollection1.Images.SetKeyName(22, "delete.png")
        Me.ImageCollection1.Images.SetKeyName(23, "delete16.png")
        Me.ImageCollection1.Images.SetKeyName(24, "properties.png")
        Me.ImageCollection1.Images.SetKeyName(25, "properties16.png")
        Me.ImageCollection1.Images.SetKeyName(26, "measure.png")
        Me.ImageCollection1.Images.SetKeyName(27, "measure16.png")
        Me.ImageCollection1.Images.SetKeyName(28, "hotdot16.png")
        Me.ImageCollection1.Images.SetKeyName(29, "hotdot.png")
        Me.ImageCollection1.Images.SetKeyName(30, "zoomin16.png")
        Me.ImageCollection1.Images.SetKeyName(31, "zoomprevious16.png")
        Me.ImageCollection1.Images.SetKeyName(32, "zoomout16.png")
        Me.ImageCollection1.Images.SetKeyName(33, "zoomrefresh16.png")
        Me.ImageCollection1.Images.SetKeyName(34, "zoomwindow16.png")
        Me.ImageCollection1.Images.SetKeyName(35, "zoomfull16.png")
        Me.ImageCollection1.Images.SetKeyName(36, "zoomfull.png")
        Me.ImageCollection1.Images.SetKeyName(37, "zoomin.png")
        Me.ImageCollection1.Images.SetKeyName(38, "zoomout.png")
        Me.ImageCollection1.Images.SetKeyName(39, "zoomprevious.png")
        Me.ImageCollection1.Images.SetKeyName(40, "zoomrefresh.png")
        Me.ImageCollection1.Images.SetKeyName(41, "zoomwindow.png")
        Me.ImageCollection1.Images.SetKeyName(42, "zones.png")
        Me.ImageCollection1.Images.SetKeyName(43, "projects.png")
        Me.ImageCollection1.Images.SetKeyName(44, "PartOutline.png")
        Me.ImageCollection1.Images.SetKeyName(45, "chamfer.png")
        Me.ImageCollection1.Images.SetKeyName(46, "tools.png")
        Me.ImageCollection1.Images.SetKeyName(47, "layers.png")
        Me.ImageCollection1.Images.SetKeyName(48, "dropStop.jpg")
        Me.ImageCollection1.Images.SetKeyName(49, "FeatureRemove.png")
        Me.ImageCollection1.Images.SetKeyName(50, "featureInsert.png")
        Me.ImageCollection1.Images.SetKeyName(51, "FeatureExtract.png")
        Me.ImageCollection1.Images.SetKeyName(52, "FeatureAdd.png")
        Me.ImageCollection1.Images.SetKeyName(53, "tnt.png")
        Me.ImageCollection1.Images.SetKeyName(54, "editlabel.png")
        Me.ImageCollection1.Images.SetKeyName(55, "hole_pattern.png")
        Me.ImageCollection1.Images.SetKeyName(56, "edit_entity.png")
        Me.ImageCollection1.Images.SetKeyName(57, "attributes.png")
        Me.ImageCollection1.Images.SetKeyName(58, "Tool_Layer.png")
        Me.ImageCollection1.Images.SetKeyName(59, "trash_full.png")
        Me.ImageCollection1.Images.SetKeyName(60, "redo.png")
        Me.ImageCollection1.Images.SetKeyName(61, "undo.png")
        Me.ImageCollection1.Images.SetKeyName(62, "redo1 (2).png")
        Me.ImageCollection1.Images.SetKeyName(63, "DocumentImport.png")
        Me.ImageCollection1.Images.SetKeyName(64, "Undo1 (1).png")
        Me.ImageCollection1.Images.SetKeyName(65, "RecordDel.png")
        Me.ImageCollection1.Images.SetKeyName(66, "blX.gif")
        Me.ImageCollection1.Images.SetKeyName(67, "blY.gif")
        Me.ImageCollection1.Images.SetKeyName(68, "brX.gif")
        Me.ImageCollection1.Images.SetKeyName(69, "brY.gif")
        Me.ImageCollection1.Images.SetKeyName(70, "tlX.gif")
        Me.ImageCollection1.Images.SetKeyName(71, "tlY.gif")
        Me.ImageCollection1.Images.SetKeyName(72, "trX.gif")
        Me.ImageCollection1.Images.SetKeyName(73, "trY.gif")
        Me.ImageCollection1.Images.SetKeyName(74, "zones.ico")
        Me.ImageCollection1.Images.SetKeyName(75, "PartOutline.ico")
        Me.ImageCollection1.Images.SetKeyName(76, "chamfer.ico")
        Me.ImageCollection1.Images.SetKeyName(77, "undo.ico")
        Me.ImageCollection1.Images.SetKeyName(78, "redo.ico")
        Me.ImageCollection1.Images.SetKeyName(79, "Print_tool_Report.ico")
        Me.ImageCollection1.Images.SetKeyName(80, "16x16_Open_Pdb.ico")
        Me.ImageCollection1.Images.SetKeyName(81, "24x24_openPDB.ico")
        Me.ImageCollection1.Images.SetKeyName(82, "zoomout.ico")
        Me.ImageCollection1.Images.SetKeyName(83, "ZoomIn.ico")
        Me.ImageCollection1.Images.SetKeyName(84, "offset.ico")
        Me.ImageCollection1.Images.SetKeyName(85, "Unchain.ico")
        Me.ImageCollection1.Images.SetKeyName(86, "Split.ico")
        Me.ImageCollection1.Images.SetKeyName(87, "Fillet.ico")
        Me.ImageCollection1.Images.SetKeyName(88, "TrimExtend.ico")
        Me.ImageCollection1.Images.SetKeyName(89, "delete.ico")
        Me.ImageCollection1.Images.SetKeyName(90, "editholepattern.ico")
        Me.ImageCollection1.Images.SetKeyName(91, "explode.ico")
        Me.ImageCollection1.Images.SetKeyName(92, "Change_tool.ico")
        Me.ImageCollection1.Images.SetKeyName(93, "Copy.ico")
        Me.ImageCollection1.Images.SetKeyName(94, "array.ico")
        Me.ImageCollection1.Images.SetKeyName(95, "mirror.ico")
        Me.ImageCollection1.Images.SetKeyName(96, "changelayer.ico")
        Me.ImageCollection1.Images.SetKeyName(97, "Scale.ico")
        Me.ImageCollection1.Images.SetKeyName(98, "reverseorder.ico")
        Me.ImageCollection1.Images.SetKeyName(99, "Rotate.ico")
        Me.ImageCollection1.Images.SetKeyName(100, "Chain.ico")
        Me.ImageCollection1.Images.SetKeyName(101, "Move.ico")
        Me.ImageCollection1.Images.SetKeyName(102, "SelectByWindow.ico")
        Me.ImageCollection1.Images.SetKeyName(103, "SelectByFeature.ico")
        Me.ImageCollection1.Images.SetKeyName(104, "SelectProfileFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(105, "HotSpot.ico")
        Me.ImageCollection1.Images.SetKeyName(106, "deselectall.ico")
        Me.ImageCollection1.Images.SetKeyName(107, "EnableSelection.ico")
        Me.ImageCollection1.Images.SetKeyName(108, "SelectAll.ico")
        Me.ImageCollection1.Images.SetKeyName(109, "deselectAllByFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(110, "SelectAllbyFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(111, "SelectCommandFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(112, "SelectPointFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(113, "SelectToolFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(114, "SelectLayerFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(115, "SelectLineFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(116, "SelectArcFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(117, "SelectHoleFilter.ico")
        Me.ImageCollection1.Images.SetKeyName(118, "Arborimage.ico")
        Me.ImageCollection1.Images.SetKeyName(119, "Code Preview.ico")
        Me.ImageCollection1.Images.SetKeyName(120, "ShapeLibrary.ico")
        Me.ImageCollection1.Images.SetKeyName(121, "Code Generation.ico")
        Me.ImageCollection1.Images.SetKeyName(122, "Configuration Manager.ico")
        Me.ImageCollection1.Images.SetKeyName(123, "CreateHole.ico")
        Me.ImageCollection1.Images.SetKeyName(124, "CreateArc.ico")
        Me.ImageCollection1.Images.SetKeyName(125, "Create Line.ico")
        Me.ImageCollection1.Images.SetKeyName(126, "Nesting.ico")
        Me.ImageCollection1.Images.SetKeyName(127, "Barcode (2).ico")
        Me.ImageCollection1.Images.SetKeyName(128, "Hammer (3).ico")
        Me.ImageCollection1.Images.SetKeyName(129, "Folder (4).ico")
        Me.ImageCollection1.Images.SetKeyName(130, "Chart Down.ico")
        Me.ImageCollection1.Images.SetKeyName(131, "New.ico")
        Me.ImageCollection1.Images.SetKeyName(132, "Eraser (3).ico")
        Me.ImageCollection1.Images.SetKeyName(133, "OK (6).ico")
        Me.ImageCollection1.Images.SetKeyName(134, "Book Search (2).ico")
        Me.ImageCollection1.Images.SetKeyName(135, "Gear (2).ico")
        Me.ImageCollection1.Images.SetKeyName(136, "Floppy - 3½ Disk.ico")
        Me.ImageCollection1.Images.SetKeyName(137, "Blocks.ico")
        Me.ImageCollection1.Images.SetKeyName(138, "Molecule Box.ico")
        Me.ImageCollection1.Images.SetKeyName(139, "Flash Drive.ico")
        Me.ImageCollection1.Images.SetKeyName(140, "config.ico")
        Me.ImageCollection1.Images.SetKeyName(141, "Gear (32).ico")
        Me.ImageCollection1.Images.SetKeyName(142, "Folder (1) (open).ico")
        Me.ImageCollection1.Images.SetKeyName(143, "LayoutParagraph.ico")
        Me.ImageCollection1.Images.SetKeyName(144, "Notepad (4).ico")
        Me.ImageCollection1.Images.SetKeyName(145, "Lightning.ico")
        Me.ImageCollection1.Images.SetKeyName(146, "Explorer.ico")
        Me.ImageCollection1.Images.SetKeyName(147, "Flash Drive.ico")
        '
        'ImageCollection2
        '
        Me.ImageCollection2.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageCollection2.ImageStream = CType(resources.GetObject("ImageCollection2.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection2.Images.SetKeyName(0, "Ribbon_New_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(1, "Ribbon_Open_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(2, "Ribbon_Close_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(3, "Ribbon_Find_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(4, "Ribbon_Save_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(6, "Ribbon_Exit_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(7, "Ribbon_Content_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(8, "Ribbon_Info_32x32.png")
        Me.ImageCollection2.Images.SetKeyName(9, "1_13.png")
        Me.ImageCollection2.Images.SetKeyName(10, "opentoolbox.png")
        Me.ImageCollection2.Images.SetKeyName(11, "imagesCA00WBPL.jpg")
        Me.ImageCollection2.Images.SetKeyName(12, "modifyEntity.png")
        Me.ImageCollection2.Images.SetKeyName(13, "dropdoor.png")
        Me.ImageCollection2.Images.SetKeyName(14, "Relationship.png")
        Me.ImageCollection2.Images.SetKeyName(15, "flowchart.jpg")
        Me.ImageCollection2.Images.SetKeyName(16, "entitylist.png")
        Me.ImageCollection2.Images.SetKeyName(17, "delete.png")
        Me.ImageCollection2.Images.SetKeyName(18, "properties.png")
        Me.ImageCollection2.Images.SetKeyName(19, "measure.png")
        Me.ImageCollection2.Images.SetKeyName(20, "hotdot.png")
        Me.ImageCollection2.Images.SetKeyName(21, "zoomfull.png")
        Me.ImageCollection2.Images.SetKeyName(22, "zoomin.png")
        Me.ImageCollection2.Images.SetKeyName(23, "zoomout.png")
        Me.ImageCollection2.Images.SetKeyName(24, "zoomprevious.png")
        Me.ImageCollection2.Images.SetKeyName(25, "zoomrefresh.png")
        Me.ImageCollection2.Images.SetKeyName(26, "zoomwindow.png")
        Me.ImageCollection2.Images.SetKeyName(27, "zones.png")
        Me.ImageCollection2.Images.SetKeyName(28, "projects.png")
        Me.ImageCollection2.Images.SetKeyName(29, "PartOutline.png")
        Me.ImageCollection2.Images.SetKeyName(30, "chamfer.png")
        Me.ImageCollection2.Images.SetKeyName(31, "tools.png")
        Me.ImageCollection2.Images.SetKeyName(32, "layers.png")
        Me.ImageCollection2.Images.SetKeyName(33, "dropStop.jpg")
        Me.ImageCollection2.Images.SetKeyName(34, "FeatureRemove.png")
        Me.ImageCollection2.Images.SetKeyName(35, "featureInsert.png")
        Me.ImageCollection2.Images.SetKeyName(36, "FeatureExtract.png")
        Me.ImageCollection2.Images.SetKeyName(37, "FeatureAdd.png")
        Me.ImageCollection2.Images.SetKeyName(38, "tnt.png")
        Me.ImageCollection2.Images.SetKeyName(39, "editlabel.png")
        Me.ImageCollection2.Images.SetKeyName(40, "hole_pattern.png")
        Me.ImageCollection2.Images.SetKeyName(41, "edit_entity.png")
        Me.ImageCollection2.Images.SetKeyName(42, "attributes.png")
        Me.ImageCollection2.Images.SetKeyName(43, "Tool_Layer.png")
        Me.ImageCollection2.Images.SetKeyName(44, "trash_full.png")
        Me.ImageCollection2.Images.SetKeyName(45, "redo.png")
        Me.ImageCollection2.Images.SetKeyName(46, "undo.png")
        Me.ImageCollection2.Images.SetKeyName(47, "redo1 (2).png")
        Me.ImageCollection2.Images.SetKeyName(48, "DocumentImport.png")
        Me.ImageCollection2.Images.SetKeyName(49, "Undo1 (1).png")
        Me.ImageCollection2.Images.SetKeyName(50, "RecordDel.png")
        Me.ImageCollection2.Images.SetKeyName(51, "zones.ico")
        Me.ImageCollection2.Images.SetKeyName(52, "PartOutline.ico")
        Me.ImageCollection2.Images.SetKeyName(53, "chamfer.ico")
        Me.ImageCollection2.Images.SetKeyName(54, "undo.ico")
        Me.ImageCollection2.Images.SetKeyName(55, "redo.ico")
        Me.ImageCollection2.Images.SetKeyName(56, "Print_tool_Report.ico")
        Me.ImageCollection2.Images.SetKeyName(57, "16x16_Open_Pdb.ico")
        Me.ImageCollection2.Images.SetKeyName(58, "24x24_openPDB.ico")
        Me.ImageCollection2.Images.SetKeyName(59, "zoomout.ico")
        Me.ImageCollection2.Images.SetKeyName(60, "ZoomIn.ico")
        Me.ImageCollection2.Images.SetKeyName(61, "offset.ico")
        Me.ImageCollection2.Images.SetKeyName(62, "Unchain.ico")
        Me.ImageCollection2.Images.SetKeyName(63, "Split.ico")
        Me.ImageCollection2.Images.SetKeyName(64, "Fillet.ico")
        Me.ImageCollection2.Images.SetKeyName(65, "TrimExtend.ico")
        Me.ImageCollection2.Images.SetKeyName(66, "delete.ico")
        Me.ImageCollection2.Images.SetKeyName(67, "editholepattern.ico")
        Me.ImageCollection2.Images.SetKeyName(68, "explode.ico")
        Me.ImageCollection2.Images.SetKeyName(69, "Change_tool.ico")
        Me.ImageCollection2.Images.SetKeyName(70, "Copy.ico")
        Me.ImageCollection2.Images.SetKeyName(71, "array.ico")
        Me.ImageCollection2.Images.SetKeyName(72, "mirror.ico")
        Me.ImageCollection2.Images.SetKeyName(73, "changelayer.ico")
        Me.ImageCollection2.Images.SetKeyName(74, "Scale.ico")
        Me.ImageCollection2.Images.SetKeyName(75, "reverseorder.ico")
        Me.ImageCollection2.Images.SetKeyName(76, "Rotate.ico")
        Me.ImageCollection2.Images.SetKeyName(77, "Chain.ico")
        Me.ImageCollection2.Images.SetKeyName(78, "Move.ico")
        Me.ImageCollection2.Images.SetKeyName(79, "SelectByWindow.ico")
        Me.ImageCollection2.Images.SetKeyName(80, "SelectByFeature.ico")
        Me.ImageCollection2.Images.SetKeyName(81, "SelectProfileFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(82, "HotSpot.ico")
        Me.ImageCollection2.Images.SetKeyName(83, "deselectall.ico")
        Me.ImageCollection2.Images.SetKeyName(84, "EnableSelection.ico")
        Me.ImageCollection2.Images.SetKeyName(85, "SelectAll.ico")
        Me.ImageCollection2.Images.SetKeyName(86, "deselectAllByFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(87, "SelectAllbyFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(88, "SelectCommandFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(89, "SelectPointFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(90, "SelectToolFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(91, "SelectLayerFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(92, "SelectLineFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(93, "SelectArcFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(94, "SelectHoleFilter.ico")
        Me.ImageCollection2.Images.SetKeyName(95, "Arborimage.ico")
        Me.ImageCollection2.Images.SetKeyName(96, "Code Preview.ico")
        Me.ImageCollection2.Images.SetKeyName(97, "ShapeLibrary.ico")
        Me.ImageCollection2.Images.SetKeyName(98, "Code Generation.ico")
        Me.ImageCollection2.Images.SetKeyName(99, "Configuration Manager.ico")
        Me.ImageCollection2.Images.SetKeyName(100, "CreateHole.ico")
        Me.ImageCollection2.Images.SetKeyName(101, "CreateArc.ico")
        Me.ImageCollection2.Images.SetKeyName(102, "Nesting.ico")
        Me.ImageCollection2.Images.SetKeyName(103, "Barcode (2).ico")
        Me.ImageCollection2.Images.SetKeyName(104, "line.ico")
        Me.ImageCollection2.Images.SetKeyName(105, "Hammer (3).ico")
        Me.ImageCollection2.Images.SetKeyName(106, "Folder (4).ico")
        Me.ImageCollection2.Images.SetKeyName(107, "Chart Down.ico")
        Me.ImageCollection2.Images.SetKeyName(108, "New.ico")
        Me.ImageCollection2.Images.SetKeyName(109, "Eraser (3).ico")
        Me.ImageCollection2.Images.SetKeyName(110, "OK (6).ico")
        Me.ImageCollection2.Images.SetKeyName(111, "Book Search (2).ico")
        Me.ImageCollection2.Images.SetKeyName(112, "Gear (2).ico")
        Me.ImageCollection2.Images.SetKeyName(113, "Floppy - 3½ Disk.ico")
        Me.ImageCollection2.Images.SetKeyName(114, "Blocks.ico")
        Me.ImageCollection2.Images.SetKeyName(115, "Molecule Box.ico")
        Me.ImageCollection2.Images.SetKeyName(116, "Flash Drive.ico")
        Me.ImageCollection2.Images.SetKeyName(117, "config.ico")
        Me.ImageCollection2.Images.SetKeyName(118, "Gear (32).ico")
        Me.ImageCollection2.Images.SetKeyName(119, "Folder (1) (open).ico")
        Me.ImageCollection2.Images.SetKeyName(120, "LayoutParagraph.ico")
        Me.ImageCollection2.Images.SetKeyName(121, "Notepad (4).ico")
        Me.ImageCollection2.Images.SetKeyName(122, "Lightning.ico")
        Me.ImageCollection2.Images.SetKeyName(123, "Explorer.ico")
        Me.ImageCollection2.Images.SetKeyName(124, "DocumentFromTemplate.png")
        Me.ImageCollection2.Images.SetKeyName(126, "delete.png")
        Me.ImageCollection2.Images.SetKeyName(127, "icon_magic[1].png")
        Me.ImageCollection2.Images.SetKeyName(128, "disassociate.png")
        Me.ImageCollection2.Images.SetKeyName(129, "Zoom11.png")
        Me.ImageCollection2.Images.SetKeyName(130, "zoomnext.png")
        Me.ImageCollection2.Images.SetKeyName(131, "SearchDocument.png")
        Me.ImageCollection2.Images.SetKeyName(132, "TravelDistance.png")
        Me.ImageCollection2.Images.SetKeyName(133, "highway_icon.png")
        Me.ImageCollection2.Images.SetKeyName(134, "monitor.png")
        Me.ImageCollection2.Images.SetKeyName(135, "line.ico")
        Me.ImageCollection2.Images.SetKeyName(136, "arc.ico")
        Me.ImageCollection2.Images.SetKeyName(137, "hole.ico")
        Me.ImageCollection2.Images.SetKeyName(138, "point.ico")
        Me.ImageCollection2.Images.SetKeyName(139, "rubberband.ico")
        Me.ImageCollection2.Images.SetKeyName(140, "boundingbox.ico")
        Me.ImageCollection2.Images.SetKeyName(141, "Associate.png")
        Me.ImageCollection2.Images.SetKeyName(142, "autotool.ico")
        Me.ImageCollection2.Images.SetKeyName(143, "LayerMap.ico")
        Me.ImageCollection2.Images.SetKeyName(144, "manual_leadin.ico")
        Me.ImageCollection2.Images.SetKeyName(145, "AutoLead.ico")
        Me.ImageCollection2.Images.SetKeyName(146, "notch.ico")
        Me.ImageCollection2.Images.SetKeyName(147, "shakertab.ico")
        Me.ImageCollection2.Images.SetKeyName(148, "Command.ico")
        Me.ImageCollection2.Images.SetKeyName(149, "Slit.ico")
        Me.ImageCollection2.Images.SetKeyName(150, "linearclear.ico")
        Me.ImageCollection2.Images.SetKeyName(151, "areaclear.ico")
        Me.ImageCollection2.Images.SetKeyName(152, "ShapeLibrary.ico")
        Me.ImageCollection2.Images.SetKeyName(153, "cutback.ico")
        Me.ImageCollection2.Images.SetKeyName(154, "dropstop.ico")
        Me.ImageCollection2.Images.SetKeyName(155, "chaincut.ico")
        Me.ImageCollection2.Images.SetKeyName(156, "champher.ico")
        Me.ImageCollection2.Images.SetKeyName(157, "fillert.ico")
        Me.ImageCollection2.Images.SetKeyName(158, "bump.ico")
        Me.ImageCollection2.Images.SetKeyName(159, "Rotate.ico")
        Me.ImageCollection2.Images.SetKeyName(160, "zones.ico")
        Me.ImageCollection2.Images.SetKeyName(161, "mirror.ico")
        Me.ImageCollection2.Images.SetKeyName(162, "Split.ico")
        Me.ImageCollection2.Images.SetKeyName(163, "TrimExtend.ico")
        Me.ImageCollection2.Images.SetKeyName(164, "Copy.ico")
        Me.ImageCollection2.Images.SetKeyName(165, "Move.ico")
        Me.ImageCollection2.Images.SetKeyName(166, "Scale.ico")
        Me.ImageCollection2.Images.SetKeyName(167, "extract.ico")
        Me.ImageCollection2.Images.SetKeyName(168, "clamps.ico")
        Me.ImageCollection2.Images.SetKeyName(169, "reposition.ico")
        Me.ImageCollection2.Images.SetKeyName(170, "editProject.ico")
        Me.ImageCollection2.Images.SetKeyName(171, "IndvHits.ico")
        Me.ImageCollection2.Images.SetKeyName(172, "Unchain.ico")
        Me.ImageCollection2.Images.SetKeyName(173, "Chain.ico")
        Me.ImageCollection2.Images.SetKeyName(174, "reverseorder.ico")
        Me.ImageCollection2.Images.SetKeyName(175, "sequenceorder.ico")
        Me.ImageCollection2.Images.SetKeyName(176, "ConfigMan.ico")
        Me.ImageCollection2.Images.SetKeyName(177, "Nesting.ico")
        Me.ImageCollection2.Images.SetKeyName(178, "CodePreview.ico")
        Me.ImageCollection2.Images.SetKeyName(179, "CadToCode.ico")
        Me.ImageCollection2.Images.SetKeyName(180, "Remnant.ico")
        Me.ImageCollection2.Images.SetKeyName(181, "MacExecute.ico")
        Me.ImageCollection2.Images.SetKeyName(182, "MacConfig.ico")
        Me.ImageCollection2.Images.SetKeyName(183, "CreatePattern.png")
        Me.ImageCollection2.Images.SetKeyName(184, "CreateInstance.png")
        Me.ImageCollection2.Images.SetKeyName(185, "GridNest.png")
        Me.ImageCollection2.Images.SetKeyName(186, "StaggerNest.png")
        Me.ImageCollection2.Images.SetKeyName(187, "SkeletonCutOff.png")
        Me.ImageCollection2.Images.SetKeyName(188, "NestSettings.png")
        Me.ImageCollection2.Images.SetKeyName(189, "EWM.png")
        Me.ImageCollection2.Images.SetKeyName(190, "48X48DumpTruck.png")
        Me.ImageCollection2.Images.SetKeyName(191, "player_play (1).png")
        Me.ImageCollection2.Images.SetKeyName(192, "player_stop.png")
        Me.ImageCollection2.Images.SetKeyName(193, "player_record.png")
        Me.ImageCollection2.Images.SetKeyName(194, "portal.png")
        Me.ImageCollection2.Images.SetKeyName(195, "softwarebug.png")
        Me.ImageCollection2.Images.SetKeyName(196, "ManPushingPuzzle.png")
        Me.ImageCollection2.Images.SetKeyName(197, "bump4.png")
        Me.ImageCollection2.Images.SetKeyName(198, "Layers.png")
        Me.ImageCollection2.Images.SetKeyName(199, "ToolBox.png")
        Me.ImageCollection2.Images.SetKeyName(200, "welcome.ico")
        Me.ImageCollection2.Images.SetKeyName(201, "welcome_title.png")
        Me.ImageCollection2.Images.SetKeyName(202, "welcome_icon.png")
        Me.ImageCollection2.Images.SetKeyName(203, "Wood_Welcome.png")
        Me.ImageCollection2.Images.SetKeyName(204, "450px-imagem_2.png")
        Me.ImageCollection2.Images.SetKeyName(205, "Auto_nesting3.png")
        Me.ImageCollection2.Images.SetKeyName(206, "DeActivateLicense.png")
        Me.ImageCollection2.Images.SetKeyName(207, "bm.ico")
        '
        'mnuPopUp
        '
        Me.mnuPopUp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpWindow), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpFull), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpPrevious), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpHotSpot, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpMeasure, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpProperties), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpDelete, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuPopUpEntityList, True)})
        Me.mnuPopUp.Manager = Me.BarManager1
        Me.mnuPopUp.Name = "mnuPopUp"
        '
        'frmPicModeler
        '
        Me.defaultToolTipController1.SetAllowHtmlText(Me, DevExpress.Utils.DefaultBoolean.[Default])
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.ClientSize = New System.Drawing.Size(937, 469)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.picModeler)
        Me.Controls.Add(Me.picPrint)
        Me.Controls.Add(Me.sbStatusBar)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPicModeler"
        Me.Text = "frmPicModelr"
        Me.sbStatusBar.ResumeLayout(False)
        Me.sbStatusBar.PerformLayout()
        CType(Me.picModeler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picModeler.ResumeLayout(False)
        Me.picModeler.PerformLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbonImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbonImageCollectionLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuPopUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents sbStausBarStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbStatusActiveTool As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbStatusBarSelection As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbStatusBarSpacer2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbStatusDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents sbStatusTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents picModeler As System.Windows.Forms.PictureBox
    Friend WithEvents picPrint As System.Windows.Forms.PictureBox
    Private WithEvents defaultToolTipController1 As DevExpress.Utils.DefaultToolTipController
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private WithEvents ribbonImageCollectionLarge As DevExpress.Utils.ImageCollection
    Private WithEvents ribbonImageCollection As DevExpress.Utils.ImageCollection
    Private WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Private WithEvents ImageCollection2 As DevExpress.Utils.ImageCollection
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuPopUpWindow As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpFull As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUp As DevExpress.XtraBars.PopupMenu
    Friend WithEvents mnuPopUpPrevious As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpMeasure As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpProperties As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpEntityList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPopUpHotSpot As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarToggleSwitchItem1 As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
