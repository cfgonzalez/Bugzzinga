using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Bugzzinga.Data;

using Services.Exceptions;
using Services.Security;

namespace Bugzzinga.Model.Business
{
    public interface IGestorEstadosTarea : IGestorABM<EstadoTarea>
    {

    }


    public class GestorEstadosTarea:GestorABM<EstadoTarea>, IGestorEstadosTarea
    {

        public GestorEstadosTarea(IDMEstadoTarea dataMapper, IServicioExcepcionesDominio gestorExcepciones, IServicioAutorizacion servicioAutorizacion, IContextoSeguridad contextoSeguridad)
            : base(dataMapper,  gestorExcepciones,  servicioAutorizacion,  contextoSeguridad)
        { 
        
        }

        public void AgregarProximoEstado(EstadoTarea estado, EstadoTarea proximoEstado)
        {
            estado.AgregarProximoEstado(proximoEstado);
            _dataMapper.Modificar(estado);            
        }

        public void QuitarProximoEstado(EstadoTarea estado, EstadoTarea proximoEstadoAQuitar)
        {
            estado.QuitarProximoEstado(proximoEstadoAQuitar);
            _dataMapper.Modificar(estado);
        }
        

        protected override void ValidarBaja(EstadoTarea entidad)
        {
            //TO DO: Validar que ninguna tarea tenga asignado el estado.
            throw new NotImplementedException();
        }

        protected override void ValidarDatosGenerales(EstadoTarea entidad)
        {
            
            //TO DO:
            throw new NotImplementedException();
        }

    }
}
