using System.Collections.Generic;
using Bugzzinga.Core.Atributos;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class TipoItem
    {

        private IList<Estado> _estadosDisponibles = new ArrayList4<Estado>();
        
        public TipoItem(string nombre,string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string Nombre { get; internal set; }
        public string Descripcion { get; set; }

        public IEnumerable<Estado> EstadosDisponibles { get { return this._estadosDisponibles; } }
    }
}
