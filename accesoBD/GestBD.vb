Imports System.Data.SqlClient

Public Class GestBD
    '' Establecer y abrir una conexión a una BD Sql

    Public Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = "Data Source=158.227.106.20;Initial Catalog=HADS14_Usuarios;Persist Security Info=True;User ID=HADS14;Password=canguro"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN" + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Function cerrarConexion() As Boolean
        conexion.Close()
    End Function


End Class
