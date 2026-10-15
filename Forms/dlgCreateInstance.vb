Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.Data.OleDb

Public Class dlgCreateInstance
    Implements IDialogMouseUp

    Private nRowIndx As Integer
    Private m_datlines() As String
    Private m_sub_item_sncs As Long
    Private editValue As String
    Private m_entity_id As Long
    Private m_In_Edit_Mode As Boolean
    Private m_prev_selection_filter As Long
    Private m_hot_dot_state As Boolean
    Private WithEvents rbPropSettings As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private m_is_active As Boolean
    Private nToolSetupRowId As BaseRow
    Private SelectedMachineName As String
    Private SelectedToolSetupName As String

    Delegate Sub FocusTextHandler(ByRef VerticalGrid)
    Private Sub FocusText(ByRef TheVerticalGrid)
        If TypeOf TheVerticalGrid.ActiveEditor Is TextEdit Then
            Dim edit As TextEdit = TryCast(TheVerticalGrid.ActiveEditor, TextEdit)
            edit.SelectionStart = 0
            edit.SelectionLength = (CStr(edit.EditValue)).Length

        End If
    End Sub
    Private Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp
        Dim pick_info As clsPickInfo

        Try
            If (vgProplist.FocusedRow IsNot Nothing) Then

                modEdit.RevertProfile()

                pick_info = modPick.GetPickInfo()

                If (pick_info IsNot Nothing) Then
                    UpdateAccumulatorPickInfo(vgProplist, pick_info)
                End If

                ClientMouseUp = 1

                Dim nChildRowCount As Integer

                'determine row
                Dim row As BaseRow = vgProplist.FocusedRow

                If TypeOf row Is CategoryRow Then

                    Dim operation As New MoveToNextCategoryOperation(vgProplist)
                    vgProplist.RowsIterator.DoOperation(operation)
                    vgProplist.Focus()

                    If (operation.NextCategory IsNot Nothing) Then
                        vgProplist.FocusedRow = operation.NextCategory
                        vgProplist.LayoutChanged()
                    Else
                        vgProplist.FocusedRow = vgProplist.Rows(0)
                        vgProplist.LayoutChanged()
                    End If

                End If

                If TypeOf row Is EditorRow Then


                    nChildRowCount = row.ParentRow.ChildRows.Count - 1

                    If (row.Index = nChildRowCount) Then
                        Dim operation As New MoveToNextCategoryOperation(vgProplist)
                        vgProplist.RowsIterator.DoOperation(operation)
                        vgProplist.Focus()

                        If (operation.NextCategory IsNot Nothing) Then
                            vgProplist.FocusedRow = operation.NextCategory
                            vgProplist.LayoutChanged()
                        Else
                            vgProplist.FocusedRow = vgProplist.Rows(0)

                            vgProplist.LayoutChanged()
                        End If
                    Else
                        Dim operation As New MoveToNextEditorRowOperation(vgProplist)
                        vgProplist.RowsIterator.DoOperation(operation)
                        vgProplist.Focus()
                        vgProplist.FocusedRow = operation.NextEditorRow

                        vgProplist.LayoutChanged()
                    End If
                End If



            End If

        Catch ex As Exception

            MessageBox.Show("ClientMouseUp: " & ex.Message)

        End Try
    End Function

    Private Sub FillDefnCombo(sncs As Long)
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sDisplayStr As String
        Dim sID As Integer
        Dim sql As String


        Try

            cboDefn.Properties.Items.Clear()

            cboDefn.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick
            cboDefn.Properties.Buttons(0).Enabled = True
            cboDefn.Properties.Buttons(0).Visible = True

            cboDefn.Visible = True

            If (sncs <= 2000) Then  'ie. geometry defn.

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

                sql = "SELECT * FROM Defn WHERE (DefnCatalogID = " & sncs & ")"

                connection = New OleDbConnection(connetionString)

                Try
                    connection.Open()

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    oledbAdapter.Fill(ds)

                    oledbAdapter.Dispose()

                    connection.Dispose()
                    connection.Close()

                    For i = 0 To ds.Tables(0).Rows.Count - 1

                        sDisplayStr = ds.Tables(0).Rows(i).Item("Display")
                        sID = ds.Tables(0).Rows(i).Item("ID")

                        With cboDefn.Properties

                            .Items.Add(New myItemData(sDisplayStr, sID))

                        End With


                    Next

                    ds.Dispose()

                    If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                Catch ex As Exception

                    MessageBox.Show("FillDefnCombo: " & ex.Message)

                Finally

                    If ds IsNot Nothing Then ds = Nothing

                    If connection IsNot Nothing Then connection = Nothing

                End Try

            End If

        Catch ex As Exception

            MessageBox.Show("FillDefnCombo: " & ex.Message)

        End Try

    End Sub
    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function
    Private Sub dlgCreateInstance_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        m_curr_dlg = Me

    End Sub

    Private Sub dlgCreateInstance_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        modView.ViewRefresh()
    End Sub

    Private Sub dlgCreateInstance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        m_is_active = False
        frmMain.CloseFirstPanel()
        modView.ViewResize()
    End Sub


    Private Sub InitStuff()
        Dim sql As String
        Dim lToolID As Long
        Dim childrow As BaseRow


        cboDefn.Visible = False

        m_is_active = True

        Try

            If (m_sncs <= 2000) Then

                'ie. the 'root' sncs of geometry defn
                'NOTE: Has side effect of populating the property list.
                FillDefnCombo(m_sncs)
                cboDefn.Visible = True
                cboDefn.Properties.Buttons(0).Visible = True

                cboDefn.SelectedIndex = 0

                If (g_clsActiveToolData IsNot Nothing) Then
                    Name = g_clsActiveToolData.Description

                    childrow = GetRowByCaption("Tool")

                    If (childrow IsNot Nothing) Then
                        vgProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = "[" & g_clsActiveToolData.NC_Code_Number & "] " & Name

                        lToolID = GetActiveLayer().Id

                        lReturn = UpdateAccumulatorDirect(vgProplist, "tool", lToolID)

                    End If

                End If

            ElseIf ((m_sncs > 2000) And (m_sncs < 3000)) Then

                lReturn = SetLabel(m_sncs)

                sql = "SELECT * FROM ModifyVar WHERE (ModifyID=" & m_sncs & ") Order By ModifyVar.ID"
                lReturn = modPropList.InitFromDB(vgProplist, PathAppDB(), sql)

                If (m_sncs = 2012) Then

                End If

            ElseIf ((m_sncs > 3000)) Then

                sql = "SELECT * FROM DefnVar WHERE (DefnID=" & m_sncs & ")"
                lReturn = modPropList.InitFromDB(vgProplist, PathAppDB(), sql)

            End If

            If (m_In_Edit_Mode = True) Then

                FillEntityProps(m_entity_id)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        vgProplist.BestFit()


    End Sub

    Public Function SetEntityID(entity_id As Long) As Long
        m_entity_id = entity_id
    End Function


    Public Function SetSNCS(sncs As Long) As Long

        Dim must_init As Boolean

        Try
            modEdit.RevertProfile()

            'By doing this, we prevent users from inadvertantly resetting
            'the proplist's values (eg. if they are in the line dialog
            'and select the line icon again when the dialog is open).
            '  must_init = (m_sncs <> sncs)
            must_init = True

            'ie. TrimExtend
            If ((sncs = 2017) And modModeMgmt.IsHotDotEnabled()) Then
                lReturn = modModeMgmt.HotDotEnable(False)
            End If

            m_sncs = sncs

            If (Me.Visible = True) Then
                If (must_init = True) Then
                    InitStuff()
                    PopulateValues()

                End If
            End If

        Catch ex As Exception

            MessageBox.Show("SetSNCS: " & ex.Message)

        End Try
    End Function
    Protected Overloads Overrides Sub WndProc(ByRef m As Message)

        '//Prevent the user from moving the form
        Try
            If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_MOVE) Then
                Exit Sub
            End If

            If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32() = HTCAPTION) Then
                Exit Sub
            End If

            MyBase.WndProc(m)

        Catch

        End Try

    End Sub

    Private Function SetLabel(sncs As Long) As Long
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String

        cboDefn.Visible = False
        cboDefn.Properties.Items.Clear()

        Try

            If ((sncs > 1000) And (sncs < 3000)) Then  'ie. an editing defn.

                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

                sql = "SELECT * FROM Modify WHERE (ID=" & sncs & ")"

                connection = New OleDbConnection(connetionString)


                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(ds)

                oledbAdapter.Dispose()

                connection.Close()

                cboDefn.EditValue = (ds.Tables(0).Rows(0).Item("Display").ToString)
                cboDefn.Properties.Buttons(0).Enabled = False
                cboDefn.Properties.Buttons(0).Visible = False

                If (cboDefn.Properties.Items.Count = 1) Then

                    cboDefn.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
                    cboDefn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                End If

                cboDefn.Visible = True

                ds.Dispose()

                If ds IsNot Nothing Then ds = Nothing

                If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                If connection IsNot Nothing Then connection = Nothing

            End If

        Catch ex As Exception

            MessageBox.Show("SetLabel: " & ex.Message)

        End Try

    End Function

    Private Sub rbPropSettings_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rbPropSettings.ButtonClick
        Dim FocusedRow As BaseRow = vgProplist.FocusedRow
        Dim Tag As Object = FocusedRow.Tag
        Dim filters As Long = 0
        Dim iname As String = Nothing
        Dim filter_mode As EXPLORER_OPTION
        Dim nDataType As Long
        Dim m_exploer_Filename As String

        Try
            frmMain.tbSelect_Enable.Checked = False
            frmMain.tbSelect_ByWindow.Checked = False

            'FilterSet(0)


            nDataType = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "VarDataType", 0)
            Select Case nDataType
                Case DB_FILE
                    filter_mode = 0

                    frmExplorer.Usage("Merge Model", filter_mode, False, FILE_MM2)

                    frmExplorer.ShowDialog(frmMain)
                    m_exploer_Filename = frmExplorer.GetFilename
                    frmExplorer.Dispose()

                    modView.ViewActivate(VIEW_WIRE)

                    modView.ViewRegen()

                    vgProplist.BeginDataUpdate()
                    vgProplist.SetCellValue(FocusedRow, vgProplist.FocusedRecord, TrimToFit(m_exploer_Filename, 25))
                    vgProplist.EndDataUpdate()

                    iname = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "DatVarName", "")

                    lReturn = UpdateAccumulatorDirect(vgProplist, iname, m_exploer_Filename)

                Case DB_MACHINE

                Case DB_TOOLSETUP
                Case DB_MATERIAL


            End Select

            modView.ViewRegen()

        Catch ex As Exception
            MessageBox.Show("rbPropSettings_ButtonClick: " & ex.Message)
        End Try

    End Sub

    Private Sub vgProplist_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgProplist.CellValueChanged

        Dim iname As String
        Dim sOptions As String
        Dim nVarType As Integer
        Dim sValue As String
        Dim childrow As BaseRow

        Try
            nVarType = CInt(GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "VarDataType", ""))
            iname = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "DatVarName", "")

            sOptions = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "Options", "")

            Dim sDatVarName As String

            sDatVarName = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "DatVarName", "")

            childrow = GetRowByCaptionChild(vgProplist.FocusedRow, vgProplist.FocusedRow.Properties.Caption)

            Select Case nVarType
                Case DB_DIR
                    If (e.Value = "CW") Then
                        sValue = -1
                    Else
                        sValue = 1
                    End If
                    '                    sValue = GetOptionIndex(sOptions, e.Value)

                Case DB_MACHINE
                    sValue = GetMachineIDFromDescrip(e.Value)

                Case DB_TOOLSETUP
                    sValue = GetToolSetupIDFromDescription(e.Value)

                Case DB_COMBO, DB_USERVAR, DB_SOLN
                    sValue = GetOptionIndex(sOptions, e.Value)


                Case DB_CRIB

                    sValue = FindModelIDFromToolDescrip(e.Value)
                    g_clsActiveToolData = FindToolByModelID(CLng(sValue))
                    Name = GetEntityName(CLng(sValue))

                    SetActiveLayer(Name, g_clsActiveToolData.TlColor)

                Case DB_LEADSETUP
                    sValue = modTranslate.GetLeadSetupID(e.Value)

                Case DB_MATERIAL
                    sValue = modTranslate.GetMaterialIDFromDescription(e.Value)


                Case DB_DBL
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetDouble("val", 0)

                        childrow.Properties.Value = Round(sValue, Places.Millionths)
                    Else
                        sValue = e.Value
                    End If

                Case DB_INT
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetInt("val", 0)

                        childrow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If
                Case DB_STR
                    sValue = e.Value

                Case Else
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetDouble("val", 0)

                        childrow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If

            End Select

            lReturn = UpdateAccumulatorDirect(vgProplist, iname, sValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub vgProplist_CellValueChanging(sender As Object, e As Events.CellValueChangedEventArgs) Handles vgProplist.CellValueChanging
        Dim sDatVarName As String
        Dim nMatID As Long

        Try
            If (e.Row.Properties.Caption = "Material Type") Then

                nMatID = modTranslate.GetMaterialIDFromDescription(e.Value)

                Dim childRows As VGridRows = vgProplist.FocusedRow.ParentRow.ChildRows


                For Each childRow As EditorRow In vgProplist.FocusedRow.ParentRow.ChildRows

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

            End If
        Catch ex As Exception

            MessageBox.Show("vgProplist_CellValueChanging: " & ex.Message)

        End Try
    End Sub


    Private Sub vgProplist_CustomDrawRowHeaderCell(sender As Object, e As Events.CustomDrawRowHeaderCellEventArgs) Handles vgProplist.CustomDrawRowHeaderCell
        If vgProplist.FocusedRow Is e.Row Then
            e.Appearance.BackColor = Color.Gold
        End If
    End Sub

    Private Sub vgPropList_CustomRecordCellEdit(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs) Handles vgProplist.CustomRecordCellEdit

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

                End Select
                If (nTemp = DB_FILE Or nTemp = DB_FOLDER) Then

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Function Set_In_Edit_Mode(Mode As Boolean) As Long
        m_In_Edit_Mode = Mode
    End Function
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try

            Me.vgProplist.FocusFirst()

            lReturn = Execute()
            Set_In_Edit_Mode(False)
            modView.ViewRegen()

            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception

            MessageBox.Show("btnAccept_Click: " & ex.Message)

        End Try
    End Sub
    Private Sub SetTheAccumulator()

        Dim iname As String
        Dim sOptions As String
        Dim nVarType As Integer
        Dim sValue As String = Nothing

        Try

            For Each row As CategoryRow In vgProplist.Rows
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

                    lReturn = UpdateAccumulatorDirect(vgProplist, iname, sValue)
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Function Execute() As Long

        Try
            If (m_sncs < 2000) Then

            If (m_sncs = 1600) Then
                lReturn = modEdit.Execute(m_sub_item_sncs, GetAccumulator())
            Else
                lReturn = modGeometry.Execute( _
                   m_sncs, m_entity_id, m_sub_item_sncs, GetAccumulator())
            End If

            lReturn = UpdateLastValues(m_sub_item_sncs)

        ElseIf ((m_sncs > 2000) And (m_sncs < 3000)) Then

            lReturn = modEdit.Execute(m_sncs, GetAccumulator)
            lReturn = UpdateLastValues(m_sncs)

        End If

        modView.ViewRegen()
            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception

            MessageBox.Show("Execute: " & ex.Message)

        End Try

    End Function
    Private Function UpdateLastValues(sncs As Long) As Long
        Dim oledbAdapter As OleDbDataAdapter
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim dsProps As New DataSet
        Dim sql As String
        Dim ChildRowTag As String
        Dim recordID As Long
        Dim sInternalName As String = Nothing
        Dim indx As Integer

        Try
            If (RegGetString("Preferences\ViewOptions", "SaveLastUsed", 1) <> 0) Then

                'This function updates the AppDb to store the last values used
                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

                connection = New OleDbConnection(connetionString)

                For Each row As CategoryRow In vgProplist.Rows

                    For Each childRow As EditorRow In row.ChildRows

                        If (UCase(childRow.Properties.Caption) <> "ID") Then

                            ChildRowTag = childRow.Tag

                            'Using the record id which is stored in the tag value makes finding the right record real easy
                            recordID = GetValueFromDelimitedData(ChildRowTag, "nRecordID", 0)

                            'Check the sncs so that we look in the right table.
                            'If the value is between 2000 and 3000 we use the modify table
                            If ((sncs > 2000) And (sncs < 3000)) Then

                                sql = "SELECT * FROM ModifyVar WHERE (ID =" & recordID & ") And (ModifyVar.Type <> 0 )"

                                oledbAdapter = New OleDbDataAdapter(sql, connection)

                                oledbAdapter.Fill(dsProps)

                                oledbAdapter.Dispose()

                                If (dsProps.Tables(0).Rows.Count > 0) Then

                                    For indx = 0 To dsProps.Tables(0).Rows.Count - 1
                                        sInternalName = dsProps.Tables(0).Rows(indx).Item("InternalName")
                                    Next

                                End If

                                If ((sInternalName <> "STAN") And (sInternalName <> "NOP") And (sInternalName <> "ETAN")) Then

                                    sql = "UPDATE [ModifyVar] set [ModifyVar].[Value] = '" & childRow.Properties.Value & "' Where ([ModifyVar].[ID] =" & recordID & " )"

                                End If

                            Else

                                sql = "SELECT * FROM DefnVar WHERE (ID = " & recordID & ") And (Type <> 0 )"

                                oledbAdapter = New OleDbDataAdapter(sql, connection)

                                oledbAdapter.Fill(dsProps)

                                oledbAdapter.Dispose()

                                If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                                If (dsProps.Tables(0).Rows.Count > 0) Then

                                    sInternalName = UCase(dsProps.Tables(0).Rows(indx).Item("InternalName"))

                                End If


                                If ((sInternalName <> "STAN") And (sInternalName <> "NOP") And (sInternalName <> "ETAN")) Then

                                    sql = "UPDATE [DefnVar] set [DefnVar].[Value] = '" & childRow.Properties.Value & "' Where ([DefnVar].[ID] =" & recordID & " )"

                                End If

                            End If

                            connection.Open()

                            Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)

                            cmd.ExecuteNonQuery()

                            connection.Close()


                        End If

                    Next

                Next

                dsProps.Dispose()


            End If


            If dsProps IsNot Nothing Then dsProps = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("UpdateLastValues: " & ex.Message)

        End Try

    End Function

    Public Sub PopulateValues()

        Select Case m_sncs

            Case 2021 : lReturn = GetProjectInfo()


        End Select


    End Sub

    Private Sub dlgCreateInstance_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        ProcessKeyPress(e.KeyCode, e.Modifiers)
    End Sub

    Private Sub FillPatternList()
        Dim lPatternCount As Long
        Dim nI As Integer
        Dim lPatID As Long
        Dim sPatName As String

        lstPattern.Items.Clear()

        Try

            lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBPATTERN)
            lPatternCount = PortalGetInt("count", 0)

            For nI = 0 To lPatternCount - 1
                lReturn = PortalExecute("*Model:Get2:indx=" & nI & ",type=" & c_DBPATTERN)
                lPatID = PortalGetInt("id", 0)

                sPatName = EntityStringGet(lPatID, "_label", "<error>")

                lstPattern.Items.Add(New myItemData(sPatName, lPatID))

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub lstPattern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPattern.SelectedIndexChanged
        Dim n_SelIndex As Integer

        Try

            n_SelIndex = Me.lstPattern.SelectedIndex

            If (n_SelIndex >= 0) Then
                ltbPatternID.Text = (TryCast(lstPattern.Items(n_SelIndex), myItemData)).ItemData.ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("lstPattern_SelectedIndexChanged() : " & ex.Message)
        End Try

    End Sub
    Private Sub dlgCreateInstance_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_is_active = True

        Try
            FillPatternList()

        frmMain.SetCurrentDialog(Me)
        ' Uncheck all buttons
        Dim button As ToolStripButton = Nothing
        For Each obj As Object In frmMain.tbSelect.Items
            If TypeOf obj Is ToolStripButton Then
                button = DirectCast(obj, ToolStripButton)
                button.Checked = False
                ' Patch to get rid of the faulty activated ToolTip background color
                'button.Visible = False
                'button.Visible = True
            End If
        Next
            'FilterSet(0)


        Catch ex As Exception
            MessageBox.Show("dlgCreateInstance_Load() : " & ex.Message)
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


            For Each row As CategoryRow In vgProplist.Rows

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

                    vgProplist.BeginDataUpdate()
                    childRow.Properties.Value = my_Value
                    vgProplist.EndDataUpdate()

                Next childRow

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        rbPropSettings = New RepositoryItemButtonEdit()
    End Sub
    Private Class MoveToNextEditorRowOperation
        Inherits RowOperation
        Private nextCategory_Renamed As EditorRow
        Private currentRow As BaseRow
        Public Sub New(ByVal grid As VGridControl)
            MyBase.New()
            currentRow = grid.FocusedRow
        End Sub
        Public Overrides Sub Execute(ByVal row As BaseRow)
            If (IsNothing(currentRow) = False) Then
                If row.VisibleIndex > currentRow.VisibleIndex Then
                    If nextCategory_Renamed Is Nothing AndAlso TypeOf row Is EditorRow Then
                        nextCategory_Renamed = TryCast(row, EditorRow)
                    End If
                End If
            End If
        End Sub

        Public ReadOnly Property NextEditorRow() As EditorRow
            Get
                Return nextCategory_Renamed
            End Get
        End Property
    End Class

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

    Private Sub cboDefn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDefn.SelectedIndexChanged
        Dim sql As String

        m_sub_item_sncs = (TryCast(cboDefn.SelectedItem, myItemData).ItemData.ToString())

        sql = "SELECT * FROM DefnVar WHERE (DefnID=" & m_sub_item_sncs & ")"
        lReturn = modPropList.InitFromDB(vgProplist, PathAppDB(), sql)

    End Sub
    Private Sub vgProplist_KeyUp(sender As Object, e As KeyEventArgs) Handles vgProplist.KeyUp


        If (e.KeyCode = Keys.Enter) Then
            If (vgProplist.FocusedRow Is vgProplist.GetLastVisible()) Then

                lReturn = Execute()
                Set_In_Edit_Mode(False)
                modView.ViewRegen()

                vgProplist.FocusedRow = vgProplist.Rows.FirstVisible

            Else
                System.Windows.Forms.SendKeys.Send("{TAB}") ' treat as a tab to calculate
            End If


        End If
    End Sub

    Private Sub vgProplist_MouseClick(sender As Object, e As MouseEventArgs) Handles vgProplist.MouseClick
        frmMain.tbSelect_Enable.Checked = False
        frmMain.tbSelect_ByWindow.Checked = False

        m_selection_mode = False
        'FilterSet(0)
        lReturn = ModeEnd(MODE_SELECT)
    End Sub

    Private Sub vgProplist_MouseDown(sender As Object, e As MouseEventArgs) Handles vgProplist.MouseDown

        frmMain.tbSelect_Enable.Checked = False
        'm_selection_mode = frmMain.tbSelect_Enable.Checked
        lReturn = ModeEnd(MODE_SELECT)
    End Sub

    Private Sub vgProplist_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles vgProplist.ShowingEditor
        BeginInvoke(New FocusTextHandler(AddressOf FocusText), sender)
    End Sub

    Private Sub vgProplist_ShownEditor(sender As Object, e As EventArgs) Handles vgProplist.ShownEditor
        Dim edit As ComboBoxEdit = TryCast(vgProplist.ActiveEditor, ComboBoxEdit)
        Dim indx As Integer
        Dim DB_TOOLSETUP As Integer = 8
        Dim DB_LAYERSETUP As Integer = 42
        Dim s_ToolSetup As String
        Dim n_ToolSetupID As Long
        Dim sOptions As String = sEmpty

        Try

            If (vgProplist.FocusedRow.Properties.Caption = "Tool Setup") Then ' IsNot Nothing Then

                'If vgProplist.FocusedRow Is nToolSetupRowId Then


                edit.Properties.Items.Clear()

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

                    vgProplist.FocusedRow.Tag = EncodeTag("toolsetup",
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
            MessageBox.Show("vgProplist_ShownEditor() : " & ex.Message)
        End Try

    End Sub

    Private Sub edit_EditValueChanged(sender As Object, e As EventArgs)
        Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
        Dim my_DefnID As Integer
        Dim childrow As BaseRow
        Dim nMaterialID As Long
        Dim my_Cvalue As String
        Dim nVarType As Integer


        Try
            nToolSetupRowId = Nothing

            editValue = edit.EditValue.ToString()

            nVarType = CInt(GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "VarDataType", ""))


            If (vgProplist.FocusedRow.Properties.Caption = "Machine") Then

                SelectedMachineName = edit.EditValue.ToString()
                m_machine_id = GetMachineIDFromDescrip(SelectedMachineName)


                nToolSetupRowId = GetRowByCaption("Tool Setup")

                If (IsNothing(nToolSetupRowId) = False) Then
                    nRowIndx = nToolSetupRowId.Index


                    vgProplist.FocusedRow = vgProplist.Rows(nToolSetupRowId.ParentRow.Index).ChildRows(nToolSetupRowId.Index)
                    vgProplist.FocusedRow.Properties.Value = ""
                    vgProplist.ShowEditor()
                End If
            End If

            If (vgProplist.FocusedRow.Properties.Caption = "Material Type") Then
                my_Cvalue = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "CValue", "")

                nMaterialID = CLng(GetMaterialIDFromDescription(edit.EditValue))

                childrow = GetRowByCaption("Material Length")

                vgProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = modMaterial.GetMaterialLength(CLng(nMaterialID))
                m_accumulator.mat_len = CDbl(modMaterial.GetMaterialLength(CLng(nMaterialID)))

                childrow = GetRowByCaption("Material Width")
                vgProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = modMaterial.GetMaterialWidth(CLng(nMaterialID))
                m_accumulator.mat_wid = CDbl(modMaterial.GetMaterialWidth(CLng(nMaterialID)))

                childrow = GetRowByCaption("Material thickness")
                vgProplist.Rows(childrow.ParentRow.Index).ChildRows(childrow.Index).Properties.Value = modMaterial.GetMaterialThickness(CLng(nMaterialID))
                m_accumulator.mat_thick = CDbl(modMaterial.GetMaterialThickness(CLng(nMaterialID)))

            End If

            my_DefnID = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "DefnID", 0)

            If (my_DefnID > 0 And nVarType = DB_USERVAR) Then


                lReturn = GetPropsForUserVar(vgProplist, vgProplist.FocusedRow, edit.SelectedIndex, my_DefnID)
                vgProplist.FocusedRow.Properties.Value = editValue
                m_accumulator.soln_Set(5, edit.SelectedIndex)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Function GetRowByCaption(ByVal s As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        'Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow



        Try
            For Each row As DevExpress.XtraVerticalGrid.Rows.BaseRow In vgProplist.Rows
                GetRowByCaption = GetRowByCaptionChild(row, s)
                If Not GetRowByCaption Is Nothing Then
                    Return GetRowByCaption
                End If
            Next row

            Return GetRowByCaption

        Catch ex As Exception
            MessageBox.Show("GetRowByCaption() : " & ex.Message)
        End Try


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
            Return Nothing
        Catch ex As Exception
            MessageBox.Show("GetRowByCaption() : " & ex.Message)
        End Try

    End Function

    Public Function MoveToFirstRow() As Long
        Dim operation As New MoveToNextCategoryOperation(vgProplist)
        vgProplist.RowsIterator.DoOperation(operation)
        vgProplist.Focus()
        vgProplist.FocusedRow = vgProplist.Rows(0)
        vgProplist.LayoutChanged()
        MoveToFirstRow = 1

    End Function

    Private Sub FillEntityProps(lEntityID As Long)
        Dim lType As Long
        Dim DX As Double
        Dim DY As Double
        Dim dZ As Double
        Dim dx2 As Double
        Dim dy2 As Double
        Dim dz2 As Double
        Dim lTemp As Long
        Dim lToolID As Long
        Dim sTemp As String
        Dim ownerID As Long
        Dim sFeatureParams As String
        Dim sFeatureName As String
        Dim Angle As Double
        Dim position As Long
        Dim sAccumualtorName As String

        Try

            lReturn = PortalExecute("*create:extract:id=" & lEntityID) ' Getting other info about entity
            lType = PortalGetInt("type", c_INVALID) ' Type: Line, Arc, Hole, Point

            '' get any tooling or layer information
            If ((lType >= c_DBPOINT And lType <= c_DBHOLE) Or lType = c_DBCOMMAND) Then

                lReturn = PortalExecute("*Entity:Tool:id=" & lEntityID)
                lToolID = PortalGetInt("ID", 0)

                lReturn = UpdateAccumulatorDirect(vgProplist, "tool", lToolID)

            End If

            lReturn = PortalExecute("*create:extract:id=" & lEntityID) ' Getting other info about entity
            lType = PortalGetInt("type", c_INVALID) ' Type: Line, Arc, Hole, Point

            Select Case lType

                Case c_DBPOINT ' point
                    DX = PortalGetDouble("x", 0)
                    DY = PortalGetDouble("y", 0)
                    dZ = PortalGetDouble("z", 0)


                Case c_DBLINE ' line
                    DX = PortalGetDouble("sx", 0)
                    DY = PortalGetDouble("sy", 0)
                    dZ = PortalGetDouble("sz", 0)

                    dx2 = PortalGetDouble("ex", 0)
                    dy2 = PortalGetDouble("ey", 0)
                    dz2 = PortalGetDouble("ez", 0)

                    SetValue(vgProplist, "ps_x", Round(DX, Places.Millionths))
                    SetValue(vgProplist, "ps_y", Round(DY, Places.Millionths))
                    SetValue(vgProplist, "ps_z", Round(dZ, Places.Millionths))

                    SetValue(vgProplist, "pe_x", Round(dx2, Places.Millionths))
                    SetValue(vgProplist, "pe_y", Round(dy2, Places.Millionths))
                    SetValue(vgProplist, "pe_z", Round(dz2, Places.Millionths))


                Case c_DBARC ' arc
                    ' cboDefn.ListIndex = 4

                    DX = PortalGetDouble("sx", 0)
                    DY = PortalGetDouble("sy", 0)
                    dZ = PortalGetDouble("sz", 0)

                    SetValue(vgProplist, "ps_x", Round(DX, Places.Millionths))
                    SetValue(vgProplist, "ps_y", Round(DY, Places.Millionths))
                    SetValue(vgProplist, "ps_z", Round(dZ, Places.Millionths))

                    DX = PortalGetDouble("ex", 0)
                    DY = PortalGetDouble("ey", 0)
                    dZ = PortalGetDouble("ez", 0)

                    SetValue(vgProplist, "pe_x", Round(DX, Places.Millionths))
                    SetValue(vgProplist, "pe_y", Round(DY, Places.Millionths))
                    SetValue(vgProplist, "pe_z", Round(dZ, Places.Millionths))

                    dx2 = PortalGetDouble("cx", 0)
                    dy2 = PortalGetDouble("cy", 0)
                    dz2 = PortalGetDouble("cz", 0)

                    SetValue(vgProplist, "pc_x", Round(dx2, Places.Millionths))
                    SetValue(vgProplist, "pc_y", Round(dy2, Places.Millionths))
                    SetValue(vgProplist, "pc_z", Round(dz2, Places.Millionths))

                    lTemp = PortalGetInt("dir", 0)

                    SetValue(vgProplist, "dir", IIf((lTemp = -1), 0, 1))


                Case c_DBHOLE ' hole
                    ownerID = GetOwnerID(lEntityID)
                    'TODO: Make the true and false values in the function string 0 and 1

                    sFeatureParams = EntityStringGet(ownerID, "function", "")
                    lReturn = vbParse(sFeatureParams)

                    sFeatureName = PortalGetString("function", "")
                    lTemp = PortalGetInt("sncs", 0)

                Case c_DBCOMMAND ' command

                    DX = PortalGetDouble("x", 0.0#)
                    DY = PortalGetDouble("y", 0.0#)
                    dZ = PortalGetDouble("z", 0.0#)

                    SetValue(vgProplist, "ps_x", Round(DX, Places.Millionths))
                    SetValue(vgProplist, "ps_y", Round(DY, Places.Millionths))
                    SetValue(vgProplist, "ps_z", Round(dZ, Places.Millionths))

                    sTemp = PortalGetString("text", "")
                    If InStr(1, sTemp, "INSTANCE") > 0 Then

                        '???
                        'Not sure what we should do if it is an instance

                    Else

                        Angle = PortalGetDouble("angle", 0.0#)
                        position = IIf((PortalGetInt("pos", 2) = 1), 1, 0)
                        'sTemp = Left(sTemp, InStr(1, sTemp, Chr$(0)) - 1)
                        SetValue(vgProplist, "text", sTemp)
                        SetValue(vgProplist, "soln(0)", position)
                        SetValue(vgProplist, "angle", Angle)

                    End If

            End Select

            For Each row As CategoryRow In vgProplist.Rows
                Dim childRows As VGridRows = row.ChildRows

                For Each childRow As EditorRow In childRows

                    sAccumualtorName = GetValueFromDelimitedData(childRow.Tag, "DatVarName", "")

                    Select Case sAccumualtorName
                        Case "ps_x" : childRow.Properties.Value = m_accumulator.ps.x
                        Case "ps_y" : childRow.Properties.Value = m_accumulator.ps.y
                        Case "ps_z" : childRow.Properties.Value = m_accumulator.ps.Z
                        Case "ps"
                        Case "ps_o"
                        Case "ps_osnap"
                        Case "ps_entityID"

                        Case "pe"
                        Case "pe_x" : childRow.Properties.Value = m_accumulator.pe.x
                        Case "pe_y" : childRow.Properties.Value = m_accumulator.pe.y
                        Case "pe_z" : childRow.Properties.Value = m_accumulator.pe.Z
                        Case "pe_o"
                        Case "pe_osnap"
                        Case "pe_entityID"

                        Case "pc"
                        Case "pc_x" : childRow.Properties.Value = m_accumulator.pc.x
                        Case "pc_y" : childRow.Properties.Value = m_accumulator.pc.y
                        Case "pc_z" : childRow.Properties.Value = m_accumulator.pc.Z
                        Case "pc_o"
                        Case "pc_osnap"
                        Case "pc_entityID"

                        Case "pi"
                        Case "pi_x" : childRow.Properties.Value = m_accumulator.PI.x
                        Case "pi_y" : childRow.Properties.Value = m_accumulator.PI.y
                        Case "pi_z" : childRow.Properties.Value = m_accumulator.PI.Z
                        Case "pi_o"
                        Case "pi_osnap"
                        Case "pi_entityID"

                        Case "length" : childRow.Properties.Value = m_accumulator.Length
                        Case "radius" : childRow.Properties.Value = m_accumulator.Rad
                        Case "angle" : childRow.Properties.Value = m_accumulator.Ang
                        Case "angincr" : childRow.Properties.Value = m_accumulator.angincr
                        Case "toolang" : childRow.Properties.Value = m_accumulator.toolang
                        Case "major" : childRow.Properties.Value = m_accumulator.major
                        Case "minor" : childRow.Properties.Value = m_accumulator.minor

                            'This set of parameters was introduced for modEdit.
                        Case "dx" : childRow.Properties.Value = m_accumulator.DX
                        Case "dy" : childRow.Properties.Value = m_accumulator.DY
                        Case "dz" : childRow.Properties.Value = m_accumulator.dZ
                            'Case "dist" : childRow.Properties.Value = lReturn : childRow.Properties.Value = m_accumulator.dist_Set(subIndex, CDbl(Value))
                        Case "factor" : childRow.Properties.Value = m_accumulator.factor
                        Case "nx" : childRow.Properties.Value = m_accumulator.nx
                        Case "ny" : childRow.Properties.Value = m_accumulator.ny
                        Case "cnt" : childRow.Properties.Value = m_accumulator.cnt

                        Case "etan" : childRow.Properties.Value = m_accumulator.etan
                        Case "stan" : childRow.Properties.Value = m_accumulator.stan

                        Case "dir" : childRow.Properties.Value = m_accumulator.dir
                        Case "soln"
                            childRow.Properties.Value = m_accumulator.soln_Set(childRow.Properties.Value, 0)
                            '                lReturn : childRow.Properties.Value = m_accumulator.soln_choice : childRow.Properties.Value = subindex
                            '
                            ' Case "soln" : childRow.Properties.Value = lReturn : childRow.Properties.Value = m_accumulator.soln_Set(subIndex, CLng(Value))
                            'lReturn : childRow.Properties.Value = m_accumulator.soln_choice : childRow.Properties.Value = subindex


                        Case "qty" : childRow.Properties.Value = m_accumulator.qty
                        Case "qty_x" : childRow.Properties.Value = m_accumulator.qty_x
                        Case "qty_y" : childRow.Properties.Value = m_accumulator.qty_y

                        Case "rptdir" : childRow.Properties.Value = m_accumulator.rptdir
                        Case "rptcnt" : childRow.Properties.Value = m_accumulator.rptcnt
                        Case "rptdst" : childRow.Properties.Value = m_accumulator.rptdst

                        Case "spacing" : childRow.Properties.Value = m_accumulator.spacing
                        Case "spacing_x" : childRow.Properties.Value = m_accumulator.spacing_x
                        Case "spacing_y" : childRow.Properties.Value = m_accumulator.spacing_y

                        Case "tool" : childRow.Properties.Value = m_accumulator.tool

                        Case "font" : childRow.Properties.Value = m_accumulator.Font
                        Case "text" : childRow.Properties.Value = m_accumulator.Text
                        Case "height" : childRow.Properties.Value = m_accumulator.Height
                        Case "justification" : childRow.Properties.Value = m_accumulator.justification
                        Case "filename" : childRow.Properties.Value = m_accumulator.Filename
                        Case "file" : childRow.Properties.Value = m_accumulator.Filename
                        Case "machine" : childRow.Properties.Value = m_accumulator.machine
                        Case "toolsetup" : childRow.Properties.Value = m_accumulator.ToolSetupID
                        Case "materialtype"

                            childRow.Properties.Value = SetValue(vgProplist, "mat_len", modMaterial.GetMaterialLength(CLng(m_accumulator.materialType)))
                            childRow.Properties.Value = SetValue(vgProplist, "mat_wid", modMaterial.GetMaterialWidth(CLng(m_accumulator.materialType)))
                            childRow.Properties.Value = SetValue(vgProplist, "mat_thick", modMaterial.GetMaterialThickness(CLng(m_accumulator.materialType)))

                        Case "mat_len" : childRow.Properties.Value = m_accumulator.mat_len
                        Case "mat_wid" : childRow.Properties.Value = m_accumulator.mat_wid
                        Case "mat_thick" : childRow.Properties.Value = m_accumulator.mat_thick
                        Case "datepick" : childRow.Properties.Value = m_accumulator.datepick
                        Case "customer" : childRow.Properties.Value = m_accumulator.customer
                        Case "num_clamps" : childRow.Properties.Value = m_accumulator.num_clamps
                        Case "clamp1" : childRow.Properties.Value = m_accumulator.clamp1
                        Case "clamp2" : childRow.Properties.Value = m_accumulator.clamp2
                        Case "clamp3" : childRow.Properties.Value = m_accumulator.clamp3
                        Case "clamp4" : childRow.Properties.Value = m_accumulator.clamp4
                        Case "folder" : childRow.Properties.Value = m_accumulator.folder
                        Case "leadsetup" : childRow.Properties.Value = m_accumulator.leadSetupID
                        Case "layersetup" : childRow.Properties.Value = m_accumulator.layersetupID
                        Case "duedate" : childRow.Properties.Value = m_accumulator.duedate


                        Case "sql_table_name" : childRow.Properties.Value = m_accumulator.sql_table_name

                        Case "pdb_DB_name" : childRow.Properties.Value = m_accumulator.pdb_DB_name

                            'Added the following for Shape Library

                        Case "CornerRad" : childRow.Properties.Value = m_accumulator.CornerRad
                        Case "Orient" : childRow.Properties.Value = m_accumulator.Orient
                        Case "ProfLen" : childRow.Properties.Value = m_accumulator.ProfLen
                        Case "ProfWid" : childRow.Properties.Value = m_accumulator.ProfWid
                        Case "CenRad" : childRow.Properties.Value = m_accumulator.CenRad
                        Case "CenPt_x" : childRow.Properties.Value = m_accumulator.CenPt.x
                        Case "CenPt_y" : childRow.Properties.Value = m_accumulator.CenPt.y
                        Case "RefPt_x" : childRow.Properties.Value = m_accumulator.RefPt.x
                        Case "RefPt_y" : childRow.Properties.Value = m_accumulator.RefPt.y
                        Case "HoleDia" : childRow.Properties.Value = m_accumulator.HoleDia
                        Case "MajorDia" : childRow.Properties.Value = m_accumulator.MajorDia

                        Case "CornerRad2" : childRow.Properties.Value = m_accumulator.CornerRad2
                        Case "Orient2" : childRow.Properties.Value = m_accumulator.Orient2
                        Case "ProfLen2" : childRow.Properties.Value = m_accumulator.ProfLen2
                        Case "ProfWid2" : childRow.Properties.Value = m_accumulator.ProfWid2
                        Case "CenRad2" : childRow.Properties.Value = m_accumulator.CenRad2
                        Case "CenPt2_x" : childRow.Properties.Value = m_accumulator.CenPt2.x
                        Case "CenPt2_y" : childRow.Properties.Value = m_accumulator.CenPt2.y
                        Case "RefPt2_x" : childRow.Properties.Value = m_accumulator.RefPt2.x
                        Case "RefPt2_y" : childRow.Properties.Value = m_accumulator.RefPt2.y
                        Case "ps1_x" : childRow.Properties.Value = m_accumulator.ps1.x
                        Case "ps1_y" : childRow.Properties.Value = m_accumulator.ps1.y
                        Case "ps2_x" : childRow.Properties.Value = m_accumulator.ps2.x
                        Case "ps2_y" : childRow.Properties.Value = m_accumulator.ps2.y
                        Case "ps3_x" : childRow.Properties.Value = m_accumulator.ps3.x
                        Case "ps3_y" : childRow.Properties.Value = m_accumulator.ps3.y
                        Case "ps4_x" : childRow.Properties.Value = m_accumulator.ps4.x
                        Case "ps4_y" : childRow.Properties.Value = m_accumulator.ps4.y
                        Case "ps5_x" : childRow.Properties.Value = m_accumulator.ps5.x
                        Case "ps5_y" : childRow.Properties.Value = m_accumulator.ps5.y
                        Case "ps6_x" : childRow.Properties.Value = m_accumulator.ps6.x
                        Case "ps6_y" : childRow.Properties.Value = m_accumulator.ps6.y
                        Case "ps7_x" : childRow.Properties.Value = m_accumulator.ps7.x
                        Case "ps7_y" : childRow.Properties.Value = m_accumulator.ps7.y
                        Case "ps8_x" : childRow.Properties.Value = m_accumulator.ps8.x
                        Case "ps8_y" : childRow.Properties.Value = m_accumulator.ps8.y


                    End Select


                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class