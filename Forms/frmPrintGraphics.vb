Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Text

Public Class frmPrintGraphics
    Inherits DevExpress.XtraEditors.XtraForm

    'Stores the information for which part is nested on whihc sheet. this can be a 1 to many
    Private m_PartInfo As New System.Collections.Generic.List(Of PartInfo)

    'Stores the information for each part to be nested
    Private m_Tooling As New List(Of PrintToolData)

    Private sSendTo As String

    Dim sTemplate As String
    Public OutputMode As Long

    Private Sub DesignPanelLoaded(sender As Object, e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)

        Try

            Dim src As New BindingSource
            src.DataSource = m_PartInfo

            Dim src1 As New BindingSource
            src1.DataSource = m_Tooling

            CType(sender, XRDesignPanel).Report.DataSource = src1

            e.DesignerHost.Container.Add(src, "Part_Info")
            e.DesignerHost.Container.Add(src1, "Part_Tooling")
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub beTemplate_Click(sender As Object, e As EventArgs) Handles beTemplate.Click
        Dim sInitDir As String

        Try

            Dim sTemplate_FileOpen As New OpenFileDialog

            sInitDir = RegGetString("Printing", "PrintGraphicsTemplate", NormalizePath(App_Path) & "Report Templates")

            sInitDir = GetFilePath(sInitDir)

            If (sInitDir = "") Then

                sInitDir = NormalizePath(App_Path) & "Report Templates"

            End If
            sTemplate_FileOpen.InitialDirectory = sInitDir

            sTemplate_FileOpen.Filter = "Part Report files (*.mrep)|*.mrep"
            sTemplate_FileOpen.FilterIndex = 1
            sTemplate_FileOpen.RestoreDirectory = True



            If sTemplate_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sTemplate = sTemplate_FileOpen.FileName
                beTemplate.Text = sTemplate

                beTemplate.ToolTip = sTemplate

            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub sbEdit_Click(sender As Object, e As EventArgs) Handles sbEdit.Click


        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            'ReportStorageTool.DefaultExtention = ".mrep"
            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.Extension = ".mrep"
            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = App_Path & "\Report Templates"

            'report.DataSource = m_Parts
            report.LoadLayout(beTemplate.Text)

            ' Force the report creation without previously 
            ' requesting the parameter value from end-users.
            report.RequestParameters = False
            GetCG_VArs(report)

            ' Open the report in the End-User Designer. 
            Dim Tool As ReportDesignTool = New ReportDesignTool(report)

            AddHandler Tool.DesignForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignPanelLoaded

            Windows.Forms.Cursor.Current = Cursors.Default

            Tool.ShowDesigner()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Dispose()

    End Sub

    Private Sub frmPrintGraphics_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sReturn = RegPutString("Printing", "PrintGraphicsSendTo", OutputMode)
        sReturn = RegPutString("Printing", "PrintGraphicsTemplate", sTemplate)
        sReturn = RegPutString("Printing", "PrintTools", cePrintTools.Checked)
        sReturn = RegPutString("Printing", "PrintAllTools", cePrintAllTools.Checked)

    End Sub


    Private Sub frmPrintGraphics_Load(sender As Object, e As EventArgs) Handles Me.Load
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        try

            frmMain.pnlNestCombos.Visible = False

            GetPartImage(PathImageFolder() & "printpreview.png")

            OutputMode = CLng(RegGetString("Printing", "PrintGraphicsSendTo", 0))

            Select Case OutputMode

                Case PRINT_MODE.TO_PRINTER

                    sSendTo = "Printer"

                Case PRINT_MODE.TO_PREVIEW

                    sSendTo = "Preview"

                Case PRINT_MODE.TO_HTML

                    sSendTo = "HTML"

                Case PRINT_MODE.TO_PDF

                    sSendTo = "PDF"

                Case PRINT_MODE.TO_RTF

                    sSendTo = "RTF"

                Case PRINT_MODE.TO_XLS

                    sSendTo = "XLS"

                Case PRINT_MODE.TO_XLSX

                    sSendTo = "XLSX"

                Case PRINT_MODE.TO_CSV

                    sSendTo = "CSV"

                Case PRINT_MODE.TO_IMAGE

                    sSendTo = "Image"

                Case PRINT_MODE.TO_TEXT

                    sSendTo = "Text"

            End Select


            sTemplate = RegGetString("Printing", "PrintGraphicsTemplate", "")
            cePrintTools.Checked = CBool(RegGetString("Printing", "PrintTools", 1))
            cePrintAllTools.Checked = CBool(RegGetString("Printing", "PrintAllTools", 0))

            beTemplate.Text = sTemplate

            'sTemplate = RegGetString("Printing", "PrintNestTemplate", "")

            If (FileExists(sTemplate) = False) Then

                MessageBox.Show("Report  Template < " & sTemplate & " > Does Not Exisit. Please Select a Template")
                sTemplate = NormalizePath(App_Path) & "Report Templates\"

            End If


            beTemplate.ToolTip = sTemplate

            Me.DropDownBtnPrint.Text = "Send To: " & sSendTo
            GetPartInfo()
            GetPartTooling()

            '#If Rittal Then

            '            ExecuteBtnClick()

            '#End If

            Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Function GetPartInfo() As System.Collections.Generic.List(Of PartInfo)
        Dim machineDesc As String
        Dim toolSetupDesc As String
        Dim machineID As Long
        Dim sMaterialType As String
        Dim nMaterialTypeID As Long
        Dim sMaterialDescrip As String
        Dim cPartInfo As PartInfo
        Dim lMaterialID As Integer = CInt(HeaderIntGet("MatCatID", 0))
        GetPartInfo = Nothing
        Dim dTemp As Double

        'm_PartInfo = Nothing
        m_PartInfo.Clear()

        Try

            sMaterialDescrip = HeaderStringGet("MatCfg", "")

            nMaterialTypeID = modMaterial.GetMaterialTypeIDFromDescription(sMaterialDescrip)

            sMaterialType = GetMaterialTypeName(nMaterialTypeID)


            toolSetupDesc = HeaderStringGet("MachCfg", "")
            machineID = modTranslate.GetMachineID(toolSetupDesc)
            machineDesc = modTranslate.GetMachineDescription(machineID)

            cPartInfo = New PartInfo


            cPartInfo.PartName = PathCurrent()
            cPartInfo.Clamp_1 = HeaderDoubleGet("Clamp1Pos", 0)
            cPartInfo.Clamp_2 = HeaderDoubleGet("Clamp2Pos", 0)
            cPartInfo.Clamp_3 = HeaderDoubleGet("Clamp3Pos", 0)
            cPartInfo.Clamp_4 = HeaderDoubleGet("Clamp4Pos", 0)
            cPartInfo.Creation_Date = Date.Now

            cPartInfo.Customer = HeaderStringGet("Customer", "")
            cPartInfo.Cycle_Time = HeaderDoubleGet("CycleTime", 0)
            cPartInfo.Due_Date = HeaderStringGet("DueDate", "")
            cPartInfo.Machine = machineDesc
            cPartInfo.Material_Length = HeaderDoubleGet("Length", 0)
            cPartInfo.Material_Thickness = HeaderDoubleGet("Thickness", 0)
            cPartInfo.Material_Type = HeaderStringGet("MatCatName", "")
            cPartInfo.Material_Descrip = sMaterialDescrip
            cPartInfo.Material_Cost = HeaderDoubleGet("MaterialCost", 0)
            cPartInfo.Material_Area = (HeaderDoubleGet("Length", 0) * HeaderDoubleGet("Width", 0))
            cPartInfo.Material_Width = HeaderDoubleGet("Width", 0)
            cPartInfo.NC_Filename = HeaderStringGet("ncfile", "")
            cPartInfo.P_O_Number = HeaderStringGet("PoNum", "")
            cPartInfo.Part_Image = PathImageFolder() & "printpreview.png"
            cPartInfo.PartArea = GetPartArea()
            cPartInfo.PartCost = 100


            m_PartInfo.Add(cPartInfo)


        Catch ex As Exception

        End Try
    End Function

    Private Sub GetPartImage(sImageFilename As String)
        Dim cmd As String
        Dim bounds As Rectangle = frmMain.pnlPicmodeler.Bounds
        Dim pt As Point = frmMain.pnlPicmodeler.PointToScreen(bounds.Location)
        Dim myBitmap As New Bitmap(bounds.Width, bounds.Height)
        Dim lSleepMilliSeconds As Integer = 0

        Try

            'TODO:1-6  frmMain.pnlSheetPatternCombo.Visible = False

            lSleepMilliSeconds = RegGetString("Preferences", "GraphicsDelay", 0)

            frmMain.StatusBar.Visible = False

            cmd = "!view:mode:" & _
                  " id=" & modView.ViewIdGet(VIEW_WIRE) & _
                  ",mono=1, targets=0"

            ''We suppress display of handles by setting targets=0.
            lReturn = PortalExecute(cmd)

            modView.ViewRefresh()

            'LockWindowUpdate(frmMain.pnlPicmodeler.Handle)

            'modLiteCadPrint.CreatePrintDxf(sTempDXF)


            Using m_g As Graphics = Graphics.FromImage(myBitmap)

                m_g.CopyFromScreen(New Point(pt.X - frmMain.pnlPicmodeler.Location.X, pt.Y - frmMain.pnlPicmodeler.Location.Y), Point.Empty, bounds.Size)

                Threading.Thread.Sleep(lSleepMilliSeconds)

                m_g.Dispose()

            End Using

            myBitmap.Save(sImageFilename)

            Threading.Thread.Sleep(lSleepMilliSeconds)

            myBitmap.Dispose()



            cmd = "!view:mode:" & _
                    " id=" & modView.ViewIdGet(VIEW_WIRE) & _
                    ",mono=0, targets=1"

            lReturn = PortalExecute(cmd)

            modView.ViewRefresh()
            'LockWindowUpdate(0&)

            frmMain.StatusBar.Visible = True
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub bbiPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPreview.ItemClick

        PrintPreview()

    End Sub

    Public Sub DoRittalPrinting()

        'PrintPreview()

    End Sub
    Public Sub ExecuteBtnClick()

        Try

            frmMain.pnlNestCombos.Visible = False


            Select Case UCase(DropDownBtnPrint.Text)

                Case "SEND TO: PRINTER"

                    PrintToPrinter()

                Case "SEND TO: PREVIEW"

                    PrintPreview()

                Case "SEND TO: HTML"

                    PrintToHTML()

                Case "SEND TO: PDF"

                    PrintToPDF()

                Case "SEND TO: RTF"

                    PrintToRTF()

                Case "SEND TO: XLS"

                    PrintToXLS()

                Case "SEND TO: XLSX"

                    PrintToXLSX()

                Case "SEND TO: CSV"

                    PrintToCSV()

                Case "SEND TO: IMAGE"

                    PrtintToImage()

                Case "SEND TO: TEXT"

                    PrintToText()


            End Select

            frmMain.pnlNestCombos.Visible = True



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub DropDownBtnPrint_Click(sender As Object, e As EventArgs) Handles DropDownBtnPrint.Click

        Try
            'ExecuteBtnClick()

            frmMain.pnlNestCombos.Visible = False


            Select Case UCase(DropDownBtnPrint.Text)

                Case "SEND TO: PRINTER"

                    PrintToPrinter()

                Case "SEND TO: PREVIEW"

                    PrintPreview()

                Case "SEND TO: HTML"

                    PrintToHTML()

                Case "SEND TO: PDF"

                    PrintToPDF()

                Case "SEND TO: RTF"

                    PrintToRTF()

                Case "SEND TO: XLS"

                    PrintToXLS()

                Case "SEND TO: XLSX"

                    PrintToXLSX()

                Case "SEND TO: CSV"

                    PrintToCSV()

                Case "SEND TO: IMAGE"

                    PrtintToImage()

                Case "SEND TO: TEXT"

                    PrintToText()


            End Select

            frmMain.pnlNestCombos.Visible = True



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub PrintPreview()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling



            ' Create a report instance.
            Dim report As New repPrintGraphics()


            ' Create a report. 
            report.DataSource = src


            report.LoadLayout(beTemplate.Text)

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            detailReportBand.DataSource = src1

            If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                detailReportBand.Visible = True

            Else

                detailReportBand.Visible = False

            End If

            GetCG_VArs(report)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            Tool.PreviewForm.PrintBarManager.AllowQuickCustomization = False
            Tool.PreviewForm.ShowInTaskbar = False

            Tool.ShowPreview()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PREVIEW

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try

    End Sub

    Private Sub PrintToPrinter()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            ' Create a report. 
            report.DataSource = src

            report.LoadLayout(beTemplate.Text)

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            detailReportBand.DataSource = src1

            If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                detailReportBand.Visible = True

            Else

                detailReportBand.Visible = False

            End If

            GetCG_VArs(report)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            'Tool.PreviewForm.PrintBarManager.AllowQuickCustomization = False
            'Tool.PreviewForm.ShowInTaskbar = False

            report.RequestParameters = True

            report.CreateDocument() '<--this will open the parameter values input form

            Tool.PrintDialog()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PRINTER

            Me.Close()


        Catch ex As Exception

            MessageBox.Show("PrintToPrinter: " & ex.Message)

        End Try


    End Sub

    Private Sub bbiPrinter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPrinter.ItemClick

        PrintToPrinter()

    End Sub

    Private Sub PrintToHTML()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "HTML Files (*.html)|*.html"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its HTML export options.
                Dim htmlOptions As HtmlExportOptions = report.ExportOptions.Html

                ' Set HTML-specific export options.
                htmlOptions.CharacterSet = "UTF-8"
                htmlOptions.TableLayout = False
                htmlOptions.RemoveSecondarySymbols = False
                htmlOptions.Title = "WE-CIM Grpahics Report"

                ' Set the pages to be exported, and page-by-page options.
                htmlOptions.ExportMode = HtmlExportMode.SingleFilePageByPage
                htmlOptions.PageBorderColor = Color.Blue
                htmlOptions.PageBorderWidth = 3

                ' Export the report to HTML.
                report.ExportToHtml(reportPath)

                OutputMode = PRINT_MODE.TO_HTML

                Windows.Forms.Cursor.Current = Cursors.Default

                StartProcess(reportPath)

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToHTML: " & ex.Message)

        End Try


    End Sub

    Private Sub bbiHTML_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiHTML.ItemClick
        PrintToHTML()
    End Sub

    Private Sub bbiPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPDF.ItemClick
        PrintToPDF()

    End Sub

    Private Sub PrintToPDF()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "PDF Files (*.pdf)|*.pdf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then
                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)


                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its PDF export options.
                Dim pdfOptions As PdfExportOptions = report.ExportOptions.Pdf

                ' Set PDF-specific export options.
                pdfOptions.Compressed = True
                pdfOptions.ImageQuality = PdfJpegImageQuality.Highest
                pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New"
                pdfOptions.DocumentOptions.Application = "WE-CIM Advanced Fabrication Application"
                pdfOptions.DocumentOptions.Author = "Wittlock Engineering LLC"
                pdfOptions.DocumentOptions.Subject = "WE-CIM Graphics Report"
                pdfOptions.DocumentOptions.Title = "WE-CIM Graphics Report"

                report.RequestParameters = True

                Dim tool As New ReportPrintTool(report)
                report.CreateDocument()

                ' Export the report to PDF.
                report.ExportToPdf(reportPath)

                OutputMode = PRINT_MODE.TO_PDF

                Windows.Forms.Cursor.Current = Cursors.Default

                StartProcess(reportPath)

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToPDF: " & ex.Message)

        End Try
    End Sub

    Private Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub

    Private Sub bbiXLS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiXLS.ItemClick
        PrintToXLS()
    End Sub

    Private Sub PrintToXLS()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "XLS Files (*.xls)|*.xls"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its XLS export options.
                Dim xlsOptions As XlsExportOptions = report.ExportOptions.Xls

                ' Set XLS-specific export options.
                xlsOptions.ShowGridLines = True
                xlsOptions.TextExportMode = TextExportMode.Value

                ' Export the report to XLS.
                report.ExportToXls(reportPath)

                OutputMode = PRINT_MODE.TO_XLS

                Windows.Forms.Cursor.Current = Cursors.Default

                ' Show the result.
                StartProcess(reportPath)

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToXLS: " & ex.Message)

        End Try
    End Sub

    Private Sub bbiXLSX_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiXLSX.ItemClick

        PrintToXLSX()

    End Sub

    Private Sub PrintToXLSX()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)


                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its XLSX export options.
                Dim xlsxOptions As XlsxExportOptions = report.ExportOptions.Xlsx

                ' Set XLSX-specific export options.
                xlsxOptions.ShowGridLines = True
                xlsxOptions.TextExportMode = TextExportMode.Value
                xlsxOptions.ExportHyperlinks = True
                xlsxOptions.SheetName = "WE-CIM Sheet"

                ' Export the report to XLSX.
                report.ExportToXlsx(reportPath)

                OutputMode = PRINT_MODE.TO_XLSX

                Windows.Forms.Cursor.Current = Cursors.Default

                ' Show the result.
                StartProcess(reportPath)

            End If


        Catch ex As Exception

            MessageBox.Show("PrintToXLSX: " & ex.Message)

        End Try
    End Sub

    Private Sub bbiCSV_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCSV.ItemClick

        PrintToCSV()

    End Sub

    Private Sub PrintToCSV()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "CSV Files (*.csv)|*.csv"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its CSV export options.
                Dim csvOptions As CsvExportOptions = report.ExportOptions.Csv

                ' Set CSV-specific export options.
                csvOptions.Encoding = Encoding.Unicode
                csvOptions.Separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString()

                ' Export the report to CSV.
                report.ExportToCsv(reportPath)

                Windows.Forms.Cursor.Current = Cursors.Default

                OutputMode = PRINT_MODE.TO_CSV

                ' Show the result.
                StartProcess(reportPath)

            End If


        Catch ex As Exception

            MessageBox.Show("PrintToCSV: " & ex.Message)

        End Try
    End Sub

    Private Sub bbiIMAGE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiIMAGE.ItemClick

        PrtintToImage()

    End Sub

    Private Sub PrtintToImage()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "BMP Files (*.bmp)|*.bmp|EMF Files (*.emf)|*.emf| WMF FIles (*.wmf)|*.wmf| GIF Files (*.gif)|*.gif| JPEG Files (*.jpeg)|*.jepg| PNG Files (*.png)|*.pmg| TIFF Files (*.tiff)|*.tiff"

            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its Image export options.
                Dim imageOptions As ImageExportOptions = report.ExportOptions.Image

                ' Set Image-specific export options.
                imageOptions.Format = ImageFormat.Png

                ' Export the report to Image.
                report.ExportToImage(reportPath)

                OutputMode = PRINT_MODE.TO_IMAGE

                Windows.Forms.Cursor.Current = Cursors.Default


                ' Show the result.
                StartProcess(reportPath)

            End If


        Catch ex As Exception

            MessageBox.Show("PrtintToImage: " & ex.Message)

        End Try
    End Sub

    Private Sub GetPartTooling()
        Dim lCount As Long

        Try
            m_Tooling.Clear()

            For Each clsToolData In g_colToolSetup
                If (cePrintTools.CheckState = CheckState.Checked) Then
                    lReturn = PortalExecute("Entity:RefCnt: id=" + CStr(clsToolData.Model_ID))
                    lCount = PortalGetInt("count", 0)

                    If (lCount > 0) Then

                        If clsToolData.NC_Code_Number > 0 Then
                            With clsToolData

                                m_Tooling.Add(New PrintToolData() With {.Id = clsToolData.id, _
                                                                    .Description = clsToolData.Description, _
                                                                    .NC_Code_Number = clsToolData.NC_Code_Number, _
                                                                    .Width_Diameter = clsToolData.Width_Diameter, _
                                                                    .Length = clsToolData.Length, _
                                                                    .Loff = clsToolData.Loff, _
                                                                    .Doff = clsToolData.Doff, _
                                                                    .Radius = clsToolData.Radius, _
                                                                    .Angle = clsToolData.Angle, _
                                                                    .Shear = clsToolData.Shear, _
                                                                    .cost = clsToolData.Cost, _
                                                                    .Life = clsToolData.Life, _
                                                                    .Filename = clsToolData.FileName, _
                                                                    .Speed = clsToolData.Speed, _
                                                                    .Feed = clsToolData.Feed, _
                                                                    .Gas = clsToolData.Gas, _
                                                                    .Power = clsToolData.Power, _
                                                                    .Type_Description = clsToolData.Type_Description, _
                                                                    .type_id = clsToolData.Type_ID, _
                                                                    .Frequency = clsToolData.Frequency, _
                                                                    .Focus = clsToolData.Focus, _
                                                                    .Die_Clearance = clsToolData.Die_Clearance, _
                                                                    .Slowdown_Angle = clsToolData.Slowdown_Angle, _
                                                                    .Slowdown_Setback = clsToolData.Slowdown_Setback, _
                                                                    .Slowdown_Divisions = clsToolData.Slowdown_Divisions, _
                                                                    .Slowdown_Formula = clsToolData.Slowdown_Formula, _
                                                                    .Corner_Radius = clsToolData.Corner_Radius, _
                                                                    .Diameter = clsToolData.Diameter, _
                                                                    .Index_Angle = clsToolData.Index_Angle, _
                                                                    .Kerf = clsToolData.Kerf, _
                                                                    .Major_Diameter = clsToolData.Major_Diameter, _
                                                                    .Minor_Diameter = clsToolData.Minor_Diameter, _
                                                                    .Pitch = clsToolData.Pitch, _
                                                                    .Web = clsToolData.Web, _
                                                                    .Auto_Index = clsToolData.Auto_Index, _
                                                                    .Fixed_Station = clsToolData.Fixed_Station, _
                                                                    .Station_Location_X = clsToolData.Station_Location_X, _
                                                                    .Station_Location_Y = clsToolData.Station_Location_Y, _
                                                                    .Station_Size = clsToolData.Station_Size, _
                                                                    .FeedMode = clsToolData.FeedMode, _
                                                                    .Workplane = clsToolData.Workplane, _
                                                                    .show = clsToolData.Show, _
                                                                    .CutSide = clsToolData.CutSide, _
                                                                    .Operation = clsToolData.Operation, _
                                                                    .Model_ID = clsToolData.Model_ID, _
                                                                    .level = clsToolData.Level, _
                                                                    .Distance = clsToolData.Distance, _
                                                                    .CutType = clsToolData.CutType, _
                                                                    .Amperage = clsToolData.Amperage, _
                                                                    .MaxPressure = clsToolData.MaxPressure, _
                                                                    .CutQuality = clsToolData.CutQuality, _
                                                                    .Plunge = clsToolData.Plunge, _
                                                                    .SharpAngle = clsToolData.SharpAngle, _
                                                                    .PrimaryCode = clsToolData.PrimaryCode, _
                                                                    .SecondaryCode = clsToolData.SecondaryCode, _
                                                                    .UseLongSide = clsToolData.UseLongSide})


                            End With

                        End If

                    End If

                ElseIf (cePrintAllTools.CheckState = CheckState.Checked) Then

                    If clsToolData.NC_Code_Number > 0 Then
                        With clsToolData

                            m_Tooling.Add(New PrintToolData() With {.Description = clsToolData.Description, _
                                                                    .NC_Code_Number = clsToolData.NC_Code_Number, _
                                                                    .Width_Diameter = clsToolData.Width_Diameter, _
                                                                    .Length = clsToolData.Length, _
                                                                    .Loff = clsToolData.Loff, _
                                                                    .Doff = clsToolData.Doff, _
                                                                    .Radius = clsToolData.Radius, _
                                                                    .Angle = clsToolData.Angle, _
                                                                    .Shear = clsToolData.Shear, _
                                                                    .cost = clsToolData.Cost, _
                                                                    .Life = clsToolData.Life, _
                                                                    .Filename = clsToolData.FileName, _
                                                                    .Speed = clsToolData.Speed, _
                                                                    .Feed = clsToolData.Feed, _
                                                                    .Gas = clsToolData.Gas, _
                                                                    .Power = clsToolData.Power, _
                                                                    .Type_Description = clsToolData.Type_Description, _
                                                                    .type_id = clsToolData.Type_ID, _
                                                                    .Frequency = clsToolData.Frequency, _
                                                                    .Focus = clsToolData.Focus, _
                                                                    .Die_Clearance = clsToolData.Die_Clearance, _
                                                                    .Slowdown_Angle = clsToolData.Slowdown_Angle, _
                                                                    .Slowdown_Setback = clsToolData.Slowdown_Setback, _
                                                                    .Slowdown_Divisions = clsToolData.Slowdown_Divisions, _
                                                                    .Slowdown_Formula = clsToolData.Slowdown_Formula, _
                                                                    .Corner_Radius = clsToolData.Corner_Radius, _
                                                                    .Diameter = clsToolData.Diameter, _
                                                                    .Index_Angle = clsToolData.Index_Angle, _
                                                                    .Kerf = clsToolData.Kerf, _
                                                                    .Major_Diameter = clsToolData.Major_Diameter, _
                                                                    .Minor_Diameter = clsToolData.Minor_Diameter, _
                                                                    .Pitch = clsToolData.Pitch, _
                                                                    .Web = clsToolData.Web, _
                                                                    .Auto_Index = clsToolData.Auto_Index, _
                                                                    .Fixed_Station = clsToolData.Fixed_Station, _
                                                                    .Station_Location_X = clsToolData.Station_Location_X, _
                                                                    .Station_Location_Y = clsToolData.Station_Location_Y, _
                                                                    .Station_Size = clsToolData.Station_Size, _
                                                                    .FeedMode = clsToolData.FeedMode, _
                                                                    .Workplane = clsToolData.Workplane, _
                                                                    .show = clsToolData.Show, _
                                                                    .CutSide = clsToolData.CutSide, _
                                                                    .Operation = clsToolData.Operation, _
                                                                    .Model_ID = clsToolData.Model_ID, _
                                                                    .level = clsToolData.Level, _
                                                                    .Distance = clsToolData.Distance, _
                                                                    .CutType = clsToolData.CutType, _
                                                                    .Amperage = clsToolData.Amperage, _
                                                                    .MaxPressure = clsToolData.MaxPressure, _
                                                                    .CutQuality = clsToolData.CutQuality, _
                                                                    .Plunge = clsToolData.Plunge, _
                                                                    .SharpAngle = clsToolData.SharpAngle, _
                                                                    .PrimaryCode = clsToolData.PrimaryCode, _
                                                                    .SecondaryCode = clsToolData.SecondaryCode, _
                                                                    .UseLongSide = clsToolData.UseLongSide})


                        End With

                    End If
                End If
            Next

        Catch ex As Exception

            MessageBox.Show("GetPartTooling: " & ex.Message)

        End Try
    End Sub
    Private Sub PrintToRTF()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "RTF Files (*.rtf)|*.rtf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Export the report to RTF.
                report.ExportToRtf(reportPath)

                OutputMode = PRINT_MODE.TO_RTF

                Windows.Forms.Cursor.Current = Cursors.Default

                ' Show the result.
                StartProcess(reportPath)

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToRTF: " & ex.Message)

        End Try
    End Sub

    Private Sub bbiRTF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRTF.ItemClick

        PrintToRTF()

    End Sub

    Private Sub bbiTEXT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiTEXT.ItemClick

        PrintToText()

    End Sub

    Private Sub PrintToText()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try

            src.DataSource = m_PartInfo

            src1.DataSource = m_Tooling

            dlgPrintSave.Filter = "TXT Files (*.txt)|*.txt"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As New repPrintGraphics()

                report.RequestParameters = True

                report.DataSource = src

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = src1

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                ' Get its Text export options.
                Dim txtOptions As TextExportOptions = report.ExportOptions.Text

                ' Set Text-specific export options.
                txtOptions.Encoding = Encoding.Unicode
                txtOptions.Separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString()

                ' Export the report to Text.
                report.ExportToText(reportPath)

                OutputMode = PRINT_MODE.TO_RTF

                Windows.Forms.Cursor.Current = Cursors.Default

                ' Show the result.
                StartProcess(reportPath)

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToText: " & ex.Message)

        End Try

    End Sub

    Private Sub cePrintAllTools_CheckedChanged(sender As Object, e As EventArgs) Handles cePrintAllTools.CheckedChanged

        If (cePrintAllTools.CheckState = CheckState.Checked) Then

            cePrintTools.CheckState = CheckState.Unchecked
            GetPartTooling()
        End If

    End Sub

    Private Sub cePrintTools_CheckedChanged(sender As Object, e As EventArgs) Handles cePrintTools.CheckedChanged
        If (cePrintTools.CheckState = CheckState.Checked) Then

            cePrintAllTools.CheckState = CheckState.Unchecked

            GetPartTooling()


        End If
    End Sub

    Private Sub GetCG_VArs(mReport As repPrintGraphics)
        Dim sVarCaption As String
        Dim sVarValue As String = Nothing
        Dim cgFilename As String
        Dim lReturn As Long
        Dim lCount As Long
        Dim indx As Long
        Dim sData As String
        Dim pieces() As String

        Try
            mReport.Parameters.Clear()

            cgFilename = HeaderStringGet("cgfile", "")

            If (cgFilename <> "") Then

                ' get cg variables from cgfile
                lReturn = PortalExecute("*admin:javavarsextract:file=" & Chr(34) & cgFilename & Chr(34) & _
                    ",class=" & Chr(34) & "cg" & Chr(34))

                lCount = PortalGetInt("count", 0)

                If (lCount > 0) Then

                    For indx = 0 To lCount - 1
                        lReturn = PortalExecute("*admin:javavarget:index=" & indx)

                        sData = PortalGetString("data", "")

                        pieces = Split(sData, "|")

                        pieces(2) = LTrim(pieces(2))

                        sVarCaption = pieces(2)

                        ' Create a parameter and specify its name.
                        Dim param1 As New Parameter()
                        param1.Name = "CG_" & Replace(sVarCaption, Chr(32), "_")


                        Select Case pieces(1)

                            Case "str", "combo", "dcombo"
                                sVarValue = HeaderStringGet(pieces(0), "")

                                param1.Type = GetType(System.String)

                            Case "dbl"
                                sVarValue = CStr(HeaderDoubleGet(pieces(0), 0))
                                param1.Type = GetType(System.Decimal)

                            Case "bool"

                                sVarValue = HeaderIntGet(pieces(0), 0)
                                param1.Type = GetType(System.Int32)


                            Case "int"
                                sVarValue = CStr(HeaderIntGet(pieces(0), -1))
                                param1.Type = GetType(System.Int32)

                        End Select

                        ' Specify other parameter properties.
                        param1.Value = sVarValue
                        param1.Visible = True

                        ' Add the parameter to the report.
                        mReport.Parameters.Add(param1)

                    Next

                End If

            End If
        Catch ex As Exception

            MessageBox.Show("GetCG_VArs: " & ex.Message)

        End Try
    End Sub

    Private Sub beTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles beTemplate.EditValueChanged

    End Sub

    Private Sub frmPrintGraphics_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '#If Rittal Then

        '        ExecuteBtnClick()

        '        Me.Dispose()


        '#End If
    End Sub



End Class