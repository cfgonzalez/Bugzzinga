using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bugzzinga.Dominio.Intefaces;

namespace Bugzzinga.Dominio.Bugtracker_Tests
{
    /// <summary>
    /// Summary description for Bugtracker_UsusariosTests
    /// </summary>
    [TestClass]
    public class Bugtracker_UsusariosTests
    {
        public Bugtracker_UsusariosTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        /// <summary>
        /// Crea nueva instancia de un usuario
        /// </summary>
        [TestMethod]
        public void Bugtracker_InstanciarNuevoUsuario()
        {
            IBugtracker target = new Bugtracker();

            IUsuario usuario = target.NuevoUsuario();

            bool instanciaCorrecta = usuario.GetType() == typeof(Usuario);
            Assert.IsTrue(instanciaCorrecta);
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Bugtracker_RegistarNuevoUsuario()
        {
            IBugtracker target = new Bugtracker();
            IUsuario usuario = target.NuevoUsuario();

            usuario.Nombre = "nombre 1";
            usuario.Apellido = "apellido 1";
            //usuario.

            Assert.Inconclusive();
        }

        [TestMethod]
        public void Bugtracker_RegistarNuevoUsuario_NombreDuplicado()
        {
            Assert.Inconclusive();
        }


        [TestMethod]
        public void Bugtracker_ListarUsuarios()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Bugtracker_ObtenerUsuarioPorNombre()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Bugtracker_ObtenerUsuarioPorNombre_NoExiste()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Bugtracker_AutenticarUsuario()
        {
            Assert.Inconclusive();
        }
    }
}
