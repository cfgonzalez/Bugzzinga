using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Contexto.Interfaces;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Bugzzinga.Contexto
{
    public class ContextoProcesoDesktop:IContextoProceso
    {
        private IDB4oServer _servidor;

        public ContextoProcesoDesktop()
        {
            this._servidor = new DB4oServer();
        }        

        public IDB4oServer ServidorBD
        {
            get { return this._servidor; }
        }

        
    }
}
