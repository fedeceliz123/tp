using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace WebStagePro.Paginas.ListarReparaciones
{
    public partial class ListarReparaciones : System.Web.UI.Page
    {

        Negocio.NegocioMaterialReparar nMR = new NegocioMaterialReparar();
        Negocio.NegocioMaterial nMat = new NegocioMaterial();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            LlenarGV();
        }

        public void LlenarGV()
        {
            string fin = Session["ListaReparacion"].ToString();
            DataTable dt = nMR.ListarReparacion(fin,txtBuscar.Text);
            GVReparaciones.DataSource = null;
            GVReparaciones.DataSource = dt;
            GVReparaciones.DataBind();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            LlenarGV();
        }

        protected void chActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chActivo.Checked == true)
            {
                Session["ListaReparacion"] = "not null";
            }
            else
            {
                Session["ListaReparacion"] = "null";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MaterialReparar/MaterialReparar.aspx");
        }

        private void llenarCampos()
        {
            int id = int.Parse(Session["IDReparacion"].ToString());

            DataTable dt = nMR.LlenarCampos(id);


            foreach (DataRow row in dt.Rows)
            {
                txtID.Text = row["id"].ToString();
                txtCodigoMat.Text = row["codigo_de_material"].ToString();
                txtCantidad.Text = row["cantidad"].ToString();
                txtDetalle.Text = row["motivo"].ToString();
                txtFechaI.Text = (DateTime.Parse(row["fecha_de_entrada"].ToString())).ToString("yyyy-MM-dd");
                if (row["fecha_de_salida"].ToString() != "")
                {
                txtFechaS.Text = (DateTime.Parse(row["fecha_de_salida"].ToString())).ToString("yyyy-MM-dd");

                }
                txtDetalleSalida.Text = row["detalle_de_raparacion"].ToString();
                Session["Cantidad"] = int.Parse(row["cantidad"].ToString());

            }


        }
        private void CamposHabilitados()
        {
            txtID.Enabled = false;
            txtCodigoMat.Enabled = false;
            txtCantidad.Enabled= true;
            txtDetalle.Enabled = true;
            txtFechaI.Enabled = true;
            txtFechaS.Enabled = true;
            txtDetalleSalida.Enabled = true;
        }

        private void CamposdesHabilitados()
        {
            txtID.Enabled = false;
            txtCodigoMat.Enabled = false;
            txtCantidad.Enabled = false;
            txtDetalle.Enabled = false;
            txtFechaI.Enabled = false;
            txtFechaS.Enabled = false;
            txtDetalleSalida.Enabled = false;
        }

        protected void GVReparaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {


                Session["IDReparacion"] = (GVReparaciones.DataKeys[index].Value).ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Reparacion";
                btnEditar.Visible = true;
                llenarCampos();
                CamposHabilitados();

                

             
            }
            if (e.CommandName == "Ver")
            {


                Session["IDReparacion"] = (GVReparaciones.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
               lblModal.Text = "Ver Reparacion";
                btnEditar.Visible = false;
                llenarCampos();
                CamposdesHabilitados();


              
            }
            if (e.CommandName == "Eliminar")
            {
                Session["IDReparacion"] = (GVReparaciones.DataKeys[index].Value).ToString();
                llenarCampos();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);

                

            }
        }

        private int Diponibilidad()
        {
            int disponible = 0;

            disponible=nMat.Disponibilidad(txtCodigoMat.Text);



            return disponible;
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {

           

            int resta = 0;

            resta = int.Parse(Session["Cantidad"].ToString()) - int.Parse(txtCantidad.Text);

            

            try
            {


            nMR.EditarReparacion(int.Parse(txtID.Text),int.Parse(txtCantidad.Text),txtDetalle.Text,txtFechaI.Text,txtDetalleSalida.Text);
           
            if (txtFechaS.Text != "")
            {
                nMR.EditarSalida(txtFechaS.Text,int.Parse(txtID.Text));
            }

                nMR.actualizarDisp(resta,txtCodigoMat.Text);


            LlenarGV();

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificacion de Reparacion";
            lblAccion.Text = "Se realizo la modificacion con exito";


            Session["IDReparacion"] = null;

            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificacion de Reparacion";
                lblAccion.Text = "Error en la modificacion";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["IDReparacion"].ToString());

            try
            {


            nMR.EliminarReparacion(id);

            LlenarGV();


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Eliminacion de reparacion";
            lblAccion.Text = "Se realizo la eliminacion con exito";

                nMR.actualizarDisp(int.Parse(txtCantidad.Text),txtCodigoMat.Text);

            Session["IDReparacion"] = null;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Eliminacion de Reparacion";
                lblAccion.Text = "Error en la eliminacion";
            }
        }
    }
}