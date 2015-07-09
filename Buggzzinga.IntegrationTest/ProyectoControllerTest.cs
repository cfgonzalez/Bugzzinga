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
            //---------------------------------------------------------------------------
            //Obtenemos los proyectos de prueba
            var proyectosTest = HelperInstanciacionProyectos.GetProyectos( 2 );

            using ( IContextoProceso contextoProceso = new ContextoProceso(HelperTestSistema.ObjectFactory ) )
            {
                contextoProceso.ContenedorObjetos.Store(proyectosTest);
            }

            //---------------------------------------------------------------------------
            var controller = new ProyectosController(HelperTestSistema.ObjectFactory);

            var proyectos = controller.Get();

            HelperTestSistema.FinalizarServidor();

            
        }


        [TestMethod]
        public void Proyecto_Post()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();
            // -----------------------------------------------------------------------------
            //Obtenemos los proyectos de prueba
            var proyectoDto = HelperInstanciacionProyectos.GetProyectos( 1 )[0];

            // Hacemos post del proyecto
            var controller = new ProyectosController( HelperTestSistema.ObjectFactory );
            controller.Post( proyectoDto );
            
            HelperTestSistema.ReiniciarConexion();        

            var proyectos = controller.Get();
            // -----------------------------------------------------------------------------
            HelperTestSistema.FinalizarServidor();


            // -----------------------------------------------------------------------------
            Assert.AreEqual("Proyecto 1" ,proyectos.ToList()[0].Nombre );
            Assert.AreNotSame( proyectoDto, proyectos.ToList()[0], "La instancia que devuelve el controller no deberia ser la misma" );
        }

    }
}
