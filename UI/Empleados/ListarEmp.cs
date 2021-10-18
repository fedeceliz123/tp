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
using System.IO;

namespace UI.Empleados
{
    public partial class ListarEmp : Form
    {
        public ListarEmp()
        {
            InitializeComponent();
        }

        Negocio.NegocioEmpleados nEmp = new NegocioEmpleados();
        Entidades.Empleados emp = new Entidades.Empleados();
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Entidades.Login login = new Entidades.Login();

        private void ListarEmp_Load(object sender, EventArgs e)
        {
            cargarGrilla(nEmp.ListarEmp(activo));

            cargarComboPermisos();

         
            cbMotivo.Items.Add("Renuncia");
            cbMotivo.Items.Add("Despido sin causa");
            cbMotivo.Items.Add("Despido con cuasa");

          

        }




        private void cargarGrilla(DataTable tabla)
        {

            dgvEmp.DataSource = null;
            dgvEmp.DataSource = tabla;
            dgvEmp.Columns[0].Width = 200;
            dgvEmp.Columns[1].Width = 200;
            dgvEmp.Columns[2].Width = 200;
            dgvEmp.Columns[3].Width = 200;

        }


        string dni = "";
        int acciones = 0;
        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dni = dgvEmp.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (chbInactivos.Checked == true)
                {
                    btnReactivar.Visible = true;
                }
                else
                {
                    btnReactivar.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void limpiar()
        {
            tbPais.Text = "";
            tbProvincia.Text = "";
            tbLocalidad.Text = "";
            tbCP.Text = "";
            tbBarrio.Text = "";
            tbCalle.Text = "";
            tbN.Text = "";
            tbPiso.Text = "";
            tbDpto.Text = "";
            tbMzana.Text = "";
            tbLote.Text = "";
            tbDni.Text = "";
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbSexo1.Text = "";
            tbFechaN.Text = "";
            tbPuesto.Text = "";
            tbFechai.Text = "";
            tbPreDep.Text = "";
            tbPreEve.Text = "";
            tbCod.Text = "";
            tbTel.Text = "";
            tbMail.Text = "";
            tbUseruario.Text = "";
            tbClave.Text = "";

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            pbUser.Enabled = true;
            pbUser.Image = UI.Properties.Resources.usuario;
            acciones = 1;
            inputHabilitados();
            btnReactivar.Visible = false;

            panelDatosPersonales.Visible = true;
            btnAceptar.Visible = false;
            btnSiguiente.Visible = true;
            btnAtras.Visible = false;
            limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            pbUser.Enabled = true;
            btnReactivar.Visible = false;
            acciones = 2;
            if (dni == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione un empleado";
                mensaje.Show();
                return;
            }
            LlenarCampos();
            inputHabilitados();

            panelDatosPersonales.Visible = true;


            btnAceptar.Visible = false;
            btnSiguiente.Visible = true;
            btnAtras.Visible = false;
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            pbUser.Enabled = false;
            btnReactivar.Visible = false;
            acciones = 3;
            if (dni == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione un empleado";
                mensaje.Show();
                return;
            }
            LlenarCampos();
            inputDesHabilitado();


            panelDatosPersonales.Visible = true;
            btnAceptar.Visible = false;
            btnSiguiente.Visible = true;
            btnAtras.Visible = false;

        }

        public string motivo = "";

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dni == "")
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione un empleado";
                mensaje.Show();
                return;
            }

            pMotivo.Visible = true;
            lblMotivo.Visible = true;
           

        }

        
       

        private void LlenarCampos()
        {

            MemoryStream ms = new MemoryStream();
            emp.dni = dni;

            foreach (DataRow obj in nEmp.empleados(emp, activo).Rows)
            {

                DateTime fechaN = DateTime.Parse(obj["fecha_de_nacimiento"].ToString());
                DateTime fechaI = DateTime.Parse(obj["fecha_de_ingreso"].ToString());

                tbDni.Text = obj["dni"].ToString();
                tbNombre.Text = obj["nombre"].ToString();
                tbApellido.Text = obj["apellido"].ToString();
                tbSexo1.Text = obj["sexo"].ToString();
                tbFechaN.Text = fechaN.ToString("dd/MM/yyyy");
                tbPuesto.Text = obj["puesto"].ToString();
                tbFechai.Text = fechaI.ToString("dd/MM/yyyy");
                tbPreDep.Text = obj["valor_dia_deposito"].ToString();
                tbPreEve.Text = obj["valor_dia_evento"].ToString();

              


            }

            if (nEmp.ImagenPerfil(dni) != null)
            {
                Bitmap bm =new Bitmap( nEmp.ImagenPerfil(dni));
                pbUser.Image = bm;
            }
            else
            {
                pbUser.Image = UI.Properties.Resources.usuario;
            }

            foreach (DataRow obj in nEmp.direccionE(emp).Rows)
            {
                tbPais.Text = obj["pais"].ToString();
                tbProvincia.Text = obj["provincia"].ToString();
                tbLocalidad.Text = obj["localidad"].ToString();
                tbCP.Text = obj["cp"].ToString();
                tbBarrio.Text = obj["barrio"].ToString();
                tbCalle.Text = obj["calle"].ToString();
                tbN.Text = obj["numero"].ToString();
                tbPiso.Text = obj["piso"].ToString();
                tbDpto.Text = obj["dpto"].ToString();
                tbMzana.Text = obj["mzna"].ToString();
                tbLote.Text = obj["lote"].ToString();

            }

            foreach (DataRow obj in nEmp.telefonoE(emp).Rows)
            {
                tbCod.Text = obj["codigo_de_area"].ToString();
                tbTel.Text = obj["numero"].ToString();
            }
            foreach (DataRow obj in nEmp.mailE(emp).Rows)
            {
                tbMail.Text = obj["email"].ToString();
            }

            foreach (DataRow obj in nEmp.UserEmp(emp).Rows)
            {
                tbUseruario.Text = obj["nombre_usuario"].ToString();
                tbClave.Text = obj["contraseña"].ToString();
                tbPermisos.Text = obj["permiso"].ToString();
                if (obj["activo"].ToString() == "si")
                {
                    chbUser.Checked = false;
                }
                else if (obj["activo"].ToString() == "no")
                {
                    chbUser.Checked = true;

                }
            }



        }


        private void inputHabilitados()
        {
            tbDni.Enabled = true;
            tbNombre.Enabled = true;
            tbApellido.Enabled = true;
            tbSexo1.Enabled = false;
            tbSexo.Enabled = true;
            tbFechaN.Enabled = false;
            tbPuesto.Enabled = true;
            tbFechai.Enabled = false;
            tbPreDep.Enabled = true;
            tbPreEve.Enabled = true;
            pbAbrirCal.Enabled = true;
            pbCal2.Enabled = true;

            tbPais.Enabled = true;
            tbProvincia.Enabled = true;
            tbLocalidad.Enabled = true;
            tbCP.Enabled = true;
            tbBarrio.Enabled = true;
            tbCalle.Enabled = true;
            tbN.Enabled = true;
            tbPiso.Enabled = true;
            tbDpto.Enabled = true;
            tbMzana.Enabled = true;
            tbLote.Enabled = true;

            tbCod.Enabled = true;
            tbTel.Enabled = true;

            tbMail.Enabled = true;

            tbUseruario.Enabled = true;
            tbClave.Enabled = true;
            tbPermisos.Enabled = false;


        }

        private void inputDesHabilitado()
        {
            tbDni.Enabled = false;
            tbNombre.Enabled = false;
            tbApellido.Enabled = false;
            tbSexo1.Enabled = false;
            tbSexo.Enabled = false;
            tbFechaN.Enabled = false;
            tbPuesto.Enabled = false;
            tbFechai.Enabled = false;
            tbPreDep.Enabled = false;
            tbPreEve.Enabled = false;
            pbAbrirCal.Enabled = false;
            pbCal2.Enabled = false;

            tbPais.Enabled = false;
            tbProvincia.Enabled = false;
            tbLocalidad.Enabled = false;
            tbCP.Enabled = false;
            tbBarrio.Enabled = false;
            tbCalle.Enabled = false;
            tbN.Enabled = false;
            tbPiso.Enabled = false;
            tbDpto.Enabled = false;
            tbMzana.Enabled = false;
            tbLote.Enabled = false;

            tbCod.Enabled = false;
            tbTel.Enabled = false;

            tbMail.Enabled = false;

            tbUseruario.Enabled = false;
            tbClave.Enabled = false;
            tbPermisos.Enabled = false;
            cbPermiso.Enabled = false;
        }

        private void tbSexo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            tbSexo1.Text = tbSexo.SelectedItem.ToString();
        }

        private void pbAbrirCal_Click(object sender, EventArgs e)
        {
            if (fNac.Visible == false)
            {
                fNac.Visible = true;
            }
            else
            {
                fNac.Visible = false;
            }
        }

        private void pbCal2_Click(object sender, EventArgs e)
        {
            if (fIng.Visible == false)
            {
                fIng.Visible = true;
            }
            else
            {
                fIng.Visible = false;
            }
        }

        private void fNac_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void fIng_DateChanged(object sender, DateRangeEventArgs e)
        {
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelDatosPersonales.Visible = false;
            p1.Visible = true;
            pDir.Visible = false;
            pTel.Visible = false;
            pUser.Visible = false;
            paso1.BackColor = Color.FromArgb(69, 172, 234);
            paso2.BackColor = Color.FromArgb(3, 109, 193);
            paso3.BackColor = Color.FromArgb(3, 109, 193);
            paso4.BackColor = Color.FromArgb(3, 109, 193);

            dni = "";


        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (p1.Visible == true)
            {
                paso2.BackColor = Color.FromArgb(69, 172, 234);
                paso1.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
                paso4.BackColor = Color.FromArgb(3, 109, 193);

                p1.Visible = false;
                pDir.Visible = true;
                pTel.Visible = false;
                pUser.Visible = false;
                btnAtras.Visible = true;
                btnSiguiente.Visible = true;
                btnAtras.Location = new System.Drawing.Point(470, 652);
                btnAceptar.Visible = false;
            }
            else if (pDir.Visible == true)
            {
                paso3.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso1.BackColor = Color.FromArgb(3, 109, 193);
                paso4.BackColor = Color.FromArgb(3, 109, 193);

                p1.Visible = false;
                pDir.Visible = false;
                pTel.Visible = true;
                pUser.Visible = false;
                btnAtras.Visible = true;
                btnSiguiente.Visible = true;
                btnAtras.Location = new System.Drawing.Point(470, 652);
                btnAceptar.Visible = false;
            }
            else if (pTel.Visible == true)
            {
                paso4.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
                paso1.BackColor = Color.FromArgb(3, 109, 193);
                p1.Visible = false;
                pDir.Visible = false;
                pTel.Visible = false;
                pUser.Visible = true;
                btnAtras.Visible = true;
                btnSiguiente.Visible = false;
                btnAtras.Location = new System.Drawing.Point(585, 652);
                btnAceptar.Visible = true;
            }
        }

        private void paso1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paso1_Click(object sender, EventArgs e)
        {
            paso1.BackColor = Color.FromArgb(69, 172, 234);
            paso2.BackColor = Color.FromArgb(3, 109, 193);
            paso3.BackColor = Color.FromArgb(3, 109, 193);
            paso4.BackColor = Color.FromArgb(3, 109, 193);

            p1.Visible = true;
            pDir.Visible = false;
            pTel.Visible = false;
            pUser.Visible = false;
            btnAtras.Visible = false;
            btnSiguiente.Visible = true;
            btnAtras.Location = new System.Drawing.Point(470, 652);
            btnAceptar.Visible = false;
        }

        private void paso2_Click(object sender, EventArgs e)
        {
            paso2.BackColor = Color.FromArgb(69, 172, 234);
            paso1.BackColor = Color.FromArgb(3, 109, 193);
            paso3.BackColor = Color.FromArgb(3, 109, 193);
            paso4.BackColor = Color.FromArgb(3, 109, 193);

            p1.Visible = false;
            pDir.Visible = true;
            pTel.Visible = false;
            pUser.Visible = false;
            btnAtras.Visible = true;

            btnSiguiente.Visible = true;
            btnAtras.Location = new System.Drawing.Point(470, 652);
            btnAceptar.Visible = false;


        }

        private void paso3_Click(object sender, EventArgs e)
        {
            paso3.BackColor = Color.FromArgb(69, 172, 234);
            paso2.BackColor = Color.FromArgb(3, 109, 193);
            paso1.BackColor = Color.FromArgb(3, 109, 193);
            paso4.BackColor = Color.FromArgb(3, 109, 193);

            p1.Visible = false;
            pDir.Visible = false;
            pTel.Visible = true;
            pUser.Visible = false;
            btnAtras.Visible = true;
            btnSiguiente.Visible = true;
            btnAtras.Location = new System.Drawing.Point(470, 652);
            btnAceptar.Visible = false;

        }

        private void paso4_Click(object sender, EventArgs e)
        {
            paso4.BackColor = Color.FromArgb(69, 172, 234);
            paso2.BackColor = Color.FromArgb(3, 109, 193);
            paso3.BackColor = Color.FromArgb(3, 109, 193);
            paso1.BackColor = Color.FromArgb(3, 109, 193);
            p1.Visible = false;
            pDir.Visible = false;
            pTel.Visible = false;
            pUser.Visible = true;
            btnAtras.Visible = true;
            btnAtras.Visible = true;
            btnSiguiente.Visible = false;
            btnAtras.Location = new System.Drawing.Point(585, 652);
            btnAceptar.Visible = true;


        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (tbClave.UseSystemPasswordChar == true)
            {
                tbClave.UseSystemPasswordChar = false;
            }
            else
            {
                tbClave.UseSystemPasswordChar = true;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (pUser.Visible == true)
            {
                paso3.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso1.BackColor = Color.FromArgb(3, 109, 193);
                paso4.BackColor = Color.FromArgb(3, 109, 193);

                p1.Visible = false;
                pDir.Visible = false;
                pTel.Visible = true;
                pUser.Visible = false;
                btnAtras.Visible = true;
                btnSiguiente.Visible = true;
                btnAtras.Location = new System.Drawing.Point(470, 652);
                btnAceptar.Visible = false;

            }
            else if (pDir.Visible == true)
            {
                paso1.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
                paso4.BackColor = Color.FromArgb(3, 109, 193);

                p1.Visible = true;
                pDir.Visible = false;
                pTel.Visible = false;
                pUser.Visible = false;
                btnAtras.Visible = false;
                btnSiguiente.Visible = true;
                btnAtras.Location = new System.Drawing.Point(470, 652);
                btnAceptar.Visible = false;
            }
            else if (pTel.Visible == true)
            {
                paso2.BackColor = Color.FromArgb(69, 172, 234);
                paso1.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
                paso4.BackColor = Color.FromArgb(3, 109, 193);

                p1.Visible = false;
                pDir.Visible = true;
                pTel.Visible = false;
                pUser.Visible = false;
                btnAtras.Visible = true;

                btnSiguiente.Visible = true;
                btnAtras.Location = new System.Drawing.Point(470, 652);
                btnAceptar.Visible = false;
            }
        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscarimagen = new OpenFileDialog();
            //buscarimagen.Filter = "Archivos de imagen|*.png";

            buscarimagen.InitialDirectory = "C:\\";

            if (buscarimagen.ShowDialog() == DialogResult.OK)
            {

                pbUser.ImageLocation = buscarimagen.FileName;
                pbUser.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            cargarGrilla(nEmp.FitroEmp(activo,tbBuscar.Text));
            btnReactivar.Visible = false;
            if (activo == "no")
            {
                btnEliminar.Visible = false;
            }
            else
            {
                btnEliminar.Visible = true;
            }

        }
        string activo="si";
        private void chbInactivos_CheckedChanged(object sender, EventArgs e)
        {

            if (chbInactivos.Checked == true)
            {
                activo = "no";
            }
            else if (chbInactivos.Checked == false)
            {
                activo = "si";
            }
        }

        private void chbInactivos_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (acciones == 2)
            {
                cargarEntidades();
                //if(validaciones.TextBoxNull(tbDni)==validaciones.TextBoxNull(tbNombre)==validaciones.TextBoxNull(tbApellido)==validaciones.TextBoxNull(tbPuesto)==false)
                //{



                nEmp.ModificarEmp(emp, dir, tel, mail, login);

                

                panelDatosPersonales.Visible = false;
                p1.Visible = true;
                pDir.Visible = false;
                pTel.Visible = false;
                pUser.Visible = false;
                paso1.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
                paso4.BackColor = Color.FromArgb(3, 109, 193);

                    cargarGrilla(nEmp.ListarEmp(activo));
                    dni = "";
                //}
                //else
                //{
                //    MensajeOk mensaje = new MensajeOk();
                //    mensaje.lblMensaje.Text = "Complete los campos obligatorios";
                //    mensaje.Show();
                //}

            }
            else if (acciones==1)
            {
                cargarEntidades();
                //if (validaciones.TextBoxNull(tbDni) == validaciones.TextBoxNull(tbNombre) == validaciones.TextBoxNull(tbApellido) == validaciones.TextBoxNull(tbPuesto) == false)
                //{
                    //nEmp.ModificarEmp(emp, dir, tel, mail, login);


                    nEmp.cargarEmpleado(emp, dir, tel, mail, login);

                    panelDatosPersonales.Visible = false;
                    p1.Visible = true;
                    pDir.Visible = false;
                    pTel.Visible = false;
                    pUser.Visible = false;
                    paso1.BackColor = Color.FromArgb(69, 172, 234);
                    paso2.BackColor = Color.FromArgb(3, 109, 193);
                    paso3.BackColor = Color.FromArgb(3, 109, 193);
                    paso4.BackColor = Color.FromArgb(3, 109, 193);

                    cargarGrilla(nEmp.ListarEmp(activo));
                    dni = "";
                //}
                //else
                //{
                //    MensajeOk mensaje = new MensajeOk();
                //    mensaje.lblMensaje.Text = "Complete los campos obligatorios *";
                //    mensaje.Show();
                //}

            }
           
        }


        string userAc = "si";


       
   
        private void cargarEntidades()
        {
            emp.dni = tbDni.Text;
            emp.nombre = tbNombre.Text;
            emp.apellido = tbApellido.Text;
            emp.sexo = tbSexo1.Text;
            emp.fecha_nacimiento = tbFechaN.Text;
            emp.puesto =  tbPuesto.Text;
            emp.fecha_ingreso = tbFechai.Text;
            emp.valor_dia_deposito = decimal.Parse(tbPreDep.Text);
            emp.valor_dia_evento = decimal.Parse(tbPreEve.Text);

            MemoryStream ms = new MemoryStream();
            pbUser.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            emp.imagen = ms;

            // dir 

            dir.id_persona = tbDni.Text;
            dir.pais = tbPais.Text;
            dir.provincia = tbProvincia.Text;
            dir.localidad = tbLocalidad.Text;
            dir.cp = tbCP.Text;
            dir.barrio = tbBarrio.Text;
            dir.calle = tbCalle.Text;
            dir.numero = tbN.Text;
            dir.piso = tbPiso.Text;
            dir.dpto = tbDpto.Text;
            dir.mzna = tbMzana.Text;
            dir.lote = tbLote.Text;

            // tel
            tel.id_persona = tbDni.Text;
            tel.codigo_de_area = tbCod.Text;
            tel.numero = tbTel.Text;

            //mail
            mail.id_persona = tbDni.Text;
            mail.email = tbMail.Text;


            // login
            login.dni = tbDni.Text;
            login.contraseña = tbClave.Text;
            login.nombre_usuario = tbUseruario.Text;
            login.email = tbMail.Text;
            login.permiso = int.Parse(tbPermisos.Text);
            login.activo = userAc;


        }

        private void cargarComboPermisos()
        {
            cbPermiso.DataSource = nEmp.listarPermisos();
            cbPermiso.DisplayMember = "permiso";
            cbPermiso.ValueMember = "id";
        }

        private void cbPermiso_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            tbPermisos.Text = (int.Parse(cbPermiso.SelectedIndex.ToString())+1).ToString(); ;
        }

        private void chbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chbUser.Checked == true)
            {
                userAc = "no";
            }
            else if (chbUser.Checked==false)
            {
                userAc = "si";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (fNac.Visible == false)
            {
                fNac.Visible = true;
            }
            else
            {
                fNac.Visible = false;
            }
        }

        private void fNac_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fecha = fNac.SelectionStart;

            tbFechaN.Text = fecha.ToString("dd/MM/yyyy");
            fNac.Visible = false;
        }

        private void fIng_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fecha = fIng.SelectionStart;
            tbFechai.Text = fecha.ToString("dd/MM/yyyy");
            fIng.Visible = false;
        }

        private void cbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void panelLista_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (cbMotivo.DroppedDown == false)
            {
                cbMotivo.DroppedDown = true;
            }
            else
            {
                cbMotivo.DroppedDown = false;
            }
        }

        private void cbMotivo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            motivo = cbMotivo.SelectedItem.ToString();

            Eliminar eliminar = new Eliminar();



            if (eliminar.ShowDialog() == DialogResult.Yes)
            {
                nEmp.DarDeBajaEmp(dni, motivo);
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }
            else
            {
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }

            cargarGrilla(nEmp.ListarEmp(activo));
            dni = "";
        }

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            nEmp.ReintrearEmp(dni);
            cargarGrilla(nEmp.ListarEmp(activo));
            dni = "";
        }

        Validaciones validaciones = new Validaciones();
        private void tbCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbN_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbPreDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void tbPreEve_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNumeros(e);
        }

        private void pbX_Click(object sender, EventArgs e)
        {
            pbX.Visible = false;
            this.Close();

        }
    }
}
