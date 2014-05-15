using System.Collections.Generic;
using System.Web.Http;
using Bugzzinga.Atributos;
using Bugzzinga.Core;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    [AtributoGestorExcepciones]
    public class UsuariosController : ApiController
    {
        public IEnumerable<Usuario> Get()
        {
            var listaUsuarios = TraerListaUsuariosDummy();
            throw new BugzzingaException( "Tu vieja !" );
            return listaUsuarios;
        }

        public Usuario Put( Usuario usuario )
        {
            return usuario;
        }

        public Usuario Post(Usuario usuario)
        {
            return usuario;
        }

        private List<Usuario> TraerListaUsuariosDummy()
        {
            var listaUsuarios = new List<Usuario>();

            for (var i = 0; i < 2; i++)
            {
                var usuario = new Usuario();

                usuario.Apellido = "Apellido" + (i + 1).ToString();
                usuario.Nombre = "Nombre" + (i + 1).ToString();
                usuario.Codigo = i + 1;

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }
    }
}
