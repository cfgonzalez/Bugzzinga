using System;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Api;
using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class ProyectoControllerTest
    {
        [TestMethod]
        public void Proyecto_Get()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();
            
            //Obtenemos los proyectos de prueba
            var proyectosTest = HelperInstanciacionProyectos.GetProyectos( 2 );
            //Guardamos los proyectos de prueba directamente en la base de datos
            using ( IContextoProceso contextoProceso = new ContextoProceso(HelperTestSistema.ObjectFactory ) )
            {
                contextoProceso.ContenedorObjetos.Store(proyectosTest);
            }
            //Reiniciamos la conexion a la base de datos
            HelperTestSistema.ReiniciarConexion();

            //Traemos los proyectos registrados desde el controller
            var controller = new ProyectosController(HelperTestSistema.ObjectFactory);
            var proyectosResultado = controller.Get();

            HelperTestSistema.FinalizarServidor();


            //Asserts

            //La cantidad de proyectos registrados deben ser 2
            Assert.AreEqual( 2, proyectosResultado.ToList().Count() );
            //El primer proyecto se debe llamar proyecto 1
            Assert.AreEqual( "Proyecto 1", proyectosResultado.ToList()[0].Nombre );
            //El segundo proyecto se debe llamar proyecto 2
            Assert.AreEqual( "Proyecto 2", proyectosResultado.ToList()[1].Nombre );
        }


        [TestMethod]
        public void Proyecto_Post()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();
            
            //Obtenemos los proyectos de prueba
            var proyectoDto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            // Hacemos post del proyecto
            var controller = new ProyectosController( HelperTestSistema.ObjectFactory );
            controller.Post( proyectoDto );
            
            //Reiniciamos la conexion para simular los postbacks
            HelperTestSistema.ReiniciarConexion();        

            //Solicitamos los proyectos al controller
            var proyectos = controller.Get();
            
            HelperTestSistema.FinalizarServidor();
            
            //Asserts 
            Assert.AreEqual("Proyecto 1" ,proyectos.ToList()[0].Nombre );
            Assert.AreNotSame( proyectoDto, proyectos.ToList()[0], "La instancia que devuelve el controller no deberia ser la misma" );
        }

    }
}
