using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos.ConsultaDetalleCompra
{
    public class ConsultaDetalleCompra:ConexionDB
    {

        public DataTable ListarDetalleCompra(int idCom)
        {
            DataTable dt = new DataTable();

            string consulta = "select *from detalle_compra where id_compra="+idCom;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }

        public DataTable ListarDetalle(int id)
        {

            DataTable dt = new DataTable();

            string consulta = "select  d.codigo_material as 'codigo',t.tipo as 'tipo',m.modelo as 'modelo', me.medida as 'medida',f.formato as 'formato',d.cantidad as 'cantidad',d.precio as 'precio' from detalle_compra d,material ma,tipo_material t,modelo_material m,formato_material f,medida_material me where d.codigo_material=ma.codigo and ma.tipo=t.id and " +
                              "ma.modelo=m.id and ma.formato=f.id and ma.medida=me.id and ma.tipo=m.id_tipo and ma.tipo=f.id_tipo and d.id_compra="+id;
                                
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarDetalle2(int id)
        {

            DataTable dt = new DataTable();

            string consulta = "select d.id as 'id',d.codigo_material as 'codigo',t.tipo +' '+ m.modelo +' '+ me.medida +' '+ f.formato as 'material',d.cantidad as 'cantidad',d.precio as 'precio' from detalle_compra d,material ma,tipo_material t,modelo_material m,formato_material f,medida_material me where convert (int,d.codigo_material)=ma.codigo and ma.tipo=t.id and " +
                              "ma.modelo=m.id and ma.formato=f.id and ma.medida=me.id and ma.tipo=m.id_tipo and ma.tipo=f.id_tipo and d.id_compra=" + id;
            //string consulta = "select d.id as 'id',d.codigo_material as 'codigo',d.cantidad as 'cantidad',d.precio as 'precio' from detalle_compra d where " +
            //                  " d.id_compra=" + id;

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }


        public void cargarDetalleCompra(detalle_compra dc)
        {
            string consulta = "insert into detalle_compra (id_compra,codigo_material,cantidad,precio)values" +
                                                    "(@com,@cod,@can,@precio)";


            SqlCommand cmd = new SqlCommand(consulta, Conetar());


            cmd.Parameters.AddWithValue("@com", dc.id_compra);
            cmd.Parameters.AddWithValue("@cod", dc.codigo_material);
            cmd.Parameters.AddWithValue("@can", dc.cantidad);
            cmd.Parameters.AddWithValue("@precio", dc.precio);



            cmd.ExecuteNonQuery();
        }

        public void editarDetalleCompra(detalle_compra dc)
        {
            string consulta = "update detalle_compra set codigo_material=@cod,cantidad=@can,precio=@precio,detalle=@det where id=@id";
                                                    


            SqlCommand cmd = new SqlCommand(consulta, Conetar());


            cmd.Parameters.AddWithValue("@con", dc.id);
            cmd.Parameters.AddWithValue("@cod", dc.codigo_material);
            cmd.Parameters.AddWithValue("@can", dc.cantidad);
            cmd.Parameters.AddWithValue("@precio", dc.precio);
            cmd.Parameters.AddWithValue("@det", dc.detalle);


            cmd.ExecuteNonQuery();
        }

        public void eliminarDetalleCompra(int id)
        {
            string consulta = "delete detalle_compra where id="+id;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }
        public void eliminarDetCompraTodo(int id)
        {
            string consulta = "delete detalle_compra where id_compra=" + id;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }

        public int descontarTotal(int id)
        {
            int total = 0;

            string consulta = "select cantidad*precio as 'total' from detalle_compra where id=" + id;
           
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

           DataTable dt = ds.Tables[0];

            foreach(DataRow row in dt.Rows)
            {
                total = int.Parse(row["total"].ToString());
            }

            return total;
        }

        public void disminuirTotal(int id, int idd)
        {
            string consulta = "UPDATE compras set total=total-" + descontarTotal(idd)+" where id=" + id;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }


        public void aumentarTotal(int id, int idd)
        {
            string consulta = "update compras set total=total+" + descontarTotal(idd) + " where id=" + id;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }

        public int idDetalle(int idCom)
        {
            DataTable dt = new DataTable();

            string consulta = "select max(id) as 'id' from detalle_compra where id_compra=" + idCom;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            int id = 0;

            foreach(DataRow row in dt.Rows)
            {
                id = int.Parse(row["id"].ToString());
            }
            return id;

        }

        public int descontarCantidad(int id)
        {
            int total = 0;

            string consulta = "select cantidad from detalle_compra where id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            foreach(DataRow row in dt.Rows)
            {
                total = int.Parse(row["cantidad"].ToString());
            }



            return total;
        }

        public void disminuirCantidad(int idd, int id)
        {

            string cod = codigo(id);
            int cant = descontarCantidad(idd);

            string consulta = "update material set disponobilidad=disponobilidad-"+cant+", stock_general=stock_general-"+cant+" where codigo="+cod;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            
            cmd.ExecuteNonQuery();

         
        }
       
     

        public void AmentarCantidad(int cantidad, string codigo)
        {
            string consulta = "update material set disponobilidad=disponobilidad+@cantidad, stock_general=stock_general+@cantidad where codigo=@codigo";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.ExecuteNonQuery();
        }



        public string codigo(int id)
        {

            string consulta = "select codigo_material from detalle_compra where id=" + id;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            string cod = "";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            foreach(DataRow row in dt.Rows)
            {
                cod = row["codigo_material"].ToString();
            }


            return cod;
        }


        public void disminuirCantidadTotal( int idcompra)
        {
            DataTable dt = CantidadCodigo(idcompra);

            foreach(DataRow row in dt.Rows)
            {

            string consulta = "update material set disponobilidad=disponobilidad-"+row["cantidad"].ToString()+", stock_general=stock_general-"+ row["cantidad"].ToString() + " where codigo ="+ row["codigo_material"].ToString() ;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            
            cmd.ExecuteNonQuery();




            }


            
        }

        public DataTable CantidadCodigo(int idcompra)
        {
            string consulta = "select codigo_material,cantidad from detalle_compra where id_compra="+idcompra;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            return dt;
        }


    }
}
