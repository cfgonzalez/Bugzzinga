using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Data.DB4o.Common;
using Data.DB4o.Repository;
using Services.Exceptions;

namespace Bugzzinga.Data
{
    public class DataMapper<Entidad> : Bugzzinga.Data.IDataMapper<Entidad>
    {

        IRepositorio _repositorio;
        IServicioExcepcionesPersistencia _servicioExcepciones;

        public DataMapper(IRepositorio repositorio, IServicioExcepcionesPersistencia servicioExcepciones)
        {
            _repositorio = repositorio;
            _servicioExcepciones = servicioExcepciones;
        }

        public void Registrar(Entidad entidad)
        {
            _repositorio.Registrar(entidad);
        }

        public void Modificar(Entidad entidad)
        {

            _repositorio.Modificar(entidad);

        }

        public void Eliminar(Entidad entidad)
        {

            _repositorio.Eliminar(entidad);
        }

        public IList<Entidad> ListarTodos()
        {
            return _repositorio.ListarTodos<Entidad>().ToList();                        
        }
    }
}
