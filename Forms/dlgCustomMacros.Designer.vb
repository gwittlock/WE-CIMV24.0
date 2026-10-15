<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgCustomMacros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgCustomMacros))
        Me.lstMacros = New DevExpress.XtraEditors.ListBoxControl()
        Me.beMacroFile = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblMacroFile = New DevExpress.XtraEditors.LabelControl()
        Me.lblMenuName = New DevExpress.XtraEditors.LabelControl()
        Me.teMenuName = New DevExpress.XtraEditors.TextEdit()
        Me.chkShowDialog = New DevExpress.XtraEditors.CheckEdit()
        Me.lblIcon = New DevExpress.XtraEditors.LabelControl()
        Me.beMacroIcon = New DevExpress.XtraEditors.ButtonEdit()
        Me.sbRemoveMacro = New DevExpress.XtraEditors.SimpleButton()
        Me.picIcon = New DevExpress.XtraEditors.PictureEdit()
        Me.dlgOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.sbApply = New DevExpress.XtraEditors.SimpleButton()
        Me.sbDone = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.lstMacros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beMacroFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teMenuName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowDialog.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beMacroIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstMacros
        '
        Me.lstMacros.Location = New System.Drawing.Point(12, 12)
        Me.lstMacros.Name = "lstMacros"
        Me.lstMacros.Size = New System.Drawing.Size(148, 163)
        Me.lstMacros.TabIndex = 0
        '
        'beMacroFile
        '
        Me.beMacroFile.Location = New System.Drawing.Point(244, 11)
        Me.beMacroFile.Name = "beMacroFile"
        Me.beMacroFile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beMacroFile.Size = New System.Drawing.Size(266, 20)
        Me.beMacroFile.TabIndex = 1
        Me.beMacroFile.ToolTip = "Select the Java file for the Macro you wish to add."
        '
        'lblMacroFile
        '
        Me.lblMacroFile.Location = New System.Drawing.Point(183, 15)
        Me.lblMacroFile.Name = "lblMacroFile"
        Me.lblMacroFile.Size = New System.Drawing.Size(55, 13)
        Me.lblMacroFile.TabIndex = 2
        Me.lblMacroFile.Text = "Add Macro:"
        '
        'lblMenuName
        '
        Me.lblMenuName.Location = New System.Drawing.Point(178, 40)
        Me.lblMenuName.Name = "lblMenuName"
        Me.lblMenuName.Size = New System.Drawing.Size(60, 13)
        Me.lblMenuName.TabIndex = 3
        Me.lblMenuName.Text = "Menu Name:"
        '
        'teMenuName
        '
        Me.teMenuName.Location = New System.Drawing.Point(244, 37)
        Me.teMenuName.Name = "teMenuName"
        Me.teMenuName.Size = New System.Drawing.Size(166, 20)
        Me.teMenuName.TabIndex = 4
        Me.teMenuName.ToolTip = "Enter the Name whcih will appear in the Macro menu."
        '
        'chkShowDialog
        '
        Me.chkShowDialog.EditValue = True
        Me.chkShowDialog.Location = New System.Drawing.Point(424, 37)
        Me.chkShowDialog.Name = "chkShowDialog"
        Me.chkShowDialog.Properties.Caption = "Show Dialog"
        Me.chkShowDialog.Size = New System.Drawing.Size(86, 19)
        Me.chkShowDialog.TabIndex = 5
        Me.chkShowDialog.ToolTip = "Check this box if the macro needs to show a dialog in order to specify parameters" &
    ""
        '
        'lblIcon
        '
        Me.lblIcon.Location = New System.Drawing.Point(192, 66)
        Me.lblIcon.Name = "lblIcon"
        Me.lblIcon.Size = New System.Drawing.Size(46, 13)
        Me.lblIcon.TabIndex = 7
        Me.lblIcon.Text = "Use Icon:"
        '
        'beMacroIcon
        '
        Me.beMacroIcon.Location = New System.Drawing.Point(244, 63)
        Me.beMacroIcon.Name = "beMacroIcon"
        Me.beMacroIcon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beMacroIcon.Size = New System.Drawing.Size(266, 20)
        Me.beMacroIcon.TabIndex = 6
        Me.beMacroIcon.ToolTip = "Select a icon form your local drive to display for the macro."
        '
        'sbRemoveMacro
        '
        Me.sbRemoveMacro.Location = New System.Drawing.Point(47, 181)
        Me.sbRemoveMacro.Name = "sbRemoveMacro"
        Me.sbRemoveMacro.Size = New System.Drawing.Size(75, 23)
        Me.sbRemoveMacro.TabIndex = 8
        Me.sbRemoveMacro.Text = "Remove"
        Me.sbRemoveMacro.ToolTip = "Click this button to delete the currenttly selected menu item in the list."
        '
        'picIcon
        '
        Me.picIcon.EditValue = CType(resources.GetObject("picIcon.EditValue"), Object)
        Me.picIcon.Location = New System.Drawing.Point(244, 89)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Properties.ReadOnly = True
        Me.picIcon.Properties.ShowMenu = False
        Me.picIcon.Size = New System.Drawing.Size(48, 48)
        Me.picIcon.TabIndex = 9
        '
        'dlgOpenDialog
        '
        Me.dlgOpenDialog.Filter = "Icon Files|*.ico"
        '
        'sbApply
        '
        Me.sbApply.Location = New System.Drawing.Point(232, 143)
        Me.sbApply.Name = "sbApply"
        Me.sbApply.Size = New System.Drawing.Size(75, 23)
        Me.sbApply.TabIndex = 10
        Me.sbApply.Text = "Apply"
        Me.sbApply.ToolTip = "Clcik this button to apply the macro to the system."
        '
        'sbDone
        '
        Me.sbDone.Location = New System.Drawing.Point(232, 181)
        Me.sbDone.Name = "sbDone"
        Me.sbDone.Size = New System.Drawing.Size(75, 23)
        Me.sbDone.TabIndex = 11
        Me.sbDone.Text = "Done"
        Me.sbDone.ToolTip = "Clcik this button when you are finished adding custom macros."
        '
        'dlgCustomMacros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 217)
        Me.Controls.Add(Me.sbDone)
        Me.Controls.Add(Me.sbApply)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.sbRemoveMacro)
        Me.Controls.Add(Me.lblIcon)
        Me.Controls.Add(Me.beMacroIcon)
        Me.Controls.Add(Me.chkShowDialog)
        Me.Controls.Add(Me.teMenuName)
        Me.Controls.Add(Me.lblMenuName)
        Me.Controls.Add(Me.lblMacroFile)
        Me.Controls.Add(Me.beMacroFile)
        Me.Controls.Add(Me.lstMacros)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "dlgCustomMacros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configure Custom Macros"
        CType(Me.lstMacros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beMacroFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teMenuName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowDialog.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beMacroIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstMacros As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents beMacroFile As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblMacroFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMenuName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teMenuName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkShowDialog As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblIcon As DevExpress.XtraEditors.LabelControl
    Friend WithEvents beMacroIcon As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents sbRemoveMacro As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents dlgOpenDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sbApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbDone As DevExpress.XtraEditors.SimpleButton
End Class
