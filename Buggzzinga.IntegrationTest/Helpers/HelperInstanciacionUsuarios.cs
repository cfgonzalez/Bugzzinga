using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Dominio;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public static class HelperInstanciacionUsuarios
    {

        public static List<Usuario> GetUsuarios( int cantidad )
        {
            List<Usuario> resultado = new List<Usuario>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                Usuario u = new Usuario();
                u.Apellido = String.Concat( "Apellido usuario ", i );
                u.Nombre = String.Concat( "Usuario ", i );

                resultado.Add( u );
            }

            return resultado;
        }
    }
}
