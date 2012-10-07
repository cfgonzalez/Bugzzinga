using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Bugzzinga.Model.Entities;
using Data.DB4o.Repository;
using Services.Exceptions;

namespace Bugzzinga.Data
{
    public class DMPrioridadTarea : DataMapper<PrioridadTarea>
    {

        public DMPrioridadTarea(IRepositorio repositorio, IServicioExcepcionesPersistencia servicioExcepciones)
            : base(repositorio, servicioExcepciones)
        {

        }
    }
}
