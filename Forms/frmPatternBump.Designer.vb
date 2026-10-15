<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatternBump
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatternBump))
        Me.scPatternBump = New DevExpress.XtraEditors.SplitContainerControl()
        Me.picPattern = New DevExpress.XtraEditors.PanelControl()
        Me.nbcPatterns = New DevExpress.XtraNavBar.NavBarControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cbeSheets = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkbUseSelected = New DevExpress.XtraEditors.CheckButton()
        Me.OptMoveCopy = New DevExpress.XtraEditors.RadioGroup()
        Me.tbFieldValues = New System.Windows.Forms.TextBox()
        Me.cmdTransfer = New DevExpress.XtraEditors.SimpleButton()
        Me.tbFieldNames = New System.Windows.Forms.TextBox()
        Me.tbHandleY = New DevExpress.XtraEditors.TextEdit()
        Me.lblHandleY = New DevExpress.XtraEditors.LabelControl()
        Me.tbHandleX = New DevExpress.XtraEditors.TextEdit()
        Me.lblHandleX = New DevExpress.XtraEditors.LabelControl()
        Me.cmdDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDrop = New DevExpress.XtraEditors.SimpleButton()
        Me.mtbOrientation = New FabV24_WIN8.MathTextBox()
        Me.lstPattern = New DevExpress.XtraEditors.ListBoxControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlBumpSheetsPic = New System.Windows.Forms.PictureBox()
        Me.NestingImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.scPatternBump, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scPatternBump.SuspendLayout()
        CType(Me.picPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbcPatterns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeSheets.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptMoveCopy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHandleY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHandleX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBumpSheetsPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NestingImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scPatternBump
        '
        Me.scPatternBump.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scPatternBump.Location = New System.Drawing.Point(0, 0)
        Me.scPatternBump.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.scPatternBump.Name = "scPatternBump"
        Me.scPatternBump.Panel1.Controls.Add(Me.picPattern)
        Me.scPatternBump.Panel1.Controls.Add(Me.nbcPatterns)
        Me.scPatternBump.Panel1.Text = "Panel1"
        Me.scPatternBump.Panel2.Controls.Add(Me.LabelControl1)
        Me.scPatternBump.Panel2.Controls.Add(Me.cbeSheets)
        Me.scPatternBump.Panel2.Controls.Add(Me.chkbUseSelected)
        Me.scPatternBump.Panel2.Controls.Add(Me.OptMoveCopy)
        Me.scPatternBump.Panel2.Controls.Add(Me.tbFieldValues)
        Me.scPatternBump.Panel2.Controls.Add(Me.cmdTransfer)
        Me.scPatternBump.Panel2.Controls.Add(Me.tbFieldNames)
        Me.scPatternBump.Panel2.Controls.Add(Me.tbHandleY)
        Me.scPatternBump.Panel2.Controls.Add(Me.lblHandleY)
        Me.scPatternBump.Panel2.Controls.Add(Me.tbHandleX)
        Me.scPatternBump.Panel2.Controls.Add(Me.lblHandleX)
        Me.scPatternBump.Panel2.Controls.Add(Me.cmdDelete)
        Me.scPatternBump.Panel2.Controls.Add(Me.cmdDrop)
        Me.scPatternBump.Panel2.Controls.Add(Me.mtbOrientation)
        Me.scPatternBump.Panel2.Controls.Add(Me.lstPattern)
        Me.scPatternBump.Panel2.Controls.Add(Me.cmdCancel)
        Me.scPatternBump.Panel2.Controls.Add(Me.pnlBumpSheetsPic)
        Me.scPatternBump.Panel2.Text = "Panel2"
        Me.scPatternBump.Size = New System.Drawing.Size(574, 742)
        Me.scPatternBump.SplitterPosition = 216
        Me.scPatternBump.TabIndex = 0
        Me.scPatternBump.Text = "scPatternBump"
        '
        'picPattern
        '
        Me.picPattern.Appearance.BackColor = System.Drawing.Color.White
        Me.picPattern.Appearance.Options.UseBackColor = True
        Me.picPattern.Location = New System.Drawing.Point(0, 0)
        Me.picPattern.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.picPattern.LookAndFeel.UseDefaultLookAndFeel = False
        Me.picPattern.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picPattern.Name = "picPattern"
        Me.picPattern.Size = New System.Drawing.Size(82, 86)
        Me.picPattern.TabIndex = 4
        '
        'nbcPatterns
        '
        Me.nbcPatterns.AllowDrop = False
        Me.nbcPatterns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nbcPatterns.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None
        Me.nbcPatterns.LargeImages = Me.ImageCollection1
        Me.nbcPatterns.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInGroup
        Me.nbcPatterns.Location = New System.Drawing.Point(0, 0)
        Me.nbcPatterns.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nbcPatterns.Name = "nbcPatterns"
        Me.nbcPatterns.NavigationPaneOverflowPanelUseSmallImages = False
        Me.nbcPatterns.OptionsNavPane.ExpandedWidth = 216
        Me.nbcPatterns.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.SideBar
        Me.nbcPatterns.Size = New System.Drawing.Size(216, 742)
        Me.nbcPatterns.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar
        Me.nbcPatterns.SmallImages = Me.ImageCollection1
        Me.nbcPatterns.TabIndex = 3
        Me.nbcPatterns.Text = "NavBarControl1"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageSize = New System.Drawing.Size(48, 48)
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl1.TabIndex = 65
        Me.LabelControl1.Text = "Sheets:"
        '
        'cbeSheets
        '
        Me.cbeSheets.Location = New System.Drawing.Point(62, 12)
        Me.cbeSheets.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbeSheets.Name = "cbeSheets"
        Me.cbeSheets.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeSheets.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeSheets.Size = New System.Drawing.Size(276, 23)
        Me.cbeSheets.TabIndex = 64
        '
        'chkbUseSelected
        '
        Me.chkbUseSelected.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.chkbUseSelected.Location = New System.Drawing.Point(79, 255)
        Me.chkbUseSelected.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkbUseSelected.Name = "chkbUseSelected"
        Me.chkbUseSelected.Size = New System.Drawing.Size(192, 28)
        Me.chkbUseSelected.TabIndex = 63
        Me.chkbUseSelected.Text = "Use Selected"
        '
        'OptMoveCopy
        '
        Me.OptMoveCopy.Location = New System.Drawing.Point(79, 290)
        Me.OptMoveCopy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OptMoveCopy.Name = "OptMoveCopy"
        Me.OptMoveCopy.Properties.Columns = 2
        Me.OptMoveCopy.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Move"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Copy")})
        Me.OptMoveCopy.Size = New System.Drawing.Size(192, 31)
        Me.OptMoveCopy.TabIndex = 57
        '
        'tbFieldValues
        '
        Me.tbFieldValues.Location = New System.Drawing.Point(13, 249)
        Me.tbFieldValues.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbFieldValues.Name = "tbFieldValues"
        Me.tbFieldValues.Size = New System.Drawing.Size(93, 23)
        Me.tbFieldValues.TabIndex = 59
        Me.tbFieldValues.Visible = False
        '
        'cmdTransfer
        '
        Me.cmdTransfer.Location = New System.Drawing.Point(79, 213)
        Me.cmdTransfer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdTransfer.Name = "cmdTransfer"
        Me.cmdTransfer.Size = New System.Drawing.Size(192, 28)
        Me.cmdTransfer.TabIndex = 51
        Me.cmdTransfer.Text = "Transfer"
        '
        'tbFieldNames
        '
        Me.tbFieldNames.Location = New System.Drawing.Point(13, 215)
        Me.tbFieldNames.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbFieldNames.Name = "tbFieldNames"
        Me.tbFieldNames.Size = New System.Drawing.Size(84, 23)
        Me.tbFieldNames.TabIndex = 58
        Me.tbFieldNames.Visible = False
        '
        'tbHandleY
        '
        Me.tbHandleY.Location = New System.Drawing.Point(223, 329)
        Me.tbHandleY.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbHandleY.Name = "tbHandleY"
        Me.tbHandleY.Properties.ReadOnly = True
        Me.tbHandleY.Size = New System.Drawing.Size(117, 23)
        Me.tbHandleY.TabIndex = 55
        '
        'lblHandleY
        '
        Me.lblHandleY.Location = New System.Drawing.Point(204, 332)
        Me.lblHandleY.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblHandleY.Name = "lblHandleY"
        Me.lblHandleY.Size = New System.Drawing.Size(12, 16)
        Me.lblHandleY.TabIndex = 54
        Me.lblHandleY.Text = "Y:"
        '
        'tbHandleX
        '
        Me.tbHandleX.Location = New System.Drawing.Point(72, 329)
        Me.tbHandleX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbHandleX.Name = "tbHandleX"
        Me.tbHandleX.Properties.DisplayFormat.FormatString = "#####.#####"
        Me.tbHandleX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tbHandleX.Properties.EditFormat.FormatString = "#####.#####"
        Me.tbHandleX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tbHandleX.Properties.ReadOnly = True
        Me.tbHandleX.Size = New System.Drawing.Size(117, 23)
        Me.tbHandleX.TabIndex = 53
        '
        'lblHandleX
        '
        Me.lblHandleX.Location = New System.Drawing.Point(12, 332)
        Me.lblHandleX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblHandleX.Name = "lblHandleX"
        Me.lblHandleX.Size = New System.Drawing.Size(56, 16)
        Me.lblHandleX.TabIndex = 52
        Me.lblHandleX.Text = "Handle X:"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(72, 399)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(87, 28)
        Me.cmdDelete.TabIndex = 50
        Me.cmdDelete.Text = "Delete"
        '
        'cmdDrop
        '
        Me.cmdDrop.Location = New System.Drawing.Point(223, 399)
        Me.cmdDrop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdDrop.Name = "cmdDrop"
        Me.cmdDrop.Size = New System.Drawing.Size(87, 28)
        Me.cmdDrop.TabIndex = 49
        Me.cmdDrop.Text = "Drop"
        '
        'mtbOrientation
        '
        Me.mtbOrientation.BackColor = System.Drawing.Color.Transparent
        Me.mtbOrientation.Caption = "Orientation"
        Me.mtbOrientation.CaptionLocation = FabV24_WIN8.MathTextBox.CaptionLocations.clLeft
        Me.mtbOrientation.EvaluatorUsed = True
        Me.mtbOrientation.FieldStyle = FabV24_WIN8.MathTextBox.FieldStyles.fsAuto
        Me.mtbOrientation.FieldWidth = 255
        Me.mtbOrientation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbOrientation.FormatString = Nothing
        Me.mtbOrientation.Location = New System.Drawing.Point(8, 361)
        Me.mtbOrientation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.mtbOrientation.MaxLength = 0
        Me.mtbOrientation.MaxValue = Nothing
        Me.mtbOrientation.MaxValueUsed = False
        Me.mtbOrientation.MinValue = Nothing
        Me.mtbOrientation.MinValueUsed = False
        Me.mtbOrientation.Name = "mtbOrientation"
        Me.mtbOrientation.Size = New System.Drawing.Size(195, 25)
        Me.mtbOrientation.Suppressed = False
        Me.mtbOrientation.TabIndex = 48
        Me.mtbOrientation.UseMnemonic = True
        '
        'lstPattern
        '
        Me.lstPattern.Location = New System.Drawing.Point(0, 565)
        Me.lstPattern.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstPattern.Name = "lstPattern"
        Me.lstPattern.Size = New System.Drawing.Size(348, 123)
        Me.lstPattern.TabIndex = 46
        Me.lstPattern.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(223, 361)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 28)
        Me.cmdCancel.TabIndex = 44
        Me.cmdCancel.Text = "Cancel"
        '
        'pnlBumpSheetsPic
        '
        Me.pnlBumpSheetsPic.BackColor = System.Drawing.Color.Black
        Me.pnlBumpSheetsPic.Location = New System.Drawing.Point(13, 43)
        Me.pnlBumpSheetsPic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlBumpSheetsPic.Name = "pnlBumpSheetsPic"
        Me.pnlBumpSheetsPic.Size = New System.Drawing.Size(328, 164)
        Me.pnlBumpSheetsPic.TabIndex = 62
        Me.pnlBumpSheetsPic.TabStop = False
        '
        'NestingImageCollection
        '
        Me.NestingImageCollection.ImageSize = New System.Drawing.Size(64, 64)
        Me.NestingImageCollection.ImageStream = CType(resources.GetObject("NestingImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'frmPatternBump
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 742)
        Me.Controls.Add(Me.scPatternBump)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatternBump"
        Me.ShowIcon = False
        Me.Text = "Pattern Bump"
        CType(Me.scPatternBump, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPatternBump.ResumeLayout(False)
        CType(Me.picPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbcPatterns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeSheets.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptMoveCopy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHandleY.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHandleX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBumpSheetsPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NestingImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'NOTE: Be sure not to access any form data here.
        'Otherwise, the app will not shut down.
        m_is_active = False
        m_orientation = 0.0#
        m_usage = MOVE_BUTTON

        ' Add any initialization after the InitializeComponent() call.


    End Sub
    Friend WithEvents scPatternBump As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents tbFieldValues As System.Windows.Forms.TextBox
    Friend WithEvents tbFieldNames As System.Windows.Forms.TextBox
    Friend WithEvents OptMoveCopy As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents tbHandleY As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblHandleY As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbHandleX As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblHandleX As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdTransfer As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDrop As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mtbOrientation As FabV24_WIN8.MathTextBox
    Friend WithEvents lstPattern As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Public WithEvents NestingImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents pnlBumpSheetsPic As System.Windows.Forms.PictureBox
    Friend WithEvents chkbUseSelected As DevExpress.XtraEditors.CheckButton
    Friend WithEvents nbcPatterns As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents picPattern As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeSheets As DevExpress.XtraEditors.ComboBoxEdit
End Class
