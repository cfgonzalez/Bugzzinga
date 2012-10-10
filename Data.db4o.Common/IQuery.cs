using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Db4objects.Db4o;

namespace Data.DB4o.Common
{
    public interface IQuery<T>
    {
        T Ejecutar(IObjectContainer pBD);
    }
}
