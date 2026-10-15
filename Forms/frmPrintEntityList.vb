Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.XtraBars
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
Imports DevExpress.XtraTreeList.Nodes
Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Text



Public Class frmPrintEntityList
    Inherits DevExpress.XtraEditors.XtraForm

    Private m_EntityInfo As New List(Of clsEntList)
    Private CFG_ROOT_NODE = Nothing
    'Private m_multiTip As clsMultiTip
    Dim bUserClick As Boolean
    Private m_is_active As Boolean

    ''Stores the information for which part is nested on whihc sheet. this can be a 1 to many
    'Private m_EntityInfo As New System.Collections.Generic.List(Of PrintEntList)
    'Private m_EntityInfo As New System.Collections.Generic.List(Of PrnEntityList)

    ''Stores the information for each part to be nested


    Private sSendTo As String

    Dim sTemplate As String
    Public OutputMode As Long
    Protected Overloads Overrides Sub WndProc(ByRef m As Message)

        '//Prevent the user from moving the form

        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_MOVE) Then
            Exit Sub
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32() = HTCAPTION) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub
    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
        'IsActive = True
    End Function

    Public Sub New()
        Dim white_background As Long

        m_is_active = False

        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        m_is_active = True


        m_bg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.White)
        m_fg_color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.Black)

    End Sub

    Private Sub DesignPanelLoaded(sender As Object, e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)

        Try
            Dim src As New BindingSource
            src.DataSource = BindToData()


            CType(sender, XRDesignPanel).Report.DataSource = src

            e.DesignerHost.Container.Add(src, "StandardProps")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Sub beTemplate_Click(sender As Object, e As EventArgs) Handles beTemplate.Click
        Dim sInitDir As String

        Try

            Dim sTemplate_FileOpen As New OpenFileDialog

            sInitDir = RegGetString("Printing", "PrintEntityListTemplate", NormalizePath(App_Path) & "Report Templates")

            If (sInitDir = "") Then

                sInitDir = NormalizePath(App_Path) & "Report Templates"

            End If

            sTemplate_FileOpen.Filter = "Entity List Report files (*.elrep)|*.elrep"
            sTemplate_FileOpen.FilterIndex = 1

            sTemplate_FileOpen.InitialDirectory = sInitDir

            If sTemplate_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sTemplate = sTemplate_FileOpen.FileName
                beTemplate.Text = sTemplate

                beTemplate.ToolTip = sTemplate

            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub sbEdit_Click(sender As Object, e As EventArgs) Handles sbEdit.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.Extension = ".elrep"
            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = App_Path & "\Report Templates"

            report.LoadLayout(beTemplate.Text)

            ' Force the report creation without previously 
            ' requesting the parameter value from end-users.
            report.RequestParameters = False
            'GetCG_VArs(report)

            ' Open the report in the End-User Designer. 
            Dim Tool As ReportDesignTool = New ReportDesignTool(report)

            AddHandler Tool.DesignForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignPanelLoaded

            Windows.Forms.Cursor.Current = Cursors.Default

            Tool.ShowDesigner()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try


    End Sub

    Private Sub frmPrintEntityList_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        m_is_active = False

        frmMain.CloseFirstPanel()
        'm_multiTip = Nothing

    End Sub

    Public Sub FillTreeViewold(Optional sFilter As String = "")
        Dim lCount As Long
        Dim Count As Long
        Dim entityID As Long
        Dim entitytype
        Dim lId As Long
        Dim lColor As Long
        Dim lParentID As Long
        Dim sParentName As String
        Dim sName As String
        Dim lToolID As Long
        Dim sLayerName As String
        Dim objNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim objParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim sReportResult As String

        sReportResult = Application.StartupPath & "\Database\ENtityList.txt"

        Dim sw As New System.IO.StreamWriter(sReportResult, True)

        Try
            sReportResult = Application.StartupPath & "\Database\ENtityList.txt"

            ConditionalFileDelete(sReportResult)

            If Not Me.Visible Then Exit Sub

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            ' Getting the number of entities
            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            ' initialize the filter combobox
            'bUserClick = False ' disable "normal" processing

            For lCounter = 0 To (lCount - 1)
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                sw.WriteLine("ID = " & lId)

                If lId <= 0 Then GoTo skip ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)

                sw.WriteLine("color = " & lColor)

                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID

                sParentName = EntityStringGet(lParentID, "Name", "<error>")

                sw.WriteLine("The Parent Name is " & sParentName)

                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any
                sLayerName = EntityStringGet(lToolID, "Name", "<error>")

                sw.WriteLine("Tool/LayerID = " & lToolID & " The Name is " & sLayerName)

                lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                Count = PortalGetInt("count", 0)

                If (Count > 0) Then 'We check the child entities to see if they are part of the table graphics

                    lReturn = PortalExecute(
                                "*Entity:Container:Get:" &
                                " id=" & lId &
                                ",index=1")
                    sLayerName = EntityStringGet(lId, "Name", "<error>")

                    entityID = PortalGetInt("id", 0)
                    entitytype = GetEntityType(entityID)
                    lReturn = PortalExecute("*create:extract:id=" & entityID)

                    lToolID = PortalGetInt("toolid", 0)

                    sw.WriteLine("Tool/LayerID = " & lToolID & " The Name is " & sLayerName)

                    lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                End If

                sLayerName = EntityStringGet(lToolID, "Name", "<error>")
                lColor = EntityIntGet(lId, "color", 16711680)


                If (sLayerName = "TableGraphics") Then GoTo skip 'We do not want to show tablegrahics in the list

                sName = GetDisplayName(lId)

                If sName = "Line" Then
                    Dim gary As Integer = 1
                End If
                ' does the filter entry already exist?
                If Not CheckEntryToList(sName, cbeEntityList) Then
                    cbeEntityList.Properties.Items.Add(sName)
                End If

                If (lColor = 0) Then
                    lColor = m_fg_color

                End If
                If (sName.Contains("Empty") = True) Then
                    'GoTo skip
                    lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & lId)
                    'lReturn = PortalExecute("Zone:Update: id=" & lId & ",delete=1")
                    'lReturn = PortalExecute("Create:Delete: id=" & lId)
                End If


                ' does the filter allow the addition of this entity?
                If Len(sFilter) = 0 Or
                    sFilter = sName Or
                        sFilter = "Everything" Or
                        (sFilter = "Toolpath" And lToolID > 0) Then

                    If (sName <> "Feature(Empty)") Then
                        ' add entity to treeview
                        'objParentNode = tvwEntityList.FindNodeByFieldValue(tvwEntityList.Columns(1).FieldName, lParentID)

                        If lParentID > 0 Then

                            'objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, objParentNode.Id, lColor}, objParentNode.Id, "uid_" & CStr(lId))

                            sw.WriteLine(sName, lId, lParentID, objParentNode.Id, lColor, objParentNode.Id, "uid_" & CStr(lId))

                        Else

                            ' objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, 0, lColor}, -1, "uid_" & CStr(lId))

                            sw.WriteLine(sName, lId, lParentID, 0, lColor, -1, "uid_" & CStr(lId))

                        End If
                    Else
                        'we do not want any empty features so we delte them to be sure
                        lReturn = PortalExecute("Create:Delete: id=" & lId)

                    End If

                End If
skip:

            Next

            sw.Close()

        Catch ex As Exception
            MessageBox.Show("FillTreView: " & ex.Message)
        End Try
    End Sub

    Private Sub SelectNodes()

        Dim entityID As Long
        Dim etype As Long = 0
        Dim my_node As TreeListNode = Nothing
        Dim node As TreeListNode


        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            'For Each node In tvwEntityList.Nodes

            '    entityID = node.GetValue("currID")

            '    node.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

            '    If node.HasChildren = True Then

            '        For Each child As TreeListNode In node.Nodes

            '            entityID = child.GetValue("currID")

            '            child.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

            '            If child.HasChildren = True Then

            '                For Each childSubNode As TreeListNode In child.Nodes

            '                    entityID = childSubNode.GetValue("currID")

            '                    childSubNode.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

            '                    If childSubNode.HasChildren = True Then

            '                        For Each childSub2Node As TreeListNode In childSubNode.Nodes

            '                            entityID = childSub2Node.GetValue("currID")

            '                            childSub2Node.CheckState = IIf((IsSelected(entityID) = True), 1, 0)

            '                        Next

            '                    End If
            '                Next

            '            End If

            '        Next

            '    End If

            'Next node



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub frmPrintEntityList_Load(sender As Object, e As EventArgs) Handles Me.Load

        OutputMode = CLng(RegGetString("Printing", "PrintEntListSendTo", 0))
        sTemplate = RegGetString("Printing", "PrintEntListTemplate", "")

        Select Case OutputMode

            Case PRINT_MODE.TO_PRINTER

                DropDownButton1.Text = "Send To: Printer"
                sSendTo = "Printer"

            Case PRINT_MODE.TO_PREVIEW

                DropDownButton1.Text = "Send To: Preview"
                sSendTo = "Preview"

            Case PRINT_MODE.TO_HTML

                DropDownButton1.Text = "Send To: HTML"
                sSendTo = "HTML"

            Case PRINT_MODE.TO_PDF

                DropDownButton1.Text = "Send To: PDF"
                sSendTo = "PDF"

            Case PRINT_MODE.TO_RTF
                DropDownButton1.Text = "Send To: RTF"
                sSendTo = "RTF"

            Case PRINT_MODE.TO_XLS

                DropDownButton1.Text = "Send To: XLS"
                sSendTo = "XLS"

            Case PRINT_MODE.TO_XLSX

                DropDownButton1.Text = "Send To: XLSX"
                sSendTo = "XLSX"

            Case PRINT_MODE.TO_CSV

                DropDownButton1.Text = "Send To: CSV"
                sSendTo = "CSV"

            Case PRINT_MODE.TO_IMAGE

                DropDownButton1.Text = "Send To: Image"
                sSendTo = "Image"

            Case PRINT_MODE.TO_TEXT

                sSendTo = "Text"

        End Select

        DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.Extension = ".mlst"
        DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = Application.StartupPath

        beTemplate.Text = sTemplate

        'sTemplate = RegGetString("Printing", "PrintNestTemplate", "")

        If (FileExists(sTemplate) = False) Then

            MessageBox.Show("Report  Template < " & sTemplate & " > Does Not Exisit. Please Select a Template")
            sTemplate = NormalizePath(App_Path) & "Report Templates\"

        End If


        beTemplate.ToolTip = sTemplate

        DropDownButton1.Text = "Send To: " & sSendTo



        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub InitFilterCombo()

        ' Clearing the combobox
        cbeEntityList.Properties.Items.Clear()
        cbeEntityList.Properties.Items.Add("Everything")
        cbeEntityList.Properties.Items.Add("Toolpath")
        cbeEntityList.SelectedIndex = 0

    End Sub

    Private Sub cbeEntityList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeEntityList.SelectedIndexChanged
        'If bUserClick Then FillEntityData(cbeEntityList.EditValue)
    End Sub

    Private Function BindToData() As DataSet

        BindToData = Nothing

        DB_PATH = App_Path & "\Database\EntList.mdb"

        'If (FileExists(DB_Path)) Then
        '    Kill(DB_Path)
        'End If

        'CreateDb(DB_PATH)

        'CreateTable(DB_PATH, "StandardProps", "FooBar")



        Gary()
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & DB_PATH & "';"

        sql = "Select StandardProps.* From StandardProps"

        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        ds.DataSetName = "Entity List"

        oledbAdapter.Fill(ds)

        ds.Tables(0).TableName = "StandardProps"

        Return ds



        Try


            '    connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & DB_PATH & "';"

            'sql = "Select StandardProps.* From StandardProps"

            'connection = New OleDbConnection(connetionString)

            'connection.Open()

            'oledbAdapter = New OleDbDataAdapter(sql, connection)
            'oledbAdapter.Fill(ds)

            ds.DataSetName = "StandardProps"

            connection.Close()

            Return ds

            oledbAdapter.Dispose()
            ds.Dispose()
        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try

    End Function
    Private Sub FillEntityData2()
        Dim lCount As Long
        Dim Count As Long
        Dim entityID As Long
        Dim entitytype
        Dim lId As Long
        Dim lColor As Long
        Dim lParentID As Long
        Dim sName As String
        Dim lToolID As Long
        Dim sLayerName As String
        Dim objNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim objParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim sReportResult As String
        Dim sText As String
        Dim cmdGetID As New OleDbCommand
        Dim sql As String
        Dim nID As Integer
        Dim sFilter As String
        Dim connectionParameters As New Access97ConnectionParameters(DB_PATH, "", "")
        Dim m_cnEntityData As New OleDb.OleDbConnection
        Dim m_daEntityData As OleDb.OleDbDataAdapter
        Dim m_cbEntityData As OleDb.OleDbCommandBuilder
        Dim m_dtEntityData As New DataTable

        Dim sField As String
        Dim sValue As String
        Dim lZone As Integer
        Dim lType As Long
        Dim wzone As Long
        Dim spieces() As String

        Try
            sFilter = ""

            sql = "SELECT [StandardProps].* FROM [StandardProps]"

            m_cnEntityData.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DB_PATH
            m_cnEntityData.Open()
            m_daEntityData = New OleDb.OleDbDataAdapter(sql, m_cnEntityData)
            m_cbEntityData = New OleDb.OleDbCommandBuilder(m_daEntityData)
            m_daEntityData.Fill(m_dtEntityData)

            sReportResult = Application.StartupPath & "\Database\ENtityList.txt"

            ConditionalFileDelete(sReportResult)

            Dim sw As New System.IO.StreamWriter(sReportResult, True)

            If Not Me.Visible Then Exit Sub

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            ' Getting the number of entities
            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            For lCounter = 0 To (lCount - 1)
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip ' this should never be, but...

                sText = GetDisplayName(lId)
                sField = "_entname"
                sValue = "'" & sText & "'"

                sw.WriteLine("[Name=] [" & sText & "]")

                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity

                lColor = EntityIntGet(lId, "color", 16711680)

                sw.WriteLine("Color=" & lColor)

                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID

                lType = PortalGetInt("type", c_INVALID) ' Type: Line, Arc, Hole, Point
                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any
                sText = PortalGetString("Name", "")

                Dim drNewRow As DataRow = m_dtEntityData.NewRow()


                sReturn = GetDisplayName(lId)
                drNewRow("_entname") = sReturn
                drNewRow("_ps_entityID") = lId

                lType = PortalGetInt("type", -1)
                'wzone = PortalGetInt("_zone_num", -1)
                spieces = Split(sReturn, " ")

                If (spieces.Length) > 1 Then
                    wzone = spieces(1)
                Else
                    wzone = -1
                End If

                sText = "ID:" & lId

                m_EntityInfo.Add(New clsEntList() With {._entID = lId,
                                                        ._entname = sText,
                                                        ._tool = lToolID,
                                                        ._workzone = wzone,
                                                        ._enttype = GetEntityType(lId)})


                lColor = EntityIntGet(lId, "color", 16711680)

                sw.WriteLine("Color=" & lColor)

                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any
                sText = PortalGetString("Name", "")

                drNewRow("_OwnerID") = lParentID

                sw.WriteLine("owner=" & lParentID)

                sw.WriteLine("toolid=" & lToolID)

                lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                sw.WriteLine("Name2=" & sText)

                Count = PortalGetInt("count", 0)

                If (Count > 0) Then 'We check the child entities to see if they are part of the table graphics

                    lReturn = PortalExecute(
                                "*Entity:Container:Get:" &
                                " id=" & lId &
                                ",index=1")
                    entityID = PortalGetInt("id", 0)
                    entitytype = GetEntityType(entityID)
                    lReturn = PortalExecute("*create:extract:id=" & entityID)

                    lToolID = PortalGetInt("toolid", 0)

                End If

                sLayerName = EntityStringGet(lToolID, "Name", "<error>")

                sw.WriteLine("Tool/Layer Name=" & sLayerName)

                drNewRow("_toolDescrip") = sLayerName

                lColor = EntityIntGet(lId, "color", 16711680)

                sw.WriteLine("Color=" & lColor)


                If (sLayerName = "TableGraphics") Then GoTo skip 'We do not want to show tablegrahics in the list

                sName = GetDisplayName(lId)

                If sName = "Line" Then
                    Dim gary As Integer = 1
                End If
                ' does the filter entry already exist?
                If Not CheckEntryToList(sName, cbeEntityList) Then
                    cbeEntityList.Properties.Items.Add(sName)
                End If

                If (lColor = 0) Then
                    lColor = m_fg_color

                End If
                If (sName.Contains("Empty") = True) Then
                    'GoTo skip
                    lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & lId)

                End If


                ' does the filter allow the addition of this entity?
                If Len(sFilter) = 0 Or
                    sFilter = sName Or
                        sFilter = "Everything" Or
                        (sFilter = "Toolpath" And lToolID > 0) Then

                    If (sName <> "Feature(Empty)") Then
                        ' add entity to treeview
                        ''objParentNode = tvwEntityList.FindNodeByFieldValue(tvwEntityList.Columns(1).FieldName, lParentID)

                        If objParentNode IsNot Nothing Then

                            sw.WriteLine("sName=" & sName & ", lid=" & lId & ",lparentid = " & lParentID & " objparentnod = " & objParentNode.Id & ",COlor=" & lColor)

                            'objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, objParentNode.Id, lColor}, objParentNode.Id, "uid_" & CStr(lId))

                        Else

                            'objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, 0, lColor}, -1, "uid_" & CStr(lId))
                            sw.WriteLine("sName=" & sName & ", lid=" & lId & ",lparentid = " & lParentID & " objparentnod = 0,COlor=" & lColor)

                        End If
                    Else
                        'we do not want any empty features so we delte them to be sure
                        lReturn = PortalExecute("Create:Delete: id=" & lId)

                    End If

                End If

                m_dtEntityData.Rows.Add(drNewRow)
                m_daEntityData.Update(m_dtEntityData)
skip:

            Next

            sw.Close()



            m_dtEntityData.Dispose()
            m_daEntityData.Dispose()

            m_cnEntityData.Close()

            If m_daEntityData IsNot Nothing Then m_daEntityData = Nothing

            If m_dtEntityData IsNot Nothing Then m_dtEntityData = Nothing



        Catch ex As Exception
            MessageBox.Show("FillData2: " & ex.Message)
        End Try
    End Sub

    Private Sub DropDownButton1_Click(sender As Object, e As EventArgs) Handles DropDownButton1.Click

        Try
            'ExecuteBtnClick()

            frmMain.pnlNestCombos.Visible = False


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

            frmMain.pnlNestCombos.Visible = True



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try


    End Sub

    Private Sub PrintPreview()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            Tool.PreviewForm.PrintBarManager.AllowQuickCustomization = False
            Tool.PreviewForm.ShowInTaskbar = False

            Tool.ShowPreviewDialog()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PREVIEW

            Tool.Report.ClosePreview()
            Tool.Dispose()

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try

    End Sub

    Private Sub FillEntityData()
        Dim lCount As Long
        Dim Count As Long
        Dim entityID As Long
        Dim entitytype
        Dim lId As Long
        Dim lColor As Long
        Dim lParentID As Long
        Dim sName As String
        Dim lToolID As Long
        Dim sLayerName As String
        Dim objNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim objParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim sReportResult As String
        Dim sText As String
        Dim cmdGetID As New OleDbCommand
        'Dim m_daEntityData As New OleDb.OleDbDataAdapter
        Dim sql As String
        Dim nID As Integer
        Dim sFilter As String
        Dim connectionParameters As New Access97ConnectionParameters(DB_PATH, "", "")
        'Dim ds As New SqlDataSourcDim ds As New DataSet
        ' Dim connection As OleDbConnection
        Dim m_cnEntityData As New OleDb.OleDbConnection
        Dim m_daEntityData As OleDb.OleDbDataAdapter
        Dim m_cbEntityData As OleDb.OleDbCommandBuilder
        Dim m_dtEntityData As New DataTable
        Dim drNewRow As DataRow = m_dtEntityData.NewRow()
        Dim sField As String
        Dim sValue As String
        Dim lType As Long
        Dim wzone As Long




        Try
            sFilter = ""

            sql = "SELECT [StandardProps].* FROM [StandardProps]"

            m_cnEntityData.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DB_PATH
            m_cnEntityData.Open()
            m_daEntityData = New OleDb.OleDbDataAdapter(sql, m_cnEntityData)
            m_cbEntityData = New OleDb.OleDbCommandBuilder(m_daEntityData)
            m_daEntityData.Fill(m_dtEntityData)

            sReportResult = Application.StartupPath & "\Database\ENtityList.txt"

            ConditionalFileDelete(sReportResult)

            Dim sw As New System.IO.StreamWriter(sReportResult, True)

            If Not Me.Visible Then Exit Sub

            Windows.Forms.Cursor.Current = Cursors.WaitCursor


            ' Getting the number of entities
            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            ' initialize the filter combobox
            'bUserClick = False ' disable "normal" processing

            For lCounter = 0 To (lCount - 1)
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID
                sText = GetDisplayName(lId)
                sField = "_entname"
                sValue = "'" & sText & "'"

                sw.WriteLine("[Name=] [" & sText & "]")

                drNewRow("_entname") = sText
                drNewRow("_ent_ID") = lId

                m_EntityInfo.Add(New clsEntList() With {._ps_x = sText,
                                                        ._entname = sText})

                If lId <= 0 Then GoTo skip ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)

                sw.WriteLine("Color=" & lColor)

                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any
                sText = PortalGetString("Name", "")

                lType = PortalGetInt("type", -1)
                wzone = PortalGetInt("wz", -1)

                sText = "ID:" & lId

                drNewRow("_OwnerID") = lParentID

                sw.WriteLine("owner=" & lParentID)

                sw.WriteLine("toolid=" & lToolID)

                lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                sw.WriteLine("Name2=" & sText)

                Count = PortalGetInt("count", 0)

                If (Count > 0) Then 'We check the child entities to see if they are part of the table graphics

                    lReturn = PortalExecute(
                                "*Entity:Container:Get:" &
                                " id=" & lId &
                                ",index=1")
                    entityID = PortalGetInt("id", 0)
                    entitytype = GetEntityType(entityID)
                    lReturn = PortalExecute("*create:extract:id=" & entityID)

                    lToolID = PortalGetInt("toolid", 0)

                End If

                sLayerName = EntityStringGet(lToolID, "Name", "<error>")

                sw.WriteLine("Tool/Layer Name=" & sLayerName)

                drNewRow("_toolDescrip") = sLayerName

                lColor = EntityIntGet(lId, "color", 16711680)

                sw.WriteLine("Color=" & lColor)


                If (sLayerName = "TableGraphics") Then GoTo skip 'We do not want to show tablegrahics in the list

                sName = GetDisplayName(lId)

                If sName = "Line" Then
                    Dim gary As Integer = 1
                End If
                ' does the filter entry already exist?
                If Not CheckEntryToList(sName, cbeEntityList) Then
                    cbeEntityList.Properties.Items.Add(sName)
                End If

                If (lColor = 0) Then
                    lColor = m_fg_color

                End If
                If (sName.Contains("Empty") = True) Then
                    'GoTo skip
                    lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & lId)

                End If


                ' does the filter allow the addition of this entity?
                If Len(sFilter) = 0 Or
                    sFilter = sName Or
                        sFilter = "Everything" Or
                        (sFilter = "Toolpath" And lToolID > 0) Then

                    If (sName <> "Feature(Empty)") Then
                        ' add entity to treeview
                        ''objParentNode = tvwEntityList.FindNodeByFieldValue(tvwEntityList.Columns(1).FieldName, lParentID)

                        If objParentNode IsNot Nothing Then

                            sw.WriteLine("sName=" & sName & ", lid=" & lId & ",lparentid = " & lParentID & " objparentnod = " & objParentNode.Id & ",COlor=" & lColor)

                            'objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, objParentNode.Id, lColor}, objParentNode.Id, "uid_" & CStr(lId))

                        Else

                            'objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, 0, lColor}, -1, "uid_" & CStr(lId))
                            sw.WriteLine("sName=" & sName & ", lid=" & lId & ",lparentid = " & lParentID & " objparentnod = 0,COlor=" & lColor)

                        End If
                    Else
                        'we do not want any empty features so we delte them to be sure
                        lReturn = PortalExecute("Create:Delete: id=" & lId)

                    End If

                End If

                m_dtEntityData.Rows.Add(drNewRow)
                m_daEntityData.Update(m_dtEntityData)
skip:

            Next

            sw.Close()



            m_dtEntityData.Dispose()
            m_daEntityData.Dispose()

            m_cnEntityData.Close()

            If m_daEntityData IsNot Nothing Then m_daEntityData = Nothing

            If m_dtEntityData IsNot Nothing Then m_dtEntityData = Nothing

        Catch ex As Exception
            MessageBox.Show("FillTreView: " & ex.Message)
        End Try
    End Sub

    Private Sub frmPrintEntityList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sReturn = RegPutString("Printing", "PrintEntityListSendTo", OutputMode)
        sReturn = RegPutString("Printing", "PrintEntityListTemplate", beTemplate.Text)

    End Sub

    Private Sub beTemplate_TextChanged(sender As Object, e As EventArgs) Handles beTemplate.TextChanged
        'FillEntityData()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'Dim sw As StreamWriter
        'Dim sr As New StreamReader
        Dim swFilename As String
        Dim srFilename As String
        Dim sLine As String
        Dim spieces() As String
        Dim sVarname As String
        Dim nVarType As String

        swFilename = Application.StartupPath & "\clsEntityList.vb"
        srFilename = Application.StartupPath & "\Constant_Vars.txt"

        ConditionalFileDelete(swFilename)

        Dim sw As New StreamWriter(Application.StartupPath & "\clsEntityList.vb", True)

        Using sr As New StreamReader(srFilename)

            sLine = sr.ReadLine()

            While (sr.EndOfStream = False)

                sLine = sr.ReadLine()
                sLine = Trim(sLine)
                spieces = Split(sLine, " ")

                If spieces.Count = 4 Then
                    sVarname = Mid(spieces(1), 2)

                    sw.WriteLine(“    Private Property “ & sVarname & “ As “ & spieces(3))
                    sw.WriteLine(“        Get”)
                    sw.WriteLine(“            Return “ & spieces(1))
                    sw.WriteLine(“        End Get”)
                    sw.WriteLine(“")
                    sw.WriteLine(“        Set(value As “ & spieces(3) & ")")
                    sw.WriteLine(“            “ & spieces(1) & “ = value”)
                    sw.WriteLine(“        End Set”)
                    sw.WriteLine(“    End Property”)
                    sw.WriteLine(“")

                End If

            End While

            sr.Close()
            sr.Dispose()
            sw.Close()
            sw.Dispose()
        End Using


    End Sub

    Private Sub PrintToPrinter()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            report.RequestParameters = True

            report.CreateDocument() '<--this will open the parameter values input form

            Tool.PrintDialog()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PRINTER

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToHTML()
        Dim src As New BindingSource
        Dim src1 As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            dlgPrintSave.Filter = "HTML Files (*.html)|*.html"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            Dim reportPath As String = dlgPrintSave.FileName

            src.DataSource = m_EntityInfo

            ' Create a report instance.
            Dim report As New repPrintGraphics()
            report.LoadLayout(beTemplate.Text)

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)


            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            ' Get its HTML export options.
            Dim htmlOptions As HtmlExportOptions = report.ExportOptions.Html

            ' Set HTML-specific export options.
            htmlOptions.CharacterSet = "UTF-8"
            htmlOptions.TableLayout = False
            htmlOptions.RemoveSecondarySymbols = False
            htmlOptions.Title = "WE-CIM Entity List Report"

            ' Set the pages to be exported, and page-by-page options.
            htmlOptions.ExportMode = HtmlExportMode.SingleFilePageByPage
            htmlOptions.PageBorderColor = Color.Blue
            htmlOptions.PageBorderWidth = 3

            ' Export the report to HTML.
            report.ExportToHtml(reportPath)

            OutputMode = PRINT_MODE.TO_HTML

            StartProcess(reportPath)

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToPDF()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo


            dlgPrintSave.Filter = "PDF Files (*.pdf)|*.pdf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)


            ' Get its PDF export options.
            Dim pdfOptions As PdfExportOptions = report.ExportOptions.Pdf

            ' Set PDF-specific export options.
            pdfOptions.Compressed = True
            pdfOptions.ImageQuality = PdfJpegImageQuality.Highest
            pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New"
            pdfOptions.DocumentOptions.Application = "WE-CIM Advanced Fabrication Application"
            pdfOptions.DocumentOptions.Author = "Wittlock Engineering LLC"
            pdfOptions.DocumentOptions.Subject = "WE-CIM Entity List Report"
            pdfOptions.DocumentOptions.Title = "WE-CIM Entity List Report"

            report.RequestParameters = True

            Dim tool As New ReportPrintTool(report)
            report.CreateDocument()

            ' Export the report to PDF.
            report.ExportToPdf(reportPath)

            OutputMode = PRINT_MODE.TO_PDF

            Windows.Forms.Cursor.Current = Cursors.Default

            StartProcess(reportPath)


        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToRTF()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            dlgPrintSave.Filter = "RTF Files (*.rtf)|*.rtf"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)


            ' Export the report to RTF.
            report.ExportToRtf(reportPath)

            OutputMode = PRINT_MODE.TO_RTF

            Windows.Forms.Cursor.Current = Cursors.Default

            ' Show the result.
            StartProcess(reportPath)


        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToXLS()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            dlgPrintSave.Filter = "XLS Files (*.xls)|*.xls"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            ' Get its XLS export options.
            Dim xlsOptions As XlsExportOptions = report.ExportOptions.Xls

            ' Set XLS-specific export options.
            xlsOptions.ShowGridLines = True
            xlsOptions.TextExportMode = TextExportMode.Value

            ' Export the report to XLS.
            report.ExportToXls(reportPath)

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_XLS

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub

    Private Sub PrintToXLSX()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            dlgPrintSave.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

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

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToCSV()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            dlgPrintSave.Filter = "CSV Files (*.csv)|*.csv"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            'detailReportBand.DataSource = src

            ' Get its CSV export options.
            Dim csvOptions As CsvExportOptions = report.ExportOptions.Csv

            ' Set CSV-specific export options.
            csvOptions.Encoding = Encoding.Unicode
            csvOptions.Separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString()

            ' Export the report to CSV.
            report.ExportToCsv(reportPath)

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_CSV

            StartProcess(reportPath)
        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToImage()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            dlgPrintSave.Filter = "PNG Files (*.png)|*.png"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()
            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            ' Create a report. 
            report.DataSource = src

            report.LoadLayout(beTemplate.Text)


            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

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

            OutputMode = PRINT_MODE.TO_PREVIEW

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub


    Private Sub PrintToText()
        Dim src As New BindingSource

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            src.DataSource = m_EntityInfo

            dlgPrintSave.Filter = "TXT Files (*.txt)|*.txt"
            dlgPrintSave.FilterIndex = 0

            dlgPrintSave.ShowDialog()

            ' Create a report instance.
            Dim report As New repPrintGraphics()

            report.LoadLayout(beTemplate.Text)

            ' A path to export a report.
            Dim reportPath As String = dlgPrintSave.FileName

            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "StandardProps"

            Dim detailReportBand As DetailReportBand = DirectCast(report.FindControl("DetailReport", False), DetailReportBand)

            ' Show the report's preview. 
            Dim Tool As ReportPrintTool = New ReportPrintTool(report)

            report.RequestParameters = True

            report.CreateDocument() '<--this will open the parameter values input form

            Tool.PrintDialog()

            Windows.Forms.Cursor.Current = Cursors.Default

            OutputMode = PRINT_MODE.TO_PREVIEW

        Catch ex As Exception

            MessageBox.Show("PrintPreview: " & ex.Message)

        End Try


    End Sub

    Private Sub bbiPDF_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPDF.ItemClick

        PrintToPDF()
        DropDownButton1.Text = "SEND TO: PDF"
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

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        sReturn = RegPutString("Printing", "PrintEntListSendTo", OutputMode)
        sReturn = RegPutString("Printing", "PrintEntListTemplate", sTemplate)
    End Sub

    Private Sub PopupMenu1_CloseUp(sender As Object, e As EventArgs) Handles PopupMenu1.CloseUp

    End Sub

    Private Sub bbiPreview_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPreview.ItemClick
        DropDownButton1.Text = "Send To: Preview"
    End Sub

    Private Sub bbiCSV_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCSV.ItemClick
        DropDownButton1.Text = "Send To: CSV"
    End Sub

    Private Sub bbiHTML_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiHTML.ItemClick
        DropDownButton1.Text = "Send To: HTML"
    End Sub

    Private Sub bbiIMAGE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiIMAGE.ItemClick
        DropDownButton1.Text = "Send To: IMAGE"
    End Sub

    Private Sub bbiPrinter_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPrinter.ItemClick
        DropDownButton1.Text = "Send To: Printer"
    End Sub

    Private Sub bbiRTF_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiRTF.ItemClick
        DropDownButton1.Text = "Send To: RTF"
    End Sub

    Private Sub bbiTEXT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiTEXT.ItemClick
        DropDownButton1.Text = "Send To: TEXT"
    End Sub

    Private Sub bbiXLS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiXLS.ItemClick
        DropDownButton1.Text = "Send To: XLS"
    End Sub

    Private Sub bbiXLSX_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiXLSX.ItemClick
        DropDownButton1.Text = "Send To: XLSX"
    End Sub

    Private Sub Gary(Optional sFilter As String = "")
        Dim lCount As Long
        Dim Count As Long
        Dim entityID As Long
        Dim entitytype
        Dim lId As Long
        Dim lColor As Long
        Dim lParentID As Long
        Dim sName As String
        Dim lToolID As Long
        Dim sLayerName As String
        Dim sToolDesc As String
        Dim sql As String
        Dim objNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim objParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim connectionParameters As New Access97ConnectionParameters(DB_PATH, "", "")
        Dim m_cnEntityData As New OleDb.OleDbConnection
        Dim m_daEntityData As OleDb.OleDbDataAdapter
        Dim m_cbEntityData As OleDb.OleDbCommandBuilder
        Dim m_dtEntityData As New DataTable
        Dim cmd As OleDbCommand

        Dim dx As Double
        Dim dy As Double
        Dim dZ As Double
        Dim dx1 As Double
        Dim dy1 As Double
        Dim dZ1 As Double
        Dim dx2 As Double
        Dim dy2 As Double
        Dim dZ2 As Double
        Dim sToolTip As String
        Dim delim As String
        Dim dTemp As Double
        Dim lTemp As Long
        Dim stemp As String
        Dim stemp2 As String
        Dim indx As Integer
        Dim start_ang As Double
        Dim end_ang As Double


        delim = vbCrLf

        Try

            If Not Me.Visible Then Exit Sub

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            m_cnEntityData.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DB_PATH
            m_cnEntityData.Open()
            sql = "DELETE * FROM [StandardProps]"

            cmd = New OleDbCommand(sql, m_cnEntityData)

            cmd.ExecuteNonQuery()

            sql = "SELECT [StandardProps].* FROM [StandardProps]"
            m_daEntityData = New OleDb.OleDbDataAdapter(sql, m_cnEntityData)
            m_cbEntityData = New OleDb.OleDbCommandBuilder(m_daEntityData)
            m_daEntityData.Fill(m_dtEntityData)

            'Clear the treeview

            tvwEntityList.ClearNodes()
            tvwEntityList.BeginUnboundLoad()


            ' Getting the number of entities
            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            ' initialize the filter combobox
            'bUserClick = False ' disable "normal" processing

            For lCounter = 0 To (lCount - 1)
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)



                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
                lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any

                lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                Count = PortalGetInt("count", 0)

                If (Count > 0) Then 'We check the child entities to see if they are part of the table graphics

                    lReturn = PortalExecute(
                                "*Entity:Container:Get:" &
                                " id=" & lId &
                                ",index=1")
                    entityID = PortalGetInt("id", 0)

                    lReturn = PortalExecute("*create:extract:id=" & entityID)
                    lReturn = PortalExecute("*Entity:Tool:id=" & entityID)
                    lToolID = PortalGetInt("ID", 0)
                    sToolDesc = EntityStringGet(lToolID, "Description", "")

                End If

                sLayerName = EntityStringGet(lToolID, "Name", "<error>")


                lColor = EntityIntGet(lId, "color", 16711680)


                If (sLayerName = "TableGraphics") Then GoTo skip 'We do not want to show tablegrahics in the list

                sName = GetDisplayName(lId)

                ' does the filter entry already exist?
                If Not CheckEntryToList(sName, cbeEntityList) Then
                    cbeEntityList.Properties.Items.Add(sName)
                End If

                If (lColor = 0) Then
                    lColor = m_fg_color

                End If
                If (sName.Contains("Empty") = True) Then
                    'GoTo skip
                    lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & lId)
                    'lReturn = PortalExecute("Zone:Update: id=" & lId & ",delete=1")
                    'lReturn = PortalExecute("Create:Delete: id=" & lId)
                End If


                ' does the filter allow the addition of this entity?
                If Len(sFilter) = 0 Or
                    sFilter = sName Or
                        sFilter = "Everything" Or
                        (sFilter = "Toolpath" And lToolID > 0) Then

                    If (sName <> "Feature(Empty)") Then
                        ' add entity to treeview
                        Dim drNewRow As DataRow = m_dtEntityData.NewRow()

                        drNewRow("_layername") = sLayerName
                        drNewRow("_toolDescrip") = sToolDesc
                        drNewRow("_color") = lColor
                        drNewRow("_tool_layer_name") = sToolDesc & " " & sLayerName

                        objParentNode = tvwEntityList.FindNodeByFieldValue(tvwEntityList.Columns(1).FieldName, lParentID)

                        If objParentNode IsNot Nothing Then

                            objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, objParentNode.Id, lColor}, objParentNode.Id, "uid_" & CStr(lId))

                        Else

                            objNode = tvwEntityList.AppendNode(New Object() {sName, lId, lParentID, 0, lColor}, -1, "uid_" & CStr(lId))

                        End If

                        drNewRow("_entname") = sName
                        drNewRow("_ent_ID") = lId

                        entitytype = GetEntityType(lId)
                        'lToolID = PortalGetInt("toolid", 0)

                        Select Case entitytype '_enttype
                            Case c_DBLAYER
                                drNewRow("_enttype") = "Layer"
                            Case c_DBWORKPLANE
                                drNewRow("_enttype") = "WorkPlane"
                            Case c_DBTOOL
                                drNewRow("_enttype") = "Tool"
                            Case c_DBPOINT
                                drNewRow("_enttype") = "Point"
                                lReturn = PortalExecute("*create:extract:id=" & lId)
                                drNewRow("_pc_entityID") = lId
                                drNewRow("_pc_x") = Round(PortalGetDouble("x", 0))
                                drNewRow("_pc_y") = Round(PortalGetDouble("y", 0))
                                drNewRow("_pc_z") = Round(PortalGetDouble("z", 0))


                            Case c_DBLINE
                                drNewRow("_enttype") = "Line"
                                lReturn = PortalExecute("*create:extract:id=" & lId)
                                dx = PortalGetDouble("sx", 0)
                                dy = PortalGetDouble("sy", 0)
                                dZ = PortalGetDouble("sz", 0)
                                sToolTip = sToolTip & "Start X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dZ)
                                dx2 = PortalGetDouble("ex", 0)
                                dy2 = PortalGetDouble("ey", 0)
                                dZ2 = PortalGetDouble("ez", 0)
                                sToolTip = sToolTip & delim & "End X:" & Round(dx2) & " Y:" & Round(dy2) & " Z:" & Round(dZ2)
                                dTemp = Dist2D(dx, dx2, dy, dy2)
                                sToolTip = sToolTip & delim & "Length:" & Round(dTemp)
                                dTemp = Radians2Degrees(ATan2(dy2 - dy, dx2 - dx))
                                lTemp = PortalGetInt("dir", 0)
                                sToolTip = sToolTip & " Angle:" & Round(dTemp, modMath.Places.TenThousandths)

                                drNewRow("_ps_entityID") = lId
                                drNewRow("_ps_x") = Round(dx)
                                drNewRow("_ps_y") = Round(dy)
                                drNewRow("_ps_z") = Round(dZ)
                                drNewRow("_pe_entityID") = lId
                                drNewRow("_pe_x") = Round(dx2)
                                drNewRow("_pe_y") = Round(dy2)
                                drNewRow("_pe_z") = Round(dZ2)
                                drNewRow("_angle") = Round(dTemp)

                            Case c_DBARC
                                drNewRow("_enttype") = "ARC/Circle"
                                lReturn = PortalExecute("*create:extract:id=" & lId)
                                dx = PortalGetDouble("sx", 0)
                                dy = PortalGetDouble("sy", 0)
                                dZ = PortalGetDouble("sz", 0)
                                sToolTip = sToolTip & "Start X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dZ)
                                dx1 = PortalGetDouble("ex", 0)
                                dy1 = PortalGetDouble("ey", 0)
                                dZ1 = PortalGetDouble("ez", 0)
                                sToolTip = sToolTip & delim & "End X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dZ)
                                dx2 = PortalGetDouble("cx", 0)
                                dy2 = PortalGetDouble("cy", 0)
                                dZ2 = PortalGetDouble("cz", 0)
                                sToolTip = sToolTip & delim & "Center X:" & Round(dx2) & " Y:" & Round(dy2) & " Z:" & Round(dZ2)
                                dTemp = Dist2D(dx, dx2, dy, dy2)
                                sToolTip = sToolTip & delim & "Radius:" & Round(dTemp)
                                lTemp = PortalGetInt("dir", 0)
                                sToolTip = sToolTip & " Dir:" & IIf((lTemp = -1), "CW", "CCW")

                                drNewRow("_ps_entityID") = lId
                                drNewRow("_ps_x") = Round(dx)
                                drNewRow("_ps_y") = Round(dy)
                                drNewRow("_ps_z") = Round(dZ)
                                drNewRow("_pe_entityID") = lId
                                drNewRow("_pe_x") = Round(dx1)
                                drNewRow("_pe_y") = Round(dy1)
                                drNewRow("_pe_z") = Round(dZ1)
                                drNewRow("_pc_entityID") = lId
                                drNewRow("_pc_x") = Round(dx2)
                                drNewRow("_pc_y") = Round(dy2)
                                drNewRow("_pc_z") = Round(dZ2)

                                drNewRow("_radius") = Round(Round(dTemp))
                                drNewRow("_dir") = IIf((lTemp > 0), "CW", "CCW")
                                start_ang = ATan2(dy - dy2, dx - dx2)
                                end_ang = ATan2(dy1 - dy2, dx1 - dx2)
                                drNewRow("_start_ang") = Round(Radians2Degrees(start_ang))
                                drNewRow("_end_ang") = Round(Radians2Degrees(end_ang))
                                'MessageBox.Show("The start ang and End ang are :" & Round(Radians2Degrees(start_ang)) & " " & Round(Radians2Degrees(end_ang)))

                            Case c_DBHOLE
                                drNewRow("_enttype") = "Hole"
                                lReturn = PortalExecute("*create:extract:id=" & lId)
                                dx = PortalGetDouble("x", 0)
                                dy = PortalGetDouble("y", 0)
                                dZ = PortalGetDouble("z", 0)
                                sToolTip = sToolTip & "X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dZ)
                                dTemp = EntityDoubleGet(lId, "orient", 0)
                                sToolTip = sToolTip & delim & "Index Angle:" & Round(dTemp, modMath.Places.Hundredths)

                                drNewRow("_pc_entityID") = lId
                                drNewRow("_pc_x") = Round(dx)
                                drNewRow("_pc_y") = Round(dy)
                                drNewRow("_pc_z") = Round(dZ)
                                drNewRow("_orient") = Round(dTemp)

                            Case c_DBPROFILE
                                drNewRow("_enttype") = "Profile"
                                lReturn = PortalExecute("*create:extract:id=" & lId)
                                drNewRow("_pc_entityID") = lId

                                drNewRow("_text") = "Profile"

                            Case c_DBCOMMAND
                                drNewRow("_enttype") = "Command"
                                lReturn = PortalExecute("*create:extract:id=" & lId)

                                stemp = PortalGetString("text", "")
                                If InStr(1, stemp, "INSTANCE") > 0 Then
                                    stemp = PortalGetString("label", "")
                                    sToolTip = sToolTip & stemp & delim

                                    dx = PortalGetDouble("x", 0)
                                    dy = PortalGetDouble("y", 0)
                                    dZ = PortalGetDouble("z", 0)
                                    sToolTip = sToolTip & "Handle Point X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dZ)

                                    drNewRow("_pc_entityID") = lId
                                    drNewRow("_pc_x") = Round(dx)
                                    drNewRow("_pc_y") = Round(dy)
                                    drNewRow("_pc_z") = Round(dZ)
                                    drNewRow("_text") = stemp

                                Else
                                    indx = InStr(1, stemp, Chr(0))
                                    If (indx > 0) Then
                                        stemp = Microsoft.VisualBasic.Left(stemp, indx - 1)
                                    End If
                                    sToolTip = sToolTip & "Text:" & stemp
                                    dx = PortalGetDouble("x", 0)
                                    dy = PortalGetDouble("y", 0)
                                    dZ = PortalGetDouble("z", 0)
                                    sToolTip = sToolTip & delim & "Handle Point X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dZ)

                                    drNewRow("_pc_entityID") = lId
                                    drNewRow("_pc_x") = Round(dx)
                                    drNewRow("_pc_y") = Round(dy)
                                    drNewRow("_pc_z") = Round(dZ)
                                    drNewRow("_text") = stemp
                                End If
                            Case c_DBFEATURE
                                drNewRow("_enttype") = "feature"
                            Case c_DBPATTERN
                                drNewRow("_enttype") = "Pattern"
                        End Select

                        m_dtEntityData.Rows.Add(drNewRow)
                        m_daEntityData.Update(m_dtEntityData)


                    Else
                        'we do not want any empty features so we delte them to be sure
                        lReturn = PortalExecute("Create:Delete: id=" & lId)

                    End If

                End If
skip:

            Next
            tvwEntityList.Columns(1).Visible = False
            tvwEntityList.Columns(2).Visible = False
            tvwEntityList.Columns(3).Visible = False
            tvwEntityList.Columns(4).Visible = False

            m_cnEntityData.Close()
            m_cnEntityData = Nothing
            m_daEntityData.Dispose()
            m_daEntityData = Nothing
            m_cbEntityData.Dispose()
            m_cbEntityData = Nothing

            tvwEntityList.EndUnboundLoad()
            '
        Catch ex As Exception
            MessageBox.Show("Gary: " & ex.Message)
        End Try
    End Sub
End Class