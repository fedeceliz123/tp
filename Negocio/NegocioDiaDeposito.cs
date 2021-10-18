using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;

namespace Negocio
{
   public class NegocioDiaDeposito
    {
        Datos.Consulta_dia_deposito.ConsultaDiaDeposito dep = new Datos.Consulta_dia_deposito.ConsultaDiaDeposito();
        public DataTable listarDiaDep()
        {
            return dep.ListarDeposito();
        }

        public DataTable Dia(int id)
        {
            return dep.ListarDia(id);
        }
        public void EditarDia(int id, string fecha, string dni)
        {
            dep.EditarDia(id,fecha,dni);
        }

        public void EliminarDia(int id )
        {
            dep.EliminarDia(id);
        }
        public void CargarDia(string fecha, string dni)
        {
            dep.CargarDia(fecha,dni);
        }

    }
}
