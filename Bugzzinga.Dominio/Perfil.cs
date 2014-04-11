using Bugzzinga.Core.Atributos;
using Bugzzinga.Core.Intefaces;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Perfil:IEntidadValidable
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        
        public IResultadoValidacion Validar()
        {
            throw new System.NotImplementedException();
        }        
    }
}
