using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio
{
    public class TipoItem:ITipoItem
    {

        private IList<IEstado> _estadosDisponibles;
        
        public TipoItem(string nombre,string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;

            this._estadosDisponibles = new List<IEstado>();
        }

        public string Nombre { get; internal set; }
        public string Descripcion { get; set; }

        public IEnumerable<IEstado> EstadosDisponibles { get { return this._estadosDisponibles; } }
    }
}
