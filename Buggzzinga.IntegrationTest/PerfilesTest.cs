using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Buggzzinga.IntegrationTest.Helpers;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Core;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;


namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class PerfilesTest
    {
      
        [TestMethod]
        public void Test_AltaPerfilDuplicado()
        {
            HelperTestSistema.LimpiarArchivoBD();
            HelperTestSistema.IniciarServidor();

            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.NuevoPerfil();
                p1.Nombre = "Perfil1";
                p1.Descripcion = "perfil de prueba";

                bugzzinga.RegistrarPerfil( p1 );
            }           

        
             using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                Perfil p1 = bugzzinga.NuevoPerfil();
                p1.Nombre = "Perfil1";
                p1.Descripcion = "perfil de prueba";

                bugzzinga.RegistrarPerfil( p1 );
            }

            HelperTestSistema.FinalizarServidor();
        }        
    }
}
