using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        [HttpGet("ListarEmpleados")]
        public JsonResult ListarEmpleados( string activo)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            
            var dt = consulta.ListarEmpleaos(activo);

            List<Entidades.Empleados> lista = new List<Entidades.Empleados>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Empleados()
                     {
                        dni=(dr["dni"]).ToString(),
                        nombre=(dr["nombre"]).ToString(),
                        apellido=(dr["apellido"]).ToString(),
                        puesto=(dr["puesto"]).ToString()
                     }).ToList();

            return new JsonResult(lista);

        }

        [HttpGet("ListaEmpleado")]
        public JsonResult ListaEmpleado(string dni,string activo)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            emp.dni = dni;
            var dt = consulta.LEmpleaos(emp,activo);

            List<Entidades.Empleados> lista = new List<Entidades.Empleados>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Empleados()
                     {
                         dni = (dr["dni"]).ToString(),
                         nombre = (dr["nombre"]).ToString(),
                         apellido = (dr["apellido"]).ToString(),
                         sexo=(dr["sexo"]).ToString(),
                         fecha_nacimiento=(dr["fecha_nacimiento"]).ToString(),
                         puesto = (dr["puesto"]).ToString(),
                         fecha_ingreso=(dr["fecha_ingreso"]).ToString(),
                         
                     }).ToList();

            return new JsonResult(lista);

        }


        [HttpGet("TelefonoEmpleado")]
        public JsonResult TelefonoEmpleado(string dni)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            emp.dni = dni;
            var dt = consulta.telEmpleados(emp);

            List<Entidades.Telefonos> lista = new List<Entidades.Telefonos>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Telefonos()
                     {
                         codigo_de_area= (dr["codigo_de_area"]).ToString(),
                         numero=(dr["numero"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }


        [HttpGet("DireccionEmpleado")]
        public JsonResult DireccionEmpleado(string dni)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            emp.dni = dni;
            var dt = consulta.dirEmpleados(emp);

            List<Entidades.Direcciones> lista = new List<Entidades.Direcciones>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Direcciones()
                     {
                         pais=(dr["pais"]).ToString(),
                         provincia=(dr["provincia"]).ToString(),
                         localidad=(dr["localidad"]).ToString(),
                         cp=(dr["cp"]).ToString(),
                         barrio = (dr["barrio"]).ToString(),
                         calle = (dr["calle"]).ToString(),
                         numero = (dr["numero"]).ToString(),
                         piso = (dr["piso"]).ToString(),
                         dpto = (dr["dpto"]).ToString(),
                         mzna = (dr["mzna"]).ToString(),
                         lote = (dr["lote"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }



        [HttpGet("EmailEmpleado")]
        public JsonResult EmailEmpleado(string dni)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            emp.dni = dni;
            var dt = consulta.mailEmpleados(emp);

            List<Entidades.Emails> lista = new List<Entidades.Emails>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Emails()
                     {
                         email = (dr["email"]).ToString(),
                        

                     }).ToList();

            return new JsonResult(lista);

        }


        [HttpPut("ModificarEmpleado")]
        public JsonResult ModificarEmpleados(string dni, string nombre, string apellido, string sexo, string fecha_de_nacimiento, string puesto, string fecha_de_ingreso,int valor_dia_deposito,int valor_dia_evento,
                                         string pais, string provincia, string localidad, string cp,
                                              string barrio, string calle, string numero, string piso, string dpto,
                                              string mzna, string lote, string codigo, string telefono, string email,
                                              string usuario,string contraseña,string permiso,string activo)
        {
            Entidades.Empleados emp = new Empleados();
            Entidades.Telefonos tel = new Telefonos();
            Entidades.Emails mail = new Emails();
            Entidades.Direcciones dir = new Direcciones();
            Entidades.Login login = new Login();

            //empleados
           emp.dni = dni;
           emp.nombre = nombre;
           emp.apellido = apellido;
           emp.sexo = sexo;
            emp.fecha_nacimiento = fecha_de_nacimiento;
            emp.fecha_ingreso = fecha_de_ingreso;
            emp.puesto = puesto;
            emp.valor_dia_deposito = valor_dia_deposito;
            emp.valor_dia_evento = valor_dia_evento;


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
            //login
            login.activo = activo;
            login.permiso =int.Parse( permiso);
            login.contraseña = contraseña;
            login.email = email;
            login.nombre_usuario = usuario;

            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();


            try
            {
                consulta.ModificarEmp(emp, dir, tel, mail,login);

                return new JsonResult("empleado modificado");
            }
            catch
            {
                return new JsonResult("error en la modificacion");
            }


        }



        [HttpGet("UserEmp")]
        public JsonResult UserEmp(string dni)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            emp.dni = dni;
            var dt = consulta.UserEmp(emp);

            List<Entidades.Login> lista = new List<Entidades.Login>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Login()
                     {
                         dni = (dr["dni"]).ToString(),
                        nombre_usuario=(dr["nobre_usuario"]).ToString(),
                        contraseña=(dr["controseña"]).ToString(),
                        email=(dr["emial"]).ToString(),
                        permiso=int.Parse((dr["permiso"]).ToString()),
                        activo=(dr["permiso"]).ToString()
                     }).ToList();

            return new JsonResult(lista);

        }


        [HttpGet("FiltrarEmpleado")]
        public JsonResult FiltrarEmpleado(string activo,string dato)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
         
            var dt = consulta.FiltoEmpleaos(activo,dato);

            List<Entidades.Empleados> lista = new List<Entidades.Empleados>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Empleados()
                     {
                         dni = (dr["dni"]).ToString(),
                         nombre = (dr["nombre"]).ToString(),
                         apellido = (dr["apellido"]).ToString(),
                         puesto = (dr["puesto"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }

        [HttpGet("ListarPermisos")]
        public JsonResult ListarPermisos()
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();

            var dt = consulta.listaPermisos();

            List<Entidades.Permisos> lista = new List<Entidades.Permisos>();

            lista = (from DataRow dr in dt.Rows
                     select new Entidades.Permisos()
                     {
                         id=int.Parse((dr["id"]).ToString()),
                         permiso=(dr["permiso"]).ToString()

                     }).ToList();

            return new JsonResult(lista);

        }


        [HttpPost("CargarEmpleado")]
        public JsonResult CargarEmpleados(string dni, string nombre, string apellido, string sexo, string fecha_de_nacimiento, string puesto, string fecha_de_ingreso, int valor_dia_deposito, int valor_dia_evento,
                                      string pais, string provincia, string localidad, string cp,
                                           string barrio, string calle, string numero, string piso, string dpto,
                                           string mzna, string lote, string codigo, string telefono, string email,
                                           string usuario, string contraseña, string permiso, string activo)
        {
            Entidades.Empleados emp = new Empleados();
            Entidades.Telefonos tel = new Telefonos();
            Entidades.Emails mail = new Emails();
            Entidades.Direcciones dir = new Direcciones();
            Entidades.Login login = new Login();

            //empleados
            emp.dni = dni;
            emp.nombre = nombre;
            emp.apellido = apellido;
            emp.sexo = sexo;
            emp.fecha_nacimiento = fecha_de_nacimiento;
            emp.fecha_ingreso = fecha_de_ingreso;
            emp.puesto = puesto;
            emp.valor_dia_deposito = valor_dia_deposito;
            emp.valor_dia_evento = valor_dia_evento;


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
            //login
            login.activo = activo;
            login.permiso = int.Parse(permiso);
            login.contraseña = contraseña;
            login.email = email;
            login.nombre_usuario = usuario;

            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();


            try
            {
                consulta.CargarEmp(emp, dir, tel, mail, login);

                return new JsonResult("empleado modificado");
            }
            catch
            {
                return new JsonResult("error en la modificacion");
            }


        }


        [HttpPut("BajaEmpleado")]
        public JsonResult BajaEmpleado(string dni,string motivo)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            try
            {
                consulta.DardeBajaEmp(dni, motivo);
                return new JsonResult("empleado dado de baja");
            }
            catch
            {
                return new JsonResult("error en la baja");
            }


        }


        [HttpPut("ReintegrarEmpleado")]
        public JsonResult ReintegrarEmpleado(string dni)
        {
            Entidades.Empleados emp = new Empleados();
            var consulta = new Datos.Consulta_Empledos.ConsultaEmpleados();
            try
            {
                consulta.ReintegrarEmp(dni);
                return new JsonResult("empleado reintegrado");
            }
            catch
            {
                return new JsonResult("error en el reintegro");
            }


        }
    }
}
