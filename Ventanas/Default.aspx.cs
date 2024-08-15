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
    public partial class Default : System.Web.UI.Page
    {
        private List<Propiedades> listaPropiedades;
        private List<Propiedades> listaDestacadas;
        private List<Imagenes> listaImagenes;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Crear instancias a objetos necesarias
            PropiedadesNegocio propiedadesNegocio = new PropiedadesNegocio();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

            try
            {
                // Si la página se carga por primera vez
                if (!IsPostBack)
                {
                    // Listar propiedades
                    listaPropiedades = propiedadesNegocio.listar();
                    // Filtrar destacadas
                    listaDestacadas = listaPropiedades.FindAll(x => x.Destacado == true);
                    //Listar Imagenes
                    listaImagenes = imagenesNegocio.listar(-1, true);

                    foreach (Propiedades propiedad in listaDestacadas)
                    {
                        Imagenes img = new Imagenes();
                        img = listaImagenes.Find(x => x.IdPropiedad == propiedad.Id);
                        propiedad.ImagenPrincipal = img.Ruta;
                    }

                    // Cargar lista filtrada en el repeater
                    repDestacados.DataSource = listaDestacadas;
                    repDestacados.DataBind();

                    Session.Add("listaPropiedades", listaPropiedades);
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