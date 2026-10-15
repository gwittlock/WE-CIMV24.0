


Public Class Select_Mach_Tool_Mat
    Private m_context As CREATE_TABLE_MODE
    Dim machineID As Integer
    Dim ToolSetupID As Integer
    Dim materialID As Integer
    Dim layersetupID As Long

    Private Sub Select_Mach_Tool_Mat_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Select Case m_context

            Case CREATE_TABLE_MODE.MACHINE_MODE
                lcTitle.Text = "You Must Select A Machine Setup!"
                lcInputTitle.Text = "Machine Setup:"

                modProject.InitMachineList(cbDropDown, machineID)

                Me.Refresh()
                'Case CREATE_TABLE_MODE.TOOL_MODE

                'Case CREATE_TABLE_MODE.TOOLSETUP_MODE
                '    lcTitle.Text = "You Must Select A Tool Setup!"
                'Case CREATE_TABLE_MODE.LAYER_MODE
                '    lcTitle.Text = "You Must Select A Layer Setup!"
                'Case CREATE_TABLE_MODE.MATERIAL_MODE
                '    lcTitle.Text = "You Must Select A Material Setup!"

        End Select

    End Sub
    Public Sub Init(context As CREATE_TABLE_MODE)

        m_context = context



    End Sub

    Private Sub sbOk_Click(sender As Object, e As EventArgs) Handles sbOk.Click
        Select Case m_context

            Case CREATE_TABLE_MODE.MACHINE_MODE

                machineID = GetMachineIDFromDescrip(cbDropDown.Text)
                modProject.SetMachine((cbDropDown.Text), machineID)



                'Case CREATE_TABLE_MODE.TOOL_MODE

                'Case CREATE_TABLE_MODE.TOOLSETUP_MODE
                '    lcTitle.Text = "You Must Select A Tool Setup!"
                'Case CREATE_TABLE_MODE.LAYER_MODE
                '    lcTitle.Text = "You Must Select A Layer Setup!"
                'Case CREATE_TABLE_MODE.MATERIAL_MODE
                '    lcTitle.Text = "You Must Select A Material Setup!"

        End Select
    End Sub
End Class