using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class SalidaMaterial
    {
        public int id { get; set; }
        public int id_evento { get; set; }
        public string codigo_material { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }

    }
}
