Public Class comida
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        plataforma_usuario.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myconnect.ConnectionString = "Data Source=KAMILIITHA;Initial Catalog=jardin;Integrated Security=True"

        If comidapreparada.Text = "" Or fechaingreso.Text = "" Or profesoracargo.Text = "" Or horariocomida.Text = "" Then
            MessageBox.Show("INGRESE TODOS LOS DATOS")
        Else
            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "INSERT INTO comida (comida_preparada, fecha_ingreso, docente_acargo,horario_comida, estado ) VALUES (@comida_preparada,@fecha_ingreso, @docente_acargo,@horario_comida,'vigente')"
            myconnect.Open()

            Try

                mycommand.Parameters.Add("@comida_preparada", SqlDbType.NVarChar).Value = comidapreparada.Text
                mycommand.Parameters.Add("@fecha_ingreso", SqlDbType.NVarChar).Value = fechaingreso.Text
                mycommand.Parameters.Add("@docente_acargo", SqlDbType.NVarChar).Value = profesoracargo.Text
                mycommand.Parameters.Add("@horario_comida", SqlDbType.NVarChar).Value = horariocomida.Text
                mycommand.ExecuteNonQuery()
                MsgBox("comida Ingresado")
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If
    End Sub

    Private Sub comida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JardinDataSet.comida_has_curso' table. You can move, or remove it, as needed.
        Me.Comida_has_cursoTableAdapter.Fill(Me.JardinDataSet.comida_has_curso)

    End Sub
End Class