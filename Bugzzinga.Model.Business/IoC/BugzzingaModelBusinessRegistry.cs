using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StructureMap.Configuration.DSL;
using Bugzzinga.Data;

using Services.Exceptions;
using Services.Security;

using Data.DB4o.Common;

namespace Bugzzinga.Model.Business.IoC
{
    public class BugzzingaModelBusinessRegistry:Registry
    {

        public BugzzingaModelBusinessRegistry()
        {

            ConfigurarPersistencia();
            ConfigurarGestores();
            ConfigurarServicios();
            ConfigurarDataMappers();
        }

        private void ConfigurarPersistencia()
        {
            For<IConfiguracionEntidadesPersistentes>().Use<ConfiguracionEntidadesPersistentesBuggzinga>();
        
        }


        private void ConfigurarGestores()
        {

            For<IGestorPerfiles>().Singleton().Use<GestorPerfiles>();
            
            
            For<IGestorPrioridadesTarea>().Singleton().Use<GestorPrioridadesTarea>();
            For<IGestorTiposDetarea>().Singleton().Use<GestorTiposDeTarea>();

        }

        private void ConfigurarServicios()
        {
            For<IServicioExcepcionesDominio>().Singleton().Use<GestorExcepcionesNulo>();
            For<IServicioAutorizacion>().Singleton().Use<ServicioAutorizacionNulo>();
        }

        private void ConfigurarDataMappers()
        {

            For<IDMPerfil>().Singleton().Use<DMPerfil>();
            For<IDMUsuario>().Singleton().Use<DMUsuario>();
            
            For<IDMTipoTarea>().Singleton().Use<DMTipoDeTarea>();
            
        }

    }
}
