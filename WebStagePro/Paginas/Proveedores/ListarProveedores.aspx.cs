using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
//asda

namespace WebStagePro.Paginas.Proveedores
{
    public partial class ListarProveedores : System.Web.UI.Page
    {
        Negocio.NegocioProveedores nProv = new NegocioProveedores();
        Entidades.Proveedores pro = new Entidades.Proveedores();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();

        private void llenarEntidad()
        {
            pro.cuit = txtCuit.Text;
            pro.razon_social = txtRazonS.Text;
            pro.nombre_fantasia = txtNombreF.Text;
            pro.iva = selectIva.SelectedValue.ToString();
            pro.rubro = txtRubro.Text;
            pro.fecha_de_ingeso = txtFechaingreso.Text;
            

            dir.id_persona = txtCuit.Text;
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

            tel.id_persona = txtCuit.Text;
            tel.codigo_de_area = txtCodArea.Text;
            tel.numero = txtTelefono.Text;

            mail.id_persona = txtCuit.Text;
            mail.email = txtMail.Text;



        }


        protected void Page_Load(object sender, EventArgs e)
        {
          
            llenarGV();

        }
        private void llenarGV()
        {
            string activo = Session["Activo"].ToString();

            GVProveedores.DataSource = null;
            GVProveedores.DataSource = nProv.ListarProv(activo);
            GVProveedores.DataBind();

        }

        protected void GVProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Session["Proveedor"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar Proveedor";
                btnEditar.Visible = true;
                llenarCampos();
                CamposHabilitados();
                btnReactivar.Visible = false;

            }
            if (e.CommandName == "Ver")
            {
                Session["Proveedor"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver Provedor";
                btnEditar.Visible = false;
                llenarCampos();
                CamposdesHabilitados();

            }
            if (e.CommandName == "Eliminar")
            {
                Session["Proveedor"] = (GVProveedores.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
            }


        }

        private void CamposHabilitados()
        {
            txtCuit.Enabled = false;
            txtFechaingreso.Enabled = true;
            txtNombreF.Enabled = true;
            txtRazonS.Enabled = true;
            txtRubro.Enabled = true;
            selectIva.Enabled = true;

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
        private void CamposdesHabilitados()
        {
            txtCuit.Enabled = false;
            txtFechaingreso.Enabled = false;
            txtNombreF.Enabled = false;
            txtRazonS.Enabled = false;
            txtRubro.Enabled = false;
            selectIva.Enabled = false;

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
        }
        private void limpiar()
        {
            txtCuit.Text="";
            txtFechaingreso.Text = "";
            txtNombreF.Text = "";
            txtRazonS.Text = "";
            txtRubro.Text = "";
            selectIva.SelectedIndex=0;

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
        private void llenarCampos()
        {

            limpiar();

            DataTable dt = nProv.llenarCamposPro(Session["Proveedor"].ToString());

            foreach(DataRow row in dt.Rows)
            {
                txtCuit.Text = row["cuit"].ToString();
                txtRazonS.Text = row["razon_social"].ToString();
                txtNombreF.Text = row["nombre_fantasia"].ToString();
                selectIva.SelectedValue = row["iva"].ToString();
                txtRubro.Text = row["rubro"].ToString();
                txtFechaingreso.Text = (DateTime.Parse(row["fecha_de_ingreso"].ToString())).ToString("yyyy-MM-dd");
            }
          
            pro.cuit = Session["Proveedor"].ToString();

            DataTable direcciones = nProv.dirPro(pro);

            foreach(DataRow dir in direcciones.Rows)
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

            DataTable tel = nProv.telPro(pro);

            foreach(DataRow t in tel.Rows)
            {
                txtCodArea.Text = t["codigo_de_area"].ToString();
                txtTelefono.Text = t["numero"].ToString();
            }

            DataTable mail = nProv.mailPro(pro);

            foreach(DataRow m in mail.Rows)
            {
                txtMail.Text = m["email"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Proveedores/CargarProveedores.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            llenarEntidad();
            try
            {

            nProv.ModificarPro(pro,dir,tel,mail);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Modificacion de Proveedor";
            lblAccion.Text = "Se realizo la modificacion con exito";
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Modificacion de Proveedor";
                lblAccion.Text = "Error en la modificacion";
            }


        }

        protected void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {

            nProv.reactivarPro(txtCuit.Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Reactivar Proveedor";
            lblAccion.Text = "Se realizo la rectivacion con exito";
            llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Reactivacion Proveedor";
                lblAccion.Text = "Error en la reactivacion";
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string cuit = Session["Proveedor"].ToString();

            try
            {

            nProv.DarDeBajaPro(cuit,txtMotivo.Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../../Imagenes/V.png";
            lblCarga.Text = "Eliminacion de Proveedor";
            lblAccion.Text = "Se realizo la eliminacion con exito";
                llenarGV();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
                imgCarga.ImageUrl = "../../Imagenes/x.png";
                lblCarga.Text = "Eliminacion de Proveedor";
                lblAccion.Text = "Error en la eliminacion";
            }
        }

        protected void chActivo_CheckedChanged(object sender, EventArgs e)
        {
            if(chActivo.Checked==true)
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

       
    }
}