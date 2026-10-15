<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraphicsEditor
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
        Me.lstGraphicsEditor = New DevExpress.XtraEditors.ListBoxControl()
        Me.frmGraphicsEditorConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdGraphicsEditorStep = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdGraphicsEditorRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCodeGenFile = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.lstGraphicsEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmGraphicsEditorConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmGraphicsEditorConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstGraphicsEditor
        '
        Me.lstGraphicsEditor.Location = New System.Drawing.Point(12, 12)
        Me.lstGraphicsEditor.Name = "lstGraphicsEditor"
        Me.lstGraphicsEditor.Size = New System.Drawing.Size(283, 261)
        Me.lstGraphicsEditor.StyleController = Me.frmGraphicsEditorConvertedLayout
        Me.lstGraphicsEditor.TabIndex = 0
        '
        'frmGraphicsEditorConvertedLayout
        '
        Me.frmGraphicsEditorConvertedLayout.Controls.Add(Me.cmdGraphicsEditorStep)
        Me.frmGraphicsEditorConvertedLayout.Controls.Add(Me.cmdGraphicsEditorRefresh)
        Me.frmGraphicsEditorConvertedLayout.Controls.Add(Me.cmdCodeGenFile)
        Me.frmGraphicsEditorConvertedLayout.Controls.Add(Me.lstGraphicsEditor)
        Me.frmGraphicsEditorConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmGraphicsEditorConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmGraphicsEditorConvertedLayout.Name = "frmGraphicsEditorConvertedLayout"
        Me.frmGraphicsEditorConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmGraphicsEditorConvertedLayout.Size = New System.Drawing.Size(307, 337)
        Me.frmGraphicsEditorConvertedLayout.TabIndex = 5
        '
        'cmdGraphicsEditorStep
        '
        Me.cmdGraphicsEditorStep.Location = New System.Drawing.Point(202, 303)
        Me.cmdGraphicsEditorStep.Name = "cmdGraphicsEditorStep"
        Me.cmdGraphicsEditorStep.Size = New System.Drawing.Size(93, 22)
        Me.cmdGraphicsEditorStep.StyleController = Me.frmGraphicsEditorConvertedLayout
        Me.cmdGraphicsEditorStep.TabIndex = 4
        Me.cmdGraphicsEditorStep.Text = "Step"
        '
        'cmdGraphicsEditorRefresh
        '
        Me.cmdGraphicsEditorRefresh.Location = New System.Drawing.Point(12, 303)
        Me.cmdGraphicsEditorRefresh.Name = "cmdGraphicsEditorRefresh"
        Me.cmdGraphicsEditorRefresh.Size = New System.Drawing.Size(186, 22)
        Me.cmdGraphicsEditorRefresh.StyleController = Me.frmGraphicsEditorConvertedLayout
        Me.cmdGraphicsEditorRefresh.TabIndex = 3
        Me.cmdGraphicsEditorRefresh.Text = "Refresh"
        '
        'cmdCodeGenFile
        '
        Me.cmdCodeGenFile.Location = New System.Drawing.Point(12, 277)
        Me.cmdCodeGenFile.Name = "cmdCodeGenFile"
        Me.cmdCodeGenFile.Size = New System.Drawing.Size(283, 22)
        Me.cmdCodeGenFile.StyleController = Me.frmGraphicsEditorConvertedLayout
        Me.cmdCodeGenFile.TabIndex = 1
        Me.cmdCodeGenFile.Text = "<Select Code Generator>"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(307, 337)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdGraphicsEditorStep
        Me.LayoutControlItem1.CustomizationFormText = "SimpleButton4item"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(190, 291)
        Me.LayoutControlItem1.Name = "SimpleButton4item"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(97, 26)
        Me.LayoutControlItem1.Text = "SimpleButton4item"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdGraphicsEditorRefresh
        Me.LayoutControlItem2.CustomizationFormText = "SimpleButton3item"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 291)
        Me.LayoutControlItem2.Name = "SimpleButton3item"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(190, 26)
        Me.LayoutControlItem2.Text = "SimpleButton3item"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdCodeGenFile
        Me.LayoutControlItem4.CustomizationFormText = "SimpleButton1item"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 265)
        Me.LayoutControlItem4.Name = "SimpleButton1item"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(287, 26)
        Me.LayoutControlItem4.Text = "SimpleButton1item"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.lstGraphicsEditor
        Me.LayoutControlItem5.CustomizationFormText = "ListBoxControl1item"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "ListBoxControl1item"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(287, 265)
        Me.LayoutControlItem5.Text = "ListBoxControl1item"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'Timer1
        '
        '
        'frmGraphicsEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 337)
        Me.Controls.Add(Me.frmGraphicsEditorConvertedLayout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGraphicsEditor"
        Me.Text = "Code Preview"
        CType(Me.lstGraphicsEditor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmGraphicsEditorConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmGraphicsEditorConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstGraphicsEditor As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents frmGraphicsEditorConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents cmdGraphicsEditorStep As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdGraphicsEditorRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCodeGenFile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter

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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
