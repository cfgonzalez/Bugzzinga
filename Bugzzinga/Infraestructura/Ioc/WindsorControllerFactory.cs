using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Bugzzinga.Infraestructura.Ioc
{
    public class WindsorControllerFactory : DefaultControllerFactory, IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Interceptor para los controles MVC que permite que sus constructores soporten inyección de dependencia
        /// </summary>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return base.GetControllerInstance(requestContext, null); // Llamar a la resolucion standard del controller para generar la excepcion estandard de MVC

            return (IController)container.Resolve(controllerType);
        }

        /// <summary>
        /// Interceptor para los controllers WebApi que permite que sus constructores soporten inyección de dependencia
        /// </summary>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(new Release(() => this.container.Release(controller)));

            return controller;
        }

        /// <summary>
        /// Es necesario hacer Release de los controllers para evitar la saturación de la memoria
        /// </summary>
        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                this.release();
            }
        }
    }
}