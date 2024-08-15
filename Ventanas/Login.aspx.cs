using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (tbxPass.Text == "123")
            {
                Session.Add("sesionActiva", true);
                Response.Redirect("DefaultAdmin.aspx", false);
            }
            else
            {
                lblError.Text = "Contraseña incorrecta. Intente de nuevo";
            }
        }
    }
}