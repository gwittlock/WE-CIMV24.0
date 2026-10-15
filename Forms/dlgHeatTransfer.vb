Imports DevExpress.Spreadsheet
Imports System.Data.OleDb
Imports System.IO
Imports System.Data
Imports System
Imports System.Windows.Forms
Imports ADOX
Imports DevExpress.XtraEditors.Controls

Public Class dlgHeatTransfer
    Dim sMDBFile As String
    Dim sMRP_File As String


    Private Sub beMaterialDB_EditValueChanged(sender As Object, e As EventArgs) Handles beMaterialDB.EditValueChanged

    End Sub

    Private Sub beMaterialDB_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beMaterialDB.ButtonClick
        Using sMRP_FileOpen As New OpenFileDialog


            sMRP_FileOpen.Filter = "MDB files (*.mdb)|*.mdb"
            sMRP_FileOpen.FilterIndex = 1
            sMRP_FileOpen.RestoreDirectory = True

            If sMRP_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sMRP_File = sMRP_FileOpen.FileName
                beMaterialDB.Text = sMRP_File

                ' beMRPFilename.ToolTip = sMRP_File
            End If
        End Using

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim nPartNo
        Dim sqlFrom_MatTypes As String
        Dim m_dsFrom_MatTypes As New System.Data.DataSet

        Dim m_cnFrom_MatTypes As New OleDb.OleDbConnection
        Dim m_daFrom_MatTypes As New OleDb.OleDbDataAdapter
        Dim m_cmdFrom_MatTypesGetID As New OleDbCommand
        Dim m_csFrom_MatTypes As String
        Dim sFrom_MatTypesDescrip As String
        Dim i As Integer
        Dim sqlCMDB_MatTypes As String
        Dim m_dsCMDB_MatTypes As New System.Data.DataSet
        Dim m_cnCMDB_MatTypes As New OleDb.OleDbConnection
        Dim m_daCMDB_MatTypes As New OleDb.OleDbDataAdapter
        Dim m_csCMDB_MatTypes As String
        Dim m_maxidCMDBMatTypes As Long
        Dim m_cmdCMDB_MatTypesGetID As New OleDbCommand
        Dim m_dsCMDB_MatInv As New System.Data.DataSet
        Dim m_cnCMDB_MatInv As New OleDb.OleDbConnection
        Dim m_daCMDB_MatInv As New OleDb.OleDbDataAdapter
        Dim m_cmdCMDB_MatInvGetID As New OleDbCommand
        Dim m_ds As New System.Data.DataSet
        Dim m_cn As New OleDb.OleDbConnection

        m_csCMDB_MatTypes = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        m_cnCMDB_MatTypes = New OleDbConnection(m_csCMDB_MatTypes)

        m_cnCMDB_MatTypes.Open()

        m_csFrom_MatTypes = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & beMaterialDB.EditValue & "';"

        sqlFrom_MatTypes = "Select Mat_Sizes.* From Mat_Sizes Where (Mat_Sizes.ID > 0 ) Order By Mat_Sizes.[Part No]"

        m_cnFrom_MatTypes = New OleDbConnection(m_csFrom_MatTypes)

        m_cnFrom_MatTypes.Open()

        m_daFrom_MatTypes = New OleDbDataAdapter(sqlFrom_MatTypes, m_csFrom_MatTypes)

        m_daFrom_MatTypes.Fill(m_dsFrom_MatTypes)



        lbcMatTypes.Items.Clear()

        For i = 0 To m_dsFrom_MatTypes.Tables(0).Rows.Count - 1
            nPartNo = CLng(m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No"))
            If (CheckEntryToListBox(nPartNo, lbcMatTypes) = False) Then
                lbcMatTypes.Items.Add(m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No"))
                sFrom_MatTypesDescrip = m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No")


                sqlCMDB_MatTypes = "INSERT INTO [Material Types] ([Description],[Display] ) VALUES('" & sFrom_MatTypesDescrip & "','" & sFrom_MatTypesDescrip & "')"

                'm_daCMDB_MatTypes.InsertCommand = New OleDbCommand(sqlCMDB_MatTypes, m_cnCMDB_MatTypes)

                'm_daCMDB_MatTypes.InsertCommand.ExecuteNonQuery()

                'm_cmdCMDB_MatTypesGetID.Connection = m_cnCMDB_MatTypes
                'm_cmdCMDB_MatTypesGetID.CommandText = "SELECT MAX(ID) FROM [Material Types]"

                'm_maxidCMDBMatTypes = m_cmdCMDB_MatTypesGetID.ExecuteScalar

            End If


            LookUpAndSaveMat(nPartNo, m_maxidCMDBMatTypes)

            'm_cs = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & beMaterialDB.EditValue & "';"

            'sql = "Select Mat_Sizes.* From Mat_Sizes Where (Mat_Sizes.[Part No] = " & nPartNo & " ) Order By Mat_Sizes.[Sheet Thickness]"

            'm_cn = New OleDbConnection(m_cs)

            'm_cn.Open()

            'm_da = New OleDbDataAdapter(sql, m_cs)

            'm_da.Fill(m_ds)

            'MsgBox("The row count is < " & m_ds.Tables(0).Rows.Count & " >")
            'For ni = 0 To m_ds.Tables(0).Rows.Count - 1

            '    If (IsDBNull(m_ds.Tables(0).Rows(ni).Item("Sheet Size")) = False) Then
            '        sPieces = Split(m_ds.Tables(0).Rows(ni).Item("Sheet Size"), "x")

            '        dLength = CDbl(sPieces(1))
            '        dWidth = CDbl(sPieces(0))

            '    Else

            '        dLength = 0
            '        dWidth = 0

            '    End If


            '    'sSheetName

            '    If (IsDBNull(m_ds.Tables(0).Rows(ni).Item("Sheet Thickness")) = False) Then
            '        dThickness = m_ds.Tables(0).Rows(ni).Item("Sheet Thickness")
            '    Else
            '        dThickness = 0
            '    End If



            '    If (IsDBNull(m_ds.Tables(0).Rows(ni).Item("Mat'l Weight Per SQ IN")) = False) Then
            '        dWeight = m_ds.Tables(0).Rows(ni).Item("Mat'l Weight Per SQ IN")
            '    Else
            '        dWeight = 0
            '    End If

            '    dCost = 0

            '    If (IsDBNull(m_ds.Tables(0).Rows(ni).Item("Name/Description")) = False) Then
            '        sSheetName = m_ds.Tables(0).Rows(ni).Item("Name/Description")
            '    Else
            '        sSheetName = "none"
            '    End If


            '    lReturn = SaveMat(sSheetName, m_maxidCMDBMatTypes, dLength, dWidth, dThickness, dWeight, dCost)


            '    m_cn.Close()
            '    m_da.Dispose()
            '    m_ds.Dispose()

            '    m_cn = Nothing
            '    m_da = Nothing
            '    m_ds = Nothing

            '    m_cs = Nothing


            'Next

        Next

        m_dsFrom_MatTypes.Dispose()

        m_daFrom_MatTypes.Dispose()

        m_cnFrom_MatTypes.Dispose()
        m_cnFrom_MatTypes.Close()


    End Sub

    Private Sub beCFGManDB_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles beCFGManDB.ButtonClick
        Using sCMDB_FileOpen As New OpenFileDialog


            sCMDB_FileOpen.Filter = "MDB files (*.mdb)|*.mdb"
            sCMDB_FileOpen.FilterIndex = 1
            sCMDB_FileOpen.RestoreDirectory = True

            If sCMDB_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sMDBFile = sCMDB_FileOpen.FileName
                beCFGManDB.Text = sMDBFile

                ' beMRPFilename.ToolTip = sMRP_File
            End If
        End Using

    End Sub

    Public Function SaveMat(ByVal sNewMaterialName As String,
                            ByVal nTheMaterialTypeID As Long,
                            ByVal dLength As Double,
                            ByVal dWidth As Double,
                            ByVal dThickness As Double,
                            ByVal dWeight As Double,
                            ByVal dCost As Double) As Long

        Dim m_cnMaterial As New OleDb.OleDbConnection
        Dim m_daMaterial As OleDb.OleDbDataAdapter
        Dim m_cbMaterial As OleDb.OleDbCommandBuilder
        Dim m_dtMaterial As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtMaterial.NewRow()
        Dim cmdGetID As New OleDbCommand

        sql = "SELECT [Material Inventory].* FROM [Material Inventory]"

        Try

            m_cnMaterial.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathCMDB()
            m_cnMaterial.Open()
            m_daMaterial = New OleDbDataAdapter(sql, m_cnMaterial)
            m_cbMaterial = New OleDbCommandBuilder(m_daMaterial)
            m_cbMaterial.QuotePrefix = "["
            m_cbMaterial.QuoteSuffix = "]"
            m_daMaterial.Fill(m_dtMaterial)

            drNewRow("Type ID") = nTheMaterialTypeID
            drNewRow("Description") = sNewMaterialName
            drNewRow("Length") = dLength
            drNewRow("Width") = dWidth
            drNewRow("Thickness") = dThickness
            drNewRow("Weight") = dWeight
            drNewRow("Quantity") = -1
            drNewRow("Cost Per Unit") = dCost


            m_dtMaterial.Rows.Add(drNewRow)
            m_daMaterial.Update(m_dtMaterial)


            cmdGetID.Connection = m_cnMaterial
            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Material Inventory]"



            SaveMat = cmdGetID.ExecuteScalar
            m_dtMaterial.Dispose()
            m_daMaterial.Dispose()

            m_cnMaterial.Close()

            ds.Dispose()
            m_cnMaterial.Dispose()
            m_cnMaterial.Close()


            If m_dtMaterial IsNot Nothing Then m_dtMaterial = Nothing
            If m_daMaterial IsNot Nothing Then m_daMaterial = Nothing

        Catch ex As Exception

            SaveMat = -1

            MessageBox.Show("SaveMaterial: " & ex.Message)

        End Try



    End Function
    Public Sub LookUpAndSaveMat(sPartNo As String, nMaxid As Long)
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim dLength As Double
        Dim dWidth As Double
        Dim dThickness As Double
        Dim dWeight As Double
        Dim dCost As Double
        Dim sSheetName As String
        Dim sPieces()
        Dim sql As String

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & beMaterialDB.EditValue & "';"

        sql = "Select Mat_Sizes.* From Mat_Sizes Where (Mat_Sizes.[Part No] = " & sPartNo & " ) Order By Mat_Sizes.[Thickness]"
        sql = "Select [Brass Coil].* From [Brass Coil] Where ([Brass Coil].[Part No] = " & sPartNo & " ) Order By [Brass Coil].Thickness"
        connection = New OleDbConnection(connetionString)

        connection.Open()

        oledbAdapter = New OleDbDataAdapter(sql, connetionString)

        oledbAdapter.Fill(ds)

        MsgBox("The row count is < " & ds.Tables(0).Rows.Count & " >")
        For ni = 0 To ds.Tables(0).Rows.Count - 1

            dLength = CDbl(1.0)
            dWidth = CDbl(ds.Tables(0).Rows(ni).Item("Width"))
            dThickness = ds.Tables(0).Rows(ni).Item("Thickness")
            'If (IsDBNull(ds.Tables(0).Rows(ni).Item("Sheet Size")) = False) Then
            '    sPieces = Split(ds.Tables(0).Rows(ni).Item("Sheet Size"), "x")

            '    dLength = CDbl(sPieces(1))
            '    dWidth = CDbl(sPieces(0))

            'Else

            '    dLength = 0
            '    dWidth = 0

            'End If


            'sSheetName

            'If (IsDBNull(ds.Tables(0).Rows(ni).Item("Sheet Thickness")) = False) Then
            '    dThickness = ds.Tables(0).Rows(ni).Item("Sheet Thickness")
            'Else
            '    dThickness = 0
            'End If



            'If (IsDBNull(ds.Tables(0).Rows(ni).Item("Mat'l Weight Per SQ IN")) = False) Then
            '    dWeight = ds.Tables(0).Rows(ni).Item("Mat'l Weight Per SQ IN")
            'Else
            dWeight = 0
            'End If

            dCost = 0

            'If (IsDBNull(ds.Tables(0).Rows(ni).Item("Name/Description")) = False) Then
            '    sSheetName = ds.Tables(0).Rows(ni).Item("Name/Description")
            'Else
            '    sSheetName = "none"
            'End If

            If (IsDBNull(ds.Tables(0).Rows(ni).Item("Mat_Type")) = False) Then
                sSheetName = "Brass Coil " & dLength & " X " & dWidth & " X " & dThickness
            End If
            lReturn = SaveMat(sSheetName, nMaxid, dLength, dWidth, dThickness, dWeight, dCost)
        Next

        ds.Dispose()
        connection.Dispose()
        connection.Close()


        If connection IsNot Nothing Then connection = Nothing
        If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

    End Sub

    Private Sub sbFindFIles_Click(sender As Object, e As EventArgs) Handles sbFindFIles.Click
        Dim ni As Integer

        For ni = 0 To ListBoxControl1.Items.Count - 1
            FindAllFiles(fcbRemnantPath.Text, ListBoxControl1.Items(ni).ToString & "*.*", lbFoundFIles, lbNotFound, "")
        Next

        Dim sw As New StreamWriter(Application.StartupPath & "\DeBug\ApiCopyFIles.bat", True)
        For ni = 0 To lbFoundFIles.Items.Count - 1
            sw.WriteLine("copy " & QStr(lbFoundFIles.Items(ni).ToString) & " " & QStr(Application.StartupPath & "\Debug"))
        Next
        sw.Close()

    End Sub

    Private Sub beCFGManDB_EditValueChanged(sender As Object, e As EventArgs) Handles beCFGManDB.EditValueChanged

    End Sub

    Private Sub fcbRemnantPath_EditValueChanged(sender As Object, e As EventArgs) Handles fcbRemnantPath.EditValueChanged

    End Sub

    Private Sub fcbRemnantPath_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles fcbRemnantPath.ButtonClick
        Dim m_folderDialog As New FolderBrowserDialog()

        Try

            m_folderDialog.SelectedPath = fcbRemnantPath.Text

            If m_folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                fcbRemnantPath.Text = m_folderDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("fcbRemnantPath_ButtonClick Error: " & ex.Message)

        End Try

    End Sub

    Private Sub sbAddStations_Click(sender As Object, e As EventArgs) Handles sbAddStations.Click
        Dim sql As String
        Dim sql2 As String
        Dim ds As DataTable
        Dim ds2 As DataTable
        Dim connection As New OleDbConnection
        Dim oledbAdapter As New OleDbDataAdapter
        Dim connetionString As String
        Dim indx As Integer


        Try
            lbFoundFIles.Items.Clear()




            sql = "Select [Station Configuration].* From [Station Configuration] Where ([Station Configuration].[Machine ID] = 15 )"

            sql2 = "Select Standard_Tooling.* From Standard_Tooling"

            ds = ConnectToCMDB(sql)



            For indx = 0 To ds.Rows.Count - 1

                lbcTlCurrStations.Items.Add(ds.Rows(indx).Item("NC Code Number"))


            Next

            DatabaseClose()

            ds.Dispose()

            lbcTlCurrStations.Refresh()

            sql2 = "Select Tooling.* From Tooling"

            ds2 = ConnectToOtherMDB("C:\1wittlockeng\Customers\APIHeatTransfer\Standard_Punch_Tooling\Vipros Turret Standard_2022_A1.mdb", sql2)
            For indx = 0 To ds2.Rows.Count - 1
                If (CheckEntryToListBox(ds2.Rows(indx).Item("Program_Station").ToString, lbcTlCurrStations) = False) Then

                    lbcTlStationsToAdd.Items.Add(ds2.Rows(indx).Item("Program_Station"))

                    AddStations(ds2.Rows(indx).Item("Program_Station"), ds2.Rows(indx).Item("Station_Size"))

                    lbcTlDescrip.Items.Add(ds2.Rows(indx).Item("Tool_Size") & " " & ds2.Rows(indx).Item("Tool_Type"))
                End If

            Next
            ds2.Dispose()

            DatabaseClose()

            CheckAvailableTooling()
            MessageBox.Show("We Are Done")

        Catch ex As Exception

            MessageBox.Show("sbAddStations_Click:  " & ex.Message)
            If connection IsNot Nothing Then connection = Nothing
            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
        Finally

            If ds IsNot Nothing Then ds = Nothing

        End Try


    End Sub
    Private Sub ExportOneTable(sMDB_Name As String, sMDB_Table As String)
        Dim connetionString As String
        Dim m_cnSettings As New OleDb.OleDbConnection
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim strExcelFile As String

        Dim sql As String

        strExcelFile = PathRemoveExt(sMDB_Name) & ".xls"

        Try
            'ConditionalFileDelete(strExcelFile)


            sql = "SELECT * INTO [" & sMDB_Table & "] IN '" & strExcelFile & "' 'Excel 8.0;' FROM " & sMDB_Table

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sMDB_Name & "';"

            m_cnSettings = New OleDbConnection(connetionString)

            m_cnSettings.Open()

            m_daSettings.SelectCommand = New OleDbCommand(sql, m_cnSettings)

            m_daSettings.SelectCommand.ExecuteNonQuery()

            m_cnSettings.Dispose()
            m_cnSettings.Close()
            m_cnSettings.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub AddStations(sStaionNum As String, sStationSize As String)
        Dim sql As String
        Dim dtStationTable As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim ni As Integer
        Dim drCopiedRow As DataRow
        Dim nRowHandle As Long
        Dim stheMachineID As String

        Try

            stheMachineID = RegGetString("Global", "MachineID", 0)
            sql = "Select * From [Station Configuration]"

            dtStationTable = ConnectToCMDB(sql)

            drCopiedRow = dtStationTable.NewRow()

            drCopiedRow("Machine ID") = 15
            drCopiedRow("WorkPlane ID") = 1
            drCopiedRow("NC Code Number") = sStaionNum
            drCopiedRow("Station Location X") = 0
            drCopiedRow("Station Location Y") = 0
            drCopiedRow("Auto Index") = False
            drCopiedRow("Station Size") = sStationSize
            drCopiedRow("Primary Code") = 0
            drCopiedRow("Secondary Code") = 0

            dtStationTable.Rows.Add(drCopiedRow)
            m_daCMDB.Update(dtStationTable)


            dtStationTable.Dispose()
            DatabaseClose()

        Catch ex As Exception

            MessageBox.Show("AddStations:  " & ex.Message)

        End Try

    End Sub

    Private Sub CheckAvailableTooling()
        Dim sql As String
        Dim sql3 As String
        Dim dtToolingTable As DataTable
        Dim cmdGetID As New OleDbCommand
        Dim ni As Integer
        Dim drCopiedRow As DataRow
        Dim nRowHandle As Long
        Dim stheMachineID As String
        Dim nToolType As Integer
        Dim sPieces() As String
        Dim dDiameter As String
        Dim dLength As String
        Dim dWidth As String
        Dim dAngle As String
        Dim SDescription As String
        Dim sFields As String
        Dim sValues As String
        Dim sStationSIze As String
        Dim connetionString As String
        Dim m_cnToolCrib As New OleDb.OleDbConnection
        Dim m_daToolCrib As New OleDb.OleDbDataAdapter
        Dim nID As Long
        Dim nStationID As Long


        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

            m_cnToolCrib = New OleDbConnection(connetionString)

            stheMachineID = RegGetString("Global", "MachineID", 0)
            sql = "Select Tooling.* From Tooling"

            dtToolingTable = ConnectToOtherMDB("C:\1wittlockeng\Customers\APIHeatTransfer\Standard_Punch_Tooling\Vipros Turret Standard_2022_A1.mdb", sql)


            'dtToolingTable = ConnectToCMDB(sql)

            For ni = 0 To dtToolingTable.Rows.Count - 1

                sPieces = Split(dtToolingTable.Rows(ni).Item("Tool_Size"), "x")

                If (IsDBNull(dtToolingTable.Rows(ni).Item("Tool_ Description")) = False) Then
                    SDescription = dtToolingTable.Rows(ni).Item("Tool_ Description") & " " & dtToolingTable.Rows(ni).Item("ANGLE") & " DEG."
                Else
                    SDescription = dtToolingTable.Rows(ni).Item("Tool_Size") & " " & dtToolingTable.Rows(ni).Item("Tool_Type") & " " & " " & dtToolingTable.Rows(ni).Item("ANGLE") & " DEG."
                End If

                SDescription = "'" & SDescription & "'"

                sStationSIze = dtToolingTable.Rows(ni).Item("Station_Size")

                Select Case UCase(dtToolingTable.Rows(ni).Item("Tool_Type"))
                    Case "OB-RD"
                        nToolType = 18
                        dWidth = sPieces(0)
                        dLength = sPieces(1)

                        sFields = "[Type ID], [Color],[Corner Radius], [Description], [Doff], [Length],[Reqd Auto Index],[Reqd Station Size], [Width]"

                        sValues = nToolType & ", 3145645,0," & SDescription & ",0," & dLength & ",0," & sStationSIze & "," & dWidth

                    Case "RD"
                        nToolType = 15
                        dDiameter = dtToolingTable.Rows(ni).Item("Tool_Size")

                        SDescription = Replace(SDescription, " " & dtToolingTable.Rows(ni).Item("ANGLE") & " DEG.", "")

                        sFields = "[Type ID],[Color],[Description],[Diameter],[Doff],[Reqd Station Size]"

                        sValues = nToolType & ", 10156544," & SDescription & "," & dDiameter & ",0," & sStationSIze

                        'sValues = nToolType & ", 10156544,'0','" & SDescription & "','" & dDiameter & "0','" & sStationSIze & "'"

                    Case "SQ"
                        nToolType = 16
                        dWidth = dtToolingTable.Rows(ni).Item("Tool_Size")

                        'sFields = "[Type ID],[Color],[Corner Radius],[Description],[Doff],[Reqd Auto Index],[Reqd Station Size],[Width]"
                        sFields = "[Type ID],[Color],[Corner Radius],[Description],[Doff],[Reqd Auto Index],[Reqd Station Size], [Width]"

                        sValues = nToolType & ", 13382297,0," & SDescription & ",0,0," & sStationSIze & "," & dWidth

                        'sValues = nToolType & ",13382297 ,'0','" & " SDescription','0','0'" & sStationSIze & "','" & sStationSIze & "'" & dWidth & "'"

                    Case "RT"
                        nToolType = 17
                        dWidth = sPieces(0)
                        dLength = sPieces(1)

                        'sFields = "[Type ID], [Color],[Corner Radius], [Description], [Doff], [Length],[Reqd Auto Index],[Reqd Station Size], [Width]"

                        'sValues = nToolType & ", 16776960,'0','" & SDescription & "','0','" & dLength & "',0,'" & sStationSIze & "','" & dWidth & "'"

                        sFields = "[Type ID], [Color],[Corner Radius], [Description], [Doff], [Length],[Reqd Auto Index],[Reqd Station Size], [Width]"

                        sValues = nToolType & ", 16776960,0," & SDescription & ",0," & dLength & ",0," & sStationSIze & "," & dWidth

                    Case Else
                        nToolType = 29

                End Select

                If nToolType > 14 And nToolType < 19 Then
                    m_cnToolCrib.Open()

                    sql3 = "INSERT INTO [Tool Crib] (" & sFields & " ) VALUES(" & sValues & ")"

                    m_daToolCrib.InsertCommand = New OleDbCommand(sql3, m_cnToolCrib)

                    m_daToolCrib.InsertCommand.ExecuteNonQuery()

                    cmdGetID.Connection = m_cnToolCrib
                    cmdGetID.CommandText = "SELECT MAX(ID) FROM [Tool Crib]"

                    nID = cmdGetID.ExecuteScalar

                    m_cnToolCrib.Close()
                    nStationID = GetStationIDFromStationNum(dtToolingTable.Rows(ni).Item("Program_Station"))
                    AssignToolToStation(324, nStationID, dtToolingTable.Rows(ni).Item("ANGLE"), False, nID)
                End If


            Next

            'drCopiedRow = dtToolingTable.NewRow()

            'drCopiedRow("Machine ID") = stheMachineID
            'drCopiedRow("WorkPlane ID") = 1
            'drCopiedRow("NC Code Number") = sStaionNum
            'drCopiedRow("Station Location X") = 0
            'drCopiedRow("Station Location Y") = 0
            'drCopiedRow("Auto Index") = False
            'drCopiedRow("Station Size") = 0
            'drCopiedRow("Primary Code") = 0
            'drCopiedRow("Secondary Code") = 0

            'dtToolingTable.Rows.Add(drCopiedRow)
            'm_daCMDB.Update(dtToolingTable)


            dtToolingTable.Dispose()
            DatabaseClose()


        Catch ex As Exception

            MessageBox.Show("CheckAvailableTooling:  " & ex.Message)


        Finally

            If dtToolingTable IsNot Nothing Then dtToolingTable = Nothing

        End Try
    End Sub

    Private Function GetStationIDFromStationNum(nProgNum As Long) As Long
        Dim sql As String
        Dim sql2 As String
        Dim ds As DataTable
        Dim ds2 As DataTable
        Dim connection As New OleDbConnection
        Dim oledbAdapter As New OleDbDataAdapter
        Dim connetionString As String
        Dim indx As Integer

        Try
            sql = "Select [Station Configuration].* From [Station Configuration] Where ([Station Configuration].[Machine ID] = 15 ) And ([Station Configuration].[NC Code Number] = " & nProgNum & " )"
            ds = ConnectToCMDB(sql)

            If (ds.Rows.Count > 0) Then
                For indx = 0 To ds.Rows.Count - 1
                    GetStationIDFromStationNum = ds.Rows(indx).Item("ID")
                Next
            End If

            DatabaseClose()

        Catch ex As Exception

        End Try
    End Function

    Private Sub sbBrass_Click(sender As Object, e As EventArgs) Handles sbBrass.Click
        Dim nPartNo
        Dim sqlFrom_MatTypes As String
        Dim m_dsFrom_MatTypes As New System.Data.DataSet

        Dim m_cnFrom_MatTypes As New OleDb.OleDbConnection
        Dim m_daFrom_MatTypes As New OleDb.OleDbDataAdapter
        Dim m_cmdFrom_MatTypesGetID As New OleDbCommand
        Dim m_csFrom_MatTypes As String
        Dim sFrom_MatTypesDescrip As String
        Dim i As Integer
        Dim sqlCMDB_MatTypes As String
        Dim m_dsCMDB_MatTypes As New System.Data.DataSet
        Dim m_cnCMDB_MatTypes As New OleDb.OleDbConnection
        Dim m_daCMDB_MatTypes As New OleDb.OleDbDataAdapter
        Dim m_csCMDB_MatTypes As String
        Dim m_maxidCMDBMatTypes As Long
        Dim m_cmdCMDB_MatTypesGetID As New OleDbCommand
        Dim m_dsCMDB_MatInv As New System.Data.DataSet
        Dim m_cnCMDB_MatInv As New OleDb.OleDbConnection
        Dim m_daCMDB_MatInv As New OleDb.OleDbDataAdapter
        Dim m_cmdCMDB_MatInvGetID As New OleDbCommand
        Dim m_ds As New System.Data.DataSet
        Dim m_cn As New OleDb.OleDbConnection

        m_csCMDB_MatTypes = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        m_cnCMDB_MatTypes = New OleDbConnection(m_csCMDB_MatTypes)

        m_cnCMDB_MatTypes.Open()

        m_csFrom_MatTypes = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & beMaterialDB.EditValue & "';"

        sqlFrom_MatTypes = "Select [Brass Coil].* From [Brass Coil] Where ([Brass Coil].[Mat_Type] = 'BRASS COIL' )"

        m_cnFrom_MatTypes = New OleDbConnection(m_csFrom_MatTypes)

        m_cnFrom_MatTypes.Open()

        m_daFrom_MatTypes = New OleDbDataAdapter(sqlFrom_MatTypes, m_csFrom_MatTypes)

        m_daFrom_MatTypes.Fill(m_dsFrom_MatTypes)



        lbcMatTypes.Items.Clear()

        For i = 0 To m_dsFrom_MatTypes.Tables(0).Rows.Count - 1



            If IsDBNull(m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No")) = False Then
                nPartNo = CLng(m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No"))
                If (CheckEntryToListBox(nPartNo, lbcMatTypes) = False) Then
                    lbcMatTypes.Items.Add(m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No"))
                    sFrom_MatTypesDescrip = m_dsFrom_MatTypes.Tables(0).Rows(i).Item("Part No")


                    sqlCMDB_MatTypes = "INSERT INTO [Material Types] ([Description],[Display] ) VALUES('" & sFrom_MatTypesDescrip & "','" & sFrom_MatTypesDescrip & "')"

                    m_daCMDB_MatTypes.InsertCommand = New OleDbCommand(sqlCMDB_MatTypes, m_cnCMDB_MatTypes)

                    m_daCMDB_MatTypes.InsertCommand.ExecuteNonQuery()

                    m_cmdCMDB_MatTypesGetID.Connection = m_cnCMDB_MatTypes
                    m_cmdCMDB_MatTypesGetID.CommandText = "SELECT MAX(ID) FROM [Material Types]"

                    m_maxidCMDBMatTypes = m_cmdCMDB_MatTypesGetID.ExecuteScalar

                End If

                LookUpAndSaveMat(nPartNo, m_maxidCMDBMatTypes)
            End If
        Next
    End Sub
End Class