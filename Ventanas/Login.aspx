<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ventanas.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center container margin-top">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="mb-3 col-lg-6">
                <h1 class="mb-5 text-center">Ingresar</h1>
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="tbxPass" TextMode="Password" runat="server" class="form-control mb-3" />
                <asp:Button text="Ingresar" OnClick="btnIngresar_Click" ID="btnIngresar" runat="server" CssClass="mb-3 btn btn-primary"/>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"/>
            </div>
            <div class="col-lg-3"></div>
        </div>
    </div>
</asp:Content>
