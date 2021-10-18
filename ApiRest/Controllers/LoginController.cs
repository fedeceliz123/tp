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
    public class LoginController : ControllerBase
    {
        [HttpGet("Acceso")]
        public JsonResult Acceso(string user, string password)
        {
            Entidades.Login login = new Login();
            Datos.Consultas_Login.ConsultasLogin log = new Datos.Consultas_Login.ConsultasLogin();

            login.nombre_usuario = user;
            login.contraseña = password;

            int permiso = log.Acceso(login);

            return new JsonResult(permiso);
        }
        [HttpGet("RecuperarNombre")]
        public JsonResult RecuperarNombre(string user, string password)
        {
            Entidades.Login login = new Login();
            Datos.Consultas_Login.ConsultasLogin log = new Datos.Consultas_Login.ConsultasLogin();

            login.nombre_usuario = user;
            login.contraseña = password;

            string nombre = log.recuperarNombre(login);

            return new JsonResult(nombre);
        }


        [HttpGet("RecuperarDNi")]
        public JsonResult RecuperarDNI(string user, string password)
        {
            Entidades.Login login = new Login();
            Datos.Consultas_Login.ConsultasLogin log = new Datos.Consultas_Login.ConsultasLogin();

            login.nombre_usuario = user;
            login.contraseña = password;

            string dni = log.recuperarDNI(login);

            return new JsonResult(dni);
        }
    }
}
