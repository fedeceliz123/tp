using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
   public class NegocioSalidaEmpleado
    {
        Datos.Consulta_Salida_Empleado.SalidaEmpleado salEmp = new Datos.Consulta_Salida_Empleado.SalidaEmpleado();
        public DataTable ListaSalidaEmp(int id)
        {
            return salEmp.ListarSalidaEmpleado(id);
        }

        public void CargarSalidaEmpl(int evento,string emp)
        {
            salEmp.CargarSalida(evento, emp);
        }
        public void eliminarSalida(int id)
        {
            salEmp.eliminarSalida(id);
        }

    }
}
