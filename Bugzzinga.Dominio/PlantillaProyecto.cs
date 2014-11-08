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
    public class PlantillaProyecto
    {
        private ArrayList4<TipoItem> _tiposDeItem = new ArrayList4<TipoItem>();
        private ArrayList4<Prioridad> _prioridades = new ArrayList4<Prioridad>();

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ArrayList4<TipoItem> TiposDeItem {
            get { return this._tiposDeItem; } 
        }

        public ArrayList4<Prioridad> Prioridades
        {
            get { return this._prioridades; }
        }
    }
}
