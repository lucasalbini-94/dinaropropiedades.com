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
                <!-- Carrousel -->
                <div id="carouselExampleFade" class="carousel slide carousel-fade margin-top mb-5" data-bs-ride="carousel" data-bs-interval="2000">
                    <div class="carousel-inner">
                        <div class="carousel-item active mt-5">
                            <img src="<%:seleccionada.ImagenPrincipal %>" class="d-block w-100" alt="<%#Eval("Alt") %>"
                                data-bs-index="0" onclick="openModal(0)">
                        </div>
                        <asp:Repeater ID="repImagenes" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item mt-5">
                                    <img src="<%#Eval("Ruta") %>" class="d-block w-100" alt="<%#Eval("Alt") %>"
                                        data-bs-index='<%# Container.ItemIndex + 1 %>' onclick="openModal(<%# Container.ItemIndex + 1 %>)">
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

                <%--<!-- Modal -->
                <div class="modal fade" id="imageModal" tabindex="-1" aria-labelledby="imageModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="imageModalLabel">Vista de imagen</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body text-center">
                                <img id="modalImage" src="" class="img-fluid" alt="Imagen modal">
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" onclick="navigateModal(-1)">Anterior</button>
                                <button type="button" class="btn btn-secondary" onclick="navigateModal(1)">Siguiente</button>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <%--Video de Youtube--%>
                <% if (!string.IsNullOrEmpty(seleccionada.Video))
                    { %>
                <div class="mb-5">
                    <iframe class="col-12" height="315" src="<%: seleccionada.Video %>"
                        title="YouTube video player" frameborder="0"
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                        referrerpolicy="strict-origin-when-cross-origin" allowfullscreen=""></iframe>
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
                        <h3><strong><%:seleccionada.Moneda %></strong> <%: string.Format("{0:###,###,###}", seleccionada.Precio).Replace(",", ".") %></h3>
                        <a target="_blank" href="https://wa.me/2616006009" class="ms-3 btn btn-success">Contactanos</a>
                    </div>
                    <% if (!seleccionada.Terreno)
                        { %>
                    <div class="row mb-3">
                        <span class="col-4"><i class="fa-solid fa-bed pe-1"></i><%:seleccionada.Dormitorios %> dormitorios</span>
                        <span class="col-4"><i class="fa-solid fa-bath pe-1"></i><%:seleccionada.Baños %> baños</span>
                        <span class="col-4"><i class="fa-solid fa-door-closed"></i><%:seleccionada.Ambientes %> ambientes</span>
                    </div>
                    <% } %>
                    <div class="row mb-3">
                        <span class="col-4"><i class="fa-solid fa-ruler-combined pe-1"></i><%:seleccionada.MetrosTotales %> m² de terreno</span>
                        <% if (!seleccionada.Terreno)
                            { %>
                        <span class="col-4"><i class="fa-solid fa-house"></i><%:seleccionada.MetrosCubiertos %> m² cubiertos</span>
                        <span class="col-4"><i class="fa-solid fa-car"></i><%:seleccionada.Cocheras %> cochera</span>
                        <% } %>
                    </div>
                    <% if (!seleccionada.Terreno)
                        { %>
                    <div>
                        <span class="col-4"><i class="fa-solid fa-stairs"></i><%:seleccionada.Plantas %> plantas</span>
                    </div>
                    <% } %>
                    <div class="row">
                        <h3>Descripción</h3>
                        <p class="mt-3"><%:seleccionada.Descripcion %></p>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <%--<script>
        let currentIndex = 0; // Índice actual de la imagen en el modal
        const images = [...document.querySelectorAll('#carouselExampleFade img')]; // Array de todas las imágenes del carrusel
        const carouselElement = document.getElementById('carouselExampleFade'); // Elemento del carrusel
        const bootstrapCarousel = new bootstrap.Carousel(carouselElement); // Instancia del carrusel de Bootstrap

        function openModal(index) {
            currentIndex = index; // Establece el índice actual
            const modalImage = document.getElementById('modalImage');
            modalImage.src = images[index].src; // Cambia la fuente de la imagen en el modal

            // Pausar el carrusel al abrir el modal
            bootstrapCarousel.pause();

            const modal = new bootstrap.Modal(document.getElementById('imageModal'));
            modal.show();
        }

        function navigateModal(direction) {
            currentIndex += direction; // Cambia el índice según la dirección (-1 o +1)
            if (currentIndex < 0) {
                currentIndex = images.length - 1; // Si llega al inicio, pasa al final
            } else if (currentIndex >= images.length) {
                currentIndex = 0; // Si llega al final, pasa al inicio
            }
            const modalImage = document.getElementById('modalImage');
            modalImage.src = images[currentIndex].src; // Cambia la fuente de la imagen en el modal
        }

        // Reanudar el carrusel cuando se cierra el modal
        const modalElement = document.getElementById('imageModal');
        modalElement.addEventListener('hidden.bs.modal', () => {
            bootstrapCarousel.cycle(); // Reinicia el temporizador del carrusel
        });
    </script>--%>
</asp:Content>
