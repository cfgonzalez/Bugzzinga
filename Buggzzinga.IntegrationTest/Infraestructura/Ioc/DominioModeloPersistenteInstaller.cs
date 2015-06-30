using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;
using Bugzzinga.Dominio.ModeloPersistente.Administradores;
using Bugzzinga.Dominio.ModeloPersistente.Interfaces;
using Castle.MicroKernel.Registration;

namespace Buggzzinga.IntegrationTest.Infraestructura.Ioc
{
    public class DominioModeloPersistenteInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<IAdministradorEntidad<Perfil>>()
                    .ImplementedBy<AdministradorPerfiles>()); 

            container.Register(Component.For<IBugtracker>()
                    .ImplementedBy<BugTrackerPersistente>());
        }
    }
}
