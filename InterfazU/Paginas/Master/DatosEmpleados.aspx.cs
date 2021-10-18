using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazU.Paginas.Master
{
    public partial class DatosEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                Label1.Text = Session["dni"].ToString();

            
        }
    }
}