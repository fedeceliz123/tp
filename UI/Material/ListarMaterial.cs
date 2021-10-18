using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;

namespace UI.Material
{
    public partial class ListarMaterial : Form
    {
        public ListarMaterial()
        {
            InitializeComponent();
        }

        string activo = "si";
        int accion = 0;

        Entidades.Material mat = new Entidades.Material();
        private void CrearQR()
        {
            QrEncoder qr = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode code = new QrCode();
            qr.TryEncode(tbCodigo.Text,out code);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize( 400,QuietZoneModules.Zero),Brushes.Black,Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(code.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var imagenTemp = new Bitmap(ms);
            var imagen = new Bitmap(imagenTemp, new Size(new Point(200, 200)));
            pbQR.Image = imagen;

            if (tbCodigo.Text.Length == 0)
            {
                pbQR.Image = UI.Properties.Resources.qr;
            }


        }

        Negocio.NegocioMaterial nMat = new NegocioMaterial(); 

        private void llenarDGV(DataTable dt)
        {
            dgvEmp.DataSource = null;
            dgvEmp.DataSource = dt;
            dgvEmp.Columns[0].Width = 133;
            dgvEmp.Columns[1].Width = 133;
            dgvEmp.Columns[2].Width = 133;
            dgvEmp.Columns[3].Width = 133;
            dgvEmp.Columns[4].Width = 133;
            dgvEmp.Columns[5].Width = 133;
        }
        private void ListarMaterial_Load(object sender, EventArgs e)
        {

            llenarDGV(nMat.ListarMaterial(activo));


            cbTipo.DataSource = null;
            cbTipo.DataSource = nMat.LlenarTipo();
            cbTipo.DisplayMember = "Tipo";
            cbTipo.ValueMember = "id";


        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            accion = 1;

            pStock.Visible = false;
            pDisp.Visible = false;
            lblDisp.Visible = false;
            lblStock.Visible = false;

            panelDatosPersonales.Visible = true;
            Habilitar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           if(cbTipo.DroppedDown == false)
            {
                cbTipo.DroppedDown = true;
            }
            else
            {
                cbTipo.DroppedDown = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cbModelo.DroppedDown == false)
            {
                cbModelo.DroppedDown = true;
            }
            else
            {
                cbModelo.DroppedDown = false;
            }
        }
        int tipo;
      

        private void cbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tipo = int.Parse(cbTipo.SelectedValue.ToString());

            cbModelo.DataSource = null;
            cbModelo.DataSource = nMat.LlenarModelo(tipo);
            cbModelo.DisplayMember = "modelo";
            cbModelo.ValueMember = "id";

            cbMedida.DataSource = null;
            cbMedida.DataSource = nMat.LlenarMedida(tipo);
            cbMedida.DisplayMember = "medida";
            cbMedida.ValueMember = "id";

         


            pbModelo.Enabled = true;
            pbMedida.Enabled = true;
            

        }

        int modelo;
        int numero;
        string codigo;
        string cod;
        string codigo2="";
        private void cbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            modelo = int.Parse(cbModelo.SelectedValue.ToString());
            if (nMat.Ultimo(tipo, modelo) != "")
            {
            numero = int.Parse(nMat.Ultimo(tipo, modelo));

            }
            else
            {
                numero = 1;
            }

            if (tipo < 10)
            {
                codigo = "0" + tipo.ToString();
            }
            else
            {
                codigo = tipo.ToString();
            }
            if (modelo < 10)
            {
                codigo = codigo + "0" + modelo.ToString();
                cod = codigo;
            }
            else
            {
                codigo = codigo + modelo.ToString();
            }

            
            if (numero < 10)
            {
                codigo = codigo + "0" + numero.ToString();
            }
            else
            {
                codigo = codigo + numero;
            }

            tbCodigo.Text = codigo;
            cbFormato.DataSource = null;
            cbFormato.DataSource = nMat.LlenarFormato(cod);
            cbFormato.DisplayMember = "formato";
            cbFormato.ValueMember = "id";
            pbFormato.Enabled = true;


        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            CrearQR();
        }

        int agregar = 0;

        private void pbTipo_Click(object sender, EventArgs e)
        {
            agregar = 1;

            tbNuevoCampo.Text = "";
            pNuevo.Visible = true;
            lblCarga.Text = "Ingrese el nombre del nuevo tipo:";
            lblCarga.Visible = true;
            btnAceptar2.Visible = true;
            btnCancelar2.Visible = true;
        }

        private void pbModelo_Click(object sender, EventArgs e)
        {
            agregar = 2;
            tbNuevoCampo.Text = "";
            pNuevo.Visible = true;
            lblCarga.Text = "Ingrese el nombre del nuevo modelo:";
            lblCarga.Visible = true;
            btnAceptar2.Visible = true;
            btnCancelar2.Visible = true;

        }

        private void btnAceptar2_Click(object sender, EventArgs e)
        {
            if (agregar == 1)
            {
                nMat.CargaTipo(tbNuevoCampo.Text);
            }
            else if (agregar == 2)
            {
                nMat.CargaModelo(tipo, tbNuevoCampo.Text);
            }
            else if (agregar == 3)
            {
                nMat.CargaMedida(tipo, tbNuevoCampo.Text);
            }
            else if(agregar==4)
            {
                nMat.CargarFormato(cod, tbNuevoCampo.Text,tipo);
            }

            pNuevo.Visible = false;
            lblCarga.Text = "";
            lblCarga.Visible = false;

            btnAceptar2.Visible = false;
            btnCancelar2.Visible = false;

            agregar = 0;
            pbModelo.Enabled = pbModelo.Enabled = true;
            pbMedida.Enabled = false; 
            pbMedida.Enabled = false;
            pbFormato.Enabled = false;

            cbTipo.DataSource = null;
            cbTipo.DataSource = nMat.LlenarTipo();
            cbTipo.DisplayMember = "Tipo";
            cbTipo.ValueMember = "id";
            cbModelo.DataSource = null;
            cbMedida.DataSource = null;
            cbFormato.DataSource = null;
            cbMedida.Enabled = false;
            cbModelo.Enabled = false;
            cbFormato.Enabled = false;

            

        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {

            pNuevo.Visible = false;
            lblCarga.Text = "";
            lblCarga.Visible = false;

            btnAceptar2.Visible = false;
            btnCancelar2.Visible = false;
            agregar = 0;
            pbModelo.Enabled = false;
            pbMedida.Enabled = false;
            pbFormato.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (codigo2 == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione el material";
                mensaje.Show();
                return;
            }

            accion = 2;
            pStock.Visible = true;
            pDisp.Visible = true;
            lblDisp.Visible = true;
            lblStock.Visible = true;
            panelDatosPersonales.Visible = true;
            Habilitar();
            llenarCampos();
            cbTipo.Enabled = false;
            cbModelo.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pbTipo.Visible = false;
            pbModelo.Visible = false;

        }

        private void llenarCampos()
        {
           DataTable dt= nMat.LlenarCampos(codigo2);

            foreach(DataRow obj in dt.Rows)
            {
                
               cbTipo.SelectedValue= int.Parse(obj["tipo"].ToString());
                tipo = int.Parse(cbTipo.SelectedValue.ToString());

                cbModelo.DataSource = null;
                cbModelo.DataSource = nMat.LlenarModelo(tipo);
                cbModelo.DisplayMember = "modelo";
                cbModelo.ValueMember = "id";
                cbModelo.SelectedValue = int.Parse(obj["modelo"].ToString());

                cbMedida.DataSource = null;
                cbMedida.DataSource = nMat.LlenarMedida(tipo);
                cbMedida.DisplayMember = "medida";
                cbMedida.ValueMember = "id";
                cbMedida.SelectedValue = int.Parse(obj["medida"].ToString());

                modelo = int.Parse(cbModelo.SelectedValue.ToString());
                if (nMat.Ultimo(tipo, modelo) != "")
                {
                    numero = int.Parse(nMat.Ultimo(tipo, modelo));

                }
                else
                {
                    numero = 1;
                }

                if (tipo < 10)
                {
                    codigo = "0" + tipo.ToString();
                }
                else
                {
                    codigo = tipo.ToString();
                }
                if (modelo < 10)
                {
                    codigo = codigo + "0" + modelo.ToString();
                    cod = codigo;
                }
                else
                {
                    codigo = codigo + modelo.ToString();
                }


                if (numero < 10)
                {
                    codigo = codigo + "0" + numero.ToString();
                }
                else
                {
                    codigo = codigo + numero;
                }

                
                cbFormato.DataSource = null;
                cbFormato.DataSource = nMat.LlenarFormato(cod);
                cbFormato.DisplayMember = "formato";
                cbFormato.ValueMember = "id";

                cbFormato.SelectedValue = int.Parse(obj["formato"].ToString());

                tbCodigo.Text = obj["codigo"].ToString();

                tbDisp.Text = obj["disponobilidad"].ToString();
                tbStock.Text = obj["stock_general"].ToString();
                tbNombre.Text = obj["detalle"].ToString();

            }

        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (codigo2 == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione el material";
                mensaje.Show();
                return;
            }

            pStock.Visible = true;
            pDisp.Visible = true;
            lblDisp.Visible = true;
            lblStock.Visible = true;
            panelDatosPersonales.Visible = true;
            Deshabilitar();
            BotonMas(pbFormato, pbMedida, pbModelo, pbTipo, false);
            llenarCampos();

        }

        private void BotonMas(PictureBox pb, PictureBox pb2, PictureBox pb3, PictureBox pb4,bool condicion)
        {
            pb.Visible= condicion;
            pb2.Visible = condicion;
            pb3.Visible = condicion;
            pb4.Visible = condicion;

        }


        private void Habilitar()
        {
            cbModelo.Enabled = true;
            cbTipo.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
          
            tbNombre.Enabled = true;
            tbStock.Enabled = true;
            tbDisp.Enabled = true;
            cbFormato.Enabled = false;
            
            pictureBox4.Enabled = true;
            pb.Enabled = true;
        }
        private void Deshabilitar()
        {
            cbModelo.Enabled = false;
            cbTipo.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
          
            tbNombre.Enabled = false;
            tbStock.Enabled = false;
            tbDisp.Enabled = false;
            cbFormato.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox4.Enabled = false;
            pb.Enabled = false;
            cbMedida.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (cbMedida.DroppedDown == false)
            {
                cbMedida.DroppedDown = true;
            }
            else
            {
                cbMedida.DroppedDown = false;
            }

        }

        private void pbMedida_Click(object sender, EventArgs e)
        {
            agregar = 3;
            tbNuevoCampo.Text = "";
            pNuevo.Visible = true;
            lblCarga.Text = "Ingrese la medida:";
            lblCarga.Visible = true;
            btnAceptar2.Visible = true;
            btnCancelar2.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LlenarEntidad();

            if (accion == 1)
            {
            nMat.CargarMaterial(mat);
            llenarDGV(nMat.ListarMaterial(activo));

                panelDatosPersonales.Visible = false;

            }
            else if (accion == 2)
            {
               // nMat.ModificarMaterial(mat.medida,mat.formato,mat.stock_general,mat.disponobilidad,codigo2,mat.detalle);
                llenarDGV(nMat.ListarMaterial(activo));

                panelDatosPersonales.Visible = false;
            }


            codigo2 = "";
        }

        private void LlenarEntidad()
        {
            mat.tipo = int.Parse(cbTipo.SelectedValue.ToString());
            mat.modelo = int.Parse(cbModelo.SelectedValue.ToString());
            mat.medida = int.Parse(cbMedida.SelectedValue.ToString());
            mat.numero = numero;
            mat.codigo = tbCodigo.Text;
            mat.formato = int.Parse(cbFormato.SelectedValue.ToString());
            mat.detalle = tbNombre.Text;
            if (tbStock.Text != "")
            {
            mat.stock_general =int.Parse( tbStock.Text);

            }
            if (tbDisp.Text != "")
            {
            mat.disponobilidad = int.Parse(tbDisp.Text);

            }
            // pasar imagen
            MemoryStream MS = new System.IO.MemoryStream();
            
            pbQR.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);

            mat.codigo_qr = MS;
            
            limpiar();
           

        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbDisp.Text = "";
            tbStock.Text = "";
            tbNombre.Text = "";
            cbMedida.DataSource = null;
            cbModelo.DataSource = null;
            cbModelo.Enabled = false;
            cbMedida.Enabled = false;
            cbFormato.DataSource = null;

        }

        private void pb_Click(object sender, EventArgs e)
        {
            if (cbFormato.DroppedDown == false)
            {
                cbFormato.DroppedDown = true;
            }
            else
            {
                cbFormato.DroppedDown = false;
            }
        }

        private void pbFormato_Click(object sender, EventArgs e)
        {
            agregar = 4;
            tbNuevoCampo.Text = "";
            pNuevo.Visible = true;
            lblCarga.Text = "Ingrese formato";
            lblCarga.Visible = true;
            btnAceptar2.Visible = true;
            btnCancelar2.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelDatosPersonales.Visible = false;

            codigo2 = "";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarDGV(nMat.ListarMaterialFiltro(tbBuscar.Text, activo));
            
           
              
          
                btnReactivar.Visible = false;
           

        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo2 = dgvEmp.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (activo == "no")
            {
                btnReactivar.Visible = true;
            }
            else
            {
                btnReactivar.Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codigo2 == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione material";
                mensaje.Show();
                return;
            }

            pMotivo.Visible = true;
            lblMotivo.Visible = true;
        }

        string motivo = "";
        private void cbMotivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            motivo = cbMotivo.SelectedItem.ToString();

            Eliminar eliminar = new Eliminar();



            if (eliminar.ShowDialog() == DialogResult.Yes)
            {
                nMat.BajaMaterial(codigo2,motivo);
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }
            else
            {
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }

            llenarDGV(nMat.ListarMaterial(activo));
            codigo2= "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(cbMotivo.DroppedDown == false)
            {
                cbMotivo.DroppedDown = true;
            }
            else
            {
                cbMotivo.DroppedDown = false;
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (codigo2 == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione material";
                mensaje.Show();
                return;
            }

            nMat.ReintegrarMaterial(codigo2);
            llenarDGV(nMat.ListarMaterial(activo));
            btnReactivar.Visible = false;
        }
    }
}
