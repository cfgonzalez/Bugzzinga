using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Castle.MicroKernel.Registration;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Buggzzinga.IntegrationTest.Infraestructura.Ioc
{
    public class DesktopInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<IDB4oServer>()
                       .ImplementedBy<DB4oServer>());

            container.Register(Component.For<IContextoProceso>()
                      .ImplementedBy<ContextoProceso>());
        }
    }
}