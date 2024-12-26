<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PropiedadAdmin.aspx.cs" Inherits="Ventanas.PropiedadAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bio {
            height: 100px;
        }

        .descripcion {
            height: 300px;
        }

        .contenedor-imagenes {
            display: flex;
            gap: 10px;
            flex-wrap: wrap;
        }

        .imagen-item {
            position: relative;
        }

        .seleccionada {
            border: 3px solid #007bff;
            transform: scale(1.05);
            transition: transform 0.2s ease, border 0.2s ease;
        }

        .img-thumbnail {
            max-width: 150px; /* Ajusta el tamaño de las imágenes si es necesario */
            height: auto;
            cursor: pointer;
        }

        .botones-imagen {
            position: absolute;
            top: 10px;
            left: 10px;
            z-index: 1000;
        }

            .botones-imagen button {
                display: inline-block;
                margin-right: 5px;
                opacity: 0.9;
            }

            .botones-imagen:hover button {
                opacity: 1;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="margin-top container" id="datosPrincipales">

        <%--Sección principal--%>

        <h1 id="encabezado" class="mt-4" runat="server"></h1>
        <ol class="breadcrumb mb-4" id="datosprincipales">
            <li class="breadcrumb-item">Panel</li>
            <li class="breadcrumb-item active">Nueva propiedad</li>
            <li class="breadcrumb-item active"><a href="#datosprincipales">Datos principales</a></li>
            <li class="breadcrumb-item active"><a href="#caracteristicas">Características</a></li>
            <li class="breadcrumb-item active"><a href="#ubicacion">Ubicación</a></li>
            <li class="breadcrumb-item active"><a href="#imagenesVideo">Imágenes y video</a></li>
            <li class="breadcrumb-item active"><a href="#btnAccion">Botones de acción</a></li>

        </ol>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxCodigo" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="tbxCodigo" CssClass="form-control" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Este campo es requerido" ControlToValidate="tbxCodigo" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="tbxTitulo" class="form-label">Título</label>
                    <asp:TextBox runat="server" ID="tbxTitulo" CssClass="form-control" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Este campo es requerido" ControlToValidate="tbxTitulo" runat="server" />
                </div>

            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlTipoPropiedad" class="form-label">Tipo de Propiedad</label>
                    <asp:DropDownList runat="server" ID="ddlTipoPropiedad" CssClass="form-select" OnSelectedIndexChanged="guardarEnSesion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Este campo es requerido"
                        ControlToValidate="ddlTipoPropiedad" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="ddlTipoContrato" class="form-label">Tipo de Contrato</label>
                    <asp:DropDownList runat="server" ID="ddlTipoContrato" CssClass="form-select" OnSelectedIndexChanged="guardarEnSesion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Este campo es requerido"
                        ControlToValidate="ddlTipoContrato" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlMoneda" class="form-label">Moneda</label>
                    <asp:DropDownList runat="server" CssClass="form-select" ID="ddlMoneda" OnSelectedIndexChanged="guardarEnSesion_SelectedIndexChanged">
                        <asp:ListItem Text="" Selected="True" />
                        <asp:ListItem Text="US$" />
                        <asp:ListItem Text="$" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Este campo es requerido"
                        ControlToValidate="ddlMoneda" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="tbxPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="tbxPrecio" CssClass="form-control" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Este campo es requerido" ControlToValidate="tbxPrecio" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <asp:CheckBox ID="chbxDestacado" Text="Destacado" CssClass="form-check ps-0" Checked="false" runat="server" OnCheckedChanged="guardarEnSession_ChekedChanged" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <asp:CheckBox ID="chbxActivo" Text="Activo" CssClass="form-check ps-0" Checked="true" runat="server" OnCheckedChanged="guardarEnSession_ChekedChanged" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="mb-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <label for="tbxBio" class="form-label">Bio</label>
                            <asp:TextBox runat="server" ID="tbxBio" CssClass="bio form-control" TextMode="MultiLine"
                                OnTextChanged="guardarEnSesion_TextChanged" AutoPostBack="true" />
                            <asp:RegularExpressionValidator ErrorMessage="Máximo 100 caracteres" ControlToValidate="tbxBio" runat="server"
                                ValidationExpression="^^[\s\S]{0,1500}$" CssClass="text-danger" />
                            <label><%: contadorCharBio %>/100 caracteres</label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="mb-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <label for="tbxDescripcion" class="form-label">Descripción</label>
                            <asp:TextBox runat="server" ID="tbxDescripcion" CssClass="descripcion form-control" TextMode="MultiLine"
                                OnTextChanged="guardarEnSesion_TextChanged" AutoPostBack="true" />
                            <asp:RegularExpressionValidator ErrorMessage="Máximo 1500 caracteres"
                                ValidationExpression="^[\s\S]{0,1500}$"
                                ControlToValidate="tbxDescripcion" runat="server" CssClass="text-danger" />
                            <label><%: contadorCharDesc %>/1500 caracteres</label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <%--Sección características--%>
        <hr id="caracteristicas" />
        <ol class="breadcrumb mb-4">
            <li class="breadcrumb-item">Panel</li>
            <li class="breadcrumb-item active">Nueva propiedad</li>
            <li class="breadcrumb-item active"><a href="#datosprincipales">Datos principales</a></li>
            <li class="breadcrumb-item active"><a href="#caracteristicas">Características</a></li>
            <li class="breadcrumb-item active"><a href="#ubicacion">Ubicación</a></li>
            <li class="breadcrumb-item active"><a href="#imagenesVideo">Imágenes y video</a></li>
            <li class="breadcrumb-item active"><a href="#btnAccion">Botones de acción</a></li>

        </ol>

        <div class="row">
            <div class="mb-5 mt-5">
                <h2 class="h1">Características</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxAmbientes" class="form-label"><i class="fa-solid fa-door-open pe-2"></i>Ambientes</label>
                    <asp:TextBox runat="server" ID="tbxAmbientes" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Seleccione una cantidad" InitialValue="" ControlToValidate="tbxAmbientes" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxDormitorios" class="form-label"><i class="fa-solid fa-bed pe-2"></i>Dormitorios</label>
                    <asp:TextBox runat="server" ID="tbxDormitorios" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Seleccione una cantidad" ControlToValidate="tbxDormitorios" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxBaños" class="form-label"><i class="fa-solid fa-bath pe-2"></i>Baños</label>
                    <asp:TextBox runat="server" ID="tbxBaños" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue="" ControlToValidate="tbxBaños" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxMetrosTotales" class="form-label"><i class="fa-solid fa-ruler-combined pe-2"></i>M² totales</label>
                    <asp:TextBox runat="server" ID="tbxMetrosTotales" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue="" ControlToValidate="tbxMetrosTotales" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxMetrosCubiertos" class="form-label"><i class="fa-solid fa-house pe-2"></i>M² cubiertos</label>
                    <asp:TextBox runat="server" ID="tbxMetrosCubiertos" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue=""
                        ControlToValidate="tbxMetrosCubiertos" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxPlantas" class="form-label"><i class="fa-solid fa-stairs pe-2"></i>Plantas</label>
                    <asp:TextBox runat="server" ID="tbxPlantas" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue=""
                        ControlToValidate="tbxPlantas" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxCocheras" class="form-label"><i class="fa-solid fa-car pe-2"></i>Cocheras</label>
                    <asp:TextBox runat="server" ID="tbxCocheras" CssClass="form-control" TextMode="Number" OnTextChanged="guardarEnSesion_TextChanged" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue=""
                        ControlToValidate="tbxCocheras" runat="server" />
                </div>
            </div>
        </div>
        <hr id="ubicacion" />
        <%--Sección ubicación--%>
        <ol class="breadcrumb mb-4">
            <li class="breadcrumb-item">Panel</li>
            <li class="breadcrumb-item active">Nueva propiedad</li>
            <li class="breadcrumb-item active"><a href="#datosprincipales">Datos principales</a></li>
            <li class="breadcrumb-item active"><a href="#caracteristicas">Características</a></li>
            <li class="breadcrumb-item active"><a href="#ubicacion">Ubicación</a></li>
            <li class="breadcrumb-item active"><a href="#imagenesVideo">Imágenes y video</a></li>
            <li class="breadcrumb-item active"><a href="#btnAccion">Botones de acción</a></li>

        </ol>
        <div class="row">
            <div class="mb-5 mt-5">
                <h2 class="h1">Ubicación</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlDepartamentos" class="form-label">Departamento</label>
                    <asp:DropDownList runat="server" ID="ddlDepartamentos" CssClass="form-select" OnSelectedIndexChanged="guardarEnSesion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Este campo es requerido" CssClass="text-danger" InitialValue=""
                        ControlToValidate="ddlDepartamentos" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlLocalidades" class="form-label">Localidad</label>
                    <asp:DropDownList runat="server" ID="ddlLocalidades" CssClass="form-select" OnSelectedIndexChanged="guardarEnSesion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Este campo es requerido" CssClass="text-danger" InitialValue=""
                        ControlToValidate="ddlLocalidades" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlPueblos" class="form-label">Barrio</label>
                    <asp:DropDownList runat="server" ID="ddlPueblos" CssClass="form-select" OnSelectedIndexChanged="guardarEnSesion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Este campo es requerido" CssClass="text-danger" InitialValue=""
                        ControlToValidate="ddlPueblos" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <%if (seleccionada is null)
                        {
                    %>
                    <div class="mb-3">
                        <p>No se ha seleccionado una ubicación para esta propiedad</p>
                    </div>
                    <% }
                        else if (string.IsNullOrEmpty(seleccionada.Ubicacion))
                        { %>
                    <div class="mb-3">
                        <p>No se ha seleccionado una ubicación para esta propiedad</p>
                    </div>
                    <% } %>
                    <div class="mb-3">
                        <label for="tbxUbicacion" class="form-label">Cargar URL de la ubicación</label>
                        <asp:TextBox runat="server" ID="tbxUbicacion" CssClass="form-control" OnTextChanged="guardarEnSesion_TextChanged" />
                    </div>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="mb-3">
                    <%if (!IsPostBack && !cargarNuevo)
                        {
                            if (seleccionada != null)
                            {
                                if (seleccionada.Ubicacion != null)
                                { %>
                    <iframe src="<%:seleccionada.Ubicacion %>"
                        width="600" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>

                    <%          }
                            }
                        }%>
                </div>
            </div>
        </div>
        <hr id="imagenesVideo" />

        <%--Sección imágenes y video--%>
        <ol class="breadcrumb mb-4">
            <li class="breadcrumb-item">Panel</li>
            <li class="breadcrumb-item active">Nueva propiedad</li>
            <li class="breadcrumb-item active"><a href="#datosprincipales">Datos principales</a></li>
            <li class="breadcrumb-item active"><a href="#caracteristicas">Características</a></li>
            <li class="breadcrumb-item active"><a href="#ubicacion">Ubicación</a></li>
            <li class="breadcrumb-item active"><a href="#imagenesVideo">Imágenes y video</a></li>
            <li class="breadcrumb-item active"><a href="#btnAccion">Botones de acción</a></li>

        </ol>
        <div class="row">
            <div class="mb-5 mt-5">
                <h2 class="h1">Imágenes y video</h2>
            </div>
        </div>
<%--        <asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
                <div class="row">
                    <div class="col-lg-4">
                        <div class="mb-3">
                            <label for="inpImagen" class="form-label">Seleccionar imágenes</label>
                            <asp:FileUpload runat="server" ID="fupImagenes" CssClass="form-control" AllowMultiple="true" />
                        </div>
                        <div class="mb-3">
                            <label for="inpPalabrasClave" class="form-label">Palabras clave</label>
                            <asp:TextBox runat="server" ID="tbxPalabrasClave" CssClass="form-control" OnTextChanged="guardarEnSesion_TextChanged" />
                            <asp:RequiredFieldValidator ErrorMessage="Este campo no puede estar vacío" CssClass="text-danger" InitialValue=""
                                ControlToValidate="tbxPalabrasClave" runat="server" />
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Cargar" ID="btnCargarImagenesImagenes" runat="server" CssClass="btn btn-primary"
                                OnClick="btnCargarImagenesImagenes_Click" />
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="contenedor-imagenes">
                            <asp:Repeater runat="server" ID="repImagenes">
                                <ItemTemplate>
                                    <div class="imagen-item col-3">
                                        <img src="<%#Eval("Ruta") %>" class="img-thumbnail mb-3" alt="<%#Eval("Alt") %>" onclick="seleccionarImagen(this)" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <%if (seleccionada is null)
                        {
                    %>
                    <div class="mb-3">
                        <p>No se ha seleccionado un video para esta propiedad</p>
                    </div>
                    <% }
                        else if (seleccionada.Video is null || seleccionada.Video == "")
                        { %>
                    <div class="mb-3">
                        <p>No se ha seleccionado un video para esta propiedad</p>
                    </div>
                    <% } %>
                    <div class="mb-3">
                        <label for="tbxVideo" class="form-label">Cargar URL de video</label>
                        <asp:TextBox runat="server" ID="tbxVideo" CssClass="form-control" OnTextChanged="guardarEnSesion_TextChanged" />
                    </div>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="mb-3">
                    <%if (!IsPostBack && !cargarNuevo)
                        {
                            if (seleccionada != null)
                            {
                                if (seleccionada.Video != null)
                                { %>
                    <iframe width="560" height="315" src="<%: seleccionada.Video %>"
                        title="YouTube video player" frameborder="0"
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                        referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
                    <%          }
                            }
                        }%>
                </div>
            </div>
        </div>

        <hr id="btnAccion" />
        <%--Botones de acción--%>
        <ol class="breadcrumb mb-4">
            <li class="breadcrumb-item">Panel</li>
            <li class="breadcrumb-item active">Nueva propiedad</li>
            <li class="breadcrumb-item active"><a href="#datosprincipales">Datos principales</a></li>
            <li class="breadcrumb-item active"><a href="#caracteristicas">Características</a></li>
            <li class="breadcrumb-item active"><a href="#ubicacion">Ubicación</a></li>
            <li class="breadcrumb-item active"><a href="#imagenesVideo">Imágenes y video</a></li>
            <li class="breadcrumb-item active"><a href="#btnAccion">Botones de acción</a></li>

        </ol>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <% if (cargarNuevo)
                        { %>
                    <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-success form-control mb-3" runat="server"
                        OnClick="btnAgregar_Click" />
                    <% }
                        else
                        { %>
                    <asp:Button ID="btnModificar" Text="Modificar" CssClass="btn btn-primary form-control mb-3" runat="server"
                        OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger form-control mb-3" runat="server"
                        OnClick="btnEliminar_Click" />
                    <% } %>
                    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary form-control mb-3" runat="server" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
        <hr />
    </div>
    <script>
        function seleccionarImagen(img) {
            // Guardar ruta relativa de imágen seleccionada
            let rutaImagen = img.src.replace(window.location.origin, '');

            // Dar estilo de seleccion a la imagen y obiar las demás
            const todasLasImagenes = document.querySelectorAll('.img-thumbnail');
            todasLasImagenes.forEach(imagen => imagen.classList.remove('seleccionada'));
            img.classList.add('seleccionada');

            console.log("Imagen seleccionada: " + rutaImagen);

            // Eliminar botones existentes en otras imágenes
            const botonesExistentes = document.querySelectorAll('.botones-imagen');
            botonesExistentes.forEach(boton => boton.remove());

            // Crear contenedor para botones
            const contenedor = document.createElement('div');
            contenedor.className = 'botones-imagen';

            // Boton "Definir como principal"
            const botonPrincipal = document.createElement('button');
            botonPrincipal.innerText = 'Imagen principal';
            botonPrincipal.className = 'btn btn-primary btn-sm mb-1';
            botonPrincipal.onclick = function () {
                __doPostBack('btnDefinirPrincipal', rutaImagen);
            };

            // Boton "Quitar imagen"
            const botonQuitar = document.createElement('button');
            botonQuitar.innerText = 'Quitar imagen';
            botonQuitar.className = 'btn btn-danger btn-sm ms-2';
            botonQuitar.onclick = function () {
                __doPostBack('btnQuitarImagen', rutaImagen);
            };

            // Añadir botones al contenedor
            contenedor.appendChild(botonPrincipal);
            contenedor.appendChild(botonQuitar);

            //Añadir contenedor a la imagen
            img.parentElement.style.position = 'relative';
            img.parentElement.appendChild(contenedor);
        }
    </script>
</asp:Content>
