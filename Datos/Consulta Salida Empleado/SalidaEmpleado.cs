using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;


namespace Datos.Consulta_Salida_Empleado
{
   public class SalidaEmpleado:ConexionDB
    {

        public DataTable ListarSalidaEmpleado(int id)
        {
            DataTable dt = new DataTable();

            string consulta = "select s.id,e.nombre+' '+e.apellido as 'empleado', ev.lugar as 'lugar'  from salida_de_empleados s, empleados e, eventos ev where ev.id="+id+
                " and s.id_empleado=e.dni and s.id_evento=ev.id";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public void CargarSalida(int evento,string empleado)
        {

            string consulta = "insert into salida_de_empleados  (id_evento,id_empleado) values("+evento+",'"+empleado+"')";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            

            cmd.ExecuteNonQuery();

        }

        public void eliminarSalida(int id)
        {
            string consulta = "delete salida_de_empleados where id="+id;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());



            cmd.ExecuteNonQuery();
        }

    }
}
