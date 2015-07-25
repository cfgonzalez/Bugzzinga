using System.Collections.Generic;
using Bugzzinga.Core.Atributos;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Estado 
    {
        private IList<Estado> _proximosEstadosValidos = new ArrayList4<Estado>();

        private IList<Estado> _anterioresEstadosValidos = new ArrayList4<Estado>();

        public Estado(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;            
        }

        public string Nombre { get; internal set; }
        public string Descripcion { get; set; }

        public IEnumerable<Estado> ProximosEstadosValidos { get { return this._proximosEstadosValidos; } }

        public IEnumerable<Estado> AnterioresEstadosValidos { get { return this._anterioresEstadosValidos; } }
    }
}
