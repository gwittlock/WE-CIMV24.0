Imports DevExpress.XtraVerticalGrid.Rows
Imports System.IO

Public Class frmEditNestDat
    Private p As System.Drawing.Point = System.Drawing.Point.Empty
    Dim sPieces() As String
    Dim nCurrentRow As Long
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

    Private Sub frmEditNestDat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        frmMain.CloseFirstPanel()
        '        Me.Dispose()
    End Sub
    Private Sub frmEditNestDat_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim machineID As Long
        Dim sDatFileName As String

        Try
            GetDefaultValuesFromGenericDat()

            machineID = modProject.GetMachineID()
            modProject.InitMachineList(cbeMachine, machineID)

            sDatFileName = PathDriveFolder(RegGetDatFilePath()) & "\" & cbeMachine.Text & ".dat"

            If (FileExists(sDatFileName) = True) Then

                GetDefaultValuesFromMachineDat(sDatFileName)


            End If

        Catch ex As Exception

            MessageBox.Show("frmEditNestDat_Load: " & ex.Message)

        End Try
    End Sub



    Private Sub GetDefaultValuesFromGenericDat()
        Dim line As String = Nothing
        Dim sGenericDatFile As String
        Dim sCategory As String = Nothing
        Dim nCatNameStart As Integer

        Try

            sGenericDatFile = RegGetDatFilePath()

            Using sr As StreamReader = New StreamReader(sGenericDatFile)

                line = sr.ReadLine()

                While (line <> Nothing)
                    If (InStr(1, line, "//=") > 0) Then

                        nCatNameStart = line.LastIndexOf("=")


                        sCategory = Trim(line.Substring(nCatNameStart + 1))

                    End If

                    If Len(line) > 3 And InStr(1, line, "glb.") > 0 Then
                        SplitVariableData(line)

                        lstDefaultSettings.Items.Add(sPieces(3))
                        lstTemp2.Items.Add(line)
                        lstTemp3.Items.Add(sPieces(2))
                        lstTemp4.Items.Add(sCategory)

                    End If
                    line = sr.ReadLine()
                End While

                sr.Dispose()

            End Using

        Catch ex As Exception

            MessageBox.Show("GetDefaultValuesFromGenericDat: " & ex.Message)

        End Try
    End Sub

    Private Sub SplitVariableData(ByVal sData As String)
        Dim nPieces As Integer

        Try
            ReDim sPieces(0 To 100)
            ' determine number of pieces
            nPieces = 1
            sPieces(nPieces) = GetToken(sData, "|")

            If sPieces(nPieces) <> sData Then
                Do While (nPieces < 100)
                    nPieces = nPieces + 1
                    sPieces(nPieces) = GetToken(sEmpty, "|")

                    If sPieces(nPieces) = sEmpty Then
                        nPieces = nPieces - 1 ' actual number of pieces
                        Exit Do
                    End If
                Loop
            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub lstDefaultSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles lstDefaultSettings.MouseDown
        Dim c As ListBoxControl = TryCast(sender, ListBoxControl)

        Try

            p = New System.Drawing.Point(e.X, e.Y)
            Dim selectedIndex As Integer = c.IndexFromPoint(p)
            If selectedIndex = -1 Then
                p = System.Drawing.Point.Empty

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub lstDefaultSettings_MouseMove(sender As Object, e As MouseEventArgs) Handles lstDefaultSettings.MouseMove
        If e.Button = MouseButtons.Left Then
            If (p <> System.Drawing.Point.Empty) AndAlso ((Math.Abs(e.X - p.X) > 5) OrElse (Math.Abs(e.Y - p.Y) > 5)) Then
                lstDefaultSettings.DoDragDrop(sender, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub vgNestSettings_DragDrop(sender As Object, e As DragEventArgs) Handles vgNestSettings.DragDrop
        Dim s_ToolDescrip As String = ""
        Dim p As System.Drawing.Point = New System.Drawing.Point(e.X, e.Y)
        Dim n_SelIndex As Long

        Try

            p = vgNestSettings.PointToClient(p)

            Dim hinfo As DevExpress.XtraVerticalGrid.VGridHitInfo = vgNestSettings.CalcHitInfo(New Point(e.X, e.Y))

            If IsNothing(hinfo.Row) And (hinfo.RecordIndex = -1) Then

                n_SelIndex = lstDefaultSettings.SelectedIndex

                CreateRows(lstTemp4.Items(n_SelIndex), lstTemp2.Items(n_SelIndex))

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub vgNestSettings_DragOver(sender As Object, e As DragEventArgs) Handles vgNestSettings.DragOver
        e.Effect = DragDropEffects.Copy
    End Sub
    Private Sub CreateRows(sCategoryRow As String, sDataLine As String)
        Dim currentCategoryRow As CategoryRow
        Dim nRowIndex As Integer
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim arrOptions As Collection
        Dim sql As String


        Try

            'NOTE: zero-based!
            sPieces = Split(sDataLine, "|")

            my_DatVarName = sPieces(0)
            my_CVarName = sPieces(0)
            my_DataType = ConvertDatTypeToDBType(sPieces(1))
            my_DialogDisplay = sPieces(2)

            If (UBound(sPieces) > 2) Then
                my_VBValue = sPieces(3)
                my_CValue = sPieces(3) 'Also see the case statement for combobox
            Else
                my_VBValue = Nothing
                my_CValue = Nothing
            End If
            my_RecodID = 0
            my_sOptions = sEmpty

            nRowIndex = DoesCategoryExist(sCategoryRow)

            If (nRowIndex = UNDEFINED) Then

                currentCategoryRow = CreateCategoryRow(vgNestSettings, sCategoryRow, sCategoryRow, sCategoryRow, 0, sCategoryRow, DB_HEADER, 0, sEmpty, 0)

            Else
                currentCategoryRow = vgNestSettings.Rows(nRowIndex)
            End If

            Select Case (my_DataType)

                Case DB_HEADER
                    currentCategoryRow = CreateCategoryRow(vgNestSettings, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)

                Case DB_STR
                    currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgNestSettings, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                Case DB_BOOL
                    currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgNestSettings, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                Case DB_INT
                    currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgNestSettings, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                Case DB_DBL
                    currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgNestSettings, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                Case DB_TOOL
                    Dim nToolSetupID As Long = RegGetString("Global", "ToolSetupID", 0)


                    my_CValue = 0
                    my_VBValue = "None"
                    my_RecodID = 0

                    sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" & _
                        " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " & _
                        "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " & _
                        "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" & _
                        " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & nToolSetupID & "))" & _
                        " ORDER BY [Station Configuration].[NC Code Number]"

                    arrOptions = PopulateComboList(sql, False, True)

                    currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestSettings, _
                                                               my_DatVarName, _
                                                            my_DialogDisplay, _
                                                            my_VBValue, _
                                                            my_CValue, _
                                                            my_CVarName, _
                                                            my_DataType, _
                                                            my_RecodID, _
                                                            arrOptions, 0))




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

                    currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgNestSettings, _
                                                            my_DatVarName, _
                                                             my_DialogDisplay, _
                                                             my_VBValue, _
                                                             my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))
            End Select


            vgNestSettings.BestFit()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click

        frmMain.CloseFirstPanel()
    End Sub
    Private Function DoesCategoryExist(sCatergoryRow As String) As Integer
        Try
            DoesCategoryExist = UNDEFINED

            For Each row As CategoryRow In vgNestSettings.Rows

                If (UCase(row.Properties.Caption) = UCase(sCatergoryRow)) Then

                    DoesCategoryExist = row.Index

                    Exit For

                End If

            Next

        Catch ex As Exception

            MessageBox.Show("DoesCategoryExist: " & ex.Message)

        End Try
    End Function

    Private Sub sbRestore_Click(sender As Object, e As EventArgs) Handles sbRestore.Click
        Dim sDatFileName As String

        Try

            sDatFileName = NormalizePath(App_Path) & cbeMachine.Text & ".dat"


            If (FileExists(sDatFileName) = True) Then
                vgNestSettings.Rows.Clear()

                Kill(sDatFileName)
                MessageBox.Show("All settings have been restored to original defaults.", "Restore Complete", MessageBoxButtons.OK)


            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub sbOk_Click(sender As Object, e As EventArgs) Handles sbOk.Click
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As String
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim sDatFilename As String
        Dim indx As Integer
        Dim indx2 As Integer
        Dim lCount As Long
        Dim swDatFile As System.IO.StreamWriter
        Dim sTag As String
        Dim sFormatedOptions As String

        Try

            sDatFilename = NormalizePath(App_Path) & cbeMachine.Text & ".dat"

            lCount = vgNestSettings.Rows.Count

            swDatFile = My.Computer.FileSystem.OpenTextFileWriter(sDatFilename, False)

            For indx = 0 To lCount - 1

                swDatFile.WriteLine("//=== " & vgNestSettings.Rows(indx).Properties.Caption)

                For indx2 = 0 To vgNestSettings.Rows(indx).ChildRows.Count - 1
                    sTag = vgNestSettings.Rows(indx).ChildRows(indx2).Tag

                    my_DatVarName = GetValueFromDelimitedData(sTag, "DatVarName", "")
                    my_DialogDisplay = GetValueFromDelimitedData(sTag, "DialogDisplay", "")
                    my_VBValue = vgNestSettings.Rows(indx).ChildRows(indx2).Properties.Value   'GetValueFromDelimitedData(sTag, "VBValue", "")
                    my_CValue = GetValueFromDelimitedData(sTag, "CValue", "")
                    my_CVarName = GetValueFromDelimitedData(sTag, "CVarName", "")
                    my_DataType = TranslateDataType(GetValueFromDelimitedData(sTag, "VarDataType", ""))
                    my_RecodID = GetValueFromDelimitedData(sTag, "nRecordID", "")
                    my_sOptions = GetValueFromDelimitedData(sTag, "Options", "")


                    Select Case CLng(GetValueFromDelimitedData(sTag, "VarDataType", ""))
                        Case DB_DCOMBO

                            sFormatedOptions = Replace(my_sOptions, ";", "|")

                            swDatFile.WriteLine(my_DatVarName & " | " & my_DataType & " | " & my_DialogDisplay & " | " & my_VBValue & "|" & sFormatedOptions)

                        Case DB_BOOL

                            my_VBValue = IIf(UCase(my_VBValue) = "FALSE", 0, 1)
                            swDatFile.WriteLine(my_DatVarName & " | " & my_DataType & " | " & my_DialogDisplay & " | " & my_VBValue)

                        Case Else

                            swDatFile.WriteLine(my_DatVarName & " | " & my_DataType & " | " & my_DialogDisplay & " | " & my_VBValue)

                    End Select



                Next

            Next

            swDatFile.Close()

            Me.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Function TranslateDataType(nDataType As Integer) As String

        TranslateDataType = Nothing

        Try

            Select Case nDataType
                Case DB_HEADER
                    TranslateDataType = "nop"

                Case DB_NOP
                    TranslateDataType = "nop"

                Case DB_INT
                    TranslateDataType = "int"

                Case DB_DBL
                    TranslateDataType = "dbl"

                Case DB_STR
                    TranslateDataType = "str"

                Case DB_BOOL
                    TranslateDataType = "bool"

                Case DB_COMBO
                    TranslateDataType = "combo"

                Case DB_DCOMBO
                    TranslateDataType = "dcombo"

                Case DB_FILE
                    TranslateDataType = "str"

                Case DB_TOOL
                    TranslateDataType = "tool"

            End Select

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Sub sbSeleectAll_Click(sender As Object, e As EventArgs) Handles sbSeleectAll.Click
        Dim ni As Integer

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            For ni = 0 To lstDefaultSettings.ItemCount - 1
                CreateRows(lstTemp4.Items(ni), lstTemp2.Items(ni))

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub sbLeft_Click(sender As Object, e As EventArgs) Handles sbLeft.Click

        Try

            If (vgNestSettings.IsCategoryRow(vgNestSettings.FocusedRow) = False) Then

                Dim row As DevExpress.XtraVerticalGrid.Rows.BaseRow = vgNestSettings.FocusedRow
                row.ParentRow.ChildRows.Remove(row)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub sbRight_Click(sender As Object, e As EventArgs) Handles sbRight.Click
        Dim ni As Integer
        Dim nItemIndex As Integer
        Dim foo As String

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            For ni = 0 To lstDefaultSettings.SelectedItems.Count - 1
                foo = lstDefaultSettings.SelectedItems(ni).ToString()
                nItemIndex = lstDefaultSettings.SelectedIndices(ni)

                If (CheckEntryToGrid(foo) = False) Then

                    CreateRows(lstTemp4.Items(nItemIndex), lstTemp2.Items(nItemIndex))


                End If

            Next


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub GetDefaultValuesFromMachineDat(sMachineDatFile As String)
        Dim line As String = Nothing
        Dim sCategory As String = Nothing
        Dim nCatNameStart As Integer

        Try
            vgNestSettings.Rows.Clear()

            'MessageBox.Show("we are looking for: " + sMachineDatFile)
            If (FileExists(sMachineDatFile) = True) Then

                Using sr As StreamReader = New StreamReader(sMachineDatFile)

                    line = sr.ReadLine()

                    While (line <> Nothing)
                        If (InStr(1, line, "//=") > 0) Then

                            nCatNameStart = line.LastIndexOf("=")


                            sCategory = Trim(line.Substring(nCatNameStart + 1))

                        End If

                        If Len(line) > 3 And InStr(1, line, "glb.") > 0 Then
                            CreateRows(sCategory, line)

                        End If
                        line = sr.ReadLine()
                    End While

                    sr.Dispose()

                End Using

            End If

        Catch ex As Exception

            MessageBox.Show("GetDefaultValuesFromGenericDat: " & ex.Message)

        End Try
    End Sub

    Private Sub cbeMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMachine.SelectedIndexChanged
        GetDefaultValuesFromMachineDat(cbeMachine.Text)
    End Sub

    Private Function CheckEntryToGrid(sEntry As String) As Boolean

        CheckEntryToGrid = False

        Try

            For Each row As CategoryRow In vgNestSettings.Rows

                For Each childRow As EditorRow In row.ChildRows

                    If (sEntry = childRow.Properties.Caption) Then

                        CheckEntryToGrid = True
                        Exit Function

                    End If
                Next

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Function


End Class