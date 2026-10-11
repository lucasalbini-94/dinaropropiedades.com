using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Ventanas.Admin.Modelos;

namespace Ventanas.Admin
{
    public partial class GestionCatalogo : System.Web.UI.Page
    {
        // Propiedades accesibles desde el markup ASPX
        public bool TieneColumnaExtra { get; set; } = false;
        public string NombreColumnaExtra { get; set; } = "";
        public bool EsCatalogoEstado { get; set; } = false;
        public bool EsCatalogoCaracteristica { get; set; } = false;
        public bool EsCatalogoBarrioOTipo { get; set; } = false;

        private string TipoCatalogo
        {
            get { return Request.QueryString["tipo"] != null ? Request.QueryString["tipo"].ToLower() : "propiedad"; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigurarTipoCatalogo();

            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void ConfigurarTipoCatalogo()
        {
            switch (TipoCatalogo)
            {
                case "estado":
                    litTituloSeccion.Text = "Estado de Propiedad";
                    litBotonNuevo.Text = "Nuevo Estado";
                    TieneColumnaExtra = true;
                    NombreColumnaExtra = "Color Asignado";
                    EsCatalogoEstado = true;
                    break;

                case "caracteristica":
                    litTituloSeccion.Text = "Características / Amenities";
                    litBotonNuevo.Text = "Nueva Característica";
                    TieneColumnaExtra = true;
                    NombreColumnaExtra = "Ícono";
                    EsCatalogoCaracteristica = true;
                    break;

                case "contrato":
                    litTituloSeccion.Text = "Tipos de Contrato";
                    litBotonNuevo.Text = "Nuevo Contrato";
                    TieneColumnaExtra = false;
                    break;

                case "barrio":
                    litTituloSeccion.Text = "Barrios";
                    litBotonNuevo.Text = "Nuevo Barrio";
                    NombreColumnaExtra = "Sigla";
                    TieneColumnaExtra = true;
                    EsCatalogoBarrioOTipo = true;
                    break;

                case "propiedad":
                    litTituloSeccion.Text = "Tipos de Propiedad";
                    litBotonNuevo.Text = "Nuevo Tipo";
                    NombreColumnaExtra = "Sigla";
                    TieneColumnaExtra = true;
                    EsCatalogoBarrioOTipo = true;
                    break;

                default:
                    litTituloSeccion.Text = "Tipos de Inmueble";
                    litBotonNuevo.Text = "Nuevo Tipo";
                    TieneColumnaExtra = false;
                    break;
            }

            // Cabecera en modo escritorio
            phHeaderExtra.Visible = TieneColumnaExtra;
            litNombreColumnaExtra.Text = NombreColumnaExtra;
        }

        private void CargarDatos()
        {
            List<ItemCatalogoViewModel> listaGrid = new List<ItemCatalogoViewModel>();

            switch (TipoCatalogo)
            {
                case "estado":
                    var estadoNegocio = new EstadoPropiedadNegocio();
                    listaGrid = estadoNegocio.ListarTodos().Select(e => new ItemCatalogoViewModel
                    {
                        Id = e.Id,
                        Descripcion = e.Descripcion,
                        Activo = e.Activo,
                        Color = !string.IsNullOrEmpty(e.Color) ? e.Color : "#6c757d"
                    }).ToList();
                    break;

                case "caracteristica":
                    var caracNegocio = new CaracteristicaNegocio();
                    listaGrid = caracNegocio.ListarTodas().Select(c => new ItemCatalogoViewModel
                    {
                        Id = c.Id,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo,
                        Icono = !string.IsNullOrEmpty(c.Icono) ? c.Icono : "fa-check"
                    }).ToList();
                    break;

                case "contrato":
                    var contratoNegocio = new TipoContratoNegocio();
                    listaGrid = contratoNegocio.ListarTodos().Select(t => new ItemCatalogoViewModel
                    {
                        Id = t.Id,
                        Descripcion = t.Descripcion,
                        Activo = t.Activo
                    }).ToList();
                    break;

                case "barrio":
                    var barrioNegocio = new BarrioNegocio();
                    listaGrid = barrioNegocio.ListarTodos().Select(b => new ItemCatalogoViewModel
                    {
                        Id = b.Id,
                        Descripcion = b.Descripcion,
                        Activo = b.Activo,
                        Sigla = b.Sigla
                    }).ToList();
                    break;

                case "propiedad":
                    var tipoPropiedadNegocio = new TipoPropiedadNegocio();
                    listaGrid = tipoPropiedadNegocio.ListarTodas().Select(tp => new ItemCatalogoViewModel{
                        Id = tp.Id,
                        Descripcion = tp.Descripcion,
                        Activo = tp.Activo,
                        Sigla = tp.Sigla
                    }).ToList();
                    break;

                default:
                    var tipoPropNegocio = new TipoPropiedadNegocio();
                    listaGrid = tipoPropNegocio.ListarTodas().Select(p => new ItemCatalogoViewModel
                    {
                        Id = p.Id,
                        Descripcion = p.Descripcion,
                        Activo = p.Activo
                    }).ToList();
                    break;
            }

            rptCatalogo.DataSource = listaGrid;
            rptCatalogo.DataBind();
        }

        protected void btnNuevoItem_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            litTituloDrawer.Text = "Nuevo registro";
            AbrirDrawer();
        }

        protected void rptCatalogo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                // Invocar baja lógica según TipoCatálogo
                CargarDatos();
            }
            else if (e.CommandName == "Editar")
            {
                CargarRegistroParaEdicion(id);
                litTituloDrawer.Text = "Editar registro #" + id;
                AbrirDrawer();
            }
        }

        private void CargarRegistroParaEdicion(int id)
        {
            hfIdRegistro.Value = id.ToString();

            switch (TipoCatalogo)
            {
                case "estado":
                    var est = new EstadoPropiedadNegocio().ObtenerPorId(id);
                    txtDescripcion.Text = est.Descripcion;
                    chkActivo.Checked = est.Activo;
                    phCampoColor.Visible = true;
                    txtColor.Text = est.Color;
                    break;

                case "caracteristica":
                    var car = new CaracteristicaNegocio().ObtenerPorId(id);
                    txtDescripcion.Text = car.Descripcion;
                    chkActivo.Checked = car.Activo;
                    phCampoIcono.Visible = true;
                    txtIcono.Text = car.Icono;
                    break;

                case "contrato":
                    var con = new TipoContratoNegocio().ObtenerPorId(id);
                    txtDescripcion.Text = con.Descripcion;
                    chkActivo.Checked = con.Activo;
                    break;

                case "barrio":
                    var bar = new BarrioNegocio().ObtenerPorId(id);
                    txtDescripcion.Text = bar.Descripcion;
                    chkActivo.Checked = bar.Activo;
                    phSigla.Visible = true;
                    txtSigla.Text = bar.Sigla;
                    break;

                default:
                    var tip = new TipoPropiedadNegocio().ObtenerPorId(id);
                    txtDescripcion.Text = tip.Descripcion;
                    chkActivo.Checked = tip.Activo;
                    break;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hfIdRegistro.Value);
            string descripcion = txtDescripcion.Text.Trim();
            bool activo = chkActivo.Checked;

            switch (TipoCatalogo)
            {
                case "estado":
                    var estNeg = new EstadoPropiedadNegocio();
                    var est = new EstadoPropiedad { Id = id, Descripcion = descripcion, Activo = activo, Color = txtColor.Text };
                    if (id == 0) estNeg.Guardar(est); else estNeg.Modificar(est);
                    break;

                case "caracteristica":
                    var carNeg = new CaracteristicaNegocio();
                    var car = new Caracteristica { Id = id, Descripcion = descripcion, Activo = activo, Icono = txtIcono.Text.Trim() };
                    carNeg.Guardar(car);
                    break;

                case "contrato":
                    var conNeg = new TipoContratoNegocio();
                    var con = new TipoContrato { Id = id, Descripcion = descripcion, Activo = activo };
                    if (id == 0) conNeg.Guardar(con); else conNeg.Modificar(con);
                    break;

                case "barrio":
                    var barNeg = new BarrioNegocio();
                    var bar = new Barrio { Id = id, Descripcion = descripcion, Activo = activo, Sigla = txtSigla.Text.Trim() };
                    if (id == 0) barNeg.Guardar(bar); else barNeg.Modificar(bar);
                    break;

                default:
                    var tipNeg = new TipoPropiedadNegocio();
                    var tip = new TipoPropiedad { Id = id, Descripcion = descripcion, Activo = activo, Sigla = txtSigla.Text.Trim() };
                    if (id == 0) tipNeg.Guardar(tip); else tipNeg.Modificar(tip);
                    break;
            }

            CerrarDrawer();
            CargarDatos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarDrawer();
        }

        private void AbrirDrawer()
        {
            pnlOverlay.Visible = true;
            pnlDrawer.Visible = true;
            pnlDrawer.CssClass = "drawer-container abierto";
            if (EsCatalogoBarrioOTipo)
            {
                phSigla.Visible = true;
                txtSigla.Attributes["placeholder"] = "Ej: CS, CB, LT...";
            }
            if (EsCatalogoCaracteristica)
            {
                phCampoIcono.Visible = true;
                txtIcono.Attributes["placeholder"] = "Ej: fa-wifi, fa-swimming-pool";
            }
            if (EsCatalogoEstado)
            {
                phCampoColor.Visible = true;
            }
        }

        private void CerrarDrawer()
        {
            pnlOverlay.Visible = false;
            pnlDrawer.Visible = false;
            pnlDrawer.CssClass = "drawer-container";
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hfIdRegistro.Value = "0";
            txtDescripcion.Text = string.Empty;
            txtColor.Text = "#28a745";
            txtIcono.Text = string.Empty;
            chkActivo.Checked = true;
        }
    }
}