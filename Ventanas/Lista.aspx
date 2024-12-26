<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Ventanas.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <%--Filtros--%>
        <div class="col-lg-3 bg-dark-subtle margin-top mt-3 ps-4 pe-4">
            <section>
                <div class="margin-top mb-3">
                    <h4>Filtros</h4>
                </div>
                <hr />
                <form runat="server">
                    <div class="mb-2 row">
                        <h5>Tipo de propiedad</h5>
                        <div>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlTipoProp" OnSelectedIndexChanged="filtro_Click" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="mb-2 row">
                        <h5>Tipo de contrato</h5>
                        <div>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlTipoContrato" OnSelectedIndexChanged="filtro_Click" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="mb-2 row">
                        <h5>Ubicación</h5>
                        <%--<div class="mb-1">
                            <label for="ddlDpto" class="form-label">Departamento</label>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlDpto"></asp:DropDownList>
                        </div>
                        <div class="mb-1">
                            <label for="ddlLocalidades" class="form-label">Localidad</label>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlLocalidades"></asp:DropDownList>
                        </div>--%>
                        <div class="mb-1">
                            <label for="ddlPueblos" class="form-label">Barrio</label>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlPueblos" OnSelectedIndexChanged="filtro_Click" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="mb-2 row">
                        <h5>Precio</h5>
                        <div class="mb-1">
                            <label for="ddlMoneda" class="form-label">Moneda</label>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlMoneda" OnSelectedIndexChanged="filtro_Click" AutoPostBack="true">
                                <asp:ListItem Text="" />
                                <asp:ListItem Text="US$" />
                                <asp:ListItem Text="$" />
                            </asp:DropDownList>
                        </div>
                        <div class="mb-1">
                            <label for="ddlOrdenarPrecio" class="form-label">Ordenar por</label>
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlOrdenarPrecio" OnSelectedIndexChanged="filtro_Click" AutoPostBack="true">
                                <asp:ListItem Text="" />
                                <asp:ListItem Text="Menor precio" />
                                <asp:ListItem Text="Mayor precio" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row mb-2">
                        <h5>Caracteristicas</h5>
                        <div class="mb-1">
                            <div class="mb-3">
                                <label for="ddlCaracteristicas" class="form-label">Elegir característica</label>
                                <asp:DropDownList CssClass="form-select" runat="server" ID="ddlCaracteriticas">
                                    <asp:ListItem Text="" />
                                    <asp:ListItem Text="Ambientes" />
                                    <asp:ListItem Text="Dormitorios" />
                                    <asp:ListItem Text="Baños" />
                                    <asp:ListItem Text="Plantas" />
                                    <asp:ListItem Text="Cocheras" />
                                </asp:DropDownList>
                            </div>
                            <div class="d-flex">
                                <label for="tbxCantidad" class="form-label">Elegir cantidad</label>
                                <asp:TextBox runat="server" CssClass="form-control col me-4 ms-4" ID="tbxCantidad" TextMode="Number" />
                                <asp:Button CssClass="btn btn-primary" Text="Buscar" runat="server" ID="btnBuscarCaracteristica" OnClick="filtro_Click" />
                            </div>
                        </div>
                    </div>
                </form>
            </section>
        </div>
        <%--Lista--%>
        <div class="col-9 mt-5 container">
            <asp:Repeater runat="server" ID="repPropiedades">
                <ItemTemplate>
                    <a class="link-light" href="Descripcion.aspx?id=<%# Eval("Id") %>">
                        <div class="card mb-3 mt-5">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img src="<%# Eval("ImagenPrincipal") %>" class="img-fluid rounded-start" alt="<%# Eval("AltImagen") %>">
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title mb-3"><%# Eval("Titulo") %></h5>
                                        <p class="card-text"><%# Eval("Bio") %></p>
                                        <h4 class="card-subtitle text-danger mb-3"><strong><%# Eval("Moneda") %></strong> <%# string.Format("{0:###,###,###}", Eval("Precio")).Replace(",", ".") %></h4>
                                    </div>
                                    <div class="card-footer">
                                        <!-- Mostrar solo si no es un terreno -->
                                        <div class="row mb-3" runat="server" visible='<%# MostrarSiNoEsTerreno((bool)Eval("Terreno")) %>'>
                                            <span class="col-4"><i class="fa-solid fa-door-closed pe-1"></i>Ambientes: <%# Eval("Ambientes") %></span>
                                            <span class="col-4"><i class="fa-solid fa-bed pe-1"></i>Dormitorios: <%# Eval("Dormitorios") %></span>
                                            <span class="col-4"><i class="fa-solid fa-bath pe-1"></i>Baños: <%# Eval("Baños") %></span>
                                        </div>
                                        <div class="row">
                                            <span class="col-4"><i class="fa-solid fa-house pe-1"></i>M² terreno: <%# Eval("MetrosTotales") %></span>
                                            <!-- Mostrar solo si no es un terreno -->
                                            <span class="col-4" runat="server" visible='<%# MostrarSiNoEsTerreno((bool)Eval("Terreno")) %>'>
                                                <i class="fa-solid fa-ruler-combined pe-1"></i>M² cubiertos: <%# Eval("MetrosCubiertos") %></span>
                                            <span class="col-4" runat="server" visible='<%# MostrarSiNoEsTerreno((bool)Eval("Terreno")) %>'>
                                                <i class="fa-solid fa-car pe-1"></i>Cocheras: <%# Eval("Cocheras") %></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <% if (listaFiltrada != null)
                {
                    if (listaFiltrada.Count == 0)
                    { %>
            <div class="margin-top text-center">
                <h2 class="h1">No se encontraron resultados</h2>
                <h3>No hay ninguna propiedad con las características que ha seleccionado</h3>
            </div>
                <% } %>
            <% } %>
        </div>
    </div>
</asp:Content>
