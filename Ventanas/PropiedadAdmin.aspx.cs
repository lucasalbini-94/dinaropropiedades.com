using System;
using System.Collections.Generic;
using System.IO;
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
        public int contadorCharBio;
        public int contadorCharDesc;
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
                        encabezado.InnerText = "Modificar propiedad";

                        // Definir cargarNuevo como false
                        cargarNuevo = false;

                        // Obtener de la sesión el objeto seleccionado
                        seleccionada = (Propiedades)Session["propiedadSeleccionada"];

                        // Cargar los campos con los datos de la propiedad
                        tbxCodigo.Text = seleccionada.Codigo;
                        tbxTitulo.Text = seleccionada.Titulo;
                        ddlTipoContrato.SelectedValue = seleccionada.TipoContrato.Id.ToString();
                        ddlTipoPropiedad.SelectedValue = seleccionada.TipoPropiedad.Id.ToString();
                        ddlMoneda.SelectedValue = seleccionada.Moneda;
                        tbxPrecio.Text = seleccionada.Precio.ToString();
                        chbxActivo.Checked = seleccionada.Activo;
                        chbxDestacado.Checked = seleccionada.Destacado;
                        tbxBio.Text = seleccionada.Bio;
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

                        cargarImagenesDeCarpeta(seleccionada.Id, seleccionada.Codigo);

                    }
                    else
                    {
                        // Si no es modificación, definir cargarNuevo como true
                        cargarNuevo = true;

                        encabezado.InnerText = "Nueva propiedad";
                    }

                    //Ajustar contador de caracteres

                    if (string.IsNullOrEmpty(tbxBio.Text))
                    {
                        contadorCharBio = 0;
                    }
                    else
                    {
                        int diferencia = tbxBio.Text.Length;
                        contadorCharBio += diferencia;
                    }

                    if (string.IsNullOrEmpty(tbxDescripcion.Text))
                    {
                        contadorCharDesc = 0;
                    }
                    else
                    {
                        int diferencia = tbxDescripcion.Text.Length;
                        contadorCharDesc += diferencia;
                    }

                    // Cargar datos de la sesion si existen
                    if (Session["datosGuardados"] != null)
                        cargarDatosSesion();
                }

                // En caso de que SÍ sea una recarga de la página
                else
                {
                    // Obtener comando del código JS
                    string eventTarget = Request.Form["__EVENTTARGET"];
                    string eventArgument = Request.Form["__EVENTARGUMENT"];

                    if (!string.IsNullOrEmpty(eventTarget))
                    {
                        switch (eventTarget)
                        {
                            case "btnDefinirPrincipal":
                                DefinirComoPrincipal(eventArgument);
                                break;
                            case "btnQuitarImagen":
                                QuitarImagen(eventArgument);
                                break;
                        }
                    }
                    // Verificar si NO ES una modificación
                    if (Request.QueryString["id"] is null)
                    {
                        cargarNuevo = true;

                        // Verificar que haya imágenes cargadas en la sesión

                        if (Session["listaImagenes"] != null)
                        {
                            // Obtener la lista de imágenes de la sesión

                            listaImagenes = new List<Imagenes>();
                            listaImagenes = (List<Imagenes>)Session["listaImagenes"];

                            repImagenes.DataSource = listaImagenes;
                            repImagenes.DataBind();
                        }
                    }
                    else
                    {
                        // En caso de que SI se esté modificando una propiedad pero NO hay imágenes en la sesión

                        if (Session["listaImagenes"] != null)
                        {
                            // Obtener el id de la propiedad seleccionada
                            int id = int.Parse(Request.QueryString["Id"]);

                            // Buscar las url de imágenes de esa propiedad en la base de datos, si es que existen
                            listaImagenes = (List<Imagenes>)Session["listaImagenes"];

                            if (listaImagenes != null)
                            {
                                repImagenes.DataSource = listaImagenes;
                                repImagenes.DataBind();
                            }
                        }
                    }

                    // Cargar datos de la sesion si existen
                    if (Session["datosGuardados"] != null)
                        cargarDatosSesion();
                    // Borrar esos datos una vez cargados para evitar el problema de la recarga
                    borrarDatosDeSesión();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Session.Add("error", error);
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        private void cargarImagenesDeCarpeta(int id, string codigo = "")
        {
            // Listar las rutas de imagenes desde la base de datos
            ImagenesNegocio negocio = new ImagenesNegocio();
            listaImagenes = negocio.listar().FindAll(x => x.IdPropiedad == id);

            // Borrar la lista de la sesión si es que existe
            if (Session["listaImagenes"] != null)
                Session.Remove("listaImagenes");

            // Agregar la lista de imágenes a la sesión y asignar la lista al repeater
            Session.Add("listaImagenes", listaImagenes);

            if (listaImagenes.Count > 0)
                tbxPalabrasClave.Text = listaImagenes[0].Alt;

            repImagenes.DataSource = listaImagenes;
            repImagenes.DataBind();

        }

        private void DefinirComoPrincipal(string ruta)
        {
            try
            {
                // Obtener lista de imágenes de la sesión
                listaImagenes = (List<Imagenes>)Session["listaImagenes"];

                // Verificar que la lista no sea nula
                if (listaImagenes != null)
                {
                    foreach (Imagenes imagen in listaImagenes)
                    {
                        if (imagen.Ruta.Replace(" ", "") == ruta.Replace("%20", ""))
                            imagen.Principal = true;
                        else
                            imagen.Principal = false;
                    }

                    Session.Remove("listaImagenes");
                    Session.Add("listaImagenes", listaImagenes);
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error: {ex.Message}');</script>");

            }
        }

        private void QuitarImagen(string ruta)
        {
            try
            {
                listaImagenes = (List<Imagenes>)Session["listaImagenes"];

                if (listaImagenes != null)
                {

                    // Buscar imagen por su ruta
                    ruta = ruta.Replace("%20", "");

                    Imagenes imagenEliminar = listaImagenes.Find(img => img.Ruta.Replace(" ", "") == ruta);

                    if (imagenEliminar != null)
                    {
                        // Eliminar archivo fisico si existe
                        string rutaAbsoluta = Page.MapPath(ruta.Replace("%20", ""));
                        if (File.Exists(rutaAbsoluta))
                        {
                            File.Delete(rutaAbsoluta);
                        }

                        // Eliminar Imagen de la base de datos
                        ImagenesNegocio negocio = new ImagenesNegocio();
                        negocio.eliminar(imagenEliminar.Id);

                        // Eliminar la imagen de lista en la la sesion
                        listaImagenes.Remove(imagenEliminar);

                        // Actualizar la sesion con la lista eliminada
                        Session.Remove("listaImagenes");
                        Session.Add("listaImagenes", listaImagenes);
                        repImagenes.DataSource = listaImagenes;
                        repImagenes.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error: {ex.Message}');</script>");
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
                aux.AltImagen = tbxPalabrasClave.Text;

                id = propiedadesNegocio.insertar(aux);

                string rutaTemporal = Page.MapPath("~/Images/ImgPropiedades/Temporales/");
                string rutaDestino = Page.MapPath($"~/Images/ImgPropiedades/{aux.Codigo}/");

                // Crear la carpeta si no existe
                if (!Directory.Exists(rutaDestino))
                    Directory.CreateDirectory(rutaDestino);

                listaImagenes = Session["listaImagenes"] as List<Imagenes>;

                if (listaImagenes != null)
                {
                    foreach (Imagenes imagen in listaImagenes)
                    {
                        string nombreArchivo = Path.GetFileName(imagen.Ruta);
                        string rutaArchivoTemporal = Path.Combine(rutaTemporal, nombreArchivo);
                        string rutaArchivoDestino = Path.Combine(rutaDestino, nombreArchivo);

                        imagen.IdPropiedad = id;
                        imagen.Ruta = $"/Images/ImgPropiedades/{aux.Codigo}/{nombreArchivo}";
                        imagen.Alt = tbxPalabrasClave.Text;

                        imagenesNegocio.insertar(imagen);

                        if (File.Exists(rutaArchivoTemporal))
                            File.Move(rutaArchivoTemporal, rutaArchivoDestino);
                    }

                    Session.Remove("lista");
                    borrarDatosDeSesión();

                    borrarImagenesDeCarpetaTempoaral();
                    Response.Redirect("DefaultAdmin.aspx", false);
                }

                Response.Write($"<script>alert('Ups... Parece que no se cargaron bien las imágenes. Intentalo de nuevo, y si persiste el error llamá a Lukyni');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error... Tranky! Mandale a Lukyni una foteli del error y él seguro se encarga de solucionarlo {ex.Message}');</script>");
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
                aux.AltImagen = tbxPalabrasClave.Text;

                negocioPropiedades.modificar(aux);

                // Eliminar imagenes de la base de datos
                List<Imagenes> listaVieja = new List<Imagenes>();
                listaVieja = imagenesNegocio.listar(aux.Id);

                foreach (Imagenes img in listaVieja)
                {
                    imagenesNegocio.eliminar(img.Id);
                }

                listaImagenes = Session["listaImagenes"] as List<Imagenes>;

                if (listaImagenes != null)
                {
                    string rutaTemporal = Page.MapPath("~/Images/ImgPropiedades/Temporales/");
                    string rutaDestino = Page.MapPath($"~/Images/ImgPropiedades/{aux.Codigo}/");

                    foreach (Imagenes imagen in listaImagenes)
                    {
                        string nombreArchivo = Path.GetFileName(imagen.Ruta);
                        string rutaArchivoTemporal = Path.Combine(rutaTemporal, nombreArchivo);
                        string rutaArchivoDestino = Path.Combine(rutaDestino, nombreArchivo);

                        imagen.IdPropiedad = aux.Id;
                        imagen.Ruta = $"/Images/ImgPropiedades/{aux.Codigo}/{nombreArchivo}";
                        imagen.Alt = tbxPalabrasClave.Text;

                        imagenesNegocio.insertar(imagen);

                        if (File.Exists(rutaArchivoTemporal))
                            File.Move(rutaArchivoTemporal, rutaArchivoDestino);
                    }

                    Session.Remove("listaImagenes");
                    Response.Redirect("DefaultAdmin.aspx", false);
                }

                borrarDatosDeSesión();

                borrarImagenesDeCarpetaTempoaral();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error... Tranky! Mandale a Lukyni una foteli del error y él seguro se encarga de solucionarlo {ex.Message}');</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            PropiedadesNegocio negocio = new PropiedadesNegocio();

            try
            {
                borrarDatosDeSesión();

                borrarImagenesDeCarpetaTempoaral();

                int id = int.Parse(Request.QueryString["id"]);
                negocio.eliminar(id);
                Response.Redirect("DefaultAdmin.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('No se pudo eliminar la propiedad: {ex.Message}');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                borrarDatosDeSesión();

                borrarImagenesDeCarpetaTempoaral();

                Response.Redirect("DefaultAdmin.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error... Tranky! Mandale a Lukyni una foteli del error y él seguro se encarga de solucionarlo {ex.Message}');</script>");
            }
        }

        protected void btnCargarImagenesImagenes_Click(object sender, EventArgs e)
        {
            // Crear Lista de imágenes
            listaImagenes = new List<Imagenes>();

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

                        // Crear carpeta temporal si no existe
                        string carpetaTemporal = Page.MapPath("/Images/ImgPropiedades/Temporales");

                        if (!Directory.Exists(carpetaTemporal))
                            Directory.CreateDirectory(carpetaTemporal);

                        // Guardar la ruta relativa para llevar a la base de dtos
                        string rutaProvisoria = "/Images/ImgPropiedades/Temporales/" + rutaArchivo;

                        string rutaAbsoluta = Page.MapPath(rutaProvisoria);

                        // Guardar la imagen
                        imagen.SaveAs(rutaAbsoluta);

                        aux.Ruta = rutaProvisoria;

                        listaImagenes.Add(aux);
                        //// Obtener la ruta final
                        //string rutaFinal = Server.MapPath(rutaProvisoria);

                        //// Agregar imagen a la lista y guardar archivo en la carpeta
                        //urlImagenes.Add(aux);
                    }
                    // Cargar lista de imágenes en sesión y recargar página para cargarlos archivos
                    if (Session["listaImagenes"] != null)
                    {
                        List<Imagenes> listaOriginal = new List<Imagenes>();
                        listaOriginal = Session["listaImagenes"] as List<Imagenes>;
                        Session.Remove("listaImagenes");
                        Session.Add("primeraCargaImg", true);
                        listaImagenes = listaOriginal.Union(listaImagenes).ToList();
                    }

                    Session.Add("listaImagenes", listaImagenes);
                    repImagenes.DataSource = listaImagenes;
                    repImagenes.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error... Tranky! Mandale a Lukyni una foteli del error y él seguro se encarga de solucionarlo {ex.Message}');</script>");
            }

        }

        public void cargarDatosSesion()
        {
            try
            {
                if (Session["campoCodigo"] != null)
                    tbxCodigo.Text = (string)Session["campoCodigo"];
                if (Session["campoTitulo"] != null)
                    tbxTitulo.Text = (string)Session["campoTitulo"];
                if (Session["campoBio"] != null)
                    tbxBio.Text = (string)Session["campoBio"];
                if (Session["campoDescripcion"] != null)
                    tbxDescripcion.Text = (string)Session["campoDescripcion"];
                if (Session["campoTipoPropiedad"] != null)
                    ddlTipoPropiedad.SelectedValue = (string)Session["campoTipoPropiedad"];
                if (Session["campoTipoContrato"] != null)
                    ddlTipoContrato.SelectedValue = (string)Session["campoTipoContrato"];
                if (Session["campoMoneda"] != null)
                    ddlMoneda.SelectedValue = (string)Session["campoMoneda"];
                if (Session["campoPrecio"] != null)
                    tbxPrecio.Text = (string)Session["campoPrecio"];
                if (Session["campoActivo"] != null)
                    chbxActivo.Checked = (bool)Session["campoActivo"];
                if (Session["campoDestacado"] != null)
                    chbxDestacado.Checked = (bool)Session["campoDestacado"];
                if (Session["campoAmbientes"] != null)
                    tbxAmbientes.Text = (string)Session["campoAmbientes"];
                if (Session["campoDormitorios"] != null)
                    tbxDormitorios.Text = (string)Session["campoDormitorios"];
                if (Session["campoBanios"] != null)
                    tbxBaños.Text = (string)Session["campoBanios"];
                if (Session["campoMtCubiertos"] != null)
                    tbxMetrosCubiertos.Text = (string)Session["campoMtCubiertos"];
                if (Session["campoMtTotales"] != null)
                    tbxMetrosTotales.Text = (string)Session["campoMtTotales"];
                if (Session["campoPlantas"] != null)
                    tbxPlantas.Text = (string)Session["campoPlantas"];
                if (Session["campoCocheras"] != null)
                    tbxCocheras.Text = (string)Session["campoCocheras"];
                if (Session["campoDptos"] != null)
                    ddlDepartamentos.SelectedValue = (string)Session["campoDptos"];
                if (Session["campoLocalidades"] != null)
                    ddlLocalidades.SelectedValue = (string)Session["campoLocalidades"];
                if (Session["campoPueblos"] != null)
                    ddlPueblos.SelectedValue = (string)Session["campoPueblos"];
                if (Session["campoVideo"] != null)
                    tbxVideo.Text = (string)Session["campoVideo"];
                if (Session["campoUbicacion"] != null)
                    tbxUbicacion.Text = (string)Session["campoUbicacion"];
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error... Tranky! Mandale a Lukyni una foteli del error y él seguro se encarga de solucionarlo {ex.Message}');</script>");
            }
        }

        protected void guardarEnSesion_TextChanged(object sender, EventArgs e)
        {
            string id = ((TextBox)sender).ID;

            if (id == "tbxCodigo")
                Session.Add("campoCodigo", tbxCodigo.Text);
            if (id == "tbxTitulo")
                Session.Add("campoTitulo", tbxTitulo.Text);
            if (id == "tbxPrecio")
                Session.Add("campoPrecio", tbxPrecio.Text);
            if (id == "tbxBio")
            {
                int diferencia = tbxBio.Text.Length;
                contadorCharBio = diferencia;
                Session.Add("campoBio", tbxBio.Text);
            }
            if (id == "tbxDescripcion")
            {
                int diferencia = tbxDescripcion.Text.Length;
                contadorCharDesc = diferencia;
                Session.Add("campoDescripcion", tbxDescripcion.Text);
            }
            if (id == "tbxAmbientes")
                Session.Add("campoAmbientes", tbxAmbientes.Text);
            if (id == "tbxDormitorios")
                Session.Add("campoDormitorios", tbxDormitorios.Text);
            if (id == "tbxBaños")
                Session.Add("campoBanios", tbxBaños.Text);
            if (id == "tbxMetrosTotales")
                Session.Add("campoMttotales", tbxMetrosTotales.Text);
            if (id == "tbxMetrosCubiertos")
                Session.Add("campoMtCubiertos", tbxMetrosCubiertos.Text);
            if (id == "tbxPlantas")
                Session.Add("campoPlantas", tbxPlantas.Text);
            if (id == "tbxCocheras")
                Session.Add("campoCocheras", tbxCocheras.Text);
            if (id == "tbxVideo")
                Session.Add("campoVideo", tbxVideo.Text);
            if (id == "tbxUbicacion")
                Session.Add("campoUbicacion", tbxUbicacion.Text);

            Session.Add("datosGuardados", true);
        }

        public void borrarDatosDeSesión()
        {
            Session.Remove("campoCodigo");
            Session.Remove("campoTitulo");
            Session.Remove("campoTipoContrato");
            Session.Remove("campoTipoPropiedad");
            Session.Remove("campoMoneda");
            Session.Remove("campoPrecio");
            Session.Remove("campoActivo");
            Session.Remove("campoDestacado");
            Session.Remove("campoBio");
            Session.Remove("campoDescripcion");
            Session.Remove("campoAmbientes");
            Session.Remove("campoBaños");
            Session.Remove("campoDormitorios");
            Session.Remove("campoMtTotales");
            Session.Remove("campoMtCubiertos");
            Session.Remove("campoPlantas");
            Session.Remove("campoCocheras");
            Session.Remove("campoDpto");
            Session.Remove("campoLocalidades");
            Session.Remove("campoPueblos");
            Session.Remove("campoUbicacion");
            Session.Remove("campoVideo");
            Session.Remove("datosGuardados");
        }

        public void borrarImagenesDeCarpetaTempoaral()
        {
            string rutaTemporal = Page.MapPath("~/Images/ImgPropiedades/Temporales/");
            if (Directory.GetFiles(rutaTemporal).Length > 0)
            {
                foreach (var item in Directory.GetFiles(rutaTemporal))
                {
                    File.Delete(item);
                }
            }
        }

        protected void guardarEnSesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ((DropDownList)sender).ID;

            if (id == "ddlTipoPropiedad")
                Session.Add("campoTipoPropiedad", ddlTipoPropiedad.SelectedValue);
            if (id == "ddlTipoContrato")
                Session.Add("campoTipoContrato", ddlTipoContrato.SelectedValue);
            if (id == "ddlMoneda")
                Session.Add("campoMoneda", ddlMoneda.SelectedValue);
            if (id == "ddlDepartamentos")
                Session.Add("campoDpto", ddlDepartamentos.SelectedValue);
            if (id == "ddlLocalidades")
                Session.Add("campoLocalidades", ddlLocalidades.SelectedValue);
            if (id == "ddlPueblos")
                Session.Add("campoPueblos", ddlPueblos.SelectedValue);

            Session.Add("datosGuardados", true);

        }

        protected void guardarEnSession_ChekedChanged(object sender, EventArgs e)
        {
            string id = ((CheckBox)sender).ID;

            if (id == "chbxActivo")
                Session.Add("campoActivo", chbxActivo.Checked);
            if (id == "chbxDestacado")
                Session.Add("campoDestacado", chbxDestacado.Checked);

            Session.Add("datosGuardados", true);

        }
    }
}