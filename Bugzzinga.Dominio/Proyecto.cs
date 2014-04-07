using Bugzzinga.Core.Atributos;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Proyecto
    {
        private IList<Usuario> _miembros = new ArrayList4<Usuario>();
        private IList<TipoItem> _tiposDeItem = new ArrayList4<TipoItem>();
        private IList<Item> _items =  new ArrayList4<Item>();

        public IEnumerable<Usuario> Miembros { get { return this._miembros; } }
        public IEnumerable<TipoItem> TiposDeItem { get {return this._tiposDeItem; } }
        public IEnumerable<Item> Items { get { return this._items; } }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }

        public void AgregarItem( Item item )
        {
            this._items.Add( item );
        }

    }
}
