<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Descripcion.aspx.cs" Inherits="Ventanas.Descripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .carousel-inner {
            width: 546px;
            height: 409px;
        }

        .carousel-item img {
            max-height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-12">
                <%--Carrousel--%>
                <div id="carouselExampleFade" class="carousel slide carousel-fade margin-top mb-5">
                    <div class="carousel-inner">
                        <div class="carousel-item active mt-5">
                            <img src="<%:seleccionada.ImagenPrincipal %>" class="d-block w-100" alt="...">
                        </div>
                        <asp:Repeater ID="repImagenes" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item mt-5">
                                    <img src="<%#Eval("Ruta") %>" class="d-block w-100" alt="...">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                <%--Video de Youtube--%>
                <% if (!string.IsNullOrEmpty(seleccionada.Video))
                    { %>
                <div class="mb-5">
                    <iframe class="col-12" height="315" src="<%: seleccionada.Video %>"
                        title="YouTube video player" frameborder="0"
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                        referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
                </div>
                <% } %>
                <%-- Contenedor del Mapa--%>
                <% if (!(string.IsNullOrEmpty(seleccionada.Ubicacion)))
                    { %>
                <div>
                    <h2 class="mb-5">Ubicación</h2>
                    <div>
                        <iframe class="container-fluid" src="<%:seleccionada.Ubicacion %>"
                            width="600" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </div>
                </div>
                <% } %>
            </div>
            <section class="col-lg-6 col-12 mt-5 ps-5">
                <%--Caracteristicas--%>
                <div class="margin-top mb-5">
                    <h2><%:seleccionada.Titulo %></h2>
                </div>
                <div>
                    <div id="precio" class="text-danger mb-5" style="display: flex; align-items: center">
                        <h3><%:seleccionada.Moneda %><%: string.Format("{0:F2}", seleccionada.Precio) %></h3>
                        <a target="_blank" href="https://wa.me/2616006009" class="ms-3 btn btn-success">Contactanos</a>
                    </div>
                    <div class="row mb-3">
                        <span class="col-4"><i class="fa-solid fa-bed pe-1"></i><%:seleccionada.Dormitorios %> dormitorios</span>
                        <span class="col-4"><i class="fa-solid fa-bath pe-1"></i><%:seleccionada.Baños %> baños</span>
                        <span class="col-4"><i class="fa-solid fa-door-closed"></i><%:seleccionada.Ambientes %> ambientes</span>
                    </div>
                    <div class="row mb-3">
                        <span class="col-4"><i class="fa-solid fa-ruler-combined pe-1"></i><%:seleccionada.MetrosTotales %> m² de terreno</span>
                        <span class="col-4"><i class="fa-solid fa-house"></i><%:seleccionada.MetrosCubiertos %> m² cubiertos</span>
                        <span class="col-4"><i class="fa-solid fa-car"></i><%:seleccionada.Cocheras %> cochera</span>
                    </div>
                    <div>
                        <span class="col-4"><i class="fa-solid fa-stairs"></i><%:seleccionada.Plantas %> plantas</span>
                    </div>
                    <div class="row">
                        <h3>Descripción</h3>
                        <p class="mt-3"><%:seleccionada.Descripcion %></p>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
