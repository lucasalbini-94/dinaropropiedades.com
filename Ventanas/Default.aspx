<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Portada--%>
    <section class="margin-top card text-bg-dark">
        <img class="card-img container-fluid p-0" src="/Images/imagenPortada1.jpg" alt="Imágen de portada" />
        <div class="card-img-overlay row text-center mt-5">
            <div class="col-4"></div>
            <h2 class="h1 col-4">Tu lugar en el mundo está acá</h2>
            <div class="col-4"></div>
        </div>
    </section>
    <%--Propiedades destacadas--%>
    <section class="container mt-5">
        <div class="text-center">
            <h2 class="h1">Propiedades destacadas</h2>
        </div>
        <%--Repetidor de propiedades--%>
        <asp:Repeater runat="server" ID="repDestacados">
            <ItemTemplate>
                <a class="link-light" href="Descripcion.aspx?id=<%#Eval("Id") %>">
                    <div class="card mb-3 mt-5">
                        <div class="row g-0">
                            <div class="col-md-4">
                                <img src="<%#Eval("ImagenPrincipal") %>" class="img-fluid rounded-start" alt="Imágen de propiedad">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title mb-3"><%#Eval("Titulo") %></h5>
                                    <p class="card-text"><%#Eval("Bio") %></p>
                                    <h4 class="card-subtitle text-danger mb-3"><strong><%#Eval("Moneda") %></strong><%#string.Format("{0:F2}", Eval("Precio")) %></h4>
                                </div>
                                <div class="card-footer">
                                    <div class="row mb-3">
                                        <span class="col-4"><i class="fa-solid fa-door-closed pe-1"></i>Ambientes: <%#Eval("Ambientes") %></span>
                                        <span class="col-4"><i class="fa-solid fa-bed pe-1"></i><%#Eval("Dormitorios") %> dormitorios</span>
                                        <span class="col-4"><i class="fa-solid fa-bath pe-1"></i><%#Eval("Baños") %> baños</span>
                                    </div>
                                    <div class="row mb-3">
                                        <span class="col-4"><i class="fa-solid fa-house pe-1"></i>M² terreno: <%#Eval("MetrosTotales") %></span>
                                        <span class="col-4"><i class="fa-solid fa-ruler-combined pe-1"></i>M² cubiertos: <%#Eval("MetrosCubiertos") %></span>
                                        <span class="col-4"><i class="fa-solid fa-car pe-1"></i>Cocheras: <%#Eval("Cocheras") %></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </section>

    <%--Formulario de contacto--%>
    <section class="container mt-5">
        <div class="row mt-5">
            <div class=" mb-5 text-center align-items-center">
                <h2 class="h1 mb-5">Comunicate con nosotros</h2>
                <a target="_blank" href="https://wa.me/2616006009">
                    <img src="/Images/ImgApp/whatsapp_logo.png" alt="WhatsApp Logo" />
                </a>
            </div>
        </div>
    </section>
</asp:Content>
