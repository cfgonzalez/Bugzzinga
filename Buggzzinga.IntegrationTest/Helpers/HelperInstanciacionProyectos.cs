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

        public static List<Item> GetItemsParaProyecto( Proyecto proyecto, int cantidad )
        {

            List<Item> resultado = new List<Item>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                Item item = new Item();
                item.Codigo =  i ;
                item.Nombre = String.Concat("I",i,proyecto.Codigo);
                item.Descripcion = String.Concat( "item ", i, " del ", proyecto.Codigo );

                resultado.Add( item );
            }

            return resultado;
        }


        public static List<TipoItem> GetTiposItemParaProyecto( Proyecto proyecto, int cantidad )
        {
            List<TipoItem> resultado = new List<TipoItem>();

            for ( int i = 1; i <= cantidad; i++ )
            {
                TipoItem tipoItem = new TipoItem
                (                
                String.Concat( "I", i, proyecto.Codigo ),
                String.Concat( "item ", i, " del ", proyecto.Codigo) 
                );

                resultado.Add( tipoItem );
            }

            return resultado;


        }
    }
}
