Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList


Public Class frmMat_Test
    Inherits Form
    Private m_In_Edit_Mode As Boolean
    Private editValue As String
    Private m_is_active As Boolean
    Private nRowIndx As Integer
    Private nRowId As BaseRow
    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Private CFG_MATERIAL_NODE As TreeListNode
    Private WithEvents rbMaterials As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit

    Public Sub New()
        InitializeComponent()


        'Delimiters for formatting internal strings.
        CHR1 = Convert.ToChar(1)
        CHR2 = Convert.ToChar(2)

    End Sub

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function

    Dim oldcurrentCategoryRow As CategoryRow = Nothing
    Dim my_DatVarName As String
    Dim my_DialogDisplay As String
    Dim my_VBValue As String
    Dim my_CValue As String
    Dim my_CVarName As String
    Dim my_DataType As Integer
    Dim my_RecodID As Integer
    Dim my_sOptions As String
    Private fileName As String = ""
    Public CHR1 As String
    Public CHR2 As String




    'Private Sub buttonEdit1_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    Dim openFileDialog1 As New OpenFileDialog()


    '    openFileDialog1.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
    '    openFileDialog1.FilterIndex = 1
    '    openFileDialog1.RestoreDirectory = True

    '    If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        fileName = openFileDialog1.FileName
    '        'buttonEdit1.EditValue = fileName
    '    End If
    'End Sub

    Private Function CreateCategoryRow(ByRef mGridCtrl As DevExpress.XtraVerticalGrid.VGridControl,
                                     ByVal DatVarName As String,
                                            DialogDisplay As String,
                                            VBValue As String,
                                            CValue As String,
                                            CVArName As String,
                                            DataType As Integer,
                                            RecodID As Integer,
                                            sOptions As String,
                                            nDefnID As Integer) As CategoryRow

        Dim categoryRow As New CategoryRow(DialogDisplay)
        mGridCtrl.Rows.Add(categoryRow)

        categoryRow.OptionsRow.DblClickExpanding = False
        categoryRow.Tag = EncodeTag(DatVarName, DialogDisplay, VBValue, CValue, CVArName, DataType, RecodID, sOptions, nDefnID)


        Return categoryRow
    End Function
    Private Function oldCreateCategoryRow(ByVal rowCaption As String) As CategoryRow
        Dim categoryRow As New CategoryRow(rowCaption)
        vgSettingsProplist.Rows.Add(categoryRow)
        Return categoryRow
    End Function

    Private Function CreateStringEditorRow(ByVal rowCaption As String, ByVal rowValue As String) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row            
        editorRow.Properties.Caption = rowCaption
        editorRow.Properties.Value = rowValue
        Return editorRow
    End Function

    Private Function CreateBooleanEditorRow(ByVal rowCaption As String, ByVal rowValue As Integer) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = rowCaption
        editorRow.Properties.Value = If(rowValue = 1, True, False)
        Return editorRow
    End Function

    Private Function CreateIntegerEditorRow(ByVal rowCaption As String, ByVal rowValue As Integer) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = rowCaption
        editorRow.Properties.Value = rowValue

        Dim reSpinEdit As New RepositoryItemSpinEdit()
        reSpinEdit.IsFloatValue = False
        vgSettingsProplist.RepositoryItems.Add(reSpinEdit)
        editorRow.Properties.RowEdit = reSpinEdit
        Return editorRow
    End Function

    Private Function CreateDoubleEditorRow(ByVal rowCaption As String, ByVal rowValue As Double) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = rowCaption
        editorRow.Properties.Value = rowValue

        Dim reCalcEdit As New RepositoryItemCalcEdit()
        vgSettingsProplist.RepositoryItems.Add(reCalcEdit)
        editorRow.Properties.RowEdit = reCalcEdit
        Return editorRow
    End Function
    Public Function CreateComboBoxListEditorRow(ByRef mGridCtrl As DevExpress.XtraVerticalGrid.VGridControl,
                                                   ByVal DatVarName As String,
                                                   DialogDisplay As String,
                                                   VBValue As String,
                                                   CValue As String,
                                                   CVArName As String,
                                                   DataType As Integer,
                                                   RecodID As Integer,
                                                   Options As Collection) As EditorRow

        'ByVal rowCaption As String, _
        'ByVal sIname As String, _
        'ByVal nRecordID As Integer, _
        'ByVal rowValue As String, _
        'ByVal options As Collection) As EditorRow
        Dim sOptions As String = Nothing

        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = DialogDisplay
        editorRow.Properties.Value = VBValue


        Dim reComboBoxEdit As New RepositoryItemComboBox()
        reComboBoxEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        mGridCtrl.RepositoryItems.Add(reComboBoxEdit)
        editorRow.Properties.RowEdit = reComboBoxEdit

        For i As Integer = 1 To Options.Count
            Dim tempMachine As MachineListCombo = Options(i)
            reComboBoxEdit.Items.Add(tempMachine.Description)

            If (i = 1) Then
                sOptions = tempMachine.Description
            Else
                sOptions = sOptions & ";" & tempMachine.Description
            End If

        Next i

        editorRow.Tag = EncodeTag(DatVarName, DialogDisplay, VBValue, CValue, CVArName, DataType, RecodID, sOptions, 0)

        Return editorRow
    End Function

    Private Function CreateComboBoxEditorRow(ByVal stringArray() As String) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = stringArray(2)
        editorRow.Properties.Value = If(stringArray.Length > 3, stringArray(3), "")

        Dim reComboBoxEdit As New RepositoryItemComboBox()

        vgSettingsProplist.RepositoryItems.Add(reComboBoxEdit)
        editorRow.Properties.RowEdit = reComboBoxEdit
        For i As Integer = 4 To stringArray.Length - 1
            reComboBoxEdit.Items.Add(stringArray(i))
        Next i
        Return editorRow
    End Function


    Private Sub vGridControl1_ShownEditor(sender As Object, e As EventArgs) Handles vgSettingsProplist.ShownEditor
        'Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
        'If nRowId IsNot Nothing Then
        '    If vgSettingsProplist.FocusedRow Is nRowId Then
        '        edit.Properties.Items.Clear()
        '        edit.Properties.Items.Add(New ComboBoxItem(editValue))
        '        edit.Properties.Items.Add(New ComboBoxItem(editValue))
        '    End If
        'End If
        'If edit IsNot Nothing Then
        '    AddHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
        'End If
        Dim edit As ComboBoxEdit = TryCast(vgSettingsProplist.ActiveEditor, ComboBoxEdit)


        Dim indx As Integer
        Dim DB_TOOLSETUP As Integer = 8
        Dim DB_LAYERSETUP As Integer = 42
        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long
        Dim sDataType As Integer


        Dim sOptions As String = sEmpty
        sDataType = GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "VarDataType", 0)

        Try


            If (sDataType = DB_MATLIST) Then

                'edit.Properties.Items.Clear()

                'edit.Properties.Items.Clear()

                arrToolSetup = PopulateComboList("SELECT * FROM [Tool Setups] " &
                                                       "WHERE ([Machine ID]=" & m_machine_id & ") ORDER BY [Description]", False, False)

                For indx = 1 To arrToolSetup.Count

                    edit.Properties.Items.Add(New ComboBoxItem(arrToolSetup(indx).Description))

                    If (indx = 1) Then
                        sOptions = arrToolSetup(indx).Description
                    Else
                        sOptions = sOptions & ";" & arrToolSetup(indx).Description
                    End If

                Next


                If (arrToolSetup.Count > 0) Then
                    s_ToolSetup = arrToolSetup(1).description

                    n_ToolSetupID = GetToolSetupIDFromDescription(s_ToolSetup)

                    edit.EditValue = s_ToolSetup

                    edit.Properties.Tag = EncodeTag("toolsetup",
                                                                 "Tool Setup",
                                                                 s_ToolSetup,
                                                                 n_ToolSetupID,
                                                                 "Tool Setup ID",
                                                                 DB_TOOLSETUP,
                                                                 0,
                                                                 sOptions, 0)
                End If
            End If


            If edit IsNot Nothing Then
                AddHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub edit_EditValueChanged(sender As Object, e As EventArgs)
        Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)


        nRowId = GetRowByCaption("Tool Setup")

        editValue = edit.EditValue.ToString()

        nRowIndx = nRowId.Index


        vgSettingsProplist.FocusedRow = vgSettingsProplist.Rows(nRowId.ParentRow.Index).ChildRows(nRowId.Index)
        vgSettingsProplist.ShowEditor()
    End Sub


    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vgSettingsProplist.Rows
            r = GetRowByCaptionChild(row, s)
            If Not r Is Nothing Then
                Return r
            End If
        Next row
        Return Nothing
    End Function

    Private Function GetRowByCaptionChild(ByVal row As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
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
        Return Nothing
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String

        'CreateMaterialTypeNodes(tl)


        popupContainerControl1.Controls.Add(tl)

        ' Used rbMaterials as the editor for Material record cell
        ' rbMaterials = New RepositoryItemPopupContainerEdit()
        'rbMaterials.Name = "rbMaterials"
        'rbMaterials.PopupControl = popupContainerControl1
        'AddHandler rbMaterials.QueryDisplayText, AddressOf rbMaterials_QueryDisplayText

        'vgSettingsProplist.RepositoryItems.Add(rbMaterials)
        'populateFromDatFile(vGridControl1, "C:\Users\gwitt\OneDrive\Pictures\WindowsFormsApplication1_Modified\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\editproject.dat", currentCategoryRow, lbOptions)

        m_sncs = 2021

        sql = "SELECT * FROM ModifyVar WHERE (ModifyID=" & m_sncs & ") Order By ModifyVar.ID"

        'populateFromAppDB(vgSettingsProplist, PathAppDB(), sql, currentCategoryRow, lbOptions)
        PopulateFromMacro()

        GetProjectInfo()

        'vgSettingsProplist.Rows("categoryMaterial").ChildRows(0).Properties.RowEdit = rbMaterials
    End Sub
    Private Sub PopulateFromMacro()
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
        Dim sPieces() As String
        Dim sClass As String = "mac"
        Dim sMacroName As String = "C:\Program Files (x86)\WE-CIM\23.0\Macros\HideHoles.java"


        Try

            vgSettingsProplist.Rows.Clear()

            currentCategoryRow = CreateCategoryRow(vgSettingsProplist, "Variables", "Variables", "Variables", 0, "MACVAR", DB_HEADER, 0, sEmpty, 0)

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
                        currentCategoryRow = CreateCategoryRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)
                        'currentCategoryRow = CreateCategoryRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)

                    Case DB_STR
                        'currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                    Case DB_BOOL
                        'currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_INT
                       ' currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_DBL
                        'currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                    Case DB_FILE

                        'currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgSettingsProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                    Case DB_MATLIST

                End Select


            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub rbMaterials_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles rbMaterials.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")

    End Sub

    Private Sub popupContainerEdit1_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles popupContainerEdit1.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")

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

        sql = "Select [Mat_Sizes].* From [Mat_Sizes]"

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


    Private Function GetProjectInfo() As Long
        Dim toolSetupName As String
        Dim materialName As String
        Dim machineID As Long
        Dim smachineName As String
        Dim ToolSetupID As Long
        Dim materialID As Long
        Dim my_Value
        Try

            toolSetupName = HeaderStringGet("MachCfg", "")

            materialName = HeaderStringGet("MatCfg", "")

            machineID = modTranslate.GetMachineID(toolSetupName)
            smachineName = GetMachineDescription(machineID)
            ToolSetupID = modTranslate.GetToolSetupIDFromDescription(toolSetupName)
            materialID = modTranslate.GetMaterialIDFromDescription(materialName)

            my_Value = Nothing


            For Each row As CategoryRow In vgSettingsProplist.Rows

                If (row.Properties.Caption = "Tool Setup") Then
                    row.Properties.Caption = "Tool_Setup"
                End If

                For Each childRow As EditorRow In row.ChildRows

                    Select Case UCase(childRow.Properties.Caption)

                        Case "MACHINE"
                            my_Value = smachineName

                        Case "TOOL SETUP"
                            my_Value = toolSetupName

                        Case "UPDATE TOOLING"
                            my_Value = True

                        Case "CUSTOMER"
                            my_Value = HeaderStringGet("customer", "")

                        Case "ORDER OR P/O #"
                            my_Value = HeaderStringGet("PoNum", "")

                        Case "DUE DATE"
                            my_Value = HeaderStringGet("DueDate", "")

                        Case "MATERIAL TYPE"
                            my_Value = materialName

                        Case "MATERIAL LENGTH"
                            my_Value = Round(HeaderDoubleGet("Length", 0), Places.Thousandths, True)

                        Case "MATERIAL WIDTH"
                            my_Value = Round(HeaderDoubleGet("Width", 0), Places.Thousandths, True)

                        Case "MATERIAL THICKNESS"
                            my_Value = Round(HeaderDoubleGet("thickness", 0), Places.Thousandths, True)


                    End Select

                    vgSettingsProplist.BeginDataUpdate()
                    childRow.Properties.Value = my_Value
                    vgSettingsProplist.EndDataUpdate()

                Next childRow

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

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
                    'popupContainerEdit1.EditValue = sCurr_Display ' e.Node.ParentNode.GetDisplayText(tl.Columns(1))
                    'popupContainerEdit1.Tag = e.Node.Tag

                    'popupContainerEdit1.ClosePopup()
                End If
            End If

        Catch ex As Exception

            MessageBox.Show("tl_FocusedNodeChanged: " & ex.Message)

        End Try

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.vgSettingsProplist.FocusFirst()



        SetTheAccumulator()

        lReturn = modEdit.Execute(2021, GetAccumulator)
        Set_In_Edit_Mode(False)
        modView.ViewRegen()


    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False
        frmMain.CloseFirstPanel()
        modView.ViewResize()
    End Sub

    Private Sub SetTheAccumulator()

        Dim iname As String
        Dim sOptions As String
        Dim nVarType As Integer
        Dim sValue As String = Nothing

        Try

            For Each row As CategoryRow In vgSettingsProplist.Rows
                Dim childRows As VGridRows = row.ChildRows

                For Each childRow As EditorRow In childRows

                    nVarType = CInt(GetValueFromDelimitedData(childRow.Tag, "VarDataType", ""))
                    iname = GetValueFromDelimitedData(childRow.Tag, "DatVarName", "")

                    sOptions = GetValueFromDelimitedData(childRow.Tag, "Options", "")

                    Dim sDatVarName As String

                    sDatVarName = GetValueFromDelimitedData(childRow.Tag, "DatVarName", "")

                    Select Case nVarType
                        Case DB_DIR
                            sValue = GetOptionIndex(sOptions, childRow.Properties.Value)

                        Case DB_MACHINE
                            sValue = GetMachineIDFromDescrip(childRow.Properties.Value)

                        Case DB_TOOLSETUP
                            sValue = GetToolSetupIDFromDescription(childRow.Properties.Value)

                        Case DB_COMBO, DB_USERVAR
                            sValue = GetOptionIndex(sOptions, childRow.Properties.Value)

                        Case DB_CRIB

                            sValue = FindModelIDFromToolDescrip(childRow.Properties.Value)
                            g_clsActiveToolData = FindToolByModelID(CLng(sValue))
                            Name = GetEntityName(CLng(sValue))

                            If (sValue > 0) Then
                                SetActiveLayer(Name, g_clsActiveToolData.TlColor)
                            End If
                        Case DB_LEADSETUP
                            sValue = modTranslate.GetLeadSetupID(childRow.Properties.Value)

                        Case DB_MATERIAL
                            sValue = modTranslate.GetMaterialIDFromDescription(childRow.Properties.Value)


                        Case DB_DBL
                            If (PortalExecute("*solve:eval:exp=" & QStr(childRow.Properties.Value)) > 0) Then

                                sValue = PortalGetDouble("val", 0)

                                childRow.Properties.Value = Round(sValue, Places.Millionths)

                            End If

                        Case DB_INT
                            If (PortalExecute("*solve:eval:exp=" & QStr(childRow.Properties.Value)) > 0) Then

                                sValue = PortalGetInt("val", 0)

                                childRow.Properties.Value = sValue

                            End If

                        Case Else
                            sValue = childRow.Properties.Value

                    End Select

                    lReturn = UpdateAccumulatorDirect(vgSettingsProplist, iname, sValue)
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Public Function Set_In_Edit_Mode(Mode As Boolean) As Long
        m_In_Edit_Mode = Mode
    End Function

    Private Sub vgSettingsProplist_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgSettingsProplist.CellValueChanging
        Dim sDatVarName As String
        Dim nMatID As Long
        Dim sDataType As Integer
        Dim edit As ComboBoxEdit = TryCast(vgSettingsProplist.ActiveEditor, ComboBoxEdit)
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

                Dim childRows As VGridRows = vgSettingsProplist.FocusedRow.ParentRow.ChildRows


                For Each childRow As EditorRow In vgSettingsProplist.FocusedRow.ParentRow.ChildRows

                    sDatVarName = GetValueFromDelimitedData(childRow.Tag, "DatVarName", "")
                    Select Case UCase(sDatVarName)
                        Case "MAT_LEN"
                            childRow.Properties.Value = modMaterial.GetMaterialLength(nMatID)

                        Case "MAT_WID"
                            childRow.Properties.Value = modMaterial.GetMaterialWidth(nMatID)

                        Case "MAT_THICK"
                            childRow.Properties.Value = modMaterial.GetMaterialThickness(nMatID)

                    End Select

                Next


        End Select
        'If (e.Row.Properties.Caption = "Material Type") Then

        '    nMatID = modTranslate.GetMaterialIDFromDescription(e.Value)

        '    Dim childRows As VGridRows = vgSettingsProplist.FocusedRow.ParentRow.ChildRows


        '    For Each childRow As EditorRow In vgSettingsProplist.FocusedRow.ParentRow.ChildRows

        '        sDatVarName = GetValueFromDelimitedData(childRow.Tag, "DatVarName", "")
        '        Select Case UCase(sDatVarName)
        '            Case "MAT_LEN"
        '                childRow.Properties.Value = modMaterial.GetMaterialLength(nMatID)

        '            Case "MAT_WID"
        '                childRow.Properties.Value = modMaterial.GetMaterialWidth(nMatID)

        '            Case "MAT_THICK"
        '                childRow.Properties.Value = modMaterial.GetMaterialThickness(nMatID)

        '        End Select

        '    Next

        'End If
    End Sub

End Class


