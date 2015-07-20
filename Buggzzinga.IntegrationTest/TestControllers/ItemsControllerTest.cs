using System;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Api;
using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Bugzzinga.Dominio;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using System.Collections.Generic;

namespace Buggzzinga.IntegrationTest.TestControllers
{
    [TestClass]
    public class ItemsControllerTest
    {

        /// <summary>
        /// Objetivo: Listar todos los items de un proyecto
        /// </summary>
        [TestMethod]
        public void ItemsController_ListarItems()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            // Creamos en la BD 2 proyectos con 2 items cada uno
            var proyectos = HelperInstanciacionProyectos.GetProyectos( 2 );
            var itemsProyecto1 = HelperInstanciacionItems.GetItems( "Proyecto 1", 2 );
            var itemsProyecto2 = HelperInstanciacionItems.GetItems( "Proyecto 2", 2 );

            proyectos[0].AgregarItem( itemsProyecto1[0] );
            proyectos[0].AgregarItem( itemsProyecto1[1] );

            proyectos[1].AgregarItem( itemsProyecto2[0] );
            proyectos[1].AgregarItem( itemsProyecto2[1] );

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                contexto.ContenedorObjetos.Store( proyectos );
            }
            
            //Solicitamos al controller los items del proyecto
            var controller = new ItemsController( HelperTestSistema.ObjectFactory );
            var itemsProyectoRequest = controller.Get( "P1" );
            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //En total el request debe devolver 2 items
            Assert.AreEqual( 2, itemsProyectoRequest.Count() );
            //Los nombres de los dos items deben ser los correctos
            Assert.AreEqual("Proyecto 1-Item de prueba 1", itemsProyectoRequest.ToList()[0].Descripcion);
            Assert.AreEqual( "Proyecto 1-Item de prueba 2", itemsProyectoRequest.ToList()[1].Descripcion );
        }

        /// <summary>
        /// Objetivo: Agregar un nuevo item a un proyecto sin items
        /// </summary>
        [TestMethod]
        public void ItemsController_AgrearItemAProyecto()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Creamos un proyecto y lo guardamos directamente en la base de datos
            var proyecto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                contexto.ContenedorObjetos.Store( proyecto );
            }

            //Instanciamos un nuevo item y lo agregamos al proyecto
                        
            Item nuevoItem = new Item(
                "Item  test", "Descripcion item test",
                new TipoItem( "Tipo 1", "Tipo 1 test" ),
                new Prioridad( "Prioridad 1", "Prioridad de prueba" ) ); 

            var controller = new ItemsController( HelperTestSistema.ObjectFactory );
            controller.Post( "P1", nuevoItem );

            //Obtenemos los datos de la BD para validarlos
            var proyectosBD = new List<Proyecto>();
            var tipoItem = new TipoItem();
            var prioridad = new Prioridad( "", "" );

            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                proyectosBD = (from Proyecto p in contexto.ContenedorObjetos select p).ToList();
                prioridad = (from Prioridad p in contexto.ContenedorObjetos select p).SingleOrDefault();
                tipoItem = (from TipoItem ti in contexto.ContenedorObjetos select ti).SingleOrDefault();
            }

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //Tiene que haber un solo proyecto en la BD
            Assert.AreEqual( 1, proyectosBD.Count );
            //El proyecto debe tener un item
            Assert.AreEqual( 1, proyectosBD[0].Items.Count() );
            //El  item debe tener el nombre y la descripcion correcta
            Assert.AreEqual("Descripcion item test", proyectosBD[0].Items.ToList()[0].Descripcion);
            //El  item debe tener la prioridad correcta
            Assert.AreSame(prioridad, proyectosBD[0].Items.ToList()[0].Prioridad);
            Assert.AreEqual("Prioridad 1", proyectosBD[0].Items.ToList()[0].Prioridad.Nombre);            
            //El item debe tener asignado el tipo de item correcto
            Assert.AreSame( tipoItem, proyectosBD[0].Items.ToList()[0].Tipo );
            Assert.AreEqual("Tipo 1", proyectosBD[0].Items.ToList()[0].Tipo.Nombre);

        }

        /// <summary>
        /// Objetivo: Agregar otro item a un proyecto que ya tiene items
        /// </summary>
        [TestMethod]
        public void ItemsController_AgrearOtroItemAProyecto()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar test" );
        }

        /// <summary>
        /// Objetivo: Modificar un item en un proyecto
        /// </summary>
        [TestMethod]
        public void ItemsController_ModificarItem()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar test" );
        }

        /// <summary>
        /// Objetivo: Cambiar la prioridad de un item en un proyecto
        /// </summary>
        [TestMethod]
        public void ItemsController_CambiarPrioridad()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar test" );
        }

        /// <summary>
        /// Objetivo: Cambiar responsable
        /// </summary>
        [TestMethod]
        public void ItemsController_CambiarResponsable()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar test" );
        }

        /// <summary>
        /// Objetivo: Cambiar responsable
        /// </summary>
        [TestMethod]
        public void ItemsController_CambiarEstado()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar test" );
        }

        /// <summary>
        /// Objetivo: Agregar registro log
        /// </summary>
        [TestMethod]
        public void ItemsController_AgregarRegistroLog()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();



            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar test" );
        }

    }
}
