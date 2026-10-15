Imports System.Windows


Public Class frmProfileBlend

    Private Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Dim L1SX As Double
    Dim L1SY As Double
    Dim LS1Z As Double
    Dim L2SX As Double
    Dim L2SY As Double
    Dim L2SZ As Double
    Dim L2EY As Double
    Dim L2EX As Double
    Dim L3EY As Double
    Dim L3EX As Double
    Dim L3EZ As Double
    Dim cornerNum As Integer

    'Dim s_flename As String = Application.StartupPath & "\CrossDataOutput.txt"
    Private crossProduct As Double
    Private crossProduct2 As Double
    Private m_Points(3) As POINTAPI
    Private m_NextPoint As Short

    'Dim 'objWriter As New System.IO.StreamWriter(s_flename)

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click


        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub crossProductExample(indxNum As Long)
        Dim stemp As String
        Dim vec1x As Double
        Dim vec1Y As Double
        Dim vec2x As Double
        Dim vec2Y As Double

        Try
            Dim vector1 As Vector = New Vector(Double.Parse(L1SX), Double.Parse(L1SY))
            Dim vector2 As Vector = New Vector(Double.Parse(L2EX), Double.Parse(L2EY))


            crossProduct = (vector1.X * vector2.Y) - (vector1.Y * vector2.X)

            crossProduct = Vector.CrossProduct(vector1, vector2)

            Me.ListBoxControl1.Items.Add("entity: " & indxNum & " - dir1 = " & crossProduct)

            'objWriter.WriteLine("entity: " & indxNum & " - dir1 = " & crossProduct)

            If (L3EX <> Nothing) Then
                Dim vector3 As Vector = New Vector(Double.Parse(L3EX), Double.Parse(L3EY))

                crossProduct2 = Vector.CrossProduct(vector2, vector3)

                Me.ListBoxControl1.Items.Add("entity; " & indxNum & " - dir2 = " & crossProduct2)

                'objWriter.WriteLine("entity; " & indxNum & " - dir2 = " & crossProduct2)

                If (crossProduct2 < 0) Then
                    stemp = "CW"
                Else
                    stemp = "CCW"
                End If


                Me.ListBoxControl1.Items.Add("The direction Of the fillet is " & stemp)
                Me.ListBoxControl1.Items.Add("---------------------------------------")
                'objWriter.WriteLine("The direction Of the fillet is " & stemp)
                'objWriter.WriteLine("---------------------------------------")

            End If
        Catch ex As Exception

            MessageBox.Show("crossProductExample < " & ex.Message & " >")

        End Try
    End Sub

    Private Sub sbDetermineCross_Click(sender As Object, e As EventArgs) Handles sbDetermineCross.Click

        'MasterCheck()


    End Sub

    Private Sub frmProfileBlend_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'objWriter.Close()
    End Sub

    Public Function MasterCheck() As Boolean
        Dim cnt As Long
        Dim indx As Long
        Dim indx2 As Long
        Dim lSelectionID As Long
        Dim lType As Long
        Dim dir As Long
        Dim containerID As Integer
        Dim Count As Integer
        Dim entityID As Long
        Dim ProfEntTYpe As Long
        Dim pt1SX, pt1SY, pt1SZ As Double
        Dim pt2SX, pt2SY, pt2SZ As Double
        Dim pt3SX, pt3SY, pt3SZ As Double
        Dim pt1EX, pt1EY, pt1EZ As Double
        Dim pt2EX, pt2EY, pt2EZ As Double
        Dim pt3EX, pt3EY, pt3EZ As Double
        Dim firstloop As Boolean = True
        Dim pntIndx As Long = 1
        Dim sTheAngle As Double
        Dim m_Radius As Double = 0.5
        Dim m_EntityID_1 As Long
        Dim m_EntityID_2 As Long
        Dim m_EntityID_3 As Long


        Try

            MasterCheck = False

            m_NextPoint = 1

            'Get the  count from the Selected Profile.
            'This    routine will only work on profilew

            'cnt = modProfileBlend.count()

            cnt = modSelection.SelectedCount

            'Loop through each entity in the profile
            For indx = 1 To cnt

                'Get the entity ID for the entity at the "indx" position in the selection
                lSelectionID = modSelection.GetAt(indx - 1)

                'Get the iiproperties of the entity
                lReturn = PortalExecute("*create:extract:id=" & lSelectionID)

                'Get the geometry type to make sure we are working with a profile
                lType = PortalGetInt("type", c_INVALID)

                dir = PortalGetInt("dir", 1)

                Select Case lType

                    'For now we only work with selected profiles
                    Case c_DBPROFILE

                        'We have a Profile so we can continue.
                        containerID = lSelectionID

                        'get the number of entities in th profile
                        lReturn = PortalExecute("*Entity:Container:Count:id=" & containerID)

                        'Loop through each entity within the profile.
                        Count = PortalGetInt("count", 0)

                        firstloop = True

                        'Loop through each entity within the selected profile.
                        For indx2 = 0 To (Count - 1)

                            Dim m_StartPts(3) As Point3D
                            Dim m_EndPts(3) As Point3D

                            'let's get some dat from the nth entity in the profile specified by "indx2"
                            lReturn = PortalExecute("*Entity:Container:Get:" & " id=" & containerID & ",index=" & indx2)

                            'Set the entity ID 
                            entityID = PortalGetInt("id", 0)

                            'Now w have the entity, so let's get some infr from it.
                            lReturn = PortalExecute("*create:extract:id=" & entityID)

                            'see what type of entity is within the profile at "indx2"
                            ProfEntTYpe = PortalGetInt("type", c_INVALID)

                            'right now we are only dealing with lines, so we check the type
                            If (ProfEntTYpe = c_DBLINE) Then

                                Dim veca As New Vector3D
                                Dim Pnt1E As New Point3D
                                Dim pt1S As New Point3D

                                pt1S.X = PortalGetDouble("sx", 0)
                                pt1S.Y = PortalGetDouble("sy", 0)
                                pt1S.Z = PortalGetDouble("sz", 0)

                                Pnt1E.X = PortalGetDouble("ex", 0)
                                Pnt1E.Y = PortalGetDouble("ey", 0)
                                Pnt1E.Z = PortalGetDouble("ez", 0)

                                m_EntityID_1 = entityID

                                'objWriter.WriteLine("Point: " & (indx2 + 1))
                                'objWriter.WriteLine(pt1S.X & "," & pt1S.Y & "," & pt1S.Z)
                                'objWriter.WriteLine(Pnt1E.X & "," & Pnt1E.Y & "," & Pnt1E.Z)
                                'objWriter.WriteLine("  ")

                                If (firstloop) Then

                                    If ((pntIndx) Mod 3 = 0) Then

                                        firstloop = False

                                        Dim strtemp As String = (pntIndx - 2) & "," & (pntIndx - 1) & "," & pntIndx

                                        'objWriter.WriteLine("Blend It")
                                        'objWriter.WriteLine("  ")

                                        lReturn = PortalExecute(
                                                "Solve:Blend:" &
                                                " idA=" & m_EntityID_1 &
                                                ",idB =" & m_EntityID_2 &
                                                ",rad = " & m_Radius)

                                    End If

                                Else

                                    Dim strtemp As String = (pntIndx - 2) & "," & (pntIndx - 1) & "," & pntIndx
                                    Dim Pnt2E As New Point3D
                                    Dim pt2S As New Point3D

                                    'objWriter.WriteLine(" ")
                                    'objWriter.WriteLine(strtemp)
                                    'objWriter.WriteLine("  ")
                                    'objWriter.WriteLine("Blend It")
                                    'objWriter.WriteLine("  ")

                                    pt2S.X = PortalGetDouble("sx", 0)
                                    pt2S.Y = PortalGetDouble("sy", 0)
                                    pt2S.Z = PortalGetDouble("sz", 0)

                                    Pnt2E.X = PortalGetDouble("ex", 0)
                                    Pnt2E.Y = PortalGetDouble("ey", 0)
                                    Pnt2E.Z = PortalGetDouble("ez", 0)

                                    m_EntityID_2 = entityID

                                    'pt2EX = PortalGetDouble("ex", 0)
                                    'pt2EY = PortalGetDouble("ey", 0)
                                    'pt2EZ = PortalGetDouble("ez", 0)

                                    Dim Pnt3E As New Point3D
                                    Dim pt3S As New Point3D

                                    pt3S.X = PortalGetDouble("sx", 0)
                                    pt3S.Y = PortalGetDouble("sy", 0)
                                    pt3S.Z = PortalGetDouble("sz", 0)

                                    Pnt3E.X = PortalGetDouble("ex", 0)
                                    Pnt3E.Y = PortalGetDouble("ey", 0)
                                    Pnt3E.Z = PortalGetDouble("ez", 0)
                                    ' Get ready for the next set of points.

                                    m_EntityID_3 = entityID

                                    m_NextPoint = 1
                                End If


                                'If ((pntIndx - 2) Mod 2 = 0) Then

                                '    'objWriter.WriteLine("output the Point: ")

                                'End If

                            End If

                            pntIndx = pntIndx + 1

                            If m_NextPoint >= 3 Then

                                m_NextPoint = 1
                            End If

                        Next

                End Select
            Next
            MasterCheck = True
        Catch ex As Exception

            MessageBox.Show("MasterCheck < " & ex.Message & " >")

        End Try

    End Function

    Private Sub Junk()
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
        Dim d_Rad As Double = 0.25
        Dim entity_1 As Long
        Dim entity_2 As Long


        m_NextPoint = 1

        'Get the  count from the Selected Profile.
        'This    routine will only work on profilew
        cnt = modSelection.SelectedCount

        Try

            'Loop through each entity in the profile
            For indx = 0 To cnt - 1

                lSelectionID = modSelection.GetAt(indx)


                'Get the iiproperties of the entity
                lReturn = PortalExecute("*create:extract:id=" & lSelectionID)

                'Get the geometry type to make sure we are working with a profile
                lType = PortalGetInt("type", c_INVALID)


                dir = PortalGetInt("dir", 1)

                Select Case lType

                    Case c_DBPROFILE
                        'We have a Profile so we can continue.
                        'If (GetEntityType(lSelectionID) = c_DBPROFILE) Then

                        containerID = lSelectionID

                        'get the number of entities in th profile
                        lReturn = PortalExecute("*Entity:Container:Count:id=" & containerID)

                        'Loop through each entity within the profile.
                        Count = PortalGetInt("count", 0)

                        For indx2 = 0 To (Count - 1)

                            lReturn = PortalExecute("*Entity:Container:Get:" & " id=" & containerID & ",index=" & indx2)

                            entityID = PortalGetInt("id", 0)
                            lReturn = PortalExecute("*create:extract:id=" & entityID)
                            ProfEntType = PortalGetInt("type", c_INVALID)

                            'right no we are only dealing with lines, so we check the type
                            If (ProfEntType = c_DBLINE) Then

                                Select Case m_NextPoint
                                    Case 1
                                        ' extract data from entity

                                        entity_1 = entityID

                                        xs = PortalGetDouble("sx", 0.0#)
                                        ys = PortalGetDouble("sy", 0.0#)
                                        xe = PortalGetDouble("ex", 0.0#)
                                        ye = PortalGetDouble("ey", 0.0#)

                                        L1SX = xs.ToString
                                        L1SY = ys.ToString
                                        LS1Z = PortalGetDouble("sz", 0.0#)

                                        L2SX = xe.ToString
                                        L2SY = ye.ToString
                                        L2SZ = PortalGetDouble("ez", 0.0#)
                                        L2EX = xe
                                        L2EY = ye

                                        Me.ListBoxControl2.Items.Add("--------------------------")

                                        Me.ListBoxControl2.Items.Add(indx2 & "  XS = " & xs.ToString)
                                        Me.ListBoxControl2.Items.Add(indx2 & "  YS = " & ys.ToString)

                                        'objWriter.WriteLine("--------------------------")

                                        'objWriter.WriteLine(indx2 & "  XS = " & xe.ToString)
                                        'objWriter.WriteLine(indx2 & "  YS = " & ye.ToString)


                                        entity_2 = entityID

                                    Case 2

                                        ' extract data from entity
                                        xs = PortalGetDouble("sx", 0.0#)
                                        ys = PortalGetDouble("sy", 0.0#)
                                        xe = PortalGetDouble("ex", 0.0#)
                                        ye = PortalGetDouble("ey", 0.0#)

                                        L2SX = xe.ToString
                                        L2SY = ye.ToString
                                        L2SZ = PortalGetDouble("sz", 0.0#)

                                        Me.ListBoxControl2.Items.Add("--------------------------")

                                        Me.ListBoxControl2.Items.Add(indx2 & "XE = " & xe)
                                        Me.ListBoxControl2.Items.Add(indx2 & "YE = " & ye)

                                        'objWriter.WriteLine("--------------------------")

                                        'objWriter.WriteLine(indx2 & "XE = " & xe)
                                        'objWriter.WriteLine(indx2 & "YE = " & ye)

                                        crossProductExample(indx2)

                                    Case 3
                                        ' extract data from entity
                                        xs = PortalGetDouble("sx", 0.0#)
                                        ys = PortalGetDouble("sy", 0.0#)
                                        xe = PortalGetDouble("ex", 0.0#)
                                        ye = PortalGetDouble("ey", 0.0#)

                                        L3EX = xe.ToString
                                        L3EY = ye.ToString
                                        L3EZ = PortalGetDouble("sz", 0.0#)

                                        Me.ListBoxControl2.Items.Add("--------------------------")

                                        Me.ListBoxControl2.Items.Add(indx2 & "XS = " & xe.ToString)
                                        Me.ListBoxControl2.Items.Add(indx2 & "YS = " & ye.ToString)

                                        'objWriter.WriteLine("--------------------------")

                                        'objWriter.WriteLine(indx2 & "XE = " & xe.ToString)
                                        'objWriter.WriteLine(indx2 & "YE = " & ye.ToString)


                                        crossProductExample(indx2)

                                        'lReturn = PortalExecute(
                                        '            "Solve:Blend:" &
                                        '            " idA=" & entity_1 &
                                        '            ",idB =" & entity_2 &
                                        '            ",rad = " & d_Rad)

                                        'lReturn = PortalExecute("profile:blend: id1=135" &
                                        '                       ",end1=" &
                                        '                       ",x1=" &
                                        '                       ",y1=" &
                                        '                       ",id2=" &
                                        '                         ",end2=" &
                                        '                        ",x2=" &
                                        '                        ",y2=" &
                                        '                        ",cx = " &
                                        '                        ",cy =" &
                                        '                        ", dir =")

                                End Select

                                If m_NextPoint >= 3 Then

                                    m_NextPoint = 1

                                End If

                                'this should be the only time the +1 is called
                                m_NextPoint = m_NextPoint + 1

                            End If

                        Next

                        'End If

                End Select

            Next indx

        Catch ex As Exception

            MessageBox.Show("ProfileBlend_ItemClick < " & ex.Message & " >")

        End Try
    End Sub

    Private Sub sbMasterCheck_Click(sender As Object, e As EventArgs) Handles sbMasterCheck.Click
        Try
            cornerNum = cornerNum + 1

            Me.ListBoxControl1.Items.Clear()

            MasterCheck()

        Catch ex As Exception

            MessageBox.Show("sbMasterCheck_Click < " & ex.Message & " >")

        End Try
        'MasterCheck()

    End Sub

    Private Sub frmProfileBlend_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ListBoxControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxControl2.SelectedIndexChanged

    End Sub
End Class