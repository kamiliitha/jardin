Imports System.Data.SqlClient
Public Class eliminar_cu
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=(local);Initial Catalog=jardin;Integrated Security=True"
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Seleccione el cupo del curso a eliminar")

        Else
            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "UPDATE curso SET estado = 'novigente' Where cantidad_inicial = @cantidad_inicial"
            myconnect.Open()

            Try
                mycommand.Parameters.Add("@cantidad_inicial", SqlDbType.NVarChar).Value = ComboBox1.SelectedItem.ToString

                mycommand.ExecuteNonQuery()
                MsgBox("Cupo curso Eliminado")
                ComboBox1.Items.Clear()

                Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
                    cnn.Open()
                    Llenar_Lista(ComboBox1, cnn)
                    cnn.Close()

                End Using
                ComboBox1.SelectedIndex = -1
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()

        End If
    End Sub

    Private Sub eliminar_cu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()
            Llenar_Lista(ComboBox1, cnn)
            cnn.Close()

        End Using
    End Sub
    Sub Llenar_Lista(ByVal sender As ComboBox, ByVal cnn As SqlConnection)
        Try
            enunciado = New SqlCommand("Select cantidad_inicial From curso where estado = 'vigente' ", cnn)
            respuesta = enunciado.ExecuteReader
            While respuesta.Read
                ComboBox1.Items.Add(respuesta.Item("cantidad_inicial"))

            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        plataforma_usuario.Show()
    End Sub
End Class