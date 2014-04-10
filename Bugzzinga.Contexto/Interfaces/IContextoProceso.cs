using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Bugzzinga.Contexto.Interfaces
{
    public interface IContextoProceso: IDisposable
    {
        IObjectContainer ContenedorObjetos{get;}

    }
}
