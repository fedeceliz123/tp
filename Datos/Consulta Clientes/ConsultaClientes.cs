using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Consulta_Clientes
{
   public class ConsultaClientes:ConexionDB
    {

        public DataTable ListarClientes(string activo)
        {
            DataTable dt = new DataTable();

            string consulta = "select dni as 'Dni',nombre as 'Nombre', apellido as 'Apellido',fecha_de_nacimiento as 'Fecha de nacimiento' from clientes_cf where activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable LlenarComposCli(string dni)
        {

            DataTable dt = new DataTable();

            string consulta = "select * from clientes_cf where dni='"+dni+"'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable dirClientes(Clientes clientes)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from direcciones where id_persona='" + clientes.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }
        public DataTable mailClientes(Clientes clientes)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from emails where id_persona='" + clientes.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable telClientes(Clientes clientes)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from telefonos where id_persona='" + clientes.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }


        public void ModificarCli(Clientes clientes, Direcciones dir, Telefonos tel, Emails mail)
        {
            // empleados
            string consulta = "set dateformat dmy UPDATE clientes_cf set nombre='" + clientes.nombre + "',apellido='" + clientes.apellido + "',sexo='" + clientes.sexo + "',fecha_de_nacimiento='" + clientes.fecha_de_nacimiento + "',ocupacion='" + clientes.ocupacion + "',fecha_de_ingreso='" + clientes.fecha_de_ingreso + "' where dni='" + clientes.dni + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();

            ///direcciones
            string consulta2 = "UPDATE direcciones set pais='" + dir.pais + "', provincia='" + dir.provincia + "', localidad='" + dir.localidad + "', cp='" + dir.cp + "', barrio='" + dir.barrio + "', calle='" + dir.calle + "', numero='" + dir.numero + "', piso='" + dir.piso + "', dpto='" + dir.dpto + "', mzna='" + dir.mzna + "', lote='" + dir.lote + "'  where id_persona = '" + clientes.dni + "'";

            SqlCommand cmd2 = new SqlCommand(consulta2, Conetar());

            cmd2.ExecuteNonQuery();

            // telefono

            string consulta3 = "UPDATE telefonos set codigo_de_area='" + tel.codigo_de_area + "', numero='" + tel.numero + "' where id_persona='" + clientes.dni + "'";


            SqlCommand cmd3 = new SqlCommand(consulta3, Conetar());

            cmd3.ExecuteNonQuery();

            // mail

            string consulta4 = "UPDATE emails set email='" + mail.email + "' where id_persona = '" + clientes.dni + "'";


            SqlCommand cmd4 = new SqlCommand(consulta4, Conetar());

            cmd4.ExecuteNonQuery();

            


        }

        public DataTable FiltoClientes(string activo, string dato)
        {
            DataTable dt = new DataTable();

            string consulta = "select dni as 'Dni',nombre as 'Nombre', apellido as 'Apellido',fecha_de_nacimiento as 'Fecha de Nacimiento' from clientes_cf where (dni like '%" + dato + "%' or nombre+' '+apellido like '%" + dato + "%') and activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }


        public void CargarCli(Clientes cli, Direcciones dir, Telefonos tel, Emails mail)
        {

            // empleados
            string consulta = "insert into clientes_cf (dni,nombre,apellido,sexo,fecha_de_nacimiento,ocupacion,fecha_de_ingreso,activo)values" +
                                                     "(@dni,@nombre,@apellido,@sexo,@fechaN,@puesto,@fechaI,@activo)";


            SqlCommand cmd = new SqlCommand(consulta, Conetar());


            cmd.Parameters.AddWithValue("@dni", cli.dni);
            cmd.Parameters.AddWithValue("@nombre", cli.nombre);
            cmd.Parameters.AddWithValue("@apellido", cli.apellido);
            cmd.Parameters.AddWithValue("@fechaN", cli.fecha_de_nacimiento);
            cmd.Parameters.AddWithValue("@puesto", cli.ocupacion);
            cmd.Parameters.AddWithValue("@fechaI", cli.fecha_de_ingreso);
            cmd.Parameters.AddWithValue("@activo", "si");
            
            cmd.Parameters.AddWithValue("@sexo", cli.sexo);


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

        public void DardeBajaCli(string dni, string motivo)
        {

            string hoy = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE clientes_cf set activo='no', motivo_egreso='" + motivo + "',fecha_de_egreso='" + hoy + "' where dni='" + dni + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();


        }
        public void ReintegrarCli(string dni)
        {

            string hoy = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE clientes_cf set activo='si', motivo_egreso='',fecha_de_ingreso='" + hoy + "' where dni='" + dni + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();

        }


    }
}
