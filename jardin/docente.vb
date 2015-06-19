Public Class docente
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=KAMILIITHA;Initial Catalog=jardin;Integrated Security=True"

        If rut.Text = "" Or nombre.Text = "" Or apellido.Text = "" Then
            MessageBox.Show("INGRESE TODOS LOS DATOS")
        Else





            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "INSERT INTO docente (rut, nombre, apellido, estado ) VALUES (@rut,@nombre, @apellido,'vigente')"
            myconnect.Open()

            Try

                mycommand.Parameters.Add("@rut", SqlDbType.NVarChar).Value = rut.Text
                mycommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre.Text
                mycommand.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido.Text
                mycommand.ExecuteNonQuery()
                MsgBox("docente Ingresado")
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If
        rut.Text = ""
        nombre.Text = ""
        apellido.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        plataforma_usuario.Show()
    End Sub
End Class