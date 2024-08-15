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
    public partial class PropiedadAdmin : System.Web.UI.Page
    {
        private List<TipoPropiedad> listaTipoPropiedad;
        private List<TipoContrato> listaTipoContrato;
        private List<Departamentos> listaDptos;
        private List<Localidades> listaLocalidades;
        private List<Pueblos> listaPueblos;
        public bool cargarNuevo = false;
        public int contadorCaracteres;
        public Propiedades seleccionada;
        public List<Imagenes> listaImagenes;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una sesión activa
                if (Session["sesionActiva"] is null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

                // Si la página se está cargando por primera vez

                if (!IsPostBack)
                {
                    // Crear instancias de objetos

                    TipoPropiedadNegocio tipoPropiedadNegocio = new TipoPropiedadNegocio();
                    TipoContratoNegocio tipoContratoNegocio = new TipoContratoNegocio();
                    DptoNegocio dptoNegocio = new DptoNegocio();
                    LocalidadesNegocio localidadesNegocio = new LocalidadesNegocio();
                    PueblosNegocio pueblosNegocio = new PueblosNegocio();
                    listaTipoPropiedad = new List<TipoPropiedad>();
                    listaTipoContrato = new List<TipoContrato>();
                    listaDptos = new List<Departamentos>();
                    listaLocalidades = new List<Localidades>();
                    listaPueblos = new List<Pueblos>();


                    // Precargar los dropdown list

                    // Tipo de propiedad
                    listaTipoPropiedad = tipoPropiedadNegocio.listar();
                    ddlTipoPropiedad.DataSource = listaTipoPropiedad;
                    ddlTipoPropiedad.DataTextField = "Descripcion";
                    ddlTipoPropiedad.DataValueField = "Id";
                    ddlTipoPropiedad.DataBind();

                    //Tipo de contrato
                    listaTipoContrato = tipoContratoNegocio.listar();
                    ddlTipoContrato.DataSource = listaTipoContrato;
                    ddlTipoContrato.DataTextField = "Descripcion";
                    ddlTipoContrato.DataValueField = "Id";
                    ddlTipoContrato.DataBind();

                    // Departamentos
                    listaDptos = dptoNegocio.listar();
                    ddlDepartamentos.DataSource = listaDptos;
                    ddlDepartamentos.DataTextField = "Descripcion";
                    ddlDepartamentos.DataValueField = "Id";
                    ddlDepartamentos.DataBind();

                    // Localidades
                    listaLocalidades = localidadesNegocio.listar();
                    ddlLocalidades.DataSource = listaLocalidades;
                    ddlLocalidades.DataTextField = "Descripcion";
                    ddlLocalidades.DataValueField = "Id";
                    ddlLocalidades.DataBind();

                    // Pueblos
                    listaPueblos = pueblosNegocio.listar();
                    ddlPueblos.DataSource = listaPueblos;
                    ddlPueblos.DataTextField = "Descripcion";
                    ddlPueblos.DataValueField = "Id";
                    ddlPueblos.DataBind();


                    // Cargar propiedad en caso de llamar a una modificación

                    if (Request.QueryString["id"] != null)
                    {
                        // Definir cargarNuevo como false
                        cargarNuevo = false;

                        // Obtener de la sesión el objeto seleccionado
                        seleccionada = (Propiedades)Session["propiedadSeleccionada"];

                        // Cargar las imágenes de la propiedad si es que existen
                        listaImagenes = imagenesNegocio.listar(seleccionada.Id);

                        // Cargar los campos con los datos de la propiedad
                        tbxCodigo.Text = seleccionada.Codigo;
                        tbxTitulo.Text = seleccionada.Titulo;
                        ddlTipoContrato.SelectedValue = seleccionada.TipoContrato.Id.ToString();
                        ddlTipoPropiedad.SelectedValue = seleccionada.TipoPropiedad.Id.ToString();
                        ddlMoneda.SelectedValue = seleccionada.Moneda;
                        tbxPrecio.Text = seleccionada.Precio.ToString("0.00");
                        chbxActivo.Checked = seleccionada.Activo;
                        chbxDestacado.Checked = seleccionada.Destacado;
                        tbxDescripcion.Text = seleccionada.Descripcion;
                        tbxAmbientes.Text = seleccionada.Ambientes.ToString();
                        tbxDormitorios.Text = seleccionada.Dormitorios.ToString();
                        tbxBaños.Text = seleccionada.Baños.ToString();
                        tbxMetrosTotales.Text = seleccionada.MetrosTotales.ToString();
                        tbxMetrosCubiertos.Text = seleccionada.MetrosCubiertos.ToString();
                        tbxPlantas.Text = seleccionada.Plantas.ToString();
                        tbxCocheras.Text = seleccionada.Cocheras.ToString();
                        ddlDepartamentos.SelectedValue = seleccionada.Departamento.Id.ToString();
                        ddlLocalidades.SelectedValue = seleccionada.Localidad.Id.ToString();
                        ddlPueblos.SelectedValue = seleccionada.Pueblo.Id.ToString();
                        tbxVideo.Text = seleccionada.Video;
                        tbxUbicacion.Text = seleccionada.Ubicacion;

                        if (listaImagenes != null)
                        {
                            repImagenes.DataSource = listaImagenes;
                            repImagenes.DataBind();
                        }
                    }
                    else
                    {
                        // Si no es modificación, definir cargarNuevo como true
                        cargarNuevo = true;
                    }

                    //Ajustar contador de caracteres
                    if (string.IsNullOrEmpty(tbxDescripcion.Text))
                    {
                        contadorCaracteres = 0;
                    }
                    else
                    {
                        int diferencia = tbxDescripcion.Text.Length;
                        contadorCaracteres += diferencia;
                    }
                }

                // En caso de que SÍ sea una recarga de la página
                else
                {
                    // Verificar si NO ES una modificación
                    if (Request.QueryString["id"] is null)
                    {
                        cargarNuevo = true;

                        // Verificar que haya imágenes cargadas en la sesión

                        if (Session["urlImagenes"] != null)
                        {
                            // Obtener la lista de imágenes de la sesión

                            listaImagenes = new List<Imagenes>();
                            listaImagenes = (List<Imagenes>)Session["urlImagenes"];

                            repImagenes.DataSource = listaImagenes;
                            repImagenes.DataBind();
                        }
                    }
                    else
                    {
                        // En caso de que SI se esté modificando una propiedad pero NO hay imágenes en la sesión

                        if (Session["urlImagenes"] != null)
                        {
                            // Obtener el id de la propiedad seleccionada
                            int id = int.Parse(Request.QueryString["Id"]);

                            // Buscar las url de imágenes de esa propiedad en la base de datos, si es que existen
                            listaImagenes = (List<Imagenes>)Session["urlImagenes"];

                            if (listaImagenes != null)
                            {
                                repImagenes.DataSource = listaImagenes;
                                repImagenes.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verivicar validaciones
                Page.Validate();
                if (!Page.IsValid)
                    return;

                PropiedadesNegocio propiedadesNegocio = new PropiedadesNegocio();
                Propiedades aux = new Propiedades();
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
                int id;

                aux.Codigo = tbxCodigo.Text;
                aux.Titulo = tbxTitulo.Text;
                aux.TipoPropiedad = new TipoPropiedad();
                aux.TipoPropiedad.Id = int.Parse(ddlTipoPropiedad.SelectedValue);
                aux.TipoContrato = new TipoContrato();
                aux.TipoContrato.Id = int.Parse(ddlTipoContrato.SelectedValue);
                aux.Destacado = chbxDestacado.Checked;
                aux.Activo = chbxActivo.Checked;
                aux.Moneda = ddlMoneda.SelectedValue;
                aux.Precio = decimal.Parse(tbxPrecio.Text);
                aux.Video = tbxVideo.Text;
                aux.Bio = tbxBio.Text;
                aux.Descripcion = tbxDescripcion.Text;
                aux.Ambientes = int.Parse(tbxAmbientes.Text);
                aux.Dormitorios = int.Parse(tbxDormitorios.Text);
                aux.Baños = int.Parse(tbxBaños.Text);
                aux.MetrosTotales = int.Parse(tbxMetrosTotales.Text);
                aux.MetrosCubiertos = int.Parse(tbxMetrosCubiertos.Text);
                aux.Plantas = int.Parse(tbxPlantas.Text);
                aux.Cocheras = int.Parse(tbxCocheras.Text);
                aux.Departamento = new Departamentos();
                aux.Departamento.Id = int.Parse(ddlDepartamentos.SelectedValue);
                aux.Localidad = new Localidades();
                aux.Localidad.Id = int.Parse(ddlLocalidades.SelectedValue);
                aux.Pueblo = new Pueblos();
                aux.Pueblo.Id = int.Parse(ddlPueblos.SelectedValue);
                aux.Ubicacion = tbxUbicacion.Text;

                id = propiedadesNegocio.insertar(aux);

                if (listaImagenes != null)
                {
                    bool primerItem = true;
                    foreach (Imagenes img in listaImagenes)
                    {
                        img.IdPropiedad = id;

                        if (primerItem)
                        {
                            img.Principal = true;
                            primerItem = false;
                        }
                        else
                            img.Principal = false;

                        imagenesNegocio.insertar(img);
                    }
                }

                Response.Redirect("DefaultAdmin.aspx");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                PropiedadesNegocio negocioPropiedades = new PropiedadesNegocio();
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
                Propiedades aux = new Propiedades();

                aux.Id = int.Parse(Request.QueryString["id"]);
                aux.Codigo = tbxCodigo.Text;
                aux.Titulo = tbxTitulo.Text;
                aux.TipoPropiedad = new TipoPropiedad();
                aux.TipoPropiedad.Id = int.Parse(ddlTipoPropiedad.SelectedValue);
                aux.TipoContrato = new TipoContrato();
                aux.TipoContrato.Id = int.Parse(ddlTipoContrato.SelectedValue);
                aux.Destacado = chbxDestacado.Checked;
                aux.Activo = chbxActivo.Checked;
                aux.Moneda = ddlMoneda.SelectedValue;
                aux.Precio = decimal.Parse(tbxPrecio.Text);
                aux.Bio = tbxBio.Text;
                aux.Descripcion = tbxDescripcion.Text;
                aux.Video = tbxVideo.Text;
                aux.Ambientes = int.Parse(tbxAmbientes.Text);
                aux.Dormitorios = int.Parse(tbxDormitorios.Text);
                aux.Baños = int.Parse(tbxBaños.Text);
                aux.MetrosTotales = int.Parse(tbxMetrosTotales.Text);
                aux.MetrosCubiertos = int.Parse(tbxMetrosCubiertos.Text);
                aux.Plantas = int.Parse(tbxPlantas.Text);
                aux.Cocheras = int.Parse(tbxCocheras.Text);
                aux.Departamento = new Departamentos();
                aux.Departamento.Id = int.Parse(ddlDepartamentos.SelectedValue);
                aux.Localidad = new Localidades();
                aux.Localidad.Id = int.Parse(ddlLocalidades.SelectedValue);
                aux.Pueblo = new Pueblos();
                aux.Pueblo.Id = int.Parse(ddlPueblos.SelectedValue);
                aux.Ubicacion = tbxUbicacion.Text;

                negocioPropiedades.modificar(aux);

                // Si la sesión tiene un parámetro "primeraCargaImg" es porque en esta modificación se llamó al
                // botón "Cargar", y se deben guardar las imagenes nuevas

                if (Session["primeraCargaImg"] != null)
                {
                    bool primerItem = true;

                    foreach (Imagenes img in listaImagenes)
                    {
                        img.IdPropiedad = aux.Id;
                        if (primerItem)
                        {
                            img.Principal = true;
                            primerItem = false;
                        }
                        else
                            img.Principal = false;

                        imagenesNegocio.insertar(img);
                    }
                }

                Response.Redirect("DefaultAdmin.aspx", false);

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        protected void tbxDescripcion_TextChanged(object sender, EventArgs e)
        {
            int diferencia = tbxDescripcion.Text.Length;
            contadorCaracteres = 0 + diferencia;
        }

        protected void btnCargarImagenesImagenes_Click(object sender, EventArgs e)
        {
            // Crear Lista de imágenes
            List<Imagenes> urlImagenes = new List<Imagenes>();

            try
            {
                // Verificar que el File Upload haya traido archivos de la PC
                if (fupImagenes.HasFiles)
                {
                    // Recorrer los archivos cargados
                    foreach (HttpPostedFile imagen in fupImagenes.PostedFiles)
                    {
                        Imagenes aux = new Imagenes();
                        // Obtener ruta de origen
                        string rutaArchivo = imagen.FileName;
                        // Guardar la ruta relativa para llevar a la base de dtos
                        string rutaProvisoria = "./Images/ImgPropiedades/" + rutaArchivo;
                        aux.Ruta = rutaProvisoria;
                        // Obtener la ruta final
                        string rutaFinal = Server.MapPath(rutaProvisoria);

                        // Agregar imagen a la lista y guardar archivo en la carpeta
                        urlImagenes.Add(aux);
                        imagen.SaveAs(rutaFinal);
                    }

                    // Cargar lista de imágenes en sesión y recargar página para cargarlos archivos
                    Session.Add("urlImagenes", urlImagenes);
                    Session.Add("primeraCargaImg", true);
                    Page_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorAdmin.aspx");
            }

        }
    }
}