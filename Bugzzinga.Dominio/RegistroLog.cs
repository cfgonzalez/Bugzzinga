using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class RegistroLog
    {
        public RegistroLog()
        {            

        }

        public DateTime Fecha { get; internal set; }
        public string Comentarios { get; set; }
        
        public Estado Estado { get; internal set; }
        public Usuario Responsable { get; set; }
    }
}
