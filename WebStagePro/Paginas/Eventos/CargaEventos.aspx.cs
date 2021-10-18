using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace WebStagePro.Paginas.Eventos
{
    public partial class CargaEventos : System.Web.UI.Page
    {


        Negocio.NegocioEventos nEven = new NegocioEventos();
        Entidades.Eventos even = new Entidades.Eventos();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarClientes();
            llenarEmplados();
        }
        private void llenarEntidad()
        {
            
            even.id_cliente = selectClientes.SelectedValue.ToString();
            even.fecha_inicio = txtFechaI.Text;
            even.hora_inicio = DropDownList1.SelectedValue.ToString();
            even.fecha_fin = txtFechaF.Text;
            even.lugar = txtLugar.Text;
            even.encargado = selectEncargado.SelectedValue.ToString();
           
           even.descuento = 0;
            
            even.total = 0;
            even.detalle = txtDetalle.Text;

        }


        protected void btnMasEncargado_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Paginas/Empleados/CargarEmpleado.aspx");
        }

        protected void btnMasCliente_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes/CargaClinete.aspx");
        }

        private void llenarClientes()
        {
            selectClientes.DataSource = null;
            selectClientes.DataSource = nEven.CargarClientes();
            selectClientes.DataValueField = "dni";
            selectClientes.DataTextField = "cliente";
            selectClientes.DataBind();
        }

        private void llenarEmplados()
        {
            selectEncargado.DataSource = null;
            selectEncargado.DataSource = nEven.CargarEmpleados();
            selectEncargado.DataValueField = "dni";
            selectEncargado.DataTextField = "empleado";
            selectEncargado.DataBind();
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {

            llenarEntidad();
            nEven.CargarEvento(even);
            limpiar();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/V.png";
                lblCarga.Text = "Carga de Evento";
                lblAccion.Text = "Se realizo la carga con exito";

            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Carga de Evento";
                lblAccion.Text = "Error en la carga";
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Eventos/ListarEventos.aspx");
        }

        private void limpiar()
        {
            llenarClientes();
            llenarEmplados();
            txtFechaI.Text = "";
            txtFechaF.Text = "";
            txtLugar.Text = "";
            DropDownList1.SelectedValue = "00:00";

        }


    }
}