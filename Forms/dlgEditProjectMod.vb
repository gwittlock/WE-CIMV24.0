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


Public Class dlgEditProjectMod

    Dim currentCategoryRow As CategoryRow = Nothing
    Dim my_DatVarName As String
    Dim my_DialogDisplay As String
    Dim my_VBValue As String
    Dim my_CValue As String
    Dim my_CVarName As String
    Dim my_DataType As Integer
    Dim my_RecodID As Integer
    Dim my_sOptions As String
    Private fileName As String = ""

    Private m_In_Edit_Mode As Boolean
    Private editValue As String
    Private nRowIndx As Integer
    Private nRowId As BaseRow

    Private nToolSetupRowId As BaseRow
    Private SelectedMachineName As String
    Private SelectedToolSetupName As String

    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Private CFG_MATERIAL_NODE As TreeListNode

    Private m_is_active As Boolean

    Public WithEvents rbMaterialSettings As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function


    Private Sub vgSettingsProplist_ShownEditor(sender As Object, e As EventArgs) Handles vgSettingsProplist.ShownEditor
        Dim edit As ComboBoxEdit = TryCast(vgSettingsProplist.ActiveEditor, ComboBoxEdit)
        Dim DB_TOOLSETUP As Integer = 8
        Dim DB_LAYERSETUP As Integer = 42
        Dim sOptions As String = sEmpty


        Try

            If nRowId IsNot Nothing Then
                If vgSettingsProplist.FocusedRow Is nRowId Then
                    edit.Properties.Items.Clear()
                    edit.Properties.Items.Add(New ComboBoxItem(editValue))
                    edit.Properties.Items.Add(New ComboBoxItem(editValue))
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

        nToolSetupRowId = Nothing


        Try
            editValue = edit.EditValue.ToString()

            If (vgSettingsProplist.FocusedRow.Properties.Caption = "Machine") Then

                SelectedMachineName = edit.EditValue.ToString()
                m_machine_id = GetMachineIDFromDescrip(SelectedMachineName)

                nToolSetupRowId = GetRowByCaption("Tool Setup")

                If (IsNothing(nToolSetupRowId) = False) Then
                    nRowIndx = nToolSetupRowId.Index


                    vgSettingsProplist.FocusedRow = vgSettingsProplist.Rows(nToolSetupRowId.ParentRow.Index).ChildRows(nToolSetupRowId.Index)
                    vgSettingsProplist.FocusedRow.Properties.Value = ""
                    vgSettingsProplist.ShowEditor()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        'nToolSetupRowId = Nothing

        'editValue = edit.EditValue.ToString()

        'nVarType = CInt(GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "VarDataType", 0))


        'If (vgSettingsProplist.FocusedRow.Properties.Caption = "Machine") Then

        '    SelectedMachineName = edit.EditValue.ToString()
        '    m_machine_id = GetMachineIDFromDescrip(SelectedMachineName)


        '    nToolSetupRowId = GetRowByCaption("Tool Setup")

        '    If (IsNothing(nToolSetupRowId) = False) Then
        '        nRowIndx = nToolSetupRowId.Index


        '        vgSettingsProplist.FocusedRow = vgSettingsProplist.Rows(nRowIndx)
        '        vgSettingsProplist.FocusedRow.Properties.Value = ""
        '        vgSettingsProplist.ShowEditor()
        '    End If
        'End If

        'If (vgSettingsProplist.FocusedRow.Properties.Caption = "Material Type") Then
        '    my_Cvalue = GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "CValue", "")

        '    nMaterialID = CLng(GetMaterialIDFromDescription(edit.EditValue))

        '    childrow = GetRowByCaption("Material Length")

        '    vgSettingsProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = modMaterial.GetMaterialLength(CLng(nMaterialID))
        '    m_accumulator.mat_len = CDbl(modMaterial.GetMaterialLength(CLng(nMaterialID)))

        '    childrow = GetRowByCaption("Material Width")
        '    vgSettingsProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = modMaterial.GetMaterialWidth(CLng(nMaterialID))
        '    m_accumulator.mat_wid = CDbl(modMaterial.GetMaterialWidth(CLng(nMaterialID)))

        '    childrow = GetRowByCaption("Material thickness")
        '    vgSettingsProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = modMaterial.GetMaterialThickness(CLng(nMaterialID))
        '    m_accumulator.mat_thick = CDbl(modMaterial.GetMaterialThickness(CLng(nMaterialID)))

        'End If

        'my_DefnID = GetValueFromDelimitedData(vgSettingsProplist.FocusedRow.Tag, "DefnID", 0)

        'If (my_DefnID > 0 And nVarType = DB_USERVAR) Then


        '    lReturn = GetPropsForUserVar(vgSettingsProplist, vgSettingsProplist.FocusedRow, edit.SelectedIndex, my_DefnID)
        '    vgSettingsProplist.FocusedRow.Properties.Value = editValue
        '    m_accumulator.soln_Set(5, edit.SelectedIndex)

        'End If


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub



    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Try
            For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vgSettingsProplist.Rows
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

    Private Sub dlgEditProject_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String

        CreateMaterialTypeNodes(tl)


        popupContainerControl1.Controls.Add(tl)
        ' Used rbMaterials as the editor for Material record cell
        rbMaterialSettings = New RepositoryItemPopupContainerEdit()
        rbMaterialSettings.Name = "rbMaterials"
        rbMaterialSettings.PopupControl = popupContainerControl1
        AddHandler rbMaterialSettings.QueryDisplayText, AddressOf rbMaterialSettings_QueryDisplayText

        vgSettingsProplist.RepositoryItems.Add(rbMaterialSettings)

        'populateFromDatFile(vGridControl1, Application.StartupPath & "\EditProject.dat", currentCategoryRow, lbOptions)

        m_sncs = 2021

        sql = "SELECT * FROM ModifyVar WHERE (ModifyID=" & m_sncs & ") Order By ModifyVar.ID"

        populateFromAppDB(vgSettingsProplist, PathAppDB(), sql, currentCategoryRow, lbOptions)

        GetProjectInfo()


        vgSettingsProplist.Rows("categoryMaterial").ChildRows(0).Properties.RowEdit = rbMaterialSettings
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

        sql = "Select [Material Types].* From [Material Types]"

        Try

            dtMaterialType = ConnectToCMDB(sql)


            For i = 0 To dtMaterialType.Rows.Count - 1
                s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")

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

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Me.vgSettingsProplist.FocusFirst()

        SetTheAccumulator()

        lReturn = modEdit.Execute(2021, GetAccumulator)
        Set_In_Edit_Mode(False)
        modView.ViewRegen()
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

                    'childRow = GetRowByCaptionChild(vgProplist.FocusedRow, vgProplist.FocusedRow.Properties.Caption)

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

    Public Sub rbMaterialSettings_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles rbMaterialSettings.QueryDisplayText

        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")
    End Sub

    Private Sub dlgEditProject_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False
        frmMain.CloseFirstPanel()
        modView.ViewResize()
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

    Private Sub dlgEditProject_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Me.Width = PanelControl.p
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
                    'popupContainerEdit1.EditValue = sCurr_Display ' e.Node.ParentNode.GetDisplayText(tl.Columns(1))
                    'popupContainerEdit1.Tag = e.Node.Tag

                    'popupContainerEdit1.ClosePopup()
                End If
            End If

        Catch ex As Exception

            MessageBox.Show("tl_FocusedNodeChanged: " & ex.Message)

        End Try


    End Sub


End Class