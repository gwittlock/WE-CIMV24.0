
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
Imports DevExpress.XtraVerticalGrid.Events

Public Class frmRegUserEntry
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



        'nRowId = GetRowByCaption("Tool Setup")

        'editValue = edit.EditValue.ToString()

        'nRowIndx = nRowId.Index


        'vgMacro.FocusedRow = vgMacro.Rows(nRowId.ParentRow.Index).ChildRows(nRowId.Index)
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

                'vgProplist.BeginDataUpdate()

                UpdateAccumulatorPickInfo(vgMacro, pick_info)

                ' vgProplist.EndDataUpdate()

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

    Public Sub init()
        Me.Text = "Macro Execute"
        Try
            fcbMacroFilename.Properties.Tag = NormalizePath(Application.StartupPath) & "extras\RegEntry.Dat"
            fcbMacroFilename.Text = NormalizePath(Application.StartupPath) & "extras\RegEntry.Dat"


            If (FileExists(PathMacroGet()) = True) Then

                LoadVariables(PathMacroGet(), "mac")

            End If


        Catch ex As Exception
            MessageBox.Show("ShapeLibrary Init: " & ex.Message)
        End Try

    End Sub

    Private Sub frmRegUserEntry_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        m_is_active = False
        frmMain.CloseFirstPanel()
    End Sub



    Private Sub LoadVariables(
                ByVal sFileName As String,
                ByVal sClass As String,
                Optional bClear As Boolean = True)

        Try

            'n_MacroType = GetMacroType(sFileName)

            'If (n_MacroType = MACRO_TYPE.MACRO_MACTYPE = True) Then

            '    LoadVersion16Variables(sFileName, sClass)

            'Else
            'Me.Text = "Macro Execute"
            'SplitContainerControl1.Panel2.Width = (pnlMacroVars.Width + 10)
            'Me.Width = Me.Width - Me.navShapeLibrary.Width - 10


            LoadVersion17Variables(contents)

            ' End If
            'LoadValuesFromHeader()

        Catch ex As Exception
            MessageBox.Show("LaodVariables: " & ex.Message)
        End Try

    End Sub

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

                    Case DB_DCOMBO
                        Dim i As Integer

                        lstOptions.Items.Clear()

                        For i = 4 To sPieces.Count - 1
                            lstOptions.Items.Add(sPieces(i).ToString)

                            If (sPieces(i).ToString = my_VBValue) Then
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

                        popupContainerControl1.Controls.Add(tl)

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


            vgMacro.BestFit()

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
                                    my_CValue = i - 4
                                End If
                            Next
                            arrOptions = PopulateComboListFromDat(lstOptions)

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                    my_DatVarName,
                                                                     my_DialogDisplay,
                                                                     my_VBValue,
                                                                     my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))

                        Case DB_MATLIST

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

                Case DB_COMBO, DB_USERVAR, DB_LEADSETUP
                    sValue = GetOptionIndex(sOptions, e.Value)

                Case DB_CRIB
                    sValue = FindModelIDFromToolDescrip(e.Value)

                Case DB_DBL
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetDouble("val", 0)

                        vgMacro.FocusedRow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If

                Case DB_INT
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetInt("val", 0)

                        vgMacro.FocusedRow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If

                Case DB_TOOL
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

    Private Sub vgMacro_CustomRecordCellEdit(sender As Object, e As GetCustomRowCellEditEventArgs) Handles vgMacro.CustomRecordCellEdit
        Dim nTemp As Integer

        Try
            'MessageBox.Show("The tool desc is < " & e.ToString & " >")

            If (e.Row.Tag IsNot Nothing) Then
                nTemp = CInt(GetValueFromDelimitedData(e.Row.Tag, "VarDataType", 0))

                Select Case nTemp
                    Case DB_FILE, DB_BATCH
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

    Private Sub rbPropSettings_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles rbPropSettings.ButtonClick
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
                Case DB_FILE, DB_BATCH
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

        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long
        Dim s_LayerSetup As String
        Dim n_LayerSetupID As Long

        Dim sOptions As String = sEmpty

        If edit IsNot Nothing Then
            AddHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
        End If
    End Sub

    Private Sub rbMaterials_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles rbMaterials.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")
    End Sub

    Private Sub frmRegUserEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        fcbMacroFilename.Properties.Tag = NormalizePath(Application.StartupPath) & "\Extras\RegEntry.dat"
        fcbMacroFilename.Text = NormalizePath(Application.StartupPath) & "\Extras\RegEntry.dat"

        Dim sline As String



        m_version = -1

            contents = New clsStringArray

            Using sr As StreamReader = New StreamReader(fcbMacroFilename.Text)

                sline = sr.ReadLine()

                While (sr.EndOfStream = False)
                    If (InStr(UCase(sline), "BEGIN_MACRO") > 0) Then

                        m_version = 17

                ElseIf (InStr(UCase(sline), "PUBLIC") > 0) Then

                        m_version = 16


                End If

                    If (m_version > 0) Then Exit While

                    lReturn = contents.Add(sline)

                    sline = sr.ReadLine()

                End While

                sr.Dispose()

            End Using

            If (FileExists(fcbMacroFilename.Text) = True) Then

            LoadVariables(fcbMacroFilename.Text, "glb")

        End If

    End Sub
End Class