using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Intefaces;
using Bugzzinga.Dominio.Validadores;
using StructureMap.Configuration.DSL;

namespace Bugzzinga.Dominio.IoC
{
    public class RegistryBugzzingaDominio: Registry
    {
        public RegistryBugzzingaDominio()
        {           
            For<IValidadorEntidad<Perfil>>().Use<ValidadorPerfil>();
        }
    }
}
