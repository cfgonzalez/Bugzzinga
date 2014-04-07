using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Item:IItem
    {

        private IEnumerable<IRegistroLog> _registrosLog;
        
        public Item(string nombre, string descripcion,ITipoItem tipo,IPrioridad prioridad)
        {
            //throw new NotImplementedException("Hay que obtener el codigo con alguna inteligencia");
            
            this.Nombre = nombre;
            this.Descripcion = descripcion;

            this.Tipo = tipo;
            this.Prioridad = prioridad;
            this._registrosLog = new List<IRegistroLog>();
        }


        public int Codigo { get; internal set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public IPrioridad Prioridad { get; internal set; }
        public IEnumerable<IRegistroLog> RegistrosLog { get { return this._registrosLog; } }
        public ITipoItem Tipo { get; internal set; }
        public IUsuario Responsable { get; internal set; }
    }
}
