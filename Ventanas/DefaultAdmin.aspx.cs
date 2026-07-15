using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.UI.HtmlControls;

namespace Ventanas
{
    public partial class DafaultAdmin : System.Web.UI.Page
    {
        private List<Propiedades> listaPropiedades;
        private List<Propiedades> listaFiltrada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesionActiva"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            PropiedadesNegocio negocioProp = new PropiedadesNegocio();

            listaPropiedades = new List<Propiedades>();

            if (!IsPostBack)
            {

                // Cargar tabla

                listaPropiedades = negocioProp.listar();
                listaPropiedades.Reverse();
                TableListView.DataSource = listaPropiedades;
                TableListView.DataBind();

            }
            else
            {
                listaPropiedades = negocioProp.listar();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (listaFiltrada != null)
                TableListView.DataSource = listaFiltrada;
            else
                TableListView.DataSource = listaPropiedades;
            TableListView.DataBind();
        }

        protected void TableListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    Propiedades propiedad = (Propiedades)e.Item.DataItem;
            //    // No necesitas FindControl aquí si Eval maneja todo en el lado del cliente

            //}
        }

        protected void TableListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarPropiedad")
            {
                // Obtén el ID de la propiedad desde CommandArgument
                string idPropiedad = e.CommandArgument.ToString();

                //Filtrar lista y obtener la propiedad por Id
                Propiedades seleccionada = listaPropiedades.Find(x => x.Id == int.Parse(idPropiedad));

                //Guardar propiedad en sesión
                Session.Add("propiedadSeleccionada", seleccionada);

                // Redirige a la página de PropiedadesAdmin con el ID en la URL
                Response.Redirect("PropiedadAdmin.aspx?id=" + idPropiedad);
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = tbxBuscar.Text.Trim();
            listaFiltrada = listaPropiedades.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()));
            TableListView.DataSource = listaFiltrada;
            TableListView.DataBind();

            lblTablaVacia.Text = listaFiltrada.Count > 0 ? "" : "No se encontraron resultados";
            lblTablaVacia.Visible = listaFiltrada.Count == 0;
        }
    }
}