using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace WebStagePro.Paginas.Compras
{
    public partial class ListarCompras : System.Web.UI.Page
    {

        Negocio.NegocioCompras nCom = new NegocioCompras();
        Negocio.NegocioDetalleCompras nDC = new NegocioDetalleCompras();
        Negocio.NegocioProveedores nPro = new NegocioProveedores();
        Entidades.compras com = new compras();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGV();
            llenarProveedor();
        }

        private void llenarGV()
        {
           

            GVCompras.DataSource = null;
            GVCompras.DataSource = nCom.ListarCompra();
            GVCompras.DataBind();
        }

        private void llenarProveedor()
        {
            DataTable dt = nPro.ListarProv("si");

            selectProveedor.DataSource = dt;
            selectProveedor.DataValueField = "Cuit";
            selectProveedor.DataTextField = "Nombre Fantasia";
            selectProveedor.DataBind();

        }

        private void CargarCampos()
        {
            int id = int.Parse(Session["Compra"].ToString());

            DataTable dt = nCom.ListarCompraId(id);


            foreach(DataRow row in dt.Rows)
            {
                selectProveedor.SelectedValue = row["id_proveedor"].ToString();
                txtFecha.Text = (DateTime.Parse(row["fecha"].ToString())).ToString("yyyy-MM-dd");
                txtFactura.Text = row["factura"].ToString();
                txtTotal.Text = row["total"].ToString();

            }


        }

        private void CamposHabilitados()
        {
            txtFactura.Enabled = true;
            txtFecha.Enabled = true;
            txtTotal.Enabled = false;
            selectProveedor.Enabled = true;
        }
        private void CamposDeshabilitados()
        {
            txtFactura.Enabled = false;
            txtFecha.Enabled = false;
            txtTotal.Enabled = false;
            selectProveedor.Enabled = false;
        }

        private void limpiar()
        {
            txtFactura.Text = "";
            txtFecha.Text = "";
            txtTotal.Text = "";
            
        }

        protected void GVCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                limpiar();
                Session["Compra"] = (GVCompras.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Compra";
                btnEditar.Visible = true;
                CargarCampos();

                CamposHabilitados();


            }
            if (e.CommandName == "Ver")
            {
                limpiar();
                Session["Compra"] = (GVCompras.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver Cliente";
                btnEditar.Visible = false;
                CargarCampos();
                CamposDeshabilitados();





            }
            if (e.CommandName == "Eliminar")
            {
                Session["Compra"] = (GVCompras.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }
            if (e.CommandName == "Cargar")
            {
                Session["Compra"] = (GVCompras.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalDetalle", "$('#modalDetalle').modal();", true);
                llenarGVdetalle();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Compras/CargarCompra.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void llenarEntidad()
        {

            com.id = int.Parse(Session["Compra"].ToString());
            com.factura = txtFactura.Text;
            com.fecha = txtFecha.Text;
            com.id_proveedor = selectProveedor.SelectedValue;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            llenarEntidad();
            try
            {

            nCom.editarCompra(com);
            llenarGV();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificar Compra";
            lblAccion.Text = "Modificacion Exitosa";
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificar Compra";
                lblAccion.Text = "Error en la modificacion";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["Compra"].ToString());
            try
            {
                nDC.DisminuirCantTotal(id);
                nDC.BorrarTodoDetalle(id);
                nCom.eliminarCarga(id);
                llenarGV();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/V.png";
                lblCarga.Text = "Eliminar Compra";
                lblAccion.Text = "Eliminacion Exitosa";
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Eliminacion Compra";
                lblAccion.Text = "Error en la eliminacion";
            }
        }


        private void llenarGVdetalle()
        {

            int id = int.Parse(Session["Compra"].ToString());
            GVDetalle.DataSource = null;
            GVDetalle.DataSource = nDC.ListarDetalle2(id);
            GVDetalle.DataBind();
        }

        protected void GVDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Eliminar")
            {
                Session["DetalleCompra"] = (GVDetalle.DataKeys[index].Value).ToString();
                int id = int.Parse(Session["Compra"].ToString());
                int idd = int.Parse(Session["DetalleCompra"].ToString());

                nDC.disminurTotal(id, idd);
                nDC.disminuirCantidad(idd,idd);
                nDC.eliminarDetalleCompra(idd);


            llenarGVdetalle();
                llenarGV();
            }
        }

        protected void btnCargarMaterial_Click(object sender, EventArgs e)
        {
            Session["Estado"] = "Cargado";

            Response.Redirect("~/Paginas/Compras/CargarCompra.aspx");
        }
    }
}