<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .encabezado {
            position: relative;
            height: 50vh;
            display: flex;
            align-items: center;
            justify-content: center;
            text-align: center;
            overflow: hidden;
        }

        .img-encabezado {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            object-fit: cover;
            z-index: -1;
        }

        .h1-encabezado {
            color: white;
            font-size: 3rem;
            margin: 0;
            text-shadow: 2px 2px 5px rgb(0 0 0);
        }

        .radio {
            border-radius: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Portada--%>
    <header class="encabezado margin-top">
        <img class="img-encabezado" src="./Images/ImgApp/portada.jpg" alt="Portada" loading="lazy">
        <div>
            <h1 class="h1-encabezado">¿Buscás tu lugar en el mundo?</h1>
        </div>
    </header>
    <%--Filtro--%>
    <form runat="server">
        <div class="container bg-dark-subtle radio mt-3">
            <div class="row text-center">
                <h2 class="mt-2">Encontralo acá...</h2>
            </div>
            <div class="row">
                <div class="col-2"></div>
                <div class="col-lg-3">
                    <div class="mb-3 mt-3 input-group">
                        <label for="ddlTipoPropiedad" class="input-group-text">Propiedad</label>
                        <asp:DropDownList CssClass="form-select" runat="server" ID="ddlTipoPropiedad"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="mt-3 mb-3 input-group">
                        <label for="ddlTipoContrato" class="input-group-text">Contrato</label>
                        <asp:DropDownList CssClass="form-select" runat="server" ID="ddlTipoContrato"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-2 mt-3 mb-3 text-center">
                    <asp:Button Text="Buscar" CssClass="btn btn-success" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                </div>
                <div class="col-2"></div>
            </div>
        </div>
    </form>
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
                                <img src="<%#Eval("ImagenPrincipal") %>" class="img-fluid rounded-start" alt="<%#Eval("AltImagen") %>">
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
