using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StructureMap;

using Bugzzinga.Model.Business;

namespace Bugzzinga.EjemplosDominio
{
    public class Dominio
    {

        private static readonly  Dominio _instancia  = new Dominio();               

        /// <summary>
        /// Se oculta el constructor para que solamente pueda ser utilizada a traves del metodo singleton.
        /// </summary>
        private Dominio()
        {
                       
        }

        public static Dominio Instancia()
        {
            return _instancia;
        }

        public IGestorTiposDetarea GestorTiposDeTarea()
        {
            return ObjectFactory.GetInstance<IGestorTiposDetarea>();
        }

        public IGestorPrioridadesTarea GestorPrioridadesTarea()
        {
            return ObjectFactory.GetInstance<IGestorPrioridadesTarea>();
        }

        public IGestorPerfiles GestorPerfiles()
        {
            return ObjectFactory.GetInstance<IGestorPerfiles>();
        }

        public IGestorUsuarios GestorUsuarios()
        {
            return ObjectFactory.GetInstance<IGestorUsuarios>();
        }
    }
}
