using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazU.Paginas.Master
{
    public partial class ABMClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;

            }
            else
            {
                Calendar1.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tbFechaN.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }
    }
}