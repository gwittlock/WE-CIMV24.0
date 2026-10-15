Public Class frmFlowchart
    Dim nInitMode As Long

    Public Sub FlowChartInitMode(nRegOrHeader As Long)

        nInitMode = nRegOrHeader

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        'we use Convert.ToInt64() to maintain legacy data in the dll's which use 0 and 1 for false true
        RegPutString("CodeGeneration", "AllHolesFirst", Convert.ToInt64(chkAllHolesFirst.Checked))
        RegPutString("CodeGeneration", "HolesByToolOrder", Convert.ToInt64(chkHolesByToolOrder.Checked))

        If (chkByRecursion.Checked = True And chkByCompletePart.Checked = True) Then
            RegPutString("CodeGeneration", "ByCompletePart", "2")
        Else
            RegPutString("CodeGeneration", "ByCompletePart", Convert.ToInt64(chkByCompletePart.Checked))
        End If

        RegPutString("CodeGeneration", "ByRecursion", Convert.ToInt64(chkByRecursion.Checked))
        RegPutString("CodeGeneration", "HolesAcrossLocalNest", Convert.ToInt64(chkHolesAcrossLocalNest.Checked))

        Me.Dispose()



    End Sub

    '    Private Sub frmFlowchart_Leave(sender As Object, e As EventArgs) Handles Me.Leave
    '        Me.Dispose()
    '
    '    End Sub

    Private Sub frmFlowchart_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim nAllHolesFirst As Long
        Dim nHolesByToolOrder As Long
        Dim nByCompletePart As Long
        Dim nHolesAcrossLocalNest As Long

        Try

            If nInitMode = 0 Then
                chkAllHolesFirst.Checked = IIf(RegGetString("CodeGeneration", "AllHolesFirst", "0") = 1, True, False)
                chkHolesByToolOrder.Checked = IIf(RegGetString("CodeGeneration", "HolesByToolOrder", "0") = 1, True, False)
                'if nByCompletePart = 0 Then By Complete Part is off as well
                'as Interior to Exterior and Holes across local nest

                'if nByCompletePart = 1 or 2 Then By Complete Part is ON.
                'and interior to Exterior as well as Holes across local nest should be set
                'appropreately from the header

                chkByRecursion.Checked = False
                chkHolesAcrossLocalNest.Checked = False

                nByCompletePart = Convert.ToInt64(RegGetString("CodeGeneration", "ByCompletePart", "0"))

                If (nByCompletePart = 1 Or nByCompletePart = 2) Then
                    chkByCompletePart.Checked = True

                    'Set the By Recursion CheckBox in the Process Flowchart dialog
                    If (nByCompletePart = 2) Then
                        chkByRecursion.Checked = True
                    Else
                        chkByRecursion.Checked = False
                    End If

                    chkHolesAcrossLocalNest.Checked = IIf(RegGetString("CodeGeneration", "HolesAcrossLocalNest", "0") = 1, True, False)
                End If

            Else
                'Set the All Holes First CheckBox in the Process Flowchart dialog
                nAllHolesFirst = HeaderIntGet("AllHolesFirst", 1)
                chkAllHolesFirst.Checked = nAllHolesFirst

                'Set the Holes By Tool Order CheckBox in the Process Flowchart dialog
                nHolesByToolOrder = HeaderIntGet("HolesByToolOrder", 1)
                chkHolesByToolOrder.Checked = nHolesByToolOrder

                'Set the By Complete Part CheckBox in the Process Flowchart dialog
                nByCompletePart = HeaderIntGet("ByCompletePart", 2)

                'set the defaults for the flowchart check boxes
                chkByCompletePart.Checked = False
                chkByRecursion.Checked = False
                chkHolesAcrossLocalNest.Checked = False

                'if nByCompletePart = 0 Then By Complete Part is off as well
                'as Interior to Exterior and Holes across local nest

                'if nByCompletePart = 1 or 2 Then By Complete Part is ON.
                'and interior to Exterior as well as Holes across local nest should be set
                'appropriately from the header

                If (nByCompletePart = 1 Or nByCompletePart = 2) Then

                    chkByCompletePart.Checked = True

                    'Set the By Recursion CheckBox in the Process Flowchart dialog
                    If (nByCompletePart = 2) Then
                        chkByRecursion.Checked = True
                    End If

                    'Set the Holes Across Local Nest CheckBox in the Process Flowchart dialog
                    nHolesAcrossLocalNest = HeaderIntGet("HolesAcrossLocalNest", 0)
                    chkHolesAcrossLocalNest.Checked = nHolesAcrossLocalNest

                End If
            End If

            If (chkByCompletePart.Checked = True) Then
                chkByRecursion.Enabled = True
                chkHolesAcrossLocalNest.Enabled = True
            Else
                chkByRecursion.Checked = False
                chkByRecursion.Enabled = False
                chkHolesAcrossLocalNest.Checked = False
                chkHolesAcrossLocalNest.Enabled = False
            End If
            If (chkAllHolesFirst.Checked = True) Then
                chkHolesByToolOrder.Enabled = True
            Else
                chkHolesByToolOrder.Checked = False
                chkHolesByToolOrder.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkAllHolesFirst_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAllHolesFirst.CheckStateChanged
        If (chkByCompletePart.Checked = True) Then
            chkByRecursion.Enabled = True
            chkHolesAcrossLocalNest.Enabled = True
        Else
            chkByRecursion.Checked = False
            chkByRecursion.Enabled = False
            chkHolesAcrossLocalNest.Checked = False
            chkHolesAcrossLocalNest.Enabled = False
        End If
    End Sub

    Private Sub chkByCompletePart_CheckStateChanged(sender As Object, e As EventArgs) Handles chkByCompletePart.CheckStateChanged
        If (chkByCompletePart.Checked = True) Then
            chkByRecursion.Enabled = True
            chkHolesAcrossLocalNest.Enabled = True
        Else
            chkByRecursion.Checked = False
            chkByRecursion.Enabled = False
            chkHolesAcrossLocalNest.Checked = False
            chkHolesAcrossLocalNest.Enabled = False
        End If
    End Sub

    Private Sub chkAllHolesFirst_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllHolesFirst.CheckedChanged
        chkHolesByToolOrder.Enabled = chkAllHolesFirst.CheckState
    End Sub
End Class