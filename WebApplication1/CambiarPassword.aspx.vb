﻿Imports System.Data.SqlClient
Imports accesoBD.GestBD
Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        divCambiarPass.Visible = False
        divObtenerPregunta.Visible = False
        ''Buscar pregunta para el email recibido y mostrarla en textbox1
        conectar()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If comprobarRespuesta(TextBox2.Text) Then
            Literal1.Text = ""
            divCambiarPass.Visible = True
        Else
            Literal1.Text = "Respuesta Incorrecta"
        End If
    End Sub

    Public Function comprobarRespuesta(ByVal resp As String) As Boolean
        ''Comprobar si la respuesta es la correcta en la BD
        Dim existe As Integer
        Dim st = "SELECT count(*) FROM Usuarios WHERE email='" & TextBox5.Text & "' and respuesta='" & TextBox2.Text & "'"
        Dim comando = New SqlCommand(st, conexion)
        Try
            existe = comando.ExecuteScalar()
        Catch ex As Exception
            Literal1.Text = (ex.Message)
        End Try
        If existe > 0 Then
            Me.ViewState("username") = TextBox5.Text
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''Cambiar Password
        Dim newpass = TextBox3.Text
        Dim st = "UPDATE Usuarios set pass='" & TextBox3.Text & "' WHERE email='" & Me.ViewState("username") & "' and respuesta='" & TextBox2.Text & "'"
        MsgBox(st)
            Dim numregs As Integer
            Dim comando = New SqlCommand(st, conexion)
            Try
            numregs = comando.ExecuteNonQuery()

            Catch ex As Exception
                Literal1.Text = ex.Message
        End Try
        If (numregs > 0) Then
            Literal1.Text = "Has cambiado tu Contraseña con exito, apuntala bien!"
        Else
            Literal1.Text = "Comprueba los datos introducidos"
        End If

        cerrarConexion()

    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ''Obtener y rellenar Pregunta

        Dim resp
        Dim st = "SELECT * FROM Usuarios WHERE email='" & TextBox5.Text & "' "

        Dim comando = New SqlCommand(st, conexion)
        Try
            resp = comando.ExecuteReader()
        Catch ex As Exception
            Literal1.Text = (ex.Message)
        End Try
        If Not resp.Read() Then
            Literal1.Text = "No estas registrado con este email"
        Else

            Literal1.Text = ""
            TextBox1.Text = resp.Item("pregunta")
            divObtenerPregunta.Visible = True
        End If

        resp.dispose()
    End Sub
End Class