<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgLifeGear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgLifeGear))
        Me.gcSize = New DevExpress.XtraEditors.GroupControl()
        Me.cbeMaterialType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblMaterialType = New DevExpress.XtraEditors.LabelControl()
        Me.cbBlankSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblBlankSize = New DevExpress.XtraEditors.LabelControl()
        Me.txtQty = New DevExpress.XtraEditors.TextEdit()
        Me.lblQty = New DevExpress.XtraEditors.LabelControl()
        Me.lblWidth = New DevExpress.XtraEditors.LabelControl()
        Me.txtWidth = New DevExpress.XtraEditors.TextEdit()
        Me.lblHeight = New DevExpress.XtraEditors.LabelControl()
        Me.txtHeight = New DevExpress.XtraEditors.TextEdit()
        Me.gcHole = New DevExpress.XtraEditors.GroupControl()
        Me.cbSpacing = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbDIa = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lcSpacing = New DevExpress.XtraEditors.LabelControl()
        Me.lblDia = New DevExpress.XtraEditors.LabelControl()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.sbRun = New DevExpress.XtraEditors.SimpleButton()
        Me.sbReset = New DevExpress.XtraEditors.SimpleButton()
        Me.gcNotch_Corners = New DevExpress.XtraEditors.GroupControl()
        Me.rgPresser = New DevExpress.XtraEditors.RadioGroup()
        Me.lblPresser = New DevExpress.XtraEditors.LabelControl()
        Me.rgNotch = New DevExpress.XtraEditors.RadioGroup()
        Me.rgLogo = New DevExpress.XtraEditors.RadioGroup()
        Me.lblLogo = New DevExpress.XtraEditors.LabelControl()
        Me.lblNotchCorners = New DevExpress.XtraEditors.LabelControl()
        Me.rgProductType = New DevExpress.XtraEditors.RadioGroup()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.pcMagPanel = New DevExpress.XtraEditors.PanelControl()
        Me.rgCorner = New DevExpress.XtraEditors.RadioGroup()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.lblPresser2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCorner = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.rgMountingHoles = New DevExpress.XtraEditors.RadioGroup()
        CType(Me.gcSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcSize.SuspendLayout()
        CType(Me.cbeMaterialType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBlankSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcHole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcHole.SuspendLayout()
        CType(Me.cbSpacing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDIa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcNotch_Corners, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcNotch_Corners.SuspendLayout()
        CType(Me.rgPresser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgNotch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgLogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgProductType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcMagPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcMagPanel.SuspendLayout()
        CType(Me.rgCorner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgMountingHoles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcSize
        '
        Me.gcSize.Controls.Add(Me.cbeMaterialType)
        Me.gcSize.Controls.Add(Me.lblMaterialType)
        Me.gcSize.Controls.Add(Me.cbBlankSize)
        Me.gcSize.Controls.Add(Me.lblBlankSize)
        Me.gcSize.Controls.Add(Me.txtQty)
        Me.gcSize.Controls.Add(Me.lblQty)
        Me.gcSize.Controls.Add(Me.lblWidth)
        Me.gcSize.Controls.Add(Me.txtWidth)
        Me.gcSize.Controls.Add(Me.lblHeight)
        Me.gcSize.Controls.Add(Me.txtHeight)
        Me.gcSize.Location = New System.Drawing.Point(12, 57)
        Me.gcSize.Name = "gcSize"
        Me.gcSize.ShowCaption = False
        Me.gcSize.Size = New System.Drawing.Size(328, 143)
        Me.gcSize.TabIndex = 2
        Me.gcSize.Text = "Part"
        '
        'cbeMaterialType
        '
        Me.cbeMaterialType.EnterMoveNextControl = True
        Me.cbeMaterialType.Location = New System.Drawing.Point(78, 5)
        Me.cbeMaterialType.Name = "cbeMaterialType"
        Me.cbeMaterialType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMaterialType.Size = New System.Drawing.Size(245, 20)
        Me.cbeMaterialType.TabIndex = 1
        '
        'lblMaterialType
        '
        Me.lblMaterialType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMaterialType.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMaterialType.Appearance.Options.UseFont = True
        Me.lblMaterialType.Location = New System.Drawing.Point(18, 8)
        Me.lblMaterialType.Name = "lblMaterialType"
        Me.lblMaterialType.Size = New System.Drawing.Size(47, 13)
        Me.lblMaterialType.TabIndex = 9
        Me.lblMaterialType.Text = "Material"
        '
        'cbBlankSize
        '
        Me.cbBlankSize.EnterMoveNextControl = True
        Me.cbBlankSize.Location = New System.Drawing.Point(77, 116)
        Me.cbBlankSize.Name = "cbBlankSize"
        Me.cbBlankSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbBlankSize.Size = New System.Drawing.Size(246, 20)
        Me.cbBlankSize.TabIndex = 5
        '
        'lblBlankSize
        '
        Me.lblBlankSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBlankSize.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblBlankSize.Appearance.Options.UseFont = True
        Me.lblBlankSize.Location = New System.Drawing.Point(3, 120)
        Me.lblBlankSize.Name = "lblBlankSize"
        Me.lblBlankSize.Size = New System.Drawing.Size(57, 13)
        Me.lblBlankSize.TabIndex = 7
        Me.lblBlankSize.Text = "Blank Size"
        '
        'txtQty
        '
        Me.txtQty.EnterMoveNextControl = True
        Me.txtQty.Location = New System.Drawing.Point(77, 88)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(246, 20)
        Me.txtQty.TabIndex = 4
        '
        'lblQty
        '
        Me.lblQty.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQty.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblQty.Appearance.Options.UseFont = True
        Me.lblQty.Location = New System.Drawing.Point(47, 92)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(20, 13)
        Me.lblQty.TabIndex = 6
        Me.lblQty.Text = "Qty"
        '
        'lblWidth
        '
        Me.lblWidth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWidth.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblWidth.Appearance.Options.UseFont = True
        Me.lblWidth.Location = New System.Drawing.Point(31, 64)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(33, 13)
        Me.lblWidth.TabIndex = 3
        Me.lblWidth.Text = "Width"
        '
        'txtWidth
        '
        Me.txtWidth.EnterMoveNextControl = True
        Me.txtWidth.Location = New System.Drawing.Point(78, 60)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(245, 20)
        Me.txtWidth.TabIndex = 3
        '
        'lblHeight
        '
        Me.lblHeight.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHeight.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblHeight.Appearance.Options.UseFont = True
        Me.lblHeight.Location = New System.Drawing.Point(26, 36)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(37, 13)
        Me.lblHeight.TabIndex = 1
        Me.lblHeight.Text = "Height"
        '
        'txtHeight
        '
        Me.txtHeight.EnterMoveNextControl = True
        Me.txtHeight.Location = New System.Drawing.Point(77, 32)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(246, 20)
        Me.txtHeight.TabIndex = 2
        '
        'gcHole
        '
        Me.gcHole.AppearanceCaption.Options.UseTextOptions = True
        Me.gcHole.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcHole.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.gcHole.Controls.Add(Me.cbSpacing)
        Me.gcHole.Controls.Add(Me.cbDIa)
        Me.gcHole.Controls.Add(Me.lcSpacing)
        Me.gcHole.Controls.Add(Me.lblDia)
        Me.gcHole.Location = New System.Drawing.Point(14, 343)
        Me.gcHole.Name = "gcHole"
        Me.gcHole.Size = New System.Drawing.Size(326, 86)
        Me.gcHole.TabIndex = 3
        Me.gcHole.Text = "Peg Holes"
        '
        'cbSpacing
        '
        Me.cbSpacing.EnterMoveNextControl = True
        Me.cbSpacing.Location = New System.Drawing.Point(78, 53)
        Me.cbSpacing.Name = "cbSpacing"
        Me.cbSpacing.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbSpacing.Size = New System.Drawing.Size(243, 20)
        Me.cbSpacing.TabIndex = 13
        '
        'cbDIa
        '
        Me.cbDIa.EnterMoveNextControl = True
        Me.cbDIa.Location = New System.Drawing.Point(79, 27)
        Me.cbDIa.Name = "cbDIa"
        Me.cbDIa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbDIa.Properties.Sorted = True
        Me.cbDIa.Size = New System.Drawing.Size(242, 20)
        Me.cbDIa.TabIndex = 12
        '
        'lcSpacing
        '
        Me.lcSpacing.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lcSpacing.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lcSpacing.Appearance.Options.UseFont = True
        Me.lcSpacing.Location = New System.Drawing.Point(18, 55)
        Me.lcSpacing.Name = "lcSpacing"
        Me.lcSpacing.Size = New System.Drawing.Size(44, 13)
        Me.lcSpacing.TabIndex = 3
        Me.lcSpacing.Text = "Spacing"
        '
        'lblDia
        '
        Me.lblDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDia.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDia.Appearance.Options.UseFont = True
        Me.lblDia.Location = New System.Drawing.Point(11, 32)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.Size = New System.Drawing.Size(53, 13)
        Me.lblDia.TabIndex = 1
        Me.lblDia.Text = "Diameter"
        '
        'sbCancel
        '
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Location = New System.Drawing.Point(14, 495)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 11
        Me.sbCancel.Text = "Cancel"
        '
        'sbRun
        '
        Me.sbRun.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sbRun.Appearance.Options.UseFont = True
        Me.sbRun.Location = New System.Drawing.Point(14, 445)
        Me.sbRun.Name = "sbRun"
        Me.sbRun.Size = New System.Drawing.Size(326, 34)
        Me.sbRun.TabIndex = 14
        Me.sbRun.Text = "Run"
        '
        'sbReset
        '
        Me.sbReset.Location = New System.Drawing.Point(265, 495)
        Me.sbReset.Name = "sbReset"
        Me.sbReset.Size = New System.Drawing.Size(75, 23)
        Me.sbReset.TabIndex = 10
        Me.sbReset.Text = "Reset"
        '
        'gcNotch_Corners
        '
        Me.gcNotch_Corners.Controls.Add(Me.rgPresser)
        Me.gcNotch_Corners.Controls.Add(Me.lblPresser)
        Me.gcNotch_Corners.Controls.Add(Me.rgNotch)
        Me.gcNotch_Corners.Controls.Add(Me.rgLogo)
        Me.gcNotch_Corners.Controls.Add(Me.lblLogo)
        Me.gcNotch_Corners.Controls.Add(Me.lblNotchCorners)
        Me.gcNotch_Corners.Location = New System.Drawing.Point(15, 206)
        Me.gcNotch_Corners.Name = "gcNotch_Corners"
        Me.gcNotch_Corners.ShowCaption = False
        Me.gcNotch_Corners.Size = New System.Drawing.Size(325, 107)
        Me.gcNotch_Corners.TabIndex = 8
        Me.gcNotch_Corners.Text = "Miscellaneous"
        '
        'rgPresser
        '
        Me.rgPresser.Location = New System.Drawing.Point(100, 70)
        Me.rgPresser.Name = "rgPresser"
        Me.rgPresser.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rgPresser.Properties.Appearance.Options.UseBackColor = True
        Me.rgPresser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rgPresser.Properties.Columns = 2
        Me.rgPresser.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "On", True, True), New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Off", True, True)})
        Me.rgPresser.Size = New System.Drawing.Size(188, 25)
        Me.rgPresser.TabIndex = 7
        '
        'lblPresser
        '
        Me.lblPresser.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPresser.Appearance.Options.UseFont = True
        Me.lblPresser.Location = New System.Drawing.Point(7, 73)
        Me.lblPresser.Name = "lblPresser"
        Me.lblPresser.Size = New System.Drawing.Size(71, 13)
        Me.lblPresser.TabIndex = 13
        Me.lblPresser.Text = "Presser Foot"
        '
        'rgNotch
        '
        Me.rgNotch.Location = New System.Drawing.Point(100, 36)
        Me.rgNotch.Name = "rgNotch"
        Me.rgNotch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rgNotch.Properties.Appearance.Options.UseBackColor = True
        Me.rgNotch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rgNotch.Properties.Columns = 2
        Me.rgNotch.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Yes"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "No")})
        Me.rgNotch.Size = New System.Drawing.Size(188, 28)
        Me.rgNotch.TabIndex = 6
        '
        'rgLogo
        '
        Me.rgLogo.Location = New System.Drawing.Point(100, 8)
        Me.rgLogo.Name = "rgLogo"
        Me.rgLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rgLogo.Properties.Appearance.Options.UseBackColor = True
        Me.rgLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rgLogo.Properties.ColumnIndent = 2
        Me.rgLogo.Properties.Columns = 2
        Me.rgLogo.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Yes"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "No")})
        Me.rgLogo.Size = New System.Drawing.Size(185, 28)
        Me.rgLogo.TabIndex = 5
        '
        'lblLogo
        '
        Me.lblLogo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLogo.Appearance.Options.UseFont = True
        Me.lblLogo.Location = New System.Drawing.Point(59, 13)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Size = New System.Drawing.Size(27, 13)
        Me.lblLogo.TabIndex = 9
        Me.lblLogo.Text = "Logo"
        '
        'lblNotchCorners
        '
        Me.lblNotchCorners.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotchCorners.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblNotchCorners.Appearance.Options.UseFont = True
        Me.lblNotchCorners.Location = New System.Drawing.Point(52, 43)
        Me.lblNotchCorners.Name = "lblNotchCorners"
        Me.lblNotchCorners.Size = New System.Drawing.Size(32, 13)
        Me.lblNotchCorners.TabIndex = 7
        Me.lblNotchCorners.Text = "Notch"
        '
        'rgProductType
        '
        Me.rgProductType.EnterMoveNextControl = True
        Me.rgProductType.Location = New System.Drawing.Point(17, 12)
        Me.rgProductType.Margin = New System.Windows.Forms.Padding(0)
        Me.rgProductType.Name = "rgProductType"
        Me.rgProductType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rgProductType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rgProductType.Properties.Appearance.Options.UseBackColor = True
        Me.rgProductType.Properties.Appearance.Options.UseFont = True
        Me.rgProductType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rgProductType.Properties.ColumnIndent = 50
        Me.rgProductType.Properties.Columns = 2
        Me.rgProductType.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.rgProductType.Properties.ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Near
        Me.rgProductType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "PegBoard MX"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "MagPanel")})
        Me.rgProductType.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Column
        Me.rgProductType.Size = New System.Drawing.Size(321, 33)
        Me.rgProductType.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Location = New System.Drawing.Point(12, 5)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(328, 45)
        Me.PanelControl1.TabIndex = 13
        '
        'pcMagPanel
        '
        Me.pcMagPanel.Controls.Add(Me.rgCorner)
        Me.pcMagPanel.Controls.Add(Me.RadioGroup1)
        Me.pcMagPanel.Controls.Add(Me.lblPresser2)
        Me.pcMagPanel.Controls.Add(Me.lblCorner)
        Me.pcMagPanel.Controls.Add(Me.LabelControl1)
        Me.pcMagPanel.Controls.Add(Me.rgMountingHoles)
        Me.pcMagPanel.Location = New System.Drawing.Point(13, 206)
        Me.pcMagPanel.Name = "pcMagPanel"
        Me.pcMagPanel.Size = New System.Drawing.Size(327, 127)
        Me.pcMagPanel.TabIndex = 14
        '
        'rgCorner
        '
        Me.rgCorner.Location = New System.Drawing.Point(124, 48)
        Me.rgCorner.Name = "rgCorner"
        Me.rgCorner.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rgCorner.Properties.Appearance.Options.UseBackColor = True
        Me.rgCorner.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rgCorner.Properties.Columns = 2
        Me.rgCorner.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Round"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Square")})
        Me.rgCorner.Size = New System.Drawing.Size(164, 28)
        Me.rgCorner.TabIndex = 10
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(124, 85)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RadioGroup1.Properties.Appearance.Options.UseBackColor = True
        Me.RadioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RadioGroup1.Properties.Columns = 2
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "On"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Off")})
        Me.RadioGroup1.Size = New System.Drawing.Size(164, 33)
        Me.RadioGroup1.TabIndex = 11
        '
        'lblPresser2
        '
        Me.lblPresser2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPresser2.Appearance.Options.UseFont = True
        Me.lblPresser2.Location = New System.Drawing.Point(22, 92)
        Me.lblPresser2.Name = "lblPresser2"
        Me.lblPresser2.Size = New System.Drawing.Size(71, 13)
        Me.lblPresser2.TabIndex = 3
        Me.lblPresser2.Text = "Presser Foot"
        '
        'lblCorner
        '
        Me.lblCorner.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCorner.Appearance.Options.UseFont = True
        Me.lblCorner.Location = New System.Drawing.Point(49, 52)
        Me.lblCorner.Name = "lblCorner"
        Me.lblCorner.Size = New System.Drawing.Size(44, 13)
        Me.lblCorner.TabIndex = 2
        Me.lblCorner.Text = "Corners"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(6, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Mounting Holes"
        '
        'rgMountingHoles
        '
        Me.rgMountingHoles.Location = New System.Drawing.Point(124, 10)
        Me.rgMountingHoles.Name = "rgMountingHoles"
        Me.rgMountingHoles.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rgMountingHoles.Properties.Appearance.Options.UseBackColor = True
        Me.rgMountingHoles.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rgMountingHoles.Properties.ColumnIndent = 9
        Me.rgMountingHoles.Properties.Columns = 2
        Me.rgMountingHoles.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "Yes", True, True), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "No", True, False)})
        Me.rgMountingHoles.Size = New System.Drawing.Size(164, 26)
        Me.rgMountingHoles.TabIndex = 9
        '
        'dlgLifeGear
        '
        Me.AcceptButton = Me.sbRun
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.CancelButton = Me.sbCancel
        Me.ClientSize = New System.Drawing.Size(354, 530)
        Me.Controls.Add(Me.rgProductType)
        Me.Controls.Add(Me.sbReset)
        Me.Controls.Add(Me.sbRun)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.gcHole)
        Me.Controls.Add(Me.gcSize)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.gcNotch_Corners)
        Me.Controls.Add(Me.pcMagPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgLifeGear"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "diamondLife"
        Me.TopMost = True
        CType(Me.gcSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcSize.ResumeLayout(False)
        Me.gcSize.PerformLayout()
        CType(Me.cbeMaterialType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBlankSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcHole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcHole.ResumeLayout(False)
        Me.gcHole.PerformLayout()
        CType(Me.cbSpacing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDIa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcNotch_Corners, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcNotch_Corners.ResumeLayout(False)
        Me.gcNotch_Corners.PerformLayout()
        CType(Me.rgPresser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgNotch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgLogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgProductType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcMagPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcMagPanel.ResumeLayout(False)
        Me.pcMagPanel.PerformLayout()
        CType(Me.rgCorner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgMountingHoles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gcSize As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblWidth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWidth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblHeight As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gcHole As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cbDIa As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lcSpacing As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbSpacing As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblQty As DevExpress.XtraEditors.LabelControl
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbRun As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcNotch_Corners As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblNotchCorners As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rgLogo As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lblLogo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rgNotch As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents rgPresser As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lblPresser As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbBlankSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblBlankSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rgProductType As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pcMagPanel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rgCorner As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lblPresser2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCorner As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rgMountingHoles As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents cbeMaterialType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblMaterialType As DevExpress.XtraEditors.LabelControl
End Class
