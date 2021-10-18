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
  public  class NegocioMaterialReparar
    {
        Datos.Consultas_Material_Reparar.ConsultasMaterialReparar MR = new Datos.Consultas_Material_Reparar.ConsultasMaterialReparar();
        public DataTable ListarReparacion(string Finalizado, string dato)
        {
            return MR.ListarReparaciones(Finalizado, dato);

        }

        public void CargarReparacion(string cod,int cant, string detalle, string fecha)
        {
            MR.CargarReparacion(cod,cant,detalle,fecha);
        }

        public DataTable LlenarCampos(int id)
        {
            return MR.LlenarCampos(id);
        }

        public void EliminarReparacion(int id)
        {
            MR.EliminarReparacion(id);
        }

        public void EditarReparacion(int id, int cantidad, string motivo, string fechai, string detalles)
        {
            MR.EditarReparacion(id,cantidad,motivo,fechai,detalles);
        }
        public void EditarSalida(string fecha,int id)
        {
            MR.EditarReparacionSalida(fecha,id);
        }

        public void actualizarDisp(int cantidad, string codigo)
        {
            MR.actualizarDisp(cantidad,codigo);
        }
    }
}
