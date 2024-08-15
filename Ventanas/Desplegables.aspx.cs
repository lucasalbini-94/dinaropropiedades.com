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
    public partial class Desplegables : System.Web.UI.Page
    {
        public string campo;
        public bool modificar = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DptoNegocio dptoNegocio = new DptoNegocio();
                LocalidadesNegocio locNegocio = new LocalidadesNegocio();
                PueblosNegocio pueNegocio = new PueblosNegocio();
                TipoPropiedadNegocio TPNegocio = new TipoPropiedadNegocio();
                TipoContratoNegocio TCNegocio = new TipoContratoNegocio();

                campo = Request.QueryString["campo"];


                if (campo == "Dpto")
                {
                    List<Departamentos> lista = dptoNegocio.listar();
                    dgvDesplegable.DataSource = lista;
                }
                else if (campo == "Loc")
                {
                    List<Localidades> lista = locNegocio.listar();
                    dgvDesplegable.DataSource = lista;
                }
                else if (campo == "Pue")
                {
                    List<Pueblos> lista = pueNegocio.listar();
                    dgvDesplegable.DataSource = lista;
                }
                else if (campo == "TP")
                {
                    List<TipoPropiedad> lista = TPNegocio.listar();
                    dgvDesplegable.DataSource = lista;
                }
                else if (campo == "TC")
                {
                    List<TipoContrato> lista = TCNegocio.listar();
                    dgvDesplegable.DataSource = lista;
                }
                else
                    return;

                dgvDesplegable.AutoGenerateSelectButton = true;
                dgvDesplegable.DataBind();

                if (campo == "Loc")
                {
                    List<Departamentos> lista = dptoNegocio.listar();
                    ddlDesplegable.DataSource = lista;
                    ddlDesplegable.DataTextField = "Descripcion";
                    ddlDesplegable.DataValueField = "Id";
                    ddlDesplegable.DataBind();
                }
                else if (campo == "Pue")
                {
                    List<Localidades> lista = locNegocio.listar();
                    ddlDesplegable.DataSource = lista;
                    ddlDesplegable.DataTextField = "Descripcion";
                    ddlDesplegable.DataValueField = "Id";
                    ddlDesplegable.DataBind();
                }

                if (modificar)
                {

                    if (Session["idSeleccionado"] != null)
                    {
                        string id = (string)Session["idSeleccionado"];

                        if (campo == "Loc")
                        {
                            List<Localidades> listaLoc = locNegocio.listar();
                            Localidades seleccionada = listaLoc.Find(x => x.Id == int.Parse(id));
                            tbxCampo.Text = seleccionada.Descripcion;
                            List<Departamentos> listaDptos = dptoNegocio.listar();
                            ddlDesplegable.DataSource = listaDptos;
                            ddlDesplegable.DataTextField = "Descripcion";
                            ddlDesplegable.DataValueField = "Id";
                            ddlDesplegable.SelectedValue = seleccionada.Departamento.Id.ToString();
                            ddlDesplegable.DataBind();
                        }
                        else if (campo == "Pue")
                        {
                            List<Pueblos> listaPue = pueNegocio.listar();
                            Pueblos seleccionado = listaPue.Find(x => x.Id == int.Parse(id));
                            tbxCampo.Text = seleccionado.Descripcion;
                            List<Localidades> listaLoc = locNegocio.listar();
                            ddlDesplegable.DataSource = listaLoc;
                            ddlDesplegable.DataTextField = "Descripcion";
                            ddlDesplegable.DataValueField = "Id";
                            ddlDesplegable.SelectedValue = seleccionado.Localidad.Id.ToString();
                            ddlDesplegable.DataBind();
                        }
                        else if (campo == "Dpto")
                        {
                            List<Departamentos> lista = dptoNegocio.listar();
                            Departamentos seleccionado = lista.Find(x => x.Id == int.Parse(id));
                            tbxCampo.Text = seleccionado.Descripcion;
                        }
                        else if (campo == "TC")
                        {
                            List<TipoContrato> lista = TCNegocio.listar();
                            TipoContrato seleccionado = lista.Find(x => x.Id == int.Parse(id));
                            tbxCampo.Text = seleccionado.Descripcion;
                        }
                        else if (campo == "TP")
                        {
                            List<TipoPropiedad> lista = TPNegocio.listar();
                            TipoPropiedad seleccionada = lista.Find(x => x.Id == int.Parse(id));
                            tbxCampo.Text = seleccionada.Descripcion;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        protected void dgvDesplegable_SelectedIndexChanged(object sender, EventArgs e)
        {
            modificar = true;
            string id = dgvDesplegable.SelectedDataKey.Value.ToString();
            Session.Add("idSeleccionado", id);
            Page_Load(sender, e);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            DptoNegocio dptoNegocio = new DptoNegocio();
            LocalidadesNegocio locNegocio = new LocalidadesNegocio();
            PueblosNegocio pueNegocio = new PueblosNegocio();
            TipoContratoNegocio TCNegocio = new TipoContratoNegocio();
            TipoPropiedadNegocio TPNegocio = new TipoPropiedadNegocio();

            try
            {
                int id;
                if (campo == "Dpto")
                {
                    if (boton.Text != "Eliminar")
                    {
                        Departamentos aux = new Departamentos();
                        aux.Descripcion = tbxCampo.Text;
                        if (modificar)
                            dptoNegocio.modificar(aux);
                        else
                            dptoNegocio.insertar(aux);
                    }
                    else
                    {
                        id = int.Parse(ddlDesplegable.SelectedValue);
                        dptoNegocio.eliminar(id);
                    }
                }
                else if (campo == "Loc")
                {
                    if (boton.Text != "Eliminar")
                    {
                        Localidades aux = new Localidades();
                        aux.Descripcion = tbxCampo.Text;
                        aux.Departamento = new Departamentos();
                        aux.Departamento.Id = int.Parse(ddlDesplegable.SelectedValue);
                        if (modificar)
                            locNegocio.modificar(aux);
                        else
                            locNegocio.insertar(aux);
                    }
                    else
                    {
                        id = int.Parse(ddlDesplegable.SelectedValue);
                        locNegocio.eliminar(id);
                    }
                }
                else if (campo == "Pue")
                {
                    if (boton.Text != "Eliminar")
                    {
                        Pueblos aux = new Pueblos();
                        aux.Descripcion = tbxCampo.Text;
                        aux.Localidad = new Localidades();
                        aux.Localidad.Id = int.Parse(ddlDesplegable.SelectedValue);
                        if (modificar)
                            pueNegocio.modificar(aux);
                        else
                            pueNegocio.insertar(aux);
                    }
                    else
                    {
                        id = int.Parse(ddlDesplegable.SelectedValue);
                        pueNegocio.eliminar(id);
                    }
                }
                else if (campo == "TC")
                {
                    if (boton.Text != "Eliminar")
                    {
                        TipoContrato aux = new TipoContrato();
                        aux.Descripcion = tbxCampo.Text;
                        if (modificar)
                            TCNegocio.modificar(aux);
                        else
                            TCNegocio.insertar(aux);
                    }
                    else
                    {
                        id = int.Parse(ddlDesplegable.SelectedValue);
                        TCNegocio.eliminar(id);
                    }
                }
                else if (campo == "TP")
                {
                    if (boton.Text != "Eliminar")
                    {
                        TipoPropiedad aux = new TipoPropiedad();
                        aux.Descripcion = tbxCampo.Text;
                        if (modificar)
                            TPNegocio.modificar(aux);
                        else
                            TPNegocio.insertar(aux);
                    }
                    else
                    {
                        id = int.Parse(ddlDesplegable.SelectedValue);
                        TPNegocio.eliminar(id);
                    }
                }

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