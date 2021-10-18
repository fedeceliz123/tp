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


namespace UI.Eventos
{
    public partial class ListarEventos : Form
    {
        public ListarEventos()
        {
            InitializeComponent();
        }

        Negocio.NegocioEventos nEven = new NegocioEventos();
        Entidades.Eventos eve = new Entidades.Eventos();

        int accion = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dtpFechaI.Focus();
            SendKeys.Send("{F4}");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            accion = 1;
            HabilitarCampo();
            panelDatosPersonales.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            dtpFechaF.Focus();
            SendKeys.Send("{F4}");
        }


        private void llenarEmp()
        {
            cbEncargado.DataSource = null;
            cbEncargado.DataSource = nEven.CargarEmpleados();
            cbEncargado.ValueMember = "dni";
            cbEncargado.DisplayMember = "empleado";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cbEncargado.DroppedDown == false)
            {
                cbEncargado.DroppedDown = true;
            }
            else
            {
                cbEncargado.DroppedDown = false;
            }

            llenarEmp();

        }

        private void llenarCli()
        {
            cbCliente.DataSource = null;
            cbCliente.DataSource = nEven.CargarClientes();
            cbCliente.ValueMember = "dni";
            cbCliente.DisplayMember = "cliente";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (cbCliente.DroppedDown == false)
            {
                cbCliente.DroppedDown = true;
            }
            else
            {
                cbCliente.DroppedDown = false;
            }

            llenarCli();
            
        }

        private void pbModelo_Click(object sender, EventArgs e)
        {
            Empleados.ListarEmp Emp = new Empleados.ListarEmp();

            Emp.pbX.Visible = true;

            Emp.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Clientes.ListarClientes Cli = new Clientes.ListarClientes();
            Cli.pbX.Visible = true;
            Cli.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {

            accion = 2;

            HabilitarCampo();
            panelDatosPersonales.Visible = true;
            llenarCli();
            llenarEmp();
            llenarcampos();
            }
            else
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione un evento";
                mensaje.Show();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                CargarEntidad();
                nEven.CargarEvento(eve);
                accion = 0;
                limpiar();
                id = 0;
                panelDatosPersonales.Visible = false;
            }
            else if (accion == 2)
            {
                CargarEntidad();
                nEven.modificarEvento(eve);
                accion = 0;
                limpiar();
                id = 0;
                panelDatosPersonales.Visible = false;

            }
            else
            {
                accion = 0;
                limpiar();
                id = 0;
                panelDatosPersonales.Visible = false;
            }

            tbBuscar.Clear();

                CargarGrilla(nEven.ListarEventos(activo,tbBuscar.Text));
        }

        string activo = "si";
        private void CargarEntidad()
        {
            eve.id = id;
            eve.lugar = tbLugar.Text;
            eve.hora_inicio = tbHora.Text;
            eve.total = int.Parse(tbTotal.Text);
            eve.detalle = tbDetalle.Text;
            eve.encargado = cbEncargado.SelectedValue.ToString();
            eve.id_cliente = cbCliente.SelectedValue.ToString();
            eve.fecha_inicio = dtpFechaI.Value.ToString();
            eve.fecha_fin = dtpFechaF.Value.ToString();

        }

        private void CargarGrilla(DataTable dt)
        {
            dgvEmp.DataSource = null;
            dgvEmp.DataSource = dt;
            dgvEmp.Columns[0].Visible = false;
            dgvEmp.Columns[1].Width = 250;
            dgvEmp.Columns[2].Width = 150;
            dgvEmp.Columns[3].Width = 150;
            dgvEmp.Columns[4].Width = 250;


        }

        private void ListarEventos_Load(object sender, EventArgs e)
        {
            CargarGrilla(nEven.ListarEventos(activo,tbBuscar.Text));
        }

        private void HabilitarCampo()
        {
            tbLugar.Enabled = true;
            tbHora.Enabled = true;
            tbTotal.Enabled = true;
            tbDetalle.Enabled = true;
            cbEncargado.Enabled = true;
            cbCliente.Enabled = true;
            dtpFechaF.Enabled = true;
            dtpFechaI.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox5.Enabled = true;
            pbCli.Enabled = true;
            pbEnc.Enabled = true;
        }
        private void DeshabilitarCampo()
        {
            tbLugar.Enabled = false;
            tbHora.Enabled = false;
            tbTotal.Enabled = false;
            tbDetalle.Enabled = false;
            cbEncargado.Enabled = false;
            cbCliente.Enabled = false;
            dtpFechaF.Enabled = false;
            dtpFechaI.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox5.Enabled = false;
            pbCli.Enabled = false;
            pbEnc.Enabled = false;
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {

            accion = 0;
            DeshabilitarCampo();
            panelDatosPersonales.Visible = true;
              

               
                llenarCli();
                llenarEmp();
                llenarcampos();
            }
            else
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione un evento";
                mensaje.Show();
            }

        }
        int id;
        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvEmp.Rows[e.RowIndex].Cells[0].Value.ToString());
            DateTime fecha = DateTime.Parse(dgvEmp.Rows[e.RowIndex].Cells[2].Value.ToString());

            if (activo == "no" && fecha> DateTime.Now)
            {
                btnReactivar.Visible = true;
            }
            else
            {
                btnReactivar.Visible = false;
            }
        }

        private void llenarcampos()
        {
            
            foreach(DataRow obj in nEven.LlenarCampos(id).Rows)
            {
                cbCliente.SelectedValue = obj["id_cliente"].ToString();
                dtpFechaI.Value = DateTime.Parse(obj["fecha_inicio"].ToString());
                tbHora.Text = obj["hora_inicio"].ToString();
                tbLugar.Text = obj["lugar"].ToString();
                cbEncargado.SelectedValue = obj["encargado"].ToString();
                tbTotal.Text = obj["total"].ToString();
                tbDetalle.Text = obj["detalle"].ToString();

            }



        }

        private void limpiar()
        {
            cbCliente.DataSource = null;
            dtpFechaI.Value = DateTime.Now;
            tbHora.Text = "";
            tbLugar.Text = "";
            cbEncargado.DataSource = null;
            tbTotal.Text = "";
            tbDetalle.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = 0;
            id = 0;
            limpiar();
            panelDatosPersonales.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (id == 0)
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione evento";
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
                nEven.BajaEvento(id, motivo);
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }
            else
            {
                lblMotivo.Visible = false;
                pMotivo.Visible = false;
            }
            tbBuscar.Text = "";
            CargarGrilla(nEven.ListarEventos(activo,tbBuscar.Text));
            id = 0;

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
            if (activo == "si")
            {
                CargarGrilla(nEven.ListarEventos(activo,tbBuscar.Text));
            }
            else
            {
                CargarGrilla(nEven.ListarInactivos(activo,tbBuscar.Text));
            }



            btnReactivar.Visible = false;

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

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = "Seleccione evento";
                mensaje.Show();
                return;
            }

            nEven.Reintegrar(id);

            CargarGrilla(nEven.ListarInactivos(activo, tbBuscar.Text));
        }
    }
}
