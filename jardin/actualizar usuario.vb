Imports System.Data.SqlClient
Public Class actualizar_usuario
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=(local);Initial Catalog=jardin;Integrated Security=True"
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Seleccione el usuario a actualizar")
        ElseIf password.Text.Length = 0 Then
            MsgBox("Ingrese la nueva contraseña")
        ElseIf ComboBox2.SelectedIndex = -1 Then
            MsgBox("Seleccione el estado del usuario")
        ElseIf password2.Text.Length = 0 Then
            MsgBox("Repita la contraseña")
        ElseIf password.Text = password2.Text Then

            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "UPDATE usuario SET password = @password, estado = @estado Where nombre = @nombre"
            myconnect.Open()

            Try
                mycommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = ComboBox1.SelectedItem.ToString
                mycommand.Parameters.Add("@estado", SqlDbType.NVarChar).Value = ComboBox2.SelectedItem.ToString
                mycommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = password.Text

                mycommand.ExecuteNonQuery()
                MsgBox("Usuario Actualizado")
                ComboBox1.SelectedIndex = -1
                ComboBox2.SelectedIndex = -1

                password.Text = ""
                password2.Text = ""
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        Else
            MsgBox("Las contraseñas no son iguales")
        End If



    End Sub

    Private Sub actualizar_usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()
            Llenar_Lista(ComboBox1, cnn)
            cnn.Close()

        End Using

    End Sub
    Sub Llenar_Lista(ByVal sender As ComboBox, ByVal cnn As SqlConnection)
        Try
            enunciado = New SqlCommand("Select nombre From usuario", cnn)
            respuesta = enunciado.ExecuteReader
            While respuesta.Read
                ComboBox1.Items.Add(respuesta.Item("nombre"))

            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        plataforma_administrador.Visible = True

    End Sub
End Class