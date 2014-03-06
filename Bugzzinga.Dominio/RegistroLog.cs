using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio
{
    public class RegistroLog:IRegistroLog
    {
        public RegistroLog()
        {
            throw new NotImplementedException("Obtener hora de un servicio  rr");

        }

        public DateTime Fecha { get; internal set; }
        public string Comentarios { get; set; }
        
        public IEstado Estado { get; internal set; }
        public IUsuario Responsable { get; set; }
    }
}
