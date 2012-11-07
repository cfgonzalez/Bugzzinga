using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;

using Bugzzinga.Data;
using Services.Security;
using Services.Exceptions;


namespace Bugzzinga.Model.Business
{


    public interface IGestorPrioridadesTarea : IGestorABM<PrioridadTarea>
    { 
    
    }

    public class GestorPrioridadesTarea : GestorABM<PrioridadTarea>, IGestorPrioridadesTarea
    {
        public GestorPrioridadesTarea(IDMPrioridadTarea dataMapper, IServicioExcepcionesDominio gestorExcepciones, IServicioAutorizacion servicioAutorizacion, IContextoSeguridad contextoSeguridad)
            : base(dataMapper,  gestorExcepciones,  servicioAutorizacion,  contextoSeguridad)
        { 
        
        }



        protected override void ValidarDatosGenerales(PrioridadTarea entidad)
        {
            ErroresValidacion errores = new ErroresValidacion();

            if (entidad.Denominacion == string.Empty)
            {
                errores.Agregar("El campo Denominacion no puede quedar vacio");
            }

            if (errores.HayErrores())
            {
                throw new DominioException("Errores de validacion en la prioridad de la tarea", errores);
            }


            //TO DO: Validar que el orden de la tarea sea único
        }

        protected override void ValidarBaja(PrioridadTarea entidad)
        {
            //TO DO: validar que ninguna tarea tenga asignada esta prioridad
        }


    }
}
