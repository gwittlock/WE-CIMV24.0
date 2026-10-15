Public Class dlgEWMSettings
    Private Flags As Long

    Private Sub dlgEWMSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim choice As Long
        Dim dval As Double


        Try
            lcbGapManagement.Clear()
            lcbGapManagement.AddItem("None")
            lcbGapManagement.AddItem("V16.5 behavior")
            lcbGapManagement.AddItem("Experimental")
            choice = RegGetString("Nesting", "use_gap_tool", "2")
            lcbGapManagement.ListIndex = IIf(((choice >= 0) And (choice <= 2)), choice, 1)

            lcbToolExtrusion.Clear()
            lcbToolExtrusion.AddItem("Disabled")  'V16.5 behavior
            lcbToolExtrusion.AddItem("Enabled")
            choice = RegGetString("Nesting", "use_tool_extruder", "1")
            lcbToolExtrusion.ListIndex = IIf(((choice >= 0) And (choice <= 1)), choice, 1)

            lcbGraphics.Clear()
            lcbGraphics.AddItem("None")
            lcbGraphics.AddItem("Wireframe")
            lcbGraphics.AddItem("Bitmap")
            lcbGraphics.AddItem("Both")
            choice = RegGetString("Nesting", "graphics", "0")
            lcbGraphics.ListIndex = IIf(((choice >= 0) And (choice <= 3)), choice, 0)

            lcbPrintSeeds.Clear()
            lcbPrintSeeds.AddItem("Disabled")
            lcbPrintSeeds.AddItem("Enabled")
            choice = RegGetString("Nesting", "print_seeds", "0")
            lcbPrintSeeds.ListIndex = IIf(((choice >= 0) And (choice <= 1)), choice, 0)

            lcbUseBitmapNesting.Clear()
            lcbUseBitmapNesting.AddItem("Disabled")
            lcbUseBitmapNesting.AddItem("Enabled")
            choice = RegGetString("Nesting", "bn", "0")
            lcbUseBitmapNesting.ListIndex = IIf(((choice >= 0) And (choice <= 1)), choice, 0)

            lcbV17LPP.Clear()
            lcbV17LPP.AddItem("Disabled")
            lcbV17LPP.AddItem("Enabled")
            choice = RegGetString("Nesting", "lpp", "0")
            lcbV17LPP.ListIndex = IIf(((choice >= 0) And (choice <= 1)), choice, 0)

            dval = RegGetString("Nesting", "gap_tol", "-1.")
            mtbGapTol.Text = dval

            dval = RegGetString("Nesting", "resolution", "-1.")
            mtbResolution.Text = dval

            lcbFilterDuplicates.Clear()
            lcbFilterDuplicates.AddItem("Disabled")
            lcbFilterDuplicates.AddItem("Enabled")
            choice = RegGetString("CadToCode", "dups", "1")
            lcbFilterDuplicates.ListIndex = IIf(((choice >= 0) And (choice <= 1)), choice, 0)

            lcbUseOldDxf.Clear()
            lcbUseOldDxf.AddItem("Disabled")
            lcbUseOldDxf.AddItem("Enabled")
            choice = RegGetString("Global", "Old_Dxf_Convert", "1")
            lcbUseOldDxf.ListIndex = IIf(((choice >= 0) And (choice <= 1)), choice, 0)

            cbfEWMSettings.Checked = RegGetString("Debug", "admin_ACTIVE", 0)
            chkEWMFilter.CheckState = RegGetString("Debug", "admin_FILTERED", 0)
            chkEWMWarnings.CheckState = RegGetString("Debug", "admin_WARNING", 0)
            chkEWMUser.CheckState = RegGetString("Debug", "admin_USER", 0)
            chkEWMInternal.CheckState = RegGetString("Debug", "admin_INTERNAL", 0)
            chkEWMDiagnostics.CheckState = RegGetString("Debug", "admin_DIAGNOSTIC", 0)
            chkEWMPortal.CheckState = RegGetString("Debug", "admin_PORTAL", 0)
            chkEWMUI.CheckState = RegGetString("Debug", "admin_UI", 0)
            chkEWMDao.CheckState = RegGetString("Debug", "admin_DAO", 0)
            chkEWMNesting.CheckState = RegGetString("Debug", "admin_NESTING", 0)
            chkEWMSeeds.CheckState = RegGetString("Debug", "admin_SEED", 0)
            chkEWMFile.CheckState = RegGetString("Debug", "admin_FILE", 0)

            chkUseAutoLog.CheckState = RegGetString("Debug", "UseAutoLog", 0)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Dispose()

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        Try
            lReturn = Set_EWM_Settings()

            RegPutString("Nesting", "use_gap_tool", lcbGapManagement.ListIndex)
            RegPutString("Nesting", "use_tool_extruder", lcbToolExtrusion.ListIndex)
            RegPutString("Nesting", "graphics", lcbGraphics.ListIndex)
            RegPutString("Nesting", "print_seeds", lcbPrintSeeds.ListIndex)
            RegPutString("Nesting", "bn", lcbUseBitmapNesting.ListIndex)
            RegPutString("Nesting", "gap_tol", mtbGapTol.Text)
            RegPutString("Nesting", "resolution", mtbResolution.Text)
            RegPutString("Nesting", "lpp", lcbV17LPP.ListIndex)
            RegPutString("CadToCode", "dups", Me.lcbFilterDuplicates.ListIndex)


            RegPutString("Debug", "admin_ACTIVE", cbfEWMSettings.Checked)
            RegPutString("Debug", "admin_FILTERED", chkEWMFilter.CheckState)
            RegPutString("Debug", "admin_WARNING", chkEWMWarnings.CheckState)
            RegPutString("Debug", "admin_USER", chkEWMUser.CheckState)
            RegPutString("Debug", "admin_INTERNAL", chkEWMInternal.CheckState)
            RegPutString("Debug", "admin_DIAGNOSTIC", chkEWMDiagnostics.CheckState)
            RegPutString("Debug", "admin_PORTAL", chkEWMPortal.CheckState)
            RegPutString("Debug", "admin_UI", chkEWMUI.CheckState)
            RegPutString("Debug", "admin_DAO", chkEWMDao.CheckState)
            RegPutString("Debug", "admin_NESTING", chkEWMNesting.CheckState)
            RegPutString("Debug", "admin_SEED", chkEWMSeeds.CheckState)
            RegPutString("Debug", "admin_FILE", chkEWMFile.CheckState)

            RegPutString("Debug", "UseAutoLog", chkUseAutoLog.CheckState)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Function Set_EWM_Settings() As Long

        Flags = 0


        Try

            If (cbfEWMSettings.Checked = True) Then
                Flags = admin_ACTIVE

                If (chkEWMFilter.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_FILTERED
                End If
                If (chkEWMWarnings.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_WARNING
                End If
                If (chkEWMUser.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_USER
                End If
                If (chkEWMInternal.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_INTERNAL
                End If
                If (chkEWMDiagnostics.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_DIAGNOSTIC
                End If
                If (chkEWMPortal.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_PORTAL
                End If
                If (chkEWMUI.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_UI
                End If
                If (chkEWMDao.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_DAO
                End If
                If (chkEWMNesting.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_NESTING
                End If
                If (chkEWMSeeds.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_SEED
                End If
                If (chkEWMFile.CheckState = CheckState.Checked) Then
                    Flags = Flags + admin_FILE
                End If

                lReturn = PortalExecute("Admin:ewm:open=1")
                lReturn = PortalExecute("Admin:Errors:Flags=" & Flags)

            Else

                lReturn = PortalExecute("Admin:ewm:close=1")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


End Class