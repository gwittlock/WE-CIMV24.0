Imports System.IO

Public Class XtraForm5
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim stempfilename As System.IO.StreamWriter
        Dim s_CsvFile As String = "C:\Program Files (x86)\WE-CIM\23.0\Report Templates\EntityList.csv"
        Dim s_ClassFile As String = "C:\Program Files (x86)\WE-CIM\23.0\Report Templates\EntityList.results"
        Dim sData As String

        stempfilename = My.Computer.FileSystem.OpenTextFileWriter(s_ClassFile, True)


        Using SR As StreamReader = New StreamReader(s_CsvFile)

            While (SR.EndOfStream = False)

                sData = SR.ReadLine()

                stempfilename.WriteLine(“Public Property “ & sData & “ As Decimal”)
                stempfilename.WriteLine(“        Get”)
                stempfilename.WriteLine(“            Return _” & sData)
                stempfilename.WriteLine(“        End Get”)
                stempfilename.WriteLine(“        Set(value As Decimal)”)
                stempfilename.WriteLine(“            _” & sData & “ = value”)
                stempfilename.WriteLine("        End Set”)
                stempfilename.WriteLine(“    End Property”)
                stempfilename.WriteLine(" ")


                'sw.WriteLine("Private " & "_" & sData & " As Decimal")
                'stempfilename.WriteLine("Private " & "_" & sData & " As Decimal")

            End While

        End Using

        stempfilename.Close()

    End Sub
End Class