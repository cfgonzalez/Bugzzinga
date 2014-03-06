using Bugzzinga.Core.Configuracion;
using Bugzzinga.Dominio.Test.IoC;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Test.TestHelpers
{
    public class ConfiguracionTest
    {

        public static void ConfigurarEntornoDeTest()
        {
            string pathBD = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString();
            pathBD = Directory.GetParent(pathBD).ToString();
            pathBD = Directory.GetParent(pathBD).ToString();

            ConfiguracionBD.PathBD = pathBD + @"\BD\BDTest\BugzzingaTest.yap";
            ConfigurarDependencias();
        }
        
        public static void ConfigurarDependencias()
        {
            ObjectFactory.Configure
                (x => 
                    x.AddRegistry(new TestRegistry())
                );
        }
    }
}
