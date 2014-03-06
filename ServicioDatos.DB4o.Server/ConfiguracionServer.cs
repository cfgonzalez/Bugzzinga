using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioDatos.DB4o.Server
{
    public class ConfiguracionServer
    {
        public string NombreHost { get; set; }
        public string NombreArchivoBD { get; set; }
        public int Puerto { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

    }
}
