using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Datos;

namespace Negocio
{
    


    public class NegocioEventos
    {
        Eventos even = new Eventos();
        Datos.ConsultaEventos.ConsultasEventos cEven = new Datos.ConsultaEventos.ConsultasEventos();

        public void CargarEvento(Eventos even)
        {
            cEven.CargarEvento(even);
        }
        public DataTable ListarEventos(string activo,string dato,string date)
        {
            return cEven.ListarEventos(activo,dato,date);
        }

        public DataTable CargarClientes()
        {
            return cEven.CargarClientes();
        }
        public DataTable CargarEmpleados()
        {
            return cEven.CargarEmpleados();
        }

        public DataTable LlenarCampos(int id)
        {
            return cEven.LlenarCampos(id);
        }

        public void modificarEvento(Eventos even)
        {
            cEven.ModificarEvento(even);

        }

        public void BajaEvento(int id, string motivo)
        {
            cEven.BajaEvento(id,motivo);
        }

        public void Reintegrar(int id)
        {
            cEven.ReintegrarEvento(id);
        }

        public DataTable ListarInactivos(string activo,string dato)
        {
            return cEven.ListarInactivos(activo,dato);
        }

        public int Total(int id)
        {
            return cEven.Total(id);
        }

        public void actualizarTotal(int total, int id)
        {
            cEven.actualizarTotal(total,id);
        }


    }
}
