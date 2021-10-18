using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.MaterialEvento
{
    public partial class MaterialEvento : Form
    {
        public MaterialEvento()
        {
            InitializeComponent();
        }

        Negocio.NegocioEventos nEven = new NegocioEventos();
        Entidades.Eventos eve = new Entidades.Eventos();
        Negocio.NegocioMaterial nMat = new NegocioMaterial();
        Entidades.SalidaMaterial sal = new SalidaMaterial();
        Negocio.NegocioSalidaMaterial salMat = new NegocioSalidaMaterial();
        private void CargarGrilla(DataTable dt)
        {
            dgvEven.DataSource = null;
            dgvEven.DataSource = dt;
            dgvEven.Columns[0].Visible = false;
            dgvEven.Columns[1].Width = 250;
            dgvEven.Columns[2].Width = 150;
            dgvEven.Columns[3].Width = 150;
            dgvEven.Columns[4].Width = 250;


        }

        private void MaterialEvento_Load(object sender, EventArgs e)
        {
            CargarGrilla(nEven.ListarEventos(activo, tbBuscar.Text));
        }

       string activo="si";
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnEntrada.Visible = false;
            if (activo == "si")
            {
                CargarGrilla(nEven.ListarEventos(activo, tbBuscar.Text));
            }
            else
            {
                CargarGrilla(nEven.ListarInactivos(activo, tbBuscar.Text));
            }
        }

        private void chbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbInactivos.Checked == true)
            {
                activo = "no";
            }
            else
            {
                activo = "si";
            }
        }
        int id = 0;
        private void dgvEven_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvEven.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (salMat.Existe(id) == true)
            {
                btnCargar.Enabled = false;
                btnModificar.Enabled = true;
                btnDetalles.Enabled = true;
                btnEntrada.Visible = true;
            }
            else
            {
                btnCargar.Enabled = true;
                btnModificar.Enabled = false;
                btnDetalles.Enabled = false;
                btnEntrada.Visible = false;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            accion = 1;
            if (id == 0)
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Seleccione evento";
                mjs.Show();
                return;
            }
            panelMaterialEvento.Visible = true;

            CargarGrillaMat();
            llenarSalida();
            btnAceptar.Visible = true;
            dgvMaterial.Visible = true;
            dgvEntrada.Visible = false;
            lblMaterial.Visible = true;
            lblEntrada.Visible = false;
        }
        
        private void CargarGrillaMat()
        {
            dgvMaterial.DataSource = null;
           dgvMaterial.DataSource= nMat.ListarMaterialFiltro(tbCodigo.Text,"si");
            dgvMaterial.Columns[0].Visible = false;
            dgvMaterial.Columns[5].Visible = false;
        }
        int accion = 0;
        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            CargarGrillaMat();
         
        }

        string codigo;
        int cant;
        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {   cant= int.Parse(dgvMaterial.Rows[e.RowIndex].Cells[5].Value.ToString());
            nudCant.Value = 0;

            if (accion != 4)
            {

            nudCant.Maximum = cant;
            codigo = dgvMaterial.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (cant > 12)
            {
                lblDisponible.ForeColor = Color.Black;
            lblDisponible.Text = "Disponibles: "+cant;
                nudCant.Enabled = true;
            }
            else if (cant<12 && cant!=0)
            {
                lblDisponible.ForeColor = Color.Red;
                lblDisponible.Text = "Disponibles: " + cant;
                nudCant.Enabled = true;
            }
            else if (cant == 0)
            {
                lblDisponible.ForeColor = Color.Red;
                lblDisponible.Text = "Producto no disponible";
                nudCant.Enabled = false;
            }
            btnEliminar.Visible = false;
            }
            else
            {
                lblDisponible.Text = "";
                nudCant.Enabled = false;
                
            }

        }
        EntradaMaterial entMat = new EntradaMaterial();

        private void EntidadEntradaMat()
        {
            entMat.id_evento = id;
            entMat.codigo_material = codigo;
            entMat.cantidad = int.Parse(nudCant.Value.ToString());
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (nudCant.Value == 0)
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "La cantidad debe ser mayor a 0";
                mjs.Show();
                return;
            }
            CargarEntidad();

            if(accion!=4)
            {


            salMat.cargarSalida(sal);
            int total =  int.Parse(nudCant.Value.ToString());

            salMat.actualizarMaterial(-total,codigo);

            }
            else
            {
                
                EntidadEntradaMat();

                salMat.EntradaMaterial(entMat);

                salMat.actualizarMaterial(int.Parse(nudCant.Value.ToString()),codigo);

                llenarEntrada();
            }
            CargarGrillaMat();

            llenarSalida();

            nudCant.Value = 0;
            lblDisponible.Text = "";

            codigo = "";

         

        }


        private void llenarEntrada()
        {
            dgvEntrada.DataSource = null;
            dgvEntrada.DataSource = salMat.ListarEntrada(id);
            dgvEntrada.Columns[0].Visible = false;
            dgvEntrada.Columns[1].Visible = false;
            dgvEntrada.Columns[2].Width = 80;
            dgvEntrada.Columns[3].Width = 240;
            dgvEntrada.Columns[4].Width = 80;
        }

        private void llenarSalida()
        {
            dgvSalida.DataSource = null;
            dgvSalida.DataSource = salMat.listarSalida(id);
            dgvSalida.Columns[0].Visible = false;
            dgvSalida.Columns[1].Visible = false;
            dgvSalida.Columns[2].Width = 80;
            dgvSalida.Columns[3].Width = 240;
            dgvSalida.Columns[4].Width = 80;
        }

        private void CargarEntidad()
        {
            sal.id_evento = id;
            sal.codigo_material = codigo;
            sal.cantidad = int.Parse(nudCant.Value.ToString());
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            accion = 2;
            if (id == 0)
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Seleccione evento";
                mjs.Show();
                return;
            }
            panelMaterialEvento.Visible = true;
            CargarGrillaMat();
            llenarSalida();
            btnAceptar.Visible = true;
            dgvMaterial.Visible = true;
            dgvEntrada.Visible = false;
            lblMaterial.Visible = true;
            lblEntrada.Visible = false;
        }


       

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            accion = 3;
            if (id == 0)
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Seleccione evento";
                mjs.Show();
                return;
            }
            panelMaterialEvento.Visible = true;
            CargarGrillaMat();
            llenarSalida();

            btnAceptar.Visible = false;
            btnEliminar.Visible = false;
            dgvMaterial.Visible = true;
            dgvEntrada.Visible = false;
            lblMaterial.Visible = true;
            lblEntrada.Visible = false;


        }
        int id_sal;
        private void dgvSalida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (accion != 3 )
            {

            btnEliminar.Visible = true;
            lblDisponible.Text = "";
            cant = int.Parse(dgvSalida.Rows[e.RowIndex].Cells[4].Value.ToString());
            codigo = dgvSalida.Rows[e.RowIndex].Cells[2].Value.ToString();
            id_sal = int.Parse(dgvSalida.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            if (accion == 4)
            {
                btnEliminar.Visible = false;
                nudCant.Enabled = true;
                nudCant.Maximum = cant;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (accion != 4)
            {

            salMat.QuitarMaterial(id_sal);
            llenarSalida();
            salMat.actualizarMaterial(cant,codigo);
            CargarGrillaMat();
            }
            else
            {
                salMat.QuitarMateriaEntrada(idEntrada);
                llenarEntrada();
                salMat.actualizarMaterial(-cant,codigo);
                CargarGrillaMat();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelMaterialEvento.Visible = false;
            codigo = "";
            id = 0;
            accion = 0;
            id_sal = 0;
            btnEntrada.Visible = false;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            accion = 4;
            if (id == 0)
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Seleccione evento";
                mjs.Show();
                return;
            }
            panelMaterialEvento.Visible = true;
            CargarGrillaMat();
            llenarSalida();
            llenarEntrada();
            btnAceptar.Visible = true;

            dgvMaterial.Visible = false;
            lblMaterial.Visible = false;
            lblEntrada.Visible = true;
            dgvEntrada.Visible = true;
            
        }

        int idEntrada;
        private void dgvEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idEntrada = int.Parse(dgvEntrada.Rows[e.RowIndex].Cells[0].Value.ToString());
            cant = int.Parse(dgvEntrada.Rows[e.RowIndex].Cells[4].Value.ToString());
            codigo = dgvEntrada.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnEliminar.Visible = true;
        }
    }
}
