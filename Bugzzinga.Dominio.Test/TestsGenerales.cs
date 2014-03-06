using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using Bugzzinga.Dominio.Test.TestHelpers;
using Bugzzinga.Dominio.Intefaces;

namespace Bugzzinga.Dominio.Test
{
    /// <summary>
    /// Summary description for EnsayosGenerales
    /// </summary>
    [TestClass]
    public class TestsGenerales
    {
        public TestsGenerales()
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


        [TestInitialize]
        public void TestInitialize()
        {
            ObjectFactory.ResetDefaults();
           
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ObjectFactory.ResetDefaults();           
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

        [TestMethod]
        public void Test_joJOjo()
        {
            ConfiguracionTest.ConfigurarEntornoDeTest();

            IBugtracker bugtracker = ObjectFactory.With<IBugtracker>(new Bugtracker()).GetInstance<IBugtracker>();
            IProyecto proyecto = bugtracker.NuevoProyecto();
            proyecto.Nombre = "Proyecto de prueba 2";
            bugtracker.RegistrarProyecto(proyecto);

        }
    }
}
