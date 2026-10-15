Imports System.ComponentModel
Imports System.IO

Public Class frmAdvancedSorting
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private WithEvents xgStations As DevExpress.XtraGrid.GridControl
    Friend WithEvents sbExit As DevExpress.XtraEditors.SimpleButton
    Private WithEvents ToolSetupView As DevExpress.XtraGrid.Views.Grid.GridView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.xgStations = New DevExpress.XtraGrid.GridControl()
        Me.ToolSetupView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sbExit = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.xgStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolSetupView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xgStations
        '
        Me.xgStations.AllowDrop = True
        Me.xgStations.Cursor = System.Windows.Forms.Cursors.Default
        Me.xgStations.Location = New System.Drawing.Point(12, 12)
        Me.xgStations.MainView = Me.ToolSetupView
        Me.xgStations.Name = "xgStations"
        Me.xgStations.Size = New System.Drawing.Size(454, 430)
        Me.xgStations.TabIndex = 4
        Me.xgStations.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ToolSetupView})
        '
        'ToolSetupView
        '
        Me.ToolSetupView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ToolSetupView.GridControl = Me.xgStations
        Me.ToolSetupView.Name = "ToolSetupView"
        Me.ToolSetupView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToolSetupView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToolSetupView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToolSetupView.OptionsCustomization.AllowColumnMoving = False
        Me.ToolSetupView.OptionsCustomization.AllowFilter = False
        Me.ToolSetupView.OptionsCustomization.AllowGroup = False
        Me.ToolSetupView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ToolSetupView.OptionsCustomization.AllowSort = False
        Me.ToolSetupView.OptionsMenu.EnableColumnMenu = False
        Me.ToolSetupView.OptionsMenu.EnableFooterMenu = False
        Me.ToolSetupView.OptionsMenu.EnableGroupPanelMenu = False
        Me.ToolSetupView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.ToolSetupView.OptionsSelection.UseIndicatorForSelection = False
        Me.ToolSetupView.OptionsView.AllowHtmlDrawGroups = False
        Me.ToolSetupView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.ToolSetupView.OptionsView.ShowDetailButtons = False
        Me.ToolSetupView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ToolSetupView.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.ToolSetupView.OptionsView.ShowGroupPanel = False
        Me.ToolSetupView.OptionsView.ShowViewCaption = True
        Me.ToolSetupView.ViewCaption = "Gag Hits"
        '
        'sbExit
        '
        Me.sbExit.Location = New System.Drawing.Point(368, 457)
        Me.sbExit.Name = "sbExit"
        Me.sbExit.Size = New System.Drawing.Size(75, 23)
        Me.sbExit.TabIndex = 5
        Me.sbExit.Text = "Exit"
        '
        'frmAdvancedSorting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(483, 492)
        Me.Controls.Add(Me.sbExit)
        Me.Controls.Add(Me.xgStations)
        Me.Name = "frmAdvancedSorting"
        Me.Text = "Advanced Grid Sorting"
        CType(Me.xgStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolSetupView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim bFirstX As Boolean = False
    Dim dStoredX As String
    'Dim gridDataList As New BindingList(Of GagInfo)
    Dim gridDatalist As New BindingList(Of GagInfo)
    Dim dGagloc As String
    Dim nGagNumber As Integer
    Private nBlockNums As Long = 0
    Dim sTempFilename As System.IO.StreamWriter
    Dim d80Percent As Double

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadData(Application.StartupPath & "\GagOutput.dat")

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

        ' ToolSetupView.Columns("X_Value").SortOrder = ColumnSortOrder.Ascending

        'ToolSetupView.Columns("X_Value").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending


        Dim sw As New System.IO.StreamWriter(Application.StartupPath & "\output.txt", False)
        sw.Close()


        WriteStartProgram()
        WriteTheCNC()

    End Sub
    Private Sub WriteStartProgram()

        Dim sw As New StreamWriter(Application.StartupPath & "\output.txt", True)

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
        Dim dMatlength = Round(HeaderDoubleGet("Length", 0), Places.Thousandths, True)
        Dim ni As Long
        Dim bDoPercent As Boolean = True

        d80Percent = 0.8 * dMatlength

        Dim sw As New StreamWriter(Application.StartupPath & "\output.txt", True)

        For ni = 0 To ToolSetupView.RowCount - 1
            dXvalue = ToolSetupView.GetRowCellValue(ni, "X_Value")
            dGagloc = ToolSetupView.GetRowCellValue(ni, "Y_Value")
            nGagNumber = ToolSetupView.GetRowCellValue(ni, "GagNum")

            If (dXvalue > d80Percent And bDoPercent = True) Then

                WriteBlockNumString(sw, "M53( X & Y SYNC OFF )")
                WriteBlockNumString(sw, "M20( Y & W GRIP JAWS OPEN )")

                bDoPercent = False
            End If

            If (dXvalue = dStoredX) Then


                WriteBlockNumString(sw, "S_A" & nGagNumber)

            Else

                If (dStoredX < 0) Then

                    WriteBlockNumString(sw, "Y" & dStoredX & " Y" & dGagloc & " T01")

                Else

                    WriteBlockNumString(sw, "X" & dStoredX & " Y" & dGagloc & " T01")

                End If

                If (dXvalue > 16 And bIsNeg = True) Then

                    WriteBlockNumString(sw, "M48(X & Z SYNCHRONOUS)")
                    WriteBlockNumString(sw, "G04P250	(DWELL)")
                    WriteBlockNumString(sw, "M19	(X & Z GRIP JAW CLOSE)")
                    WriteBlockNumString(sw, "M52	(X & Y SYNCHRONOUS)")
                    WriteBlockNumString(sw, "G04P250	(DWELL)")
                    bIsNeg = False

                End If

                WriteBlockNumString(sw, "S_B" & nGagNumber)
                dStoredX = dXvalue

            End If

        Next


        sw.Close()
    End Sub
    Private Sub WriteBlockNumString(sWriteFilename As System.IO.StreamWriter, sThetext As String)

        sWriteFilename.WriteLine("N" & nBlockNums & " " & sThetext)

        nBlockNums = nBlockNums + 1

    End Sub

    Private Sub sbExit_Click(sender As Object, e As EventArgs) Handles sbExit.Click
        End

    End Sub
End Class