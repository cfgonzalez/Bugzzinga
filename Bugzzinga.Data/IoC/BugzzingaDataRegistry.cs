using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StructureMap.Configuration.DSL;
using Services.Exceptions;
using Data.DB4o.Repository;

namespace Bugzzinga.Data.IoC
{
    public class BugzzingaDataRegistry:Registry 
    {

        public BugzzingaDataRegistry()
        {

            ConfigurarServicios();
        }


        private void ConfigurarServicios()
        {
            For<IRepositorio>().Singleton().Use<Repositorio>();
            For<IServicioExcepcionesPersistencia>().Singleton().Use<GestorExcepcionesNulo>();
        }
    }
}
