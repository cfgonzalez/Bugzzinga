using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using System.Collections.Generic;
using System.Linq;
using Bugzzinga.Core;

namespace Bugzzinga.Dominio.Bugtracker_Tests
{
    [TestClass]
    public class BugTracker_ProyectosTests
    {      
        /// <summary>
        /// El bugtracker debe retornar una nueva instancia de proyecto
        /// </summary>
        [TestMethod]
        public void Bugtracker_InstanciarNuevoProyecto()
        {
                        
            IBugtracker target = new Bugtracker();

            IProyecto proyecto = target.NuevoProyecto();

            bool instanciaCorrecta = proyecto.GetType() == typeof(Proyecto);

            Assert.IsTrue(instanciaCorrecta);
        }

        /// <summary>
        /// El bugtracker debe agregar un nuevo proyecto al sistema
        /// </summary>
        [TestMethod]
        public void Bugtracker_RegistrarNuevoProyecto()
        {
            IBugtracker target = new Bugtracker();
            IProyecto proyecto = target.NuevoProyecto();
            proyecto.Nombre = "Proyecto test";

            target.RegistrarProyecto(proyecto);
                        
            Assert.AreEqual(((IList<IProyecto>)target.Proyectos).Count, 1);
            Assert.AreSame(proyecto,target.Proyectos.First());            
        }

        /// <summary>
        /// El bugtracker debe lanzar una excepción porque ya existe otro proyecto con el mismo nombre
        /// </summary>
        [TestMethod]
        public void Bugtracker_RegistrarNuevoProyecto_NombreDuplicado()
        {
            BugzzingaException expected = null;

            IBugtracker target = new Bugtracker();

            //Primero arego un proyecto
            IProyecto proyecto1 = target.NuevoProyecto();
            proyecto1.Nombre = "Proyecto test";
            target.RegistrarProyecto(proyecto1);

            //Ahora intento agregar otro proyecto con el mismo nombre
            IProyecto proyecto2 = target.NuevoProyecto();
            proyecto2.Nombre = "Proyecto test";
            
            try
            {
                target.RegistrarProyecto(proyecto2);   
            }
            catch (BugzzingaException ex)
            {
                expected = ex;                
            }

            Assert.IsNotNull(expected);
            Assert.IsTrue(expected.Message.StartsWith("Ya existe un proyecto registrado con el nombre"));
            //No se tiene que haber agregado el segundo proyecto
            Assert.AreEqual(((IList<IProyecto>)target.Proyectos).Count, 1);
        }

        /// <summary>
        /// El bugtracker debe listar todos los proyectos registrados
        /// </summary>
        [TestMethod]
        public void Bugtracker_ListarTodosLosProyectos()
        {
            //Registro dos proyectos
            IBugtracker target = new Bugtracker();

            IProyecto proyecto1 = target.NuevoProyecto();
            proyecto1.Nombre = "Proyecto 1";
            target.RegistrarProyecto(proyecto1);
   
            IProyecto proyecto2 = target.NuevoProyecto();
            proyecto2.Nombre = "Proyecto 2";
            target.RegistrarProyecto(proyecto2);


            Assert.AreEqual(target.Proyectos.Count(),2);
            Assert.IsTrue(target.Proyectos.Contains(proyecto1));
            Assert.IsTrue(target.Proyectos.Contains(proyecto2));            
        }

        /// <summary>
        /// Debe retornar un proyecto registrado basado en su nombre
        /// </summary>
        [TestMethod]
        public void Bugtracker_ObtenerProyectoPorNombre()
        {

            IBugtracker target = new Bugtracker();
            IProyecto proyecto1 = target.NuevoProyecto();
            proyecto1.Nombre = "Proyecto 1";
                        
            IProyecto proyecto2 = target.NuevoProyecto();
            proyecto2.Nombre = "Proyecto 2";

            target.RegistrarProyecto(proyecto1);
            target.RegistrarProyecto(proyecto2);

            IProyecto proyectoRetornado = target.ObtenerProyecto("Proyecto 1");

            Assert.AreSame(proyecto1, proyectoRetornado);
            
        }

        /// <summary>
        /// Debe retornar un proyecto registrado basado en su nombre, debe retornar null ya que el proyecto no existe
        /// </summary>
        [TestMethod]
        public void Bugtracker_ObtenerProyectoPorNombre_NoExiste()
        {
            IBugtracker target = new Bugtracker();
            IProyecto proyecto1 = target.NuevoProyecto();
            proyecto1.Nombre = "Proyecto 1";

            IProyecto proyecto2 = target.NuevoProyecto();
            proyecto2.Nombre = "Proyecto 2";

            target.RegistrarProyecto(proyecto1);
            target.RegistrarProyecto(proyecto2);

            IProyecto proyectoRetornado = target.ObtenerProyecto("Proyecto 3");

            Assert.IsNull (proyectoRetornado);
        }


        /// <summary>
        /// Debe retornar un proyecto en base a su codigo
        /// </summary>
        [TestMethod]
        public void Bugtracker_ObtenerProyectoPorCodigo()
        {
            Assert.Inconclusive();
        }

        //Debe retornar un proyecto en base a su codigo, debe retornar null ya que el proyecto no existe
        [TestMethod]
        public void Bugtracker_ObtenerProyectoPorCodigo_NoExiste()
        {
            Assert.Inconclusive();
        }
       
    }
}
