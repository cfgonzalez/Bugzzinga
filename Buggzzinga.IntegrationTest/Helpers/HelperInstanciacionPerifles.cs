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

        public static List<Perfil> GetProyectos( int cantidad )
        {
            List<Perfil> resultado = new List<Perfil>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                Perfil p = new Perfil();                
                p.Descripcion = String.Concat( "Perfil de prueba ", i );
                p.Nombre = String.Concat( "Perfil ", i );

                resultado.Add( p );
            }

            return resultado;
        }
    }
}
