<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExplorer
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDimensions = New DevExpress.XtraEditors.LabelControl()
        Me.fraPreRotate = New System.Windows.Forms.Panel()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.mtbPreRotate = New System.Windows.Forms.TextBox()
        Me.ltbCurveRes = New FabV24_WIN8.MathTextBox()
        Me.chkRaw = New System.Windows.Forms.CheckBox()
        Me.chkStripLayers = New System.Windows.Forms.CheckBox()
        Me.chkAutoSave = New System.Windows.Forms.CheckBox()
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
        Me.lcbFilter = New FabV24_WIN8.LabelComboBox()
        Me.lblFilename = New FabV24_WIN8.lblTextBox()
        Me.ltbAddress = New FabV24_WIN8.lblTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.fraPreRotate.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.picPreview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdOpen, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(868, 410)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'cmdOpen
        '
        Me.cmdOpen.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOpen.Enabled = False
        Me.cmdOpen.Location = New System.Drawing.Point(3, 3)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(67, 23)
        Me.cmdOpen.TabIndex = 9
        Me.cmdOpen.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(76, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(67, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'lblDimensions
        '
        Me.lblDimensions.Location = New System.Drawing.Point(700, 342)
        Me.lblDimensions.Name = "lblDimensions"
        Me.lblDimensions.Size = New System.Drawing.Size(75, 13)
        Me.lblDimensions.TabIndex = 21
        Me.lblDimensions.Text = "Model Extents: "
        '
        'fraPreRotate
        '
        Me.fraPreRotate.Controls.Add(Me.LabelControl1)
        Me.fraPreRotate.Controls.Add(Me.mtbPreRotate)
        Me.fraPreRotate.Controls.Add(Me.ltbCurveRes)
        Me.fraPreRotate.Controls.Add(Me.chkRaw)
        Me.fraPreRotate.Controls.Add(Me.chkStripLayers)
        Me.fraPreRotate.Controls.Add(Me.chkAutoSave)
        Me.fraPreRotate.Location = New System.Drawing.Point(303, 358)
        Me.fraPreRotate.Name = "fraPreRotate"
        Me.fraPreRotate.Size = New System.Drawing.Size(376, 68)
        Me.fraPreRotate.TabIndex = 23
        Me.fraPreRotate.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(6, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Pre Rotate Angle:"
        '
        'mtbPreRotate
        '
        Me.mtbPreRotate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mtbPreRotate.Location = New System.Drawing.Point(98, 8)
        Me.mtbPreRotate.Name = "mtbPreRotate"
        Me.mtbPreRotate.Size = New System.Drawing.Size(103, 21)
        Me.mtbPreRotate.TabIndex = 9
        Me.mtbPreRotate.WordWrap = False
        '
        'ltbCurveRes
        '
        Me.ltbCurveRes.BackColor = System.Drawing.Color.Transparent
        Me.ltbCurveRes.Caption = "Curve Resolution"
        Me.ltbCurveRes.CaptionLocation = FabV24_WIN8.MathTextBox.CaptionLocations.clLeft
        Me.ltbCurveRes.EvaluatorUsed = False
        Me.ltbCurveRes.FieldStyle = FabV24_WIN8.MathTextBox.FieldStyles.fsAuto
        Me.ltbCurveRes.FieldWidth = 255
        Me.ltbCurveRes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltbCurveRes.FormatString = Nothing
        Me.ltbCurveRes.Location = New System.Drawing.Point(15, 36)
        Me.ltbCurveRes.MaxLength = 0
        Me.ltbCurveRes.MaxValue = Nothing
        Me.ltbCurveRes.MaxValueUsed = False
        Me.ltbCurveRes.MinValue = Nothing
        Me.ltbCurveRes.MinValueUsed = False
        Me.ltbCurveRes.Name = "ltbCurveRes"
        Me.ltbCurveRes.Size = New System.Drawing.Size(186, 25)
        Me.ltbCurveRes.Suppressed = False
        Me.ltbCurveRes.TabIndex = 10
        Me.ltbCurveRes.UseMnemonic = True
        '
        'chkRaw
        '
        Me.chkRaw.AutoSize = True
        Me.chkRaw.Location = New System.Drawing.Point(325, 33)
        Me.chkRaw.Name = "chkRaw"
        Me.chkRaw.Size = New System.Drawing.Size(47, 17)
        Me.chkRaw.TabIndex = 13
        Me.chkRaw.Text = "Raw"
        Me.chkRaw.UseVisualStyleBackColor = True
        '
        'chkStripLayers
        '
        Me.chkStripLayers.AutoSize = True
        Me.chkStripLayers.Location = New System.Drawing.Point(208, 33)
        Me.chkStripLayers.Name = "chkStripLayers"
        Me.chkStripLayers.Size = New System.Drawing.Size(83, 17)
        Me.chkStripLayers.TabIndex = 12
        Me.chkStripLayers.Text = "Strip Layers"
        Me.chkStripLayers.UseVisualStyleBackColor = True
        '
        'chkAutoSave
        '
        Me.chkAutoSave.AutoSize = True
        Me.chkAutoSave.Location = New System.Drawing.Point(208, 8)
        Me.chkAutoSave.Name = "chkAutoSave"
        Me.chkAutoSave.Size = New System.Drawing.Size(164, 17)
        Me.chkAutoSave.TabIndex = 11
        Me.chkAutoSave.Text = "Auto Save ( in source folder)"
        Me.chkAutoSave.UseVisualStyleBackColor = True
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl3)
        Me.PanelControl1.Controls.Add(Me.SplitterControl1)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.SplitterControl2)
        Me.PanelControl1.Controls.Add(Me.PanelControl4)
        Me.PanelControl1.Location = New System.Drawing.Point(16, 37)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(995, 303)
        Me.PanelControl1.TabIndex = 24
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.fgList)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(251, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(393, 299)
        Me.PanelControl3.TabIndex = 1
        '
        'fgList
        '
        Me.fgList.AllowColumnHeaderDragdrop = True
        Me.fgList.AllowZipFolders = True
        Me.fgList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgList.EnableVistaTheme = False
        Me.fgList.Location = New System.Drawing.Point(2, 2)
        Me.fgList.Name = "fgList"
        Me.fgList.Padding = New System.Windows.Forms.Padding(3)
        Me.fgList.ShowFolders = False
        Me.fgList.Size = New System.Drawing.Size(389, 295)
        Me.fgList.TabIndex = 0
        Me.fgList.Text = "FileView1"
        Me.fgList.ViewStyle = LogicNP.FileViewControl.ViewStyles.Report
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SplitterControl1.Location = New System.Drawing.Point(644, 2)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(6, 299)
        Me.SplitterControl1.TabIndex = 0
        Me.SplitterControl1.TabStop = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.picPreview1)
        Me.PanelControl2.Controls.Add(Me.picPreview)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(650, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(343, 299)
        Me.PanelControl2.TabIndex = 0
        '
        'picPreview1
        '
        Me.picPreview1.BackColor = System.Drawing.Color.Black
        Me.picPreview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview1.Location = New System.Drawing.Point(2, 2)
        Me.picPreview1.Name = "picPreview1"
        Me.picPreview1.Size = New System.Drawing.Size(339, 295)
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
        Me.SplitterControl2.Location = New System.Drawing.Point(245, 2)
        Me.SplitterControl2.Name = "SplitterControl2"
        Me.SplitterControl2.Size = New System.Drawing.Size(6, 299)
        Me.SplitterControl2.TabIndex = 0
        Me.SplitterControl2.TabStop = False
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.fldrVw)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(243, 299)
        Me.PanelControl4.TabIndex = 2
        '
        'fldrVw
        '
        Me.fldrVw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fldrVw.FileView = Me.fgList
        Me.fldrVw.Location = New System.Drawing.Point(2, 2)
        Me.fldrVw.Name = "fldrVw"
        Me.fldrVw.Padding = New System.Windows.Forms.Padding(3)
        Me.fldrVw.Size = New System.Drawing.Size(239, 295)
        Me.fldrVw.TabIndex = 0
        Me.fldrVw.Text = "FolderView1"
        '
        'lcbFilter
        '
        Me.lcbFilter.BackColor = System.Drawing.Color.Transparent
        Me.lcbFilter.Caption = "File of types: "
        Me.lcbFilter.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbFilter.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbFilter.FieldWidth = 495
        Me.lcbFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbFilter.ListIndex = -1
        Me.lcbFilter.Location = New System.Drawing.Point(16, 391)
        Me.lcbFilter.Name = "lcbFilter"
        Me.lcbFilter.Size = New System.Drawing.Size(281, 25)
        Me.lcbFilter.TabIndex = 22
        Me.lcbFilter.UseMnemonic = True
        '
        'lblFilename
        '
        Me.lblFilename.BackColor = System.Drawing.Color.Transparent
        Me.lblFilename.Caption = "Filename: "
        Me.lblFilename.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.lblFilename.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.lblFilename.FieldWidth = 100
        Me.lblFilename.Location = New System.Drawing.Point(33, 360)
        Me.lblFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.lblFilename.MaxLength = 32767
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(264, 25)
        Me.lblFilename.TabIndex = 2
        '
        'ltbAddress
        '
        Me.ltbAddress.AutoSize = True
        Me.ltbAddress.BackColor = System.Drawing.Color.Transparent
        Me.ltbAddress.Caption = "Address: "
        Me.ltbAddress.CaptionLocation = FabV24_WIN8.lblTextBox.CaptionLocations.clLeft
        Me.ltbAddress.FieldStyle = FabV24_WIN8.lblTextBox.FieldStyles.fsAuto
        Me.ltbAddress.FieldWidth = 100
        Me.ltbAddress.Location = New System.Drawing.Point(20, 6)
        Me.ltbAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.ltbAddress.MaxLength = 32767
        Me.ltbAddress.Name = "ltbAddress"
        Me.ltbAddress.Size = New System.Drawing.Size(1042, 25)
        Me.ltbAddress.TabIndex = 18
        '
        'frmExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(1025, 451)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.fraPreRotate)
        Me.Controls.Add(Me.lcbFilter)
        Me.Controls.Add(Me.lblDimensions)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.ltbAddress)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExplorer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open Model"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.fraPreRotate.ResumeLayout(False)
        Me.fraPreRotate.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.picPreview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblFilename As FabV24_WIN8.lblTextBox
    Friend WithEvents lblDimensions As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lcbFilter As FabV24_WIN8.LabelComboBox
    Friend WithEvents fraPreRotate As System.Windows.Forms.Panel
    Friend WithEvents ltbCurveRes As FabV24_WIN8.MathTextBox
    Friend WithEvents chkRaw As System.Windows.Forms.CheckBox
    Friend WithEvents chkStripLayers As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoSave As System.Windows.Forms.CheckBox
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents fgList As LogicNP.FileViewControl.FileView
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picPreview As System.Windows.Forms.Panel
    Friend WithEvents SplitterControl2 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents fldrVw As LogicNP.FolderViewControl.FolderView
    Friend WithEvents ltbAddress As FabV24_WIN8.lblTextBox
    Friend WithEvents picPreview1 As System.Windows.Forms.PictureBox
    Friend WithEvents mtbPreRotate As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
