using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.IO;

namespace Negocio
{
    public class NegocioLogin
    {
        Datos.Consultas_Login.ConsultasLogin conLog = new Datos.Consultas_Login.ConsultasLogin();
        public int ingresar(Login login)
        {

            return conLog.Acceso(login);

        }


        public string nombres(Login login)
        {
            return conLog.recuperarNombre(login);
        }

        public string dni(Login login)
        {
            return conLog.recuperarDNI(login);
        }
        public MemoryStream imagen(string dni)
        {
          return  conLog.CargarimagenUser(dni);
        }

    }
}
