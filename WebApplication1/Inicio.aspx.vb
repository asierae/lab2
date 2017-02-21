Imports accesoBD.GestBD
Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsNothing(Request.Params("msj")) Then
            Label1.Text = Request.Params("msj")
        End If
        If Page.IsPostBack Then

        End If
    End Sub




    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        conectar()
        Dim existe As Integer
        Dim st = "SELECT count(*) FROM Usuarios WHERE email='" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'"
        Dim comando = New SqlCommand(st, conexion)
        Try
            existe = comando.ExecuteScalar()
        Catch ex As Exception
            Label1.Text = (ex.Message)
        End Try
        If existe > 0 Then
            Session("username") = TextBox1.Text
            Session("logged") = True
            Response.Redirect("/Home.aspx")
        Else
            Literal1.Text = "<span style=""color: red;"">Credenciales Incorrectas </span>"
        End If
        cerrarConexion()

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("/Registro.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Response.Redirect("/CambiarPassword.aspx")
    End Sub
End Class