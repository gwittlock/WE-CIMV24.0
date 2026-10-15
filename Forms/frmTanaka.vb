Public Class frmTanaka
    Private m_is_active As Boolean
    Private Sub frmTanaka_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lCount As Long
        Dim entitytype
        Dim entityID As Long
        Dim sTemp As String
        Dim lFeatureCount As Long
        Dim lFeatureID As Long

        UndoPrepare()

        lstAllInstance.Items.Clear()

        lReturn = SetFormIcon(Me)

        lstPattern.Items.Clear()

        lReturn = PortalExecute("*Model:EntityCount:type=" & c_DBCOMMAND)
        lFeatureCount = PortalGetInt("count", 0)

        For nI = 0 To lFeatureCount - 1
            lReturn = PortalExecute("*Model:Get2:indx=" & nI & ",type=" & c_DBCOMMAND)
            lFeatureID = PortalGetInt("id", 0)
            lReturn = PortalExecute("*create:extract:id=" & lFeatureID)
            sTemp = UCase(PortalGetString("TEXT", ""))

            If lFeatureID <= 0 Then GoTo Skip ' this should never be, but...

            If InStr(1, sTemp, "@INSTANCE") > 0 Then

                lstAllInstance.Items.Add(lFeatureID)

            End If

Skip:

        Next





        '        lReturn = PortalExecute("*admin:treeinit:")
        '        lReturn = PortalExecute("*admin:treecount:")
        '        lCount = PortalGetInt("count", 0)


        '        For lCounter = 0 To (lCount - 1)
        '            lReturn = PortalExecute("*admin:treeget:index=" & lCounter)
        '            lId = PortalGetInt("id", 0) ' Getting the entity ID



        '            lReturn = PortalExecute("*create:extract:id=" & lId) ' Getting other info about entity

        '            sTemp = UCase(PortalGetString("TEXT", ""))



        '            If lId <= 0 Then GoTo Skip ' this should never be, but...

        '            If InStr(1, sTemp, "@INSTANCE") > 0 Then

        '                lstAllInstance.Items.Add(lId)

        '            End If

        'Skip:

        '        Next


        m_is_active = True
    End Sub

    Private Sub frmTanaka_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        m_is_active = False
        frmMain.CloseFirstPanel()
        modView.ViewRegen()
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim m_count As Long = 0
        Dim count As Long
        Dim lFeatureID As Long
        Dim indx As Long
        Dim zone_num As Long
        Dim iFeatureName As Long
        Dim entityID As Long
        Dim xmin As Double
        Dim xmax As Double
        Dim ymin As Double
        Dim ymax As Double
        Dim dx As Double
        Dim dy As Double
        Dim dz As Double
        Dim sTemp As String
        Dim Zone_ID As Long
        Dim iZoneCounter As Long


        Try
            UndoPrepare()

            'lstPattern.Items.Clear()

            lReturn = PortalExecute("zone:count:")
            m_count = PortalGetInt("count", 0)

            For indx = 1 To m_count
                iFeatureName = PortalExecute("zone:get:_zone_num=" & indx)

                If (lReturn > 0) Then

                    lFeatureID = Round(PortalGetInt("ID", 0))
                    lReturn = PortalExecute("Entity:Container:BenignFlush: id=" & lFeatureID)
                    lReturn = PortalExecute("Create:Delete: id=" & lFeatureID)

                End If

            Next


            For indx = 0 To lstPattern.ItemCount - 1

                entityID = lstPattern.Items(indx)

                lReturn = PortalExecute("*create:extract:id=" & entityID)
                dx = PortalGetDouble("x", 0.0#)
                dy = PortalGetDouble("y", 0.0#)
                dz = PortalGetDouble("z", 0.0#)

                iZoneCounter = iZoneCounter + 1

                lReturn = PortalExecute("*Entity: Box:id=" & entityID)
                xmin = (PortalGetDouble("xmin", 0))
                xmax = (PortalGetDouble("xmax", 0))
                ymin = PortalGetDouble("ymin", 0)
                ymax = PortalGetDouble("ymax", 0)
                dx = PortalGetDouble("x", 0.0#)
                dy = PortalGetDouble("y", 0.0#)
                dz = PortalGetDouble("z", 0.0#)

                lReturn = PortalExecute(
                                            "zone:update:" &
                                            "_zone_num=" & iZoneCounter &
                                            ",_zone_bottom=0" &
                                            ",_zone_left=0" &
                                            ",_zone_right=0" &
                                            ",_zone_top=0")

                Zone_ID = PortalGetInt("ID", 0)
                lReturn = FeatureAdd(Zone_ID, entityID)

            Next

            If ceFirstPartInsp.Checked = True Then

                iZoneCounter = iZoneCounter + 1

                lReturn = PortalExecute(
                                            "zone:update:" &
                                            "_zone_num=" & iZoneCounter &
                                            ",_zone_bottom=0" &
                                            ",_zone_left=0" &
                                            ",_zone_right=0" &
                                            ",_zone_top=0")

                Zone_ID = PortalGetInt("ID", 0)



                For indx = 0 To lstAllInstance.ItemCount - 1

                    entityID = lstAllInstance.Items(indx).ToString

                    lReturn = FeatureAdd(Zone_ID, entityID)

                Next

            End If

            MessageBox.Show("Process Complete! ", "Sequence Applied.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            modView.ViewRegen()

            UndoCommit()


        Catch ex As Exception
            MessageBox.Show("Edit Sequence By Instance: " & ex.Message)
        End Try


        modView.ViewRegen()

    End Sub

    Public Function AddInstanceToList(nInstanceID) As Long
        lstPattern.Items.Add(nInstanceID)

    End Function
    Public Function IsActive() As Boolean
        IsActive = m_is_active
    End Function

    Private Sub ceFirstPartInsp_CheckedChanged(sender As Object, e As EventArgs) Handles ceFirstPartInsp.CheckedChanged

    End Sub
End Class