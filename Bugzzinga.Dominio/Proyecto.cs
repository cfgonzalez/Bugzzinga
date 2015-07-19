using System;
using System.Collections.Generic;
using Bugzzinga.Core.Atributos;
using Db4objects.Db4o.Collections;
using System.Linq;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Proyecto:DomainObject 
    {
        private IList<Usuario> _miembros = new ArrayList4<Usuario>();
        private IList<TipoItem> _tiposDeItem = new List<TipoItem>();
        private IList<Item> _items =  new ArrayList4<Item>();
        private ArrayList4<Prioridad> _prioridades = new ArrayList4<Prioridad>();

        public IEnumerable<Usuario> Miembros { get { return this._miembros; } }
        public IEnumerable<TipoItem> TiposDeItem { get {return this._tiposDeItem; } }
        public IEnumerable<Item> Items { get { return this._items; } }
        public ArrayList4<Prioridad> Prioridades
        {
            get { return this._prioridades; }
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }

        #region "Tipos de item"

        public void AgregarTipoDeItem( TipoItem tipoDeItem )
        {
            this._tiposDeItem.Add( tipoDeItem );
        }

        public void QuitarTipoDeItem( TipoItem tipoDeItem )
        {
            this._tiposDeItem.Remove( tipoDeItem );
        }

        public TipoItem GetTipoItem( string nombreTipoItem )
        {
            return this._tiposDeItem.Where( x => x.Nombre.Equals( nombreTipoItem, StringComparison.InvariantCultureIgnoreCase ) ).SingleOrDefault();
        }

        #endregion

        public void AgregarItem(Item item)
        {
            this._items.Add(item);
        }

        public void AgregarMiembro(Usuario usuario)
        {
            this._miembros.Add(usuario);
        }
    }
}
