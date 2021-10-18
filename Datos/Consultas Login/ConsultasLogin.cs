using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace Datos.Consultas_Login
{
   public class ConsultasLogin:ConexionDB
    {
        public int Acceso(Login login)
        {
            int existe = 0;

            string consulta = "select permiso from login where nombre_usuario='" + login.nombre_usuario + "' and contraseña='" + login.contraseña + "'";

            SqlCommand command = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = command.ExecuteReader();

            if (leer.Read() == true)
            {
                existe = int.Parse(leer["permiso"].ToString());
            }


            return existe;


        }

        public string recuperarNombre(Login login)
        {
            string nombre = "";
            string consulta = "select nombre+', '+apellido as 'nombres'from empleados where dni=(select dni from login where  nombre_usuario='" + login.nombre_usuario + "' and contraseña='" + login.contraseña + "')";
            SqlCommand command = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = command.ExecuteReader();

            if (leer.Read() == true)
            {
                nombre = leer["nombres"].ToString();
                
            }


            return nombre;

        }

        public string recuperarDNI(Login login)
        {
            string nombre = "";
            string consulta = "select dni from empleados where dni=(select dni from login where  nombre_usuario='" + login.nombre_usuario + "' and contraseña='" + login.contraseña + "')";
            SqlCommand command = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = command.ExecuteReader();

            if (leer.Read() == true)
            {
                nombre = leer["dni"].ToString();
            }


            return nombre;

        }

        public MemoryStream CargarimagenUser(string dni)
        {

            SqlCommand a = new SqlCommand();
            string consulta = "select imagen from empleados where dni='" + dni + "'";

            a = new SqlCommand(consulta, Conetar());

            SqlDataReader leer = a.ExecuteReader();



            if (leer.HasRows)
            {
                //convertir los datos byts a la imagen 
                leer.Read();
                MemoryStream ms = new MemoryStream((byte[])leer["imagen"]);
                try
                {
                    Bitmap bm = new Bitmap(ms);

                }
                catch
                {
                    return null;
                }



                return ms;

            }
            else
            {
                return null;
            }


        }

    }
}
