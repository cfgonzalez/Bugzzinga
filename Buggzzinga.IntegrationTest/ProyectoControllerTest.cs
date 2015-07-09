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
        public void ProyectosController_ListarProyectos()
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
        public void ProyectosController_NuevoProyecto()
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

        [TestMethod]
        public void ProyectosController_ModificarProyecto()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos los proyectos de ejemplo directamente sobre la base de datos
            var listadProyectosDto = HelperInstanciacionProyectos.GetProyectos( 2 );

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory  ))
            {
                foreach ( var proyectoDto in listadProyectosDto )
                {
                    contexto.ContenedorObjetos.Store( proyectoDto );
                }
            }

            //Reiniciamos la conexion a la base de datos
            HelperTestSistema.ReiniciarConexion();

            var controller = new ProyectosController( HelperTestSistema.ObjectFactory );
            //obtenemos los proyectos y reiniciamos la conexion
            var listadoProyectosBD = controller.Get();            
            HelperTestSistema.ReiniciarConexion();

            //obtenemos el primer proyecto y lo modificamos
            var proyectoBD = listadoProyectosBD.ToList()[0];
            proyectoBD.Descripcion = "Proyecto de prueba 1 modificado";

            //modificamos el proyecto en la BD a traves del controller y reiniciamos la conexion
            controller.Put( proyectoBD );
            HelperTestSistema.ReiniciarConexion();

            //limpiamos las variables para garantizar que las instancias quedan limpias
            listadoProyectosBD = null;
            
            //Obtenemos los proyectos nuevamentes
            listadoProyectosBD = controller.Get();
            var otroProyectoBD = listadoProyectosBD.ToList()[0];

            HelperTestSistema.FinalizarServidor();

            //Asserts

            //La cantidad de proyectos debe ser 2 (ya que solo se modifico un proyecto)
            Assert.AreEqual( 2, listadoProyectosBD.ToList().Count );
            //El primer proyecto debe tener la descripcion modificada
            Assert.AreEqual("Proyecto de prueba 1 modificado",listadoProyectosBD.ToList()[0].Descripcion);
            //La instancia del primer proyecto debe ser una instancia diferente
            Assert.AreNotSame( proyectoBD, listadoProyectosBD.ToList()[0] );
        }

    }
}
