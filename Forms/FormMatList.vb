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



Public Class FormMatList
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

    Public Sub New()
        InitializeComponent()


        'Delimiters for formatting internal strings.
        CHR1 = Convert.ToChar(1)
        CHR2 = Convert.ToChar(2)

    End Sub

    Private Sub buttonEdit1_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim openFileDialog1 As New OpenFileDialog()


        openFileDialog1.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            fileName = openFileDialog1.FileName
            'buttonEdit1.EditValue = fileName
        End If
    End Sub

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
        vGridControl1.RepositoryItems.Add(reSpinEdit)
        editorRow.Properties.RowEdit = reSpinEdit
        Return editorRow
    End Function

    Private Function CreateDoubleEditorRow(ByVal rowCaption As String, ByVal rowValue As Double) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = rowCaption
        editorRow.Properties.Value = rowValue

        Dim reCalcEdit As New RepositoryItemCalcEdit()
        vGridControl1.RepositoryItems.Add(reCalcEdit)
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

        editorRow.Tag = EncodeTag(DatVarName, DialogDisplay, VBValue, CValue, CVArName, DataType, RecodID, sOptions)

        Return editorRow
    End Function

    Private Function CreateComboBoxEditorRow(ByVal stringArray() As String) As EditorRow
        Dim editorRow As New EditorRow()
        ' assigning the name and caption to the created editor row
        editorRow.Properties.Caption = stringArray(2)
        editorRow.Properties.Value = If(stringArray.Length > 3, stringArray(3), "")

        Dim reComboBoxEdit As New RepositoryItemComboBox()

        vGridControl1.RepositoryItems.Add(reComboBoxEdit)
        editorRow.Properties.RowEdit = reComboBoxEdit
        For i As Integer = 4 To stringArray.Length - 1
            reComboBoxEdit.Items.Add(stringArray(i))
        Next i
        Return editorRow
    End Function


    Public Function EncodeTag(DatVarname As String,
                           DialogDisplay As String,
                           VBValue As String,
                           CValue As String,
                           CVarName As String,
                           VarDataType As Integer,
                           nRecordID As Integer,
                           sOptions As String) As String

        EncodeTag = CHR1 & "DatVarName" & CHR2 & DatVarname &
                        CHR1 & "DialogDisplay" & CHR2 & DialogDisplay &
                        CHR1 & "VBValue" & CHR2 & VBValue &
                        CHR1 & "CValue" & CHR2 & CValue &
                        CHR1 & "CVarName" & CHR2 & CVarName &
                        CHR1 & "VarDataType" & CHR2 & VarDataType &
                        CHR1 & "nRecordID" & CHR2 & nRecordID &
                        CHR1 & "Options" & CHR2 & sOptions


    End Function

    Private Sub vGridControl1_ShownEditor(sender As Object, e As EventArgs) Handles vGridControl1.ShownEditor
        Dim edit As ComboBoxEdit = TryCast(vGridControl1.ActiveEditor, ComboBoxEdit)
        Dim DB_TOOLSETUP As Integer = 8
        Dim DB_LAYERSETUP As Integer = 42
        Dim sOptions As String = sEmpty


        Try

            If nRowId IsNot Nothing Then
                If vGridControl1.FocusedRow Is nRowId Then
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


        nRowId = GetRowByCaption("Tool Setup")

        editValue = edit.EditValue.ToString()

        nRowIndx = nRowId.Index


        vGridControl1.FocusedRow = vGridControl1.Rows(nRowId.ParentRow.Index).ChildRows(nRowId.Index)
        vGridControl1.ShowEditor()
    End Sub


    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vGridControl1.Rows
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
        CreateMaterialTypeNodes(tl)


        popupContainerControl1.Controls.Add(tl)
        ' Used rbMaterialSettings as the editor for Material record cell
        rbMaterialSettings = New RepositoryItemPopupContainerEdit()
        rbMaterialSettings.Name = "rbMaterialSettings"
        rbMaterialSettings.PopupControl = popupContainerControl1
        AddHandler rbMaterialSettings.QueryDisplayText, AddressOf rbMaterialSettings_QueryDisplayText

        vGridControl1.RepositoryItems.Add(rbMaterialSettings)


        vGridControl1.RepositoryItems.Add(rbMaterialSettings)
        populateFromMacro(vGridControl1, "C:\Program Files (x86)\WE-CIM\22.0\Macros\MatListTest.java", currentCategoryRow, lbOptions)

        ' vGridControl1.Rows("categoryMaterial_Inventory").ChildRows(0).Properties.RowEdit = rbMaterialSettings
    End Sub


    Private Sub popupContainerEdit1_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles popupContainerEdit1.QueryDisplayText
        'e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")

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

    Private Sub tl_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tl.FocusedNodeChanged
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

    Public Sub populateFromMacro(vgProplist As DevExpress.XtraVerticalGrid.VGridControl, datfilename As String, currentCategoryRow As CategoryRow, OptionsListbox As DevExpress.XtraEditors.ListBoxControl)
        Dim tempstring As String = String.Empty
        Dim lCount As Integer = -1
        Dim sData As String
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim sql As String
        Dim sClass As String = "mac"
        Dim sMacroName As String = "C:\Program Files (x86)\WE-CIM\22.0\Macros\MatListTest.java"


        If datfilename = String.Empty Then
            Return
        End If

        vGridControl1.Rows.Clear()


        currentCategoryRow = CreateCategoryRow(vGridControl1, "Variables", "Variables", "Variables", 0, "MACVAR", DB_HEADER, 0, sEmpty, 0)

        lReturn = PortalExecute("admin:javavarsextract:" &
           " file=" & QStr(sMacroName) & ",class=" & QStr(sClass))

        lCount = PortalGetInt("count", 0)

        For nCounter = 1 To lCount
            lReturn = PortalExecute("*admin:javavarget:index=" & nCounter - 1)

            sData = PortalGetString("data", "")

            ' parse out the data
            SplitVariableData(sData)
        Next


        Using file = System.IO.File.OpenText(datfilename)
            ' read file                
            'Dim currentCategoryRow As CategoryRow = Nothing

            Do While Not file.EndOfStream
                Dim currentLine As String = file.ReadLine()

                If InStr(currentLine, "//") = 0 Then
                    Exit Do
                End If
                currentLine = currentLine.Replace("//", "")
                currentLine = currentLine.Replace(" | ", "|")


                If (InStr(currentLine, "=") > 0) Then
                    tempstring = Mid(currentLine, InStrRev(currentLine, "=") + 2)

                    currentLine = "mac." & tempstring & "|Category|" & tempstring & "||"

                End If


                If currentLine.Trim() <> "" Then
                    Dim lineValues() As String = currentLine.Split(New String() {"|"}, StringSplitOptions.None)

                    my_DatVarName = lineValues(0)
                    my_DataType = ConvertDatTypeToDBType(lineValues(1))
                    my_DialogDisplay = Trim(lineValues(2))

                    If (lineValues.Count > 3) Then

                        my_VBValue = Trim(lineValues(3))
                        my_CValue = Trim(lineValues(3))

                    Else

                        my_VBValue = sEmpty
                        my_CValue = sEmpty

                    End If

                    my_CVarName = Replace(lineValues(0), "mac.", "")
                    my_RecodID = 0
                    my_sOptions = sEmpty

                    Select Case (my_DataType)

                        Case DB_HEADER
                            currentCategoryRow = CreateCategoryRow(vGridControl1, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, DB_HEADER, my_RecodID, my_sOptions, 0)

                        Case DB_STR
                           ' currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                        Case DB_BOOL
                            'currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_INT
                            'currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_DBL
                            'currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_CRIB
                            MessageBox.Show("We should have loaded the tools")
                        Case DB_TOOL
                            'Dim nToolSetupID As Long = RegGetString("Global", "ToolSetupID", 0)


                            '' my_CValue = 0
                            ''my_VBValue = "None"
                            ''my_RecodID = 0

                            'sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" &
                            '    " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " &
                            '    "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " &
                            '    "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" &
                            '    " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & nToolSetupID & "))" &
                            '    " ORDER BY [Station Configuration].[NC Code Number]"

                            Dim i As Integer

                            OptionsListbox.Items.Clear()

                            For i = 4 To lineValues.Count - 1
                                OptionsListbox.Items.Add(lineValues(i).ToString)

                                If (lineValues(i).ToString = my_VBValue) Then
                                    my_CValue = i - 4
                                End If
                            Next

                            'arrTools = PopulateComboList(sql, False, True)

                            'currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgProplist,
                            '                                        my_DatVarName,
                            '                                        my_DialogDisplay,
                            '                                        my_VBValue,
                            '                                        my_CValue,
                            '                                        my_CVarName,
                            '                                        my_DataType,
                            '                                        my_RecodID,
                            '                                        arrTools, 0))


                        Case DB_DCOMBO
                            Dim i As Integer

                            OptionsListbox.Items.Clear()

                            For i = 4 To lineValues.Count - 1
                                OptionsListbox.Items.Add(lineValues(i).ToString)

                                If (lineValues(i).ToString = my_VBValue) Then
                                    my_CValue = i - 4
                                End If
                            Next
                            arrOptions = PopulateComboListFromDat(OptionsListbox)

                            'currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgProplist,
                            '                                        my_DatVarName,
                            '                                         my_DialogDisplay,
                            '                                         my_VBValue,
                            '                                         my_CValue,
                            '                                         my_CVarName,
                            '                                         my_DataType,
                            '                                         my_RecodID,
                            '                                         arrOptions, 0))

                        Case DB_MATLIST
                            'MessageBox.Show("We found matlist")
                            currentCategoryRow.ChildRows.Add(CreateMatListEditorRow(vGridControl1, Me, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                    End Select

                End If
            Loop

        End Using

    End Sub

    Public Sub rbMaterialSettings_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles rbMaterialSettings.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")
    End Sub
End Class