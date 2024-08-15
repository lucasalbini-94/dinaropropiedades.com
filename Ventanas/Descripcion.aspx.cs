using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Ventanas
{
    public partial class Descripcion : System.Web.UI.Page
    {
        public List<Propiedades> listaPropiedades;
        public List<Imagenes> listaImagenes;
        public Propiedades seleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["listaPropiedades"] != null)
                {
                    // Obtener lista de propiedades de la sesión
                    listaPropiedades = (List<Propiedades>)Session["listaPropiedades"];
                }
                else
                {
                    PropiedadesNegocio propiedadesNegocio = new PropiedadesNegocio();
                    listaPropiedades = propiedadesNegocio.listar();
                }

                // Si se carga la página por primera vez
                if (!IsPostBack)
                {
                    // Capturar ID de la propiedad seleccionada
                    int id = int.Parse(Request.QueryString["id"]);

                    // Seleccionar propiedad de la lista por el ID
                    seleccionada = listaPropiedades.Find(x => x.Id == id);

                    // Cargar imágenes de la propiedad
                    ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
                    listaImagenes = imagenesNegocio.listar(id, false);

                    // Obtener la imagen principal
                    Imagenes principal = listaImagenes.Find(x => x.Principal == true);
                    seleccionada.ImagenPrincipal = principal.Ruta;

                    // Cargar Carrousel de imágenes con las imágenes de la propiedad
                    repImagenes.DataSource = listaImagenes.FindAll(x=> x.Principal == false);
                    repImagenes.DataBind();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("errorUser", error);
                Response.Redirect("ErrorUser.aspx");
            }
        }
    }
}