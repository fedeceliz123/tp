using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;


namespace WebStagePro.Paginas.Eventos
{
    public partial class ListarEventos : System.Web.UI.Page
    {
        Negocio.NegocioEventos nEven = new NegocioEventos();
        Entidades.Eventos even = new Entidades.Eventos();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGV();
        }

        private void llenarGV()
        {

            string date;
            if (txtFechaInicio.Text != "")
            {
                date = (DateTime.Parse(txtFechaInicio.Text)).ToString("dd-MM-yyyy");

            }
            else
            {
                date = DateTime.Now.ToString("dd_MM-yyyy");
            }

            DataTable dt =  nEven.ListarEventos("si",txtBuscar.Text,date);

            GVEventos.DataSource = null;
            GVEventos.DataSource = dt;
            GVEventos.DataBind();


        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            llenarGV();


        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Paginas/Eventos/CargaEventos.aspx");

        }
        private void LlenarClientes()
        {
            selectCliente.DataSource = null;
            selectCliente.DataSource = nEven.CargarClientes();
            selectCliente.DataValueField = "dni";
            selectCliente.DataTextField = "cliente";
            selectCliente.DataBind();
        }

        private void LlenarEmpleado()
        {
            selectEncargado.DataSource = null;
            selectEncargado.DataSource = nEven.CargarEmpleados();
            selectEncargado.DataValueField = "dni";
            selectEncargado.DataTextField = "empleado";
            selectEncargado.DataBind();
        }

            private void LlenarCampos()
        {
            int evento = int.Parse(Session["Evento"].ToString());

            LlenarClientes();
            LlenarEmpleado();
                                    
            DataTable dt = nEven.LlenarCampos(evento);

            foreach(DataRow row in dt.Rows)
            {
                txtId.Text = row["id"].ToString();
                selectCliente.SelectedValue = row["id_cliente"].ToString();
                txtFechai.Text = (DateTime.Parse(row["fecha_inicio"].ToString())).ToString("yyyy-MM-dd");
                if (row["hora_inicio"].ToString() == "")
                {
                    selectHora.SelectedValue = "00:00";
                }
                else
                {
                selectHora.SelectedValue = row["hora_inicio"].ToString();

                }



                if (row["fecha_fin"].ToString() == "")
                {
                    txtFechaf.Text = (DateTime.Parse(row["fecha_inicio"].ToString())).ToString("yyyy-MM-dd");
                }
                else
                {

                txtFechaf.Text = (DateTime.Parse(row["fecha_fin"].ToString())).ToString("yyyy-MM-dd");
                }
                txtLugar.Text = row["lugar"].ToString();
                selectEncargado.SelectedValue = row["encargado"].ToString();
                txtTotal.Text = row["total"].ToString();
                txtDetalle.Text = row["detalle"].ToString();
                txtDescuento.Text = row["descuento"].ToString();


            }





        }


        protected void GVEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Session["Evento"] = (GVEventos.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Evento";
                LlenarCampos();
                camposhabilitados();
                btnEditar.Visible = true;
                btnReactivar.Visible = false;
            }
            if (e.CommandName == "Ver")
            {
                Session["Evento"] = (GVEventos.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver Evento";
                LlenarCampos();
                camposDeshabilitados();
                btnReactivar.Visible = false;
                btnEditar.Visible = false;

            }
            if (e.CommandName == "Eliminar")
            {
                Session["Evento"] = (GVEventos.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
                lblEliminar.Text = lblEliminar.Text + " el Evento ";
                txtMotivo.Text = "";
            }
            if (e.CommandName == "Cargar")
            {
                Session["Evento"] = (GVEventos.DataKeys[index].Value).ToString();
                Response.Redirect("~/Paginas/SaldidaMaterial/MaterialParaEvento.aspx");

            }
            if (e.CommandName == "Personal")
            {
                Session["Evento"] = (GVEventos.DataKeys[index].Value).ToString();
                Response.Redirect("~/Paginas/PersonalEvento/PersonalEvento.aspx");

            }
        }


        private void llenarEntidad()
        {
            even.id = int.Parse(txtId.Text);
            even.id_cliente = selectCliente.SelectedValue.ToString() ;
            even.fecha_inicio = txtFechai.Text;
            even.hora_inicio = selectHora.SelectedValue.ToString();
            even.fecha_fin = txtFechaf.Text;
            even.lugar = txtLugar.Text;
            even.encargado = selectEncargado.SelectedValue.ToString();
            if (txtDescuento.Text == "")
            {
                even.descuento = 0;
            }
            else
            {

            even.descuento = double.Parse(txtDescuento.Text);
            }
            even.total = int.Parse(txtTotal.Text);
            even.detalle = txtDetalle.Text;

        }


        protected void MasEmpleados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Empleados/CargarEmpleado.aspx");
        }

        protected void MasClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes/CargaClinete.aspx");
        }
   
        protected void btnEditar_Click(object sender, EventArgs e) 
        {
            llenarEntidad();

            try
            {

            nEven.modificarEvento(even);
            //if(txtDescuento.Text!="" && txtDescuento.Text!="0")
            // {
            //        int id = int.Parse(Session["Evento"].ToString());
            //        float total = float.Parse(txtTotal.Text);
            //        float desc =Math.Round((1- int.Parse(txtDescuento.Text) / 100),2);
            //        total = total * desc;
            //        int totalF = (int)total;

            //        nEven.actualizarTotal(totalF,id);


            // }

            llenarGV();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificacion de Evento";
            lblAccion.Text = "Se realizo la modificacion con exito";
            }catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificacion de Evento";
                lblAccion.Text = "Error en la modificacion";
            }
        }

        private void camposhabilitados()
        {
            txtId.Enabled = false;
            selectCliente.Enabled=true;
            txtFechai.Enabled = true;
            selectHora.Enabled = true;
              txtFechaf.Enabled = true;
            txtLugar.Enabled = true;
             selectEncargado.Enabled = true;
           txtDescuento.Enabled = true;
            txtTotal.Enabled = true;
            txtDetalle.Enabled = true;
        }

        private void camposDeshabilitados()
        {
            txtId.Enabled = false;
            selectCliente.Enabled = false;
            txtFechai.Enabled = false;
            selectHora.Enabled = false;
            txtFechaf.Enabled = false;
            txtLugar.Enabled = false;
            selectEncargado.Enabled = false;
            txtDescuento.Enabled = false;
            txtTotal.Enabled = false;
            txtDetalle.Enabled = false;
        }


        protected void btnElimina_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["Evento"].ToString());


            try
            {

            nEven.BajaEvento(id,txtMotivo.Text);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/V.png";
                lblCarga.Text = "Eliminacion de Evento";
                lblAccion.Text = "Eliminacion con exito";
                llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Eliminacion de Evento";
                lblAccion.Text = "Error en la eliminicion";
            }

        }
    }
}