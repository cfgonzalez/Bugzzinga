using System.Collections.Generic;
using Bugzzinga.Core.Atributos;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Item
    {

        private IList<LogItem> _historial = new ArrayList4<LogItem>();
        
        /// <summary>
        /// Constructor de prueba, solamente para los tests iniciales de db4o
        /// </summary>
        public Item()
        { 
        
        }

        public Item(string nombre, string descripcion, TipoItem tipo, Prioridad prioridad)
        {                     
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TipoItem = tipo;
            this.Prioridad = prioridad;            
        }


        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }

        public Prioridad Prioridad { get; internal set; }
        public IEnumerable<LogItem> Historial { get { return this._historial; } }
        public TipoItem TipoItem { get; internal set; }
        public MiembroProyecto Responsable { get; set; }
    }
}
