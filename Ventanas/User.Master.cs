using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (tbxBuscar.Text != "")
            //    {
            //        string campo = tbxBuscar.Text;
            //        Response.Redirect("Lista.aspx?campo=" + campo);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Session.Add("error", ex.ToString());
            //    Response.Redirect("ErrorUser.aspx");
            //}
        }
    }
}