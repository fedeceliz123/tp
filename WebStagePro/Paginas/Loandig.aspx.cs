using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStagePro.Paginas
{
    public partial class Loandig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            string url = Request.QueryString["url"].ToString();
            Response.Redirect("~"+url);
        }
    }
}