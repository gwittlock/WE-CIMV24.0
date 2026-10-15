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
Imports Microsoft.Win32
Public Class frmRegDataUserNew
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
    Private sSubKeyString As String
    Private sDatVarName As String
    Private nChildType As Integer
    Private nSubKeyRow As BaseRow
    Private nRowIndx As Integer
    Private nSubKeyValueRow As BaseRow

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

        Try
            nSubKeyRow = Nothing
            editValue = edit.EditValue.ToString()

            If (vgMacro.FocusedRow.Properties.Caption = "Main Key") Then

                nSubKeyRow = GetRowByCaption("Sub Keys")

                If (IsNothing(nSubKeyRow) = False) Then
                    nRowIndx = nSubKeyRow.Index

                    vgMacro.FocusedRow = vgMacro.Rows(nSubKeyRow.ParentRow.Index).ChildRows(nSubKeyRow.Index)
                    vgMacro.FocusedRow.Properties.Value = ""
                    'vgMacro.ShowEditor()
                End If

            ElseIf vgMacro.FocusedRow.Properties.Caption = "Sub Key" Then

                nSubKeyValueRow = GetRowByCaption("Key Values")

                If (IsNothing(nSubKeyValueRow) = False) Then
                    nRowIndx = nSubKeyValueRow.Index

                    vgMacro.FocusedRow = vgMacro.Rows(nSubKeyRow.ParentRow.Index).ChildRows(nSubKeyValueRow.Index)
                    vgMacro.FocusedRow.Properties.Value = ""
                End If
            End If

            vgMacro.ShowEditor()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        Dim nTempRow As BaseRow
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

                        Case DB_MAINKEY

                            lstOptions.Items.Clear()

                            'lstOptions.Items.Add("<None>")

                            Dim instance As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\WE-CIM\22.0")

                            For Each s As String In instance.GetSubKeyNames()
                                lstOptions.Items.Add(s)
                            Next

                            arrOptions = PopulateComboListFromDat(lstOptions)

                            my_VBValue = lstOptions.Items(0).ToString
                            my_CVarName = lstOptions.Items(0).ToString
                            sSubKeyString = my_VBValue

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                    my_DatVarName,
                                                                     my_DialogDisplay,
                                                                     my_VBValue,
                                                                     my_CValue,
                                                                     my_CVarName,
                                                                     my_DataType,
                                                                     my_RecodID,
                                                                     arrOptions, 0))


                        Case DB_SUBKEY
                            'nTempRow = GetRowByCaption("Main Key")
                            'Dim sSubKeyVale As String = nTempRow.Properties.Value

                            lstOptions.Items.Clear()

                            'lstOptions.Items.Add("<None>")

                            Dim instance As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\WE-CIM\22.0\" & sSubKeyString)

                            'If (instance.GetSubKeyNames().Count > 0) Then
                            For Each s As String In instance.GetSubKeyNames()

                                lstOptions.Items.Add(s)

                            Next
                            'End If

                            arrOptions = PopulateComboListFromDat(lstOptions)
                            If (lstOptions.Items.Count > 0) Then
                                my_VBValue = lstOptions.Items(0).ToString
                                my_CVarName = lstOptions.Items(0).ToString
                            Else
                                my_VBValue = ""
                                my_CVarName = ""
                            End If


                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                    my_DatVarName,
                                                                     my_DialogDisplay,
                                                                     my_VBValue,
                                                                     my_CValue,
                                                                     my_CVarName,
                                                                     my_DataType,
                                                                     my_RecodID,
                                                                     arrOptions, 0))

                        Case DB_KeyValue

                            lstOptions.Items.Clear()

                            Dim key As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\WE-CIM\22.0\" & sSubKeyString)
                            If (key IsNot Nothing) Then
                                For Each ValueName In key.GetValueNames
                                    Debug.WriteLine(key.GetValue(ValueName))

                                Next
                            End If

                            arrOptions = PopulateComboListFromDat(lstOptions)
                            If (lstOptions.Items.Count > 0) Then
                                my_VBValue = lstOptions.Items(0).ToString
                                my_CVarName = lstOptions.Items(0).ToString
                            Else
                                my_VBValue = ""
                                my_CVarName = ""
                            End If


                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgMacro,
                                                                    my_DatVarName,
                                                                     my_DialogDisplay,
                                                                     my_VBValue,
                                                                     my_CValue,
                                                                     my_CVarName,
                                                                     my_DataType,
                                                                     my_RecodID,
                                                                     arrOptions, 0))


                    End Select

                End If

            Next

        Catch ex As Exception
            MessageBox.Show("LoadVersion17Variables: " & ex.Message)
        End Try


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

    Private Sub rbMaterials_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles rbMaterials.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")
    End Sub


    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Try
            For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vgMacro.Rows
                r = GetRowByCaptionChild(row, s)
                If Not r Is Nothing Then
                    Return r
                End If
            Next row
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return Nothing
    End Function

    Private Function GetRowByCaptionChild(ByVal row As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Try
            If row.Properties.Caption = s Then
                Return row
            End If
            Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
            For Each cRow As DevExpress.XtraVerticalGrid.Rows.BaseRow In row.ChildRows
                r = GetRowByCaptionChild(cRow, s)
                If Not r Is Nothing Then
                    Return r
                End If
            Next cRow
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return Nothing
    End Function

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

End Class