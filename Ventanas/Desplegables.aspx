<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Desplegables.aspx.cs" Inherits="Ventanas.Desplegables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container margin-top">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row mt-3">
                    <div class="mb-3">
                        <h1>Administrar desplegable</h1>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblEncabezado" runat="server" CssClass="h3" />
                    </div>
                    <div class="mb-3">
                        <asp:GridView runat="server" ID="dgvDesplegable" DataKeyNames="Id" CssClass="table" OnSelectedIndexChanged="dgvDesplegable_SelectedIndexChanged"></asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <div class="mb-3">
                            <label class="form-label"></label>
                            <asp:TextBox runat="server" ID="tbxCampo" CssClass="form-control" />
                        </div>
                    </div>
                    <% if (campo == "Pue" || campo == "Loc")
                        { %>
                    <div class="col-lg-4 mt-4">
                        <div class="mb-3">
                            <asp:Label ID="lblDesplegable" CssClass="form-label" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlDesplegable" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>
                    <% } %>
                    <div class="col-lg-4 mt-4">
                        <div class="mb-3">
                            <% if (!modificar)
                                { %>
                            <asp:Button Text="Agregar" runat="server" CssClass="btn btn-success" ID="btnAgregar" OnClick="btnAgregar_Click" />
                            <% }
                                else
                                { %>
                            <asp:Button Text="Modificar" runat="server" CssClass="btn btn-primary" ID="btnModificar" OnClick="btnAgregar_Click"/>
                            <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" ID="btnEliminar" OnClick="btnAgregar_Click"/>
                            <% } %>
                            <a href="DefaultAdmin.aspx" class="btn btn-primary">Cancelar</a>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
