Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.Data.OleDb

Public Class frmEditToolLayer
    Private edit As RepositoryItemCheckEdit
    Private sPieces() As String
    Private WithEvents rbProcessParameters As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private bToolMode As Boolean

    Private Sub frmEditToolLayer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub

    '    Private Sub frmEditToolLayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub frmEditToolLayer_Load(sender As Object, e As EventArgs) Handles Me.Load

        LoadToolSetupListview()

    End Sub

    Public Sub LoadLayersListview()

        Dim lCount As Long
        Dim indx As Long
        Dim lLayerID As Long
        Dim lLayerColor As Long
        Dim sLayerName As String
        Dim lHidden As Long
        Dim type_id As Long
        Dim lst As New List(Of TheTools)()
        Dim bestwidth As Integer

        bToolMode = False

        grdToolLayer.DataSource = Nothing

        gViewToolLayer.Columns.Clear()

        Try

            edit = New RepositoryItemCheckEdit()
            edit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio

            lReturn = PortalExecute("*Model:EntityCount: type=" & c_DBTOOL)
            lCount = PortalGetInt("count", 0)

            If lCount > 0 Then

                For indx = 0 To (lCount - 1)

                    lReturn = PortalExecute( _
                                "*Model:Get2:" & _
                                " indx=" & indx & _
                                ",type=" & c_DBTOOL)

                    lLayerID = PortalGetInt("id", 0)

                    'NOTE: Only tools have a Type_ID attribute.
                    type_id = EntityIntGet(lLayerID, "Type_ID", UNDEFINED)
                    If (type_id = UNDEFINED) Then

                        sLayerName = EntityStringGet(lLayerID, "name", "<error>")
                        If (UCase$(sLayerName) <> "STOCK") Then

                            lLayerColor = EntityIntGet(lLayerID, "color", ColorTranslator.ToOle(Color.White))

                            lHidden = 0 ' initialize variable
                            lReturn = PortalExecute("*entity:ishidden:id=" & lLayerID)
                            lHidden = PortalGetInt("val", 0)

                            lst.Add(New TheTools() With {.ToolHidden = IIf((lHidden = 0), True, False), _
                                                         .ToolNumber = lLayerID, _
                                                         .ToolName = sLayerName, _
                                                          .ToolColor = System.Drawing.ColorTranslator.FromOle(lLayerColor)})

                        End If

                    End If

                Next indx

            End If


            grdToolLayer.DataSource = lst
            gViewToolLayer.Columns("ToolHidden").Caption = " "
            gViewToolLayer.Columns("ToolHidden").ColumnEdit = edit
            gViewToolLayer.Columns("ToolColor").Visible = False
            gViewToolLayer.Columns("ToolNumber").Visible = False
            gViewToolLayer.Columns("ToolName").Caption = "Layer Name"

            grdToolLayer.SuspendLayout()

            For Each col In gViewToolLayer.Columns

                bestwidth = col.GetBestWidth()
                col.MinWidth = bestwidth
            Next


            grdToolLayer.ResumeLayout()
            AddHandler gViewToolLayer.RowStyle, AddressOf gViewToolLayer_RowStyle

        Catch ex As Exception

            MessageBox.Show("LoadLayersListview < " & ex.Message & " >")

        End Try
    End Sub

    Public Sub LoadToolSetupListview()
        Dim lst As New List(Of TheTools)()
        Dim clsToolData As ToolData
        Dim bestwidth As Integer

        bToolMode = True

        grdToolLayer.DataSource = Nothing

        gViewToolLayer.Columns.Clear()

        Try

            edit = New RepositoryItemCheckEdit()
            edit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio

            g_DescripChar_len = 0

            If Not g_colToolSetup Is Nothing Then
                For Each clsToolData In g_colToolSetup
                    With clsToolData
                        If UCase$(.Workplane) = UCase$(GetCurrentWorkplane()) Then

                            If (Len(.Description) > g_DescripChar_len) Then

                                g_DescripChar_len = Len(.Description)

                            End If
                            lst.Add(New TheTools() With {.ToolHidden = IIf((clsToolData.show), True, False), _
                                                         .ToolNumber = clsToolData.NC_Code_Number, _
                                                         .ToolName = clsToolData.Description, _
                                                         .ToolColor = System.Drawing.ColorTranslator.FromOle(clsToolData.TlColor)})
                        End If
                    End With
                Next

                grdToolLayer.DataSource = lst
                gViewToolLayer.Columns("ToolHidden").Caption = " "
                gViewToolLayer.Columns("ToolHidden").ColumnEdit = edit
                gViewToolLayer.Columns("ToolColor").Visible = False
                gViewToolLayer.Columns("ToolNumber").Visible = True


                grdToolLayer.SuspendLayout()

                For Each col In gViewToolLayer.Columns

                    bestwidth = col.GetBestWidth()
                    col.MinWidth = bestwidth
                Next


                grdToolLayer.ResumeLayout()
                AddHandler gViewToolLayer.RowStyle, AddressOf gViewToolLayer_RowStyle

            End If

        Catch ex As Exception

            MessageBox.Show("LoadToolSetupListview < " & ex.Message & " >")

        End Try

    End Sub
    Public Class TheTools
        Private privateToolHidden As Boolean
        Public Property ToolHidden() As Boolean
            Get
                Return privateToolHidden
            End Get
            Set(ByVal value As Boolean)
                privateToolHidden = value
            End Set
        End Property
        Private privateToolNumber As Integer
        Public Property ToolNumber() As Integer
            Get
                Return privateToolNumber
            End Get
            Set(ByVal value As Integer)
                privateToolNumber = value
            End Set
        End Property
        Private privateToolName As String
        Public Property ToolName() As String
            Get
                Return privateToolName
            End Get
            Set(ByVal value As String)
                privateToolName = value
            End Set
        End Property
        Private privateToolColor As System.Drawing.Color
        Public Property ToolColor() As System.Drawing.Color
            Get
                Return privateToolColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                privateToolColor = value
            End Set
        End Property
    End Class

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        rbProcessParameters = New RepositoryItemButtonEdit()

    End Sub

    Private Sub LoadToolData(clsToolData As ToolData)

        Dim clsOperation As Operation
        Dim sData As String
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim arrOptions As Collection
        Dim currentCategoryRow As CategoryRow = Nothing

        vgProcessParameters.Rows.Clear()

        Try

            currentCategoryRow = CreateCategoryRow(vgProcessParameters, "Processs Parameters", "Processs Parameters", "Processs Parameters", "Processs Parameters", "Processs Parameters", 0, DB_HEADER, sEmpty, 0)

            ''degParameters.InitializeGrid()

            For Each clsOperation In clsToolData.ToolOps
                ' parse out the data
                sData = clsOperation.Description & "|" & clsOperation.Parameters

                sPieces = Split(sData, "|")

                my_DatVarName = sPieces(0)
                my_CVarName = sPieces(0)
                my_DataType = ConvertDatTypeToDBType(sPieces(1))
                my_DialogDisplay = sPieces(2)
                my_VBValue = sPieces(3)
                my_CValue = sPieces(3) 'Also see the case statement for combobox
                my_RecodID = 0
                my_sOptions = sEmpty

                Select Case (my_DataType)

                    Case DB_HEADER
                        currentCategoryRow = CreateCategoryRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)

                    Case DB_STR
                        currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                    Case DB_BOOL
                        currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_INT
                        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_DBL
                        currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_TOOL

                    Case DB_DCOMBO, DB_COMBO
                        Dim i As Integer

                        lstOptions.Items.Clear()

                        For i = 3 To sPieces.Count - 1
                            lstOptions.Items.Add(sPieces(i).ToString)

                            If (sPieces(i).ToString = my_VBValue) Then
                                my_CValue = i - 4
                            End If
                        Next
                        arrOptions = PopulateComboListFromDat(lstOptions)

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgProcessParameters, _
                                                                my_DatVarName, _
                                                                 my_DialogDisplay, _
                                                                 my_VBValue, _
                                                                 my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))
                End Select

            Next

            clsOperation = Nothing
            ' now we add our custom parameters (if not punching)

            If (clsToolData.type_id < 15) Or (clsToolData.type_id > 27) Then
                '    'Note: We set the level to the empty string because we
                '    'do *not* want to generate a Create:Hole: portal command
                '    'unless the user provides a level value.

                sData = "Level|dbl|Level|"

                sPieces = Split(sData, "|")

                my_DatVarName = sPieces(0)
                my_CVarName = sPieces(0)
                my_DataType = ConvertDatTypeToDBType(sPieces(1))
                my_DialogDisplay = sPieces(2)
                my_VBValue = 0
                my_CValue = 0
                my_RecodID = 0
                my_sOptions = sEmpty
                currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            End If


        Catch ex As Exception

            MessageBox.Show("clsToolData < " & ex.Message & " >")

        End Try
    End Sub

    Private Sub grdToolLayer_GotFocus(sender As Object, e As EventArgs) Handles grdToolLayer.GotFocus
        Dim bestwidth As Integer
        grdToolLayer.SuspendLayout()

        For Each col In gViewToolLayer.Columns

            bestwidth = col.GetBestWidth()
            col.MinWidth = bestwidth
        Next

        grdToolLayer.ResumeLayout()
    End Sub
    Private Sub gViewToolLayer_Click(sender As Object, e As EventArgs) Handles gViewToolLayer.Click

        If (bToolMode = True) Then
            Dim clsToolData As ToolData
            Dim View As Views.Grid.GridView
            Dim MyConnection As OleDbConnection = OpenTheCmdb()

            View = CType(sender, Views.Grid.GridView)

            Dim col As Object = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ToolNumber"))
            clsToolData = g_colToolSetup("T" & col.ToString())

            'GetToolOperations(clsToolData, MyConnection)
            'GetMaterialAttributes(clsToolData, MyConnection)

            'MyConnection.Close()
            'MyConnection.Dispose()

            LoadToolData(clsToolData)
            clsToolData = Nothing
        End If

    End Sub

    Private Sub gViewToolLayer_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gViewToolLayer.RowStyle
        Dim lst As List(Of TheTools)
        Dim item As TheTools

        If (e.RowHandle < 0) Then

            Return

        End If

        lst = CType(gViewToolLayer.DataSource, List(Of TheTools))
        item = lst(e.RowHandle)
        e.Appearance.ForeColor = item.ToolColor
        e.Appearance.BackColor = Color.Black

    End Sub

    Private Sub gViewToolLayer_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gViewToolLayer.ShowingEditor
        Dim View As Views.Grid.GridView

        View = CType(sender, Views.Grid.GridView)

        If (View.FocusedColumn.Name = "colToolName" Or View.FocusedColumn.Name = "colToolNumber") Then

            e.Cancel = True

        End If
    End Sub

    Private Sub rgChangeTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgChangeTo.SelectedIndexChanged
        If (rgChangeTo.SelectedIndex = 1) Then

            LoadToolSetupListview()

        End If

        If (rgChangeTo.SelectedIndex = 2) Then

            LoadLayersListview()

        End If
    End Sub


    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        Dim clsToolData As ToolData
        Dim active_layer As ActiveLayerInfo
        Dim lLayerID As Long
        Dim lst As List(Of TheTools)
        Dim item As TheTools

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            active_layer = GetActiveLayer()

            If (rgChangeTo.SelectedIndex = 0) Then

                UndoPrepare()
                UpdateAttributes()
                UndoCommit()

            ElseIf (rgChangeTo.SelectedIndex = 1) Then

                'change to a  tool
                If (gViewToolLayer.SelectedRowsCount = 0) Then

                    MessageBox.Show("Please select a 'Tool'.", App_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Exit Sub

                End If

                Dim col As Object = gViewToolLayer.GetRowCellValue(gViewToolLayer.FocusedRowHandle, gViewToolLayer.Columns("ToolNumber"))

                ' establish the tool
                clsToolData = g_colToolSetup("T" & col.ToString())

                ' find the tool's associated layer
                lLayerID = GetToolLayer(clsToolData)

                UndoPrepare()
                lReturn = PortalExecute("attrib:updatelayer:layer=" & lLayerID)
                lReturn = SelectedIntSet("color", clsToolData.TlColor)

                UpdateAttributes()

                UndoCommit()

                clsToolData = Nothing

            ElseIf (rgChangeTo.SelectedIndex = 2) Then
                'change to a layer
                If (gViewToolLayer.SelectedRowsCount = 0) Then

                    MessageBox.Show("Please select a 'Layer'.", App_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Exit Sub

                End If

                ' get the layer id
                Dim col As Object = gViewToolLayer.GetRowCellValue(gViewToolLayer.FocusedRowHandle, gViewToolLayer.Columns(2))

                lReturn = PortalExecute("*admin:lookup:name=" & QStr(col.ToString()))
                lLayerID = PortalGetInt("id", 0)

                UndoPrepare()
                lReturn = PortalExecute("attrib:updatelayer:layer=" & lLayerID)

                'Now we need to get rid of the tool attributes because we are now layers
                lReturn = PortalExecute("attrib:updatedel:name=all")
                col = gViewToolLayer.GetRowCellValue(gViewToolLayer.FocusedRowHandle, gViewToolLayer.Columns("ToolNumber"))

                lst = CType(gViewToolLayer.DataSource, List(Of TheTools))
                item = lst(gViewToolLayer.FocusedRowHandle)
                lReturn = SelectedIntSet("color", ColorTranslator.ToOle(item.ToolColor))
                UpdateAttributes()

                UndoCommit()

            End If

            modView.ViewRefresh()

            If (bIsEntityLoaded = True) Then frmEntityList.FillTreeView()

            SetActiveLayer(active_layer.Name, active_layer.Color)

        Catch ex As Exception

            MessageBox.Show("cmdOk_Click < " & ex.Message & " >")

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default


    End Sub

    Private Sub UpdateAttributes()

        Dim sMyTag As String
        Dim my_CValue As String
        Dim my_CVarName As String

        Try

            For Each row As CategoryRow In vgProcessParameters.Rows
                For Each childRow As EditorRow In row.ChildRows
                    sMyTag = childRow.Tag

                    my_CVarName = GetValueFromDelimitedData(sMyTag, "CVarName", 0)
                    my_CValue = GetValueFromDelimitedData(sMyTag, "CValue", 0)

                    Select Case my_CVarName

                        Case "Amperage"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedDoubleSet("amperage", CDbl(my_CValue))
                            End If

                        Case "Angle"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedDoubleSet("angle", CDbl(my_CValue))
                            End If

                        Case "CutQuality"
                            If Len(my_CValue) > 0 Then
                                Select Case my_CValue

                                    Case "Scribing"
                                        lReturn = SelectedIntSet("cutquality", 0)

                                    Case "Coarse"
                                        lReturn = SelectedIntSet("cutquality", 1)

                                    Case "Medium"
                                        lReturn = SelectedIntSet("cutquality", 2)

                                    Case "Medium Fine"
                                        lReturn = SelectedIntSet("cutquality", 3)

                                    Case "Fine"
                                        lReturn = SelectedIntSet("cutquality", 4)

                                    Case "Extra Fine"
                                        lReturn = SelectedIntSet("cutquality", 5)

                                End Select
                            End If

                        Case "CutSide"
                            If Len(my_CValue) > 0 Then
                                Select Case my_CValue

                                    Case "Left"
                                        lReturn = SelectedIntSet("cutside", 1)

                                    Case "Right"
                                        lReturn = SelectedIntSet("cutside", -1)

                                    Case "None"
                                        lReturn = SelectedIntSet("cutside", 0)

                                End Select
                            End If

                        Case "CutType"
                            If Len(my_CValue) > 0 Then
                                Select Case my_CValue

                                    Case "Inside"
                                        lReturn = SelectedIntSet("cuttype", 0)

                                    Case "Outside"
                                        lReturn = SelectedIntSet("cuttype", 1)

                                End Select
                            End If

                        Case "Doff"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedIntSet("doff", CLng(my_CValue))
                            End If

                        Case "Feed"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedDoubleSet("feed", CDbl(my_CValue))
                            End If

                        Case "FeedMode"
                            If Len(my_CValue) > 0 Then
                                Select Case my_CValue

                                    Case "Canned Cycle"
                                        lReturn = SelectedIntSet("feedmode", 0)

                                    Case "Standard Punching"
                                        lReturn = SelectedIntSet("feedmode", 1)

                                    Case "Equalized Punching"
                                        lReturn = SelectedIntSet("feedmode", 2)

                                    Case "Bridge Punching"
                                        lReturn = SelectedIntSet("feedmode", 3)

                                    Case "UPR"
                                        lReturn = SelectedIntSet("feedmode", 4)

                                    Case "UPT"
                                        lReturn = SelectedIntSet("feedmode", 5)

                                End Select
                            End If

                        Case "Loff"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedIntSet("loff", CLng(my_CValue))
                            End If

                        Case "MaxPressure"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedDoubleSet("maxpressure", CDbl(my_CValue))
                            End If

                        Case "Plunge"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedDoubleSet("plunge", CDbl(my_CValue))
                            End If

                        Case "Speed"
                            If Len(my_CValue) > 0 Then
                                lReturn = SelectedDoubleSet("speed", CDbl(my_CValue))
                            End If

                            ' our custom parameters

                        Case "Level"
                            If Len(my_CValue) > 0 Then
                                UpdateZlevel(my_CValue)
                            End If

                    End Select
                Next
            Next


        Catch ex As Exception

            MessageBox.Show("UpdateAttributes < " & ex.Message & " >")

        End Try
    End Sub


    Private Sub UpdateZlevel(ByVal dLevel As Double)

        Dim cmd As String
        Dim cnt As Long
        Dim indx As Long
        Dim lSelectionID As Long
        Dim lType As Long
        Dim xs As Double
        Dim ys As Double
        Dim xe As Double
        Dim ye As Double
        Dim Xc As Double
        Dim Yc As Double
        Dim dir As Long
        Dim diam As Double
        Dim depth As Double

        cnt = modSelection.SelectedCount

        Try

            For indx = 0 To cnt - 1

                lSelectionID = modSelection.GetAt(indx)

                lReturn = PortalExecute("*create:extract:id=" & lSelectionID)
                lType = PortalGetInt("type", c_INVALID)

                Select Case lType

                    Case 3 ' point
                        ' extract data from entity
                        xs = PortalGetDouble("x", 0.0#)
                        ys = PortalGetDouble("y", 0.0#)
                        cmd = "create:point:" & _
                            " action=" & WEUPDATE & _
                            ",id=" & lSelectionID & _
                            ",x=" & xs & _
                            ",y=" & ys & _
                            ",z=" & dLevel

                        ' modify the entity
                        lReturn = PortalExecute(cmd)

                    Case 4 ' line
                        ' extract data from entity
                        xs = PortalGetDouble("sx", 0.0#)
                        ys = PortalGetDouble("sy", 0.0#)
                        xe = PortalGetDouble("ex", 0.0#)
                        ye = PortalGetDouble("ey", 0.0#)

                        cmd = "create:line:" & _
                            " action=" & WEUPDATE & _
                            ",sncs=" & LINE_2PT & _
                            ",id=" & lSelectionID & _
                            ",xs=" & xs & _
                            ",ys=" & ys & _
                            ",zs=" & dLevel & _
                            ",xe=" & xe & _
                            ",ye=" & ye & _
                            ",ze=" & dLevel

                        ' modify the entity
                        lReturn = PortalExecute(cmd)

                    Case 5 ' arc
                        ' extract data from entity
                        xs = PortalGetDouble("sx", 0.0#)
                        ys = PortalGetDouble("sy", 0.0#)
                        xe = PortalGetDouble("ex", 0.0#)
                        ye = PortalGetDouble("ey", 0.0#)
                        Xc = PortalGetDouble("cx", 0.0#)
                        Yc = PortalGetDouble("cy", 0.0#)
                        dir = PortalGetInt("dir", 1)

                        cmd = "create:arc:" & _
                            " action=" & WEUPDATE & _
                            ",sncs=" & ARC_PS_PE_PC & _
                            ",id=" & lSelectionID & _
                            ",xs=" & xs & _
                            ",ys=" & ys & _
                            ",zs=" & dLevel & _
                            ",xe=" & xe & _
                            ",ye=" & ye & _
                            ",ze=" & dLevel & _
                            ",xc=" & Xc & _
                            ",yc=" & Yc & _
                            ",zc=" & dLevel & _
                            ",dir=" & dir

                        ' modify the entity
                        lReturn = PortalExecute(cmd)

                    Case 6 ' hole
                        ' extract data from entity
                        xs = PortalGetDouble("x", 0.0#)
                        ys = PortalGetDouble("y", 0.0#)
                        diam = PortalGetDouble("dia", 0.0#)
                        depth = PortalGetDouble("depth", 0.0#)

                        cmd = "create:hole:" & _
                            " action=" & WEUPDATE & _
                            ",id=" & lSelectionID & _
                            ",xc=" & xs & _
                            ",yc=" & ys & _
                            ",zc=" & dLevel & _
                            ",dia=" & diam & _
                            ",depth=" & depth

                        ' modify the entity
                        lReturn = PortalExecute(cmd)

                End Select
            Next indx

        Catch ex As Exception

            MessageBox.Show("UpdateZlevel < " & ex.Message & " >")

        End Try

    End Sub
    Private Sub vgProcessParameters_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgProcessParameters.CellValueChanged
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String

        my_DatVarName = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "DatVarName", 0)
        my_DialogDisplay = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "DialogDisplay", 0)
        my_CVarName = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "DatVarName", 0)
        my_DataType = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "VarDataType", 0)
        my_RecodID = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "RecodID", 0)
        my_sOptions = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "sOptions", 0)

        my_VBValue = e.Value
        my_CValue = e.Value

        vgProcessParameters.FocusedRow.Tag = EncodeTag(my_DatVarName, _
                                                                  my_DialogDisplay, _
                                                                  my_VBValue, _
                                                                  my_CValue, _
                                                                  my_CVarName, _
                                                                  my_DataType, _
                                                                  my_RecodID, _
                                                                  my_sOptions, 0)

    End Sub

End Class