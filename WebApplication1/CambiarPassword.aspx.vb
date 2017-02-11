Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        divCambiarPass.Visible = False
        ''Buscar pregunta para el email recibido y mostrarla en textbox1
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If comprobarRespuesta(TextBox2.Text) Then
            divCambiarPass.Visible = True

        End If
    End Sub

    Public Function comprobarRespuesta(ByVal resp As String) As Boolean
        ''Comprobar si la respuesta es la correcta en la BD
        Return True
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''Cambiar Password
        Dim newpass = TextBox3.Text

    End Sub
End Class