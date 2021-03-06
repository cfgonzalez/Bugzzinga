﻿using System;
using System.IO;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using AutoMapper;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.ModeloPersistente.Configuracion;
using Bugzzinga.Infraestructura.Ioc;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using IFactory = Bugzzinga.Contexto.IoC.IFactory;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public static class HelperTestSistema
    {
        public static IFactory ObjectFactory;

        private static  string _directorioBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"\..\..\..\BD\BDTest" );
        private static string _nombreBD = "BugzzingaTest.yap";

        public static void IniciarServidor()
        {
            ObjectFactory = ContainerSetup.BootstrapContainer();

            ConfiguracionServer configuracionServidor = new ConfiguracionServer();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            configuracionServidor.RutaArchivos = _directorioBD;
            configuracionServidor.NombreArchivoBD = _nombreBD;
            configuracionServidor.Puerto = 0;
            configuracionServidor.PersistenciaTransparente = true;
            configuracionServidor.ActivacionTransparente = false;

            IDB4oServer servidorBD = ObjectFactory.Create<IDB4oServer>();
                        
            servidorBD.Iniciar( configuracionServidor, new ConfiguracionEntidades() );

            ConfiguracionMapeos.ConfigurarMapeos();
        }

       

        public static void FinalizarServidor()
        {
            IDB4oServer servidorBD = ObjectFactory.Create<IDB4oServer>();
            servidorBD.Finalizar();
        }

        public static void ReiniciarConexion()
        {
            ObjectFactory.Create<IContextoProceso>().ResetearContenedorObjetos();
        }

        public static void LimpiarArchivoBD()
        {
            System.IO.File.Delete( Path.Combine( _directorioBD, _nombreBD ) );
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
