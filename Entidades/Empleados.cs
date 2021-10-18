using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Empleados
    {

        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string sexo { get; set; }
        public string fecha_nacimiento { get; set; }
        public string puesto { get; set; }
        public string fecha_ingreso { get; set; }
        public string activo { get; set; }
        public string fecha_egreso { get; set; }
        public decimal valor_dia_deposito { get; set; }
        public decimal valor_dia_evento { get; set; }
        public MemoryStream imagen { get; set; }
    }
}
