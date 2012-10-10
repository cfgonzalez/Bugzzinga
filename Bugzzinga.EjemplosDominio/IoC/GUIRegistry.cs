using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StructureMap.Configuration.DSL;

using Services.Security;

namespace Bugzzinga.EjemplosDominio.IoC
{
    public class GUIRegistry:Registry
    {
        public GUIRegistry()
        {

            For<IContextoSeguridad>().Singleton().Use<ContextoSeguridadDesktop>();
            
        }

    }
}
