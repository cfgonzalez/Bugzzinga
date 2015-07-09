using System;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Api;
using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
