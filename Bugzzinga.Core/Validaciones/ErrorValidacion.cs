using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Core.Validaciones
{
    public class ErrorValidacion
    {
        public ErrorValidacion()
        {
                
        }

        public ErrorValidacion(string mensaje)
        {
            this.Mensaje = mensaje;
        }

        public string Mensaje { get; set; }
    }
}
