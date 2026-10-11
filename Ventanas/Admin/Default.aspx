<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
      <h2>Panel de Control</h2>
      <div class="cards-grid">
        <div class="card"><i class="fas fa-home"></i><div><h3>24</h3><p>Activos</p></div></div>
        <div class="card"><i class="fas fa-tag"></i><div><h3>8</h3><p>Vendidos</p></div></div>
        <div class="card"><i class="fas fa-star"></i><div><h3>5</h3><p>Destacados</p></div></div>
      </div>
    </main>
</asp:Content>
