using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Page is Login || Page is ErrorAdmin))
                {
                    if (Session["sesionActiva"] is null)
                        Response.Redirect("Login.aspx", false);
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