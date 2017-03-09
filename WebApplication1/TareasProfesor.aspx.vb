Public Class TareasProfesor1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("username") = "vadillo@ehu.es" ''BORRAR!
    End Sub

End Class