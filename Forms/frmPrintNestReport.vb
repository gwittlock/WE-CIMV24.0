Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Text

Public Class frmPrintNestReport
    Inherits DevExpress.XtraEditors.XtraForm

    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer,
                                                      ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr,
                                                      ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020

    Private m_Tooling As New List(Of TheTools)

    Private m_NestSetup As New List(Of NestSetup)

    Private m_PDBFile As String

    Private m_DataSet As DataSet

    Private dsSetup As DataSet

    Private dsCustom As DataSet

    ' Private m_NestSetup As New System.Collections.Generic.List(Of Nest_Setup)

    Private m_CMDB As String

    Private cNestInfo As NestSetup

    Dim sSendTo As String

    Dim sTemplate As String
    Dim OutputMode As Long

    Private Sub GetCG_VArs(mReport As XtraReport)
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

            Dim param1 As New Parameter()
            param1.Name = ("Programmed_By")
            param1.Type = GetType(System.String)
            param1.Value = ""
            param1.Visible = True

            ' Add the parameter to the report.

            mReport.Parameters.Add(param1)

            param1 = New Parameter()
            param1.Name = ("Customer")
            param1.Type = GetType(System.String)
            param1.Value = ""
            param1.Visible = True

            ' Add the parameter to the report.

            mReport.Parameters.Add(param1)

            cgFilename = HeaderStringGet("cgfile", "")

            If (cgFilename <> "") Then

                ' get cg variables from cgfile
                lReturn = PortalExecute("*admin:javavarsextract:file=" & Chr(34) & cgFilename & Chr(34) &
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
                        param1 = New Parameter()
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
    Private Sub beTemplate_Click(sender As Object, e As EventArgs) Handles beTemplate.Click
        Dim sTemplate_FileOpen As New OpenFileDialog
        Dim sInitDir As String

        Try

            sInitDir = RegGetString("Printing", "PrintNestTemplate", NormalizePath(App_Path) & "Report Templates")

            If (sInitDir = "") Then

                sInitDir = NormalizePath(App_Path) & "Report Templates"

            End If


            sInitDir = GetFilePath(sInitDir)


            sTemplate_FileOpen.Filter = "Nest Report files (*.nrep)|*.nrep"
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub sbEdit_Click(sender As Object, e As EventArgs) Handles sbEdit.Click

        Try

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ' Create a report instance.
            Dim report As New repPrintNestReport()

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.Extension = ".nrep"
            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = App_Path & "\Report Templates"

            'DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode =
            'DataBindingModeExtensions

            'ReportStorageTool.DefaultExtention = ".nrep"
            'ReportStorageTool.DefaultRootDirectory = App_Path & "\Report Templates"

            AddToolsTableToPDB()
            AddMaterialAndImage()
            AddSettingsTableToPDB()
            GetSetupParametrs(report)
            GetSheetInfo(m_PDBFile)

            ' Force the report creation without previously 
            ' requesting the parameter value from end-users.
            report.RequestParameters = True
            'report.DataSource = m_DataSet

            'report.DataSource = m_Parts
            report.LoadLayout(beTemplate.Text)

            GetCG_VArs(report)
            ' Open the report in the End-User Designer. 
            Dim Tool As ReportDesignTool = New ReportDesignTool(report)

            AddHandler Tool.DesignForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignPanelLoaded

            Windows.Forms.Cursor.Current = Cursors.Default

            Tool.ShowDesigner()

        Catch ex As Exception

            MessageBox.Show("Print Nesat Report::sbEdit_Click: " & ex.Message)

        End Try


    End Sub
    Private Sub DesignPanelLoaded(sender As Object, e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)

        Dim src As New BindingSource
        src.DataSource = m_DataSet

        Dim src1 As New BindingSource
        src1.DataSource = m_NestSetup

        CType(sender, XRDesignPanel).Report.DataSource = src

        e.DesignerHost.Container.Add(src, "Nesting")
        ' e.DesignerHost.Container.Add(src1, "NestSetup")
    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        frmMain.pnlNestCombos.Visible = True
        Me.Dispose()

    End Sub

    Private Sub frmPrintNestReport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        sReturn = RegPutString("Printing", "PrintNestSendTo", OutputMode)
        sReturn = RegPutString("Printing", "PrintNestTemplate", sTemplate)
        sReturn = RegPutString("Printing", "PrintTools", cePrintTools.Checked)
        sReturn = RegPutString("Printing", "PrintAllTools", cePrintAllTools.Checked)
        sReturn = RegPutString("Printing", "PrintGraphics", cePrintGraphics.Checked)
        sReturn = RegPutString("Printing", "PrintPartList", cePrintPartList.Checked)

        DeleteFolder(modPath.PathTempImages)

    End Sub

    Private Sub frmPrintNestReport_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            frmMain.pnlNestCombos.Visible = False

            If (UCase(PathExt(m_curr_file)) = "NST") Then

                m_PDBFile = HeaderStringGet("pdb_file", "")
            Else

                m_PDBFile = RegGetString("Fabrication\FileOpen", "LastPDB", PathPDB())

            End If


            If (FileExists(m_PDBFile) = True) Then

                PathPDB_Set(m_PDBFile)

                OutputMode = 0 'CLng(RegGetString("Printing", "PrintNestSendTo", PRINT_MODE.TO_PRINTER)

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

                cePrintTools.Checked = CBool(RegGetString("Printing", "PrintTools", 1))
                cePrintAllTools.Checked = CBool(RegGetString("Printing", "PrintAllTools", 0))
                cePrintGraphics.Checked = CBool(RegGetString("Printing", "PrintGraphics", 1))
                cePrintPartList.Checked = CBool(RegGetString("Printing", "PrintPartList", 1))

                sTemplate = RegGetString("Printing", "PrintNestTemplate", "")

                If (FileExists(sTemplate) = False) Then

                    MessageBox.Show("Report  Template < " & sTemplate & " > Does Not Exisit. Please Select a Template")

                    sTemplate = NormalizePath(App_Path) & "Report Templates\"

                End If

                beTemplate.Text = sTemplate

                beTemplate.ToolTip = sTemplate

                DropDownButton1.Text = "Send To: " & sSendTo

                Windows.Forms.Cursor.Current = Cursors.Default


            Else

                MessageBox.Show("File " & m_PDBFile & " was Not Found! Unable to continue Printing!", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception


            MessageBox.Show("PrintNestFormLoad: " & ex.Message)

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

                                m_Tooling.Add(New TheTools() With {.ToolNumber = clsToolData.NC_Code_Number,
                                                            .ToolName = clsToolData.Description,
                                                            .ToolFeed = clsToolData.Feed,
                                                            .ToolAngle = clsToolData.Index_Angle,
                                                            .ToolXLocation = clsToolData.Station_Location_X,
                                                            .ToolYLocation = clsToolData.Station_Location_Y,
                                                            .Tool_Auto_Index = clsToolData.Auto_Index,
                                                            .Tool_Station_Size = clsToolData.Station_Size,
                                                            .Tool_Primary_Code = clsToolData.PrimaryCode,
                                                            .Tool_Secomdary_Code = clsToolData.SecondaryCode,
                                                            .Tool_Type_ID = clsToolData.type_id})


                            End With

                        End If

                    End If

                ElseIf (cePrintAllTools.CheckState = CheckState.Checked) Then

                    If clsToolData.NC_Code_Number > 0 Then
                        With clsToolData

                            m_Tooling.Add(New TheTools() With {.ToolNumber = clsToolData.NC_Code_Number,
                                                        .ToolName = clsToolData.Description,
                                                        .ToolFeed = clsToolData.Feed,
                                                        .ToolAngle = clsToolData.Index_Angle,
                                                        .ToolXLocation = clsToolData.Station_Location_X,
                                                        .ToolYLocation = clsToolData.Station_Location_Y,
                                                        .Tool_Auto_Index = clsToolData.Auto_Index,
                                                        .Tool_Station_Size = clsToolData.Station_Size,
                                                        .Tool_Primary_Code = clsToolData.PrimaryCode,
                                                        .Tool_Secomdary_Code = clsToolData.SecondaryCode,
                                                        .Tool_Type_ID = clsToolData.type_id})


                        End With

                    End If
                End If
            Next

        Catch ex As Exception

            MessageBox.Show("GetPartTooling: " & ex.Message)

        End Try
    End Sub
    Private Sub GetSheetInfo(s_PdbFileName As String)
        Dim SQL1 As String
        Dim SQL2 As String
        Dim SQL3 As String
        Dim SQL4 As String
        Dim SQL5 As String
        Dim m_da_SheetResults As OleDbDataAdapter
        Dim m_da_PartResults As OleDbDataAdapter
        Dim m_da_UserVars As OleDbDataAdapter
        Dim m_da_Tooling As OleDbDataAdapter
        Dim m_da_NestSetup As OleDbDataAdapter
        Dim m_MaterialType As DataColumn

        'AddMaterialAndImage()

        ' Compose the connection string.
        Dim connect_string As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & s_PdbFileName & "';"



        SQL1 = "SELECT * FROM [Sheet Result]"

        SQL2 = "SELECT Part.*,[Part Result].* FROM Part,[Part Result] Where Part.ID=[Part Result].[Part ID]"

        'SQL2 = "Select [Part].*, [Part Result].*,[Sheet Result].* From [Part], [Part Result],[Sheet Result] "

        SQL3 = "SELECT * FROM SheetTooling"

        SQL4 = "Select NestSetup.* From NestSetup"

        SQL5 = "Select [Part Variables].* From [Part Variables]"

        ' Create a DataAdapter to load the Sheet Results table.
        m_da_NestSetup = New OleDbDataAdapter(SQL4, connect_string)

        m_da_SheetResults = New OleDbDataAdapter(SQL1, connect_string)

        m_da_PartResults = New OleDbDataAdapter(SQL2, connect_string)

        m_da_Tooling = New OleDbDataAdapter(SQL3, connect_string)

        m_da_UserVars = New OleDbDataAdapter(SQL5, connect_string)

        ' Create and fill the DataSet.
        m_DataSet = New DataSet

        m_MaterialType = New DataColumn("MaterialType", System.Type.GetType("System.String"))

        m_DataSet.DataSetName = "Nest_Params"

        m_da_NestSetup.Fill(m_DataSet, "Nest Setup")

        m_da_SheetResults.Fill(m_DataSet, "Sheet Results")

        m_da_PartResults.Fill(m_DataSet, "Part Result")

        m_da_Tooling.Fill(m_DataSet, "SheetTooling")

        m_da_NestSetup.Update(m_DataSet, "Nest Setup")

        ' Define the relationship between the tables.
        Dim data_relation As New DataRelation("SheetResults_Parts",
            m_DataSet.Tables("Sheet Results").Columns("ID"),
            m_DataSet.Tables("Part Result").Columns("Sheet ID"))

        m_DataSet.Relations.Add(data_relation)

        ' Define the relationship between the tables.
        Dim data_relationTooling As New DataRelation("SheetResults_Tools",
            m_DataSet.Tables("Sheet Results").Columns("ID"),
            m_DataSet.Tables("SheetTooling").Columns("SheetID"))

        m_DataSet.Relations.Add(data_relationTooling)

        If m_da_NestSetup IsNot Nothing Then m_da_NestSetup = Nothing

        If m_da_PartResults IsNot Nothing Then m_da_PartResults = Nothing

        If m_da_SheetResults IsNot Nothing Then m_da_SheetResults = Nothing

        If m_da_Tooling IsNot Nothing Then m_da_Tooling = Nothing

        If m_da_UserVars IsNot Nothing Then m_da_UserVars = Nothing

        If m_daCMDB IsNot Nothing Then m_daCMDB = Nothing


    End Sub

    Private Function GetMaterialDescription(m_Matid As Integer) As String

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialDescription = "" 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then

                GetMaterialDescription = ds.Tables(0).Rows(0).Item("Description").ToString

            End If

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetMaterialDescription " & ex.Message)

        End Try

    End Function
    Private Function GetMaterialWeight(ByVal m_Matid As Long) As Double
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialWeight = 0 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                GetMaterialWeight = CDbl(ds.Tables(0).Rows(i).Item("Weight").ToString)
            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetMaterialWeight " & ex.Message)

        End Try

    End Function
    Private Function GetMaterialCost(ByVal m_Matid As Long) As Double
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialCost = 0 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                GetMaterialCost = CDbl(ds.Tables(0).Rows(i).Item("Cost Per Unit").ToString)
            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetMaterialCost " & ex.Message)

        End Try

    End Function
    Private Function GetMaterialLength(m_Matid As Integer) As Double

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialLength = 0 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                GetMaterialLength = CDbl(ds.Tables(0).Rows(i).Item("Length").ToString)
            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetMaterialLength " & ex.Message)

        End Try

    End Function

    Private Function GetMaterialWidth(m_Matid As Integer) As Double

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialWidth = 0 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                GetMaterialWidth = CDbl(ds.Tables(0).Rows(i).Item("Width").ToString)
            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing
        Catch ex As Exception

            MessageBox.Show("GetMaterialWidth " & ex.Message)

        End Try

    End Function

    Private Function GetMaterialThickness(m_Matid As Integer) As Double

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialThickness = 0 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                GetMaterialThickness = CDbl(ds.Tables(0).Rows(i).Item("Thickness").ToString)
            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing


        Catch ex As Exception

            MessageBox.Show("GetMaterialThickness " & ex.Message)

        End Try

    End Function
    Private Function GetMaterialType(m_Matid As Integer) As String

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim m_TypeID As Integer

        GetMaterialType = "" 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].ID = " & m_Matid & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                m_TypeID = CInt(ds.Tables(0).Rows(i).Item("Type ID").ToString)
            Next

            ds.Dispose()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_CMDB & "';"

            sql = "Select [Material Types].* From [Material Types] Where ([Material Types].ID = " & m_TypeID & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                GetMaterialType = ds.Tables(0).Rows(i).Item("Description").ToString
            Next

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetMaterialType " & ex.Message)

        End Try

    End Function

    Private Function AddMaterialAndImage() As Long
        Dim sql As String
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim ni As Integer
        Dim cmd As OleDbCommand = New OleDbCommand
        Dim sNestImage As String
        Dim sFirstSheet As String
        Dim nSheetID As Integer
        Dim dTempTotaTravel As Double
        Dim n_MaterialID As Integer
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        sFirstSheet = Nothing

        'frmMain.TopMost = True

        sql = "SELECT * From [Sheet Result]"

        AddMaterialAndImage = -1

        Try
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            ni = ds.Tables(0).Columns.IndexOf("MaterialType") 'test if colum exists 


            If ni = -1 Then 'Column is missing so add it

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "MaterialDescrip")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Material_Type")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Material_Width")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Material_Length")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Material_Thickness")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Material_Weight")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Material_Cost")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Image")

                modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "NC_Filename")

                If (DoesFieldExist(m_PDBFile, "Sheet Result", "Sheet_Cut_Travel") = False) Then
                    modOleDbHandler.AddFieldToTable(m_PDBFile, "Sheet Result", "Sheet_Cut_Travel")
                End If

            End If

NoAlter:
            For i = 0 To ds.Tables(0).Rows.Count - 1

                nSheetID = ds.Tables(0).Rows(i).Item("ID")

                dTempTotaTravel = GetTotalTravelfForSheet(m_PDBFile, nSheetID)

                cmd = New OleDbCommand(sql, connection)

                n_MaterialID = CInt(ds.Tables(0).Rows(i).Item("ID"))

                Dim s_SHeetid As String = "the sheetid is < " & n_MaterialID & " >"
                Dim dMatWeight As Double = GetMaterialWeight(n_MaterialID)

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[MaterialDescrip] = '" & HeaderStringGet("MatCfg", "") & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Material_Type] = '" & HeaderStringGet("MatCatName", "") & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Material_Weight] = '" & GetMaterialWeight(CInt(ds.Tables(0).Rows(i).Item("Material ID"))) & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Material_Cost] = '" & GetMaterialCost(CInt(ds.Tables(0).Rows(i).Item("Material ID"))) & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Material_Width] = '" & GetMaterialWidth(CInt(ds.Tables(0).Rows(i).Item("Material ID"))) & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Material_Length] = '" & GetMaterialLength(CInt(ds.Tables(0).Rows(i).Item("Material ID"))) & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Material_Thickness] = '" & GetMaterialThickness(CInt(ds.Tables(0).Rows(i).Item("Material ID"))) & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Sheet_Cut_Travel] = " & dTempTotaTravel & " Where ([Sheet Result].ID = " & nSheetID & " )"

                cmd.ExecuteNonQuery()

                sNestImage = PathTempImages() & PathFile(ds.Tables(0).Rows(i).Item("Sheet Filename")) & ".png"


                If (i = 0) Then

                    sFirstSheet = ds.Tables(0).Rows(i).Item("Sheet Filename")

                End If

                cmd.CommandText = "UPDATE [Sheet Result] Set [Sheet Result].[Image] = '" & sNestImage & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                sReturn = ImportMM2(ds.Tables(0).Rows(i).Item("Sheet Filename"))

                If (m_PONum <> "") Then

                    lReturn = HeaderStringSet("PoNum", m_PONum)
                    lReturn = modFileIO.ExportMM2(ds.Tables(0).Rows(i).Item("Sheet Filename"))
                    modAdmin.ModelDirtyClear()

                End If

                If (m_Customer <> "") Then

                    lReturn = HeaderStringSet("Customer", m_Customer)
                    lReturn = modFileIO.ExportMM2(ds.Tables(0).Rows(i).Item("Sheet Filename"))
                    modAdmin.ModelDirtyClear()

                End If

                modView.ViewFull()

                cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[NC_Filename] = '" & HeaderStringGet("ncfile", "File Has not Been Coded") & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                cmd.ExecuteNonQuery()

                If (HeaderStringGet("CycleTime", "") <> "") Then

                    cmd.CommandText = "UPDATE [Sheet Result] set [Sheet Result].[Cycle Time] = '" & HeaderStringGet("CycleTime", "") & "' Where ([Sheet Result].[ID] =" & CInt(ds.Tables(0).Rows(i).Item("ID")) & " )"

                    cmd.ExecuteNonQuery()

                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                PopulateToolsTable(ds.Tables(0).Rows(i).Item("ID"))

                GetPartImage(sNestImage)

            Next

            ds.Dispose()

            connection.Close()

            connection.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

            'sReturn = ImportMM2(sFirstSheet)
            sReturn = ImportFile(sFirstSheet, sFirstSheet)

            If (frmNesting.IsActive = True) Then
                frmNesting.TV_NestConfig.FocusedNode = frmNesting.CFG_RESULTS_NODE.FirstNode
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor


            AddMaterialAndImage = 1

            frmMain.TopMost = False

        Catch ex As Exception

            MessageBox.Show("AddMaterialAndImage: " & ex.Message)


        End Try

    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        '' Show the report's preview. 
        Dim report As New XtraReport

        report.LoadLayout(beTemplate.Text)

        GetSetupParametrs(report)

        report.DataSource = m_DataSet
        report.DataMember = m_DataSet.Tables(0).TableName

        Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

        detailReportBand.DataSource = m_DataSet

        Dim Tool As ReportPrintTool = New ReportPrintTool(report)

        Tool.AutoShowParametersPanel = False

        Windows.Forms.Cursor.Current = Cursors.Default
        Tool.ShowPreview()
    End Sub
    Private Sub GetSetupParametrs(ByVal MyReport As XtraReport)

        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim sql2 As String

        dsSetup = New DataSet
        dsCustom = New DataSet

        cNestInfo = New NestSetup

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

        sql = "SELECT * FROM [Setup]"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(dsSetup)

        oledbAdapter.Dispose()

        For i = 0 To dsSetup.Tables(0).Rows.Count - 1

            Select Case Trim(dsSetup.Tables(0).Rows(i).Item("DialogDisplay"))
                Case "Template"
                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = "") Then
                        cNestInfo.Template = "Empty"
                    Else
                        cNestInfo.Template = dsSetup.Tables(0).Rows(i).Item("VBValue")
                    End If

                Case "Machine"
                    cNestInfo.Machine = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Tool Setup"
                    cNestInfo.Tool_Setup = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Layer Setup"
                    cNestInfo.Layer_Setup = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Lead Setup"
                    cNestInfo.Lead_Setup = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Result Path"
                    cNestInfo.Result_Path = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Result Name"
                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = "") Then
                        cNestInfo.Result_Name = "Empty"
                    Else
                        cNestInfo.Result_Name = dsSetup.Tables(0).Rows(i).Item("VBValue")
                    End If


                Case "Result Digits"
                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = "") Then
                        cNestInfo.Result_Digits = "Empty"
                    Else
                        cNestInfo.Result_Digits = CInt(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                    End If

                Case "Draw While Nesting"
                    If (UCase(dsSetup.Tables(0).Rows(i).Item("VBValue")) = "FALSE") Then
                        cNestInfo.Draw_While_Nesting = 0
                    Else
                        cNestInfo.Draw_While_Nesting = 1
                    End If

                    'cNestInfo.Draw_While_Nesting = CInt(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Annotate While Nesting"
                    If (UCase(dsSetup.Tables(0).Rows(i).Item("VBValue")) = "FALSE") Then
                        cNestInfo.Draw_While_Nesting = 0
                    Else
                        cNestInfo.Draw_While_Nesting = 1
                    End If
                    'cNestInfo.Annotate_While_Nesting = CInt(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Minimum Yield (percent)"
                    cNestInfo.Minimum_Yield = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Gap Tolerance"
                    cNestInfo.Gap_Tolerance = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Cut Sheets"
                    cNestInfo.Cut_Sheets = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Pierce Holes"
                    cNestInfo.Pierce_Holes = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Layers"
                    cNestInfo.Layers = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Unused Tools"
                    cNestInfo.Unused_Tools = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Drop/Stop Commands"
                    cNestInfo.Drop_Stop_Commands = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Auto Code"
                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = False) Then
                        cNestInfo.Auto_Code = 0
                    Else
                        cNestInfo.Auto_Code = 1
                    End If
                Case "Auto Print"
                    cNestInfo.Auto_Print = CBool(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Part Labels"
                    cNestInfo.Part_Labels = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Label Angle"
                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = "") Then
                        cNestInfo.Label_Angle = 0
                    Else
                        cNestInfo.Label_Angle = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                    End If

                Case "Print Label Size"
                    cNestInfo.Print_Label_Size = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Labeling Tool"
                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = "" Or dsSetup.Tables(0).Rows(i).Item("VBValue") = "(None)") Then
                        cNestInfo.Labeling_Tool = "(None)"
                    Else
                        cNestInfo.Labeling_Tool = dsSetup.Tables(0).Rows(i).Item("VBValue")
                    End If

                Case "Ordering"
                    cNestInfo.Ordering = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Pierce Hole"
                    cNestInfo.Pierce_Hole = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Parts In Parts"
                    cNestInfo.Parts_In_Parts = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Fill Direction"
                    cNestInfo.Fill_Direction = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Nesting Start"
                    cNestInfo.Nesting_Start = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Web Size"
                    cNestInfo.Web_Size = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Placement"
                    cNestInfo.Placement = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Fill Limit"
                    cNestInfo.Fill_Limit = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Split Patterns"
                    cNestInfo.Split_Patterns = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Chain Size"
                    cNestInfo.Chain_Size = CInt(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Chain Offset"
                    cNestInfo.Chain_Offset = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Cut Back Tool"

                    If (dsSetup.Tables(0).Rows(i).Item("VBValue") = "" Or dsSetup.Tables(0).Rows(i).Item("VBValue") = "None") Then
                        cNestInfo.Cut_Back_Tool = 0
                    Else
                        cNestInfo.Cut_Back_Tool = dsSetup.Tables(0).Rows(i).Item("VBValue")
                    End If

                Case "Repo Mode"
                    cNestInfo.Repo_Mode = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Workzone Size"
                    cNestInfo.Workzone_Size = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Reposition Overlap"
                    cNestInfo.Reposition_Overlap = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Short Repo"
                    cNestInfo.Short_Repo = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Nest Around Clamps"
                    cNestInfo.Nest_Around_Clamps = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Hold Placement"
                    cNestInfo.Hold_Placement = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Hold Default X"
                    cNestInfo.Hold_Default_X = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Hold Default Y"
                    cNestInfo.Hold_Default_Y = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Clamp 1 Position"
                    cNestInfo.Clamp_1_Position = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Clamp 2 Position"
                    cNestInfo.Clamp_2_Position = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Clamp 3 Position"
                    cNestInfo.Clamp_3_Position = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Clamp 4 Position"
                    cNestInfo.Clamp_4_Position = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Left Border"
                    cNestInfo.Left_Border = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Right Border"
                    cNestInfo.Right_Border = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Top Border"
                    cNestInfo.Top_Border = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Bottom Border"
                    cNestInfo.Bottom_Border = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Remnant Border"
                    cNestInfo.Remnant_Border = CDbl(dsSetup.Tables(0).Rows(i).Item("VBValue"))
                Case "Part Holes"
                    cNestInfo.Part_Holes = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Part Kerf"
                    cNestInfo.Part_Kerf = dsSetup.Tables(0).Rows(i).Item("VBValue")
                Case "Subs Across Sheets"

                    cNestInfo.Subs_Across_Sheets = IIf(dsSetup.Tables(0).Rows(i).Item("VBValue") = True, 1, 0)

                Case Else



                    sql2 = "UPDATE [Setup] set [Setup].[VBvalue] = '" & HeaderStringGet(Trim(dsSetup.Tables(0).Rows(i).Item("DialogDisplay")), "") & "' Where ([Setup].[DialogDisplay] ='" & Trim(dsSetup.Tables(0).Rows(i).Item("DialogDisplay")) & "' )"

                    dsSetup.Tables(0).Rows(i).Item("VBValue") = HeaderStringGet(Trim(dsSetup.Tables(0).Rows(i).Item("DialogDisplay")), "")
                    dsSetup.Tables(0).Rows(i).Item("CValue") = HeaderStringGet(Trim(dsSetup.Tables(0).Rows(i).Item("DialogDisplay")), "")

                    Dim cmd As OleDbCommand = New OleDbCommand(sql2, connection)

                    cmd.ExecuteNonQuery()

                    cmd.Dispose()



            End Select


        Next

        dsSetup.Dispose()

        connection.Close()

        If dsSetup IsNot Nothing Then dsSetup = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing



        PopulateSettingsTable()


    End Sub

    Private Sub PrintPreview()
        Try



            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Me.Hide()

            AddToolsTableToPDB()
            AddMaterialAndImage()

            '' Show the report's preview. 
            Dim report As New XtraReport

            AddSettingsTableToPDB()
            GetSetupParametrs(report)
            GetSheetInfo(m_PDBFile)

            report.DataSource = m_DataSet
            report.DataMember = m_DataSet.Tables(0).TableName

            report.LoadLayout(beTemplate.Text)
            GetCG_VArs(report)

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            If detailReportBand IsNot Nothing Then


                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If

                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If



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
            Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try

    End Sub


    Private Sub PrintToPrinter()

        Try

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Me.Hide()

            AddToolsTableToPDB()
            AddMaterialAndImage()

            '' Show the report's preview. 
            Dim report As New XtraReport



            report.RequestParameters = True

            AddSettingsTableToPDB()
            GetSetupParametrs(report)
            GetSheetInfo(m_PDBFile)

            report.DataSource = m_DataSet
            report.DataMember = m_DataSet.Tables(0).TableName

            report.LoadLayout(beTemplate.Text)

            GetCG_VArs(report)

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            detailReportBand.DataSource = m_DataSet  'm_Tooling

            ' Me.Show()

            Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

            If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                detailReportBand1.Visible = False
            Else
                detailReportBand1.Visible = True

            End If


            If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                detailReportBand.Visible = True

            Else

                detailReportBand.Visible = False

            End If

            Dim Tool As New ReportPrintTool(report)

            Tool.AutoShowParametersPanel = True
            report.CreateDocument()

            Tool.PrintDialog()

            OutputMode = PRINT_MODE.TO_PRINTER

            If m_DataSet IsNot Nothing Then m_DataSet = Nothing

        Catch ex As Exception

            MessageBox.Show("PrintToPrinter: " & ex.Message)

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
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)
                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

            End If


        Catch ex As Exception

            MessageBox.Show("PrintToHTML: " & ex.Message)

        End Try

    End Sub

    Private Sub StartProcess(ByVal path As String)
        Dim process As New Process()

        Try

            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()

        Catch ex As Exception

            MessageBox.Show("StartProcess: " & ex.Message)

        End Try

    End Sub
    Private Sub PrintToPDF()

        Try

            dlgPrintSave.InitialDirectory = RegGetString("Fabrication\FileOpen", "LastPDF", NormalizePath(App_Path) & "nests")
            dlgPrintSave.Filter = "PDF Files (*.pdf)|*.pdf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                Dim reportPath As String = dlgPrintSave.FileName
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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


                ' Export the report to PDF.
                report.ExportToPdf(reportPath)

                OutputMode = PRINT_MODE.TO_PDF

                Windows.Forms.Cursor.Current = Cursors.Default

                StartProcess(reportPath)

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

                RegPutString("Fabrication\FileOpen", "LastPDF", NormalizePath(PathDriveFolder(dlgPrintSave.FileName)))

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToPDF: " & ex.Message)

        End Try

    End Sub
    Private Sub PrintToXLS()

        Try

            dlgPrintSave.Filter = "XLS Files (*.xls)|*.xls"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then


                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToXLS: " & ex.Message)

        End Try

    End Sub
    Private Sub PrintToXLSX()

        Try

            dlgPrintSave.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

            End If

        Catch ex As Exception

            MessageBox.Show("PrintToXLSX: " & ex.Message)

        End Try
    End Sub


    Private Sub PrintToCSV()

        Try

            dlgPrintSave.Filter = "CSV Files (*.csv)|*.csv"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then
                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

            End If


        Catch ex As Exception

            MessageBox.Show("PrintToCSV: " & ex.Message)

        End Try

    End Sub

    Private Sub PrtintToImage()

        Try

            dlgPrintSave.Filter = "BMP Files (*.bmp)|*.bmp|EMF Files (*.emf)|*.emf| WMF FIles (*.wmf)|*.wmf| GIF Files (*.gif)|*.gif| JPEG Files (*.jpeg)|*.jepg| PNG Files (*.png)|*.pmg| TIFF Files (*.tiff)|*.tiff"

            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            If (dlgPrintSave.FileName <> "") Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                ' A path to export a report.
                Dim reportPath As String = dlgPrintSave.FileName
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()
                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If



                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

            End If


        Catch ex As Exception

            MessageBox.Show("PrtintToImage: " & ex.Message)

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
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()


                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

                ' Export the report to RTF.
                report.ExportToRtf(reportPath)

                OutputMode = PRINT_MODE.TO_RTF

                Windows.Forms.Cursor.Current = Cursors.Default

                ' Show the result.
                StartProcess(reportPath)


                If m_DataSet IsNot Nothing Then m_DataSet = Nothing


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
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Hide()

                AddToolsTableToPDB()
                AddMaterialAndImage()

                '' Show the report's preview. 
                Dim report As New XtraReport

                AddSettingsTableToPDB()
                GetSetupParametrs(report)
                GetSheetInfo(m_PDBFile)

                report.DataSource = m_DataSet
                report.DataMember = m_DataSet.Tables(0).TableName

                report.LoadLayout(beTemplate.Text)

                GetCG_VArs(report)

                Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

                detailReportBand.DataSource = m_DataSet  'm_Tooling

                Me.Show()

                Dim detailReportBand1 As DetailReportBand = DirectCast(report.FindControl("DetailReport1", False), DetailReportBand)

                If (cePrintPartList.CheckState = CheckState.Unchecked) Then
                    detailReportBand1.Visible = False
                Else
                    detailReportBand1.Visible = True

                End If


                If ((cePrintTools.CheckState) Or (cePrintAllTools.CheckState) = CheckState.Checked) Then

                    detailReportBand.Visible = True

                Else

                    detailReportBand.Visible = False

                End If

                Dim Tool As ReportPrintTool = New ReportPrintTool(report)

                Tool.AutoShowParametersPanel = True

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

                If m_DataSet IsNot Nothing Then m_DataSet = Nothing

            End If


        Catch ex As Exception

            MessageBox.Show("PrintToText: " & ex.Message)

        End Try

    End Sub

    Private Sub cePrintAllTools_CheckedChanged(sender As Object, e As EventArgs) Handles cePrintAllTools.CheckedChanged

        If (cePrintAllTools.CheckState = CheckState.Checked) Then

            cePrintTools.CheckState = CheckState.Unchecked
            ' PopulateToolsTable()

        End If

    End Sub

    Private Sub cePrintTools_CheckedChanged(sender As Object, e As EventArgs) Handles cePrintTools.CheckedChanged

        If (cePrintTools.CheckState = CheckState.Checked) Then

            cePrintAllTools.CheckState = CheckState.Unchecked
            'PopulateToolsTable()

        End If

    End Sub


    Private Sub GetPartImage(sImageFilename As String)
        Dim cmd As String
        Dim bounds As Rectangle = frmMain.pnlPicmodeler.Bounds
        Dim pt As Point = frmMain.pnlPicmodeler.PointToScreen(bounds.Location)
        Dim myBitmap As New Bitmap(bounds.Width - 25, bounds.Height)

        'MessageBox.Show("The bounds width is < " & frmMain.pnlPicmodeler.Bounds.Width & " > and the height is < " & frmMain.pnlPicmodeler.Bounds.Height & " > ")

        frmMain.StatusBar.Visible = False

        cmd = "!view:mode:" & _
              " id=" & modView.ViewIdGet(VIEW_WIRE) & _
              ",mono=1, targets=0"

        ''We suppress display of handles by setting targets=0. 
        lReturn = PortalExecute(cmd)

        modView.ViewRefresh()

        ' lReturn = PortalExecute("!View:Zoom:factor=" & (1.0# / VIEW_ZOOM_FACTOR))
        modView.ViewAll()


        'LockWindowUpdate(frmMain.pnlPicmodeler.Handle)

        Using m_g As Graphics = Graphics.FromImage(myBitmap)

            m_g.CopyFromScreen(New Point(pt.X - frmMain.pnlPicmodeler.Location.X, pt.Y - frmMain.pnlPicmodeler.Location.Y), Point.Empty, bounds.Size)


            m_g.Dispose()

        End Using

        myBitmap.Save(sImageFilename)

        myBitmap.Dispose()

        cmd = "!view:mode:" & _
                " id=" & modView.ViewIdGet(VIEW_WIRE) & _
                ",mono=0, targets=1"

        lReturn = PortalExecute(cmd)

        modView.ViewRefresh()

        'LockWindowUpdate(0&)


        frmMain.StatusBar.Visible = True

    End Sub

    Private Sub AddToolsTableToPDB()
        Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & m_PDBFile)
        Dim sTablename As String = "SheetTooling"
        Dim ds As New DataSet
        Dim dt1 As DataTable = ds.Tables("SheetTooling")


        Try
            connection.Open()

            'Get database schema 
            Dim dbSchema As DataTable = connection.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, sTablename, "TABLE"})

            ' If the table exists, the count = 1 
            If dbSchema.Rows.Count > 0 Then

                ' do whatever you want to do if the table exists 
                Dim cmd2 As New OleDb.OleDbCommand("DROP TABLE SheetTooling", connection)

                cmd2.ExecuteNonQuery()

            End If

            'do whatever you want to do if the table does not exist 
            ' e.g. create a table 
            Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename & _
               "] ([ID] AUTOINCREMENT PRIMARY KEY  , " & _
               "[SheetID] Integer , " & _
               "[Description] TEXT(255) , " & _
               "[NC_Code_Number] Integer , " & _
               "[Width_Diameter] Float , " & _
               "[Length] Float , " & _
               "[Loff] Integer , " & _
               "[Doff] Integer , " & _
               "[Radius] Float , " & _
               "[Angle] Float , " & _
               "[Shear] Float , " & _
               "[Cost] Float , " & _
               "[Life] Float , " & _
               "[FileName] TEXT(255) , " & _
               "[Speed] Float , " & _
               "[Feed] Float , " & _
               "[Gas] Float , " & _
               "[Power] Float , " & _
               "[Type_Description] TEXT(255) , " & _
               "[Type_ID] Integer , " & _
               "[Frequency] Float , " & _
               "[Focus] Float , " & _
               "[Die_Clearance] Float , " & _
               "[Slowdown_Angle] Float , " & _
               "[Slowdown_Setback] Float , " & _
               "[Slowdown_Divisions] Integer , " & _
               "[Slowdown_Formula] TEXT(255) , " & _
               "[Corner_Radius] Float , " & _
               "[Diameter] Float , " & _
               "[Index_Angle] Float , " & _
               "[Kerf] Float , " & _
               "[Major_Diameter] Float , " & _
               "[Minor_Diameter] Float , " & _
               "[Pitch] Float , " & _
               "[Web] Float , " & _
               "[Auto_Index] LOGICAL , " & _
               "[Fixed_Station] LOGICAL , " & _
               "[Station_Location_X] Float , " & _
               "[Station_Location_Y] Float , " & _
               "[Station_Size] Float , " & _
               "[FeedMode] Integer , " & _
               "[Workplane] TEXT(255) , " & _
               "[Show] LOGICAL , " & _
               "[CutSide] Integer , " & _
               "[Operation] TEXT(255) , " & _
               "[Model_ID] Integer , " & _
               "[Level] Float , " & _
               "[Distance] Float , " & _
               "[CutType] Integer , " & _
               "[Amperage] Float , " & _
               "[MaxPressure] Float , " & _
               "[CutQuality] Integer , " & _
               "[Plunge] Float , " & _
               "[SharpAngle] Float , " & _
               "[PrimaryCode] TEXT(255) , " & _
               "[SecondaryCode] TEXT(255))", connection)

            cmd.ExecuteNonQuery()

            'We need to set a relationship to the Sheet Results table.  The is for reporting
            'so that we can print only the tools for each sheet in the nest
            cmd.CommandText = "ALTER TABLE SheetTooling  ADD FOREIGN KEY (SheetID)  REFERENCES  [Sheet Result][(ID)]"

            cmd.ExecuteNonQuery()

            connection.Close()

        Catch ex As Exception

            MessageBox.Show("AddToolsToPDB: " & ex.Message)

        End Try


    End Sub
    Private Sub AddSettingsTableToPDB()
        Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & m_PDBFile)
        Dim sTablename As String = "NestSetup"
        Dim sql As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim sFieldName As String

        connection.Open()

        'Get database schema 
        Dim dbSchema As DataTable = connection.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, sTablename, "TABLE"})

        ' If the table exists, the count = 1 
        If dbSchema.Rows.Count > 0 Then

            ' do whatever you want to do if the table exists 
            Dim cmd2 As New OleDb.OleDbCommand("DROP TABLE NestSetup", connection)

            cmd2.ExecuteNonQuery()

        End If

        Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename & _
       "] ([ID] AUTOINCREMENT PRIMARY KEY  , " & _
       "[Workzone_Size] Float, " & _
       "[Reposition_Overlap] Float, " & _
       "[Short_Repo] TEXT(255), " & _
       "[Nest_Around_Clamps] TEXT(255), " & _
       "[Hold_Placement] TEXT(255), " & _
       "[Hold_Default_X] Float, " & _
       "[Hold_Default_Y] Float, " & _
       "[Clamp_1_Position] Float, " & _
       "[Clamp_2_Position] Float, " & _
       "[Clamp_3_Position] Float, " & _
       "[Clamp_4_Position] Float, " & _
       "[Left_Border] Float, " & _
       "[Right_Border] Float, " & _
       "[Top_Border] Float, " & _
       "[Bottom_Border] Float, " & _
       "[Remnant_Border] Float, " & _
       "[Part_Holes] TEXT(255), " & _
       "[Part_Kerf] TEXT(255), " & _
       "[Subs_Across_Sheets] Integer, " & _
       "[Template] TEXT(255), " & _
       "[Machine] TEXT(255), " & _
       "[Tool_Setup] TEXT(255), " & _
       "[Layer_Setup] TEXT(255), " & _
       "[Lead_Setup] TEXT(255), " & _
       "[Result_Path] TEXT(255), " & _
       "[Result_Name] TEXT(255), " & _
       "[Result_Digits] Integer, " & _
       "[Draw_While_Nesting] Integer, " & _
       "[Annotate_While_Nesting] Integer, " & _
       "[Minimum_Yield] Float, " & _
       "[Gap_Tolerance] Float, " & _
       "[Cut_Sheets] TEXT(255), " & _
       "[Pierce_Hole] TEXT(255), " & _
       "[Layers] TEXT(255), " & _
       "[Unused_Tools] TEXT(255), " & _
       "[Drop_Stop_Commands] TEXT(255), " & _
       "[Auto_Code] Integer, " & _
       "[Auto_Print] Integer, " & _
       "[Part_Labels] TEXT(255), " & _
       "[Label_Angle] Float, " & _
       "[Print_Label_Size] Float, " & _
       "[Labeling_Tool] TEXT(255), " & _
       "[Ordering] TEXT(255), " & _
       "[Pierce_Holes] TEXT(255), " & _
       "[Parts_In_Parts] TEXT(255), " & _
       "[Fill_Direction] TEXT(255), " & _
       "[Nesting_Start] TEXT(255), " & _
       "[Web_Size] Float, " & _
       "[Placement] TEXT(255), " & _
       "[Fill_Limit] TEXT(255), " & _
       "[Split_Patterns] TEXT(255), " & _
       "[Chain_Size] Integer, " & _
       "[Chain_Offset] Float, " & _
       "[Cut_Back_Tool] TEXT(255), " & _
       "[Repo_Mode] TEXT(255)) ", connection)

        cmd.ExecuteNonQuery()


        Sql = "SELECT * FROM Setup"

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(ds)

        oledbAdapter.Dispose()

        If (ds.Tables(0).Rows.Count > 0) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                sFieldName = Replace(ds.Tables(0).Rows(i).Item("DialogDisplay"), " ", "_")

                If (Not sFieldName.Contains("Yield") And Not sFieldName.Contains("Drop")) Then

                    If DoesFieldExist(m_PDBFile, "NestSetup", sFieldName) = False Then

                        cmd.CommandText = "ALTER TABLE [NestSetup] ADD [" & sFieldName & "] Text (255)"

                        cmd.ExecuteNonQuery()

                    End If

                End If

            Next

        End If


        ds.Dispose()
        oledbAdapter.Dispose()
        connection.Close()

        If ds IsNot Nothing Then ds = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

        If connection IsNot Nothing Then connection = Nothing

    End Sub
    Private Sub PopulateToolsTable(nSheetId As Integer)
        Dim m_cnTool As New OleDb.OleDbConnection
        Dim m_daTool As New OleDb.OleDbDataAdapter
        Dim m_dtTool As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim lCount As Long

        sFieldNames = sEmpty
        sFieldValues = sEmpty

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            m_cnTool = New OleDbConnection(connetionString)

            m_cnTool.Open()

            sFieldNames = "[Description]," & _
                             "[NC_Code_Number]," & _
                             "[Width_Diameter]," & _
                             "[Length]," & _
                             "[Loff]," & _
                             "[Doff]," & _
                             "[Radius]," & _
                             "[Angle]," & _
                             "[Shear]," & _
                             "[Cost]," & _
                             "[Life]," & _
                             "[FileName]," & _
                             "[Speed]," & _
                             "[Feed]," & _
                             "[Gas]," & _
                             "[Power]," & _
                             "[Type_Description]," & _
                             "[Type_ID]," & _
                             "[Frequency]," & _
                             "[Focus]," & _
                             "[Die_Clearance]," & _
                             "[Slowdown_Angle]," & _
                             "[Slowdown_Setback]," & _
                             "[Slowdown_Divisions]," & _
                             "[Slowdown_Formula]," & _
                             "[Corner_Radius]," & _
                             "[Diameter]," & _
                             "[Index_Angle]," & _
                             "[Kerf]," & _
                             "[Major_Diameter]," & _
                             "[Minor_Diameter]," & _
                             "[Pitch]," & _
                             "[Web]," & _
                             "[Auto_Index]," & _
                             "[Fixed_Station]," & _
                             "[Station_Location_X]," & _
                             "[Station_Location_Y]," & _
                             "[Station_Size]," & _
                             "[FeedMode]," & _
                             "[Workplane]," & _
                             "[Show]," & _
                             "[CutSide]," & _
                             "[Operation]," & _
                             "[Model_ID]," & _
                             "[Level]," & _
                             "[Distance]," & _
                             "[CutType]," & _
                             "[Amperage]," & _
                             "[MaxPressure]," & _
                             "[CutQuality]," & _
                             "[Plunge]," & _
                             "[SharpAngle]," & _
                             "[PrimaryCode]," & _
                             "[SecondaryCode]," & _
                             "[SheetID]"

            'NOTE: TODO: we need to check the fields defined as strings to
            ' output a Empty String if not defined

            For Each clsToolData In g_colToolSetup
                If (cePrintTools.CheckState = CheckState.Checked) Then
                    lReturn = PortalExecute("Entity:RefCnt: id=" + CStr(clsToolData.Model_ID))
                    lCount = PortalGetInt("count", 0)

                    If (lCount > 0) Then
                        sFieldValues = "'" & clsToolData.Description & "'," & _
                             clsToolData.NC_Code_Number & "," & _
                             clsToolData.Width_Diameter & "," & _
                             clsToolData.Length & "," & _
                             clsToolData.Loff & "," & _
                             clsToolData.Doff & "," & _
                             clsToolData.Radius & "," & _
                             clsToolData.Angle & "," & _
                             clsToolData.Shear & "," & _
                             clsToolData.Cost & "," & _
                             clsToolData.Life & "," & _
                            "'Filename'," & _
                             clsToolData.Speed & "," & _
                             clsToolData.Feed & "," & _
                             clsToolData.Gas & "," & _
                             clsToolData.Power & "," & _
                             "'" & clsToolData.Type_Description & "'," & _
                             clsToolData.Type_ID & "," & _
                             clsToolData.Frequency & "," & _
                             clsToolData.Focus & "," & _
                             clsToolData.Die_Clearance & "," & _
                             clsToolData.Slowdown_Angle & "," & _
                             clsToolData.Slowdown_Setback & "," & _
                             clsToolData.Slowdown_Divisions & "," & _
                             "'SlowDown Formula'," & _
                             clsToolData.Corner_Radius & "," & _
                             clsToolData.Diameter & "," & _
                             clsToolData.Index_Angle & "," & _
                             clsToolData.Kerf & "," & _
                             clsToolData.Major_Diameter & "," & _
                             clsToolData.Minor_Diameter & "," & _
                             clsToolData.Pitch & "," & _
                             clsToolData.Web & "," & _
                             clsToolData.Auto_Index & "," & _
                             clsToolData.Fixed_Station & "," & _
                             clsToolData.Station_Location_X & "," & _
                             clsToolData.Station_Location_Y & "," & _
                             clsToolData.Station_Size & "," & _
                             clsToolData.FeedMode & "," & _
                             "'" & clsToolData.Workplane & "'," & _
                             clsToolData.Show & "," & _
                             clsToolData.CutSide & "," & _
                             "'Operation'," & _
                             clsToolData.Model_ID & "," & _
                             clsToolData.Level & "," & _
                             clsToolData.Distance & "," & _
                             clsToolData.CutType & "," & _
                             clsToolData.Amperage & "," & _
                             clsToolData.MaxPressure & "," & _
                             clsToolData.CutQuality & "," & _
                             clsToolData.Plunge & "," & _
                             clsToolData.SharpAngle & "," & _
                             "'Primary'," & _
                             "'Secondary'," & _
                            CInt(nSheetId)


                        sql = "INSERT INTO [SheetTooling] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

                        m_daTool.InsertCommand = New OleDbCommand(sql, m_cnTool)

                        m_daTool.InsertCommand.ExecuteNonQuery()

                    End If

                Else
                    sFieldValues = "'" & clsToolData.Description & "'," & _
                         clsToolData.NC_Code_Number & "," & _
                         clsToolData.Width_Diameter & "," & _
                         clsToolData.Length & "," & _
                         clsToolData.Loff & "," & _
                         clsToolData.Doff & "," & _
                         clsToolData.Radius & "," & _
                         clsToolData.Angle & "," & _
                         clsToolData.Shear & "," & _
                         clsToolData.Cost & "," & _
                         clsToolData.Life & "," & _
                        "'Filename'," & _
                         clsToolData.Speed & "," & _
                         clsToolData.Feed & "," & _
                         clsToolData.Gas & "," & _
                         clsToolData.Power & "," & _
                         "'" & clsToolData.Type_Description & "'," & _
                         clsToolData.Type_ID & "," & _
                         clsToolData.Frequency & "," & _
                         clsToolData.Focus & "," & _
                         clsToolData.Die_Clearance & "," & _
                         clsToolData.Slowdown_Angle & "," & _
                         clsToolData.Slowdown_Setback & "," & _
                         clsToolData.Slowdown_Divisions & "," & _
                         "'SlowDown Formula'," & _
                         clsToolData.Corner_Radius & "," & _
                         clsToolData.Diameter & "," & _
                         clsToolData.Index_Angle & "," & _
                         clsToolData.Kerf & "," & _
                         clsToolData.Major_Diameter & "," & _
                         clsToolData.Minor_Diameter & "," & _
                         clsToolData.Pitch & "," & _
                         clsToolData.Web & "," & _
                         clsToolData.Auto_Index & "," & _
                         clsToolData.Fixed_Station & "," & _
                         clsToolData.Station_Location_X & "," & _
                         clsToolData.Station_Location_Y & "," & _
                         clsToolData.Station_Size & "," & _
                         clsToolData.FeedMode & "," & _
                         "'" & clsToolData.Workplane & "'," & _
                         clsToolData.Show & "," & _
                         clsToolData.CutSide & "," & _
                         "'Operation'," & _
                         clsToolData.Model_ID & "," & _
                         clsToolData.Level & "," & _
                         clsToolData.Distance & "," & _
                         clsToolData.CutType & "," & _
                         clsToolData.Amperage & "," & _
                         clsToolData.MaxPressure & "," & _
                         clsToolData.CutQuality & "," & _
                         clsToolData.Plunge & "," & _
                         clsToolData.SharpAngle & "," & _
                         "'Primary'," & _
                         "'Secondary'," & _
                        CInt(nSheetId)


                    sql = "INSERT INTO [SheetTooling] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

                    m_daTool.InsertCommand = New OleDbCommand(sql, m_cnTool)

                    m_daTool.InsertCommand.ExecuteNonQuery()

                End If

            Next


            m_daTool.Dispose()

            m_dtTool.Dispose()

            m_cnTool.Close()

        Catch ex As Exception

            MessageBox.Show("PopulateToolsTable: " & ex.Message)

        End Try
    End Sub

    Sub PopulateSettingsTable()
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim cmdGetID As New OleDbCommand
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim sTempFieldValue As String

        sFieldNames = sEmpty
        sFieldValues = sEmpty

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            sFieldNames = "[Workzone_Size], " & _
               "[Reposition_Overlap], " & _
               "[Short_Repo], " & _
               "[Nest_Around_Clamps], " & _
               "[Hold_Placement], " & _
               "[Hold_Default_X], " & _
               "[Hold_Default_Y], " & _
               "[Clamp_1_Position], " & _
               "[Clamp_2_Position], " & _
               "[Clamp_3_Position], " & _
               "[Clamp_4_Position], " & _
               "[Left_Border], " & _
               "[Right_Border], " & _
               "[Top_Border], " & _
               "[Bottom_Border], " & _
               "[Remnant_Border], " & _
               "[Part_Holes], " & _
               "[Part_Kerf], " & _
               "[Subs_Across_Sheets], " & _
               "[Template], " & _
               "[Machine], " & _
               "[Tool_Setup], " & _
               "[Layer_Setup], " & _
               "[Lead_Setup], " & _
               "[Result_Path], " & _
               "[Result_Name], " & _
               "[Result_Digits], " & _
               "[Draw_While_Nesting], " & _
               "[Annotate_While_Nesting], " & _
               "[Minimum_Yield], " & _
               "[Gap_Tolerance], " & _
               "[Cut_Sheets], " & _
               "[Pierce_Holes], " & _
               "[Layers], " & _
               "[Unused_Tools], " & _
               "[Drop_Stop_Commands], " & _
               "[Auto_Code], " & _
               "[Auto_Print], " & _
               "[Part_Labels], " & _
               "[Label_Angle], " & _
               "[Print_Label_Size], " & _
               "[Labeling_Tool], " & _
               "[Ordering], " & _
               "[Pierce_Hole], " & _
               "[Parts_In_Parts], " & _
               "[Fill_Direction], " & _
               "[Nesting_Start], " & _
               "[Web_Size], " & _
               "[Placement], " & _
               "[Fill_Limit], " & _
               "[Split_Patterns], " & _
               "[Chain_Size], " & _
               "[Chain_Offset], " & _
               "[Cut_Back_Tool], " & _
               "[Repo_Mode] "

            sFieldValues = cNestInfo.Workzone_Size & "," & _
            cNestInfo.Reposition_Overlap & ",'" & _
            cNestInfo.Short_Repo & "','" & _
            cNestInfo.Nest_Around_Clamps & "','" & _
            cNestInfo.Hold_Placement & "'," & _
            cNestInfo.Hold_Default_X & "," & _
            cNestInfo.Hold_Default_Y & "," & _
            cNestInfo.Clamp_1_Position & "," & _
            cNestInfo.Clamp_2_Position & "," & _
            cNestInfo.Clamp_3_Position & "," & _
            cNestInfo.Clamp_4_Position & "," & _
            cNestInfo.Left_Border & "," & _
            cNestInfo.Right_Border & "," & _
            cNestInfo.Top_Border & "," & _
            cNestInfo.Bottom_Border & "," & _
            cNestInfo.Remnant_Border & ",'" & _
            cNestInfo.Part_Holes & "','" & _
            cNestInfo.Part_Kerf & "'," & _
            cNestInfo.Subs_Across_Sheets & ",'" & _
            cNestInfo.Template & "','" & _
            cNestInfo.Machine & "','" & _
            cNestInfo.Tool_Setup & "','" & _
            cNestInfo.Layer_Setup & "','" & _
            cNestInfo.Lead_Setup & "','" & _
            cNestInfo.Result_Path & "','" & _
            cNestInfo.Result_Name & "'," & _
            cNestInfo.Result_Digits & "," & _
            cNestInfo.Draw_While_Nesting & "," & _
            cNestInfo.Annotate_While_Nesting & "," & _
            cNestInfo.Minimum_Yield & "," & _
            cNestInfo.Gap_Tolerance & ",'" & _
            cNestInfo.Cut_Sheets & "','" & _
            cNestInfo.Pierce_Holes & "','" & _
            cNestInfo.Layers & "','" & _
            cNestInfo.Unused_Tools & "','" & _
            cNestInfo.Drop_Stop_Commands & "'," & _
            cNestInfo.Auto_Code & "," & _
            cNestInfo.Auto_Print & ",'" & _
            cNestInfo.Part_Labels & "'," & _
            cNestInfo.Label_Angle & "," & _
            cNestInfo.Print_Label_Size & ",'" & _
            cNestInfo.Labeling_Tool & "','" & _
            cNestInfo.Ordering & "','" & _
            cNestInfo.Pierce_Hole & "','" & _
            cNestInfo.Parts_In_Parts & "','" & _
            cNestInfo.Fill_Direction & "','" & _
            cNestInfo.Nesting_Start & "'," & _
            cNestInfo.Web_Size & ",'" & _
            cNestInfo.Placement & "','" & _
            cNestInfo.Fill_Limit & "','" & _
            cNestInfo.Split_Patterns & "'," & _
            cNestInfo.Chain_Size & "," & _
            cNestInfo.Chain_Offset & ",'" & _
            cNestInfo.Cut_Back_Tool & "','" & _
            cNestInfo.Repo_Mode & "'"

            sql = "INSERT INTO [NestSetup] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.InsertCommand.ExecuteNonQuery()

            sql = "SELECT * FROM Setup"

            oledbAdapter = New OleDbDataAdapter(sql, m_cnSettings)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            If (ds.Tables(0).Rows.Count > 0) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    sFieldNames = Replace(ds.Tables(0).Rows(i).Item("DialogDisplay"), " ", "_")

                    sTempFieldValue = ds.Tables(0).Rows(i).Item("VBValue").ToString
                    If (UCase(sTempFieldValue) = "FALSE") Then
                        sTempFieldValue = 0
                    ElseIf (ucase(sTempFieldValue) = "TRUE") Then
                        sTempFieldValue = 1
                    End If

                    If (sTempFieldValue <> "" And sTempFieldValue IsNot Nothing) Then



                        If (Not sFieldNames.Contains("Yield") And Not sFieldNames.Contains("Drop") And Not sFieldNames.Contains("Draw_While") And Not sFieldNames.Contains("Annotate")) Then

                            sql = "UPDATE [NestSetup] set [NestSetup].[" & sFieldNames & "] = '" & sTempFieldValue & "'"

                            m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnSettings)

                            m_daSettings.InsertCommand.ExecuteNonQuery()

                        End If
                    End If
                Next

            End If

            m_daSettings.Dispose()

            m_cnSettings.Close()

            If m_daSettings IsNot Nothing Then m_daSettings = Nothing

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If m_cnSettings IsNot Nothing Then m_cnSettings = Nothing

        Catch ex As Exception

            MessageBox.Show("PopulateSettingsTable: " & ex.Message)

        End Try
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub bbiCSV_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCSV.ItemClick
        DropDownButton1.Text = "Send To: CSV"
        PrintToCSV()
    End Sub

    Private Sub bbiHTML_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiHTML.ItemClick
        DropDownButton1.Text = "Send To: HTML"
        PrintToHTML()
    End Sub

    Private Sub bbiIMAGE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiIMAGE.ItemClick
        DropDownButton1.Text = "Send To: Image"
        PrtintToImage()
    End Sub

    Private Sub bbiPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPDF.ItemClick
        DropDownButton1.Text = "Send To: PDF"
        PrintToPDF()
    End Sub

    Private Sub bbiPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPreview.ItemClick
        DropDownButton1.Text = "Send To: Preview"
        PrintPreview()
    End Sub

    Private Sub bbiPrinter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPrinter.ItemClick
        DropDownButton1.Text = "Send To: Printer"
        PrintToPrinter()
    End Sub

    Private Sub bbiRTF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRTF.ItemClick
        DropDownButton1.Text = "Send To: RTF"
        PrintToRTF()
    End Sub

    Private Sub bbiTEXT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiTEXT.ItemClick
        DropDownButton1.Text = "Send To: Text"
        PrintToText()
    End Sub

    Private Sub bbiXLS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiXLS.ItemClick
        DropDownButton1.Text = "Send To: XLS"
        PrintToXLS()
    End Sub

    Private Sub bbiXLSX_ItemClick1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiXLSX.ItemClick
        DropDownButton1.Text = "Send To: XLSX"
        PrintToXLSX()
    End Sub

    Private Sub DropDownButton1_Click(sender As Object, e As EventArgs) Handles DropDownButton1.Click

        frmMain.pnlNestCombos.Visible = False
        'frmMain.TopMost = True
        'MessageBox.Show("The version number is < " & Application.ProductVersion & ">")
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

                PrtintToImage()

            Case "SEND TO: TEXT"

                PrintToText()

        End Select
        'frmMain.TopMost = False
        frmMain.pnlNestCombos.Visible = True

    End Sub


    Private Function GetMaterialTypeFromSheetResults(m_SheetID As Integer) As String

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        GetMaterialTypeFromSheetResults = Nothing 'assume failure

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & m_PDBFile & "';"

            sql = "Select [Sheet Result].* From [Sheet Result] Where ([Sheet Result].ID = " & m_SheetID & " )"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then

                'GetMaterialTypeFromSheetResults = CInt(ds.Tables(0).Rows(0).Item("MaterialType").ToString)
                GetMaterialTypeFromSheetResults = HeaderStringGet("MatCatName", "")

            End If

            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetMaterialTypeFromSheetResults " & ex.Message)

        End Try

    End Function


End Class