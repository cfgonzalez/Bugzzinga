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
    public class GestorTiposDeTarea:GestorABM<TipoTarea> 
    {

        public GestorTiposDeTarea(IDMTipoTarea dataMapper, IServicioExcepcionesDominio gestorExcepciones, IServicioAutorizacion servicioAutorizacion, IContextoSeguridad contextoSeguridad)
            : base(dataMapper,  gestorExcepciones,  servicioAutorizacion,  contextoSeguridad)
        { 
        
        }


        protected override void ValidarDatosGenerales(TipoTarea entidad)
        {
            ErroresValidacion errores = new ErroresValidacion();

            if (entidad.Denominacion == string.Empty)
            {
                errores.Agregar("El campo Denominacion no puede quedar vacio");
            }

            if (errores.HayErrores())
            {
                throw new DominioException("Errores de validacion en el tipo de tarea", errores);
            }
        }

        protected override void ValidarBaja(TipoTarea entidad)
        {
            // Hay que validar que no este asignada a ninguna tarea existente.
        }
        
    }
}
