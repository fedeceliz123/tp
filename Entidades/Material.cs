using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Material
    {
        public int tipo { get; set; }
        public int modelo { get; set; }
        public int numero { get; set; }
        public string codigo { get; set; }
        public int medida { get; set; }
        public int formato { get; set; }
        public int stock_general { get; set; }
        public int disponobilidad { get; set; }
        public MemoryStream codigo_qr { get; set; }
        public string activo { get; set; }
        public string fecha_egreso { get; set; }
        public string motivo { get; set; }
        public string detalle { get; set; }
        public int precio { get; set; }



    }
}
