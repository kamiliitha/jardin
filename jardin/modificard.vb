Imports System.Data.SqlClient
Public Class modificard
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=(local);Initial Catalog=jardin;Integrated Security=True"

        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Seleccione el docente a actualizar")
        ElseIf curso.Text.Length = 0 Then
            MsgBox("Ingrese el nuevo curso")
        ElseIf ComboBox2.SelectedIndex = -1 Then
            MsgBox("Seleccione el estado del usuario")

            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "UPDATE docente SET curso = @curso, estado = @estado Where rut = @rut"
            myconnect.Open()

            Try
                mycommand.Parameters.Add("@rut", SqlDbType.NVarChar).Value = ComboBox1.SelectedItem.ToString
                mycommand.Parameters.Add("@estado", SqlDbType.NVarChar).Value = ComboBox2.SelectedItem.ToString
                mycommand.Parameters.Add("@curso", SqlDbType.NVarChar).Value = curso.Text

                mycommand.ExecuteNonQuery()
                MsgBox("Docente Actualizado")
                ComboBox1.SelectedIndex = -1
                ComboBox2.SelectedIndex = -1

                
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
       
        End If
    End Sub

    Private Sub modificard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()
            Llenar_Lista(ComboBox1, cnn)
            cnn.Close()

        End Using

    End Sub
    Sub Llenar_Lista(ByVal sender As ComboBox, ByVal cnn As SqlConnection)
        Try
            enunciado = New SqlCommand("Select rut From docente", cnn)
            respuesta = enunciado.ExecuteReader
            While respuesta.Read
                ComboBox1.Items.Add(respuesta.Item("rut"))

            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        plataforma_usuario.Visible = True
    End Sub
End Class