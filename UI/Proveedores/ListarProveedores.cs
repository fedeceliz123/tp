﻿using System;
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

namespace UI.Proveedores
{
    public partial class ListarProveedores : Form
    {
        string dni = "";
        int acciones = 0;

        
        
        Entidades.Direcciones dir = new Direcciones();
        Entidades.Telefonos tel = new Telefonos();
        Entidades.Emails mail = new Emails();
        Entidades.Proveedores pro = new Entidades.Proveedores();
        Negocio.NegocioProveedores nPro = new NegocioProveedores();
      

        public ListarProveedores()
        {
            InitializeComponent();
        }

        private void panelDatosPersonales_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LlenarCampos()
        {


            pro.cuit = dni;

            foreach (DataRow obj in nPro.llenarCamposPro(dni).Rows)
            {
             
                DateTime fechaI;
               
                
               

                if (obj["fecha_de_ingreso"].ToString() != ""){

                fechaI = DateTime.Parse(obj["fecha_de_ingreso"].ToString());
                    tbFechai.Text = fechaI.ToString("dd/MM/yyyy");
                }
                

                tbDni.Text = obj["cuit"].ToString();
                tbNombre.Text = obj["razon_social"].ToString();
                tbApellido.Text = obj["nombre_fantasia"].ToString();
                tbSexo1.Text = obj["iva"].ToString();
                
                tbPuesto.Text = obj["rubro"].ToString();
                
                


            }

            foreach (DataRow obj in nPro.dirPro(pro).Rows)
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

            foreach (DataRow obj in nPro.telPro(pro).Rows)
            {
                tbCod.Text = obj["codigo_de_area"].ToString();
                tbTel.Text = obj["numero"].ToString();
            }
            foreach (DataRow obj in nPro.mailPro(pro).Rows)
            {
                tbMail.Text = obj["email"].ToString();
            }

          



        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (p1.Visible == true)
            {
                paso2.BackColor = Color.FromArgb(69, 172, 234);
                paso1.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
             

                p1.Visible = false;
                pDir.Visible = true;
                pTel.Visible = false;
               
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
               

                p1.Visible = false;
                pDir.Visible = false;
                pTel.Visible = true;
                
                btnAtras.Visible = true;
                btnSiguiente.Visible = false;
                btnAtras.Location = new System.Drawing.Point(585, 652);
                btnAceptar.Visible = true;
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
           
            tbPuesto.Text = "";
            tbFechai.Text = "";
           
            tbCod.Text = "";
            tbTel.Text = "";
            tbMail.Text = "";
           

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

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void inputHabilitados()
        {
            tbDni.Enabled = true;
            tbNombre.Enabled = true;
            tbApellido.Enabled = true;
            //tbSexo1.Enabled = true;
            tbSexo.Enabled = true;
            //tbFechaN.Enabled = true;
            tbPuesto.Enabled = true;
            //tbFechai.Enabled = true;
            
            
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

        

        }
        private void inputDesHabilitado()
        {
            tbDni.Enabled = false;
            tbNombre.Enabled = false;
            tbApellido.Enabled = false;
            tbSexo1.Enabled = false;
            tbSexo.Enabled = false;
            
            tbPuesto.Enabled = false;
            tbFechai.Enabled = false;
           
            
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

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelDatosPersonales.Visible = false;
            p1.Visible = true;
            pDir.Visible = false;
            pTel.Visible = false;
            
            paso1.BackColor = Color.FromArgb(69, 172, 234);
            paso2.BackColor = Color.FromArgb(3, 109, 193);
            paso3.BackColor = Color.FromArgb(3, 109, 193);

            dni = "";
            
        }

        private void paso1_Click(object sender, EventArgs e)
        {
            paso1.BackColor = Color.FromArgb(69, 172, 234);
            paso2.BackColor = Color.FromArgb(3, 109, 193);
            paso3.BackColor = Color.FromArgb(3, 109, 193);
           

            p1.Visible = true;
            pDir.Visible = false;
            pTel.Visible = false;
            
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
         

            p1.Visible = false;
            pDir.Visible = true;
            pTel.Visible = false;
           
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
            

            p1.Visible = false;
            pDir.Visible = false;
            pTel.Visible = true;
            
            btnAtras.Visible = true;
            btnSiguiente.Visible = false;
            btnAtras.Location = new System.Drawing.Point(585, 652);
            btnAceptar.Visible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (pDir.Visible == true)
            {
                paso1.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);
                

                p1.Visible = true;
                pDir.Visible = false;
                pTel.Visible = false;
                
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
                

                p1.Visible = false;
                pDir.Visible = true;
                pTel.Visible = false;
                
                btnAtras.Visible = true;

                btnSiguiente.Visible = true;
                btnAtras.Location = new System.Drawing.Point(470, 652);
                btnAceptar.Visible = false;
            }
        }
        string activo = "si";
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGrilla(nPro.filtroPro(activo, tbBuscar.Text));
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (acciones == 2)
            {
                cargarEntidades();
                if (validaciones.TextBoxNull(tbDni) == validaciones.TextBoxNull(tbNombre) == validaciones.TextBoxNull(tbApellido) == validaciones.TextBoxNull(tbPuesto) == false)
                {

                    nPro.ModificarPro(pro, dir, tel, mail);

                    panelDatosPersonales.Visible = false;
                    p1.Visible = true;
                    pDir.Visible = false;
                    pTel.Visible = false;

                    paso1.BackColor = Color.FromArgb(69, 172, 234);
                    paso2.BackColor = Color.FromArgb(3, 109, 193);
                    paso3.BackColor = Color.FromArgb(3, 109, 193);


                    cargarGrilla(nPro.ListarProv(activo));
                    acciones = 0;
                    dni = "";
                }
                else
                {
                    MensajeOk mensaje = new MensajeOk();
                    mensaje.lblMensaje.Text = "Complete los campos obligatorios";
                    mensaje.Show();
                }

              

            }
            else if (acciones == 1)
            {
                cargarEntidades();

                if (validaciones.TextBoxNull(tbDni) == validaciones.TextBoxNull(tbNombre)  == false)
                {
                    nPro.CargarPro(pro, dir, tel, mail);

                    panelDatosPersonales.Visible = false;
                    p1.Visible = true;
                    pDir.Visible = false;
                    pTel.Visible = false;

                    paso1.BackColor = Color.FromArgb(69, 172, 234);
                    paso2.BackColor = Color.FromArgb(3, 109, 193);
                    paso3.BackColor = Color.FromArgb(3, 109, 193);


                    cargarGrilla(nPro.ListarProv(activo));
                    acciones = 0;
                    dni = "";
                }
                else
                {
                    MensajeOk mensaje = new MensajeOk();
                    mensaje.lblMensaje.Text = "Complete los campos obligatorios";
                    mensaje.Show();
                }
               
            }
            else
            {
                panelDatosPersonales.Visible = false;
                p1.Visible = true;
                pDir.Visible = false;
                pTel.Visible = false;

                paso1.BackColor = Color.FromArgb(69, 172, 234);
                paso2.BackColor = Color.FromArgb(3, 109, 193);
                paso3.BackColor = Color.FromArgb(3, 109, 193);


                cargarGrilla(nPro.ListarProv(activo));
                dni = "";
            }
        }
        private void cargarEntidades()
        {
            pro.cuit = tbDni.Text;
            pro.razon_social = tbNombre.Text;
            pro.nombre_fantasia = tbApellido.Text;
            pro.iva = tbSexo1.Text;
            
            pro.rubro = tbPuesto.Text;
            pro.fecha_de_ingeso = tbFechai.Text;


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
            mail.id_persona = tbMail.Text;
            mail.email = tbMail.Text;


           


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

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

        private void btnDetalles_Click(object sender, EventArgs e)
        {
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            acciones = 1;
            inputHabilitados();

            panelDatosPersonales.Visible = true;
            btnAceptar.Visible = false;
            btnSiguiente.Visible = true;
            btnAtras.Visible = false;
            
            limpiar();
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

        private void tbSexo1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSexo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            tbSexo1.Text = tbSexo.SelectedItem.ToString();
        }

        private void fNac_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void fIng_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fecha = fIng.SelectionStart;
            tbFechai.Text = fecha.ToString("dd/MM/yyyy");
            fIng.Visible = false;
        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            cargarGrilla(nPro.ListarProv(activo));
        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dni = dgvEmp.Rows[e.RowIndex].Cells[0].Value.ToString();
                pro.cuit = dgvEmp.Rows[e.RowIndex].Cells[0].Value.ToString();
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
        string motivo = "";
        private void cbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            motivo = cbMotivo.SelectedItem.ToString();

            Eliminar eliminar = new Eliminar();



            if (eliminar.ShowDialog() == DialogResult.Yes)
            {
                nPro.DarDeBajaPro(dni, motivo);
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }
            else
            {
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }

            cargarGrilla(nPro.ListarProv(activo));
            dni = "";
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            nPro.reactivarPro(dni);
            cargarGrilla(nPro.ListarProv(activo));
            dni = "";
        }

        private void tbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSexo1.Text = tbSexo.SelectedItem.ToString();

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
    }
}
