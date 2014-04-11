using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Perfil
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
