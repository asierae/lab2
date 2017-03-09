<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="WebApplication1.TareasProfesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tareas Profesor</title>
</head>
        <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
		<script src="js/jquery-3.1.1.min.js"></script>
<body>


    <form id="form1" runat="server">
     <div class="container">
    <div class="row">
        <div class="col-md-3">
            <ul class="nav nav-pills nav-stacked">
                <li class="active"><a href="#"><i class="fa fa-home fa-fw"></i>Home</a></li>
                <li>
                    <asp:LinkButton ID="LinkButton1" CssClass="fa fa-list-alt fa-fw" runat="server">Asignaturas</asp:LinkButton>
                </li>
                <li><a href="#"><i class="fa fa-file-o fa-fw"></i>Tareas</a></li>
                <li><a href="#"><i class="fa fa-bar-chart-o fa-fw"></i>Grupos</a></li>
                <li><a href="#"><i class="fa fa-table fa-fw"></i>Estadisticas</a></li>
                <li><a href="#"><i class="fa fa-tasks fa-fw"></i>Alumnos</a></li>
                <li><a href="#"><i class="fa fa-calendar fa-fw"></i>Importar</a></li>
                <li><a href="#"><i class="fa fa-book fa-fw"></i>Exportar</a></li>
                <li><a href="#"><i class="fa fa-pencil fa-fw"></i>Nuevo</a></li>
                <li><a href="#"><i class="fa fa-cogs fa-fw"></i>Settings</a></li>
            </ul>
        </div>
        <div id="contenido" class="col-md-9 well">
            Bienvenido Session("username")
        </div>
    </div>
    </form>
</body>
</html>
