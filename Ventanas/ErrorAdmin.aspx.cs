using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class ErrorAdmin : System.Web.UI.Page
    {
        public string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
                error = (string)Session["error"];
        }
    }
}