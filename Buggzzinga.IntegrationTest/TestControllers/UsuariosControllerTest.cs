using System;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Api;
using Bugzzinga.Contexto;
using Bugzzinga.Contexto.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Bugzzinga.Dominio;

namespace Buggzzinga.IntegrationTest.TestControllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public void UsuariosController_ListarUsuarios()
        {            
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos dos usuarios de prueba directamente sobre la BD
            var usuarios = HelperInstanciacionUsuarios.GetUsuarios( 2 );

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                contexto.ContenedorObjetos.Store( usuarios );
            }
            //Reseteamos la conexion a la BD
            HelperTestSistema.ReiniciarConexion();

            //Cargo los usuarios solicitandolos al controller
            var controller = new UsuariosController( HelperTestSistema.ObjectFactory );
            var usuariosBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //En la base de datos tiene que haber 2 usuarios
            Assert.AreEqual( 2, usuariosBD.Count() );
            //El nombre del primer usuario debe ser usuario 1
            Assert.AreEqual( "Usuario 1" , usuariosBD.ToList()[0].Nombre);
            //El nombre del segundo usuario debe ser usuario 2
            Assert.AreEqual( "Usuario 2", usuariosBD.ToList()[1].Nombre );
        }

        [TestMethod]
        public void UsuariosController_NuevoUsuario()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos un usuario de prueba
            var usuarioDto = HelperInstanciacionUsuarios.GetUsuarios( 1 )[0];

            //Guardamos el usuario a traves del controller
            var controller = new UsuariosController( HelperTestSistema.ObjectFactory );
            controller.Post( usuarioDto );
            HelperTestSistema.ReiniciarConexion();

            //Traemos los usuarios registrrados en el sistema
            var usuariosBD = controller.Get();
            HelperTestSistema.ReiniciarConexion();
            
            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //Debe haber un solo usuario en la base de datos
            Assert.AreEqual( 1, usuariosBD.Count() );
            //El usuario se debe llamar usuario 1
            Assert.AreEqual( "Usuario 1", usuariosBD.ToList()[0].Nombre );
            //La instancia del usuario debe ser distinta a la instancia del usuario dto
            Assert.AreNotSame( usuarioDto, usuariosBD.ToList()[0] );
        }

        [TestMethod]
        public void UsuariosController_ModificarUsuario()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos dos usuarios de prueba directamente sobre la BD
            var usuarios = HelperInstanciacionUsuarios.GetUsuarios( 2 );

            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                contexto.ContenedorObjetos.Store( usuarios );
            }
            //Reseteamos la conexion a la BD
            HelperTestSistema.ReiniciarConexion();

            //Cargamos los usuarios registrados
            var controller = new UsuariosController( HelperTestSistema.ObjectFactory );
            var usuariosPrimerRequest = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            //MOdificamos el primer usuario
            var usuarioAModificar = usuariosPrimerRequest.ToList()[0];
            usuarioAModificar.Nombre = "usuario 1 modificado";
            controller.Put( usuarioAModificar );
            HelperTestSistema.ReiniciarConexion();

            //Cargamos nuevamente los usuarios registrados
            var usuariosSegundoRequest = controller.Get();
            HelperTestSistema.ReiniciarConexion();
                        
            HelperTestSistema.FinalizarServidor();
            
            //Asserts
            
            //En la base de datos debe haber solo 2 usuarios
            Assert.AreNotSame( 2, usuariosSegundoRequest.ToList().Count );
            //El nombre del usuario 1 se debe encontrar modificado
            Assert.AreEqual( "usuario 1 modificado", usuariosSegundoRequest.ToList()[0].Nombre );
            //La instancia del usuario 1 debe ser distinta de la instancia del put
            Assert.AreNotSame( usuarioAModificar, usuariosSegundoRequest.ToList()[0] );

        }

        [TestMethod]
        public void UsuariosController_NuevoUsuarioConPerfil()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos los perfiles de prueba en la base de datos
            var perfiles = HelperInstanciacionPerifles.GetPerfiles( 2 );

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                contexto.ContenedorObjetos.Store( perfiles );
            }

            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los perfiles del sistema
            var perfilesController = new PerfilesController( HelperTestSistema.ObjectFactory );            
            var perfilesBD = perfilesController.Get();
            HelperTestSistema.ReiniciarConexion();

            //Generamos un usuario nuevo y le asignamos el primer perfil
            var controller = new UsuariosController( HelperTestSistema.ObjectFactory );
            Usuario usuarioDto = HelperInstanciacionUsuarios.GetUsuarios( 1 ).ToList()[0];
            usuarioDto.Perfil = perfilesBD.ToList()[0];
            controller.Post( usuarioDto );
            HelperTestSistema.ReiniciarConexion();
           
            //Obtenemos de la BD los datos a validar
            perfilesBD = null;
            perfilesBD = new List<Perfil>();
            var usuariosBD = new List<Usuario>();

            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                perfilesBD = (from Perfil p in contexto.ContenedorObjetos select p).ToList();
                usuariosBD = (from Usuario u in contexto.ContenedorObjetos select u).ToList();
            }
            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //Tiene que haber un solo usuario en la base de datos
            Assert.AreEqual( 1, usuariosBD.Count() );
            //Tienen que haber solamente dos perfiles en la base de datos
            Assert.AreEqual( 2, perfilesBD.Count() );
            //El perfil asignado al usuario debe ser el perfil 1
            Assert.AreEqual("Perfil 1", usuariosBD[0].Perfil.Nombre);
            Assert.AreSame( perfilesBD.ToList()[0] , usuariosBD[0].Perfil );
        }


        [TestMethod]
        public void UsuariosController_ModificarUsuarioConPerfil()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos los perfiles y los usuarios de prueba en la base de datos
            var perfiles = HelperInstanciacionPerifles.GetPerfiles( 2 );
            var usuarios = HelperInstanciacionUsuarios.GetUsuarios( 2 );

            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                contexto.ContenedorObjetos.Store( perfiles );
                usuarios[0].Perfil = perfiles[0];
                usuarios[1].Perfil = perfiles[1];
                contexto.ContenedorObjetos.Store( usuarios );
            }

            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los usuarios registrados
            var controller = new UsuariosController( HelperTestSistema.ObjectFactory );
            var usuariosPrimerRequest = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            //Modificamos el primer usuario y lo guardamos
            usuariosPrimerRequest.ToList()[0].Apellido = "apellido 1 modificado";
            controller.Put( usuariosPrimerRequest.ToList()[0] );
            HelperTestSistema.ReiniciarConexion();
            
            //Obtenemos los datos para validar
            var perfilesBD = new List<Perfil>();
            var usuariosBD  = new List<Usuario>();
            using ( IContextoProceso contexto = new ContextoProceso(HelperTestSistema.ObjectFactory) )
            {
                perfilesBD = (from Perfil p in contexto.ContenedorObjetos select p).ToList();
                usuariosBD = (from Usuario u in contexto.ContenedorObjetos select u).ToList();
            }


            HelperTestSistema.FinalizarServidor();
            
            //Asserts
            
            //Los usuarios de la BD deben ser 2
            Assert.AreEqual( 2, usuariosBD.Count );
            //Los perfiles de la BD deben ser 2
            Assert.AreEqual( 2, perfilesBD.Count );
            //El apellido del primer usuario debe estar modificado
            Assert.AreEqual( "apellido 1 modificado", usuariosBD[0].Apellido );
            //El primer usuario debe tener asignado el perfil 1
            Assert.AreSame( perfilesBD[0], usuariosBD[0].Perfil );

        }

        [TestMethod]
        public void UsuariosController_AsignarOtroPerfilAUnUsuario()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            //Generamos los perfiles y los usuarios de prueba en la base de datos
            var perfiles = HelperInstanciacionPerifles.GetPerfiles( 2 );
            var usuarios = HelperInstanciacionUsuarios.GetUsuarios( 2 );

            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                contexto.ContenedorObjetos.Store( perfiles );
                usuarios[0].Perfil = perfiles[0];
                usuarios[1].Perfil = perfiles[1];
                contexto.ContenedorObjetos.Store( usuarios );
            }
            HelperTestSistema.ReiniciarConexion();

            //Obtengo los perfiles registrados en el sistema
            var perfilesController = new PerfilesController ( HelperTestSistema.ObjectFactory );
            var perfilesPrimerRequest = perfilesController.Get();
            HelperTestSistema.ReiniciarConexion();
            
            //Obtengo los usuarios registrados en el sistema
            var controller = new UsuariosController( HelperTestSistema.ObjectFactory );
            var usuariosPrimerRequest = controller.Get();
            HelperTestSistema.ReiniciarConexion();

            //Le asigno el perfil 2 al usuario 1
            var usuarioAModificar = usuariosPrimerRequest.ToList()[0];
            usuarioAModificar.Perfil = perfilesPrimerRequest.ToList()[1];
            controller.Put( usuarioAModificar );
            HelperTestSistema.ReiniciarConexion();

            //Obtenemos los datos para la validacion
            var perfilesBD = new List<Perfil>();
            var usuariosBD = new List<Usuario>();
            using ( IContextoProceso contexto = new ContextoProceso( HelperTestSistema.ObjectFactory ) )
            {
                perfilesBD = (from Perfil p in contexto.ContenedorObjetos select p).ToList();
                usuariosBD = (from Usuario u in contexto.ContenedorObjetos select u).ToList();
            }
            HelperTestSistema.ReiniciarConexion();

            HelperTestSistema.FinalizarServidor();

            //Asserts
            
            //Tiene que haber 2 usuarios en la BD
            Assert.AreEqual( 2, usuariosBD.Count );
            //Tiene que haber 2 perfiles en la BD
            Assert.AreEqual( 2, perfilesBD.Count );
            //El usuario 1 debe tener asociado el perfil 2
            Assert.AreEqual( "Perfil 2", usuariosBD[0].Perfil.Nombre );
            Assert.AreSame( perfilesBD[1], usuariosBD[0].Perfil );

        }

        [TestMethod]
        public void UsuariosController_EliminarUsuario()
        {

            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

           


            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "" );
        }


        [TestMethod]
        public void UsuariosController_ListarUsuariosDeUnProyecto()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            HelperTestSistema.FinalizarServidor();

            //Asserts
            Assert.Inconclusive( "Terminar este test cuando pensemos bien la implementacion de usuarios asociados a un proyecto" );
        }
    }
}
