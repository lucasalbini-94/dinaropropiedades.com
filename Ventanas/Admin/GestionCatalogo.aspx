<%@ Page Title="Gestión de Catálogo" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="GestionCatalogo.aspx.cs" Inherits="Ventanas.Admin.GestionCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style-lista-inmueble.css" rel="stylesheet" />
    <link href="../css/style-catalogo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--ScriptManager para permitir actualización parcial con AJAX--%>
    <asp:ScriptManager ID="smPrincipal" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="upPrincipal" runat="server">
        <ContentTemplate>
            <%--Barra superior--%>
            <div class="barra-superior-container">
                <div class="barra-superior">
                    Catálogos / <b>
                        <asp:Literal ID="litTituloSeccion" runat="server">Catálogo</asp:Literal></b>
                </div>
                <div class="acciones-superiores">
                    <div class="controles-tabla">
                        <label for="registrosPorPagina">Mostrar:</label>
                        <select id="registrosPorPagina" class="select-paginacion">
                            <option value="5">5</option>
                            <option value="10" selected>10</option>
                            <option value="25">25</option>
                        </select>
                    </div>
                    <asp:LinkButton ID="btnNuevoItem" runat="server" CssClass="btn btn-success" OnClick="btnNuevoItem_Click">
                        <i class="fas fa-plus"></i>
                        <asp:Literal ID="litBotonNuevo" runat="server"> Nuevo</asp:Literal>
                    </asp:LinkButton>
                </div>
            </div>

            <%--Tabla Adaptable--%>
            <table class="tabla-inmuebles tabla-responsive" id="tablaInmuebles">
                <thead>
                    <tr>
                        <th style="width: 70px;">ID</th>
                        <th>Descripción</th>
                        <%--Columna condicional para atributos especiales--%>
                        <asp:PlaceHolder ID="phHeaderExtra" runat="server" Visible="false">
                            <th>
                                <asp:Literal ID="litNombreColumnaExtra" runat="server"></asp:Literal></th>
                        </asp:PlaceHolder>
                        <th style="width: 120px">Estado</th>
                        <th style="width: 120px">Acciones</th>
                    </tr>
                </thead>
                <tbody id="tablaBody">
                    <asp:Repeater ID="rptCatalogo" runat="server" OnItemCommand="rptCatalogo_ItemCommand">
                        <ItemTemplate>
                            <tr class="propiedad-row">
                                <%--Id: en el móvil actúa como la celda cabecera de la tarjeta--%>
                                <td class="col-foto">#<%# Eval("Id") %>
                                </td>
                                <td class="col-titulo" data-label="Descripcion">
                                    <div class="header-movil-wrap">
                                        <span class="titulo-texto"><%# Eval("Descripcion") %></span>
                                    </div>
                                </td>
                                <% if (TieneColumnaExtra)
                                    { %>
                                <td data-label="<%= NombreColumnaExtra %>">
                                    <% if (EsCatalogoEstado)
                                        { %>
                                    <div style="display: flex; align-items: center; gap: 8px;">
                                        <span style="display: inline-block; width: 22px; height: 22px; border-radius: 50%; background-color: <%# Eval("Color") %>; border: 1px solid #ccc;"></span>
                                        <code><%# Eval("Color") %></code>
                                    </div>
                                    <% } %>
                                    <% if (EsCatalogoCaracteristica)
                                        { %>
                                    <div style="display: flex; align-items: center; gap: 8px;">
                                        <i class="fas <%# Eval("Icono") %>" style="font-size: 1.2rem;"></i>
                                    </div>
                                    <% } %>
                                    <% if (EsCatalogoBarrioOTipo)
                                        { %>
                                    <div style="display: flex; align-items: center; gap: 8px;">
                                        <span><%# Eval("Sigla") %></span>
                                    </div>
                                    <% } %>
                                </td>
                                <% } %>

                                <!-- Estado Activo / Inactivo -->
                                <td data-label="Estado">
                                    <span class='badge <%# (bool)Eval("Activo") ? "badge-disponible" : "badge-vendido" %>'>
                                        <%# (bool)Eval("Activo") ? "Activo" : "Inactivo" %>
                            </span>
                                </td>

                                <!-- Botones de Acción -->
                                <td class="col-acciones" data-label="Acciones">
                                    <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" title="Editar">
                                <i class="fas fa-edit"></i>
                            </asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" title="Eliminar" OnClientClick="return confirm('¿Seguro que deseas dar de baja este registro?');">
                                <i class="fas fa-trash"></i>
                            </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="paginacion-container" id="paginacionContainer"></div>

            <!-- TELÓN DE FONDO (BACKDROP) -->
            <asp:Panel ID="pnlOverlay" runat="server" CssClass="drawer-overlay" Visible="false" />

            <!-- PANEL LATERAL DESLIZANTE (FORMULARIO ALTA / MODIFICACIÓN) -->
            <asp:Panel ID="pnlDrawer" runat="server" CssClass="drawer-container" Visible="false">
                <div class="drawer-header">
                    <h3>
                        <i class="fas fa-sliders-h"></i>
                        <asp:Literal ID="litTituloDrawer" runat="server">Registro</asp:Literal>
                    </h3>
                    <asp:LinkButton ID="btnCerrar" runat="server" CssClass="btn-cerrar-drawer" OnClick="btnCancelar_Click" CausesValidation="false">
                        <i class="fas fa-times"></i>
                    </asp:LinkButton>
                </div>

                <div class="drawer-body">
                    <asp:HiddenField ID="hfIdRegistro" runat="server" Value="0" />

                    <div>
                        <label class="form-label" for="txtDescripcion">Descripción / Nombre *</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Ej: Departamento, Alquiler, Pileta..." />
                    </div>

                    <!-- Campo específico para Barrio o Tipo de Propiedad: Ingresar Sigla -->
                    <asp:PlaceHolder ID="phSigla" runat="server" Visible="false">
                        <div>
                            <label class="form-label" for="txtSigla">Sigla Identificadora</label>
                            <div class="form-color-wrap">
                                <asp:TextBox ID="txtSigla" runat="server" CssClass="form-control"/>
                                <small style="color: #718096;">Sigla para código</small>
                            </div>
                        </div>
                    </asp:PlaceHolder>

                    <!-- Campo específico para Estado: Selección de Color -->
                    <asp:PlaceHolder ID="phCampoColor" runat="server" Visible="false">
                        <div>
                            <label class="form-label" for="txtColor">Color Identificador</label>
                            <div class="form-color-wrap">
                                <asp:TextBox ID="txtColor" runat="server" TextMode="Color" CssClass="form-control input-color" Value="#28a745" />
                                <small style="color: #718096;">Color de etiqueta para listados</small>
                            </div>
                        </div>
                    </asp:PlaceHolder>

                    <!-- Campo específico para Característica: Clase Font Awesome -->
                    <asp:PlaceHolder ID="phCampoIcono" runat="server" Visible="false">
                        <div>
                            <label class="form-label" for="txtIcono">Clase Ícono FontAwesome</label>
                            <asp:TextBox ID="txtIcono" runat="server" CssClass="form-control" placeholder="Ej: fa-wifi, fa-swimming-pool" />
                            <small style="color: #718096;">Nombre del ícono (sin el prefijo "fas")</small>
                        </div>
                    </asp:PlaceHolder>

                    <div>
                        <label class="form-label">Estado de Publicación</label>
                        <asp:CheckBox ID="chkActivo" runat="server" Text=" &nbsp;Activo y disponible" Checked="true" />
                    </div>
                </div>

                <div class="drawer-footer">
                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false">
                        Cancelar
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click">
                        <i class="fas fa-save"></i> Guardar
                    </asp:LinkButton>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>