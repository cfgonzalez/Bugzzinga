using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.DTO
{
    public class ProyectoDTO
    {
        //private IList<Usuario> _miembros = new ArrayList4<Usuario>();
        //private IList<TipoItem> _tiposDeItem = new ArrayList4<TipoItem>();
        //private IList<Item> _items =  new ArrayList4<Item>();
        //private ArrayList4<Prioridad> _prioridades = new ArrayList4<Prioridad>();

        //public IEnumerable<Usuario> Miembros { get { return this._miembros; } }
        //public IEnumerable<TipoItem> TiposDeItem { get {return this._tiposDeItem; } }
        //public IEnumerable<Item> Items { get { return this._items; } }
        /*
         * public ArrayList4<Prioridad> Prioridades
        {
            get { return this._prioridades; }
        }
       */
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
