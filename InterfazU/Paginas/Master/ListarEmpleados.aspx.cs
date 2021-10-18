using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace InterfazU.Paginas.Master
{
    public partial class ListarEmpleados : System.Web.UI.Page
    {
        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();
        Entidades.Empleados Emp = new Empleados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            gvEmp.DataSource=nEmp.ListarEmp("si");
            gvEmp.DataBind();

            }
        }

        protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // Se obtiene la fila seleccionada del gridview
            //
            GridViewRow row = gvEmp.SelectedRow;

            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            int id = Convert.ToInt32(gvEmp.DataKeys[row.RowIndex].Value);


           

            Label1.Text = "Se edito "+id.ToString();

        }


        int dni;
        bool accion;
        protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                int id = Convert.ToInt32(gvEmp.DataKeys[index].Value);
                
                accion = true;
                dni = id;

                Session["dni"] = id.ToString();

                Response.Redirect("~/Paginas/Master/DatosEmpleados.aspx");

            }
            else if (e.CommandName == "eliminar")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                int id = Convert.ToInt32(gvEmp.DataKeys[index].Value);
                dni = id;

            }
        }
    }
}