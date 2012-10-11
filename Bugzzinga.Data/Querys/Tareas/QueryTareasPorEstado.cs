using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Data.DB4o.Common;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Data.Querys
{
    public class QueryTareasPorEstado : QueryDB4o<IList<Tarea>>
    {
        private EstadoTarea _estado;

        public QueryTareasPorEstado(EstadoTarea estado)
        {
            _estado = estado;
        }

        public override IList<Tarea> Ejecutar(Db4objects.Db4o.IObjectContainer pBD)
        {
            IList<Tarea> resultado =
                (from Tarea t in pBD
                where t.EstadoActual.Denominacion == _estado.Denominacion 
                select t).ToList();

                return resultado;
        }
    }
}
