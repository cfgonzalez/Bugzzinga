using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Security
{
    public interface IContextoSeguridad
    {
         string NombreUsuarioActual { get; set; }
    }
}
