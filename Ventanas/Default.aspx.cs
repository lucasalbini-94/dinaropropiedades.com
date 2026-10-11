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
        private readonly PropiedadNegocio _propiedadNegocio = new PropiedadNegocio();

        private const string tipoLote = "Lote";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPropiedadesDestacadas();
            }
        }

        private void CargarPropiedadesDestacadas()
        {
            try
            {
                List<Propiedad> listaDestacadas = _propiedadNegocio.ListarDestacadas();

                if(listaDestacadas != null && listaDestacadas.Count > 0)
                {
                    // Filtrar Lotes
                    var lotes = listaDestacadas
                        .Where(p => p.TipoPropiedad != null &&
                        p.TipoPropiedad.Descripcion.Equals(tipoLote, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    // Filtrar Viviendas
                    var viviendas = listaDestacadas
                        .Where(p => p.TipoPropiedad != null &&
                        !p.TipoPropiedad.Descripcion.Equals(tipoLote, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    // Enlazar Repeaters
                    repDestacadosViviendas.DataSource = viviendas;
                    repDestacadosViviendas.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar propiedades destacadas: {ex.Message}");
            }
        }
    }
}