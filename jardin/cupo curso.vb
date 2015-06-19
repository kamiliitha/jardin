Imports System.Data.SqlClient
Public Class cupo_curso
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        plataforma_usuario.Show()

    End Sub

    Private Sub cupo_curso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JardinDataSet.curso' table. You can move, or remove it, as needed.
        Me.CursoTableAdapter.Fill(Me.JardinDataSet.curso)
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()
            Llenar_Lista(cupocurso, cnn)
            cnn.Close()

        End Using
    End Sub
    Sub Llenar_Lista(ByVal sender As ComboBox, ByVal cnn As SqlConnection)
        Try
            enunciado = New SqlCommand("Select tipo_nivel From curso", cnn)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read
                cupocurso.Items.Add(respuesta.Item("tipo_nivel"))

            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        myconnect.ConnectionString = "Data Source=KAMILIITHA;Initial Catalog=jardin;Integrated Security=True"
        myconnect.ConnectionString = "Data Source=(local);Initial Catalog=jardin;Integrated Security=True"
        If cupoi.Text = "" Or cupoa.Text = "" Or cupocurso.SelectedIndex = -1 Then
            MessageBox.Show("INGRESE TODOS LOS DATOS")
        Else
            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "INSERT INTO curso (tipo_nivel, cantidad_cupo_inicial, cantidad_cupo_actual, estado ) VALUES (@tipo_nivel, @cantidad_cupo_inicial,@cantidad_cupo_actual,'vigente')"
            myconnect.Open()

            Try
                mycommand.Parameters.Add("@tipo_nivel", SqlDbType.NVarChar).Value = cupocurso.SelectedIndex = -1
                mycommand.Parameters.Add("@cantidad_cupo_inicial", SqlDbType.NVarChar).Value = cupoi.Text
                mycommand.Parameters.Add("@cantidad_cupo_actual", SqlDbType.NVarChar).Value = cupoa.Text

                mycommand.ExecuteNonQuery()
                MsgBox("Cupo curso Ingresado")
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If
        cupoi.Text = ""
        cupoa.Text = ""
        cupocurso.SelectedIndex = -1
    End Sub
End Class