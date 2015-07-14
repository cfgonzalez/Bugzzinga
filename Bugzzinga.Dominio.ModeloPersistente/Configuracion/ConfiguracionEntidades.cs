using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace Bugzzinga.Dominio.ModeloPersistente.Configuracion
{
    public class ConfiguracionEntidades
    {
        public static void ConfigurarPersistencia()
        {
            Db4oFactory.Configure().ObjectClass( typeof( Proyecto ) ).CascadeOnUpdate( true );
        }        
    }
}
