using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos.ConsultaEventos
{
   public class ConsultasEventos:ConexionDB
    {


        public DataTable LlenarCampos(int id)
        {
            DataTable dt = new DataTable();
            string consulta = "select * from eventos where id=" + id ;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }

        public void CargarEvento(Eventos ev)
        {
            string consulta = "insert into eventos (id_cliente,fecha_inicio,hora_inicio,fecha_fin,lugar,encargado,total,detalle,activo,descuento)values(@cli,@fi,@hora,@ff,@lugar,@enc,@total,@det,'si',@des)";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.Parameters.AddWithValue("@cli",ev.id_cliente);
            cmd.Parameters.AddWithValue("@fi", ev.fecha_inicio);
            cmd.Parameters.AddWithValue("@hora", ev.hora_inicio);
            cmd.Parameters.AddWithValue("@ff", ev.fecha_fin);
            cmd.Parameters.AddWithValue("@lugar", ev.lugar);
            cmd.Parameters.AddWithValue("@enc", ev.encargado);
            cmd.Parameters.AddWithValue("@total", ev.total);
            cmd.Parameters.AddWithValue("@det", ev.detalle);
            cmd.Parameters.AddWithValue("@des", ev.descuento);

            cmd.ExecuteNonQuery();
        }

        public DataTable ListarEventos(string activo,string dato, string date)

        {
            string fecha = (DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd");

            DataTable dt = new DataTable();
            string consulta = "select e.id as 'id',e.lugar as 'Lugar',e.fecha_inicio as 'Fecha',e.hora_inicio as 'Hora',c.nombre+' '+c.apellido as 'Cliente' from eventos e, clientes_cf c where (e.activo='"+activo+"' and fecha_inicio > '"+fecha+ "') and id_cliente=c.dni and (c.nombre+' '+c.apellido like '%" + dato + "%' or lugar like '%" + dato + "%' or fecha_inicio like '%" + date + "%')";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }

        public DataTable ListarInactivos(string activo,string dato)

        {
            string fecha = (DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd");

            DataTable dt = new DataTable();
            string consulta = "select e.id,e.lugar as 'Lugar',e.fecha_inicio as 'Fecha',e.hora_inicio as 'Hora',c.nombre+' '+c.apellido as 'Cliente' from eventos e, clientes_cf c where (e.activo='" + activo + "' or e.fecha_inicio < '" + fecha + "') and e.id_cliente=c.dni and (c.nombre+' '+c.apellido like '%"+dato+"%' or lugar like '%"+dato+"%' or fecha_inicio like '%"+dato+"%')" ;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }


        public DataTable CargarClientes()
        {
            DataTable dt = new DataTable();
            string consulta = "select dni, nombre+' '+apellido as cliente from clientes_cf where activo='si'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }
        public DataTable CargarEmpleados()
        {
            DataTable dt = new DataTable();
            string consulta = "select dni, nombre+' '+apellido as empleado from empleados where activo='si'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }


        public void ModificarEvento(Eventos even)
        {
            string consulta = "set dateformat dmy UPDATE eventos set id_cliente='"+even.id_cliente+ 
                "', fecha_inicio='"+even.fecha_inicio+ "', hora_inicio='"+even.hora_inicio+ "', fecha_fin='"+even.fecha_fin+
                "', lugar='"+even.lugar+ "',encargado="+even.encargado+ ", total="+even.total+ ", detalle='"+even.detalle+"' where id="+even.id;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

        public void BajaEvento(int id, string motivo)


        {
           

            string consulta = "set dateformat dmy UPDATE eventos set activo='no', motivo='" + motivo + "' where id=" + id ;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }


        public void ReintegrarEvento(int id)
        {


            string consulta = "set dateformat dmy UPDATE eventos set activo='si', motivo='' where id=" + id ;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

        public int Total(int id)
        {
            int total = 0;

            DataTable dt = new DataTable();
            string consulta = "select precio from salida_material where id_evento="+id;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
             
            foreach(DataRow row in dt.Rows)
            {
                total = total + int.Parse(row["precio"].ToString());
            }




            return total;

        }

        public void actualizarTotal(int total, int id)
        {
            string consulta = "set dateformat dmy UPDATE eventos set total="+total+" where id=" + id;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

    }
}
