Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        divCambiarPass.Visible = False
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If comprobarRespuesta(TextBox2.Text) Then
            divCambiarPass.Visible = True

        End If
    End Sub

    Public Function comprobarRespuesta(ByVal resp As String) As Boolean

        Return True
    End Function
End Class