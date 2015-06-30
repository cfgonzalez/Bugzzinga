using Bugzzinga.Contexto.IoC;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;

namespace Buggzzinga.IntegrationTest.Infraestructura.Ioc
{
    public class ContainerInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            //Registers
            //Factory
            container.Register(Component.For<IFactory>().AsFactory());
        }
    }
}
