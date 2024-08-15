<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ErrorUser.aspx.cs" Inherits="Ventanas.ErrorUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1 class="text-center mt-5 pt-5">¡Ha ocurrido un error inesperado!</h1>
        <asp:Label ID="lblError" runat="server" />
    </div>
</asp:Content>
