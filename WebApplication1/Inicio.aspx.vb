Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "prueba@prueba.com" And TextBox2.Text = "prueba" Then
            Response.Redirect("http://miazure.cuandoeste/Home.aspx")
        Else
            Literal1.Text = "<span style=""color: red;"">Credenciales Incorrectas </span>"
        End If

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("Registrar.aspx")
    End Sub
End Class