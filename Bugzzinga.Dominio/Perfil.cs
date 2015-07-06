using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Perfil:DomainObject  //:IEntidadValidable
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
