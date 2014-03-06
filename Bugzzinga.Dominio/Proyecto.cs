using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Dominio
{
    public class Proyecto:IProyecto
    {
        private IList<IUsuario> _miembros;
        private IList<ITipoItem> _tiposDeItem;
        private IList<IItem> _items;

        public Proyecto()
        {
            this._miembros = new List<IUsuario>();
            this._tiposDeItem = new List<ITipoItem>();
            this._items = new List<IItem>();           
        }


        public IEnumerable<IUsuario> Miembros { get { return this._miembros; } }
        public IEnumerable<ITipoItem> TiposDeItem { get {return this._tiposDeItem; } }
        public IEnumerable<IItem> Items { get{ return this.Items;}}


        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
