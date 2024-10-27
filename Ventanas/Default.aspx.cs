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
                    listaPropiedades = propiedadesNegocio.listar().FindAll(x => x.Activo == true);
                    // Filtrar destacadas
                    listaDestacadas = listaPropiedades.FindAll(x => x.Destacado == true);
                    //Listar Imagenes principales
                    listaImagenes = imagenesNegocio.listar(-1, true);

                    foreach (Propiedades propiedad in listaDestacadas)
                    {
                        Imagenes img = new Imagenes();
                        img = listaImagenes.Find(x => x.IdPropiedad == propiedad.Id);

                        if (img != null)
                        {
                            if (!(string.IsNullOrEmpty(img.Ruta) && !string.IsNullOrEmpty(img.Alt)))
                            {
                                propiedad.ImagenPrincipal = img.Ruta;
                                propiedad.AltImagen = img.Alt;
                            }
                            else
                            {
                                img = Helper.imagenPlaceholder();
                                propiedad.AltImagen = img.Alt;
                                propiedad.ImagenPrincipal = img.Ruta;
                            }
                        }
                        else
                        {
                            img = Helper.imagenPlaceholder();
                            propiedad.AltImagen = img.Alt;
                            propiedad.ImagenPrincipal = img.Ruta;
                        }
                    }

                    TipoPropiedadNegocio tipoPropNegocio = new TipoPropiedadNegocio();
                    ddlTipoPropiedad.DataSource = tipoPropNegocio.listar();
                    ddlTipoPropiedad.DataTextField = "Descripcion";
                    ddlTipoPropiedad.DataValueField = "Id";
                    ddlTipoPropiedad.DataBind();
                    TipoContratoNegocio tipoContNegocio = new TipoContratoNegocio();
                    ddlTipoContrato.DataSource = tipoContNegocio.listar();
                    ddlTipoContrato.DataTextField = "Descripcion";
                    ddlTipoContrato.DataValueField = "Id";
                    ddlTipoContrato.DataBind();

                    // Cargar lista filtrada en el repeater
                    repDestacados.DataSource = listaDestacadas;
                    repDestacados.DataBind();

                    Session.Add("listaPropiedades", listaPropiedades);
                }

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorUser.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string contrato = ddlTipoContrato.SelectedValue;
                string propiedad = ddlTipoPropiedad.SelectedValue;
                Response.Redirect($"Lista.aspx?contrato={contrato}&propiedad={propiedad}", false);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorUser.aspx");
            }
        }
    }
}