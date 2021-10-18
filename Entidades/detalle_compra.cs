using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class detalle_compra
    {
        public int id { get; set; }
        public int id_compra { get; set; }
        public int codigo_material { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public string detalle { get; set; }
    }
}
