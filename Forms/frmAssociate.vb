Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraVerticalGrid.Rows

Public Class frmAssociate

    Private edit As RepositoryItemCheckEdit
    Private sPieces() As String
    Private m_colToolSubset As ToolSetup
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
    Public Sub LoadToolSetupListview()
        Dim lst As New List(Of MyTheTools)()
        Dim clsToolData As ToolData
        Dim bestwidth As Integer

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
                            lst.Add(New MyTheTools() With {.ToolHidden = IIf((clsToolData.show), False, True), _
                                                         .ToolNumber = clsToolData.NC_Code_Number, _
                                                         .ToolName = clsToolData.Description, _
                                                         .ToolColor = System.Drawing.ColorTranslator.FromOle(clsToolData.TlColor)})
                        End If
                    End With
                Next

                grdToolLayer.DataSource = lst
                gViewToolLayer.Columns("ToolHidden").Caption = " "
                gViewToolLayer.Columns("ToolHidden").ColumnEdit = edit
                'gViewToolLayer.Columns("ToolColor").Visible = False
                gViewToolLayer.Columns("ToolNumber").Visible = True

                For Each col In gViewToolLayer.Columns

                    bestwidth = col.GetBestWidth()
                    col.MinWidth = bestwidth
                Next

                vgProcessParameters.Refresh()

                AddHandler gViewToolLayer.RowStyle, AddressOf gViewToolLayer_RowStyle

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub gViewToolLayer_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles gViewToolLayer.FocusedRowChanged
        Dim clsToolData As ToolData
        Dim View As Views.Grid.GridView
        View = CType(sender, Views.Grid.GridView)

        Dim col As Object = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ToolNumber"))

        Try

            m_colToolSubset = Nothing
            m_colToolSubset = New ToolSetup

            Load_Tool_Params(col)

            clsToolData = m_colToolSubset(1)

            LoadToolData(clsToolData)

            clsToolData = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Load_Tool_Params(sCol As String)

        Dim clsToolData As ToolData
        Dim clsToolCopy As ToolData

        Try

            ' add tool to collection
            clsToolData = m_colToolSubset.Add

            ' copy the attributes
            clsToolCopy = g_colToolSetup("T" & sCol)

            lReturn = clsToolData.ParamsCopy(clsToolCopy)

            clsToolData = m_colToolSubset(1)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub gViewToolLayer_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gViewToolLayer.RowStyle
        If e.RowHandle < 0 Then
            Return
        End If
        Dim lst As List(Of MyTheTools)

        Try

            lst = CType(gViewToolLayer.DataSource, List(Of MyTheTools))
            Dim item As MyTheTools = lst(e.RowHandle)
            e.Appearance.ForeColor = item.ToolColor
            e.Appearance.BackColor = Color.Black

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
                                my_CValue = i - 3
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

            ' add distance
            my_DatVarName = "Distance"
            my_CVarName = "Distance"
            my_DataType = ConvertDatTypeToDBType("dbl")
            my_DialogDisplay = "Distance"
            my_VBValue = 0
            my_CValue = 0
            my_RecodID = 0
            my_sOptions = sEmpty
            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


            ''add sharp angle (if burning/punching with a tool having a round cross section)
            If (clsToolData.type_id < 16) Or (clsToolData.type_id > 27) Then
                my_DatVarName = "SharpAngle"
                my_CVarName = "SharpAngle"
                my_DataType = ConvertDatTypeToDBType("dbl")
                my_DialogDisplay = "Sharp Angle"
                my_VBValue = 60
                my_CValue = 60
                my_RecodID = 0
                my_sOptions = sEmpty
                currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            End If


            If (clsToolData.Auto_Index() = True) Then
                my_DatVarName = "UseLongSide"
                my_CVarName = "UseLongSide"
                my_DataType = ConvertDatTypeToDBType("BOOL")
                my_DialogDisplay = "Use Long Side"
                my_VBValue = 0
                my_CValue = 0
                my_RecodID = 0
                my_sOptions = sEmpty
                currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgProcessParameters, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Friend Class MyTheTools
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

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim active_layer As ActiveLayerInfo
        Dim entityID As Long
        Dim entityType As Long
        Dim Count As Long
        Dim indx As Long
        Dim ni As Integer
        Dim clsToolData As ToolData


        active_layer = GetActiveLayer()

        Try

            UndoPrepare()

            clsToolData = m_colToolSubset(1)

            For ni = 0 To vgProcessParameters.Rows(0).ChildRows.Count - 1

                Select Case vgProcessParameters.Rows(0).ChildRows(ni).Properties.Caption



                    Case "Amperage"
                        clsToolData.Amperage = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Angle"
                        clsToolData.Angle = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Cut Quality"
                        Select Case vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                            Case "Scribing"
                                clsToolData.CutQuality = 0

                            Case "Coarse"
                                clsToolData.CutQuality = 1

                            Case "Medium"
                                clsToolData.CutQuality = 2

                            Case "Medium Fine"
                                clsToolData.CutQuality = 3

                            Case "Fine"
                                clsToolData.CutQuality = 4

                            Case "Extra Fine"
                                clsToolData.CutQuality = 5

                        End Select

                    Case "Cut Side"
                        Select Case vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                            Case "Left"
                                clsToolData.CutSide = 1

                            Case "Right"
                                clsToolData.CutSide = -1

                            Case "None"
                                clsToolData.CutSide = 0

                        End Select

                    Case "Cut Type"
                        Select Case vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                            Case "Inside"
                                clsToolData.CutType = 0

                            Case "Outside"
                                clsToolData.CutType = 1

                        End Select

                    Case "Doff"
                        clsToolData.Doff = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Feed"
                        clsToolData.Feed = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Feed Mode"
                        Select Case vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                            Case "Canned Cycle"
                                clsToolData.FeedMode = 0

                            Case "Standard Punching"
                                clsToolData.FeedMode = 1

                            Case "Equalized Punching"
                                clsToolData.FeedMode = 2

                            Case "Bridge Punching"
                                clsToolData.FeedMode = 3

                            Case "UPR"
                                clsToolData.FeedMode = 4

                            Case "UPT"
                                clsToolData.FeedMode = 5

                        End Select

                    Case "Loff"
                        clsToolData.Loff = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "MaxPressure"
                        clsToolData.MaxPressure = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Plunge"
                        clsToolData.Plunge = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Speed"
                        clsToolData.Speed = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                        ' our custom parameters

                    Case "Level"
                        clsToolData.level = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Distance"
                        clsToolData.Distance = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Sharp Angle"
                        clsToolData.SharpAngle = vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value

                    Case "Use Long Side"
                        If (vgProcessParameters.Rows(0).ChildRows(ni).Properties.Value = True) Then
                            clsToolData.UseLongSide = 1
                        Else
                            clsToolData.UseLongSide = 0
                        End If

                End Select

                'clsToolData = Nothing

            Next
            Count = modSelection.SelectedCount()

            'Profiles take precedence over curves...
            For indx = 0 To (Count - 1)

                entityID = modSelection.GetAt(indx)

                lReturn = PortalExecute("*create:extract:id=" & entityID)
                entityType = PortalGetInt("type", c_INVALID)

                If (entityType = c_DBPROFILE) Then
                    Offset(entityID)
                End If

            Next

            'And now the remaining curves...
            For indx = 0 To (Count - 1)

                entityID = modSelection.GetAt(indx)
                If (CanProcess(entityID) = True) Then
                    Offset(entityID)
                End If

            Next
            clsToolData = Nothing
            modView.ViewRegen()
            UndoCommit()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function CanProcess(entityID As Long) As Boolean

        Dim parentID As Long
        Dim entityType As Long
        Dim okay As Boolean

        okay = False

        Try

            lReturn = PortalExecute("*create:extract:id=" & entityID)
            entityType = PortalGetInt("type", c_INVALID)

            If (entityType = c_DBLINE Or entityType = c_DBARC) Then

                parentID = 0
                parentID = PortalGetInt("owner", 0)

                If (parentID > 0) Then

                    lReturn = PortalExecute("*create:extract:id=" & parentID)
                    entityType = PortalGetInt("type", c_INVALID)

                    If (entityType = c_DBPROFILE) Then
                        okay = (IsSelected(parentID) = False)
                    Else
                        okay = True
                    End If

                Else

                    okay = True

                End If

            End If

            CanProcess = okay

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Private Sub Offset(entityID As Long)

        Dim clsToolData As ToolData

        Try

            For Each clsToolData In m_colToolSubset
                Call GetToolLayer(clsToolData)

                If m_colToolSubset(1).CutSide = 0 Then
                    lReturn = UniformOffset(entityID, clsToolData)

                Else
                    If (m_colToolSubset(1).Auto_Index = True) Then
                        lReturn = AutoIndexOffset(entityID, clsToolData)
                    ElseIf (m_colToolSubset(1).type_id >= 16) And (clsToolData.type_id <= 27) Then
                        lReturn = ConvexHullOffset(entityID, clsToolData)
                    Else
                        lReturn = UniformOffset(entityID, clsToolData)
                    End If
                End If

                If (m_colToolSubset(1).CutSide = 0) Then

                End If

                ' update the attributes
                If (lReturn > 0) Then
                    entityID = PortalGetInt("id", 0)

                    lReturn = SelectorPush()

                    lReturn = modSelection.SelectEntity(entityID)
                    SetToolAttributesOnGroup(clsToolData)

                    lReturn = SelectorPop()
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function AutoIndexOffset(entityID As Long, theToolData As ToolData) As Long

        Try

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            AutoIndexOffset = PortalExecute( _
                "toolpath:autoindexoffset:" & _
                " toolid=" & theToolData.Model_ID & _
                ",profid=" & entityID & _
                ",dir =" & theToolData.CutSide & _
                ",longside = " & theToolData.UseLongSide)

            System.Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Private Function ConvexHullOffset(entityID As Long, theToolData As ToolData) As Long

        Try

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            ConvexHullOffset = PortalExecute( _
                "toolpath:convexhulloffset:" & _
                " toolid=" & theToolData.Model_ID & _
                ",profid=" & entityID & _
                ",dir =" & theToolData.CutSide)

            System.Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Private Function UniformOffset(entityID As Long, theToolData As ToolData) As Long

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try

            UniformOffset = PortalExecute( _
                "create:offsetprofile:" & _
                " toolid=" & theToolData.Model_ID & _
                ",profid=" & entityID & _
                ",partprof=" & HeaderIntGet("PartProf", 0) & _
                ",zlevel=" & theToolData.level & _
                ",dir =" & theToolData.CutSide & _
                ",dist = " & theToolData.Distance & _
                ",explode = 0" & _
                ",sharp =" & theToolData.SharpAngle)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        System.Windows.Forms.Cursor.Current = Cursors.Default

    End Function

    Private Sub vgProcessParameters_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgProcessParameters.CellValueChanged
        Dim sFieldName As String
        Dim svalue As String

        Try

            sFieldName = GetValueFromDelimitedData(e.Row.Tag, "DatVarName", sEmpty)
            svalue = e.Value

            UpdateParameterValue(sFieldName, svalue)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub XtraForm7_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.CloseFirstPanel()
    End Sub

    '    Private Sub frmAssociate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub XtraForm7_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_colToolSubset = New ToolSetup

        LoadToolSetupListview()

        SetInitialParameterValues()

    End Sub

    Private Sub UpdateParameterValue(sFieldName As String, sFieldValue As String)

        Try

            Select Case sFieldName
                ' update based upon parameter selected

                Case "Amperage"
                    m_colToolSubset(1).Amperage = sFieldValue

                Case "Angle"
                    m_colToolSubset(1).Angle = sFieldValue

                Case "CutQuality"
                    Select Case sFieldValue

                        Case "Scribing"
                            m_colToolSubset(1).CutQuality = 0

                        Case "Coarse"
                            m_colToolSubset(1).CutQuality = 1

                        Case "Medium"
                            m_colToolSubset(1).CutQuality = 2

                        Case "Medium Fine"
                            m_colToolSubset(1).CutQuality = 3

                        Case "Fine"
                            m_colToolSubset(1).CutQuality = 4

                        Case "Extra Fine"
                            m_colToolSubset(1).CutQuality = 5

                    End Select

                Case "CutSide"
                    Select Case sFieldValue

                        Case "Left"
                            m_colToolSubset(1).CutSide = 1
                        Case "Right"
                            m_colToolSubset(1).CutSide = -1
                        Case "None"
                            m_colToolSubset(1).CutSide = 0

                    End Select

                Case "CutType"
                    Select Case sFieldValue

                        Case "Inside"
                            m_colToolSubset(1).CutType = 0

                        Case "Outside"
                            m_colToolSubset(1).CutType = 1

                    End Select

                Case "Doff"
                    m_colToolSubset(1).Doff = sFieldValue

                Case "Feed"
                    m_colToolSubset(1).Feed = sFieldValue

                Case "FeedMode"
                    Select Case sFieldValue

                        Case "Canned Cycle"
                            m_colToolSubset(1).FeedMode = 0

                        Case "Standard Punching"
                            m_colToolSubset(1).FeedMode = 1

                        Case "Equalized Punching"
                            m_colToolSubset(1).FeedMode = 2

                        Case "Bridge Punching"
                            m_colToolSubset(1).FeedMode = 3

                        Case "UPR"
                            m_colToolSubset(1).FeedMode = 4

                        Case "UPT"
                            m_colToolSubset(1).FeedMode = 5

                    End Select

                Case "Loff"
                    m_colToolSubset(1).Loff = sFieldValue

                Case "MaxPressure"
                    m_colToolSubset(1).MaxPressure = sFieldValue

                Case "Plunge"
                    m_colToolSubset(1).Plunge = sFieldValue

                Case "Speed"
                    m_colToolSubset(1).Speed = sFieldValue

                    ' our custom parameters

                Case "Level"
                    m_colToolSubset(1).level = sFieldValue

                Case "Distance"
                    m_colToolSubset(1).Distance = sFieldValue

                Case "SharpAngle"
                    m_colToolSubset(1).SharpAngle = sFieldValue

                Case "UseLongSide"
                    If (sFieldValue = "Enabled") Then
                        m_colToolSubset(1).UseLongSide = 1
                    Else
                        m_colToolSubset(1).UseLongSide = 0
                    End If

            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetInitialParameterValues()
        Dim cnt As Integer
        Dim sVarName As String
        Dim sVarValue As String
        Dim ni As Integer

        cnt = vgProcessParameters.Rows(0).ChildRows.Count

        Try

            For ni = 0 To cnt - 1
                vgProcessParameters.FocusedRow = vgProcessParameters.Rows(0).ChildRows(ni)

                sVarName = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "DatVarName", sEmpty)
                sVarValue = GetValueFromDelimitedData(vgProcessParameters.FocusedRow.Tag, "VBValue", sEmpty)

                UpdateParameterValue(sVarName, sVarValue)

            Next

            vgProcessParameters.FocusedRow = vgProcessParameters.Rows(0).ChildRows(0)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class