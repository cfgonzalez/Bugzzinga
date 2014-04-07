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
using System.Collections;
using System.Collections.Generic;


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
        public void Test_BugTrackerScope()
        {
            //this.LimpiarArchivoBD();

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                Proyecto p = bugzzinga.NuevoProyecto();
                p.Codigo = "P1";
                p.Nombre = "Proyecto de prueba 1";

                bugzzinga.RegistrarProyecto( p );
            }

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                Proyecto p = bugzzinga.ObtenerProyecto( "Proyecto de prueba 1" );
                p.Nombre = "Proyecto de prueba modificado";
            }

        }

        [TestMethod]
        public void Test_AltaProyectos()
        {
            this.LimpiarArchivoBD();
            
            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                Proyecto p1 = bugzzinga.NuevoProyecto();
                p1.Codigo = "P1";
                p1.Nombre = "Proyecto1";
                bugzzinga.RegistrarProyecto( p1 );

                Proyecto p2 = bugzzinga.NuevoProyecto();
                p2.Codigo = "P2";
                p2.Nombre = "Proyecto2";
                bugzzinga.RegistrarProyecto( p2 );

                Proyecto p3 = bugzzinga.NuevoProyecto();
                p3.Codigo = "P3";
                p3.Nombre = "Proyecto3";
                bugzzinga.RegistrarProyecto( p3 );               
            }

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                IEnumerable<Proyecto> proyectos = bugzzinga.Proyectos;
                IList<Proyecto> proyectosList = proyectos.ToList();
            }
        }

        [TestMethod]
        public void Test_PersistenciaPorAlcance()
        {
             this.LimpiarArchivoBD();

             using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
             {
                 Proyecto p1 = bugzzinga.NuevoProyecto();
                 p1.Codigo = "P1";
                 p1.Nombre = "Proyecto1";
                 bugzzinga.RegistrarProyecto( p1 );
             }

             using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
             {
                 Proyecto p = bugzzinga.ObtenerProyecto( "Proyecto1" );
                 p.Nombre = "Proyecto de prueba modificado";

                 Item item1 = new Item();                 
                 item1.Nombre = "Primer item del proyecto";

                 p.AgregarItem(item1);
             }

        }
    }
}
