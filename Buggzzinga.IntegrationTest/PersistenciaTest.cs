﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Core;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class PersistenciaTest
    {      
        [TestMethod]
        public void Test_BugTrackerScope()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

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

            HelperTestSistema.FinalizarServidor();
        }

        [TestMethod]
        public void Test_AltaProyectos()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();
            
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

            HelperTestSistema.FinalizarServidor();
        }

        [TestMethod]
        public void Test_PersistenciaPorAlcance()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

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

             HelperTestSistema.FinalizarServidor();
        }

        //[TestMethod]
        //public void Test_AltaUsuarioConPerfiles()
        //{
        //    HelperTestSistema.LimpiarArchivoBD();
        //    HelperTestSistema.IniciarServidor();

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Perfil p1 = bugzzinga.NuevoPerfil();
        //        p1.Nombre = "Perfil 1";

        //        Perfil p2 = bugzzinga.NuevoPerfil();
        //        p2.Nombre = "Perfil 2";

        //        bugzzinga.RegistrarPerfil( p1 );
        //        bugzzinga.RegistrarPerfil( p2 );
        //    }

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Perfil p1 = bugzzinga.ObtenerPerfil( "Perfil 1" );

        //        Usuario usuario1 = bugzzinga.NuevoUsuario();
        //        usuario1.Nombre = "Gabriel";
        //        usuario1.Apellido = "Batistuta";
        //        usuario1.Perfil = p1;

        //        bugzzinga.RegistrarUsuario( usuario1 );
        //    }

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Usuario u = bugzzinga.ObtenerUsuario( "Gabriel" );
        //        u.Nombre = "Roberto";              
        //    }

        //    HelperTestSistema.FinalizarServidor();
        //}

        //[TestMethod]
        //public void Test_AltaUsuarioConPerfiles_EjemploException()
        //{
        //    HelperTestSistema.LimpiarArchivoBD();
        //    HelperTestSistema.IniciarServidor();

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Perfil p1 = bugzzinga.NuevoPerfil();
        //        p1.Nombre = "Perfil 1";

        //        Perfil p2 = bugzzinga.NuevoPerfil();
        //        p2.Nombre = "Perfil 2";

        //        bugzzinga.RegistrarPerfil( p1 );
        //        bugzzinga.RegistrarPerfil( p2 );
        //    }

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Perfil p1 = bugzzinga.ObtenerPerfil( "Perfil 1" );

        //        Usuario usuario1 = bugzzinga.NuevoUsuario();
        //        usuario1.Nombre = "Gabriel";
        //        usuario1.Apellido = "Batistuta";
        //        usuario1.Perfil = p1;

        //        bugzzinga.RegistrarUsuario( usuario1 );
        //    }

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Usuario u = bugzzinga.ObtenerUsuario( "Gabriel" );
        //        u.Nombre = "Roberto";

        //        //Como ocurrio una excepción, no deberia registrarse ningun cambio en la base de datos
        //        throw new BugzzingaException("Error de la capa de dominio");
        //    }


        //    HelperTestSistema.FinalizarServidor();
        //}

        //[TestMethod]
        //public void Test_DemoActivacionTransparente_ObjetosSimples()
        //{
        //    HelperTestSistema.LimpiarArchivoBD();
        //    HelperTestSistema.IniciarServidor();

        //    // ------------------------------------------------------------------------------------
        //    //Guardamos los cambios y persistimos en forma transparente

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Perfil p1 = bugzzinga.NuevoPerfil();
        //        p1.Nombre = "Perfil 1";

        //        Perfil p2 = bugzzinga.NuevoPerfil();
        //        p2.Nombre = "Perfil 2";

        //        bugzzinga.RegistrarPerfil( p1 );
        //        bugzzinga.RegistrarPerfil( p2 );
        //    }

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        Perfil p1 = bugzzinga.ObtenerPerfil( "Perfil 1" );

        //        Usuario usuario1 = bugzzinga.NuevoUsuario();
        //        usuario1.Nombre = "Gabriel";
        //        usuario1.Apellido = "Batistuta";
        //        usuario1.Perfil = p1;

        //        bugzzinga.RegistrarUsuario( usuario1 );
        //    }
        //    // ------------------------------------------------------------------------------------

        //    Usuario usuarioActivado = null;

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        usuarioActivado = bugzzinga.ObtenerUsuario( "Gabriel" );
        //    }
        //    //El perfil no deberia tener datos, ya que lo solicite fuera del alcance del sistema
        //    Perfil perfil = usuarioActivado.Perfil;

        //    // ------------------------------------------------------------------------------------

        //    usuarioActivado = null;

        //    using ( BugTrackerPersistente bugzzinga = new BugTrackerPersistente() )
        //    {
        //        usuarioActivado = bugzzinga.ObtenerUsuario( "Gabriel" );
        //        //Esta vez los datos del perfil se cargan ya que estoy dentro del contexto del sistema
        //        Perfil perfilActivado = usuarioActivado.Perfil;
        //    }
        //    // ------------------------------------------------------------------------------------
        //    HelperTestSistema.FinalizarServidor();
        //}

        [TestMethod]
        public void Test_DemoActivacionTransparente_Colecciones()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

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

            HelperTestSistema.FinalizarServidor();
        }
    }
}
