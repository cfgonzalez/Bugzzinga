using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Dominio;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public static class HelperInstanciacionItems
    {
        public static List<TipoItem> GetTiposDeItem(string nombreProyecto, int cantidad )
        {
            List<TipoItem> resultado = new List<TipoItem>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                TipoItem p = new TipoItem();
                p.Nombre = String.Concat( "Tipo de item ", i );
                p.Descripcion = String.Concat(nombreProyecto, "-" , "Tipo de item de prueba ", i );                

                resultado.Add( p );
            }

            return resultado;
        }        
    }
}
