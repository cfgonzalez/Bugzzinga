﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public interface IServicioExcepcionesPersistencia
    {
        void GestionarExcepcion(Exception ex);
    }
}
