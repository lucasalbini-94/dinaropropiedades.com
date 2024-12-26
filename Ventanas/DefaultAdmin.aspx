<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DefaultAdmin.aspx.cs" Inherits="Ventanas.DafaultAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top container">
        <h1 class="mt-4">Propiedades</h1>
        <ol class="breadcrumb mb-4">
            <li class="breadcrumb-item">Panel</li>
            <li class="breadcrumb-item active">Propiedades</li>
        </ol>
        <div class="row pt-3 mb-3">
            <div class="col-lg-8 d-flex">
                <asp:TextBox runat="server" CssClass="form-control me-3" ID="tbxBuscar" />
                <asp:Button CssClass="btn btn-primary mt-1" Text="Buscar" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" />
            </div>
        </div>

        <asp:ListView runat="server" ID="TableListView" ItemPlaceholderID="itemPlaceHolder" OnItemCommand="TableListView_ItemCommand">
            <LayoutTemplate>
                <table id="ListViewTable" class="table table-bordered">
                    <thead>
                        <tr>
                            <th scope="col">Código</th>
                            <th scope="col">Título</th>
                            <th scope="col">Destacado</th>
                            <th scope="col">Activo</th>
                            <th scope="col">Tipo</th>
                            <th scope="col">Contrato</th>
                            <th scope="col">Moneda</th>
                            <th scope="col">Precio</th>
                            <th scope="col">Editar</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("Codigo") %></td>
                    <td><%# Eval("Titulo") %></td>
                    <td><%# Eval("Destacado", "{0}").Replace("True", "SI").Replace("False", "NO") %></td>
                    <td><%# Eval("Activo", "{0}").Replace("True", "SI").Replace("False", "NO") %></td>
                    <td><%# Eval("TipoPropiedad.Descripcion") %></td>
                    <td><%# Eval("TipoContrato.Descripcion") %></td>
                    <td><%# Eval("Moneda") %></td>
                    <td><%# string.Format("{0:###,###,###}", Eval("Precio")).Replace(",", ".") %></td>
                    <td>
                        <asp:LinkButton runat="server" ID="btnEditar" Text="✍ Editar" CommandName="EditarPropiedad" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

        <asp:DataPager runat="server" ID="TableDataPager" PagedControlID="TableListView" PageSize="10" CssClass="pagination justify-content-center">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" PreviousPageText="&#9668;" FirstPageText="&#9668;&#9668;" ButtonCssClass="btn btn-sm btn-default" />
                <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn btn-sm btn-default" CurrentPageLabelCssClass="" NextPreviousButtonCssClass="btn btn-sm btn-default" />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowPreviousPageButton="False" NextPageText="&#9658;" LastPageText="&#9658;&#9658;" ButtonCssClass="btn btn-sm btn-default" />
            </Fields>
        </asp:DataPager>

        <asp:Label ID="lblTablaVacia" CssClass="text-danger mt-3" runat="server" Visible="false" />
        <a href="PropiedadAdmin.aspx" class="btn btn-success">Agregar</a>
    </div>
</asp:Content>