using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio
{
    public class Estado
    {
        private IList<Estado> _proximosEstadosValidos;

        public Estado(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;

            this._proximosEstadosValidos = new List<Estado>();
        }

        public string Nombre { get; internal set; }
        public string Descripcion { get; set; }

        public IEnumerable<Estado> ProximosEstadosValidos { get; set; }
    }
}
