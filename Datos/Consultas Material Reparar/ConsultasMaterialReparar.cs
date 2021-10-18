using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Consultas_Material_Reparar
{
    public class ConsultasMaterialReparar:ConexionDB
    {



        public DataTable ListarReparaciones(string tipo,string dato)
        {
            DataTable dt = new DataTable();
            string consulta = "select * from material_en_reparacion where codigo_de_material like '%"+dato+"%' and fecha_de_salida is " + tipo;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;

        }

        public void CargarReparacion(string codigo, int cantidad,string motivo,string fecha)
        {
            string consulta = "insert into material_en_reparacion (codigo_de_material,cantidad,motivo,fecha_de_entrada)values('" + codigo + "'," + cantidad + ",'" + motivo + "','"+fecha+"')";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();


        }

        public DataTable LlenarCampos(int id)
        {
            DataTable dt = new DataTable();
            string consulta = "select * from material_en_reparacion where id= " + id;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;

        }

        public void EliminarReparacion(int id)
        {
            string consulta = "delete material_en_reparacion where id="+id;
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();


        }

        public void EditarReparacion(int id,int cantidad,string motivo,string fechai , string detalles)
        {
            string consulta = "set dateformat dmy UPDATE material_en_reparacion set cantidad="+ cantidad + ",motivo='"+motivo+ "', fecha_de_entrada='"+fechai+ "', detalle_de_raparacion='"+detalles+"' where id=" + id  ;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();


        }
        public void EditarReparacionSalida( string fechas , int id)
        {
            string consulta = "set dateformat dmy UPDATE material_en_reparacion set fecha_de_salida='" + fechas + "' where id=" + id;

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();


        }


        public void actualizarDisp(int cantidad, string codigo)
        {
            string consulta = "update material set disponobilidad=disponobilidad+@cant where codigo=@cod";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.Parameters.AddWithValue("@cant", cantidad);
            cmd.Parameters.AddWithValue("@cod", codigo);

            cmd.ExecuteNonQuery();
        }
    }
}
