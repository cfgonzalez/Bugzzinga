using Bugzzinga.Persistencia.Interfaces;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Persistencia.IoC
{
    public class RepositorioIoCRegistry:Registry
    {
        public RepositorioIoCRegistry()
        {
            For<IRepositorio>().Use<Repositorio>();
        }
    }
}
