using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StructureMap;
using Bugzzinga.Model.Business.IoC;
using Bugzzinga.Data.IoC;


namespace Bugzzinga.EjemplosDominio.IoC
{
    public class ConfiguracionIoC
    {

        public static void ConfigurarAplicacion()
        {
            ObjectFactory.Initialize
                (
                x =>
                {
                    x.AddRegistry(new GUIRegistry());
                    x.AddRegistry(new BugzzingaModelBusinessRegistry());
                    x.AddRegistry(new BugzzingaDataRegistry());
                }
                );
        }
    }
}
