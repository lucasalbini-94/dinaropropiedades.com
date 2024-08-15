<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ErrorAdmin.aspx.cs" Inherits="Ventanas.ErrorAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top mb-5">
        <%--<img src="/Images/ImgApp/imgError.png" width="300px" height="200px" alt="Alternate Text" class="text-center card-img"/>--%>
    </div>
    <div class="row">
        <h1 class="text-center mt-5">¡Ha ocurrido un error inesperado!</h1>
        <p><%:error %></p>
    </div>
</asp:Content>
