using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DB4o.Repository
{
    public class ContextoContenedorDesktop : IContextoContenedor
    {

        private  Db4objects.Db4o.IObjectContainer _contenedor;

        public ContextoContenedorDesktop()
        { 
        }

        public Db4objects.Db4o.IObjectContainer GetContenedor()
        {
            return _contenedor;
        }

        public void LiberarContenedor()
        {
            _contenedor.Dispose();
            _contenedor = null;
        }


        public void SetContenedor(Db4objects.Db4o.IObjectContainer contenedor)
        {
            _contenedor = contenedor;
        }
    }
}
