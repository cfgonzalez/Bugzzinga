using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Security
{
    interface IServicioAutenticacion
    {
        bool AutenticarUsuario(string usuario, string password);
    }
}
