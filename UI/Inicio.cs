using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

            DiasSemana();
           


        }

        private void DiasSemana()
        {
            mes.Text = (DateTime.Now.ToString("MMMM", new CultureInfo("es-ES"))).ToUpper();

            DateTime hoy = DateTime.Today;

            D1.Text = hoy.ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.ToString("dd");
            D2.Text = hoy.AddDays(1).ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.AddDays(1).ToString("dd");
            D3.Text = hoy.AddDays(2).ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.AddDays(2).ToString("dd");
            D4.Text = hoy.AddDays(3).ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.AddDays(3).ToString("dd");
            D5.Text = hoy.AddDays(4).ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.AddDays(4).ToString("dd");
            D6.Text = hoy.AddDays(5).ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.AddDays(5).ToString("dd");
            D7.Text = hoy.AddDays(6).ToString("dddd", new CultureInfo("es-ES")) + " " + hoy.AddDays(6).ToString("dd");

            DateTime[] semana = new DateTime[7];

            for (var i = 0; i < 7; i++)
            {
                semana[i] = hoy;
                hoy = hoy.AddDays(1);

            }
        }

       
    }
}
