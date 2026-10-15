<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditAttributes
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
        Me.rgOptByGroup = New DevExpress.XtraEditors.RadioGroup()
        Me.dlgEditAttributesConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.vgEditAttributes = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.pnlCmdButtons = New DevExpress.XtraEditors.PanelControl()
        Me.cmdRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlEntity = New DevExpress.XtraEditors.PanelControl()
        Me.teEntity = New DevExpress.XtraEditors.TextEdit()
        Me.lcEntity = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        CType(Me.rgOptByGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dlgEditAttributesConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dlgEditAttributesConvertedLayout.SuspendLayout()
        CType(Me.vgEditAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCmdButtons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCmdButtons.SuspendLayout()
        CType(Me.pnlEntity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntity.SuspendLayout()
        CType(Me.teEntity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgOptByGroup
        '
        Me.rgOptByGroup.Location = New System.Drawing.Point(12, 12)
        Me.rgOptByGroup.Name = "rgOptByGroup"
        Me.rgOptByGroup.Properties.Columns = 2
        Me.rgOptByGroup.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Use Selection"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "By Entity")})
        Me.rgOptByGroup.Size = New System.Drawing.Size(220, 28)
        Me.rgOptByGroup.StyleController = Me.dlgEditAttributesConvertedLayout
        Me.rgOptByGroup.TabIndex = 2
        Me.rgOptByGroup.ToolTip = "Specify whether you want to change the attributes for all the slected items or ju" &
    "st a particular entity."
        Me.rgOptByGroup.Visible = False
        '
        'dlgEditAttributesConvertedLayout
        '
        Me.dlgEditAttributesConvertedLayout.Controls.Add(Me.cmdApply)
        Me.dlgEditAttributesConvertedLayout.Controls.Add(Me.vgEditAttributes)
        Me.dlgEditAttributesConvertedLayout.Controls.Add(Me.pnlCmdButtons)
        Me.dlgEditAttributesConvertedLayout.Controls.Add(Me.pnlEntity)
        Me.dlgEditAttributesConvertedLayout.Controls.Add(Me.rgOptByGroup)
        Me.dlgEditAttributesConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dlgEditAttributesConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.dlgEditAttributesConvertedLayout.Name = "dlgEditAttributesConvertedLayout"
        Me.dlgEditAttributesConvertedLayout.Root = Me.LayoutControlGroup1
        Me.dlgEditAttributesConvertedLayout.Size = New System.Drawing.Size(244, 398)
        Me.dlgEditAttributesConvertedLayout.TabIndex = 106
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(12, 364)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(220, 22)
        Me.cmdApply.StyleController = Me.dlgEditAttributesConvertedLayout
        Me.cmdApply.TabIndex = 105
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.ToolTip = "Applies the attribute changes"
        '
        'vgEditAttributes
        '
        Me.vgEditAttributes.Location = New System.Drawing.Point(12, 102)
        Me.vgEditAttributes.Name = "vgEditAttributes"
        Me.vgEditAttributes.OptionsView.ShowButtons = False
        Me.vgEditAttributes.Size = New System.Drawing.Size(220, 258)
        Me.vgEditAttributes.TabIndex = 104
        '
        'pnlCmdButtons
        '
        Me.pnlCmdButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlCmdButtons.Controls.Add(Me.cmdRemove)
        Me.pnlCmdButtons.Controls.Add(Me.cmdAdd)
        Me.pnlCmdButtons.Location = New System.Drawing.Point(12, 74)
        Me.pnlCmdButtons.Name = "pnlCmdButtons"
        Me.pnlCmdButtons.Size = New System.Drawing.Size(220, 24)
        Me.pnlCmdButtons.TabIndex = 4
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(120, 0)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 1
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.ToolTip = "Remove the currently selected attribute form the selection or entity."
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.ToolTip = "Clcik this button in order to create a NEW attibute for the selection or selected" &
    " entity."
        '
        'pnlEntity
        '
        Me.pnlEntity.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlEntity.Controls.Add(Me.teEntity)
        Me.pnlEntity.Controls.Add(Me.lcEntity)
        Me.pnlEntity.Location = New System.Drawing.Point(12, 44)
        Me.pnlEntity.Name = "pnlEntity"
        Me.pnlEntity.Size = New System.Drawing.Size(220, 26)
        Me.pnlEntity.TabIndex = 3
        '
        'teEntity
        '
        Me.teEntity.Enabled = False
        Me.teEntity.Location = New System.Drawing.Point(63, 3)
        Me.teEntity.Name = "teEntity"
        Me.teEntity.Size = New System.Drawing.Size(100, 20)
        Me.teEntity.TabIndex = 1
        Me.teEntity.ToolTip = "Specifies which entity attributes you wish to modify."
        '
        'lcEntity
        '
        Me.lcEntity.Location = New System.Drawing.Point(22, 6)
        Me.lcEntity.Name = "lcEntity"
        Me.lcEntity.Size = New System.Drawing.Size(35, 13)
        Me.lcEntity.TabIndex = 0
        Me.lcEntity.Text = "Entity: "
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(244, 398)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdApply
        Me.LayoutControlItem1.CustomizationFormText = "cmdApplyitem"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 352)
        Me.LayoutControlItem1.Name = "cmdApplyitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(224, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.vgEditAttributes
        Me.LayoutControlItem2.CustomizationFormText = "vgProcessParametersitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 90)
        Me.LayoutControlItem2.Name = "vgProcessParametersitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(224, 262)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.pnlCmdButtons
        Me.LayoutControlItem3.CustomizationFormText = "pnlCmdButtonsitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 62)
        Me.LayoutControlItem3.Name = "pnlCmdButtonsitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(224, 28)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.pnlEntity
        Me.LayoutControlItem4.CustomizationFormText = "pnlEntityitem"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem4.Name = "pnlEntityitem"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(224, 30)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        Me.LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.rgOptByGroup
        Me.LayoutControlItem5.CustomizationFormText = "RadioGroup1item"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "RadioGroup1item"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(224, 32)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'dlgEditAttributes
        '
        Me.AcceptButton = Me.cmdApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 398)
        Me.Controls.Add(Me.dlgEditAttributesConvertedLayout)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgEditAttributes"
        Me.Text = "Edit Attributes"
        CType(Me.rgOptByGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dlgEditAttributesConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dlgEditAttributesConvertedLayout.ResumeLayout(False)
        CType(Me.vgEditAttributes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCmdButtons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCmdButtons.ResumeLayout(False)
        CType(Me.pnlEntity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntity.ResumeLayout(False)
        Me.pnlEntity.PerformLayout()
        CType(Me.teEntity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rgOptByGroup As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents pnlEntity As DevExpress.XtraEditors.PanelControl
    Friend WithEvents teEntity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcEntity As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlCmdButtons As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents vgEditAttributes As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents dlgEditAttributesConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
