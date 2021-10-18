using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {

        [HttpGet("ListarProveedores")]
        public JsonResult ListarProveedores(string activo)
        {
            Entidades.Proveedores proveedores = new Entidades.Proveedores();
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            var dt = consulta.ListarProv(activo);

            List<Entidades.Proveedores> prov = new List<Entidades.Proveedores>();

            prov = (from DataRow dr in dt.Rows
                    select new Entidades.Proveedores()
                    {
                        cuit = (dr["cuit"]).ToString(),
                        razon_social = (dr["razon_social"]).ToString(),
                        nombre_fantasia = (dr["nombre_fantasia"]).ToString(),
                        rubro = (dr["rubro"]).ToString()



                    }).ToList();

            return new JsonResult(prov);

        }


        [HttpGet("LenarCamposProveedor")]
        public JsonResult LlenarCampos(string cuit)
        {
            Entidades.Proveedores proveedores = new Entidades.Proveedores();
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            var dt = consulta.LlenarComposPro(cuit);

            List<Entidades.Proveedores> prov = new List<Entidades.Proveedores>();

            prov = (from DataRow dr in dt.Rows
                    select new Entidades.Proveedores()
                    {
                        cuit = (dr["cuit"]).ToString(),
                        razon_social = (dr["razon_social"]).ToString(),
                        nombre_fantasia = (dr["nombre_fantasia"]).ToString(),
                        rubro = (dr["rubro"]).ToString(),
                        iva = (dr["iva"]).ToString(),
                        fecha_de_ingeso = (dr["fecha_de_ingeso"]).ToString(),




                    }).ToList();

            return new JsonResult(prov);

        }


        [HttpGet("DireccionProveedor")]
        public JsonResult DireccionProveedores(string cuit)
        {
            Entidades.Direcciones dir = new Entidades.Direcciones();
            Entidades.Proveedores prov = new Entidades.Proveedores();
            prov.cuit = cuit;
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            var dt = consulta.dirPro(prov);

            List<Entidades.Direcciones> dirc = new List<Entidades.Direcciones>();

            dirc = (from DataRow dr in dt.Rows
                    select new Entidades.Direcciones()
                    { 
                        
                        id = int.Parse((dr["id"]).ToString()),
                        id_persona = (dr["id_persona"]).ToString(),
                        pais = (dr["pais"]).ToString(),
                        provincia=(dr["provincia"]).ToString(),
                        localidad=(dr["localidad"]).ToString(),
                        cp=(dr["cp"]).ToString(),
                        barrio=(dr["barrio"]).ToString(),
                        calle=(dr["calle"]).ToString(),
                        numero=(dr["numero"]).ToString(),
                        piso=(dr["piso"]).ToString(),
                        dpto=(dr["dpto"]).ToString(),
                        mzna=(dr["mzna"]).ToString(),
                        lote=(dr["lote"]).ToString()





                    }).ToList();

            return new JsonResult(dirc);

        }
        [HttpGet("TelefonosProveedores")]
        public JsonResult TelefonosProveedores(string cuit)
        {
            Entidades.Proveedores proveedores = new Entidades.Proveedores();
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            proveedores.cuit = cuit;
            var dt = consulta.telPro(proveedores);

            List<Entidades.Telefonos> tel = new List<Entidades.Telefonos>();

            tel = (from DataRow dr in dt.Rows
                    select new Entidades.Telefonos()
                    {
                        id=int.Parse((dr["id"]).ToString()),
                        id_persona = (dr["id_persona"]).ToString(),
                        codigo_de_area=(dr["codigo_de_area"]).ToString(),
                        numero=(dr["numero"]).ToString()




                    }).ToList();

            return new JsonResult(tel);

        }
        [HttpGet("EmailsProveedores")]
        public JsonResult EmailsProveedores(string cuit)
        {
            Entidades.Proveedores proveedores = new Entidades.Proveedores();
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            proveedores.cuit = cuit;
            var dt = consulta.mailPro(proveedores);

            List<Entidades.Emails> mail = new List<Entidades.Emails>();

            mail = (from DataRow dr in dt.Rows
                   select new Entidades.Emails()
                   {
                       id = int.Parse((dr["id"]).ToString()),
                       id_persona = (dr["id_persona"]).ToString(),
                      email = (dr["email"]).ToString(),
                       




                   }).ToList();

            return new JsonResult(mail);

        }


        [HttpPut("ModificarProveedores")]
        public JsonResult ModificarProveedores(string cuit,string rs,string nf, string iva,string rubro,string fi,
                                                string pais,string provincia,string localidad, string cp,
                                                string barrio,string calle,string numero,string piso, string dpto, 
                                                string mzna,string lote, string codigo,string telefono,string email)
        {
            Entidades.Proveedores prov = new Entidades.Proveedores();
            Entidades.Telefonos tel = new Telefonos();
            Entidades.Emails mail = new Emails();
            Entidades.Direcciones dir = new Direcciones();
           // proveedores
            prov.razon_social = rs;
            prov.nombre_fantasia = nf;
            prov.iva = iva;
            prov.rubro = rubro;
            prov.fecha_de_ingeso = fi;
            prov.cuit = cuit;
            // direcciones
            dir.pais = pais;
            dir.provincia = provincia;
            dir.localidad = localidad;
            dir.cp = cp;
            dir.barrio = barrio;
            dir.calle = calle;
            dir.numero = numero;
            dir.piso = piso;
            dir.dpto = dpto;
            dir.mzna = mzna;
            dir.lote = lote;
            // telefono
            tel.codigo_de_area = codigo;
            tel.numero = telefono;
            //mail
            mail.email = email;


             var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            
            
            try
            {
            consulta.ModificarPro(prov,dir,tel,mail);

            return new JsonResult("proveedor modificado");
            } 
            catch
            {
                return new JsonResult("error en la modificacion");
            }                             


        }
        [HttpGet("FiltroProveedores")]
        public JsonResult FiltroProveedores(string dato, string activo)
        {
           
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            
            var dt = consulta.FiltoPro(activo,dato);

            List<Entidades.Proveedores> prov = new List<Entidades.Proveedores>();

            prov = (from DataRow dr in dt.Rows
                    select new Entidades.Proveedores()
                    {

                        cuit = (dr["cuit"]).ToString(),
                        razon_social = (dr["razon_social"]).ToString(),
                        nombre_fantasia = (dr["nombre_fantasia"]).ToString(),
                        rubro = (dr["rubro"]).ToString()

                    }).ToList();

            return new JsonResult(prov);

        }

        [HttpPost("CargarProveedores")]
        public JsonResult CargarProveedores(string cuit, string rs, string nf, string iva, string rubro, string fi,
                                              string pais, string provincia, string localidad, string cp,
                                              string barrio, string calle, string numero, string piso, string dpto,
                                              string mzna, string lote, string codigo, string telefono, string email)
        {
            Entidades.Proveedores prov = new Entidades.Proveedores();
            Entidades.Telefonos tel = new Telefonos();
            Entidades.Emails mail = new Emails();
            Entidades.Direcciones dir = new Direcciones();
            // proveedores
            prov.razon_social = rs;
            prov.nombre_fantasia = nf;
            prov.iva = iva;
            prov.rubro = rubro;
            prov.fecha_de_ingeso = fi;
            prov.cuit = cuit;
            // direcciones
            dir.pais = pais;
            dir.provincia = provincia;
            dir.localidad = localidad;
            dir.cp = cp;
            dir.barrio = barrio;
            dir.calle = calle;
            dir.numero = numero;
            dir.piso = piso;
            dir.dpto = dpto;
            dir.mzna = mzna;
            dir.lote = lote;
            // telefono
            tel.codigo_de_area = codigo;
            tel.numero = telefono;
            //mail
            mail.email = email;


            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();


            try
            {
                consulta.CargarPro(prov, dir, tel, mail);

                return new JsonResult("proveedor cargado");
            }
            catch
            {
                return new JsonResult("error en la carga");
            }


        }

        [HttpPut("BajaProveedor")]
        public JsonResult BajaProveedores(string cuit, string motivo)
        {
            Entidades.Proveedores prov = new Entidades.Proveedores();
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            try
            {
                consulta.DardeBajaPro(cuit,motivo);
                return new JsonResult("proveedor dado de baja");
            }
            catch
            {
                return new JsonResult("error en la baja");
            }
        }

        [HttpPut("ReintegrarProveedor")]
        public JsonResult ReintegrarProveedores(string cuit)
        {
            Entidades.Proveedores prov = new Entidades.Proveedores();
            var consulta = new Datos.ConsultasProveedores.ConsultaProveedores();
            try
            {
                consulta.ReintegrarPro(cuit);
                return new JsonResult("proveedor reintegrado");
            }
            catch
            {
                return new JsonResult("error en reintegrado");
            }
        }

    }
}
