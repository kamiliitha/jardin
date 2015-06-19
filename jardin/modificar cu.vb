Imports System.Data.SqlClient
Public Class modificar_cu
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        plataforma_usuario.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=(local);Initial Catalog=jardin;Integrated Security=True"
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Seleccione el cupo curso a modificar")
        ElseIf cupoi.Text.Length = 0 Then
            MsgBox("Ingrese el cupo inicial ")
        ElseIf ComboBox2.SelectedIndex = -1 Then
            MsgBox("Seleccione el estado del usuario")
        ElseIf cupoa.Text.Length = 0 Then
            MsgBox("ingrese el cupo actual")


            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "UPDATE curso SET cantidad_cupo_inicial = @cantidad_cupo_inicial, cantidad_cupo_actual = @cantidad_cupo_actual, estado = @estado Where tipo_nivel = @tipo_nivel"
            myconnect.Open()

            Try
                mycommand.Parameters.Add("@tipo_nivel", SqlDbType.NVarChar).Value = ComboBox1.SelectedItem.ToString
                mycommand.Parameters.Add("@estado", SqlDbType.NVarChar).Value = ComboBox1.SelectedItem.ToString
                mycommand.Parameters.Add("@cantidad_cupo_inicial", SqlDbType.NVarChar).Value = cupoi.Text
                mycommand.Parameters.Add("@cantidad_cupo_actual", SqlDbType.NVarChar).Value = cupoa.Text


                mycommand.ExecuteNonQuery()
                MsgBox("Cupo curso Actualizado")
                ComboBox1.SelectedIndex = -1
                ComboBox2.SelectedIndex = -1


            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If
        cupoi.Text = ""
        cupoa.Text = ""


    End Sub

    Private Sub modificar_cu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()
            Llenar_Lista(ComboBox1, cnn)
            cnn.Close()

        End Using
    End Sub
    Sub Llenar_Lista(ByVal sender As ComboBox, ByVal cnn As SqlConnection)
        Try
            enunciado = New SqlCommand("Select tipo_nivel From curso", cnn)
            respuesta = enunciado.ExecuteReader
            While respuesta.Read()
                ComboBox1.Items.Add(respuesta.Item("tipo_nivel"))

            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class