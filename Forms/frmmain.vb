Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.Spreadsheet
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Numerics

Public Class frmMain
    Inherits RibbonForm
    Private Enum SELECTION_FILTER
        SEL_NONE = &H0
        SEL_LAYER = &H1         'OBSOLETE
        SEL_WORK = &H2
        SEL_TOOL = &H4
        SEL_POINT = &H8
        SEL_LINE = &H10
        SEL_ARC = &H20
        SEL_HOLE = &H40
        SEL_PROFILE = &H80
        SEL_COMMAND = &H100
        SEL_FEATURE = &H200
        SEL_SEQUENCE = &H400
        SEL_PATTERN = &H800
        SEL_ALL = &HFFF
    End Enum

    Private Declare Auto Function FindWindow Lib "user32.dll" (
    ByVal lpClassName As String,
    ByVal lpWindowName As String
    ) As IntPtr

    Private Declare Auto Function FindWindowEx Lib "user32.dll" (
    ByVal hwndParent As IntPtr,
    ByVal hwndChildAfter As IntPtr,
    ByVal lpszClass As String,
    ByVal lpszWindow As String
    ) As IntPtr


    Private Declare Function LockWindowUpdate Lib "user32.dll" (ByVal hWndLock As IntPtr) As Boolean
    Private _PaintersCollection As New BorderPaintersHelper()
    Private m_use_ccs_fab_ui As Boolean
    Private bReturn As Boolean
    Private MRUCount As Long      '
    Private m_g_LogRecord As Boolean
    Private m_figure As New VDFigure
    Private m_nTBSelectIndex As Long
    Private m_is_active As Boolean
    Public CCS_FAB_RAN As Boolean

    Public m_forms(0 To (m_max_forms - 1)) As tCiFormHwnd

    Dim status As Long
    Dim nStausBarHeight = 10
    Dim dPnlNestCombosHeight = 33
    Dim hLcWnd As Integer, hLcDrw As Integer, hProps As Integer, hStatbar As Integer, hBlock As Integer
    Dim Wfrm As Integer, Hfrm As Integer
    Dim LcEvent As F_LCEVENT
    Dim PropsWidth As Integer
    Dim DoCustomDrawItem As Boolean = True
    Dim s_filename As String


    Public Structure tCiFormHwnd
        Dim the_form As DevExpress.XtraEditors.XtraForm
        Dim the_hwnd As Long
    End Structure
    'Private m_selection_filter As Long

    Public frm As Form
    Public MRU_ListAray As ArrayList
    'Private m_multiTip As clsMultiTip

    Private m_orientation As Double
    Private m_usage As Long  '(0) Move / (1) Copy

    Private m_is_view_initialized As Boolean

    Private m_instance_id As Long
    Private m_pattern_id As Long
    Private m_is_pattern As Boolean
    Private m_part_id As Long
    Private PatternData As List(Of ThePatternData)
    Private beginLocation As Point
    Private sSheetPicFilename As String

    Private fooni As Integer = 0
    Private Flags As Long

    Const MOVE_BUTTON = 0
    Const COPY_BUTTON = 1

    Public Sub New()
        Dim returnValue As Integer = 0
        Dim cmdArgs As String() = System.Environment.GetCommandLineArgs()

        ''This is just a check to make sure the right project is load when using fab.sln
        Try

            'UserLookAndFeel.Default.SkinName = My.Settings.Default("ApplicationSkinName").ToString()

#If ADVROTOR Then

            SplashScreenManager.ShowForm(GetType(dlgDegMagSplash))
            
#Else
            CheckLicense()
                IsFrmMainLoaded = False


                SplashScreenManager.ShowForm(GetType(SplashScreen1))
#End If


            Me.Location = Screen.AllScreens(UBound(Screen.AllScreens)).Bounds.Location




#If CCS_FAB Then
        'Me.Text = "CCS-FAB"
        Me.Text = "BenchMark Fabrication Software"

        'sReturn = RegPutString("Fabrication", "ImagePath", PathTempFolder)

#ElseIf ADVROTOR Then
            Me.Text = "WE-CIM DEGMAG Lamanator Software"
#Else

            'App.Title = "WE-CIM"
            Me.Text = "WE-CIM Fabrication Software"
#End If
            'Delimiters for formatting internal strings.
            CHR1 = Convert.ToChar(1)

            CHR2 = Convert.ToChar(2)

            'Initailize()

            EngineInit()

            'CreateLogFile()

            InitSkins()

            InitializeComponent()

            'frmPicModeler.TopLevel = False
            'frmPicModeler.TopMost = True
            'Me.pnlPicmodeler.Controls.Add(frmPicModeler)
            'frmPicModeler.Dock = DockStyle.Fill
            'frmPicModeler.Show()

            Me.InitSkinGallery()

            Me.splitContainerControl.SuspendLayout()
            Me.splitContainerControl.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2

            Me.splitContainerControl.ResumeLayout()



        Catch ex As Exception
            MessageBox.Show("New: " & ex.Message)

        End Try

    End Sub
    Private Function GetGroupBounds(ByVal group As RibbonPageGroup) As Rectangle
        Dim groupInfo = RibbonControl.ViewInfo.Panel.Groups.Cast(Of RibbonPageGroupViewInfo)().FirstOrDefault(Function(x) x.PageGroup Is group)
        Return If(groupInfo Is Nothing, Rectangle.Empty, groupInfo.Bounds)

    End Function

    Private Sub AttachPicModeler()

        Try
            ViewSystemInvalidate()
            ViewSystemInit()
            'ViewCreate(VIEW_WIRE, frmPicModeler.Handle)
            ViewCreate(VIEW_WIRE, Me.pnlPicmodeler.Handle)
            'ViewCreate(VIEW_WIRE, Me.PictureBox1.Handle)
            'lReturn = PortalExecute("admin:errors:level=1")

            m_suppress_view_activate = False

            modView.SetViewModes(VIEW_WIRE)
            modView.ViewActivate(VIEW_WIRE)
        Catch ex As Exception
            MessageBox.Show("AttachPicModeler: " & ex.Message)
        End Try

    End Sub
    Sub InitSkins()
        Try
            DevExpress.Skins.SkinManager.EnableFormSkins()
            DevExpress.UserSkins.BonusSkins.Register()

        Catch ex As Exception
            MessageBox.Show("InitSkins: " & ex.Message)
        End Try

    End Sub
    Private Sub InitSkinGallery()
        Dim indx As Integer = 0
        Try
            indx = 0
            SkinHelper.InitSkinGallery(rgbiSkins, True)
            AddHandler rgbiSkins.GalleryInitDropDownGallery, AddressOf rgbiSkins_GalleryInitDropDownGallery
            Dim i As Integer = 0
            For Each itemItem As GalleryItem In rgbiSkins.Gallery.Groups(0).Items
                If itemItem.Caption.Contains("DevExpress") Then
                    Dim item As GalleryItem = itemItem
                    item.Caption = itemItem.Caption.Replace("DevExpress", "WE_CIM")
                    item.Hint = item.Caption
                    If (indx <= 1) Then

                        item.Image = New Bitmap(rgbSkins.Images(indx), New System.Drawing.Size(16, 16))
                        item.HoverImage = New Bitmap(rgbSkins.Images(indx), New System.Drawing.Size(48, 48))
                        indx = indx + 1
                    End If
                End If
            Next itemItem
        Catch ex As Exception
            MessageBox.Show("InitSkinGallery: " & ex.Message)
        End Try
    End Sub

    Private Sub rgbiSkins_GalleryInitDropDownGallery(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs) Handles rgbiSkins.GalleryInitDropDownGallery

    End Sub
    Private Sub rgbiSkins_GalleryItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles rgbiSkins.GalleryItemClick
        ToolStripContainer1.TopToolStripPanel.BackColor = Me.ribbonStatusBar.BackColor
    End Sub

    Private Sub rgbiSkins_GalleryPopupClose(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs) Handles rgbiSkins.GalleryPopupClose
        rgbiSkins.Gallery.ShowGroupCaption = False
    End Sub

    Public Shadows Function IsActive() As Boolean
        IsActive = m_is_active
    End Function
    Private Sub frmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        Try
            'VERY IMPORTANT!!!!!!!!!!!!!!
            'When creating the EXE for CCS FAB we must uncomment the license code used by CCS FAB
            'That would be the call to the CCS DLL and then { If bResult = False Then} Statement below
            'For WE_CIM THe Calls containing bResult and HasLicense() Should be commentted out

            'ITI IS now using 2 different license schemes
            'We must maintain both schemes. The only way to do this
            'is by creating two different exe's
            'for version 4 license. Uncomment the line below and make
            'sure the proper reference is set in the project references
            'Dim ce As New iTi_Benchmark_BusinessLibrary_Wrapper.COMExports

            'ITI changed the way the dll was called during the V4 project
            'the old V4 was called using the following line.
            'make sure to use the line above when generating a V4 exe Not this line
            'Dim ce As New Iti_Ccs_BusinessLibrary_Wrapper.COMExports



            'For version3 use the code line below and again make sure to use the correct reference
            'Dim ce As New Ccs_Library.COMExports

            'call the HasLicense() method on the instance
            Dim bResult As Boolean
            'bResult = ce.HasLicense()
            'bResult = True

            If (m_initializing = True) Then


                m_initializing = False

                If bResult = False Then

                    ' MsgBox("Please Make sure Benchmark is running.", vbCritical, "Benchmark License Not Found")
                    ' End

                End If

                If (IS_CCS_FAB = True) Then

                    bbiBenchMark.Visibility = BarItemVisibility.Always

                Else

                    bbiBenchMark.Visibility = BarItemVisibility.Never

                End If


            End If

            DoCustomDrawItem = False

#If ADVROTOR Then
            'SplashScreenManager.CloseForm()

#End If

        Catch ex As Exception
            MessageBox.Show("frmMain_Activated: " & ex.Message)
        End Try

    End Sub

    Public Sub EngineInit()

        Dim sDllPath As String
        Dim sClassPath As String
        Dim sStoragePath As String
        Dim cmd As String
        Dim error_level As String
        Dim debug_level As Integer
        Dim Flags As Integer
        Dim nResponse As Integer
        Dim sWengJar2 As String
        Dim sWengJar As String
        Dim sToolsJar As String
        Dim sRTJar As String
        Dim User_Folder As String
        Dim Use_Old_Dxf As Boolean
        Dim s_My_Doc_Folder As String


        Try
            IS_CCS_FAB = False

            'bbiBenchMark.Visibility = BarItemVisibility.Never

            modAdmin.UndoInit()



#If CCS_FAB Then

            IS_CCS_FAB = True

            IS_CCS_FAB_SILENT = (InStr(1, UCase(m_command), UCase("~l")) > 0)
            m_use_ccs_fab_ui = (InStr(1, UCase(m_command), UCase("~xls")) > 0)

            If (m_use_ccs_fab_ui = True) Then

                m_xls_Filename = PathXLSSet(m_command)
                IS_CCS_FAB = True


            Else

                IS_CCS_FAB = False

                'CheckIfHaspIsRegistered

                If (m_debug_bootup = True) Then MsgBox("Checked The hasp")
            End If

#End If


            m_using_ide = (InStr(1, Command(), "~ide") > 0)
            m_debug_bootup = (InStr(1, Command(), "~b") > 0)
            m_debug_shutdown = (InStr(1, Command(), "~z") > 0)
            m_bypass_portal = (InStr(1, Command(), "~np") > 0)
            m_debug_menu = (InStr(1, Command(), "~d") > 0)

            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            'Get the Java Runtime Environment information.
            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            'CRITICAL: Without this call, the our dlls will not load.
            App_Path = System.Windows.Forms.Application.StartupPath
            ChDir(App_Path)

            sDllPath = App_Path & "\dlls"

            If (m_debug_bootup) Then MsgBox("sClassPath")
            sClassPath = PathClass()

            If (sClassPath = "") Then
                sWengJar2 = sDllPath & "\Weng2.jar;"
                sWengJar = sDllPath & "\Weng.jar;"
                sToolsJar = App_Path & "\JRE\1.7_051\lib\tools.jar;"
                sRTJar = App_Path & "\JRE\1.7_051\lib\tools.rt"
                sClassPath = sWengJar2 & sWengJar & sToolsJar & sRTJar
                sReturn = (RegPutString("Java", "ClassPath", sClassPath))
            End If

            sReturn = (RegPutString("Java", "JRE", App_Path & "\JRE\1.7_051"))


            If (m_debug_bootup) Then MsgBox("sStoragePath")
            sStoragePath = PathStorage()

            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            'Load the dlls and initialize the Java Virtual Machine.
            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            'CRITICAL: Without this call, the our dlls will not load.
            ' App_Path = System.Windows.Forms.Application.StartupPath
            ChDir(App_Path)

            Flags = 0
            If (m_bypass_portal = True) Then Flags = (Flags Or &H1S)
            If (m_using_ide = True) Then Flags = (Flags Or &H2S)

            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            '2006.11.15 (PE) -- Removed some dependencies on the registry.
            'In particular, Weng.jar is always in the dlls folder and the
            'Storage folder is always under the app folder. Of course, I
            'have allowed for over-rides too (as can be seen by the use
            'of conditional statements).
            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            sDllPath = App_Path & "\dlls"
            If (m_debug_bootup = True) Then MsgBox("sclasspath Before is " & sClassPath)
            'At this point, sClassPath should be (at minimum) something like:
            '   C:\jdk1.3.1\lib\tools.jar;C:\jdk1.3.1\jre\lib\rt.jar
            '
            'NOTE: We check for the empty-string because we want the app
            'to fail if the registry entry is empty or non-existent.
            If ((Len(sClassPath) > 0) And (InStr(sClassPath, "Weng.jar") < 1)) Then
                sClassPath = sDllPath & "\Weng.jar;" & sClassPath
            End If

            If (m_debug_bootup = True) Then MsgBox("sclasspath After is " & sClassPath)

            If (Len(sStoragePath) < 1) Then
                sStoragePath = App_Path & "\Storage"
            End If

            '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            If ((sClassPath = "") Or (sStoragePath = "")) Then
                MsgBox("Unable to find Java Runtime Enviroment!" & vbCrLf & "Application will terminate!", MsgBoxStyle.Critical)
                End
            End If

            If (m_using_ide = True) Then
                sClassPath = ""
            End If
            If (m_debug_bootup) Then
                MsgBox("Before init")
            End If

            lReturn = PortalInit(RegAppKey(), sDllPath, sClassPath, sStoragePath, Flags)

            If (m_debug_bootup) Then MsgBox("After init")

            If (m_debug_bootup) Then MsgBox("PortalInit <" & lReturn & ">")

            If (lReturn = 0) Then

                nResponse = MsgBox("Unable to properly initialize application!" & vbCrLf & "   Do you want to CONTINUE?", MsgBoxStyle.YesNo)

                If (nResponse = MsgBoxResult.No) Then End

            End If

            'This command makes the engine read the 'Verbose' and 'ViewCmds'
            'entries from the registry, both controlling the appearance of
            'various portal commands in both a log file and the ewm. Prior
            'to this command, command filtering was applied only to when
            'actively recording a log file.
            lReturn = PortalExecute("admin:config:")


            'Force the ewm to appear (based upon its latest configuration).
            'Otherwise, you have to remember to use Admin/Settings.
            error_level = CInt(RegGetString("Debug", "Severity", 1))
            'error_level = CInt(613)
            debug_level = CInt(RegGetString("Debug", "Detail", 1))
            cmd = "admin:errors:" & " level=" & error_level & ",debug=" & debug_level

            lReturn = PortalExecute(cmd)

            'Init the Weng.dll

            s_My_Doc_Folder = NormalizePath(modPath.GetMyDocumentsDir()) & "WE-CAD\"

            User_Folder = RegGetString("Global", "WE-CAD_Folder", s_My_Doc_Folder)

            Use_Old_Dxf = RegGetString("Global", "Old_DXF_Convert", 0)

            User_Folder = NormalizePath(User_Folder)

            LcEvent = New F_LCEVENT(AddressOf ProcLcEvent)
            bReturn = Lcad.Initialize()

            'Call Lcad.PropPutStr(0, LC_PROP_G_REGCODE, "984e-1ea8-a604-c653")

        Catch ex As Exception
            MessageBox.Show("EngineInit: " & ex.Message)
        End Try

    End Sub

    Private Sub iNew_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iNew.ItemClick
        lReturn = appMain.ExecuteFunction(101)
    End Sub

    Private Function CheckEWMSettings() As Long
        Dim EWMSettings As Boolean
        Dim EWMFilter As Boolean
        Dim EWMWarnings As Boolean
        Dim EWMUser As Boolean
        Dim EWMInternal As Boolean
        Dim EWMDiagnostics As Boolean
        Dim EWMPortal As Boolean
        Dim EWMUI As Boolean
        Dim EWMDao As Boolean
        Dim EWMNesting As Boolean
        Dim EWMSeeds As Boolean
        Dim EWMFile As Boolean



        Flags = 0

        Try
            EWMSettings = RegGetString("Debug", "admin_ACTIVE", 0)
            EWMFilter = RegGetString("Debug", "admin_FILTERED", 0)
            EWMWarnings = RegGetString("Debug", "admin_WARNING", 0)
            EWMUser = RegGetString("Debug", "admin_USER", 0)
            EWMInternal = RegGetString("Debug", "admin_INTERNAL", 0)
            EWMDiagnostics = RegGetString("Debug", "admin_DIAGNOSTIC", 0)
            EWMPortal = RegGetString("Debug", "admin_PORTAL", 0)
            EWMUI = RegGetString("Debug", "admin_UI", 0)
            EWMDao = RegGetString("Debug", "admin_DAO", 0)
            EWMNesting = RegGetString("Debug", "admin_NESTING", 0)
            EWMSeeds = RegGetString("Debug", "admin_SEED", 0)
            EWMFile = RegGetString("Debug", "admin_FILE", 0)

            If (EWMSettings = True) Then
                lReturn = PortalExecute("admin:ewm: open=1")
                Flags = admin_ACTIVE

                If (EWMFilter = True) Then
                    Flags = Flags + admin_FILTERED
                End If
                If (EWMWarnings = True) Then
                    Flags = Flags + admin_WARNING
                End If
                If (EWMUser = True) Then
                    Flags = Flags + admin_USER
                End If
                If (EWMInternal = True) Then
                    Flags = Flags + admin_INTERNAL
                End If
                If (EWMDiagnostics = True) Then
                    Flags = Flags + admin_DIAGNOSTIC
                End If
                If (EWMPortal = True) Then
                    Flags = Flags + admin_PORTAL
                End If
                If (EWMUI = True) Then
                    Flags = Flags + admin_UI
                End If
                If (EWMDao = True) Then
                    Flags = Flags + admin_DAO
                End If
                If (EWMNesting = True) Then
                    Flags = Flags + admin_NESTING
                End If
                If (EWMSeeds = True) Then
                    Flags = Flags + admin_SEED
                End If
                If (EWMFile = True) Then
                    Flags = Flags + admin_FILE
                End If

                lReturn = PortalExecute("Admin:Errors:Flags=" & Flags)

            Else

                CloseEWM()

            End If
        Catch ex As Exception
            MessageBox.Show("CheckEWMSettings: " & ex.Message)
        End Try
    End Function
    Private Sub FormMgrInit()
        Exit Sub

        'Try
        '    Dim indx As Long

        '    For indx = 0 To (m_max_forms - 1)
        '        m_forms(indx).the_form = Nothing
        '        m_forms(indx).the_hwnd = 0
        '    Next
        'Catch ex As Exception
        '    MessageBox.Show("FormMgrInit: " & ex.Message)
        'End Try


    End Sub


    Private Sub frmMain_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim directory As String = App_Path & "\PatternImages\"
        Dim di As New IO.DirectoryInfo(directory)
        Dim diar1 As IO.FileInfo()

        Try
            diar1 = di.GetFiles("*.png")

            For Each dra In diar1

                FileSystem.Kill(dra.FullName)

            Next
        Catch ex As Exception
            MessageBox.Show("frmMain_DragDrop: " & ex.Message)
        End Try

    End Sub
    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        CloseEWM()

        End

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            If (bIsGraphicsEditorLoaded) Then
                lReturn = PortalExecute("*codegen:xrefdestroy:")
                lReturn = PortalExecute("!view:highlight:id=0")
                lReturn = PortalExecute("Admin:GlobalModel:")  'for safety

                modSelection.DeselectAll()

                bIsGraphicsEditorLoaded = False
                m_is_active = False
                CloseFirstPanel()
                frmGraphicsEditor.Dispose()
            End If

            modFile.ConditionalFileSave()

            If (RegGetString("Debug", "UseAutoLog", 0) = 1) Then
                lReturn = PortalExecute("cmdstop:")
            End If


            CloseEWM()

            RibbonControl.Toolbar.SaveLayoutToXml(Application.StartupPath & "\RibbonSettings.xml")
            'Me.RibbonControl.Toolbar.SaveLayoutToXml(Application.StartupPath & "\RibbonSettings.xml")


            'Close the License
            IP2Lib32Managed.WR_Close(0)

            'Save the window dimensions for reuse.
            If (Me.WindowState <> FormWindowState.Minimized) Then
                sReturn = RegPutString("Fabrication\Main", "Width", Me.Width)
                sReturn = RegPutString("Fabrication\Main", "Height", Me.Height)
                sReturn = RegPutString("Fabrication\Main", "Top", Me.Top)
                sReturn = RegPutString("Fabrication\Main", "Left", Me.Left)
            End If

            '' Unload the docking forms.
            'For indx = 0 To (m_max_forms - 1)
            '    If (m_forms(indx).the_hwnd <> 0) Then
            '        FormMgrClose(m_forms(indx).the_form.Handle)
            '    End If
            'Next

            PortalTerminate()
        Catch ex As Exception
            MessageBox.Show("frmMain_FormClosing: " & ex.Message)
        End Try

        Me.Dispose()
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try

            If (e.KeyCode = Keys.M AndAlso e.Modifiers = Keys.Control) Then
                If (bIsGraphicsEditorLoaded = False) Then
                    ''LockWindowUpdate(pnlPicmodeler.Handle)

                    modView.MaterialExtents()
                    ''LockWindowUpdate(0&)

                End If

            End If

            If (bIsGraphicsEditorLoaded = True) Then
                If (e.KeyCode = Keys.F3) Then
                    frmGraphicsEditor.ExecuteSearch()
                End If

            End If

            If (e.KeyCode = System.Windows.Forms.Keys.Escape) Then
                defaultToolTipController1.DefaultController.HideHint()
                ModeCancelCurrent()
            End If

        Catch ex As Exception
            MessageBox.Show("frmMain_KeyDown: " & ex.Message)
        End Try
    End Sub

    Private Sub frmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        'If (m_is_nesting = True = False And bIsEntityLoaded = False And bIsCfgManLoaded = False) Then
        ProcessKeyPress(e.KeyCode, e.Modifiers)
        'End If

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim yo As Long
        Dim xo As Long
        Dim DY As Long
        Dim DX As Long

        Try
            Update_Appdb_To_Current()

            DefaultLookAndFeel1.LookAndFeel.SkinName = RegGetString("Global", "SkinName", "Dark Side") 'My.Settings.Default("ApplicationSkinName").ToString()

            bbi_Rittal.Visibility = BarItemVisibility.Never

            bbiDiamondLife.Visibility = BarItemVisibility.Never

            bbiFreightCarAmerica.Visibility = BarItemVisibility.Never

            IS_APIHEATTRANSFER = False
            bbiCreateLams.Visibility = BarItemVisibility.Never
            bbiRotors.Visibility = BarItemVisibility.Never




#If Rittal Then
            bbi_Rittal.Visibility = BarItemVisibility.Always
#End If

#If APIHeatTransfer Then

            'bbiAPiCopy.Visibility = BarItemVisibility.Always

#End If

#If ADVROTOR Then
            ribNesting.Visible = False
            ribProcess.Visible = False
            EditRibbonPage.Visible = False
            CreateRibbonPage.Visible = False
            ModifyRibbonPage.Visible = False
            SequenceRibbonPage.Visible = False
            MacroRibbonPage.Visible = False
            SplashScreenManager.CloseForm()
            bbiCreateLams.visibility =BarItemVisibility.Always
            bbiRotors.Visibility = BarItemVisibility.Always
#Else

            rpgForTesting.visible=false
#End If

            Me.Text = App_Title

            Me.HelpProvider1.HelpNamespace = Application.StartupPath & "\Help\WECIM_V21.chm"
            Me.DoubleBuffered = True

            'AddHandler rpgCustomMacros.Ribbon.ItemClick, AddressOf ribbonControl_ItemClick

            lReturn = Update_CMDB_To_Current()

            MRU_ListAray = New ArrayList

            lReturn = CheckEWMSettings()

            AttachPicModeler()

            FormMgrInit()

            statusDate.Caption = "Date: " & Now.ToString("MMMM dd, yyyy")
            statusTime.Caption = "Time: " & Now.ToString("hh:mm tt")

            'TODO:1-6 pnlBump.Height = pnlSheetPatternCombo.Height
            yo = RegGetString("Fabrication\Main", "Top", 0)
            xo = RegGetString("Fabrication\Main", "Left", 0)
            DY = RegGetString("Fabrication\Main", "Height", Screen.GetBounds(Me).Height)
            DX = RegGetString("Fabrication\Main", "Width", Screen.GetBounds(Me).Width)

            beGraphicsPref.EditValue = RegGetString("Preferences", "GraphicsDelay", 0)

            Me.WindowState = vbNormal
            'Me.StartUpPosition = vbManual

            Me.Top = yo
            Me.Left = xo
            Me.Height = DY
            Me.Width = DX

            bbCMDB.EditValue = RegGetString("ConfigurationManager", "Database", My.Application.Info.DirectoryPath & "\database\cmdb.mdb")
            bbResetAppdb.EditValue = RegGetString("Database", "AppDB", My.Application.Info.DirectoryPath & "\database\appdb.mdb")

            GetRecentFiles()
            modModeMgmt.ModeMgmtInit()
            'ModesReset

            modMeasure.MeasureInit()

            AdminRibbonPage.Visible = m_debug_menu
            'rpgForTesting.Visible = m_debug_menu

            ' m_multiTip = New clsMultiTip
            m_curr_dlg = Nothing

            LoadUserMacros()

            m_selection_mode = False

            If (FileExists(Application.StartupPath & "\RibbonSettings.xml") = True) Then
                Me.RibbonControl.Toolbar.RestoreLayoutFromXml(Application.StartupPath & "\RibbonSettings.xml")
            End If


            modModeMgmt.HotDotEnable(True)

#If CCS_FAB Then
            bbiDeactivate.Visibility = BarItemVisibility.Never
            Me.rpgBenchMark.Visible = True

            If (InStr(1, UCase$(m_command), "~XLS") > 0) Then
                bbExport.Enabled = False
            Else
                bbExport.Enabled = True
            End If

#Else
            bbiDeactivate.Visibility = BarItemVisibility.Always
            'rpgBenchMark.Visible = False

#End If

            If Not m_debug_menu Then
                bbiForTesting.Visibility = BarItemVisibility.Never
                bbiForm1.Visibility = BarItemVisibility.Never
                BarButtonItem17.Visibility = BarItemVisibility.Never
                BarButtonItem19.Visibility = BarItemVisibility.Never
                bbiForm1.Visibility = BarItemVisibility.Never
                btmHeatTransfer.Visibility = BarItemVisibility.Never
                BarButtonItem20.Visibility = BarItemVisibility.Never

            End If


#If DIAMOND Then
            rpgCustomization.Visible = True
            bbiDiamondLife.Visibility = BarItemVisibility.Always

#Else
            rpgCustomization.Visible = False
#End If


            rpgCustomization.Visible = True

            lReturn = SetFormIcon(Me)

#If (IS_CCS_FAB = True) Then

                b_ShowDefaultsDialog = CBool(RegGetString("Global", "ShowDialog", "0"))

                If (b_ShowDefaultsDialog = True Or RegGetString("Global", "MachineID", 0) = 0) Then

                    frmCCS_FAB_Setup.ShowDialog()

                End If


#ElseIf (ADVROTOR) Then
            lReturn = appMain.ExecuteFunction(102)
#Else


                frmStartUp.ShowDialog(Me)

#End If


            Timer2.Enabled = True

            If (RegGetString("Debug", "UseAutoLog", 0) = 1) Then
                Dim today = Date.Today
                Dim day = today.Day
                Dim month = today.Month
                Dim year = today.Year
                Dim hour = DateTime.Now.Hour
                Dim minute = DateTime.Now.Minute
                Dim LogFileName As String

                LogFileName = NormalizePath(App_Path) &
                                "Debug\" &
                                year &
                                "_" & month &
                                "_" & day &
                                "_" & hour &
                                "_" & minute & ".log"
                lReturn = PortalExecute("cmdlog:file=" & QStr(LogFileName))

            End If

            Me.KeyPreview = True


        Catch ex As Exception
            MessageBox.Show("frmMain_Load: " & ex.Message)
        End Try

    End Sub
    Private Sub splitContainerControl_ClientSizeChanged(sender As Object, e As EventArgs) Handles splitContainerControl.ClientSizeChanged


        Try
            If (splitContainerControl.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both) Then
                frm.Height = splitContainerControl.Panel1.Height
            End If
            pnlPicmodeler.Left = 5

            If (pnlNestCombos.Visible = True) Then
                pnlPicmodeler.Height = splitContainerControl.Panel2.Height - nStausBarHeight - dPnlNestCombosHeight
            Else
                pnlPicmodeler.Top = 5
                pnlPicmodeler.Height = splitContainerControl.Panel2.Height - nStausBarHeight
            End If

            pnlPicmodeler.Width = splitContainerControl.Panel2.Width - 15


        Catch ex As Exception
            MessageBox.Show("splitContainerControl_ClientSizeChanged: " & ex.Message)
        End Try

    End Sub

    Private Sub splitContainerControl_Resize(sender As Object, e As EventArgs) Handles splitContainerControl.Resize

        Try
            If (IsNothing(frm) = False) Then

                frm.Size = Me.splitContainerControl.Panel1.Size

            End If
        Catch ex As Exception
            MessageBox.Show("splitContainerControl_Resize: " & ex.Message)
        End Try

    End Sub
    Private Sub splitContainerControl_SplitterMoved(sender As Object, e As EventArgs) Handles splitContainerControl.SplitterMoved

        Try
            If (IsNothing(frm) = False) Then
                frm.Size = Me.splitContainerControl.Panel1.Size
            End If

            pnlPicmodeler.Left = 5

            If (pnlNestCombos.Visible = True) Then
                pnlPicmodeler.Height = splitContainerControl.Panel2.Height - nStausBarHeight - dPnlNestCombosHeight
            Else
                pnlPicmodeler.Top = 5
                pnlPicmodeler.Height = splitContainerControl.Panel2.Height - nStausBarHeight

            End If

            pnlPicmodeler.Width = splitContainerControl.Panel2.Width - 15
        Catch ex As Exception
            MessageBox.Show("splitContainerControl_SplitterMoved: " & ex.Message)
        End Try
    End Sub

    Private Sub iOpen_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iOpen.ItemClick

        lReturn = appMain.ExecuteFunction(102)

    End Sub

    Private Sub iMerge_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iMerge.ItemClick

        lReturn = appMain.ExecuteFunction(107)

    End Sub

    'Where file_name represents the file in memory.
    Public Sub ShowCombos(file_name As String)

        Try
            If (GetViewContext() <> VIEW_INVALID) Then

                cboSheets.Properties.Items.Clear()
                cboPatterns.Properties.Items.Clear()

                'Populate and display the Sheet combo, as necessary.
                SheetComboShow(file_name)

                'Likewise for the Pattern combo.
                PatternComboShow()

                'Place and display.
                ShowCombos_core()

            End If
        Catch ex As Exception
            MessageBox.Show("ShowCombos: " & ex.Message)
        End Try

    End Sub


    Public Sub ShowCombos_core()

        Try
            If (GetViewContext() <> VIEW_INVALID) Then

                pnlNestCombos.Visible = ((cboSheets.Properties.Items.Count() > 0) Or (cboPatterns.Properties.Items.Count() > 0))

                'Me.Refresh()

                If (bIsPatternBumpLoaded = False) Then

                    '    'TODO:1-6  pnlBump.Height = pnlSheetPatternCombo.Height
                    'Else
                    'pnlNestCombos.Visible = False
                End If


            End If
        Catch ex As Exception
            MessageBox.Show("ShowCombos_core: " & ex.Message)
        End Try

    End Sub

    'Where file_name represents the file in memory.
    Private Sub SheetComboShow(file_name As String)

        Dim indx As Long

        Try
            indx = SheetComboPopulate(file_name, cboSheets)
            If (indx >= 0) Then

                'Suppress recursive behavior (ie. side effect of setting ListIndex)
                m_suppress = True

                'Set index to match the given (current) file !
                cboSheets.SelectedIndex = indx

                m_suppress = False

            End If

            cboSheets.Visible = (cboSheets.Properties.Items.Count > 0)
            lblSheets.Visible = (cboSheets.Properties.Items.Count > 0)
        Catch ex As Exception
            MessageBox.Show("SheetComboShow:" & ex.Message)
        End Try

    End Sub
    Public Sub PatternComboShow()

        Dim lPatternCount As Long
        Dim nI As Integer
        Dim lPatID As Long
        Dim sPatName As String

        Try
            m_suppress = True

            cboPatterns.Properties.Items.Clear()

            lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBPATTERN)
            lPatternCount = PortalGetInt("count", 0)

            If (lPatternCount > 0) Then
                cboPatterns.Properties.Items.Add(New myItemData("(None)", 0))
                cboPatterns.SelectedIndex = 0


                lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBPATTERN)
                lPatternCount = PortalGetInt("count", 0)

                For nI = 0 To lPatternCount - 1
                    lReturn = PortalExecute("*Model:Get2:indx=" & nI & ",type=" & c_DBPATTERN)
                    lPatID = PortalGetInt("id", 0)
                    sPatName = EntityStringGet(lPatID, "_label", "<error>")

                    cboPatterns.Properties.Items.Add(New myItemData(sPatName, lPatID))

                Next

            End If

            ' cboPatterns.Visible = True 'lPatternCount > 0

            m_suppress = False
        Catch ex As Exception
            MessageBox.Show("PatternComboShow: " & ex.Message)
        End Try

    End Sub

    Private Sub bbViewFull_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewFull.ItemClick
        ''LockWindowUpdate(pnlPicmodeler.Handle)

        modView.ViewAll()

        ''LockWindowUpdate(0&)

    End Sub

    'NOTE: Unlike CI, we allow only a single form to be open.
    'We may, of course, want to change this but ....
    Public Sub FormMgrOpen(ByVal oForm As Form, sncs As Long)
        Dim newForm As Form = oForm
        Dim form_is_open As Boolean
        Dim the_hwnd As Long

        Try
            If (frmWorkZones.IsActive = True) Then
                frmWorkZones.Close()

            End If

            If (bIsCfgManLoaded = False) Then

                'This way we have only one window open at a time.
                FormMgrClose(m_forms(0).the_hwnd)

                m_forms(0).the_form = newForm

                m_forms(0).the_hwnd = the_hwnd
            End If

            If (sncs <> 9500) Then
                Select Case UCase(oForm.Name)
                    Case "DLGENTITY"
                        oForm.Width = 283
                    Case "FRMSHAPELIBRARY"
                        If (frmShapeLibrary.nMacroOP = MACRO_OPTION.MACRO_NORM) Then
                            'check maro mode for proper width assignment
                            oForm.Width = 299
                        Else
                            oForm.Width = 446
                        End If


                End Select
            End If
            newForm.SuspendLayout()

            splitContainerControl.Panel1.Controls.Clear()

            newForm.TopLevel = False

            newForm.Parent = splitContainerControl.Panel1

            splitContainerControl.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both

            splitContainerControl.SplitterPosition = oForm.Width

            newForm.Size = Me.splitContainerControl.Panel1.Size

            frm = newForm

            newForm.ResumeLayout()

            newForm.Show()

            the_hwnd = newForm.Handle

            form_is_open = (m_forms(0).the_hwnd = the_hwnd)

            If (form_is_open = False) Then

                If (sncs <> 9500) Then
                    'If (bIsCfgManLoaded = False) Then

                    '    'This way we have only one window open at a time.
                    '    FormMgrClose(m_forms(0).the_hwnd)

                    '    m_forms(0).the_form = newForm

                    '    m_forms(0).the_hwnd = the_hwnd
                    'End If
                End If

                'Show the proper icon for the app
                lReturn = SetFormIcon(oForm)

            End If

            If (IsFrmMainLoaded = True) Then

                'modView.ViewResize()

            End If

        Catch ex As Exception
            MessageBox.Show("FormMgrOpen: " & ex.Message)
        End Try

    End Sub
    Public Sub FormMgrClose(the_hwnd As Long)

        Dim indx As Long

        On Error Resume Next

        CloseFirstPanel()


        'If (the_hwnd > 0) Then
        '    For indx = 0 To (m_max_forms - 1)
        '        If (m_forms(indx).the_hwnd = the_hwnd) Then
        '            'By set the_hwnd to zero, we prevent recursive unloading
        '            m_forms(indx).the_hwnd = 0
        '            m_forms(indx).the_form.Dispose()
        '            m_forms(indx).the_form = Nothing
        '            pnlPicmodeler.Focus()
        '            Exit For
        '        End If
        '    Next
        'End If


    End Sub

    Private Sub iOpenPDB_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iOpenPDB.ItemClick

        lReturn = appMain.ExecuteFunction(108)  'NOTE: not in dat file

    End Sub

    Public Sub CloseFirstPanel()

        Try
            splitContainerControl.Panel1.Controls.Clear()

            Me.splitContainerControl.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2

            pnlPicmodeler.Left = 5

            If (pnlNestCombos.Visible = True) Then
                pnlPicmodeler.Height = splitContainerControl.Panel2.Height - nStausBarHeight - dPnlNestCombosHeight
            Else
                pnlPicmodeler.Top = 5
                pnlPicmodeler.Height = splitContainerControl.Panel2.Height - nStausBarHeight
            End If

            pnlPicmodeler.Width = splitContainerControl.Panel2.Width - 15

            modView.ViewRegen()
        Catch ex As Exception
            MessageBox.Show("CloseFirstPanel: " & ex.Message)
        End Try

    End Sub

    Private Sub bbConfigMan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbConfigMan.ItemClick

        lReturn = appMain.ExecuteFunction(501)

    End Sub

    Private Sub iPrintTools_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iPrintTools.ItemClick

        frmPrintTools.ShowDialog(Me)

    End Sub

    Private Function ScriptGet(cmd As String) As String

        Dim indx As Long
        Dim jndx As Long
        Dim slen As Long
        Dim quotes As Long
        Dim QUOTE As String

        ScriptGet = ""  'assume no argument.

        Try


            QUOTE = Chr(34)

            slen = Len(cmd)
            indx = InStr(1, Command(), "~r")

            If (indx > 0) Then

                indx = indx + 3  'Move past the blank

                quotes = 0
                If (Mid(cmd, indx, 1) = QUOTE) Then
                    quotes = quotes + 1
                    indx = indx + 1
                End If

                jndx = indx
                Do While (True)

                    If (jndx > slen) Then Exit Do

                    If (Mid(cmd, jndx, 1) = QUOTE) Then
                        quotes = quotes + 1
                        If (quotes >= 2) Then Exit Do
                    End If

                    jndx = jndx + 1

                Loop

                If (quotes >= 2) Then jndx = jndx - 1

                ScriptGet = Mid(cmd, indx, (jndx - indx + 1))

            End If
        Catch ex As Exception
            MessageBox.Show("ScriptGet: " & ex.Message)
        End Try

    End Function

    Private Sub bbViewCodeViewer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewCodeViewer.ItemClick

        lReturn = appMain.ExecuteFunction(209)

    End Sub

    'To be called by a docking form (during its activation).
    Public Sub SetCurrentDialog(dlg As DevExpress.XtraEditors.XtraForm)

        m_curr_dlg = dlg

    End Sub


    Private Sub sbViewOptions_Popup(sender As Object, e As EventArgs) Handles sbViewOptions.Popup

        Try
            BarShowStock.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowStock", 1) = 1, True, False)
            BarShowWorkzones.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowWorkZones", 1) = 1, True, False)
            BarShowToolpathDashed.Checked = IIf(RegGetString("Preferences\ViewOptions", "ToolpathGeometry", 0) = 1, True, False)
            BarShowProfileMarkers.Checked = IIf(RegGetString("Preferences\ViewOptions", "ProfileMarkers", 0) = 1, True, False)
            BarShowEndpoints.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowEndPts", 0) = 1, True, False)
            BarShowInstanceText.Checked = IIf(RegGetString("Preferences\ViewOptions", "TextCommands", 1) = 1, True, False)
            BarShowNibbleHits.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowNibbleHits", 1) = 1, True, False)
            BarHighlightProfiles.Checked = IIf(RegGetString("Preferences\ViewOptions", "HighLight", 1) = 1, True, False)
            BarShowRapidMoves.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowRapids", 0) = 1, True, False)
            BarShowSolidHits.Checked = IIf(RegGetString("Preferences\ViewOptions", "SolidHits", 0) = 1, True, False)
            BarShowLegend.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowLegend", 1) = 1, True, False)
            BarShowHandles.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowHandles", 1) = 1, True, False)
            BarSaveLastUsed.Checked = IIf(RegGetString("Preferences\ViewOptions", "SaveLastUsed", 1) = 1, True, False)
            BarUseWhiteBG.Checked = IIf(RegGetString("Preferences\ViewOptions", "BackColor", 0) = 1, True, False)
            BarShowTableGraphics.Checked = IIf(RegGetString("Preferences\ViewOptions", "ShowTableGraphics", 0) = 1, True, False)
            barSnapResolution.EditValue = RegGetString("Preferences\ViewOptions", "SnapGridResolution", 0.0001)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub UpdateViewOptions()
        Try
            Call RegPutString("Preferences\ViewOptions", "ShowStock", IIf(BarShowStock.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "ShowWorkZones", IIf(BarShowWorkzones.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "ToolpathGeometry", IIf(BarShowToolpathDashed.Checked = True, 1, 0))
            Call RegPutString("Preferences\ViewOptions", "ProfileMarkers", IIf(BarShowProfileMarkers.Checked = True, 1, 0))
            Call RegPutString("Preferences\ViewOptions", "ShowEndPts", IIf(BarShowEndpoints.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "TextCommands", IIf(BarShowInstanceText.Checked = True, 1, 0))
            Call RegPutString("Preferences\ViewOptions", "ShowNibbleHits", IIf(BarShowNibbleHits.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "Highlight", IIf(BarHighlightProfiles.Checked = True, 1, 0))
            Call RegPutString("Preferences\ViewOptions", "ShowRapids", IIf(BarShowRapidMoves.Checked = True, 1, 0))
            Call RegPutString("Preferences\ViewOptions", "SolidHits", IIf(BarShowSolidHits.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "SnapGridResolution", barSnapResolution.EditValue)
            Call RegPutString("Preferences\ViewOptions", "ShowLegend", IIf(BarShowLegend.Checked = True, 1, 0))
            Call RegPutString("Preferences\ViewOptions", "ShowHandles", IIf(BarShowHandles.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "SaveLastUSed", IIf(BarSaveLastUsed.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "BackColor", IIf(BarUseWhiteBG.Checked = True, 1, 0))

            Call RegPutString("Preferences\ViewOptions", "ShowTableGraphics", IIf(BarShowTableGraphics.Checked = True, 1, 0))

            modView.SetViewModes(modView.GetViewContext())
            modView.ViewRegen()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub BarSaveLastUsed_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarSaveLastUsed.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowNibbleHits_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowNibbleHits.ItemClick

        UpdateViewOptions()
    End Sub

    Private Sub BarHighlightProfiles_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarHighlightProfiles.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowEndpoints_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowEndpoints.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowHandles_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowHandles.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowInstanceText_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowInstanceText.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowLegend_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowLegend.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowProfileMarkers_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowProfileMarkers.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowRapidMoves_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowRapidMoves.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowSolidHits_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowSolidHits.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowStock_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowStock.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowTableGraphics_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowTableGraphics.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowToolpathDashed_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowToolpathDashed.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub BarShowWorkzones_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarShowWorkzones.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub barSnapResolution_EditValueChanged(sender As Object, e As EventArgs) Handles barSnapResolution.EditValueChanged
        UpdateViewOptions()
    End Sub

    Private Sub BarUseWhiteBG_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarUseWhiteBG.ItemClick
        UpdateViewOptions()
    End Sub

    Private Sub iSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iSave.ItemClick
        lReturn = appMain.ExecuteFunction(103)
    End Sub

    Private Sub iExportCNC_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iExportCNC.ItemClick
        frmCodeGen.ShowDialog(Me)

    End Sub
    Private Sub bbViewRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewRefresh.ItemClick
        modView.ViewRegen()
    End Sub

    Private Sub iUndo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iUndo.ItemClick
        lReturn = appMain.ExecuteFunction(401)
    End Sub


    Private Sub iRedo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iRedo.ItemClick
        lReturn = appMain.ExecuteFunction(402)
    End Sub

    Private Sub iDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iDelete.ItemClick
        lReturn = appMain.ExecuteFunction(2003)
    End Sub

    Private Sub iPurge_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iPurge.ItemClick
        lReturn = appMain.ExecuteFunction(2004)
    End Sub

    Private Sub iChangeTool_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iChangeTool.ItemClick
        lReturn = appMain.ExecuteFunction(2005)

    End Sub

    Private Sub iChangeAttrib_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iChangeAttrib.ItemClick
        lReturn = appMain.ExecuteFunction(2006)
    End Sub

    Private Sub ExecuteMeasure(sToolTipText As String)

        Dim args As New DevExpress.Utils.ToolTipControllerShowEventArgs()

        Try
            args.ToolTipType = DevExpress.Utils.ToolTipType.Standard
            args.ToolTip = sToolTipText
            args.ShowBeak = True
            args.RoundRadius = 7
            args.Rounded = True

            Me.defaultToolTipController1.DefaultController.ShowHint(args)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub ExecuteFunction(Button As Integer, Shift As Integer, x As Single, y As Single)

        Dim scrPoint As PortalPoint
        Dim lGE_RecNo As Long
        Dim start_id As Long
        Dim higher_id As Long
        Dim ConvertedPoint As PortalPoint
        Dim pick_side As Long
        Dim ent_type As Long
        Dim sToolTipText As String

        Try
            'Get the screen pick point.
            scrPoint.dx = x
            scrPoint.dy = y
            scrPoint.dZ = 0

            'Convert to model-space.
            lReturn = PortalScreenToWorld(scrPoint)

            'Get the actual model-space coordinates.  The values may
            'differ from those of scrPoint if snap behavior is active.
            lReturn = PortalExecute("!view:pick:x=" & scrPoint.dx & ",y=" & scrPoint.dy)
            m_pickX = PortalGetDouble("px", 0.0#)
            m_pickY = PortalGetDouble("py", 0.0#)
            m_pickZ = PortalGetDouble("pz", 0.0#)

            'Limit the number of digits that are displayed in a form when set
            'via ReturnClickToControl().  Note, the modeler's precision is 1.e-6.
            m_pickX = CDbl(Round(m_pickX, modMath.Places.Millionths))
            m_pickY = CDbl(Round(m_pickY, modMath.Places.Millionths))
            m_pickZ = CDbl(Round(m_pickZ, modMath.Places.Millionths))

            ConvertedPoint.dx = m_pickX
            ConvertedPoint.dy = m_pickY
            ConvertedPoint.dZ = m_pickZ

            'Get some attributes from the selected entity.
            start_id = PortalGetInt("id", 0)
            ent_type = PortalGetInt("type", c_INVALID)
            m_figure.Init(start_id, ent_type)

            pick_side = PortalGetInt("end", 0)
            PickInfoInit()
            modPick.SetPickInfo(m_figure, ConvertedPoint, 0, pick_side, CLng(Shift))

            If (IsModeActive(MODE_INQUIRE) = True) Then

                If (start_id > 0) Then

                    sToolTipText = BuildTooltip(start_id)

                    Dim args As New DevExpress.Utils.ToolTipControllerShowEventArgs()
                    'setup the SuperToolTip...
                    'args.SuperTip = superToolTip1
                    args.ToolTipType = DevExpress.Utils.ToolTipType.Standard
                    args.ToolTip = sToolTipText
                    args.ShowBeak = True
                    args.RoundRadius = 7
                    args.Rounded = True

                    Me.defaultToolTipController1.DefaultController.ShowHint(args)


                End If
            End If

            ReturnClickToControl(m_pickX, m_pickY, m_pickZ, start_id, pick_side, start_id)

            If (bIsCodeGenLoaded = True) Then

                lReturn = frmCodeGen.EchoLocation(m_pickX, m_pickY)

            ElseIf (bIsGraphicsEditorLoaded = True) Then

                higher_id = PortalGetInt("id", 0)

                'Obtain the record number of the first clfile record
                'that references the given entity. We do this because
                'the relationship between an entity and the blocks of
                'cnc code can be one-to-many.
                lReturn = PortalExecute("*codegen:xrefrecno:id=" & higher_id)
                lGE_RecNo = PortalGetInt("recno", 0)

                'NOTE: As a side effect of setting the list index,
                'frmGraphicsEditor.lstGraphicsEditor_Click() is called,
                'in turn behaving as if you selected a block of cnc code.
                If (lGE_RecNo >= 0) And (lGE_RecNo < frmGraphicsEditor.lstGraphicsEditor.Items.Count) And (lReturn = 1) Then
                    frmGraphicsEditor.lstGraphicsEditor.SelectedIndex = CInt(lGE_RecNo)
                Else
                    frmGraphicsEditor.lstGraphicsEditor.SelectedIndex = 0
                End If

            ElseIf (dlgFlipSheet.IsActive() = True) Then
                Dim sDatVarName = GetValueFromDelimitedData(dlgFlipSheet.vgProplist.FocusedRow.Tag, "DatVarName", Nothing)
                If (sDatVarName = "profid") Then
                    dlgFlipSheet.vgProplist.FocusedRow.Properties.Value = start_id
                End If


            End If

            If ((modSelection.IsActive() = True) And
                 (bIsCodeGenLoaded = False)) Then

                If (start_id <> 0 And Shift <> Keys.Control) Then

                    'TODO: If frmSeqMove is open, should restrict selections to
                    'those entities that are in the currently selected work-zone.
                    lReturn = SelectEntity(start_id)
                    If frmTanaka.IsActive = True Then
                        frmTanaka.AddInstanceToList(start_id)
                        higher_id = frmTanaka.lstAllInstance.FindStringExact(start_id)
                        frmTanaka.lstAllInstance.Items.RemoveAt(higher_id)
                    End If

                    If (lReturn = 1) Then
                        'higher_id = PortalGetInt("id", 0)
                        If (IsSelected(start_id) = True) Then SynchronizeUI(SelectedCount())
                    End If

                ElseIf (start_id <> 0 And Shift = Keys.Control) Then
                    lReturn = DeselectEntity(start_id)
                    lReturn = PortalExecute("selector:empty:")

                    SynchronizeUI(SelectedCount())
                End If

            End If

            m_lastX = m_pickX
            m_lastY = m_pickY
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub iChangeEntities_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iChangeEntities.ItemClick
        lReturn = appMain.ExecuteFunction(2007)
    End Sub

    Private Function IsDialogActive() As Boolean
        IsDialogActive = ((m_curr_dlg Is Nothing) = False)
    End Function


    Private Sub bbViewEntityList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewEntityList.ItemClick
        lReturn = appMain.ExecuteFunction(208)
    End Sub

    Private Sub bbViewTravel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewTravel.ItemClick
        Try
            lReturn = GetTotalPartTravel()

            MessageBox.Show("Travel Distance: " & CStr(Round(g_CutTravel, Places.TenThousandths)) & vbCrLf & "Pierces: " & g_num_Pierces, "Travel Distance and Pierces")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub iDisAssociate_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iDisAssociate.ItemClick
        lReturn = appMain.ExecuteFunction(2009)
    End Sub

    Private Sub iLabels_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iLabels.ItemClick
        lReturn = appMain.ExecuteFunction(2010)
    End Sub

    Private Sub iDeletePattern_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iDeletePattern.ItemClick
        lReturn = appMain.ExecuteFunction(2011)
    End Sub

    Private Sub iExplodePattern_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iExplodePattern.ItemClick
        lReturn = appMain.ExecuteFunction(2012)
    End Sub

    Private Sub iFeatureAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iFeatureAdd.ItemClick
        lReturn = appMain.ExecuteFunction(2013)
    End Sub

    Private Sub iFeatureExtract_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iFeatureExtract.ItemClick
        lReturn = appMain.ExecuteFunction(2014)
    End Sub

    Private Sub iFeatureInsert_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iFeatureInsert.ItemClick
        lReturn = appMain.ExecuteFunction(2015)
    End Sub

    Private Sub iFeatureRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iFeatureRemove.ItemClick
        lReturn = appMain.ExecuteFunction(2016)
    End Sub

    Private Sub bbEditProject_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbEditProject.ItemClick
        lReturn = appMain.ExecuteFunction(2021)
    End Sub

    Private Sub bbViewWindow_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewWindow.ItemClick
        Dim ms As New System.IO.MemoryStream(My.Resources.window)
        pnlPicmodeler.Cursor = New Cursor(ms)
        lReturn = appMain.ExecuteFunction(201)
    End Sub

    Private Sub bbViewZoomIn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewZoomIn.ItemClick
        lReturn = appMain.ExecuteFunction(205)
    End Sub

    Private Sub bbViewZoomOut_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewZoomOut.ItemClick
        lReturn = appMain.ExecuteFunction(206)
    End Sub

    Private Sub bbViewPrevious_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewPrevious.ItemClick
        ' modView.ViewPrevious()

        lReturn = appMain.ProcessKeyPress(Keys.F3, 0)
    End Sub
    Private Sub bbViewHotspot_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbViewHotspot.ItemClick
        lReturn = modModeMgmt.HotDotToggle()

    End Sub

    Private Sub iExit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iExit.ItemClick
        'PortalTerminate()

        'End

        Me.Close()
    End Sub

    Private Sub bbTransformMove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTransformMove.ItemClick
        lReturn = appMain.ExecuteFunction(1401)
    End Sub


    Public Sub SynchronizeUI(Count As Long)
        Try

            If (bIsEntityLoaded = True) Then

                frmEntityList.SelectNodes()

            End If

            If (bIsSeqMoveLoaded = True) Then

                frmSeqMove.SelectSynchronize()

            End If

            modView.ViewRegen()

            SelectionStatusUpdate(Count)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub bbTransFormCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTransFormCopy.ItemClick
        lReturn = appMain.ExecuteFunction(1402)
    End Sub

    Private Sub bbTransFormScale_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTransFormScale.ItemClick
        lReturn = appMain.ExecuteFunction(1403)
    End Sub

    Private Sub bbTRansformMirror_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTRansformMirror.ItemClick
        lReturn = appMain.ExecuteFunction(1405)
    End Sub

    Private Sub CreateBitmap()
        Dim cmd As String

        Dim ribHeight As Double

        Try
            ribHeight = Me.RibbonControl.Height

            Dim tsHeight As Double
            tsHeight = Me.ToolStripContainer1.TopToolStripPanel.Height

            Dim combinedHeight = Me.Top + ribHeight + tsHeight

            Dim MySize As System.Drawing.Size

            cmd = "!view:mode:" &
                          " id=" & modView.ViewIdGet(VIEW_WIRE) &
                          ",mono=1, targets=0"

            'We suppress display of handles by setting targets=0.
            lReturn = PortalExecute(cmd)

            modView.ViewRegen()

            MySize.Width = splitContainerControl.Panel2.Width
            MySize.Height = splitContainerControl.Panel2.Height

            Dim bmp As New Bitmap(splitContainerControl.Panel2.Width - 60, splitContainerControl.Panel2.Height, PixelFormat.Format32bppArgb)
            Dim gr As Graphics = Graphics.FromImage(bmp)

            gr.CopyFromScreen(splitContainerControl.Panel2.Location.X + Me.Left - 30,
                              combinedHeight,
                               splitContainerControl.Panel2.Location.X + Me.Left - 30,
                              0,
                              MySize,
                              CopyPixelOperation.SourceCopy)

            'PictureBox1.Image = bmp

            bmp.Save(My.Computer.FileSystem.SpecialDirectories.Desktop & "\test1.bmp", Imaging.ImageFormat.Bmp)
            gr.Dispose()             'Disposing our Graphics

            cmd = "!view:mode:" &
                          " id=" & modView.ViewIdGet(VIEW_WIRE) &
                          ",mono=0, targets=1"
            lReturn = PortalExecute(cmd)

            modView.ViewRegen()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub pnlPicmodeler_MouseClick(sender As Object, e As MouseEventArgs) Handles pnlPicmodeler.MouseClick

        'lReturn = CType(m_curr_dlg, IDialogMouseUp).ClientMouseUp
        bMyButton = e.Button


    End Sub


    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Me.statusTime.Caption = Date.Now.ToLocalTime().ToShortTimeString()

    'End Sub

    Private Sub pnlPicmodeler_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlPicmodeler.MouseDown
        Dim world_pt As PortalPoint
        Dim local_pt As PortalPoint

        Try
            If (e.Button = Windows.Forms.MouseButtons.Left) Then

                'NOTE: Added by Gary Because Our User
                'are Used to holding the mouse down and then Dragging
                If (IsModeActive(MODE_WINDOW) = True) Then

                    If (modView.BoxPointCount() = 0) Then
                        world_pt = modView.WorldPointGet(e.X, e.Y)
                        lReturn = modView.BoxStart(world_pt)
                    Else
                        lReturn = modView.BoxEnd(world_pt)
                        If (modSelection.IsBoxSelectActive() = True) Then
                            lReturn = modSelection.BoxSelect(
                                modView.BoxPointGet(0), modView.BoxPointGet(1))
                        Else
                            ''LockWindowUpdate(pnlPicmodeler.Handle)

                            lReturn = modView.ViewWindow(
                                modView.BoxPointGet(0), modView.BoxPointGet(1))
                            ''LockWindowUpdate(0&)


                        End If
                        lReturn = ModeEnd(MODE_WINDOW)
                    End If

                ElseIf ((g_shape Is Nothing) = False) Then

                    world_pt = modView.WorldPointGet(e.X, e.Y)
                    local_pt = modView.MouseMove(world_pt, 0)

                    If (e.Button = 0) Then
                        g_shape.AnchorSet(local_pt.dx, local_pt.dy)
                    End If

                End If

                'ElseIf (Button = vbMiddleButton) Then

                If (AllowPan(e.Button, Control.ModifierKeys) = True) Then
                    If (IsModeActive(MODE_PAN) = False) Then
                        lReturn = ModeBegin(MODE_PAN)
                        lReturn = modView.ViewPanBegin(CDbl(e.X), CDbl(e.Y))
                    End If
                End If

#If ORIGINAL_CODE Then
        If (IsDialogActive() = True) Then
            If (m_curr_dlg.Name = "dlgEntity") Then lReturn = dlgEntity.Execute()
        End If
#End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub pnlPicmodeler_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlPicmodeler.MouseMove
        Dim world_pt As PortalPoint
        Dim local_pt As PortalPoint
        Dim cmd As String

        Try

            If Math.Abs(beginLocation.X - e.Location.X) > 40 OrElse Math.Abs(beginLocation.Y - e.Location.Y) > 40 Then
                Me.defaultToolTipController1.DefaultController.HideHint()
            End If

            world_pt = modView.WorldPointGet(e.X, e.Y)

            ' local_pt = ViewMouseMove(world_pt, 1)

            If (IsModeActive(MODE_PAN) = True) Then

                If (AllowPan(e.Button, Control.ModifierKeys) = False) Then
                    lReturn = ModeEnd(MODE_PAN)

                    modView.ViewPanCancel()

                End If

            End If

            If (IsModeActive(MODE_PAN) = True) Then
                If (AllowPan(e.Button, Control.ModifierKeys) = False) Then
                    lReturn = ModeEnd(MODE_PAN)
                    modView.ViewPanCancel()
                End If
            End If

            If (IsModeActive(MODE_WINDOW) = True) Then

                'NOTE: This branch will be active when for any operation requiring
                'a rubberband box, like windowing and selecting entities by box.

                lReturn = modView.BoxUpdate(world_pt)


            ElseIf (IsModeActive(MODE_PAN) = True) Then

                'NOTE: The left mouse button should be down but
                'I don't think we have to check for that condition.
                'lReturn = modView.ViewPanUpdate(world_pt)
                lReturn = modView.ViewPanUpdate(CDbl(e.X), CDbl(e.Y))

            ElseIf ((g_shape Is Nothing) = False) Then

                'We use this call only to update the coordinate readout.
                local_pt = modView.MouseMove(world_pt, 0)
                lReturn = ShapeDrag(e.Button, Control.ModifierKeys, local_pt)

            Else

                local_pt = modView.MouseMove(world_pt, 1)

            End If

            cmd = "Status " & ": X " & Round(local_pt.dx, 5) &
           "  Y " & Round(local_pt.dy, 5) & "  Z " & Round(DefaultZ)

            statusLocation.Caption = cmd


        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnlPicmodeler_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlPicmodeler.MouseUp
        Dim world_pt As PortalPoint
        Dim PopUpPoint As Point

        bMyButton = e.Button

        Try
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left

                    world_pt = modView.WorldPointGet(e.X, e.Y)

                    If (IsModeActive(MODE_WINDOW) = True) Then


                        If (modView.BoxPointCount() = 0) Then
                            lReturn = modView.BoxStart(world_pt)
                        Else
                            lReturn = modView.BoxEnd(world_pt)
                            If (modSelection.IsBoxSelectActive() = True) Then
                                lReturn = modSelection.BoxSelect(
                                    modView.BoxPointGet(0), modView.BoxPointGet(1))
                                'We do not call ModeEnd(MODE_WINDOW) here because
                                'we want Select By Box to be modal.
                            Else
                                lReturn = modView.ViewWindow(
                                    modView.BoxPointGet(0), modView.BoxPointGet(1))
                                lReturn = ModeEnd(MODE_WINDOW)
                            End If
                        End If

                    ElseIf (IsModeActive(MODE_PAN) = True) Then

                        'lReturn = modView.ViewPanUpdate(CDbl(X), CDbl(Y))

                        'NOTE: This statement has been commented-out because pan
                        'behavior seems more intuitive as a modal feature.  As
                        'such, you must <escape> out of pan mode.
                        lReturn = ModeEnd(MODE_PAN)
                        modView.ViewPanCancel()

                    ElseIf (IsModeActive(MODE_MEASURE) = True) Then

                        If (modMeasure.MeasurePointCount() = 0) Then
                            lReturn = modMeasure.MeasureBegin(world_pt)

                        Else
                            sReturn = modMeasure.MeasureEnd(world_pt)
                            beginLocation = e.Location
                            ExecuteMeasure(sReturn)

                        End If

                    ElseIf (IsModeActive(MODE_INQUIRE) = True) Then
                        beginLocation = e.Location
                        'We have a special branch here only because we want to
                        'prevent sending the event the any dialog that may be open.
                        ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)

                    ElseIf (IsDialogActive() = True) Then

                        '2007.03.05 (PE) -- When using forms like Edit/Zones/Manage, we must
                        'be sure that no mode is active, otherwise frmWorkZones will intercept
                        'the action (and things like entity selection will not work).
                        If (IsAnyModeActive() = True) Then

                            ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)

                        ElseIf (bIsWorkZoneLoaded = True) Then

                            lReturn = frmWorkZones.ClientMouseUp()

                        Else

                            ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)


                            If (bIsPatternBumpLoaded = False) Then

                                'Icky. frmPatternBump.ClientMouseUp() is restricted
                                'to responding to the middle mouse button (aka. accept)


                                'lReturn = m_curr_dlg.ClientMouseUp
                                lReturn = CType(m_curr_dlg, IDialogMouseUp).ClientMouseUp
                            End If

                        End If

                    Else

                        ExecuteFunction(e.Button, Control.ModifierKeys, e.X, e.Y)


                        If (m_curr_dlg IsNot Nothing) Then
                            lReturn = CType(m_curr_dlg, IDialogMouseUp).ClientMouseUp
                        End If

                    End If

                Case Windows.Forms.MouseButtons.Right
                    PopUpPoint.X = System.Windows.Forms.Cursor.Position.X

                    PopUpPoint.Y = System.Windows.Forms.Cursor.Position.Y

                    'super incattation of right mose click for popups
                    mnuPopUp3.ShowPopup(PopUpPoint)


                Case Windows.Forms.MouseButtons.Middle
                    If (IsDialogActive() = True) Then
                        If (m_curr_dlg.Name = "dlgEntity") Then lReturn = dlgEntity.Execute()
                    End If

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub pnlPicmodeler_MouseWheel(sender As Object, e As MouseEventArgs) Handles pnlPicmodeler.MouseWheel
        Dim pt As PortalPoint
        Dim cmd As String
        Dim factor As Double

        Try
            'If ((My.Computer.Keyboard.CtrlKeyDown) And _
            '    (My.Computer.Keyboard.ShiftKeyDown)) Then

            lReturn = IsModeActive(MODE_ZOOM) = True

            If (IsModeActive(MODE_ZOOM) = False) Then
                lReturn = ModeBegin(MODE_ZOOM)
            End If

            'Hack to get around conversion of Xpos,Ypos (which I don't know how to do).
            pt = modView.MousePosition()
            lReturn = PortalLocalToWorld(pt)

            'factor = IIf((Rotation > 0), VIEW_ZOOM_FACTOR, (1# / VIEW_ZOOM_FACTOR))
            factor = IIf((e.Delta > 0), (1.0# / VIEW_ZOOM_FACTOR), VIEW_ZOOM_FACTOR)
            LockWindowUpdate(Me.pnlPicmodeler.Handle)
            cmd = "!View:Zoom: " &
                  " factor=" & factor &
                  ",x=" & pt.dx &
                  ",y=" & pt.dy

            lReturn = PortalExecute(cmd)
            LockWindowUpdate(0&)
            ModesReset()

            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.pnlPicmodeler.Cursor = Cursors.Default
    End Sub
    '
    'Private Sub pnlPicmodeler_Paint(sender As Object, e As PaintEventArgs) Handles pnlPicmodeler.Paint
    '    pnlPicmodeler.SuspendLayout()
    '    modView.ViewRefresh()

    'End Sub
    Public Function EchoOrientation(degrees As Double) As Long

        Try
            'Arrrrrgh, VB does not update the text field unless we refresh.
            'Refresh()

            EchoOrientation = 1 'fodder
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Public Function EchoLocation(world_pt As clsCoord3d) As Long

        Try
            'Arrrrrgh, VB does not update the text field unless we refresh.
            ' Refresh()

            EchoLocation = 1 'fodder
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Private Function ShapeDrag(Button As Integer, Shift As Integer, local_pt As PortalPoint) As Long

        Try
            If (Button = Windows.Forms.MouseButtons.Left) Then

                If (bIsPatternBumpLoaded = True) Then

                    If (frmPatternBump.IsTransferPattern = False) Then

                        If (Shift = Keys.Shift) Then
                            lReturn = g_shape.Rotate(local_pt.dx, local_pt.dy)
                            lReturn = frmPatternBump.EchoOrientation(g_shape.GetOrientation())
                        Else
                            g_shape.Move(local_pt.dx, local_pt.dy)
                        End If


                        'We execute this statement here (instead of just inside the else clause)
                        'because rotating the part about an anchor point that is *not* coincident
                        'with the handle point causes the handle point to change.
                        lReturn = frmPatternBump.EchoLocation(g_shape.GetLocation())
                    End If

                ElseIf (bIsWorkZoneLoaded = True) Then

                    g_shape.Move(local_pt.dx, local_pt.dy)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


    Private Sub bbCreateLine_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreateLine.ItemClick
        lReturn = appMain.ExecuteFunction(1101)
    End Sub

    Private Sub bbCreateArc_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreateArc.ItemClick
        lReturn = appMain.ExecuteFunction(1102)
    End Sub

    Private Sub bbCreateHole_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreateHole.ItemClick
        lReturn = appMain.ExecuteFunction(1103)
    End Sub

    Private Sub bbCreatePoint_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreatePoint.ItemClick
        lReturn = appMain.ExecuteFunction(1104)
        'dlgEntity.SetSNCS(HOLE_ROOT_SNCS)
        'dlgEntity.SetEntityID(0)
    End Sub
    Public Sub SelectionStatusUpdate(Count As Long)
        statusSelection.Caption = "Selected ( " & Count & " )"
    End Sub

    Private Sub bbShapeLIbrary_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbShapeLIbrary.ItemClick
        'If (dlgEntity.IsActive = True) Then
        '    dlgEntity.Close()

        'End If
        frmShapeLibrary.Init(MACRO_OPTION.MACRO_SHAPE_LIB)

        lReturn = appMain.ExecuteFunction(106)
    End Sub


    '2007.01.11 (PE) -- Added to support Connweld's CommonLine.java
    'because the macro adds patterns and instances to the model.
    Public Sub PublicPatternComboShow()

        PatternComboShow()
        ShowCombos_core()

    End Sub

    Private Sub bbWallOfset_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbWallOfset.ItemClick
        If (SelectedCount() = 0) Then

            MessageBox.Show("You must have a selection in order to use this feature!", "No Entities Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            lReturn = appMain.ExecuteFunction(2041)
        End If

    End Sub

    Private Sub bbMacroExecute_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbMacroExecute.ItemClick
        If (bIsShapeLibraryLoaded = True) Then
            frmShapeLibrary.Dispose()
        End If

        frmShapeLibrary.Init(MACRO_OPTION.MACRO_NORM)

        lReturn = appMain.ExecuteFunction(106)
    End Sub

    Private Sub tbViewFull_Click(sender As Object, e As EventArgs) Handles tbViewFull.Click
        modView.ViewAll()


    End Sub

    Private Sub tbViewPrevious_Click(sender As Object, e As EventArgs) Handles tbViewPrevious.Click
        lReturn = appMain.ProcessKeyPress(Keys.F3, 0)
    End Sub

    Private Sub tbViewRefresh_Click(sender As Object, e As EventArgs) Handles tbViewRefresh.Click
        modView.ViewRefresh()
    End Sub

    Private Sub tbViewWindow_Click(sender As Object, e As EventArgs) Handles tbViewWindow.Click
        Dim ms As New System.IO.MemoryStream(My.Resources.window)
        pnlPicmodeler.Cursor = New Cursor(ms)
        lReturn = appMain.ExecuteFunction(201)
    End Sub

    Private Sub tbViewZoomIn_Click(sender As Object, e As EventArgs) Handles tbViewZoomIn.Click
        lReturn = appMain.ExecuteFunction(205)
    End Sub

    Private Sub tbViewZoomOut_Click(sender As Object, e As EventArgs) Handles tbViewZoomOut.Click
        lReturn = appMain.ExecuteFunction(206)
    End Sub

    Private Sub bbAssociate_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAssociate.ItemClick
        If (SelectedCount() = 0) Then

            MessageBox.Show("You must have a selection in order to use this feature!", "No Entities Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            lReturn = appMain.ExecuteFunction(1105)

        End If
    End Sub

    Private Sub bbAutoPunch_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAutoPunch.ItemClick
        lReturn = appMain.ExecuteFunction(1106)
    End Sub

    Private Sub bbManualLead_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbManualLead.ItemClick
        lReturn = appMain.ExecuteFunction(1107)
    End Sub

    Private Sub bbAutoLead_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAutoLead.ItemClick
        lReturn = appMain.ExecuteFunction(1108)
    End Sub

    Private Sub bbNotch_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbNotch.ItemClick
        lReturn = appMain.ExecuteFunction(1110)
    End Sub

    Private Sub bbShakerTab_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbShakerTab.ItemClick
        lReturn = appMain.ExecuteFunction(1111)

    End Sub

    Private Sub bbCommad_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCommad.ItemClick
        lReturn = appMain.ExecuteFunction(1112)
    End Sub

    Private Sub bbSlit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSlit.ItemClick
        lReturn = appMain.ExecuteFunction(1115)
    End Sub

    Private Sub bbLinearCler_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbLinearCler.ItemClick
        lReturn = appMain.ExecuteFunction(1116)
    End Sub

    Private Sub bbAreaClear_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAreaClear.ItemClick
        lReturn = appMain.ExecuteFunction(1117)
    End Sub

    Private Sub bbRubberBand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbRubberBand.ItemClick
        lReturn = appMain.ExecuteFunction(1119)
    End Sub

    Private Sub bbCreateBoundingBox_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreateBoundingBox.ItemClick
        lReturn = appMain.ExecuteFunction(1118)
    End Sub

    Private Sub bbTransformRotate_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTransformRotate.ItemClick
        lReturn = appMain.ExecuteFunction(1404)
    End Sub


    Private Sub bbModTrimExtend_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModTrimExtend.ItemClick
        lReturn = appMain.ExecuteFunction(2017)
    End Sub

    Private Sub bbModSplit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModSplit.ItemClick
        lReturn = appMain.ExecuteFunction(2020)
    End Sub

    Private Sub bbModFillet_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModFillet.ItemClick
        lReturn = appMain.ExecuteFunction(2018)
    End Sub

    Private Sub bbModChampher_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModChampher.ItemClick
        lReturn = appMain.ExecuteFunction(2019)
    End Sub

    Private Sub bbModDropStop_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModDropStop.ItemClick
        lReturn = appMain.ExecuteFunction(2028)
    End Sub

    Private Sub bbModChainCut_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModChainCut.ItemClick
        lReturn = appMain.ExecuteFunction(2029)
    End Sub

    Private Sub bbModCutBack_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModCutBack.ItemClick
        lReturn = appMain.ExecuteFunction(2045)
    End Sub

    Private Sub bbModIndvHIts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModIndvHIts.ItemClick
        Dim errmsg As String
        Dim cnt As Long



        Try

            modAdmin.UndoPrepare()
            lReturn = PortalExecute("Toolpath:Nibble:")
            cnt = PortalGetInt("cnt", 0)
            modAdmin.UndoCommit()

            If (cnt > 0) Then

                SynchronizeUI(modSelection.SelectedCount())

            Else

                errmsg = "  The Ind. Hits function operates only on selected" & vbCrLf &
                         "feature and profile entities, and none were detected."

                lReturn = MessageBox.Show(errmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bbModZonesManage_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModZonesManage.ItemClick
        lReturn = appMain.ExecuteFunction(2022)
    End Sub

    Private Sub bbModZonesExtract_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModZonesExtract.ItemClick
        lReturn = appMain.ExecuteFunction(2024)
    End Sub

    Private Sub bbModClamps_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModClamps.ItemClick
        lReturn = appMain.ExecuteFunction(2025)
    End Sub

    Private Sub bbModReposition_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbModReposition.ItemClick
        lReturn = appMain.ExecuteFunction(2027)
    End Sub

    Private Sub bbSequenceChain_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSequenceChain.ItemClick
        lReturn = appMain.ExecuteFunction(2037)
    End Sub

    Private Sub bbSequemceUnchain_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSequemceUnchain.ItemClick
        lReturn = appMain.ExecuteFunction(2038)
    End Sub

    Private Sub bbSequenceRevOrder_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSequenceRevOrder.ItemClick
        lReturn = appMain.ExecuteFunction(2039)
    End Sub

    Private Sub bbSeqManOrder_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSeqManOrder.ItemClick
        lReturn = appMain.ExecuteFunction(2046)
    End Sub



    Private Sub bbRemnant_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbRemnant.ItemClick
        frmRemMgr.ShowDialog(Me)
    End Sub

    Private Sub bbCreatePattern_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreatePattern.ItemClick
        lReturn = appMain.ExecuteFunction(1113)
    End Sub

    Private Sub bbCreateInstance_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCreateInstance.ItemClick
        lReturn = appMain.ExecuteFunction(1114)
    End Sub

    Private Sub tbSelect_HotDot_CheckStateChanged(sender As Object, e As EventArgs) Handles tbSelect_HotDot.CheckStateChanged

        modModeMgmt.HotDotEnable(tbSelect_HotDot.Checked)

        If (tbSelect_HotDot.CheckState = CheckState.Checked) Then

            tbSelect_HotDot.Image = My.Resources.Blue_HotDot

        Else
            tbSelect_HotDot.Image = My.Resources.Orange_HotDot
        End If

        'modModeMgmt.HotDotToggle()

    End Sub


    Private Sub ToggleSelButton(sncs As Long)
        Dim ni As Integer
        Dim tb As ToolStripButton


        For ni = 0 To tbSelect.Items.Count - 1

            If (CLng(tbSelect.Items(ni).Tag) = sncs) Then
                tb = tbSelect.Items(ni)
                tb.CheckState = CheckState.Unchecked

                Exit For
            End If

        Next
    End Sub

    Private Sub bbTrueShape_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTrueShape.ItemClick

        doNesting()

    End Sub

    Private Sub bbManulNestingGrid_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbManulNestingGrid.ItemClick

        Try
            If (SelectedCount() = 0) Then

                MessageBox.Show("You must have a selection in order to use this feature!", "No Entities Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else

                lReturn = appMain.ExecuteFunction(2035)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub bbSkeltonCutOff_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbSkeltonCutOff.ItemClick
        lReturn = appMain.ExecuteFunction(2060)
    End Sub

    Private Sub bbStaggerNest_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbStaggerNest.ItemClick

        If (SelectedCount() = 0) Then

            MessageBox.Show("You must have a selection in order to use this feature!", "No Entities Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            lReturn = appMain.ExecuteFunction(2061)

        End If

    End Sub

    Private Sub pnlPicmodeler_Paint(sender As Object, e As PaintEventArgs) Handles pnlPicmodeler.Paint
        pnlPicmodeler.SuspendLayout()

        modView.ViewRefresh()
        pnlPicmodeler.ResumeLayout()

    End Sub

    Private Sub pnlPicmodeler_Resize(sender As Object, e As EventArgs) Handles pnlPicmodeler.Resize
        pnlPicmodeler.SuspendLayout()
        modView.ViewResize()
        pnlPicmodeler.ResumeLayout()
    End Sub

    Public Function ThumbnailCallback() As Boolean
        Return True
    End Function


    Private Sub iSaveAs_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iSaveAs.ItemClick
        lReturn = appMain.ExecuteFunction(104)
    End Sub

    Private Sub bbAdminDumpModel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAdminDumpModel.ItemClick
        Dim cmd As String
        cmd = "File:ModelDump:file=" & QStr(App_Path & "\debug\model.txt") & ",type=1"
        lReturn = PortalExecute(cmd)

    End Sub

    Private Sub bbExecutePortal_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbExecutePortal.ItemClick
        Dim cmd As String
        Dim id As Integer = 88
        cmd = InputBox("Portal Command")
        'cmd = "Entity:Container:DestructiveFlush:id=88" '+ id
        lReturn = PortalExecute(cmd)

    End Sub

    Private Sub bbLogFileRecord_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbLogFileRecord.ItemClick

        Try
            dlgFileSaveDialog.Title = "Save Log File"
            dlgFileSaveDialog.Filter = "Log Files (*.log)|*.log"
            dlgFileSaveDialog.InitialDirectory = NormalizePath(PathDriveFolder(PathLOG()))

            dlgFileSaveDialog.ShowDialog()

            PathLOG_Set(dlgFileSaveDialog.FileName)

            'PathLOG_Set("C:\Program Files (x86)\WE-CIM\22.0\Debug\Debug.log")

            m_g_LogRecord = True

            lReturn = PortalExecute("cmdlog:file=" & QStr(PathLOG()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub bbLogFileStop_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbLogFileStop.ItemClick
        Try
            If m_g_LogRecord = True Then
                ' all view commands should be suppressed but this final one
                modView.ViewFull()

                lReturn = PortalExecute("cmdstop:")
                m_g_LogRecord = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bbbLogFilePlay_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbbLogFilePlay.ItemClick
        Try
            dlgFileOpenDialog.Title = "Open Log File"
            dlgFileOpenDialog.Filter = "Log Files (*.log)|*.log|All Files (*.*)|*.*"

            If (FileExists(PathFile(PathLOG())) = True) Then
                dlgFileOpenDialog.FileName = PathFile(PathLOG())
                dlgFileOpenDialog.InitialDirectory = NormalizePath(PathDriveFolder(PathLOG()))
            Else
                dlgFileOpenDialog.FileName = Nothing
                dlgFileOpenDialog.InitialDirectory = App_Path


            End If

            dlgFileOpenDialog.ShowDialog(Me)

            If Len(dlgFileOpenDialog.FileName) = 0 Then
                Exit Sub
            End If

            PathLOG_Set(dlgFileOpenDialog.FileName)

            lReturn = PortalExecute("cmdplay: file=" & QStr(PathLOG()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub bbEWM_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbEWM.ItemClick
        dlgEWMSettings.ShowDialog(Me)
    End Sub

    Private Sub iPrintNest_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iPrintNest.ItemClick
        On Error Resume Next

        frmPrintNestReport.ShowDialog(Me)

    End Sub
    Sub GetRecentFiles()
        Dim indx As Integer = 0
        MRUCount = -1

        MRU_ListAray.Clear()

        Try
            Dim myMRU As RegistryKey = Registry.CurrentUser.CreateSubKey(RegAppKey() & "\RecentFiles")

            barRecentFiles.ClearLinks()

            For Each valueName As String In myMRU.GetValueNames()
                MRUCount = MRUCount + 1

                Dim newItem As BarButtonItem = New BarButtonItem(Ribbon.Manager, myMRU.GetValue(valueName).ToString())

                AddHandler newItem.ItemClick, AddressOf MRU_itemClick

                barRecentFiles.AddItem(newItem)

                MRU_ListAray.Add(newItem.Caption)

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function AddToMru(sItem As String, m_ArrayList As ArrayList) As Long

        Dim ni As Long
        Dim m_str As String

        Try
            If (sItem = "") Then
                Exit Function

            End If

            'first we checkif it is already in the list
            'if so we remove it.
            If (m_ArrayList.Count > 0) Then
                For ni = 0 To m_ArrayList.Count - 1
                    m_str = m_ArrayList.Item(ni)

                    If (m_str = sItem) Then
                        'We found a duplicate so delete it from the Array list

                        m_ArrayList.Remove(sItem)

                        Exit For
                    End If

                Next
            End If

            If (m_ArrayList.Count < 9) Then
                m_ArrayList.Insert(0, sItem)
            Else
                m_ArrayList.RemoveAt(8)
                m_ArrayList.Insert(0, sItem)

            End If

            SaveRecentInReg()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Public Sub SaveRecentInReg()

        Dim ni As Long
        Dim cnt As Integer = MRU_ListAray.Count

        Try
            Registry.CurrentUser.DeleteSubKeyTree((RegAppKey() & "\RecentFiles"), False)

            Dim myMRU As RegistryKey = Registry.CurrentUser.CreateSubKey(RegAppKey() & "\RecentFiles")

            For ni = 0 To (cnt - 1)

                myMRU.SetValue(ni, MRU_ListAray.Item(ni).ToString())

            Next

            GetRecentFiles()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub MRU_itemClick(sender As Object, e As ItemClickEventArgs)
        Dim sTarget As String
        Dim sCandidate As String

        Try
            sCandidate = e.Item.Caption
            sTarget = sCandidate
            modView.ViewActivate(VIEW_WIRE)

            'At this point, the user has committed to importing the file.
            sTarget = modFileIO.ImportFile(sCandidate, sTarget)
            lReturn = Me.AddToMru(sTarget, Me.MRU_ListAray)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub tbUndo_Undo_Click(sender As Object, e As EventArgs) Handles tbUndo_Undo.Click
        lReturn = modEdit.EditUndo()
    End Sub

    Private Sub tbUndo_Redo_Click(sender As Object, e As EventArgs) Handles tbUndo_Redo.Click
        lReturn = modEdit.EditRedo
    End Sub
    Private Sub bbInquire_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbInquire.ItemClick
        lReturn = ModeBegin(MODE_INQUIRE)

    End Sub

    Private Sub bbCMDB_EditValueChanged(sender As Object, e As EventArgs) Handles bbCMDB.EditValueChanged

        RegPutString("ConfigurationManager", "Database", bbCMDB.EditValue.ToString())

    End Sub


    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles repCMDBFile.Click
        Dim dialog As New OpenFileDialog()
        Dim sFilename As String

        Try
            dialog.Multiselect = False
            dialog.Title = "Select CMDB File"
            dialog.Filter = "CMDB Files(*.MDB)|*.MDB"

            If dialog.ShowDialog(Me) = DialogResult.OK Then
                sFilename = (dialog.FileName)
                bbCMDB.EditValue = sFilename

                PathCMDB_Set(sFilename)
                Update_CMDB_To_Current()

                Update_Appdb_To_Current()


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Dim pt As PortalPoint
        Dim cmd As String
        Dim factor As Double

        Try
            If ((My.Computer.Keyboard.CtrlKeyDown) And
                (My.Computer.Keyboard.ShiftKeyDown)) Then

                lReturn = IsModeActive(MODE_ZOOM) = True

                If (IsModeActive(MODE_ZOOM) = False) Then
                    lReturn = ModeBegin(MODE_ZOOM)
                End If

                'Hack to get around conversion of Xpos,Ypos (which I don't know how to do).
                pt = modView.MousePosition()
                lReturn = PortalLocalToWorld(pt)

                'factor = IIf((Rotation > 0), VIEW_ZOOM_FACTOR, (1# / VIEW_ZOOM_FACTOR))
                factor = IIf((e.Delta > 0), (1.0# / VIEW_ZOOM_FACTOR), VIEW_ZOOM_FACTOR)

                LockWindowUpdate(Me.pnlPicmodeler.Handle)
                cmd = "!View:Zoom: " &
                      " factor=" & factor &
                      ",x=" & pt.dx &
                      ",y=" & pt.dy


                lReturn = PortalExecute(cmd)
                LockWindowUpdate(0&)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub SetSpalshScreenDescription(sDescription As String)
        SplashScreenManager.Default.SetWaitFormDescription(sDescription)
    End Sub
    Public Sub doNesting()

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If (bIstartUpLoaded = True) Then

                frmStartUp.Close()

            End If

            Me.RibbonControl.SelectedPage = Me.ribNesting
            Me.splitContainerControl.Panel1.Controls.Clear()
            picPattern.Parent = RibbonControl
            'picPattern.Bounds.X(GetGroupBounds(rpgBump).X)


            Me.Refresh()

            lReturn = appMain.ExecuteFunction(505)
            picPattern.Visible = False
            splitContainerControl.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both

            'frm.Show()

            splitContainerControl.SplitterPosition = 560

            Me.splitContainerControl.Panel1.Refresh()

            Windows.Forms.Cursor.Current = Cursors.Default

            ' frmNesting.Size = Me.splitContainerControl.Panel1.Size
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub iPrintGraphics_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iPrintGraphics.ItemClick

        frmPrintGraphics.ShowDialog(Me)

    End Sub

    Private Sub bbNestingDefaults_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbNestingDefaults.ItemClick
        lReturn = appMain.ExecuteFunction(2067)
    End Sub

    Private Sub bbExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbExport.ItemClick

        frmCodeGen.ShowDialog(Me)

    End Sub

    Private Sub rpgCustomMacros_CaptionButtonClick(sender As Object, e As RibbonPageGroupEventArgs) Handles rpgCustomMacros.CaptionButtonClick

        dlgCustomMacros.ShowDialog(Me)

    End Sub


    Private Sub iAbout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iAbout.ItemClick
        frmAboutBox.ShowDialog(Me)

    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        frmTechSupport.ShowDialog(Me)

    End Sub

    Private Sub ribbonControl_CustomDrawItem(sender As Object, e As BarItemCustomDrawEventArgs) Handles RibbonControl.CustomDrawItem

        Try
            If (DoCustomDrawItem = True) Then

                If (e.RibbonItemInfo.Item Is Nothing) Then
                    Return
                End If
                Dim link As BarButtonItemLink = TryCast(e.RibbonItemInfo.Item, BarButtonItemLink)

                If link Is Nothing OrElse link.Item.Tag Is Nothing Then
                    Return
                End If

                If link.Item.Tag = "DrawButton" Then
                    Dim button As New EditorButton() With {.Kind = ButtonPredefines.Glyph, .ImageLocation = ImageLocation.MiddleRight}
                    Dim drawArgs As New EditorButtonObjectInfoArgs(e.Cache, button, AppearanceObject.EmptyAppearance)
                    drawArgs.Bounds = e.Bounds
                    _PaintersCollection.Painters(6).DrawObject(drawArgs)
                    e.Handled = True
                    e.DrawBackground()
                    e.DrawText()
                End If

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ribbonControl_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RibbonControl.ItemClick
        Dim sMacroName As String
        Dim sJavaFile As String
        Dim bShowDialog As Boolean = False
        Dim ds As New DataSet
        Dim connection As OleDbConnection = Nothing
        Dim oledbAdapter As OleDbDataAdapter = Nothing
        Dim connetionString As String
        Dim sql As String
        Dim cmd As String
        Dim Result As DialogResult


        Try

            UndoPrepare()

            If (e IsNot Nothing) Then

                sJavaFile = Nothing

                sMacroName = e.Item.Caption

                'If (e.Item.Container.ToString = "") Then

                'End If
                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

                sql = "SELECT Icon.* FROM Icon WHERE (Icon.Display = '" & sMacroName & "' ) And (Icon.ToolBarID = 1500 )"


                connection = New OleDbConnection(connetionString)


                connection.Open()

                oledbAdapter = New OleDbDataAdapter(sql, connection)

                oledbAdapter.Fill(ds)

                oledbAdapter.Dispose()

                connection.Close()

                If (ds.Tables(0).Rows.Count > 0) Then


                    For i = 0 To ds.Tables(0).Rows.Count - 1

                        sJavaFile = ds.Tables(0).Rows(i).Item("Macro_FilePath")

                        bShowDialog = ds.Tables(0).Rows(i).Item("Show_Dialog")

                        sReturn = PathMacroSet(sJavaFile)


                    Next

                    If (sJavaFile IsNot Nothing) Then
                        If (bShowDialog = True) Then
                            frmShapeLibrary.Init(MACRO_OPTION.MACRO_NORM)
                            lReturn = appMain.ExecuteFunction(106)

                        Else

                            Result = MessageBox.Show("Running a macro can have great effects on your model. Are you sure you want to continue?", "About To Run " &
                                                PathFileExt(sJavaFile), MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If (Result = Windows.Forms.DialogResult.Yes) Then
                                cmd = "admin:macrorun: javafile=" & QStr(PathMacroGet)
                                lReturn = PortalExecute(cmd)

                                'Lets be sure thera are no empty features lying around
                                lReturn = PortalExecute("create:empty:") ' get rid of empty feature

                                m_suppress = False

                                'Me.PublicPatternComboShow()
                                Me.SynchronizeUI(modSelection.SelectedCount())

                            End If

                        End If

                    End If

                End If

            End If


            ds.Dispose()

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing


        Catch ex As Exception

            If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            If ds IsNot Nothing Then ds = Nothing

            If connection IsNot Nothing Then connection = Nothing

            If (m_debug_menu) Then
                'MessageBox.Show("ribbonControl_ItemClick++: " & ex.Message)
            End If

        Finally

            UndoCommit()


        End Try

    End Sub

    Public Sub GetSheetsFromPDB(s_PDB_Name As String)


        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sheet_file As String
        Dim sql As String
        Dim i As Integer
        Dim ds_Sheets As New List(Of FileItem)()

        Try
            If (s_PDB_Name <> "") Then

                If (FileExists(s_PDB_Name) = True) Then

                    connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & s_PDB_Name & "';"

                    sql = "SELECT * FROM [Sheet Result]"

                    connection = New OleDbConnection(connetionString)

                    connection.Open()

                    oledbAdapter = New OleDbDataAdapter(sql, connection)

                    oledbAdapter.Fill(ds)

                    oledbAdapter.Dispose()

                    connection.Close()

                    For i = 0 To ds.Tables(0).Rows.Count - 1

                        sheet_file = ds.Tables(0).Rows(i).Item("Sheet Filename")

                        ds_Sheets.Add(New FileItem() With {.FullPath = String.Format(sheet_file, i), .ShortText = String.Format(PathFile(sheet_file), i), .UniqueID = i})

                    Next

                    repSheetsGridLookUp.DataSource = ds_Sheets
                    repSheetsGridLookUp.DisplayMember = "ShortText"
                    repSheetsGridLookUp.ValueMember = "UniqueID"
                    RepositoryItemGridLookUpEdit1View.Columns.Clear()
                    RepositoryItemGridLookUpEdit1View.Columns.AddVisible("FullPath")
                    RepositoryItemGridLookUpEdit1View.OptionsView.ShowIndicator = False
                    RepositoryItemGridLookUpEdit1View.OptionsView.ShowColumnHeaders = False
                    RepositoryItemGridLookUpEdit1View.OptionsView.ShowHorizontalLines = DefaultBoolean.True

                    ds.Dispose()

                    If ds IsNot Nothing Then ds = Nothing

                    If connection IsNot Nothing Then connection = Nothing

                    If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Can't Find " & s_PDB_Name & ". Some data will be missing! ")

        End Try
    End Sub

    Private Sub bbiTools_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiTools.ItemClick
        lReturn = appMain.ExecuteFunction(2063)
    End Sub

    Private Sub bbiSetLayer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSetLayer.ItemClick
        lReturn = appMain.ExecuteFunction(2064)
    End Sub

    Private Sub LoadUserMacros()
        Dim ds As New DataSet
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim connetionString As String
        Dim sql As String


        Try
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PathAppDB() & "';"

            sql = "SELECT * FROM Icon WHERE (Icon.ToolBarID = 1500 )"

            connection = New OleDbConnection(connetionString)


            connection.Open()

            oledbAdapter = New OleDbDataAdapter(sql, connection)

            oledbAdapter.Fill(ds)

            oledbAdapter.Dispose()

            connection.Close()
            If (ds.Tables(0).Rows.Count > 0) Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    If (IsDBNull(ds.Tables(0).Rows(i).Item("Macro_FilePath")) = False) Then
                        Dim NewBarButtonItem As BarButtonItem = New BarButtonItem()

                        NewBarButtonItem.PaintStyle = BarItemPaintStyle.Standard
                        NewBarButtonItem.Caption = ds.Tables(0).Rows(i).Item("Display")
                        NewBarButtonItem.LargeGlyph = System.Drawing.Image.FromFile(ds.Tables(0).Rows(i).Item("Icon_FilePath"))
                        NewBarButtonItem.Tag = ds.Tables(0).Rows(i).Item("Macro_FilePath")

                        rpgCustomMacros.ItemLinks.Add(NewBarButtonItem)

                    End If
                Next

                ds.Dispose()

                If ds IsNot Nothing Then ds = Nothing

                If connection IsNot Nothing Then connection = Nothing

                If oledbAdapter IsNot Nothing Then oledbAdapter = Nothing

            End If

        Catch ex As Exception

            MessageBox.Show("LoadUserMacros: " & ex.Message)

        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit3_Click(sender As Object, e As EventArgs) Handles repAPPDBFile.Click
        Dim dialog As New OpenFileDialog()
        Dim sFilename As String

        Try
            dialog.Multiselect = False
            dialog.Title = "Select AppDB File"
            dialog.Filter = "AppDb Files(*.MDB)|*.MDB"

            If dialog.ShowDialog(Me) = DialogResult.OK Then
                sFilename = (dialog.FileName)
                bbResetAppdb.EditValue = sFilename
                PathAppDB_Set(sFilename)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Function ShapeInit(entity_id As Long, is_pattern As Boolean) As Long
        'NOTE: is_pattern is True only when selecting from a list.
        Dim cmd As String
        Dim tmp As Double
        Dim entity_type As Long
        Dim picH As Long
        Dim sPattern_Name As String

        ShapeInit = 0  'assume failure.


        Try
            If ((g_shape Is Nothing) = True) Then

                '2005.11.26 (PE) -- Prior to this change, it was possible that a
                'mouse-up event (while dragging a part) returned the id of something
                'like a curve.  This caused the 'Drop' button to be inadvertantly
                'disabled.  This undesirable behavior might still be a problem if
                'the mouse-up event is received when the cursor is positioned over
                'the handle point of an instance.  I guess we'll solve that problem
                'when it arises :-(
                lReturn = PortalExecute("*create:extract:id=" & entity_id)
                entity_type = PortalGetInt("type", c_INVALID)
                If ((entity_type <> c_DBCOMMAND) And
                    (entity_type <> c_DBPATTERN)) Then
                    Exit Function
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                'Selecting a new instance should clear the previous reference.
                g_shape = Nothing
                lReturn = modSelection.DeselectAll

                picH = picPattern.Handle

                If (bDo_BumpDrag = True) Then
                    'picPattern.Visible = False
                End If


                cmd = "nest:manual:instance:" &
                    " opt=" & BUMP_INIT &
                    ",id=" & entity_id &
                    ",hwnd=" & picH


                If (is_pattern = True) Then
                    cmd = cmd & ",pattern=1"
                    m_instance_id = 0
                Else
                    m_instance_id = entity_id
                End If

                lReturn = PortalExecute(cmd)

                m_pattern_id = PortalGetInt("pattern_id", 0)
                m_part_id = PortalGetInt("part_id", 0)

                If (m_pattern_id <> 0) Then
                    sPattern_Name = EntityStringGet(m_pattern_id, "_label", "<error>")

                    m_is_pattern = is_pattern

                    tmp = PortalGetDouble("xp", 0.0#)
                    'tbHandleX.Text = Round(tmp, Places.TenThousandths)

                    tmp = PortalGetDouble("yp", 0.0#)
                    'txtHandleY.Text = Round(tmp, Places.TenThousandths)

                    tmp = PortalGetDouble("part_angle", 0.0#)
                    'mtbOrientation.Text = Round((tmp * RAD2DEG), Places.Tenths)

                    'CRITICAL: We must defer setting g_shape until after the
                    'dialogs controls have been initialized. Otherwise, we crash
                    'with the nasty (and difficult to diagnose) error:
                    '
                    '  Run-time error -2147417848 (80010108)
                    '  Automation error.
                    '  The object invoked has disconnected from its clients.
                    '
                    'This is true because the preceding statement:
                    '  mtbOrientation.Text = Round((tmp * RAD2DEG), Tenths)
                    'has the side effect of calling mtbOrientation_Change()
                    '

                    g_shape = New clsShape
                    lReturn = g_shape.PartInit()


                    'If (bDo_Bump = False) Then
                    '    GetPartImage(PathImageFolder() & sPattern_Name)
                    'End If

                    ''' LockWindowUpdate(pnlPicmodeler.Handle)

                    ShapeInit = ((g_shape Is Nothing) = False)


                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Function
    Public Class ThePatternData
        Private nPatid As Integer
        Public Property PatternID() As Integer
            Get
                Return nPatid
            End Get
            Set(ByVal value As Integer)
                nPatid = value
            End Set
        End Property
        Private dPatAng As Double
        Public Property PatternAngle() As Double
            Get
                Return dPatAng
            End Get
            Set(ByVal value As Double)
                dPatAng = value
            End Set
        End Property
        Private sPatLabel As String
        Public Property PatternLabel() As String
            Get
                Return sPatLabel
            End Get
            Set(ByVal value As String)
                sPatLabel = value
            End Set
        End Property
    End Class

    Private Sub GetPartImage(sImageFilename As String)
        Dim sPatName As String

        Dim bounds As Rectangle = picPattern.Bounds
        Dim sheet_bounds As Rectangle = pnlPicmodeler.Bounds

        Dim pt As Point = picPattern.PointToScreen(bounds.Location)
        Dim sheet_pt As Point = pnlPicmodeler.PointToScreen(sheet_bounds.Location)

        Dim myBitmap As New Bitmap(bounds.Width, bounds.Height)
        Dim sheet_Bitmap As New Bitmap(sheet_bounds.Width, sheet_bounds.Height)

        Try
            Using m_g As Graphics = Graphics.FromImage(myBitmap)

                m_g.CopyFromScreen(New Point(pt.X - picPattern.Location.X, pt.Y - picPattern.Location.Y), Point.Empty, bounds.Size)

                m_g.Dispose()

            End Using
            sImageFilename = sImageFilename & ".png"

            sPatName = PathFile(sImageFilename)

            myBitmap.Save(sImageFilename, ImageFormat.Png)

            myBitmap.Dispose()

            myBitmap = Nothing


            ClearDrawingPanel()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function Reinit() As Long

        m_instance_id = 0
        m_pattern_id = 0
        m_is_pattern = False

        g_shape = Nothing
        modSelection.DeselectAll()

        Reinit = 1

    End Function

    Public Sub ClearDrawingPanel()
        ' clears drawing panel

        Dim g As Graphics = Me.picPattern.CreateGraphics

        g.Clear(picPattern.BackColor)

        g.Dispose()

    End Sub
    Private Sub bbManualNestAddPart_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbManualNestAddPart.ItemClick
        lReturn = appMain.ExecuteFunction(1113)

    End Sub
    'Private Sub GetSheetInfo(s_PdbFileName As String)
    '    Dim SQL1 As String
    '    Dim SQL2 As String
    '    Dim SQL3 As String
    '    Dim SQL4 As String
    '    Dim m_da_SheetResults As OleDbDataAdapter
    '    Dim m_da_PartResults As OleDbDataAdapter
    '    Dim m_da_Parts As OleDbDataAdapter
    '    Dim m_MaterialType As DataColumn
    '    Dim m_dataSet As DataSet

    '    Try
    '        ' Compose the connection string.
    '        Dim connect_string As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & "C:\_Nest_Test_E\NestTest_85.mdb" & "';"

    '        SQL1 = "SELECT * FROM [Sheet Result]"

    '        SQL2 = "SELECT * FROM [Part Result]"

    '        SQL3 = "SELECT * FROM [Part]"

    '        SQL4 = "SELECT * FROM [Setup]"

    '        ' Create a DataAdapter to load the Sheet Results table.
    '        m_da_SheetResults = New OleDbDataAdapter(SQL1, connect_string)

    '        ' Create a DataAdapter to load the Part Results table.
    '        m_da_PartResults = New OleDbDataAdapter(SQL2, connect_string)

    '        m_da_Parts = New OleDbDataAdapter(SQL3, connect_string)

    '        ' Create and fill the DataSet.
    '        m_dataSet = New DataSet

    '        m_MaterialType = New DataColumn("MaterialType", System.Type.GetType("System.String"))

    '        m_dataSet.DataSetName = "Nest_Params"

    '        m_da_SheetResults.Fill(m_dataSet, "Sheet Results")

    '        m_da_PartResults.Fill(m_dataSet, "Part Result")

    '        m_da_Parts.Fill(m_dataSet, "Part")


    '        ' Define the relationship between the tables.
    '        Dim data_relation As New DataRelation("SheetResults_Parts", _
    '            m_dataSet.Tables("Sheet Results").Columns("ID"), _
    '            m_dataSet.Tables("Part Result").Columns("Sheet ID"))


    '        ' Define the relationship between the tables.
    '        Dim data_relation2 = New DataRelation("PartRelationship", _
    '            m_dataSet.Tables("Part").Columns("ID"), _
    '            m_dataSet.Tables("Part Result").Columns("Part ID"))


    '        m_dataSet.Relations.Add(data_relation)
    '        m_dataSet.Relations.Add(data_relation2)

    '        m_da_Parts.Update(m_dataSet.Tables("Part"))
    '        m_da_PartResults.Update(m_dataSet.Tables("Part Result"))
    '        m_da_SheetResults.Update(m_dataSet.Tables("Sheet Results"))

    '        For ni = 0 To m_dataSet.Tables(0).Columns.Count - 1
    '            MessageBox.Show(m_dataSet.Tables(0).Rows(ni).Item("Display"))
    '        Next

    '        If m_dataSet IsNot Nothing Then m_dataSet = Nothing

    '        If m_da_Parts IsNot Nothing Then m_da_Parts = Nothing

    '        If m_da_PartResults IsNot Nothing Then m_da_PartResults = Nothing

    '        If m_da_SheetResults IsNot Nothing Then m_da_SheetResults = Nothing

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Sub ProgressPatternImages_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs)
        e.DisplayText = "Loading Nested Parts " & e.Value
    End Sub

    Private Sub bbiMeasure_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMeasure.ItemClick
        Dim ms As New System.IO.MemoryStream(My.Resources.Cursor1)
        pnlPicmodeler.Cursor = New Cursor(ms)
        lReturn = ModeBegin(MODE_MEASURE)

    End Sub

    Private Sub bbPatternBump_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbPatternBump.ItemClick
        lReturn = appMain.ExecuteFunction(1408)
    End Sub
    Public Function GetPatternImage(entity_id As Long, is_pattern As Boolean) As Long
        'NOTE: is_pattern is True only when selecting from a list.
        Dim cmd As String
        Dim entity_type As Long
        Dim picH As Long
        Dim bounds As Rectangle = picPattern.Bounds
        Dim pt As Point = picPattern.PointToScreen(bounds.Location)
        Dim myBitmap As New Bitmap(bounds.Width, bounds.Height)
        Dim sPattern_Name As String
        Dim sImageFilename As String

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            GetPatternImage = 0  'assume failure.

            g_shape = Nothing
            lReturn = Reinit()
            picPattern.Refresh()
            If ((g_shape Is Nothing) = True) Then

                lReturn = PortalExecute("*create:extract:id=" & entity_id)
                entity_type = PortalGetInt("type", c_INVALID)
                If ((entity_type <> c_DBCOMMAND) And
                    (entity_type <> c_DBPATTERN)) Then
                    Exit Function
                End If

                'Selecting a new instance should clear the previous reference.
                g_shape = Nothing
                lReturn = modSelection.DeselectAll

                picH = picPattern.Handle

                If (bDo_BumpDrag = True) Then
                    'picPattern.Visible = False
                End If


                cmd = "nest:manual:instance:" &
                    " opt=" & BUMP_INIT &
                    ",id=" & entity_id &
                    ",hwnd=" & picH


                If (is_pattern = True) Then
                    cmd = cmd & ",pattern=1"
                    m_instance_id = 0
                Else
                    m_instance_id = entity_id
                End If

                lReturn = PortalExecute(cmd)

                m_pattern_id = PortalGetInt("pattern_id", 0)

                sPattern_Name = EntityStringGet(m_pattern_id, "_label", "<error>")

                sImageFilename = App_Path & "PatternImages\" & sPattern_Name & ".png"
                sImageFilename = PathTempFolder() & sPattern_Name & ".png"

                If (m_pattern_id > 0) Then

                    Using m_g As Graphics = Graphics.FromImage(myBitmap)

                        m_g.CopyFromScreen(New Point(pt.X - picPattern.Location.X, pt.Y - picPattern.Location.Y), Point.Empty, bounds.Size)

                        m_g.Dispose()

                    End Using

                    myBitmap.Save(sImageFilename)

                    myBitmap.Dispose()

                    '
                    'g_shape = New clsShape

                    ' GetPatternImage = ((g_shape Is Nothing) = False)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Function


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        statusTime.Caption = "Time: " & Now.ToString("hh:mm tt")
    End Sub

    Private Sub cboSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheets.SelectedIndexChanged
        Dim sFileName As String
        Dim n_SelIndex As Long

        Try
            n_SelIndex = cboSheets.SelectedIndex

            If (m_suppress = False) Then

                ' get the associated file name
                sFileName = CStr(TryCast(cboSheets.EditValue, myItemData).Name)



                sFileName = modFileIO.ImportMM2(sFileName)
                If (sFileName <> "") Then

                    PrepareUI(sFileName)

                Else

                    MsgBox("Unable to open the file:" & vbCrLf & vbTab & sFileName, vbCritical, App_Title)

                End If

                PatternComboShow()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboPatterns_CloseUp(sender As Object, e As CloseUpEventArgs) Handles cboPatterns.CloseUp
        pnlPicmodeler.Focus()
    End Sub


    Private Sub cboPatterns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPatterns.SelectedIndexChanged
        Dim PatId As Long

        Try
            If (m_suppress = False) Then

                If (cboPatterns.SelectedIndex = 0) Then
                    'frmMain.mnuEditPatternLabels.Enabled = False
                    'frmMain.mnuEditPatternDelete.Enabled = True
                Else
                    'frmMain.mnuEditPatternLabels.Enabled = True
                    'frmMain.mnuEditPatternDelete.Enabled = False
                End If

                PatId = (TryCast(cboPatterns.Properties.Items(cboPatterns.SelectedIndex), myItemData)).ItemData.ToString()


                lReturn = modSelection.DeselectAll()
                lReturn = PortalExecute("Pattern:Edit:id=" & PatId)

                modView.ViewAll()

                SelectionStatusUpdate(0)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub bbShowWelcome_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbShowWelcome.ItemClick
        frmStartUp.ShowDialog(Me)
    End Sub

    Private Sub bbiWECAD_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiWECAD.ItemClick

        lReturn = appMain.ExecuteFunction(515)

    End Sub

    Private Sub bbiCutShop_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCutShop.ItemClick

        lReturn = appMain.ExecuteFunction(512)

    End Sub

    Private Sub iHelp_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iHelp.ItemClick

        System.Windows.Forms.Help.ShowHelp(Me, Application.StartupPath & "\Help\WECIM_V21.chm", HelpNavigator.TableOfContents)

    End Sub

    Private Sub bbiDeactivae_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDeactivate.ItemClick



        lReturn = MessageBox.Show(Me, "Are you sure you want to deactivate this license? ", "License Deactivation.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If (lReturn = 1) Then
            lReturn = IP2Lib32Managed.WR_DeactivateInstallation(0, 0)

            'lReturn = IP2Lib32Managed.WR_DeactivateLicense(0)

            If (lReturn = 0) Then
                MessageBox.Show(Me, "Deactivated Failed! ", "License Deactivation.", vbOKOnly, MessageBoxIcon.Error)

            End If
            If (lReturn = 1) Then
                MessageBox.Show(Me, "The application was deactivated successfully. ", "License Deactivation.", vbOKOnly, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub bbiForTesting_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiForTesting.ItemClick
        ' frmPicModeler.TopLevel = False
        'frmPicModeler.TopMost = True
        'Me.pnlPicmodeler.Controls.Add(frmPicModeler)
        'frmPicModeler.Dock = DockStyle.Fill
        'frmPicModeler.Show()

        dlgFlipSheet.ShowDialog(Me)
        'dlgAddMulti.ShowDialog(Me)



        'CreateDXFHeader("c:\_jm\VS_Dxf_Print_Test.dxf")

    End Sub

    'Private Sub bbiBenchMark_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiBenchMark.ItemClick

    '    If (IS_CCS_FAB = True) Then
    '        b_ShowDefaultsDialog = True
    '        frmCCS_FAB_Setup.ShowDialog()
    '    End If

    'End Sub

    Private Sub tbViewSetTools_Click(sender As Object, e As EventArgs) Handles tbViewSetTools.Click
        lReturn = appMain.ExecuteFunction(2063)
    End Sub

    Private Sub tbViewSetLayers_Click(sender As Object, e As EventArgs) Handles tbViewSetLayers.Click
        lReturn = appMain.ExecuteFunction(2064)
    End Sub

    Private Sub tbSelect_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbSelect.ItemClicked

        lReturn = appMain.ExecuteFunction(CLng(e.ClickedItem.Tag))
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        RegPutString("Fabrication\FileOpen", "LastPDB", "")
    End Sub

    Private Sub ProcLcEvent(ByVal hEvent As Integer)
        Dim EventType As Integer
        EventType = Lcad.PropGetInt(hEvent, LC_PROP_EVENT_TYPE)
        Select Case EventType
            Case LC_EVENT_LBDOWN
                ProcLBDown(hEvent)
            Case LC_EVENT_MOUSEMOVE
                ProcMouseMove(hEvent)
            Case LC_EVENT_WNDVIEW
                ProcWndView(hEvent)
        End Select
    End Sub

    Private Sub ProcLBDown(ByVal hEvent As Integer)
        Dim hBlock As Integer, hEnt As Integer, bCtrl As Integer
        Dim X As Double, Y As Double
        bCtrl = Lcad.PropGetInt(hEvent, LC_PROP_EVENT_INT4)
        If (bCtrl = 1) Then
            hBlock = Lcad.PropGetHandle(hEvent, LC_PROP_EVENT_BLOCK)
            X = Lcad.PropGetFloat(hEvent, LC_PROP_EVENT_FLOAT1)
            Y = Lcad.PropGetFloat(hEvent, LC_PROP_EVENT_FLOAT2)
            hEnt = Lcad.BlockAddPoint(hBlock, X, Y)
            Lcad.BlockUpdate(hBlock, True, hEnt)
            Lcad.WndRedraw(hLcWnd)
            Lcad.EventReturnCode(1)
        End If
    End Sub
    Private Sub ProcMouseMove(ByVal hEvent As Integer)
        Dim szBuf As String
        Dim X As Double, Y As Double
        Dim hLcWnd As Integer

        hLcWnd = Lcad.PropGetHandle(hEvent, LC_PROP_EVENT_WND)

        ' Cursor coordinates
        X = Lcad.PropGetFloat(hEvent, LC_PROP_EVENT_FLOAT1)
        Y = Lcad.PropGetFloat(hEvent, LC_PROP_EVENT_FLOAT2)
        ' Display data in status bar
        ' X
        szBuf = X.ToString("F3")
        Lcad.StatbarText(hStatbar, 1, szBuf)
        ' Y
        szBuf = Y.ToString("F3")
        Lcad.StatbarText(hStatbar, 2, szBuf)
        ' redraw the status bar
        Lcad.StatbarRedraw(hStatbar)
    End Sub

    Private Sub ProcWndView(ByVal hEvent As Integer)
        Dim szBuf As String
        Dim X As Double, Y As Double
        Dim PixSize As Double, Lef As Double, Bot As Double, Rig As Double, Top As Double, dx As Double, dy As Double
        Dim hLcWnd As Integer

        hLcWnd = Lcad.PropGetHandle(hEvent, LC_PROP_EVENT_WND)
        PixSize = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_PIXELSIZE)
        X = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_CURX)
        Y = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_CURY)
        Lef = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_XMIN)
        Bot = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_YMIN)
        Rig = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_XMAX)
        Top = Lcad.PropGetFloat(hLcWnd, LC_PROP_WND_YMAX)
        dx = Rig - Lef
        dy = Top - Bot

        ' Display data in status bar
        ' X
        szBuf = X.ToString("F3")
        Lcad.StatbarText(hStatbar, 1, szBuf)
        ' Y
        szBuf = Y.ToString("F3")
        Lcad.StatbarText(hStatbar, 2, szBuf)
        ' Pixel size
        szBuf = "Pixel size: " + PixSize.ToString("F4")
        Lcad.StatbarText(hStatbar, 3, szBuf)
        ' visible area
        szBuf = "Visible area:  L=" + Lef.ToString("F2") + "  B=" + Bot.ToString("F2") + "  R=" + Rig.ToString("F2") + "  T=" + Bot.ToString("F2") + "   W=" + dx.ToString("F2") + "  H=" + dy.ToString("F2")
        Lcad.StatbarText(hStatbar, 4, szBuf)
        ' redraw the status bar
        Lcad.StatbarRedraw(hStatbar)
    End Sub

    Private Sub tbSelect_ByWindow_Click(sender As Object, e As EventArgs) Handles tbSelect_ByWindow.Click

    End Sub
    Private Sub LaunchCCS_Fab()





        ' MessageBox.Show("The reg setting for showing the dialog is < " & b_ShowDefaultsDialog & " > ")

        'If (b_ShowDefaultsDialog = False) Then

        'MessageBox.Show("We should go right to nesting")


        'doNesting()
        'Else

        If (b_ShowDefaultsDialog = False) Then

            SplashScreenManager.Default.SetWaitFormDescription("Loading and Settings defaults...")

        End If

        'MessageBox.Show("We should show the defaults dialog")
        GetAndSetCCSDefaults(frmCCS_FAB_Setup.cbeMachine, frmCCS_FAB_Setup.cbeLayerSetup,
                             frmCCS_FAB_Setup.cbeLeadSetup, frmCCS_FAB_Setup.cbeToolSetup,
                             frmCCS_FAB_Setup.cbeCutBackTool)

        SetToolSetup(frmCCS_FAB_Setup.cbeToolSetup.Text,
                     TryCast(frmCCS_FAB_Setup.cbeToolSetup.SelectedItem, myItemData).ItemData.ToString())

        SetLayerSetup(frmCCS_FAB_Setup.cbeLayerSetup.Text, TryCast(frmCCS_FAB_Setup.cbeLayerSetup.SelectedItem, myItemData).ItemData.ToString())
        SetLeadSetup(frmCCS_FAB_Setup.cbeLeadSetup.Text, TryCast(frmCCS_FAB_Setup.cbeLeadSetup.SelectedItem, myItemData).ItemData.ToString())
        SetMachine(frmCCS_FAB_Setup.cbeMachine.Text, TryCast(frmCCS_FAB_Setup.cbeMachine.SelectedItem, myItemData).ItemData.ToString())
        SetCutBackTool(frmCCS_FAB_Setup.cbeCutBackTool.Text, TryCast(frmCCS_FAB_Setup.cbeCutBackTool.SelectedItem, myItemData).ItemData.ToString())

        If (b_ShowDefaultsDialog = False) Then

            SplashScreenManager.Default.SetWaitFormDescription("Loading the spreadsheet...")

        End If

        frmCCS_FAB_Setup.SpreadsheetControl1.LoadDocument(PathXLSGet(), DocumentFormat.Xls)

        frmCCS_FAB_Setup.m_XLS_Name = PathXLSGet()

        frmCCS_FAB_Setup.GetSpreadSheet()


        frmCCS_FAB_Setup.PopulateDefaultSettings()

        frmCCS_FAB_Setup.GetPDBNames()


        PathPDB_Set(frmCCS_FAB_Setup.sMRP_DB)

        bDo_MRP_Nesting = True


        doNesting()

    End Sub
    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        IsFrmMainLoaded = True

        If (IS_CCS_FAB = True) Then

            If (b_ShowDefaultsDialog = False) Then

                If (bShowSplash = True) Then

                    SplashScreenManager.CloseForm()

                    bShowSplash = False

                End If

                SplashScreenManager.ShowForm(GetType(WaitForm1))

                LaunchCCS_Fab()

                SplashScreenManager.CloseForm()

            End If

        End If


    End Sub


    Private Sub beGraphicsPref_EditValueChanged(sender As Object, e As EventArgs) Handles beGraphicsPref.EditValueChanged

        If (IsFrmMainLoaded = True) Then
            If (beGraphicsPref.EditValue.ToString() <> "") Then
                sReturn = RegPutString("Preferences", "GraphicsDelay", CStr(beGraphicsPref.EditValue.ToString()))
            End If
        End If

    End Sub

    Private Sub bbiTechConnect_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiTechConnect.ItemClick

        Process.Start(App_Path & "\WE-CIM_signed.exe")

    End Sub

    Private Sub bbCMDB_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCMDB.ItemClick

    End Sub

    Private Sub BarShowTableGraphics_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarShowTableGraphics.CheckedChanged
        Call RegPutString("Preferences\ViewOptions", "ShowTableGraphics", IIf(BarShowTableGraphics.Checked = True, 1, 0))

        ShowHideTableGraphics()


    End Sub

    Private Sub bbiMRP_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMRP.ItemClick
        lReturn = ExecuteMRP()

        If (bDo_MRP_Nesting = True) Then
            bCameFromStartUp = True

            doNesting()
        End If

    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim m_cnMaterialType As New OleDb.OleDbConnection
        Dim m_daMMaterialType As OleDb.OleDbDataAdapter

        Dim m_cbMMaterialType As OleDb.OleDbCommandBuilder
        Dim m_dtMaterialType As New DataTable
        Dim sql As String
        Dim ds As New DataSet
        Dim drNewRow As DataRow = m_dtMaterialType.NewRow()
        Dim cmdGetID As New OleDbCommand
        Dim s_TemplateFile As String = "C:\Program Files (x86)\WE-CIM\22.0\Tech_Code.params"
        Dim SMaterialTypeString As String = Nothing


        'XtraForm4.ShowDialog(Me)

        Exit Sub

        Dim connection As New OleDbConnection

        Dim i As Integer = 1
        Dim my_sOptions As String
        Dim sData As String
        Dim indx As Long
        Dim sPieces() As String
        Dim my_DataType As Integer
        Dim my_DatVarName As String
        Dim my_DialogDisplay As String
        Dim my_VBValue As String
        Dim my_CValue As String

        sql = "SELECT [Material Types].* FROM [Material Types]"

        Try

            Using sr As StreamReader = New StreamReader(s_TemplateFile)

                While (sr.EndOfStream = False)
                    my_sOptions = Nothing

                    indx = indx + 1

                    sData = sr.ReadLine()

                    'NOTE:zero -based!
                    sPieces = Split(sData, "|")

                    If (DoesFieldExist(PathPDB(), "Part Result", sPieces(2)) = True) Then
                        GoTo skip
                    End If

                    my_DatVarName = sPieces(0)
                    my_DataType = ConvertDatTypeToDBType(sPieces(1))
                    my_DialogDisplay = Replace(sPieces(2), " ", "_")


                    Dim cmd As OleDbCommand = New OleDbCommand(sql, connection)

                    Select Case my_DataType

                        Case DB_STR

                            cmd.CommandText = "ALTER TABLE [Part Result] ADD [" & my_DialogDisplay & "] Text (255)"

                        Case DB_INT

                            cmd.CommandText = "ALTER TABLE [Part Result] ADD [" & my_DialogDisplay & "] Integer"

                        Case DB_DBL

                            cmd.CommandText = "ALTER TABLE [Part Result] ADD [" & my_DialogDisplay & "] Double"

                        Case DB_BOOL

                            cmd.CommandText = "ALTER TABLE [Part Result] ADD [" & my_DialogDisplay & "] BIT"

                        Case DB_DCOMBO, DB_COMBO

                            my_VBValue = sPieces(3)

                            For i = 4 To sPieces.Count - 1

                                If i = sPieces.Count - 1 Then

                                    my_sOptions = my_sOptions + sPieces(i).ToString

                                Else

                                    my_sOptions = my_sOptions + sPieces(i).ToString & "|"

                                End If

                                If (sPieces(i).ToString = my_VBValue) Then

                                    my_CValue = i - 4

                                End If
                            Next

                    End Select

                    cmd.ExecuteNonQuery()
skip:

                End While

                sr.Dispose()

            End Using

            connection.Close()
            connection.Dispose()

            m_cnMaterialType.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathCMDB()
            m_cnMaterialType.Open()
            m_daMMaterialType = New OleDb.OleDbDataAdapter(sql, m_cnMaterialType)
            m_cbMMaterialType = New OleDb.OleDbCommandBuilder(m_daMMaterialType)
            m_cbMMaterialType.QuotePrefix = "["
            m_cbMMaterialType.QuoteSuffix = "]"
            m_daMMaterialType.Fill(m_dtMaterialType)

            drNewRow("Description") = SMaterialTypeString
            drNewRow("Display") = SMaterialTypeString
            drNewRow("Shear Strength") = 0

            m_dtMaterialType.Rows.Add(drNewRow)
            m_daMMaterialType.Update(m_dtMaterialType)


            cmdGetID.Connection = m_cnMaterialType
            cmdGetID.CommandText = "SELECT MAX(ID) FROM [Material Types]"

            m_dtMaterialType.Dispose()

            If ds IsNot Nothing Then ds = Nothing
            If m_cnMaterialType IsNot Nothing Then m_cnMaterialType = Nothing

            If m_daMMaterialType IsNot Nothing Then m_daMMaterialType = Nothing

        Catch ex As Exception

            MessageBox.Show("BarButtonItem17_ItemClick: " & ex.Message)

        End Try

    End Sub

    Private Sub bbi_Rittal_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Rittal.ItemClick
        DoReports()

    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        XtraForm5.ShowDialog()
        'lReturn = appMain.ExecuteFunction(9600)

        'dlgFlipSheet.ShowDialog()
    End Sub

    Private Sub bbiForm1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiForm1.ItemClick
        'frmRegUserEntry.ShowDialog()
        dlgEditClamps.ShowDialog()


    End Sub

    Private Sub btmHeatTransfer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btmHeatTransfer.ItemClick
        Dim text As New System.Text.StringBuilder
        Dim Lam_num As Long
        Dim sMyLofFile As String

        sMyLofFile = "C:\1wittlockeng\Customers\Advanced Rotor\From Shop\Gary.log"

        For Lam_num = 0 To 224

            text.Append("admin:New" & vbCrLf)
            text.Append("view:clear" & vbCrLf)
            text.Append("file: ImportMM2: File = " & QStr("C:\1wittlockeng\Customers\Advanced Rotor\From Shop\LAM_" & Lam_num & ".mm2") & vbCrLf)
            text.Append("admin:  macrorun : javafile =" & QStr("C:\Program Files (x86)\WE-CIM\24.0\Macros\Create_Lams.java") & vbCrLf)
        Next

        System.IO.File.WriteAllText(sMyLofFile, text.ToString())

        'XtraForm3.Show(Me)
        'dlgHeatTransfer.Show()
        'frmNewMRP.Show()

    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        'XtraForm3.ShowDialog()


        Dim sOutfilename As System.IO.StreamWriter
        Dim sTempFile As String
        Dim sOutFile As String = "C:\_Dev\FabV24.0\VB_SRC\Resources\128Outfile.txt"
        Dim sMyline As String
        Dim DOUBLE_QUOTE As String = Chr(34) & Chr(34)

        sTempFile = "C:\_Dev\FabV24.0\VB_SRC\Resources\128HTML.txt"

        sOutfilename = My.Computer.FileSystem.OpenTextFileWriter(sOutFile, False)

        Using sr As StreamReader = New StreamReader(sTempFile)
            sMyline = sr.ReadLine()
            While (sMyline <> Nothing)
                sOutfilename.WriteLine(sMyline & DOUBLE_QUOTE & ")")
                sMyline = sr.ReadLine()
            End While
        End Using

        sOutfilename.Close()


    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        lReturn = ExecuteMRP()

        If (bDo_MRP_Nesting = True) Then
            bCameFromStartUp = True

            doNesting()
        End If

    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        dlgNestPartDefaults.Show(Me)

    End Sub

    Private Sub bbiFileManage_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFileManage.ItemClick
        frmFilemaintenance.Show(Me)

    End Sub

    Private Sub BarShowLegend_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarShowLegend.CheckedChanged

    End Sub

    Private Sub BarShowStock_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarShowStock.CheckedChanged

    End Sub

    Private Sub BarShowWorkzones_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarShowWorkzones.CheckedChanged

    End Sub

    Private Sub BarShowHandles_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarShowHandles.CheckedChanged

    End Sub

    Private Sub BarShowEndpoints_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarShowEndpoints.CheckedChanged

    End Sub

    Private Sub bbiFreightCarAmerica_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFreightCarAmerica.ItemClick
        dlgNewFreightCarAM.Show(Me)
    End Sub

    Private Sub bbiDiamondLife_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDiamondLife.ItemClick
        lReturn = appMain.ExecuteFunction(516)

        'Me.RibbonControl.SelectedPage = Me.ribProcess
        'Me.splitContainerControl.Panel1.Controls.Clear()
        'picPattern.Parent = RibbonControl

        ''Me.FormMgrOpen(NewdlgLifeGear, 0)
        ''NewdlgLifeGear.ShowDialog()

        'lReturn = appMain.ExecuteFunction(516)

        'picPattern.Visible = False
        'splitContainerControl.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both

        ''frm.Show()

        'splitContainerControl.SplitterPosition = frm.Width

        'Me.splitContainerControl.Panel1.Refresh()

        'frm.Size = Me.splitContainerControl.Panel1.Size


    End Sub

    Private Sub bbiPartExtents_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPartExtents.ItemClick
        Dim dXMin As Double
        Dim dXMax As Double
        Dim dYMin As Double
        Dim dYMax As Double
        Dim cnt As Integer
        Dim ni As Integer
        Dim entityID As Integer
        Dim lId As Integer
        Dim lParentID As Integer
        Dim lToolID As Integer
        Dim entcnt As Integer


        Dim pat_id As Integer
        Dim pattern_EntCnt As Integer
        Dim nMyOwner As Integer
        Dim entType As Integer
        Dim sPatName As String

        'TestFunction()

        lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBPATTERN)
        pattern_EntCnt = PortalGetInt("count", 0)

        For ni = 0 To pattern_EntCnt - 1
            lReturn = PortalExecute("*Model:Get2:indx=" & ni & ",type=" & c_DBPATTERN)
            pat_id = PortalGetInt("patid", 0)

            lReturn = PortalExecute("*create:extract:id=" & pat_id) ' Getting other info about entity
            lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
            lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any

            lReturn = PortalExecute("*Entity:Container:Count:id=" & pat_id)

            cnt = PortalGetInt("count", 0)

            'pat_id = PortalGetInt("id", 0)

            sPatName = EntityStringGet(pat_id, "_label", "<error>")

        Next

        For ni = 0 To SelectedCount() - 1

            lId = modSelection.GetAt(ni)
            entType = GetEntityType(lId)

            Select Case entType
                Case c_DBPOINT
                    'MessageBox.Show(" Found Point")
                Case c_DBLINE
                    'MessageBox.Show(" Found Line")
                Case c_DBARC
                    'MessageBox.Show(" Found Ar")
                Case c_DBHOLE
                    'MessageBox.Show(" Found File")
                Case c_DBPROFILE
                    'MessageBox.Show(" Found Profile")
                Case c_DBCOMMAND
                    'MessageBox.Show(" Found Comannd")
                Case c_DBFEATURE
                    'MessageBox.Show(" Found Feature")
                Case c_DBPATTERN
                    'MessageBox.Show(" Found Pattern")
            End Select


        Next

        For ni = 0 To SelectedCount() - 1

            lId = modSelection.GetAt(ni)
            lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity
            lParentID = PortalGetInt("owner", 0) ' Getting the parent ID
            lToolID = PortalGetInt("toolid", 0) ' Getting the tool ID if any


            '            MessageBox.Show("The entity type is < " & GetEntityType(lId) & " > ")

            If (GetEntityType(lId) = 8) Then
                pat_id = EntityIntGet(lId, "patid", 0)

                lReturn = PortalExecute(
                                "*Entity:Container:Get:" &
                                " id=" & lParentID &
                                ",index=1")
                entityID = PortalGetInt("id", 0)
                lReturn = PortalExecute("*create:extract:id=" & lParentID)
                nMyOwner = PortalGetInt("owner", 0)
                pattern_EntCnt = PortalGetInt("count", 0)
                'lToolID = PortalGetInt("toolid", 0)

                If (pattern_EntCnt > 0) Then
                    For ni2 = 0 To pattern_EntCnt

                    Next
                End If

            Else



                lReturn = PortalExecute("*Entity:Container:Count:id=" & lId)

                entcnt = PortalGetInt("count", 0)

                If (entcnt > 0) Then 'We check the child entities to see if they are part of the table graphics

                    lReturn = PortalExecute(
                                "*Entity:Container:Get:" &
                                " id=" & lId &
                                ",index=1")
                    entityID = PortalGetInt("id", 0)


                    lReturn = PortalExecute("*create:extract:id=" & entityID)

                    lToolID = PortalGetInt("toolid", 0)

                End If

            End If

            'sLayerName = EntityStringGet(lToolID, "Name", "<error>")
            'lColor = EntityIntGet(lId, "color", 16711680)


            'If (sLayerName = "TableGraphics") Then GoTo skip 'We do not want to show tablegrahics in the list

            'sname = GetDisplayName(lId)
            'End If

            'MessageBox.Show("The selected count is < " & SelectedCount() & " > and the entity ID is < " & entityID & " > ")
        Next

        If modSelection.SelectedCount > 0 Then

            MessageBox.Show(GetSelectionExtents(), "Part Extents", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            MessageBox.Show(CalculateDimensionsJustXY, "Part Extents", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        'lReturn = PortalExecute("*model:partextent:")
        'dXMin = PortalGetDouble("xmin", 0)
        'dXMax = PortalGetDouble("xmax", 0)
        'dYMin = PortalGetDouble("ymin", 0)
        'dYMax = PortalGetDouble("ymax", 0)
        'MessageBox.Show("Extents: X=" & Round(dXMax - dXMin, 4) & ", Y=" & Round(dYMax - dYMin, 4))

    End Sub
    Private Function CrossProduct(ByVal v1 As Vector3, ByVal v2 As Vector3) As Vector3
        'Dim x, y, z As Double
        'x = v1.Y * v2.Z - v2.Y * v1.Z
        'y = (v1.X * v2.Z - v2.X * v1.Z) * -1
        'z = v1.X * v2.Y - v2.X * v1.Y
        'Dim rtnvector = New Vector3(x, y, z)
        'rtnvector.Unitize()
        'Return rtnvector
        frmProfileBlend.ShowDialog(Me)
    End Function

    Private Sub ProfileBlend_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ProfileBlend.ItemClick
        Dim cmd As String
        Dim cnt As Long
        Dim indx As Long
        Dim lSelectionID As Long
        Dim lType As Long
        Dim xs As Double
        Dim ys As Double
        Dim xe As Double
        Dim ye As Double
        Dim Xc As Double
        Dim Yc As Double
        Dim dir As Long
        Dim dLevel As Double = 0.0
        Dim diam As Double
        Dim depth As Double
        Dim containerID As Integer
        Dim Count As Integer
        Dim indx2 As Integer
        Dim entityID As Long
        Dim ProfEntType As Long

        frmProfileBlend.ShowDialog()
    End Sub

    Private Sub PrintEntityList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintEntityList.ItemClick

        frmPrintEntityList.ShowDialog()

    End Sub

    Private Sub bbiProfileBlend_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiProfileBlend.ItemClick

        FormMgrOpen(dlgProfileBlend, 9500)

    End Sub

    Private Sub pnlPicmodeler_KeyUp(sender As Object, e As KeyEventArgs) Handles pnlPicmodeler.KeyUp
        Try
            ProcessKeyPress(e.KeyCode, e.Modifiers)
            'If (e.KeyCode = System.Windows.Forms.Keys.Delete) Then
            '    lReturn = appMain.ExecuteFunction(2003)
            '    'Else
            '    '    lReturn = appMain.ProcessKeyPress(e.KeyCode, 0)
            'End If

            'If (e.KeyCode = System.Windows.Forms.Keys.Escape) Then
            '    'DefaultToolTipController1.DefaultController.HideHint()
            '    ModeCancelCurrent()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        sReturn = RegPutString("Global", "SkinName", UserLookAndFeel.Default.SkinName)

        'My.Settings.Default("ApplicationSkinName") = UserLookAndFeel.Default.SkinName
        'My.Settings.Default.Save()
    End Sub

    Private Sub bbiFlipSheet_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFlipSheet.ItemClick
        lReturn = appMain.ExecuteFunction(9600)

    End Sub

    Private Sub bbiMaterialList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMaterialList.ItemClick
        On Error Resume Next

        frmPrintMaterial.ShowDialog(Me)
    End Sub

    Private Sub PrintCrossData_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintCrossData.ItemClick
        Dim nAttribCount As Long

        modSelection.SelectEntity(114)
        nAttribCount = modSelection.SelectedCount

        lReturn = PortalExecute("*Attrib:Selected:Count:")

        nAttribCount = PortalGetInt("count", 0)
    End Sub

    Private Sub BarSaveLastUsed_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles BarSaveLastUsed.CheckedChanged

    End Sub

    Private Sub PatternToCircle_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PatternToCircle.ItemClick
        lReturn = appMain.ExecuteProcess(2062)
    End Sub

    Private Sub tbSelect_Lines_Click(sender As Object, e As EventArgs) Handles tbSelect_Lines.Click

    End Sub

    Private Sub bbiCircleResize_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCircleResize.ItemClick
        FormMgrOpen(dlgResizeCircle, 0)
    End Sub

    Private Sub btnTanaka_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnTanaka.ItemClick
        lReturn = appMain.ExecuteFunction(2047)
    End Sub

    Private Sub bbiAppDBConvert_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiAppDBConvert.ItemClick
        lReturn = appMain.ExecuteFunction(2068)
    End Sub


    Private Sub tbSelect_Layers_Click(sender As Object, e As EventArgs) Handles tbSelect_Layers.Click

    End Sub

    Private Sub bbiCreateLams_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCreateLams.ItemClick
        If (bIsShapeLibraryLoaded = True) Then
            frmShapeLibrary.Dispose()
        End If
        RegPutString("MRU", "Macro", App_Path & "\Macros\MultiRotor.java")

        frmShapeLibrary.Init(MACRO_OPTION.MACRO_NORM)

        lReturn = appMain.ExecuteFunction(109)
    End Sub

    Private Sub bbiRotors_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiRotors.ItemClick
        If (bIsShapeLibraryLoaded = True) Then
            frmShapeLibrary.Dispose()
        End If
        RegPutString("MRU", "Macro", App_Path & "\Macros\stator.java")

        frmShapeLibrary.Init(MACRO_OPTION.MACRO_NORM)

        lReturn = appMain.ExecuteFunction(109)
    End Sub

    Private Sub bbiQuickSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiQuickSave.ItemClick
        lReturn = appMain.ExecuteFunction(103)
    End Sub

    Private Sub bbiSaveAs_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSaveAs.ItemClick
        lReturn = appMain.ExecuteFunction(104)
    End Sub

    Private Sub TestFunction()
        Dim lPatternCount As Long
        Dim nI As Integer
        Dim lPatID As Integer
        Dim lInstID As Long
        Dim sPatName As String
        Dim nPatEntCnt As Integer
        Dim cnt As Integer
        Dim entityID As Integer
        Dim entType As Integer
        Dim nEntCnt As Integer
        Dim xmin As Double
        Dim xmax As Double
        Dim ymax As Double
        Dim ymin As Double
        Dim temptext As String
        Dim sTemp As String
        Dim entity_type As Integer
        Dim pat_angle As Double
        Dim sToolTip As String
        Dim delim As String
        Dim dx As Double
        Dim dy As Double
        Dim dz As Double
        Dim sPieces() As String
        Dim sPieces2() As String
        Dim swDatFile As System.IO.StreamWriter
        Dim sDatFilename As String = App_Path & "\debug\Patern_box2D.txt"

        lReturn = PortalExecute("*Model:EntityCount: type=" & c_DBCOMMAND)
        cnt = PortalGetInt("count", 0)

        If (cnt > 0) Then

            swDatFile = My.Computer.FileSystem.OpenTextFileWriter(sDatFilename, False)

            picPattern.Visible = True

            nI = 0

            For indx = 0 To (cnt - 1)
                picPattern.Refresh()


                lReturn = PortalExecute("*Model:Get2: indx=" & indx & ", type=" & c_DBCOMMAND)
                lInstID = PortalGetInt("id", 0)
                sPatName = EntityStringGet(lInstID, "_label", "<error>")

                lPatID = EntityIntGet(lInstID, "Part_ID", 0)

                pat_angle = EntityDoubleGet(lInstID, "part_angle", 0)

                'pat_angle = Radians2Degrees(pat_angle)


                lReturn = PortalExecute("*create:extract:id=" & lInstID) ' Getting other info about entity

                sTemp = PortalGetString("text", "")

                If InStr(1, sTemp, "INSTANCE") > 0 Then
                    sTemp = PortalGetString("label", "")
                    'Dim spartStart As Integer = InStr(1, sTemp, "=")
                    sToolTip = sToolTip & sTemp & delim
                    'pat_angle = Mid(sPieces(1), spartStart)
                    dx = PortalGetDouble("x", 0)
                    dy = PortalGetDouble("y", 0)
                    dz = PortalGetDouble("z", 0)
                    sToolTip = sToolTip & "Handle Point X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dz)
                    ' MessageBox.Show(sToolTip, "Greg's INfo.", MessageBoxButtons.OKCancel)
                End If


                lPatID = EntityStringGet(lInstID, "patID", "-1")
                sPatName = EntityStringGet(lPatID, "_label", "<error>")
                If (sPatName <> "<error>") Then
                    lReturn = PortalExecute("*Entity: Box:id=" & lInstID)
                    xmin = (PortalGetDouble("xmin", 0))
                    xmax = (PortalGetDouble("xmax", 0))
                    ymin = PortalGetDouble("ymin", 0)
                    ymax = PortalGetDouble("ymax", 0)

                    'pat_angle = PortalGetDouble("part_angle", 0)

                    temptext = "This should be the bounding box of the part < " & sPatName & " >. " &
                        vbCrLf & "ID = " & lInstID &
                        vbCrLf & "Pattern ID =" & lPatID &
                        vbCrLf & "Pattern Angle = " & pat_angle &
                        vbCrLf & "Xmin = " & xmin &
                        vbCrLf & "Xmax = " & xmax &
                        vbCrLf & " Ymin = " & ymin &
                        vbCrLf & " Ymax = " & ymax &
                        vbCrLf & "Handle Point X:" & Round(dx) & " Y:" & Round(dy) & " Z:" & Round(dz)

                    swDatFile.WriteLine(temptext)
                    swDatFile.WriteLine(vbCrLf)


                    MessageBox.Show(temptext, "Greg's Equal Space.", MessageBoxButtons.OKCancel)

                End If

                lReturn = PortalExecute("*Entity:Container:Count:id=" & lInstID)

                nEntCnt = PortalGetInt("count", 0)


                If (nEntCnt > 0) Then
                    lReturn = PortalExecute("*create:extract:id=" & lInstID)

                    entity_type = PortalGetInt("type", c_INVALID)

                    sTemp = UCase(PortalGetString("text", ""))



                    If InStr(1, sTemp, "INSTANCE") > 0 Then
                        sPatName = PortalGetInt("patid", c_INVALID)

                        MessageBox.Show("We found a instance which is a entity type of < " & entity_type & " > The pattern id is < " & lInstID & " > ")

                    End If


                End If

                ' partidnum = EntityIntGet(pattern_id, "Part_ID", 0)

                'pat_angle = EntityDoubleGet(pattern_id, "part_angle", 0)

                'pat_angle = Radians2Degrees(pat_angle)
            Next

            swDatFile.Close()

        End If


    End Sub

    Private Sub tbViewSelHide_Click(sender As Object, e As EventArgs) Handles tbViewSelHide.Click
        Dim ni As Integer
        Dim lSelectionID As Long

        Try

            For ni = 0 To SelectedCount() - 1
                lSelectionID = modSelection.GetAt(ni)

                lReturn = PortalExecute("entity:hide:id=" & lSelectionID)

                modView.ViewRegen()

            Next

        Catch ex As Exception

            MessageBox.Show("tbViewSelHide_Click: " & ex.Message)

        End Try

    End Sub

    Private Sub tbViewSelShow_Click(sender As Object, e As EventArgs) Handles tbViewSelShow.Click
        Dim ni As Integer
        Dim lSelectionID As Long

        Try

            For ni = 0 To SelectedCount() - 1

                lSelectionID = modSelection.GetAt(ni)

                lReturn = PortalExecute("entity:show:id=" & lSelectionID)

                modView.ViewRegen()
            Next

        Catch ex As Exception

            MessageBox.Show("tbViewSelShow_Click: " & ex.Message)

        End Try

    End Sub


End Class

Public Class BarItemDrawSettings
    Private privateBorderStyle As Integer
    Public Property BorderStyle() As Integer
        Get
            Return privateBorderStyle
        End Get
        Set(ByVal value As Integer)
            privateBorderStyle = value
        End Set
    End Property
    Private privateButtonKind As ButtonPredefines
    Public Property ButtonKind() As ButtonPredefines
        Get
            Return privateButtonKind
        End Get
        Set(ByVal value As ButtonPredefines)
            privateButtonKind = value
        End Set
    End Property
End Class

Public Class BorderPaintersHelper

    Private _Painters() As EditorButtonPainter
    Public ReadOnly Property Painters() As EditorButtonPainter()
        Get
            Return _Painters
        End Get
    End Property
    Public Sub New()
        CreatePainters()
    End Sub

    Private Sub CreatePainters()
        _Painters = New EditorButtonPainter(System.Enum.GetValues(GetType(BorderStyles)).Length - 1) {}
        Painters(CInt(Fix(BorderStyles.NoBorder))) = New EditorButtonPainter(New FlatButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.Simple))) = New EditorButtonPainter(New SimpleButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.Flat))) = New EditorButtonPainter(New FlatButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.HotFlat))) = New EditorButtonPainter(New HotFlatButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.UltraFlat))) = New EditorButtonPainter(New UltraFlatButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.Style3D))) = New EditorButtonPainter(New Style3DButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.Office2003))) = New EditorButtonPainter(New Office2003ButtonObjectPainter())
        Painters(CInt(Fix(BorderStyles.Default))) = New EditorButtonPainter(New Office2003ButtonInBarsObjectPainter())
    End Sub

End Class


