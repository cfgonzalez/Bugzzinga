using System;
using System.IO;
using Bugzzinga.IoC.Registrys;
using Bugzzinga.Dominio.IoC;
using Bugzzinga.Dominio.ModeloPersistente.IoC;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using Sharpen.IO;
using StructureMap;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public static class HelperTestSistema
    {
        private static  string _directorioBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"\..\..\..\BD\BDTest" );
        private static string _nombreBD = "BugzzingaTest.yap";
        public static void IniciarServidor()
        {
            ConfigurarIoC();

            ConfiguracionServer configuracionServidor = new ConfiguracionServer();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            configuracionServidor.RutaArchivos = _directorioBD;
            configuracionServidor.NombreArchivoBD = _nombreBD;
            configuracionServidor.Puerto = 0;
            configuracionServidor.PersistenciaTransparente = true;
            configuracionServidor.ActivacionTransparente = true;

            IDB4oServer servidorBD = ObjectFactory.GetInstance<IDB4oServer>();
            servidorBD.Iniciar( configuracionServidor );
        }

        public static void FinalizarServidor()
        {
            IDB4oServer servidorBD = ObjectFactory.GetInstance<IDB4oServer>();
            servidorBD.Finalizar();
        }
        private static void ConfigurarIoC()
        {
            ObjectFactory.Initialize( x => x.AddRegistry( new RegistryDesktop() ) );
            ObjectFactory.Configure( x => x.AddRegistry( new RegistryBugzzingaDominio() ) );
            ObjectFactory.Configure( x => x.AddRegistry( new RegistryBugzzingaDominioModeloPersistente() ) );            
        }

        public static void LimpiarArchivoBD()
        {
            System.IO.File.Delete( Path.Combine( _directorioBD, _nombreBD ) );
        }      
    }
}
