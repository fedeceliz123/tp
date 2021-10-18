using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos.ConsultasCompras
{
  public  class ConsultasCompras:ConexionDB
    {


        public int UltimoID()
        {
            DataTable dt = new DataTable();

            string consulta = "select max(id) as 'id' from compras";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];
            int ultimo = 1;

            foreach (DataRow row in dt.Rows)
            {
                ultimo = int.Parse(row["id"].ToString());
            }

            return ultimo;

        }

        public DataTable ListarCompra()
        {
            DataTable dt = new DataTable();

            string consulta = "select *from compras";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }

        public DataTable ListarCompraId(int id)
        {
            DataTable dt = new DataTable();

            string consulta = "select *from compras where id="+id;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }

        public void cargarCompra(compras com)
        {
            string consulta = "insert into compras (id_proveedor,fecha,factura,total)values" +
                                                    "(@prov,@fecha,@fac,@total)";


            SqlCommand cmd = new SqlCommand(consulta, Conetar());


            cmd.Parameters.AddWithValue("@prov", com.id_proveedor);
            cmd.Parameters.AddWithValue("@fecha", com.fecha);
            cmd.Parameters.AddWithValue("@fac", com.factura);
            cmd.Parameters.AddWithValue("@total", 0);



            cmd.ExecuteNonQuery();
        }

        public void editarCompra(compras com)
        {

            string consulta = " set dateformat dmy UPDATE compras set id_proveedor=@prov, fecha=@fecha,factura=@factura where id=@id";


            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.Parameters.AddWithValue("@id", com.id);
            cmd.Parameters.AddWithValue("@prov", com.id_proveedor);
            cmd.Parameters.AddWithValue("@fecha", com.fecha);
            cmd.Parameters.AddWithValue("@factura", com.factura);
            



            cmd.ExecuteNonQuery();

        }


        public void eliminarCompra(int id)
        {
            string consulta = "delete compras where id="+id;


            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }


        public int Total(int id)
        {
            int total = 0;
            DataTable dt = new DataTable();

            string consulta = "select total from compras where id="+id;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            foreach(DataRow row in dt.Rows)
            {
                total = int.Parse(row["total"].ToString());
            }


            return total;
        }

    }
}
