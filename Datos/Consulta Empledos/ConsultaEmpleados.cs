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


namespace Datos.Consulta_Empledos
{
    public class ConsultaEmpleados : ConexionDB
    {
        public DataTable LEmpleaos(Empleados empleado, string activo)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from empleados where dni like '%" + empleado.dni + "%' and activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarEmpleaos(string activo)
        {
            DataTable dt = new DataTable();

            string consulta = "select dni as 'Dni',nombre as 'Nombre', apellido as 'Apellido',puesto as 'Puesto' from empleados where activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarEmpleaosSelect()
        {
            DataTable dt = new DataTable();

            string consulta = "select dni ,nombre +' '+ apellido as 'empleado',puesto as 'Puesto' from empleados where activo='si'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }
        public DataTable selecEmpleados(string dni)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from empleados where dni='" + dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }
        public DataTable telEmpleados(Empleados empleado)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from telefonos where id_persona='" + empleado.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable dirEmpleados(Empleados empleado)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from direcciones where id_persona='" + empleado.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public DataTable mailEmpleados(Empleados empleado)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from emails where id_persona='" + empleado.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }

        public void ModificarEmp(Empleados empleados, Direcciones dir, Telefonos tel, Emails mail, Login login)
        {
            // empleados
            string consulta = "set dateformat dmy UPDATE Empleados set nombre='" + empleados.nombre + "',apellido='" + empleados.apellido + "',sexo='" + empleados.sexo + "',fecha_de_nacimiento='" + empleados.fecha_nacimiento + "',puesto='" + empleados.puesto + "',fecha_de_ingreso='" + empleados.fecha_ingreso + "',valor_dia_deposito=" + empleados.valor_dia_deposito + ",valor_dia_evento=" + empleados.valor_dia_evento + ", imagen=@img where dni='" + empleados.dni + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.Parameters.AddWithValue("@img", empleados.imagen.GetBuffer());

            cmd.ExecuteNonQuery();

            ///direcciones
            string consulta2 = "UPDATE direcciones set pais='" + dir.pais + "', provincia='" + dir.provincia + "', localidad='" + dir.localidad + "', cp='" + dir.cp + "', barrio='" + dir.barrio + "', calle='" + dir.calle + "', numero='" + dir.numero + "', piso='" + dir.piso + "', dpto='" + dir.dpto + "', mzna='" + dir.mzna + "', lote='" + dir.lote + "'  where id_persona = '" + empleados.dni + "'";

            SqlCommand cmd2 = new SqlCommand(consulta2, Conetar());

            cmd2.ExecuteNonQuery();

            // telefono

            string consulta3 = "UPDATE telefonos set codigo_de_area='" + tel.codigo_de_area + "', numero='" + tel.numero + "' where id_persona='" + empleados.dni + "'";


            SqlCommand cmd3 = new SqlCommand(consulta3, Conetar());

            cmd3.ExecuteNonQuery();

            // mail

            string consulta4 = "UPDATE emails set email='" + mail.email + "' where id_persona = '" + empleados.dni + "'";


            SqlCommand cmd4 = new SqlCommand(consulta4, Conetar());

            cmd4.ExecuteNonQuery();

            // usuario

            string consulta5 = "UPDATE login set activo='"+login.activo+"' ,permiso='"+login.permiso+"', email='" + login.email + "' ,contraseña='" + login.contraseña + "' ,nombre_usuario='" + login.nombre_usuario + "' where dni= '" + empleados.dni + "'";


            SqlCommand cmd5 = new SqlCommand(consulta5, Conetar());

            cmd5.ExecuteNonQuery();


        }

        public DataTable UserEmp(Empleados empleado)
        {
            DataTable dt = new DataTable();

            string consulta = "select * from login where dni='" + empleado.dni + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }


        public DataTable FiltoEmpleaos(string activo, string dato)
        {
            DataTable dt = new DataTable();

            string consulta = "select dni as 'Dni',nombre as 'Nombre', apellido as 'Apellido',puesto as 'Puesto' from empleados where (dni like '%" + dato + "%' or nombre+' '+apellido like '%" + dato + "%' or puesto like '%" + dato + "%') and activo='" + activo + "'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;

        }


        public DataTable listaPermisos()
        {
            DataTable dt = new DataTable();

            string consulta = "select * from permisos";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];

            return dt;
        }

        public void CargarEmp(Empleados empleados, Direcciones dir, Telefonos tel, Emails mail, Login login)
        {

            // empleados
            string consulta = "insert into empleados (dni,nombre,apellido,sexo,fecha_de_nacimiento,puesto,fecha_de_ingreso,activo,valor_dia_deposito,valor_dia_evento)values"+
                                                     "(@dni,@nombre,@apellido,@sexo,@fechaN,@puesto,@fechaI,@activo,@vd,@ve)";


            SqlCommand cmd = new SqlCommand(consulta, Conetar());


            cmd.Parameters.AddWithValue("@dni", empleados.dni);
            cmd.Parameters.AddWithValue("@nombre", empleados.nombre);
            cmd.Parameters.AddWithValue("@apellido", empleados.apellido);
            cmd.Parameters.AddWithValue("@fechaN", empleados.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@puesto", empleados.puesto);
            cmd.Parameters.AddWithValue("@fechaI", empleados.fecha_ingreso);
            cmd.Parameters.AddWithValue("@activo", "si");
            cmd.Parameters.AddWithValue("@vd", empleados.valor_dia_deposito);
            cmd.Parameters.AddWithValue("@ve", empleados.valor_dia_evento);
            cmd.Parameters.AddWithValue("@sexo", empleados.sexo);
            //cmd.Parameters.AddWithValue("@imagen", empleados.imagen.GetBuffer());


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

            // usuario

            string consulta5 = "insert into login (nombre_usuario,dni,contraseña,email,permiso,activo)values" +
                                                     "(@user,@dni,@cont,@mail,@permiso,@activo)";


            SqlCommand cmd5 = new SqlCommand(consulta5, Conetar());

            cmd5.Parameters.AddWithValue("@dni", login.dni);
            cmd5.Parameters.AddWithValue("@user", login.nombre_usuario);
            cmd5.Parameters.AddWithValue("@cont", login.contraseña);
            cmd5.Parameters.AddWithValue("@mail", login.email);
            cmd5.Parameters.AddWithValue("@permiso", login.permiso);
            cmd5.Parameters.AddWithValue("@activo", login.activo);



            cmd5.ExecuteNonQuery();

        }

        public void DardeBajaEmp(string dni,string motivo)
        {

            string hoy = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE Empleados set activo='no', motivo_egreso='"+motivo+"',fecha_de_egreso='"+hoy+"' where dni='" + dni+"'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();


        }
        public void ReintegrarEmp(string dni)
        {

            string hoy = DateTime.Now.ToString("dd/MM/yyyy");

            string consulta = "set dateformat dmy UPDATE Empleados set activo='si', motivo_egreso='',fecha_de_ingreso='" + hoy + "' where dni='" + dni + "'";

            SqlCommand cmd = new SqlCommand(consulta, Conetar());

            cmd.ExecuteNonQuery();

        }


        public MemoryStream Cargarimagen(string dni)
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
