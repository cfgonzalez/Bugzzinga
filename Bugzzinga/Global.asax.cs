using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bugzzinga.App_Start;
using Bugzzinga.Inicializacion;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Bugzzinga
{
    using AutoMapper;
    using Bugzzinga.Dominio;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            jsonFormatter.UseDataContractJsonSerializer = false;
            settings.Converters.Add(new IsoDateTimeConverter());
            settings.Formatting = Formatting.Indented;

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.Add(jsonFormatter);
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
this.ConfigurarMapeos();ContainerSetup.BootstrapContainer();            GestorAplicacion.IniciarAplicacion();
        }

        protected void Application_End()
        {
            GestorAplicacion.FinalizarAplicacion();
            ContainerSetup.TeardownContainer();
        }

        private void ConfigurarMapeos()
        {
            Mapper.CreateMap<Proyecto, Proyecto>();
        }
    }

    public static class ContainerSetup
    {
        private static IWindsorContainer container;

        /// <summary>
        /// Inicializa el container
        /// </summary>
        public static void BootstrapContainer()
        {
            container = new WindsorContainer()

                .AddFacility<TypedFactoryFacility>()
                .Register()

                //Registra todos los installers
                .Install(FromAssembly.This());
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