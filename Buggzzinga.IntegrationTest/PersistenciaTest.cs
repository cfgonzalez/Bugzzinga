using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using System;
using System.Linq;

namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class PersistenciaTest
    {

        private void LimpiarArchivoBD()
        { 
        
        }

        private IDB4oServer ObtenerServidorTest()
        {
            ConfiguracionServer configuracion = new ConfiguracionServer();            

            string path = AppDomain.CurrentDomain.BaseDirectory;
            configuracion.RutaArchivos = String.Concat(path, @"\..\..\..\BD\BDTest");
            configuracion.NombreArchivoBD = "BugzzingaTest.yap";
            configuracion.Puerto = 0;
            configuracion.PersistenciaTransparente = true;
            configuracion.ActivacionTransparente = true;

            IDB4oServer servidor = new DB4oServer();
            servidor.Iniciar(configuracion);

            return servidor;
        }


        [TestMethod]
        public void TestMethod1()
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
        public void Test2()
        {
            var servidor = this.ObtenerServidorTest();
            IObjectContainer contenedor = servidor.CrearConexion();

            var proyecto = (from Proyecto p in contenedor select p).SingleOrDefault();

            proyecto.Nombre = "Proyecto modificado";

            servidor.FinalizarConexion(contenedor);
            servidor.Finalizar();
        }
    }
}
