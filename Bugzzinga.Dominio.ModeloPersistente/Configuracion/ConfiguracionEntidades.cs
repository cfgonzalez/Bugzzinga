using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.CS.Config;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Bugzzinga.Dominio.ModeloPersistente.Configuracion
{
    public class ConfiguracionEntidades : IConfiguracionEntidades
    {
       
        #region IConfiguracionEntidades Members

        public IServerConfiguration ConfigurarPersistenciaEntidades( IServerConfiguration configuracion )
        {

            //configuracion.Common.ObjectClass( typeof( Proyecto )).CascadeOnUpdate( true );
            configuracion.Common.ObjectClass( typeof( Proyecto ) ).UpdateDepth( 10 );
            
            return configuracion;
        }

        #endregion
    }
}
