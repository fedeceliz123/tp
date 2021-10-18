using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


namespace WebStagePro.Paginas.Login
{

    public partial class Login : System.Web.UI.Page
    {

        Negocio.NegocioLogin Nlog = new NegocioLogin();
        Entidades.Login Log = new Entidades.Login();

        protected void Page_Load(object sender, EventArgs e)
        {
         

        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            Log.contraseña = password.Text;
            Log.nombre_usuario = username.Text;

            if (Nlog.ingresar(Log) != 0)
            {
                Session["Permiso"] = Nlog.ingresar(Log);
                string nombre = Nlog.nombres(Log);
                Session["Usuario"] = Nlog.dni(Log);
               

                Response.Redirect("~/Inicio.aspx?empleado="+nombre);
                
            }
            else
            {

                string msg = "Usuario o contraseña incorrecta";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);
            }

            


        



        }
    }
}