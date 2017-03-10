Imports System.Data.SqlClient
Imports accesoBD.GestBD

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Dim dapt As SqlDataAdapter
    Dim dst As DataSet
    Dim tbTareas As DataTable
    Dim tbAsig As DataTable
    Dim tbTareasAsig As DataTable
    Dim query As IEnumerable(Of DataRow) '' Hay que decirle de que tipo es si quiero poder copiar a datatable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Control Accesp
        'If Session("logged") = False Then
        '    Response.Redirect("Inicio.aspx?msj= Debes estar logueado para acceder")
        'End If
        'If Session("tipo") = "P" Then
        '    Response.Write("No Estas Autorizado para acceder a este reurso <a href='/Inicio.aspx'>Inicio</a>")
        '    Response.End()
        'End If
        If Not IsPostBack Then
            Session("username") = "pepe@ikasle.ehu.es" ''BORRAR!!!!
            '' Cargar Lista Asignaturas
            conectar()
            Dim st = "Select Asignaturas.codigo FROM ((Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig) INNER JOIN EstudiantesGrupo ON GruposClase.codigo=EstudiantesGrupo.grupo) INNER JOIN Usuarios ON EstudiantesGrupo.Email=Usuarios.email WHERE Usuarios.email='" & Session("username") & "'"
            dapt = New SqlDataAdapter(st, conexion)
            dst = New DataSet()
            dapt.Fill(dst, "Asignaturas") ''cargamos la tabla
            tbAsig = New DataTable()
            tbAsig = dst.Tables("Asignaturas")

            DropDownList1.DataSource = tbAsig
            DropDownList1.DataValueField = "codigo"
            DropDownList1.DataBind()

            DropDownList1.Items.Item(0).Selected = True ''Mostramos los datos de la primera asignatura al cargar

            ''Crear tabla con el grid
            ''dapt = New SqlDataAdapter("SELECT * FROM TareasGenericas WHERE CodAsig='" & DropDownList1.SelectedValue & "'", conexion)
            ''dapt = New SqlDataAdapter("SELECT * FROM TareasGenericas", conexion)
            dapt = New SqlDataAdapter("SELECT * FROM TareasGenericas where Explotacion='true' and Codigo not in (SELECT CodTarea FROM EstudiantesTareas WHERE Email='" & Session("username") & "')", conexion)
            dst = New DataSet()
            dapt.Fill(dst, "TareasGenericas") ''cargamos la tabla
            Session("ds") = dst ''guardamos el dataset para cuando recargue
            tbTareas = New DataTable()
            tbTareas = Session("ds").Tables("TareasGenericas")
            ''Consulta Linq to Dataset
            query = From tarea In tbTareas.AsEnumerable()
             Where tarea("codAsig") = DropDownList1.SelectedValue
             Select tarea
            If query.Count > 0 Then
                tbTareasAsig = query.CopyToDataTable() ''Solo con Ienumerable(of DataRow)
                GridView1.DataSource = tbTareasAsig
                GridView1.DataBind()
            Else
                LabelErrors.Text = "No Tienes tareas de esta Asignatura"
            End If
            cerrarConexion()

        Else

            tbTareas = Session("ds").Tables("TareasGenericas")
        End If
    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        query = From tarea In tbTareas.AsEnumerable()
        Where tarea("codAsig") = DropDownList1.SelectedValue
        Select tarea
        If query.Count > 0 Then
            LabelErrors.Text = ""
            tbTareasAsig = New DataTable()
            tbTareasAsig = query.CopyToDataTable() ''Solo con Ienumerable(of DataRow)
            Session("tbtemp") = tbTareasAsig.AsDataView
            GridView1.DataSource = tbTareasAsig
            GridView1.DataBind()
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            LabelErrors.Text = "No Tienes tareas de esta Asignatura"
        End If

        'opcion chuflons
        'conectar()
        'dapt = New SqlDataAdapter("SELECT * FROM TareasGenericas WHERE CodAsig='" & DropDownList1.SelectedValue & "'", conexion)
        'dst = New DataSet()
        'dapt.Fill(dst, "TareasGenericas") ''cargamos la tabla
        'tbTareas = New DataTable()
        'tbTareas = dst.Tables("TareasGenericas")
        'GridView1.DataSource = tbTareas
        'GridView1.DataBind()
        'cerrarConexion()
    End Sub

    
    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.Redirect("/Inicio.aspx?msj= Vuelve pronto :)")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        ' Dim row As GridViewRow = sender.Rows(e.CommandArgument) ''commandArgument devuelve el num de fila
        Dim x = GridView1.SelectedIndex + 1
        'LabelErrors.Text = tbTareas.Rows(x).Item(4)
        Response.Redirect("/InstanciarTarea.aspx?cod=" & tbTareas.Rows(x).Item(0) & "&h=" & tbTareas.Rows(x).Item(3) & "")

    End Sub
  

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting

        Dim vista = Session("tbtemp")
        vista.Sort = e.SortExpression    ''nombre de la columna y direction

        GridView1.DataSource = vista.ToTable 'tbTareas
        GridView1.DataBind()
    End Sub
  
End Class