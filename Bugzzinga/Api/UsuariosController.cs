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
            //throw new BugzzingaException( "Error !" );
            return listaUsuarios;
        }

        //Trae los usuarios para un proyecto 
        public IEnumerable<Usuario> Get(int codigoProyecto)
        {
            //Devuelve una sublista dummy del total de usuarios
            var lista = TraerListaUsuariosDummy();

            lista.RemoveAt(1);

            return lista;
        }

        public Usuario Put(Usuario usuario)
        {
            return usuario;
        }

        public Usuario Post(Usuario usuario)
        {
            return usuario;
        }

        public bool Delete(int codigo)
        {
            return true;
        }

        private List<Usuario> TraerListaUsuariosDummy()
        {
            var listaUsuarios = new List<Usuario>();

            for (var i = 0; i < 3; i++)
            {
                var usuario = new Usuario();

                var perfil = new Perfil() { Nombre = "p" + (i + 1).ToString(), Descripcion = "Perfil" + (i + 1).ToString() };
                
                usuario.Apellido = "Apellido" + (i + 1).ToString();
                usuario.Nombre = "Nombre" + (i + 1).ToString();
                usuario.Codigo = i + 1;
                usuario.Perfil = perfil;

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }
    }
}
