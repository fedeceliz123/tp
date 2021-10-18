using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace WebStagePro.Paginas.Compras
{
    public partial class CargarCompra : System.Web.UI.Page
    {
        Negocio.NegocioProveedores nPro = new NegocioProveedores();
        Negocio.NegocioMaterial nMat = new NegocioMaterial();
        Negocio.NegocioCompras nCom = new NegocioCompras();
        Negocio.NegocioDetalleCompras nDC = new NegocioDetalleCompras();
        Entidades.compras com = new compras();
        Entidades.detalle_compra dc = new detalle_compra();

        private void llenarEntidadCom()
        {
            com.id_proveedor = selectProveedor.SelectedValue;
            com.fecha = txtFecha.Text;
            com.factura = txtFactura.Text;
        }

        private void llenarEntidadDetallecompra()
        {
            if(Session["Estado"].ToString() != "Cargado")
            {

            Session["Compra"]= nCom.UltimoID();
            }
            int compra = int.Parse(Session["Compra"].ToString());

            dc.id_compra = compra;
            dc.codigo_material = int.Parse(txtCOdigo.Text);
            dc.cantidad = int.Parse(txtCantidad.Text);
            dc.precio = int.Parse(txtPrecio.Text);
        }



        private void cargarCombo()
        {
            selectProveedor.DataSource = nPro.CargarCombo(); ;
            selectProveedor.DataValueField = "cuit";
            selectProveedor.DataTextField = "nombre_fantasia";
            selectProveedor.DataBind();

        }

        private void LlenarGV()
        {
            GVMaterial.DataSource = null;
            GVMaterial.DataSource= nMat.ListarMaterialFiltro(txtProducto.Text,"si");
            GVMaterial.DataBind();

        }

        private void LlenarGVDetalle()
        {
            int id = int.Parse(Session["Compra"].ToString());

            GVDetalle.DataSource = null;
            GVDetalle.DataSource = nDC.ListarDetalle2(id);
            GVDetalle.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Estado"].ToString()=="Cargado")
            {
                ContenedorCabe.Visible = false;
            }
            else
            {
                ContenedorCabe.Visible = true;
            }


            cargarCombo();
            LlenarGV();

            LlenarGVDetalle();



        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGV();
        }

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index= Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Agregar")
            {
                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();
                txtCOdigo.Text = Session["CodigoMaterial"].ToString();
              
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            llenarEntidadCom();


            string estado = Session["Estado"].ToString();

            if (estado != "Cargado" )
            {

            nCom.CargarCompra(com);
            }
            
            llenarEntidadDetallecompra();
            nDC.cargarDetalleCompra(dc);

            Session["Estado"] = "Cargado";

            int id = int.Parse(Session["Compra"].ToString());
            int idd = nDC.UltimoID(id);

            nDC.aumentoCantidad(int.Parse(txtCantidad.Text),txtCOdigo.Text);
            nDC.aumentoTotal(id,idd);


            lblTotal.Text = "Total: $" + nCom.Total(id);

            LlenarGVDetalle();
            Limpiar();
        }


        private void Limpiar()
        {
            txtCOdigo.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session["Estado"] = "";
            Session["Compra"] = "0";
            Response.Redirect("~/Paginas/Compras/ListarCompras.aspx");

        }

        protected void btnFinalizat_Click(object sender, EventArgs e)
        {
            Session["Estado"] = "";
            Session["Compra"] = "0";
        }

        protected void GVDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index= Convert.ToInt32(e.CommandArgument);

            if (e.CommandName== "Eliminar")
            {
                Session["DetalleCompra"] = (GVDetalle.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }
          
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idd = int.Parse(Session["DetalleCompra"].ToString());
            int id = int.Parse(Session["Compra"].ToString());

            nDC.disminurTotal(id,idd);
            nDC.disminuirCantidad(idd,idd);

            lblTotal.Text = nCom.Total(id).ToString();

            nDC.eliminarDetalleCompra(idd);
            LlenarGVDetalle();
        }
    }
}