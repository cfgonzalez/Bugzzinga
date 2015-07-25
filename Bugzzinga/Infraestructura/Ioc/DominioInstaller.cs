using Bugzzinga.Contexto;
using Bugzzinga.Core.Intefaces;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Validadores;
using Castle.MicroKernel.Registration;

namespace Bugzzinga.Infraestructura.Ioc
{
    public class DominioInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<IValidadorEntidad<Rol>>()
                     .ImplementedBy<ValidadorPerfil>());          
        }
    }
}