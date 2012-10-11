using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Business;
using Bugzzinga.Model.Entities;

namespace Bugzzinga.EjemplosDominio.Ejemplos
{
    public static class EjemploUsuariosyPerfiles
    {
        #region Usuarios

        public static void RegistrarNuevoUsuario(ILogger log)
        {

            Usuario usuario1 = new Usuario();

            usuario1.LoginName = "Nafta";
            usuario1.Nombre = "Que es";
            usuario1.Apellido = "Nafta";

            Dominio.Instancia().GestorUsuarios().Registrar(usuario1);
        }

        public static void ModificarUsuario(ILogger log)
        {
            //Para modificar un objeto, tengo que tenerlo desde le repositorio.. en un mundo de objetos siempre conozco al objeto


        }
        public static void ListarTodosLosUsuarios(ILogger log)
        {
            IList<Usuario> usuarios =
                Dominio.Instancia().GestorUsuarios().ListarTodos();


            foreach (var usuario in usuarios)
            {
                log.AgregarALog(string.Format("Usuario {0}", usuario.LoginName));
            }
        }

        #endregion

       
    }
}
