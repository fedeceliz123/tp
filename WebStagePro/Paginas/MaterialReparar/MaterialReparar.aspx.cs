using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace WebStagePro.Paginas
{
    public partial class MaterialReparar : System.Web.UI.Page
    {

        Negocio.NegocioMaterial nMat = new NegocioMaterial();
        Negocio.NegocioMaterialReparar nMR = new NegocioMaterialReparar();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGVMaterial();
            txtCodigo.Enabled = false;
        }

        private void llenarGVMaterial()
        {
            GVMaterial.DataSource = null;
            GVMaterial.DataSource = nMat.ListarMaterialFiltro(txtMaterial.Text, "si");
            GVMaterial.DataBind();
        }

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Agregar")
            {
                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();
                txtCodigo.Text = Session["CodigoMaterial"].ToString();
                Session["CantidadDisponible"] = nMat.Disponibilidad(txtCodigo.Text);
               


            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarGVMaterial();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListarReparaciones/ListarReparaciones.aspx");
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {

          

            if (ValidarCodigo() == true)
            {
                string msg = "No hay codigo para realizar carga";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);

                return;
            }

            if (ValidarCantidad()==true)
            {
                string msg = "La cantidad no puede ser mayor a "+ nMat.Disponibilidad(txtCodigo.Text)+" ni menor a 1";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);

                return;
            }

            if (ValidarFecha() == true)
            {
                string msg = "La fecha mayor a la de hoy " ;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);

                return;
            }




            try
            {

            nMR.CargarReparacion(txtCodigo.Text,int.Parse(txtCantidad.Text),txtDetalle.Text,txtFechaI.Text) ;

            int resta = -int.Parse(txtCantidad.Text);

            nMR.actualizarDisp(resta,txtCodigo.Text);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Carga de reparacion";
            lblAccion.Text = "Se realizo la carga con exito";
                limpiar();

            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Carga de reparacion";
                lblAccion.Text = "Error en la carga";
            }


        }


        private void limpiar()
        {
            txtCantidad.Text = "0";
            txtCodigo.Text = "";
            txtDetalle.Text = "";
            txtFechaI.Text = "";


        }

        private bool ValidarCantidad() 
        {
            if (txtCantidad.Text == ""|| txtCantidad.Text == "0"||int.Parse(txtCantidad.Text) > nMat.Disponibilidad(txtCodigo.Text)  )
            {
                return true;
                
            }
            else
            {
                return false;
            }

          



        }
        private bool ValidarFecha()
        {
            if (txtFechaI.Text == "" || DateTime.Parse(txtFechaI.Text) > DateTime.Now )
            {
                return true;

            }
            else
            {
                return false;
            }

        }


        private bool ValidarCodigo()
        {
            if (txtCodigo.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}