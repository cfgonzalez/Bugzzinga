using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio
{
    public class Prioridad:IPrioridad
    {

        public Prioridad(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string Nombre {  get; private set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; } // ver como resolver el tema del orden
    }
}
