<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="QR.aspx.cs" Inherits="Ventanas.QR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top">
        <div class="container">
            <h1>Generar QR</h1>
            <div class="mb-3">
                <label for="tbxUrl" class="form-label">Introduzca la URL de la propiedad</label>
                <div class="d-flex">
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbxUrl" />
                    <asp:RequiredFieldValidator ErrorMessage="Este campo es requerido" ControlToValidate="tbxUrl" runat="server"
                        CssClass="text-danger" />
                    <asp:Button Text="Generar" ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="mb-3">
                <label for="tbxRenombrar" class="form-label">Nombre del archivo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbxRenombrar"/>
            </div>
            <div>
                <asp:Image CssClass="mb-3" ID="imgQR" runat="server" />
                <div class="row">
                    <div class="col-2">
                        <asp:Button CssClass="btn btn-success" Text="Descargar" ID="btnDescargar" runat="server" OnClick="btnDescargar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
