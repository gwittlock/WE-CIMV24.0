Imports System.Data.OleDb

Public Class dlgLifeGear


    Private Sub dlgLifeGear_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        frmMain.CloseFirstPanel()
        modView.ViewResize()
    End Sub

    Private Sub LifeGear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtMaterialType As DataTable = Nothing
        Dim dtMaterials As DataTable = Nothing

        txtQty.Text = "1"
        FillToolListBasedOnType(15)
        rgProductType.SelectedIndex = 0

        'cbSpacing.Properties.Items.Add("0.5"" X  0.5""")
        cbSpacing.Properties.Items.Add(New myItemData("0.5"" X  0.5""", 0, ".5"))
        cbSpacing.Properties.Items.Add(New myItemData("1.0"" X  1.0""", 1, "1.0"))
        cbSpacing.Properties.Items.Add(New myItemData("1.5"" X  1.5""", 2, "1.5"))

        'cbSpacing.Properties.Items.Add("1.0"" X  1.0""")
        '.Properties.Items.Add("1.5"" X  1.5""")
        cbSpacing.SelectedIndex = 1

        LoadMaterialTypes("PegBoard")

        rgProductType.SelectedIndex = 0

        rgLogo.SelectedIndex = 0
        rgNotch.SelectedIndex = 0
        rgPresser.SelectedIndex = 0
        txtHeight.Focus()
        MsgBox("Hello")


    End Sub
    Private Sub FillToolListBasedOnType(tlTypeId As Long)
        Dim sDisplayStr As String
        Dim nID As Integer
        Dim sql As String
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim connetionString As String
        Dim m_machineType As Long = 1
        Dim tlDia As Double

        cbDIa.Properties.Items.Clear()

        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathCMDB() & "';"

        sql = "SELECT [Tool Crib].* FROM ([Tool Types] INNER JOIN [Tool Crib] ON [Tool Types].ID = [Tool Crib].[Type ID]) INNER JOIN [Machine Tool Types] ON [Tool Types].ID = [Machine Tool Types].[Tool Type ID]" & _
                " WHERE ((([Tool Types].ID)=" & tlTypeId & ") AND (([Machine Tool Types].[Machine Type ID])=" & m_machineType & ")) Order By [Tool Crib].Diameter"

        connection = New OleDbConnection(connetionString)

        Try
            InitFillDS(ds, Nothing, sql, connection)

            For i = 0 To ds.Tables(0).Rows.Count - 1
                sDisplayStr = CStr(ds.Tables(0).Rows(i).Item("Description"))
                nID = CInt(ds.Tables(0).Rows(i).Item("ID"))

                tlDia = ds.Tables(0).Rows(i).Item("Diameter")

                Select Case tlDia

                    Case 0.141, 0.195, 0.265, 0.312, 0.38, 0.393, 0.433, 0.472

                        cbDIa.Properties.Items.Add(New myItemData(sDisplayStr, nID, tlDia))

                End Select

            Next

            cbDIa.SelectedIndex = 2
            ds.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub lcSpacing_Click(sender As Object, e As EventArgs) Handles lcSpacing.Click

    End Sub

    Private Sub rgProductType_EditValueChanged(sender As Object, e As EventArgs) Handles rgProductType.EditValueChanged
        LoadMaterialTypes("MagPanel")
    End Sub

    Private Sub rgProductType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgProductType.SelectedIndexChanged


        If (rgProductType.SelectedIndex = 0) Then

            gcNotch_Corners.Visible = True
            pcMagPanel.Visible = False
            gcHole.Visible = True
            rgLogo.SelectedIndex = 0
            rgNotch.SelectedIndex = 0
            rgPresser.SelectedIndex = 0
            LoadMaterialTypes("PegBoard")

        Else

            gcNotch_Corners.Visible = False
            pcMagPanel.Visible = True

            rgMountingHoles.SelectedIndex = 0
            rgCorner.SelectedIndex = 0
            RadioGroup1.SelectedIndex = 0

            gcHole.Visible = False
            LoadMaterialTypes("MagPanel")

        End If

        txtHeight.Focus()

    End Sub

    Private Sub sbRun_Click(sender As Object, e As EventArgs) Handles sbRun.Click
        Dim nToolSetupID As Long = RegGetString("Global", "ToolSetupID", 0)
        Dim sFileName As String = ""
        Dim nmachineID As Long = RegGetString("Global", "MachineID", 0)
        Dim nmaterialID As Long = modTranslate.GetMaterialIDFromDescription(cbBlankSize.Text)
        Dim dmaterialLength As Double = CDbl(modMaterial.GetMaterialLength(CLng(nmaterialID)))
        Dim dmaterialWidth As Double = CDbl(modMaterial.GetMaterialWidth(CLng(nmaterialID)))
        Dim dmaterialThickness As Double = CDbl(modMaterial.GetMaterialThickness(CLng(nmaterialID)))
        Dim sCgFile As String
        Dim sNCFile As String

        sReturn = NewModel(sFileName, nmachineID, nToolSetupID, nmaterialID, dmaterialLength, dmaterialWidth, dmaterialThickness)

        sCgFile = RegGetString("Customizations", "SpecJava", NormalizePath(Application.StartupPath) & "CodeGen\TRUMPF2020_D.java")

        lReturn = HeaderStringSet("cgfile", sCgFile)

        sNCFile = RegGetString("Customizations", "SpecNcFile", NormalizePath(Application.StartupPath) & "CNC\01234.LST")

        lReturn = HeaderStringSet("ncfile", sNCFile)

        lReturn = HeaderDoubleSet("mac.Dia", TryCast(cbDIa.Properties.Items(cbDIa.SelectedIndex), myItemData).sItemData)

        UndoPrepare()

        If (rgProductType.SelectedIndex = 0) Then

            CretePegBoardMX()
            ViewRegen()
            ViewFull()

            '
            'Me.Dispose()

        Else

            CreateMagPanel()
            ViewRegen()
            ViewFull()


        End If

        frmMain.SynchronizeUI(modSelection.SelectedCount())

        UndoCommit()

        lReturn = HeaderIntSet("subs", 0)

        'Record the checkbox for optimizing the toolpath
        lReturn = HeaderIntSet("opttoolpath", 1)

        'Record the optimization mode.
        'The radio button order is Grid/Closest/Progressive
        lReturn = HeaderIntSet("OptAlgorithm", 1)

        'Record the Linear Trend Value
        lReturn = HeaderIntSet("Sticky", 100)

        'Record Sequence By Mode (Preset Tool Order,Containment Order,Process Flowchart)
        lReturn = HeaderIntSet("seq_opt", 0)

        'Record Zig Zag Checkbox
        lReturn = HeaderIntSet("bidir", 1)

        'If (FileExists(sNCFile)) Then
        '    Kill(sNCFile)

        'End If
        frmCodeGen.ShowDialog(Me)


    End Sub
    Private Sub CretePegBoardMX()
        Dim cmd As String

        'txtQty.Text = "1"
        HeaderStringSet("cgfile", RegGetString("Customizations", "SpecJava", App_Path & "\CodeGen\TRUMPF2020_D.java"))

        HeaderStringSet("ncfile", RegGetString("Customizations", "SpecNcFile", App_Path & "\CNC\01234.LST"))


        HeaderStringSet("mac.ProfLen2", "0.688")
        HeaderStringSet("mac.Profwid2", "0.688")
        HeaderStringSet("mac.notch45", "0.468")
        HeaderStringSet("mac.proflen", txtWidth.Text)
        HeaderStringSet("mac.ProfWid", txtHeight.Text)
        HeaderStringSet("mac.qty", txtQty.Text)
        HeaderStringSet("mac.matid", cbBlankSize.EditValue)
        HeaderStringSet("mac.Logo", rgLogo.SelectedIndex)
        HeaderStringSet("mac.notch", rgNotch.SelectedIndex)
        HeaderStringSet("mac.presser", rgPresser.SelectedIndex)


        HeaderDoubleSet("cg.xload", "1.0")
        'HeaderDoubleSet("Clamp1Pos", 18.503)
        'HeaderDoubleSet("Clamp2Pos", 85)
        HeaderDoubleSet("mac.spaceing", (TryCast(cbSpacing.Properties.Items(cbSpacing.SelectedIndex), myItemData)).ItemData.ToString())


        cmd = "admin:macrorun: javafile=" & QStr(App_Path & "\macros\PegBoardMX.java")

        lReturn = PortalExecute(cmd)

        'Lets be sure thera are no empty features lying around

        lReturn = PortalExecute("create:empty:") ' get rid of empty feature
    End Sub
    Private Sub CreateMagPanel()
        Dim cmd As String

        txtQty.Text = "1"
        HeaderStringSet("cgfile", RegGetString("Customizations", "SpecJava", App_Path & "\CodeGen\TRUMPF2020_D.java"))

        HeaderStringSet("ncfile", RegGetString("Customizations", "SpecNcFile", App_Path & "\CNC\01234.LST"))


        HeaderStringSet("mac.ProfLen2", "0.688")
        HeaderStringSet("mac.Profwid2", "0.688")
        HeaderStringSet("mac.notch45", "0.468")
        HeaderStringSet("mac.proflen", txtWidth.Text)
        HeaderStringSet("mac.ProfWid", txtHeight.Text)
        HeaderStringSet("mac.qty", txtQty.Text)
        HeaderStringSet("mac.matid", cbBlankSize.EditValue)
        HeaderStringSet("mac.Logo", rgLogo.SelectedIndex)
        HeaderStringSet("mac.notch", rgNotch.SelectedIndex)
        HeaderStringSet("mac.presser", rgPresser.SelectedIndex)
        HeaderStringSet("mac.moutingholes", rgMountingHoles.SelectedIndex)
        HeaderStringSet("mac.roundedcorners", rgCorner.SelectedIndex)


        HeaderDoubleSet("mac.spaceing", "1.0")
        HeaderDoubleSet("Clamp1Pos", 18.503)
        HeaderDoubleSet("Clamp2Pos", 44.0939)
        HeaderDoubleSet("mac.spaceing", (TryCast(cbSpacing.Properties.Items(cbSpacing.SelectedIndex), myItemData)).ItemData.ToString())


        cmd = "admin:macrorun: javafile=" & QStr(App_Path & "\macros\MagPanel.java")

        lReturn = PortalExecute(cmd)

        'Lets be sure thera are no empty features lying around

        lReturn = PortalExecute("create:empty:") ' get rid of empty feature

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Dispose()
    End Sub

    Private Sub dlgLifeGear_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtHeight.Focus()
    End Sub


    Private Sub cbeMaterialType_EditValueChanged(sender As Object, e As EventArgs) Handles cbeMaterialType.EditValueChanged
        FindBlank()
    End Sub

    Private Sub LoadMaterialTypes(s_CompareStr As String)
        Dim sql As String
        Dim dtMaterialType As DataTable
        Dim n_MaterialID As Long
        Dim s_MaterialCategory As String

        sql = "SELECT * FROM [Material Types] ORDER BY Display"
        dtMaterialType = ConnectToCMDB(sql)

        For i = 0 To dtMaterialType.Rows.Count - 1

            s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")
            n_MaterialID = dtMaterialType.Rows(i).Item("ID")

            If (InStr(s_MaterialCategory, s_CompareStr) > 0) Then

                cbeMaterialType.Properties.Items.Add(New myItemData(s_MaterialCategory, n_MaterialID))

            End If

        Next

        cbeMaterialType.SelectedIndex = 0

        DatabaseClose()

        dtMaterialType.Dispose()

        dtMaterialType = Nothing

        rgProductType.SelectedIndex = 0

    End Sub

    Private Sub cbeMaterialType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMaterialType.SelectedIndexChanged

    End Sub
    Private Sub FindBlank()
        Dim sql As String
        Dim MatTypeID
        Dim dtMaterials As DataTable
        Dim s_MaterialBlank As String
        Dim n_MaterialID As Integer

        cbBlankSize.Properties.Items.Clear()

        If (Val(txtHeight.Text) > 0 And Val(txtWidth.Text) > 0) Then

            MatTypeID = TryCast(cbeMaterialType.Properties.Items(cbeMaterialType.SelectedIndex), myItemData).ItemData.ToString()

            sql = "Select * From [Material Inventory] " & _
                        "Where ([Material Inventory].[Type ID] = " & MatTypeID & _
                        ") And ([Material Inventory].[Length] >= " & txtWidth.Text & _
                        ") And ([Material Inventory].[Width] >= " & txtHeight.Text & " )"

            dtMaterials = ConnectToCMDB(sql)

            If dtMaterials.Rows.Count > 0 Then

                For i = 0 To dtMaterials.Rows.Count - 1

                    s_MaterialBlank = dtMaterials.Rows(i).Item("Description")
                    n_MaterialID = dtMaterials.Rows(i).Item("ID")

                    cbBlankSize.Properties.Items.Add(New myItemData(s_MaterialBlank, n_MaterialID))

                Next

            End If

            cbBlankSize.SelectedIndex = 0

            DatabaseClose()

            dtMaterials.Dispose()

            dtMaterials = Nothing
        End If

    End Sub

    Private Sub txtWidth_LostFocus(sender As Object, e As EventArgs) Handles txtWidth.LostFocus
        FindBlank()
    End Sub

    Private Sub txtHeight_LostFocus(sender As Object, e As EventArgs) Handles txtHeight.LostFocus
        FindBlank()
    End Sub
End Class