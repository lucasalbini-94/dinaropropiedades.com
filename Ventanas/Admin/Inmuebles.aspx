<%@ Page Title="Lista de Inmuebles" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Inmuebles.aspx.cs" Inherits="Ventanas.Admin.Inmuebles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style-lista-inmueble.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Barra superior--%>
    <div class="barra-superior-container">
        <div class="barra-superior">
            Inmuebles / <b>Lista de inmuebles</b>
        </div>
        <div class="acciones-superiores">
            <div class="controles-tabla">
                <label for="registrosPorPagina">Mostrar</label>
                <select id="registrosPorPagina" class="select-paginacion">
                    <option value="5">5</option>
                    <option value="10" selected>10</option>
                    <option value="25">25</option>
                </select>
            </div>
            <a href="ABMPropiedad.aspx" class="btn btn-success">
                <i class="fas fa-plus"></i>Agregar Inmueble
            </a>
        </div>
    </div>

    <%--Mensajes de Alerta (Éxito o Error)--%>
    <asp:Label ID="lblMensaje" runat="server" CssClass="alert d-block mb-3"></asp:Label>

    <table class="tabla-inmuebles tabla-responsive" id="tablaInmuebles">
        <thead>
            <tr>
                <th>Foto</th>
                <th>Nombre</th>
                <th>Ubicación</th>
                <th>Precio</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody id="tablaBody">
            <asp:Repeater ID="rptPropiedades" runat="server" OnItemCommand="rptPropiedades_ItemCommand">
                <ItemTemplate>
                    <tr class="propiedad-row">
                        <td class="col-foto">
                            <img src='<%# Eval("RutaImagenPrincipal") != null 
                                    ? ResolveUrl("~/" + Eval("RutaImagenPrincipal")) 
                                    : ResolveUrl("~/Images/ImgApp/placeholder.jpg") %>'
                                alt="Imagen Propiedad"
                                class="thumb-inmueble" />
                        </td>
                        <td class="col-titulo" data-label="Nombre">
                            <div class="header-movil-wrap">
                                <span class="titulo-texto">
                                    <%# Eval("Titulo") %>
                                </span>
                            </div>
                        </td>
                        <td data-label="Ubicacion"><%# Eval("Barrio.Descripcion") %></td>
                        <td data-label="Precio"><%# Eval("Moneda") %> <%# Eval("PrecioActual", "{0:N0}") %></td>
                        <td class="col-acciones" data-label="Acciones">
                            <a href="ABMPropiedad.aspx?id=<%# Eval("Id") %>"
                                class="btn btn-primary" title="Editar">
                                <i class="fas fa-edit"></i>
                            </a>
                            <asp:LinkButton ID="btnEliminar" runat="server"
                                CommandName="Eliminar"
                                CommandArgument='<%# Eval("Id") %>'
                                CssClass="btn btn-danger"
                                title="Eliminar"
                                OnClientClick="return confirm('¿Está seguro de que desea eliminar este inmueble?');">
                                            <i class="fas fa-trash"></i>
                            </asp:LinkButton>
                            <a href="GeneradorQr.aspx?id=<%# Eval("Id") %>"
                                class="btn btn-primary" title="Generar QR">
                                <i class="fas fa-qrcode"></i>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div class="paginacion-container" id="paginacionContainer"></div>
</asp:Content>
