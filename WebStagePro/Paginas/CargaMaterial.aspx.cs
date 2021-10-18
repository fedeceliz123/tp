using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
using System.IO;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;

namespace WebStagePro.Paginas
{
    public partial class Material : System.Web.UI.Page
    {

        Negocio.NegocioMaterial nMat = new NegocioMaterial();


        private void QR()
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(txtCodigo.Text);
            System.Drawing.Image QR = (System.Drawing.Image)img;

            using (MemoryStream ms = new MemoryStream())
            {
                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                imgQR.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                imgQR.Height = 200;
                imgQR.Width = 200;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
            LlenarTipo();
                SelectModelo.Items.Insert(0, new ListItem("Seleccione un modelo de material", "0"));
                selectMedida.Items.Insert(0, new ListItem("Seleccione una medida de material", "0"));
                selectFormato.Items.Insert(0, new ListItem("Seleccione un formato de material", "0"));
                
            }
          

        }

        private void LlenarTipo()
        {
            DataTable dt = nMat.LlenarTipo();

            selectTipo.DataSource = dt;
            selectTipo.DataValueField = "id";
            selectTipo.DataTextField = "tipo";
            selectTipo.DataBind();
            selectTipo.Items.Insert(0, new ListItem("Seleccione un tipo de material", "0"));
        }
        private void LlenarModelo()
        {
            SelectModelo.DataSource = nMat.LlenarModelo(int.Parse(selectTipo.SelectedValue.ToString()));
            SelectModelo.DataValueField = "id";
            SelectModelo.DataTextField = "modelo";
            
            SelectModelo.DataBind();
            SelectModelo.Items.Insert(0, new ListItem("Seleccione un modelo de material", "0"));
        }

        private void LlenarMedida()
        {
            selectMedida.DataSource = nMat.LlenarMedida(int.Parse(selectTipo.SelectedValue.ToString()));
            selectMedida.DataValueField = "id";
            selectMedida.DataTextField = "medida";
                 
            selectMedida.DataBind();
            selectMedida.Items.Insert(0, new ListItem("Seleccione una medida de material", "0"));
        }

        private void LlenarFormato()
        {
            
        }


        protected void selectTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarModelo();
            LlenarMedida();
            Session["Tipo"] = selectTipo.SelectedValue.ToString();
            txtCodigo.Text = "";


        }

        protected void SelectModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string format="";
            Session["Modelo"] = SelectModelo.SelectedValue.ToString();

            if (nMat.Ultimo(int.Parse(Session["Tipo"].ToString()), int.Parse(Session["Modelo"].ToString())) != "")
            {
                Session["UltimoMaterial"] = (nMat.Ultimo(int.Parse(Session["Tipo"].ToString()), int.Parse(Session["Modelo"].ToString()))).ToString();

            }
            else
            {
                Session["UltimoMaterial"] = "1";
            }

            if (int.Parse(Session["Tipo"].ToString()) < 10)
            {
                Session["CodigoMaterial"] = "0" + Session["Tipo"].ToString();
            }
            else
            {
                Session["CodigoMaterial"] = Session["Tipo"].ToString();
            }
            if (int.Parse(Session["Modelo"].ToString()) < 10)
            {
                Session["CodigoMaterial"] = Session["CodigoMaterial"].ToString() + "0" + (Session["Modelo"].ToString());
                Session["FormatoAux"] = Session["CodigoMaterial"].ToString();
                 format = Session["FormatoAux"].ToString();
            }
            else
            {
                Session["CodigoMaterial"] = Session["CodigoMaterial"].ToString() + (Session["Modelo"].ToString());
                Session["FormatoAux"] = Session["CodigoMaterial"].ToString();
                format = Session["FormatoAux"].ToString();
            }


            if (int.Parse(Session["UltimoMaterial"].ToString()) < 10)
            {
                Session["CodigoMaterial"] = Session["CodigoMaterial"].ToString() + "0" + Session["UltimoMaterial"].ToString();
            }
            else
            {
                Session["CodigoMaterial"] = Session["CodigoMaterial"].ToString() + Session["UltimoMaterial"].ToString();
            }
            txtCodigo.Text = Session["CodigoMaterial"].ToString();

            selectFormato.DataSource = nMat.LlenarFormato(format);
            selectFormato.DataValueField = "id";
            selectFormato.DataTextField = "formato";
            selectFormato.DataBind();
            selectFormato.Items.Insert(0, new ListItem("Seleccione un formato de material", "0"));



        }

        protected void btnMasTipo_Click(object sender, ImageClickEventArgs e)
        {
            Session["Nuevo"] = "tipo";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalNuevo", "$('#modalNuevo').modal();", true);
            lblNuevo.Text = "Nuevo Tipo";
            txtNuevo.Text = "";
        }

        protected void btnMasModelo_Click(object sender, ImageClickEventArgs e)
        {
            Session["Nuevo"] = "modelo";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalNuevo", "$('#modalNuevo').modal();", true);
            lblNuevo.Text = "Nuevo Modelo";
            txtNuevo.Text = "";
        }

        protected void btnMasFormato_Click(object sender, ImageClickEventArgs e)
        {
            Session["Nuevo"] = "formato";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalNuevo", "$('#modalNuevo').modal();", true);
            lblNuevo.Text = "Nuevo Formato";
            txtNuevo.Text = "";
        }

        protected void btnMasMedida_Click(object sender, ImageClickEventArgs e)
        {
            Session["Nuevo"] = "medida";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalNuevo", "$('#modalNuevo').modal();", true);
            lblNuevo.Text = "Nuevo Medida";
            txtNuevo.Text = "";


        }

         
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            string codigo="";

            if (int.Parse(selectTipo.SelectedValue.ToString()) < 10)
            {
                codigo = "0" + selectTipo.SelectedValue.ToString();
            }
            else
            {
                codigo = selectTipo.SelectedValue.ToString();
            }

            if(int.Parse(SelectModelo.SelectedValue.ToString())<10)
            {
                codigo = codigo + "0" + SelectModelo.SelectedValue.ToString();
            }
            else
            {
                codigo = codigo + SelectModelo.SelectedValue.ToString();
            }



            if (Session["Nuevo"].ToString()== "tipo")
            {
                nMat.CargaTipo(txtNuevo.Text);
            }
            if (Session["Nuevo"].ToString() == "modelo")
            {
                nMat.CargaModelo(int.Parse(selectTipo.SelectedValue.ToString()), txtNuevo.Text);
            }
            if (Session["Nuevo"].ToString() == "formato")
            {
                nMat.CargarFormato(codigo,txtNuevo.Text,int.Parse(selectTipo.SelectedValue.ToString()));
            }
            if (Session["Nuevo"].ToString() == "medida")
            {
                

                nMat.CargaMedida(int.Parse(selectTipo.SelectedValue.ToString()),txtNuevo.Text);
            }


            LlenarFormato();
            LlenarMedida();
            LlenarModelo();
            LlenarTipo();
           
        }


        Entidades.Material mat = new Entidades.Material();

        private void cargarEntidad()
        {
            mat.codigo = txtCodigo.Text;
            mat.tipo = int.Parse(selectTipo.SelectedValue.ToString());
            mat.modelo = int.Parse(SelectModelo.SelectedValue.ToString());
            mat.numero = int.Parse(Session["UltimoMaterial"].ToString());
            mat.medida = int.Parse(selectMedida.SelectedValue.ToString());
            mat.formato = int.Parse(selectFormato.SelectedValue.ToString());
            if (txtStock.Text != "")
            {
                mat.stock_general = int.Parse(txtStock.Text);
                mat.disponobilidad= int.Parse(txtStock.Text);
            }
            else
            {
                mat.stock_general = 0;
                mat.disponobilidad = 0;
            }
            mat.detalle = txtDetalle.Text;
            mat.precio = int.Parse(txtPrecio.Text);


        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modalCarga", "$('#modalCarga').modal();", true);


            cargarEntidad();
            try
            {

                nMat.CargarMaterial(mat);
                imgCarga.ImageUrl = "../Imagenes/V.png";
                lblCarga.Text = "Carga de Material";
                lblAccion.Text = "Se realizo la carga con exito";

                Limpiar();
            }
            catch
            {
                imgCarga.ImageUrl = "../Imagenes/x.png";
                lblCarga.Text = "Carga de Material";
                lblAccion.Text = "Error en la carga";

                Limpiar();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaMaterial.aspx");
        }


        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtDetalle.Text = "";
            txtStock.Text = "";
            LlenarFormato();
            LlenarMedida();
            LlenarModelo();
            LlenarTipo();

        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            QR();
        }
    }
}