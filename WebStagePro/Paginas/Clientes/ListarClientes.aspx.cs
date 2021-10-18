using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;


namespace WebStagePro.Paginas.Clientes
{
    public partial class ListarClientes : System.Web.UI.Page
    {

        Negocio.NegocioClientes nCli = new NegocioClientes();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Entidades.Clientes cli = new Entidades.Clientes();


        private void llenarEntidad()
        {
            cli.dni = txtDni.Text;
            cli.nombre = txtNombre.Text;
            cli.apellido = txtApellido.Text;
            cli.sexo = selectSexo.SelectedValue.ToString();
            cli.fecha_de_nacimiento = txtFechaN.Text;
            cli.ocupacion = txtOcupacion.Text;
            cli.fecha_de_ingreso = txtFechaI.Text;
            cli.fecha_de_egreso = txtFechaSal.Text;
            cli.motivo_egreso = txtMot.Text;
            


            dir.id_persona = txtDni.Text;
            dir.pais = txtPais.Text;
            dir.provincia = txtProvincia.Text;
            dir.localidad = txtLocalidad.Text;
            dir.cp = txtCP.Text;
            dir.barrio = txtBarrio.Text;
            dir.calle = txtCalle.Text;
            dir.numero = txtN.Text;
            dir.piso = txtPiso.Text;
            dir.dpto = txtDpto.Text;
            dir.mzna = txtMzna.Text;
            dir.lote = txtLodte.Text;

            tel.id_persona =txtDni.Text;
            tel.codigo_de_area = txtCodArea.Text;
            tel.numero = txtTelefono.Text;

            mail.id_persona = txtDni.Text;
            mail.email = txtMail.Text;



        }





        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGV();
        }

        private void LlenarGV()
        {
            string activo = Session["Activo"].ToString();

            GVProveedores.DataSource = null;
            GVProveedores.DataSource= nCli.filtroCli(activo,txtBuscar.Text);
            GVProveedores.DataBind();


        }

        private void limpiar()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaN.Text = "";
            txtOcupacion.Text = "";
            selectSexo.SelectedIndex = 0;
            txtFechaI.Text = "";

            txtFechaSal.Text = "";
            txtMot.Text = "";

            txtPais.Text = "";
            txtProvincia.Text = "";
            txtLocalidad.Text = "";
            txtCP.Text = "";
            txtBarrio.Text = "";
            txtCalle.Text = "";
            txtN.Text = "";
            txtPiso.Text = "";
            txtDpto.Text = "";
            txtMzna.Text = "";
            txtLodte.Text = "";

            txtCodArea.Text = "";
            txtTelefono.Text = "";

            txtMail.Text = "";
        }

        private void CamposHabilitados()
        {
            txtDni.Enabled = false;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtOcupacion.Enabled = true;
            txtFechaN.Enabled = true;
            selectSexo.Enabled = true;
            txtFechaI.Enabled = true;
            txtFechaSal.Enabled = true;
            txtMot.Enabled = true;

            txtPais.Enabled = true;
            txtProvincia.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            txtBarrio.Enabled = true;
            txtCalle.Enabled = true;
            txtN.Enabled = true;
            txtPiso.Enabled = true;
            txtDpto.Enabled = true;
            txtMzna.Enabled = true;
            txtLodte.Enabled = true;

            txtCodArea.Enabled = true;
            txtTelefono.Enabled = true;

            txtMail.Enabled = true;

        }
        private void CamposDeshabilitados()
        {
            txtDni.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtOcupacion.Enabled = false;
            txtFechaN.Enabled = false;
            selectSexo.Enabled = false;
            txtFechaI.Enabled = false;
            txtFechaSal.Enabled = false;
            txtMot.Enabled = false;

            txtPais.Enabled = false ;
            txtProvincia.Enabled = false;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            txtBarrio.Enabled = false;
            txtCalle.Enabled = false;
            txtN.Enabled = false;
            txtPiso.Enabled = false;
            txtDpto.Enabled = false;
            txtMzna.Enabled = false;
            txtLodte.Enabled = false;

            txtCodArea.Enabled = false;
            txtTelefono.Enabled = false;

            txtMail.Enabled = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes/CargaClinete.aspx");
        }

        protected void chActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chActivo.Checked == true)
            {
                Session["Activo"] = "no";
            }
            else
            {
                Session["Activo"] = "si";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGV();

            if (chActivo.Checked == true)
            {
                GVProveedores.Columns[6].Visible = false;
                GVProveedores.Columns[5].Visible = false;
            }
            else
            {
                GVProveedores.Columns[6].Visible = true;
                GVProveedores.Columns[5].Visible = true;
            }


        }

        protected void GVProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Session["Cliente"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Cliente";
                btnEditar.Visible = true;
                llenarCampos();
                CamposHabilitados();
                btnReactivar.Visible = false;

            }
            if (e.CommandName == "Ver")
            {
                Session["Cliente"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver Cliente";
                btnEditar.Visible = false;
                llenarCampos();
                CamposDeshabilitados();
                if(chActivo.Checked==true)
                {
                    btnReactivar.Visible = true;
                }
                else
                {
                    btnReactivar.Visible = false;
                }

            }
            if (e.CommandName == "Eliminar")
            {
                Session["Cliente"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }
        }

        protected void btnReactivar_Click(object sender, EventArgs e)
        {
            string dni = Session["Cliente"].ToString();
            try
            {

            nCli.reactivarCli(dni);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Reactivar de Cliente";
            lblAccion.Text = "Se realizo la reactivacion con exito";
            LlenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Reactivar de Cliente";
                lblAccion.Text = "Error en la reactivacion";
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            llenarEntidad();

            try
            {

            nCli.ModificarCliente(cli,dir,tel,mail);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificacion de Cliente";
            lblAccion.Text = "Se realizo la modificacion con exito";
            LlenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificacion de Cliente";
                lblAccion.Text = "Error en la modificacion";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string dni = Session["Cliente"].ToString();

            try
            {

            nCli.DarDeBajaCli(dni,txtMotivo.Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Elimincaion de Cliente";
            lblAccion.Text = "Se realizo la eliminacion con exito";
            LlenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Elimincaion de Cliente";
                lblAccion.Text = "Error en la eliminacion";
            }
        }

        private void llenarCampos()
        {

            limpiar();

            DataTable dt = nCli.llenarCamposCli(Session["Cliente"].ToString());

            foreach (DataRow row in dt.Rows)
            {
                txtDni.Text = row["dni"].ToString();
                txtNombre.Text = row["nombre"].ToString();
                txtApellido.Text = row["apellido"].ToString();
                selectSexo.SelectedValue = row["sexo"].ToString();
                txtOcupacion.Text = row["ocupacion"].ToString();
                if (row["fecha_de_ingreso"].ToString() != "")
                {

                txtFechaI.Text = (DateTime.Parse(row["fecha_de_ingreso"].ToString())).ToString("yyyy-MM-dd");
                }
                if (row["fecha_de_nacimiento"].ToString() != "")
                {
                txtFechaN.Text = (DateTime.Parse(row["fecha_de_nacimiento"].ToString())).ToString("yyyy-MM-dd");

                }
                if (row["fecha_de_egreso"].ToString() != "")
                {

                txtFechaSal.Text = (DateTime.Parse(row["fecha_de_egreso"].ToString())).ToString("yyyy-MM-dd");
                }
                txtMot.Text = row["motivo_egreso"].ToString();

            }

            cli.dni = Session["Cliente"].ToString();

            DataTable direcciones = nCli.dirClientes(cli);

            foreach (DataRow dir in direcciones.Rows)
            {

                txtPais.Text = dir["pais"].ToString();
                txtProvincia.Text = dir["provincia"].ToString();
                txtLocalidad.Text = dir["localidad"].ToString();
                txtCP.Text = dir["cp"].ToString();
                txtBarrio.Text = dir["barrio"].ToString();
                txtCalle.Text = dir["calle"].ToString();

                txtN.Text = dir["numero"].ToString();
                txtPiso.Text = dir["piso"].ToString();
                txtDpto.Text = dir["dpto"].ToString();
                txtMzna.Text = dir["mzna"].ToString();
                txtLodte.Text = dir["lote"].ToString();


            }

            DataTable tel = nCli.telCli(cli);

            foreach (DataRow t in tel.Rows)
            {
                txtCodArea.Text = t["codigo_de_area"].ToString();
                txtTelefono.Text = t["numero"].ToString();
            }

            DataTable mail = nCli.mailCli(cli);

            foreach (DataRow m in mail.Rows)
            {
                txtMail.Text = m["email"].ToString();
            }

        }

    }
}