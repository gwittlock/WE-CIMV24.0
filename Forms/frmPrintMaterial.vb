Imports System.Text
Imports DevExpress.XtraBars
Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.Globalization
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
Imports DevExpress.DataAccess.ConnectionParameters

Partial Public Class frmPrintMaterial
    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer,
                                                   ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr,
                                                   ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020


    Private m_PDBFile As String

    Private m_DataSet As DataSet

    Private dsSetup As DataSet

    Private dsCustom As DataSet

    Private m_CMDB As String

    Dim sSendTo As String

    Dim sTemplate As String
    Dim OutputMode As Long


    Public Enum PRINT_MODE
        TO_PRINTER = 0
        TO_PREVIEW = 1
        TO_FILE = 2
        TO_HTML = 3
        TO_PDF = 4
        TO_RTF = 5
        TO_XLS = 6
        TO_XLSX = 7
        TO_CSV = 8
        TO_IMAGE = 9
        TO_TEXT = 10
    End Enum

    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        OutputMode = CLng(RegGetString("Printing", "PrintMaterialsSendTo", PRINT_MODE.TO_PRINTER))

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

        DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.Extension = ".mlst"
        DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = Application.StartupPath

        beTemplate.Text = sTemplate

        beTemplate.ToolTip = sTemplate

        DropDownButton1.Text = "Send To: " & sSendTo

        'GetMaterialListing()


        Windows.Forms.Cursor.Current = Cursors.Default


    End Sub



    Private Sub sbEdit_Click(sender As Object, e As EventArgs) Handles sbEdit.Click

        Try

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ' Create a report instance.

            'CreateReport()

            'Exit Sub

            Dim report As New XtraReport()

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.Extension = ".mlst"
            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = Application.StartupPath

            ' GetMaterialListing()

            report.RequestParameters = True

            'report.DataSource = m_Parts
            report.LoadLayout(beTemplate.Text)

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            'report.Desi
            report.DataMember = "Types"


            ' Open the report in the End-User Designer. 
            Dim Tool As ReportDesignTool = New ReportDesignTool(report)

            AddHandler Tool.DesignForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignPanelLoaded


            Windows.Forms.Cursor.Current = Cursors.Default

            Tool.ShowDesigner()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Sub DesignPanelLoaded(sender As Object, e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)
        Dim src As New BindingSource
        src.DataSource = BindToData()


        CType(sender, XRDesignPanel).Report.DataSource = src

        e.DesignerHost.Container.Add(src, "Material_Inventory")

    End Sub

    Private Sub PrintPreview()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

            report.LoadLayout(beTemplate.Text)

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "Material Types"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            If detailReportBand IsNot Nothing Then

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

            End If

            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            Tool.AutoShowParametersPanel = True

            Tool.ShowPreviewDialog()

            If m_DataSet IsNot Nothing Then
                m_DataSet = Nothing
                report.DataSource = Nothing
                report.DataMember = Nothing
            End If

            Tool.Report.ClosePreview()
            Tool.Dispose()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PREVIEW

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Close()
    End Sub

    Private Sub DropDownButton1_Click(sender As Object, e As EventArgs) Handles DropDownButton1.Click
        Try


            Select Case UCase(DropDownButton1.Text)

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

                    PrintToImage()

                Case "SEND TO: TEXT"

                    PrintToText()


            End Select

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Sub PrintToPrinter()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ' Create a report instance.
            Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

            report.LoadLayout(beTemplate.Text)
            report.DataSource = BindToData()
            report.DataMember = "Material Types"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            If detailReportBand IsNot Nothing Then

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

            End If

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            'Tool.PreviewForm.PrintBarManager.AllowQuickCustomization = False
            'Tool.PreviewForm.ShowInTaskbar = False

            report.RequestParameters = True

            report.CreateDocument() '<--this will open the parameter values input form

            Tool.PrintDialog()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PRINTER

        Catch ex As Exception

            MessageBox.Show("PrintToPrinter: " & ex.Message)

        End Try


    End Sub

    Private Sub PrintToRTF()
        Try

            dlgPrintSave.Filter = "RTF Files (*.rtf)|*.rtf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

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

    Private Sub PrintToText()

        Try

            dlgPrintSave.Filter = "TXT Files (*.txt)|*.txt"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

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

    Private Sub PrintToXLS()

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            dlgPrintSave.Filter = "XLS Files (*.xls)|*.xls"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

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


    Private Sub PrintToXLSX()

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            dlgPrintSave.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

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

    Private Sub PrintToImage()

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor


            dlgPrintSave.Filter = "BMP Files (*.bmp)|*.bmp|EMF Files (*.emf)|*.emf| WMF FIles (*.wmf)|*.wmf| GIF Files (*.gif)|*.gif| JPEG Files (*.jpeg)|*.jepg| PNG Files (*.png)|*.pmg| TIFF Files (*.tiff)|*.tiff"

            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

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

    Private Sub PrintToHTML()

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            dlgPrintSave.Filter = "HTML Files (*.html)|*.html"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                End If

                ' Get its HTML export options.
                Dim htmlOptions As HtmlExportOptions = report.ExportOptions.Html

                ' Set HTML-specific export options.
                htmlOptions.CharacterSet = "UTF-8"
                htmlOptions.TableLayout = False
                htmlOptions.RemoveSecondarySymbols = False
                htmlOptions.Title = "WE-CIM Material Inventory Report"

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

    Private Sub PrintToPDF()

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            OutputMode = PRINT_MODE.TO_PDF

            dlgPrintSave.Filter = "PDF Files (*.pdf)|*.pdf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then
                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                ' Create a report instance.
                Dim report As XtraReport = XtraReport.FromFile(beTemplate.Text, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                End If


                ' Get its PDF export options.
                Dim pdfOptions As PdfExportOptions = report.ExportOptions.Pdf

                ' Set PDF-specific export options.
                pdfOptions.Compressed = True
                pdfOptions.ImageQuality = PdfJpegImageQuality.Highest
                pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New"
                pdfOptions.DocumentOptions.Application = "WE-CIM Advanced Fabrication Application"
                pdfOptions.DocumentOptions.Author = "Wittlock Engineering LLC"
                pdfOptions.DocumentOptions.Subject = "WE-CIM Material Inventory Report"
                pdfOptions.DocumentOptions.Title = "WE-CIM Material Inventory Report"

                report.RequestParameters = True

                Dim tool As New ReportPrintTool(report)
                report.CreateDocument()

                ' Export the report to PDF.
                report.ExportToPdf(reportPath)

                Windows.Forms.Cursor.Current = Cursors.Default

                StartProcess(reportPath)

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToPDF: " & ex.Message)

        End Try
    End Sub

    Private Sub PrintToCSV()


        Try

            dlgPrintSave.Filter = "CSV Files (*.csv)|*.csv"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                Dim reportPath As String = dlgPrintSave.FileName

                Dim report As XtraReport = XtraReport.FromFile(reportPath, True)

                report.LoadLayout(beTemplate.Text)
                report.DataSource = BindToData()
                report.DataMember = "Material Types"

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                If detailReportBand IsNot Nothing Then

                    Me.Show()

                    Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

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

    Private Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub

    Private Sub beTemplate_Click(sender As Object, e As EventArgs) Handles beTemplate.Click
        Dim sTemplate_FileOpen As New OpenFileDialog
        Dim sInitDir As String

        Try

            sInitDir = Application.StartupPath

            If (beTemplate.Text = "") Then

                sInitDir = Application.StartupPath & "\Report Templates\"
            Else
                sInitDir = PathDriveFolder(beTemplate.Text) & "\"

            End If



            sTemplate_FileOpen.Filter = "Material Report files (*.mlst)|*.mlst"
            sTemplate_FileOpen.FilterIndex = 1

            sTemplate_FileOpen.InitialDirectory = sInitDir

            If sTemplate_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sTemplate = sTemplate_FileOpen.FileName
                beTemplate.Text = sTemplate

                beTemplate.ToolTip = sTemplate

            End If
        Catch ex As Exception

            MessageBox.Show("beTemplate_Click: " & ex.Message)

        End Try
    End Sub

    Private Function BindToData() As DataSet
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Select [Material Inventory].*,[Material Types].* From [Material Inventory],[Material Types] Where ([Material Types].ID > 0 ) And [Material Inventory].[Type ID]=[Material Types].ID"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        ds.DataSetName = "Material Inventory"

        oledbAdapter.Fill(ds)

        ds.Tables(0).TableName = "Types"

        Return ds
    End Function


    Private Function CreateReport() As XtraReport
        ' Create a new report instance.
        'Dim report As New XtraReport()
        Dim report As New XtraReport


        report.LoadLayout(beTemplate.Text)

        ' Assign the data source to the report.
        report.DataSource = BindToData()
        report.DataMember = "Material Types"

        ' Add a detail band to the report.
        'Dim detailBand As New DetailBand()
        'detailBand.Height = 50
        'report.Bands.Add(detailBand)

        Dim detailReportBand As DetailBand = DirectCast(report.FindControl("Detail", False), DetailBand)

        If detailReportBand IsNot Nothing Then

            'detailReportBand.DataSource = m_DataSet  'MatListProps

            Me.Show()

            'Dim detailtBand1 As DetailtBand = DirectCast(report.FindControl("DetailReport1", False), DetailBand)


            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            Tool.AutoShowParametersPanel = True

            Tool.ShowPreviewDialog()
            'Tool.ShowPreview()

            OutputMode = PRINT_MODE.TO_PREVIEW

            If m_DataSet IsNot Nothing Then
                m_DataSet = Nothing
                report.DataSource = Nothing
                report.DataMember = Nothing
            End If

            Tool.Report.ClosePreview()
            Tool.Dispose()

        End If

        Return report
    End Function

    Private Sub bbiPreview_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPreview.ItemClick
        PrintPreview()
        DropDownButton1.Text = "SEND TO: Preview"
    End Sub

    Private Sub bbiCSV_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCSV.ItemClick
        PrintToCSV()
        DropDownButton1.Text = "SEND TO: CSV"
    End Sub

    Private Sub bbiHTML_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiHTML.ItemClick
        PrintToHTML()
        DropDownButton1.Text = "SEND TO: HTML"
    End Sub

    Private Sub bbiIMAGE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiIMAGE.ItemClick
        PrintToImage()
        DropDownButton1.Text = "SEND TO: IMAGE"

    End Sub

    Private Sub bbiPDF_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPDF.ItemClick
        PrintToPDF()
        DropDownButton1.Text = "SEND TO: PDF"
    End Sub

    Private Sub bbiPrinter_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPrinter.ItemClick
        PrintToPrinter()
        DropDownButton1.Text = "SEND TO: PRINTER"
    End Sub

    Private Sub bbiRTF_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiRTF.ItemClick
        PrintToRTF()
        DropDownButton1.Text = "SEND TO: RTF"
    End Sub

    Private Sub bbiTEXT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiTEXT.ItemClick
        PrintToText()
        DropDownButton1.Text = "SEND TO: TEXT"
    End Sub

    Private Sub bbiXLS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiXLS.ItemClick
        PrintToXLS()
        DropDownButton1.Text = "SEND TO: XLS"
    End Sub

    Private Sub bbiXLSX_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiXLSX.ItemClick
        PrintToXLSX()
        DropDownButton1.Text = "SEND TO: XLSX"
    End Sub

    Private Sub frmPrintMaterial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sReturn = RegPutString("Printing", "PrintMaterialsSendTo", OutputMode)
        sReturn = RegPutString("Printing", "PrintMaterialsTemplate", beTemplate.Text)

    End Sub
End Class
