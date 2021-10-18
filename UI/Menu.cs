using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace UI
{
    public partial class Menu : Form
    {
        public MemoryStream mest;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);
        public Menu()
        {
            InitializeComponent();
        }

        private void panelBarrasub_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox2.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox2.Visible = true;
            pictureBox4.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private void Menu_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(mest);

            imagenUsuario.Image = bm;

            AbrirFormhijo(new Inicio());
        }

        private void AbrirFormhijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;

            fh.Show();

        }

        private void CerrarSub()
        {
            panelSubCom.Visible = false;
            panelSubEstadis.Visible = false;
            panelSubEventos.Visible = false;
            panelSubPersonal.Visible = false;
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (panelSubCom.Visible == false)
            {

            CerrarSub();
            panelSubCom.Visible = true;
            }
            else
            {
                panelSubCom.Visible = false;
            }
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            if (panelSubEventos.Visible == false)
            {

                CerrarSub();
                panelSubEventos.Visible = true;
            }
            else
            {
                panelSubEventos.Visible = false;
            }
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            if (panelSubPersonal.Visible == false)
            {
                
                CerrarSub();
                panelSubPersonal.Visible = true;
            }
            else
            {
                panelSubPersonal.Visible = false;
            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            if (panelSubEstadis.Visible == false)
            {

                CerrarSub();
                panelSubEstadis.Visible = true;
            }
            else
            {
                panelSubEstadis.Visible = false;
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Proveedores.ListarProveedores());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Clientes.ListarClientes());
        }

        private void btnCarPersonal_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Empleados.ListarEmp());
        }

        private void btnCarEvento_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Eventos.ListarEventos());
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new MaterialEvento.MaterialEvento());
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Material.ListarMaterial());
        }
    }
}