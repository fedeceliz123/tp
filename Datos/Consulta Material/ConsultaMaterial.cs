using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Consulta_Matrial
{
   public class ConsultaMaterial:ConexionDB
    {

        public DataTable LlenarTipo()
        {
            DataTable dt = new DataTable();
            string consulta = "select * from tipo_material";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;

        }

        public DataTable LlenarModelo(int tipo)
        {
            DataTable dt = new DataTable();
            string consulta = "select id,id_tipo,modelo from modelo_material where id_tipo="+tipo;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;

        }
        public DataTable LlenarMedida(int tipo)
        {
            DataTable dt = new DataTable();
            string consulta = "select id,medida from medida_material where id_tipo=" + tipo;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }

        public string Ultimo(int tipo,int modelo)
        {
            string ultimo;
            DataTable dt = new DataTable();
            string consulta = "select MAX(numero+1) as 'num' from material where tipo='" + tipo +"' and modelo='"+modelo+"'" ;
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            if (lector.Read() == true)
            {
                if(lector["num"].ToString() != "")
                {
                    ultimo = lector["num"].ToString();
                    return ultimo;
                }
                else
                {
                    ultimo = "";
                    return ultimo;
                }
            }
            else
            {
                ultimo = "";
                return ultimo;
            }
                                   

        }

        public int UltimoModelo(int tipo)
        {
            int ultimo;
            DataTable dt = new DataTable();
            string consulta = "select COUNT(id) as 'num' from modelo_material where id_tipo='" + tipo + "'";
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            if (lector.Read() == true)
            {
                if (int.Parse(lector["num"].ToString()) != 0)
                {
                    ultimo = int.Parse(lector["num"].ToString())+1;
                    return ultimo;
                }
                else
                {
                    ultimo = 1;
                    return ultimo;
                }
            }
            else
            {
                ultimo = 1;
                return ultimo;
            }


        }

        public void CargaModelo(int tipo, string modelo)
        {
            string consulta = "insert into modelo_material (id,id_tipo,modelo)values('"+UltimoModelo(tipo)+"','" + tipo + "','"+modelo+"')";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }
        public void CargaTipo(string tipo)
        {
            string consulta = "insert into tipo_material (tipo)values('"+tipo+"')";
            SqlCommand cmd = new SqlCommand(consulta,Conetar());
            cmd.ExecuteNonQuery();
        }

        public void CargaMedida(int tipo, string medida)
        {
            string consulta = "insert into medida_material (id_tipo,medida)values('" + tipo + "','"+medida+"')";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }
        public void CargaFormato(string tipo, string formato,int tip)
        {
            string consulta = "insert into formato_material (cod,formato,id_tipo)values('" + tipo + "','" + formato + "', "+tip+")";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            cmd.ExecuteNonQuery();
        }

        public DataTable LlenarFormato(string tipo)
        {
            DataTable dt = new DataTable();
            string consulta = "select id,formato from formato_material where cod='" + tipo+"'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;

        }

        public void CargaMaterial(Material material)
        {
            string consulta = "insert into material (tipo,modelo,numero,codigo,medida,formato,activo,detalle,stock_general,disponobilidad,precio)values(@tipo,@modelo,@num,@cod,@medida,@nombre,'si',@detalle,@stock,@disp,@precio)";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.Parameters.AddWithValue("@tipo", material.tipo);
            cmd.Parameters.AddWithValue("@modelo", material.modelo);
            cmd.Parameters.AddWithValue("@num", material.numero);
            cmd.Parameters.AddWithValue("@cod", material.codigo);
            cmd.Parameters.AddWithValue("@medida", material.medida);
            cmd.Parameters.AddWithValue("@nombre", material.formato);
            cmd.Parameters.AddWithValue("@stock", material.stock_general);
            cmd.Parameters.AddWithValue("@disp", material.disponobilidad);
            cmd.Parameters.AddWithValue("@precio", material.precio);

            cmd.Parameters.AddWithValue("@detalle", material.detalle);
            cmd.ExecuteNonQuery();
        }

        public DataTable ListarMaterial(string activo)
        {
            DataTable dt = new DataTable();

            string consulta = "select ma.codigo as Codigo ,t.tipo as Tipo,m.modelo as Modelo,f.formato as Formato, me.medida as Medida, ma.disponobilidad as Disponibilidad  " +
                             " from material ma,tipo_material t,modelo_material m,formato_material f,medida_material me where ma.tipo=t.id and "+
                              "ma.modelo=m.id and ma.formato=f.id and ma.medida=me.id and ma.tipo=m.id_tipo and ma.tipo=f.id_tipo and ma.activo='"+activo+"'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }

        public int Precio(string codigo)
        {
            int precio = 0;

            string consulta = "select precio from material where codigo='" + codigo + "'";
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            if (lector.Read() == true)
            {


                precio = int.Parse(lector["precio"].ToString());

            }


            return precio;
        }


        public DataTable ListarMaterialFiltro(string dato,string activo)
        {
            DataTable dt = new DataTable();

            string consulta = "select ma.codigo as Codigo ,t.tipo as Tipo,m.modelo as Modelo,f.formato as Formato, me.medida as Medida, ma.disponobilidad as Disponibilidad  " +
                             " from material ma,tipo_material t,modelo_material m,formato_material f,medida_material me where ma.tipo=t.id and " +
                              "ma.modelo=m.id and ma.formato=f.id and ma.medida=me.id and ma.tipo=m.id_tipo and ma.tipo=f.id_tipo and "+
                              "(ma.codigo like '%"+dato+"%' or t.tipo like '%"+dato+"%' or m.modelo like '%"+dato+"%' or f.formato like '%"+dato+"%' ) and ma.activo='"+activo+"'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }

        public DataTable LlenarCampos(string codigo)
        {
            DataTable dt = new DataTable();
            string consulta = "select * from material where codigo='" + codigo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];


            return dt;
        }

        public void ModificarMaterial(int medida,int formato,int stock,int disp,string codigo,string detalle,int precio)
        {
            string consulta = "set dateformat dmy UPDATE material set medida = "+medida+" , formato= "+formato+ ", stock_general="+stock+ ", disponobilidad="+disp+", detalle='"+detalle+"', precio="+precio+" where codigo='"+codigo+"'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

        public void BajaMaterial( string codigo, string motivo)

           
        {
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE material set activo='no', motivo='"+motivo+"', fecha_egreso='"+fecha+"' where codigo='"+codigo+"'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }

        public void ReintegrarMaterial(string codigo)
        {
            

            string consulta = "set dateformat dmy UPDATE material set activo='si', motivo='', fecha_egreso='' where codigo='" + codigo + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();
        }


        public int Disponibilidad(string codigo)
        {
            int ultimo=0;
           
            string consulta = "select disponobilidad from material where codigo='" + codigo + "'";
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            if (lector.Read() == true)
            {


                ultimo = int.Parse(lector["disponobilidad"].ToString()) ;

            }

            return ultimo;
        }


    }




  }

