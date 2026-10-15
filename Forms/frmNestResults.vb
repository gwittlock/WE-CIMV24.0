Public Class frmNestResults
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
    Private m_status As Long
    Private m_prev_stock_state As Long
    Private m_prev_workzone_state As Long
    Private m_suppress_drawing As Boolean
    Private m_is_active As Boolean

    Private Enum EDrawingOptions As Integer
        PRF_CHECKVISIBLE = &H1
        PRF_NONCLIENT = &H2
        PRF_CLIENT = &H4
        PRF_ERASEBKGND = &H8
        PRF_CHILDREN = &H10
        PRF_OWNED = &H20
    End Enum
    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
        'IsActive = True
    End Function
    Public Function CompletionStatus() As Long
        CompletionStatus = m_status
    End Function
    Private Sub frmNestResults_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        pnlFailedParts.Visible = False

        modView.ViewDestroy(VIEW_PREVIEW)
        modView.ViewActivate(VIEW_WIRE)
        modView.ViewRefresh()

        modFileIO.AllowMessages(True)
    End Sub

    Private Sub frmNestResults_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        m_is_active = False
    End Sub

    Private Sub frmNestResults_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '        Me.Dispose()

    End Sub
    Private Sub frmNestResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim white_background As Long

        Try

            dataNestResults.DataSource = Nothing

            m_suppress_drawing = True

            'So that we can restore the state when this form closes.
            m_prev_stock_state = RegGetString( _
                 "Preferences\ViewOptions", "ShowStock", 1)

            'Set up to display the workzones (independent of app's view modes).
            m_prev_workzone_state = RegGetString( _
                 "Preferences\ViewOptions", "ShowWorkZones", 1)

            RegPutString("Preferences\ViewOptions", "ShowStock", 0)
            RegPutString("Preferences\ViewOptions", "ShowWorkZones", 1)
            modView.SetViewModes(VIEW_WIRE)


            InitResultData()

            white_background = RegGetString("Preferences\ViewOptions", "BackColor", 0)

            If (white_background <> 0) Then
                'picPreview.BackColor = System.Drawing.Color.White
                picPreview.BackColor = System.Drawing.Color.White
            Else
                'picPreview.BackColor = System.Drawing.Color.Black
                picPreview.BackColor = System.Drawing.Color.White
            End If

            m_FileName = ""

            m_is_active = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub InitResultData()

        Dim DBFileName As String = PathPDB()
        Dim dbAdapter As System.Data.OleDb.OleDbDataAdapter
        Dim nFailedPartCount As Long
        Dim ds As New DataSet()

        Try

            Dim con As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBFileName

            txtArea.DataBindings.Clear()
            txtEfficiency.DataBindings.Clear()
            txtRepeat.DataBindings.Clear()
            txtHodParts.DataBindings.Clear()
            txtFailedParts.DataBindings.Clear()
            txtFilename.DataBindings.Clear()

            dbAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet Result]", con)

            dbAdapter.Fill(ds, "SheetResults")
            dbAdapter.Dispose()

            dataNestResults.DataSource = ds.Tables("SheetResults")

            txtArea.DataBindings.Add("Text", ds.Tables("SheetResults"), "Area")
            txtEfficiency.DataBindings.Add("Text", ds.Tables("SheetResults"), "Efficiency")
            txtRepeat.DataBindings.Add("Text", ds.Tables("SheetResults"), "Repeat")
            ' Me.txtHodParts.DataBindings.Add("Text", ds.Tables("SheetResults"), "HoldCount")
            ' Me.txtFailedParts.DataBindings.Add("Text", ds.Tables("SheetResults"), "FailedCount")
            txtFilename.DataBindings.Add("text", ds.Tables("SheetResults"), "Sheet Filename")
            dbAdapter.Dispose()
            ds.Dispose()

            ds = New DataSet

            dbAdapter = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [Failed Part Result]", con)

            dbAdapter.Fill(ds, "FailedParts")

            nFailedPartCount = ds.Tables("FailedParts").Rows.Count

            For ni = 0 To nFailedPartCount - 1

                lstFailedParts.Items.Add(ds.Tables(0).Rows(ni).Item("Part Name").ToString & " " & ds.Tables(0).Rows(ni).Item("Reason"))

            Next

            dbAdapter.Dispose()
            nFailedPartCount = ds.Tables("FailedParts").Rows.Count

            txtFailedParts.Text = CStr(nFailedPartCount)
            ds.Dispose()


            If ds IsNot Nothing Then ds = Nothing

            If dbAdapter IsNot Nothing Then dbAdapter = Nothing

            If con IsNot Nothing Then con = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dataNestResults_PositionChanged(sender As Object, e As EventArgs) Handles dataNestResults.PositionChanged
        Dim sFilename As String

        Try

            sFilename = txtFilename.Text

            If (m_is_view_initialized = False) Then

                modView.ViewCreate(VIEW_PREVIEW, Me.picPreview.Handle)
                modView.ViewActivate(VIEW_PREVIEW)
                m_is_view_initialized = True
            End If

            sFilename = modFileIO.ImportFile( _
                      SelectedFile(), (PathTempFolder() & "\preview.mm2"))

            PreviewRefresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PreviewRefresh()

        lReturn = PortalExecute("!view:materialextents: regen=0")

    End Sub

    Private Function SelectedFile() As String

        SelectedFile = txtFilename.Text

    End Function

    Private Sub frmNestResults_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim sFilename As String

        Try

            sFilename = txtFilename.Text

            'If (m_is_view_initialized = False) Then

            modView.ViewCreate(VIEW_PREVIEW, Me.picPreview.Handle)
            modView.ViewActivate(VIEW_PREVIEW)
            m_is_view_initialized = True
            'End If

            sFilename = modFileIO.ImportFile( _
                      SelectedFile(), (PathTempFolder() & "\preview.mm2"))

            PreviewRefresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub pcPreview_Paint(sender As Object, e As PaintEventArgs) Handles pcPreview.Paint
        modView.ViewResize()
        modView.ViewRegen()
        modView.ViewRefresh()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        'Dim dTotalSheetTravel As Double
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lstFailedParts.Items.Clear()
        pnlFailedParts.Visible = False

        CreateUserVarsInPartResultTable(PathPDB())
        m_status = vbOK

        'dTotalSheetTravel = GetTotalTravelfForSheet(PathPDB())
        Windows.Forms.Cursor.Current = Cursors.Default

        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_status = vbCancel
        lstFailedParts.Items.Clear()
        pnlFailedParts.Visible = False

        Me.Close()

    End Sub

    Private Sub sbReport_Click(sender As Object, e As EventArgs) Handles sbReport.Click
        Try

            pnlFailedParts.Visible = True

        Catch ex As Exception

            MessageBox.Show("sbReport_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        modView.ViewRegen()
    End Sub

    Private Sub picPreview_Paint(sender As Object, e As PaintEventArgs) Handles picPreview.Paint
        modView.ViewRegen()
    End Sub

    Private Sub PictureEdit1_Paint(sender As Object, e As PaintEventArgs)
        modView.ViewRegen()
    End Sub


    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        pnlFailedParts.Visible = False
    End Sub

    Private Sub cmdOK_DragDrop(sender As Object, e As DragEventArgs) Handles cmdOK.DragDrop

    End Sub
End Class