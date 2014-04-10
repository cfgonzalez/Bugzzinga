using Bugzzinga.Contexto.Interfaces;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Contexto.IoC
{
    public class RegistryWeb:Registry
    {
        public RegistryWeb()
        {

            For<IDB4oServer>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton))
                .Use<DB4oServer>();
            
            For<IContextoProceso>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.HttpSession))
                .Use<ContextoProceso>();            
        }
    }
}
