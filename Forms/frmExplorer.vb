Imports System.ComponentModel

Public Class frmExplorer
    Private Structure tValuePair
        'Stucture for storing the file extions used in dialogs such as The file Open
        Public filter_text As String
        Public filter_value As Long
    End Structure
    Public m_mode As EXPLORER_OPTION

    Private m_table(0 To 12) As tValuePair
    Private m_original_name As String
    Private m_file_type As Long
    Private m_FileName As String

    Private m_caption As String

    Private m_preview As Boolean
    Private m_filters As Long

    Private m_pre_rotate As Double
    Private m_strip_layers As Boolean
    Private m__debug_click_event As Boolean

    'm_is_view_initialized is used to defer initializing the view until
    'it is required.  NOTE: view initialization appears to cause the most
    'lag when opening the form.
    Private m_is_view_initialized As Boolean
    Private m_curr_file_filter As String
    Private m_initializing As Boolean

    Private Sub InitFilterList()

        Dim last_used_file_type As Long
        Dim list_index As Long
        Dim indx As Long

        'Assume failure.
        list_index = -1

        InitFilterData()


        'Get the extension last used with this dialog.  This allows
        'us to open the dialog, displaying the last accessed file
        'type and folder.  The purpose of this action is to
        'minimize folder navigation.
        '
        last_used_file_type = RegGetString("Fabrication\FileOpen", "LastEXT", FILE_MM2)

        For indx = 0 To UBound(m_table)

            If ((m_filters And m_table(indx).filter_value) > 0) Then

                lcbFilter.AddItem(m_table(indx).filter_text)
                lcbFilter.ItemData(lcbFilter.ListCount - 1) = m_table(indx).filter_value

                If (m_table(indx).filter_value = last_used_file_type) Then
                    list_index = lcbFilter.ListCount - 1
                End If

            End If

        Next

        If (list_index < 0) Then
            'Punt.
            list_index = 0
        End If

        m_file_type = lcbFilter.ItemData(list_index)
        lcbFilter.ListIndex = list_index


    End Sub

    Public Sub InitFilterData()

        ReDim m_table(0 To 13)

        m_table(0).filter_text = "Model Files (*.mm2)"
        m_table(0).filter_value = FILE_MM2

        m_table(1).filter_text = "Nested Files (*.nst)"
        m_table(1).filter_value = FILE_NST

        m_table(2).filter_text = "DXF Cad Files (*.dxf)"
        m_table(2).filter_value = FILE_DXF

        m_table(3).filter_text = "DWG Cad Files (*.dwg)"
        m_table(3).filter_value = FILE_DWG

        m_table(4).filter_text = "SmartCAM Files (*.pm4)"
        m_table(4).filter_value = FILE_PM4

        m_table(5).filter_text = "CNC Files (*.cnc)"
        m_table(5).filter_value = FILE_CNC

        m_table(6).filter_text = "PDB Files (*.pdb)"
        m_table(6).filter_value = FILE_PDB

        m_table(7).filter_text = "MDB Files (*.mdb)"
        m_table(7).filter_value = FILE_MDB

        m_table(8).filter_text = "All Files (*.*)"
        m_table(8).filter_value = FILE_ALL

        m_table(9).filter_text = "PSM Files (*.psm)"
        m_table(9).filter_value = FILE_PSM

        m_table(10).filter_text = "REM Files (*.rem)"
        m_table(10).filter_value = FILE_REM

        m_table(11).filter_text = "CTG Files (*.ctg)"
        m_table(11).filter_value = FILE_CTG

        m_table(12).filter_text = "Table Files (*.tbg)"
        m_table(12).filter_value = FILE_TABLE

        m_table(13).filter_text = "Template Files (*.template)"
        m_table(13).filter_value = FILE_TEMPLATE

    End Sub

    Private Sub frmExplorer_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        modView.ViewDestroy(VIEW_PREVIEW)
        modView.ViewActivate(VIEW_WIRE)
        modView.ViewRefresh()

        modFileIO.AllowMessages(True)

    End Sub

    Private Sub frmExplorer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        m_is_view_initialized = False
        '        'Me.Dispose()
    End Sub

    Private Sub frmExplorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim white_background As Long

        white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)

        If (white_background <> 0) Then
            picPreview1.BackColor = System.Drawing.Color.White
        Else
            picPreview1.BackColor = System.Drawing.Color.Black
        End If

        m_FileName = ""

        InitControls()

        fldrVw.SelectNode(GetFolder(m_curr_file_filter), True)



    End Sub

    Sub InitControls()


        chkAutoSave.Checked = RegGetString("Global", "AutoSave", "1")
        chkRaw.Checked = RegGetString("Global", "Raw", "0")
        ltbCurveRes.Text = RegGetString("Global", "CurveRes", "20")

        InitFilterList()

    End Sub

    Public Sub Usage(
                Caption As String,
                Mode As EXPLORER_OPTION,
                preview As Boolean,
                filters As Long)

        m_caption = Caption
        m_mode = Mode
        m_preview = preview
        m_filters = filters

    End Sub

    Private Function GetFileFilter() As String
        'We get the file patter fron the text of the combo box
        'so we can update the file list to only show those files
        Dim Filter As String
        Dim nLen As Long
        Dim indx As Long

        Filter = lcbFilter.Text

        nLen = Len(Filter)

        indx = InStr(1, Filter, ".")
        indx = IIf((indx <= 0), 1, indx + 1)

        GetFileFilter = "*." & Mid(Filter, indx, (nLen - indx))

    End Function

    Private Sub PreviewRefresh()

        lReturn = PortalExecute("!view:materialextents: regen=0")

    End Sub

    Private Function SelectedFile() As String

        SelectedFile = fldrVw.SelectedNode.Path & "\" & Me.lblFilename.Text

    End Function

    Public Function GetPreRotate() As Double
        'As set by txtPreRotateAngle_Change()
        GetPreRotate = RegGetString("Global", "PreRotate", "0")
        If (IsNumeric(GetPreRotate) = False) Then
            GetPreRotate = 0
            lReturn = RegPutString("Global", "PreRotate", "0")
        End If
    End Function

    Public Function GetStripLayers() As Boolean
        'As set by chkStripLayers_Click()
        GetStripLayers = (RegGetString("Global", "StripLayers", "0") <> 0)
    End Function

    Public Function GetRaw() As Boolean
        'As set by chkRaw_Click()
        GetRaw = (RegGetString("Global", "Raw", "0") <> 0)
    End Function

    Private Sub lcbFilter_TextChange() Handles lcbFilter.TextChange
        Dim Filter As String

        lblFilename.Text = Nothing

        Filter = GetFileFilter()

        fgList.FilePattern = Filter

        If (Filter <> m_curr_file_filter) Then
            m_curr_file_filter = Filter

            fldrVw.SelectNode(GetFolder(m_curr_file_filter), True)
            fldrVw.SelectedNode.EnsureVisible()


        End If


    End Sub


    Private Function GetFolder(ByVal filter_type As String) As String

        Dim last_file_name As String

        m_file_type = modPath.FileTypeGet(Mid(filter_type, 3, 3))

        fraPreRotate.Visible = False

        Select Case m_file_type
            Case FILE_MM2
                last_file_name = PathMM2()
            Case FILE_NST
                last_file_name = PathNST()
            Case FILE_DXF

                last_file_name = PathDXF()
                If (m_mode = EXPLORER_OPTION.EXPLORER_OPEN) Then
                    fraPreRotate.Visible = True
                Else
                    'if we are saving a dxf we do not need to see the frame
                    fraPreRotate.Visible = False
                End If
                mtbPreRotate.Text = RegGetString("Global", "PreRotate", "0")

                'make sure we have a number oterwise conversion fails
                If (IsNumeric(mtbPreRotate.Text) = False) Then mtbPreRotate.Text = "0"

                chkStripLayers.Checked = RegGetString("Global", "StripLayers", "0")

            Case FILE_DWG

                last_file_name = PathDWG()
                fraPreRotate.Visible = True

                mtbPreRotate.Text = RegGetString("Global", "PreRotate", "0")

                'make sure we have a number oterwise conversion fails
                If (IsNumeric(mtbPreRotate.Text) = False) Then mtbPreRotate.Text = "0"

                chkStripLayers.Checked = RegGetString("Global", "StripLayers", "0")

            Case FILE_PM4
                last_file_name = PathPM4()
            Case FILE_PDB
                last_file_name = PathPDB()
            Case FILE_MDB
                last_file_name = PathCMDB()
            Case FILE_PSM

                last_file_name = PathPSM()
                fraPreRotate.Visible = True

                'make sure we have a number oterwise conversion fails
                If (IsNumeric(mtbPreRotate.Text) = False) Then mtbPreRotate.Text = "0"

                mtbPreRotate.Text = RegGetString("Global", "PreRotate", "0")

                chkStripLayers.Checked = RegGetString("Global", "StripLayers", "0")

            Case Else
                last_file_name = App_Path & "\Models\*.*"
        End Select

        GetFolder = NormalizePath(PathDriveFolder(last_file_name))

    End Function

    Private Sub fgList_ItemClick(sender As Object, e As LogicNP.FileViewControl.FileViewEventArgs) Handles fgList.ItemClick
        Dim sFileName As String
        Dim Filter As Long

        'On Error GoTo error_handler

        m__debug_click_event = (InStr(1, Command(), "~e") > 0)

        'Set the text in the filename to the file selected
        lblFilename.Text = PathFileExt(e.Item.Path)
        ltbAddress.Text = SelectedFile()

        Filter = lcbFilter.ItemData(lcbFilter.ListIndex)

        If (Filter < FILE_NO_GRAPHICS) Then

            'Dim the buttons while the app is processing ...
            cmdCancel.Enabled = False
            cmdOpen.Enabled = False

            Windows.Forms.Cursor.Current = Cursors.WaitCursor


            If (m__debug_click_event = True) Then

                MsgBox("Creating Temp Folder")

            End If
            PathTempFolderCreate()

            If (m__debug_click_event = True) Then

                MsgBox("Finished Temp Folder")

            End If

            If (m_is_view_initialized = False) Then

                modView.ViewCreate(VIEW_PREVIEW, Me.picPreview1.Handle)
                modView.ViewActivate(VIEW_PREVIEW)
                m_is_view_initialized = True

            End If


            If (m__debug_click_event = True) Then

                MsgBox("Setting Conversion Parameters")

            End If

            lReturn = modConversion.ConversionParametersSet(
                GetPreRotate(), GetRaw(), GetStripLayers())



            If (m__debug_click_event = True) Then

                MsgBox("Finished Conversion Parameters")

            End If


            'Because we are previewing the file, the intermediate
            'file is always written to the users my documents temp folder instead of
            'appdir\temp\preview.mm2 because of vista
            sFileName = modFileIO.ImportFile(
            SelectedFile(), (PathTempFolder() & "preview.mm2"))

            If (m__debug_click_event = True) Then

                MsgBox("Calculate the dimensions")

            End If

            'CalculateDimensions()
            Dim sPartExtent As String = CalculateDimensionsJustXY()

            Windows.Forms.Cursor.Current = Cursors.Default

            If (m__debug_click_event = True) Then

                MsgBox("Finished Import File")

            End If


            If (m__debug_click_event = True) Then

                MsgBox("Refresh The preview")

            End If

            PreviewRefresh()
            ViewRefresh()

            'sPartExtent = CalculateDimensionsJustXY()
            lblDimensions.Text = "Model extents: " & sPartExtent


            cmdCancel.Enabled = True
            cmdOpen.Enabled = True

        End If

    End Sub

    Public Function GetFilename() As String
        GetFilename = m_FileName
    End Function

    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        m_FileName = ""
        If (lblFilename.Text <> "") Then
            m_FileName = SelectedFile()
        End If
        RegUpdate()

    End Sub

    Private Sub RegUpdate()

        Dim sFileName As String
        Dim ext As String

        sFileName = SelectedFile()

        ext = UCase$(PathExt(sFileName))
        m_file_type = FileTypeGet(ext)

        RegPutString("Fabrication\FileOpen", "LastEXT", m_file_type)

        Select Case m_file_type
            Case FILE_MM2 : PathMM2_Set(sFileName)
            Case FILE_NST : PathNST_Set(sFileName)
            Case FILE_DXF : PathDXF_Set(sFileName)
            Case FILE_DWG : PathDWG_Set(sFileName)
            Case FILE_PM4 : PathPM4_Set(sFileName)
            Case FILE_PDB : PathPDB_Set(sFileName)
            Case FILE_MDB : PathCMDB_Set(sFileName)
            Case FILE_PSM : PathPSM_Set(sFileName)

        End Select

    End Sub

    Private Sub picPreview_DoubleClick(sender As Object, e As EventArgs) Handles picPreview.DoubleClick
        Dim sPartExtent As String = CalculateDimensionsJustXY()
        MessageBox.Show("Model extents: " & sPartExtent)
    End Sub


    Private Sub picPreview_Paint(sender As Object, e As PaintEventArgs) Handles picPreview.Paint
        'modView.ViewResize()
        'modView.ViewRegen()
        'modView.ViewRefresh()

    End Sub


    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_FileName = ""
        Me.Dispose()

    End Sub

    Private Sub fldrVw_AfterSelect(sender As Object, e As LogicNP.FolderViewControl.FolderViewEventArgs) Handles fldrVw.AfterSelect
        fldrVw.SelectedNode.EnsureVisible()
    End Sub

    Private Sub mtbPreRotate_TextChange()

    End Sub

    Private Sub ltbCurveRes_TextChange() Handles ltbCurveRes.TextChange
        If (ltbCurveRes.Text <> "") Then

            If (IsNumeric(ltbCurveRes.Text) = False) Then

                ltbCurveRes.Text = "20"

            End If

            RegPutString("Global", "CurveRes", ltbCurveRes.Text)

        End If
    End Sub
    Private Sub chkStripLayers_CheckStateChanged(sender As Object, e As EventArgs) Handles chkStripLayers.CheckStateChanged
        'CRITICAL to modConversion.
        RegPutString("Global", "StripLayers", chkStripLayers.CheckState)
    End Sub

    Private Sub chkAutoSave_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAutoSave.CheckStateChanged
        RegPutString("Global", "AutoSave", chkAutoSave.CheckState)
    End Sub
    Private Sub chkRaw_CheckStateChanged(sender As Object, e As EventArgs) Handles chkRaw.CheckStateChanged
        'CRITICAL to modConversion.
        RegPutString("Global", "Raw", chkRaw.CheckState)
    End Sub

    Private Sub mtbPreRotate_KeyDown(sender As Object, e As KeyEventArgs) Handles mtbPreRotate.KeyDown
        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub mtbPreRotate_LostFocus(sender As Object, e As EventArgs) Handles mtbPreRotate.LostFocus
        If (mtbPreRotate.Text <> "") Then
            If (IsNumeric(mtbPreRotate.Text) = False) Then mtbPreRotate.Text = "0"
            RegPutString("Global", "PreRotate", mtbPreRotate.Text)
        End If
    End Sub

End Class