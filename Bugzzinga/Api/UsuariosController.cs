using System.Collections.Generic;
using System.Web.Http;
using Bugzzinga.Atributos;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Core;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using System.Linq;

namespace Bugzzinga.Api
{


    [AtributoGestorExcepciones]
    public class UsuariosController : ApiController
    {
        private readonly IFactory objectFactory;

        public UsuariosController( IFactory objectFactory )
        {
            this.objectFactory = objectFactory;

        }

        public IEnumerable<Usuario> Get()
        {
            var listaUsuarios = new List<Usuario>();
            
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                listaUsuarios = bugzzinga.Usuarios.ToList();
            }

            return listaUsuarios;
        }

        //Trae los usuarios para un proyecto 
        public IEnumerable<Usuario> Get(int codigoProyecto)
        {
            return null;
        }

        public Usuario Put(Usuario usuarioDto)
        {
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                bugzzinga.ModificarUsuario( usuarioDto );
            }

            return usuarioDto;
        }

        public Usuario Post(Usuario usuarioDto)
        {
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                bugzzinga.RegistrarUsuario( usuarioDto );
            }

            return usuarioDto;
        }

        public bool Delete(int codigo)
        {
            return true;
        }

        //private List<Usuario> TraerListaUsuariosDummy()
        //{
        //    var listaUsuarios = new List<Usuario>();

        //    for (var i = 0; i < 3; i++)
        //    {
        //        var usuario = new Usuario();

        //        var perfil = new Perfil() { Nombre = "p" + (i + 1).ToString(), Descripcion = "Perfil" + (i + 1).ToString() };
                
        //        usuario.Apellido = "Apellido" + (i + 1).ToString();
        //        usuario.Nombre = "Nombre" + (i + 1).ToString();
        //        usuario.Codigo = i + 1;
        //        usuario.Perfil = perfil;

        //        listaUsuarios.Add(usuario);
        //    }

        //    return listaUsuarios;
        //}
    }
}
