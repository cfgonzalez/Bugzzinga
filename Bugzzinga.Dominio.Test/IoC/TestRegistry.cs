using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;
using Bugzzinga.Persistencia;
using Bugzzinga.Persistencia.Interfaces;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Test.IoC
{
    public class TestRegistry:Registry
    {
        public TestRegistry()
        {
            this.ConfigurarDomino();
            this.ConfigurarPersistencia();
            
        }

        private void ConfigurarDomino()
        {
            For<IBugtracker>().Use<BugtrackerPersistente>();
        }

        private void ConfigurarPersistencia()
        {
              For<IRepositorio>().Singleton().Use<Repositorio>();
        }
    }
}
