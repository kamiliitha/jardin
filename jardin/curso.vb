Imports System.Data.SqlClient
Public Class curso
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        plataforma_usuario.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        myconnect.ConnectionString = "Data Source=KAMILIITHA;Initial Catalog=jardin;Integrated Security=True"
        myconnect.ConnectionString = "Data Source=(local);Initial Catalog=jardin;Integrated Security=True"

        If nivel1.Text = "" Or cupoi.Text = "" Or cupoa.Text = "" Or horarioc.Text = "" Or horarios.Text = "" Or invent.Text = "" Or ComboBox2.SelectedIndex = -1 Or rutdocente.Text = "" Then
            MessageBox.Show("INGRESE TODOS LOS DATOS")


        Else

            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "INSERT INTO curso (tipo_nivel, cantidad_cupo_inicial,cantida_cupo_actual, horario_comida,horario_siesta,inventario_idinventario, alumno_rut, docente_rut, estado ) VALUES (@tipo_nivel, @cantidad_cupo_inicial,@cantida_cupo_actual, @horario_comida,@horario_siesta,@inventario_idinventario, @alumno_rut, @docente_rut,'vigente')"
            myconnect.Open()

            Try

                mycommand.Parameters.Add("@tipo_nivel", SqlDbType.NVarChar).Value = nivel1.Text
                mycommand.Parameters.Add("@cantida_cupo_inicial", SqlDbType.NVarChar).Value = cupoi.Text
                mycommand.Parameters.Add("@cantidad_cupo_actual", SqlDbType.NVarChar).Value = cupoa.Text
                mycommand.Parameters.Add("@horario_comida", SqlDbType.NVarChar).Value = horarioc.Text
                mycommand.Parameters.Add("@horario_siesta", SqlDbType.NVarChar).Value = horarios.Text
                mycommand.Parameters.Add("@inventario_idinventario", SqlDbType.NVarChar).Value = invent.Text
                mycommand.Parameters.Add("@alumno_rut", SqlDbType.NVarChar).Value = ComboBox2.SelectedIndex = -1
                mycommand.Parameters.Add("@docente_rut", SqlDbType.NVarChar).Value = rutdocente.Text


                mycommand.ExecuteNonQuery()
                MsgBox("Curso Ingresado")
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If
        nivel1.Text = ""
        cupoi.Text = ""
        cupoa.Text = ""
        horarioc.Text = ""
        horarios.Text = ""
        invent.Text = ""
        ComboBox2.SelectedIndex = -1
        rutdocente.Text = ""
    End Sub

    Private Sub curso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()
            Llenar_Lista(ComboBox2, cnn)
            cnn.Close()

        End Using

    End Sub
    Sub Llenar_Lista(ByVal sender As ComboBox, ByVal cnn As SqlConnection)
        Try
            enunciado = New SqlCommand("Select rut From alumno", cnn)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read
                ComboBox2.Items.Add(respuesta.Item("rut"))

            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
  
End Class