using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;


namespace WebStagePro.Paginas.DiaDeposito
{
    public partial class ListarDiaDeposito : System.Web.UI.Page
    {
        Negocio.NegocioDiaDeposito nDD = new NegocioDiaDeposito();
        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGV();
            llenarSelect();
        }

        private void llenarGV()
        {
            GVProveedores.DataSource = null;
            GVProveedores.DataSource = nDD.listarDiaDep();
            GVProveedores.DataBind();


        }

        private void llenarSelect()
        {
            selectEmpleado.DataSource = null;
            selectEmpleado.DataSource = nEmp.ListarEmpleadosSelect();
            selectEmpleado.DataValueField = "dni";
            selectEmpleado.DataTextField = "empleado";
            selectEmpleado.DataBind();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void chActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/DiaDeposito/DiaDepesito.aspx");
        }

        private void llenarCampos()
        {
            int id = int.Parse(Session["DiaDeposito"].ToString());

            DataTable dt = nDD.Dia(id);

            foreach(DataRow row in dt.Rows)
            {
                txtId.Text = row["id"].ToString();
                txtFecha.Text = (DateTime.Parse(row["fecha"].ToString())).ToString("yyyy-MM-dd");
                selectEmpleado.SelectedValue = row["id_empleado"].ToString();
            }


        }

        private void CamposHabilitados()
        {
            txtId.Enabled = false;
            txtFecha.Enabled = true;
            selectEmpleado.Enabled = true;
        }

        private void CamposDeshabilitados()
        {
            txtId.Enabled = false;
            txtFecha.Enabled = false;
            selectEmpleado.Enabled = false;
        }


        protected void GVProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Session["DiaDeposito"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Dia de deposito";
                btnEditar.Visible = true;
                llenarCampos();
                CamposHabilitados();
              

            }
            if (e.CommandName == "Ver")
            {
                Session["DiaDeposito"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver Dia de deposito";
                btnEditar.Visible = false;
                llenarCampos();
                CamposDeshabilitados();
               

            }
            if (e.CommandName == "Eliminar")
            {
                Session["DiaDeposito"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }


        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["DiaDeposito"].ToString());

            try
            {

            nDD.EditarDia(id,txtFecha.Text,selectEmpleado.SelectedValue);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificacion dia de deposito";
            lblAccion.Text = "Se realizo la Modificacion con exito";
                llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificacion dia de deposito";
                lblAccion.Text = "Error en la modificacion";

            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["DiaDeposito"].ToString());

            try
            {

            nDD.EliminarDia(id);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Eliminacion dia de deposito";
            lblAccion.Text = "Se realizo la eliminacion con exito";
                llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Eliminacion dia de deposito";
                lblAccion.Text = "Error en la eliminacion";
            }


        }
    }
}