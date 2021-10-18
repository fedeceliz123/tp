using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
  public  class Validaciones
    {


        public Boolean TextBoxNull(TextBox Text)
        {
            Boolean a;

            if (Text.Text == "")
            {
                a = true;
            }
            else
            {
                a = false;
            }

            return a;

        }

        public void SoloNumeros(KeyPressEventArgs pr)
        {
            if (char.IsDigit(pr.KeyChar))
            {
                pr.Handled = false;
            }
            else if (char.IsControl(pr.KeyChar))
            {
                pr.Handled = false;
            }
            else
            {
                pr.Handled = true;

                MensajeOk oMensaje = new MensajeOk();
                oMensaje.Show();
                oMensaje.lblMensaje.Text = "Solo ingresar numeros ";
            }

        }
    }
}
