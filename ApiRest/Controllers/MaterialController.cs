using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;
using System.IO;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        [HttpGet("ListarMaterial")]
        public JsonResult ListarMaterial(string dato,string activo)
        {
            Entidades.ListaMaterial listMat = new ListaMaterial();
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            var dt = consulta.ListarMaterialFiltro(dato,activo);

            List<Entidades.ListaMaterial> lista = new List<Entidades.ListaMaterial>();

            lista= (from DataRow dr in dt.Rows
                    select new Entidades.ListaMaterial()
                    {
                        Codigo = (dr["Codigo"]).ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Modelo = dr["Modelo"].ToString(),
                        Formato = dr["Formato"].ToString(),
                        Medida = dr["Medida"].ToString(),
                        Disponibilidad = int.Parse(dr["Disponibilidad"].ToString())
                    }).ToList();

            return new JsonResult(lista);

        }

        [HttpGet("ListarTipo")]
        public JsonResult listarTipo()
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            var dt = consulta.LlenarTipo();

            List<Entidades.TipoMaterial> tipo = new List<TipoMaterial>();

            tipo= (from DataRow dr in dt.Rows
                   select new Entidades.TipoMaterial()
                   {
                       id = int.Parse((dr["id"]).ToString()),
                       tipo = (dr["tipo"]).ToString()

                   }).ToList();

            return new JsonResult(tipo);
        }

        [HttpGet("ListarModelo")]
        public JsonResult listarMoldelo(int tipos)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            var dt = consulta.LlenarModelo(tipos);

            List<Entidades.ModeloMaterial> tipo = new List<ModeloMaterial>();

            tipo = (from DataRow dr in dt.Rows
                    select new Entidades.ModeloMaterial()
                    {
                        id = int.Parse((dr["id"]).ToString()),
                       id_tipo=int.Parse((dr["id_tipo"].ToString())),
                        modelo = (dr["modelo"]).ToString()

                    }).ToList();

            return new JsonResult(tipo);
        }
        [HttpGet("ListarMedida")]
        public JsonResult listarMedida(int tipos)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            var dt = consulta.LlenarMedida(tipos);

            List<Entidades.MedidaMaterial> medida = new List<MedidaMaterial>();

            medida = (from DataRow dr in dt.Rows
                      select new Entidades.MedidaMaterial()
                      {
                          id = int.Parse((dr["id"]).ToString()),
                          
                          medida = (dr["medida"]).ToString()

                      }).ToList();

            return new JsonResult(medida);
        }
        [HttpGet("CodigoUltimo")]
        public JsonResult CodigoUltimo(int tipos,int modelo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();

            int numero;
            string codigo;
            if (consulta.Ultimo(tipos, modelo) != "")
            {
                numero = int.Parse(consulta.Ultimo(tipos, modelo));

            }
            else
            {
                numero = 1;
            }

            if (tipos < 10)
            {
                codigo = "0" + tipos.ToString();
            }
            else
            {
                codigo = tipos.ToString();
            }
            if (modelo < 10)
            {
                codigo = codigo + "0" + modelo.ToString();
                
            }
            else
            {
                codigo = codigo + modelo.ToString();
            }


            if (numero < 10)
            {
                codigo = codigo + "0" + numero.ToString();
            }
            else
            {
                codigo = codigo + numero;
            };

          
            return new JsonResult(codigo);
        }

        [HttpGet("ListarFormato")]
        public JsonResult listarFormato(int tipos, int modelo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();

            int numero;
            string codigo;
            if (consulta.Ultimo(tipos, modelo) != "")
            {
                numero = int.Parse(consulta.Ultimo(tipos, modelo));

            }
            else
            {
                numero = 1;
            }

            if (tipos < 10)
            {
                codigo = "0" + tipos.ToString();
            }
            else
            {
                codigo = tipos.ToString();
            }
            if (modelo < 10)
            {
                codigo = codigo + "0" + modelo.ToString();

            }
            else
            {
                codigo = codigo + modelo.ToString();
            }


            var dt = consulta.LlenarFormato(codigo);

            List<Entidades.FormatoMaterial> formato = new List<FormatoMaterial>();

            formato = (from DataRow dr in dt.Rows
                      select new Entidades.FormatoMaterial()
                      {
                          id = int.Parse((dr["id"]).ToString()),
                          
                          formato = (dr["formato"]).ToString(),
                       

                      }).ToList();




            return new JsonResult(formato);
        }

        [HttpGet("UltimoModelo")]
        public JsonResult UltimoModelo(int tipos)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            int um = consulta.UltimoModelo(tipos);

           

            return new JsonResult(um);
        }
        [HttpPost("CargarModelo")]
        public JsonResult CargarModelo(int tipos,string modelo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();


            try
            {
             consulta.CargaModelo(tipos,modelo);

            return new JsonResult("Se cargo modelo");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("CargarTipo")]
        public JsonResult CargarTipo(string tipos)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();


            try
            {
                consulta.CargaTipo(tipos);

                return new JsonResult("Se cargo tipo");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("CargarMedida")]
        public JsonResult CargarMedida(int tipos, string medida)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();


            try
            {
                consulta.CargaMedida(tipos,medida);

                return new JsonResult("Se cargo medida");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("CargarFormato")]
        public JsonResult CargarFormato(int tipos, string formato, int tipo,int modelo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            int numero;
            string codigo;
            if (consulta.Ultimo(tipos, modelo) != "")
            {
                numero = int.Parse(consulta.Ultimo(tipos, modelo));

            }
            else
            {
                numero = 1;
            }

            if (tipos < 10)
            {
                codigo = "0" + tipos.ToString();
            }
            else
            {
                codigo = tipos.ToString();
            }
            if (modelo < 10)
            {
                codigo = codigo + "0" + modelo.ToString();

            }
            else
            {
                codigo = codigo + modelo.ToString();
            }

            try
            {
                consulta.CargaFormato(codigo,formato,tipo);

                return new JsonResult("Se cargo formato");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("CargarMaterial")]
        public JsonResult CargarMaterial(int tipo,int modelo,int numero,string codigo,int medida,int formato,int stock_general,int disponobilidad)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            Material material = new Material();
            material.tipo = tipo;
            material.modelo = modelo;
            material.numero = numero;
            material.codigo=codigo;
            material.medida = medida;
            material.formato = formato;
            material.stock_general = stock_general;
            material.disponobilidad = disponobilidad;
           



            try
            {
                consulta.CargaMaterial(material);

                return new JsonResult("Se cargo material");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }


        [HttpGet("LlenarCampos")]
        public JsonResult LlenarCampos(string codigo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            var dt = consulta.LlenarCampos(codigo);

            List<Entidades.Material> material = new List<Material>();

            material = (from DataRow dr in dt.Rows
                        select new Entidades.Material()
                        {
                            tipo = int.Parse(dr["tipo"].ToString()),
                            modelo = int.Parse(dr["modelo"].ToString()),
                            numero = int.Parse(dr["numero"].ToString()),
                            codigo = (dr["codigo"]).ToString(),
                            medida = int.Parse((dr["medida"].ToString())),
                            formato = int.Parse((dr["medida"].ToString())),
                            stock_general = int.Parse((dr["stock_general"].ToString())),
                            disponobilidad = int.Parse((dr["disponobilidad"].ToString()))



                        }).ToList();

            return new JsonResult(material);
        }

        [HttpPut("BajaMaterial")]
        public JsonResult BajaMaterial(string codigo, string motivo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            
           


            try
            {
                consulta.BajaMaterial(codigo,motivo);
             

                return new JsonResult("baja realizada");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }

        [HttpPut("ModificarMaterial")]
        public JsonResult ModificarMaterial(int medida, int formato, int stock, int disp, string codigo, string detalle)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();
            Entidades.Material mat = new Material();
            mat.medida = medida;
            mat.formato = formato;
            mat.stock_general = stock;
            mat.disponobilidad = disp;
            mat.codigo = codigo;
            mat.detalle = detalle;


            try
            {
                consulta.ModificarMaterial(medida, formato, stock, disp, codigo, detalle);


                return new JsonResult("modificacion realizada");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }
        [HttpPut("ReintegrarMaterial")]
        public JsonResult ReintegrarMaterial(string codigo)
        {
            var consulta = new Datos.Consulta_Matrial.ConsultaMaterial();




            try
            {
                consulta.ReintegrarMaterial(codigo);


                return new JsonResult("reintegracion realizada");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }
    }
}
