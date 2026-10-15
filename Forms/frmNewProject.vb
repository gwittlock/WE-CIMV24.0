

Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTreeList.Nodes

Public Class frmNewProject
    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private CFG_MATERIAL_NODE As TreeListNode
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Private Const TAG_OPERATION_ROOT_NODE = -300
    Private Const TAG_OPERATION_LEAD_ROOT_NODE = -301
    Private Const TAG_OPERATION_LEAD_PARAM_ROOT_NODE = -302
    Private Const TAG_OPERATION_LEAD_PARAM_NODE = -303
    Private Const TAG_OPERATION_LEAD_SETUP_ROOT_NODE = -304
    Private Const TAG_OPERATION_LEAD_SETUP_NODE = -305


    Private sPieces() As String
    Private sMatPieces() As String
    Private sMaterialWidth As String
    Private sMaterialLength As String
    Private sMaterialThickness As String
    Private bHeaderDone As Boolean

    Dim dCheckX As Double
    Dim dCheckY As Double
    Dim sUsage As String


    '    Private Sub frmNewProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub frmNewProject_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim machineID As Long
        Dim ToolSetupID As Long
        Dim materialID As Long
        Dim sMaterialTYpeAndSize As String


        machineID = modProject.GetMachineID()

        If (DoesMachineExists(machineID) = True) Then

            ToolSetupID = modProject.GetToolSetupID()

        Else

            machineID = 0
            ToolSetupID = 0

        End If

        materialID = modProject.GetMaterialID()

        If (DoesMaterialExist(materialID) = False) Then

            materialID = 0

        End If


        modProject.InitMachineList(cbeMachine, machineID)
        modProject.InitToolSetupList(cbeToolSetup, machineID, ToolSetupID)
        modProject.InitMaterialList(cbeMaterial, materialID)

        tebCustomer.Text = modProject.GetCustomer()

        deDueDate.EditValue = Date.Today
        CreateMaterialTypeNodes(tl)


        popupContainerControl1.Controls.Add(tl)
        popupContainerEdit1.Properties.PopupControl = popupContainerControl1
        popupContainerEdit1.Properties.ShowPopupCloseButton = False
        AddHandler popupContainerEdit1.QueryDisplayText, AddressOf popupContainerEdit1_QueryDisplayText


        sMaterialTYpeAndSize = GetMaterialTypeName(GetMaterialType(materialID))
        sMaterialTYpeAndSize = sMaterialTYpeAndSize & "," & GetMaterialDescription(materialID)

        popupContainerEdit1.Text = sMaterialTYpeAndSize
        popupContainerEdit1.Tag = TAG_MATERIAL_NODE & "," & materialID
        tebMaterialLength.Text = modMaterial.GetMaterialLength(materialID)
        tebMaterialWidth.Text = modMaterial.GetMaterialWidth(materialID)
        tebMaterialThickness.Text = modMaterial.GetMaterialThickness(materialID)

        cbeMaterialType.Focus()
        LoadMaterialTypes("Nothing")
        EnableOkButton()


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

                If InStr(UCase(s_MaterialCategory), UCase(sUsage)) Then
                    n_MaterialID = dtMaterialType.Rows(i).Item("ID")

                    CFG_MATERIAL_CATEGORY_NODE = tl.AppendNode(New Object() {s_MaterialCategory}, CFG_MATERIAL_ROOT_NODE, TAG_MATERIAL_CATEGORY_NODE)

                    FillMaterialNodes(n_MaterialID)

                    dtMaterialType.Dispose()
                End If

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


    Private Sub EnableOkButton()

        cmdOK.Enabled = False

        If (cbeToolSetup.Text <> "" And
            cbeMaterial.Text <> "" And
            tebMaterialLength.Text <> "" And
            tebMaterialWidth.Text <> "") Then

            cmdOK.Enabled = True

        End If
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim sFileName As String
        Dim machineID As Integer
        Dim ToolSetupID As Integer
        Dim materialID As Integer
        Dim Length As Double
        Dim width As Double
        Dim thickness As Double
        Dim sPieces()
        Dim Message As String = "NOTE: The selected material exceeds the weight limitations of the machine." &
                                "  Do you want to proceed?"
        Dim Caption As String = "Weight limitations have been exceeded"
        Dim Buttons As MessageBoxButtons = MessageBoxButtons.OKCancel

        Dim Result As DialogResult
        Result = Windows.Forms.DialogResult.OK

        Try

            ' validate the material weight
            'If (CheckMaterialWeight(TryCast(cbeMachine.SelectedItem, myItemData).ItemData.ToString(), TryCast(cbeMaterial.SelectedItem, myItemData).ItemData.ToString()) = True) Then

            ''Displays the MessageBox
            'Result = MessageBox.Show(Message, Caption, Buttons)

            'End If

            ' Gets the result of the MessageBox display
            If Result = System.Windows.Forms.DialogResult.OK Then
                sPieces = Split(popupContainerEdit1.Tag, ",")
                If sPieces.Count > 0 Then
                    materialID = sPieces(1) 'TryCast(cbeMaterial.SelectedItem, myItemData).ItemData.ToString()
                End If

                machineID = GetMachineIDFromDescrip(cbeMachine.Text) 'lcbMachine.ItemData(lcbMachine.ListIndex)
                ToolSetupID = GetToolSetupIDFromDescription(cbeToolSetup.Text) 'lcbToolSetup.ItemData(lcbToolSetup.ListIndex)

                'ToolSetupID = 'lcbToolSetup.ItemData(lcbToolSetup.ListIndex)

                width = CDbl(tebMaterialWidth.Text)
                Length = CDbl(tebMaterialLength.Text)
                thickness = CDbl(tebMaterialThickness.Text)

                modProject.SetMachine((cbeMachine.Text), machineID)
                modProject.SetToolSetup((cbeToolSetup.Text), ToolSetupID)
                modProject.SetMaterial((cbeMaterial.Text), materialID)
                modProject.SetMaterialDims(Length, width, thickness)
                modProject.SetCustomer((tebCustomer.Text))

                Cursor.Current = Cursors.WaitCursor

                sFileName = NewModel("", machineID, ToolSetupID, materialID, Length, width, thickness)

            End If

        Catch ex As Exception
            MessageBox.Show("Create New Model! ", ex.Message)
        End Try

        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub

    Private Sub cbeMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMachine.SelectedIndexChanged
        Dim n_MachineID As Long
        n_MachineID = (TryCast(cbeMachine.SelectedItem, myItemData).ItemData.ToString())

        modProject.InitToolSetupList(cbeToolSetup, n_MachineID, 0)



    End Sub

    Private Sub cbeToolSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeToolSetup.SelectedIndexChanged
        EnableOkButton()
    End Sub

    Private Sub cbeMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMaterial.SelectedIndexChanged
        Dim materialID As Long
        Dim spieces()

        If (popupContainerEdit1.Tag <> Nothing) Then
            spieces = Split(popupContainerEdit1.Tag, ",")

            If sPieces.Count > 0 Then

                materialID = spieces(1)
                tebMaterialLength.Text = modMaterial.GetMaterialLength(materialID)
                tebMaterialWidth.Text = modMaterial.GetMaterialWidth(materialID)
                tebMaterialThickness.Text = modMaterial.GetMaterialThickness(materialID)


                EnableOkButton()
            End If
        End If


    End Sub

    Private Sub tebMaterialLength_EditValueChanged(sender As Object, e As EventArgs) Handles tebMaterialLength.EditValueChanged
        EnableOkButton()
    End Sub

    Private Sub tebMaterialThickness_EditValueChanged(sender As Object, e As EventArgs) Handles tebMaterialThickness.EditValueChanged
        EnableOkButton()
    End Sub

    Private Sub tebMaterialWidth_EditValueChanged(sender As Object, e As EventArgs) Handles tebMaterialWidth.EditValueChanged
        EnableOkButton()
    End Sub

    Private Sub LoadMaterialTypes(s_CompareStr As String)
        Dim sql As String
        Dim dtMaterialType As DataTable = Nothing
        Dim n_MaterialID As Long
        Dim dtMaterials As DataTable = Nothing
        Dim s_MaterialCategory As String

        cbeMaterialType.Properties.Items.Clear()

        sql = "Select [Material Types].* From [Material Types] Where ([Material Types].ID > 0 ) Order By [Material Types].Display"
        dtMaterialType = ConnectToCMDB(sql)

        For i = 0 To dtMaterialType.Rows.Count - 1

            s_MaterialCategory = dtMaterialType.Rows(i).Item("Description")
            n_MaterialID = dtMaterialType.Rows(i).Item("ID")

            'If (InStr(s_MaterialCategory, s_CompareStr) > 0) Then

            cbeMaterialType.Properties.Items.Add(New myItemData(s_MaterialCategory, n_MaterialID))

            'End If

        Next

        cbeMaterialType.SelectedIndex = 0

        DatabaseClose()

        dtMaterialType.Dispose()

        dtMaterialType = Nothing

        'rgProductType.SelectedIndex = 0

    End Sub

    Private Sub tl_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tl.FocusedNodeChanged
        Dim itemtype As Long
        Dim nCurr_Node_Tag As Long
        Dim sCurr_Display As String
        Dim sMaterialType As String
        Dim nTestNode
        Dim sPieces()

        Try


            If (e.Node IsNot Nothing) Then


                If (e.Node.ParentNode IsNot Nothing) Then

                    sMaterialType = e.Node.ParentNode.GetDisplayText(tl.Columns(0))
                    sCurr_Display = sMaterialType & ", " & e.Node.GetDisplayText(tl.Columns(0))
                    nCurr_Node_Tag = e.Node.Tag

                    popupContainerEdit1.EditValue = sCurr_Display ' e.Node.ParentNode.GetDisplayText(tl.Columns(1))
                    popupContainerEdit1.Tag = e.Node.Tag
                    sPieces = Split(e.Node.Tag, ",")

                    RegPutString("Global", "Material", e.Node.GetDisplayText(tl.Columns(0)))
                    cbeMaterial.Text = e.Node.GetDisplayText(tl.Columns(0))
                    tebMaterialLength.Text = modMaterial.GetMaterialLength(sPieces(1))
                    tebMaterialWidth.Text = modMaterial.GetMaterialWidth(sPieces(1))
                    tebMaterialThickness.Text = modMaterial.GetMaterialThickness(sPieces(1))
                    popupContainerEdit1.ClosePopup()

                End If
            End If

        Catch ex As Exception

            MessageBox.Show("tl_FocusedNodeChanged: " & ex.Message)

        End Try
    End Sub

    Private Sub popupContainerEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles popupContainerEdit1.EditValueChanged
        Dim sPieces() As String
        Try


            If (popupContainerEdit1.Tag IsNot Nothing) Then
                sPieces = Split(popupContainerEdit1.Tag, ",")

                Dim materialID As Long

                'MsgBox("The material ID is < " & e.ToString)

                materialID = (sPieces(1))

                tebMaterialLength.Text = modMaterial.GetMaterialLength(materialID)
                tebMaterialWidth.Text = modMaterial.GetMaterialWidth(materialID)
                tebMaterialThickness.Text = modMaterial.GetMaterialThickness(materialID)
            End If

        Catch ex As Exception
            MessageBox.Show("popupContainerEdit1_EditValueChanged: " & ex.Message)
        End Try
        'EnableOkButton()
    End Sub

End Class