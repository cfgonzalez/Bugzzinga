using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Infraestructura.Ioc;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Bugzzinga.Dominio.ModeloPersistente.Configuracion;

namespace Bugzzinga.Inicializacion
{
    public class GestorAplicacion
    {
        private static IFactory objectFactory;

        public static void IniciarAplicacion()
        {
            objectFactory = ContainerSetup.BootstrapContainer();   

            string pathBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"..\BD");

            ConfiguracionServer configuracionServidor = new ConfiguracionServer();
            configuracionServidor.RutaArchivos = pathBD;//Properties.Settings.Default.DirectorioBD;
            configuracionServidor.NombreArchivoBD = Properties.Settings.Default.NombreBD;
            configuracionServidor.Puerto = 0;
            configuracionServidor.PersistenciaTransparente = false;
            configuracionServidor.ActivacionTransparente = false;

            IDB4oServer servidorBD = objectFactory.Create<IDB4oServer>();
            servidorBD.Iniciar(configuracionServidor, new ConfiguracionEntidades());
        }

        public static void FinalizarAplicacion()
        {
            IDB4oServer servidorBD = objectFactory.Create<IDB4oServer>();
            servidorBD.Finalizar();
        }
    }

    public static class ContainerSetup
    {
        private static IWindsorContainer container;

        /// <summary>
        /// Inicializa el container
        /// </summary>
        public static IFactory BootstrapContainer()
        {
            container = new WindsorContainer()

                .AddFacility<TypedFactoryFacility>()
                .Register()

                //Registra todos los installers
                .Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //Intercepta la construcción de los IHttpControllers para WebApi
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), controllerFactory);

            return container.Resolve<IFactory>();
        }

        public static void TeardownContainer()
        {
            if (container != null)
            {
                container.Dispose();
            }
        }
    }
}