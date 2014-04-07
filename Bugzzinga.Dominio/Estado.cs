using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Atributos;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Estado
    {
        private IList<Estado> _proximosEstadosValidos = new ArrayList4<Estado>();

        public Estado(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;            
        }

        public string Nombre { get; internal set; }
        public string Descripcion { get; set; }

        public IEnumerable<Estado> ProximosEstadosValidos { get { return this._proximosEstadosValidos; } }
    }
}
