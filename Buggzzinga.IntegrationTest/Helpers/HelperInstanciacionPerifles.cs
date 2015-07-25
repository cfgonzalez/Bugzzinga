using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Dominio;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public class HelperInstanciacionPerifles
    {

        public static List<Rol> GetPerfiles( int cantidad )
        {
            List<Rol> resultado = new List<Rol>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                Rol p = new Rol();                
                p.Descripcion = String.Concat( "Perfil de prueba ", i );
                p.Nombre = String.Concat( "Perfil ", i );

                resultado.Add( p );
            }

            return resultado;
        }
    }
}
