using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using Db4objects.Db4o;
using Data.DB4o.Server;

namespace Data.DB4o.Repository
{
    public class ContextoContenedorWeb:IContextoContenedor 
    {
        /// <summary>
        /// Clave para identificar la instancia del contenedor de objetos dentro de las
        /// colecciones.
        /// </summary>
        private const string _claveDb4o = "##InstanciaObjectContainer##";
        
        public Db4objects.Db4o.IObjectContainer GetContenedor()
        {
            IObjectContainer _db = HttpContext.Current.Session[_claveDb4o] as IObjectContainer;;

            if (_db == null)
            {
                _db = ServidorBD.Instancia().CrearConexion();
            }

            return _db;            
        }

        public void LiberarContenedor()
        {
            HttpContext.Current.Session.Remove(_claveDb4o);
        }
    }
}
