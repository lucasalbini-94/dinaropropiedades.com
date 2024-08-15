<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="NuestrasPropiedades.aspx.cs" Inherits="Ventanas.NuestrasPropiedades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container margin-top">
        <div class="row mb-5">
            <div class="col-lg-6 col-12 mt-5">
                <img class="container-fluid" src="https://previews.123rf.com/images/perig76/perig761508/perig76150800039/45293462-vista-de-un-ingeniero-y-un-trabajador-mirando-el-plano-en-el-sitio-de-construcci%C3%B3n.jpg"
                    alt="Alternate Text" />
            </div>
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <h2 class="h1">Construimos tu casa ideal</h2>
                <p class="ms-5 me-5">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
            </div>
        </div>
        <div class="row mt-5 mb-5">
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <h2 class="h1">Somos expertos en construcción</h2>
                <p class="ms-5 me-5">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
            </div>
            <div class="col-lg-6 col-12 mt-5">
                <img class="container-fluid" src="https://substackcdn.com/image/fetch/w_1456,c_limit,f_auto,q_auto:good,fl_progressive:steep/https%3A%2F%2Fbucketeer-e05bbc84-baa3-437e-9518-adb32be77984.s3.amazonaws.com%2Fpublic%2Fimages%2Ff5dc02d8-3705-4b1f-bb09-a746798bf67e_1280x720.jpeg"
                    alt="Alternate Text" />
            </div>
        </div>
        <div class="row mt-5 mb-5">
            <div class="col-lg-6 col-12">
                <%--Carrousel--%>
                <div id="carouselExampleFade" class="carousel slide carousel-fade margin-top mb-5">
                    <div class="carousel-inner">
                        <div class="carousel-item active mt-5">
                            <img src="/Images/imgweb1.jpg" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item mt-5">
                            <img src="/Images/foto13.jpg" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item mt-5">
                            <img src="/Images/foto17.jpg" class="d-block w-100" alt="...">
                        </div>
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
            </div>
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <h2 class="h1">Conocé nuestras propiedades</h2>
                <p class="ms-5 me-5">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
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
