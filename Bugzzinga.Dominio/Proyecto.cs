﻿using Bugzzinga.Core.Atributos;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Proyecto:IProyecto
    {
        //private IList<IUsuario> _miembros;
        //private IList<ITipoItem> _tiposDeItem;
        protected IList<Item> _items = new ArrayList4<Item>();

        public Proyecto()
        {
        //    this._miembros = new List<IUsuario>();
        //    this._tiposDeItem = new List<ITipoItem>();                       
        }


        //public IEnumerable<IUsuario> Miembros { get { return this._miembros; } }
        //public IEnumerable<ITipoItem> TiposDeItem { get {return this._tiposDeItem; } }
        public IEnumerable<IItem> Items { get { return this._items; } }


        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
