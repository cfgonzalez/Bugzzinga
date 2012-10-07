using Data.DB4o.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Db4objects.Db4o;

namespace Data.DB4o.Test
{
    
    
    /// <summary>
    ///This is a test class for ServidorBDTest and is intended
    ///to contain all ServidorBDTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServidorBDTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{

        //}
        
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ServidorBD Constructor
        ///</summary>
        [TestMethod()]
        public void ServidorBDSingletonTest()
        {
            ServidorBD target = ServidorBD.Instancia();
            ServidorBD target2 = ServidorBD.Instancia();
            
            Assert.AreEqual(target, target2);

        }

        /// <summary>
        ///A test for CrearConexion
        ///</summary>
        [TestMethod()]
        public void CrearyEliminarConexionTest()
        {
            ServidorBD target = ServidorBD.Instancia();
            ConfiguracionServidorBD configuracion = new ConfiguracionServidorBD();
            configuracion.Bd = System.IO.Directory.GetCurrentDirectory() + @"\Test.yap";
            target.IniciarServidor(configuracion);

            IObjectContainer actual;
            actual = target.CrearConexion();

            Assert.IsNotNull(actual);

            target.EliminarConexion(actual);
            target.FinalizarServidor();
        }

    
        /// <summary>
        ///A test for IniciarServidor
        ///</summary>
        [TestMethod()]
        public void IniciaryFinalizarServidorTest()
        {
            ServidorBD target = ServidorBD.Instancia();
            ConfiguracionServidorBD configuracion = new ConfiguracionServidorBD();
            configuracion.Bd = System.IO.Directory.GetCurrentDirectory() + @"\Test.yap";
            
            target.IniciarServidor(configuracion);

            target.FinalizarServidor();
        }

    
    }
}
