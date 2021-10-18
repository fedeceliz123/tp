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
    public partial class DiaDepesito : System.Web.UI.Page
    {

        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();
        Negocio.NegocioDiaDeposito nDD = new NegocioDiaDeposito();
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGV();
        }
        private void LlenarGV()
        {
            GVPersonal.DataSource = null;
            GVPersonal.DataSource = nEmp.FitroEmp("si", txtPersonal.Text);
            GVPersonal.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGV();
        }
        private void llenarCampos()
        {
            string dni = Session["Empleado"].ToString();
            DataTable dt = nEmp.selecEmplado(dni);

            foreach (DataRow row in dt.Rows)
            {
                txtDni.Text = row["dni"].ToString();
                txtNombre.Text = row["nombre"].ToString() + " " + row["apellido"].ToString();
                
            }

        }
        protected void GVPersonal_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Agregar")
            {
                Session["Empleado"] = (GVPersonal.DataKeys[index].Value).ToString();
                llenarCampos();

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

            nDD.CargarDia(txtFecha.Text,txtDni.Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Carga dia de deposito";
            lblAccion.Text = "Se realizo la carga con exito";
                limpiar();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Carga dia de deposito";
                lblAccion.Text = "Error en la carga";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/DiaDeposito/ListarDiaDeposito.aspx");
        }

        private void limpiar()
        {
            txtDni.Text = "";
            txtFecha.Text = "";
            txtNombre.Text = "";
        }
    }
}