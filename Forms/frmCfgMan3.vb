Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class frmCfgMan3

    Private m_is_active As Boolean
    Private Const MACHINE_ATTRIBUTES_INDEX = 6
    Private Const MODE_DXF = 0
    Private Const MODE_DWG = 1

    Private Const DEFAULT_TOL = 0.0001

    Dim MachineType As Integer
    Dim nFilenameAttributeRow As Integer


    Private Const MODE_ADD = 0
    Private Const MODE_EDIT = 1
    Private Const MODE_FINISH = 2
    Private m_ToolCribMode As Integer
    Private m_MaterialID As Long

    Private m_machineID As Long
    Private m_machineType As Long
    Private m_toolSetupID As Long
    Private m_MaterialTypeID As Long
    Private m_layerSetupID As Long
    Private m_globallayerinfoID As Long
    Private m_LayerInfoID As Long
    Private m_AnalyzeMode As Integer
    Private m_LayerAddEditMode As Boolean
    Private m_LeadSetupID As Long
    Private m_LeadParamID As Long
    Private nIndexOfActualMachine As Long
    Private nIndexOfLibMachineRoot As Long
    Private nLibRoot As Long
    Private nMachineNodeIndex As Long
    Private nActualStationNodeIndex As Long
    Private nCADDefsNodeIndex As Long
    Private nToolingNodeIndex As Long
    Private nActualToolingNodeIndex As Long
    Private nMaterialTypeNodeIndex As Long
    Private nMaterialTypeRootIndex As Long
    Private m_MaterialMainNode As Long
    Private m_MaterialTypeNode As Long


    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MACHINE_ROOT_NODE As TreeListNode
    Private CFG_MACHINE_TYPE_NODE As TreeListNode
    Private CFG_MACHINE_NODE As TreeListNode
    Private CFG_STATION_ROOT_NODE As TreeListNode
    Private CFG_TOOL_SETUP_ROOT_NODE As TreeListNode
    Private CFG_TOOL_SETUP_NODE As TreeListNode
    Private CFG_LAYER_SETUP_ROOT_NODE As TreeListNode
    Private CFG_LAYER_SETUP_NODE As TreeListNode
    Private CFG_LAYER_MAP_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private CFG_MATERIAL_NODE As TreeListNode
    Private CFG_OPERATION_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_PARAM_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_PARAM_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_SETUP_ROOT_NODE As TreeListNode
    Private CFG_OPERATION_LEAD_SETUP_NODE As TreeListNode

    'The folowing values are set as the tag property on each node
    'this helps determine the context in which the tree is in
    Private Const TAG_ROOT_NODE = 0
    Private Const TAG_MACHINE_ROOT_NODE = -100
    Private Const TAG_MACHINE_NODE = -101
    Private Const TAG_STATION_ROOT_NODE = -102
    Private Const TAG_TOOL_SETUP_ROOT_NODE = -103
    Private Const TAG_TOOL_SETUP_NODE = -104
    Private Const TAG_LAYER_SETUP_ROOT_NODE = -105
    Private Const TAG_LAYER_SETUP_NODE = -106
    Private Const TAG_LAYER_MAP_NODE = -107
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Private Const TAG_OPERATION_ROOT_NODE = -300
    Private Const TAG_OPERATION_LEAD_ROOT_NODE = -301
    Private Const TAG_OPERATION_LEAD_PARAM_ROOT_NODE = -302
    Private Const TAG_OPERATION_LEAD_PARAM_NODE = -303
    Private Const TAG_OPERATION_LEAD_SETUP_ROOT_NODE = -304
    Private Const TAG_OPERATION_LEAD_SETUP_NODE = -305

    Private Const LAYER_NAME_INDEX = 1
    Private Const HOLE_DIAM_INDEX = 2
    Private m_DoEdit As Boolean
    Private NcCodeNumberHolder As String
    Private m_last_Mode As Long
    Public IsMoveable As New clsMoveableForm
    Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton


    Dim bRemoveToolSetup As Boolean = False
    Dim nMyToolID As Integer
    Dim nStationID As Integer
    Dim nStationMachineID As Integer
    Dim nWorkPlaneID As Integer
    Dim dStationLocX As Double
    Dim dStationLocY As Double
    Dim bAutoIndex As Boolean
    Dim sPrimaryCode As String
    Dim sSecodaryCode As String
    Dim nNcCodeNumber As Integer
    Dim sStationSize As Double
    Private _hitInfo As TreeListHitInfo
    Private Const popup_MachineAdd As Integer = 0
    Private WithEvents rbMachSettings As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Dim gridDataList As New BindingList(Of StationMembers)
    Private Const OrderFieldName As String = "OrderID"
    Private captureHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Private dataSet1 As System.Data.DataSet
    Private gridControl1 As DevExpress.XtraGrid.GridControl
    Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private gridControl2 As DevExpress.XtraGrid.GridControl
    Private gridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private splitter1 As System.Windows.Forms.Splitter
    Private dataTable1 As System.Data.DataTable
    Private dataColumn1 As System.Data.DataColumn
    Private p As System.Drawing.Point = System.Drawing.Point.Empty
    Private downHitInfo As GridHitInfo = Nothing
    Private n_UpperBoundOrderID As Integer
    Private c_listboxColor As System.Drawing.Color
    Private WithEvents rbdsAnalyzeLayer As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private WithEvents rbToolParamSettings As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit


    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        On Error Resume Next

        '//Prevent the user from moving the form

        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_MOVE) Then
            Exit Sub
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32() = HTCAPTION) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub
    Public Shadows ReadOnly Property IsActive As Boolean
        Get
            IsActive = m_is_active
        End Get
    End Property

    Private Sub frmCfgMan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMain.CloseFirstPanel()

        bIsCfgManLoaded = False

        m_is_active = False
    End Sub

    Private Sub frmCfgMan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If (m_last_Mode = TAG_TOOL_SETUP_NODE And m_toolSetupID > 0) Then

            If (bRemoveToolSetup = False) Then
                AssignTheTools()
            End If

        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        '        Me.Dispose()

    End Sub
    Private Sub CreateRootNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)

        tl.ClearNodes()
        tl.BeginUnboundLoad()

        CFG_ROOT_NODE = Nothing

        CFG_MACHINE_ROOT_NODE = tl.AppendNode(New Object() {"Machine Types"}, 0)
        CFG_MATERIAL_ROOT_NODE = tl.AppendNode(New Object() {"Materials"}, CFG_ROOT_NODE, TAG_MATERIAL_ROOT_NODE)
        CFG_OPERATION_ROOT_NODE = tl.AppendNode(New Object() {"Operations"}, CFG_ROOT_NODE, TAG_OPERATION_ROOT_NODE)
        CFG_OPERATION_LEAD_ROOT_NODE = tl.AppendNode(New Object() {"Leads"}, CFG_OPERATION_ROOT_NODE, TAG_OPERATION_LEAD_ROOT_NODE)
        CFG_OPERATION_LEAD_PARAM_ROOT_NODE = tl.AppendNode(New Object() {"Lead Parameters"}, CFG_OPERATION_LEAD_ROOT_NODE, TAG_OPERATION_LEAD_PARAM_ROOT_NODE)
        CFG_OPERATION_LEAD_SETUP_ROOT_NODE = tl.AppendNode(New Object() {"Lead Setups"}, CFG_OPERATION_LEAD_ROOT_NODE, TAG_OPERATION_LEAD_SETUP_ROOT_NODE)

        FillMachineTypes()

        CreateMaterialTypeNodes(TV_Config)

        CreateLeadParameterNodes(TV_Config)

        CreateLeadSetupNodes(TV_Config)

        CFG_MACHINE_ROOT_NODE.Expanded = True

        For Each column As DevExpress.XtraTreeList.Columns.TreeListColumn In TV_Config.Columns
            column.OptionsColumn.AllowMove = False
        Next
        tl.EndUnboundLoad()

    End Sub

    Private Sub FillMachineTypes()
        Dim sql As String
        Dim ds As New DataSet
        Dim s_MachineDescrip As String
        Dim n_MachineID As Integer
        Dim i As Integer
        Dim dt1 As DataTable = Nothing

        s_MachineDescrip = ""
        n_MachineID = 0

        sql = "Select [Machine Types].* From [Machine Types]"

        Try

            ' InitFillDS(ds, Nothing, sql, connection)
            dt1 = ConnectToCMDB(sql)

            For i = 0 To dt1.Rows.Count - 1
                s_MachineDescrip = dt1.Rows(i).Item("Description")

                n_MachineID = dt1.Rows(i).Item("ID")

                If (n_MachineID < 10) Then

                    CFG_MACHINE_TYPE_NODE = TV_Config.AppendNode(New Object() {s_MachineDescrip}, CFG_MACHINE_ROOT_NODE, TAG_MACHINE_ROOT_NODE)

                    FillMachineNames(n_MachineID)

                End If

            Next
            m_dtCMDB.Dispose()



        Catch ex As Exception

            MessageBox.Show("FillMachineTypes: " & ex.Message)

        End Try

    End Sub

    Private Sub FillMachineNames(n_typeID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim s_MachineDescrip As String
        Dim n_MachineID As Integer
        Dim i As Integer
        Dim dtMachineNames As DataTable = Nothing
        Dim dt2 As DataTable = Nothing

        s_MachineDescrip = ""
        n_MachineID = 0

        sql = "Select Machines.* From Machines Where (Machines.[Type ID] = " & n_typeID & " )"

        Try
            dtMachineNames = ConnectToCMDB(sql)

            For i = 0 To dtMachineNames.Rows.Count - 1
                s_MachineDescrip = dtMachineNames.Rows(i).Item("Description")

                n_MachineID = dtMachineNames.Rows(i).Item("ID")

                If (n_typeID < 8) Then

                    CFG_MACHINE_NODE = TV_Config.AppendNode(New Object() {s_MachineDescrip}, CFG_MACHINE_TYPE_NODE, n_MachineID)

                    CFG_STATION_ROOT_NODE = TV_Config.AppendNode(New Object() {"Stations"}, CFG_MACHINE_NODE, TAG_STATION_ROOT_NODE)

                    CFG_TOOL_SETUP_ROOT_NODE = TV_Config.AppendNode(New Object() {"Tool Setups"}, CFG_MACHINE_NODE, TAG_TOOL_SETUP_ROOT_NODE)

                    FillToolSetups(n_MachineID)

                End If


            Next

            dtMachineNames.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillMachineNames: " & ex.Message)

        End Try

    End Sub

    Private Sub FillToolSetups(n_Machine_ID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim s_ToolSetupDescrip As String
        Dim n_ToolSetupID As Integer
        Dim i As Integer
        Dim dtToolSetups As DataTable = Nothing

        s_ToolSetupDescrip = ""

        'sql = "Select [Tool Setups].* From [Tool Setups] Where ([Tool Setups].[Machine ID] = " & n_Machine_ID & " )"
        sql = "Select [Tool Setups].* From [Tool Setups] Where ([Tool Setups].[Machine ID] = " & n_Machine_ID & " ) Order By [Tool Setups].Description"

        Try
            dtToolSetups = ConnectToCMDB(sql)

            For i = 0 To dtToolSetups.Rows.Count - 1

                s_ToolSetupDescrip = dtToolSetups.Rows(i).Item("Description")

                n_ToolSetupID = dtToolSetups.Rows(i).Item("ID")

                CFG_TOOL_SETUP_NODE = TV_Config.AppendNode(New Object() {s_ToolSetupDescrip}, CFG_TOOL_SETUP_ROOT_NODE, n_ToolSetupID)

                CFG_LAYER_SETUP_ROOT_NODE = TV_Config.AppendNode(New Object() {"Layer Setups"}, CFG_TOOL_SETUP_NODE, TAG_LAYER_SETUP_ROOT_NODE)

                FillLayerSetups(n_Machine_ID)
            Next

            dtToolSetups.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillToolSetups: " & ex.Message)

        End Try

    End Sub

    Private Sub FillLayerSetups(n_Machine_ID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim s_LayerSetupDescrip As String
        Dim n_LayerSetupID As Integer
        Dim i As Integer
        Dim dtLayerSetups As DataTable = Nothing

        s_LayerSetupDescrip = ""

        sql = "Select [Layer Setups].* From [Layer Setups] Where ([Layer Setups].[Machine ID] = " & n_Machine_ID & " )"

        Try

            dtLayerSetups = ConnectToCMDB(sql)

            For i = 0 To dtLayerSetups.Rows.Count - 1

                s_LayerSetupDescrip = dtLayerSetups.Rows(i).Item("Description")

                n_LayerSetupID = dtLayerSetups.Rows(i).Item("ID")

                CFG_LAYER_SETUP_NODE = TV_Config.AppendNode(New Object() {s_LayerSetupDescrip}, CFG_LAYER_SETUP_ROOT_NODE, n_LayerSetupID)

                FillLayerNames(n_LayerSetupID)

            Next

            dtLayerSetups.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillLayerSetups: " & ex.Message)

        End Try

    End Sub

    Private Sub FillLayerNames(n_layerSetupID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim s_LayerName As String
        Dim n_LayerNameID As Integer
        Dim i As Integer
        Dim dtLayerNames As DataTable = Nothing
        s_LayerName = ""

        sql = "Select Directives.* From Directives Where (Directives.[Layer Setup ID] = " & n_layerSetupID & " )"

        Try

            dtLayerNames = ConnectToCMDB(sql)

            For i = 0 To dtLayerNames.Rows.Count - 1

                s_LayerName = dtLayerNames.Rows(i).Item("CAD Layer")

                n_LayerNameID = dtLayerNames.Rows(i).Item("ID")

                CFG_LAYER_MAP_NODE = TV_Config.AppendNode(New Object() {s_LayerName}, CFG_LAYER_SETUP_NODE, n_LayerNameID)

            Next

            dtLayerNames.Dispose()


        Catch ex As Exception

            MessageBox.Show("FillLayerNames: " & ex.Message)

        End Try

    End Sub

    Private Sub CreateMaterialTypeNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        Dim sql As String
        Dim ds As New DataSet
        Dim s_MaterialCategory As String
        Dim n_MaterialID As Integer
        Dim i As Integer
        Dim dtMaterialType As DataTable = Nothing


        s_MaterialCategory = ""

        sql = "Select [Material Types].* From [Material Types] Order By [Material Types].Description"

        Try

            dtMaterialType = ConnectToCMDB(sql)


            For i = 0 To dtMaterialType.Rows.Count - 1
                s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")

                n_MaterialID = dtMaterialType.Rows(i).Item("ID")

                CFG_MATERIAL_CATEGORY_NODE = TV_Config.AppendNode(New Object() {s_MaterialCategory}, CFG_MATERIAL_ROOT_NODE, TAG_MATERIAL_CATEGORY_NODE)

                FillMaterialNodes(n_MaterialID)

                dtMaterialType.Dispose()

            Next

        Catch ex As Exception

            MessageBox.Show("CreateMaterialTypeNodes: " & ex.Message)

        End Try

    End Sub
    Private Sub FillMaterialNodes(n_MaterialID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim s_MaterialDescription As String
        Dim i As Integer
        Dim dtMaterialNode As DataTable = Nothing

        s_MaterialDescription = ""

        sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].[Type ID] = " & n_MaterialID & " )  Order By [Material Inventory].Description ASC, [Material Inventory].Width ASC, [Material Inventory].Length ASC, [Material Inventory].Thickness ASC"

        Try

            dtMaterialNode = ConnectToCMDB(sql)

            For i = 0 To dtMaterialNode.Rows.Count - 1
                s_MaterialDescription = dtMaterialNode.Rows(i).Item("Description")

                n_MaterialID = dtMaterialNode.Rows(i).Item("ID")

                CFG_MATERIAL_NODE = TV_Config.AppendNode(New Object() {s_MaterialDescription}, CFG_MATERIAL_CATEGORY_NODE, TAG_MATERIAL_NODE)

            Next

            dtMaterialNode.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillMaterialNodes: " & ex.Message)

        End Try

    End Sub

    Private Sub CreateLeadParameterNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim s_LeadParamDescription As String
        Dim i As Integer
        Dim n_LeadParamID As Long

        s_LeadParamDescription = ""

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Select [Lead Parameter].* From [Lead Parameter]"

        connection = New OleDbConnection(connetionString)

        Try
            InitFillDS(ds, Nothing, sql, connection)

            For i = 0 To ds.Tables(0).Rows.Count - 1
                s_LeadParamDescription = ds.Tables(0).Rows(i).Item("Description")

                n_LeadParamID = ds.Tables(0).Rows(i).Item("ID")

                CFG_OPERATION_LEAD_PARAM_NODE = TV_Config.AppendNode(New Object() {s_LeadParamDescription}, CFG_OPERATION_LEAD_PARAM_ROOT_NODE, TAG_OPERATION_LEAD_PARAM_NODE)

            Next

            ds.Dispose()
            connection.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Sub CreateLeadSetupNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim s_LeadSetupDescription As String
        Dim i As Integer
        Dim n_LeadSetupID As Long

        s_LeadSetupDescription = ""

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Select [Lead Setup].* From [Lead Setup]"

        connection = New OleDbConnection(connetionString)

        Try
            InitFillDS(ds, Nothing, sql, connection)

            For i = 0 To ds.Tables(0).Rows.Count - 1
                s_LeadSetupDescription = ds.Tables(0).Rows(i).Item("Description")

                n_LeadSetupID = ds.Tables(0).Rows(i).Item("ID")

                CFG_OPERATION_LEAD_SETUP_NODE = TV_Config.AppendNode(New Object() {s_LeadSetupDescription}, CFG_OPERATION_LEAD_SETUP_ROOT_NODE, TAG_OPERATION_LEAD_SETUP_NODE)

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Sub HideControls(nTheMode As Long)
        Dim preamble As String

        'set a default width
        Me.Width = 700

        preamble = ""

        If (m_last_Mode = TAG_TOOL_SETUP_NODE And m_toolSetupID > 0) Then
            If (bRemoveToolSetup = False) Then
                AssignTheTools()
            End If

        End If

        Me.pnlPreamble.Visible = False
        Me.pnlMachSettings.Visible = False
        Me.pnlStations.Visible = False
        Me.pnlToolSetups.Visible = False
        Me.pnlToolingParameters.Visible = False
        Me.pnlAvailableTooling.Visible = False
        Me.pnlToolingParameters.Visible = False
        Me.pnlLayerGlobal.Visible = False
        Me.pnlLayerSetup.Visible = False
        Me.pnlMaterialInfo.Visible = False
        Me.pnlLeadParameters.Visible = False
        Me.pnlLeadSetupInfo.Visible = False
        Me.pnlAnalyze.Visible = False

        cmdToolCribEdit.Enabled = False
        cmdToolCribRemove.Enabled = False

        vgMachSettings.SuspendLayout()
        Me.SuspendLayout()
        Select Case nTheMode

            Case TAG_ROOT_NODE

                preamble = vbCrLf & vbCrLf &
               "The Configuration Browser works much like Window's Explorer. " &
               "You can expand and collapse branches of the tree by left-mouse " &
               "clicking on the '+' and '-' symbols that appear in front of a " &
               "node name."

                Me.pnlPreamble.Visible = True

            Case TAG_MACHINE_ROOT_NODE


                SetMachineType(UCase(TV_Config.FocusedNode.GetDisplayText(TV_Config.Columns(0))))


                m_machineType = MachineType

                preamble = vbCrLf & vbCrLf &
                "The Machine node of the Configuration Browser is used " &
                "to capture your machine, tooling and CAD conversion " &
                "definitions." & vbCrLf & vbCrLf &
                "You should name your data items with a " &
                "convention that you can remember and understand." &
                "You can add and remove Machines " &
                "by right-mouse clicking on the proper machine type node, and then by selecting the " &
                "desired option in the pop menu that appears."

                Me.pnlPreamble.Visible = True

            Case TAG_MACHINE_NODE
                'Me.Width = 700
                Me.pnlMachSettings.Visible = True

                m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.GetDisplayText(0))

                m_machineType = GetMachineType(m_machineID)

                FillMachineAttributes(m_machineType)

                GetRowsData()

                vgMachSettings.BestFit()

                vgMachSettings.OptionsMenu.EnableContextMenu = False


            Case TAG_STATION_ROOT_NODE


                m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.GetDisplayText(0))
                InitStations()
                ubgStationsView.BestFitColumns(True)
                'Me.Width = 750
                Me.pnlStations.Visible = True

            Case TAG_TOOL_SETUP_ROOT_NODE
                preamble = "The Tooling node of the Configuration Browser is used " &
                "to capture your tooling and tool setup information. " &
                "Tool setups establish relationships between the stations " &
                "of your machine and tools in your tool crib.  This " &
                "information can be used to generate operator instructions " &
                "for machine setup, and it is also necessary for teaching " &
                "the system how to perform CAD conversions." &
                vbCrLf & vbCrLf &
                "Also, your tool crib is accessed through a tool setup. " &
                "Therefore, you will not be able to access your tool crib until " &
                "you add at least one tool setup to your configuration data."""

                Me.pnlPreamble.Visible = True

            Case TAG_TOOL_SETUP_NODE
                m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.GetDisplayText(0))
                m_machineType = GetMachineType(m_machineID)

                Me.pnlToolSetups.Visible = True

                FillToolTypes(cboToolSetupAvailTools, m_machineType)
                cboToolSetupAvailTools.SelectedIndex = 0

                m_toolSetupID = TV_Config.FocusedNode.Tag

                InitToolSetupGrid(m_toolSetupID, m_machineID)

                Me.pnlAvailableTooling.Visible = True
                Me.Width = 900

            Case TAG_LAYER_SETUP_ROOT_NODE
                m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0))
                Me.pnlPreamble.Visible = True

                preamble = preamble &
                    vbCrLf & vbCrLf &
                    "The layer setup node of the Configuration Browser " &
                    "is used to capture your CAD conversion information. " &
                    "Each layer setup is associated with a tool setup because " &
                    "the layer mappings, within the layer setup, establish " &
                    "relationships between CAD geometry and the tools that " &
                    "will be used to cut the geometry."

            Case TAG_LAYER_SETUP_NODE
                m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0))
                Me.pnlLayerGlobal.Visible = True

                m_globallayerinfoID = TV_Config.FocusedNode.Tag
                Me.Width = 525

                FillGlobalLayerInfo(m_globallayerinfoID)

            Case TAG_LAYER_MAP_NODE
                'Me.Width = 525
                m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0))

                Me.pnlLayerSetup.Visible = True

                m_layerSetupID = TV_Config.FocusedNode.ParentNode.Tag

                Dim sToolSetupName As String = TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0)

                m_toolSetupID = modTranslate.GetToolSetupIDFromDescription(sToolSetupName)

                FillComboWithTools(m_toolSetupID)

                m_LayerInfoID = TV_Config.FocusedNode.Tag

                FillLayerInfo(m_LayerInfoID)
                vgLayerInfo.BestFit()




            Case TAG_MATERIAL_NODE
                Me.Width = 525

                Me.pnlMaterialInfo.Visible = True
                m_MaterialID = modTranslate.GetMaterialIDFromDescription(TV_Config.FocusedNode.GetDisplayText(0))

                If (m_MaterialID > 0) Then
                    FillMaterialInfo(m_MaterialID)
                End If
                vgMaterialInfo.BestFit()

            Case TAG_OPERATION_LEAD_PARAM_NODE
                m_LeadParamID = modTranslate.GetLeadParamID(TV_Config.FocusedNode.GetDisplayText(0))


                PopulateLeadParamValues(m_LeadParamID)

                Me.pnlLeadParameters.Visible = True

            Case TAG_OPERATION_LEAD_SETUP_NODE
                Me.Width = TV_Config.Width + pnlLeadSetupInfo.Width + 25
                m_LeadSetupID = modTranslate.GetLeadSetupID(TV_Config.FocusedNode.GetDisplayText(0))

                GetLeadSetupAttributes(m_LeadSetupID)
                Me.pnlLeadSetupInfo.Visible = True

            Case Else



        End Select

        m_last_Mode = nTheMode

        Me.memoInfo.Text = preamble

        frmMain.splitContainerControl.SplitterPosition = Me.Width
        vgMachSettings.ResumeLayout()
        Me.ResumeLayout()

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        CreateRootNodes(TV_Config)

        Windows.Forms.Cursor.Current = Cursors.Default
        ' Add any initialization after the InitializeComponent() call.

        rbMachSettings = New RepositoryItemButtonEdit()

        rbdsAnalyzeLayer = New RepositoryItemButtonEdit()

        rbToolParamSettings = New RepositoryItemButtonEdit()

        m_is_active = True

    End Sub

    Private Sub frmCfgMan3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            System.Windows.Forms.SendKeys.Send("{TAB}") ' treat as a tab to calculate
        End If
    End Sub
    Private Sub frmCfgMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        InitLeadParameterPanel()

        HideControls(0)
        LoadLeadParamCombos()

        lstToolSetupAvailTools.BackColor = frmMain.pnlPicmodeler.BackColor
        Me.m_is_active = True
        bIsCfgManLoaded = True
    End Sub

    Private Function TreeItemType(nNode As TreeListNode) As Long

        Dim Parent As TreeListNode
        Dim itemTag As Long

        itemTag = -1


        Try
            If (nNode IsNot Nothing) Then


                itemTag = nNode.Tag

                If (itemTag <= 0) Then

                    'Must be a root node of some type.

                Else

                    'Base the item type off of the root node of this item.

                    Parent = nNode.ParentNode
                    itemTag = Parent.Tag

                    If (itemTag > 0) Then
                        Parent = nNode.ParentNode.ParentNode
                        itemTag = Parent.Tag - 1
                    End If

                    itemTag = itemTag - 1

                End If

                TreeItemType = itemTag
            End If


        Catch ex As ArgumentException

            MessageBox.Show(ex.Message)

        End Try


    End Function

    Private Sub SetMachineType(MachineText As String)
        Select Case MachineText
            Case "PUNCH"
                MachineType = 1
            Case "PUNCH/PLASMA"
                MachineType = 2
            Case "LASER"
                MachineType = 3
            Case "PUNCH/LASER"
                MachineType = 4
            Case "BURNER"
                MachineType = 5
            Case "WATERJET"
                MachineType = 6
            Case "ROUTER"
                MachineType = 7
            Case "MILL"
                MachineType = 9
        End Select

    End Sub

    Private Sub FillMachineAttributes(ByVal n_MachineType As Integer)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim sql As String
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        Dim i As Integer
        Dim m_UNITS As String = "Inch"
        Dim m_QUAD As String = "Upper"
        Dim m_CLAMPCTG As String = ""
        Dim m_TABLECTG As String = ""
        Dim m_HOLDDOWNCTG As String = ""
        Dim m_DEFAULTCNCFILEPATH As String = ""
        Dim m_CODEPARTPROFILE As Boolean = False
        Dim dtMachineAttributes As DataTable = Nothing

        m_DoEdit = False

        MachSettings.ChildRows.Clear()

        sql = "SELECT * FROM Machines WHERE (ID = " & m_machineID & ")"

        Try
            dtMachineAttributes = ConnectToCMDB(sql)

            For i = 0 To dtMachineAttributes.Rows.Count - 1
                m_UNITS = IIf(dtMachineAttributes.Rows(i).Item("Units") = 0, "Inch", "Metric")
                m_QUAD = IIf(dtMachineAttributes.Rows(i).Item("Workplane Type ID") = 1, "Upper", "Lower")

                If (IsDBNull(dtMachineAttributes.Rows(i).Item("Clamp_CTG")) = False) Then

                    m_CLAMPCTG = CStr(dtMachineAttributes.Rows(i).Item("Clamp_CTG").ToString)

                End If

                If (IsDBNull(dtMachineAttributes.Rows(i).Item("HoldDown_CTG")) = False) Then

                    m_HOLDDOWNCTG = CStr(dtMachineAttributes.Rows(i).Item("HoldDown_CTG"))

                End If

                If (IsDBNull(dtMachineAttributes.Rows(i).Item("Table_CTG")) = False) Then

                    m_TABLECTG = CStr(dtMachineAttributes.Rows(i).Item("Table_CTG"))

                End If

                If (IsDBNull(dtMachineAttributes.Rows(i).Item("CNC_Folder")) = False) Then

                    m_DEFAULTCNCFILEPATH = CStr(dtMachineAttributes.Rows(i).Item("CNC_Folder"))

                End If
                m_CODEPARTPROFILE = dtMachineAttributes.Rows(i).Item("Code Part Profile")

            Next

            dtMachineAttributes.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        sql = "SELECT [Machine Attribute Types].*" &
            " FROM [Machine Types] INNER JOIN ([Machine Attribute Types] " &
            "INNER JOIN [Machine Type Attributes] ON [Machine Attribute Types].ID = " &
            "[Machine Type Attributes].[Attribute Type ID]) ON [Machine Types].ID = " &
            "[Machine Type Attributes].[Machine Type  ID]" &
            " Where ((([Machine Types].ID) = " & n_MachineType &
            ")) ORDER BY [Machine Attribute Types].ID"



        Try


            dtMachineAttributes = ConnectToCMDB(sql)

            Dim sChoices As New Collection
            sChoices.Add("Upper")
            sChoices.Add("Lower")

            MachSettings.ChildRows.Add(CreateComboBoxEditorRow(vgMachSettings, "Quadrant", "Quadrant", 0, m_QUAD, sChoices))

            sChoices.Clear()
            sChoices.Add("Inch")
            sChoices.Add("Metric")

            MachSettings.ChildRows.Add(CreateComboBoxEditorRow(vgMachSettings, "Units", "Units", 0, m_UNITS, sChoices))
            MachSettings.ChildRows.Add(CreateBooleanEditorRow(vgMachSettings,
                                                                "Code Part Profile",
                                                                "Code Part Profile",
                                                                m_CODEPARTPROFILE,
                                                                0,
                                                                "Code Part Profile",
                                                                DB_BOOL,
                                                                0,
                                                                sEmpty, 0))


            'sDefaultName = RegGetString("Global", "NestResultPath", App_Path & "\nests")
            MachSettings.ChildRows.Add(CreateFileEditEditorRow(vgMachSettings,
                                                                     "CNC_Folder",
                                                                     "Default CNC File Path",
                                                                     m_DEFAULTCNCFILEPATH,
                                                                     m_DEFAULTCNCFILEPATH,
                                                                     "CNC_Folder",
                                                                     DB_FOLDER,
                                                                     0,
                                                                     sEmpty, 0))

            MachSettings.ChildRows.Add(CreateButtonEditEditorRow(vgMachSettings,
                                                                 "HoldDown_CTG",
                                                                 "HoldDown CTG",
                                                                  m_HOLDDOWNCTG,
                                                                  m_HOLDDOWNCTG,
                                                                  "HoldDown_CTG",
                                                                  DB_FILE,
                                                                  0,
                                                                  "CTG Files (CTG Files);*.CTG", 0))

            MachSettings.ChildRows.Add(CreateButtonEditEditorRow(vgMachSettings,
                                                                 "Clamp_CTG",
                                                                 "Clamp CTG",
                                                                  m_CLAMPCTG,
                                                                  m_CLAMPCTG,
                                                                  "Clamp_CTG",
                                                                  DB_FILE,
                                                                  0,
                                                                  "CTG Files (CTG Files);*.CTG", 0))


            MachSettings.ChildRows.Add(CreateButtonEditEditorRow(vgMachSettings,
                                                                 "Table_CTG",
                                                                 "Table CTG",
                                                                  m_TABLECTG,
                                                                  m_TABLECTG,
                                                                  "Table_CTG",
                                                                  DB_FILE,
                                                                  0,
                                                                  "CTG Files (CTG Files);*.CTG", 0))


            For i = 0 To dtMachineAttributes.Rows.Count - 1
                my_DatVarName = CStr(dtMachineAttributes.Rows(i).Item("Description"))
                my_DialogDisplay = CStr(dtMachineAttributes.Rows(i).Item("Display"))
                my_RecodID = CInt(dtMachineAttributes.Rows(i).Item("ID"))
                my_DataType = CInt(dtMachineAttributes.Rows(i).Item("DataType"))


                my_VBValue = 0
                my_CValue = 0
                my_CVarName = my_DatVarName


                my_sOptions = sEmpty


                Select Case my_DataType
                    Case 4
                        MachSettings.ChildRows.Add(CreateIntegerEditorRow(vgMachSettings,
                                                                my_DatVarName,
                                                                my_DialogDisplay,
                                                                my_VBValue,
                                                                my_CValue,
                                                                my_CVarName,
                                                                my_DataType,
                                                                my_RecodID,
                                                                my_sOptions, 0))
                    Case 7
                        MachSettings.ChildRows.Add(CreateDoubleEditorRow(vgMachSettings,
                                                                my_DatVarName,
                                                                my_DialogDisplay,
                                                                my_VBValue,
                                                                my_CValue,
                                                                my_CVarName,
                                                                my_DataType,
                                                                my_RecodID,
                                                                my_sOptions, 0))
                    Case Else
                        MachSettings.ChildRows.Add(CreateStringEditorRow(vgMachSettings,
                                                                my_DatVarName,
                                                                my_DialogDisplay,
                                                                my_VBValue,
                                                                my_CValue,
                                                                my_CVarName,
                                                                my_DataType,
                                                                my_RecodID,
                                                                my_sOptions, 0))
                End Select

            Next

            dtMachineAttributes.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillMachineAttributes" & ex.Message)

        End Try

        m_DoEdit = True


        vgMachSettings.FocusedRecord = 0

        Me.vgMachSettings.BestFit()
    End Sub

    Private Function CreateGridColumn(ByVal gridview As GridView,
                                              ByVal caption As String,
                                              ByVal field As String,
                                              ByVal visibleindex As Integer,
                                              ByVal IsVisible As Boolean,
                                              ByVal colType As DevExpress.Data.UnboundColumnType) As DevExpress.XtraGrid.Columns.GridColumn

        Dim gc As DevExpress.XtraGrid.Columns.GridColumn = gridview.Columns.Add()
        Dim nColWid As Integer

        gc.Caption = caption
        gc.VisibleIndex = visibleindex

        gc.FieldName = field
        gc.Visible = IsVisible

        gc.OptionsColumn.AllowEdit = True
        gc.UnboundType = colType

        nColWid = gc.GetBestWidth

        If (visibleindex = 1 Or visibleindex = 2 Or visibleindex = 4) Then
            gc.MaxWidth = 40
        End If

        If (visibleindex = 3) Then
            gc.MaxWidth = 65
        End If

        If (visibleindex = 0 Or visibleindex = 5 Or visibleindex = 6) Then
            gc.MaxWidth = 95
        End If


        Return gc

    End Function

    Private Sub InitStations()
        Dim sql As String
        Dim ds As New DataSet
        Dim sFieldName As String
        Dim i As Integer
        Dim indx As Integer
        Dim bShowCol As Boolean
        Dim sColCaption As String
        Dim tColType As DevExpress.Data.UnboundColumnType
        Dim dtInitStations As DataTable = Nothing


        sFieldName = ""
        ubgStationsView.Columns.Clear()

        ubgStations.DataSource.Clear()


        sql = "SELECT * FROM [Station Configuration] WHERE ([Machine ID] = " &
                m_machineID & " ) ORDER BY [NC Code Number]"


        Try

            dtInitStations = ConnectToCMDB(sql)

            For i = 0 To dtInitStations.Columns.Count - 1

                sFieldName = dtInitStations.Columns(i).ColumnName
                sColCaption = sFieldName

                Select Case UCase(sFieldName)

                    Case "ID"
                        indx = 0
                        bShowCol = False
                        sColCaption = " ID"
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                    Case "MACHINE ID"
                        indx = 1
                        bShowCol = False
                        sColCaption = "Machine ID "
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                    Case "WORKPLANE ID"
                        indx = 2
                        bShowCol = False
                        sColCaption = "Workplane ID "
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                    Case "NC CODE NUMBER"
                        indx = 0
                        bShowCol = True
                        tColType = DevExpress.Data.UnboundColumnType.Integer

                    Case "STATION LOCATION X"
                        indx = 1
                        bShowCol = True
                        sColCaption = "X Loc."
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "STATION LOCATION Y"
                        indx = 2
                        bShowCol = True
                        sColCaption = "Y Loc."
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "AUTO INDEX"
                        indx = 3
                        bShowCol = True
                        tColType = DevExpress.Data.UnboundColumnType.Boolean

                    Case "STATION SIZE"
                        indx = 4
                        bShowCol = True
                        sColCaption = "Size"
                        tColType = DevExpress.Data.UnboundColumnType.Decimal

                    Case "PRIMARY CODE"
                        indx = 5
                        bShowCol = True
                        tColType = DevExpress.Data.UnboundColumnType.String

                    Case "SECONDARY CODE"
                        indx = 6
                        bShowCol = True
                        tColType = DevExpress.Data.UnboundColumnType.String

                End Select

                'CreateGridColumn(ubgStationsView, sColCaption, sFieldName, indx, bShowCol, tColType)
                CreateGridColumn(ubgStationsView, sColCaption, sFieldName, indx, bShowCol, tColType)

            Next
            AddStationRows(m_machineID)

            dtInitStations.Dispose()




        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try


    End Sub

    Private Sub AddStationRows(n_MachineID As Integer)
        Dim sql As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim dtStationRows As DataTable = Nothing


        sql = "SELECT * FROM [Station Configuration] WHERE ([Machine ID] = " &
                n_MachineID & " ) ORDER BY [NC Code Number]"

        Try
            dtStationRows = ConnectToCMDB(sql)

            For i = 0 To dtStationRows.Rows.Count - 1

                nStationID = CInt(dtStationRows.Rows(i).Item(0))
                nStationMachineID = CInt(dtStationRows.Rows(i).Item(1))
                nWorkPlaneID = CInt(dtStationRows.Rows(i).Item(2))
                dStationLocX = CDbl(dtStationRows.Rows(i).Item(3))
                dStationLocY = CDbl(dtStationRows.Rows(i).Item(4))
                bAutoIndex = CBool(dtStationRows.Rows(i).Item(5))
                sPrimaryCode = CStr(dtStationRows.Rows(i).Item(6))
                sSecodaryCode = CStr(dtStationRows.Rows(i).Item(7))
                nNcCodeNumber = CInt(dtStationRows.Rows(i).Item(8))
                sStationSize = CInt(dtStationRows.Rows(i).Item(9))

                ubgStationsView.AppendRow(New Object() {nStationID, nStationMachineID, nWorkPlaneID,
                                                         dStationLocX, dStationLocY, bAutoIndex,
                                                        sPrimaryCode, sSecodaryCode, nNcCodeNumber,
                                                         sStationSize})
            Next

            dtStationRows.Dispose()



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub FillToolAttributes(tltype As Integer)
        Dim sql As String
        Dim lMyToolTypeId As Long
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        Dim i As Integer
        Dim sDisplayStr As String
        Dim sDescription As String
        Dim nID As Integer
        Dim nDataType As Integer
        Dim sTag As String
        Dim dtToolAttributes As DataTable = Nothing
        Dim sDieClearance As String
        If tltype = 0 Then Exit Sub

        ToolParams.ChildRows.Clear()

        lMyToolTypeId = (TryCast(cboToolSetupAvailTools.EditValue, myItemData)).ItemData.ToString()

        sql = "SELECT [Tool Attribute Types].*" &
            " FROM [Tool Types] INNER JOIN ([Tool Attribute Types] INNER JOIN [Tool Type Attributes] ON [Tool Attribute Types].ID = [Tool Type Attributes].[Attribute Type ID]) ON [Tool Types].ID = [Tool Type Attributes].[Tool Type  ID]" &
            " WHERE ((([Tool Types].ID)= " & lMyToolTypeId & ") AND (([Tool Attribute Types].ID)<>11))" &
            " ORDER BY [Tool Attribute Types].Description"

        Try
            dtToolAttributes = ConnectToCMDB(sql)

            For i = 0 To dtToolAttributes.Rows.Count - 1

                sDescription = CStr(dtToolAttributes.Rows(i).Item("Description"))
                sDisplayStr = Replace(sDescription, "_", " ")

                'sDieClearance = CStr(dtToolAttributes.Rows(i).Item("Die_Clearance"))

                nID = CInt(dtToolAttributes.Rows(i).Item("ID"))
                nDataType = CInt(dtToolAttributes.Rows(i).Item("DataType"))
                sTag = CStr(nID)

                If (nID = 18) Then
                    ToolParams.ChildRows.Add(CreateColorEditEditorRow(vgToolParameters, "Color", sDescription, nID, System.Drawing.Color.Cyan))
                End If
                If (lMyToolTypeId = 29 And nID = 21) Then
                    ToolParams.ChildRows.Add(CreateButtonEditEditorRow(vgToolParameters,
                                                                 "Filename",
                                                                 "Filename",
                                                                  sEmpty,
                                                                  sEmpty,
                                                                  "Filename",
                                                                  DB_FILE,
                                                                  nID,
                                                                  "CTG Files (CTG Files);*.CTG", 0))
                End If
                If nID < 17 Or nID > 28 And nID <> 30 Then
                    Select Case nDataType
                        Case 1
                            ToolParams.ChildRows.Add(CreateBooleanEditorRow(vgToolParameters,
                                                                            sDescription,
                                                                            sDisplayStr,
                                                                            False,
                                                                            False,
                                                                            sDisplayStr,
                                                                            DB_BOOL, nID, sEmpty, 0))


                        Case 4
                            ToolParams.ChildRows.Add(CreateIntegerEditorRow(vgToolParameters,
                                                                  sDisplayStr,
                                                                  sDescription,
                                                                  0,
                                                                  0,
                                                                  sDescription,
                                                                  DB_DBL, nID, sEmpty, 0))
                            'ToolParams.ChildRows.Add(CreateIntegerEditorRow(vgToolParameters, sDisplayStr, sDescription, nID, 0, sEmpty))
                        Case 7
                            ToolParams.ChildRows.Add(CreateDoubleEditorRow(vgToolParameters,
                                                                  sDisplayStr,
                                                                  sDisplayStr,
                                                                  0,
                                                                  0,
                                                                  sDescription,
                                                                  DB_DBL, nID, sEmpty, 0))
                            'ToolParams.ChildRows.Add(CreateDoubleEditorRow(vgToolParameters, sDisplayStr, sDescription, nID, 0, sEmpty))
                        Case Else
                            ToolParams.ChildRows.Add(CreateStringEditorRow(vgToolParameters,
                                                                  sDisplayStr,
                                                                  sDisplayStr,
                                                                  0,
                                                                  0,
                                                                  sDescription,
                                                                  DB_DBL, nID, sEmpty, 0))
                            'ToolParams.ChildRows.Add(CreateStringEditorRow(vgToolParameters, sDisplayStr, sDescription, nID, "<New value>"))
                    End Select

                End If
            Next

            dtToolAttributes.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        vgToolParameters.BestFit()

    End Sub
    Private Sub FillToolTypes(objList As DevExpress.XtraEditors.ComboBoxEdit, nMachineType As Long)
        Dim sDisplayStr As String
        Dim nID As Integer
        Dim sql As String
        Dim ds As New DataSet
        Dim dtToolTypes As DataTable = Nothing

        objList.Properties.Items.Clear()


        sql = "SELECT [Tool Types].* FROM [Tool Types] INNER JOIN [Machine Tool Types] ON [Tool Types].ID = [Machine Tool Types].[Tool Type ID]" &
                    " WHERE ((([Machine Tool Types].[Machine Type ID])=" & nMachineType & "))"

        Try
            dtToolTypes = ConnectToCMDB(sql)

            For i = 0 To dtToolTypes.Rows.Count - 1

                sDisplayStr = CStr(dtToolTypes.Rows(i).Item("Description"))
                nID = CInt(dtToolTypes.Rows(i).Item("ID"))
                objList.Properties.Items.Add(New myItemData(sDisplayStr, nID))

            Next

            dtToolTypes.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub FillToolListBasedOnType(ctrl As DevExpress.XtraEditors.ListBoxControl, tlTypeId As Long)
        Dim sDisplayStr As String
        Dim nID As Integer
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String

        ctrl.Items.Clear()

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "SELECT [Tool Crib].* FROM ([Tool Types] INNER JOIN [Tool Crib] ON [Tool Types].ID = [Tool Crib].[Type ID]) INNER JOIN [Machine Tool Types] ON [Tool Types].ID = [Machine Tool Types].[Tool Type ID]" &
                " WHERE ((([Tool Types].ID)=" & tlTypeId & ") AND (([Machine Tool Types].[Machine Type ID])=" & m_machineType & "))"


        connection = New OleDbConnection(connetionString)

        Try
            InitFillDS(ds, Nothing, sql, connection)

            For i = 0 To ds.Tables(0).Rows.Count - 1
                sDisplayStr = CStr(ds.Tables(0).Rows(i).Item("Description"))
                nID = CInt(ds.Tables(0).Rows(i).Item("ID"))

                ctrl.Items.Add(New myItemData(sDisplayStr, nID, ds.Tables(0).Rows(i).Item("Color")))
            Next

            ctrl.SelectedIndex = 0
            ds.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub TV_Config_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles TV_Config.FocusedNodeChanged
        Dim itemtype As Long
        Dim nCurr_Node_Tag As Long
        Dim sCurr_Display As String
        Dim nTestNode

        'Try

        If (e.Node IsNot Nothing) Then
            itemtype = TreeItemType(e.Node)



            sCurr_Display = e.Node.GetDisplayText(TV_Config.Columns(0))
            nCurr_Node_Tag = e.Node.Tag


            If (e.Node.ParentNode IsNot Nothing) Then
                nTestNode = e.Node.ParentNode.GetDisplayText(TV_Config.Columns(0))
            End If

            HideControls(itemtype)
        End If

        'Catch ex As Exception
        ' MessageBox.Show("TV_Config_FocusedNodeChanged" & ex.Message)
        'End Try
    End Sub

    Private Sub GetRowsData()
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim MachineAttID As Integer


        oledbAdapter = Nothing

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        connection = New OleDbConnection(connetionString)
        connection.Open()

        For Each row As CategoryRow In vgMachSettings.Rows

            Dim childRows As VGridRows = row.ChildRows

            For Each childRow As EditorRow In childRows

                If (childRow.Index < MACHINE_ATTRIBUTES_INDEX) Then
                    GoTo DoNext
                End If

                MachineAttID = GetValueFromDelimitedData(childRow.Tag, "nRecordID", 0)

                If (MachineAttID > 0) Then


                    sql = "Select [Machine Attributes].* From [Machine Attributes] Where ([Machine Attributes].[Machine ID] = " &
                   m_machineID & " ) And ([Machine Attributes].[Attribute Type ID] = " &
                   MachineAttID & ")"

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    Try

                        oledbAdapter.Fill(ds)

                        If (ds.Tables(0).Rows.Count > 0) Then

                            childRow.Properties.Value = ds.Tables(0).Rows(0).Item("Value").ToString()

                        End If

                        ds.Tables.Clear()


                    Catch ex As Exception

                        MessageBox.Show(ex.Message)


                    End Try

                End If
DoNext:
            Next childRow

        Next row

        ds.Dispose()

        oledbAdapter.Dispose()

        connection.Close()

        If connection IsNot Nothing Then connection = Nothing
        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
        If ds IsNot Nothing Then ds = Nothing


    End Sub


    Private Sub vgMachSettings_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgMachSettings.CellValueChanged
        Dim sql As String = Nothing
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim connetionString As String = Nothing
        Dim n_Workplane_Type As Long = 0
        Dim n_Units As Long = 0
        Dim b_PartProfile As Boolean
        Dim CTG_Name As String = Nothing
        Dim typeID As Integer
        Dim sTempString As String

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        connection = New OleDbConnection(connetionString)
        Try


            If (e.Row.VisibleIndex > 7) Then
                typeID = GetValueFromDelimitedData(e.Row.Tag, "nRecordID", 0)

                sql = "Update [Machine Attributes] set  [Machine Attributes].[Value] =  " & e.Value &
                        " Where ([Machine Attributes].[Attribute Type ID] = " & typeID & " ) And ([Machine Attributes].[Machine ID] =" & m_machineID & " )"
                connection.Open()

                Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


                cmd.ExecuteNonQuery()

                connection.Close()
            Else
                CTG_Name = UCase(e.Row.Properties.Caption)
                sTempString = GetValueFromDelimitedData(e.Row.Tag, "VBValue", "")

                Select Case CTG_Name
                    Case "HOLDDOWN CTG"

                        If (e.Value = "") Then

                            sql = "UPDATE [Machines] set [Machines].[HOLDDOWN_CTG] = '" & DBNull.Value & "' Where ([Machines].[ID] =" & m_machineID & " )"
                        Else

                            sql = "UPDATE [Machines] set [Machines].[HOLDDOWN_CTG] = '" & sTempString & "' Where ([Machines].[ID] =" & m_machineID & " )"
                        End If


                    Case "CLAMP CTG"

                        If (e.Value = "") Then

                            sql = "UPDATE [Machines] set [Machines].[CLAMP_CTG] = '" & DBNull.Value & "' Where ([Machines].[ID] =" & m_machineID & " )"

                        Else
                            sql = "UPDATE [Machines] set [Machines].[CLAMP_CTG] = '" & sTempString & "' Where ([Machines].[ID] =" & m_machineID & " )"
                        End If


                    Case "TABLE CTG"
                        If (e.Value = "") Then

                            sql = "UPDATE [Machines] set [Machines].[TABLE_CTG] = '" & DBNull.Value & "' Where ([Machines].[ID] =" & m_machineID & " )"
                        Else

                            sql = "UPDATE [Machines] set [Machines].[TABLE_CTG] = '" & sTempString & "' Where ([Machines].[ID] =" & m_machineID & " )"

                        End If

                    Case "QUADRANT"

                        If (UCase(e.Value) = "UPPER") Then
                            n_Workplane_Type = 1
                        Else
                            n_Workplane_Type = 2

                        End If

                        sql = "UPDATE [Machines] set [Machines].[Workplane Type ID] = " & n_Workplane_Type & " Where ([Machines].[ID] =" & m_machineID & " )"

                    Case "UNITS"
                        If (UCase(e.Value) = "INCH") Then
                            n_Units = 0

                        Else
                            n_Units = 1

                        End If
                        sql = "UPDATE [Machines] set [Machines].[Units] = " & n_Units & " Where ([Machines].[ID] =" & m_machineID & " )"

                    Case "CODE PART PROFILE"

                        If (e.Value = True) Then
                            b_PartProfile = True

                        Else
                            b_PartProfile = False
                        End If
                        sql = "UPDATE [Machines] set [Machines].[Code Part Profile] = " & b_PartProfile & " Where ([Machines].[ID] =" & m_machineID & " )"

                    Case "DEFAULT CNC FILE PATH"

                        sql = "UPDATE [Machines] set [Machines].[CNC_Folder] = '" & sTempString & "' Where ([Machines].[ID] =" & m_machineID & " )"

                End Select


                connection.Open()

                Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                connection.Close()

            End If

        Catch ex As Exception

            MessageBox.Show("Update Command Error: " & "< " & sql & " >" & ex.Message)

        End Try

    End Sub

    Protected Sub TV_Config_MouseUp(sender As Object, e As MouseEventArgs) Handles TV_Config.MouseUp
        Dim itemtype As Long

        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            Dim TreeList As TreeList = DirectCast(sender, TreeList)
            _hitInfo = TreeList.CalcHitInfo(e.Location)

            TV_Config.FocusedNode = _hitInfo.Node

            itemtype = TreeItemType(TV_Config.FocusedNode)

            PopUp_TV_Config.ItemLinks.Clear()

            If _hitInfo.HitInfoType = HitInfoType.Cell Then
                Select Case itemtype
                    Case TAG_MACHINE_ROOT_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "MachineTypeNode" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_MACHINE_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "MachineNode" Then
                                nMachineNodeIndex = TV_Config.GetNodeIndex(_hitInfo.Node)


                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_STATION_ROOT_NODE
                        'Handled in ubgStations because of the grid type used

                    Case TAG_TOOL_SETUP_ROOT_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "ToolSetupRootNode" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next
                    Case TAG_TOOL_SETUP_NODE

                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "ToolSetupNode" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_LAYER_SETUP_ROOT_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LayerSetupRootNode" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next


                    Case TAG_LAYER_SETUP_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LayerSetupNode" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next
                    Case TAG_LAYER_MAP_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LayerNode" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_MATERIAL_ROOT_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "MaterialType" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_MATERIAL_CATEGORY_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "Material" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_MATERIAL_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "SpecificMaterial" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next

                    Case TAG_OPERATION_ROOT_NODE
                    Case TAG_OPERATION_LEAD_ROOT_NODE
                    Case TAG_OPERATION_LEAD_PARAM_ROOT_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LeadParamAdd" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next
                    Case TAG_OPERATION_LEAD_PARAM_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LeadParamRemove" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next
                    Case TAG_OPERATION_LEAD_SETUP_ROOT_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LeadSetupAdd" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next
                    Case TAG_OPERATION_LEAD_SETUP_NODE
                        For Each item As BarItem In CFG_Man_BarMan.Items
                            If item.Category.Name = "LeadSetupRemove" Then
                                PopUp_TV_Config.AddItem(item)
                            End If
                        Next
                End Select

                PopUp_TV_Config.ShowPopup(Control.MousePosition)

            End If

        End If

    End Sub

    Private Sub ToolSetupView_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles ToolSetupView.CellValueChanged

        Dim sql As String
        Dim nStationID As Long
        Dim connection As OleDbConnection
        Dim connetionString As String = Nothing
        Dim vRealValue As Object
        Dim sTranslatedFieldName As String = Nothing


        Try

            nStationID = ToolSetupView.GetRowCellValue(ToolSetupView.FocusedRowHandle, ToolSetupView.Columns("StationID")).ToString()

            m_toolSetupID = TV_Config.FocusedNode.Tag

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            If (e.Value.GetType = GetType(Boolean)) Then

                If (e.Value = False) Then
                    vRealValue = 0
                Else
                    vRealValue = 1
                End If

            Else

                vRealValue = e.Value

            End If

            Select Case UCase(e.Column.FieldName)

                Case "INDEXANGLE"
                    sTranslatedFieldName = "Index Angle"

                Case "FIXEDSTATION"
                    sTranslatedFieldName = "Fixed Station"

                Case Else

                    sTranslatedFieldName = e.Column.ToString

            End Select

            If (UCase(e.Column.FieldName) <> "TOOLDESCRIPTION" And UCase(e.Column.FieldName) <> "ORDERID") Then
                sql = "UPDATE [Tool Setup Members] set [Tool Setup Members].[" & sTranslatedFieldName & "] = '" & vRealValue &
                        "' Where ([Tool Setup Members].[Tool Setup ID] = " & m_toolSetupID & ")" &
                        " And ([Tool Setup Members].[Station ID] = " & nStationID & ")"

                connection.Open()

                Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)

                cmd.ExecuteNonQuery()

                connection.Close()

                If connection IsNot Nothing Then connection = Nothing

            End If
        Catch ex As Exception

            ' MessageBox.Show("ToolSetupView_CellValueChanged: " & ex.Message)

        End Try

    End Sub

    Private Sub ToolSetupView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles ToolSetupView.CustomDrawRowIndicator
        Dim rowIndex As Integer = e.RowHandle

        If Not e.Info.IsRowIndicator Then
            e.Info.DisplayText = "Station"
        End If

        If rowIndex >= 0 Then
            rowIndex += 1

            e.Info.DisplayText = rowIndex.ToString()

            e.Info.DisplayText = ToolSetupView.GetRowCellValue(e.RowHandle, ToolSetupView.Columns("Station")).ToString()

        End If
    End Sub
    Private Sub InitToolSetupGrid(ByVal ToolSetupID As Long, ByVal m_machineID As Long)
        Dim sql As String
        Dim ds = New DataSet()
        Dim sMyNCCodeNumber As String
        Dim lMyStationID As Long
        Dim sMyPrimaryCode As String
        Dim sMyToolDescription As String
        Dim lMyOrderID As Long
        Dim lMyToolID As Long
        Dim dMyIndexAngle As Double
        Dim bMyFixedSation As Boolean
        Dim DoAdd As Boolean
        Dim rowHandle As Long
        Dim lDescriptionLength As Long
        Dim lStationLength As Long
        Dim lFixedAngleLength As Long
        Dim lIndexAngleLength As Long
        Dim nOverallGridWidth As Long

        n_UpperBoundOrderID = 0 ' used to store the upper bound value of the orderid's

        lStationLength = GetMinStringWidth("Station", Me.ubgStations.Font)
        lFixedAngleLength = GetMinStringWidth("Index Angle", Me.ubgStations.Font)
        lIndexAngleLength = GetMinStringWidth("Fixed Station", Me.ubgStations.Font)
        lDescriptionLength = 0

        gridDataList.Clear()
        xgStations.DataSource = Nothing

        xgStations.SuspendLayout()

        ToolSetupView.Columns.Clear()

        ToolSetupView.IndicatorWidth = 80
        'Dim filePath As String = "C:\_Gary\AI\toolsetups.csv" ' Specify your file path

        'Using sw As StreamWriter = File.AppendText(filePath)



        Dim connection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';")


        ToolSetupView.ViewCaption = "Station Information"

            sql = "SELECT [Tool Setup Members].[Tool Setup ID], [Tool Setup Members].[Index Angle]," &
                "[Station Configuration].[NC Code Number],[Station Configuration].[WorkPlane Id],[Station Configuration].[Station Location X]," &
                "[Station Configuration].[Station Location Y],[Station Configuration].[Primary Code], [Station Configuration].[Secondary Code]," &
                "[Station Configuration].[Auto Index],[Tool Crib].Description, [Tool Setup Members].[Tool ID]," &
                "[Tool Setup Members].[Station ID], [Tool Setup Members].[Fixed Station], [Tool Setup Members].ID" &
                " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] ON " &
                "[Station Configuration].ID = [Tool Setup Members].[Station ID]) ON [Tool Crib].ID = " &
                "[Tool Setup Members].[Tool ID] WHERE ((([Tool Setup Members].[Tool Setup ID])=" &
                ToolSetupID & " ))" & " ORDER BY [Tool Setup Members].ID"

            InitFillDS(ds, Nothing, sql, connection)

        'stoolsetupname as string = gettoolsetupname
        'sw.WriteLine("[")
        'sw.WriteLine("{")
        'sw.WriteLine(Chr(34) & "Name" & Chr(34) & ": " & Chr(34) & TV_Config.FocusedNode.GetDisplayText(0) & Chr(34) & ",")
        'sw.WriteLine(Chr(34) & "MachineID" & Chr(34) & ": " & m_machineID & ",")
        'sw.WriteLine(Chr(34) & "StationTools" & Chr(34) & ": {")

        Dim tableNumber = 0
        For i = 0 To ds.Tables(tableNumber).Rows.Count - 1
            sMyNCCodeNumber = Convert.ToString(ds.Tables(tableNumber).Rows(i)("NC Code Number"))
            lMyStationID = ds.Tables(tableNumber).Rows(i)("Station ID")
            sMyToolDescription = Convert.ToString(ds.Tables(tableNumber).Rows(i)("Description"))
            sMyPrimaryCode = Convert.ToString(ds.Tables(tableNumber).Rows(i)("Primary Code"))
            lMyOrderID = ds.Tables(tableNumber).Rows(i)("ID")
            lMyToolID = ds.Tables(tableNumber).Rows(i)("Tool ID")
            dMyIndexAngle = ds.Tables(tableNumber).Rows(i)("Index Angle")
                bMyFixedSation = ds.Tables(tableNumber).Rows(i)("Fixed Station")

                Dim wkplaneid As String = ds.Tables(tableNumber).Rows(i)("WorkPlane Id")
                dStationLocX = ds.Tables(tableNumber).Rows(i)("Station Location X")
                dStationLocY = ds.Tables(tableNumber).Rows(i)("Station Location Y")
                Dim bAutoIndex As String = ds.Tables(tableNumber).Rows(i)("Auto Index")
                Dim sSecondaryCode As String = ds.Tables(tableNumber).Rows(i)("Secondary Code")
                If (GetMinStringWidth(sMyToolDescription, Me.ubgStations.Font) > lDescriptionLength) Then

                lDescriptionLength = GetMinStringWidth(sMyToolDescription, Me.ubgStations.Font)

            End If

            gridDataList.Add(New StationMembers(sMyNCCodeNumber, lMyStationID, sMyToolDescription, lMyToolID, lMyOrderID, dMyIndexAngle, bMyFixedSation, sMyPrimaryCode))

                Dim sToolTypeID As String = GetToolTypeFromID(lMyToolID)


            'sw.WriteLine(Chr(34) & sMyNCCodeNumber & Chr(34) & ": {" & Chr(34) & "Description" & Chr(34) & ":" & Chr(34) & sMyToolDescription & Chr(34) &
            '    "," & Chr(34) & "Type" & Chr(34) & ":" & sToolTypeID & "," & Chr(34) & "ToolID" & Chr(34) & ":" & lMyToolID & "," & Chr(34) & "WorkPlaneID" & Chr(34) & ": " & wkplaneid _
            '    & "," & Chr(34) & "StationLocationX" & Chr(34) & ":" & dStationLocX & "," & Chr(34) _
            '    & "StationLocationY" & Chr(34) & ":" & dStationLocY & "," & Chr(34) & "AutoIndex" & Chr(34) & ":" & Chr(34) _
            '    & bAutoIndex & Chr(34) & "," & Chr(34) & "PrimaryCode" & Chr(34) & ":" & Chr(34) & sMyPrimaryCode & Chr(34) _
            '    & "," & Chr(34) & "SecondaryCode" & Chr(34) & ":" & Chr(34) & sSecondaryCode & Chr(34) & "},")


            'SecondaryCode
            n_UpperBoundOrderID = lMyOrderID

        Next i
        ds.Dispose()

            'sw.WriteLine("   }")
            'sw.WriteLine("},")
            'sw.WriteLine("{")
            Me.xgStations.DataSource = gridDataList

        'Get the rest of the stations
        sql = "Select * FROM [Station Configuration] WHERE [Machine ID] = " & m_machineID & " ORDER BY [NC Code Number]"

        InitFillDS(ds, Nothing, sql, connection)

        For i = 0 To ds.Tables(tableNumber).Rows.Count - 1
            DoAdd = True
            For i2 = 0 To ToolSetupView.RowCount - 1
                rowHandle = ToolSetupView.GetRowHandle(i2)
                If (ds.Tables(tableNumber).Rows(i)("NC Code Number")) = ToolSetupView.GetRowCellValue(i2, ToolSetupView.Columns("Station")).ToString() Then

                    DoAdd = False
                    Exit For
                End If

            Next

            If (DoAdd = True) Then
                sMyNCCodeNumber = Convert.ToString(ds.Tables(tableNumber).Rows(i)("NC Code Number"))
                lMyStationID = Convert.ToString(ds.Tables(tableNumber).Rows(i)("ID"))
                sMyPrimaryCode = Convert.ToString(ds.Tables(tableNumber).Rows(i)("Primary Code"))
                gridDataList.Add(New StationMembers(sMyNCCodeNumber, lMyStationID, "", 0, 9000, 0, False, sMyPrimaryCode))
            End If
        Next
        ds.Dispose()

        Me.xgStations.DataSource = gridDataList

        If (lDescriptionLength = 0) Then

            lDescriptionLength = 150

        End If
        ToolSetupView.Columns("ToolDescription").Width = lDescriptionLength

        'ToolSetupView.Columns("OrderID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        ToolSetupView.IndicatorWidth = 80

        ToolSetupView.Columns("ToolID").Visible = False
        ToolSetupView.Columns("Station").Visible = False
        ToolSetupView.Columns("StationID").Visible = False
        ToolSetupView.Columns("OrderID").Visible = False
        ToolSetupView.Columns("ToolDescription").OptionsColumn.AllowEdit = False
        ToolSetupView.Columns("PrimaryCode").OptionsColumn.AllowEdit = False


        nOverallGridWidth = lStationLength + lFixedAngleLength + lIndexAngleLength + lDescriptionLength + 20

        pnlToolSetups.Width = nOverallGridWidth + nOverallGridWidth + ToolSetupView.IndicatorWidth + 30
        Me.Width = TV_Config.Width + nOverallGridWidth + nOverallGridWidth + ToolSetupView.IndicatorWidth + 30

        xgStations.ResumeLayout()

        ToolSetupView.BestFitColumns()
        ' End Using

    End Sub




    Private Sub cmdToolCribAdd_Click(sender As Object, e As EventArgs) Handles cmdToolCribAdd.Click
        If (cmdToolCribAdd.Text = "Add") Then
            m_ToolCribMode = MODE_ADD
            lstToolSetupAvailTools.Enabled = False
            cmdToolCribAdd.Text = "Apply"
            cmdToolCribEdit.Text = "Cancel"
            cmdToolCribEdit.Enabled = True
            cmdToolCribRemove.Enabled = False
            pnlToolingParameters.Visible = True
            pnlToolingParameters.BringToFront()
            FillToolAttributes(CInt((TryCast(cboToolSetupAvailTools.EditValue, myItemData)).ItemData.ToString()))



        Else
            AddRecordToToolCrib(CInt((TryCast(cboToolSetupAvailTools.EditValue, myItemData)).ItemData.ToString()))
            m_ToolCribMode = MODE_FINISH
            lstToolSetupAvailTools.Enabled = True
            cmdToolCribAdd.Text = "Add"
            cmdToolCribEdit.Text = "Edit"
            cmdToolCribRemove.Enabled = True
            pnlToolingParameters.Visible = False
            pnlToolingParameters.SendToBack()

        End If
    End Sub
    Private Sub AddRecordToToolCrib(ByVal tlType As Long)
        Dim m_cnToolCrib As New OleDb.OleDbConnection
        Dim m_daToolCrib As New OleDb.OleDbDataAdapter
        Dim m_dtToolCrib As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtToolCrib.NewRow()
        Dim connetionString As String
        Dim cmdGetID As New OleDbCommand
        Dim sToolDescript As String = ""
        Dim firstloop As Boolean = True
        Dim sFieldName As String = ""
        Dim sFieldValue As String = ""
        Dim dFieldValue As Double
        Dim nFieldValue As Int32
        Dim tlColor As Long
        Dim nID As Long
        Dim nTlIndex As Integer


        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

                m_cnToolCrib = New OleDbConnection(connetionString)


        If (m_ToolCribMode = MODE_ADD) Then

            tbToolCribParamFields.Text = "[Type ID]"
            tbToolCribParamValues.Text = tlType


            For Each row As CategoryRow In vgToolParameters.Rows

                Dim childRows As VGridRows = row.ChildRows

                For Each childRow As EditorRow In childRows

                    If (UCase(childRow.Properties.Caption) <> "ID") Then

                        sFieldName = "[" & childRow.Properties.Caption & "]"

                        If (UCase(childRow.Properties.Caption) = "COLOR") Then

                            sFieldValue = ColorTranslator.ToOle(childRow.Properties.Value)
                            tlColor = sFieldValue

                        Else

                            sFieldValue = "'" & childRow.Properties.Value & "'"

                        End If

                    End If

                    If (UCase(childRow.Properties.Caption) = "DESCRIPTION") Then

                        sToolDescript = childRow.Properties.Value

                    End If

                    If (childRow.Properties.RowType.Name = "Boolean") Then
                        sFieldValue = IIf((childRow.Properties.Value = True), 1, 0)


                    End If
                    tbToolCribParamFields.Text = tbToolCribParamFields.Text & "," & sFieldName
                    tbToolCribParamValues.Text = tbToolCribParamValues.Text & "," & sFieldValue

                    firstloop = False

                Next childRow

            Next row


            sql = "INSERT INTO [Tool Crib] (" & tbToolCribParamFields.Text & " ) VALUES(" & tbToolCribParamValues.Text & ")"



            Try

                m_cnToolCrib.Open()

                m_daToolCrib.InsertCommand = New OleDbCommand(sql, m_cnToolCrib)

                m_daToolCrib.InsertCommand.ExecuteNonQuery()

                cmdGetID.Connection = m_cnToolCrib
                cmdGetID.CommandText = "SELECT MAX(ID) FROM [Tool Crib]"

                nID = cmdGetID.ExecuteScalar

                lstToolSetupAvailTools.Items.Add(New myItemData(sToolDescript, nID, tlColor))
            Catch ex As Exception

                MsgBox(ex.ToString)

            End Try

        ElseIf (m_ToolCribMode = MODE_EDIT) Then

            sql = "Select [Tool Crib].* From [Tool Crib] Where ([Tool Crib].ID = " & nMyToolID & " )"
            m_dtToolCrib = ConnectToCMDB(sql)

            For Each row As CategoryRow In vgToolParameters.Rows

                Dim childRows As VGridRows = row.ChildRows

                For Each childRow As EditorRow In childRows

                    Dim rowType As Type = childRow.Properties.RowType

                    If (UCase(childRow.Properties.Caption) <> "ID") Then

                        sFieldName = childRow.Properties.Caption

                        Select Case UCase(rowType.Name)
                            Case "COLOR"
                                m_dtToolCrib.Rows(0)(sFieldName) = ColorTranslator.ToOle(childRow.Properties.Value)



                            Case "DOUBLE"
                                dFieldValue = CDbl(Val(childRow.Properties.Value))
                                m_dtToolCrib.Rows(0)(sFieldName) = dFieldValue

                            Case "STRING"
                                m_dtToolCrib.Rows(0)(sFieldName) = childRow.Properties.Value

                            Case "INT32"
                                nFieldValue = CInt(Val(childRow.Properties.Value))
                                m_dtToolCrib.Rows(0)(sFieldName) = nFieldValue

                        End Select

                    End If

                Next childRow

            Next row

            nTlIndex = lstToolSetupAvailTools.SelectedIndex

            m_daCMDB.Update(m_dtToolCrib)

            FillToolListBasedOnType(lstToolSetupAvailTools, (TryCast(cboToolSetupAvailTools.EditValue, myItemData)).ItemData.ToString())

            lstToolSetupAvailTools.SelectedIndex = nTlIndex

        End If
skip:

        m_cnToolCrib.Close()

    End Sub
    Private Sub cboToolSetupAvailTools_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboToolSetupAvailTools.SelectedIndexChanged
        If lstToolSetupAvailTools.ItemCount > 0 Then
            lstToolSetupAvailTools.SelectedIndex = 0
            cmdToolCribRemove.Enabled = True
            Me.cmdToolCribEdit.Enabled = True
        Else
            cmdToolCribRemove.Enabled = False
            Me.cmdToolCribEdit.Enabled = False
        End If
    End Sub
    Private Sub GetToolAttributesFromToolID(lMytoolId As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String


        Dim nNumOfRows As Integer
        Dim nI As Integer
        Dim sDisplayString As String
        Dim sValue

        If (lMytoolId > 0) Then


            nNumOfRows = vgToolParameters.Rows(0).ChildRows.Count

            nI = 0

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"


            connection = New OleDbConnection(connetionString)


            sql = "SELECT * FROM [Tool Crib] WHERE [ID] = " & lMytoolId

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()



            For nI = 0 To nNumOfRows - 1
                sDisplayString = vgToolParameters.Rows(0).ChildRows(nI).Properties.Caption
                sValue = ds.Tables(0).Rows(0).Item(sDisplayString)

                If (sDisplayString = "Color") Then
                    sValue = System.Drawing.ColorTranslator.FromOle(CInt(ds.Tables(0).Rows(0).Item(sDisplayString)))
                End If
                vgToolParameters.Rows(0).ChildRows(nI).Properties.Value = sValue
            Next

            ds.Dispose()

            If connection IsNot Nothing Then connection = Nothing
            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
            If ds IsNot Nothing Then ds = Nothing


        End If


    End Sub

    Private Sub cmdToolCribEdit_Click(sender As Object, e As EventArgs) Handles cmdToolCribEdit.Click
        If (cmdToolCribEdit.Text = "Edit") Then
            lstToolSetupAvailTools.Enabled = False
            m_ToolCribMode = MODE_EDIT
            cmdToolCribAdd.Text = "Apply"
            cmdToolCribEdit.Text = "Cancel"
            cmdToolCribRemove.Enabled = False
            pnlToolingParameters.Visible = True
            pnlToolingParameters.BringToFront()

            FillToolAttributes(CInt((TryCast(cboToolSetupAvailTools.EditValue, myItemData)).ItemData.ToString()))

            GetToolAttributesFromToolID(nMyToolID)

        Else
            m_ToolCribMode = MODE_FINISH
            lstToolSetupAvailTools.Enabled = True
            cmdToolCribAdd.Text = "Add"
            cmdToolCribEdit.Text = "Edit"
            cmdToolCribRemove.Enabled = True
            lstToolSetupAvailTools.Enabled = True
            pnlToolingParameters.Visible = False
            pnlToolingParameters.SendToBack()

        End If

    End Sub



    Private Sub cmdRemoveTool_Click(sender As Object, e As EventArgs) Handles cmdRemoveTool.Click
        Dim view = ToolSetupView
        Dim index = view.FocusedRowHandle

        ToolSetupView.SetRowCellValue(index, "ToolDescription", Nothing)
        ToolSetupView.SetRowCellValue(index, "OrderID", 9000)
        ToolSetupView.SetRowCellValue(index, "ToolID", Nothing)
        ToolSetupView.SetRowCellValue(index, "Index Angle", 0)
        ToolSetupView.SetRowCellValue(index, "Fixed Station", False)
        ToolSetupView.Columns("OrderID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        ToolSetupView.RefreshData()

    End Sub

    Private Sub bbADD_MACHINE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbADD_MACHINE.ItemClick
        Dim sAddModeString As String
        Dim n_MachineID As Long

        Try
            CFG_MACHINE_TYPE_NODE = TV_Config.FocusedNode

            sAddModeString = InputBox("Enter New Machine Name:", "New Machine")

            If (sAddModeString <> "") Then
                'Add the machine to the db
                n_MachineID = SaveMachine(sAddModeString, MachineType)

                CFG_MACHINE_NODE = TV_Config.AppendNode(New Object() {sAddModeString}, CFG_MACHINE_TYPE_NODE, n_MachineID)

                CFG_STATION_ROOT_NODE = TV_Config.AppendNode(New Object() {"Stations"}, CFG_MACHINE_NODE, TAG_STATION_ROOT_NODE)

                CFG_TOOL_SETUP_ROOT_NODE = TV_Config.AppendNode(New Object() {"Tool Setups"}, CFG_MACHINE_NODE, TAG_TOOL_SETUP_ROOT_NODE)


                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_MACHINE_NODE
            End If

        Catch ex As Exception
            MessageBox.Show("bbAddMachine: " & ex.Message)

        End Try


    End Sub

    Private Sub lstToolSetupAvailTools_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles lstToolSetupAvailTools.DrawItem
        Dim ColorID As String
        ColorID = DirectCast(lstToolSetupAvailTools.Items(e.Index).sItemData, String)
        e.Appearance.ForeColor = System.Drawing.ColorTranslator.FromOle(CInt(ColorID))

    End Sub
    Private Sub lstToolSetupAvailTools_MouseDown(sender As Object, e As MouseEventArgs) Handles lstToolSetupAvailTools.MouseDown
        Dim c As ListBoxControl = TryCast(sender, ListBoxControl)


        p = New System.Drawing.Point(e.X, e.Y)
        Dim selectedIndex As Integer = c.IndexFromPoint(p)
        If selectedIndex = -1 Then
            p = System.Drawing.Point.Empty
        Else

        End If
    End Sub

    Private Sub lstToolSetupAvailTools_MouseMove(sender As Object, e As MouseEventArgs) Handles lstToolSetupAvailTools.MouseMove
        If e.Button = MouseButtons.Left Then
            If (p <> System.Drawing.Point.Empty) AndAlso ((Math.Abs(e.X - p.X) > 5) OrElse (Math.Abs(e.Y - p.Y) > 5)) Then
                lstToolSetupAvailTools.DoDragDrop(sender, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub xgStations_DragDrop(sender As Object, e As DragEventArgs) Handles xgStations.DragDrop
        Dim s_ToolDescrip As String = ""
        Dim p As System.Drawing.Point = New System.Drawing.Point(e.X, e.Y)
        Dim n_SelIndex As Long
        Dim l_tlid As Long
        Dim nToolID As Long
        Dim StationId As Long
        Dim dIndexAng As Double
        Dim bFixedStation As Boolean
        Dim sql As String
        Dim connetionString As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim cmd As OleDbCommand

        p = xgStations.PointToClient(p)

        Dim hitInfo As GridHitInfo = ToolSetupView.CalcHitInfo(p)

        If hitInfo.InRow Then
            'TODO: We should really check to see if we are in the right column

            Dim foo = gridDataList.Item(hitInfo.RowHandle).OrderID

            n_SelIndex = Me.lstToolSetupAvailTools.SelectedIndex
            l_tlid = (TryCast(lstToolSetupAvailTools.Items(n_SelIndex), myItemData)).ItemData.ToString()

            s_ToolDescrip = lstToolSetupAvailTools.SelectedItem.ToString
            ToolSetupView.SetRowCellValue(hitInfo.RowHandle, "ToolDescription", s_ToolDescrip)

            ToolSetupView.SetRowCellValue(hitInfo.RowHandle, "ToolID", l_tlid)
            ToolSetupView.SetRowCellValue(hitInfo.RowHandle, "OrderID", n_UpperBoundOrderID + 1)


            '********************************************************************************
            StationId = ToolSetupView.GetRowCellValue(hitInfo.RowHandle, ToolSetupView.Columns("StationID")).ToString()
            dIndexAng = ToolSetupView.GetRowCellValue(hitInfo.RowHandle, ToolSetupView.Columns("IndexAngle")).ToString()
            bFixedStation = ToolSetupView.GetRowCellValue(hitInfo.RowHandle, ToolSetupView.Columns("FixedStation")).ToString()
            nToolID = ToolSetupView.GetRowCellValue(hitInfo.RowHandle, ToolSetupView.Columns("ToolID")).ToString()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"


            connection = New OleDbConnection(connetionString)


            connection.Open()

            sql = "Update [Tool Setup Members] set  [Tool Setup Members].[Tool Setup ID] =  '" & m_toolSetupID & "' Where " &
                        "[Tool Setup Members].[ID] = " & foo & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Tool Setup Members] set  [Tool Setup Members].[Station ID] =  '" & StationId & "' Where " &
                        "[Tool Setup Members].[ID] = " & foo & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Tool Setup Members] set  [Tool Setup Members].[Tool ID] =  '" & nToolID & "' Where " &
                        "[Tool Setup Members].[ID] = " & foo & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Tool Setup Members] set  [Tool Setup Members].[Fixed Station] =  '" & bFixedStation & "' Where " &
                        "[Tool Setup Members].[ID] = " & foo & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()


            sql = "Update [Tool Setup Members] set  [Tool Setup Members].[Index Angle] =  '" & dIndexAng & "' Where " &
                        "[Tool Setup Members].[ID] = " & foo & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            connection.Close()
            AssignToolToStation(m_toolSetupID, StationId, dIndexAng, bFixedStation, nToolID)

        End If

    End Sub

    Private Sub xgStations_DragOver(sender As Object, e As DragEventArgs) Handles xgStations.DragOver
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub ShowHitInfo(ByVal hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)
        '********************************************
        'This is strictly used for debugging purposes.
        'If you want to debug the information just uncomment the following lines
        '********************************************


        'lbHitTest.Text = hi.HitTest.ToString()

        'If hi.Column Is Nothing Then
        '    lbColumn.Text = "No column"
        'Else
        '    lbColumn.Text = hi.Column.GetTextCaption()
        'End If
        'lbRow.Text = hi.RowHandle.ToString()
        'If hi.Column Is Nothing OrElse hi.RowHandle = -1 Then
        '    lbCellValue.Text = " "

        'End If

    End Sub

    Private Sub xgStations_MouseMove(sender As Object, e As MouseEventArgs) Handles xgStations.MouseMove
        ShowHitInfo(ToolSetupView.CalcHitInfo(New System.Drawing.Point(e.X, e.Y)))
    End Sub
    Private Sub AssignTheTools()
        Dim sql As String
        Dim ni As Long = 0
        Dim nToolID As Long
        Dim StationId As Long
        Dim dIndexAng As Double
        Dim bFixedStation As Boolean
        Dim sDescrip As String
        Dim dt1 As DataTable = Nothing
        Dim dt2 As DataTable = Nothing

        Try

            sql = "DELETE * FROM [Tool Setup Members] WHERE [Tool Setup ID] =" & m_toolSetupID
            dt1 = ConnectToCMDB(sql)


            sql = "SELECT * FROM [Tool Setup Members]"
            dt2 = ConnectToCMDB(sql)

            For ni = 0 To ToolSetupView.RowCount() - 1

                If (IsNothing(ToolSetupView.GetRowCellValue(ni, ToolSetupView.Columns("ToolDescription"))) = False) Then

                    sDescrip = ToolSetupView.GetRowCellValue(ni, ToolSetupView.Columns("ToolDescription")).ToString()
                    If (sDescrip <> "") Then
                        StationId = ToolSetupView.GetRowCellValue(ni, ToolSetupView.Columns("StationID")).ToString()
                        dIndexAng = ToolSetupView.GetRowCellValue(ni, ToolSetupView.Columns("IndexAngle")).ToString()
                        bFixedStation = ToolSetupView.GetRowCellValue(ni, ToolSetupView.Columns("FixedStation")).ToString()
                        nToolID = ToolSetupView.GetRowCellValue(ni, ToolSetupView.Columns("ToolID")).ToString()

                        AssignToolToStation(m_toolSetupID, StationId, dIndexAng, bFixedStation, nToolID)
                    End If
                End If
            Next

            dt1.Dispose()
            dt2.Dispose()
            DatabaseClose()


        Catch ex As ArgumentException

            MessageBox.Show("AssignTheTools: " & ex.Message)
        End Try

    End Sub

    Private Sub MachineRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles MachineRemove.ItemClick

        Dim sql As String
        Dim dt1 As DataTable = Nothing

        Try
            If (m_machineID > 0) Then
                sql = "DELETE * FROM [Machines] WHERE [ID] = " & m_machineID

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If

            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()
        Catch ex As ArgumentException

            MessageBox.Show("MachineRemove: " & ex.Message)
        End Try

    End Sub

    Private Sub MachineCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles MachineCopy.ItemClick
        Dim sNewMachineName As String
        Dim nNewMachineID As Long
        Dim nCurrentMachineID As Long
        Dim sCurrentMachineName As String
        Dim dtOriginal As DataTable = Nothing
        Dim dtCopy As DataTable = Nothing
        Dim sql As String
        Dim ni As Long = 0

        Try

            nCurrentMachineID = m_machineID

            m_machineType = GetMachineType(m_machineID)

            sCurrentMachineName = GetMachineDescription(nCurrentMachineID)

            CFG_MACHINE_TYPE_NODE = TV_Config.FocusedNode.ParentNode

            sNewMachineName = InputBox("Enter New Machine Name: ", "Copy Machine")

            If (sNewMachineName <> "") Then

                'Add the machine to the db
                nNewMachineID = SaveMachine(sNewMachineName, m_machineType)

                CFG_MACHINE_NODE = TV_Config.AppendNode(New Object() {sNewMachineName}, CFG_MACHINE_TYPE_NODE, nNewMachineID)

                CFG_STATION_ROOT_NODE = TV_Config.AppendNode(New Object() {"Stations"}, CFG_MACHINE_NODE, TAG_STATION_ROOT_NODE)

                CFG_TOOL_SETUP_ROOT_NODE = TV_Config.AppendNode(New Object() {"Tool Setups"}, CFG_MACHINE_NODE, TAG_TOOL_SETUP_ROOT_NODE)


                sql = "Select [Machine Attributes].* From [Machine Attributes] Where ([Machine Attributes].[Machine ID] = " & m_machineID & ")"
                dtOriginal = ConnectToCMDB(sql)

                dtCopy = ConnectToCMDB("Select [Machine Attributes].* From [Machine Attributes]")

                For ni = 0 To dtOriginal.Rows.Count - 1

                    Dim drCopiedRow As DataRow = dtCopy.NewRow()

                    drCopiedRow("Attribute Type ID") = dtOriginal.Rows(ni).Item("Attribute Type ID")
                    drCopiedRow("Machine ID") = nNewMachineID
                    drCopiedRow("Value") = dtOriginal.Rows(ni).Item("Value")

                    dtCopy.Rows.Add(drCopiedRow)
                    m_daCMDB.Update(dtCopy)
                Next

                CopyStationRows(nCurrentMachineID, nNewMachineID)

                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_MACHINE_NODE

            End If

            dtOriginal.Dispose()
            dtCopy.Dispose()

        Catch ex As ArgumentException

            MessageBox.Show("MachineCopy: " & ex.Message)

        End Try

    End Sub
    Private Sub CopyStationRows(n_MachineID As Integer, n_NewMachineID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim dtOriginalStationRows As DataTable = Nothing
        Dim dtNewStationRows As DataTable = Nothing

        sql = "SELECT * FROM [Station Configuration] WHERE ([Machine ID] = " &
                n_MachineID & " ) ORDER BY [NC Code Number]"

        Try
            dtOriginalStationRows = ConnectToCMDB(sql)

            dtNewStationRows = ConnectToCMDB("SELECT * FROM [Station Configuration]")

            For i = 0 To dtOriginalStationRows.Rows.Count - 1

                Dim drCopiedRow As DataRow = dtNewStationRows.NewRow()


                drCopiedRow("Machine ID") = n_NewMachineID
                drCopiedRow("Workplane ID") = CInt(dtOriginalStationRows.Rows(i).Item("Workplane ID"))
                drCopiedRow("Station Location X") = CDbl(dtOriginalStationRows.Rows(i).Item("Station Location X"))
                drCopiedRow("Station Location Y") = CDbl(dtOriginalStationRows.Rows(i).Item("Station Location Y"))
                drCopiedRow("Auto Index") = CBool(dtOriginalStationRows.Rows(i).Item("Auto Index"))
                drCopiedRow("Primary Code") = CStr(dtOriginalStationRows.Rows(i).Item("Primary Code"))
                drCopiedRow("Secondary Code") = CStr(dtOriginalStationRows.Rows(i).Item("Secondary Code"))
                drCopiedRow("NC Code Number") = CStr(dtOriginalStationRows.Rows(i).Item("NC Code Number"))
                drCopiedRow("Station Size") = CInt(dtOriginalStationRows.Rows(i).Item("Station Size"))

                dtNewStationRows.Rows.Add(drCopiedRow)
                m_daCMDB.Update(dtNewStationRows)

            Next

            dtOriginalStationRows.Dispose()
            dtNewStationRows.Dispose()

        Catch ex As Exception

            MessageBox.Show("CopyStationRows: " & ex.Message)

        End Try

    End Sub

    Private Sub MachineRename_ItemClick(sender As Object, e As ItemClickEventArgs) Handles MachineRename.ItemClick
        Dim sql As String
        Dim dtMachineRename As DataTable = Nothing
        Dim sNewMachineName As String

        Try

            sNewMachineName = InputBox("Enter New Machine Name: ", "Copy Machine")

            If (sNewMachineName <> "") Then

                If (m_machineID > 0) Then
                    sql = "Select * FROM [Machines] WHERE [ID] = " & m_machineID

                    dtMachineRename = ConnectToCMDB(sql)
                    dtMachineRename.Rows(0)("Description") = sNewMachineName

                End If

                m_daCMDB.Update(dtMachineRename)

                TV_Config.FocusedNode(0) = sNewMachineName


            End If

            If dtMachineRename IsNot Nothing Then
                dtMachineRename.Dispose()
            End If


            TV_Config.Refresh()

        Catch ex As ArgumentException

            MessageBox.Show("MachineRename: " & ex.Message)
        End Try


    End Sub

    Private Sub ToolSetupAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ToolSetupAdd.ItemClick
        Dim sql As String
        Dim dtToolSetupTable As DataTable
        Dim sToolSetupName As String
        Dim n_ToolSetupID As Long
        Dim cmdGetID As New OleDbCommand


        Try
            m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.GetDisplayText(0))

            If (CheckForStationsBeforeProceeding(m_machineID) = False) Then

            End If

            sql = "SELECT * FROM [Station Configuration] WHERE ([Machine ID] =" & m_machineID & "  )"

            dtToolSetupTable = ConnectToCMDB(sql)

            If (dtToolSetupTable.Rows.Count <= 0) Then
                MessageBox.Show("Your machine must contain at least 1 station in order to create a tool setup!", "Invalid Station Setup", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                GoTo EarlyExit

            End If

            sql = "Select * From [Tool Setups]"

            sToolSetupName = InputBox("Enter New Tool Setup Name: ", "Tool Setup")

            If (sToolSetupName = "") Then

                Exit Sub

            End If

            dtToolSetupTable = ConnectToCMDB(sql)

            Dim drRow As DataRow = dtToolSetupTable.NewRow()


            drRow("Machine ID") = m_machineID
            drRow("Description") = sToolSetupName

            dtToolSetupTable.Rows.Add(drRow)
            m_daCMDB.Update(dtToolSetupTable)

            dtToolSetupTable.Dispose()

            n_ToolSetupID = GetNewID("Tool Setups")


            CFG_TOOL_SETUP_ROOT_NODE = TV_Config.FocusedNode

            CFG_TOOL_SETUP_NODE = TV_Config.AppendNode(New Object() {sToolSetupName}, CFG_TOOL_SETUP_ROOT_NODE, n_ToolSetupID)
            CFG_LAYER_SETUP_ROOT_NODE = TV_Config.AppendNode(New Object() {"Layer Setups"}, CFG_TOOL_SETUP_NODE, TAG_LAYER_SETUP_ROOT_NODE)

            TV_Config.Refresh()
            TV_Config.FocusedNode = CFG_TOOL_SETUP_NODE

        Catch ex As ArgumentException

            MessageBox.Show("ToolSetupAdd: " & ex.Message)


        End Try
EarlyExit:

    End Sub

    Private Sub ToolSetupRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ToolSetupRemove.ItemClick
        Dim sql As String
        Dim dt1 As DataTable = Nothing

        Try
            bRemoveToolSetup = True

            If (m_toolSetupID > 0) Then
                sql = "DELETE * From [Tool Setups] Where ([Tool Setups].ID = " & m_toolSetupID & " )"

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If

            dt1.Dispose()

            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()

            bRemoveToolSetup = False

        Catch ex As ArgumentException

            MessageBox.Show("ToolSetupRemove: " & ex.Message)
        End Try
    End Sub

    Private Sub ToolSetupCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ToolSetupCopy.ItemClick
        Dim sql As String
        Dim sToolSetupName As String
        Dim dtNewToolSetupTable As DataTable
        Dim dtOrgToolSetupTable As DataTable
        Dim n_OrgToolSetupID As Long
        Dim n_NewToolSetupID As Long
        Dim cmdGetID As New OleDbCommand
        Dim ni As Integer

        Try
            n_OrgToolSetupID = modTranslate.GetToolSetupIDFromDescription(TV_Config.FocusedNode.GetDisplayText(0))

            m_machineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.GetDisplayText(0))

            sql = "Select * From [Tool Setups]"

            sToolSetupName = InputBox("Enter New Tool Setup Name: ", "Tool Setup")

            dtNewToolSetupTable = ConnectToCMDB(sql)

            Dim drRow As DataRow = dtNewToolSetupTable.NewRow()


            drRow("Machine ID") = m_machineID
            drRow("Description") = sToolSetupName

            dtNewToolSetupTable.Rows.Add(drRow)

            m_daCMDB.Update(dtNewToolSetupTable)

            n_NewToolSetupID = GetNewID("Tool Setups")

            sql = "SELECT * FROM [Tool Setup Members] WHERE ([Tool Setup ID] = " & n_OrgToolSetupID & " )"

            dtOrgToolSetupTable = ConnectToCMDB(sql)

            sql = "Select * From[Tool Setup Members]"

            dtNewToolSetupTable = ConnectToCMDB(sql)

            For ni = 0 To dtOrgToolSetupTable.Rows.Count - 1

                Dim drCopiedRow As DataRow = dtNewToolSetupTable.NewRow()

                drCopiedRow("Tool Setup ID") = n_NewToolSetupID
                drCopiedRow("Station ID") = CInt(dtOrgToolSetupTable.Rows(ni).Item("Station ID"))
                drCopiedRow("Tool ID") = CInt(dtOrgToolSetupTable.Rows(ni).Item("Tool ID"))
                drCopiedRow("Index Angle") = CInt(dtOrgToolSetupTable.Rows(ni).Item("Index Angle"))
                drCopiedRow("Fixed Station") = CInt(dtOrgToolSetupTable.Rows(ni).Item("Fixed Station"))

                dtNewToolSetupTable.Rows.Add(drCopiedRow)
                m_daCMDB.Update(dtNewToolSetupTable)

            Next

            dtNewToolSetupTable.Dispose()
            dtOrgToolSetupTable.Dispose()

            DatabaseClose()

            CFG_TOOL_SETUP_ROOT_NODE = TV_Config.FocusedNode.ParentNode

            CFG_TOOL_SETUP_NODE = TV_Config.AppendNode(New Object() {sToolSetupName}, CFG_TOOL_SETUP_ROOT_NODE, n_NewToolSetupID)
            CFG_LAYER_SETUP_ROOT_NODE = TV_Config.AppendNode(New Object() {"Layer Setups"}, CFG_TOOL_SETUP_NODE, TAG_LAYER_SETUP_ROOT_NODE)

            TV_Config.Refresh()
            TV_Config.FocusedNode = CFG_TOOL_SETUP_NODE


        Catch ex As ArgumentException

            MessageBox.Show("ToolSetupCopy: " & ex.Message)
        End Try

EarlyExit:

    End Sub

    Private Sub sbAddStation_Click(sender As Object, e As EventArgs) Handles sbAddStation.Click
        Dim sql As String
        Dim dtStationTable As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim ni As Integer
        Dim drCopiedRow As DataRow
        Dim nRowHandle As Long

        Try
            If (ubgStationsView.RowCount > 0) Then


                nRowHandle = ubgStationsView.FocusedRowHandle

                NcCodeNumberHolder = ubgStationsView.GetRowCellValue(nRowHandle, ubgStationsView.Columns("NC Code Number")).ToString()
            Else
                NcCodeNumberHolder = 0
            End If
            sql = "Select * From [Station Configuration]"

            dtStationTable = ConnectToCMDB(sql)

            If (cbfAutoFillStations.Checked = True) Then

                For ni = 1 To CInt(lbtAutoFill.Text)
                    drCopiedRow = dtStationTable.NewRow()

                    NcCodeNumberHolder = NcCodeNumberHolder + 1

                    drCopiedRow("Machine ID") = m_machineID
                    drCopiedRow("WorkPlane ID") = 1
                    drCopiedRow("NC Code Number") = NcCodeNumberHolder
                    drCopiedRow("Station Location X") = 0
                    drCopiedRow("Station Location Y") = 0
                    drCopiedRow("Auto Index") = False
                    drCopiedRow("Station Size") = 0
                    drCopiedRow("Primary Code") = 0
                    drCopiedRow("Secondary Code") = 0

                    dtStationTable.Rows.Add(drCopiedRow)
                    m_daCMDB.Update(dtStationTable)

                Next
            Else

                drCopiedRow = dtStationTable.NewRow()

                drCopiedRow("Machine ID") = m_machineID
                drCopiedRow("WorkPlane ID") = 1
                drCopiedRow("NC Code Number") = (NcCodeNumberHolder + 1)
                drCopiedRow("Station Location X") = 0
                drCopiedRow("Station Location Y") = 0
                drCopiedRow("Auto Index") = False
                drCopiedRow("Station Size") = 0
                drCopiedRow("Primary Code") = 0
                drCopiedRow("Secondary Code") = 0

                dtStationTable.Rows.Add(drCopiedRow)
                m_daCMDB.Update(dtStationTable)

            End If

            dtStationTable.Dispose()
            DatabaseClose()
            cbfAutoFillStations.Checked = False
            InitStations()




        Catch ex As ArgumentException

            MessageBox.Show("sbAddStation: " & ex.Message)
        End Try

EarlyExit:


    End Sub

    Private Sub sbRemoveStation_Click(sender As Object, e As EventArgs) Handles sbRemoveStation.Click
        Dim sql As String
        Dim nStationID As Long
        Dim dtStationTable As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim bMessageResult As Long


        Try

            nStationID = ubgStationsView.GetFocusedRowCellValue("ID")

            sql = "Select [Tool Setup Members].* From [Tool Setup Members] Where ([Tool Setup Members].[Station ID] =" &
            nStationID & ")"

            dtStationTable = ConnectToCMDB(sql)

            If (dtStationTable.Rows.Count > 0) Then

                bMessageResult = MessageBox.Show("Station is used by (" & dtStationTable.Rows.Count - 1 & ") Setup(s). Are you sure you wish to remove it?", "Remove Station", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If (bMessageResult = System.Windows.Forms.DialogResult.Yes) Then

                    sql = "Delete [Station Configuration].* From [Station Configuration] " &
                            "Where ([Station Configuration].ID = " & nStationID & " )"

                    dtStationTable = ConnectToCMDB(sql)

                    DatabaseClose()

                End If
            Else

                sql = "Delete [Station Configuration].* From [Station Configuration] " &
                            "Where ([Station Configuration].ID = " & nStationID & " )"

                dtStationTable = ConnectToCMDB(sql)

                DatabaseClose()

            End If

            dtStationTable.Dispose()
            InitStations()

        Catch ex As ArgumentException

            MessageBox.Show("sbRemove: " & ex.Message)

        End Try

    End Sub

    Private Sub FillGlobalLayerInfo(ByVal nLayerID As Long)
        Dim sql As String
        Dim dtGlobalLayerInfo As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim nZLevelMode As String
        Dim dSharpAngle As Double
        Dim dCleanTol As Double
        Dim dGapTol As Double
        Dim dFilterTol As Double
        Dim bProcessText As Boolean
        Dim bRestrictOffset As Boolean
        Dim nID As Integer


        Try

            catGlobalLayerInfo.ChildRows.Clear()

            sql = "SELECT * FROM [Layer Setups] WHERE [ID] =" & nLayerID

            dtGlobalLayerInfo = ConnectToCMDB(sql)

            Dim sChoices As New Collection

            sChoices.Clear()
            sChoices.Add("From CAD")
            sChoices.Add("From db")

            nID = dtGlobalLayerInfo.Rows(0).Item("ID")
            dSharpAngle = dtGlobalLayerInfo.Rows(0).Item("Sharp Angle")
            dCleanTol = dtGlobalLayerInfo.Rows(0).Item("Clean Tolerance")
            dGapTol = dtGlobalLayerInfo.Rows(0).Item("Gap Tolerance")
            dFilterTol = dtGlobalLayerInfo.Rows(0).Item("Filter Tolerance")
            bProcessText = dtGlobalLayerInfo.Rows(0).Item("ProcessText")
            bRestrictOffset = dtGlobalLayerInfo.Rows(0).Item("Restrict_Offset")

            nZLevelMode = IIf(dtGlobalLayerInfo.Rows(0).Item("Z Level Mode") = 0, "From CAD", "From db")
            catGlobalLayerInfo.ChildRows.Add(CreateComboBoxEditorRow(vgGlobalLayerInfo, "Z Level Mode", "Z Level Mode", nID, nZLevelMode, sChoices))
            catGlobalLayerInfo.ChildRows.Add(CreateDoubleEditorRow(vgGlobalLayerInfo,
                                                                   "Sharp Angle",
                                                                   "Sharp Angle",
                                                                   dSharpAngle,
                                                                   dSharpAngle,
                                                                   "Sharp Angle",
                                                                   DB_DBL, nID, sEmpty, 0))

            catGlobalLayerInfo.ChildRows.Add(CreateDoubleEditorRow(vgGlobalLayerInfo,
                                                                   "Clean Tolerance",
                                                                   "Clean Tolerance",
                                                                   dCleanTol,
                                                                   dCleanTol,
                                                                   "Clean Tolerance",
                                                                   DB_DBL, nID, sEmpty, -0))

            catGlobalLayerInfo.ChildRows.Add(CreateDoubleEditorRow(vgGlobalLayerInfo,
                                                                   "Gap Tolerance",
                                                                   "Gap Tolerance",
                                                                   dGapTol,
                                                                   dGapTol,
                                                                   "Gap Tolerance",
                                                                   DB_DBL, nID, sEmpty, 0))


            catGlobalLayerInfo.ChildRows.Add(CreateDoubleEditorRow(vgGlobalLayerInfo,
                                                                   "Filter Tolerance",
                                                                   "Filter Tolerance",
                                                                   dFilterTol,
                                                                   dFilterTol,
                                                                   "Filter Tolerance",
                                                                   DB_DBL, nID, sEmpty, 0))


            catGlobalLayerInfo.ChildRows.Add(CreateBooleanEditorRow(vgGlobalLayerInfo,
                                                                    "ProcessText",
                                                                    "Process Text",
                                                                    bProcessText,
                                                                    bProcessText,
                                                                    "ProcessText",
                                                                    DB_BOOL, nID, sEmpty, 0))

            catGlobalLayerInfo.ChildRows.Add(CreateBooleanEditorRow(vgGlobalLayerInfo,
                                                                    "Restrict_Offset",
                                                                    "Restrict Offset",
                                                                    bRestrictOffset,
                                                                    bRestrictOffset,
                                                                    "Restrict_Offset",
                                                                    DB_BOOL, nID, sEmpty, 0))

            dtGlobalLayerInfo.Dispose()

        Catch ex As ArgumentException

            MessageBox.Show("FillGlobalLayerInfo: " & ex.Message)


        End Try
    End Sub

    Private Sub FillLayerInfo(ByVal nLayerInfoID As Long)
        Dim sql As String
        Dim ni As Long
        Dim dtLayerInfo As DataTable
        Dim sCadLayer As String = Nothing
        Dim sCamLayer As String = Nothing
        Dim dZLevel As Double
        Dim lColor As System.Drawing.Color
        Dim sStation As String = Nothing
        Dim nCutDir As Integer
        Dim nCutSide As Integer
        Dim dDistance As Double
        Dim sCutDirection As String
        Dim sChoicesCutSide As New Collection
        Dim sChoicesCutDir As New Collection
        Dim sChoicesStation As New Collection
        Dim sStationText As String
        Dim sStationCheck As String
        Dim sStationDefault As String = Nothing
        Dim nid As Integer


        Dim sCutSide As String = "None"

        sCutDirection = Nothing

        catLayerInformation.ChildRows.Clear()

        sql = "SELECT * FROM [Directives] WHERE [ID] =" & nLayerInfoID

        dtLayerInfo = ConnectToCMDB(sql)
        If (dtLayerInfo.Rows.Count > 0) Then
            nid = dtLayerInfo.Rows(0).Item("ID")
            sCadLayer = dtLayerInfo.Rows(0).Item("CAD Layer")
            sCamLayer = dtLayerInfo.Rows(0).Item("CAM Layer")
            dZLevel = dtLayerInfo.Rows(0).Item("Z Level")

            lColor = ColorTranslator.FromOle(dtLayerInfo.Rows(0).Item("Color"))
            sStation = dtLayerInfo.Rows(0).Item("Station")

            nCutDir = dtLayerInfo.Rows(0).Item("Cut Direction")
            nCutSide = dtLayerInfo.Rows(0).Item("Cut Side")
            dDistance = dtLayerInfo.Rows(0).Item("Distance")

        End If

        catLayerInformation.ChildRows.Add(CreateStringEditorRow(vgLayerInfo,
                                                                "CAD Layer",
                                                                "CAD Layer",
                                                                sCadLayer,
                                                                sCadLayer,
                                                                "CAD Layer",
                                                                DB_STR, nid, sEmpty, 0))

        catLayerInformation.ChildRows.Add(CreateStringEditorRow(vgLayerInfo,
                                                                "CAM Layer",
                                                                "CAM Layer",
                                                                sCamLayer,
                                                                sCamLayer,
                                                                "CAM Layer",
                                                                DB_STR, nid, sEmpty, 0))

        catLayerInformation.ChildRows.Add(CreateDoubleEditorRow(vgLayerInfo,
                                                                "Z Level",
                                                                "Z Level",
                                                                dZLevel,
                                                                dZLevel,
                                                                "Z Level",
                                                                DB_DBL, nid, sEmpty, 0))

        catLayerInformation.ChildRows.Add(CreateColorEditEditorRow(vgLayerInfo, "Color", "Color", nid, lColor))

        sChoicesStation.Clear()

        For ni = 0 To cbLayerTools.Properties.Items.Count - 1

            sStationText = cbLayerTools.Properties.Items(ni).ToString()

            sChoicesStation.Add(sStationText)

            sStationCheck = Mid(sStationText, 2, InStr(sStationText, "]") - 2)

            Select Case UCase(sStationText)
                Case "[**AUTO**]"

                    sStationDefault = "[**Auto**]"
                    'Exit For

                Case "[NONE]"

                    sStationDefault = "[None]"
                    'Exit For

                Case Else

                    If (sStationCheck = sStation) Then

                        sStationDefault = sStationText
                        'Exit For

                    End If

            End Select

        Next

        catLayerInformation.ChildRows.Add(CreateComboBoxEditorRow(vgLayerInfo, "Station", "Station", nid, sStationDefault, sChoicesStation))

        sChoicesCutDir.Clear()
        sChoicesCutDir.Add("CW")
        sChoicesCutDir.Add("CCW")
        sChoicesCutDir.Add("Auto")
        sChoicesCutDir.Add("As Specified")

        Select Case nCutDir

            Case 0 '"CW"
                sCutDirection = "CW"
            Case 1 '"CCW"
                sCutDirection = "CCW"
            Case 2 '"Auto"
                sCutDirection = "Auto"
            Case 3 '"As Specified"
                sCutDirection = "As Specified"

        End Select

        catLayerInformation.ChildRows.Add(CreateComboBoxEditorRow(vgLayerInfo, "Cut Direction", "Cut Direction", nid, sCutDirection, sChoicesCutDir))

        sChoicesCutSide.Clear()
        sChoicesCutSide.Add("None")
        sChoicesCutSide.Add("Left")
        sChoicesCutSide.Add("Right")


        Select Case nCutSide
            Case -1 'Right
                sCutSide = "Right"
            Case 0 'None
                sCutSide = "None"
            Case 1 'Left
                sCutSide = "Left"
        End Select

        dtLayerInfo.Dispose()

        catLayerInformation.ChildRows.Add(CreateComboBoxEditorRow(vgLayerInfo, "Cut Side", "Cut Side", nid, sCutSide, sChoicesCutSide))
        catLayerInformation.ChildRows.Add(CreateDoubleEditorRow(vgLayerInfo,
                                                                "Distance",
                                                                "Distance",
                                                                dDistance,
                                                                dDistance,
                                                                "Distance",
                                                                DB_DBL, nid, sEmpty, 0))

        vgLayerInfo.BestFit()
    End Sub

    Private Sub FillComboWithTools(ByVal m_toolSetupID As Long)
        Dim sql As String
        Dim dtToolStation As DataTable
        Dim ni As Integer
        Dim sToolDescription As String
        Dim sStaionName As String



        Try

            cbLayerTools.Properties.Items.Clear()
            'addd the generic items. All toolsetups have the following 2 choices
            cbLayerTools.Properties.Items.Add("[**Auto**]")

            cbLayerTools.Properties.Items.Add("[None]")


            'get the tools from the current toolsetp 
            sql = "SELECT [Tool Setup Members].[Tool Setup ID], [Tool Setup Members].[Index Angle]," &
                    "[Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[Tool ID]," &
                    "[Tool Setup Members].[Station ID], [Tool Setup Members].[Fixed Station], [Tool Setup Members].ID" &
                    " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] ON " &
                    "[Station Configuration].ID = [Tool Setup Members].[Station ID]) ON [Tool Crib].ID = " &
                    "[Tool Setup Members].[Tool ID] WHERE ((([Tool Setup Members].[Tool Setup ID])=" &
                    m_toolSetupID & " ))" & " ORDER BY [Station Configuration].[NC Code Number]"

            dtToolStation = ConnectToCMDB(sql)

            For ni = 0 To dtToolStation.Rows.Count - 1

                sToolDescription = dtToolStation.Rows(ni).Item("Description")
                sStaionName = dtToolStation.Rows(ni).Item("NC Code Number")

                cbLayerTools.Properties.Items.Add("[" & sStaionName & "] " & sToolDescription)

            Next

            dtToolStation.Dispose()

        Catch ex As ArgumentException

            MessageBox.Show("FillGlobalLayerInfo: " & ex.Message)


        End Try
    End Sub

    Private Sub LayerSetupAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LayerSetupAdd.ItemClick
        Dim sAddModeString As String
        Dim n_LayerSetupID As Long


        Try
            CFG_LAYER_SETUP_ROOT_NODE = TV_Config.FocusedNode

            sAddModeString = InputBox("Enter New Layer Setup Name:", "New Machine")

            If (sAddModeString <> "") Then
                'Add the Layer Setup to the db
                n_LayerSetupID = SaveLayerSetup(sAddModeString, m_machineID)

                CFG_LAYER_SETUP_NODE = TV_Config.AppendNode(New Object() {sAddModeString}, CFG_LAYER_SETUP_ROOT_NODE, n_LayerSetupID)

                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_LAYER_SETUP_NODE
            End If

        Catch ex As Exception
            MessageBox.Show("bbAddMachine: " & ex.Message)

        End Try
    End Sub

    Private Function SaveLayerSetup(ByVal sAddModeString As String, ByVal lMachineId As Long) As Long
        Dim m_cnLayerSetup As New OleDb.OleDbConnection
        Dim m_daLayerSetup As OleDb.OleDbDataAdapter
        Dim m_cbLayerSetup As OleDb.OleDbCommandBuilder
        Dim m_dtLayerSetup As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtLayerSetup.NewRow()
        Dim cmdGetID As New OleDbCommand

        sql = "SELECT [Layer Setups].* FROM [Layer Setups]"

        Try

            m_cnLayerSetup.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathCMDB()
            m_cnLayerSetup.Open()
            m_daLayerSetup = New OleDb.OleDbDataAdapter(sql, m_cnLayerSetup)
            m_cbLayerSetup = New OleDb.OleDbCommandBuilder(m_daLayerSetup)
            m_cbLayerSetup.QuotePrefix = "["
            m_cbLayerSetup.QuoteSuffix = "]"
            m_daLayerSetup.Fill(m_dtLayerSetup)

            drNewRow("Description") = sAddModeString
            drNewRow("Machine ID") = lMachineId
            drNewRow("Z Level Mode") = 1
            drNewRow("Sharp Angle") = 60
            drNewRow("Clean Tolerance") = DEFAULT_TOL
            drNewRow("Gap Tolerance") = DEFAULT_TOL
            drNewRow("Filter Tolerance") = DEFAULT_TOL
            drNewRow("ProcessText") = False
            drNewRow("Restrict_Offset") = False


            m_dtLayerSetup.Rows.Add(drNewRow)
            m_daLayerSetup.Update(m_dtLayerSetup)


            cmdGetID.Connection = m_cnLayerSetup
            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Layer Setups]"



            SaveLayerSetup = cmdGetID.ExecuteScalar

            m_dtLayerSetup.Dispose()
            m_daLayerSetup.Dispose()

            m_cnLayerSetup.Close()

            If m_cnLayerSetup IsNot Nothing Then m_cnLayerSetup = Nothing
            If m_daLayerSetup IsNot Nothing Then m_daLayerSetup = Nothing
            If m_dtLayerSetup IsNot Nothing Then m_dtLayerSetup = Nothing


        Catch ex As Exception

            SaveLayerSetup = -1

            MessageBox.Show("SaveMachine: " & ex.Message)

        End Try

    End Function

    Private Sub LayerRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LayerRemove.ItemClick
        Dim sql As String
        Dim dt1 As DataTable = Nothing
        Dim n_MachineID As Integer

        Try
            n_MachineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0))
            m_layerSetupID = modTranslate.GetLayerSetupID(TV_Config.FocusedNode.GetDisplayText(0), n_MachineID)

            If (m_layerSetupID > 0) Then
                sql = "DELETE * From [Layer Setups] Where ([Layer Setups].ID = " & m_layerSetupID & " )"

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If

            dt1.Dispose()

            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()

        Catch ex As ArgumentException

            MessageBox.Show("LayerRemove: " & ex.Message)
        End Try

    End Sub

    Private Sub LayerAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LayerAdd.ItemClick
        Dim m_cnLayerSetup As New OleDb.OleDbConnection
        Dim m_daLayerSetup As OleDb.OleDbDataAdapter
        Dim m_cbLayerSetup As OleDb.OleDbCommandBuilder
        Dim m_dtLayerSetup As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtLayerSetup.NewRow()
        Dim cmdGetID As New OleDbCommand
        Dim n_LayerNameID As Long
        Dim n_MachineID As Integer

        sql = "Select Directives.* From Directives"

        Try
            n_MachineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0))
            m_layerSetupID = modTranslate.GetLayerSetupID(TV_Config.FocusedNode.GetDisplayText(0), n_MachineID)
            m_cnLayerSetup.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathCMDB()
            m_cnLayerSetup.Open()
            m_daLayerSetup = New OleDb.OleDbDataAdapter(sql, m_cnLayerSetup)
            m_cbLayerSetup = New OleDb.OleDbCommandBuilder(m_daLayerSetup)
            m_cbLayerSetup.QuotePrefix = "["
            m_cbLayerSetup.QuoteSuffix = "]"
            m_daLayerSetup.Fill(m_dtLayerSetup)


            drNewRow("Layer Setup ID") = m_layerSetupID
            drNewRow("CAD Layer") = "New Layer"
            drNewRow("CAM Layer") = "CAM Layer"
            drNewRow("Z Level") = 0
            drNewRow("Color") = 16776960
            drNewRow("Station") = "None"
            drNewRow("Cut Direction") = 2
            drNewRow("Cut Side") = 1
            drNewRow("Distance") = 0



            m_dtLayerSetup.Rows.Add(drNewRow)
            m_daLayerSetup.Update(m_dtLayerSetup)


            cmdGetID.Connection = m_cnLayerSetup
            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Directives]"

            n_LayerNameID = cmdGetID.ExecuteScalar

            CFG_LAYER_MAP_NODE = TV_Config.AppendNode(New Object() {"New Layer"}, TV_Config.FocusedNode, n_LayerNameID)

            TV_Config.Refresh()

            TV_Config.FocusedNode = CFG_LAYER_MAP_NODE
            m_dtLayerSetup.Dispose()

            FillLayerInfo(n_LayerNameID)

            If m_cnLayerSetup IsNot Nothing Then m_cnLayerSetup = Nothing
            If m_daLayerSetup IsNot Nothing Then m_daLayerSetup = Nothing
            If m_dtLayerSetup IsNot Nothing Then m_dtLayerSetup = Nothing

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub LayerNameRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LayerNameRemove.ItemClick
        Dim sql As String
        Dim dt1 As DataTable = Nothing
        Dim n_layerid As Long


        Try
            n_layerid = GetLayerID(TV_Config.FocusedNode.GetDisplayText(0))

            If (m_machineID > 0) Then
                sql = "DELETE Directives.* From Directives Where (Directives.ID = " & n_layerid & " )"

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If


            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()
        Catch ex As ArgumentException

            MessageBox.Show("MachineRemove: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdToolCribRemove_Click(sender As Object, e As EventArgs) Handles cmdToolCribRemove.Click
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String = Nothing
        Dim toolID As Long
        Dim Result As DialogResult
        Dim dt1 As DataTable = Nothing


        If (lstToolSetupAvailTools.SelectedIndex > -1) Then

            toolID = (TryCast(lstToolSetupAvailTools.Items(lstToolSetupAvailTools.SelectedIndex), myItemData)).ItemData.ToString()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            sql = "SELECT * FROM [Tool Setup Members] WHERE ([Tool ID]=" & toolID & ")"

            connection = New OleDbConnection(connetionString)

            Try
                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                sql = Nothing


                oledbAdapter.Fill(ds)

                If (ds.Tables(0).Rows.Count > 0) Then

                    Result = MessageBox.Show("This tool is used by (" & ds.Tables(0).Rows.Count & ") Setup(s). Are you sure you wish to remove it?", "Warning", MessageBoxButtons.YesNo)

                    If (Result = Windows.Forms.DialogResult.Yes) Then

                        sql = "DELETE * FROM [Tool Crib] WHERE (ID=" & toolID & ")"

                    End If

                Else
                    sql = "DELETE * FROM [Tool Crib] WHERE (ID=" & toolID & ")"

                End If


                oledbAdapter.Dispose()

                If (sql <> Nothing) Then

                    lstToolSetupAvailTools.Items.Remove(lstToolSetupAvailTools.SelectedItem)


                    If (toolID > 0) Then

                        dt1 = ConnectToCMDB(sql)

                        DatabaseClose()

                    End If

                    dt1.Dispose()

                End If

                oledbAdapter.Dispose()
                connection.Close()

                If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                'Check if the tool is used in other setups
            Catch ex As Exception

                MessageBox.Show("cmdToolCribRemove: " & ex.Message)
            Finally

                If ds IsNot Nothing Then ds = Nothing

                If connection IsNot Nothing Then connection = Nothing

            End Try

        End If
    End Sub

    Private Sub lstToolSetupAvailTools_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstToolSetupAvailTools.SelectedIndexChanged
        Dim n_SelIndex As Integer

        n_SelIndex = Me.lstToolSetupAvailTools.SelectedIndex
        If (n_SelIndex >= 0) Then
            nMyToolID = (TryCast(lstToolSetupAvailTools.Items(n_SelIndex), myItemData)).ItemData.ToString()
        End If


    End Sub

    Private Sub AddMaterialType_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AddMaterialType.ItemClick
        Dim sAddModeString As String
        Dim nMaterialID As Integer

        Try
            CFG_MATERIAL_NODE = TV_Config.FocusedNode


            sAddModeString = InputBox("Enter Material Type: ", "Material Type")

            m_MaterialID = modTranslate.GetMaterialTypeID(TV_Config.FocusedNode.GetDisplayText(0))

            If sAddModeString <> "" Then
                nMaterialID = AddMaterialTypeToDB(sAddModeString)


                CFG_MATERIAL_NODE = TV_Config.AppendNode(New Object() {sAddModeString}, CFG_MATERIAL_NODE, nMaterialID)

                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_MATERIAL_NODE

            End If

        Catch ex As Exception
            MessageBox.Show("AddMaterialType_ItemClick: " & ex.Message)

        End Try


    End Sub


    Private Sub bbRemoveMaterialType_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbRemoveMaterialType.ItemClick
        Dim sql As String
        Dim dt1 As DataTable = Nothing

        m_MaterialID = modTranslate.GetMaterialTypeID(TV_Config.FocusedNode.GetDisplayText(0))

        Try
            If (m_MaterialID > 0) Then
                sql = "DELETE * FROM [Material Types] WHERE [ID] = " & m_MaterialID

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If


            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()
        Catch ex As ArgumentException

            MessageBox.Show("MachineRemove: " & ex.Message)
        End Try
    End Sub

    Private Sub bbAddMaterial_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAddMaterial.ItemClick
        Dim sAddModeString As String
        Dim n_MaterialD As Long

        Try
            CFG_MATERIAL_CATEGORY_NODE = TV_Config.FocusedNode

            sAddModeString = InputBox("Enter New Material Name:", "New Material")

            If (sAddModeString <> "") Then
                m_MaterialTypeID = modTranslate.GetMaterialTypeID(TV_Config.FocusedNode.GetDisplayText(0))

                n_MaterialD = SaveMaterial(sAddModeString, m_MaterialTypeID)

                CFG_MATERIAL_NODE = TV_Config.AppendNode(New Object() {sAddModeString}, CFG_MATERIAL_CATEGORY_NODE, n_MaterialD)


                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_MATERIAL_NODE
                FillMaterialInfo(n_MaterialD)
            End If

        Catch ex As Exception
            MessageBox.Show("bbAddMaterial: " & ex.Message)

        End Try


    End Sub

    Private Sub FillMaterialInfo(ByVal nMaterialID As Integer)
        Dim dtMaterialInfo As DataTable
        Dim sMaterialDescription As String
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim dWeight As Double
        Dim nQty As Integer
        Dim dCostPerUnit As Double
        Dim sql As String
        Dim nID As Integer
        Dim sGreg As String

        catMaterialInfo.ChildRows.Clear()

        sql = "SELECT * FROM [Material Inventory] WHERE [ID] =" & nMaterialID

        dtMaterialInfo = ConnectToCMDB(sql)

        sMaterialDescription = dtMaterialInfo.Rows(0).Item("Description")
        nID = dtMaterialInfo.Rows(0).Item("ID")
        dLength = dtMaterialInfo.Rows(0).Item("Length")
        dWidth = dtMaterialInfo.Rows(0).Item("Width")
        dThickness = dtMaterialInfo.Rows(0).Item("Thickness")
        dWeight = dtMaterialInfo.Rows(0).Item("Weight")
        nQty = dtMaterialInfo.Rows(0).Item("Quantity")
        dCostPerUnit = dtMaterialInfo.Rows(0).Item("Cost Per Unit")


        catMaterialInfo.ChildRows.Add(CreateStringEditorRow(vgMaterialInfo,
                                                            "Description",
                                                            "Description",
                                                            sMaterialDescription,
                                                            sMaterialDescription,
                                                            "Description",
                                                            DB_STR, nID, sEmpty, 0))



        catMaterialInfo.ChildRows.Add(CreateDoubleEditorRow(vgMaterialInfo,
                                                            "Length",
                                                            "Length",
                                                            dLength,
                                                            dLength,
                                                            "Length",
                                                            DB_DBL, nID, sEmpty, 0))

        catMaterialInfo.ChildRows.Add(CreateDoubleEditorRow(vgMaterialInfo,
                                                            "Width",
                                                            "Width",
                                                            dWidth,
                                                            dWidth,
                                                            "Width",
                                                            DB_DBL, nID, sEmpty, 0))

        catMaterialInfo.ChildRows.Add(CreateDoubleEditorRow(vgMaterialInfo,
                                                            "Thickness",
                                                            "Thickness",
                                                            dThickness,
                                                            dThickness,
                                                            "Thickness",
                                                            DB_DBL, nID, sEmpty, 0))

        catMaterialInfo.ChildRows.Add(CreateDoubleEditorRow(vgMaterialInfo,
                                                            "Weight",
                                                            "Weight",
                                                            dWeight,
                                                            dWeight,
                                                            "Weight",
                                                            DB_DBL, nID, sEmpty, 0))

        catMaterialInfo.ChildRows.Add(CreateDoubleEditorRow(vgMaterialInfo,
                                                             "Cost Per Unit",
                                                             "Cost Per Unit",
                                                             dCostPerUnit,
                                                             dCostPerUnit,
                                                             "Cost Per Unit",
                                                             DB_DBL, nID, sEmpty, 0))

        catMaterialInfo.ChildRows.Add(CreateIntegerEditorRow(vgMaterialInfo,
                                                             "Quantity",
                                                             "Quantity",
                                                             nQty,
                                                             nQty,
                                                             "Quantity",
                                                             DB_INT, nID, sEmpty, 0))



        dtMaterialInfo.Dispose()


    End Sub

    Private Sub bbSpecificMaterialRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSpecificMaterialRemove.ItemClick
        Dim sql As String
        Dim dt1 As DataTable = Nothing

        m_MaterialID = modTranslate.GetMaterialIDFromDescription(TV_Config.FocusedNode.GetDisplayText(0))

        Try
            If (m_MaterialID > 0) Then
                sql = "DELETE * FROM [Material Inventory] WHERE [ID] = " & m_MaterialID

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If


            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()
        Catch ex As ArgumentException

            MessageBox.Show("bbSpecificMaterialRemove: " & ex.Message)
        End Try
    End Sub

    Private Sub bbLeadParamAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbLeadParamAdd.ItemClick
        Dim sAddModeString As String


        Try
            CFG_OPERATION_LEAD_PARAM_ROOT_NODE = TV_Config.FocusedNode


            sAddModeString = InputBox("Enter New Lead Parameter Name:", "New Lead Parameter")

            If (sAddModeString <> "") Then

                m_LeadSetupID = SaveLeadParam(sAddModeString)

                CFG_OPERATION_LEAD_PARAM_NODE = TV_Config.AppendNode(New Object() {sAddModeString}, CFG_OPERATION_LEAD_PARAM_ROOT_NODE, m_LeadSetupID)


                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_OPERATION_LEAD_PARAM_NODE

                LoadLeadParamCombos()

            End If

        Catch ex As Exception
            MessageBox.Show("bbLeadParamAdd: " & ex.Message)

        End Try


    End Sub

    Private Sub vgMaterialInfo_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgMaterialInfo.CellValueChanged

        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim sCaption As String
        Dim nDisplay As Integer


        nDisplay = e.Row.VisibleIndex - 1
        sCaption = vgMaterialInfo.Rows(0).ChildRows(nDisplay).Properties.Caption

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Update [Material Inventory] set  [Material Inventory].[" & sCaption & "] =  '" & e.Value & "' Where " &
                "[Material Inventory].[ID] = " & m_MaterialID & ""

        connection = New OleDbConnection(connetionString)

        Try
            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


            cmd.ExecuteNonQuery()

            connection.Close()

        Catch ex As Exception

            MessageBox.Show("Update Command Error: " & ex.Message)

        End Try
    End Sub

    Private Sub vgMaterialInfo_ShownEditor(sender As Object, e As EventArgs) Handles vgMaterialInfo.ShownEditor
        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)
    End Sub

    Delegate Sub FocusTextHandler(ByRef VerticalGrid)

    Private Sub FocusText(ByRef TheVerticalGrid)

        If TypeOf TheVerticalGrid.ActiveEditor Is TextEdit And TheVerticalGrid.ActiveEditor.EditorTypeName <> "ColorEdit" Then
            Dim edit As TextEdit = TryCast(TheVerticalGrid.ActiveEditor, TextEdit)
            edit.SelectionStart = 0
            edit.SelectionLength = (CStr(edit.EditValue)).Length

        End If
    End Sub

    Private Sub InitLeadParameterPanel()
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim nID As Long
        Dim sDisplayStr As String


        cboLeadType.Properties.Items.Clear()

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Select [Lead Types].* From [Lead Types]"

        connection = New OleDbConnection(connetionString)

        Try


            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            For i = 0 To ds.Tables(0).Rows.Count - 1

                sDisplayStr = ds.Tables(0).Rows(i).Item("Description")

                If (UCase(sDisplayStr) <> "RAMP") Then
                    nID = ds.Tables(0).Rows(i).Item("ID")
                    cboLeadType.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                End If

            Next

            cboLeadType.SelectedIndex = 0

            FillToolTypes(cboLeadToolType, 1)

            cboLeadToolType.SelectedIndex = 2

            cboLeadLocation.Properties.Items.Add(New myItemData("1 O 'Clock (Top/Right)", 0))
            cboLeadLocation.Properties.Items.Add(New myItemData("2 O 'Clock (Right/Top)", 1))
            cboLeadLocation.Properties.Items.Add(New myItemData("3 O 'Clock (Right)", 2))
            cboLeadLocation.Properties.Items.Add(New myItemData("4 O 'Clock (Right/Bottom)", 3))
            cboLeadLocation.Properties.Items.Add(New myItemData("5 O 'Clock (Bottom/Right)", 4))
            cboLeadLocation.Properties.Items.Add(New myItemData("6 O 'Clock (Bottom)", 5))
            cboLeadLocation.Properties.Items.Add(New myItemData("7 O 'Clock (Bottom/Left)", 6))
            cboLeadLocation.Properties.Items.Add(New myItemData("8 O 'Clock (Left/Bottom)", 7))
            cboLeadLocation.Properties.Items.Add(New myItemData("9 O 'Clock (Left)", 8))
            cboLeadLocation.Properties.Items.Add(New myItemData("10 O 'Clock (Left/Top)", 9))
            cboLeadLocation.Properties.Items.Add(New myItemData("11 O 'Clock (Top/Left)", 10))
            cboLeadLocation.Properties.Items.Add(New myItemData("12 O 'Clock (Top)", 11))
            cboLeadLocation.SelectedIndex = 0


            cboSplitLocation.Properties.Items.Add(New myItemData("At Intersection/No Split", 1))
            cboSplitLocation.Properties.Items.Add(New myItemData("30% From Intersection", 3))
            cboSplitLocation.Properties.Items.Add(New myItemData("20% From Intersection", 5))
            cboSplitLocation.Properties.Items.Add(New myItemData("Always Split", 100))
            cboSplitLocation.SelectedIndex = 0

            cboLeadJunction.Properties.Items.Add(New myItemData("Exact", 0))
            cboLeadJunction.Properties.Items.Add(New myItemData("Gap", 1))
            cboLeadJunction.Properties.Items.Add(New myItemData("Overlap", 2))
            cboLeadJunction.Properties.Items.Add(New myItemData("Tab", 3))
            cboLeadJunction.SelectedIndex = 0


        Catch ex As Exception

            MessageBox.Show("InitLeadParameterPanel: " & ex.Message)

        Finally

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing

        End Try

    End Sub

    Private Sub lblLeadLocation_Click(sender As Object, e As EventArgs) Handles lblLeadLocation.Click
        lblLeadLocation.BackColor = GetLabelHighlightedBackColor()
        cboLeadLocation.Focus()
        cboLeadLocation.ShowPopup()
    End Sub

    Private Sub lblJunction_Click(sender As Object, e As EventArgs) Handles lblJunction.Click
        lblJunction.BackColor = GetLabelHighlightedBackColor()
        cboLeadJunction.Focus()
        cboLeadJunction.ShowPopup()
    End Sub

    Private Sub lblLeadType_Click(sender As Object, e As EventArgs) Handles lblLeadType.Click
        lblLeadType.BackColor = GetLabelHighlightedBackColor()
        cboLeadType.Focus()
        cboLeadType.ShowPopup()
    End Sub

    Private Sub lblSplitLocation_Click(sender As Object, e As EventArgs) Handles lblSplitLocation.Click
        lblSplitLocation.BackColor = GetLabelHighlightedBackColor()
        cboSplitLocation.Focus()
        cboSplitLocation.ShowPopup()
    End Sub

    Private Sub lblLeadLength_Click(sender As Object, e As EventArgs) Handles lblLeadLength.Click
        lblLeadLength.BackColor = GetLabelHighlightedBackColor()
        txtLeadLength.Focus()

    End Sub

    Private Sub lblLeadDistance_Click(sender As Object, e As EventArgs) Handles lblLeadDistance.Click
        lblLeadDistance.BackColor = GetLabelHighlightedBackColor()
        txtLeadDistance.Focus()

    End Sub

    Private Sub lblLeadAngle_Click(sender As Object, e As EventArgs) Handles lblLeadAngle.Click
        lblLeadAngle.BackColor = GetLabelHighlightedBackColor()
        txtLeadAngle.Focus()
    End Sub

    Private Sub cboLeadLocation_Enter(sender As Object, e As EventArgs) Handles cboLeadLocation.Enter
        lblLeadLocation.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadLocation_LostFocus(sender As Object, e As EventArgs) Handles cboLeadLocation.LostFocus
        lblLeadLocation.BackColor = Color.Transparent

    End Sub

    Private Sub cboLeadJunction_Enter(sender As Object, e As EventArgs) Handles cboLeadJunction.Enter
        lblJunction.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadJunction_Leave(sender As Object, e As EventArgs) Handles cboLeadJunction.Leave
        lblJunction.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadType_Enter(sender As Object, e As EventArgs) Handles cboLeadType.Enter
        lblLeadType.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadType_Leave(sender As Object, e As EventArgs) Handles cboLeadType.Leave
        lblLeadType.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadType_LostFocus(sender As Object, e As EventArgs) Handles cboLeadType.LostFocus
        lblLeadType.BackColor = Color.Transparent
    End Sub

    Private Sub cboSplitLocation_ContextMenuChanged(sender As Object, e As EventArgs) Handles cboSplitLocation.ContextMenuChanged
        lblSplitLocation.BackColor = Color.Transparent
    End Sub

    Private Sub txtLeadAngle_Enter(sender As Object, e As EventArgs) Handles txtLeadAngle.Enter
        lblLeadAngle.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtLeadAngle_Leave(sender As Object, e As EventArgs) Handles txtLeadAngle.Leave
        lblLeadAngle.BackColor = Color.Transparent
    End Sub

    Private Sub txtLeadDistance_Enter(sender As Object, e As EventArgs) Handles txtLeadDistance.Enter
        lblLeadDistance.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtLeadDistance_Leave(sender As Object, e As EventArgs) Handles txtLeadDistance.Leave
        lblLeadDistance.BackColor = Color.Transparent
    End Sub

    Private Sub txtLeadIncludedAngle_Enter(sender As Object, e As EventArgs) Handles txtLeadIncludedAngle.Enter
        lblLeadIncludedAngle.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtLeadIncludedAngle_Leave(sender As Object, e As EventArgs) Handles txtLeadIncludedAngle.Leave
        lblLeadIncludedAngle.BackColor = Color.Transparent
    End Sub

    Private Sub txtLeadLength_Enter(sender As Object, e As EventArgs) Handles txtLeadLength.Enter
        lblLeadLength.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtLeadLength_Leave(sender As Object, e As EventArgs) Handles txtLeadLength.Leave
        lblLeadLength.BackColor = Color.Transparent
    End Sub

    Private Sub txtRadius_Enter(sender As Object, e As EventArgs) Handles txtRadius.Enter
        lblRadius.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtRadius_Leave(sender As Object, e As EventArgs) Handles txtRadius.Leave
        lblRadius.BackColor = Color.Transparent
    End Sub

    Private Sub cboSplitLocation_Enter(sender As Object, e As EventArgs) Handles cboSplitLocation.Enter
        lblSplitLocation.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboSplitLocation_Leave(sender As Object, e As EventArgs) Handles cboSplitLocation.Leave
        lblSplitLocation.BackColor = Color.Transparent
    End Sub
    Private Sub lblLeadIncludedAngle_Click(sender As Object, e As EventArgs) Handles lblLeadIncludedAngle.Click
        lblLeadIncludedAngle.BackColor = GetLabelHighlightedBackColor()
        txtLeadIncludedAngle.Focus()
    End Sub

    Private Sub lblRadius_Click(sender As Object, e As EventArgs) Handles lblRadius.Click
        lblRadius.BackColor = GetLabelHighlightedBackColor()
        txtRadius.Focus()
    End Sub

    Private Sub lblPierceDistance_Click(sender As Object, e As EventArgs) Handles lblPierceDistance.Click
        lblPierceDistance.BackColor = GetLabelHighlightedBackColor()
        txtPierceDistance.Focus()
    End Sub

    Private Sub txtPierceDistance_Enter(sender As Object, e As EventArgs) Handles txtPierceDistance.Enter
        lblPierceDistance.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtPierceDistance_Leave(sender As Object, e As EventArgs) Handles txtPierceDistance.Leave
        lblPierceDistance.BackColor = Color.Transparent
    End Sub

    Private Sub lblLeadToolType_Click(sender As Object, e As EventArgs) Handles lblLeadToolType.Click
        lblLeadToolType.BackColor = GetLabelHighlightedBackColor()
        cboLeadToolType.Focus()
        cboLeadToolType.ShowPopup()
    End Sub

    Private Sub cboLeadToolType_Enter(sender As Object, e As EventArgs) Handles cboLeadToolType.Enter
        lblLeadToolType.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtLeadToolType_Leave(sender As Object, e As EventArgs) Handles cboLeadToolType.Leave
        lblLeadToolType.BackColor = Color.Transparent
    End Sub

    Private Sub lblLeadToolDia_Click(sender As Object, e As EventArgs) Handles lblLeadToolDia.Click
        lblLeadToolDia.BackColor = GetLabelHighlightedBackColor()
        txtLeadToolDia.Focus()

    End Sub

    Private Sub txtLeadToolDia_Enter(sender As Object, e As EventArgs) Handles txtLeadToolDia.Enter
        lblLeadToolDia.BackColor = GetLabelHighlightedBackColor()

    End Sub

    Private Sub txtLeadToolDia_Leave(sender As Object, e As EventArgs) Handles txtLeadToolDia.Leave
        lblLeadToolDia.BackColor = Color.Transparent
    End Sub

    Private Sub UpdateLeadParams(ByVal sFieldName, ByVal m_FieldValue)

        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"



        sql = "Update [Lead Parameter] set  [Lead Parameter].[" & sFieldName & "] =  " & m_FieldValue & " Where " &
                "[Lead Parameter].[ID] = " & m_LeadParamID & ""

        connection = New OleDbConnection(connetionString)

        Try
            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


            cmd.ExecuteNonQuery()

            connection.Close()

        Catch ex As Exception

            MessageBox.Show("Update Command Error: " & ex.Message)

        End Try

    End Sub

    Private Sub cboLeadLocation_Validated(sender As Object, e As EventArgs) Handles cboLeadLocation.Validated
        UpdateLeadParams("Location", cboLeadLocation.SelectedIndex)
    End Sub


    Private Sub cboSplitLocation_Validated(sender As Object, e As EventArgs) Handles cboSplitLocation.Validated
        Dim nSplitValue = 0

        Select Case UCase(cboSplitLocation.Text)
            Case "AT INTERSECTION/NO SPLIT"
                nSplitValue = 1
            Case "30% FROM INTERSECTION"
                nSplitValue = 3
            Case "20% FROM INTERSECTION"
                nSplitValue = 5
            Case "ALWAYS SPLIT"
                nSplitValue = 100
        End Select

        UpdateLeadParams("Tolerance", nSplitValue)
    End Sub

    Private Sub cboLeadType_Validated(sender As Object, e As EventArgs) Handles cboLeadType.Validated
        Dim nTypeID As Long

        nTypeID = (TryCast(cboLeadType.SelectedItem, myItemData).ItemData.ToString())

        UpdateLeadParams("Type ID", nTypeID)

    End Sub

    Private Sub cboLeadJunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLeadJunction.SelectedIndexChanged
        If (cboLeadJunction.SelectedIndex > 0) Then

            lblLeadDistance.Visible = True
            txtLeadDistance.Visible = True

        Else

            lblLeadDistance.Visible = False
            txtLeadDistance.Visible = False

        End If
    End Sub
    Private Sub cboLeadJunction_Validated(sender As Object, e As EventArgs) Handles cboLeadJunction.Validated
        Dim nTypeID As Long

        nTypeID = (TryCast(cboLeadJunction.SelectedItem, myItemData).ItemData.ToString())
        UpdateLeadParams("Junction", nTypeID)

    End Sub

    Private Sub txtLeadLength_Validated(sender As Object, e As EventArgs) Handles txtLeadLength.Validated
        UpdateLeadParams("Length", txtLeadLength.Text)
    End Sub

    Private Sub txtLeadLength_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLeadLength.KeyDown
        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send(vbTab)

        End If
    End Sub
    Private Function GetLeadDescripFromID(ByVal LeadParamID As Long) As String
        Dim sql As String
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim nLeadTypeID As Long
        Dim i As Integer
        Dim ni As Integer
        Dim oledbAdapter As OleDbDataAdapter

        GetLeadDescripFromID = Nothing

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            sql = "Select [Lead Parameter].* From [Lead Parameter] Where ([Lead Parameter].ID = " & LeadParamID & ")"

            connection = New OleDbConnection(connetionString)


            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                nLeadTypeID = ds.Tables(0).Rows(i).Item("Type ID")

            Next

            ds.Dispose()


            sql = "Select [Lead Types].* From [Lead Types] Where ([Lead Types].ID = " & nLeadTypeID & " )"
            connection = New OleDbConnection(connetionString)


            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds2)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds2.Tables(0).Rows.Count - 1

                If (ds2.Tables(0).Rows(i).Item("ID") = nLeadTypeID) Then

                    If (IsDBNull(ds2.Tables(0).Rows(i).Item("Display")) = False) Then

                        GetLeadDescripFromID = ds2.Tables(0).Rows(i).Item("Display")

                        For ni = 0 To cboLeadType.Properties.Items.Count - 1

                            If cboLeadType.Properties.Items(ni).ToString = GetLeadDescripFromID Then
                                cboLeadType.SelectedIndex = ni
                                Exit For

                            End If
                        Next

                        Exit Function
                    End If

                End If

            Next

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If ds2 IsNot Nothing Then ds2 = Nothing

            If connection IsNot Nothing Then connection = Nothing


        Catch ex As Exception

            MessageBox.Show("GetLeadDescripFromID: " & ex.Message)

        End Try

    End Function
    Private Sub PopulateLeadParamValues(ByVal LeadParamID As Long)
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim nToolTypeID As Long
        Dim nPierceToolTypeID As Long

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Select [Lead Parameter].* From [Lead Parameter] Where ([Lead Parameter].ID =" & LeadParamID & " )"

        connection = New OleDbConnection(connetionString)

        Try
            InitFillDS(ds, Nothing, sql, connection)

            For i = 0 To ds.Tables(0).Rows.Count - 1

                If (ds.Tables(0).Rows(i).Item("Location") > 0) Then
                    cboLeadLocation.SelectedIndex = ds.Tables(0).Rows(i).Item("Location")
                Else
                    cboLeadLocation.SelectedIndex = 0
                End If

                cboLeadJunction.SelectedIndex = ds.Tables(0).Rows(i).Item("Junction")



                If (cboLeadJunction.SelectedIndex < 3) Then

                    txtLeadLength.Text = ds.Tables(0).Rows(i).Item("Length")
                    lblLeadLength.Text = "Length"

                Else

                    txtLeadLength.Text = ds.Tables(0).Rows(i).Item("Tab Thickness")
                    lblLeadLength.Text = "Tab Thickness"

                End If

                If (cboLeadJunction.SelectedIndex > 0) Then

                    txtLeadDistance.Text = ds.Tables(0).Rows(i).Item("Distance")

                End If

                Select Case ds.Tables(0).Rows(i).Item("Tolerance")
                    Case 1
                        cboSplitLocation.SelectedIndex = 0
                    Case 3
                        cboSplitLocation.SelectedIndex = 1
                    Case 5
                        cboSplitLocation.SelectedIndex = 2
                    Case 100
                        cboSplitLocation.SelectedIndex = 3
                End Select

                Dim sLeadType As String = GetLeadDescripFromID(LeadParamID)

                cboLeadType.SelectedItem = sLeadType


                txtLeadAngle.Text = ds.Tables(0).Rows(i).Item("Angle")

                txtLeadIncludedAngle.Text = ds.Tables(0).Rows(i).Item("Included Angle")
                txtRadius.Text = ds.Tables(0).Rows(i).Item("Radius")

                If (ds.Tables(0).Rows(i).Item("Use Pierce") > 0) Then

                    cbfLeadParam.Checked = True
                    RadioGroup1.SelectedIndex = 0

                    txtPierceDistance.Text = ds.Tables(0).Rows(i).Item("Pierce Offset")
                    txtLeadToolDia.Text = ds.Tables(0).Rows(i).Item("Pierce Diameter")
                    nPierceToolTypeID = ds.Tables(0).Rows(i).Item("Pierce Type ID")

                    If (ds.Tables(0).Rows(i).Item("Use Pierce") = 1) Then
                        RadioGroup1.SelectedIndex = 0
                    ElseIf (ds.Tables(0).Rows(i).Item("Use Pierce") = 2) Then
                        RadioGroup1.SelectedIndex = 1
                    End If

                    If (cboLeadToolType.Properties.Items.Count > 0) Then
                        For ni = 0 To cboLeadToolType.Properties.Items.Count - 0
                            nToolTypeID = TryCast(cboLeadToolType.Properties.Items(ni), myItemData).ItemData.ToString()

                            If (nToolTypeID = nPierceToolTypeID) Then
                                'cboLeadType.SelectedIndex = ni

                                Exit For

                            End If
                        Next
                    End If

                Else

                    cbfLeadParam.Checked = False

                End If

            Next

            If (cboLeadJunction.SelectedIndex > 0) Then

                lblLeadDistance.Visible = True
                txtLeadDistance.Visible = True

            Else

                lblLeadDistance.Visible = False
                txtLeadDistance.Visible = False

            End If


            connection.Close()

        Catch ex As Exception

            MessageBox.Show("PopulateLeadParamValues: " & ex.Message)

        End Try
    End Sub

    Private Sub cboLeadType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLeadType.SelectedIndexChanged
        Dim nTypeID As Long

        txtLeadLength.Visible = False
        lblLeadLength.Visible = False
        txtLeadAngle.Visible = False
        lblLeadAngle.Visible = False
        txtLeadDistance.Visible = False
        lblLeadDistance.Visible = False
        txtLeadIncludedAngle.Visible = False
        lblLeadIncludedAngle.Visible = False
        txtRadius.Visible = False
        lblRadius.Visible = False
        cboLeadJunction.Visible = False
        lblJunction.Visible = False

        nTypeID = (TryCast(cboLeadType.SelectedItem, myItemData).ItemData.ToString())

        Select Case nTypeID

            Case 0



            Case 1
                txtLeadLength.Visible = True
                lblLeadLength.Visible = True
                txtLeadAngle.Visible = True
                lblLeadAngle.Visible = True
                cboLeadJunction.Visible = True
                lblJunction.Visible = True



            Case 2
                txtLeadIncludedAngle.Visible = True
                lblLeadIncludedAngle.Visible = True
                txtRadius.Visible = True
                lblRadius.Visible = True
                cboLeadJunction.Visible = True
                lblJunction.Visible = True


            Case 3
                txtLeadLength.Visible = True
                lblLeadLength.Visible = True
                txtLeadAngle.Visible = True
                lblLeadAngle.Visible = True
                cboLeadJunction.Visible = True
                lblJunction.Visible = True


            Case 4
                txtLeadLength.Visible = True
                lblLeadLength.Visible = True

                txtLeadAngle.Visible = True
                lblLeadAngle.Visible = True

                txtLeadIncludedAngle.Visible = True
                lblLeadIncludedAngle.Visible = True

                txtRadius.Visible = True
                lblRadius.Visible = True

                cboLeadJunction.Visible = True
                lblJunction.Visible = True


            Case 5
                txtLeadLength.Visible = True
                lblLeadLength.Visible = True

                cboLeadJunction.Visible = True
                lblJunction.Visible = True

                txtLeadAngle.Visible = True
                lblLeadAngle.Visible = True



        End Select



    End Sub

    Private Sub txtLeadAngle_Validated(sender As Object, e As EventArgs) Handles txtLeadAngle.Validated
        UpdateLeadParams("Angle", txtLeadAngle.Text)
    End Sub
    Private Sub txtLeadDistance_Validated(sender As Object, e As EventArgs) Handles txtLeadDistance.Validated
        UpdateLeadParams("Distance", txtLeadDistance.Text)
    End Sub

    Private Sub txtLeadIncludedAngle_Validated(sender As Object, e As EventArgs) Handles txtLeadIncludedAngle.Validated
        UpdateLeadParams("Included Angle", txtLeadIncludedAngle.Text)
    End Sub
    Private Sub txtRadius_Validated(sender As Object, e As EventArgs) Handles txtRadius.Validated
        UpdateLeadParams("Radius", txtRadius.Text)
    End Sub

    Private Sub txtPierceDistance_Validated(sender As Object, e As EventArgs) Handles txtPierceDistance.Validated
        UpdateLeadParams("Pierce Offset", txtPierceDistance.Text)
    End Sub

    Private Sub cboLeadToolType_Validated(sender As Object, e As EventArgs) Handles cboLeadToolType.Validated
        UpdateLeadParams("Pierce Type ID", (TryCast(cboLeadToolType.SelectedItem, myItemData).ItemData.ToString()))
    End Sub

    Private Sub txtLeadToolDia_Validated(sender As Object, e As EventArgs) Handles txtLeadToolDia.Validated
        UpdateLeadParams("Pierce Diameter", txtLeadToolDia.Text)
    End Sub
    Private Sub bbLeadParamRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbLeadParamRemove.ItemClick
        Dim sql As String
        Dim dtLeadSetupTable As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim bMessageResult As Long


        Try

            sql = "Select [Lead Setup].* From [Lead Setup] Where " &
                    "([Lead Setup].[IIL ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[IIA ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[OIL ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[OIA ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[IEL ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[IEA ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[OEL ID] = " & m_LeadParamID &
                    "Or [Lead Setup].[OEA ID] = " & m_LeadParamID & " )"


            dtLeadSetupTable = ConnectToCMDB(sql)

            If (dtLeadSetupTable.Rows.Count > 0) Then

                bMessageResult = MessageBox.Show("This Parameter is used by (" & dtLeadSetupTable.Rows.Count - 1 & ") Setup(s). Are you sure you wish to remove it?", "Remove Station", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If (bMessageResult = System.Windows.Forms.DialogResult.Yes) Then

                    sql = "Delete [Lead Parameter].* From [Lead Parameter] " &
                            "Where ([Lead Parameter].ID = " & m_LeadParamID & " )"

                    dtLeadSetupTable = ConnectToCMDB(sql)

                End If

                TV_Config.Nodes.Remove(TV_Config.FocusedNode)
                TV_Config.Refresh()

            Else
                sql = "Delete [Lead Parameter].* From [Lead Parameter] " &
                            "Where ([Lead Parameter].ID = " & m_LeadParamID & " )"

                dtLeadSetupTable = ConnectToCMDB(sql)
                TV_Config.Nodes.Remove(TV_Config.FocusedNode)
                TV_Config.Refresh()

            End If

            DatabaseClose()

            dtLeadSetupTable.Dispose()


        Catch ex As ArgumentException

            MessageBox.Show("bbLeadParamRemove: " & ex.Message)

        End Try

    End Sub

    Private Sub RadioGroup1_Validated(sender As Object, e As EventArgs) Handles RadioGroup1.Validated
        If (RadioGroup1.SelectedIndex = 0) Then
            UpdateLeadParams("Use Pierce", 1)
        Else
            UpdateLeadParams("Use Pierce", 2)
        End If

    End Sub
    Private Sub bbLeadSetupAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbLeadSetupAdd.ItemClick
        Dim sAddModeString As String

        Try

            CFG_OPERATION_LEAD_SETUP_ROOT_NODE = TV_Config.FocusedNode

            sAddModeString = InputBox("Enter New Lead Setup Name:", "New Lead Setup")

            If (sAddModeString <> "") Then

                m_LeadSetupID = SaveLeadSetup(sAddModeString)

                CFG_OPERATION_LEAD_SETUP_NODE = TV_Config.AppendNode(New Object() {sAddModeString}, CFG_OPERATION_LEAD_SETUP_ROOT_NODE, m_LeadSetupID)


                TV_Config.Refresh()
                TV_Config.FocusedNode = CFG_OPERATION_LEAD_SETUP_NODE

            End If

        Catch ex As Exception
            MessageBox.Show("bbLeadSetupAdd: " & ex.Message)

        End Try

    End Sub
    Private Sub lblLeadExtArcIn_Click(sender As Object, e As EventArgs) Handles lblLeadExtArcIn.Click

        lblLeadExtArcIn.BackColor = GetLabelHighlightedBackColor()
        cboLeadExtArcIn.Focus()
        cboLeadExtArcIn.ShowPopup()

    End Sub

    Private Sub lblLeadExtArcOut_Click(sender As Object, e As EventArgs) Handles lblLeadExtArcOut.Click
        lblLeadExtArcOut.BackColor = GetLabelHighlightedBackColor()
        cboLeadExtArcOut.Focus()
        cboLeadExtArcOut.ShowPopup()
    End Sub

    Private Sub lblLeadExtLineIn_Click(sender As Object, e As EventArgs) Handles lblLeadExtLineIn.Click
        lblLeadExtLineIn.BackColor = GetLabelHighlightedBackColor()
        cboLeadExtLineIn.Focus()
        cboLeadExtLineIn.ShowPopup()
    End Sub

    Private Sub lblLeadExtLineOut_Click(sender As Object, e As EventArgs) Handles lblLeadExtLineOut.Click
        lblLeadExtLineOut.BackColor = GetLabelHighlightedBackColor()
        cboLeadExtLineOut.Focus()
        cboLeadExtLineOut.ShowPopup()

    End Sub

    Private Sub lblLeadIntArcIn_Click(sender As Object, e As EventArgs) Handles lblLeadIntArcIn.Click
        lblLeadIntArcIn.BackColor = GetLabelHighlightedBackColor()
        cboLeadIntArcIn.Focus()
        cboLeadIntArcIn.ShowPopup()
    End Sub

    Private Sub lblLeadIntArcOut_Click(sender As Object, e As EventArgs) Handles lblLeadIntArcOut.Click
        lblLeadIntArcOut.BackColor = GetLabelHighlightedBackColor()
        cboLeadIntArcOut.Focus()
        cboLeadIntArcOut.ShowPopup()
    End Sub

    Private Sub lblLeadIntLineIn_Click(sender As Object, e As EventArgs) Handles lblLeadIntLineIn.Click
        lblLeadIntLineIn.BackColor = GetLabelHighlightedBackColor()
        cboLeadIntLineIn.Focus()
        cboLeadIntLineIn.ShowPopup()
    End Sub

    Private Sub lblLeadIntLineOut_Click(sender As Object, e As EventArgs) Handles lblLeadIntLineOut.Click
        lblLeadIntLineOut.BackColor = GetLabelHighlightedBackColor()
        cboLeadIntLineOut.Focus()
        cboLeadIntLineOut.ShowPopup()
    End Sub

    Private Sub cboLeadExtArcIn_Enter(sender As Object, e As EventArgs) Handles cboLeadExtArcIn.Enter
        lblLeadExtArcIn.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadExtArcIn_Leave(sender As Object, e As EventArgs) Handles cboLeadExtArcIn.Leave
        lblLeadExtArcIn.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadExtArcOut_Enter(sender As Object, e As EventArgs) Handles cboLeadExtArcOut.Enter
        lblLeadExtArcOut.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadExtArcOut_Leave(sender As Object, e As EventArgs) Handles cboLeadExtArcOut.Leave
        lblLeadExtArcOut.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadExtLineIn_Enter(sender As Object, e As EventArgs) Handles cboLeadExtLineIn.Enter
        lblLeadExtLineIn.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadExtLineIn_Leave(sender As Object, e As EventArgs) Handles cboLeadExtLineIn.Leave
        lblLeadExtLineIn.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadExtLineOut_Enter(sender As Object, e As EventArgs) Handles cboLeadExtLineOut.Enter
        lblLeadExtLineOut.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadExtLineOut_Leave(sender As Object, e As EventArgs) Handles cboLeadExtLineOut.Leave
        lblLeadExtLineOut.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadIntArcIn_Enter(sender As Object, e As EventArgs) Handles cboLeadIntArcIn.Enter
        lblLeadIntArcIn.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadIntArcIn_Leave(sender As Object, e As EventArgs) Handles cboLeadIntArcIn.Leave
        lblLeadIntArcIn.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadIntArcOut_Enter(sender As Object, e As EventArgs) Handles cboLeadIntArcOut.Enter
        lblLeadIntArcOut.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadIntArcOut_Leave(sender As Object, e As EventArgs) Handles cboLeadIntArcOut.Leave
        lblLeadIntArcOut.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadIntLineIn_Enter(sender As Object, e As EventArgs) Handles cboLeadIntLineIn.Enter
        lblLeadIntLineIn.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadIntLineIn_Leave(sender As Object, e As EventArgs) Handles cboLeadIntLineIn.Leave
        lblLeadIntLineIn.BackColor = Color.Transparent
    End Sub

    Private Sub cboLeadIntLineOut_Enter(sender As Object, e As EventArgs) Handles cboLeadIntLineOut.Enter
        lblLeadIntLineOut.BackColor = GetLabelHighlightedBackColor()
    End Sub

    Private Sub cboLeadIntLineOut_Leave(sender As Object, e As EventArgs) Handles cboLeadIntLineOut.Leave
        lblLeadIntLineOut.BackColor = Color.Transparent
    End Sub

    Private Sub LoadLeadParamCombos()
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter
        Dim nID As Long
        Dim sDisplayStr As String

        cboLeadExtArcIn.Properties.Items.Clear()
        cboLeadExtArcOut.Properties.Items.Clear()
        cboLeadExtLineIn.Properties.Items.Clear()
        cboLeadExtLineOut.Properties.Items.Clear()
        cboLeadIntArcIn.Properties.Items.Clear()
        cboLeadIntArcOut.Properties.Items.Clear()
        cboLeadIntLineIn.Properties.Items.Clear()
        cboLeadIntLineOut.Properties.Items.Clear()


        cboLeadExtArcIn.Properties.Items.Add(New myItemData("None", 0))
        cboLeadExtArcOut.Properties.Items.Add(New myItemData("None", 0))
        cboLeadExtLineIn.Properties.Items.Add(New myItemData("None", 0))
        cboLeadExtLineOut.Properties.Items.Add(New myItemData("None", 0))
        cboLeadIntArcIn.Properties.Items.Add(New myItemData("None", 0))
        cboLeadIntArcOut.Properties.Items.Add(New myItemData("None", 0))
        cboLeadIntLineIn.Properties.Items.Add(New myItemData("None", 0))
        cboLeadIntLineOut.Properties.Items.Add(New myItemData("None", 0))

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            sql = "SELECT * FROM [Lead Parameter]"

            connection = New OleDbConnection(connetionString)

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If connection IsNot Nothing Then connection = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            For i = 0 To ds.Tables(0).Rows.Count - 1

                sDisplayStr = ds.Tables(0).Rows(i).Item("Description")
                nID = ds.Tables(0).Rows(i).Item("ID")

                cboLeadExtArcIn.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadExtArcOut.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadExtLineIn.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadExtLineOut.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadIntArcIn.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadIntArcOut.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadIntLineIn.Properties.Items.Add(New myItemData(sDisplayStr, nID))
                cboLeadIntLineOut.Properties.Items.Add(New myItemData(sDisplayStr, nID))


            Next

        Catch ex As Exception

            MessageBox.Show("LoadLeadParamCombos: " & ex.Message)

        Finally

            If ds IsNot Nothing Then ds = Nothing

        End Try

    End Sub


    Private Sub GetLeadSetupAttributes(ByVal lLeadSetupId As Long)

        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "SELECT * FROM [Lead Setup] WHERE [ID] = " & lLeadSetupId

        connection = New OleDbConnection(connetionString)

        oledbAdapter = New OleDbDataAdapter(sql, connection)

        oledbAdapter.Fill(ds)

        oledbAdapter.Dispose()

        connection.Close()

        For i = 0 To ds.Tables(0).Rows.Count - 1

            cboLeadIntLineIn.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("IIL ID"), cboLeadIntLineIn)
            cboLeadIntLineOut.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("OIL ID"), cboLeadIntLineOut)
            cboLeadIntArcIn.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("IIA ID"), cboLeadIntArcIn)
            cboLeadIntArcOut.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("OIA ID"), cboLeadIntArcOut)
            cboLeadExtLineIn.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("IEL ID"), cboLeadExtLineIn)
            cboLeadExtLineOut.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("OEL ID"), cboLeadExtLineOut)
            cboLeadExtArcIn.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("IEA ID"), cboLeadExtArcIn)
            cboLeadExtArcOut.SelectedIndex = FindNameForComboFromRsFieldID(ds.Tables(0).Rows(i).Item("OEA ID"), cboLeadExtArcOut)

        Next


        If ds IsNot Nothing Then ds = Nothing

        If connection IsNot Nothing Then connection = Nothing

        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

    End Sub

    Private Function FindNameForComboFromRsFieldID(myFieldValue As Long, ctrl As DevExpress.XtraEditors.ComboBoxEdit) As Long

        Dim nI As Integer

        For nI = 0 To ctrl.Properties.Items.Count - 1

            If (TryCast(ctrl.Properties.Items(nI), myItemData).ItemData.ToString() = myFieldValue) Then


                FindNameForComboFromRsFieldID = nI
                Exit For

            Else
                FindNameForComboFromRsFieldID = 0
            End If

        Next


    End Function
    Private Sub EditLeadSetup()
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim m_cnLeadSetup As New OleDb.OleDbConnection
        Dim m_dtLeadSetup As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtLeadSetup.NewRow()
        Dim cmdGetID As New OleDbCommand
        Dim cmd As OleDbCommand

        'sql = "SELECT * FROM [Lead Setup] WHERE [ID] = " & m_LeadSetupID

        Try

            'm_cnLeadSetup.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathCMDB()
            'm_cnLeadSetup.Open()
            'm_daLeadSetup = New OleDb.OleDbDataAdapter(sql, m_cnLeadSetup)
            'm_cbLeadSetup = New OleDb.OleDbCommandBuilder(m_daLeadSetup)
            'm_cbLeadSetup.QuotePrefix = "["
            'm_cbLeadSetup.QuoteSuffix = "]"
            'm_daLeadSetup.Fill(m_dtLeadSetup)

            'drNewRow("Description") = TV_Config.FocusedNode.GetDisplayText(0)
            'drNewRow("Buffer") = 0
            'drNewRow("Machine Type ID") = 5
            'drNewRow("Material Type ID") = GetFirstMaterial()
            'drNewRow("IIL ID") = TryCast(cboLeadIntLineIn.Properties.Items(cboLeadIntLineIn.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("IIA ID") = TryCast(cboLeadIntArcIn.Properties.Items(cboLeadIntArcIn.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("OIL ID") = TryCast(cboLeadIntLineOut.Properties.Items(cboLeadIntLineOut.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("OIA ID") = TryCast(cboLeadIntArcOut.Properties.Items(cboLeadIntArcOut.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("IEL ID") = TryCast(cboLeadExtLineIn.Properties.Items(cboLeadExtLineIn.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("IEA ID") = TryCast(cboLeadExtArcIn.Properties.Items(cboLeadExtArcIn.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("OEL ID") = TryCast(cboLeadExtLineOut.Properties.Items(cboLeadExtLineOut.SelectedIndex), myItemData).ItemData.ToString()
            'drNewRow("OEA ID") = TryCast(cboLeadExtArcOut.Properties.Items(cboLeadExtArcOut.SelectedIndex), myItemData).ItemData.ToString()

            'm_dtLeadSetup.Rows.Add(drNewRow)
            'm_daLeadSetup.Update(m_dtLeadSetup)

            'm_dtLeadSetup.Dispose()
            'm_daLeadSetup.Dispose()

            'm_cnLeadSetup.Close()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            sql = "Update [Lead Setup] set  [Lead Setup].[Buffer] =  0.0 Where " &
                    "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            connection.Open()

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            'FabV21 TODO: Find out why this is hard coded to 5
            sql = "Update [Lead Setup] set  [Lead Setup].[Machine Type ID] = 5 Where " &
                    "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            'connection.Open()

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[Material Type ID] = '" & GetFirstMaterial() & "' Where " &
                                "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            'connection.Open()

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[IIL ID] = '" &
                TryCast(cboLeadIntLineIn.Properties.Items(cboLeadIntLineIn.SelectedIndex), myItemData).ItemData.ToString() &
                "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[IIA ID] = '" &
                    TryCast(cboLeadIntArcIn.Properties.Items(cboLeadIntArcIn.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()


            sql = "Update [Lead Setup] set  [Lead Setup].[OIL ID] = '" &
                    TryCast(cboLeadIntLineOut.Properties.Items(cboLeadIntLineOut.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[OIA ID] = '" &
                    TryCast(cboLeadIntArcOut.Properties.Items(cboLeadIntArcOut.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[IEL ID] = '" &
                    TryCast(cboLeadExtLineIn.Properties.Items(cboLeadExtLineIn.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[IEA ID] = '" &
                   TryCast(cboLeadExtArcIn.Properties.Items(cboLeadExtArcIn.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[OEL ID] = '" &
                   TryCast(cboLeadExtLineOut.Properties.Items(cboLeadExtLineOut.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            sql = "Update [Lead Setup] set  [Lead Setup].[OEA ID] = '" &
                   TryCast(cboLeadExtArcOut.Properties.Items(cboLeadExtArcOut.SelectedIndex), myItemData).ItemData.ToString() &
                    "' Where " & "[Lead Setup].[ID] = " & m_LeadSetupID & ""

            cmd = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()


            connection.Close()

        Catch ex As Exception


            MessageBox.Show("EditLeadSetup: " & ex.Message)

        End Try



    End Sub


    Private Sub cboLeadIntLineIn_Validated(sender As Object, e As EventArgs) Handles cboLeadIntLineIn.Validated
        EditLeadSetup()
    End Sub


    Private Sub cboLeadIntLineOut_Validated(sender As Object, e As EventArgs) Handles cboLeadIntLineOut.Validated
        EditLeadSetup()
    End Sub


    Private Sub cboLeadIntArcIn_Validated(sender As Object, e As EventArgs) Handles cboLeadIntArcIn.Validated
        EditLeadSetup()
    End Sub


    Private Sub cboLeadIntArcOut_Validated(sender As Object, e As EventArgs) Handles cboLeadIntArcOut.Validated
        EditLeadSetup()
    End Sub


    Private Sub cboLeadExtLineIn_Validated(sender As Object, e As EventArgs) Handles cboLeadExtLineIn.Validated
        EditLeadSetup()
    End Sub


    Private Sub cboLeadExtLineOut_Validated(sender As Object, e As EventArgs) Handles cboLeadExtLineOut.Validated
        EditLeadSetup()
    End Sub

    Private Sub cboLeadExtArcIn_Validated(sender As Object, e As EventArgs) Handles cboLeadExtArcIn.Validated
        EditLeadSetup()
    End Sub

    Private Sub cboLeadExtArcOut_Validated(sender As Object, e As EventArgs) Handles cboLeadExtArcOut.Validated
        EditLeadSetup()
    End Sub

    Private Sub rbMachSettings_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rbMachSettings.ButtonClick
        Dim edit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim sFilename As String
        Dim dialog As New OpenFileDialog()
        Dim m_folderDialog As New FolderBrowserDialog()

        Try

            my_DatVarName = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "DatVarName", 0)
            my_DialogDisplay = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "DialogDisplay", 0)
            my_CVarName = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "CVArName", 0)
            my_DataType = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "VarDataType", 0)
            my_RecodID = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "RecodID", 0)
            my_sOptions = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "sOptions", 0)



            Select Case my_DataType

                Case DB_FILE

                    dialog.Multiselect = False
                    If (my_DatVarName = "Table_CTG") Then
                        dialog.Title = "Select TBG file"
                        dialog.Filter = "Table Graphics(*.TBG)|*.TBG"

                    Else
                        dialog.Title = "Select CTG file"
                        dialog.Filter = "CTG Files(*.CTG)|*.CTG"

                    End If

                    If dialog.ShowDialog(Me) = DialogResult.OK Then

                        'edit.EditValue = TrimToFit(dialog.FileName, 35)
                        edit.EditValue = dialog.FileName

                        sFilename = (dialog.FileName)

                        my_VBValue = sFilename

                        my_CValue = sFilename

                        vgMachSettings.FocusedRow.Tag = EncodeTag(my_DatVarName,
                                                              my_DialogDisplay,
                                                              my_VBValue,
                                                              my_CValue,
                                                              my_CVarName,
                                                              my_DataType,
                                                              my_RecodID,
                                                              my_sOptions, 0)

                    End If

                Case DB_FOLDER

                    m_folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
                    m_folderDialog.SelectedPath = GetValueFromDelimitedData(vgMachSettings.FocusedRow.Tag, "VBValue", 0)


                    If (m_folderDialog.ShowDialog() = DialogResult.OK) Then
                        my_VBValue = m_folderDialog.SelectedPath

                        my_CValue = m_folderDialog.SelectedPath

                        edit.EditValue = TrimToFit(m_folderDialog.SelectedPath, 40)

                        vgMachSettings.FocusedRow.Tag = EncodeTag(my_DatVarName,
                                                                  my_DialogDisplay,
                                                                  my_VBValue,
                                                                  my_CValue,
                                                                  my_CVarName,
                                                                  my_DataType,
                                                                  my_RecodID,
                                                                  my_sOptions, 0)

                    End If
            End Select

        Catch ex As Exception

            MessageBox.Show("rbMachSettings_ButtonClick: " & ex.Message)

        End Try

    End Sub

    Private Sub vgMachSettings_CustomRecordCellEdit(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs) Handles vgMachSettings.CustomRecordCellEdit
        Dim nTemp As Integer

        If (e.Row.Tag IsNot Nothing) Then
            nTemp = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0))

            If (nTemp = DB_FILE Or nTemp = DB_FOLDER) Then
                e.RepositoryItem = rbMachSettings
            End If
        End If

    End Sub

    Private Sub LayerAnalyze_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LayerAnalyze.ItemClick
        Me.pnlPreamble.Visible = False
        Me.pnlMachSettings.Visible = False
        Me.pnlStations.Visible = False
        Me.pnlToolSetups.Visible = False
        Me.pnlToolingParameters.Visible = False
        Me.pnlAvailableTooling.Visible = False
        Me.pnlToolingParameters.Visible = False
        Me.pnlLayerGlobal.Visible = False
        Me.pnlLayerSetup.Visible = False
        Me.pnlMaterialInfo.Visible = False
        Me.pnlLeadParameters.Visible = False
        Me.pnlLeadSetupInfo.Visible = False
        Me.pnlAnalyze.Visible = True
        Dim nID As Integer = 0

        dsAnalyzeLayer.ChildRows.Add(CreateBooleanEditorRow(vgLayerAnalyze,
                                                            "Layer Analyze",
                                                            "Analyze Entire Directory",
                                                            True,
                                                            True,
                                                            "Layer Analyze",
                                                            DB_BOOL, nID, sEmpty, 0))

        dsAnalyzeLayer.ChildRows.Add(CreateBooleanEditorRow(vgLayerAnalyze,
                                                            "Parse From Layer",
                                                            "Parse From Layer",
                                                            False,
                                                            False,
                                                            "Parse From Layer",
                                                            DB_BOOL, nID, sEmpty, 0))


        dsAnalyzeLayer.ChildRows.Add(CreateButtonEditEditorRow(vgMachSettings,
                                                             "Filename",
                                                             "Filename",
                                                              "",
                                                              "",
                                                              "Filename",
                                                              DB_FILE,
                                                              0,
                                                              "DXF File(s) (*.dxf);*.dxf ;DWG File(s) (*.dwg);*.dwg", 0))


        Dim sChoices As New Collection
        sChoices.Add("From CAD")
        sChoices.Add("From DB")

        dsAnalyzeLayer.ChildRows.Add(CreateComboBoxEditorRow(vgLayerAnalyze, "Z Level Mode", "Z Level Mode", nID, "From DB", sChoices))

        dsAnalyzeLayer.ChildRows.Add(CreateDoubleEditorRow(vgLayerAnalyze,
                                                           "Clean Tol.",
                                                           "Sharp Angle",
                                                          60,
                                                          60,
                                                           "Sharp Angle",
                                                           DB_DBL, nID, sEmpty, 0))

        dsAnalyzeLayer.ChildRows.Add(CreateDoubleEditorRow(vgLayerAnalyze,
                                                            "Clean Tol.",
                                                            "Clean Tol.",
                                                            0.001,
                                                            0.001,
                                                            "Clean Tol.",
                                                            DB_DBL, nID, sEmpty, 0))

        dsAnalyzeLayer.ChildRows.Add(CreateDoubleEditorRow(vgLayerAnalyze,
                                                            "Filter Tol.",
                                                            "Filter Tol.",
                                                            0.001,
                                                            0.001,
                                                            "Filter Tol.",
                                                            DB_DBL, nID, sEmpty, 0))

        dsAnalyzeLayer.ChildRows.Add(CreateDoubleEditorRow(vgLayerAnalyze,
                                                            "Gap Tol.",
                                                            "Gap Tol.",
                                                            0.001,
                                                            0.001,
                                                            "Gap Tol.",
                                                            DB_DBL, nID, sEmpty, 0))


        sChoices.Clear()
        sChoices.Add("CW")
        sChoices.Add("CCW")
        sChoices.Add("Auto")
        sChoices.Add("As Specified")

        dsAnalyzeLayer.ChildRows.Add(CreateComboBoxEditorRow(vgLayerAnalyze, "Direction", "Cut Direction", nID, "CW", sChoices))

        sChoices.Clear()
        sChoices.Add("None")
        sChoices.Add("Left")
        sChoices.Add("Right")

        dsAnalyzeLayer.ChildRows.Add(CreateComboBoxEditorRow(vgLayerAnalyze, "Cut Side", "Cut Side", nID, "None", sChoices))

        dsAnalyzeLayer.ChildRows.Add(CreateDoubleEditorRow(vgLayerAnalyze,
                                                           "Distance",
                                                           "Distance",
                                                           0.0,
                                                           0.0,
                                                           "Distance",
                                                           DB_DBL, nID, sEmpty, 0))


        sChoices = BuildStationChoices()

        dsAnalyzeLayer.ChildRows.Add(CreateComboBoxEditorRow(vgLayerAnalyze, "Station", "Station", nID, "None", sChoices))

        dsAnalyzeLayer.ChildRows.Add(CreateColorEditEditorRow(vgLayerAnalyze, "Color", "Color", nID, System.Drawing.Color.Cyan))

        vgLayerAnalyze.BestFit()


        Me.Width = 625
        frmMain.splitContainerControl.SplitterPosition = Me.Width
    End Sub

    Private Function BuildStationChoices() As Collection
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim oledbAdapter As OleDbDataAdapter

        BuildStationChoices = New Collection

        'BuildStationChoices.Clear()
        BuildStationChoices.Add("**Auto**")
        BuildStationChoices.Add("None")
        Try
            m_toolSetupID = TV_Config.FocusedNode.ParentNode.ParentNode.Tag

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            sql = "SELECT [Tool Setup Members].[Tool Setup ID], [Tool Setup Members].[Index Angle]," &
                "[Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[Tool ID]," &
                "[Tool Setup Members].[Station ID], [Tool Setup Members].[Fixed Station], [Tool Setup Members].ID" &
                " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] ON " &
                "[Station Configuration].ID = [Tool Setup Members].[Station ID]) ON [Tool Crib].ID = " &
                "[Tool Setup Members].[Tool ID] WHERE ((([Tool Setup Members].[Tool Setup ID])=" &
                m_toolSetupID & " ))" & " ORDER BY [Tool Setup Members].ID"



            connection = New OleDbConnection(connetionString)

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If connection IsNot Nothing Then connection = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            For i = 0 To ds.Tables(0).Rows.Count - 1

                BuildStationChoices.Add("[" & ds.Tables(0).Rows(i).Item("NC Code Number") & "] " & ds.Tables(0).Rows(i).Item("Description"))

            Next

        Catch ex As Exception

            MessageBox.Show("BuildStationChoices: " & ex.Message)

        Finally

            If ds IsNot Nothing Then ds = Nothing


        End Try


    End Function


    Private Sub rbdsAnalyzeLayer_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rbdsAnalyzeLayer.ButtonClick
        Dim edit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim sFilename As String
        Dim sExt As String
        Dim dialog As New OpenFileDialog()


        dialog.Multiselect = False
        dialog.InitialDirectory = PathDriveFolder(PathAnalyze())
        dialog.Title = "Select Cad file"
        dialog.Filter = "DXF Files(*.DXF)|*.DXF|DWG Files (*.DWG)|*.DWG"

        If dialog.ShowDialog(Me) = DialogResult.OK Then
            sFilename = (dialog.FileName)
            sExt = LCase(PathExt(sFilename))

            'edit.EditValue = TrimToFit(sFilename, 35)
            edit.EditValue = dialog.FileName

            '*****************************************
            ' make a reference to a directory
            Dim di As New IO.DirectoryInfo(PathDriveFolder(sFilename))
            Dim diar1 As IO.FileInfo() = di.GetFiles("*." & sExt)

            ListBox1.DataSource = diar1

            '*****************************************


            edit.Tag = sFilename
        End If
    End Sub

    Private Sub vgLayerAnalyze_CustomRecordCellEdit(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs) Handles vgLayerAnalyze.CustomRecordCellEdit
        If (UCase(e.Row.Properties.Caption) = "FILENAME") Then
            e.RepositoryItem = rbdsAnalyzeLayer
        End If
    End Sub

    Private Sub vgGlobalLayerInfo_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgGlobalLayerInfo.CellValueChanged
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim sCaption As String
        Dim nDisplay As Integer
        Dim m_value


        nDisplay = e.Row.VisibleIndex - 1
        sCaption = vgGlobalLayerInfo.Rows(0).ChildRows(nDisplay).Properties.Caption

        Select Case UCase(sCaption)
            Case "Z LEVEL MODE"

                m_value = IIf(e.Value = "From CAD", 0, 1)

            Case "PROCESS TEXT"

                sCaption = "ProcessText"
                m_value = e.Value

            Case "RESTRICT OFFSET"
                sCaption = "Restrict_Offset"
                m_value = e.Value
            Case Else

                m_value = e.Value

        End Select

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "Update [Layer Setups] set  [Layer Setups].[" & sCaption & "] =  " & m_value & " Where " &
                "[Layer Setups].[ID] = " & m_globallayerinfoID & ""

        connection = New OleDbConnection(connetionString)

        Try
            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


            cmd.ExecuteNonQuery()

            connection.Close()

        Catch ex As Exception

            MessageBox.Show("vgGlobalLayerInfo_CellValueChanged Error: " & ex.Message)

        End Try
    End Sub

    Private Sub vgToolParameters_CustomRecordCellEdit(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs) Handles vgToolParameters.CustomRecordCellEdit
        Dim nTemp As Integer

        If (e.Row.Tag IsNot Nothing) Then
            nTemp = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0))

            If (nTemp = DB_FILE Or nTemp = DB_FOLDER) Then
                e.RepositoryItem = rbToolParamSettings
            End If
        End If

    End Sub


    Private Sub ubgStations_MouseUp(sender As Object, e As MouseEventArgs) Handles ubgStations.MouseUp
        'If (e.Button = Windows.Forms.MouseButtons.Right) Then

        '    PopUp_TV_Config.ItemLinks.Clear()

        '    For Each item As BarItem In CFG_Man_BarMan.Items
        '        If item.Category.Name = "Stations" Then
        '            PopUp_TV_Config.AddItem(item)
        '        End If
        '    Next

        '    PopUp_TV_Config.ShowPopup(Control.MousePosition)

        'End If

    End Sub

    Private Sub cmdLayerSetupAnalyzeOk_Click(sender As Object, e As EventArgs) Handles cmdLayerSetupAnalyzeOk.Click
        Dim ni As Integer
        Dim isOK As Boolean
        Dim m_LayerSetupID As Integer
        Dim sCadFilename As String = Nothing
        Dim sFolder As String
        Dim sql As String = Nothing
        Dim connection As OleDbConnection
        Dim connetionString As String = Nothing
        Dim n_MachineID As Integer

        isOK = False
        Try
            For ni = 0 To vgLayerAnalyze.Rows(0).ChildRows.Count - 1

                If (vgLayerAnalyze.Rows(0).ChildRows(ni).Properties.Caption = "Filename") Then

                    If (vgLayerAnalyze.Rows(0).ChildRows(ni).Properties.Value = "") Then

                        MessageBox.Show("You must select a DXF or DWG file in the 'Filename' Field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        isOK = False
                    Else
                        sCadFilename = vgLayerAnalyze.Rows(0).ChildRows(ni).Properties.Value

                        isOK = True
                    End If

                End If

            Next

            If (isOK) Then
                n_MachineID = GetMachineIDFromDescrip(TV_Config.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetDisplayText(0))
                m_LayerSetupID = modTranslate.GetLayerSetupID(TV_Config.FocusedNode.GetDisplayText(0), n_MachineID)

                'Ensure the temp folder exists for results of analysis.
                PathTempFolderCreate()

                PathAnalyze_Set(sCadFilename)

                'The folder to use when "Analyze Entire Directory" is checked.
                sFolder = PathDriveFolder(sCadFilename)

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

                connection = New OleDbConnection(connetionString)

                For ni = 0 To vgLayerAnalyze.Rows(0).ChildRows.Count - 1

                    Dim rowType As Type = vgLayerAnalyze.Rows(0).ChildRows(ni).Properties.RowType
                    'MessageBox .Show ("The rowtype is " & CStr(rowType) & " and the row type name is " & rowType.Name 


                    If (rowType.Name = "Boolean") Then

                    End If


                Next

                'cmd.CommandText = "UPDATE [Layer Setups] set [Layer Setups].[" & s_DatVarName & "] = " & sEdit_Value & " Where ([Layer Setups].[ID] =" & m_LayerSetupID & " )"


                'cmd.ExecuteNonQuery()
            End If

        Catch ex As Exception

            MessageBox.Show("cmdLayerSetupAnalyzeOk_Click Error: " & ex.Message)

        End Try
    End Sub


    Private Sub rbToolParamSettings_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rbToolParamSettings.ButtonClick
        Dim edit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim sFilename As String
        Dim dialog As New OpenFileDialog()
        Dim m_folderDialog As New FolderBrowserDialog()

        Try

            my_DatVarName = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "DatVarName", 0)
            my_DialogDisplay = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "DialogDisplay", 0)
            my_CVarName = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "CVArName", 0)
            my_DataType = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "VarDataType", 0)
            my_RecodID = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "RecodID", 0)
            my_sOptions = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "sOptions", 0)



            Select Case my_DataType

                Case DB_FILE


                    dialog.Multiselect = False
                    dialog.Title = "Select CTG file"
                    dialog.Filter = "CTG Files(*.CTG)|*.CTG"
                    If dialog.ShowDialog(Me) = DialogResult.OK Then

                        'edit.EditValue = TrimToFit(dialog.FileName, 35)
                        edit.EditValue = dialog.FileName
                        sFilename = (dialog.FileName)

                        my_VBValue = sFilename

                        my_CValue = sFilename

                        vgToolParameters.FocusedRow.Tag = EncodeTag(my_DatVarName,
                                                                  my_DialogDisplay,
                                                                  my_VBValue,
                                                                  my_CValue,
                                                                  my_CVarName,
                                                                  my_DataType,
                                                                  my_RecodID,
                                                                  my_sOptions, 0)

                    End If

                Case DB_FOLDER

                    m_folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
                    m_folderDialog.SelectedPath = GetValueFromDelimitedData(vgToolParameters.FocusedRow.Tag, "VBValue", 0)


                    If (m_folderDialog.ShowDialog() = DialogResult.OK) Then
                        my_VBValue = m_folderDialog.SelectedPath

                        my_CValue = m_folderDialog.SelectedPath

                        edit.EditValue = TrimToFit(m_folderDialog.SelectedPath, 40)

                        vgToolParameters.FocusedRow.Tag = EncodeTag(my_DatVarName,
                                                                  my_DialogDisplay,
                                                                  my_VBValue,
                                                                  my_CValue,
                                                                  my_CVarName,
                                                                  my_DataType,
                                                                  my_RecodID,
                                                                  my_sOptions, 0)

                    End If
            End Select

        Catch ex As Exception

            MessageBox.Show("rbToolParamSettings_ButtonClick: " & ex.Message)

        End Try


    End Sub


    Private Sub ubgStationsView_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles ubgStationsView.CellValueChanged
        Dim sql As String
        Dim nStationID As Long
        Dim connection As OleDbConnection
        Dim connetionString As String = Nothing
        Dim vRealValue As Object

        Try
            nStationID = ubgStationsView.GetFocusedRowCellValue("ID")

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            connection = New OleDbConnection(connetionString)

            If (IsNumeric(e.Value) = False) Then
                vRealValue = e.Value
            Else

                If (e.Column.ColumnType.FullName = "System.Boolean") Then
                    If (e.Value = False) Then
                        vRealValue = 0
                    ElseIf (e.Value = True) Then
                        vRealValue = 1
                    End If
                Else
                    vRealValue = e.Value
                End If
            End If


            '    'If e.Column.ColumnType = CheckBox Then

            '    'End If
            '    If (e.Value = False) Then
            '        vRealValue = 0
            '    ElseIf (e.Value = True) Then
            '        vRealValue = 1
            '    Else
            '        vRealValue = e.Value
            '    End If
            'End If

            'If (e.Value = False) Then
            '    vRealValue = 0
            'ElseIf (e.Value = True) Then
            '    vRealValue = 1
            'Else
            '    vRealValue = e.Value
            'End If


            sql = "UPDATE [Station Configuration] set [Station Configuration].[" & e.Column.FieldName & "] = '" & vRealValue & "' Where ([Station Configuration].[ID] =" & nStationID & " )"

            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)

            cmd.ExecuteNonQuery()

            connection.Close()

        Catch ex As Exception

            MessageBox.Show("rbToolParamSettings_ButtonClick: " & ex.Message)

        End Try

    End Sub



    Private Sub vgLayerInfo_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgLayerInfo.CellValueChanged
        Dim sql As String = Nothing
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim sCaption As String
        Dim nDisplay As Integer
        Dim n_layerid As Integer
        Dim lColor As Long
        Dim sMyStation As String
        Dim nComboValue As Integer


        n_layerid = TV_Config.FocusedNode.Tag

        nDisplay = e.Row.VisibleIndex - 1
        sCaption = vgLayerInfo.FocusedRow.Properties.Caption

        Select Case UCase(sCaption)
            Case "CAD LAYER", "CAM LAYER", "DISTANCE"

                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '" & e.Value & "' Where " &
                    "[Directives].[ID] = " & n_layerid & ""

                'Case "CAM LAYER"
            Case "COLOR"
                lColor = ColorTranslator.ToOle(e.Value)

                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '" & lColor & "' Where " &
                        "[Directives].[ID] = " & n_layerid & ""

            Case "STATION"
                sMyStation = e.Value

                sMyStation = Replace(sMyStation, "[", "")
                sMyStation = Replace(sMyStation, "]", "")

                If sMyStation <> "**Auto**" And sMyStation <> "None" Then
                    sMyStation = Trim(Mid(sMyStation, 1, InStr(1, sMyStation, Chr(32))))
                End If

                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '" & sMyStation & "' Where " &
                        "[Directives].[ID] = " & n_layerid & ""

            Case "TOOL TYPE"
                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '0' Where " &
                    "[Directives].[ID] = " & n_layerid & ""

            Case "CUT DIRECTION"
                Select Case e.Value
                    Case "CW"
                        nComboValue = 0
                    Case "CCW"
                        nComboValue = 1
                    Case "Auto"
                        nComboValue = 2
                    Case "As Specified"
                        nComboValue = 3

                End Select

                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '" & nComboValue & "' Where " &
                        "[Directives].[ID] = " & n_layerid & ""

            Case "CUT SIDE"
                Select Case e.Value
                    Case "None"
                        nComboValue = 0

                    Case "Left"
                        nComboValue = 1

                    Case "Right"
                        nComboValue = -1

                End Select

                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '" & nComboValue & "' Where " &
                        "[Directives].[ID] = " & n_layerid & ""

            Case "Z LEVEL"
                sql = "Update [Directives] set  [Directives].[" & sCaption & "] =  '0' Where " &
                    "[Directives].[ID] = " & n_layerid & ""

        End Select

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"


        connection = New OleDbConnection(connetionString)

        Try
            connection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)


            cmd.ExecuteNonQuery()

            connection.Close()

            If (sCaption = "CAD Layer") Then

                TV_Config.FocusedNode.SetValue(0, e.Value)

            End If

        Catch ex As Exception

            MessageBox.Show("vgLayerInfo_CellValueChanged " & ex.Message)

        End Try

    End Sub

    Private Sub vgLayerInfo_ShownEditor(sender As Object, e As EventArgs) Handles vgLayerInfo.ShownEditor
        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)
    End Sub

    Private Sub vgMachSettings_ShownEditor(sender As Object, e As EventArgs) Handles vgMachSettings.ShownEditor
        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)
    End Sub

    Private Sub vgGlobalLayerInfo_ShownEditor(sender As Object, e As EventArgs) Handles vgGlobalLayerInfo.ShownEditor
        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)
    End Sub

    Private Sub StationsAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles StationsAdd.ItemClick
        Dim sql As String
        Dim dtStationTable As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim ni As Integer
        Dim drCopiedRow As DataRow
        Dim nRowHandle As Long

        Try
            If (ubgStationsView.RowCount > 0) Then


                nRowHandle = ubgStationsView.FocusedRowHandle

                NcCodeNumberHolder = ubgStationsView.GetRowCellValue(nRowHandle, ubgStationsView.Columns("NC Code Number")).ToString()
            Else
                NcCodeNumberHolder = 0
            End If
            sql = "Select * From [Station Configuration]"

            dtStationTable = ConnectToCMDB(sql)

            If (cbfAutoFillStations.Checked = True) Then

                For ni = 1 To CInt(lbtAutoFill.Text)
                    drCopiedRow = dtStationTable.NewRow()

                    NcCodeNumberHolder = NcCodeNumberHolder + 1

                    drCopiedRow("Machine ID") = m_machineID
                    drCopiedRow("WorkPlane ID") = 1
                    drCopiedRow("NC Code Number") = NcCodeNumberHolder
                    drCopiedRow("Station Location X") = 0
                    drCopiedRow("Station Location Y") = 0
                    drCopiedRow("Auto Index") = False
                    drCopiedRow("Station Size") = 0
                    drCopiedRow("Primary Code") = 0
                    drCopiedRow("Secondary Code") = 0

                    dtStationTable.Rows.Add(drCopiedRow)
                    m_daCMDB.Update(dtStationTable)

                Next
            Else

                drCopiedRow = dtStationTable.NewRow()

                drCopiedRow("Machine ID") = m_machineID
                drCopiedRow("WorkPlane ID") = 1
                drCopiedRow("NC Code Number") = (NcCodeNumberHolder + 1)
                drCopiedRow("Station Location X") = 0
                drCopiedRow("Station Location Y") = 0
                drCopiedRow("Auto Index") = False
                drCopiedRow("Station Size") = 0
                drCopiedRow("Primary Code") = 0
                drCopiedRow("Secondary Code") = 0

                dtStationTable.Rows.Add(drCopiedRow)
                m_daCMDB.Update(dtStationTable)

            End If

            dtStationTable.Dispose()
            DatabaseClose()
            cbfAutoFillStations.Checked = False
            InitStations()


        Catch ex As ArgumentException

            MessageBox.Show("sbAddStation: " & ex.Message)
        End Try

EarlyExit:


    End Sub

    Private Sub StationsRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles StationsRemove.ItemClick
        ' MessageBox.Show("hello")

    End Sub

    Private Sub LeadSetupRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LeadSetupRemove.ItemClick
        Dim sql As String
        Dim dt1 As DataTable = Nothing

        Try
            If (m_LeadSetupID > 0) Then
                sql = "DELETE * FROM [Lead Setup] WHERE [ID] = " & m_LeadSetupID

                ' sql = "DELETE * FROM [Machines] WHERE [ID] = " & m_machineID

                dt1 = ConnectToCMDB(sql)

                DatabaseClose()

            End If

            TV_Config.Nodes.Remove(TV_Config.FocusedNode)
            TV_Config.Refresh()
        Catch ex As ArgumentException

            MessageBox.Show("LeadSetupRemove: " & ex.Message)
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'TV_Config.PrintDialog()

        vgMachSettings.Print()

        'Dim cmdGetID As New OleDbCommand
        'Dim m_cnToolCrib As New OleDb.OleDbConnection
        'Dim m_daToolCrib As New OleDb.OleDbDataAdapter
        'Dim m_dtToolCrib As New DataTable
        'Dim sql As String
        'Dim lMyToolTypeId As Long
        'Dim ds As New DataSet
        'Dim ds1 As New DataSet
        'Dim i As Integer
        'Dim sDisplayStr As String
        'Dim sDescription As String
        'Dim nID As Integer
        'Dim nDataType As Integer
        'Dim sTag As String
        'Dim dtToolAttributes As DataTable = Nothing
        'Dim sDieClearance As String
        'Dim sToolDescript As String
        'Dim ToolCribParamFields As String
        'Dim ToolCribParamValues As String
        'Dim sToolType As String
        'Dim sToolTypeID As String


        'sql = "Select [Tool Types].* From [Tool Types] Where ([Tool Types].ID <> 25 ) And ([Tool Types].ID <> 26 ) And ([Tool Types].ID <> 28 ) And ([Tool Types].ID > 14 )"

        'dtToolAttributes = ConnectToCMDB(sql)

        'm_cnToolCrib = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';")

        'm_cnToolCrib.Open()

        'For i = 0 To dtToolAttributes.Rows.Count - 1

        '    sToolTypeID = "Tool Type ID"

        '    sToolType = dtToolAttributes.Rows(i).Item("ID").ToString

        '    ToolCribParamFields = "[Tool Type  ID]," &
        '                            "[Attribute Type ID]"

        '    ToolCribParamValues = sToolType & ", 32"

        '    sql = "INSERT INTO [Tool Type Attributes] (" & ToolCribParamFields & " ) VALUES(" & ToolCribParamValues & ")"

        '    m_daToolCrib.InsertCommand = New OleDbCommand(sql, m_cnToolCrib)

        '    m_daToolCrib.InsertCommand.ExecuteNonQuery()

        '    cmdGetID.Connection = m_cnToolCrib
        '    cmdGetID.CommandText = "SELECT MAX(ID) FROM [Tool Type Attributes]]"

        '    nID = cmdGetID.ExecuteScalar

        'Next

        'm_cnToolCrib.Close()
    End Sub
    Public Sub AddDoffForLaser()
        Dim m_cnToolCrib As New OleDb.OleDbConnection
        Dim m_daToolCrib As New OleDb.OleDbDataAdapter
        Dim m_dtToolCrib As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtToolCrib.NewRow()
        Dim connetionString As String
        Dim cmdGetID As New OleDbCommand
        Dim sToolDescript As String = ""
        Dim firstloop As Boolean = True
        Dim sFieldName As String = ""
        Dim sFieldValue As String = ""
        Dim dFieldValue As Double
        Dim nFieldValue As Int32
        Dim tlColor As Long
        Dim nID As Long
        Dim nTlIndex As Integer
        Dim sTablename As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            m_cnToolCrib = New OleDbConnection(connetionString)
            sTablename = "Tool Type Attributes"

            tbToolCribParamFields.Text = "[Tool Type  ID], [Attribute Type ID]"
            tbToolCribParamValues.Text = "'13','4'"

            sql = "INSERT INTO [" & sTablename & "] (" & tbToolCribParamFields.Text & " ) VALUES(" & tbToolCribParamValues.Text & ")"
            'sql = "INSERT INTO [Tool Type Attributes] (" & tbToolCribParamFields.Text & " ) VALUES(" & tbToolCribParamValues.Text & ")"

            m_cnToolCrib.Open()

            m_daToolCrib.InsertCommand = New OleDbCommand(sql, m_cnToolCrib)

            m_daToolCrib.InsertCommand.ExecuteNonQuery()

            tbToolCribParamFields.Text = "[Tool Type  ID], [Attribute Type ID]"
            tbToolCribParamValues.Text = "'10','4'"

            sql = "INSERT INTO [Tool Type Attributes] (" & tbToolCribParamFields.Text & " ) VALUES(" & tbToolCribParamValues.Text & ")"

            m_daToolCrib.InsertCommand = New OleDbCommand(sql, m_cnToolCrib)

            m_daToolCrib.InsertCommand.ExecuteNonQuery()


            cmdGetID.Connection = m_cnToolCrib
            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Tool Crib]"

            nID = cmdGetID.ExecuteScalar

            lstToolSetupAvailTools.Items.Add(New myItemData(sToolDescript, nID, tlColor))
        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub cboToolSetupAvailTools_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboToolSetupAvailTools.SelectedValueChanged
        Dim nToolType As Long

        If (cboToolSetupAvailTools.Properties.Items.Count > 0) Then

            nToolType = (TryCast(cboToolSetupAvailTools.EditValue, myItemData)).ItemData.ToString()

            FillToolListBasedOnType(lstToolSetupAvailTools, nToolType)

        End If

        If lstToolSetupAvailTools.ItemCount > 0 Then
            lstToolSetupAvailTools.SelectedIndex = -1
            cmdToolCribRemove.Enabled = True
            Me.cmdToolCribEdit.Enabled = True
        Else
            cmdToolCribRemove.Enabled = False
            Me.cmdToolCribEdit.Enabled = False
        End If
    End Sub

    Private Sub cmdMoveToolUp_Click(sender As Object, e As EventArgs) Handles cmdMoveToolUp.Click
        Dim view = ToolSetupView
        Dim index = view.FocusedRowHandle
        Dim sCurrStation As String
        Dim nCurrStationID As String
        Dim nCurrToolId As String
        Dim sCurrDescription As String
        Dim nCurrOrderID As String
        Dim bCurrFixedStation As Boolean
        Dim dCurrIndexAngle As Double

        Dim sPrevStation As String
        Dim nPrevStationID As String
        Dim nPrevToolId As String
        Dim sPrevDescription As String
        Dim nPrevOrderID As String
        Dim bPrevFixedStation As Boolean
        Dim dPrevIndexAngle As Double

        Try
            If index <= 0 Then
                Return
            End If

            sCurrStation = ToolSetupView.GetRowCellValue(index, "Station")
            nCurrStationID = ToolSetupView.GetRowCellValue(index, "StationID")
            nCurrToolId = ToolSetupView.GetRowCellValue(index, "ToolID")
            sCurrDescription = ToolSetupView.GetRowCellValue(index, "ToolDescription")
            nCurrOrderID = ToolSetupView.GetRowCellValue(index, "OrderID")
            dCurrIndexAngle = ToolSetupView.GetRowCellValue(index, "IndexAngle")
            bCurrFixedStation = ToolSetupView.GetRowCellValue(index, "FixedStation")

            sPrevStation = ToolSetupView.GetRowCellValue(index - 1, "Station")
            nPrevStationID = ToolSetupView.GetRowCellValue(index - 1, "StationID")
            nPrevToolId = ToolSetupView.GetRowCellValue(index - 1, "ToolID")
            sPrevDescription = ToolSetupView.GetRowCellValue(index - 1, "ToolDescription")
            nPrevOrderID = ToolSetupView.GetRowCellValue(index - 1, "OrderID")
            dPrevIndexAngle = ToolSetupView.GetRowCellValue(index - 1, "IndexAngle")
            bPrevFixedStation = ToolSetupView.GetRowCellValue(index - 1, "FixedStation")

            ToolSetupView.SetRowCellValue((index - 1), "Station", sCurrStation)
            ToolSetupView.SetRowCellValue(index - 1, "StationID", nCurrStationID)
            ToolSetupView.SetRowCellValue(index - 1, "ToolID", nCurrToolId)
            ToolSetupView.SetRowCellValue(index - 1, "ToolDescription", sCurrDescription)
            ToolSetupView.SetRowCellValue(index - 1, "OrderID", nCurrOrderID)
            ToolSetupView.SetRowCellValue(index - 1, "IndexAngle", dCurrIndexAngle)
            ToolSetupView.SetRowCellValue(index - 1, "FixedStation", bCurrFixedStation)

            ToolSetupView.SetRowCellValue(index, "Station", sPrevStation)
            ToolSetupView.SetRowCellValue(index, "StationID", nPrevStationID)
            ToolSetupView.SetRowCellValue(index, "ToolID", nPrevToolId)
            ToolSetupView.SetRowCellValue(index, "OrderID", nPrevOrderID)
            ToolSetupView.SetRowCellValue(index, "ToolDescription", sPrevDescription)
            ToolSetupView.SetRowCellValue(index, "IndexAngle", dPrevIndexAngle)
            ToolSetupView.SetRowCellValue(index, "FixedStation", bPrevFixedStation)



            view.FocusedRowHandle = index - 1

        Catch ex As Exception

            MessageBox.Show("cmdMoveToolUp_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub cmdMoveToolDown_Click(sender As Object, e As EventArgs) Handles cmdMoveToolDown.Click
        Dim view = ToolSetupView
        Dim index = view.FocusedRowHandle
        Dim sCurrStation As String
        Dim nCurrStationID As String
        Dim nCurrToolId As String
        Dim sCurrDescription As String
        Dim nCurrOrderID As String
        Dim bCurrFixedStation As Boolean
        Dim dCurrIndexAngle As Double

        Dim sNextStation As String
        Dim nNextStationID As String
        Dim nNextToolId As String
        Dim sNextDescription As String
        Dim nNextOrderID As String
        Dim bNextFixedStation As Boolean
        Dim dNextIndexAngle As Double

        Try
            If (ToolSetupView.GetRowCellValue(index + 1, "OrderID") = 9000) Then
                Return
            End If

            sCurrStation = ToolSetupView.GetRowCellValue(index, "Station")
            nCurrStationID = ToolSetupView.GetRowCellValue(index, "StationID")
            nCurrToolId = ToolSetupView.GetRowCellValue(index, "ToolID")
            sCurrDescription = ToolSetupView.GetRowCellValue(index, "ToolDescription")
            nCurrOrderID = ToolSetupView.GetRowCellValue(index, "OrderID")
            dCurrIndexAngle = ToolSetupView.GetRowCellValue(index, "IndexAngle")
            bCurrFixedStation = ToolSetupView.GetRowCellValue(index, "FixedStation")

            sNextStation = ToolSetupView.GetRowCellValue(index + 1, "Station")
            nNextStationID = ToolSetupView.GetRowCellValue(index + 1, "StationID")
            nNextToolId = ToolSetupView.GetRowCellValue(index + 1, "ToolID")
            sNextDescription = ToolSetupView.GetRowCellValue(index + 1, "ToolDescription")
            nNextOrderID = ToolSetupView.GetRowCellValue(index + 1, "OrderID")
            dNextIndexAngle = ToolSetupView.GetRowCellValue(index + 1, "IndexAngle")
            bNextFixedStation = ToolSetupView.GetRowCellValue(index + 1, "FixedStation")

            ToolSetupView.SetRowCellValue(index + 1, "Station", sCurrStation)
            ToolSetupView.SetRowCellValue(index + 1, "StationID", nCurrStationID)
            ToolSetupView.SetRowCellValue(index + 1, "ToolID", nCurrToolId)
            ToolSetupView.SetRowCellValue(index + 1, "ToolDescription", sCurrDescription)
            ToolSetupView.SetRowCellValue(index + 1, "OrderID", nCurrOrderID)
            ToolSetupView.SetRowCellValue(index + 1, "IndexAngle", dCurrIndexAngle)
            ToolSetupView.SetRowCellValue(index + 1, "FixedStation", bCurrFixedStation)

            ToolSetupView.SetRowCellValue(index, "Station", sNextStation)
            ToolSetupView.SetRowCellValue(index, "StationID", nNextStationID)
            ToolSetupView.SetRowCellValue(index, "ToolID", nNextToolId)
            ToolSetupView.SetRowCellValue(index, "OrderID", nNextOrderID)
            ToolSetupView.SetRowCellValue(index, "ToolDescription", sNextDescription)
            ToolSetupView.SetRowCellValue(index, "IndexAngle", dNextIndexAngle)
            ToolSetupView.SetRowCellValue(index, "FixedStation", bNextFixedStation)



            view.FocusedRowHandle = index + 1

        Catch ex As Exception

            MessageBox.Show("cmdMoveToolDown_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub frmCfgMan3_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Private Sub sbHtmlAdd_Click(sender As Object, e As EventArgs) Handles sbHtmlAdd.Click
        'Dim objNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        'Dim objParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        'Dim sMyLine As String
        'Dim sTempFile As String = "C:\_Dev\FabV24.0\VB_SRC\Resources\128Outfile.txt"
        'Dim sName As String
        'Dim lid As Long
        'Dim lcolor As Long
        'Dim lParentID As Long
        'Dim nSeqID As Long = 0

        'TListWin1.InvStyle = 3

        ''Important *** Setting Redraw to False to prevent updates while
        'TListWin1.Redraw = False

        'TListWin1.Grid.Cols = 3

        'TListWin1.Grid.ShowColTitles = True

        'TListWin1.Grid.Cells(0, 1).Value.Data = "Entity"
        'TListWin1.Grid.Cells(0, 2).Value.Data = "Tool"

        'TListWin1.ColDelimiter = 94
        ''objParentNode = tlhtml.Nodes.Add("Hello")
        ''lParentID = tlhtml.Nodes.newindex

        ''TListWin1.AddItem(sTemp & "^" & m_descrip & "^" & nSeqOrderID & "^" & nSeqID, -1)

        'TListWin1.AddItem("Hello", -1)

        'Using sr As StreamReader = New StreamReader(sTempFile)
        '    sMyLine = sr.ReadLine()
        '    While (sMyLine <> Nothing)

        '        nSeqID = nSeqID + 1

        '        'ColorTranslator.FromHtml("#FFFFD2")
        '        TListWin1.AddItem(sMyLine & "^" & nSeqID, -1)
        '        TListWin1.Grid.RowDefs.Item(TListWin1.NewIndex + 1).CellDef.ForeColor = System.Drawing.ColorTranslator.FromHtml(Chr(34) & "#" & sMyLine & Chr(34))

        '        'objNode = tlhtml.AppendNode(New Object() {sName, lId, lParentID, objParentNode.Id, lColor}, objParentNode.Id, "uid_" & CStr(lId))
        '        'lbHTMLColors.Items.Add(sMyLine)
        '        ''lbHTMLColors.Ite

        '        'sOutfilename.WriteLine(sMyline & DOUBLE_QUOTE & ")")
        '        sMyLine = sr.ReadLine()
        '    End While
        'End Using

    End Sub
End Class
