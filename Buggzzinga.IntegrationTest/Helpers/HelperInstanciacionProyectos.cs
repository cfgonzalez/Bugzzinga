using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Dominio;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public static class HelperInstanciacionProyectos
    {

        public static List<Proyecto> GetProyectos( int cantidad )
        {
            List<Proyecto> resultado = new List<Proyecto>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                Proyecto p = new Proyecto();
                p.Codigo = String.Concat ("P", i);
                p.Descripcion = String.Concat("Proyecto de prueba ",i);
                p.Nombre = String.Concat("Proyecto ",i);

                resultado.Add( p );
            }

            return resultado;
        }
    }
}
