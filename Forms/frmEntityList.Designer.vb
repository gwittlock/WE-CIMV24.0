<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEntityList
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntityList))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.bbAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bcInfo = New DevExpress.XtraBars.BarCheckItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.LayoutConverter1 = New DevExpress.XtraLayout.Converter.LayoutConverter(Me.components)
        Me.cbeEntityList = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tvwEntityList = New DevExpress.XtraTreeList.TreeList()
        Me.MainRoot = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.currID = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ParentID = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.myObjNodeIndex = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.currColor = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.toolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeEntityList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvwEntityList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbAdd, Me.bbRemove, Me.BarButtonItem3, Me.BarButtonItem1, Me.bcInfo})
        Me.BarManager1.MaxItemId = 7
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.bbRemove), New DevExpress.XtraBars.LinkPersistInfo(Me.bcInfo)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.AllowRename = True
        Me.Bar1.OptionsBar.DisableClose = True
        Me.Bar1.OptionsBar.DisableCustomization = True
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.Text = "Tools"
        '
        'bbAdd
        '
        Me.bbAdd.Caption = "Add item(s) to selection"
        Me.bbAdd.Id = 0
        Me.bbAdd.ImageOptions.Image = CType(resources.GetObject("bbAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.bbAdd.Name = "bbAdd"
        '
        'bbRemove
        '
        Me.bbRemove.Caption = "Remove item(s) from selection"
        Me.bbRemove.Id = 1
        Me.bbRemove.ImageOptions.Image = CType(resources.GetObject("bbRemove.ImageOptions.Image"), System.Drawing.Image)
        Me.bbRemove.Name = "bbRemove"
        '
        'bcInfo
        '
        Me.bcInfo.BindableChecked = True
        Me.bcInfo.Caption = "BarCheckItem1"
        Me.bcInfo.Checked = True
        Me.bcInfo.Id = 6
        Me.bcInfo.ImageOptions.Image = CType(resources.GetObject("bcInfo.ImageOptions.Image"), System.Drawing.Image)
        Me.bcInfo.Name = "bcInfo"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(275, 34)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 407)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(275, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 34)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 373)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(275, 34)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 373)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Toggle on/off the information tooltips"
        Me.BarButtonItem3.Id = 4
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.GroupIndex = 1
        Me.BarButtonItem1.Id = 5
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'cbeEntityList
        '
        Me.cbeEntityList.Location = New System.Drawing.Point(109, 12)
        Me.cbeEntityList.MenuManager = Me.BarManager1
        Me.cbeEntityList.Name = "cbeEntityList"
        Me.cbeEntityList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeEntityList.Size = New System.Drawing.Size(138, 20)
        Me.cbeEntityList.TabIndex = 13
        '
        'tvwEntityList
        '
        Me.tvwEntityList.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.MainRoot, Me.currID, Me.ParentID, Me.myObjNodeIndex, Me.currColor})
        Me.tvwEntityList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwEntityList.Location = New System.Drawing.Point(0, 34)
        Me.tvwEntityList.Name = "tvwEntityList"
        Me.tvwEntityList.OptionsBehavior.AutoChangeParent = False
        Me.tvwEntityList.OptionsBehavior.AutoNodeHeight = False
        Me.tvwEntityList.OptionsBehavior.AutoSelectAllInEditor = False
        Me.tvwEntityList.OptionsBehavior.CloseEditorOnLostFocus = False
        Me.tvwEntityList.OptionsBehavior.Editable = False
        Me.tvwEntityList.OptionsBehavior.ResizeNodes = False
        Me.tvwEntityList.OptionsBehavior.SmartMouseHover = False
        Me.tvwEntityList.OptionsMenu.EnableFooterMenu = False
        Me.tvwEntityList.OptionsPrint.PrintHorzLines = False
        Me.tvwEntityList.OptionsPrint.PrintVertLines = False
        Me.tvwEntityList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tvwEntityList.OptionsSelection.KeepSelectedOnClick = False
        Me.tvwEntityList.OptionsSelection.MultiSelect = True
        Me.tvwEntityList.OptionsView.ShowCheckBoxes = True
        Me.tvwEntityList.OptionsView.ShowHorzLines = False
        Me.tvwEntityList.OptionsView.ShowIndicator = False
        Me.tvwEntityList.OptionsView.ShowVertLines = False
        Me.tvwEntityList.Size = New System.Drawing.Size(275, 373)
        Me.tvwEntityList.TabIndex = 23
        Me.tvwEntityList.ToolTipController = Me.toolTipController1
        '
        'MainRoot
        '
        Me.MainRoot.AllNodesSummary = True
        Me.MainRoot.Caption = "Entity List"
        Me.MainRoot.FieldName = "Key"
        Me.MainRoot.MinWidth = 34
        Me.MainRoot.Name = "MainRoot"
        Me.MainRoot.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count
        Me.MainRoot.SummaryFooterStrFormat = "Count keys = {0}"
        Me.MainRoot.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.MainRoot.Visible = True
        Me.MainRoot.VisibleIndex = 0
        Me.MainRoot.Width = 173
        '
        'currID
        '
        Me.currID.Caption = "currID"
        Me.currID.FieldName = "currID"
        Me.currID.Name = "currID"
        Me.currID.Visible = True
        Me.currID.VisibleIndex = 1
        Me.currID.Width = 20
        '
        'ParentID
        '
        Me.ParentID.Caption = "ParentID"
        Me.ParentID.FieldName = "ParentID"
        Me.ParentID.Name = "ParentID"
        Me.ParentID.Visible = True
        Me.ParentID.VisibleIndex = 2
        Me.ParentID.Width = 20
        '
        'myObjNodeIndex
        '
        Me.myObjNodeIndex.Caption = "myObjNodeIndex"
        Me.myObjNodeIndex.FieldName = "myObjNodeIndex"
        Me.myObjNodeIndex.Name = "myObjNodeIndex"
        Me.myObjNodeIndex.Visible = True
        Me.myObjNodeIndex.VisibleIndex = 3
        Me.myObjNodeIndex.Width = 20
        '
        'currColor
        '
        Me.currColor.Caption = "currColor"
        Me.currColor.FieldName = "currColor"
        Me.currColor.Name = "currColor"
        Me.currColor.Visible = True
        Me.currColor.VisibleIndex = 4
        Me.currColor.Width = 20
        '
        'toolTipController1
        '
        Me.toolTipController1.AutoPopDelay = 2500
        '
        'frmEntityList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 407)
        Me.Controls.Add(Me.tvwEntityList)
        Me.Controls.Add(Me.cbeEntityList)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmEntityList"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeEntityList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvwEntityList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents bbAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cbeEntityList As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutConverter1 As DevExpress.XtraLayout.Converter.LayoutConverter
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bcInfo As DevExpress.XtraBars.BarCheckItem
    Private WithEvents tvwEntityList As DevExpress.XtraTreeList.TreeList
    Private WithEvents MainRoot As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents currID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ParentID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents myObjNodeIndex As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents currColor As DevExpress.XtraTreeList.Columns.TreeListColumn
    Private WithEvents toolTipController1 As DevExpress.Utils.ToolTipController
End Class
