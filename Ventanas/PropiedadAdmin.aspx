<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PropiedadAdmin.aspx.cs" Inherits="Ventanas.PropiedadAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bio {
            height: 100px;
        }

        .descripcion {
            height: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="margin-top container">

        <%--Sección principal--%>

        <div class="row">
            <div class="pt-3 mb-5">
                <h1>Datos principales</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxCodigo" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="tbxCodigo" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Este campo es requerido" ControlToValidate="tbxCodigo" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="tbxTitulo" class="form-label">Título</label>
                    <asp:TextBox runat="server" ID="tbxTitulo" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Este campo es requerido" ControlToValidate="tbxTitulo" runat="server" />
                </div>

            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlTipoPropiedad" class="form-label">Tipo de Propiedad</label>
                    <asp:DropDownList runat="server" ID="ddlTipoPropiedad" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Este campo es requerido"
                        ControlToValidate="ddlTipoPropiedad" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="ddlTipoContrato" class="form-label">Tipo de Contrato</label>
                    <asp:DropDownList runat="server" ID="ddlTipoContrato" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Este campo es requerido"
                        ControlToValidate="ddlTipoContrato" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlMoneda" class="form-label">Moneda</label>
                    <asp:DropDownList runat="server" CssClass="form-select" ID="ddlMoneda">
                        <asp:ListItem Text="" Selected="True" />
                        <asp:ListItem Text="US$" />
                        <asp:ListItem Text="$" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Este campo es requerido"
                        ControlToValidate="ddlMoneda" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="tbxPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="tbxPrecio" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Este campo es requerido" ControlToValidate="tbxPrecio" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <asp:CheckBox ID="chbxDestacado" Text="Destacado" CssClass="form-check ps-0" Checked="false" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <asp:CheckBox ID="chbxActivo" Text="Activo" CssClass="form-check ps-0" Checked="true" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="mb-3">
                    <label for="tbxBio" class="form-label">Bio</label>
                    <asp:TextBox runat="server" ID="tbxBio" CssClass="bio form-control" TextMode="MultiLine"/>
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
                                OnTextChanged="tbxDescripcion_TextChanged" AutoPostBack="true" />
                            <asp:RegularExpressionValidator ErrorMessage="Máximo 1500 caracteres"
                                ValidationExpression="^.{0,1500}$"
                                ControlToValidate="tbxDescripcion" runat="server" CssClass="text-danger" />
                            <label><%: contadorCaracteres %>/1500 caracteres</label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <hr />
        <%--Sección características--%>

        <div class="row">
            <div class="mb-5 mt-5">
                <h2 class="h1">Características</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxAmbientes" class="form-label"><i class="fa-solid fa-door-open pe-2"></i>Ambientes</label>
                    <asp:TextBox runat="server" ID="tbxAmbientes" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Seleccione una cantidad" InitialValue="" ControlToValidate="tbxAmbientes" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxDormitorios" class="form-label"><i class="fa-solid fa-bed pe-2"></i>Dormitorios</label>
                    <asp:TextBox runat="server" ID="tbxDormitorios" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator CssClass="text-danger" InitialValue="" ErrorMessage="Seleccione una cantidad" ControlToValidate="tbxDormitorios" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxBaños" class="form-label"><i class="fa-solid fa-bath pe-2"></i>Baños</label>
                    <asp:TextBox runat="server" ID="tbxBaños" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue="" ControlToValidate="tbxBaños" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxMetrosTotales" class="form-label"><i class="fa-solid fa-ruler-combined pe-2"></i>M² totales</label>
                    <asp:TextBox runat="server" ID="tbxMetrosTotales" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue="" ControlToValidate="tbxMetrosTotales" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxMetrosCubiertos" class="form-label"><i class="fa-solid fa-house pe-2"></i>M² cubiertos</label>
                    <asp:TextBox runat="server" ID="tbxMetrosCubiertos" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue=""
                        ControlToValidate="tbxMetrosCubiertos" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxPlantas" class="form-label"><i class="fa-solid fa-stairs pe-2"></i>Plantas</label>
                    <asp:TextBox runat="server" ID="tbxPlantas" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue=""
                        ControlToValidate="tbxPlantas" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="tbxCocheras" class="form-label"><i class="fa-solid fa-car pe-2"></i>Cocheras</label>
                    <asp:TextBox runat="server" ID="tbxCocheras" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="Seleccione una cantidad" CssClass="text-danger" InitialValue=""
                        ControlToValidate="tbxCocheras" runat="server" />
                </div>
            </div>
        </div>
        <hr />
        <%--Sección ubicación--%>

        <div class="row">
            <div class="mb-5 mt-5">
                <h2 class="h1">Ubicación</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlDepartamentos" class="form-label">Departamento</label>
                    <asp:DropDownList runat="server" ID="ddlDepartamentos" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Este campo es requerido" CssClass="text-danger" InitialValue=""
                        ControlToValidate="ddlDepartamentos" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlLocalidades" class="form-label">Localidad</label>
                    <asp:DropDownList runat="server" ID="ddlLocalidades" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Este campo es requerido" CssClass="text-danger" InitialValue=""
                        ControlToValidate="ddlLocalidades" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="ddlPueblos" class="form-label">Barrio</label>
                    <asp:DropDownList runat="server" ID="ddlPueblos" CssClass="form-select"></asp:DropDownList>
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
                        <asp:TextBox runat="server" ID="tbxUbicacion" CssClass="form-control" />
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
                            width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    
                    <%          }
                            }
                        }%>
                </div>
            </div>
        </div>
        <hr />

        <%--Sección imágenes y video--%>
        <div class="row">
            <div class="mb-5 mt-5">
                <h2 class="h1">Imágenes y video</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3">
                    <label for="inpImagen" class="form-label">Seleccionar imágenes</label>
                    <asp:FileUpload runat="server" ID="fupImagenes" CssClass="form-control" AllowMultiple="true" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Cargar" ID="btnCargarImagenesImagenes" runat="server" CssClass="btn btn-primary"
                        OnClick="btnCargarImagenesImagenes_Click" />
                </div>
            </div>
            <div class="col-lg-8">
                <asp:Repeater runat="server" ID="repImagenes">
                    <ItemTemplate>
                        <img src="<%#Eval("Ruta") %>" class="img-thumbnail mb-3 col-3" alt="Imagen de propiedad" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
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
                        <asp:TextBox runat="server" ID="tbxVideo" CssClass="form-control" />
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

        <hr />
        <%--Botones de acción--%>
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
                    <% } %>
                    <a href="DefaultAdmin.aspx" class="btn btn-primary form-control mb-3">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
