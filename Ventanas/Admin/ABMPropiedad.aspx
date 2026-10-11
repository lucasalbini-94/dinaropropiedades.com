<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ABMPropiedad.aspx.cs" Inherits="Ventanas.Admin.ABMPropiedad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style-agregar-inmueble.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="formAgregarInmueble" class="form-inmueble">
        <!-- Barra superior fija con ruta y botones de acción -->
        <div class="barra-acciones-sticky">
            <div class="barra-superior">
                Inmuebles / <b>Agregar Inmueble</b>
            </div>
            <div class="form-actions-top">
                <a href="Inmuebles.aspx" class="btn btn-danger">
                    <i class="fas fa-times"></i>Cancelar
                </a>
                <asp:Button runat="server" CssClass="btn btn-success"
                    Text="Guardar Inmueble" ID="btnGuardar" OnClick="btnGuardar_Click" />
            </div>
        </div>

        <asp:Label ID="lblError" runat="server"></asp:Label>

        <%--Menú de pestañas para saltar entre campos--%>
        <nav class="tabs-menu" id="tabsMenu">
            <button type="button" class="tab-item active" data-tab="tab-general">
                <i class="fas fa-info-circle"></i>Información General
            </button>
            <button type="button" class="tab-item" data-tab="tab-clasificacion">
                <i class="fas fa-map-marker-alt"></i>Clasificación y Ubicación
            </button>
            <button type="button" class="tab-item" data-tab="tab-medidas">
                <i class="fas fa-ruler-combined"></i>Medidas, Distribución y Precio
            </button>
            <button type="button" class="tab-item" data-tab="tab-amenities">
                <i class="fas fa-concierge-bell"></i>Características
            </button>
            <button type="button" class="tab-item" data-tab="tab-multimedia">
                <i class="fas fa-images"></i>Multimedia y Visibilidad
            </button>
        </nav>

        <%--Contenedores de cada pestaña--%>
        <div class="tabs-content">

            <%--Pestaña 1: General--%>
            <section class="tab-pane active" id="tab-general">
                <div class="form-card">
                    <h3>
                        <i class="fas fa-info-circle"></i>
                        Información General
                    </h3>
                    <div class="form-group col-span-3">
                        <label for="tbxCodigo">Código</label>
                        <asp:TextBox ID="tbxCodigo" placeholder="El código se genera automáticamente"
                            ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-span-2">
                        <label for="tbxTitulo">Título de la Publicación *</label>
                        <asp:TextBox ID="tbxTitulo" placeholder="Ej: Cabaña de tronco con parque y pileta"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-span-3">
                        <label for="tbxBio">Bio</label>
                        <asp:TextBox ID="tbxBio" placeholder="Frase destacada para tarjetas y listados..."
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-span-3">
                        <label for="descripcion">Descripción Completa</label>
                        <asp:TextBox ID="tbxDescripcion" TextMode="MultiLine" Rows="5"
                            placeholder="Detalle completo del inmueble..." runat="server"></asp:TextBox>
                    </div>
                </div>
            </section>

            <%--Pestaña 2: Clasificación y Ubicación--%>
            <section class="tab-pane" id="tab-clasificacion">
                <div class="form-card">
                    <h3>
                        <i class="fas fa-map-marker-alt"></i>
                        Clasificación y Ubicación
                    </h3>
                    <div class="form-grid grid-3">
                        <div class="form-group">
                            <label for="ddlTipoPropiedad">Tipo de Propiedad *</label>
                            <asp:DropDownList ID="ddlTipoPropiedad" runat="server" DataValueField="Id" DataTextField="Descripcion"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlTipoContrato">Tipo de Contrato *</label>
                            <asp:DropDownList ID="ddlTipoContrato" runat="server" DataValueField="Id" DataTextField="Descripcion"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlEstado">Estado *</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="Id" DataTextField="Descripcion"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlBarrio">Barrio / Zona *</label>
                            <asp:DropDownList ID="ddlBarrio" runat="server" DataValueField="Id" DataTextField="Descripcion"></asp:DropDownList>
                        </div>
                        <div class="form-group col-span-2">
                            <label for="tbxDireccion">Dirección</label>
                            <asp:TextBox ID="tbxDireccion" placeholder="Calle falsa 123" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <label style="font-size: 0.85rem; font-weight: 600; color: #4a5568;" for="chbxMostrarDireccion">Mostrar dirección:</label>
                            <asp:CheckBox ID="chbxMostrarDireccion" runat="server" />
                        </div>
                    </div>
                </div>
            </section>

            <%--Pestaña 3: Medidas, Distribución y Precio--%>
            <section class="tab-pane" id="tab-medidas">
                <div class="form-card">
                    <h3><i class="fas fa-ruler-combined"></i>Medidas, Distribución y Precio</h3>
                    <div class="form-grid grid-4">
                        <div class="form-group">
                            <label for="tbxAmbientes">Ambientes</label>
                            <asp:TextBox TextMode="Number" ID="tbxAmbientes" min="0" placeholder="0" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="tbxDormitorios">Dormitorios</label>
                            <asp:TextBox TextMode="Number" ID="tbxDormitorios" min="0" placeholder="0" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label for="tbxBanios">Baños</label>
                            <asp:TextBox TextMode="Number" ID="tbxBanios" min="0" placeholder="0" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="tbxCocheras">Cocheras</label>
                            <asp:TextBox TextMode="Number" ID="tbxCocheras" min="0" placeholder="0" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="tbxPlantas">Plantas / Pisos</label>
                            <asp:TextBox TextMode="Number" ID="tbxPlantas" min="0" placeholder="1" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="tbxMetrosTotales">Metros Totales (m²)</label>
                            <asp:TextBox TextMode="Number" ID="tbxMetrosTotales" min="0" placeholder="0" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="tbxMetrosCubiertos">Metros Cubiertos (m²)</label>
                            <asp:TextBox TextMode="Number" ID="tbxMetrosCubiertos" min="0" placeholder="0" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="ddlMoneda">Moneda *</label>
                            <asp:DropDownList ID="ddlMoneda" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group col-span-2">
                            <label for="tbxPrecio">Precio *</label>
                            <asp:TextBox TextMode="Number" ID="tbxPrecio" min="0" placeholder="Ej: 150000" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </section>

            <!-- Pestaña 4: Características Adicionales -->
            <section class="tab-pane" id="tab-amenities">
                <div class="form-card">
                    <h3><i class="fas fa-concierge-bell"></i>Características Adicionales</h3>
                    <div class="checkbox-grid">
                        <asp:Repeater ID="rptCaracteristicas" runat="server">
                            <ItemTemplate>
                                <label class="custom-checkbox">
                                    <!-- Checkbox de servidor: guarda el ID de la característica en el Value / Hidden -->
                                    <asp:HiddenField ID="hfIdCaracteristica" runat="server" Value='<%# Eval("Id") %>' />
                                    <asp:CheckBox ID="chkCaracteristica" runat="server" />
                                    <span><i class='fas <%# Eval("Icono") %>'></i>
                                        <%# Eval("Descripcion") %></span>
                                </label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </section>

            <!-- Pestaña 5: Multimedia y Visibilidad -->
            <section class="tab-pane" id="tab-multimedia">
                <div class="form-card">
                    <h3><i class="fas fa-images"></i>Multimedia y Visibilidad</h3>

                    <div class="form-grid grid-3" style="margin-bottom: 20px;">
                        <div class="form-group col-span-3">
                            <label for="tbxVideo">Enlace de Video (YouTube / Vimeo)</label>
                            <asp:TextBox ID="tbxVideo" TextMode="Url" runat="server" placeholder="https://www.youtube.com/watch?v=..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="switches-container">
                        <label class="switch-control">
                            <asp:CheckBox ID="chbxDestacado" runat="server" />
                            <span class="slider"></span>
                            <span class="switch-label"><b>Destacar propiedad</b> (Mostrar en inicio)</span>
                        </label>
                        <label class="switch-control">
                            <asp:CheckBox ID="chbxActivo" runat="server" Checked="true" />
                            <span class="slider"></span>
                            <span class="switch-label"><b>Publicación Activa</b> (Visible al público)</span>
                        </label>
                    </div>

                    <div class="upload-zone" id="uploadZone">
                        <i class="fas fa-cloud-upload-alt upload-icon"></i>
                        <p>Seleccionar imágenes (se comprimen automáticamente) <span>haz clic aquí</span></p>
                        <!-- Input HTML estándar para que JavaScript capture y comprima antes de enviar -->
                        <input type="file" id="inputImagenes" multiple accept="image/*" class="file-input" />
                    </div>

                    <!-- HiddenField con el JSON de imágenes comprimidas y ordenadas -->
                    <asp:HiddenField ID="hfImagenesData" runat="server" ClientIDMode="Static" />

                    <div class="previews-grid" id="previewsGrid"></div>
                </div>
            </section>
        </div>
        
    </div>
    <script src="../js/script-agregar-inmueble.js"></script>
</asp:Content>
