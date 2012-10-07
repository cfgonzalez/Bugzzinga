using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public interface IServicioExcepciones
    {
        void GestionarExcepcion(Exception ex);
    }
}
