using System;
using Bugzzinga.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Collections.Generic;

namespace Buggzzinga.IntegrationTest
{
    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            Proyecto entidadDto = new Proyecto();

            List<string> referencias = new List<string>();

            Type tipoObjeto = entidadDto.GetType();

            foreach ( var propiedad in tipoObjeto.GetProperties() )
            {
                if ( propiedad.PropertyType.FullName.StartsWith( "System.Collections.Generic.IEnumerable`1" ) &&
                        propiedad.PropertyType.IsGenericType == true )
                {
                    if ( propiedad.PropertyType.GenericTypeArguments[0].FullName.StartsWith( "Bugzzinga.Dominio" ) )
                    {
                        referencias.Add( propiedad.Name );
                    }
                }                            
            }

            //return referencias;
        }
    }
}
