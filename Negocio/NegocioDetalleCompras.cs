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
   public class NegocioDetalleCompras
    {
        Datos.ConsultaDetalleCompra.ConsultaDetalleCompra DC = new Datos.ConsultaDetalleCompra.ConsultaDetalleCompra();

        public void DisminuirCantTotal(int idcompra)
        {
            DC.disminuirCantidadTotal(idcompra);
        }
        public int UltimoID(int id)
        {
            return DC.idDetalle(id);
        }

        public void aumentoCantidad(int cantidad, string codigo)
        {
            DC.AmentarCantidad(cantidad,codigo);
        }

        public void aumentoTotal(int id, int idd)
        {
            DC.aumentarTotal(id,idd);
        }

        public void disminurTotal(int id,int idd)
        {
            DC.disminuirTotal(id,idd);
        }

        public void disminuirCantidad(int idd,int id)
        {
            DC.disminuirCantidad(idd,id);
        }

        public DataTable ListarDetalle2(int id)
        {
            return DC.ListarDetalle2(id);
        }
        public DataTable ListarDetalleCompra(int idCom)
        {
            return DC.ListarDetalleCompra(idCom);
        }

        public void BorrarTodoDetalle(int id)
        {
            DC.eliminarDetCompraTodo(id);
        }
        public DataTable ListarDetalle(int id)
        {
            return DC.ListarDetalle(id);
        }

        public void cargarDetalleCompra(detalle_compra dcom)
        {
            DC.cargarDetalleCompra(dcom);
        }

        public void editarDetalleCompra(detalle_compra dcom)
        {
            DC.editarDetalleCompra(dcom);
        }

        public void eliminarDetalleCompra(int id)
        {
            DC.eliminarDetalleCompra(id);
        }

    }
}
