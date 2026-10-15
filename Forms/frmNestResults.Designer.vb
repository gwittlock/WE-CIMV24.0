<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNestResults
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
        Me.pcSideBar = New DevExpress.XtraEditors.PanelControl()
        Me.sbReport = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblHodParts = New DevExpress.XtraEditors.LabelControl()
        Me.txtHodParts = New DevExpress.XtraEditors.TextEdit()
        Me.lblFailedParts = New DevExpress.XtraEditors.LabelControl()
        Me.txtFailedParts = New DevExpress.XtraEditors.TextEdit()
        Me.lblRepeat = New DevExpress.XtraEditors.LabelControl()
        Me.txtRepeat = New DevExpress.XtraEditors.TextEdit()
        Me.ltbEfficiency = New DevExpress.XtraEditors.LabelControl()
        Me.txtEfficiency = New DevExpress.XtraEditors.TextEdit()
        Me.lblArea = New DevExpress.XtraEditors.LabelControl()
        Me.txtArea = New DevExpress.XtraEditors.TextEdit()
        Me.dataNestResults = New DevExpress.XtraEditors.DataNavigator()
        Me.pcPreview = New DevExpress.XtraEditors.PanelControl()
        Me.picPreview = New System.Windows.Forms.Panel()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.pnlFailedParts = New System.Windows.Forms.GroupBox()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lstFailedParts = New System.Windows.Forms.ListBox()
        CType(Me.pcSideBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcSideBar.SuspendLayout()
        CType(Me.txtHodParts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFailedParts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRepeat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfficiency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcPreview.SuspendLayout()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFailedParts.SuspendLayout()
        Me.SuspendLayout()
        '
        'pcSideBar
        '
        Me.pcSideBar.Controls.Add(Me.sbReport)
        Me.pcSideBar.Controls.Add(Me.cmdOK)
        Me.pcSideBar.Controls.Add(Me.cmdCancel)
        Me.pcSideBar.Controls.Add(Me.lblHodParts)
        Me.pcSideBar.Controls.Add(Me.txtHodParts)
        Me.pcSideBar.Controls.Add(Me.lblFailedParts)
        Me.pcSideBar.Controls.Add(Me.txtFailedParts)
        Me.pcSideBar.Controls.Add(Me.lblRepeat)
        Me.pcSideBar.Controls.Add(Me.txtRepeat)
        Me.pcSideBar.Controls.Add(Me.ltbEfficiency)
        Me.pcSideBar.Controls.Add(Me.txtEfficiency)
        Me.pcSideBar.Controls.Add(Me.lblArea)
        Me.pcSideBar.Controls.Add(Me.txtArea)
        Me.pcSideBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcSideBar.Location = New System.Drawing.Point(449, 0)
        Me.pcSideBar.Name = "pcSideBar"
        Me.pcSideBar.Size = New System.Drawing.Size(136, 335)
        Me.pcSideBar.TabIndex = 4
        '
        'sbReport
        '
        Me.sbReport.Location = New System.Drawing.Point(5, 186)
        Me.sbReport.Name = "sbReport"
        Me.sbReport.Size = New System.Drawing.Size(100, 23)
        Me.sbReport.TabIndex = 12
        Me.sbReport.Text = "Report"
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(24, 271)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(67, 23)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(24, 300)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(67, 23)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        '
        'lblHodParts
        '
        Me.lblHodParts.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblHodParts.Appearance.Options.UseFont = True
        Me.lblHodParts.Location = New System.Drawing.Point(5, 217)
        Me.lblHodParts.Name = "lblHodParts"
        Me.lblHodParts.Size = New System.Drawing.Size(58, 16)
        Me.lblHodParts.TabIndex = 9
        Me.lblHodParts.Text = "Hold Parts"
        '
        'txtHodParts
        '
        Me.txtHodParts.Location = New System.Drawing.Point(5, 236)
        Me.txtHodParts.Name = "txtHodParts"
        Me.txtHodParts.Size = New System.Drawing.Size(100, 20)
        Me.txtHodParts.TabIndex = 8
        '
        'lblFailedParts
        '
        Me.lblFailedParts.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblFailedParts.Appearance.Options.UseFont = True
        Me.lblFailedParts.Location = New System.Drawing.Point(5, 141)
        Me.lblFailedParts.Name = "lblFailedParts"
        Me.lblFailedParts.Size = New System.Drawing.Size(67, 16)
        Me.lblFailedParts.TabIndex = 7
        Me.lblFailedParts.Text = "Failed Parts"
        '
        'txtFailedParts
        '
        Me.txtFailedParts.Location = New System.Drawing.Point(5, 160)
        Me.txtFailedParts.Name = "txtFailedParts"
        Me.txtFailedParts.Size = New System.Drawing.Size(100, 20)
        Me.txtFailedParts.TabIndex = 6
        '
        'lblRepeat
        '
        Me.lblRepeat.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblRepeat.Appearance.Options.UseFont = True
        Me.lblRepeat.Location = New System.Drawing.Point(5, 100)
        Me.lblRepeat.Name = "lblRepeat"
        Me.lblRepeat.Size = New System.Drawing.Size(46, 16)
        Me.lblRepeat.TabIndex = 5
        Me.lblRepeat.Text = "Repeats"
        '
        'txtRepeat
        '
        Me.txtRepeat.Location = New System.Drawing.Point(5, 119)
        Me.txtRepeat.Name = "txtRepeat"
        Me.txtRepeat.Size = New System.Drawing.Size(100, 20)
        Me.txtRepeat.TabIndex = 4
        '
        'ltbEfficiency
        '
        Me.ltbEfficiency.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ltbEfficiency.Appearance.Options.UseFont = True
        Me.ltbEfficiency.Location = New System.Drawing.Point(5, 54)
        Me.ltbEfficiency.Name = "ltbEfficiency"
        Me.ltbEfficiency.Size = New System.Drawing.Size(53, 16)
        Me.ltbEfficiency.TabIndex = 3
        Me.ltbEfficiency.Text = "Efficiency"
        '
        'txtEfficiency
        '
        Me.txtEfficiency.Location = New System.Drawing.Point(5, 73)
        Me.txtEfficiency.Name = "txtEfficiency"
        Me.txtEfficiency.Size = New System.Drawing.Size(100, 20)
        Me.txtEfficiency.TabIndex = 2
        '
        'lblArea
        '
        Me.lblArea.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblArea.Appearance.Options.UseFont = True
        Me.lblArea.Location = New System.Drawing.Point(5, 10)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(27, 16)
        Me.lblArea.TabIndex = 1
        Me.lblArea.Text = "Area"
        '
        'txtArea
        '
        Me.txtArea.Location = New System.Drawing.Point(5, 29)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(100, 20)
        Me.txtArea.TabIndex = 0
        '
        'dataNestResults
        '
        Me.dataNestResults.Buttons.Append.Visible = False
        Me.dataNestResults.Buttons.CancelEdit.Visible = False
        Me.dataNestResults.Buttons.EndEdit.Visible = False
        Me.dataNestResults.Buttons.NextPage.Visible = False
        Me.dataNestResults.Buttons.PrevPage.Visible = False
        Me.dataNestResults.Buttons.Remove.Visible = False
        Me.dataNestResults.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.dataNestResults.Location = New System.Drawing.Point(0, 311)
        Me.dataNestResults.Name = "dataNestResults"
        Me.dataNestResults.Size = New System.Drawing.Size(444, 19)
        Me.dataNestResults.TabIndex = 3
        Me.dataNestResults.Text = "DataNavigator1"
        Me.dataNestResults.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center
        Me.dataNestResults.TextStringFormat = "Sheet {0} of {1}"
        '
        'pcPreview
        '
        Me.pcPreview.Controls.Add(Me.picPreview)
        Me.pcPreview.Location = New System.Drawing.Point(2, 25)
        Me.pcPreview.Name = "pcPreview"
        Me.pcPreview.Size = New System.Drawing.Size(444, 265)
        Me.pcPreview.TabIndex = 5
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.Black
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview.Location = New System.Drawing.Point(2, 2)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Padding = New System.Windows.Forms.Padding(3)
        Me.picPreview.Size = New System.Drawing.Size(440, 261)
        Me.picPreview.TabIndex = 1
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(45, 4)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(399, 20)
        Me.txtFilename.TabIndex = 7
        '
        'pnlFailedParts
        '
        Me.pnlFailedParts.Controls.Add(Me.cmdClose)
        Me.pnlFailedParts.Controls.Add(Me.lstFailedParts)
        Me.pnlFailedParts.Location = New System.Drawing.Point(0, 0)
        Me.pnlFailedParts.Name = "pnlFailedParts"
        Me.pnlFailedParts.Size = New System.Drawing.Size(448, 330)
        Me.pnlFailedParts.TabIndex = 8
        Me.pnlFailedParts.TabStop = False
        Me.pnlFailedParts.Text = "Failed Parts"
        Me.pnlFailedParts.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(181, 303)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        '
        'lstFailedParts
        '
        Me.lstFailedParts.FormattingEnabled = True
        Me.lstFailedParts.HorizontalScrollbar = True
        Me.lstFailedParts.Location = New System.Drawing.Point(13, 20)
        Me.lstFailedParts.Name = "lstFailedParts"
        Me.lstFailedParts.Size = New System.Drawing.Size(431, 277)
        Me.lstFailedParts.TabIndex = 1
        '
        'frmNestResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 335)
        Me.Controls.Add(Me.pnlFailedParts)
        Me.Controls.Add(Me.pcSideBar)
        Me.Controls.Add(Me.dataNestResults)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.pcPreview)
        Me.Name = "frmNestResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmNestResults"
        CType(Me.pcSideBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcSideBar.ResumeLayout(False)
        Me.pcSideBar.PerformLayout()
        CType(Me.txtHodParts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFailedParts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRepeat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfficiency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcPreview.ResumeLayout(False)
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFailedParts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcSideBar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents sbReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblHodParts As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHodParts As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFailedParts As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFailedParts As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblRepeat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRepeat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ltbEfficiency As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEfficiency As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblArea As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtArea As DevExpress.XtraEditors.TextEdit
    Friend WithEvents dataNestResults As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents pcPreview As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picPreview As System.Windows.Forms.Panel
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnlFailedParts As System.Windows.Forms.GroupBox
    Friend WithEvents lstFailedParts As System.Windows.Forms.ListBox
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
End Class
