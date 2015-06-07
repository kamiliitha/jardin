Public Class inventario
    Dim Sql As String
    Dim myconnect As New SqlClient.SqlConnection

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub inventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JardinDataSet.inventario' table. You can move, or remove it, as needed.
        Me.InventarioTableAdapter.Fill(Me.JardinDataSet.inventario)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        myconnect.ConnectionString = "Data Source=KAMILIITHA;Initial Catalog=jardin;Integrated Security=True"

        If implemento.Text = "" Or cantidad.Text = "" Then
            MessageBox.Show("INGRESE TODOS LOS DATOS")
        Else
            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            mycommand.Connection = myconnect
            mycommand.CommandText = "INSERT INTO inventario (nombre_implemento,cantidad,estado ) VALUES (@nombre_implemnto,@cantidad,'vigente')"
            myconnect.Open()

            Try

                mycommand.Parameters.Add("@nombre_implemento", SqlDbType.NVarChar).Value = implemento.Text
                mycommand.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = cantidad.Text
                mycommand.ExecuteNonQuery()
                MsgBox("inventario Ingresado")
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message)
            End Try
            myconnect.Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        plataforma_usuario.Show()
    End Sub
End Class