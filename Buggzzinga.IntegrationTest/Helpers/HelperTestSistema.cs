using System;
using System.IO;
using Bugzzinga.Contexto.IoC;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;

namespace Buggzzinga.IntegrationTest.Helpers
{
    public class HelperTestSistema
    {
        private static string _directorioBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"\..\..\..\BD\BDTest" );
        private static string _nombreBD = "BugzzingaTest.yap";

        public static void IniciarServidor()
        {
            ObjectFactory.Initialize( x => x.AddRegistry( new RegistryDesktop() ) );

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


        public static void LimpiarArchivoBD()
        {
            File.Delete( Path.Combine( _directorioBD, _nombreBD ) );
        }
    }
}
