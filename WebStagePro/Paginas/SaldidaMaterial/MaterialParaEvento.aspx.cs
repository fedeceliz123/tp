using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace WebStagePro.Paginas.SaldidaMaterial
{
    public partial class CargarSalidaMaterial : System.Web.UI.Page
    {

        Negocio.NegocioSalidaMaterial nSMat = new NegocioSalidaMaterial();
        Negocio.NegocioMaterial nMat = new NegocioMaterial();
        Entidades.SalidaMaterial sMat = new SalidaMaterial();
        Negocio.NegocioEventos nEven = new NegocioEventos();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGVMaterial();
            llenarSalida();
            actualizarTotal();
        }
        

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName=="Agregar")
            {
                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();
                txtCodigo.Text = Session["CodigoMaterial"].ToString();
                Session["CantidadDisponible"] = nMat.Disponibilidad(txtCodigo.Text);
                lblDisp.Text = Session["CantidadDisponible"].ToString();
               

            }
        }

        private void llenarGVMaterial()
        {
            GVMaterial.DataSource = null;
            GVMaterial.DataSource = nMat.ListarMaterialFiltro(txtMaterial.Text,"si");
            GVMaterial.DataBind();
        }

        private void llenarEntidad()
        {
            int id = int.Parse(Session["Evento"].ToString());
            sMat.id_evento = id;
            sMat.codigo_material = txtCodigo.Text;
            sMat.cantidad = int.Parse(txtCantidad.Text);
        }

        private void CaragarMaterial()
        {
            llenarEntidad();
            nSMat.cargarSalida(sMat);


        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarGVMaterial();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Session["Evento"].ToString());
            
            CaragarMaterial();
                llenarSalida();
            int dis = int.Parse(txtCantidad.Text);


                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#madalCarga", "$('#madalCarga').modal();", true);
                lblCarga.Text = "Registro material de evento";
                imgCarga.ImageUrl = "../../Imagenes/V.png";
               
                lblAccion.Text = "Se agrego material con exito";

                nSMat.actualizarMaterial(-dis,txtCodigo.Text);
            llenarGVMaterial();

                actualizarTotal();
                lblTotal.Text = nEven.Total(id).ToString();

                limpiar();
            }
            catch
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#madalCarga", "$('#madalCarga').modal();", true);
                lblCarga.Text = "Registro material de evento";
                imgCarga.ImageUrl = "../../Imagenes/x.png";

                lblAccion.Text = "Error en el registro";


            }


        }

        private void llenarSalida()
        {
            int id = int.Parse(Session["Evento"].ToString());
            GVMaterialEvento.DataSource = null;
            GVMaterialEvento.DataSource = nSMat.listarSalida(id);
            GVMaterialEvento.DataBind();
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtCantidad.Text = "0";
            lblDisp.Text = "-";
        }

        private void actualizarTotal()
        {
            int id = int.Parse(Session["Evento"].ToString());
            int total= nEven.Total(id);

            nEven.actualizarTotal(total,id);


        }



        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["IDSalida"].ToString());

            int cant=nSMat.reCantidad(id);
            string cod = nSMat.reCodigo(id);

            nSMat.actualizarMaterial(+cant,cod);

            nSMat.QuitarMaterial(id);
            
            llenarSalida();
            llenarGVMaterial();
            actualizarTotal();
            int id2 = int.Parse(Session["Evento"].ToString());
            lblTotal.Text = nEven.Total(id2).ToString();

            limpiar();
        }

        protected void GVMaterialEvento_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
             

            if (e.CommandName == "Quitar")
            {
                Session["IDSalida"] = (GVMaterialEvento.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }

        }

        

        protected void btnVolver_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Eventos/ListarEventos.aspx");
        }
    }
}