using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Contexto.Interfaces;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap.Configuration.DSL;

namespace Bugzzinga.Contexto.IoC
{
    public class RegistryDesktop:Registry
    {
        public RegistryDesktop()
        {
            For<IDB4oServer>().Singleton().Use<DB4oServer>();
            For<IContextoProceso>().Singleton().Use<ContextoProceso>();            
        }
    }
}
