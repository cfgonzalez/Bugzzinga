using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Security
{
    public interface IServicioAutorizacion
    {
        bool AutorizacionAccion(string usuario, eAcciones accion);
    }
}
