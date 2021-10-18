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
    public partial class CargarEmpleado : System.Web.UI.Page
    {
        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();
        Entidades.Empleados emp = new Entidades.Empleados();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Entidades.Login login = new Entidades.Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarPermiso();
        }

        private void llenarEntidad()
        {
            emp.dni = txtDni.Text;
            emp.nombre = txtNombre.Text;
            emp.apellido = txtApellido.Text;
            emp.sexo = selectSexo.SelectedValue.ToString();
            emp.fecha_nacimiento = txtFechaN.Text;
            emp.puesto = txtPuesto.Text;
            emp.fecha_ingreso = txtFechaI.Text;
            emp.activo = "si";




            dir.id_persona = txtDni.Text;
            dir.pais = txtPais.Text;
            dir.provincia = txtProvincia.Text;
            dir.localidad = txtLocoalidad.Text;
            dir.cp = txtCP.Text;
            dir.barrio = txtBarrio.Text;
            dir.calle = tctCalle.Text;
            dir.numero = txtN.Text;
            dir.piso = txtPiso.Text;
            dir.dpto = txtDpto.Text;
            dir.mzna = txtMzna.Text;
            dir.lote = txtLote.Text;

            tel.id_persona = txtDni.Text;
            tel.codigo_de_area = txtCodArea.Text;
            tel.numero = txtTelefono.Text;

            mail.id_persona = txtDni.Text;
            mail.email = txtMail.Text;

            login.contraseña = tctClave.Text;
            login.nombre_usuario = txtUsuario.Text;
            login.permiso = int.Parse(selectPermiso.SelectedValue.ToString());
            login.dni = txtDni.Text;
            login.email = txtMail.Text;

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
            selectPermiso.DataSource = nEmp.listarPermisos();
            selectPermiso.DataValueField = "id";
            selectPermiso.DataTextField = "permiso";
            selectPermiso.DataBind();
            selectPermiso.Items.Insert(0, new ListItem("Seleccione un permiso de usuario", "0"));


        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
         
            llenarEntidad();

            //try
            //{

            nEmp.cargarEmpleado(emp,dir,tel,mail,login);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Carga de Empleado";
            lblAccion.Text = "Se realizo la carga con exito";
                limpiar();
            //}
            //catch
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            //    imgCarga.ImageUrl = "../../Imagenes/x.png";
            //    lblCarga.Text = "Carga de Empleado";
            //    lblAccion.Text = "Error en la carga";
            //}
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Empleados/ListarEmpleado.aspx");
        }

        protected void chAc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaN.Text = "";
            txtPuesto.Text = "";
            selectSexo.SelectedIndex = 0;
            txtFechaI.Text = "";

         

            txtPais.Text = "";
            txtProvincia.Text = "";
            txtLocoalidad.Text = "";
            txtCP.Text = "";
            txtBarrio.Text = "";
            tctCalle.Text = "";
            txtN.Text = "";
            txtPiso.Text = "";
            txtDpto.Text = "";
            txtMzna.Text = "";
            txtLote.Text = "";

            txtCodArea.Text = "";
            txtTelefono.Text = "";

            txtMail.Text = "";

            txtUsuario.Text = "";
            tctClave.Text = "";
            selectPermiso.SelectedValue = "0";


        }
    }
}