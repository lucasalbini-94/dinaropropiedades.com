using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Ventanas
{
    public partial class DafaultAdmin : System.Web.UI.Page
    {
        private List<Propiedades> listaPropiedades;
        private List<Propiedades> listaFiltrada;
        private List<TipoContrato> listaTipoContrato;
        private List<TipoPropiedad> listaTipoPropiedad;
        private List<Departamentos> listaDepartamentos;
        private List<Localidades> listaLocalidades;
        private List<Pueblos> listaPueblos;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay sesion activa
                if (Session["sesionActiva"] is null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                PropiedadesNegocio negocioProp = new PropiedadesNegocio();
                TipoContratoNegocio negocioTipoCon = new TipoContratoNegocio();
                TipoPropiedadNegocio negocioTipoProp = new TipoPropiedadNegocio();
                DptoNegocio negocioDpto = new DptoNegocio();
                LocalidadesNegocio negocioLocal = new LocalidadesNegocio();
                PueblosNegocio negocioPueblo = new PueblosNegocio();
                listaPropiedades = new List<Propiedades>();
                listaTipoContrato = new List<TipoContrato>();
                listaTipoPropiedad = new List<TipoPropiedad>();
                listaDepartamentos = new List<Departamentos>();
                listaLocalidades = new List<Localidades>();
                listaPueblos = new List<Pueblos>();

                if (!IsPostBack)
                {

                    // Cargar tabla

                    listaPropiedades = negocioProp.listar();
                    dgvListaPropiedades.DataSource = listaPropiedades;
                    dgvListaPropiedades.DataBind();

                    // Cargar desplegables
                    // Tipo de contrato

                    listaTipoContrato = negocioTipoCon.listar();
                    ddlTipoContrato.DataSource = listaTipoContrato;
                    ddlTipoContrato.DataTextField = "Descripcion";
                    ddlTipoContrato.DataValueField = "Id";
                    ddlTipoContrato.DataBind();

                    // Tipo de propiedad

                    listaTipoPropiedad = negocioTipoProp.listar();
                    ddlTipoPropiedad.DataSource = listaTipoPropiedad;
                    ddlTipoPropiedad.DataTextField = "Descripcion";
                    ddlTipoPropiedad.DataValueField = "Id";
                    ddlTipoPropiedad.DataBind();

                    // Departamentos

                    listaDepartamentos = negocioDpto.listar();
                    ddlDepartamentos.DataSource = listaDepartamentos;
                    ddlDepartamentos.DataTextField = "Descripcion";
                    ddlDepartamentos.DataValueField = "Id";
                    ddlDepartamentos.DataBind();

                    // Localidades

                    listaLocalidades = negocioLocal.listar();
                    ddlLocalidades.DataSource = listaLocalidades;
                    ddlLocalidades.DataTextField = "Descripcion";
                    ddlLocalidades.DataValueField = "Id";
                    ddlLocalidades.DataBind();

                    // Pueblos

                    listaPueblos = negocioPueblo.listar();
                    ddlPueblos.DataSource = listaPueblos;
                    ddlPueblos.DataTextField = "Descripcion";
                    ddlPueblos.DataValueField = "Id";
                    ddlPueblos.DataBind();
                }
                else
                {
                    listaPropiedades = negocioProp.listar();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorAdmin.aspx");
            }

        }

        protected void dgvListaPropiedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guardar Id de la propiedad seleccionada
            string id = dgvListaPropiedades.SelectedDataKey.Value.ToString();

            //Filtrar lista y obtener la propiedad por Id
            Propiedades seleccionada = listaPropiedades.Find(x => x.Id == int.Parse(id));

            //Guardar propiedad en sesión
            Session.Add("propiedadSeleccionada", seleccionada);

            //Redirigir a página de administración con id por URL
            Response.Redirect("PropiedadAdmin.aspx?id=" + id);
        }

        protected void dgvListaPropiedades_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            dgvListaPropiedades.PageIndex = e.NewPageIndex;
            dgvListaPropiedades.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = tbxBuscar.Text;
            listaFiltrada = listaPropiedades.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()));
            dgvListaPropiedades.DataSource = listaFiltrada;
            dgvListaPropiedades.DataBind();
        }
    }
}