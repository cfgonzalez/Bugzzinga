using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Contexto.Interfaces;

namespace Bugzzinga.Contexto
{
    public class ContextoProcesoWeb:IContextoProceso
    {

        #region IContextoProceso Members

        public ServicioDatos.DB4o.Server.Interfaces.IDB4oServer ServidorBD
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
