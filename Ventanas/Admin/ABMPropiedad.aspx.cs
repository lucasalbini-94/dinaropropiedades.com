using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Servicios;

namespace Ventanas.Admin
{
    public partial class ABMPropiedad : System.Web.UI.Page
    {
        public int IdPropiedad = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();

                if (Request.QueryString["id"] != null)
                {
                    IdPropiedad = Convert.ToInt32(Request.QueryString["id"]);
                    CargarPropiedad(IdPropiedad);
                }
            }
        }

        public void CargarDatos()
        {
            TipoContratoNegocio tipoContratoNegocio = new TipoContratoNegocio();
            TipoPropiedadNegocio tipoPropiedadNegocio = new TipoPropiedadNegocio();
            EstadoPropiedadNegocio estadoPropiedadNegocio = new EstadoPropiedadNegocio();
            BarrioNegocio barrioNegocio = new BarrioNegocio();
            CaracteristicaNegocio caracteristicaNegocio = new CaracteristicaNegocio();

            ddlTipoContrato.DataSource = tipoContratoNegocio.ListarTodos().Where(tc => tc.Activo == true);
            ddlTipoContrato.DataBind();
            ddlTipoPropiedad.DataSource = tipoPropiedadNegocio.ListarTodas().Where(tp => tp.Activo == true);
            ddlTipoPropiedad.DataBind();
            ddlEstado.DataSource = estadoPropiedadNegocio.ListarTodos().Where(ep => ep.Activo == true);
            ddlEstado.DataBind();
            ddlBarrio.DataSource = barrioNegocio.ListarTodos().Where(b => b.Activo == true);
            ddlBarrio.DataBind();

            List<string> moneda = new List<string>();
            moneda.Add("");
            moneda.Add("ARS");
            moneda.Add("USD");

            ddlMoneda.DataSource = moneda;
            ddlMoneda.DataBind();

            rptCaracteristicas.DataSource = caracteristicaNegocio.ListarTodas();
            rptCaracteristicas.DataBind();

        }

        public void CargarPropiedad(int id)
        {
            PropiedadNegocio propNegocio = new PropiedadNegocio();
            Propiedad propiedad = propNegocio.ObtenerPorId(id);
            ImagenNegocio imgNegocio = new ImagenNegocio();

            try
            {
                // General
                tbxCodigo.Text = propiedad.Codigo;
                tbxTitulo.Text = propiedad.Titulo;
                tbxBio.Text = propiedad.Bio;
                tbxDescripcion.Text = propiedad.Descripcion;

                // Clasificacion y ubicacion
                ddlTipoPropiedad.SelectedValue = propiedad.IdTipoPropiedad.ToString();
                ddlTipoContrato.SelectedValue = propiedad.IdTipoContrato.ToString();
                ddlEstado.SelectedValue = propiedad.IdEstadoPropiedad.ToString();
                ddlBarrio.SelectedValue = propiedad.IdBarrio.ToString();
                tbxDireccion.Text = propiedad.Direccion;
                chbxMostrarDireccion.Checked = propiedad.MostrarDireccion;

                // Medidas, Distribucion y Precio
                tbxAmbientes.Text = propiedad.Ambientes.ToString();
                tbxDormitorios.Text = propiedad.Dormitorios.ToString();
                tbxBanios.Text = propiedad.Banios.ToString();
                tbxCocheras.Text = propiedad.Cocheras.ToString();
                tbxPlantas.Text = propiedad.Plantas.ToString();
                tbxMetrosCubiertos.Text = propiedad.MetrosCubiertos.ToString();
                tbxMetrosTotales.Text = propiedad.MetrosTotales.ToString();
                ddlMoneda.SelectedValue = propiedad.Moneda;
                tbxPrecio.Text = propiedad.PrecioActual.ToString();

                // Caracteristicas adicionales

                // Multimedia y Visibilidad
                List<Imagen> listaImagenes = imgNegocio.ListarPorPropiedad(propiedad.Id);
                if (listaImagenes.Count > 0)
                {
                    propiedad.Imagenes = listaImagenes;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al cargar la propiedad.";
            }

        }

        public bool ValidarCamposObligatorios()
        {
            if (string.IsNullOrEmpty(tbxTitulo.Text))
            {
                lblError.Text = "El título del inmueble es obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(tbxPrecio.Text))
            {
                lblError.Text = "El precio del inmueble es obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(ddlMoneda.SelectedValue))
            {
                lblError.Text = "Debe seleccionar un tipo de moneda";
                return false;
            }

            return true;
        }

        public string GenerarCodigo(int siguienteId)
        {
            int idTipoProp = Convert.ToInt32(ddlTipoPropiedad.SelectedValue);
            int idBarrio = Convert.ToInt32(ddlBarrio.SelectedValue);

            TipoPropiedadNegocio tipoPropNegocio = new TipoPropiedadNegocio();
            BarrioNegocio barrioNegocio = new BarrioNegocio();

            TipoPropiedad tipo = tipoPropNegocio.ObtenerPorId(idTipoProp);
            Barrio barrio = barrioNegocio.ObtenerPorId(idBarrio);

            string siglaTipo = !string.IsNullOrEmpty(tipo?.Sigla) ? tipo.Sigla.ToUpper() : "GEN";
            string siglaBarrio = !string.IsNullOrEmpty(barrio?.Sigla) ? barrio.Sigla.ToUpper() : "ZN";

            // Formatear
            return $"{siglaTipo}-{siglaBarrio}-{siguienteId.ToString("D4")}";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios())
                return;

            try
            {
                Propiedad propiedad = new Propiedad();
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();

                if (IdPropiedad == -1)
                {
                    // Obtener el último id para generar el código
                    int siguienteId = propiedadNegocio.ObtenerSiguienteId();
                    propiedad.Codigo = GenerarCodigo(siguienteId);
                }
                else
                {
                    propiedad.Codigo = tbxCodigo.Text;
                }

                propiedad.Titulo = tbxTitulo.Text;
                propiedad.Bio = tbxBio.Text;
                propiedad.Descripcion = tbxDescripcion.Text;

                // Claves foraneas
                propiedad.IdTipoPropiedad = Convert.ToInt32(ddlTipoPropiedad.SelectedValue);
                propiedad.IdTipoContrato = Convert.ToInt32(ddlTipoContrato.SelectedValue);
                propiedad.IdEstadoPropiedad = Convert.ToInt32(ddlEstado.SelectedValue);
                propiedad.IdBarrio = Convert.ToInt32(ddlBarrio.SelectedValue);

                // Ubicacion
                if (!string.IsNullOrEmpty(tbxDireccion.Text))
                {
                    propiedad.Direccion = tbxDireccion.Text;
                }
                propiedad.MostrarDireccion = chbxMostrarDireccion.Checked;
                // Agregar método para extraer latitud y longitud

                // Detalle y características numéricas
                propiedad.Ambientes = !string.IsNullOrEmpty(tbxAmbientes.Text) ? Convert.ToInt16(tbxAmbientes.Text) : (Int16)0;
                propiedad.Dormitorios = !string.IsNullOrEmpty(tbxDormitorios.Text) ? Convert.ToInt16(tbxDormitorios.Text) : (Int16)0;
                propiedad.Banios = !string.IsNullOrEmpty(tbxBanios.Text) ? Convert.ToInt16(tbxBanios.Text) : (Int16)0;
                propiedad.Cocheras = !string.IsNullOrEmpty(tbxCocheras.Text) ? Convert.ToInt16(tbxCocheras.Text) : (Int16)0;
                propiedad.Plantas = !string.IsNullOrEmpty(tbxPlantas.Text) ? Convert.ToInt16(tbxPlantas.Text) : (Int16)1;
                propiedad.MetrosTotales = !string.IsNullOrEmpty(tbxMetrosTotales.Text) ? Convert.ToInt16(tbxMetrosTotales.Text) : (Int16)0;
                propiedad.MetrosCubiertos = !string.IsNullOrEmpty(tbxMetrosCubiertos.Text) ? Convert.ToInt16(tbxMetrosCubiertos.Text) : (Int16)0;

                // Precio y estado
                propiedad.Moneda = ddlMoneda.SelectedValue;
                propiedad.PrecioActual = Convert.ToDecimal(tbxPrecio.Text);

                if (!string.IsNullOrEmpty(tbxVideo.Text))
                {
                    propiedad.Video = tbxVideo.Text;
                }
                propiedad.Activo = chbxActivo.Checked;
                propiedad.Destacado = chbxDestacado.Checked;
                

                // Cargar caracteristicas seleccionadas
                List<int> idCaracteristicasSeleccionadas = new List<int>();

                foreach (RepeaterItem item in rptCaracteristicas.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chk = (CheckBox)item.FindControl("chkCaracteristica");
                        HiddenField hfId = (HiddenField)item.FindControl("hfIdCaracteristica");

                        if (chk != null)
                        {
                            idCaracteristicasSeleccionadas.Add(Convert.ToInt32(hfId.Value));
                        }
                    }
                }

                // Auditoria de fechas
                propiedad.FechaAlta = DateTime.Now;
                if (chbxActivo.Checked)
                {
                    propiedad.FechaPublicacion = DateTime.Now;
                }

                // Generar Id si es una propiedad nueva, de lo contrario guardar los cambios en la propiedad
                if (IdPropiedad == -1)
                {
                    int idNuevo = propiedadNegocio.Guardar(propiedad);
                    propiedad.Id = idNuevo;
                }
                else
                {
                    propiedadNegocio.Modificar(propiedad);
                }

                if (!string.IsNullOrEmpty(hfImagenesData.Value))
                {
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    // Aumentar el límite del serializador por seguridad
                    serializer.MaxJsonLength = int.MaxValue;

                    List<ImagenSubidaDTO> listaImagenes = serializer.Deserialize<List<ImagenSubidaDTO>>(hfImagenesData.Value);
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    string rutaFisicaRaiz = Server.MapPath("~/");

                    foreach (var item in listaImagenes.OrderBy(x => x.Orden))
                    {
                        string nombreUnico = Guid.NewGuid().ToString().Substring(0, 8);
                        string rutaRelativa = ServicioImagen.GuardarImagenDesdeBase64(item.Base64, propiedad.Id, nombreUnico, rutaFisicaRaiz);

                        Imagen img = new Imagen
                        {
                            IdPropiedad = propiedad.Id,
                            Ruta = rutaRelativa,
                            Principal = (item.Orden == 1),
                            Orden = (short)item.Orden,
                            Activo = true
                        };

                        imagenNegocio.Guardar(img);
                    }
                }

                Response.Redirect("Inmuebles.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
            }
        }
    }
}