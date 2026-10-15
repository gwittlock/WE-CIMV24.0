<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkZones
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
        Me.grdWorkZones = New DevExpress.XtraGrid.GridControl()
        Me.grdWorkZonesView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SpinEdit1 = New DevExpress.XtraEditors.SpinEdit()
        Me.frmWorkZonesConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdHold = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAssign = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        CType(Me.grdWorkZones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdWorkZonesView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmWorkZonesConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmWorkZonesConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdWorkZones
        '
        Me.grdWorkZones.AllowDrop = True
        Me.grdWorkZones.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdWorkZones.Location = New System.Drawing.Point(12, 12)
        Me.grdWorkZones.MainView = Me.grdWorkZonesView
        Me.grdWorkZones.Name = "grdWorkZones"
        Me.grdWorkZones.Size = New System.Drawing.Size(434, 417)
        Me.grdWorkZones.TabIndex = 11
        Me.grdWorkZones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdWorkZonesView})
        '
        'grdWorkZonesView
        '
        Me.grdWorkZonesView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.grdWorkZonesView.GridControl = Me.grdWorkZones
        Me.grdWorkZonesView.IndicatorWidth = 60
        Me.grdWorkZonesView.Name = "grdWorkZonesView"
        Me.grdWorkZonesView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdWorkZonesView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdWorkZonesView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdWorkZonesView.OptionsCustomization.AllowColumnMoving = False
        Me.grdWorkZonesView.OptionsCustomization.AllowFilter = False
        Me.grdWorkZonesView.OptionsCustomization.AllowGroup = False
        Me.grdWorkZonesView.OptionsCustomization.AllowQuickHideColumns = False
        Me.grdWorkZonesView.OptionsCustomization.AllowSort = False
        Me.grdWorkZonesView.OptionsMenu.EnableColumnMenu = False
        Me.grdWorkZonesView.OptionsMenu.EnableFooterMenu = False
        Me.grdWorkZonesView.OptionsMenu.EnableGroupPanelMenu = False
        Me.grdWorkZonesView.OptionsNavigation.EnterMoveNextColumn = True
        Me.grdWorkZonesView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.grdWorkZonesView.OptionsSelection.UseIndicatorForSelection = False
        Me.grdWorkZonesView.OptionsView.AllowHtmlDrawGroups = False
        Me.grdWorkZonesView.OptionsView.ColumnAutoWidth = False
        Me.grdWorkZonesView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.grdWorkZonesView.OptionsView.ShowDetailButtons = False
        Me.grdWorkZonesView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdWorkZonesView.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.grdWorkZonesView.OptionsView.ShowGroupPanel = False
        Me.grdWorkZonesView.OptionsView.ShowViewCaption = True
        Me.grdWorkZonesView.ViewCaption = "WorkZones Information"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.SpinEdit1)
        Me.PanelControl1.Location = New System.Drawing.Point(222, 433)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(119, 48)
        Me.PanelControl1.TabIndex = 18
        '
        'SpinEdit1
        '
        Me.SpinEdit1.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SpinEdit1.Location = New System.Drawing.Point(3, 0)
        Me.SpinEdit1.Name = "SpinEdit1"
        Me.SpinEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 25.0!)
        Me.SpinEdit1.Properties.Appearance.Options.UseFont = True
        Me.SpinEdit1.Properties.AutoHeight = False
        Me.SpinEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SpinEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.SpinEdit1.Size = New System.Drawing.Size(53, 48)
        Me.SpinEdit1.StyleController = Me.frmWorkZonesConvertedLayout
        Me.SpinEdit1.TabIndex = 21
        '
        'frmWorkZonesConvertedLayout
        '
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.PanelControl1)
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.cmdCancel)
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.cmdHold)
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.cmdRemove)
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.cmdAssign)
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.cmdAdd)
        Me.frmWorkZonesConvertedLayout.Controls.Add(Me.grdWorkZones)
        Me.frmWorkZonesConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmWorkZonesConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmWorkZonesConvertedLayout.Name = "frmWorkZonesConvertedLayout"
        Me.frmWorkZonesConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmWorkZonesConvertedLayout.Size = New System.Drawing.Size(458, 493)
        Me.frmWorkZonesConvertedLayout.TabIndex = 19
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(345, 433)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(101, 22)
        Me.cmdCancel.StyleController = Me.frmWorkZonesConvertedLayout
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdHold
        '
        Me.cmdHold.Location = New System.Drawing.Point(117, 459)
        Me.cmdHold.Name = "cmdHold"
        Me.cmdHold.Size = New System.Drawing.Size(101, 22)
        Me.cmdHold.StyleController = Me.frmWorkZonesConvertedLayout
        Me.cmdHold.TabIndex = 16
        Me.cmdHold.Text = "Drag"
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(12, 459)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(101, 22)
        Me.cmdRemove.StyleController = Me.frmWorkZonesConvertedLayout
        Me.cmdRemove.TabIndex = 15
        Me.cmdRemove.Text = "Remove"
        '
        'cmdAssign
        '
        Me.cmdAssign.Location = New System.Drawing.Point(117, 433)
        Me.cmdAssign.Name = "cmdAssign"
        Me.cmdAssign.Size = New System.Drawing.Size(101, 22)
        Me.cmdAssign.StyleController = Me.frmWorkZonesConvertedLayout
        Me.cmdAssign.TabIndex = 14
        Me.cmdAssign.Text = "Assign"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(12, 433)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(101, 22)
        Me.cmdAdd.StyleController = Me.frmWorkZonesConvertedLayout
        Me.cmdAdd.TabIndex = 13
        Me.cmdAdd.Text = "Add"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(458, 493)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl1
        Me.LayoutControlItem1.CustomizationFormText = "PanelControl1item"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(210, 421)
        Me.LayoutControlItem1.Name = "PanelControl1item"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(123, 52)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdCancel
        Me.LayoutControlItem2.CustomizationFormText = "cmdCancelitem"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(333, 421)
        Me.LayoutControlItem2.Name = "cmdCancelitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(105, 52)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdHold
        Me.LayoutControlItem3.CustomizationFormText = "cmdHolditem"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(105, 447)
        Me.LayoutControlItem3.Name = "cmdHolditem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(105, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdRemove
        Me.LayoutControlItem4.CustomizationFormText = "cmdRemoveitem"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 447)
        Me.LayoutControlItem4.Name = "cmdRemoveitem"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(105, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdAssign
        Me.LayoutControlItem5.CustomizationFormText = "cmdAssignitem"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(105, 421)
        Me.LayoutControlItem5.Name = "cmdAssignitem"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(105, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdAdd
        Me.LayoutControlItem6.CustomizationFormText = "cmdAdditem"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 421)
        Me.LayoutControlItem6.Name = "cmdAdditem"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(105, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.grdWorkZones
        Me.LayoutControlItem7.CustomizationFormText = "grdWorkZonesitem"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "grdWorkZonesitem"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(438, 421)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'frmWorkZones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 493)
        Me.Controls.Add(Me.frmWorkZonesConvertedLayout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmWorkZones"
        Me.Text = "Manage WorkZones "
        CType(Me.grdWorkZones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdWorkZonesView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmWorkZonesConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmWorkZonesConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grdWorkZones As DevExpress.XtraGrid.GridControl
    Private WithEvents grdWorkZonesView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdHold As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAssign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents frmWorkZonesConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents SpinEdit1 As DevExpress.XtraEditors.SpinEdit
End Class
