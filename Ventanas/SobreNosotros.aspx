<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="SobreNosotros.aspx.cs" Inherits="Ventanas.SobreNosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imagen-about {
            background-image: url(./Images/ImgApp/paisajeconlogo.png);
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            height: 100vh;
            display: flex;
            align-items: center; /* Alinea el contenido verticalmente al centro */
            justify-content: center; /* Alinea el contenido horizontalmente al centro */
            text-align: center;
        }

        .h2-imagen-about {
            color: white;
            font-size: 3rem;
            margin: 0;
            text-shadow: 2px 2px 5px rgb(0 0 0); /* Sombra gris */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container margin-top">
        <div class="row mb-5">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <a href="https://maps.app.goo.gl/LSLJF5sZCGhQsP7s8" target="_blank"><img src="/Images/ImgApp/banner.png" alt=""></a>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row mb-5">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <h1 class="mb-5">¿Quienes somos?</h1>
                <p class="ms-5 me-5">
                    En <strong>Dinaro Propiedades</strong>, nos dedicamos a conectar a nuestros clientes con sus hogares ideales. Nos encontramos en Potrerillos, Mendoza, y con una sólida experiencia en el mercado inmobiliario local, 
                    nos especializamos en la venta de propiedades, ofreciendo una amplia gama de opciones que se adaptan a cada necesidad y presupuesto.
                </p>
                <p class="ms-5 me-5">
                    Nuestra inmobiliaria no solo se enfoca en la venta de propiedades, sino que también brindamos un servicio integral que incluye asesoramiento personalizado, 
                    gestión de ventas, y un profundo conocimiento del mercado local. Nos esforzamos por ofrecer un servicio de excelencia, ayudándote a encontrar la propiedad perfecta con la tranquilidad 
                    de estar en manos expertas.
                </p>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row mb-5">
            <div class="col-lg-6 col-12 mt-5">
                <img class="container-fluid" src="/Images/ImgApp/cds1.png"
                    alt="Alternate Text" />
            </div>
            <div class="col-lg-6 col-12 mt-5 text-center align-content-center">
                <p class="ms-5 me-5">
                    Como un valor añadido, en <strong>Dinaro Propiedades</strong> también contamos con <strong>Construcciones del Sol</strong>, nuestra empresa hermana especializada en construcción. 
                    Si no encontrás una propiedad que se ajuste a tus necesidades, o si tenés un terreno y deseas construir desde cero, estamos aca para ayudarte a llevar a cabo tu proyecto. 
                </p>
                <p class="ms-5 me-5">
                    Ofrecemos servicios de construcción que van desde el diseño hasta la entrega final, asegurando calidad y satisfacción en cada etapa.
                </p>
            </div>
        </div>
    </div>
    <div>
        <div class="imagen-about">
        </div>
    </div>
    <div class="container">
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
