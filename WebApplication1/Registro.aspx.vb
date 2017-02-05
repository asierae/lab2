Public Class Registro
    Inherits System.Web.UI.Page
    Public host As String = "http://localhost"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function RandomKey() As Integer
        Dim NumConf As Decimal
        Randomize()
        NumConf = CLng(Rnd() * 9000000) + 1000000
        Return NumConf
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim emailer As New Email.Email
        Dim url_activar As String

        url_activar = host + "/Confirmar.aspx?mbr=" + TextBox1.Text + "&numconf=" + RandomKey().ToString
        emailer.enviarEmail("asierpaz@gmail.com", "Email de Bienvenida", "Bienvenido! Activa tu cuenta desde la siguiente dirección:" + url_activar)

    End Sub
End Class