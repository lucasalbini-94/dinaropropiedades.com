<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AyudaContacto.aspx.cs" Inherits="Ventanas.AyudaContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container margin-top">
        <div class="row pt-3 mb-3">
            <h1 class="mt-5">Preguntas frecuentes</h1>
        </div>
        <div class="mb-3">
            <h3>Servicios Generales de la Inmobiliaria</h3>
        </div>
        <%--Acordion 1--%>
        <div class="accordion mb-3" id="accordion1">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a1c1" aria-expanded="false" aria-controls="a1c1">
                        <strong>1. ¿Qué tipos de propiedades ofrecen? </strong>
                    </button>
                </h2>
                <div id="a1c1" class="accordion-collapse collapse" data-bs-parent="#accordion1">
                    <div class="accordion-body">
                        <p>Ofrecemos una amplia gama de propiedades, incluyendo casas, terrenos y lotes. También brindamos servicios de construcción de viviendas personalizadas.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a1c2" aria-expanded="false" aria-controls="a1c2">
                        <strong>2. ¿Ofrecen servicios de administración de propiedades? </strong>
                    </button>
                </h2>
                <div id="a1c2" class="accordion-collapse collapse" data-bs-parent="#accordion1">
                    <div class="accordion-body">
                        <p>Sí, ofrecemos servicios de administración de propiedades para ayudarte a manejar tu inversión, incluyendo mantenimiento, cobro de rentas y más.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a1c3" aria-expanded="false" aria-controls="a1c3">
                        <strong>3. ¿Qué pasa si una propiedad que me interesa ya ha sido vendida?</strong>
                    </button>
                </h2>
                <div id="a1c3" class="accordion-collapse collapse" data-bs-parent="#accordion1">
                    <div class="accordion-body">
                        <p>Te ayudaremos a encontrar propiedades similares que cumplan con tus criterios y necesidades.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a1c4" aria-expanded="false" aria-controls="a1c4">
                        <strong>4. ¿Puedo comprar una propiedad como inversión para rentar?</strong>
                    </button>
                </h2>
                <div id="a1c4" class="accordion-collapse collapse" data-bs-parent="#accordion1">
                    <div class="accordion-body">
                        <p>Sí, muchas de nuestras propiedades son excelentes opciones para inversión y te ayudaremos a gestionar el proceso de alquiler.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a1c5" aria-expanded="false" aria-controls="a1c5">
                        <strong>5.	¿Puedo obtener referencias de clientes anteriores?</strong>
                    </button>
                </h2>
                <div id="a1c5" class="accordion-collapse collapse" data-bs-parent="#accordion1">
                    <div class="accordion-body">
                        <p>Sí, estamos orgullosos de nuestro historial de clientes satisfechos y podemos proporcionarte referencias bajo solicitud.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--Acordion 2--%>
        <div class="mb-3">
            <h3>Servicios de Corretaje y Venta de Propiedades</h3>
        </div>
        <div class="accordion mb-3" id="accordion2">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a2c1" aria-expanded="false" aria-controls="a2c1">
                        <strong>1. ¿Que ventajas tenés de contratar una inmobiliaria en el que su personal está matriculado?</strong>
                    </button>
                </h2>
                <div id="a2c1" class="accordion-collapse collapse" data-bs-parent="#accordion2">
                    <div class="accordion-body">
                        <p>La profesión de corredor inmobiliario es una carrera universitaria donde por años se prepara al profesional en cuestiones legales, administrativas y de resolución de conflictos. Además, el corredor inmobiliario te acompaña de principio a fin, una transacción para que todo salga como esperás.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a2c2" aria-expanded="false" aria-controls="a2c2">
                        <strong>2. ¿Pueden ayudarme a vender mi propiedad actual?</strong>
                    </button>
                </h2>
                <div id="a2c2" class="accordion-collapse collapse" data-bs-parent="#accordion2">
                    <div class="accordion-body">
                        <p>Sí, ofrecemos servicios de corretaje para ayudarte a vender tu propiedad actual de manera rápida y eficiente.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a2c3" aria-expanded="false" aria-controls="a2c3">
                        <strong>3. ¿Cómo determino el valor de una propiedad?</strong>
                    </button>
                </h2>
                <div id="a2c3" class="accordion-collapse collapse" data-bs-parent="#accordion2">
                    <div class="accordion-body">
                        <p>No hay una sola forma de hacer una tasación eficiente y acordé. Dependerá de varios factores. Es por eso que te ofrecemos servicios de tasación profesional para ayudarte a determinar el valor justo de una propiedad basada en el mercado actual y características específicas del inmueble.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a2c4" aria-expanded="false" aria-controls="a2c4">
                        <strong>4. ¿Cómo puedo estar seguro de que estoy haciendo una buena inversión?</strong>
                    </button>
                </h2>
                <div id="a2c4" class="accordion-collapse collapse" data-bs-parent="#accordion2">
                    <div class="accordion-body">
                        <p>Nuestro equipo de expertos en bienes raíces te proporcionará un análisis detallado del mercado y asesoramiento personalizado para ayudarte a tomar decisiones informadas.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a2c5" aria-expanded="false" aria-controls="a2c5">
                        <strong>5. ¿Cómo puedo saber si una propiedad tiene todas las licencias y permisos necesarios? </strong>
                    </button>
                </h2>
                <div id="a2c5" class="accordion-collapse collapse" data-bs-parent="#accordion2">
                    <div class="accordion-body">
                        <p>Nos aseguramos de que todas nuestras propiedades cumplan con las normativas locales y posean las licencias y permisos necesarios antes de ponerlas a la venta. Y que no estén embargadas o trabadas de alguna manera.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a2c6" aria-expanded="false" aria-controls="a2c6">
                        <strong>6. ¿Cómo determino si una propiedad es adecuada para mis necesidades familiares?</strong>
                    </button>
                </h2>
                <div id="a2c6" class="accordion-collapse collapse" data-bs-parent="#accordion2">
                    <div class="accordion-body">
                        <p>Considerá factores como el tamaño, distribución, cercanía a escuelas y servicios, y características de la comunidad. Nuestro equipo te asistirá en evaluar todas estas variables.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--Acordion 3--%>
        <div class="mb-3">
            <h3>Asesoría y Servicios Legales</h3>
        </div>
        <div class="accordion mb-3" id="accordion3">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a3c1" aria-expanded="false" aria-controls="a3c1">
                        <strong>1. ¿Ofrecen servicios de asesoría legal para la compra de propiedades?</strong>
                    </button>
                </h2>
                <div id="a3c1" class="accordion-collapse collapse" data-bs-parent="#accordion3">
                    <div class="accordion-body">
                        <p>Sí, contamos con un equipo de asesores legales que pueden ayudarte con todos los aspectos legales relacionados con la compra de una propiedad.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a3c2" aria-expanded="false" aria-controls="a3c2">
                        <strong>2. ¿Qué debo hacer si quiero modificar mi oferta de compra?</strong>
                    </button>
                </h2>
                <div id="a3c2" class="accordion-collapse collapse" data-bs-parent="#accordion3">
                    <div class="accordion-body">
                        <p>Comunicáte con nosotros lo antes posible. Te asistiremos en la modificación de tu oferta y en las negociaciones necesarias.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a3c3" aria-expanded="false" aria-controls="a3c3">
                        <strong>3. ¿Cómo se manejan las disputas o problemas durante el proceso de compra?</strong>
                    </button>
                </h2>
                <div id="a3c3" class="accordion-collapse collapse" data-bs-parent="#accordion3">
                    <div class="accordion-body">
                        <p>Contamos con un proceso estructurado para manejar disputas y problemas de manera rápida y eficiente, asegurando la transparencia y satisfacción de todas las partes involucradas.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--Acordion 4--%>
        <div class="mb-3">
            <h3>Proceso de Compra y Post-Venta</h3>
        </div>
        <div class="accordion mb-3" id="accordion4">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a4c1" aria-expanded="false" aria-controls="a4c1">
                        <strong>1. ¿Cómo puedo programar una visita a una propiedad?</strong>
                    </button>
                </h2>
                <div id="a4c1" class="accordion-collapse collapse" data-bs-parent="#accordion4">
                    <div class="accordion-body">
                        <p>Puedes programar una visita a través de nuestro formulario de contacto en la web, llamándonos directamente o enviándonos un correo electrónico.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a4c2" aria-expanded="false" aria-controls="a4c2">
                        <strong>2. ¿Ofrecen servicios post-venta?</strong>
                    </button>
                </h2>
                <div id="a4c2" class="accordion-collapse collapse" data-bs-parent="#accordion4">
                    <div class="accordion-body">
                        <p>Sí, ofrecemos un servicio integral que incluye asistencia post-venta para asegurarnos de que estés completamente satisfecho con tu compra. Además, nos aseguramos que los trámites y transferencias de dominio se hayan concluido correctamente.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a4c3" aria-expanded="false" aria-controls="a4c3">
                        <strong>3. ¿Qué debo hacer si encuentro problemas con la propiedad después de la compra?</strong>
                    </button>
                </h2>
                <div id="a4c3" class="accordion-collapse collapse" data-bs-parent="#accordion4">
                    <div class="accordion-body">
                        <p>Contactános inmediatamente. Estamos comprometidos a resolver cualquier problema y asegurar tu satisfacción con la propiedad.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--Acordion 5--%>
        <div class="mb-3">
            <h3>Construcción y Personalización de Viviendas</h3>
        </div>
        <div class="accordion" id="accordion5">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c1" aria-expanded="false" aria-controls="a5c1">
                        <strong>1. ¿Puedo construir una casa en cualquier terreno que compre?</strong>
                    </button>
                </h2>
                <div id="a5c1" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>Sí, ofrecemos servicios de construcción de viviendas personalizadas en los terrenos que compres con nosotros. Nuestro equipo te asistirá en todo el proceso de diseño y construcción.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c2" aria-expanded="false" aria-controls="a5c2">
                        <strong>2. ¿Cómo sé si un terreno es adecuado para la construcción?</strong>
                    </button>
                </h2>
                <div id="a5c2" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>Realizamos un análisis detallado del terreno para asegurarnos de que cumple con todas las normativas y requisitos necesarios para la construcción.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c3" aria-expanded="false" aria-controls="a5c3">
                        <strong>3. ¿Cuánto tiempo lleva construir una casa?</strong>
                    </button>
                </h2>
                <div id="a5c3" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>El tiempo de construcción puede variar dependiendo del diseño y tamaño de la casa, pero generalmente puede tomar entre 3 a 6 meses desde el inicio hasta la finalización.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c4" aria-expanded="false" aria-controls="a5c4">
                        <strong>4. ¿Qué garantías ofrecen en las propiedades nuevas?</strong>
                    </button>
                </h2>
                <div id="a5c4" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>Todas nuestras propiedades nuevas vienen con garantías estructurales y de construcción para asegurar la tranquilidad y satisfacción de nuestros clientes. Además, te asesoramos en la presentación de planos y trámites municipales.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c5" aria-expanded="false" aria-controls="a5c5">
                        <strong>5. ¿Pueden ayudarme a encontrar un terreno específico según mis necesidades?</strong>
                    </button>
                </h2>
                <div id="a5c5" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>Sí, trabajamos estrechamente con vos para encontrar el terreno perfecto que se ajuste a tus requisitos y objetivos.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c6" aria-expanded="false" aria-controls="a5c6">
                        <strong>6. ¿Cómo es el proceso de personalización de una vivienda nueva?</strong>
                    </button>
                </h2>
                <div id="a5c6" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>Trabajamos con vos desde el diseño hasta la construcción, permitiéndote elegir materiales, acabados y otros detalles para que tu hogar sea exactamente como lo deseás.</p>
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#a5c7" aria-expanded="false" aria-controls="a5c7">
                        <strong>7. ¿Cómo aseguran la calidad de las construcciones?</strong>
                    </button>
                </h2>
                <div id="a5c7" class="accordion-collapse collapse" data-bs-parent="#accordion5">
                    <div class="accordion-body">
                        <p>Utilizamos materiales de alta calidad y trabajamos con profesionales experimentados para garantizar que todas las construcciones cumplan con los más altos estándares.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--Contacto--%>
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
</asp:Content>
