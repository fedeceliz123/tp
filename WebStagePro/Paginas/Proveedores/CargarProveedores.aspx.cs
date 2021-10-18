using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace WebStagePro.Paginas.Proveedores
{
    public partial class CargarProveedores : System.Web.UI.Page
    {
        Entidades.Proveedores prov = new Entidades.Proveedores();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Negocio.NegocioProveedores nPro = new NegocioProveedores();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void llenarEntidad()
        {
            prov.cuit = txtCuit.Text;
            prov.razon_social = txtRS.Text;
            prov.nombre_fantasia = txtNF.Text;
            prov.iva = selectIva.SelectedValue.ToString();
            prov.rubro = txtRubro.Text;
            prov.fecha_de_ingeso = txtFechaI.Text;

            dir.id_persona = txtCuit.Text;
            dir.pais = txtPais.Text;
            dir.provincia = txtProvincia.Text;
            dir.localidad = txtLocoalidad.Text;
            dir.cp = txtCP.Text;
            dir.barrio = txtBarrio.Text;
            dir.calle = txtCalle.Text;
            dir.numero = txtN.Text;
            dir.piso = txtPiso.Text;
            dir.dpto = txtDpto.Text;
            dir.mzna = txtMzna.Text;
            dir.lote = txtLote.Text;

            tel.id_persona = txtCuit.Text;
            tel.codigo_de_area = txtCodArea.Text;
            tel.numero = txtTelefono.Text;

            mail.id_persona = txtCuit.Text;
            mail.email = txtMail.Text;



        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Proveedores/ListarProveedores.aspx");
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            llenarEntidad();
            
            nPro.CargarPro(prov,dir,tel,mail);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../Imagenes/V.png";
            lblCarga.Text = "Carga de Proveedores";
            lblAccion.Text = "Se realizo la carga con exito";
            limpiar();

        }

        private void limpiar()
        {
            txtCuit.Text = "";
            txtRS.Text = "";
             txtNF.Text = "";
             selectIva.SelectedIndex = 0;
             txtRubro.Text = "";
             txtFechaI.Text = "";

           
           txtPais.Text = "";
            txtProvincia.Text = "";
             txtLocoalidad.Text = "";
            txtCP.Text = "";
             txtBarrio.Text = "";
             txtCalle.Text = "";
             txtN.Text = "";
             txtPiso.Text = "";
            txtDpto.Text = "";
             txtMzna.Text = "";
            txtLote.Text = "";

      
             txtCodArea.Text = "";
            txtTelefono.Text = "";
 
            txtMail.Text="";
        }
    }
}