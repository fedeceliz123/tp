using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Datos;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet("ListarClientes")]
        public JsonResult ListarClientes(string activo)
        {
            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            var dt = consulta.ListarClientes(activo);

            List<Entidades.Clientes> lista = new List<Entidades.Clientes>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Clientes()
                     {
                         dni = (dr["dni"]).ToString(),
                         nombre = (dr["nombre"]).ToString(),
                         apellido = (dr["apellido"]).ToString(),
                         fecha_de_nacimiento = (dr["fecha_de_nacimiento"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }

        [HttpGet("LlenarClientes")]
        public JsonResult LlenarClientes(string dni)
        {

            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            var dt = consulta.LlenarComposCli(dni);

            List<Entidades.Clientes> lista = new List<Entidades.Clientes>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Clientes()
                     {
                         dni = (dr["dni"]).ToString(),
                         nombre = (dr["nombre"]).ToString(),
                         apellido = (dr["apellido"]).ToString(),
                         sexo=(dr["sexo"]).ToString(),
                         fecha_de_nacimiento = (dr["fecha_de_nacimiento"]).ToString(),
                         ocupacion=(dr["ocupacion"]).ToString(),
                         fecha_de_ingreso=(dr["fecha_de_ingreso"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }

        [HttpGet("LlenarDireccione")]
        public JsonResult LlenarDirecciones(string dni)
        {

            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            cli.dni = dni;
            var dt = consulta.dirClientes(cli);

            List<Entidades.Direcciones> lista = new List<Entidades.Direcciones>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Direcciones()
                     {
                       id=int.Parse((dr["id"]).ToString()),
                         pais=(dr["pais"]).ToString(),
                         provincia=(dr["provincia"]).ToString(),
                         localidad=(dr["localidad"]).ToString(),
                         cp=(dr["cp"]).ToString(),
                         barrio=(dr["barrio"]).ToString(),
                         calle=(dr["calle"]).ToString(),
                         numero=(dr["numero"]).ToString(),
                         piso=(dr["piso"]).ToString(),
                         dpto=(dr["dpto"]).ToString(),
                         mzna=(dr["mzna"]).ToString(),
                         lote=(dr["lote"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }
        [HttpGet("LlenarEmails")]
        public JsonResult LlenarEmais(string dni)
        {

            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            cli.dni = dni;
            var dt = consulta.mailClientes(cli);

            List<Entidades.Emails> lista = new List<Entidades.Emails>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Emails()
                     {
                       email=(dr["email"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }

        [HttpGet("LlenarTelefonos")]
        public JsonResult LlenarTelefonos(string dni)
        {

            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            cli.dni = dni;
            var dt = consulta.telClientes(cli);

            List<Entidades.Telefonos> lista = new List<Entidades.Telefonos>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Telefonos()
                     {
                         codigo_de_area = (dr["codigo_de_area"]).ToString(),
                         numero=(dr["numero"]).ToString()
                        

                     }).ToList();

            return new JsonResult(lista);

        }

        [HttpPut("ModificarCliente")]
        public JsonResult ModificarCliente(string dni, string nombre,string apellido,string sexo,string fecha_de_nacimiento, string ocupacion,string fecha_de_ingreso,
                                           string pais, string provincia, string localidad, string cp,
                                                string barrio, string calle, string numero, string piso, string dpto,
                                                string mzna, string lote, string codigo, string telefono, string email)
        {
            Entidades.Clientes cli = new Clientes();
            Entidades.Telefonos tel = new Telefonos();
            Entidades.Emails mail = new Emails();
            Entidades.Direcciones dir = new Direcciones();

            //clientes 
            cli.dni = dni;
            cli.nombre = nombre;
            cli.apellido = apellido;
            cli.sexo = sexo;
            cli.fecha_de_nacimiento = fecha_de_nacimiento;
            cli.ocupacion = ocupacion;
            cli.fecha_de_ingreso = fecha_de_ingreso;
            // direcciones
            dir.pais = pais;
            dir.provincia = provincia;
            dir.localidad = localidad;
            dir.cp = cp;
            dir.barrio = barrio;
            dir.calle = calle;
            dir.numero = numero;
            dir.piso = piso;
            dir.dpto = dpto;
            dir.mzna = mzna;
            dir.lote = lote;
            // telefono
            tel.codigo_de_area = codigo;
            tel.numero = telefono;
            //mail
            mail.email = email;


            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();


            try
            {
                consulta.ModificarCli(cli, dir, tel, mail);

                return new JsonResult("cliente modificado");
            }
            catch
            {
                return new JsonResult("error en la modificacion");
            }


        }
        [HttpGet("FiltroClientes")]
        public JsonResult FiltroClientes(string activo,string dato)
        {
            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            var dt = consulta.FiltoClientes(activo,dato);

            List<Entidades.Clientes> lista = new List<Entidades.Clientes>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Clientes()
                     {
                         dni = (dr["dni"]).ToString(),
                         nombre = (dr["nombre"]).ToString(),
                         apellido = (dr["apellido"]).ToString(),
                         fecha_de_nacimiento = (dr["fecha_de_nacimiento"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }


        [HttpPost("CargarCliente")]
        public JsonResult CargarCliente(string dni, string nombre, string apellido, string sexo, string fecha_de_nacimiento, string ocupacion, string fecha_de_ingreso,
                                         string pais, string provincia, string localidad, string cp,
                                              string barrio, string calle, string numero, string piso, string dpto,
                                              string mzna, string lote, string codigo, string telefono, string email)
        {
            Entidades.Clientes cli = new Clientes();
            Entidades.Telefonos tel = new Telefonos();
            Entidades.Emails mail = new Emails();
            Entidades.Direcciones dir = new Direcciones();

            //clientes 
            cli.dni = dni;
            cli.nombre = nombre;
            cli.apellido = apellido;
            cli.sexo = sexo;
            cli.fecha_de_nacimiento = fecha_de_nacimiento;
            cli.ocupacion = ocupacion;
            cli.fecha_de_ingreso = fecha_de_ingreso;
            // direcciones
            dir.pais = pais;
            dir.provincia = provincia;
            dir.localidad = localidad;
            dir.cp = cp;
            dir.barrio = barrio;
            dir.calle = calle;
            dir.numero = numero;
            dir.piso = piso;
            dir.dpto = dpto;
            dir.mzna = mzna;
            dir.lote = lote;
            // telefono
            tel.codigo_de_area = codigo;
            tel.numero = telefono;
            //mail
            mail.email = email;


            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();


            try
            {
                consulta.CargarCli(cli, dir, tel, mail);

                return new JsonResult("cliente cargado");
            }
            catch
            {
                return new JsonResult("error en la carga");
            }


        }


        [HttpPut("BajaClientes")]
        public JsonResult BajaClientes(string dni, string motivo)
        {
            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            try
            {
                consulta.DardeBajaCli(dni,motivo);
                return new JsonResult("cliente dado de baja");
            }
            catch
            {
                return new JsonResult("error en la baja");
            }

        }
        [HttpPut("ReintegroClientes")]
        public JsonResult RenitegroClientes(string dni)
        {
            Entidades.Clientes cli = new Clientes();
            var consulta = new Datos.Consulta_Clientes.ConsultaClientes();
            try
            {
                consulta.ReintegrarCli(dni);
                return new JsonResult("cliente dado de baja");
            }
            catch
            {
                return new JsonResult("error en la baja");
            }

        }
    }
}
