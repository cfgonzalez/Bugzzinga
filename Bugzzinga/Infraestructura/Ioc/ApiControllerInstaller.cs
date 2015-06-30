using System.Web.Http;
using Castle.MicroKernel.Registration;

namespace Bugzzinga.Infraestructura.Ioc
{
    public class ApiControllerInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
             container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .Configure(x => x.LifestyleTransient()));
        }
    }
}



