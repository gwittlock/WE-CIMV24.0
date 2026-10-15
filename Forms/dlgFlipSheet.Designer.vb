<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFlipSheet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgFlipSheet))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.popupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.popupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.lbOptions = New DevExpress.XtraEditors.ListBoxControl()
        Me.cboDefn = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.vgProplist = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl1.SuspendLayout()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDefn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgProplist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(673, 174)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(103, 173)
        Me.ListBox1.TabIndex = 62
        Me.ListBox1.Visible = False
        '
        'popupContainerEdit1
        '
        Me.popupContainerEdit1.Location = New System.Drawing.Point(368, 8)
        Me.popupContainerEdit1.Name = "popupContainerEdit1"
        Me.popupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.popupContainerEdit1.Properties.ShowPopupCloseButton = False
        Me.popupContainerEdit1.Properties.ShowPopupShadow = False
        Me.popupContainerEdit1.Properties.SuppressMouseEventOnOuterMouseClick = True
        Me.popupContainerEdit1.Size = New System.Drawing.Size(228, 20)
        Me.popupContainerEdit1.TabIndex = 61
        Me.popupContainerEdit1.Visible = False
        '
        'popupContainerControl1
        '
        Me.popupContainerControl1.Controls.Add(Me.tl)
        Me.popupContainerControl1.Location = New System.Drawing.Point(403, 34)
        Me.popupContainerControl1.Name = "popupContainerControl1"
        Me.popupContainerControl1.Size = New System.Drawing.Size(234, 302)
        Me.popupContainerControl1.TabIndex = 63
        '
        'tl
        '
        Me.tl.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.MainRoot})
        Me.tl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tl.Location = New System.Drawing.Point(0, 0)
        Me.tl.Name = "tl"
        Me.tl.OptionsBehavior.AutoChangeParent = False
        Me.tl.OptionsBehavior.AutoNodeHeight = False
        Me.tl.OptionsBehavior.AutoSelectAllInEditor = False
        Me.tl.OptionsBehavior.CloseEditorOnLostFocus = False
        Me.tl.OptionsBehavior.Editable = False
        Me.tl.OptionsBehavior.ResizeNodes = False
        Me.tl.OptionsBehavior.SmartMouseHover = False
        Me.tl.OptionsMenu.EnableFooterMenu = False
        Me.tl.OptionsPrint.PrintHorzLines = False
        Me.tl.OptionsPrint.PrintVertLines = False
        Me.tl.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tl.OptionsSelection.KeepSelectedOnClick = False
        Me.tl.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None
        Me.tl.OptionsView.ShowHorzLines = False
        Me.tl.OptionsView.ShowIndicator = False
        Me.tl.OptionsView.ShowVertLines = False
        Me.tl.Size = New System.Drawing.Size(234, 302)
        Me.tl.TabIndex = 7
        Me.tl.Visible = False
        '
        'MainRoot
        '
        Me.MainRoot.AllNodesSummary = True
        Me.MainRoot.Caption = "Materials"
        Me.MainRoot.FieldName = "Key"
        Me.MainRoot.MinWidth = 33
        Me.MainRoot.Name = "MainRoot"
        Me.MainRoot.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count
        Me.MainRoot.SummaryFooterStrFormat = "Count keys = {0}"
        Me.MainRoot.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.MainRoot.Width = 235
        '
        'lbOptions
        '
        Me.lbOptions.Appearance.BackColor = System.Drawing.Color.White
        Me.lbOptions.Appearance.Options.UseBackColor = True
        Me.lbOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbOptions.Location = New System.Drawing.Point(673, 118)
        Me.lbOptions.Name = "lbOptions"
        Me.lbOptions.Size = New System.Drawing.Size(166, 32)
        Me.lbOptions.TabIndex = 73
        Me.lbOptions.Visible = False
        '
        'cboDefn
        '
        Me.cboDefn.EnterMoveNextControl = True
        Me.cboDefn.Location = New System.Drawing.Point(71, 8)
        Me.cboDefn.Name = "cboDefn"
        Me.cboDefn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDefn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboDefn.Size = New System.Drawing.Size(251, 20)
        Me.cboDefn.TabIndex = 76
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(23, 472)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(299, 22)
        Me.btnAccept.TabIndex = 75
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.ToolTip = "Applies the values for the current operation."
        '
        'vgProplist
        '
        Me.vgProplist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgProplist.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgProplist.Location = New System.Drawing.Point(23, 34)
        Me.vgProplist.Name = "vgProplist"
        Me.vgProplist.OptionsBehavior.UseEnterAsTab = True
        Me.vgProplist.OptionsView.ShowButtons = False
        Me.vgProplist.RecordWidth = 92
        Me.vgProplist.RowHeaderWidth = 108
        Me.vgProplist.Size = New System.Drawing.Size(299, 432)
        Me.vgProplist.TabIndex = 74
        Me.vgProplist.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(23, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 77
        Me.LabelControl1.Text = "Definition"
        '
        'dlgFlipSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1067, 506)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cboDefn)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.vgProplist)
        Me.Controls.Add(Me.lbOptions)
        Me.Controls.Add(Me.popupContainerControl1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.popupContainerEdit1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgFlipSheet"
        Me.Text = "CNC Flip Sheet"
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl1.ResumeLayout(False)
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDefn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgProplist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As ListBox
    Private WithEvents popupContainerEdit1 As PopupContainerEdit
    Private WithEvents popupContainerControl1 As PopupContainerControl
    Private WithEvents tl As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents lbOptions As ListBoxControl
    Friend WithEvents cboDefn As ComboBoxEdit
    Friend WithEvents btnAccept As SimpleButton
    Friend WithEvents vgProplist As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents LabelControl1 As LabelControl
End Class
