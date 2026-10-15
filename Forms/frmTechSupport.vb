Imports DevExpress.Compression
Imports System.Data.OleDb
Public Class frmTechSupport

    Private Sub frmTechSupport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim pdb_file As String
        Dim sCGFilename As String
        Dim NCFile As String

        lstBoxFile.Items.Clear()

        teFirstName.Text = RegGetString("TechSupport", "FirstName", "")
        teLastName.Text = RegGetString("TechSupport", "LastName", "")
        meLine.Text = RegGetString("TechSupport", "Address", "")
        teCity.Text = RegGetString("TechSupport", "City", "")
        teState.Text = RegGetString("TechSupport", "State", "")
        teZip.Text = RegGetString("TechSupport", "Zip", "")
        teEmail.Text = RegGetString("TechSupport", "Email", "")
        tePhone.Text = RegGetString("TechSupport", "Phone", "")



        pdb_file = HeaderStringGet("pdb_file", "")

        lstBoxFile.Items.Add(PathCMDB())

        If FileExists(pdb_file) = True Then
            lstBoxFile.Items.Add(pdb_file)

            GetPartsFromDb(pdb_file)
            GetNstFilesFromDB(pdb_file)
        Else
            lstBoxFile.Items.Add(PathCurrent())
        End If

        sCGFilename = HeaderStringGet("cgfile", "")

        If FileExists(sCGFilename) = True Then
            lstBoxFile.Items.Add(sCGFilename)
        End If

        NCFile = HeaderStringGet("ncfile", "")

        If FileExists(NCFile) = True Then
            lstBoxFile.Items.Add(NCFile)
        End If

        Dim sTemplate As String = RegGetString("Nesting", "Template", "")

        If (FileExists(sTemplate) = True) Then

            lstBoxFile.Items.Add(sTemplate)

        End If

        Dim machineID As Long
        Dim ToolSetupID As Long
        Dim materialID As Long
        Dim layersetupID As Long

        machineID = modProject.GetMachineID()

        If (DoesMachineExists(machineID) = True) Then

            ToolSetupID = modProject.GetToolSetupID()
            layersetupID = modProject.GetLayerSetupID

        Else

            machineID = 0
            ToolSetupID = 0
            layersetupID = 0
        End If

        materialID = modProject.GetMaterialID()

        If (DoesMaterialExist(materialID) = False) Then

            materialID = 0

        End If

        modProject.InitMachineList(cboMachine, machineID)
        modProject.InitToolSetupList(cboToolSetup, machineID, ToolSetupID)
        modProject.InitMaterialList(cboMaterial, materialID)
        modProject.InitLayerSetupList(cboLayerSetup, machineID, layersetupID)
    End Sub

    Sub GetPartsFromDb(pdbfile As String)
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String
        Dim sMM2Filename As String
        Dim sDxfFilename As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & pdbfile & "';"

            sql = "Select * From [Part]"

            connection = New OleDbConnection(connetionString)
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1
                sMM2Filename = ds.Tables(0).Rows(i).Item("Filename")

                sDxfFilename = PathReplaceExt(sMM2Filename, "dxf")

                lstBoxFile.Items.Add(sMM2Filename)

                If (FileExists(sDxfFilename)) Then
                    lstBoxFile.Items.Add(sDxfFilename)
                End If

            Next

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetPartsFromDb: " & ex.Message)

        End Try

    End Sub

    Sub GetNstFilesFromDB(pdbfile As String)
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String

        Try

            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & pdbfile & "';"

            sql = "SELECT * FROM [Sheet Result]"

            connection = New OleDbConnection(connetionString)
            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()

            For i = 0 To ds.Tables(0).Rows.Count - 1

                lstBoxFile.Items.Add(ds.Tables(0).Rows(i).Item("Sheet Filename"))
            Next

            If ds IsNot Nothing Then ds = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If connection IsNot Nothing Then connection = Nothing

        Catch ex As Exception

            MessageBox.Show("GetPartsFromDb: " & ex.Message)

        End Try

    End Sub



    Private Function ArchiveFiles() As String
        Dim today = Date.Today
        Dim day = today.Day
        Dim month = today.Month
        Dim year = today.Year
        Dim minute = DateTime.Now.Minute
        Dim file As System.IO.StreamWriter
        Dim sProblemTextFile As String



        sProblemTextFile = NormalizePath(PathTechSupport()) & "problem.txt"

        file = My.Computer.FileSystem.OpenTextFileWriter(sProblemTextFile, False)
        file.WriteLine("***CUSTOMER INFORMATION****")
        file.WriteLine("Name: " & teFirstName.Text & " " & teLastName.Text)
        file.WriteLine("Address: " & meLine.Text)
        file.WriteLine("City: " & teCity.Text)
        file.WriteLine("State: " & teState.Text)
        file.WriteLine("Zipcode: " & teZip.Text)
        file.WriteLine("Phone: " & tePhone.Text)
        file.WriteLine("Email: " & teEmail.Text)
        file.WriteLine(" ")
        file.WriteLine("***CONFIGURATION INFORMATION****")
        file.WriteLine("Machine: " & cboMachine.Text)
        file.WriteLine("Tool Setup: " & cboToolSetup.Text)
        file.WriteLine("Layer Setup: " & cboLayerSetup.Text)
        file.WriteLine("Material: " & cboMaterial.Text)
        file.WriteLine(" ")
        file.WriteLine("***PROBLEM INFORMATION****")
        file.WriteLine(Me.memoEdit1.Text)

        file.Close()

        lstBoxFile.Items.Add(sProblemTextFile)

        ArchiveFiles = NormalizePath(PathTechSupport()) & _
           year & _
           "_" & month & _
           "_" & day & _
           "_" & minute & ".zip"

        Dim ni As Integer

        If (FolderExists(App_Path & "\TechSupport") = False) Then
            MkDir(App_Path & "\TechSupport")

        End If

        Using archive As New ZipArchive()
            For ni = 0 To Me.lstBoxFile.Items.Count - 1
                archive.AddFile(lstBoxFile.Items(ni).ToString, "/")
            Next

            If (FileExists(App_Path & "\" & cboMachine.Text & ".dat") = True) Then

                archive.AddFile(App_Path & "\" & cboMachine.Text & ".dat")

            Else
                archive.AddFile(RegGetDatFilePath())

            End If

            archive.Save(ArchiveFiles)
        End Using

        Kill(sProblemTextFile)

        MessageBox.Show("Please send the following file to contact@wittlockeng.com " & ArchiveFiles)
        modView.ViewAll()

    End Function

    Private Sub cboMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMachine.SelectedIndexChanged
        If (cboMachine.SelectedIndex > -1) Then
            Dim machineid As Long = (TryCast(cboMachine.SelectedItem, myItemData).ItemData.ToString())

            modProject.InitToolSetupList(cboToolSetup, machineid, 0)
            modProject.InitLayerSetupList(cboLayerSetup, machineid, 0)
        End If

    End Sub

    Private Sub sbSend_Click(sender As Object, e As EventArgs) Handles sbSend.Click

        'Dim msg As MailMessage = New MailMessage()
        'msg.From = "sender@mail.com"
        'msg.To = "use1@mail.com;user2@mail.com"
        'msg.Subject = "dns sending"
        'msg.Body = "it is a test."
        'Dim client As DnsMailClient = New DnsMailClient()
        'client.Send(msg)


        If (DxValidationProvider1.Validate() = True) Then


            sReturn = RegPutString("TechSupport", "FirstName", Me.teFirstName.Text)
            sReturn = RegPutString("TechSupport", "LastName", Me.teLastName.Text)
            sReturn = RegPutString("TechSupport", "Address", Me.meLine.Text)
            sReturn = RegPutString("TechSupport", "City", Me.teCity.Text)
            sReturn = RegPutString("TechSupport", "State", Me.teState.Text)
            sReturn = RegPutString("TechSupport", "Zip", Me.teZip.Text)
            sReturn = RegPutString("TechSupport", "Email", Me.teEmail.Text)
            sReturn = RegPutString("TechSupport", "Phone", Me.tePhone.Text)

            ArchiveFiles()

        End If

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Dispose()

    End Sub

End Class