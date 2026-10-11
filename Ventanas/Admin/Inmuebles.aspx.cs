using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Ventanas.Admin
{
    public partial class Inmuebles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;

            if (!IsPostBack)
            {
                if (Request.QueryString["listar"] != null)
                {
                    string listar = Request.QueryString["listar"];
                    CargarLista(listar);
                }

                CargarLista();
            }

        }

        private void CargarLista(string listar = "")
        {
            try
            {
                PropiedadNegocio negocio = new PropiedadNegocio();
                switch (listar)
                {
                    case "inactivos":
                        rptPropiedades.DataSource = negocio.ListarTodas();
                        rptPropiedades.DataBind();
                        break;

                    case "vendidos":
                        rptPropiedades.DataSource = negocio.ListarTodas();
                        rptPropiedades.DataBind();
                        break;

                    case "destacados":
                        rptPropiedades.DataSource = negocio.ListarDestacadas();
                        rptPropiedades.DataBind();
                        break;

                    default:
                        rptPropiedades.DataSource = negocio.ListarTodas();
                        rptPropiedades.DataBind();
                        break;
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar las propiedades: {ex.Message}", "alert-danger");
            }

        }

        // Este evento se dispara cuando se hace click en los botones con "CommandName" dentro del Repeater
        protected void rptPropiedades_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idPropiedad = Convert.ToInt32(e.CommandArgument);

                try
                {
                    PropiedadNegocio negocio = new PropiedadNegocio();
                    negocio.Eliminar(idPropiedad);
                    MostrarMensaje("El inmueble fué dado de baja exitosamente.", "alert-success");
                    CargarLista();
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"No se pudo dar de baja al inmueble: {ex.Message}", "alert-danger");
                }
            }
        }

        private void MostrarMensaje(string texto, string claseBootstrap)
        {
            lblMensaje.Text = texto;
            lblMensaje.CssClass = $"alert {claseBootstrap} d-block mb-3";
            lblMensaje.Visible = true;
        }
    }
}