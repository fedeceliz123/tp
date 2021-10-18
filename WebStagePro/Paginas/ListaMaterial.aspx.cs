using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace WebStagePro.Paginas
{
    public partial class ListaMaterial : System.Web.UI.Page
    {
            Negocio.NegocioMaterial nMat = new NegocioMaterial();
        private void QR( string codigo)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(codigo);
            System.Drawing.Image QR = (System.Drawing.Image)img;
           
            using (MemoryStream ms = new MemoryStream())
            {
                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                imgQR.Src = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                imgQR.Height = 200;
                imgQR.Width = 200;
                              
               
            }

           

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            llenarGV();

            //if (chActivo.Checked == true)
            //{
            //    Session["Activo"] = "no";
            //}
            //else
            //{
            //    Session["Activo"] = "si";
            //}
            if (!IsPostBack)
            {
         
            }

        }

        private void llenarGV()
        {


            GVMaterial.DataSource = null;
            GVMaterial.DataSource= nMat.ListarMaterial(Session["Activo"].ToString());
            GVMaterial.DataBind();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string activo = Session["Activo"].ToString();
            GVMaterial.DataSource = null;
            GVMaterial.DataSource = nMat.ListarMaterialFiltro(txtBuscar.Text,activo);
            GVMaterial.DataBind();

            

        }


        private void llenarCampos()
        {
            DataTable dt = nMat.LlenarCampos(Session["CodigoMaterial"].ToString());
            string formato = "";
            foreach (DataRow row in dt.Rows)
            {

                selectMedida.DataSource = nMat.LlenarMedida(int.Parse(row["tipo"].ToString()));
                selectMedida.DataValueField = "id";
                selectMedida.DataTextField = "medida";
                selectMedida.DataBind();
                selectMedida.Items.Insert(0, new ListItem("Seleccione una medida de material", "0"));
                selectMedida.SelectedValue = row["medida"].ToString();

                Session["Tipo"] = row["tipo"].ToString();
                Session["Modelo"] = row["modelo"].ToString();

                if (int.Parse((row["tipo"]).ToString()) < 10)
                {
                    formato = "0" + (row["tipo"]).ToString();
                    
                }
                else
                {
                    formato = (row["tipo"]).ToString();
                }
                if (int.Parse((row["modelo"]).ToString()) < 10)
                {
                    formato = formato + "0" + (row["modelo"]).ToString();
                }
                else
                {
                    formato = formato + (row["modelo"]).ToString();

                }

                selectFormato.DataSource = nMat.LlenarFormato(formato);
                selectFormato.DataValueField = "id";
                selectFormato.DataTextField = "formato";
                selectFormato.DataBind();
                selectFormato.Items.Insert(0, new ListItem("Seleccione un formato de material", "0"));
                selectFormato.SelectedValue = row["formato"].ToString();

                txtCodigo.Text = row["codigo"].ToString();
                txtStock.Text = row["stock_general"].ToString();
                txtDisponibilidad.Text = row["disponobilidad"].ToString();
                txtDetalle.Text = row["detalle"].ToString();
                txtPrecio.Text = row["precio"].ToString();

                QR(row["codigo"].ToString());

            }


        }
      

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {

           int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
               

                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Editar material";
                btnEditar.Visible = true;
                llenarCampos();
                CamposHabilitados();
                
                btnReactivar.Visible = false;
            }
            if (e.CommandName == "Ver")
            {
                

                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('#myModal').modal();", true);
                lblModal.Text = "Ver material";
                btnEditar.Visible = false;
                llenarCampos();
                CamposdesHabilitados();
               

                string activo = Session["Activo"].ToString();

                if ( activo== "no")
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
                
                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalEliminar", "$('#modalEliminar').modal();", true);
                lblEliminar.Text = lblEliminar.Text + " el material " + Session["CodigoMaterial"].ToString();
                txtMotivo.Text = "";
            }


        }

        private void CamposHabilitados()
        {
            txtCodigo.Enabled = false;
            txtDetalle.Enabled = true;
            txtDisponibilidad.Enabled = true;
            txtStock.Enabled = true;
            selectFormato.Enabled = true;
            selectMedida.Enabled = true;
            txtPrecio.Enabled = true;
        }
        private void CamposdesHabilitados()
        {
            txtCodigo.Enabled = false;
            txtDetalle.Enabled = false;
            txtDisponibilidad.Enabled = false;
            txtStock.Enabled = false;
            selectFormato.Enabled = false;
            selectMedida.Enabled = false;
            txtPrecio.Enabled = false;
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtDisponibilidad.Text) > int.Parse(txtStock.Text))
            {
                string msg = "La disponibilidad no puede ser mayor al stock";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);
                return;
            }


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);

            try
            {

            nMat.ModificarMaterial(int.Parse(selectMedida.SelectedValue.ToString()),int.Parse(selectFormato.SelectedValue.ToString()),int.Parse(txtStock.Text),int.Parse(txtDisponibilidad.Text),txtCodigo.Text,txtDetalle.Text,int.Parse(txtPrecio.Text));
                imgCarga.ImageUrl = "../Imagenes/V.png";
                lblCarga.Text = "Modificacion de Material";
                lblAccion.Text = "Se realizo la modificacion con exito";

            }
            catch
            {
                imgCarga.ImageUrl = "../Imagenes/x.png";
                lblCarga.Text = "Modificacion de Material";
                lblAccion.Text = "Error en la modificacion";
            }


        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtMotivo.Text == "")
            {
                string msg = "Seleccione un motivo";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            imgCarga.ImageUrl = "../Imagenes/V.png";
            lblCarga.Text = "Eliminacion de Material";
            lblAccion.Text = "Se realizo la eliminacion con exito";

            nMat.BajaMaterial(Session["CodigoMaterial"].ToString(), txtMotivo.Text);

            Session["CodigoMaterial"] = null;
            llenarGV();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/CargaMaterial.aspx");
        }

        protected void MasMedida_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalNuevo", "$('#modalNuevo').modal();", true);
            lblNuevo.Text = "Nueva Medida";
            Session["Nuevo"] = "Medida";
            txtNuevo.Text = "";
        }

        protected void MasFormato_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalNuevo", "$('#modalNuevo').modal();", true);
            lblNuevo.Text = "Nuevo Formato";
            Session["Nuevo"] = "Formato";
            txtNuevo.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Session["Nuevo"].ToString() == "Medida")
            {


                nMat.CargaMedida(int.Parse(Session["Tipo"].ToString()),txtNuevo.Text);
            }
            if (Session["Nuevo"].ToString() == "Formato")
            {
                string formato = "";
                if (int.Parse((Session["Tipo"]).ToString()) < 10)
                {
                    formato = "0" + (Session["Tipo"]).ToString();

                }
                else
                {
                    formato = (Session["Tipo"]).ToString();
                }
                if (int.Parse((Session["Modelo"]).ToString()) < 10)
                {
                    formato = formato + "0" + (Session["Modelo"]).ToString();
                }
                else
                {
                    formato = formato + (Session["Modelo"]).ToString();

                }

                nMat.CargarFormato(formato,txtNuevo.Text,int.Parse(Session["Tipo"].ToString()));

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


        protected void btnReactivar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);
            try
            {

            nMat.ReintegrarMaterial(txtCodigo.Text);
            imgCarga.ImageUrl = "../Imagenes/V.png";
            lblCarga.Text = "Reintegro de Material";
            lblAccion.Text = "Se realizo el reintegro con exito";

            }
            catch
            {
                imgCarga.ImageUrl = "../Imagenes/x.png";
                lblCarga.Text = "Reintegro de Material";
                lblAccion.Text = "Error en reintegrar material";
            }

            llenarGV(); 


        }
        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}