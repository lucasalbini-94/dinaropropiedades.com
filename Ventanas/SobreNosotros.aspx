<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="SobreNosotros.aspx.cs" Inherits="Ventanas.SobreNosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Portada--%>
    <div class="container margin-top">
        <div class="row mb-5">
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <h1>¿Quienes somos?</h1>
                <p class="ms-5 me-5">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                    Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                    Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
            </div>
            <div class="col-lg-6 col-12 mt-5">
                <img class="container-fluid" src="https://img.freepik.com/foto-gratis/retrato-agente-inmobiliaria-mirando-camara-mientras-pareja-feliz-pie-fondo_637285-6097.jpg"
                    alt="Alternate Text" />
            </div>
        </div>
        <div class="row">
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
        </div>
    </div>
</asp:Content>
