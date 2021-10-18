using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace InterfazU.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Negocio.NegocioLogin NLog = new NegocioLogin();
        Entidades.Login Log = new Entidades.Login();
        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            Log.nombre_usuario = tbUsuario.Text;
            Log.contraseña = tbClave.Text;

            if (NLog.ingresar(Log) != 0)
            {
                string nombre = NLog.nombres(Log);


                Response.Redirect("~/Paginas/Master/Inicio.aspx?permiso="+NLog.ingresar(Log)+"&nombre="+nombre);
            }
            else
            {
                string msg = "El Usuario o contraseña son incorrecta";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);
            }

        }
    }
}