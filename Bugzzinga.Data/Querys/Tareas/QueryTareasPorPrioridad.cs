using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Data.DB4o.Common;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Data.Querys
{
    public class QueryTareasPorPrioridad : QueryDB4o<IList<Tarea>>
    {
        private PrioridadTarea  _prioridad;

        public QueryTareasPorPrioridad(PrioridadTarea prioridad)
        {
            _prioridad = prioridad;
        }

        public override IList<Tarea> Ejecutar(Db4objects.Db4o.IObjectContainer pBD)
        {
            IList<Tarea> resultado =
                (from Tarea t in pBD
                where t.Prioridad.Denominacion == _prioridad.Denominacion 
                select t).ToList();

                return resultado;
        }
    }
}
