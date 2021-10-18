using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Datos;
using System.Drawing;
using System.IO;

namespace Negocio
{
   public class NegocioEmpleados
    {
        Datos.Consulta_Empledos.ConsultaEmpleados emp = new Datos.Consulta_Empledos.ConsultaEmpleados();
       

        public DataTable ListarEmpleadosSelect()
        {
            return emp.ListarEmpleaosSelect();
        }

        public DataTable selecEmplado(string dni)
        {
            return emp.selecEmpleados(dni);
        }
        public void ModificarEmp(Empleados empl,Direcciones dir,Telefonos tel, Emails mail,Login login)
        {
            emp.ModificarEmp(empl,dir,tel,mail,login);
        }

        public DataTable FitroEmp(string activo, string dato)
        {
            return emp.FiltoEmpleaos(activo,dato);

        }

        public DataTable UserEmp(Empleados empleados)
        {
            return emp.UserEmp(empleados);
        }

        public DataTable listarPermisos()
        {
            return emp.listaPermisos();
        }

        public void cargarEmpleado(Empleados empl, Direcciones dir,Telefonos tel,Emails mail,Login login)
        {
            emp.CargarEmp(empl,dir,tel,mail,login);
        }


        public DataTable empleados(Empleados empleados,string activo)
        {

            return emp.LEmpleaos(empleados,activo);

        }

        public DataTable ListarEmp(string activo)
        {
            return emp.ListarEmpleaos(activo);
        }

        public void ModificarEmpleado(Empleados empleados)
        {
             //emp.ModificarEmp(empleados,);
        }

        public DataTable telefonoE(Empleados empleados)
        {
            return emp.telEmpleados(empleados);
        }
        public DataTable direccionE(Empleados empleados)
        {
            return emp.dirEmpleados(empleados);
        }
        public DataTable mailE(Empleados empleados)
        {
            return emp.mailEmpleados(empleados);
        }

        public void DarDeBajaEmp(string dni, string motivo)
        {
            emp.DardeBajaEmp(dni,motivo);
        }

        public void ReintrearEmp(string dni)
        {
            emp.ReintegrarEmp(dni);
        }

        public MemoryStream ImagenPerfil(string dni)
        {
            return emp.Cargarimagen(dni);
        }
    }
}
