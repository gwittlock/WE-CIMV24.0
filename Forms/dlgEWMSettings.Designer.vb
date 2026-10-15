<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEWMSettings
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
        Me.grpNesting = New DevExpress.XtraEditors.GroupControl()
        Me.mtbResolution = New DevExpress.XtraEditors.TextEdit()
        Me.mtbGapTol = New FabV24_WIN8.MathTextBox()
        Me.lcbGapManagement = New FabV24_WIN8.LabelComboBox()
        Me.lcbUseBitmapNesting = New FabV24_WIN8.LabelComboBox()
        Me.lcbFilterDuplicates = New FabV24_WIN8.LabelComboBox()
        Me.lcbPrintSeeds = New FabV24_WIN8.LabelComboBox()
        Me.lcbToolExtrusion = New FabV24_WIN8.LabelComboBox()
        Me.lcbV17LPP = New FabV24_WIN8.LabelComboBox()
        Me.lcbUseOldDxf = New FabV24_WIN8.LabelComboBox()
        Me.lcbGraphics = New FabV24_WIN8.LabelComboBox()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.chkUseAutoLog = New System.Windows.Forms.CheckBox()
        Me.cbfEWMSettings = New FabV24_WIN8.WindowsApplication234.ChkBoxFrame()
        Me.chkEWMSeeds = New System.Windows.Forms.CheckBox()
        Me.chkEWMNesting = New System.Windows.Forms.CheckBox()
        Me.chkEWMFile = New System.Windows.Forms.CheckBox()
        Me.chkEWMDao = New System.Windows.Forms.CheckBox()
        Me.chkEWMUI = New System.Windows.Forms.CheckBox()
        Me.chkEWMPortal = New System.Windows.Forms.CheckBox()
        Me.chkEWMDiagnostics = New System.Windows.Forms.CheckBox()
        Me.chkEWMInternal = New System.Windows.Forms.CheckBox()
        Me.chkEWMUser = New System.Windows.Forms.CheckBox()
        Me.chkEWMWarnings = New System.Windows.Forms.CheckBox()
        Me.chkEWMFilter = New System.Windows.Forms.CheckBox()
        Me.lblResolution = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grpNesting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNesting.SuspendLayout()
        CType(Me.mtbResolution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbfEWMSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpNesting
        '
        Me.grpNesting.Controls.Add(Me.lblResolution)
        Me.grpNesting.Controls.Add(Me.mtbResolution)
        Me.grpNesting.Controls.Add(Me.mtbGapTol)
        Me.grpNesting.Controls.Add(Me.lcbGapManagement)
        Me.grpNesting.Controls.Add(Me.lcbUseBitmapNesting)
        Me.grpNesting.Controls.Add(Me.lcbFilterDuplicates)
        Me.grpNesting.Controls.Add(Me.lcbPrintSeeds)
        Me.grpNesting.Controls.Add(Me.lcbToolExtrusion)
        Me.grpNesting.Controls.Add(Me.lcbV17LPP)
        Me.grpNesting.Controls.Add(Me.lcbUseOldDxf)
        Me.grpNesting.Controls.Add(Me.lcbGraphics)
        Me.grpNesting.Location = New System.Drawing.Point(12, 12)
        Me.grpNesting.Name = "grpNesting"
        Me.grpNesting.Size = New System.Drawing.Size(522, 187)
        Me.grpNesting.TabIndex = 0
        Me.grpNesting.Text = "Nesting Settings"
        '
        'mtbResolution
        '
        Me.mtbResolution.Location = New System.Drawing.Point(132, 116)
        Me.mtbResolution.MaximumSize = New System.Drawing.Size(175, 25)
        Me.mtbResolution.Name = "mtbResolution"
        Me.mtbResolution.Size = New System.Drawing.Size(104, 20)
        Me.mtbResolution.TabIndex = 6
        '
        'mtbGapTol
        '
        Me.mtbGapTol.BackColor = System.Drawing.Color.Transparent
        Me.mtbGapTol.Caption = "Gap Tolerance"
        Me.mtbGapTol.CaptionLocation = FabV24_WIN8.MathTextBox.CaptionLocations.clLeft
        Me.mtbGapTol.EvaluatorUsed = True
        Me.mtbGapTol.FieldStyle = FabV24_WIN8.MathTextBox.FieldStyles.fsAuto
        Me.mtbGapTol.FieldWidth = 255
        Me.mtbGapTol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbGapTol.FormatString = Nothing
        Me.mtbGapTol.Location = New System.Drawing.Point(312, 85)
        Me.mtbGapTol.MaxLength = 0
        Me.mtbGapTol.MaxValue = Nothing
        Me.mtbGapTol.MaxValueUsed = False
        Me.mtbGapTol.MinValue = Nothing
        Me.mtbGapTol.MinValueUsed = False
        Me.mtbGapTol.Name = "mtbGapTol"
        Me.mtbGapTol.Size = New System.Drawing.Size(175, 25)
        Me.mtbGapTol.Suppressed = False
        Me.mtbGapTol.TabIndex = 5
        Me.mtbGapTol.UseMnemonic = True
        '
        'lcbGapManagement
        '
        Me.lcbGapManagement.BackColor = System.Drawing.Color.Transparent
        Me.lcbGapManagement.Caption = "Gap Management"
        Me.lcbGapManagement.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbGapManagement.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbGapManagement.FieldWidth = 495
        Me.lcbGapManagement.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbGapManagement.ListIndex = -1
        Me.lcbGapManagement.Location = New System.Drawing.Point(51, 54)
        Me.lcbGapManagement.Name = "lcbGapManagement"
        Me.lcbGapManagement.Size = New System.Drawing.Size(185, 25)
        Me.lcbGapManagement.TabIndex = 2
        Me.lcbGapManagement.UseMnemonic = True
        '
        'lcbUseBitmapNesting
        '
        Me.lcbUseBitmapNesting.BackColor = System.Drawing.Color.Transparent
        Me.lcbUseBitmapNesting.Caption = "Use Bitmap Nesting"
        Me.lcbUseBitmapNesting.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbUseBitmapNesting.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbUseBitmapNesting.FieldWidth = 495
        Me.lcbUseBitmapNesting.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbUseBitmapNesting.ListIndex = -1
        Me.lcbUseBitmapNesting.Location = New System.Drawing.Point(40, 85)
        Me.lcbUseBitmapNesting.Name = "lcbUseBitmapNesting"
        Me.lcbUseBitmapNesting.Size = New System.Drawing.Size(196, 25)
        Me.lcbUseBitmapNesting.TabIndex = 4
        Me.lcbUseBitmapNesting.UseMnemonic = True
        '
        'lcbFilterDuplicates
        '
        Me.lcbFilterDuplicates.BackColor = System.Drawing.Color.Transparent
        Me.lcbFilterDuplicates.Caption = "Filter Duplicate Geometry"
        Me.lcbFilterDuplicates.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbFilterDuplicates.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbFilterDuplicates.FieldWidth = 495
        Me.lcbFilterDuplicates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbFilterDuplicates.ListIndex = -1
        Me.lcbFilterDuplicates.Location = New System.Drawing.Point(12, 147)
        Me.lcbFilterDuplicates.Name = "lcbFilterDuplicates"
        Me.lcbFilterDuplicates.Size = New System.Drawing.Size(224, 25)
        Me.lcbFilterDuplicates.TabIndex = 8
        Me.lcbFilterDuplicates.UseMnemonic = True
        '
        'lcbPrintSeeds
        '
        Me.lcbPrintSeeds.BackColor = System.Drawing.Color.Transparent
        Me.lcbPrintSeeds.Caption = "Print Seeds"
        Me.lcbPrintSeeds.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbPrintSeeds.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbPrintSeeds.FieldWidth = 495
        Me.lcbPrintSeeds.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbPrintSeeds.ListIndex = -1
        Me.lcbPrintSeeds.Location = New System.Drawing.Point(327, 23)
        Me.lcbPrintSeeds.Name = "lcbPrintSeeds"
        Me.lcbPrintSeeds.Size = New System.Drawing.Size(160, 25)
        Me.lcbPrintSeeds.TabIndex = 1
        Me.lcbPrintSeeds.UseMnemonic = True
        '
        'lcbToolExtrusion
        '
        Me.lcbToolExtrusion.BackColor = System.Drawing.Color.Transparent
        Me.lcbToolExtrusion.Caption = "Tool Extrusion"
        Me.lcbToolExtrusion.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbToolExtrusion.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbToolExtrusion.FieldWidth = 495
        Me.lcbToolExtrusion.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbToolExtrusion.ListIndex = -1
        Me.lcbToolExtrusion.Location = New System.Drawing.Point(314, 54)
        Me.lcbToolExtrusion.Name = "lcbToolExtrusion"
        Me.lcbToolExtrusion.Size = New System.Drawing.Size(173, 25)
        Me.lcbToolExtrusion.TabIndex = 3
        Me.lcbToolExtrusion.UseMnemonic = True
        '
        'lcbV17LPP
        '
        Me.lcbV17LPP.BackColor = System.Drawing.Color.Transparent
        Me.lcbV17LPP.Caption = "V17 Large Part Pass"
        Me.lcbV17LPP.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbV17LPP.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbV17LPP.FieldWidth = 495
        Me.lcbV17LPP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbV17LPP.ListIndex = -1
        Me.lcbV17LPP.Location = New System.Drawing.Point(283, 116)
        Me.lcbV17LPP.Name = "lcbV17LPP"
        Me.lcbV17LPP.Size = New System.Drawing.Size(204, 25)
        Me.lcbV17LPP.TabIndex = 7
        Me.lcbV17LPP.UseMnemonic = True
        '
        'lcbUseOldDxf
        '
        Me.lcbUseOldDxf.BackColor = System.Drawing.Color.Transparent
        Me.lcbUseOldDxf.Caption = "Use Old DXF Conversion"
        Me.lcbUseOldDxf.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbUseOldDxf.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbUseOldDxf.FieldWidth = 495
        Me.lcbUseOldDxf.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbUseOldDxf.ListIndex = -1
        Me.lcbUseOldDxf.Location = New System.Drawing.Point(263, 147)
        Me.lcbUseOldDxf.Name = "lcbUseOldDxf"
        Me.lcbUseOldDxf.Size = New System.Drawing.Size(224, 25)
        Me.lcbUseOldDxf.TabIndex = 9
        Me.lcbUseOldDxf.UseMnemonic = True
        '
        'lcbGraphics
        '
        Me.lcbGraphics.BackColor = System.Drawing.Color.Transparent
        Me.lcbGraphics.Caption = "Graphics"
        Me.lcbGraphics.CaptionLocation = FabV24_WIN8.LabelComboBox.CaptionLocations.clLeft
        Me.lcbGraphics.FieldStyle = FabV24_WIN8.LabelComboBox.FieldStyles.fsAuto
        Me.lcbGraphics.FieldWidth = 495
        Me.lcbGraphics.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcbGraphics.ListIndex = -1
        Me.lcbGraphics.Location = New System.Drawing.Point(94, 23)
        Me.lcbGraphics.Name = "lcbGraphics"
        Me.lcbGraphics.Size = New System.Drawing.Size(142, 25)
        Me.lcbGraphics.TabIndex = 0
        Me.lcbGraphics.UseMnemonic = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(467, 303)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(67, 23)
        Me.cmdOK.TabIndex = 13
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(467, 332)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(67, 23)
        Me.cmdCancel.TabIndex = 14
        Me.cmdCancel.Text = "Cancel"
        '
        'chkUseAutoLog
        '
        Me.chkUseAutoLog.AutoSize = True
        Me.chkUseAutoLog.Location = New System.Drawing.Point(390, 215)
        Me.chkUseAutoLog.Name = "chkUseAutoLog"
        Me.chkUseAutoLog.Size = New System.Drawing.Size(90, 17)
        Me.chkUseAutoLog.TabIndex = 15
        Me.chkUseAutoLog.Text = "Use Auto Log"
        Me.chkUseAutoLog.UseVisualStyleBackColor = True
        '
        'cbfEWMSettings
        '
        Me.cbfEWMSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.cbfEWMSettings.Caption = "Enable EWM"
        Me.cbfEWMSettings.CaptionColor = System.Drawing.Color.Silver
        Me.cbfEWMSettings.Checked = False
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMSeeds)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMNesting)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMFile)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMDao)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMUI)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMPortal)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMDiagnostics)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMInternal)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMUser)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMWarnings)
        Me.cbfEWMSettings.Controls.Add(Me.chkEWMFilter)
        Me.cbfEWMSettings.Location = New System.Drawing.Point(12, 205)
        Me.cbfEWMSettings.Name = "cbfEWMSettings"
        Me.cbfEWMSettings.Padding = New System.Windows.Forms.Padding(0, 11, 0, 0)
        Me.cbfEWMSettings.Size = New System.Drawing.Size(372, 153)
        Me.cbfEWMSettings.TabIndex = 12
        '
        'chkEWMSeeds
        '
        Me.chkEWMSeeds.AutoSize = True
        Me.chkEWMSeeds.Location = New System.Drawing.Point(283, 81)
        Me.chkEWMSeeds.Name = "chkEWMSeeds"
        Me.chkEWMSeeds.Size = New System.Drawing.Size(55, 17)
        Me.chkEWMSeeds.TabIndex = 23
        Me.chkEWMSeeds.Text = "Seeds"
        Me.chkEWMSeeds.UseVisualStyleBackColor = True
        '
        'chkEWMNesting
        '
        Me.chkEWMNesting.AutoSize = True
        Me.chkEWMNesting.Location = New System.Drawing.Point(283, 58)
        Me.chkEWMNesting.Name = "chkEWMNesting"
        Me.chkEWMNesting.Size = New System.Drawing.Size(62, 17)
        Me.chkEWMNesting.TabIndex = 22
        Me.chkEWMNesting.Text = "Nesting"
        Me.chkEWMNesting.UseVisualStyleBackColor = True
        '
        'chkEWMFile
        '
        Me.chkEWMFile.AutoSize = True
        Me.chkEWMFile.Location = New System.Drawing.Point(283, 35)
        Me.chkEWMFile.Name = "chkEWMFile"
        Me.chkEWMFile.Size = New System.Drawing.Size(42, 17)
        Me.chkEWMFile.TabIndex = 21
        Me.chkEWMFile.Text = "File"
        Me.chkEWMFile.UseVisualStyleBackColor = True
        '
        'chkEWMDao
        '
        Me.chkEWMDao.AutoSize = True
        Me.chkEWMDao.Location = New System.Drawing.Point(162, 104)
        Me.chkEWMDao.Name = "chkEWMDao"
        Me.chkEWMDao.Size = New System.Drawing.Size(48, 17)
        Me.chkEWMDao.TabIndex = 20
        Me.chkEWMDao.Text = "DAO"
        Me.chkEWMDao.UseVisualStyleBackColor = True
        '
        'chkEWMUI
        '
        Me.chkEWMUI.AutoSize = True
        Me.chkEWMUI.Location = New System.Drawing.Point(162, 81)
        Me.chkEWMUI.Name = "chkEWMUI"
        Me.chkEWMUI.Size = New System.Drawing.Size(37, 17)
        Me.chkEWMUI.TabIndex = 19
        Me.chkEWMUI.Text = "UI"
        Me.chkEWMUI.UseVisualStyleBackColor = True
        '
        'chkEWMPortal
        '
        Me.chkEWMPortal.AutoSize = True
        Me.chkEWMPortal.Location = New System.Drawing.Point(162, 58)
        Me.chkEWMPortal.Name = "chkEWMPortal"
        Me.chkEWMPortal.Size = New System.Drawing.Size(54, 17)
        Me.chkEWMPortal.TabIndex = 18
        Me.chkEWMPortal.Text = "Portal"
        Me.chkEWMPortal.UseVisualStyleBackColor = True
        '
        'chkEWMDiagnostics
        '
        Me.chkEWMDiagnostics.AutoSize = True
        Me.chkEWMDiagnostics.Location = New System.Drawing.Point(162, 35)
        Me.chkEWMDiagnostics.Name = "chkEWMDiagnostics"
        Me.chkEWMDiagnostics.Size = New System.Drawing.Size(80, 17)
        Me.chkEWMDiagnostics.TabIndex = 17
        Me.chkEWMDiagnostics.Text = "Diagnostics"
        Me.chkEWMDiagnostics.UseVisualStyleBackColor = True
        '
        'chkEWMInternal
        '
        Me.chkEWMInternal.AutoSize = True
        Me.chkEWMInternal.Location = New System.Drawing.Point(12, 104)
        Me.chkEWMInternal.Name = "chkEWMInternal"
        Me.chkEWMInternal.Size = New System.Drawing.Size(64, 17)
        Me.chkEWMInternal.TabIndex = 16
        Me.chkEWMInternal.Text = "Internal"
        Me.chkEWMInternal.UseVisualStyleBackColor = True
        '
        'chkEWMUser
        '
        Me.chkEWMUser.AutoSize = True
        Me.chkEWMUser.Location = New System.Drawing.Point(12, 81)
        Me.chkEWMUser.Name = "chkEWMUser"
        Me.chkEWMUser.Size = New System.Drawing.Size(48, 17)
        Me.chkEWMUser.TabIndex = 15
        Me.chkEWMUser.Text = "User"
        Me.chkEWMUser.UseVisualStyleBackColor = True
        '
        'chkEWMWarnings
        '
        Me.chkEWMWarnings.AutoSize = True
        Me.chkEWMWarnings.Location = New System.Drawing.Point(12, 58)
        Me.chkEWMWarnings.Name = "chkEWMWarnings"
        Me.chkEWMWarnings.Size = New System.Drawing.Size(71, 17)
        Me.chkEWMWarnings.TabIndex = 14
        Me.chkEWMWarnings.Text = "Warnings"
        Me.chkEWMWarnings.UseVisualStyleBackColor = True
        '
        'chkEWMFilter
        '
        Me.chkEWMFilter.AutoSize = True
        Me.chkEWMFilter.Location = New System.Drawing.Point(12, 35)
        Me.chkEWMFilter.Name = "chkEWMFilter"
        Me.chkEWMFilter.Size = New System.Drawing.Size(50, 17)
        Me.chkEWMFilter.TabIndex = 13
        Me.chkEWMFilter.Text = "Filter"
        Me.chkEWMFilter.UseVisualStyleBackColor = True
        '
        'lblResolution
        '
        Me.lblResolution.Location = New System.Drawing.Point(72, 119)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(54, 13)
        Me.lblResolution.TabIndex = 13
        Me.lblResolution.Text = "Resolution:"
        '
        'dlgEWMSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 360)
        Me.Controls.Add(Me.chkUseAutoLog)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cbfEWMSettings)
        Me.Controls.Add(Me.grpNesting)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgEWMSettings"
        Me.Text = "EWM & Nesting Settings"
        CType(Me.grpNesting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNesting.ResumeLayout(False)
        Me.grpNesting.PerformLayout()
        CType(Me.mtbResolution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbfEWMSettings.ResumeLayout(False)
        Me.cbfEWMSettings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpNesting As DevExpress.XtraEditors.GroupControl
    Friend WithEvents mtbGapTol As FabV24_WIN8.MathTextBox
    Friend WithEvents lcbGapManagement As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbUseBitmapNesting As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbFilterDuplicates As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbPrintSeeds As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbToolExtrusion As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbV17LPP As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbUseOldDxf As FabV24_WIN8.LabelComboBox
    Friend WithEvents lcbGraphics As FabV24_WIN8.LabelComboBox
    Friend WithEvents cbfEWMSettings As FabV24_WIN8.WindowsApplication234.ChkBoxFrame
    Friend WithEvents chkEWMSeeds As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMNesting As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMFile As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMDao As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMUI As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMPortal As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMDiagnostics As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMInternal As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMWarnings As System.Windows.Forms.CheckBox
    Friend WithEvents chkEWMFilter As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkUseAutoLog As System.Windows.Forms.CheckBox
    Friend WithEvents mtbResolution As TextEdit
    Friend WithEvents lblResolution As LabelControl
End Class
