using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Services.Exceptions;

namespace Services.Exceptions
{
    public class GestorExcepcionesNulo:IServicioExcepciones,IServicioExcepcionesDominio,IServicioExcepcionesPersistencia 
    {
        public void GestionarExcepcion(Exception ex)
        {
            throw ex;
        }
    }
}
