using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {

        public string nombre_usuario { get; set; }

        public string dni { get; set; }
        public string contraseña { get; set; }
        public string email { get; set; }
        public int permiso { get; set; }
        public string activo { get; set; }

    }
}
