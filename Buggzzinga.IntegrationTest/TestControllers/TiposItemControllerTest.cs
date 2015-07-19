using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Contexto;
using Bugzzinga.Api;
using Bugzzinga.Dominio;


namespace Buggzzinga.IntegrationTest.TestControllers
{
    [TestClass]
    public class TiposItemControllerTest
    {

        /// <summary>
        /// El objetivo es listar todos los tipos de item de un proyecto en particular
        /// </summary>
        [TestMethod]
        public void TiposItemController_ListarTiposItemDeProyecto()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Creamos dos proyectos directamente en la BD 
            //Cada proyecto tiene dos tipos de item
            var tiposDeItemProyecto1 = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 1", 2 );
            var tiposDeItemProyecto2 = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 2", 2 );
            var proyectos = HelperInstanciacionProyectos.GetProyectos( 2 );
            
            proyectos[0].AgregarTipoDeItem( tiposDeItemProyecto1[0] );
            proyectos[0].AgregarTipoDeItem( tiposDeItemProyecto1[1] );

            proyectos[1].AgregarTipoDeItem( tiposDeItemProyecto2[0] );
            proyectos[1].AgregarTipoDeItem( tiposDeItemProyecto2[1] );
            
            //Guardamos los objetos en la BD
            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                contexto.ContenedorObjetos.Store( proyectos );
            }

            HelperTestSistema.ReiniciarConexion();

            //Ahora obtenemos los datos desde la API
            var controller = new TiposItemController( HelperTestSistema.ObjectFactory );
            
            //Obtenemos los tipos de item del proyecto 1 desde la API
            var tiposDeItemProyecto1Request = controller.Get("P1");
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los tipso de item del proyecto 2 desde la API
            var tiposDeItemProyecto2Request = controller.Get("P2");
            HelperTestSistema.ReiniciarConexion();


            HelperTestSistema.FinalizarServidor();

            //Asserts
                        
            //La cantidad de tipos de item del proyecto 1 debe ser 2
            Assert.AreEqual( 2, tiposDeItemProyecto1.Count );
            //Los nombres y descripciones de los tipos de item del proyecto 1 deben ser los correctos
            Assert.AreEqual( 2, tiposDeItemProyecto2.Count );
            //Los nombres y descripciones de los tipos de item del proyecto 2 deben ser los correctos
            Assert.AreEqual( "Proyecto 1-Tipo de item de prueba 1", tiposDeItemProyecto1[0].Descripcion  );
            Assert.AreEqual( "Proyecto 1-Tipo de item de prueba 2", tiposDeItemProyecto1[1].Descripcion );
            //La cantidad de tipos de item del proyecto 2 debe ser 2
            Assert.AreEqual( "Proyecto 2-Tipo de item de prueba 1", tiposDeItemProyecto2[0].Descripcion );
            Assert.AreEqual( "Proyecto 2-Tipo de item de prueba 2", tiposDeItemProyecto2[1].Descripcion );
        }

        /// <summary>
        /// El objetivo es agregar un nuevo tipo de item a un proyecto que ya tiene tipos de item asignados
        /// </summary>
        [TestMethod]
        public void TiposItemController_AgregarTipoDeItemAProyecto()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Creamos 1 proyecto1 directamente en la BD con dos tipos de item            
            var tiposDeItemProyecto1 = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 1", 2 );            
            var proyecto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[0] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[1] );

            //Guardamos los objetos en la BD
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            { 
                contexto.ContenedorObjetos.Store( proyecto );
            }

            HelperTestSistema.ReiniciarConexion();



            //Creamos un tipo de item y lo agregamos al proyecto a traves de la API
            var controller = new TiposItemController( HelperTestSistema.ObjectFactory );

            //Obtenemos el 2 ya que tenemos que simular un nuevo tipo de item
            var nuevoTipoItem = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 1" ,3 )[2];

            controller.Post( "P1", nuevoTipoItem );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los datos directamente de la base de datos para verificarlos

            var proyectosBD = new List<Proyecto>();

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                 proyectosBD = (from Proyecto p in contexto.ContenedorObjetos select p).ToList();
            }


            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts            

            //Debe haber un solo proyecto en la base de datos
            Assert.AreEqual( 1, proyectosBD.ToList().Count );
            //El proyecto debe tener 3 tipos de item
            Assert.AreEqual( 3, proyectosBD[0].TiposDeItem.Count() );
            //El tercer tipo de item debe ser el que agregamos
            Assert.AreEqual( "Proyecto 1-Tipo de item de prueba 3", proyectosBD[0].TiposDeItem.ToList()[2].Descripcion );
        }


        /// <summary>
        /// El objetivo es modificar un tipo de item de un proyecto que tiene mas de un tipo de item
        /// </summary>
        [TestMethod]
        public void TiposItemController_ModificarTipoDeItemDeProyecto()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Creamos 1 proyecto1 directamente en la BD con dos tipos de item            
            var tiposDeItemProyecto1 = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 1", 3 );
            var proyecto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[0] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[1] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[2] );

            //Guardamos los objetos en la BD
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                contexto.ContenedorObjetos.Store( proyecto );
            }

            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los tipos de item del proyecto directamente a traves de la API
            var controller = new TiposItemController( HelperTestSistema.ObjectFactory );
            var tiposItem = controller.Get( "P1" );

            //Obtenemos el primer tipo de item y lo modificamos a traves de la API
            var tipoItem = tiposItem.ToList()[1];
            tipoItem.Descripcion = "Tipo de item 2 modificado";
            controller.Put( "P1", tipoItem );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los datos para validar directamente desde la base de datos
            var  proyectosBD = new List<Proyecto>();
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                proyectosBD = (from Proyecto p in contexto.ContenedorObjetos select p).ToList();
            }

            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
           
            //Tiene que haber un solo proyecto en la BD
            Assert.AreEqual( 1, proyectosBD.Count );
            //El proyecto debe tener 3 tipos de item
            Assert.AreEqual( 3, proyectosBD[0].TiposDeItem.Count() );
            //El tipo de item 2 debe tener la descripcion modificada
            Assert.AreEqual( "Tipo de item 2 modificado", proyectosBD[0].TiposDeItem.ToList()[1].Descripcion );
        }


        /// <summary>
        /// El objetivo es modificar un tipo de item de un proyecto que tiene mas de un tipo de item
        /// Además este tipo de item esta referenciado por un item particular del proyecto
        /// </summary>
        [TestMethod]
        public void TiposItemController_ModificarTipoDeItemDeProyecto_ConReferencias()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Creamos 1 proyecto1 directamente en la BD con dos tipos de item            
            var tiposDeItemProyecto1 = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 1", 3 );
            var proyecto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[0] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[1] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[2] );

            //Cregamos un item y le asignamos el tipo de item 2
            var item = new Item("Item 1", "Item de prueba 1",tiposDeItemProyecto1[1], new Prioridad("Baja", "Test") );            
            proyecto.AgregarItem( item );

            //Guardamos los objetos en la BD
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                contexto.ContenedorObjetos.Store( proyecto );
            }

            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los tipos de item del proyecto desde el controller
            var controller = new TiposItemController( HelperTestSistema.ObjectFactory );
            var tiposItem = controller.Get( "P1" );
            
            var tipoItemAModificar = tiposItem.ToList()[1];
            tipoItemAModificar.Descripcion = "Tipo de item 2 modificado";

            controller.Put( "P1", tipoItemAModificar );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los datos directamente desde la BD para validarlos
             //Obtenemos los datos para validar directamente desde la base de datos
            var  proyectosBD = new List<Proyecto>();
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                proyectosBD = (from Proyecto p in contexto.ContenedorObjetos select p).ToList();
            }


            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //Tiene que haber un solo proyecto
            Assert.AreEqual( 1, proyectosBD.Count );
            //El proyeto debe tener 3 tipos de item
            Assert.AreEqual( 3, proyectosBD[0].TiposDeItem.Count() );
            //El tipo de item 2 debe estar modificado
            Assert.AreEqual( "Tipo de item 2 modificado", proyectosBD[0].TiposDeItem.ToList()[1].Descripcion );
            //El proyecto debe tener 1 item
            Assert.AreEqual( 1, proyectosBD[0].Items.Count() );
            //La instanacia del tipo de item 2 debe ser la misma asociada al item del proyecto
            Assert.AreSame( proyectosBD[0].TiposDeItem.ToList()[1], proyectosBD[0].Items.ToList()[0].Tipo );
        }

        /// <summary>
        /// El objetivo es quitar un tipo de item de un proyecto que tiene mas de un tipo de item
        /// </summary>
        [TestMethod]
        public void TiposItemController_QuitarTipoDeItemDeProyecto()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();
            
            //Creamos 1 proyecto1 directamente en la BD con tres tipos de item            
            var tiposDeItemProyecto1 = HelperInstanciacionItems.GetTiposDeItem( "Proyecto 1", 3 );
            var proyecto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[0] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[1] );
            proyecto.AgregarTipoDeItem( tiposDeItemProyecto1[2] );

            //Guardamos los objetos en la BD
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                contexto.ContenedorObjetos.Store( proyecto );
            }

            HelperTestSistema.ReiniciarConexion();


            //Obtenemos los tipos de item desde el controller y damos de baja el tipo de item 2
            var controller = new TiposItemController( HelperTestSistema.ObjectFactory );
            var tiposItem = controller.Get( "P1" );

            var tipoItemABorrar = tiposItem.ToList()[1];
            controller.Delete( "P1", tipoItemABorrar.Nombre );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los datos directamente de la BD para validarlos
            var proyectosBD = new List<Proyecto>();
            var tiposItemBD = new List<TipoItem>();

            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                proyectosBD = (from Proyecto p in contexto.ContenedorObjetos select p).ToList();
                tiposItemBD = (from TipoItem t in contexto.ContenedorObjetos select t).ToList();
            }


            HelperTestSistema.ReiniciarConexion();
            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //Debe haber 1 proyecto en la BD
            Assert.AreEqual( 1, proyectosBD.Count );
            //El proyecto debe tener dos tipos de item
            Assert.AreEqual( 2, proyectosBD[0].TiposDeItem.Count() );
            //Solo debe haber dos tipos de item en la BD
            Assert.AreEqual( 2, tiposItemBD.Count );

        }


        //El objetivo es quitar un tipo de item de un proyecto que tiene un item con este tipo de item asociado
        //Deberia ocurrir una excepcion de dominio
        [TestMethod]
        public void TiposItemController_QuitarTipoDeItemDeProyecto_ConReferencias()
        {
            //Asserts
            Assert.Inconclusive();
        }



    }
}

