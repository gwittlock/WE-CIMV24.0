Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList


Public Class frmShapeLibrary
    Implements IDialogMouseUp
    Private s_Machine As String = String.Empty
    Private s_ToolSetup As String = String.Empty
    Private s_LayerSetup As String = String.Empty
    Private s_LeadSetup As String = String.Empty
    Private editValue As String

    Private nToolSetupRowId As BaseRow
    Private nLayerSetupRowID As BaseRow

    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Private CFG_MATERIAL_NODE As TreeListNode
    Private WithEvents rbMaterials As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit

    Private m_context As MACRO_OPTION
    Private m_is_active As Boolean
    Private sPieces() As String
    Private n_MacroType As Integer
    Private m_version As Long
    Private contents As clsStringArray
    Private WithEvents rbPropSettings As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Public nMacroOP As MACRO_OPTION

    Private Sub edit_EditValueChanged(sender As Object, e As EventArgs)
        Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
        nToolSetupRowId = Nothing
        nLayerSetupRowID = Nothing
        Dim datfilename As String = Nothing
        Dim currentCategoryRow As CategoryRow = Nothing


        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_dtSettings As New DataTable
        Dim connetionString As String
        Dim sql As String
        Dim nDataType As Integer

        vgMacro.ShowEditor()
    End Sub
    Private Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp
        Dim pick_info As clsPickInfo
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String


        Try
            If (vgMacro.FocusedRow IsNot Nothing) Then
                my_DatVarName = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "DatVarName", "")
                my_DialogDisplay = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "DialogDisplay", "")
                my_VBValue = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "VBValue", "")
                my_CValue = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "CValue", "")
                my_CVarName = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "CVarName", "")
                my_DataType = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "VarDataType", "")
                my_RecodID = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "nRecordID", "")
                my_sOptions = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "Options", "")

                modEdit.RevertProfile()

                pick_info = modPick.GetPickInfo()

                UpdateAccumulatorPickInfo(vgMacro, pick_info)

                ClientMouseUp = 1
                Dim operation As New MoveToNextCategoryOperation(vgMacro)
                Select Case bMyButton
                    Case Windows.Forms.MouseButtons.Left
                        vgMacro.RowsIterator.DoOperation(operation)
                        vgMacro.Focus()
                        vgMacro.FocusedRow = operation.NextCategory
                        vgMacro.LayoutChanged()

                    Case Windows.Forms.MouseButtons.Middle

                        vgMacro.RowsIterator.DoOperation(operation)
                        vgMacro.Focus()
                        vgMacro.FocusedRow = vgMacro.Rows(0)
                        vgMacro.LayoutChanged()
                End Select


            End If

        Catch ex As Exception
            MessageBox.Show("ShapeLibrary ClientMouseUp: " & ex.Message)
        End Try

    End Function
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

    End Function

    Public Sub Init(context As MACRO_OPTION)
        Try
            m_context = context
            nMacroOP = m_context

            Me.lblMacFilename.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            pnlMacroIcons.Visible = False
            SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1


            If (m_context = MACRO_OPTION.MACRO_SHAPE_LIB) Then
                AddNavGroups()
                Me.Text = "Shape Library"
                Me.Width = pnlMacroIcons.Width + pnlMacroVars.Width
                frmMain.splitContainerControl.SplitterPosition = Me.Width
                pnlMacroIcons.Visible = True
                Me.lblMacFilename.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                'SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Both
            ElseIf (m_context = MACRO_OPTION.MACRO_NORM) Then
                Me.Text = "Macro Execute"
                    'SplitContainerControl1.Panel2.Width = (pnlMacroVars.Width + 10)
                    Me.Width = Me.Width - Me.navShapeLibrary.Width - 10
                    fcbMacroFilename.Properties.Tag = PathMacroGet()
                    fcbMacroFilename.Text = TrimToFit(PathMacroGet(), 25)

                    If (FileExists(PathMacroGet()) = True) Then

                        LoadVariables(PathMacroGet(), "mac")

                    End If

            End If

        Catch ex As Exception
            MessageBox.Show("ShapeLibrary Init: " & ex.Message)
        End Try

    End Sub

    Private Sub navShapeLibrary_DoubleClick(sender As Object, e As EventArgs) Handles navShapeLibrary.DoubleClick
        Try
            Dim sncs As String
            SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Both
            picMacroDrawing.Visible = True
            sncs = navShapeLibrary.SelectedLink.ItemName
            Me.Width = Me.SplitContainerControl1.SplitterPosition + Me.picMacroDrawing.Width + 20

            frmMain.splitContainerControl.SplitterPosition = Me.Width


            picMacroDrawing.Image = ImageCollDWG.Images(sncs & ".gif")

        Catch ex As Exception
            MessageBox.Show("navShapeLibrary_DoubleClick: " & ex.Message)
        End Try

    End Sub
    Private Sub navShapeLibrary_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles navShapeLibrary.LinkClicked
        Dim cmd As String
        Dim sncs As String
        Dim sql As String

        Try
            sncs = e.Link.Item.Name

            sql = "SELECT * FROM SLDefnVar WHERE (SLDefnVar.DefnID = " & sncs & ")"

            cmd = "Admin:VarSys:StrPut:" &
                          " name=" & QStr("ShapeLibID") &
                          ",val=" & QStr(sncs)

            PortalExecute(cmd)

            lReturn = modPropList.InitFromDB(vgMacro, PathAppDB(), sql)

        Catch ex As Exception
            MessageBox.Show("navShapeLibrary_LinkClicked: " & ex.Message)
        End Try
    End Sub

    Private Sub AddNavGroups()
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim nGroupID As Integer
        Dim i As Integer
        Dim group As DevExpress.XtraNavBar.NavBarGroup

        Try
            navShapeLibrary.Groups.Clear()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            sql = "Select * From SL_Defn"

            connection = New OleDbConnection(connetionString)
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1
                group = navShapeLibrary.Groups.Add()
                group.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList
                group.Caption = ds.Tables(0).Rows(i).Item("Display")
                nGroupID = ds.Tables(0).Rows(i).Item("Group")

                navShapeLibrary.ActiveGroup = group

                AddGroupItems(group, nGroupID)

            Next

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing


        Catch ex As Exception
            MessageBox.Show("Fill Shape Lib Items: " & ex.Message)
        End Try

    End Sub
    Private Sub AddGroupItems(grp As DevExpress.XtraNavBar.NavBarGroup, nGroupID As Integer)
        'Select Shape_Lib.* From Shape_Lib Where (Shape_Lib.Group = 1 )

        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim sLibSNCS As String
        Dim i As Integer
        Dim item As DevExpress.XtraNavBar.NavBarItem
        Dim sLibIcon As String


        Try
            navShapeLibrary.ActiveGroup = grp

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            sql = "Select Shape_Lib.* From Shape_Lib Where (Shape_Lib.Group = " & nGroupID & " )"


            connection = New OleDbConnection(connetionString)
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                sLibSNCS = ds.Tables(0).Rows(i).Item("SNCS")
                sLibIcon = sLibSNCS & ".png"
                item = navShapeLibrary.Items.Add()
                item.Caption = ds.Tables(0).Rows(i).Item("Description")
                item.Name = sLibSNCS
                item.Tag = ds.Tables(0).Rows(i).Item("Macro_FilePath")

                item.SmallImageIndex = ImageCollection1.Images.Keys.IndexOf(sLibIcon)

                item.LargeImageIndex = item.SmallImageIndex

                navShapeLibrary.ActiveGroup.ItemLinks.Add(item)

            Next

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("Fill Shape Lib Items: " & ex.Message)

        End Try

    End Sub

    Private Sub LoadValuesFromHeader()
        Dim sval As String
        Dim sHeaderProp As String
        Dim my_DataType As Integer
        Dim sOptions

        Try
            For Each row As CategoryRow In vgMacro.Rows

                For Each childRow As EditorRow In row.ChildRows
                    sHeaderProp = GetValueFromDelimitedData(childRow.Tag, "DatVarName", "")
                    my_DataType = GetValueFromDelimitedData(childRow.Tag, "VarDataType", 0)

                    sval = childRow.Properties.Value

                    If (HeaderStringGet(sHeaderProp, "") <> "") Then
                        sval = HeaderStringGet(sHeaderProp, "")
                    End If

                    If (my_DataType > DB_SIMPLE) Then
                        sOptions = GetValueFromDelimitedData(childRow.Tag, "Options", "")
                        'childRow.Properties.Value = GetOptionText(";", GetValueFromDelimitedData(childRow.Tag, "Options", ""), 0)


                    Else
                        childRow.Properties.Value = sval
                    End If
                Next

            Next

        Catch ex As Exception
            MessageBox.Show("LoadValuesFromHeader: " & ex.Message)
        End Try

    End Sub
    Private Function PrepareVars() As Long
        Dim sval As String
        Dim cmd As String
        Dim iname As String
        Dim my_DataType As Integer
        Dim sOptions As String

        Try
            For Each row As CategoryRow In vgMacro.Rows

                For Each childRow As EditorRow In row.ChildRows

                    my_DataType = GetValueFromDelimitedData(childRow.Tag, "VarDataType", "")

                    If (my_DataType = DB_COMBO) Then

                        sOptions = GetValueFromDelimitedData(childRow.Tag, "Options", "")

                        sval = GetOptionIndex(sOptions, childRow.Properties.Value)

                        ' sval = GetValueFromDelimitedData(childRow.Properties.Value, "CValue", "")
                    Else
                        sval = childRow.Properties.Value
                    End If


                    iname = Trim(GetValueFromDelimitedData(childRow.Tag, "DatVarName", ""))
                    ' iname = childRow.Tag
                    'Record the variable in the model header.  Doing this allows
                    'us to display the last-used value in the dialog (if ever we
                    'execute the same macro on the same (or similar) model).
                    lReturn = HeaderStringSet(iname, sval)

                    'Redundant to HeaderStringSet().  Introduced with V17.
                    'Just another way of passing data to the macro.  In this
                    'case, the macro can use VarSys.StrGet().
                    cmd = "Admin:VarSys:StrPut:" &
                          " name=" & QStr(iname) &
                          ",val=" & QStr(sval)

                    lReturn = PortalExecute(cmd)
                Next

            Next

        Catch ex As Exception
            MessageBox.Show("PrePareVars: " & ex.Message)
        End Try

    End Function

    Private Sub frmShapeLibrary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False
        frmMain.CloseFirstPanel()
        bIsShapeLibraryLoaded = False
    End Sub


    Private Sub LoadVariables(
                ByVal sFileName As String,
                ByVal sClass As String,
                Optional bClear As Boolean = True)

        Try

            n_MacroType = GetMacroType(sFileName)

            If (n_MacroType = MACRO_TYPE.MACRO_MACTYPE = True) Then

                LoadVersion16Variables(sFileName, sClass)

            Else

                LoadVersion17Variables(contents)

            End If
            LoadValuesFromHeader()

        Catch ex As Exception
            MessageBox.Show("LaodVariables: " & ex.Message)
        End Try

    End Sub

    Private Function GetMacroType(sFilename As String) As Integer
        Dim sline As String

        Try
            GetMacroType = -1
            m_version = -1

            contents = New clsStringArray

            Using sr As StreamReader = New StreamReader(sFilename)

                sline = sr.ReadLine()

                While (sr.EndOfStream = False)
                    If (InStr(UCase(sline), "BEGIN_MACRO") > 0) Then

                        m_version = 17
                        GetMacroType = MACRO_TYPE.MACRO_VARTYPE
                    ElseIf (InStr(UCase(sline), "PUBLIC") > 0) Then

                        m_version = 16
                        GetMacroType = MACRO_TYPE.MACRO_MACTYPE

                    End If

                    If (m_version > 0) Then Exit While

                    lReturn = contents.Add(sline)

                    sline = sr.ReadLine()

                End While

                sr.Dispose()

            End Using

        Catch ex As Exception
            MessageBox.Show("GetMacroType: " & ex.Message)
        End Try

    End Function

    Private Sub LoadVersion16Variables(sMacroName As String, sClass As String)
        Dim lCount As Long
        Dim nRow As Long 'Actually represents the number of variables
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
        Dim toolSetupName As String
        Dim sql As String
        Dim n_ToolSetupID As Integer
        Dim sDefaultName As String = Nothing


        Try
            vgMacro.Rows.Clear()


            currentCategoryRow = CreateCategoryRow(vgMacro, "Variables", "Variables", "Variables", 0, "MACVAR", DB_HEADER, 0, sEmpty, 0)

            lReturn = PortalExecute("admin:javavarsextract:" &
           " file=" & QStr(sMacroName) & ",class=" & QStr(sClass))

            lCount = PortalGetInt("count", 0)

            For nRow = 1 To lCount
                lReturn = PortalExecute("*admin:javavarget:index=" & nRow - 1)

                sData = PortalGetString("data", "")

                'NOTE: zero-based!
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

                    Case DB_HEADER, DB_NOP
                        currentCategoryRow = CreateCategoryRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)

                    Case DB_STR
                        currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                    Case DB_BOOL
                        currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_INT
                        currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_DBL
                        currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_FILE, DB_BATCH

                        currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                    Case DB_TOOL
                        toolSetupName = HeaderStringGet("MachCfg", "")
                        n_ToolSetupID = GetToolSetupIDFromDescription(toolSetupName)  'RegGetString("Global", "ToolSetupID", 0)
                        'my_CValue = 0
                        'my_VBValue = "None"
                        'my_RecodID = 0

                        sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" &
                            " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " &
                            "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " &
                            "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" &
                            " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & n_ToolSetupID & "))" &
                            " ORDER BY [Tool Crib].Description"

                        arrMachine = PopulateComboList(sql, False, True)

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                   my_DatVarName,
                                                                my_DialogDisplay,
                                                                my_VBValue,
                                                                my_CValue,
                                                                my_CVarName,
                                                                my_DataType,
                                                                my_RecodID,
                                                                arrMachine, 4))

                    Case DB_LEADSETUP

                        arrLayerSetup = PopulateComboList("Select [Lead Setup].* From [Lead Setup]  Order By [Lead Setup].Description", False, True)

                        sDefaultName = RegGetString("Global", "LeadSetup", "None")

                        sDefaultName = sDefaultName

                        Dim n_LayerSetupID As Integer = modTranslate.GetLeadSetupID(sDefaultName)

                        If (sDefaultName = String.Empty) Then
                            sDefaultName = "None"
                        End If

                        s_LayerSetup = sDefaultName

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                         "glb.LeadSetupID",
                                                                         "Lead Setup",
                                                                         s_LayerSetup,
                                                                         n_LayerSetupID,
                                                                         "Lead Setup ID",
                                                                         DB_LEADSETUP,
                                                                         0,
                                                                         arrLayerSetup, 0))




                    Case DB_DCOMBO
                        Dim i As Integer

                        lstOptions.Items.Clear()

                        For i = 4 To sPieces.Count - 1
                            lstOptions.Items.Add(sPieces(i).ToString)

                            If (UCase(sPieces(i).ToString) = UCase(my_VBValue)) Then
                                my_CValue = i - 4
                            End If
                        Next
                        arrOptions = PopulateComboListFromDat(lstOptions)

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                my_DatVarName,
                                                                 my_DialogDisplay,
                                                                 my_VBValue,
                                                                 my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))

                    Case DB_COMBO
                        Dim i As Integer

                        lstOptions.Items.Clear()

                        For i = 3 To sPieces.Count - 1
                            lstOptions.Items.Add(sPieces(i).ToString)

                            If (sPieces(i).ToString = my_VBValue) Then
                                my_CValue = i - 3
                            End If
                        Next
                        arrOptions = PopulateComboListFromDat(lstOptions)

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                my_DatVarName,
                                                                 my_DialogDisplay,
                                                                 my_VBValue,
                                                                 my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))

                    Case DB_TOOLSETUP

                        Dim i As Integer

                        arrToolSetup = PopulateComboList("SELECT * FROM [Tool Setups] " &
                                                          "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, False)


                        sDefaultName = RegGetString("Global", "ToolSetup", "")
                            s_ToolSetup = sDefaultName
                        n_ToolSetupID = modTranslate.GetToolSetupIDFromDescription(s_ToolSetup)

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                         "glb.ToolSetupID",
                                                                         "Tool Setup",
                                                                         s_ToolSetup,
                                                                         n_ToolSetupID,
                                                                         "Tool Setup ID",
                                                                         DB_TOOLSETUP,
                                                                         0,
                                                                         arrToolSetup, 0))


                    Case DB_MATLIST

                        CreateMaterialTypeNodes(tl)

                        ' Used rbMaterials as the editor for Material record cell
                        rbMaterials = New RepositoryItemPopupContainerEdit()
                        rbMaterials.Name = "rbMaterials"
                        rbMaterials.PopupControl = popupContainerControl1
                        AddHandler rbMaterials.QueryDisplayText, AddressOf rbMaterials_QueryDisplayText

                        vgMacro.RepositoryItems.Add(rbMaterials)


                    Case DB_MACHINE
                        arrMachine = PopulateComboList("SELECT * FROM [Machines]", True, False)

                        sDefaultName = RegGetString("Global", "Machine", "")

                        s_Machine = sDefaultName

                        m_machine_id = modMachine.GetMachineIDFromDescrip(s_Machine)

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                     "glb.Machine",
                                                                     "Machine",
                                                                    s_Machine,
                                                                    m_machine_id,
                                                                    "Machine ID",
                                                                    DB_MACHINE,
                                                                    0,
                                                                    arrMachine, 0))

                    Case DB_LAYERSETUP

                        arrLayerSetup = PopulateComboList("SELECT * FROM [Layer Setups] " &
                            "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, True)

                        sDefaultName = RegGetString("Global", "LayerSetup", "None")

                        sDefaultName = sDefaultName

                        Dim n_LayerSetupID As Integer = modTranslate.GetLayerSetupID(sDefaultName, m_machine_id)

                        If (sDefaultName = String.Empty) Then
                            sDefaultName = "None"
                        End If

                        s_LayerSetup = sDefaultName

                        currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                         "glb.LayerSetupID",
                                                                         "Layer Setup",
                                                                         s_LayerSetup,
                                                                         n_LayerSetupID,
                                                                         "Layer Setup ID",
                                                                         DB_LAYERSETUP,
                                                                         0,
                                                                         arrLayerSetup, 0))



                End Select
            Next

        Catch ex As Exception
            MessageBox.Show("LoadVersion16Variables: " & ex.Message)
        End Try

    End Sub

    Private Sub LoadVersion17Variables(m_contents As clsStringArray)
        Dim lCount As Long
        Dim indx As Long
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
        Dim nOpenBracket As Long
        Dim nClosedBracket As Long
        Dim toolSetupName As String
        Dim sql As String
        Dim nToolSetupID As Long


        Try

            vgMacro.Rows.Clear()

            lstOptions.Items.Clear()


            currentCategoryRow = CreateCategoryRow(vgMacro, "Variables", "Variables", "Variables", 0, "MACVAR", DB_HEADER, 0, sEmpty, 0)

            lCount = m_contents.Count

            For indx = 1 To lCount - 1

                sData = contents.GetAt(indx)
                If (sData <> "") Then

                    nOpenBracket = sData.IndexOf("[") + 1
                    nClosedBracket = sData.IndexOf("]") - nOpenBracket

                    sData = sData.Substring(nOpenBracket, nClosedBracket)


                    'NOTE: zero-based!
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
                            currentCategoryRow = CreateCategoryRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)

                        Case DB_STR
                            currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                        Case DB_BOOL
                            currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_INT
                            currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_DBL
                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_TOOL
                            toolSetupName = HeaderStringGet("MachCfg", "")
                            nToolSetupID = GetToolSetupIDFromDescription(toolSetupName)  'RegGetString("Global", "ToolSetupID", 0)
                            'my_CValue = 0
                            'my_VBValue = "None"
                            'my_RecodID = 0

                            sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" &
                                " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " &
                                "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " &
                                "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" &
                                " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & nToolSetupID & "))" &
                                " ORDER BY [Tool Crib].Description"

                            arrMachine = PopulateComboList(sql, False, True)

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(m_proplist,
                                                                       my_DatVarName,
                                                                    my_DialogDisplay,
                                                                    my_VBValue,
                                                                    my_CValue,
                                                                    my_CVarName,
                                                                    my_DataType,
                                                                    my_RecodID,
                                                                    arrMachine, 4))


                        Case DB_FILE, DB_BATCH
                            my_sOptions = sPieces(4)

                            currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                        Case DB_DCOMBO, DB_COMBO
                            Dim i As Integer

                            lstOptions.Items.Clear()

                            For i = 4 To sPieces.Count - 1
                                lstOptions.Items.Add(sPieces(i).ToString)

                                If (sPieces(i).ToString = my_VBValue) Then
                                    my_CValue = i - 3
                                End If
                            Next
                            arrOptions = PopulateComboListFromDat(lstOptions)

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                    my_DatVarName,
                                                                     my_DialogDisplay,
                                                                     my_VBValue,
                                                                     my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))

                        Case DB_MATLIST
                            MessageBox.Show("We found matlist")
                            currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgMacro,
                                                                                   my_DatVarName,
                                                                                   my_DialogDisplay,
                                                                                   my_VBValue,
                                                                                   my_CValue,
                                                                                   my_CVarName,
                                                                                   my_DataType,
                                                                                   my_RecodID,
                                                                                   my_sOptions, 0))

                        Case DB_MAT_LEN

                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgMacro,
                                                                                     my_DatVarName,
                                                                                    my_DialogDisplay,
                                                                                    my_VBValue,
                                                                                    my_CValue,
                                                                                    my_CVarName,
                                                                                    my_DataType,
                                                                                    my_RecodID,
                                                                                    my_sOptions, 0))


                        Case DB_MAT_WID
                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgMacro,
                                                                                    my_DatVarName,
                                                                                    my_DialogDisplay,
                                                                                    my_VBValue,
                                                                                    my_CValue,
                                                                                    my_CVarName,
                                                                                    my_DataType,
                                                                                    my_RecodID,
                                                                                    my_sOptions, 0))

                        Case DB_MAT_THICK
                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgMacro, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    End Select

                End If


            Next

        Catch ex As Exception
            MessageBox.Show("LoadVersion17Variables: " & ex.Message)
        End Try


    End Sub

    Private Sub sbExecute_Click(sender As Object, e As EventArgs) Handles sbExecute.Click

        Dim cmd As String
        Dim DoUpdate As String

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            UndoPrepare()

            PrepareVars()

            If (m_context = MACRO_OPTION.MACRO_NORM) Then


                sReturn = PathMacroSet(fcbMacroFilename.Properties.Tag.ToString)
                cmd = "admin:macrorun: javafile=" & QStr(fcbMacroFilename.Properties.Tag.ToString)
            Else

                cmd = "admin:macrorun: javafile=" & QStr(App_Path & "\macros\SL_Global.java")

            End If


            lReturn = PortalExecute(cmd)

            'Lets be sure thera are no empty features lying around
            lReturn = PortalExecute("create:empty:") ' get rid of empty feature


            frmMain.PublicPatternComboShow()
            frmMain.SynchronizeUI(modSelection.SelectedCount())

            Windows.Forms.Cursor.Current = Cursors.Default

            '2011.15.08 (GW) -- Creating macros that does a model:toolsupdate: does not reflect
            'the new tools until we reload the model. So to play it safe we should get the tools
            'from the model. We check the mac var updatetooling so we do not have to run this on each macro.
            'the only issue is that this mac var has to hardcoded

            DoUpdate = HeaderStringGet("mac.updatetooling", "")
            If (UCase(DoUpdate) = "TRUE") Then
                'MsgBox "we do the update"

                GetToolsFromModel()

            End If

            UndoCommit()
        Catch ex As Exception
            MessageBox.Show("sbExecute_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub fcbMacroFilename_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles fcbMacroFilename.ButtonClick
        Dim java_FileOpen As New OpenFileDialog
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim sJavaFile As String

        Try

            java_FileOpen.Filter = "java files (*.java)|*.java"
            java_FileOpen.FilterIndex = 1
            'java_FileOpen.RestoreDirectory = True

            If (PathMacroGet() <> "") Then
                java_FileOpen.InitialDirectory = PathDriveFolder(PathMacroGet())

            Else
                java_FileOpen.InitialDirectory = PathMacroFolder()
            End If


            If java_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                sJavaFile = java_FileOpen.FileName
                LoadVariables(sJavaFile, "mac")
                Me.fcbMacroFilename.Properties.Tag = sJavaFile
                Me.fcbMacroFilename.Text = TrimToFit(sJavaFile, 20)

            End If

            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception

            MessageBox.Show("fcbMacroFilename_ButtonClick: " & ex.Message)

        End Try

    End Sub

    Private Sub vgMacro_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgMacro.CellValueChanged
        Dim iname As String
        Dim sOptions As String
        Dim nVarType As Integer
        Dim sValue As String
        Dim VbVarValue As Object

        Try
            nVarType = CInt(GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "VarDataType", ""))
            iname = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "DatVarName", "")

            sOptions = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "Options", "")

            Select Case nVarType

                Case DB_COMBO, DB_DCOMBO, DB_USERVAR, DB_LEADSETUP
                    sValue = GetOptionIndex(sOptions, e.Value)

                Case DB_CRIB
                    sValue = FindModelIDFromToolDescrip(e.Value)

                Case DB_DBL
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetDouble("val", 0)
                        'we need to only round to millionths in the case of the Adv Rotor build
                        'we ar leaving it for now to test.
                        sValue = Round(e.Value, Places.TenThousandths)
                        vgMacro.FocusedRow.Properties.Value = sValue
                    Else
                        sValue = Round(e.Value, Places.TenThousandths)
                    End If

                Case DB_INT
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetInt("val", 0)

                        vgMacro.FocusedRow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If

                Case DB_TOOL, DB_STR
                    VbVarValue = e.Row.Properties.Value

                    sValue = VbVarValue

                    vgMacro.FocusedRow.Properties.Value = sValue

                Case Else
                    If (PortalExecute("*solve:eval:exp=" & QStr(vgMacro.FocusedRow.Properties.Value)) > 0) Then

                        sValue = PortalGetInt("val", 0)

                        vgMacro.FocusedRow.Properties.Value = sValue

                    Else

                        sValue = 0

                    End If
                    '                sValue = e.Value

            End Select

            lReturn = UpdateAccumulatorDirect(vgMacro, iname, sValue)

        Catch ex As Exception
            MessageBox.Show("vgmacro_CellValueChanged: " & ex.Message)
        End Try

    End Sub

    Private Sub tl_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tl.FocusedNodeChanged
        Dim nCurr_Node_Tag As Long
        Dim sCurr_Display As String
        Dim sMaterialType As String
        Dim treeList As TreeList = TryCast(sender, TreeList)

        Try


            If (e.Node IsNot Nothing) Then


                If (e.Node.ParentNode IsNot Nothing) Then

                    sMaterialType = e.Node.ParentNode.GetDisplayText(tl.Columns(0))
                    sCurr_Display = sMaterialType & ", " & e.Node.GetDisplayText(tl.Columns(0))
                    nCurr_Node_Tag = e.Node.Tag

                    Dim popupContainerControl = TryCast(treeList.Parent, PopupContainerControl)
                    popupContainerControl.OwnerEdit.EditValue = sCurr_Display
                    popupContainerControl.OwnerEdit.Tag = e.Node.Tag
                    popupContainerControl.OwnerEdit.ClosePopup()

                End If
            End If

        Catch ex As Exception

            MessageBox.Show("tl_FocusedNodeChanged: " & ex.Message)

        End Try

    End Sub

    Private Sub vgMacro_KeyUp(sender As Object, e As KeyEventArgs) Handles vgMacro.KeyUp
        Try
            If (e.KeyCode = Keys.Enter) Then

                If (vgMacro.FocusedRow Is vgMacro.GetLastVisible()) Then

                    vgMacro.FocusedRow = vgMacro.Rows.FirstVisible

                Else

                    System.Windows.Forms.SendKeys.Send("{TAB}") ' treat as a tab to calculate

                End If

            End If

        Catch ex As Exception
            MessageBox.Show("vgMacro_KeyUp: " & ex.Message)
        End Try

    End Sub

    Private Sub frmShapeLibrary_Load(sender As Object, e As EventArgs) Handles Me.Load
#If ADVROTOR Then
        lblMacFilename.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
#End If
        bIsShapeLibraryLoaded = True
        vgMacro.Refresh()

        m_curr_dlg = Me
    End Sub
    Private Class MoveToNextCategoryOperation
        Inherits RowOperation
        Private nextCategory_Renamed As CategoryRow
        Private currentRow As BaseRow

        Public Sub New(ByVal grid As VGridControl)
            MyBase.New()
            currentRow = grid.FocusedRow
        End Sub
        Public Overrides Sub Execute(ByVal row As BaseRow)

            If (currentRow IsNot Nothing) Then
                If row.VisibleIndex > currentRow.VisibleIndex Then
                    If nextCategory_Renamed Is Nothing AndAlso TypeOf row Is CategoryRow Then
                        nextCategory_Renamed = TryCast(row, CategoryRow)
                    End If
                End If

            End If
        End Sub

        Public ReadOnly Property NextCategory() As CategoryRow
            Get
                Return nextCategory_Renamed
            End Get
        End Property
    End Class

    Private Sub picMacroDrawing_Click(sender As Object, e As EventArgs) Handles picMacroDrawing.Click

        Try
            Me.picMacroDrawing.Image = Nothing
            picMacroDrawing.Visible = False
            Me.Width = pnlMacroIcons.Width + pnlMacroVars.Width
            frmMain.splitContainerControl.SplitterPosition = Me.Width
            SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1

        Catch ex As Exception
            MessageBox.Show("picMacroDrawing_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub rbPropSettings_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles rbPropSettings.ButtonClick
        Dim FocusedRow As BaseRow = vgMacro.FocusedRow
        Dim Tag As Object = FocusedRow.Tag
        Dim filters As Long = 0
        Dim iname As String = Nothing
        Dim nDataType As Long
        Dim m_exploer_Filename As String
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim openFileDialog As New OpenFileDialog()
        Dim spieces() As String
        Dim nDialogType As Integer
        Dim sOptions As String
        Dim sDialogFilters As String
        Dim sDialogTitle As String

        Try

            nDataType = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "VarDataType", 0)
            Select Case nDataType
                Case DB_FILE, FILE_BAT
                    sOptions = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "Options", 0)

                    spieces = Split(sOptions, ",")

                    nDialogType = spieces(1)

                    sDialogTitle = spieces(0)

                    Select Case Val(spieces(3))

                        Case FILE_MM2
                            sDialogFilters = "MM2 Files (*.MM2)|*.MM2"

                        Case FILE_NST
                            sDialogFilters = "NST Files (*.NST)|*.NST"

                        Case FILE_REM
                            sDialogFilters = "REM Files (*.REM)|*.REM"

                        Case FILE_DXF
                            sDialogFilters = "DXF Files (*.DXF)|*.DXF"

                        Case FILE_DWG
                            sDialogFilters = "DWG Files (*.DWG)|*.DWG"

                        Case FILE_PSM
                            sDialogFilters = "PSM Files (*.PSM)|*.PSM"

                        Case FILE_CNC
                            sDialogFilters = "CNC Files (*.CNC)|*.CNC"

                        Case FILE_PDB
                            sDialogFilters = "PDB Files (*.PDB)|*.PDB"

                        Case FILE_BAT
                            sDialogFilters = "BAT Files (*.BAT)|*.BAT"

                        Case Else
                            sDialogFilters = "All Files (*.*)|*.*"

                    End Select


                    If (nDialogType = 0) Then

                        openFileDialog.Filter = sDialogFilters
                        openFileDialog.FilterIndex = 1
                        openFileDialog.Title = sDialogTitle
                        'saveFileDialog1.RestoreDirectory = True

                        If openFileDialog.ShowDialog() = DialogResult.OK Then

                            m_exploer_Filename = openFileDialog.FileName


                            vgMacro.BeginDataUpdate()
                            vgMacro.SetCellValue(FocusedRow, vgMacro.FocusedRecord, m_exploer_Filename)
                            vgMacro.EndDataUpdate()
                            vgMacro.RefreshEditor()
                            iname = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "DatVarName", "")

                            lReturn = UpdateAccumulatorDirect(vgMacro, iname, m_exploer_Filename)
                        End If

                    Else

                        saveFileDialog1.Filter = sDialogFilters
                        saveFileDialog1.FilterIndex = 1
                        saveFileDialog1.Title = sDialogTitle
                        'saveFileDialog1.RestoreDirectory = True

                        If saveFileDialog1.ShowDialog() = DialogResult.OK Then

                            m_exploer_Filename = saveFileDialog1.FileName


                            vgMacro.BeginDataUpdate()
                            vgMacro.SetCellValue(FocusedRow, vgMacro.FocusedRecord, m_exploer_Filename)
                            vgMacro.EndDataUpdate()
                            vgMacro.RefreshEditor()
                            iname = GetValueFromDelimitedData(vgMacro.FocusedRow.Tag, "DatVarName", "")

                            lReturn = UpdateAccumulatorDirect(vgMacro, iname, m_exploer_Filename)
                        End If


                    End If
            End Select

            modView.ViewRegen()

        Catch ex As Exception
            MessageBox.Show("rbPropSettings_ButtonClick: " & ex.Message)
        End Try



    End Sub


    Private Sub sbCompile_Click(sender As Object, e As EventArgs) Handles sbCompile.Click

        Try

            Dim cmd As String

            cmd = "Admin:MacroCompile:" &
                  " javafile=" & QStr(fcbMacroFilename.Properties.Tag.ToString)

            lReturn = PortalExecute(cmd)
            If (lReturn < 1) Then
                cmd = "The macro (" & fcbMacroFilename.Tag & ") failed to compile."
                lReturn = MessageBox.Show(cmd, "Error")
            End If

        Catch ex As Exception
            MessageBox.Show("sbCompile_Click: " & ex.Message)
        End Try

    End Sub


    Private Sub fcbMacroFilename_MouseHover(sender As Object, e As EventArgs) Handles fcbMacroFilename.MouseHover
        fcbMacroFilename.ToolTip = fcbMacroFilename.Properties.Tag.ToString

    End Sub

    Private Sub CreateMaterialTypeNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        Dim sql As String
        Dim ds As New System.Data.DataSet

        Dim s_MaterialCategory As String
        Dim n_MaterialID As Integer
        Dim i As Integer
        Dim dtMaterialType As System.Data.DataTable


        tl.BeginUnboundLoad()

        tl.ClearNodes()

        CFG_ROOT_NODE = Nothing


        CFG_MATERIAL_ROOT_NODE = tl.AppendNode(New Object() {"Materials"}, CFG_ROOT_NODE, TAG_MATERIAL_ROOT_NODE)

        s_MaterialCategory = ""

        sql = "Select [Material Types].* From [Material Types]"

        Try

            dtMaterialType = ConnectToCMDB(sql)


            For i = 0 To dtMaterialType.Rows.Count - 1
                s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")

                'If InStr(UCase(s_MaterialCategory), UCase(sUsage)) Then
                n_MaterialID = dtMaterialType.Rows(i).Item("ID")

                CFG_MATERIAL_CATEGORY_NODE = tl.AppendNode(New Object() {s_MaterialCategory}, CFG_MATERIAL_ROOT_NODE, TAG_MATERIAL_CATEGORY_NODE)

                FillMaterialNodes(n_MaterialID)

                dtMaterialType.Dispose()
                'End If

            Next

            tl.EndUnboundLoad()



        Catch ex As Exception

            MessageBox.Show("CreateMaterialTypeNodes: " & ex.Message)

        End Try

    End Sub

    Private Sub FillMaterialNodes(n_MaterialID As Long)
        Dim sql As String
        Dim ds As New System.Data.DataSet
        Dim s_MaterialDescription As String
        Dim i As Integer
        Dim dtMaterialNode As System.Data.DataTable

        s_MaterialDescription = ""

        sql = "Select [Material Inventory].* From [Material Inventory] Where ([Material Inventory].[Type ID] = " & n_MaterialID & " )"

        Try

            dtMaterialNode = ConnectToCMDB(sql)

            For i = 0 To dtMaterialNode.Rows.Count - 1
                s_MaterialDescription = dtMaterialNode.Rows(i).Item("Description")

                n_MaterialID = dtMaterialNode.Rows(i).Item("ID")

                CFG_MATERIAL_NODE = tl.AppendNode(New Object() {s_MaterialDescription}, CFG_MATERIAL_CATEGORY_NODE, TAG_MATERIAL_NODE & "," & n_MaterialID)

            Next
            tl.ExpandAll()

            dtMaterialNode.Dispose()

        Catch ex As Exception

            MessageBox.Show("FillMaterialNodes: " & ex.Message)

        End Try

    End Sub

    Private Sub vgMacro_ShowingEditor(sender As Object, e As CancelEventArgs) Handles vgMacro.ShowingEditor
        Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
        Dim indx As Integer
        ' Dim DB_TOOLSETUP As Integer = 8
        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long
        Dim s_LayerSetup As String
        Dim n_LayerSetupID As Long

        Dim sOptions As String = sEmpty

        If edit IsNot Nothing Then
            AddHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
        End If
    End Sub

    Private Sub popupContainerEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles popupContainerEdit1.EditValueChanged
        Dim sPieces() As String
        Try


            If (popupContainerEdit1.Tag IsNot Nothing) Then
                sPieces = Split(popupContainerEdit1.Tag, ",")

                Dim materialID As Long

                materialID = (sPieces(1))

            End If

        Catch ex As Exception
            MessageBox.Show("popupContainerEdit1_EditValueChanged: " & ex.Message)
        End Try
    End Sub

    Private Sub popupContainerEdit1_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles popupContainerEdit1.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")
    End Sub

    Private Sub rbMaterials_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles rbMaterials.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")
    End Sub

    Private Sub PopulateMaterialList()
        CreateMaterialTypeNodes(tl)


        popupContainerControl1.Controls.Add(tl)

        ' Used rbMaterials as the editor for Material record cell
        rbMaterials = New RepositoryItemPopupContainerEdit()
        rbMaterials.Name = "rbMaterials"
        rbMaterials.PopupControl = popupContainerControl1
        AddHandler rbMaterials.QueryDisplayText, AddressOf rbMaterials_QueryDisplayText
        vgMacro.Rows("categoryMaterial").ChildRows(0).Properties.RowEdit = rbMaterials

    End Sub

    Private Sub vgMacro_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgMacro.CellValueChanging
        Dim sDatVarName As String
        Dim nMatID As Long
        Dim sDataType As Integer
        Dim edit As ComboBoxEdit = TryCast(vgMacro.ActiveEditor, ComboBoxEdit)
        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long


        Dim sOptions As String = sEmpty



        sDataType = GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0)

        If (sDataType = DB_MATLIST) Then
            MessageBox.Show("Fill the material sizes")
        End If
        Select Case sDataType
            Case DB_MATLIST
                nMatID = modTranslate.GetMaterialIDFromDescription(e.Value)

                Dim childRows As VGridRows = vgMacro.FocusedRow.ParentRow.ChildRows



        End Select

    End Sub

    Private Sub vgMacro_CustomRecordCellEdit(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs) Handles vgMacro.CustomRecordCellEdit
        Dim nTemp As Integer

        Try

            If (e.Row.Tag IsNot Nothing) Then

                nTemp = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0))

                Select Case nTemp
                    Case DB_FILE
                        e.RepositoryItem = rbPropSettings

                    Case DB_FOLDER
                        e.RepositoryItem = rbPropSettings

                    Case DB_USERVAR
                        ' modPropList.GetPropsForUserVar(vgProplist, e.Row, e.RecordIndex, m_sub_item_sncs)


                End Select
                If (nTemp = DB_FILE Or nTemp = DB_FOLDER) Then

                End If

            End If

        Catch ex As Exception
            MessageBox.Show("vgMacro_CustomRecordCellEdit: " & ex.Message)
        End Try
    End Sub
End Class