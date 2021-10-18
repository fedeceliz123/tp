using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos.ConsultasProveedores
{
   public class ConsultaProveedores:ConexionDB
    {
        public DataTable ListarProv(string activo)
        {
            DataTable dt = new DataTable();

            string consulta = "select cuit as 'Cuit',razon_social as 'Razon Social', nombre_fantasia as 'Nombre Fantasia',rubro as 'Rubro' from proveedores where activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable LlenarComposPro(string cuit)
        {

            DataTable dt = new DataTable();

            string consulta = "select * from proveedores where cuit='" + cuit + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable dirPro(Proveedores prov)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from direcciones where id_persona='" + prov.cuit + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }
        public DataTable mailPro(Proveedores prov)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from emails where id_persona='" + prov.cuit+ "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable telPro(Proveedores prov)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from telefonos where id_persona='" + prov.cuit + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }


        public void ModificarPro(Proveedores prov, Direcciones dir, Telefonos tel, Emails mail)
        {
            // empleados
            string consulta = "set dateformat dmy UPDATE proveedores  set razon_social='" + prov.razon_social + "',nombre_fantasia='" + prov.nombre_fantasia + "',iva='" + prov.iva + "',rubro='" + prov.rubro + "',fecha_de_ingreso='" + prov.fecha_de_ingeso + "' where cuit='" + prov.cuit + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();

            ///direcciones
            string consulta2 = "UPDATE direcciones set pais='" + dir.pais + "', provincia='" + dir.provincia + "', localidad='" + dir.localidad + "', cp='" + dir.cp + "', barrio='" + dir.barrio + "', calle='" + dir.calle + "', numero='" + dir.numero + "', piso='" + dir.piso + "', dpto='" + dir.dpto + "', mzna='" + dir.mzna + "', lote='" + dir.lote + "'  where id_persona = '" + prov.cuit + "'";

            SqlCommand cmd2 = new SqlCommand(consulta2, Conetar());

            cmd2.ExecuteNonQuery();

            // telefono

            string consulta3 = "UPDATE telefonos set codigo_de_area='" + tel.codigo_de_area + "', numero='" + tel.numero + "' where id_persona='" + prov.cuit + "'";


            SqlCommand cmd3 = new SqlCommand(consulta3, Conetar());

            cmd3.ExecuteNonQuery();

            // mail

            string consulta4 = "UPDATE emails set email='" + mail.email + "' where id_persona = '" + prov.cuit + "'";


            SqlCommand cmd4 = new SqlCommand(consulta4, Conetar());

            cmd4.ExecuteNonQuery();




        }

        public DataTable FiltoPro(string activo, string dato)
        {
            DataTable dt = new DataTable();

            string consulta = "select cuit as 'Dni',razon_social as 'Razon Social', nombre_fantasia as 'Nombre Fantasia',rubro as 'Rubro' from proveedores where (cuit like '%" + dato + "%' or razon_social like '%"+dato+ "%' or nombre_fantasia like '%" + dato + "%') and activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }


        public void CargarPro(Proveedores pro, Direcciones dir, Telefonos tel, Emails mail)
        {

            // empleados
            string consulta = "insert into proveedores (cuit,razon_social,nombre_fantasia,iva,rubro,fecha_de_ingreso,activo)values" +
                                                     "(@cuit,@raz,@nomFan,@iva,@rubro,@fechaI,@activo)";


            SqlCommand cmd = new SqlCommand(consulta, Conetar());


            cmd.Parameters.AddWithValue("@cuit", pro.cuit );
            cmd.Parameters.AddWithValue("@raz",pro.razon_social );
            cmd.Parameters.AddWithValue("@nomFan", pro.nombre_fantasia);
            cmd.Parameters.AddWithValue("@iva", pro.iva);
            cmd.Parameters.AddWithValue("@rubro", pro.rubro);
            cmd.Parameters.AddWithValue("@fechaI", pro.fecha_de_ingeso);
            cmd.Parameters.AddWithValue("@activo", "si");

            


            cmd.ExecuteNonQuery();

            ///direcciones
            string consulta2 = "insert into direcciones (id_persona,pais,provincia,localidad,cp,barrio,calle,numero,piso,dpto,mzna,lote)values" +
                                                     "(@dni,@pais,@prov,@loc,@cp,@barrio,@calle,@n,@piso,@dpto,@mzna,@lote)";

            SqlCommand cmd2 = new SqlCommand(consulta2, Conetar());

            cmd2.Parameters.AddWithValue("@dni", dir.id_persona);
            cmd2.Parameters.AddWithValue("@pais", dir.pais);
            cmd2.Parameters.AddWithValue("@prov", dir.provincia);
            cmd2.Parameters.AddWithValue("@loc", dir.localidad);
            cmd2.Parameters.AddWithValue("@cp", dir.cp);
            cmd2.Parameters.AddWithValue("@barrio", dir.barrio);
            cmd2.Parameters.AddWithValue("@calle", dir.calle);
            cmd2.Parameters.AddWithValue("@n", dir.numero);
            cmd2.Parameters.AddWithValue("@piso", dir.piso);
            cmd2.Parameters.AddWithValue("@dpto", dir.dpto);
            cmd2.Parameters.AddWithValue("@mzna", dir.mzna);
            cmd2.Parameters.AddWithValue("@lote", dir.lote);

            cmd2.ExecuteNonQuery();

            // telefono

            string consulta3 = "insert into telefonos (id_persona,codigo_de_area,numero)values" +
                                                     "(@dni,@cod,@num)";


            SqlCommand cmd3 = new SqlCommand(consulta3, Conetar());
            cmd3.Parameters.AddWithValue("@dni", tel.id_persona);
            cmd3.Parameters.AddWithValue("@cod", tel.codigo_de_area);
            cmd3.Parameters.AddWithValue("@num", tel.numero);


            cmd3.ExecuteNonQuery();

            // mail

            string consulta4 = "insert into emails (id_persona,email)values" +
                                                     "(@dni,@mail)";


            SqlCommand cmd4 = new SqlCommand(consulta4, Conetar());
            cmd4.Parameters.AddWithValue("@dni", mail.id_persona);
            cmd4.Parameters.AddWithValue("@mail", mail.email);



            cmd4.ExecuteNonQuery();



        }

        public void DardeBajaPro(string cuit, string motivo)
        {

            string hoy = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE proveedores set activo='no', motivo_egreso='" + motivo + "',fecha_de_egreso='" + hoy + "' where cuit='" + cuit + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();


        }
        public void ReintegrarPro(string cuit)
        {

            string hoy = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE proveedores set activo='si', motivo_egreso='',fecha_de_ingreso='" + hoy + "' where cuit='" + cuit + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();

        }

        public DataTable Cargarcombo()
        {
            DataTable dt = new DataTable();

            string consulta = "select cuit , nombre_fantasia from proveedores where activo='si'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }



    }
}
