using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Dominio.ModeloPersistente.Administradores;
using Bugzzinga.Dominio.ModeloPersistente.Interfaces;
using StructureMap.Configuration.DSL;

namespace Bugzzinga.Dominio.ModeloPersistente.IoC
{
    public class RegistryBugzzingaDominioModeloPersistente:Registry
    {
        public RegistryBugzzingaDominioModeloPersistente()
        {
            For<IAdministradorEntidad<Perfil>>().Use<AdministradorPerfiles>();
        }
    }
}
