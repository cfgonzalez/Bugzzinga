using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap.Configuration.DSL;

namespace Bugzzinga.IoC.Registrys
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
