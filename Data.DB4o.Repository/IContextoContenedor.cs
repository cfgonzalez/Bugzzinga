using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Db4objects.Db4o;

namespace Data.DB4o.Repository
{
    public interface IContextoContenedor
    {

        IObjectContainer GetContenedor();
        void LiberarContenedor();
        void SetContenedor(IObjectContainer contenedor);

    }
}
