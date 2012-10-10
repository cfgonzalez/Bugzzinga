using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Data.DB4o.Common;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Data.Querys
{
    public class QueryTareasPorTipoTarea:QueryDB4o<IEnumerable<Tarea>>
    {
        private TipoTarea  _tipoTarea;

        public QueryTareasPorTipoTarea(TipoTarea tipoTarea)
        {
            _tipoTarea = tipoTarea;
        }

        public override IEnumerable<Tarea> Ejecutar(Db4objects.Db4o.IObjectContainer pBD)
        {
            IEnumerable<Tarea> resultado =
                from Tarea t in pBD
                where t.TipoTarea.Denominacion == _tipoTarea.Denominacion 
                select t;

                return resultado;
        }
    }
}
