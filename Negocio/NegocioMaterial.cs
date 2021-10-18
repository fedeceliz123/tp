using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioMaterial
    {
        Datos.Consulta_Matrial.ConsultaMaterial Mat = new Datos.Consulta_Matrial.ConsultaMaterial();
        public DataTable LlenarTipo()
        {
            return Mat.LlenarTipo();
        }
        public int Disponibilidad(string codigo)
        {
            return Mat.Disponibilidad(codigo);
        }

        public DataTable LlenarModelo(int tipo)
        {
            return Mat.LlenarModelo(tipo);
        }
        public DataTable LlenarMedida(int tipo)
        {
            return Mat.LlenarMedida(tipo);
        }

        public string Ultimo(int tipo ,int modelo)
        {
            return Mat.Ultimo(tipo,modelo);
        }

        public int UltimoModelo(int tipo)
        {
            return Mat.UltimoModelo(tipo);
        }

        public void CargaModelo(int tipo,string modelo)
        {
            Mat.CargaModelo(tipo,modelo);
        }

        public void CargaTipo(string tipo)
        {
            Mat.CargaTipo(tipo);
        }

        public void CargaMedida(int tipo,string medida)
        {
            Mat.CargaMedida(tipo,medida);
        }

        public void CargarMaterial(Material material)
        {
          
            Mat.CargaMaterial(material);

            
        }

        public DataTable LlenarFormato(string tipo)
        {
           return Mat.LlenarFormato(tipo);
        }
        public void CargarFormato(string tipo, string formato,int tip)
        {
            Mat.CargaFormato(tipo,formato,tip);
        }

        public DataTable ListarMaterial(string activo)
        {
           return Mat.ListarMaterial(activo);
        }

        public DataTable ListarMaterialFiltro(string dato,string activo)
        {
            return Mat.ListarMaterialFiltro(dato,activo);
        }

        public DataTable LlenarCampos(string codigo)
        {
            return Mat.LlenarCampos(codigo);
        }

        public void ModificarMaterial(int medida, int formato, int stock, int disp, string codigo,string detalle,int precio)
        {
            Mat.ModificarMaterial(medida,formato,stock,disp,codigo,detalle,precio);
        }

        public void BajaMaterial(string codigo, string motivo)
        {
            Mat.BajaMaterial(codigo,motivo);
        }
        public void ReintegrarMaterial(string codigo)
        {
            Mat.ReintegrarMaterial(codigo);
        }

        public void Precio(string codigo)
        {
            Mat.Precio(codigo);
        }

    }
}
