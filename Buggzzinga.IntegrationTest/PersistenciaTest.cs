using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Core;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;


namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class PersistenciaTest
    {
        private string _directorioBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"\..\..\..\BD\BDTest" );
        private string _nombreBD = "BugzzingaTest.yap";

        private void IniciarServidor()
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

        private void FinalizarServidor()
        {
            IDB4oServer servidorBD = ObjectFactory.GetInstance<IDB4oServer>();
            servidorBD.Finalizar();
        }

        private void LimpiarArchivoBD()
        {   
            File.Delete( Path.Combine(_directorioBD,_nombreBD ));
        }      

        [TestMethod]
        public void Test_BugTrackerScope()
        {
            this.LimpiarArchivoBD();
            this.IniciarServidor();

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

            this.FinalizarServidor();
        }

        [TestMethod]
        public void Test_AltaProyectos()
        {
            this.LimpiarArchivoBD();
            this.IniciarServidor();
            
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

            this.FinalizarServidor();
        }

        [TestMethod]
        public void Test_PersistenciaPorAlcance()
        {
             this.LimpiarArchivoBD();
             this.IniciarServidor();

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

             this.FinalizarServidor();
        }

        [TestMethod]
        public void Test_AltaUsuarioConPerfiles()
        {
            this.LimpiarArchivoBD();
            this.IniciarServidor();

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.NuevoPerfil();
                p1.Nombre = "Perfil 1";

                Perfil p2 = bugzzinga.NuevoPerfil();
                p2.Nombre = "Perfil 2";

                bugzzinga.RegistrarPerfil( p1 );
                bugzzinga.RegistrarPerfil( p2 );
            }

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.ObtenerPerfil( "Perfil 1" );

                Usuario usuario1 = bugzzinga.NuevoUsuario();
                usuario1.Nombre = "Gabriel";
                usuario1.Apellido = "Batistuta";
                usuario1.Perfil = p1;

                bugzzinga.RegistrarUsuario( usuario1 );
            }

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Usuario u = bugzzinga.ObtenerUsuario( "Gabriel" );
                u.Nombre = "Roberto";              
            }

            this.FinalizarServidor();
        }

        [TestMethod]
        public void Test_AltaUsuarioConPerfiles_EjemploException()
        {
            this.LimpiarArchivoBD();
            this.IniciarServidor();

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.NuevoPerfil();
                p1.Nombre = "Perfil 1";

                Perfil p2 = bugzzinga.NuevoPerfil();
                p2.Nombre = "Perfil 2";

                bugzzinga.RegistrarPerfil( p1 );
                bugzzinga.RegistrarPerfil( p2 );
            }

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.ObtenerPerfil( "Perfil 1" );

                Usuario usuario1 = bugzzinga.NuevoUsuario();
                usuario1.Nombre = "Gabriel";
                usuario1.Apellido = "Batistuta";
                usuario1.Perfil = p1;

                bugzzinga.RegistrarUsuario( usuario1 );
            }

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Usuario u = bugzzinga.ObtenerUsuario( "Gabriel" );
                u.Nombre = "Roberto";

                //Como ocurrio una excepción, no deberia registrarse ningun cambio en la base de datos
                throw new BugzzingaException("Error de la capa de dominio");
            }


            this.FinalizarServidor();
        }

        [TestMethod]
        public void Test_DemoActivacionTransparente_ObjetosSimples()
        {
            this.LimpiarArchivoBD();
            this.IniciarServidor();

            // ------------------------------------------------------------------------------------
            //Guardamos los cambios y persistimos en forma transparente

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.NuevoPerfil();
                p1.Nombre = "Perfil 1";

                Perfil p2 = bugzzinga.NuevoPerfil();
                p2.Nombre = "Perfil 2";

                bugzzinga.RegistrarPerfil( p1 );
                bugzzinga.RegistrarPerfil( p2 );
            }

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.ObtenerPerfil( "Perfil 1" );

                Usuario usuario1 = bugzzinga.NuevoUsuario();
                usuario1.Nombre = "Gabriel";
                usuario1.Apellido = "Batistuta";
                usuario1.Perfil = p1;

                bugzzinga.RegistrarUsuario( usuario1 );
            }
            // ------------------------------------------------------------------------------------

            Usuario usuarioActivado = null;

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                usuarioActivado = bugzzinga.ObtenerUsuario( "Gabriel" );
            }
            //El perfil no deberia tener datos, ya que lo solicite fuera del alcance del sistema
            Perfil perfil = usuarioActivado.Perfil;

            // ------------------------------------------------------------------------------------

            usuarioActivado = null;

            using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
            {
                usuarioActivado = bugzzinga.ObtenerUsuario( "Gabriel" );
                //Esta vez los datos del perfil se cargan ya que estoy dentro del contexto del sistema
                Perfil perfilActivado = usuarioActivado.Perfil;
            }
            // ------------------------------------------------------------------------------------
            this.FinalizarServidor();
        }

        [TestMethod]
        public void Test_DemoActivacionTransparente_Colecciones()
        {
            this.LimpiarArchivoBD();
            this.IniciarServidor();

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                Proyecto p = bugzzinga.NuevoProyecto();
                p.Nombre = "Proyecto1";
                                
                Item item1 = new Item();
                item1.Nombre = "Primer item del proyecto";

                Item item2 = new Item();
                item2.Nombre = "Segundo item del proyecto";

                p.AgregarItem( item1 );
                p.AgregarItem( item2 );

                bugzzinga.RegistrarProyecto( p );
            }

            // ----------------------------------------------------------------------------------------------------

            Proyecto proyecto = null;

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                proyecto = bugzzinga.ObtenerProyecto( "Proyecto1" );
            }

            //Al cargar esta instancia de pryecto de la BD, los items deberian estar en blanco
            //ya que solo se van a activar de manera lazy pero ya estan fuera del contexto del sistema
            IEnumerable<Item> items = proyecto.Items;

            // ----------------------------------------------------------------------------------------------------

            proyecto = null;

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                proyecto = bugzzinga.ObtenerProyecto( "Proyecto1" );

                IEnumerable<Item> itemsActivados = proyecto.Items;
            }      

            // ----------------------------------------------------------------------------------------------------

            this.FinalizarServidor();
        }
    }
}
