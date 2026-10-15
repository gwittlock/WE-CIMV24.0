<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProfileBlend
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
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.sbDetermineCross = New DevExpress.XtraEditors.SimpleButton()
        Me.ListBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
        Me.ListBoxControl2 = New DevExpress.XtraEditors.ListBoxControl()
        Me.sbMasterCheck = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListBoxControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(482, 511)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 15
        Me.SimpleButton2.Text = "Close"
        '
        'sbDetermineCross
        '
        Me.sbDetermineCross.Location = New System.Drawing.Point(457, 21)
        Me.sbDetermineCross.Name = "sbDetermineCross"
        Me.sbDetermineCross.Size = New System.Drawing.Size(102, 23)
        Me.sbDetermineCross.TabIndex = 24
        Me.sbDetermineCross.Text = "Determine Cross"
        '
        'ListBoxControl1
        '
        Me.ListBoxControl1.Location = New System.Drawing.Point(1, 7)
        Me.ListBoxControl1.Name = "ListBoxControl1"
        Me.ListBoxControl1.Size = New System.Drawing.Size(180, 527)
        Me.ListBoxControl1.TabIndex = 25
        '
        'ListBoxControl2
        '
        Me.ListBoxControl2.Location = New System.Drawing.Point(187, 7)
        Me.ListBoxControl2.Name = "ListBoxControl2"
        Me.ListBoxControl2.Size = New System.Drawing.Size(262, 527)
        Me.ListBoxControl2.TabIndex = 26
        '
        'sbMasterCheck
        '
        Me.sbMasterCheck.Location = New System.Drawing.Point(457, 257)
        Me.sbMasterCheck.Name = "sbMasterCheck"
        Me.sbMasterCheck.Size = New System.Drawing.Size(102, 23)
        Me.sbMasterCheck.TabIndex = 27
        Me.sbMasterCheck.Text = "Master Check"
        '
        'frmProfileBlend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 546)
        Me.Controls.Add(Me.sbMasterCheck)
        Me.Controls.Add(Me.sbDetermineCross)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.ListBoxControl2)
        Me.Controls.Add(Me.ListBoxControl1)
        Me.Name = "frmProfileBlend"
        Me.Text = "ProfileBlend"
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListBoxControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents L1EX As TextEdit
    Friend WithEvents L1EY As TextEdit
    Friend WithEvents SimpleButton2 As SimpleButton
    Friend WithEvents sbDetermineCross As SimpleButton
    Friend WithEvents ListBoxControl1 As ListBoxControl
    Friend WithEvents ListBoxControl2 As ListBoxControl
    Friend WithEvents sbMasterCheck As SimpleButton
End Class
