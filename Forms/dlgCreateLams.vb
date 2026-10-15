Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Public Class dlgCreateLams
    Implements IDialogMouseUp
    Private ox As Double
    Private oy As Double
    Private Slot_Diff_Adjust As Double
    Private KW_Diff_Adjust As Double = 0
    Dim OD_Diff_Adjust As Double
    Private ID_Diff_Adjust As Double
    Private slot_center_X As Double
    Private slot_center_y As Double
    Private id_keyway_ang As Double
    Private slot_count As Long
    Private sDefaultName As String
    Private s_Machine As String = String.Empty
    Private s_ToolSetup As String = String.Empty
    Private s_LayerSetup As String = String.Empty
    Private nRowIndx As Integer
    Private m_datlines() As String
    Private m_sub_item_sncs As Long
    Private editValue As String
    Private m_entity_id As Long
    Private m_In_Edit_Mode As Boolean
    Private m_prev_selection_filter As Long
    Private m_hot_dot_state As Boolean
    Private WithEvents rbPropSettings As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private WithEvents rbMaterialSettings As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Private m_is_active As Boolean
    Private nToolSetupRowId As BaseRow
    Private SelectedMachineName As String
    Private SelectedToolSetupName As String
    Private n_MacroType As Integer

    Private CFG_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_ROOT_NODE As TreeListNode
    Private CFG_MATERIAL_CATEGORY_NODE As TreeListNode
    Private CFG_MATERIAL_NODE As TreeListNode
    Private Const TAG_MATERIAL_ROOT_NODE = -200
    Private Const TAG_MATERIAL_CATEGORY_NODE = -201
    Private Const TAG_MATERIAL_NODE = -202

    Public WithEvents rbMaterials As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Delegate Sub FocusTextHandler(ByRef VerticalGrid)
    Dim sUsage As String
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
    Private nRowId As BaseRow
    Private n_materialID As Long
    Private contents As clsStringArray
    Private bDidOD As Boolean = False
    Private bDidID As Boolean = False
    Private bDidKeyway As Boolean = False
    Private bDidSlot As Boolean = False
    Private nKeywayLayerID As Long
    Private nIdArcLayerID As Long


    Private Function ClientMouseUp() As Long Implements IDialogMouseUp.ClientMouseUp
        Dim pick_info As clsPickInfo
        On Error Resume Next

        'Try


        If (vgProplist.FocusedRow IsNot Nothing) Then

            modEdit.RevertProfile()

            pick_info = modPick.GetPickInfo()

            If (pick_info IsNot Nothing) Then
                UpdateAccumulatorPickInfo(vgProplist, pick_info)
            End If

            ClientMouseUp = 1

            Dim nChildRowCount As Integer

            'determine row
            If (vgProplist.FocusedRow IsNot Nothing) Then


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

        End If

        ' Catch ex As Exception

        'End Try


    End Function

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


    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim ni As Long
        Dim lam_name As String
        Dim od_diff As Double
        Dim id_diff As Double
        Dim kw_Diff As Double
        Dim id_ang As Long
        Dim slotcnt As Long
        Dim lam_cnt As Long
        Dim sMM2_File As String
        Dim iname As String
        Dim sval As String
        Dim sMM2_File_Save As String
        Dim sJavafilename As String
        Dim cmd As String
        Dim sTarget As String
        UndoPrepare()

        sMM2_File = PathCurrent()

        For Each row As CategoryRow In vgProplist.Rows
            Dim childRows As VGridRows = row.ChildRows


            For Each childRow As EditorRow In childRows

                Select Case childRow.Properties.Caption

                    Case " Lam. Prefix "
                        lam_name = childRow.Properties.Value
                    Case " OD Difference "
                        od_diff = childRow.Properties.Value
                    Case " ID Difference "
                        id_diff = childRow.Properties.Value
                        kw_Diff = childRow.Properties.Value
                    Case " ID Angle "
                        id_ang = childRow.Properties.Value
                    Case " Slot Count "
                        slotcnt = childRow.Properties.Value
                    Case " Lam. Count "
                        lam_cnt = childRow.Properties.Value
                End Select
            Next
        Next

        sJavafilename = RegGetString("Fabrication\FileOpen", "LastJava", "")

        For ni = 0 To lam_cnt - 1
            sReturn = ImportFile(sMM2_File, sMM2_File)

            bDidOD = False
            bDidOD = False
            bDidID = False
            bDidSlot = False
            bDidKeyway = False
            'id_keyway_ang = 0
            ' modSelection.SelectAll()

            ParseGeo(ni)



            'sMM2_File_Save = NormalizePath(PathDriveFolder(sMM2_File)) & lam_name & ni & ".mm2"
            'ExportMM2(sMM2_File_Save)
            'modAdmin.ModelDirtyClear()

            'cmd = "admin:macrorun: javafile=" & QStr(sJavafilename)

            'lReturn = PortalExecute(cmd)

            ''Lets be sure thera are no empty features lying around

            'lReturn = PortalExecute("create:empty:") ' get rid of empty feature

            'Next

            '     For ni = 0 To lam_cnt - 1

            'sMM2_File_Save = NormalizePath(PathDriveFolder(sMM2_File)) & lam_name & ni & ".mm2"

            'modView.ViewActivate(VIEW_WIRE)

            'At this point, the user has committed to importing the file.
            'sTarget = modFileIO.ImportFile(sMM2_File_Save, sMM2_File_Save)
            'sTarget = modFileIO.ImportFile(sMM2_File_Save, sMM2_File_Save)

            'modView.ViewRegen()
            'modView.ViewFull()
            'modView.ViewRefresh()
            'modAdmin.ModelReset()

            'sReturn = ImportFile(sMM2_File_Save, sMM2_File_Save)


            'modView.ViewRegen()
            'modView.ViewFull()
            'modView.ViewRefresh()
            'modView.ViewRegen()
            'modView.ViewFull()
            'modView.ViewRefresh()

            'MessageBox.Show("I should be viewing the MM2 file named < " & sMM2_File_Save & " >")
            'sval = PathReplaceExt(sMM2_File_Save, "dxf")

            'sReturn = HeaderStringSet("File", sval)

            'sReturn = HeaderStringSet("DXFFile", sval)

            'modCreateDXF.Dxf_File_Init(sval)


        Next


        UndoCommit()

    End Sub
    Private Sub ParseGeo(LamNum As Long)

        Dim lCount As Long
        Dim CircleCount As Long = 0
        Dim lId As Long
        Dim lColor As Long
        Dim lToolID As Long
        Dim IsCircle As Boolean = False
        Dim lCounter As Long
        Dim lam_name As String
        Dim od_diff As Double
        Dim id_diff As Double
        Dim kw_Diff As Double
        Dim id_ang As Long
        Dim slotcnt As Long
        Dim lam_cnt As Long
        Dim sToolLayerDesc As String
        Dim sval As String
        Dim sMM2_File_Save As String
        Dim sMM2_File As String
        Dim materialLength As Double
        Dim m_sPortalCommand As String
        Dim Zone1ID As Long
        Dim sCGFile As String
        Dim cmd As String

        Try

            Slot_Diff_Adjust = 0
            KW_Diff_Adjust = 0
            'OD_Diff_Adjust = 0
            ID_Diff_Adjust = 0

            For Each row As CategoryRow In vgProplist.Rows
                Dim childRows As VGridRows = row.ChildRows


                For Each childRow As EditorRow In childRows

                    Select Case childRow.Properties.Caption

                        Case " Lam. Prefix "
                            lam_name = childRow.Properties.Value
                        Case " OD Difference "
                            od_diff = childRow.Properties.Value
                        Case " ID Difference "
                            id_diff = childRow.Properties.Value
                            kw_Diff = childRow.Properties.Value
                        Case " ID Angle "
                            id_ang = childRow.Properties.Value
                            id_keyway_ang = childRow.Properties.Value + id_keyway_ang
                        Case " Slot Count "
                            slotcnt = childRow.Properties.Value
                            slot_count = slotcnt
                        Case " Lam. Count "
                            lam_cnt = childRow.Properties.Value
                    End Select
                Next
            Next

            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            'For lCounter = 0 To (lCount - 1)
            For lCounter = lCount - 1 To 0 Step -1
                'For lCounter = lCount - 1 To 0 Step -1
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip

                lColor = EntityIntGet(lId, "color", 16711680)
                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity

                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any

                sToolLayerDesc = GetToolDescriptionFromID(lId)

                If (UCase(sToolLayerDesc) = "OD" And bDidOD = False) Then
                    SetActiveLayer(lToolID, lColor)
                    CreateODArc(lId, od_diff)
                    bDidOD = True
                End If


                If (bDidOD = True And bDidID = True And bDidSlot = True And bDidKeyway = True) Then Exit For

skip:
            Next

            lReturn = PortalExecute("*admin:treeinit:")
            lReturn = PortalExecute("*admin:treecount:")
            lCount = PortalGetInt("count", 0)

            'For lCounter = 0 To (lCount - 1)
            For lCounter = lCount - 1 To 0 Step -1
                'For lCounter = lCount - 1 To 0 Step -1
                lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
                lId = PortalGetInt("id", 0) ' Getting the entity ID

                If lId <= 0 Then GoTo skip2 ' this should never be, but...

                lColor = EntityIntGet(lId, "color", 16711680)
                lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity

                lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any

                sToolLayerDesc = GetToolDescriptionFromID(lId)

                If (UCase(sToolLayerDesc) = "ID" And bDidID = False) Then
                    nIdArcLayerID = lToolID
                    SetActiveLayer(sToolLayerDesc, lColor)
                    CreateIDArc(lId, id_diff, lToolID)
                    bDidID = True
                End If

                If (UCase(sToolLayerDesc) = "SLOT" And bDidSlot = False) Then
                    SetActiveLayer(sToolLayerDesc, lColor)
                    MoveSlot(lId, od_diff, lToolID, id_ang, slotcnt)
                    bDidSlot = True
                End If

                If (UCase(sToolLayerDesc) = "KEYWAY" And bDidKeyway = False) Then
                    nKeywayLayerID = lToolID
                    SetActiveLayer(sToolLayerDesc, lColor)
                    MoveKeyway(lId, id_diff, lToolID)
                    bDidKeyway = True
                End If

                If (bDidOD = True And bDidID = True And bDidSlot = True And bDidKeyway = True) Then Exit For


                modView.ViewRegen()

skip2:

            Next

            'MessageBox.Show("Process complete. " & CircleCount & " Circles processed", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            RotateKeyway_IdArc()

            materialLength = HeaderDoubleGet("Length", 0)
            'Create the first default workzone just for ease of use for the user
            lReturn = PortalExecute("zone:update:" & "_zone_num=1" & ",_zone_bottom=" & HeaderDoubleGet("Width", 0) & ",_zone_left=0" & ",_zone_right=" & materialLength & ",_zone_top=0")

            SelectAll()
            m_toolsetup_id = GetToolSetupID()
            m_machine_id = modProject.GetMachineID()

            sMM2_File = PathCurrent()

            lReturn = GetToolIDFromDescription("OD", m_machine_id, m_toolsetup_id)
            lReturn = PortalExecute("model:activetool:id=" & lReturn)

            lReturn = PortalExecute("zone:get:_zone_num=1")

            Zone1ID = PortalGetInt("id", 0)

            lReturn = PortalExecute("Feature:Modify: id=" & Zone1ID & ",selected=1")

            sMM2_File_Save = NormalizePath(PathDriveFolder(sMM2_File)) & lam_name & LamNum & ".mm2"

            ExportMM2(sMM2_File_Save)

            sval = PathReplaceExt(sMM2_File_Save, "dxf")

            DeselectAll()


            sCGFile = RegGetString("Fabrication\fileopen", "LastJava", "")

            lReturn = PortalExecute("*attrib:headset: name= $cgfile,val=" & QStr(sCGFile))
            'lReturn = PortalExecute(cmd)

            cmd = "Admin:GlobalModel:"
            lReturn = PortalExecute(cmd)


            cmd = "codegen:generate:cgfile=" & QStr(sCGFile) & ",ncfile=" & QStr(sval) & ",Subs=0,adv=0,Optalgorithm=1,Slice_Opt=0,Sticky=1,BiDir=1,Seq_Opt=2,AllHolesFirst=1,HolesByToolOrder=1,ByCompletePart=1,HolesAcrossLocalNest=0"
            lReturn = PortalExecute(cmd)

            cmd = "Admin:GlobalModel:"
            lReturn = PortalExecute(cmd)


            sMM2_File = PathCurrent()


            sMM2_File_Save = NormalizePath(PathDriveFolder(sMM2_File)) & lam_name & LamNum & ".mm2"

            sval = PathReplaceExt(sMM2_File_Save, "dxf")

            sReturn = HeaderStringSet("File", sval)

            sReturn = HeaderStringSet("DXFFile", sval)

            ExportMM2(sMM2_File_Save)
            'modCreateDXF.Dxf_File_Init(sval)


        Catch ex As Exception
            MessageBox.Show("ParseGeo : sbAccept_Click: " & ex.Message)
        End Try

    End Sub
    Private Sub RotateKeyway_IdArc()
        Dim dangle As Double
        Dim lCount As Long


        DeselectAll()
        lReturn = SetSelectionFilters(
                        (SELECTION_FILTER.SEL_LINE Or SELECTION_FILTER.SEL_ARC Or SELECTION_FILTER.SEL_HOLE Or SELECTION_FILTER.SEL_POINT Or
                            SELECTION_FILTER.SEL_COMMAND Or SELECTION_FILTER.SEL_PROFILE Or SELECTION_FILTER.SEL_FEATURE))


        lCount = SelectAllRefsTo(nIdArcLayerID)
        lCount = SelectAllRefsTo(nKeywayLayerID)
        'MessageBox.Show("The total count is < " + modSelection.SelectedCount().ToString + " > ")

        dangle = id_keyway_ang * PI / 180

        lReturn = PortalExecute("transform:rotate:ox=" & slot_center_X &
            ",oy=" & slot_center_y &
            ",ang=" & dangle &
            ",copies=" & 0)


    End Sub
    Private Sub MoveSlot(lSelectionid As Long, kw_Diff As Double, lToolID As Long, angle As Double, cnt As Long)
        Dim lCount As Long
        Dim dangle As Double
        Dim slot_ang As Double



        slot_ang = 360 / cnt

        KW_Diff_Adjust = KW_Diff_Adjust + kw_Diff

        lReturn = SetSelectionFilters(
                        (SELECTION_FILTER.SEL_LINE Or SELECTION_FILTER.SEL_ARC Or SELECTION_FILTER.SEL_HOLE Or SELECTION_FILTER.SEL_POINT Or
                            SELECTION_FILTER.SEL_COMMAND Or SELECTION_FILTER.SEL_PROFILE Or SELECTION_FILTER.SEL_FEATURE))

        lCount = SelectAllRefsTo(lToolID)

        modEdit.TransformMove(0, 0, 0, 0, -OD_Diff_Adjust, 0, 0)

        dangle = slot_ang * PI / 180

        lReturn = PortalExecute("transform:rotate:ox=" & slot_center_X &
          ",oy=" & slot_center_y &
          ",ang=" & dangle &
          ",copies=" & cnt)

        lReturn = modSelection.DeselectAll



    End Sub
    Private Sub CreateIDArc(lSelectionid As Long, id_diff As Double, lToolID As Long)
        Dim lTemp As Long


        lReturn = PortalExecute("*create:extract:id=" & lSelectionid)
        lTemp = 1  'PortalGetInt("dir", 0)

        ID_Diff_Adjust = ID_Diff_Adjust + id_diff

        lReturn = PortalExecute("create:offsetprofile:Toolid = " & lToolID &
                         ",profid=" & lSelectionid & ",partprof=0,zlevel=0,dir = " & lTemp & ",dist = " & ID_Diff_Adjust & ",sharp =0")

        lReturn = PortalExecute("Create:Delete: id=" & lSelectionid)

    End Sub

    Private Sub CreateODArc(lSelectionid As Long, od_diff As Double)
        Dim dx As Double
        Dim dy As Double
        Dim dZ As Double
        Dim dx2 As Double
        Dim dy2 As Double
        Dim dZ2 As Double
        Dim lTemp As Long
        Dim dTemp As Double
        Dim MainArcRad As Double
        Dim incrArcRad As Double
        Dim cmd As String


        lTemp = PortalGetInt("dir", 0)

        lReturn = PortalExecute("*create:extract:id=" & lSelectionid)

        dx = PortalGetDouble("sx", 0)
        dy = PortalGetDouble("sy", 0)
        dZ = PortalGetDouble("sz", 0)

        dx = PortalGetDouble("ex", 0)
        dy = PortalGetDouble("ey", 0)
        dZ = PortalGetDouble("ez", 0)

        dx2 = PortalGetDouble("cx", 0)
        dy2 = PortalGetDouble("cy", 0)
        dZ2 = PortalGetDouble("cz", 0)

        slot_center_X = dx2
        slot_center_y = dy2


        dTemp = Dist2D(dx, dx2, dy, dy2)
        MainArcRad = dTemp

        OD_Diff_Adjust = OD_Diff_Adjust + od_diff

        incrArcRad = MainArcRad - OD_Diff_Adjust


        lTemp = PortalGetInt("dir", 0)
        PortalExecute("model:activetool:id = 104")

        cmd = "create:arc: action=0,sncs=201,id=0,xc=" & dx2 & ",yc=" & dy2 & ",zc=0,rad=" & incrArcRad & ",dir=" & lTemp
        lReturn = PortalExecute(cmd)

        lReturn = PortalExecute("Create:Delete: id=" & lSelectionid)
    End Sub
    Private Sub ChangeOD()
        Dim ODLayerId As Long
        Dim lCount As Long
        Dim count2 As Long
        Dim lSelectionID As Long
        Dim ProfEntType As Long
        Dim CircleCount As Long = 0
        Dim sLayerName As String
        Dim dx As Double
        Dim dy As Double
        Dim dZ As Double
        Dim dx1 As Double
        Dim dy1 As Double
        Dim dZ1 As Double
        Dim dx2 As Double
        Dim dy2 As Double
        Dim dZ2 As Double
        Dim IsCircle As Boolean = False
        Dim dTemp As Double
        Dim start_ang As Double
        Dim end_ang As Double
        Dim lTemp As Long
        Dim indx As Long
        Dim sTest As String

        modSelection.SelectAll()

        lCount = modSelection.SelectedCount()



        For indx = 0 To count2 - 1

            lReturn = PortalExecute("*create:extract:id=" & lSelectionID)

            ProfEntType = PortalGetInt("type", c_INVALID)

            sDefaultName = RegGetString("Global", "Machine", "")



            s_Machine = sDefaultName

            m_machine_id = modMachine.GetMachineIDFromDescrip(s_Machine)

            ODLayerId = modTranslate.GetLayerSetupID("Multi Lam Macro", m_machine_id)

            sLayerName = EntityStringGet(ODLayerId, "name", "<error>")

            sTest = GetLayerSetupDesription(ODLayerId)


            Select Case ProfEntType
                Case c_DBARC

                    dx = PortalGetDouble("sx", 0)
                    dy = PortalGetDouble("sy", 0)
                    dZ = PortalGetDouble("sz", 0)

                    dx1 = PortalGetDouble("ex", 0)
                    dy1 = PortalGetDouble("ey", 0)
                    dZ1 = PortalGetDouble("ez", 0)

                    dx2 = PortalGetDouble("cx", 0)
                    dy2 = PortalGetDouble("cy", 0)
                    dZ2 = PortalGetDouble("cz", 0)

                    dTemp = Dist2D(dx, dx2, dy, dy2)

                    'If (Dist2D(dx, dx1, dy, dy1) < 0.000001) Then

                    IsCircle = True
                    ' CircleCount = CircleCount + 1

                    lTemp = PortalGetInt("dir", 0)

                    start_ang = ATan2(dy - dy2, dx - dx2)
                    end_ang = ATan2(dy1 - dy2, dx1 - dx2)
                    'dTemp = Round(Dist2D(dx, dx2, dy, dy2) * 2)
                    dTemp = Round(Dist2D(dx, dx2, dy, dy2))
                    dTemp = dTemp * 2


                Case c_DBLINE

                    dx = PortalGetDouble("sx", 0)
                    dy = PortalGetDouble("sy", 0)
                    dZ = PortalGetDouble("sz", 0)

                    dx1 = PortalGetDouble("ex", 0)
                    dy1 = PortalGetDouble("ey", 0)
                    dZ1 = PortalGetDouble("ez", 0)

                Case c_DBPROFILE

            End Select


        Next



        '        "Select Directives.*,[Layer Setups].* From Directives,[Layer Setups] Where ([Layer Setups].ID = 27 )" And "(Directives.[CAD Layer] = "OD" )" And "(Directives.[Layer Setup ID] = 27 )"

        '        sDefaultName = RegGetString("Global", "Machine", "")

        '        s_Machine = sDefaultName

        '        m_machine_id = modMachine.GetMachineIDFromDescrip(s_Machine)

        '        ODLayerId = modTranslate.GetLayerSetupID("Multi Lam Macro", m_machine_id)

        '        sLayerName = EntityStringGet(ODLayerId, "name", "<error>")

        '        sTest = GetLayerSetupDesription(ODLayerId)

        '        lReturn = SetSelectionFilters(
        '                        (SELECTION_FILTER.SEL_LINE Or SELECTION_FILTER.SEL_ARC Or SELECTION_FILTER.SEL_HOLE Or SELECTION_FILTER.SEL_POINT Or
        '                            SELECTION_FILTER.SEL_COMMAND Or SELECTION_FILTER.SEL_PROFILE Or SELECTION_FILTER.SEL_FEATURE))

        '        lCount = SelectAllRefsTo(ODLayerId)

        '        count2 = modSelection.SelectedCount()


        '        For indx = 0 To count2 - 1

        '            lSelectionID = modSelection.GetAt(indx)

        '            lReturn = PortalExecute("*create:extract:id=" & lSelectionID)
        '            ProfEntType = PortalGetInt("type", c_INVALID)

        '            If (ProfEntType = c_DBARC) Then


        '                SetActiveLayer(sToolLayerDesc, lColor)

        '                lReturn = PortalExecute("*create:extract:id=" & lSelectionID)
        '                dx = PortalGetDouble("sx", 0)
        '                dy = PortalGetDouble("sy", 0)
        '                dZ = PortalGetDouble("sz", 0)

        '                dx1 = PortalGetDouble("ex", 0)
        '                dy1 = PortalGetDouble("ey", 0)
        '                dZ1 = PortalGetDouble("ez", 0)

        '                dx2 = PortalGetDouble("cx", 0)
        '                dy2 = PortalGetDouble("cy", 0)
        '                dZ2 = PortalGetDouble("cz", 0)

        '                dTemp = Dist2D(dx, dx2, dy, dy2)

        '                If (Dist2D(dx, dx1, dy, dy1) < 0.000001) Then

        '                    IsCircle = True
        '                    ' CircleCount = CircleCount + 1

        '                    lTemp = PortalGetInt("dir", 0)

        '                    start_ang = ATan2(dy - dy2, dx - dx2)
        '                    end_ang = ATan2(dy1 - dy2, dx1 - dx2)
        '                    'dTemp = Round(Dist2D(dx, dx2, dy, dy2) * 2)
        '                    dTemp = Round(Dist2D(dx, dx2, dy, dy2))
        '                    dTemp = dTemp * 2

        '                    If dTemp >= minDia And dTemp <= maxDia Then

        '                        cmd = "create:arc: action=0,sncs=201,id=0,xc=" & dx2 & ",yc=" & dy2 & ",zc=0,rad=" & newDia & ",dir=1"
        '                        lReturn = PortalExecute(cmd)

        '                        lReturn = PortalExecute("Create:Delete: id=" & lId)

        '                    End If


        '                End If

        '            End If

        'skip:
        '        Next


    End Sub
    Private Sub dlgCreateLams_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False
        frmMain.CloseFirstPanel()
        modView.ViewResize()
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

    Private Function GetMacroType(sFilename As String) As Integer
        Dim sline As String

        Try
            GetMacroType = -1
            m_version = -1

            contents = New clsStringArray

            Using sr As New StreamReader(sFilename)

                sline = sr.ReadLine()

                While (sr.EndOfStream = False)
                    If (InStr(UCase(sline), "BEGIN_MACRO") > 0) Then

                        m_version = 17
                        GetMacroType = MACRO_TYPE.MACRO_VARTYPE
                    ElseIf (InStr(UCase(sline), "PUBLIC") > 0) Then

                        m_version = 16
                        GetMacroType = MACRO_TYPE.MACRO_MACTYPE

                    End If

                    If (m_version > 0) Then Exit While

                    lReturn = contents.Add(sline)

                    sline = sr.ReadLine()

                End While

                sr.Dispose()

            End Using
        Catch ex As Exception
            MessageBox.Show("GetMacroType: " & ex.Message)
        End Try

    End Function
    Private Sub dlgCreateLams_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sJavaFile As String


        sJavaFile = Application.StartupPath & "\data\CreateLams.dat"
        LoadVariables(sJavaFile, "mac")

    End Sub

    Private Sub LoadVariables(
                ByVal sFileName As String,
                ByVal sClass As String,
                Optional bClear As Boolean = True)

        Try
            'cboDefn.Visible = True
            'cboDefn.Properties.Buttons(0).Visible = False
            'cboDefn.Properties.Items.Add("Flip Sheet")

            n_MacroType = GetMacroType(sFileName)

            If (n_MacroType = MACRO_TYPE.MACRO_MACTYPE = True) Then

                'LoadVersion16Variables(sFileName, sClass)

            Else

                LoadVersion17Variables(contents)

            End If
            'LoadValuesFromHeader()

        Catch ex As Exception
            MessageBox.Show("LaodVariables: " & ex.Message)
        End Try

    End Sub
    Private Sub LoadVersion17Variables(m_contents As clsStringArray)
        Dim lCount As Long
        Dim indx As Long
        Dim sData As String
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String
        Dim my_CVarName As String
        Dim my_DataType As Integer
        Dim my_RecodID As Integer
        Dim my_sOptions As String
        Dim arrOptions As Collection
        Dim currentCategoryRow As CategoryRow = Nothing
        Dim nOpenBracket As Long
        Dim nClosedBracket As Long
        Dim sql As String
        Dim nToolSetupID As Long
        Dim toolSetupName As String

        Try

            vgProplist.Rows.Clear()

            lbOptions.Items.Clear()

            contents = New clsStringArray


            'currentCategoryRow = CreateCategoryRow(vgProplist, "Variables", "Variables", "Variables", 0, "MACVAR", DB_HEADER, 0, sEmpty, 0)

            lCount = m_contents.Count

            For indx = 1 To lCount - 1

                sData = m_contents.GetAt(indx)
                If (sData <> "") Then

                    nOpenBracket = sData.IndexOf("[") + 1
                    nClosedBracket = sData.IndexOf("]") - nOpenBracket

                    sData = sData.Substring(nOpenBracket, nClosedBracket)


                    'NOTE: zero-based!
                    sPieces = Split(sData, "|")

                    my_DatVarName = sPieces(0)
                    my_CVarName = sPieces(0)
                    my_DataType = ConvertDatTypeToDBType(sPieces(1))
                    my_DialogDisplay = sPieces(2)
                    my_VBValue = sPieces(3)
                    my_CValue = sPieces(3) 'Also see the case statement for combobox
                    my_RecodID = 0
                    my_sOptions = sEmpty

                    Select Case (my_DataType)

                        Case DB_HEADER
                            currentCategoryRow = CreateCategoryRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0)

                        Case DB_STR
                            currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                        Case DB_BOOL
                            currentCategoryRow.ChildRows.Add(CreateBooleanEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_INT, DB_ENTITYID
                            currentCategoryRow.ChildRows.Add(CreateIntegerEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_DBL
                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_TOOL
                            toolSetupName = HeaderStringGet("MachCfg", "")
                            nToolSetupID = GetToolSetupIDFromDescription(toolSetupName)  'RegGetString("Global", "ToolSetupID", 0)
                            'my_CValue = 0
                            'my_VBValue = "None"
                            'my_RecodID = 0

                            sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" &
                                " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " &
                                "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " &
                                "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" &
                                " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & nToolSetupID & "))" &
                                " ORDER BY [Tool Crib].Description"

                            arrMachine = PopulateComboList(sql, False, True)

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgProplist,
                                                                       my_DatVarName,
                                                                    my_DialogDisplay,
                                                                    my_VBValue,
                                                                    my_CValue,
                                                                    my_CVarName,
                                                                    my_DataType,
                                                                    my_RecodID,
                                                                    arrMachine, 4))

                        Case DB_FILE, DB_BATCH
                            my_sOptions = sPieces(4)

                            currentCategoryRow.ChildRows.Add(CreateButtonEditEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))


                        Case DB_DCOMBO, DB_COMBO
                            Dim i As Integer

                            lbOptions.Items.Clear()

                            For i = 4 To sPieces.Count - 1
                                lbOptions.Items.Add(sPieces(i).ToString)

                                If (sPieces(i).ToString = my_VBValue) Then
                                    my_CValue = i - 3
                                End If
                            Next
                            arrOptions = PopulateComboListFromDat(lbOptions)

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgProplist,
                                                                    my_DatVarName,
                                                                     my_DialogDisplay,
                                                                     my_VBValue,
                                                                     my_CValue, my_CVarName, my_DataType, my_RecodID, arrOptions, 0))

                        Case DB_MATLIST
                            MessageBox.Show("We found matlist")
                            currentCategoryRow.ChildRows.Add(CreateStringEditorRow(vgProplist,
                                                                                   my_DatVarName,
                                                                                   my_DialogDisplay,
                                                                                   my_VBValue,
                                                                                   my_CValue,
                                                                                   my_CVarName,
                                                                                   my_DataType,
                                                                                   my_RecodID,
                                                                                   my_sOptions, 0))


                        Case DB_MAT_LEN

                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProplist,
                                                                                     my_DatVarName,
                                                                                    my_DialogDisplay,
                                                                                    my_VBValue,
                                                                                    my_CValue,
                                                                                    my_CVarName,
                                                                                    my_DataType,
                                                                                    my_RecodID,
                                                                                    my_sOptions, 0))


                        Case DB_MAT_WID
                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProplist,
                                                                                    my_DatVarName,
                                                                                    my_DialogDisplay,
                                                                                    my_VBValue,
                                                                                    my_CValue,
                                                                                    my_CVarName,
                                                                                    my_DataType,
                                                                                    my_RecodID,
                                                                                    my_sOptions, 0))

                        Case DB_MAT_THICK
                            currentCategoryRow.ChildRows.Add(CreateDoubleEditorRow(vgProplist, my_DatVarName, my_DialogDisplay, my_VBValue, my_CValue, my_CVarName, my_DataType, my_RecodID, my_sOptions, 0))

                        Case DB_CRIB
                            toolSetupName = HeaderStringGet("MachCfg", "")
                            nToolSetupID = GetToolSetupIDFromDescription(toolSetupName)  'RegGetString("Global", "ToolSetupID", 0)
                            my_CValue = 0
                            my_VBValue = "None"
                            my_RecodID = 0

                            sql = "SELECT [Station Configuration].[NC Code Number], [Tool Crib].Description, [Tool Setup Members].[ID]" &
                                " FROM [Tool Crib] INNER JOIN ([Station Configuration] INNER JOIN [Tool Setup Members] " &
                                "ON [Station Configuration].ID = [Tool Setup Members].[Station ID]) ON " &
                                "[Tool Crib].ID = [Tool Setup Members].[Tool ID]" &
                                " WHERE ((([Tool Setup Members].[Tool Setup ID]) = " & nToolSetupID & "))" &
                                " ORDER BY [Tool Crib].Description"

                            arrMachine = PopulateComboList(sql, False, True)

                            currentCategoryRow.ChildRows.Add(CreateComboBoxListEditorRow(vgProplist,
                                                                       my_DatVarName,
                                                                    my_DialogDisplay,
                                                                    my_VBValue,
                                                                    my_CValue,
                                                                    my_CVarName,
                                                                    my_DataType,
                                                                    my_RecodID,
                                                                    arrMachine, 4))

                    End Select


                End If

            Next

        Catch ex As Exception
            MessageBox.Show("LoadVersion17Variables: " & ex.Message)
        End Try
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

    Private Sub vgProplist_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles vgProplist.CellValueChanged
        Dim iname As String
        Dim sOptions As String
        Dim nVarType As Integer
        Dim sValue As String
        Dim VbVarValue As Object

        Try
            nVarType = CInt(GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "VarDataType", ""))
            iname = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "DatVarName", "")

            sOptions = GetValueFromDelimitedData(vgProplist.FocusedRow.Tag, "Options", "")

            Select Case nVarType

                Case DB_COMBO, DB_DCOMBO, DB_USERVAR, DB_LEADSETUP
                    sValue = GetOptionIndex(sOptions, e.Value)

                Case DB_CRIB
                    sValue = FindModelIDFromToolDescrip(e.Value)

                Case DB_DBL
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetDouble("val", 0)
                        sValue = Round(sValue, Places.TenThousandths)
                        vgProplist.FocusedRow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If

                Case DB_INT
                    If (PortalExecute("*solve:eval:exp=" & QStr(e.Value)) > 0) Then

                        sValue = PortalGetInt("val", 0)

                        vgProplist.FocusedRow.Properties.Value = sValue
                    Else
                        sValue = e.Value
                    End If

                Case DB_TOOL, DB_STR
                    VbVarValue = e.Row.Properties.Value

                    sValue = VbVarValue

                    vgProplist.FocusedRow.Properties.Value = sValue

                Case Else
                    If (PortalExecute("*solve:eval:exp=" & QStr(vgProplist.FocusedRow.Properties.Value)) > 0) Then

                        sValue = PortalGetInt("val", 0)

                        vgProplist.FocusedRow.Properties.Value = sValue

                    Else

                        sValue = 0

                    End If
                    '                sValue = e.Value

            End Select

            lReturn = UpdateAccumulatorDirect(vgProplist, iname, sValue)

        Catch ex As Exception
            MessageBox.Show("vgproplist_CellValueChanged: " & ex.Message)
        End Try

    End Sub

    Private Sub MoveKeyway(lSelectionID As Long, id_Diff As Double, lToolid As Long)
        Dim lCount As Long

        Slot_Diff_Adjust = Slot_Diff_Adjust + id_Diff

        lReturn = SetSelectionFilters(
                        (SELECTION_FILTER.SEL_LINE Or SELECTION_FILTER.SEL_ARC Or SELECTION_FILTER.SEL_HOLE Or SELECTION_FILTER.SEL_POINT Or
                            SELECTION_FILTER.SEL_COMMAND Or SELECTION_FILTER.SEL_PROFILE Or SELECTION_FILTER.SEL_FEATURE))

        lCount = SelectAllRefsTo(lToolid)

        modEdit.TransformMove(0, 0, 0, 0, -Slot_Diff_Adjust, 0, 0)
        lReturn = modSelection.DeselectAll


    End Sub



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim ni As Long
        Dim lam_cnt As Long
        Dim sMM2_File_Save As String
        Dim sval As String

        lam_cnt = 224

        For ni = 0 To lam_cnt
            sMM2_File_Save = "C:\1wittlockeng\Customers\Advanced Rotor\From Shop\Lam_" & ni & ".mm2"

            ImportMM2(sMM2_File_Save)
            sval = PathReplaceExt(sMM2_File_Save, "dxf")
            ViewFull()
            ViewRegen()
            MessageBox.Show("Create DXF", "Lets Go", MessageBoxButtons.YesNo)

            modCreateDXF.Dxf_File_Init(sval)
        Next


    End Sub
End Class