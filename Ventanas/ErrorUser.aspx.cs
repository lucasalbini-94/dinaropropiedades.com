using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class ErrorUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorUser;
            if (Session["errorUser"] != null)
            {
                errorUser = (string)Session["errorUser"];
                lblError.Text = errorUser;
            }
        }
    }
}