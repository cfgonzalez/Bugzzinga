using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using System;
using System.Linq;
using System.IO;
using Bugzzinga.Dominio.ModeloPersistente;


namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class PersistenciaTest
    {

        private string _directorioBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"\..\..\..\BD\BDTest" );
        private string _nombreBD = "BugzzingaTest.yap";

        private void LimpiarArchivoBD()
        {   
            File.Delete( Path.Combine(_directorioBD,_nombreBD ));
        }

        private IDB4oServer ObtenerServidorTest()
        {
            ConfiguracionServer configuracion = new ConfiguracionServer();            

            string path = AppDomain.CurrentDomain.BaseDirectory;
            configuracion.RutaArchivos = _directorioBD;
            configuracion.NombreArchivoBD = _nombreBD;
            configuracion.Puerto = 0;
            configuracion.PersistenciaTransparente = true;
            configuracion.ActivacionTransparente = true;

            IDB4oServer servidor = new DB4oServer();
            servidor.Iniciar(configuracion);

            return servidor;
        }


        [TestMethod]
        public void Test_AltaProyecto()
        {
            this.LimpiarArchivoBD();

            var servidor = this.ObtenerServidorTest();       
            IObjectContainer contenedor = servidor.CrearConexion();

            IBugtracker bugzzinga = new Bugtracker();
            
            IProyecto proyecto1 = bugzzinga.NuevoProyecto();
            proyecto1.Codigo = "P1";
            proyecto1.Nombre = "Proyecto 1 de prueba";

            contenedor.Store(proyecto1);           
            servidor.FinalizarConexion(contenedor);
            servidor.Finalizar();
        }

        [TestMethod]
        public void Test_ModificacionProyecto()
        {
            var servidor = this.ObtenerServidorTest();
            IObjectContainer contenedor = servidor.CrearConexion();

            var proyecto = (from Proyecto p in contenedor select p).SingleOrDefault();

            proyecto.Nombre = "Proyecto modificado";

            servidor.FinalizarConexion(contenedor);
            servidor.Finalizar();
        }

        [TestMethod]
        public void Test_BugTrackerScope()
        {
            //this.LimpiarArchivoBD();

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                IProyecto p = bugzzinga.NuevoProyecto();
                p.Codigo = "P1";
                p.Nombre = "Proyecto de prueba 1";

                bugzzinga.RegistrarProyecto( p );
            }

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                IProyecto p =  bugzzinga.ObtenerProyecto( "Proyecto de prueba 1" );
                p.Nombre = "Proyecto de prueba modificado";
            }
        
        }
    }
}
