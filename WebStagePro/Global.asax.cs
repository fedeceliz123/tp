using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebStagePro
{
    public class Global : System.Web.HttpApplication
    {

        
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["CodigoMaterial"] = null;
            Session["Permiso"] = null;
            Session["FormatoAux"] = null;
            Session["Tipo"] = null;
            Session["Modelo"] = null;
            Session["UltimoMaterial"] = null;
            Session["Nuevo"] = null;
            Session["Numero"] = null;
            Session["Activo"] = "si";
            Session["ListaReparacion"] = "null";
            Session["Proveedor"] = null;
            Session["Usuario"] = null;
            Session["Evento"] = null;
            Session["CantidadDisponible"] = null;
            Session["IDSalida"] = null;
            Session["IDReparacion"] = null;
            Session["Cantidad"] = null;
            Session["Mensaje"] = null;
            Session["Empleado"] = null;
            Session["SalidaEmpleado"] = null;
            Session["Cliente"] = null;
            Session["DiaDeposito"] = null;
            Session["Compra"] = "0";
            Session["DetalleCompra"] = null;
            Session["Estado"] = "";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}