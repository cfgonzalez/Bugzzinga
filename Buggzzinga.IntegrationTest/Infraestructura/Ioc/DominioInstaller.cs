using Bugzzinga.Core.Intefaces;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Validadores;
using Castle.MicroKernel.Registration;

namespace Buggzzinga.IntegrationTest.Infraestructura.Ioc
{
    public class DominioInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<IValidadorEntidad<Perfil>>()
                     .ImplementedBy<ValidadorPerfil>());          
        }
    }
}