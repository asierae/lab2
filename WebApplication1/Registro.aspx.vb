Imports accesoBD.GestBD
Imports System.Data.SqlClient


Public Class Registro

    Inherits System.Web.UI.Page
    Public host As String = "http://localhost"
    Public Shared conn As accesoBD.GestBD
    Private Shared comando As New SqlCommand
    Public key As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' MsgBox(conectar())


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
        If Page.IsValid Then
            conectar()
            Dim key = RandomKey()
            url_activar = host + "/Confirmar.aspx?mbr=" + TextBox1.Text + "&numconf=" + key.ToString
            emailer.enviarEmail(TextBox1.Text, "Email de Bienvenida", "Bienvenido! Activa tu cuenta desde la siguiente dirección:" + url_activar)
            registrar()
        End If

    End Sub

    Public Function registrar() As String
        Dim array = TextBox2.Text.Split()
        Dim apellidos = array.GetValue(1) & " " & array.GetValue(2)
        apellidos = "segundo"
        Dim st = "insert into Usuarios (email,nombre,apellidos,pregunta,respuesta,dni,numconfir,confirmado,pass) values(" & TextBox1.Text & "," & array.GetValue(0) & "," & apellidos & "," & TextBox6.Text & "," & TextBox7.Text & "," & TextBox3.Text & "," & key & "," & False & "," & TextBox4.Text & ")"
        Dim numregs As Integer
        comando = New SqlCommand(st, accesoBD.GestBD.conexion)
        Try
            numregs =comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox(numregs & " registro(s) insertado(s) en la BD ")
    End Function

End Class