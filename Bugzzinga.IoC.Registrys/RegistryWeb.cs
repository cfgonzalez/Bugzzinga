
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Contexto;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;


namespace Bugzzinga.IoC.Registrys
{
    public class RegistryWeb:Registry
    {
        public RegistryWeb()
        {

            For<IBugtracker>()
                .Use<BugTrackerPersistente>();

            For<IDB4oServer>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton))
                .Use<DB4oServer>();
            
            For<IContextoProceso>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.HttpSession))
                .Use<ContextoProceso>();            
        }
    }
}
