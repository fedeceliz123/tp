using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazU
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         
            Calendar1.SelectedDates.Add(DateTime.Parse("02/02/2021"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}