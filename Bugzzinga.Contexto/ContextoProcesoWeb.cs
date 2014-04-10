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

        public Db4objects.Db4o.IObjectContainer ContenedorObjetos
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
