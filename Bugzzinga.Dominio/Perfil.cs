using Bugzzinga.Core.Atributos;
using Bugzzinga.Core.Intefaces;
using StructureMap;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Perfil//:IEntidadValidable
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
             

        //public IResultadoValidacion Validar()
        //{
        //    return true;
        //    //IValidadorEntidad<Perfil> validador = ObjectFactory.GetInstance<IValidadorEntidad<Perfil>>();
        //    //return validador.Validar( this );
        //}        
    }
}
