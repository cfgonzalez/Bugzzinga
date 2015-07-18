using System;
using Bugzzinga.Dominio;
using Db4objects.Db4o.CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using System.Linq;
using Buggzzinga.IntegrationTest.Helpers;

namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class DB4oTest
    {
        [TestMethod]
        public void TestUpdateDepth()
        {

            System.IO.File.Delete( @"c:\temp\bugzzinga\BDTest.yap" );

            var db4oConfig =  Db4oClientServer.NewServerConfiguration();

            //db4oConfig.Common.ObjectClass( typeof( Proyecto )).UpdateDepth(10);
            //db4oConfig.Common.ObjectClass( typeof( Proyecto ).FullName ).CascadeOnUpdate( true );
            //db4oConfig.Common.UpdateDepth = 10;
            
            var servidor = Db4oClientServer.OpenServer( db4oConfig, @"c:\temp\bugzzinga\BDTest.yap", 0 );
            //-----------------------------------------------------------------------------------------
            var db = servidor.OpenClient();

            Proyecto proyecto = new Proyecto();

            proyecto.Codigo = "P1";
            proyecto.Nombre = "Proyecto de prueba";

            var tiposItem =  HelperInstanciacionItems.GetTiposDeItem( "Proyecto de prueba", 2 );
            
            foreach ( var item in tiposItem )
            {
                proyecto.AgregarTipoDeItem( item );
            }

            db.Store( proyecto );
            db.Close();
            //-----------------------------------------------------------------------------------------
            
            db = servidor.OpenClient();

            proyecto = null;
            var proyectoTest = (from Proyecto p in db select p).ToList()[0];
            tiposItem = null;
            var tipoItem = HelperInstanciacionItems.GetTiposDeItem( "Proyecto de prueba", 3 ).ToList()[2];
            proyectoTest.AgregarTipoDeItem( tipoItem );

            db.Store( proyectoTest );

            db.Close();
            
            //-----------------------------------------------------------------------------------------

            db = servidor.OpenClient();

            proyectoTest = null;
            var proyectoTest2 = (from Proyecto p in db select p).ToList()[0];


            db.Close();

            //-----------------------------------------------------------------------------------------

            servidor.Close();

        }
    }
}

