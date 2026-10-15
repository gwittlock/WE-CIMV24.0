Partial Public Class frmPrintMaterial
    Inherits DevExpress.XtraEditors.XtraForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintMaterial))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.DropDownButton1 = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPrinter = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiHTML = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPDF = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiRTF = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiTEXT = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiXLS = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiXLSX = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCSV = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiIMAGE = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.sbEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.sbNew = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.dlgPrintSave = New System.Windows.Forms.SaveFileDialog()
        Me.beTemplate = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DropDownButton1
        '
        Me.DropDownButton1.DropDownControl = Me.PopupMenu1
        Me.DropDownButton1.Location = New System.Drawing.Point(380, 39)
        Me.DropDownButton1.MenuManager = Me.BarManager1
        Me.DropDownButton1.Name = "DropDownButton1"
        Me.BarManager1.SetPopupContextMenu(Me.DropDownButton1, Me.PopupMenu1)
        Me.DropDownButton1.Size = New System.Drawing.Size(135, 23)
        Me.DropDownButton1.TabIndex = 49
        Me.DropDownButton1.Text = "Send To:"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPreview), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPrinter), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiHTML), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPDF), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiRTF), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiTEXT), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiXLS), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiXLSX), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiCSV), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiIMAGE)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'bbiPreview
        '
        Me.bbiPreview.Caption = "Preview"
        Me.bbiPreview.Id = 12
        Me.bbiPreview.ImageOptions.Image = CType(resources.GetObject("bbiPreview.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiPreview.ImageOptions.LargeImage = CType(resources.GetObject("bbiPreview.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiPreview.Name = "bbiPreview"
        '
        'bbiPrinter
        '
        Me.bbiPrinter.Caption = "Printer"
        Me.bbiPrinter.Id = 11
        Me.bbiPrinter.ImageOptions.Image = CType(resources.GetObject("bbiPrinter.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiPrinter.ImageOptions.LargeImage = CType(resources.GetObject("bbiPrinter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiPrinter.Name = "bbiPrinter"
        '
        'bbiHTML
        '
        Me.bbiHTML.Caption = "HTML"
        Me.bbiHTML.Id = 14
        Me.bbiHTML.ImageOptions.Image = CType(resources.GetObject("bbiHTML.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiHTML.ImageOptions.LargeImage = CType(resources.GetObject("bbiHTML.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiHTML.Name = "bbiHTML"
        '
        'bbiPDF
        '
        Me.bbiPDF.Caption = "PDF"
        Me.bbiPDF.Id = 15
        Me.bbiPDF.ImageOptions.Image = CType(resources.GetObject("bbiPDF.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiPDF.ImageOptions.LargeImage = CType(resources.GetObject("bbiPDF.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiPDF.Name = "bbiPDF"
        '
        'bbiRTF
        '
        Me.bbiRTF.Caption = "RTF"
        Me.bbiRTF.Id = 16
        Me.bbiRTF.ImageOptions.Image = CType(resources.GetObject("bbiRTF.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiRTF.ImageOptions.LargeImage = CType(resources.GetObject("bbiRTF.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiRTF.Name = "bbiRTF"
        '
        'bbiTEXT
        '
        Me.bbiTEXT.Caption = "TEXT"
        Me.bbiTEXT.Id = 21
        Me.bbiTEXT.ImageOptions.Image = CType(resources.GetObject("bbiTEXT.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiTEXT.ImageOptions.LargeImage = CType(resources.GetObject("bbiTEXT.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiTEXT.Name = "bbiTEXT"
        '
        'bbiXLS
        '
        Me.bbiXLS.Caption = "XLS"
        Me.bbiXLS.Id = 17
        Me.bbiXLS.ImageOptions.Image = CType(resources.GetObject("bbiXLS.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiXLS.ImageOptions.LargeImage = CType(resources.GetObject("bbiXLS.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiXLS.Name = "bbiXLS"
        '
        'bbiXLSX
        '
        Me.bbiXLSX.Caption = "XLSX"
        Me.bbiXLSX.Id = 18
        Me.bbiXLSX.ImageOptions.Image = CType(resources.GetObject("bbiXLSX.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiXLSX.ImageOptions.LargeImage = CType(resources.GetObject("bbiXLSX.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiXLSX.Name = "bbiXLSX"
        '
        'bbiCSV
        '
        Me.bbiCSV.Caption = "CSV"
        Me.bbiCSV.Id = 19
        Me.bbiCSV.ImageOptions.Image = CType(resources.GetObject("bbiCSV.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiCSV.ImageOptions.LargeImage = CType(resources.GetObject("bbiCSV.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiCSV.Name = "bbiCSV"
        '
        'bbiIMAGE
        '
        Me.bbiIMAGE.Caption = "Image"
        Me.bbiIMAGE.Id = 20
        Me.bbiIMAGE.ImageOptions.Image = CType(resources.GetObject("bbiIMAGE.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiIMAGE.ImageOptions.LargeImage = CType(resources.GetObject("bbiIMAGE.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiIMAGE.Name = "bbiIMAGE"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPrinter, Me.bbiPreview, Me.bbiHTML, Me.bbiPDF, Me.bbiRTF, Me.bbiXLS, Me.bbiXLSX, Me.bbiCSV, Me.bbiIMAGE, Me.bbiTEXT})
        Me.BarManager1.MaxItemId = 25
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(536, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 113)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(536, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 113)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(536, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 113)
        '
        'sbCancel
        '
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Location = New System.Drawing.Point(449, 81)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 42
        Me.sbCancel.Text = "Finish"
        '
        'sbEdit
        '
        Me.sbEdit.Location = New System.Drawing.Point(156, 39)
        Me.sbEdit.Name = "sbEdit"
        Me.sbEdit.Size = New System.Drawing.Size(75, 23)
        Me.sbEdit.TabIndex = 41
        Me.sbEdit.Text = "Edit"
        '
        'sbNew
        '
        Me.sbNew.Location = New System.Drawing.Point(75, 39)
        Me.sbNew.Name = "sbNew"
        Me.sbNew.Size = New System.Drawing.Size(75, 23)
        Me.sbNew.TabIndex = 40
        Me.sbNew.Text = "New"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(36, 81)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(195, 23)
        Me.SimpleButton1.TabIndex = 43
        Me.SimpleButton1.Text = "Print Test Report"
        Me.SimpleButton1.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 38
        Me.LabelControl1.Text = "Template:"
        '
        'dlgPrintSave
        '
        Me.dlgPrintSave.InitialDirectory = "c:\ProgramFIles (x86)"
        '
        'beTemplate
        '
        Me.beTemplate.Location = New System.Drawing.Point(67, 13)
        Me.beTemplate.Name = "beTemplate"
        Me.beTemplate.Properties.Appearance.Options.UseTextOptions = True
        Me.beTemplate.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        EditorButtonImageOptions1.Image = Global.FabV24_WIN8.My.Resources.Resources.open_16x161
        Me.beTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.beTemplate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.beTemplate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.beTemplate.Size = New System.Drawing.Size(448, 20)
        Me.beTemplate.TabIndex = 54
        '
        'frmPrintMaterial
        '
        Me.ClientSize = New System.Drawing.Size(536, 113)
        Me.Controls.Add(Me.beTemplate)
        Me.Controls.Add(Me.DropDownButton1)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbEdit)
        Me.Controls.Add(Me.sbNew)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintMaterial"
        Me.Text = "Print Material Inventory"
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dlgPrintSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DropDownButton1 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents beTemplate As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPrinter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiHTML As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRTF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiXLS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiXLSX As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCSV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiIMAGE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiTEXT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu

#End Region


End Class
