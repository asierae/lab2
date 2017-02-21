<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="true" CodeBehind="Inicio.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido</title>
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
		<script src="js/jquery-3.1.1.min.js"></script>
    </head>
<body>
    <form id="form1" runat="server" enableviewstate="true">
    <div style="margin-left: 40px; height: 445px; width: 679px;">
    
        <h1>Login</h1>
        <p>&nbsp;</p>
&nbsp;<h5><strong>Email:&nbsp;</strong><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="250px" placeholder="Tu email" BorderColor="#99CCFF" ViewStateMode="Enabled"></asp:TextBox>
        </h5>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Introduce un email" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Introduce un Email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        &nbsp;<h5><strong>Password</strong><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"  Width="250px" placeholder="password" BorderColor="#99CCFF" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Introduce un Password" ForeColor="Red"></asp:RequiredFieldValidator>
        </h5>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="Entrar" Width="114px" Height="48px" ViewStateMode="Enabled" />
    
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False">Registrar</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False">Cambiar Password</asp:LinkButton>
       
        <br />
        <br />
        </div>
    </form>
</body>
</html>
