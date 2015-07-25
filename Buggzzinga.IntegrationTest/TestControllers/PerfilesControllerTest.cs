using System;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Api;
using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Db4objects.Db4o.Linq;
using Db4objects.Db4o;

namespace Buggzzinga.IntegrationTest.TestControllers
{
    [TestClass]
    public class PerfilesControllerTest
    {
        [TestMethod]
        public void PerfilesController_ListarPerfiles()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();
            //Generamos dos perfiles de prueba
            var perfiles = HelperInstanciacionPerifles.GetPerfiles(2);
            //Guardamos los perfiles directamente en la base de datos
            using ( IContextoProceso contexto =  new ContextoProceso(HelperTestSistema.ObjectFactory ) )
            {
                foreach ( Rol perfil in perfiles )
                {
                    contexto.ContenedorObjetos.Store( perfil );
                }
            }
            
            //Reiniciamos la conexion
            HelperTestSistema.ReiniciarConexion();

            //Obtenermos los perfiles desede el controller
            var controller = new PerfilesController( HelperTestSistema.ObjectFactory );
            var perfilesBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.FinalizarServidor();
            
            //Asserts
            Assert.Inconclusive( "Refactorizar y terminar este test" );
           //En la BD dede haber solo dos perfiles
            Assert.AreEqual( 2, perfilesBD.ToList().Count );
            //Las instancias retornadas  deben ser diferencias a las almacenadas manualmente
            Assert.AreNotSame( perfiles[0], perfilesBD.ToList()[0] );
            Assert.AreNotSame( perfiles[1], perfilesBD.ToList()[1] );
        }

        [TestMethod]
        public void PerfilesController_NuevoPerfil()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Instanciamos un perfil de prueba
            var perfilDto = HelperInstanciacionPerifles.GetPerfiles( 1 )[0];

            //Guardarmos el perfil 
            var controller = new PerfilesController(HelperTestSistema.ObjectFactory);
            controller.Post( perfilDto );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los perfiles almacenados
            var perfilesBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();
            
            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Refactorizar y terminar este test" );
            //Solo debe haber un perfil almecenado
            Assert.AreEqual( 1, perfilesBD.ToList().Count );
            //La instancia del perfil almacenado debe ser diferente
            Assert.AreNotSame( perfilDto, perfilesBD.ToList()[0] );
            //EL nombre de la instancia del perfil seleccionado debe ser el correcto
            Assert.AreEqual( "Perfil 1", perfilesBD.ToList()[0].Nombre );
        }

        [TestMethod]
        public void PerfilesController_ModificarPerfil()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos dos perfiles de prueba
            var perfiles = HelperInstanciacionPerifles.GetPerfiles( 2 );
            //Guardamos los perfiles directamente en la base de datos
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                foreach ( Rol perfil in perfiles )
                {
                    contexto.ContenedorObjetos.Store( perfil );
                }
            }

            //Reiniciamos la conexion
            HelperTestSistema.ReiniciarConexion();

            //Obtenermos los perfiles desede el controller
            var controller = new PerfilesController( HelperTestSistema.ObjectFactory );
            var perfilesBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            //Modificamos el primer perfil
            Rol perfilAModificar = perfilesBD.ToList()[0];
            perfilAModificar.Descripcion = "perfil de prueba 1 modificado";
            controller.Put( perfilAModificar );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los perfiles de nuevo desde la base de datos
            perfilesBD = null;
            perfilesBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.FinalizarServidor();
                        
            //Asserts
            Assert.Inconclusive( "Refactorizar y terminar este test" );
            //En la bd debe haber solamente dos perfiles 
            Assert.AreEqual( 2, perfilesBD.ToList().Count );
            //La instancia del perfil a modificar y el primer perfil de la BD deben ser diferentes
            Assert.AreNotSame( perfilAModificar, perfilesBD.ToList()[0] );
            //La descripcion del perfil de la BD se tiene que haber modificado correctamente
            Assert.AreEqual( "perfil de prueba 1 modificado", perfilesBD.ToList()[0].Descripcion );
        }

        [TestMethod]
        public void PerfilesController_ModificarPerfilAsignadoAUsuario()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos dos perfiles  y un  usuario de prueba
            var perfiles = HelperInstanciacionPerifles.GetPerfiles( 2 );
            var usuario = HelperInstanciacionUsuarios.GetUsuarios( 1 )[0];

            //Guardamos los perfiles y el usuario directamente en la base de datos
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                foreach ( Rol perfil in perfiles )
                {
                    contexto.ContenedorObjetos.Store( perfil );
                }
                //Asociamos el primer perfil al usuario
                //usuario.Perfil = perfiles[0];

                contexto.ContenedorObjetos.Store( usuario );
            }

            //Reiniciamos la conexion
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los perfiles desde el controller
            var controller = new PerfilesController( HelperTestSistema.ObjectFactory );
            var perfilesBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            //Modificamos el primer perfil
            var perfilAModificar = perfilesBD.ToList()[0];
            perfilAModificar.Descripcion = "perfil de prueba 1 modificado";
            controller.Put( perfilAModificar );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los datos directamente de la base de datos para verificarlos
            perfilesBD = null;
            var usuariosBD = new List<Usuario>();

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                perfilesBD = (from Rol p in contexto.ContenedorObjetos select p).ToList();
                usuariosBD = (from Usuario u in contexto.ContenedorObjetos select u).ToList();
            }

            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Refactorizar y terminar este test" );
            // La cantidad de perfiles en la BD debe seguir siendo la misma (solo 2 )
            Assert.AreEqual( 2, perfiles.Count );
            //Se tiene que haber modificado el nombre en el perfil asociado al usuario
            //Assert.AreEqual( "perfil de prueba 1 modificado", usuariosBD[0].Perfil.Descripcion );
            //El perfil se tiene que haber modificado correctamente
            Assert.AreEqual( "perfil de prueba 1 modificado", perfilesBD.ToList()[0].Descripcion );
            //La instancia del perfil asociado al usuario y el primer perfil deben ser  la misma
            //Assert.AreSame(perfilesBD.ToList()[0], usuariosBD[0].Perfil );
        }


        [TestMethod]
        public void PerfilesController_EliminarPerfil()
        {
            Assert.Inconclusive();
        }
    }

}
