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
    public partial class Lista : System.Web.UI.Page
    {
        private List<Propiedades> listaPropiedades;
        public List<Propiedades> listaFiltrada;
        private List<Imagenes> listaImagenes;
        private bool filtroVacio = false;

        public bool MostrarSiNoEsTerreno(bool esTerreno)
        {
            return !esTerreno;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    cargarGrilla();
                    cargarDesplegables();

                    if (Request.QueryString["contrato"] != null && Request.QueryString["propiedad"] != null)
                    {
                        string contrato = Request.QueryString["contrato"];
                        string propiedad = Request.QueryString["propiedad"];

                        ddlTipoContrato.SelectedValue = contrato;
                        ddlTipoProp.SelectedValue = propiedad;

                        filtrar();
                        if (listaFiltrada != null)
                        {
                            repPropiedades.DataSource = listaFiltrada;
                            repPropiedades.DataBind();
                        }
                        else
                            cargarGrilla();
                    }
                    else
                        cargarGrilla();
                }
                else
                {
                    if (listaFiltrada is null)
                    {
                        cargarGrilla();
                    }
                    else
                    {
                        if (listaFiltrada.Count > 0)
                        {
                            repPropiedades.DataSource = listaFiltrada;
                            repPropiedades.DataBind();
                        }
                        else
                        {
                            repPropiedades.DataSource = listaFiltrada;
                            repPropiedades.DataBind();
                            filtroVacio = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorUser.aspx");
            }
        }

        private void cargarGrilla()
        {
            try
            {
                PropiedadesNegocio propiedadesNegocio = new PropiedadesNegocio();
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

                // Listar propiedades activas
                listaPropiedades = propiedadesNegocio.listar().FindAll(x => x.Activo == true);
                // Separar terrenos y propiedades
                Helper.separarPropiedadesYTerrenos(ref listaPropiedades);
                listaImagenes = imagenesNegocio.listar(-1, true);


                foreach (Propiedades prop in listaPropiedades)
                {
                    Imagenes img = listaImagenes.Find(x => x.IdPropiedad == prop.Id);
                    if (img != null)
                    {
                        if (!(string.IsNullOrEmpty(img.Ruta) && !string.IsNullOrEmpty(img.Alt)))
                        {
                            prop.ImagenPrincipal = img.Ruta;
                            prop.AltImagen = img.Alt;
                        }
                        else
                        {
                            img = Helper.imagenPlaceholder();
                            prop.ImagenPrincipal = img.Ruta;
                            prop.AltImagen = img.Alt;
                        }
                    }
                    else
                    {
                        img = Helper.imagenPlaceholder();
                        prop.ImagenPrincipal = img.Ruta;
                        prop.AltImagen = img.Alt;
                    }
                }

                repPropiedades.DataSource = listaPropiedades;
                repPropiedades.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        private void cargarDesplegables()
        {
            try
            {
                DptoNegocio dptoNegocio = new DptoNegocio();
                LocalidadesNegocio localidadesNegocio = new LocalidadesNegocio();
                PueblosNegocio pueblosNegocio = new PueblosNegocio();
                TipoContratoNegocio tipoContratoNegocio = new TipoContratoNegocio();
                TipoPropiedadNegocio tipoPropiedadNegocio = new TipoPropiedadNegocio();

                //// Cargar desplegables
                //// Departamentos
                //ddlDpto.DataSource = dptoNegocio.listar();
                //ddlDpto.DataBind();

                //// Localidades
                //ddlLocalidades.DataSource = localidadesNegocio.listar();
                //ddlLocalidades.DataBind();

                // Pueblos
                ddlPueblos.DataSource = pueblosNegocio.listar();
                ddlPueblos.DataTextField = "Descripcion";
                ddlPueblos.DataValueField = "Id";
                ddlPueblos.DataBind();

                // Tipo de contrato y propiedad

                ddlTipoContrato.DataSource = tipoContratoNegocio.listar();
                ddlTipoContrato.DataValueField = "Id";
                ddlTipoContrato.DataTextField = "Descripcion";
                ddlTipoContrato.DataBind();

                ddlTipoProp.DataSource = tipoPropiedadNegocio.listar();
                ddlTipoProp.DataTextField = "Descripcion";
                ddlTipoProp.DataValueField = "Id";
                ddlTipoProp.DataBind();

                if (filtroVacio)
                {
                    ddlTipoProp.Enabled = false;
                    ddlTipoContrato.Enabled = false;
                    ddlPueblos.Enabled = false;
                    ddlMoneda.Enabled = false;
                    ddlOrdenarPrecio.Enabled = false;
                    ddlCaracteriticas.Enabled = false;
                    tbxCantidad.Enabled = false;
                }
                else
                {
                    ddlTipoProp.Enabled = true;
                    ddlTipoContrato.Enabled = true;
                    ddlPueblos.Enabled = true;
                    ddlMoneda.Enabled = true;
                    ddlOrdenarPrecio.Enabled = true;
                    ddlCaracteriticas.Enabled = true;
                    tbxCantidad.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }


        private void filtrar()
        {
            try
            {
                TipoPropiedad auxTP = new TipoPropiedad();
                auxTP.Id = int.Parse(ddlTipoProp.SelectedValue);

                if (listaFiltrada is null)
                {
                    if (auxTP.Id > 1)
                        listaFiltrada = listaPropiedades.FindAll(x => x.TipoPropiedad.Id == auxTP.Id);
                }
                else
                {
                    if (auxTP.Id > 1)
                        listaFiltrada = listaFiltrada.FindAll(x => x.TipoPropiedad.Id == auxTP.Id);
                }

                TipoContrato auxTC = new TipoContrato();
                auxTC.Id = int.Parse(ddlTipoContrato.SelectedValue);

                if (listaFiltrada is null)
                {
                    if (auxTC.Id > 1)
                        listaFiltrada = listaPropiedades.FindAll(x => x.TipoContrato.Id == auxTC.Id);
                }
                else
                {
                    if (auxTC.Id > 1)
                        listaFiltrada = listaFiltrada.FindAll(x => x.TipoContrato.Id == auxTC.Id);
                }

                Pueblos auxP = new Pueblos();
                auxP.Id = int.Parse(ddlPueblos.SelectedValue);

                if (listaFiltrada is null)
                {
                    if (auxP.Id > 1)
                        listaFiltrada = listaPropiedades.FindAll(x => x.Pueblo.Id == auxP.Id);
                }
                else
                {
                    if (auxP.Id > 1)
                        listaFiltrada = listaFiltrada.FindAll(x => x.Pueblo.Id == auxP.Id);
                }

                if (ddlMoneda.SelectedValue != "")
                {
                    if (listaFiltrada is null)
                        listaFiltrada = listaPropiedades.FindAll(x => x.Moneda == ddlMoneda.SelectedValue);
                    else
                        listaFiltrada = listaFiltrada.FindAll(x => x.Moneda == ddlMoneda.SelectedValue);
                }

                if (ddlOrdenarPrecio.SelectedValue != "")
                {
                    string valor = ddlOrdenarPrecio.SelectedValue;

                    if (listaFiltrada is null)
                    {
                        if (valor == "Menor precio")
                            listaFiltrada = listaPropiedades.OrderBy(x => x.Precio).ToList();
                        else
                            listaFiltrada = listaPropiedades.OrderBy(x => x.Precio).Reverse().ToList();
                    }
                    else
                    {
                        if (valor == "Menor precio")
                            listaFiltrada = listaFiltrada.OrderBy(x => x.Precio).ToList();
                        else
                            listaFiltrada = listaFiltrada.OrderBy(x => x.Precio).Reverse().ToList();
                    }
                }

                if (ddlCaracteriticas.SelectedValue != "" && tbxCantidad.Text != "")
                {
                    string campo = ddlCaracteriticas.SelectedValue;
                    int cant = int.Parse(tbxCantidad.Text);

                    if (listaFiltrada is null)
                    {
                        if (campo == "Ambientes")
                            listaFiltrada = listaPropiedades.FindAll(x => x.Ambientes == cant);
                        else if (campo == "Dormitorios")
                            listaFiltrada = listaPropiedades.FindAll(x => x.Dormitorios == cant);
                        else if (campo == "Baños")
                            listaFiltrada = listaPropiedades.FindAll(x => x.Baños == cant);
                        else if (campo == "Plantas")
                            listaFiltrada = listaPropiedades.FindAll(x => x.Plantas == cant);
                        else
                            listaFiltrada = listaPropiedades.FindAll(x => x.Cocheras == cant);
                    }
                    else
                    {
                        if (campo == "Ambientes")
                            listaFiltrada = listaFiltrada.FindAll(x => x.Ambientes == cant);
                        else if (campo == "Dormitorios")
                            listaFiltrada = listaFiltrada.FindAll(x => x.Dormitorios == cant);
                        else if (campo == "Baños")
                            listaFiltrada = listaFiltrada.FindAll(x => x.Baños == cant);
                        else if (campo == "Plantas")
                            listaFiltrada = listaFiltrada.FindAll(x => x.Plantas == cant);
                        else
                            listaFiltrada = listaFiltrada.FindAll(x => x.Cocheras == cant);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        protected void filtro_Click(object sender, EventArgs e)
        {
            try
            {
                filtrar();
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }
    }
}