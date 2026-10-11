<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Header--%>
    <header class="hero-section">
        <div class="hero-carousel">
            <div class="carousel-item active">
                <img src="https://images.unsplash.com/photo-1584098731526-e3924fad98db?fm=jpg&q=60&w=3000&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y2FzYSUyMGRlJTIwbW9udGElQzMlQjFhfGVufDB8fDB8fHww" alt="Imagen 1" class="carousel-image">
                <div class="carousel-caption">
                    <h2>Encuentra tu hogar ideal</h2>
                    <p>Explora nuestras propiedades y encuentra el lugar perfecto para ti.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="https://hips.hearstapps.com/hmg-prod/images/edc020125commune-002-674dde87b8f84.jpg" alt="Imagen 2" class="carousel-image">
                <div class="carousel-caption">
                    <h2>Construimos tus sueños</h2>
                    <p>Descubre nuestras construcciones y haz realidad la casa de tus sueños.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="https://img.freepik.com/foto-gratis/cabana-barranco_181624-24461.jpg?semt=ais_hybrid&w=740&q=80" alt="Imagen 3" class="carousel-image">
                <div class="carousel-caption">
                    <h2>Terrenos disponibles</h2>
                    <p>Encuentra el terreno perfecto para construir tu futuro hogar.</p>
                </div>
            </div>
            <button class="carousel-control prev" aria-label="Anterior">&#10094;</button>
            <button class="carousel-control next" aria-label="Siguiente">&#10095;</button>
            <div class="carousel-dots"></div>
        </div>

        <%--Panel selector estático--%>
        <div class="hero-selector-container">
            <div class="selector-panel">

                <!-- Pestañas superiores -->
                <div class="selector-tabs">
                    <button class="tab-btn active" type="button" onclick="filterChange(this, 'viviendas')">VIVIENDAS</button>
                    <button class="tab-btn" type="button" onclick="filterChange(this, 'lotes')">LOTES</button>
                </div>

                <!-- Filtros de propiedades -->
                <div class="selector-filters" id="propiedades-filter">
                    <select class="filter-select">
                        <option value="">Ubicación</option>
                        <option value="">Las Vegas</option>
                        <option value="">Valle del SOl</option>
                        <option value="">Los Zorzales</option>
                    </select>

                    <select class="filter-select">
                        <option value="">Ambientes</option>
                        <option value="">1</option>
                        <option value="">2</option>
                        <option value="">3</option>
                        <option value="">4+</option>
                    </select>

                    <button class="filter-btn" type="button">Buscar</button>
                </div>
                <!-- Filtros de terrenos -->
                <div class="selector-filters" id="terrenos-filter" style="display: none;">
                    <select class="filter-select">
                        <option value="">Ubicación</option>
                        <option value="">Las Vegas</option>
                        <option value="">Valle del SOl</option>
                        <option value="">Los Zorzales</option>
                    </select>

                    <select class="filter-select">
                        <option value="">Tamaño</option>
                        <option value="">500 m²</option>
                        <option value="">1000 m²</option>
                        <option value="">2000 m²</option>
                        <option value="">5000 m²+</option>
                    </select>

                    <button class="filter-btn" type="button">Buscar</button>
                </div>
            </div>
        </div>
    </header>

    <%--Propiedades destacadas--%>
    <section class="destacados">
        <h2 class="section-title">Publicaciones destacadas</h2>

        <div class="cards-container" id="container-viviendas">
            <asp:Repeater runat="server" ID="repDestacadosViviendas">
                <ItemTemplate>
                    <div class="property-card">
                        <div class="card-image">
                            <img src='' alt='<%# Eval("Titulo") %>' />
                            <span class="badge"><%# Eval("TipoContrato.Nombre") %></span>
                        </div>

                        <div class="card-content">
                            <h3><%#Eval("Titulo") %></h3>
                            <div class="card-icons">
                                <span><i class="fas fa-bed">  <%#Eval("Dormitorios") %></i></span>
                                <span><i class="fas fa-door-closed">  <%#Eval("Ambientes") %></i></span>
                                <span><i class="fas fa-ruler-combined">  <%#Eval("MetrosCubiertos") %></i></span>
                            </div>
                            <div class="card-footer">
                                <span class="price"><strong><%#Eval("Moneda") %></strong> <%#string.Format("{0:###,###,###}", Eval("Precio")).Replace(",", ".") %></span>
                                <a href="Descripcion.aspx?id=<%#Eval("Id") %>" class="btn-details">Ver Detalles</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="cards-container" id="container-lotes" style="display: none;">
            <asp:Repeater runat="server" ID="repDestacadosLotes">
                <ItemTemplate>
                    <div class="property-card">
                        <div class="card-image">
                            <img src='' alt='<%# Eval("Titulo") %>' />
                            <span class="badge"><%# Eval("TipoContrato.Nombre") %></span>
                        </div>

                        <div class="card-content">
                            <h3><%# Eval("Titulo") %></h3>
                            <div class="card-icons">
                                <span><i class="fas fa-ruler-combined"> <%# Eval("MetrosTotales") ?? 0 %> m²</i></span>
                            </div>
                            <div class="card-footer">
                                <span class="price">
                                    <strong><%# Eval("Moneda") %></strong> 
                                    <%# string.Format("{0:N0}", Eval("Precio")).Replace(",", ".") %>
                                </span>
                                <a href='<%# "Descripcion.aspx?id=" + Eval("IdPropiedad") %>' class="btn-details">Ver Detalles</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <%--Botones de navegacion del carrousel--%>
        <button class="carousel-btn prev-btn" onclick="scrollIzquierda()">&#10094;</button>
        <button class="carousel-btn next-btn" onclick="scrollDerecha()">&#10095;</button>
    </section>
    <script type="text/javascript">
        function filterChange(btn, tipo) {
            // Actualizar clase activa en los botones de pestaña
            var tabs = document.querySelectorAll('.tab-btn');
            tabs.forEach(t => t.classList.remove('active'));
            btn.classList.add('active');

            // Paneles de filtros superiores
            var filterProp = document.getElementById('propiedades-filter');
            var filterTerr = document.getElementById('terrenos-filter');

            // Contenedores de tarjetas de propiedades destacadas
            var containerViviendas = document.getElementById('container-viviendas');
            var containerLotes = document.getElementById('container-lotes');

            if (tipo === 'lotes') {
                if (filterProp) filterProp.style.display = 'none';
                if (filterTerr) filterTerr.style.display = 'flex';

                if (containerViviendas) containerViviendas.style.display = 'none';
                if (containerLotes) containerLotes.style.display = 'flex';
            } else {
                if (filterProp) filterProp.style.display = 'flex';
                if (filterTerr) filterTerr.style.display = 'none';

                if (containerViviendas) containerViviendas.style.display = 'flex';
                if (containerLotes) containerLotes.style.display = 'none';
            }
        }
    </script>
</asp:Content>
