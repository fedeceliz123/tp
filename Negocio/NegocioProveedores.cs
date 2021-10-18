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
   public class NegocioProveedores
    {
        Datos.ConsultasProveedores.ConsultaProveedores pro = new Datos.ConsultasProveedores.ConsultaProveedores();


        public DataTable CargarCombo()
        {
            return pro.Cargarcombo();
        }
        public DataTable ListarProv(string activo)
        {
            return pro.ListarProv(activo);
        }


        public DataTable llenarCamposPro(string dni)
        {
            return pro.LlenarComposPro(dni);
        }
        public DataTable dirPro(Proveedores prov)
        {
            return pro.dirPro(prov);
        }
        public DataTable telPro(Proveedores prov)
        {
            return pro.telPro(prov);
        }
        public DataTable mailPro(Proveedores prov)
        {
            return pro.mailPro(prov);
        }

        public void ModificarPro(Proveedores prov, Direcciones dir, Telefonos tel, Emails mail)
        {
            pro.ModificarPro(prov, dir, tel, mail);
        }
        public DataTable filtroPro(string activo, string dato)
        {
            return pro.FiltoPro(activo, dato);
        }

        public void CargarPro(Proveedores prov, Direcciones dir, Telefonos tel, Emails mail)
        {
            pro.CargarPro(prov, dir, tel, mail);
        }

        public void DarDeBajaPro(string dni, string motivo)
        {
            pro.DardeBajaPro(dni, motivo);
        }

        public void reactivarPro(string dni)
        {
            pro.ReintegrarPro(dni);
        }



    }
}
