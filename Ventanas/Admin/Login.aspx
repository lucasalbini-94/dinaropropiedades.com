<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ventanas.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Iniciar Sesión - Dinaro Propiedades</title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <link href="../css/login-admin.css" rel="stylesheet" />
</head>
<body>
    <%--FORMULARIO DE LIGIN DE ADMINISTRACIÓN--%>
    <form id="formLogin" runat="server">
        <div class="login-card">

            <%--Cabecera con Brand y Logo--%>
            <div class="login-header">
                <img src="../Images/ImgApp/logo-empresa.png" alt="Dinaro Propiedades" onerror="this.style.display='none'" />
                <span>PANEL DE ADMINISTRACIÓN</span>
            </div>

            <%--Cartel de Error si falla la autenticación--%>
            <asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="alert-danger">
                <i class="fas fa-exclamation-circle"></i>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </asp:Panel>

            <%--Campo Email--%>
            <div class="form-group">
                <label for="tbxEmail">Correo Electrónico</label>
                <div class="input-wrapper">
                    <i class="fas fa-envelope"></i>
                    <asp:TextBox ID="tbxEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="admin@dinaropropiedades.com"></asp:TextBox>
                </div>
            </div>

            <%--Campo Contraseña--%>
            <div class="form-group">
                <label for="tbxPass">Contraseña</label>
                <div class="input-wrapper">
                    <i class="fas fa-lock"></i>
                    <asp:TextBox ID="tbxPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="••••••••"></asp:TextBox>
                </div>
            </div>

            <%--Botón de Ingreso--%>
            <asp:Button Text="Ingresar al Panel" OnClick="btnIngresar_Click" ID="btnIngresar" runat="server" CssClass="btn-ingresar" />
            
            <div class="footer-text">
                &copy; <%= DateTime.Now.Year %> Dinaro Propiedades. Todos los derechos reservados.
            </div>
        </div>
    </form>
</body>
</html>
