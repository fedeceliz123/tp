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
     public class NegocioCompras
    {

        Datos.ConsultasCompras.ConsultasCompras com = new Datos.ConsultasCompras.ConsultasCompras();

        public int Total(int id)
        {
            return com.Total(id);
        }


        public int UltimoID()
        {
            return com.UltimoID();
        }

        public DataTable ListarCompra()
        {
            return com.ListarCompra();
        }

        public void CargarCompra(compras comp)
        {
            com.cargarCompra(comp);
        }

        public void editarCompra(compras comp)
        {
            com.editarCompra(comp);
        }

        public void eliminarCarga(int id)
        {
            com.eliminarCompra(id);
        }

        public DataTable ListarCompraId(int id)
        {
            return com.ListarCompraId(id);
        }

    }
}
