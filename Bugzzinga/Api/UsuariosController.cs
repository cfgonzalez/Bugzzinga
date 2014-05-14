using System.Collections.Generic;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class UsuariosController : ApiController
    {
        public IEnumerable<Usuario> Get()
        {
            var listaUsuarios = TraerListaUsuariosDummy();

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

            for (var i = 0; i < 10; i++)
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
