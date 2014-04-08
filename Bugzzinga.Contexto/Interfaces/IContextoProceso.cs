using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Bugzzinga.Contexto.Interfaces
{
    public interface IContextoProceso
    {
        IDB4oServer ServidorBD { get; }

    }
}
