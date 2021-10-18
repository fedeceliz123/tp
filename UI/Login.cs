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
using Entidades;
using Negocio;

namespace UI
{
    public partial class Login : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void pbpass_Click(object sender, EventArgs e)
        {
            if (tbClave.PasswordChar == true)
            {
                tbClave.PasswordChar = false;
            }
            else
            {
                tbClave.PasswordChar = true;
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void pbLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        Entidades.Login login = new Entidades.Login();
        Negocio.NegocioLogin Nlogin = new NegocioLogin();
        private void btnIngresat_Click(object sender, EventArgs e)
        {
            login.nombre_usuario = tbUsuario.Texts;
            login.contraseña = tbClave.Texts;

            if (Nlogin.ingresar(login) != 0)
            {
                  Carga Carga = new Carga();

                Carga.Show();

                Menu menu = new Menu();

                string dni = Nlogin.dni(login);
               


                menu.lblNombre.Text = Nlogin.nombres(login);
                menu.mest = Nlogin.imagen(dni);
                menu.Show();

                tbClave.Texts = "";
                tbUsuario.Texts = "";

                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "El Usuario o Contraseña no son correctas";
                mjs.Show();
                tbUsuario.Texts = "";
                tbClave.Texts = "";
            }
        }
    }
}
