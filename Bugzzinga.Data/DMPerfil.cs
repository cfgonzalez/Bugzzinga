﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;

using Data.DB4o.Repository;

using Services.Exceptions;

namespace Bugzzinga.Data
{
    public interface IDMPerfil : IDataMapper<Perfil>
    { 
    }

    public class DMPerfil:DataMapper<Perfil>,IDMPerfil 
    {
        public DMPerfil(IRepositorio repositorio, IServicioExcepcionesPersistencia servicioExcepciones) :
            base(repositorio, servicioExcepciones)
        { 
        }

    }
}
