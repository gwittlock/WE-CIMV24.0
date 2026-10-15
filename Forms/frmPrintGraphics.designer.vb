<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrintGraphics
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintGraphics))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.beTemplate = New DevExpress.XtraEditors.ButtonEdit()
        Me.sbNew = New DevExpress.XtraEditors.SimpleButton()
        Me.sbEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.DropDownBtnPrint = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiPrinter = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPreview = New DevExpress.XtraBars.BarButtonItem()
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
        Me.dlgPrintOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgPrintSave = New System.Windows.Forms.SaveFileDialog()
        Me.cePrintAllTools = New DevExpress.XtraEditors.CheckEdit()
        Me.cePrintTools = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.beTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cePrintAllTools.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cePrintTools.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Template:"
        '
        'beTemplate
        '
        Me.beTemplate.Location = New System.Drawing.Point(66, 10)
        Me.beTemplate.Name = "beTemplate"
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.beTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.beTemplate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.beTemplate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.beTemplate.Size = New System.Drawing.Size(448, 20)
        Me.beTemplate.TabIndex = 1
        '
        'sbNew
        '
        Me.sbNew.Location = New System.Drawing.Point(65, 37)
        Me.sbNew.Name = "sbNew"
        Me.sbNew.Size = New System.Drawing.Size(75, 23)
        Me.sbNew.TabIndex = 4
        Me.sbNew.Text = "New"
        '
        'sbEdit
        '
        Me.sbEdit.Location = New System.Drawing.Point(146, 37)
        Me.sbEdit.Name = "sbEdit"
        Me.sbEdit.Size = New System.Drawing.Size(75, 23)
        Me.sbEdit.TabIndex = 5
        Me.sbEdit.Text = "Edit"
        '
        'sbCancel
        '
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Location = New System.Drawing.Point(439, 72)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 7
        Me.sbCancel.Text = "Cancel"
        '
        'DropDownBtnPrint
        '
        Me.DropDownBtnPrint.DropDownControl = Me.PopupMenu1
        Me.DropDownBtnPrint.Location = New System.Drawing.Point(376, 37)
        Me.DropDownBtnPrint.MenuManager = Me.BarManager1
        Me.DropDownBtnPrint.Name = "DropDownBtnPrint"
        Me.DropDownBtnPrint.Size = New System.Drawing.Size(135, 23)
        Me.DropDownBtnPrint.TabIndex = 9
        Me.DropDownBtnPrint.Text = "Send To:"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPrinter), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPreview), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiHTML), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPDF), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiRTF), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiTEXT), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiXLS), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiXLSX), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiCSV), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiIMAGE)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'bbiPrinter
        '
        Me.bbiPrinter.Caption = "Printer"
        Me.bbiPrinter.Id = 11
        Me.bbiPrinter.ImageOptions.Image = CType(resources.GetObject("bbiPrinter.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiPrinter.ImageOptions.LargeImage = CType(resources.GetObject("bbiPrinter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiPrinter.Name = "bbiPrinter"
        '
        'bbiPreview
        '
        Me.bbiPreview.Caption = "Preview"
        Me.bbiPreview.Id = 12
        Me.bbiPreview.ImageOptions.Image = CType(resources.GetObject("bbiPreview.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiPreview.ImageOptions.LargeImage = CType(resources.GetObject("bbiPreview.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiPreview.Name = "bbiPreview"
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
        Me.BarManager1.MaxItemId = 22
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(543, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 119)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(543, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 119)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(543, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 119)
        '
        'dlgPrintOpen
        '
        Me.dlgPrintOpen.FileName = "OpenFileDialog1"
        '
        'cePrintAllTools
        '
        Me.cePrintAllTools.Location = New System.Drawing.Point(257, 68)
        Me.cePrintAllTools.Name = "cePrintAllTools"
        Me.cePrintAllTools.Properties.Caption = "Print All Tools"
        Me.cePrintAllTools.Size = New System.Drawing.Size(100, 19)
        Me.cePrintAllTools.TabIndex = 20
        '
        'cePrintTools
        '
        Me.cePrintTools.EditValue = True
        Me.cePrintTools.Location = New System.Drawing.Point(257, 39)
        Me.cePrintTools.Name = "cePrintTools"
        Me.cePrintTools.Properties.Caption = "Print Tools"
        Me.cePrintTools.Size = New System.Drawing.Size(75, 19)
        Me.cePrintTools.TabIndex = 19
        '
        'frmPrintGraphics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.sbCancel
        Me.ClientSize = New System.Drawing.Size(543, 119)
        Me.Controls.Add(Me.cePrintAllTools)
        Me.Controls.Add(Me.cePrintTools)
        Me.Controls.Add(Me.DropDownBtnPrint)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.sbEdit)
        Me.Controls.Add(Me.sbNew)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.beTemplate)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPrintGraphics"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Graphics Report"
        CType(Me.beTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cePrintAllTools.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cePrintTools.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents beTemplate As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents sbNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DropDownBtnPrint As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
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
    Friend WithEvents bbiTEXT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiXLS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiXLSX As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCSV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiIMAGE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents dlgPrintOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgPrintSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cePrintAllTools As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cePrintTools As DevExpress.XtraEditors.CheckEdit
End Class
