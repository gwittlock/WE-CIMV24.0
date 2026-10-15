<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiamondLIfe
    Inherits DevExpress.XtraEditors.XtraForm
    Private m_currRecordID As Long
    Private m_searchString As String
    Private m_searchIndex As Integer

    Private m_code_gen As String
    Private m_ncfile As String
    Private m_is_active As Boolean
    Private sPortalCommand As String


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
        Me.frmGraphicsEditorConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.frmGraphicsEditorConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmGraphicsEditorConvertedLayout
        '
        Me.frmGraphicsEditorConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmGraphicsEditorConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmGraphicsEditorConvertedLayout.Name = "frmGraphicsEditorConvertedLayout"
        Me.frmGraphicsEditorConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmGraphicsEditorConvertedLayout.Size = New System.Drawing.Size(307, 337)
        Me.frmGraphicsEditorConvertedLayout.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(307, 337)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'frmDiamondLIfe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 337)
        Me.Controls.Add(Me.frmGraphicsEditorConvertedLayout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDiamondLIfe"
        Me.Text = "Code Preview"
        CType(Me.frmGraphicsEditorConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmGraphicsEditorConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_currRecordID = 0
        m_searchString = ""
        m_searchIndex = -1

        m_is_active = False
        m_code_gen = NEED_CODEGEN
        m_ncfile = ""

    End Sub
End Class
