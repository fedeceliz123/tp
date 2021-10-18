using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Eventos
    {
        public int id { get; set; }
        public string id_cliente { get; set; }
        public string fecha_inicio { get; set; }
        public string hora_inicio { get; set; }
        public string fecha_fin { get; set; }
        public string lugar { get; set; }
        public string encargado { get; set; }
        public int total { get; set; }
        public string detalle { get; set; }
        public string activo { get; set; }
        public string motivo { get; set; }
        public double descuento { get; set; }

    }
}
