<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlowchart
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
        Me.chkAllHolesFirst = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHolesByToolOrder = New DevExpress.XtraEditors.CheckEdit()
        Me.chkByCompletePart = New DevExpress.XtraEditors.CheckEdit()
        Me.chkByRecursion = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHolesAcrossLocalNest = New DevExpress.XtraEditors.CheckEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkAllHolesFirst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHolesByToolOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkByCompletePart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkByRecursion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHolesAcrossLocalNest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkAllHolesFirst
        '
        Me.chkAllHolesFirst.Location = New System.Drawing.Point(29, 12)
        Me.chkAllHolesFirst.Name = "chkAllHolesFirst"
        Me.chkAllHolesFirst.Properties.Caption = "Process all holes across work areas first?"
        Me.chkAllHolesFirst.Size = New System.Drawing.Size(221, 19)
        Me.chkAllHolesFirst.TabIndex = 0
        '
        'chkHolesByToolOrder
        '
        Me.chkHolesByToolOrder.Location = New System.Drawing.Point(50, 46)
        Me.chkHolesByToolOrder.Name = "chkHolesByToolOrder"
        Me.chkHolesByToolOrder.Properties.Caption = "Process holes by tool order?"
        Me.chkHolesByToolOrder.Size = New System.Drawing.Size(167, 19)
        Me.chkHolesByToolOrder.TabIndex = 1
        '
        'chkByCompletePart
        '
        Me.chkByCompletePart.Location = New System.Drawing.Point(29, 80)
        Me.chkByCompletePart.Name = "chkByCompletePart"
        Me.chkByCompletePart.Properties.Caption = "Process by complete part?"
        Me.chkByCompletePart.Size = New System.Drawing.Size(152, 19)
        Me.chkByCompletePart.TabIndex = 2
        '
        'chkByRecursion
        '
        Me.chkByRecursion.Location = New System.Drawing.Point(50, 114)
        Me.chkByRecursion.Name = "chkByRecursion"
        Me.chkByRecursion.Properties.Caption = "Process local nested parts, interior to exterior?"
        Me.chkByRecursion.Size = New System.Drawing.Size(256, 19)
        Me.chkByRecursion.TabIndex = 3
        '
        'chkHolesAcrossLocalNest
        '
        Me.chkHolesAcrossLocalNest.Location = New System.Drawing.Point(50, 148)
        Me.chkHolesAcrossLocalNest.Name = "chkHolesAcrossLocalNest"
        Me.chkHolesAcrossLocalNest.Properties.Caption = "Process holes across local nest?"
        Me.chkHolesAcrossLocalNest.Size = New System.Drawing.Size(183, 19)
        Me.chkHolesAcrossLocalNest.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(3, 40)
        Me.Label1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(38, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 3)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 3)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(3, 55)
        Me.Label4.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(37, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 3)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Label5"
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(291, 10)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "Ok"
        '
        'frmFlowchart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkHolesAcrossLocalNest)
        Me.Controls.Add(Me.chkByRecursion)
        Me.Controls.Add(Me.chkByCompletePart)
        Me.Controls.Add(Me.chkHolesByToolOrder)
        Me.Controls.Add(Me.chkAllHolesFirst)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFlowchart"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Flowchart Parameters"
        CType(Me.chkAllHolesFirst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHolesByToolOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkByCompletePart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkByRecursion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHolesAcrossLocalNest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkAllHolesFirst As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkHolesByToolOrder As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkByCompletePart As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkByRecursion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkHolesAcrossLocalNest As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
End Class
