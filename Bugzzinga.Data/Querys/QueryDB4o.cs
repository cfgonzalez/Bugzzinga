using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Data.DB4o.Repository;
using Data.DB4o.Common;
using StructureMap;

namespace Bugzzinga.Data.Querys
{
    public abstract class QueryDB4o<T>:IQuery<T>
    {
        private IRepositorio _repositorio;

        public QueryDB4o()
        {
            _repositorio = ObjectFactory.GetInstance<IRepositorio>();
        }


        public T EjecutarQuery()
        {
            return _repositorio.Ejecutar<T>(this);
        }

        public abstract T Ejecutar(Db4objects.Db4o.IObjectContainer pBD);
    }
}
