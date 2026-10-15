<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewProject
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblRequired = New DevExpress.XtraEditors.LabelControl()
        Me.cbeMachine = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblMachine = New DevExpress.XtraEditors.LabelControl()
        Me.lblToolSetup = New DevExpress.XtraEditors.LabelControl()
        Me.cbeToolSetup = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblCutomer = New DevExpress.XtraEditors.LabelControl()
        Me.tebCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.lblOrderPO = New DevExpress.XtraEditors.LabelControl()
        Me.tebOderPO = New DevExpress.XtraEditors.TextEdit()
        Me.lblDueDate = New DevExpress.XtraEditors.LabelControl()
        Me.deDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblMaterial = New DevExpress.XtraEditors.LabelControl()
        Me.lblMateriallength = New DevExpress.XtraEditors.LabelControl()
        Me.tebMaterialLength = New DevExpress.XtraEditors.TextEdit()
        Me.tebMaterialWidth = New DevExpress.XtraEditors.TextEdit()
        Me.lblMaterialWidth = New DevExpress.XtraEditors.LabelControl()
        Me.tebMaterialThickness = New DevExpress.XtraEditors.TextEdit()
        Me.lblMaterialThickness = New DevExpress.XtraEditors.LabelControl()
        Me.cbeMaterial = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.popupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.tl = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.popupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.cbeMaterialType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cbeMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeToolSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebOderPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebMaterialLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebMaterialWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tebMaterialThickness.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl1.SuspendLayout()
        CType(Me.cbeMaterialType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdOK, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(208, 297)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(3, 3)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(67, 23)
        Me.cmdOK.TabIndex = 9
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(76, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(67, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'lblRequired
        '
        Me.lblRequired.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.lblRequired.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblRequired.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lblRequired.Appearance.Options.UseBackColor = True
        Me.lblRequired.Appearance.Options.UseFont = True
        Me.lblRequired.Appearance.Options.UseForeColor = True
        Me.lblRequired.Location = New System.Drawing.Point(53, 272)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(268, 16)
        Me.lblRequired.TabIndex = 26
        Me.lblRequired.Text = "* Fields preceeded by an Asterisk are required"
        '
        'cbeMachine
        '
        Me.cbeMachine.EnterMoveNextControl = True
        Me.cbeMachine.Location = New System.Drawing.Point(123, 12)
        Me.cbeMachine.Name = "cbeMachine"
        Me.cbeMachine.Properties.AutoHeight = False
        Me.cbeMachine.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMachine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeMachine.Size = New System.Drawing.Size(228, 22)
        Me.cbeMachine.TabIndex = 0
        '
        'lblMachine
        '
        Me.lblMachine.Location = New System.Drawing.Point(65, 16)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(52, 13)
        Me.lblMachine.TabIndex = 34
        Me.lblMachine.Text = "* Machine:"
        '
        'lblToolSetup
        '
        Me.lblToolSetup.Location = New System.Drawing.Point(53, 45)
        Me.lblToolSetup.Name = "lblToolSetup"
        Me.lblToolSetup.Size = New System.Drawing.Size(64, 13)
        Me.lblToolSetup.TabIndex = 35
        Me.lblToolSetup.Text = "* Tool Setup:"
        '
        'cbeToolSetup
        '
        Me.cbeToolSetup.EnterMoveNextControl = True
        Me.cbeToolSetup.Location = New System.Drawing.Point(123, 41)
        Me.cbeToolSetup.Name = "cbeToolSetup"
        Me.cbeToolSetup.Properties.AutoHeight = False
        Me.cbeToolSetup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeToolSetup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeToolSetup.Size = New System.Drawing.Size(228, 22)
        Me.cbeToolSetup.TabIndex = 1
        '
        'lblCutomer
        '
        Me.lblCutomer.Location = New System.Drawing.Point(67, 74)
        Me.lblCutomer.Name = "lblCutomer"
        Me.lblCutomer.Size = New System.Drawing.Size(50, 13)
        Me.lblCutomer.TabIndex = 37
        Me.lblCutomer.Text = "Customer:"
        '
        'tebCustomer
        '
        Me.tebCustomer.EnterMoveNextControl = True
        Me.tebCustomer.Location = New System.Drawing.Point(123, 70)
        Me.tebCustomer.Name = "tebCustomer"
        Me.tebCustomer.Properties.AutoHeight = False
        Me.tebCustomer.Size = New System.Drawing.Size(228, 22)
        Me.tebCustomer.TabIndex = 2
        '
        'lblOrderPO
        '
        Me.lblOrderPO.Location = New System.Drawing.Point(40, 103)
        Me.lblOrderPO.Name = "lblOrderPO"
        Me.lblOrderPO.Size = New System.Drawing.Size(77, 13)
        Me.lblOrderPO.TabIndex = 39
        Me.lblOrderPO.Text = "Order or P/O #:"
        '
        'tebOderPO
        '
        Me.tebOderPO.EnterMoveNextControl = True
        Me.tebOderPO.Location = New System.Drawing.Point(123, 99)
        Me.tebOderPO.Name = "tebOderPO"
        Me.tebOderPO.Properties.AutoHeight = False
        Me.tebOderPO.Size = New System.Drawing.Size(228, 22)
        Me.tebOderPO.TabIndex = 3
        '
        'lblDueDate
        '
        Me.lblDueDate.Location = New System.Drawing.Point(68, 132)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(49, 13)
        Me.lblDueDate.TabIndex = 41
        Me.lblDueDate.Text = "Due Date:"
        '
        'deDueDate
        '
        Me.deDueDate.EditValue = Nothing
        Me.deDueDate.EnterMoveNextControl = True
        Me.deDueDate.Location = New System.Drawing.Point(123, 128)
        Me.deDueDate.Name = "deDueDate"
        Me.deDueDate.Properties.AutoHeight = False
        Me.deDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDueDate.Size = New System.Drawing.Size(228, 22)
        Me.deDueDate.TabIndex = 4
        '
        'lblMaterial
        '
        Me.lblMaterial.Location = New System.Drawing.Point(70, 161)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(47, 13)
        Me.lblMaterial.TabIndex = 43
        Me.lblMaterial.Text = "* Material"
        '
        'lblMateriallength
        '
        Me.lblMateriallength.Location = New System.Drawing.Point(30, 190)
        Me.lblMateriallength.Name = "lblMateriallength"
        Me.lblMateriallength.Size = New System.Drawing.Size(87, 13)
        Me.lblMateriallength.TabIndex = 45
        Me.lblMateriallength.Text = "* Material Length:"
        '
        'tebMaterialLength
        '
        Me.tebMaterialLength.EnterMoveNextControl = True
        Me.tebMaterialLength.Location = New System.Drawing.Point(123, 186)
        Me.tebMaterialLength.Name = "tebMaterialLength"
        Me.tebMaterialLength.Properties.AutoHeight = False
        Me.tebMaterialLength.Size = New System.Drawing.Size(228, 22)
        Me.tebMaterialLength.TabIndex = 6
        '
        'tebMaterialWidth
        '
        Me.tebMaterialWidth.EnterMoveNextControl = True
        Me.tebMaterialWidth.Location = New System.Drawing.Point(123, 215)
        Me.tebMaterialWidth.Name = "tebMaterialWidth"
        Me.tebMaterialWidth.Properties.AutoHeight = False
        Me.tebMaterialWidth.Size = New System.Drawing.Size(228, 22)
        Me.tebMaterialWidth.TabIndex = 7
        '
        'lblMaterialWidth
        '
        Me.lblMaterialWidth.Location = New System.Drawing.Point(35, 219)
        Me.lblMaterialWidth.Name = "lblMaterialWidth"
        Me.lblMaterialWidth.Size = New System.Drawing.Size(82, 13)
        Me.lblMaterialWidth.TabIndex = 47
        Me.lblMaterialWidth.Text = "* Material Width:"
        '
        'tebMaterialThickness
        '
        Me.tebMaterialThickness.EnterMoveNextControl = True
        Me.tebMaterialThickness.Location = New System.Drawing.Point(123, 244)
        Me.tebMaterialThickness.Name = "tebMaterialThickness"
        Me.tebMaterialThickness.Properties.AutoHeight = False
        Me.tebMaterialThickness.Size = New System.Drawing.Size(228, 22)
        Me.tebMaterialThickness.TabIndex = 8
        '
        'lblMaterialThickness
        '
        Me.lblMaterialThickness.Location = New System.Drawing.Point(17, 248)
        Me.lblMaterialThickness.Name = "lblMaterialThickness"
        Me.lblMaterialThickness.Size = New System.Drawing.Size(100, 13)
        Me.lblMaterialThickness.TabIndex = 49
        Me.lblMaterialThickness.Text = "* Material Thickness:"
        '
        'cbeMaterial
        '
        Me.cbeMaterial.EnterMoveNextControl = True
        Me.cbeMaterial.Location = New System.Drawing.Point(53, 297)
        Me.cbeMaterial.Name = "cbeMaterial"
        Me.cbeMaterial.Properties.AutoHeight = False
        Me.cbeMaterial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeMaterial.Size = New System.Drawing.Size(228, 22)
        Me.cbeMaterial.TabIndex = 5
        Me.cbeMaterial.Visible = False
        '
        'popupContainerEdit1
        '
        Me.popupContainerEdit1.Location = New System.Drawing.Point(123, 160)
        Me.popupContainerEdit1.Name = "popupContainerEdit1"
        Me.popupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.popupContainerEdit1.Properties.ShowPopupCloseButton = False
        Me.popupContainerEdit1.Properties.ShowPopupShadow = False
        Me.popupContainerEdit1.Properties.SuppressMouseEventOnOuterMouseClick = True
        Me.popupContainerEdit1.Size = New System.Drawing.Size(228, 20)
        Me.popupContainerEdit1.TabIndex = 52
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
        Me.tl.Size = New System.Drawing.Size(299, 241)
        Me.tl.TabIndex = 7
        '
        'MainRoot
        '
        Me.MainRoot.AllNodesSummary = True
        Me.MainRoot.Caption = "Materials"
        Me.MainRoot.FieldName = "Key"
        Me.MainRoot.MinWidth = 33
        Me.MainRoot.Name = "MainRoot"
        Me.MainRoot.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.MainRoot.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.MainRoot.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count
        Me.MainRoot.SummaryFooterStrFormat = "Count keys = {0}"
        Me.MainRoot.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.MainRoot.Visible = True
        Me.MainRoot.VisibleIndex = 0
        Me.MainRoot.Width = 235
        '
        'popupContainerControl1
        '
        Me.popupContainerControl1.Controls.Add(Me.tl)
        Me.popupContainerControl1.Location = New System.Drawing.Point(441, 25)
        Me.popupContainerControl1.Name = "popupContainerControl1"
        Me.popupContainerControl1.Size = New System.Drawing.Size(299, 241)
        Me.popupContainerControl1.TabIndex = 53
        '
        'cbeMaterialType
        '
        Me.cbeMaterialType.EnterMoveNextControl = True
        Me.cbeMaterialType.Location = New System.Drawing.Point(40, 328)
        Me.cbeMaterialType.Name = "cbeMaterialType"
        Me.cbeMaterialType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeMaterialType.Size = New System.Drawing.Size(245, 20)
        Me.cbeMaterialType.TabIndex = 54
        Me.cbeMaterialType.Visible = False
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 338)
        Me.ControlBox = False
        Me.Controls.Add(Me.popupContainerControl1)
        Me.Controls.Add(Me.popupContainerEdit1)
        Me.Controls.Add(Me.tebMaterialThickness)
        Me.Controls.Add(Me.lblMaterialThickness)
        Me.Controls.Add(Me.tebMaterialWidth)
        Me.Controls.Add(Me.lblMaterialWidth)
        Me.Controls.Add(Me.tebMaterialLength)
        Me.Controls.Add(Me.lblMateriallength)
        Me.Controls.Add(Me.lblMaterial)
        Me.Controls.Add(Me.deDueDate)
        Me.Controls.Add(Me.lblDueDate)
        Me.Controls.Add(Me.tebOderPO)
        Me.Controls.Add(Me.lblOrderPO)
        Me.Controls.Add(Me.tebCustomer)
        Me.Controls.Add(Me.lblCutomer)
        Me.Controls.Add(Me.cbeToolSetup)
        Me.Controls.Add(Me.lblToolSetup)
        Me.Controls.Add(Me.lblMachine)
        Me.Controls.Add(Me.cbeMachine)
        Me.Controls.Add(Me.lblRequired)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.cbeMaterial)
        Me.Controls.Add(Me.cbeMaterialType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmNewProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Project"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.cbeMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeToolSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebOderPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebMaterialLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebMaterialWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tebMaterialThickness.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl1.ResumeLayout(False)
        CType(Me.cbeMaterialType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblRequired As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeMachine As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblMachine As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblToolSetup As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeToolSetup As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblCutomer As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tebCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblOrderPO As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tebOderPO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDueDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblMaterial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMateriallength As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tebMaterialLength As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tebMaterialWidth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblMaterialWidth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tebMaterialThickness As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblMaterialThickness As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbeMaterial As ComboBoxEdit
    Private WithEvents popupContainerEdit1 As PopupContainerEdit
    Private WithEvents tl As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents popupContainerControl1 As PopupContainerControl
    Friend WithEvents cbeMaterialType As ComboBoxEdit
End Class
