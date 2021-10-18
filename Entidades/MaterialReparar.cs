using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MaterialReparar
    {
        public int id { get; set; }
        public string codigo_de_material { get; set; }
        public int cantidad { get; set; }
        public string motivo { get; set; }
        public string fecha_de_entrada { get; set; }
        public string fecha_de_salida { get; set; }
        public string detalle_de_raparacion { get; set; }
    }
}
