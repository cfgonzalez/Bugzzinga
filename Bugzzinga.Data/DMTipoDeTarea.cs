using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Data.DB4o.Repository;
using Services.Exceptions;

namespace Bugzzinga.Data
{

    public interface IDMTipoTarea:IDataMapper<TipoTarea>
    { 
        
    }


    public class DMTipoDeTarea : DataMapper<TipoTarea>, IDMTipoTarea
    {
        public DMTipoDeTarea(IRepositorio repositorio, IServicioExcepcionesPersistencia servicioExcepciones) :
            base(repositorio, servicioExcepciones)
        { 
        }

    }
}
