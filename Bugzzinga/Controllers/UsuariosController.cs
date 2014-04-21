using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bugzzinga.Dominio;

namespace Bugzzinga.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TraerTodos()
        {
            var listaUsuarios = TraerListaUsuariosDummy();

            return Json(listaUsuarios);
        }

        public ActionResult Grabar(Usuario usuario)
        {
            //Acá se graba el usuario

            return Json(usuario);
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
