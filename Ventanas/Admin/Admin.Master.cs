using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Ventanas.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public Usuario usuarioActivo;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si hay un usuario logueado en la sesión
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            usuarioActivo = (Usuario)Session["Usuario"];
            //lblEmailUsuario.Text = usuarioActivo.Email;
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("~/Admin/Login.aspx", false);
        }
    }
}