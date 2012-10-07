using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
