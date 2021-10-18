using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;


namespace WebStagePro.Paginas.Precios
{
    public partial class ActualizarPrecios : System.Web.UI.Page
    {

        Negocio.NegocioMaterial nMat = new NegocioMaterial();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            LlenarGV();
            llenarTipo();
            selectModelo.Items.Insert(0, new ListItem("Seleccione un modelo de material", "0"));
            }


        }

        private void LlenarGV()
        {
            GVMaterial.DataSource = null;
            GVMaterial.DataSource = nMat.ListarMaterialFiltro(txtProducto.Text,"si");
            GVMaterial.DataBind();
        }

        private void llenarTipo()
        {
           
            selectTipo.DataSource = nMat.LlenarTipo();
            selectTipo.DataValueField = "id";
            selectTipo.DataTextField = "tipo";
            selectTipo.DataBind();
            selectTipo.Items.Insert(0, new ListItem("Seleccione un tipo de material", "0"));
        }
        private void llenarModelo()
        {
             selectModelo.DataSource = nMat.LlenarModelo(int.Parse(selectTipo.SelectedValue.ToString()));
            selectModelo .DataValueField = "id";
             selectModelo.DataTextField = "modelo";
             
            selectModelo .DataBind();
             selectModelo.Items.Insert(0, new ListItem("Seleccione un modelo de material", "0"));

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGV();
        }

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Agregar")
            {
                Session["CodigoMaterial"] = (GVMaterial.DataKeys[index].Value).ToString();
                txtCodigo.Text = Session["CodigoMaterial"].ToString();

            }

        }

        protected void selectTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            llenarModelo();
        }

        protected void selectModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chConfirmar_CheckedChanged(object sender, EventArgs e)
        {
            if (chConfirmar.Checked == true)
            {
                selectModelo.Enabled = true;
                selectTipo.Enabled = true;
                txtAumento.Enabled = true;

                txtAuCod.Enabled = false;
            }
            else
            {
                selectModelo.Enabled = false;
                selectTipo.Enabled = false;
                txtAumento.Enabled = false;

                txtAuCod.Enabled = true;


            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (chConfirmar.Checked == true)
            {

            }
            else
            {

            }
        }
    }
}