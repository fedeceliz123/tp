using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace WebStagePro.Paginas.Clientes
{
    public partial class CargaClinete : System.Web.UI.Page
    {

        Entidades.Clientes cli = new Entidades.Clientes();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Negocio.NegocioClientes nCli = new NegocioClientes();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes/ListarClientes.aspx");
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
        }

        private void llenarEntidad()
        {
            cli.dni = txtDni.Text;
            cli.nombre = txtNombre.Text;
            cli.apellido = txtApellido.Text;
            cli.sexo = selectSexo.SelectedValue.ToString();
            cli.fecha_de_nacimiento = txtFechaN.Text;
            cli.ocupacion = txtOcupacion.Text;
            cli.fecha_de_ingreso = txtFechaI.Text;
    



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



        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            llenarEntidad();
            try
            {

            nCli.CargarCli(cli,dir,tel,mail);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Carga de Cliente";
            lblAccion.Text = "Se realizo la carga con exito";
                limpiar();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Carga de Cliente";
                lblAccion.Text = "Error en la carga";
            }
        }
    }
}