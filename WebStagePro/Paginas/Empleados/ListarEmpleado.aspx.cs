using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace WebStagePro.Paginas.Empleados
{
    public partial class ListarEmpleado : System.Web.UI.Page
    {
        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();
        Entidades.Empleados emp = new Entidades.Empleados();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Entidades.Login login = new Entidades.Login();

        private void llenarEntidad()
        {
            emp.dni = txtDni.Text;
            emp.nombre = txtNombre.Text;
            emp.apellido = txtApellido.Text;
            emp.sexo = selectSexo.SelectedValue.ToString();
            emp.fecha_nacimiento = txtFechaN.Text;
            emp.puesto = txtOcupacion.Text;
            emp.fecha_ingreso = txtFechaI.Text;
            
          



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

            tel.id_persona = txtDni.Text;
            tel.codigo_de_area = txtCodArea.Text;
            tel.numero = txtTelefono.Text;

            mail.id_persona = txtDni.Text;
            mail.email = txtMail.Text;

            login.contraseña = txtClave.Text;
            login.nombre_usuario = txtUsuario.Text;
            login.permiso = int.Parse(selectPermiso.SelectedValue.ToString());


            if (chAc.Checked == true)
            {
                login.activo = "si";
            }
            else
            {
                login.activo = "no";
            }

        }


        private void llenarPermiso()
        {

           selectPermiso.DataSource= nEmp.listarPermisos();
            selectPermiso.DataValueField = "id";
            selectPermiso.DataTextField = "permiso";
            selectPermiso.DataBind();
            selectPermiso.Items.Insert(0, new ListItem("Seleccione un permiso de usuario", "0"));
        }

        private void llenarGV()
        {
            string activo = Session["Activo"].ToString();

            GVProveedores.DataSource = null;
            GVProveedores.DataSource = nEmp.ListarEmp(activo);
            GVProveedores.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGV();
            llenarPermiso();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarGV();
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

            txtClave.Enabled = true;
            txtUsuario.Enabled = false;
            selectPermiso.Enabled = true;

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

            txtPais.Enabled = false;
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

            txtClave.Enabled = false;
            txtUsuario.Enabled = false;
            selectPermiso.Enabled = false;




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Empleados/CargarEmpleado.aspx");
        }

        protected void GVProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                limpiar();
                Session["Empleado"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Cliente";
                btnEditar.Visible = true;
                llenarCampos();
                
                CamposHabilitados();
                btnReactivar.Visible = false;

            }
            if (e.CommandName == "Ver")
            {
                limpiar();
                Session["Empleado"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver Cliente";
                btnEditar.Visible = false;
                llenarCampos();
                CamposDeshabilitados();
                if (chActivo.Checked == true)
                {
                    btnReactivar.Visible = true;
                    txtFechaSal.Visible = true;
                    txtMot.Visible = true;
                    lblFS.Visible = true;
                    lblMot.Visible = true;
                }
                else
                {
                    btnReactivar.Visible = false;
                    txtFechaSal.Visible = false;
                    txtMot.Visible = false;
                    lblFS.Visible = false;
                    lblMot.Visible = false;
                }




            }
            if (e.CommandName == "Eliminar")
            {
                Session["Empleado"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }
        }


        private void llenarCampos()
        {

            limpiar();

            DataTable dt = nEmp.selecEmplado(Session["Empleado"].ToString());

            foreach (DataRow row in dt.Rows)
            {
                txtDni.Text = row["dni"].ToString();
                txtNombre.Text = row["nombre"].ToString();
                txtApellido.Text = row["apellido"].ToString();
                selectSexo.SelectedValue = row["sexo"].ToString();
                txtOcupacion.Text = row["puesto"].ToString();
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

            emp.dni = Session["Empleado"].ToString();

            DataTable direcciones = nEmp.direccionE(emp);

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

            DataTable tel = nEmp.telefonoE(emp);

            foreach (DataRow t in tel.Rows)
            {
                txtCodArea.Text = t["codigo_de_area"].ToString();
                txtTelefono.Text = t["numero"].ToString();
            }

            DataTable mail = nEmp.mailE(emp);

            foreach (DataRow m in mail.Rows)
            {
                txtMail.Text = m["email"].ToString();
            }

            DataTable log = nEmp.UserEmp(emp);

            foreach(DataRow l in log.Rows)
            {
                txtUsuario.Text = l["nombre_usuario"].ToString();
                txtClave.Text = l["contraseña"].ToString();
                selectPermiso.SelectedValue = l["permiso"].ToString();

                if (l["activo"].ToString() == "si")
                {

                chAc.Checked = true;
                }
                else
                {
                    chAc.Checked = false;
                }

            }


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

            txtUsuario.Text = "";
            txtClave.Text = "";
            selectPermiso.SelectedValue = "0";

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string dni = Session["Empleado"].ToString();

            try
            {

            nEmp.DarDeBajaEmp(dni, txtMotivo.Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Eliminar Empleado";
            lblAccion.Text = "Se realizo la eliminacion con exito";
            llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Eliminar Empleado";
                lblAccion.Text = "Error en la eliminacion";
            }
        }

        protected void btnReactivar_Click(object sender, EventArgs e)
        {
            string dni = Session["Empleado"].ToString();
            try
            {

            nEmp.ReintrearEmp(dni);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Reactivar Empleado";
            lblAccion.Text = "Se realizo la Reactivacion con exito";
            llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Reactivar Empleado";
                lblAccion.Text = "Error en la reactivacion";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            llenarEntidad();

            try
            {

            nEmp.ModificarEmp(emp,dir,tel,mail,login);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificacion de Empleado";
            lblAccion.Text = "Se realizo la Modificacion con exito";
            llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificacion de Empleado";
                lblAccion.Text = "Error en la modificacion";
            }

        }
    }
}