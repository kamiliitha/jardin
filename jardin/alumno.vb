Public Class alumno
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        plataforma_usuario.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=KAMILIITHA;Initial Catalog=jardin;Integrated Security=True"

        If rut.Text = "" Or nombres.Text = "" Or apellidos.Text = "" Or direccion.Text = "" Or telefono.Text = "" Or alergia.Text = "" Then
            MessageBox.Show("INGRESE TODOS LOS DATOS")


        Else





            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "INSERT INTO alumno (rut, nombre, apellido, direccion, telefono, tipo_alergia, estado ) VALUES (@rut,@nombre, @apellido,@direccion,@telefono,@tipo_alergia,'vigente')"
            myconnect.Open()

            Try

                mycommand.Parameters.Add("@rut", SqlDbType.NVarChar).Value = rut.Text
                mycommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombres.Text
                mycommand.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellidos.Text()
                mycommand.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion.Text
                mycommand.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = telefono.Text
                mycommand.Parameters.Add("@tipo_alergia", SqlDbType.NVarChar).Value = alergia.Text

                mycommand.ExecuteNonQuery()
                MsgBox("alumno Ingresado")
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If

    End Sub
End Class