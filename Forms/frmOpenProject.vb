
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Public Class frmOpenProject
    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private CFG_MATERIAL_NODE As TreeListNode
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202
    Dim sUsage As String

    Private m_FileName As String

    '    Private Sub frmOpenProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    Private Sub popupContainerEdit1_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles popupContainerEdit1.QueryDisplayText
        e.DisplayText = If(e.EditValue IsNot Nothing, e.EditValue.ToString(), "")

    End Sub

    Private Sub frmOpenProject_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim machineID As Long
        Dim ToolSetupID As Long
        Dim materialID As Long
        Dim layersetupID As Long
        Dim sMaterialTYpeAndSize As String

        Try

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

            modProject.InitMachineList(cbeMachine, machineID)
            modProject.InitToolSetupList(cbeToolSetup, machineID, ToolSetupID)
            modProject.InitMaterialList(cbeMaterial, materialID)
            modProject.InitLayerSetupList(cbeLayerSetup, machineID, layersetupID)


            tebCustomer.Text = modProject.GetCustomer()

            deDueDate.EditValue = Date.Today

            '*************************************************

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
            '*************************************************

            EnableOkButton()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Dim machineID As Long
        'Dim ToolSetupID As Long
        'Dim materialID As Long
        'Dim layersetupID As Long
        'Dim sMaterialTYpeAndSize As String


        'Try

        '    Windows.Forms.Cursor.Current = Cursors.WaitCursor

        '    machineID = modProject.GetMachineID()

        '    If (DoesMachineExists(machineID) = True) Then

        '        ToolSetupID = modProject.GetToolSetupID()
        '        layersetupID = modProject.GetLayerSetupID


        '    Else

        '        machineID = 0
        '        ToolSetupID = 0
        '        layersetupID = 0
        '    End If

        '    ' materialID = modProject.GetMaterialID()
        '    materialID = GetMaterialIDFromDescription(RegGetString("Global", "Material", ""))

        '    'MsgBox("Gregs real material name is < " & cbeMaterial.Text & " > along with a material ID of < " & materialID & " >")

        '    If (DoesMaterialExist(materialID) = False) Then

        '        materialID = 0

        '    End If



        '    modProject.InitMachineList(cbeMachine, machineID)
        '    modProject.InitToolSetupList(cbeToolSetup, machineID, ToolSetupID)
        '    modProject.InitMaterialList(cbeMaterial, materialID)
        '    modProject.InitLayerSetupList(cbeLayerSetup, machineID, layersetupID)

        '    sMaterialTYpeAndSize = GetMaterialTypeName(GetMaterialType(materialID))
        '    sMaterialTYpeAndSize = sMaterialTYpeAndSize & "," & GetMaterialDescription(materialID)

        '    cbeMaterial.Text = sMaterialTYpeAndSize
        '    tebCustomer.Text = modProject.GetCustomer()

        '    deDueDate.EditValue = Date.Today

        '    'MatProps.MatListProps(0).nMaterialID = materialID

        '    'sMaterialTYpeAndSize = GetMaterialTypeName(GetMaterialType(materialID))
        '    'sMaterialTYpeAndSize = sMaterialTYpeAndSize & "," & GetMaterialDescription(materialID)

        '    'MatProps.SetMatPropValues(materialID)
        '    ''GetMaterialTypeName(GetMaterialType(materialID))
        '    'MatProps.popupContainerEdit1
        '    'MatProps.MatListProps(0).nMatCategoryID = GetMaterialType(materialID)
        '    'MatProps.MatListProps(0).sMatCategoryName = GetMaterialTypeName(GetMaterialType(materialID))

        '    'MatProps.MatListProps(0).dMaterialLength = modMaterial.GetMaterialLength(materialID)
        '    'MatProps.MatListProps(0).dMaterialWidth = modMaterial.GetMaterialWidth(materialID)
        '    'MatProps.MatListProps(0).dMaterialThickness = modMaterial.GetMaterialThickness(materialID)
        '    'MatProps.MatListProps(0).nMaterialID = materialID
        '    EnableOkButton()


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Windows.Forms.Cursor.Current = Cursors.Default
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
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim machineID As Integer
        Dim ToolSetupID As Integer
        Dim materialID As Integer
        Dim layersetupID As Long
        Dim sMatPieces()


        Try

            cbeMaterial.Text = MatProps.sTheMaterialName


            machineID = GetMachineIDFromDescrip(cbeMachine.Text) 'lcbMachine.ItemData(lcbMachine.ListIndex)
            ToolSetupID = GetToolSetupIDFromDescription(cbeToolSetup.Text) 'lcbToolSetup.ItemData(lcbToolSetup.ListIndex)

            'sMatPieces = Split(MatProps.MatListProps.Item(0).nMaterialID, ",")
            'If sMatPieces.Count > 0 Then
            '    materialID = sMatPieces(1) 'TryCast(cbeMaterial.SelectedItem, myItemData).ItemData.ToString()
            'End If

            materialID = MatProps.nTheMaterialID
            materialID = GetMaterialIDFromDescription(RegGetString("Global", "Material", ""))



            modProject.SetMachine((cbeMachine.Text), machineID)

            modProject.SetToolSetup(cbeToolSetup.Text, ToolSetupID)

            modProject.SetMaterial(GetMaterialDescription(materialID), materialID)
            'modProject.SetMaterial(MatProps.sTheMaterialName, materialID)
            tebMaterialLength.Text = modMaterial.GetMaterialLength(materialID)
            tebMaterialWidth.Text = modMaterial.GetMaterialWidth(materialID)
            tebMaterialThickness.Text = modMaterial.GetMaterialThickness(materialID)

            modProject.SetMaterialDims(tebMaterialLength.Text, tebMaterialWidth.Text, tebMaterialThickness.Text)
            modProject.SetCustomer((tebCustomer.Text))



            'modProject.SetLayerSetup(cbeLayerSetup.EditValue.ToString(), myItemData)
            layersetupID = modTranslate.GetLayerSetupID(cbeLayerSetup.Text, machineID)

            modProject.SetLayerSetup(cbeLayerSetup.Text, layersetupID)

            lReturn = HeaderStringSet("MaterialWeight", CheckMaterialWeight(materialID))
            lReturn = HeaderStringSet("MaterialCost", GetMaterialCost(materialID))

            modProject.SetCustomer(tebCustomer.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EnableOkButton()

        'NOTE: lcbLayerSetup[0] is "(None)"
        cmdOK.Enabled =
            ((cbeLayerSetup.SelectedIndex <> 0) And
             (cbeToolSetup.Text <> "") And
             (cbeMaterial.Text <> ""))

    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_FileName = ""
        'SetFilename(m_FileName)
        Me.Dispose()

    End Sub

    Public Sub SetFilename(Filename As String)
        m_FileName = Filename
    End Sub

    Public Function GetFilename() As String
        GetFilename = m_FileName
    End Function

    Private Sub cbeMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMachine.SelectedIndexChanged

        If (cbeMachine.SelectedIndex > -1) Then
            Dim machineid As Long = (TryCast(cbeMachine.SelectedItem, myItemData).ItemData.ToString())

            modProject.InitToolSetupList(cbeToolSetup, machineid, 0)
            modProject.InitLayerSetupList(cbeLayerSetup, machineid, 0)
        End If

        EnableOkButton()
    End Sub

    Private Sub cbeLayerSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeLayerSetup.SelectedIndexChanged
        EnableOkButton()
    End Sub

    Private Sub cbeMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeMaterial.SelectedIndexChanged
        EnableOkButton()
    End Sub

    Private Sub cbeToolSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbeToolSetup.SelectedIndexChanged
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

    Private Sub tl_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tl.FocusedNodeChanged
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
End Class