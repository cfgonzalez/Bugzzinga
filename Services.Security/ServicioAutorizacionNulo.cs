using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Security
{
    public class ServicioAutorizacionNulo:IServicioAutorizacion 
    {
        public bool AutorizacionAccion(string usuario, eAcciones accion)
        {
            return true;
        }
    }
}
