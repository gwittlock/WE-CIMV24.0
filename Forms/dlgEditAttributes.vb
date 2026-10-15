Imports DevExpress.XtraVerticalGrid.Rows

Public Class dlgEditAttributes
    Private m_is_active As Boolean
    Private nAttribCount As Long
    Private nI As Integer
    Private sMyAttribName As String
    Private sMyAttribValue As String
    Private nMyAttribType As Long
    Private nPos As Integer
    Private Sub dlgEditAttributes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        m_is_active = False

        frmMain.CloseFirstPanel()

    End Sub

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function


    Private Sub dlgEditAttributes_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (SelectedCount() > 0) Then
            rgOptByGroup.SelectedIndex = 0

            GetAttributes()
        Else
            rgOptByGroup.SelectedIndex = 0

        End If

        m_is_active = True
        rgOptByGroup.Visible = False

    End Sub

    Sub GetAttributes()
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim indx As Long
        Dim sCutSide As String = "None"
        Dim sChoicesCutSide As New Collection

        vgEditAttributes.Rows.Clear()

        vgEditAttributes.SuspendLayout()

        currentCategoryRow = CreateCategoryRow(vgEditAttributes, "Attibutes", "Attributes", "Attributes", 0, "Attributes", DB_HEADER, 0, sEmpty, 0)

        lReturn = PortalExecute("*Attrib:Selected:Count:")

        nAttribCount = PortalGetInt("count", 0)

        For indx = 0 To nAttribCount - 1

            lReturn = PortalExecute("*Attrib:Selected:Get:indx=" & indx)

            my_DatVarName = PortalGetString("name", "")
            my_VBValue = PortalGetString("Value", "")

            nMyAttribType = PortalGetInt("type", 0)


            my_CVarName = my_DatVarName
            my_DataType = DB_STR
            my_DialogDisplay = my_DatVarName
            my_CValue = my_VBValue
            my_RecodID = 0
            my_sOptions = sEmpty


            If (UCase(my_DatVarName) = "COLOR") Then
                'CreateColorEditEditorRow

                currentCategoryRow.ChildRows.Add(CreateColorEditEditorRow(vgEditAttributes, "Color", "Color", my_RecodID, ColorTranslator.FromOle(my_CValue)))
            ElseIf (UCase(my_DatVarName) = "CUTSIDE") Then

                sChoicesCutSide.Clear()
                sChoicesCutSide.Add("None")
                sChoicesCutSide.Add("Left")
                sChoicesCutSide.Add("Right")


                Select Case my_CValue
                    Case -1 'Right
                        sCutSide = "Right"
                    Case 0 'None
                        sCutSide = "None"
                    Case 1 'Left
                        sCutSide = "Left"
                End Select


                currentCategoryRow.ChildRows.Add(CreateComboBoxEditorRow(vgEditAttributes, "Cut Side", "Cut Side", my_RecodID, sCutSide, sChoicesCutSide))
            Else

                currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgEditAttributes, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

            End If


            'FillAttributesGrid(sMyAttribName, sMyAttribValue, nMyAttribType)

        Next
        vgEditAttributes.ResumeLayout()

    End Sub

    Private Sub dlgEditAttributes_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        m_is_active = False
        frmMain.CloseFirstPanel()
    End Sub

    Private Sub teEntity_TextChanged(sender As Object, e As EventArgs) Handles teEntity.TextChanged
        Dim entityID As Long

        If (teEntity.Text <> sEmpty) Then

            lReturn = modSelection.DeselectAll()
            'curr_state = modSelector.GetSelectorState(SEL_APPLICATION)

            entityID = teEntity.Text
            modSelection.SetSelectionFilterByType(GetEntityType(entityID))

            lReturn = modSelection.SelectEntity(entityID)
            ' If (lReturn > 0) Then SynchronizeUI(modSelection.SelectedCount())

            GetAttributes()

        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim currentCategoryRow As CategoryRow
        Dim sAddAttribute As String

        sAddAttribute = InputBox("Enter New Attribute Name:", "New Attribute")

        Dim row As CategoryRow

        row = vgEditAttributes.Rows.LastVisible
        Dim nMytype = row.ChildRows.LastVisible.Tag

        my_DataType = GetValueFromDelimitedData(row.ChildRows.LastVisible.Tag, "AttType", 0)

        my_DatVarName = sAddAttribute
        my_CVarName = sAddAttribute
        my_DataType = DB_STR
        my_DialogDisplay = sAddAttribute
        my_VBValue = sEmpty
        my_CValue = sEmpty 'Also see the case statement for combobox
        my_RecodID = 0
        my_sOptions = sEmpty

        currentCategoryRow = vgEditAttributes.Rows.FirstVisible
        currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgEditAttributes, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        Dim sMyAttribName As String
        Dim sMyAttribValue As String = sEmpty
        Dim nMyAttribType As Long


        For Each row As CategoryRow In vgEditAttributes.Rows
            Dim childRows As VGridRows = row.ChildRows


            For Each childRow As EditorRow In childRows

                sMyAttribName = childRow.Properties.Caption

                If (UCase(sMyAttribName) = "COLOR") Then
                    sMyAttribValue = ColorTranslator.ToOle(childRow.Properties.Value)
                    nMyAttribType = GetValueFromDelimitedData(childRow.Tag, "AttType", 0)

                ElseIf ((UCase(sMyAttribName) = "CUTSIDE")) Then

                    Select Case UCase(childRow.Properties.Value)
                        Case "NONE"

                            sMyAttribValue = 0

                        Case "RIGHT"

                            sMyAttribValue = -1

                        Case "LEFT"

                            sMyAttribValue = 1

                    End Select
                    nMyAttribType = GetValueFromDelimitedData(childRow.Tag, "VarDataType", 0)
                Else
                    sMyAttribValue = childRow.Properties.Value
                    nMyAttribType = GetValueFromDelimitedData(childRow.Tag, "VarDataType", 0)
                End If



                lReturn = PortalExecute( _
                   "Attrib:Selected:Set:" & _
                   " name=" & QStr(sMyAttribName) & _
                   ",value=" & QStr(sMyAttribValue) & _
                   ",type=" & nMyAttribType)

            Next

        Next

    End Sub

    Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        Dim row As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim nRowIndex As Long

        row = vgEditAttributes.FocusedRow
        nRowIndex = vgEditAttributes.FocusedRow.Index

        lReturn = PortalExecute("Attrib:Selected:Delete:name=" & row.Properties.Caption)

        row.ParentRow.ChildRows.Remove(row)



    End Sub

End Class