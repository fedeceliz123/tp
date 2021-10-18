using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;



namespace WebStagePro.Paginas.PersonalEvento
{
    public partial class PersonalEvento : System.Web.UI.Page
    {

        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();
        Negocio.NegocioSalidaEmpleado nSE = new NegocioSalidaEmpleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGV();
            LlenarGVSaldida();
        }

        private void LlenarGV()
        {
            GVPersonal.DataSource = null;
            GVPersonal.DataSource = nEmp.FitroEmp("si",txtPersonal.Text);
            GVPersonal.DataBind();
        }

        private void LlenarGVSaldida()
        {
            int id = int.Parse(Session["Evento"].ToString());

            GVPersonalEvento.DataSource = null;
            GVPersonalEvento.DataSource = nSE.ListaSalidaEmp(id);
            GVPersonalEvento.DataBind();
        }


        private void llenarCampos()
        {
            string dni = Session["Empleado"].ToString();
            DataTable dt = nEmp.selecEmplado(dni);

            foreach(DataRow row in dt.Rows)
            {
                txtDni.Text = row["dni"].ToString();
                txtNombre.Text = row["nombre"].ToString() + " " + row["apellido"].ToString();
                txtPuesto.Text = row["puesto"].ToString();
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGV();
        }

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index= Convert.ToInt32(e.CommandArgument);

            if (e.CommandName== "Agregar")
            {
                Session["Empleado"] = (GVPersonal.DataKeys[index].Value).ToString();
                llenarCampos();

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int evento = int.Parse(Session["Evento"].ToString());

            try
            {

            nSE.CargarSalidaEmpl(evento,txtDni.Text);
            LlenarGVSaldida();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/V.png";
                lblCarga.Text = "Agregar Personal";
                lblAccion.Text = "Se realizo la carga con exito";
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Carga Personal";
                lblAccion.Text = "Error en la carga";
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Eventos/ListarEventos.aspx");
        }

        protected void GVPersonalEvento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           int index= Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Quitar")
            {
                Session["SalidaEmpleado"]= (GVPersonalEvento.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["SalidaEmpleado"].ToString());

            try
            {

            nSE.eliminarSalida(id);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/V.png";
                lblCarga.Text = "Quitar Personal";
                lblAccion.Text = "Se realizo la eliminacion con exito";
                LlenarGVSaldida();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Quitar Personal";
                lblAccion.Text = "Error en la eliminacion";
            }

        }
    }
}