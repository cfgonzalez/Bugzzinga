using Data.DB4o.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.DB4o.Common;

using Services.Exceptions;
using Data.DB4o.Server;

namespace Data.DB4o.Test
{
    
    
    /// <summary>
    ///This is a test class for RepositorioTest and is intended
    ///to contain all RepositorioTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositorioTest
    {

        private ServidorBD _servidor = ServidorBD.Instancia();
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {


        }
        
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
        ///A test for Repositorio Constructor
        ///</summary>
        [TestMethod()]
        public void RepositorioConstructorTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CancelarTransaccion
        ///</summary>
        [TestMethod()]
        public void CancelarTransaccionTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            target.CancelarTransaccion();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Conectar
        ///</summary>
        [TestMethod()]
        public void ConectarTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            target.Conectar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ConfigurarEntidadesPersistentes
        ///</summary>
        [TestMethod()]
        public void ConfigurarEntidadesPersistentesTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades1 = null; // TODO: Initialize to an appropriate value
            target.ConfigurarEntidadesPersistentes(configuracionEntidades1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Desconectar
        ///</summary>
        [TestMethod()]
        public void DesconectarTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            target.Desconectar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Ejecutar
        ///</summary>
        [TestMethod()]
        public void EjecutarTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            IQuery pQuery = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.Ejecutar(pQuery);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Eliminar
        ///</summary>
        [TestMethod()]
        public void EliminarTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            object pObjeto = null; // TODO: Initialize to an appropriate value
            target.Eliminar(pObjeto);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EliminarInstancia
        ///</summary>
        [TestMethod()]
        public void EliminarInstanciaTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            target.EliminarInstancia();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FinalizarTransaccion
        ///</summary>
        [TestMethod()]
        public void FinalizarTransaccionTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            target.FinalizarTransaccion();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetId
        ///</summary>
        [TestMethod()]
        public void GetIdTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            object pObjeto = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.GetId(pObjeto);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modificar
        ///</summary>
        [TestMethod()]
        public void ModificarTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            object pObjeto = null; // TODO: Initialize to an appropriate value
            target.Modificar(pObjeto);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RefrescarInstancia
        ///</summary>
        [TestMethod()]
        public void RefrescarInstanciaTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            object pObjeto = null; // TODO: Initialize to an appropriate value
            int pProfundidad = 0; // TODO: Initialize to an appropriate value
            target.RefrescarInstancia(pObjeto, pProfundidad);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Registrar
        ///</summary>
        [TestMethod()]
        public void RegistrarTest()
        {
            IContextoContenedor contexto = null; // TODO: Initialize to an appropriate value
            IConfiguracionEntidadesPersistentes configuracionEntidades = null; // TODO: Initialize to an appropriate value
            IServicioExcepcionesPersistencia gestorExcepciones = null; // TODO: Initialize to an appropriate value
            Repositorio target = new Repositorio(contexto, configuracionEntidades, gestorExcepciones); // TODO: Initialize to an appropriate value
            object pObjeto = null; // TODO: Initialize to an appropriate value
            target.Registrar(pObjeto);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
