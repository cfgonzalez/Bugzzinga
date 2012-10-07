using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StructureMap.Configuration.DSL;
using Bugzzinga.Data;

using Services.Exceptions;
using Services.Security;

namespace Bugzzinga.Model.Business.IoC
{
    public class BugzzingaModelBusinessRegistry:Registry
    {

        public BugzzingaModelBusinessRegistry()
        {
        }


        private void ConfigurarServicios()
        {
            For<IServicioExcepcionesDominio>().Singleton().Use<GestorExcepcionesNulo>();
            For<IServicioAutorizacion>().Singleton().Use<ServicioAutorizacionNulo>();
        }

        private void ConfigurarDataMappers()
        {

            For<IDMTipoTarea>().Singleton().Use<DMTipoDeTarea>();
        }

    }
}
