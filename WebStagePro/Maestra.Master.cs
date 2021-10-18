using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebStagePro
{
    public partial class Maestra : System.Web.UI.MasterPage

    {
        Negocio.NegocioLogin login = new NegocioLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            // string nombre = Request.QueryString["empleado"].ToString();

            // lblUsuario.Text = nombre;

            // string dni = Session["Usuario"].ToString();

            // MemoryStream ms = new MemoryStream();

            //ms= login.imagen(dni);

            // imagen(ms);

          


        }

        private void imagen(MemoryStream ms)
        {
           
               
                byte[] imageBytes = ms.ToArray();
                ImageUser.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                         



        }

        protected void linkProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Loandig.aspx?url="+ "/Paginas/Proveedores/ListarProveedores.aspx");
            //Response.Redirect("~/Paginas/Proveedores/ListarProveedores.aspx");
        }

        protected void linkMatelial_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/ListaMaterial.aspx");
            
        }

        protected void linkCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/Compras/ListarCompras.aspx");
        }

        protected void linkReaparar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/ListarReparaciones/ListarReparaciones.aspx");
            
        }

        protected void linkEventos_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/Eventos/ListarEventos.aspx");

        }

        protected void linkCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/Clientes/ListarClientes.aspx");
       
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/Empleados/ListarEmpleado.aspx");
            
        }

        protected void linkDiaDep_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/DiaDeposito/ListarDiaDeposito.aspx");

           
        }

        protected void linkPrecios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Loandig.aspx?url=" + "/Paginas/Precios/ActualizarPrecios.aspx");
        }
    }
}