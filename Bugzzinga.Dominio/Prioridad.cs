using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Prioridad
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
