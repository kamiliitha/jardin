Imports System.Data.SqlClient
Public Class Form1

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using cnn As New SqlConnection("Data Source=(local);Initial Catalog=jardin;Integrated Security=True")
            cnn.Open()

            Dim consulta As String = "Select password From usuario where nombre=@Nombre"
            Dim cmd As New SqlCommand(consulta, cnn)
            Dim nombre As String = "admin"
            Dim clave As String = "admin"
            cmd.Parameters.AddWithValue("@Nombre", usuario.Text)
            If usuario.Text = "" Or pass.Text = "" Then
                MsgBox("Faltan datos necesarios", MsgBoxStyle.Critical, "Error Login")
            Else
                If usuario.Text = nombre And pass.Text = clave Then
                    Me.Visible = False
                    plataforma_administrador.Visible = True
                Else
                    Dim Password As String = cmd.ExecuteScalar()
                    If Password = pass.Text Then
                        Me.Visible = False
                        plataforma_usuario.Visible = True
                    Else
                        MsgBox("Error de credenciales", MsgBoxStyle.Critical, "Error Login")
                    End If
                End If

            End If
        End Using
        'comentarios 
    End Sub
End Class
