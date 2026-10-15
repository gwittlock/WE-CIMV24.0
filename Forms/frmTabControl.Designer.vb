<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTabControl
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpMRPSettings = New DevExpress.XtraTab.XtraTabPage()
        Me.xtpFilesProcessed = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(12, 55)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.xtpMRPSettings
        Me.XtraTabControl1.Size = New System.Drawing.Size(898, 603)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpMRPSettings, Me.xtpFilesProcessed})
        '
        'xtpMRPSettings
        '
        Me.xtpMRPSettings.Name = "xtpMRPSettings"
        Me.xtpMRPSettings.Size = New System.Drawing.Size(893, 578)
        Me.xtpMRPSettings.Text = "MRP SEETTINGS"
        '
        'xtpFilesProcessed
        '
        Me.xtpFilesProcessed.Name = "xtpFilesProcessed"
        Me.xtpFilesProcessed.Size = New System.Drawing.Size(295, 275)
        Me.xtpFilesProcessed.Text = "Filles Process"
        '
        'frmTabControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 625)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "frmTabControl"
        Me.Text = "frmTabControl"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpMRPSettings As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtpFilesProcessed As DevExpress.XtraTab.XtraTabPage
End Class
