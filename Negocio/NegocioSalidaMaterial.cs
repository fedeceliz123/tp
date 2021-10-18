using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Datos;

namespace Negocio
{
  public  class NegocioSalidaMaterial
    {

        Datos.SalidaMaterial.ConsultasSalidaMaterial conSal = new Datos.SalidaMaterial.ConsultasSalidaMaterial();


        public string reCodigo(int id)
        {
            return conSal.recCodigo(id);
        }

        public int reCantidad(int id)
        {
            return conSal.recCantidad(id);
        }

        public void cargarSalida(Entidades.SalidaMaterial sal)
        {
            conSal.cargarSalidaMaterial(sal);
        }

        public DataTable listarSalida(int id)
        {
           return conSal.LiastarSalidas(id);
        }

        public bool Existe(int id)
        {
            return conSal.ExisteSalida(id);
        }

        public void actualizarMaterial(int cantidad,string codigo)
        {
            conSal.actualizarDisp(cantidad,codigo);
        }

        public void QuitarMaterial(int id)
        {
            conSal.QuitarElemento(id);
        }

        public void EntradaMaterial(EntradaMaterial entMat)
        {
            conSal.CargarIngreso(entMat);
        }

        public DataTable ListarEntrada(int id)
        {
            return conSal.LiastarEntrada(id);
        }

        public void QuitarMateriaEntrada(int id)
        {
            conSal.QuitarElementoEntrada(id);
        }
    }
}
