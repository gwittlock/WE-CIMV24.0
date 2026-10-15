Imports DevExpress.XtraGrid.Views.Grid
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class dlgNewFreightCarAM
    Dim sGAG_DB As String
    Dim dGagloc As Double
    Dim nGagNumber As Integer
    Dim dGagPunchSize As Double
    Dim dtGags As DataTable = Nothing
    Private sPieces() As String
    Private nBlockNums As Long = 0
    Dim d80Percent As Double
    Dim dStoredX As String
    Dim gridDatalist As New BindingList(Of GagInfo)
    Dim bFirstX As Boolean = False

    Private Sub dlgNewFreightCarAM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ugcGags.DataSource.Clear()
        ubgStationsView.DataSource.clear()

    End Sub

    Private Sub dlgNewFreightCarAM_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            fcbScodeFile.Text = RegGetString("Customizations", "Gag_Java", App_Path & "\Codegen\*.java")
            beExportTo.Text = PathRemoveExt(m_curr_file) & ".cnc"
            teProgression.Text = RegGetString("Customizations", "Progression", "1.0")

            sGAG_DB = App_Path & "\Gag_Config" & "\" & PathFile(m_curr_file) & ".gag"

            Me.Text = "Current Gag Locations From < " & sGAG_DB & " >"

            If (FileExists(sGAG_DB)) Then

                LoadGagLocations(sGAG_DB)

            Else

                CreateNewGagLocations()

            End If

        Catch ex As Exception
            MessageBox.Show("dlgNewFreightCarAM_Load: " & ex.Message)
        End Try
    End Sub

    Sub LoadGagLocations(sGagdb As String)
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim cmd As OleDbCommand = Nothing

        sql = "Select [Gags].* From [Gags]"


        Try

            ugcGags.DataSource.Clear()

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sGagdb & "';"

            connection = New OleDbConnection(connetionString)

            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            If (ds.Tables(0).Rows.Count > 0) Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    nGagNumber = ds.Tables(0).Rows(i).Item("GagNumber")
                    dGagloc = ds.Tables(0).Rows(i).Item("Yloc")
                    dGagPunchSize = ds.Tables(0).Rows(i).Item("PunchSize")

                    ugcGags.DataSource.AddRow(New Object() {nGagNumber, dGagloc, dGagPunchSize})

                Next


            End If

            ugcGags.RefreshDataSource()

            If connection IsNot Nothing Then connection = Nothing
            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing
            If ds IsNot Nothing Then ds = Nothing

        Catch ex As Exception
            MessageBox.Show("LoadGagLocations: " & ex.Message)
        End Try

    End Sub

    Sub CreateNewGagLocations()
        Dim I As Long

        Try

            For I = 1 To 48

                ugcGags.DataSource.AddRow(New Object() {I, 0, 0})
            Next

        Catch ex As Exception
            MessageBox.Show("CreateNewGagLocations: " & ex.Message)
        End Try
    End Sub

    Private Sub bbNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Dim cat As ADOX.Catalog = New ADOX.Catalog()
        Dim Gag_FileSave As New SaveFileDialog
        dtGags = New DataTable()
        Dim sTablename As String = "Gags"
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim sql As String
        Dim m_daSettings As New OleDb.OleDbDataAdapter


        Try

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            ugcGags.DataSource.Clear()

            Gag_FileSave.Filter = "GAG files (*.gag)|*.gag"
            Gag_FileSave.FilterIndex = 1
            Gag_FileSave.RestoreDirectory = True
            Gag_FileSave.InitialDirectory = App_Path & "\Gag_Config" & "\"

            If Gag_FileSave.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sGAG_DB = Gag_FileSave.FileName

                If (FileExists(sGAG_DB) = True) Then

                    ' ConditionalFileDelete(sGAG_DB)

                End If

                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                      "Data Source=" & sGAG_DB & ";" & _
                      "Jet OLEDB:Engine Type=5")

                cat.ActiveConnection.close()

                Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & sGAG_DB)


                Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename & _
                                                        "] ([ID] AUTOINCREMENT PRIMARY KEY  , " & _
                                                        "[GagNumber] INTEGER, " & _
                                                        "[Yloc] FLOAT," & _
                                                        "[PunchSize] FLOAT )", connection)

                connection.Open()
                cmd.ExecuteNonQuery()

                sFieldNames = "[GagNumber]," & _
                                "[Yloc]," & _
                                "[PunchSize]"



                For i = 1 To 48

                    sFieldValues = "'" & i & "','" & 0 & "','" & 0 & "'"

                    sql = "INSERT INTO [Gags] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

                    m_daSettings.InsertCommand = New OleDbCommand(sql, connection)

                    m_daSettings.InsertCommand.ExecuteNonQuery()

                Next


                connection.Close()

                cmd.Dispose()

                If connection IsNot Nothing Then connection = Nothing
                If m_daSettings IsNot Nothing Then m_daSettings = Nothing
                If dtGags IsNot Nothing Then dtGags = Nothing

                LoadGagLocations(sGAG_DB)

                Windows.Forms.Cursor.Current = Cursors.Default

            End If

        Catch ex As Exception

            MessageBox.Show("bbNew_ItemClick: " & ex.Message)

        End Try
    End Sub

    Private Sub bbOpen_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbOpen.ItemClick
        Dim Gag_FileOpen As New OpenFileDialog

        Try


            Gag_FileOpen.Filter = "GAG files (*.gag)|*.gag"
            Gag_FileOpen.FilterIndex = 1
            Gag_FileOpen.RestoreDirectory = True
            Gag_FileOpen.InitialDirectory = App_Path & "\Gag_Config" & "\"

            If Gag_FileOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                sGAG_DB = Gag_FileOpen.FileName

                LoadGagLocations(sGAG_DB)

                Me.Text = "Current Gag Locations From < " & sGAG_DB & " >"

            End If


            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception

            MessageBox.Show("bbNew_ItemClick: " & ex.Message)

        End Try

    End Sub

    Private Sub bbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick
        Dim connetionString As String
        Dim sql As String
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim m_cnGags As New OleDb.OleDbConnection
        Dim cmd As OleDbCommand
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim sTablename As String = "Gags"


        Try
            Me.Text = "Current Gag Locations From < " & sGAG_DB & " >"

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & sGAG_DB & "';"

            m_cnGags = New OleDbConnection(connetionString)

            m_cnGags.Open()

            sql = "DELETE * FROM [Gags]"

            cmd = New OleDbCommand(sql, m_cnGags)

            cmd.ExecuteNonQuery()

            sFieldNames = "[GagNumber]," & _
                                   "[Yloc]," & _
                                   "[PunchSize]"

            For i = 0 To ugvGags.RowCount - 1


                sFieldValues = "'" & ugcGags.DataSource(i).GetValue(0) & "','" & ugcGags.DataSource(i).GetValue(1) & "','" & ugcGags.DataSource(1).GetValue(2) & "'"

                sql = "INSERT INTO [" & sTablename & "] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

                m_daSettings.InsertCommand = New OleDbCommand(sql, m_cnGags)

                m_daSettings.InsertCommand.ExecuteNonQuery()


            Next
            m_cnGags.Close()

            If m_cnGags IsNot Nothing Then m_cnGags = Nothing
            If m_daSettings IsNot Nothing Then m_daSettings = Nothing

        Catch ex As Exception

            MessageBox.Show("bbiSave_ItemClick: " & ex.Message)

        End Try

    End Sub

    Private Sub teProgression_EditValueChanged(sender As Object, e As EventArgs)
        RegPutString("Customizations", "Progression", teProgression.Text)
    End Sub

    Private Sub fcbScodeFile_EditValueChanged(sender As Object, e As EventArgs) Handles fcbScodeFile.EditValueChanged
        RegPutString("Customizations", "Gag_Java", fcbScodeFile.Text)
    End Sub

    Private Sub sbRun_Click(sender As Object, e As EventArgs) Handles sbRun.Click
        nBlockNums = 0

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim cmd As String
        Dim sCodeFile As String
        Dim sNCFile As String
        Dim cat As ADOX.Catalog = New ADOX.Catalog()


        ubgStationsView.DataSource.clear()

        sNCFile = NormalizePath(PathTempFolder()) & "GagOutput.dat"

        If (FileExists(sNCFile) = True) Then

            Kill(sNCFile)

        End If

        sGAG_DB = App_Path & "\Gag_Config" & "\" & PathFile(m_curr_file) & ".gag"

        sReturn = RegPutString("Customizations", "GagDB", sGAG_DB)

        sReturn = HeaderStringSet("GagDB", sGAG_DB)

        sCodeFile = fcbScodeFile.Text

        lReturn = HeaderStringSet("cgfile", sCodeFile)

        lReturn = PortalExecute("admin:javavarsextract: file=" & QStr(sCodeFile) & ",class=" & QStr("cg"))
        lReturn = PortalExecute("CodeGen:WorkZonesVerify:")
        lReturn = PortalExecute("Admin:GlobalModel:")

        cmd = "codegen:generate:cgfile=" & QStr((sCodeFile)) & ",ncfile=" & QStr(sNCFile) & ",Subs=0,adv=0,Optalgorithm=1,Slice_Opt=7,Sticky=100,BiDir=0,Seq_Opt=0"

        lReturn = PortalExecute(cmd)

        'TListWin1.Redraw = False
        'LoadData(NormalizePath(PathTempFolder()) & "GagOutput.dat")
        'TListWin1.Redraw = True


        sGAG_DB = NormalizePath(PathTempFolder()) & "GagOutput.mdb"

        If (FileExists(sGAG_DB) = True) Then

            ConditionalFileDelete(sGAG_DB)

        End If

        cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                           "Data Source=" & sGAG_DB & ";" & _
                           "Jet OLEDB:Engine Type=5")

        cat.ActiveConnection.close()

        CreateGagTable(sGAG_DB)


        If cat IsNot Nothing Then cat = Nothing

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub


    Private Sub CreateGagTable(sGag_DBName As String)
        Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & sGag_DBName)
        Dim sTablename As String = "Gags"
        Dim ds As New DataSet
        Dim dt1 As DataTable = ds.Tables("Gags")
        Dim sql As String = "SELECT * FROM Gags"
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim nbadcount As Long = 0
        Dim sData As String
        Dim m_daSettings As New OleDb.OleDbDataAdapter
        Dim sNCFile As String
        Dim dtX_Value As Double
        Dim dtY_Value As Double
        Dim DTGag_Numaber As Integer
        Dim dGagHoldX As Double
        Dim stempfilename As System.IO.StreamWriter
        Dim nLastGag As Integer
        Dim dNextHoldX As Double
        Dim dGagOffset As Double = 0
        Dim dTempX As Double = 0
        Dim dMatlength As Double
        Dim sXorY As String
        Dim bDoGreater16 As Boolean = False
        Dim d80Percent As Double
        Dim bDoPercent As Boolean = True
        Dim bIsNeg As Boolean = False

        Try

            sNCFile = NormalizePath(PathTempFolder()) & "GagOutput.dat"

            LoadData(sNCFile)

            dMatlength = Round(HeaderDoubleGet("Length", 0), Places.Thousandths, True)

            d80Percent = 0.8 * dMatlength

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            ListBox3.Items.Clear()

            ubgStationsView.Columns.Clear()

            If (ubgStationsView.RowCount > 0) Then

                Dim i As Integer = 1

                While i < ubgStationsView.RowCount

                    ubgStationsView.DeleteRow(i)

                End While

            End If

            If (FileExists(beExportTo.Text) = True) Then

                Kill(beExportTo.Text)

            End If

            '
            stempfilename = My.Computer.FileSystem.OpenTextFileWriter(beExportTo.Text, True)

            connection.Open()


            'Get database schema 
            Dim dbSchema As DataTable = connection.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, sTablename, "TABLE"})

            connection.Close()

            ' If the table exists, the count = 1 
            If dbSchema.Rows.Count > 0 Then
                ' do whatever you want to do if the table exists 
            Else

                Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename & _
                                                    "] ([ID] AUTOINCREMENT UNIQUE  , " & _
                                                  "[X_Value] float ," & _
                                                  "[Yloc] float ," & _
                                                  "[GagNumber] INTEGER)", connection)
                connection.Open()
                cmd.ExecuteNonQuery()

                sFieldNames = "[X_Value]," & _
                                 "[Yloc]," & _
                                 "[GagNumber]"

                Using SR As StreamReader = New StreamReader(sNCFile)

                    While (SR.EndOfStream = False)

                        sData = SR.ReadLine()

                        sPieces = Split(sData, ",")

                        If (CInt(sPieces(2)) = -1) Then
                            nbadcount = nbadcount + 1
                            ListBox3.Items.Add(sData)
                            GoTo skip

                        End If

                        sFieldValues = "'" & sPieces(0) & "','" & sPieces(1) & "','" & sPieces(2) & "'"

                        sql = "INSERT INTO [" & sTablename & "] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"


                        m_daSettings.InsertCommand = New OleDbCommand(sql, connection)

                        m_daSettings.InsertCommand.ExecuteNonQuery()
skip:

                    End While

                End Using


                connection.Close()

                WriteBlockNumString(stempfilename, "M38	(ALL GRIP JAWS RAISE)")
                WriteBlockNumString(stempfilename, "G00	G90	X16.000	Z16.000	Y-705.000	W-705.000")
                WriteBlockNumString(stempfilename, "M46	(CENTER POS CLAMP)")
                WriteBlockNumString(stempfilename, "M00	(LOAD POSITION & PLATE CENTERING CLAMP)")
                WriteBlockNumString(stempfilename, "G00	M50	(Y & W SYNCHRONOUS)")
                WriteBlockNumString(stempfilename, "G01	G91	Y24.000	F10000	(AUTO GRIP)")
                WriteBlockNumString(stempfilename, "G04   P250	M47	(DWELL, & PLATE CENTERING UNCLAMP)")
                WriteBlockNumString(stempfilename, "M00	(PROGRAM STOP)")
                WriteBlockNumString(stempfilename, "G90	G00	(ABSOLUTE MODE)")


                CreateGridColumn(ubgStationsView, "X_Value", "X_Value", 0, True, DevExpress.Data.UnboundColumnType.Decimal)
                CreateGridColumn(ubgStationsView, "Y_Value", "Y_Value", 1, True, DevExpress.Data.UnboundColumnType.Decimal)
                CreateGridColumn(ubgStationsView, "GagNumber", "GagNumber", 2, True, DevExpress.Data.UnboundColumnType.Integer)

                sql = "Select Gags.X_Value,Gags.Yloc,Gags.GagNumber From Gags Where (Gags.ID > 0 ) Order By Gags.X_Value, Gags.GagNumber Desc"

                dt1 = ConnectToGagDB(sql, sGag_DBName)



                For i = 0 To dt1.Rows.Count - 1
                    ' dtX_Value = Format(dt1.Rows(i).Item(0), "#####.#####")
                    dtX_Value = CDbl(dt1.Rows(i).Item(0))
                    dtY_Value = CDbl(dt1.Rows(i).Item(1))
                    DTGag_Numaber = CInt(dt1.Rows(i).Item(2))

                    If (dtX_Value < 0) Then
                        sXorY = "Y"
                        bIsNeg = True

                    Else
                        sXorY = "X"

                    End If

                    ubgStationsView.AppendRow(New Object() {dtX_Value, dtY_Value, DTGag_Numaber})


                    If (dtX_Value > 16 And bIsNeg = True) Then

                        WriteBlockNumString(stempfilename, "M48(X & Z SYNCHRONOUS)")
                        WriteBlockNumString(stempfilename, "G04P250	(DWELL)")
                        WriteBlockNumString(stempfilename, "M19	(X & Z GRIP JAW CLOSE)")
                        WriteBlockNumString(stempfilename, "M52	(X & Y SYNCHRONOUS)")
                        WriteBlockNumString(stempfilename, "G04P250	(DWELL)")

                        bIsNeg = False
                        bDoGreater16 = False
                    End If

                    If (i = 0) Then

                        WriteBlockNumString(stempfilename, "S" & DTGag_Numaber)
                        dGagHoldX = dtX_Value

                    Else

                        If (i < dt1.Rows.Count - 1) Then

                            dNextHoldX = CDbl(dt1.Rows(i + 1).Item(0))

                        End If

                        If (dNextHoldX <> dtX_Value) Then

                            WriteBlockNumString(stempfilename, "S" & DTGag_Numaber)

                            If (dtX_Value > d80Percent And bDoPercent = True) Then

                                WriteBlockNumString(stempfilename, "M53( X & Y SYNC OFF )")
                                WriteBlockNumString(stempfilename, "M20( Y & W GRIP JAWS OPEN )")

                                bDoPercent = False
                            End If


                            WriteBlockNumString(stempfilename, sXorY & CDbl(dt1.Rows(i).Item(0)) & " T01")


                        End If

                        If (dNextHoldX = dtX_Value) Then

                            nLastGag = DTGag_Numaber

                            WriteBlockNumString(stempfilename, "S" & DTGag_Numaber)

                        End If

                    End If

                    dGagHoldX = dtX_Value

                Next

                MessageBox.Show((dt1.Rows.Count) & " Gags Processed. < ******* " & nbadcount & " Holes Did Not Line UP *******> ")

            End If
ByPass:
            ubgStationsView.RefreshData()
            WriteBlockNumString(stempfilename, "M00	(PROGRAM STOP)")
            WriteBlockNumString(stempfilename, "M00	(PROGRAM STOP)")
            WriteBlockNumString(stempfilename, "X804.000	 Y-715.000")
            WriteBlockNumString(stempfilename, "M18	(X & Z GRIP JAWS OPEN)")
            WriteBlockNumString(stempfilename, "X 814.0000")
            WriteBlockNumString(stempfilename, "M35	(X & Z GRIP JAWS LOWER)")
            WriteBlockNumString(stempfilename, "X550.000")
            WriteBlockNumString(stempfilename, "X36.000	M36	(Y & W GRIP JAWS RAISE)")
            WriteBlockNumString(stempfilename, "M34	(X & Z GRIP JAWS RAISE)")
            WriteBlockNumString(stempfilename, "G04 P250")
            WriteBlockNumString(stempfilename, "M49	(X & Z  SYNCHRONOUS OFF)")
            WriteBlockNumString(stempfilename, "M51	(Y & W  SYNCHRONOUS OFF)")
            WriteBlockNumString(stempfilename, "M30	(RESET & REWIND)")


            stempfilename.Close()
            dt1.Dispose()


            If dt1 IsNot Nothing Then dt1 = Nothing

        Catch ex As Exception

            MessageBox.Show("CreateGagTable: " & ex.Message)

        End Try

    End Sub
    Private Sub LoadData(ByVal PathToFile As String)
        Dim sPieces() As String


        'stempfilename = My.Computer.FileSystem.OpenTextFileWriter(beExportTo.Text, True)

        gridDatalist.Clear()

        Dim sr As StreamReader
        ' Open the file to read.
        sr = File.OpenText(PathToFile)
        ' Read each line in the file.
        ' When the end of the file is reached, return the value "-1".
        Dim x As String
        Dim LastParent As Long = 0
        While sr.Peek <> -1
            x = sr.ReadLine()

            sPieces = Split(x, ",")

            If (CInt(sPieces(2)) = -1) Then
                'nbadcount = nbadcount + 1
                'ListBox3.Items.Add(sData)
                GoTo skip

            End If

            If bFirstX = False Then
                dStoredX = sPieces(0)
                bFirstX = True
            End If
            gridDatalist.Add(New GagInfo(sPieces(0), sPieces(1), sPieces(2)))
            ' TListWin1.AddItem(sPieces(0) & "^" & sPieces(1) & "^" & sPieces(2), NewIndex)
Skip:

        End While
        ' Close the file.
        sr.Close()


        Me.xgStations.DataSource = gridDatalist

        ToolSetupView.Columns("X_Value").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        'ToolSetupView.Columns("X_Value").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending


        Dim sw As New System.IO.StreamWriter(beExportTo.Text, False)
        sw.Close()


        WriteStartProgram()
        WriteTheCNC()


    End Sub
    Private Function ConnectToGagDB(ByVal sqlString As String, sDBName As String) As DataTable

        Dim MyDataTable As DataTable = Nothing

        m_cnCMDB.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sDBName

        m_cnCMDB.Open()
        MyDataTable = New DataTable
        m_daCMDB = New OleDb.OleDbDataAdapter(sqlString, m_cnCMDB)
        m_cbCMDB = New OleDb.OleDbCommandBuilder(m_daCMDB)
        m_cbCMDB.QuotePrefix = "["
        m_cbCMDB.QuoteSuffix = "]"
        m_daCMDB.Fill(MyDataTable)
        m_cnCMDB.Close()
        ConnectToGagDB = MyDataTable

    End Function
    Private Sub WriteBlockNumString(sWriteFilename As System.IO.StreamWriter, sThetext As String)

        sWriteFilename.WriteLine("N" & nBlockNums & " " & sThetext)

        'sWriteFilename.WriteLine(sThetext)
        nBlockNums = nBlockNums + 1

    End Sub

    Private Function CreateGridColumn(ByVal gridview As GridView, _
                                             ByVal caption As String, _
                                             ByVal field As String, _
                                             ByVal visibleindex As Integer, _
                                             ByVal IsVisible As Boolean, _
                                             ByVal colType As DevExpress.Data.UnboundColumnType) As DevExpress.XtraGrid.Columns.GridColumn

        Dim gc As DevExpress.XtraGrid.Columns.GridColumn = gridview.Columns.Add()
        Dim nColWid As Integer

        gc.Caption = caption
        gc.VisibleIndex = visibleindex

        gc.FieldName = field
        gc.Visible = IsVisible

        gc.OptionsColumn.AllowEdit = True
        gc.UnboundType = colType

        nColWid = gc.GetBestWidth

        Return gc

    End Function

    Private Sub bsiSaveAs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bsiSaveAs.ItemClick
        Dim cat As ADOX.Catalog = New ADOX.Catalog()
        Dim Gag_FileSave As New SaveFileDialog
        dtGags = New DataTable()
        Dim sTablename As String = "Gags"
        Dim sFieldNames As String
        Dim sFieldValues As String
        Dim sql As String
        Dim m_daSettings As New OleDb.OleDbDataAdapter

        Try

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            ugcGags.DataSource.Clear()

            Gag_FileSave.Filter = "GAG files (*.gag)|*.gag"
            Gag_FileSave.FilterIndex = 1
            Gag_FileSave.RestoreDirectory = True
            Gag_FileSave.InitialDirectory = App_Path & "\Gag_Config" & "\"

            If Gag_FileSave.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                sGAG_DB = Gag_FileSave.FileName

                If (FileExists(sGAG_DB) = True) Then

                    ' ConditionalFileDelete(sGAG_DB)

                End If

                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                      "Data Source=" & sGAG_DB & ";" & _
                      "Jet OLEDB:Engine Type=5")

                cat.ActiveConnection.close()

                Dim connection As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & sGAG_DB)


                Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" & sTablename & _
                                                        "] ([ID] AUTOINCREMENT PRIMARY KEY  , " & _
                                                        "[GagNumber] INTEGER, " & _
                                                        "[Yloc] FLOAT," & _
                                                        "[PunchSize] FLOAT )", connection)

                connection.Open()
                cmd.ExecuteNonQuery()

                sFieldNames = "[GagNumber]," & _
                                "[Yloc]," & _
                                "[PunchSize]"



                For i = 1 To 48

                    sFieldValues = "'" & i & "','" & 0 & "','" & 0 & "'"

                    sql = "INSERT INTO [Gags] (" & sFieldNames & " ) VALUES(" & sFieldValues & ")"

                    m_daSettings.InsertCommand = New OleDbCommand(sql, connection)

                    m_daSettings.InsertCommand.ExecuteNonQuery()

                Next


                connection.Close()

                cmd.Dispose()

                If connection IsNot Nothing Then connection = Nothing
                If m_daSettings IsNot Nothing Then m_daSettings = Nothing
                If dtGags IsNot Nothing Then dtGags = Nothing

                LoadGagLocations(sGAG_DB)

                Windows.Forms.Cursor.Current = Cursors.Default

            End If

        Catch ex As Exception

            MessageBox.Show("bbNew_ItemClick: " & ex.Message)

        End Try

    End Sub

    Private Sub bbClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub WriteStartProgram()

        Dim sw As New StreamWriter(beExportTo.Text, True)

        WriteBlockNumString(sw, "M38	(ALL GRIP JAWS RAISE)")
        WriteBlockNumString(sw, "G00	G90	X16.000	Z16.000	Y-705.000	W-705.000")
        WriteBlockNumString(sw, "M46	(CENTER POS CLAMP)")
        WriteBlockNumString(sw, "M00	(LOAD POSITION & PLATE CENTERING CLAMP)")
        WriteBlockNumString(sw, "G00	M50	(Y & W SYNCHRONOUS)")
        WriteBlockNumString(sw, "G01	G91	Y24.000	F10000	(AUTO GRIP)")
        WriteBlockNumString(sw, "G04   P250	M47	(DWELL, & PLATE CENTERING UNCLAMP)")
        WriteBlockNumString(sw, "M00	(PROGRAM STOP)")
        WriteBlockNumString(sw, "G90	G00	(ABSOLUTE MODE)")
        sw.Close()

    End Sub

    Private Sub WriteTheCNC()
        Dim dXvalue As String
        Dim bIsNeg As Boolean = True
        Dim dMatlength As Double = 334.5
        Dim ni As Long
        Dim bDoPercent As Boolean = True

        d80Percent = 0.8 * dMatlength

        Dim sw As New StreamWriter(beExportTo.Text, True)

        For ni = 0 To ToolSetupView.RowCount - 1
            dXvalue = ToolSetupView.GetRowCellValue(ni, "X_Value")
            dGagloc = ToolSetupView.GetRowCellValue(ni, "Y_Value")
            nGagNumber = ToolSetupView.GetRowCellValue(ni, "GagNum")



            If (dXvalue = dStoredX) Then


                WriteBlockNumString(sw, "S" & nGagNumber)

            Else

                If (dStoredX < 0) Then

                    WriteBlockNumString(sw, "Y" & dStoredX & " Y" & dGagloc & " T01")

                Else

                    WriteBlockNumString(sw, "X" & dStoredX & " Y" & dGagloc & " T01")
                    If (dXvalue > d80Percent And bDoPercent = True) Then

                        WriteBlockNumString(sw, "M53( X & Y SYNC OFF )")
                        WriteBlockNumString(sw, "M20( Y & W GRIP JAWS OPEN )")

                        bDoPercent = False
                    End If

                End If

                If (dXvalue > 16 And bIsNeg = True) Then

                    WriteBlockNumString(sw, "M48(X & Z SYNCHRONOUS)")
                    WriteBlockNumString(sw, "G04P250	(DWELL)")
                    WriteBlockNumString(sw, "M19	(X & Z GRIP JAW CLOSE)")
                    WriteBlockNumString(sw, "M52	(X & Y SYNCHRONOUS)")
                    WriteBlockNumString(sw, "G04P250	(DWELL)")
                    bIsNeg = False

                End If

                WriteBlockNumString(sw, "S" & nGagNumber)
                dStoredX = dXvalue

            End If

        Next


        sw.Close()
    End Sub
End Class