using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Ventanas.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Si ya existe sesión activa, redirigir al Default
                if (Session["Usuario"] != null)
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            
            pnlError.Visible = false;

            try
            {
                string email = tbxEmail.Text;
                string pass = tbxPass.Text;

                UsuarioNegocio negocio = new UsuarioNegocio();

                Usuario usuarioAutenticado = new Usuario();
                usuarioAutenticado = negocio.Login(email, pass);

                Session.Add("Usuario", usuarioAutenticado);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}