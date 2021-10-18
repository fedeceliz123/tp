using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Consulta_dia_deposito
{
    public class ConsultaDiaDeposito:ConexionDB
    {

        public DataTable ListarDeposito()
        {
            DataTable dt = new DataTable();

            string consulta = "select d.id as 'id', d.fecha as 'fecha',e.nombre+' '+e.apellido as 'empleado' from dia_de_deposito d,empleados e where d.id_empleado=e.dni";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }

        public DataTable ListarDia(int id   )
        {
            DataTable dt = new DataTable();

            string consulta = "select id , fecha ,id_empleado from dia_de_deposito  where id="+id;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }

        public void EditarDia(int id,string fecha,string dni)
        {
            string consulta = "set dateformat dmy UPDATE dia_de_deposito set fecha='"+fecha+"', id_empleado='"+dni+"' where id="+id;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

        public void EliminarDia(int id)
        {
            string consulta = "delete dia_de_deposito where id=" + id;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }


        public void CargarDia(string fecha, string dni)
        {
            string consulta = "insert into dia_de_deposito (fecha,id_empleado)values('"+fecha+"','"+dni+"')";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

    }
}
