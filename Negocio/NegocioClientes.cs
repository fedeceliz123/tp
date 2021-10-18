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
    public class NegocioClientes
    {
        Datos.Consulta_Clientes.ConsultaClientes clientes = new Datos.Consulta_Clientes.ConsultaClientes();

        public DataTable ListarClientes(string activo)
        {
            return clientes.ListarClientes(activo);
        }


        public DataTable llenarCamposCli(string dni)
        {
            return clientes.LlenarComposCli(dni);
        }
        public DataTable dirClientes(Clientes cliente)
        {
            return clientes.dirClientes(cliente);
        }
        public DataTable telCli(Clientes cliente)
        {
            return clientes.telClientes(cliente);
        }
        public DataTable mailCli(Clientes cliente)
        {
            return clientes.mailClientes(cliente);
        }

        public void ModificarCliente(Clientes cliente,Direcciones dir,Telefonos tel, Emails mail)
        {
            clientes.ModificarCli(cliente,dir,tel,mail);
        }
        public DataTable filtroCli(string activo,string dato)
        {
            return clientes.FiltoClientes(activo,dato);
        }

        public void CargarCli(Clientes cli ,Direcciones dir, Telefonos tel, Emails mail)
        {
            clientes.CargarCli(cli,dir,tel,mail);
        }

        public void DarDeBajaCli(string dni,string motivo)
        {
            clientes.DardeBajaCli(dni,motivo);
        }

        public void reactivarCli(string dni)
        {
            clientes.ReintegrarCli(dni);
        }


    }
}
