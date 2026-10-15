<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddMulti
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.fgList = New LogicNP.FileViewControl.FileView(Me.components)
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.picPreview1 = New System.Windows.Forms.PictureBox()
        Me.picPreview = New System.Windows.Forms.Panel()
        Me.SplitterControl2 = New DevExpress.XtraEditors.SplitterControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.fldrVw = New LogicNP.FolderViewControl.FolderView()
        Me.lblDimensions = New DevExpress.XtraEditors.LabelControl()
        Me.lblFileType = New DevExpress.XtraEditors.LabelControl()
        Me.cboFileType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblDefaultQTY = New DevExpress.XtraEditors.LabelControl()
        Me.lblDefaultRotation = New DevExpress.XtraEditors.LabelControl()
        Me.lblRepresentation = New DevExpress.XtraEditors.LabelControl()
        Me.teDefaultQTY = New DevExpress.XtraEditors.TextEdit()
        Me.teDefaultRotation = New DevExpress.XtraEditors.TextEdit()
        Me.cboRepresentation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ceStripLayers = New DevExpress.XtraEditors.CheckEdit()
        Me.sbAddSelectedFiles = New DevExpress.XtraEditors.SimpleButton()
        Me.sbAddSelectedFolder = New DevExpress.XtraEditors.SimpleButton()
        Me.ubgParts = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl()
        Me.ubgPartsView = New FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView()
        Me.sbRemovePart = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.picPreview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.cboFileType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teDefaultQTY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teDefaultRotation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRepresentation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceStripLayers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ubgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ubgPartsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl3)
        Me.PanelControl1.Controls.Add(Me.SplitterControl1)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.SplitterControl2)
        Me.PanelControl1.Controls.Add(Me.PanelControl4)
        Me.PanelControl1.Location = New System.Drawing.Point(6, 85)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1012, 229)
        Me.PanelControl1.TabIndex = 27
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.fgList)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(252, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(452, 225)
        Me.PanelControl3.TabIndex = 1
        '
        'fgList
        '
        Me.fgList.AllowColumnHeaderDragdrop = True
        Me.fgList.AllowFileExecution = False
        Me.fgList.AllowItemRenaming = False
        Me.fgList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgList.EnableVistaTheme = False
        Me.fgList.Location = New System.Drawing.Point(2, 2)
        Me.fgList.Name = "fgList"
        Me.fgList.Padding = New System.Windows.Forms.Padding(3)
        Me.fgList.ShowFolders = False
        Me.fgList.ShowHiddenItems = False
        Me.fgList.Size = New System.Drawing.Size(448, 221)
        Me.fgList.TabIndex = 0
        Me.fgList.Text = "FileView1"
        Me.fgList.ViewStyle = LogicNP.FileViewControl.ViewStyles.Report
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SplitterControl1.Location = New System.Drawing.Point(704, 2)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(6, 225)
        Me.SplitterControl1.TabIndex = 0
        Me.SplitterControl1.TabStop = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.picPreview1)
        Me.PanelControl2.Controls.Add(Me.picPreview)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(710, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(300, 225)
        Me.PanelControl2.TabIndex = 0
        '
        'picPreview1
        '
        Me.picPreview1.BackColor = System.Drawing.Color.Black
        Me.picPreview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview1.Location = New System.Drawing.Point(2, 2)
        Me.picPreview1.Name = "picPreview1"
        Me.picPreview1.Size = New System.Drawing.Size(296, 221)
        Me.picPreview1.TabIndex = 1
        Me.picPreview1.TabStop = False
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.Black
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPreview.Location = New System.Drawing.Point(2, 2)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Padding = New System.Windows.Forms.Padding(3)
        Me.picPreview.Size = New System.Drawing.Size(73, 48)
        Me.picPreview.TabIndex = 0
        '
        'SplitterControl2
        '
        Me.SplitterControl2.Location = New System.Drawing.Point(246, 2)
        Me.SplitterControl2.Name = "SplitterControl2"
        Me.SplitterControl2.Size = New System.Drawing.Size(6, 225)
        Me.SplitterControl2.TabIndex = 0
        Me.SplitterControl2.TabStop = False
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.fldrVw)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(244, 225)
        Me.PanelControl4.TabIndex = 2
        '
        'fldrVw
        '
        Me.fldrVw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fldrVw.FileView = Me.fgList
        Me.fldrVw.Location = New System.Drawing.Point(2, 2)
        Me.fldrVw.Name = "fldrVw"
        Me.fldrVw.Padding = New System.Windows.Forms.Padding(3)
        Me.fldrVw.Size = New System.Drawing.Size(240, 221)
        Me.fldrVw.TabIndex = 0
        Me.fldrVw.Text = "FolderView1"
        '
        'lblDimensions
        '
        Me.lblDimensions.Location = New System.Drawing.Point(745, 320)
        Me.lblDimensions.Name = "lblDimensions"
        Me.lblDimensions.Size = New System.Drawing.Size(75, 13)
        Me.lblDimensions.TabIndex = 26
        Me.lblDimensions.Text = "Model Extents: "
        '
        'lblFileType
        '
        Me.lblFileType.Location = New System.Drawing.Point(311, 62)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(47, 13)
        Me.lblFileType.TabIndex = 3
        Me.lblFileType.Text = "File Type:"
        '
        'cboFileType
        '
        Me.cboFileType.Location = New System.Drawing.Point(365, 59)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFileType.Size = New System.Drawing.Size(168, 20)
        Me.cboFileType.TabIndex = 3
        '
        'lblDefaultQTY
        '
        Me.lblDefaultQTY.Location = New System.Drawing.Point(65, 12)
        Me.lblDefaultQTY.Name = "lblDefaultQTY"
        Me.lblDefaultQTY.Size = New System.Drawing.Size(62, 13)
        Me.lblDefaultQTY.TabIndex = 29
        Me.lblDefaultQTY.Text = "Default QTY:"
        '
        'lblDefaultRotation
        '
        Me.lblDefaultRotation.Location = New System.Drawing.Point(44, 41)
        Me.lblDefaultRotation.Name = "lblDefaultRotation"
        Me.lblDefaultRotation.Size = New System.Drawing.Size(83, 13)
        Me.lblDefaultRotation.TabIndex = 30
        Me.lblDefaultRotation.Text = "Default Rotation:"
        '
        'lblRepresentation
        '
        Me.lblRepresentation.Location = New System.Drawing.Point(15, 67)
        Me.lblRepresentation.Name = "lblRepresentation"
        Me.lblRepresentation.Size = New System.Drawing.Size(112, 13)
        Me.lblRepresentation.TabIndex = 31
        Me.lblRepresentation.Text = "Default Representation"
        '
        'teDefaultQTY
        '
        Me.teDefaultQTY.Location = New System.Drawing.Point(133, 9)
        Me.teDefaultQTY.Name = "teDefaultQTY"
        Me.teDefaultQTY.Size = New System.Drawing.Size(100, 20)
        Me.teDefaultQTY.TabIndex = 0
        '
        'teDefaultRotation
        '
        Me.teDefaultRotation.Location = New System.Drawing.Point(133, 38)
        Me.teDefaultRotation.Name = "teDefaultRotation"
        Me.teDefaultRotation.Size = New System.Drawing.Size(100, 20)
        Me.teDefaultRotation.TabIndex = 1
        '
        'cboRepresentation
        '
        Me.cboRepresentation.Location = New System.Drawing.Point(133, 64)
        Me.cboRepresentation.Name = "cboRepresentation"
        Me.cboRepresentation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRepresentation.Size = New System.Drawing.Size(123, 20)
        Me.cboRepresentation.TabIndex = 2
        '
        'ceStripLayers
        '
        Me.ceStripLayers.AutoSizeInLayoutControl = True
        Me.ceStripLayers.Location = New System.Drawing.Point(586, 59)
        Me.ceStripLayers.Name = "ceStripLayers"
        Me.ceStripLayers.Properties.Caption = "Strip Layers"
        Me.ceStripLayers.Size = New System.Drawing.Size(98, 19)
        Me.ceStripLayers.TabIndex = 4
        '
        'sbAddSelectedFiles
        '
        Me.sbAddSelectedFiles.Location = New System.Drawing.Point(396, 320)
        Me.sbAddSelectedFiles.Name = "sbAddSelectedFiles"
        Me.sbAddSelectedFiles.Size = New System.Drawing.Size(173, 22)
        Me.sbAddSelectedFiles.TabIndex = 6
        Me.sbAddSelectedFiles.Text = "Add Selected Files"
        '
        'sbAddSelectedFolder
        '
        Me.sbAddSelectedFolder.Location = New System.Drawing.Point(12, 316)
        Me.sbAddSelectedFolder.Name = "sbAddSelectedFolder"
        Me.sbAddSelectedFolder.Size = New System.Drawing.Size(179, 22)
        Me.sbAddSelectedFolder.TabIndex = 5
        Me.sbAddSelectedFolder.Text = "Add Selected Folder"
        '
        'ubgParts
        '
        Me.ubgParts.Cursor = System.Windows.Forms.Cursors.Default
        Me.ubgParts.Location = New System.Drawing.Point(12, 348)
        Me.ubgParts.MainView = Me.ubgPartsView
        Me.ubgParts.Name = "ubgParts"
        Me.ubgParts.Size = New System.Drawing.Size(704, 190)
        Me.ubgParts.TabIndex = 7
        Me.ubgParts.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ubgPartsView})
        '
        'ubgPartsView
        '
        Me.ubgPartsView.ActiveFilterEnabled = False
        Me.ubgPartsView.GridControl = Me.ubgParts
        Me.ubgPartsView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.ubgPartsView.Name = "ubgPartsView"
        Me.ubgPartsView.OptionsCustomization.AllowColumnMoving = False
        Me.ubgPartsView.OptionsCustomization.AllowFilter = False
        Me.ubgPartsView.OptionsCustomization.AllowGroup = False
        Me.ubgPartsView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ubgPartsView.OptionsCustomization.AllowSort = False
        Me.ubgPartsView.OptionsDetail.ShowDetailTabs = False
        Me.ubgPartsView.OptionsNavigation.EnterMoveNextColumn = True
        Me.ubgPartsView.OptionsView.ColumnAutoWidth = False
        Me.ubgPartsView.OptionsView.ShowDetailButtons = False
        Me.ubgPartsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ubgPartsView.OptionsView.ShowGroupPanel = False
        Me.ubgPartsView.OptionsView.ShowIndicator = False
        Me.ubgPartsView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'sbRemovePart
        '
        Me.sbRemovePart.Location = New System.Drawing.Point(722, 348)
        Me.sbRemovePart.Name = "sbRemovePart"
        Me.sbRemovePart.Size = New System.Drawing.Size(127, 22)
        Me.sbRemovePart.TabIndex = 10
        Me.sbRemovePart.Text = "Remove Part"
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Enabled = False
        Me.cmdOk.Location = New System.Drawing.Point(756, 515)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(82, 22)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(756, 487)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(82, 22)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        '
        'dlgAddMulti
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(1025, 550)
        Me.Controls.Add(Me.sbRemovePart)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.ubgParts)
        Me.Controls.Add(Me.sbAddSelectedFiles)
        Me.Controls.Add(Me.sbAddSelectedFolder)
        Me.Controls.Add(Me.ceStripLayers)
        Me.Controls.Add(Me.cboRepresentation)
        Me.Controls.Add(Me.teDefaultRotation)
        Me.Controls.Add(Me.teDefaultQTY)
        Me.Controls.Add(Me.lblRepresentation)
        Me.Controls.Add(Me.lblDefaultRotation)
        Me.Controls.Add(Me.lblDefaultQTY)
        Me.Controls.Add(Me.cboFileType)
        Me.Controls.Add(Me.lblFileType)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.lblDimensions)
        Me.DoubleBuffered = True
        Me.Name = "dlgAddMulti"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgAddMulti"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.picPreview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.cboFileType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teDefaultQTY.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teDefaultRotation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRepresentation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceStripLayers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ubgParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ubgPartsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents fgList As LogicNP.FileViewControl.FileView
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picPreview1 As System.Windows.Forms.PictureBox
    Friend WithEvents picPreview As System.Windows.Forms.Panel
    Friend WithEvents SplitterControl2 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents fldrVw As LogicNP.FolderViewControl.FolderView
    Friend WithEvents lblDimensions As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFileType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboFileType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblDefaultQTY As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDefaultRotation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblRepresentation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teDefaultQTY As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teDefaultRotation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboRepresentation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ceStripLayers As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents sbAddSelectedFiles As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbAddSelectedFolder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ubgParts As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridControl
    Friend WithEvents ubgPartsView As FabV24_WIN8.CustomGrid.CustomGrid.UnboundGridView
    Friend WithEvents sbRemovePart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
End Class
