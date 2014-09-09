using System.Collections.Generic;
using Bugzzinga.Core.Atributos;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Item
    {

        private IList<RegistroLog> _registrosLog = new ArrayList4<RegistroLog>();

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
            this.Tipo = tipo;
            this.Prioridad = prioridad;            
        }


        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Prioridad Prioridad { get; internal set; }
        public IEnumerable<RegistroLog> RegistrosLog { get { return this._registrosLog; } }
        public TipoItem Tipo { get; internal set; }
        public Usuario Responsable { get; internal set; }
    }
}
