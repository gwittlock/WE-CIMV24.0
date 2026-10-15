<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgProfileBlend
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
        Me.dlgEntityConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.cboDefn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.vgProplist = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.popupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        CType(Me.dlgEntityConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dlgEntityConvertedLayout.SuspendLayout()
        CType(Me.cboDefn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgProplist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dlgEntityConvertedLayout
        '
        Me.dlgEntityConvertedLayout.Controls.Add(Me.cboDefn)
        Me.dlgEntityConvertedLayout.Controls.Add(Me.btnAccept)
        Me.dlgEntityConvertedLayout.Controls.Add(Me.vgProplist)
        Me.dlgEntityConvertedLayout.Location = New System.Drawing.Point(10, 0)
        Me.dlgEntityConvertedLayout.Name = "dlgEntityConvertedLayout"
        Me.dlgEntityConvertedLayout.Root = Me.LayoutControlGroup1
        Me.dlgEntityConvertedLayout.Size = New System.Drawing.Size(223, 345)
        Me.dlgEntityConvertedLayout.TabIndex = 13
        '
        'cboDefn
        '
        Me.cboDefn.EnterMoveNextControl = True
        Me.cboDefn.Location = New System.Drawing.Point(60, 12)
        Me.cboDefn.Name = "cboDefn"
        Me.cboDefn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDefn.Properties.Items.AddRange(New Object() {"Profile Blend"})
        Me.cboDefn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboDefn.Size = New System.Drawing.Size(151, 20)
        Me.cboDefn.StyleController = Me.dlgEntityConvertedLayout
        Me.cboDefn.TabIndex = 8
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(12, 311)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(199, 22)
        Me.btnAccept.StyleController = Me.dlgEntityConvertedLayout
        Me.btnAccept.TabIndex = 3
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.ToolTip = "Applies the values for the current operation."
        '
        'vgProplist
        '
        Me.vgProplist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgProplist.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgProplist.Location = New System.Drawing.Point(12, 36)
        Me.vgProplist.Name = "vgProplist"
        Me.vgProplist.OptionsView.ShowButtons = False
        Me.vgProplist.RecordWidth = 92
        Me.vgProplist.RowHeaderWidth = 108
        Me.vgProplist.Size = New System.Drawing.Size(199, 271)
        Me.vgProplist.TabIndex = 2
        Me.vgProplist.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(223, 345)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "GroupControl1item"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(203, 325)
        Me.LayoutControlGroup2.Text = "LayoutControlGroup1"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboDefn
        Me.LayoutControlItem1.CustomizationFormText = "Definition"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "cboDefnitem"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(203, 24)
        Me.LayoutControlItem1.Text = "Definition"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnAccept
        Me.LayoutControlItem2.CustomizationFormText = "btnAcceptitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 299)
        Me.LayoutControlItem2.Name = "btnAcceptitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(203, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.vgProplist
        Me.LayoutControlItem3.CustomizationFormText = "vgProplistitem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "vgProplistitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(203, 275)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(1, 176)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(103, 173)
        Me.ListBox1.TabIndex = 61
        Me.ListBox1.Visible = False
        '
        'popupContainerEdit1
        '
        Me.popupContainerEdit1.Location = New System.Drawing.Point(293, 142)
        Me.popupContainerEdit1.Name = "popupContainerEdit1"
        Me.popupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.popupContainerEdit1.Properties.ShowPopupCloseButton = False
        Me.popupContainerEdit1.Properties.ShowPopupShadow = False
        Me.popupContainerEdit1.Properties.SuppressMouseEventOnOuterMouseClick = True
        Me.popupContainerEdit1.Size = New System.Drawing.Size(228, 20)
        Me.popupContainerEdit1.TabIndex = 60
        '
        'tl
        '
        Me.tl.Location = New System.Drawing.Point(238, 32)
        Me.tl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tl.MinWidth = 17
        Me.tl.Name = "tl"
        Me.tl.Size = New System.Drawing.Size(343, 162)
        Me.tl.TabIndex = 62
        Me.tl.TreeLevelWidth = 15
        '
        'dlgProfileBlend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 349)
        Me.Controls.Add(Me.tl)
        Me.Controls.Add(Me.popupContainerEdit1)
        Me.Controls.Add(Me.dlgEntityConvertedLayout)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "dlgProfileBlend"
        Me.Text = "Profile Blend"
        CType(Me.dlgEntityConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dlgEntityConvertedLayout.ResumeLayout(False)
        CType(Me.cboDefn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgProplist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dlgEntityConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents cboDefn As ComboBoxEdit
    Friend WithEvents btnAccept As SimpleButton
    Friend WithEvents vgProplist As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ListBox1 As ListBox
    Private WithEvents popupContainerEdit1 As PopupContainerEdit
    Friend WithEvents tl As DevExpress.XtraTreeList.TreeList
End Class
