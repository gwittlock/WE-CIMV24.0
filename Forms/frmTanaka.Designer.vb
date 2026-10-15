<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTanaka
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
        Me.lstPattern = New DevExpress.XtraEditors.ListBoxControl()
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.lstAllInstance = New DevExpress.XtraEditors.ListBoxControl()
        Me.ceFirstPartInsp = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstAllInstance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceFirstPartInsp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstPattern
        '
        Me.lstPattern.Location = New System.Drawing.Point(12, 41)
        Me.lstPattern.Name = "lstPattern"
        Me.lstPattern.Size = New System.Drawing.Size(260, 215)
        Me.lstPattern.TabIndex = 1
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(35, 262)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(216, 22)
        Me.btnAccept.TabIndex = 4
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.ToolTip = "Applies the values for the current operation."
        '
        'lstAllInstance
        '
        Me.lstAllInstance.Location = New System.Drawing.Point(12, 290)
        Me.lstAllInstance.Name = "lstAllInstance"
        Me.lstAllInstance.Size = New System.Drawing.Size(260, 164)
        Me.lstAllInstance.TabIndex = 5
        Me.lstAllInstance.Visible = False
        '
        'ceFirstPartInsp
        '
        Me.ceFirstPartInsp.Location = New System.Drawing.Point(12, 12)
        Me.ceFirstPartInsp.Name = "ceFirstPartInsp"
        Me.ceFirstPartInsp.Properties.Caption = "First Part Inspection"
        Me.ceFirstPartInsp.Size = New System.Drawing.Size(260, 19)
        Me.ceFirstPartInsp.TabIndex = 6
        '
        'frmTanaka
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 466)
        Me.Controls.Add(Me.ceFirstPartInsp)
        Me.Controls.Add(Me.lstAllInstance)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.lstPattern)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTanaka"
        Me.Text = "Sequence By Instance"
        CType(Me.lstPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstAllInstance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceFirstPartInsp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstPattern As ListBoxControl
    Friend WithEvents btnAccept As SimpleButton
    Friend WithEvents lstAllInstance As ListBoxControl
    Friend WithEvents ceFirstPartInsp As CheckEdit
End Class
