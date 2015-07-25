using System;
using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class LogItem
    {
        public LogItem()
        {            

        }

        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
        
        public Estado Estado { get; set; }
        public Usuario Responsable { get; set; }
        public Rol ResponsableRol { get; set; }
    }
}
