<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DefaultAdmin.aspx.cs" Inherits="Ventanas.DafaultAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top container">
        <div class="row pt-3">
            <div class="col-lg-4">
                <h2 class="mb-3">Lista de Propiedades</h2>
            </div>
            <div class="col-lg-8 d-flex">
                <asp:TextBox runat="server" CssClass="form-control me-3" ID="tbxBuscar"/>
                <asp:Button CssClass="btn btn-success mt-1" Text="Buscar" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click"/>
            </div>
        </div>
        <div class="row">
            <asp:GridView ID="dgvListaPropiedades" CssClass="table mt-5 mb-3" AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvListaPropiedades_SelectedIndexChanged" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Título" DataField="Titulo" />
                    <asp:CheckBoxField HeaderText="Destacado" DataField="Destacado" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:BoundField HeaderText="Tipo" DataField="TipoPropiedad.Descripcion" />
                    <asp:BoundField HeaderText="Contrato" DataField="TipoContrato.Descripcion" />
                    <asp:BoundField HeaderText="Moneda" DataField="Moneda" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}"/>
                    <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="row">
            <div class="mt-5">
                <h2 class="h1 mb-3">Administrar desplegables</h2>
                <h3 class="mb-3">Propiedades y contratos</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3 d-flex">
                    <label for="ddlTipoPropiedad" class="form-label">Propiedad</label>
                    <asp:DropDownList runat="server" ID="ddlTipoPropiedad" CssClass="form-select ms-3 me-3"></asp:DropDownList>
                    <a href="Desplegables.aspx?campo=TP" class="btn btn-primary">Editar</a>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3 d-flex">
                    <label for="ddlTipoContrato" class="form-label">Contratos</label>
                    <asp:DropDownList runat="server" ID="ddlTipoContrato" CssClass="form-select ms-3 me-3"></asp:DropDownList>
                    <a href="Desplegables.aspx?campo=TC" class="btn btn-primary">Ediar</a>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mt-5">
                <h3 class="mb-3">Ubicaciónes</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="mb-3 d-flex">
                    <label for="ddlDepartamentos" class="form-label">Departamentos</label>
                    <asp:DropDownList runat="server" ID="ddlDepartamentos" CssClass="form-select ms-3 me-3"></asp:DropDownList>
                    <a href="Desplegables.aspx?campo=Dpto" class="btn btn-primary">Editar</a>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3 d-flex">
                    <label for="ddlLocalidades" class="form-label">Localidades</label>
                    <asp:DropDownList runat="server" ID="ddlLocalidades" CssClass="form-select ms-3 me-3"></asp:DropDownList>
                    <a href="Desplegables.aspx?campo=Loc" class="btn btn-primary">Editar</a>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="mb-3 d-flex">
                    <label for="ddlPueblos" class="form-label">Barrios</label>
                    <asp:DropDownList runat="server" ID="ddlPueblos" CssClass="form-select ms-3 me-3"></asp:DropDownList>
                    <a href="Desplegables.aspx?campo=Pue" class="btn btn-primary">Editar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
