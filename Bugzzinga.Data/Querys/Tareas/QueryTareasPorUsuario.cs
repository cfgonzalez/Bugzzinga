using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Data.DB4o.Common;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Data.Querys
{
    public class QueryTareasPorUsuario:QueryDB4o<IEnumerable<Tarea>>
    {
        private Usuario  _usuario;

        public QueryTareasPorUsuario(Usuario usuario)
        {
            _usuario = usuario;
        }

        public override IEnumerable<Tarea> Ejecutar(Db4objects.Db4o.IObjectContainer pBD)
        {
            IEnumerable<Tarea> resultado =
                from Tarea t in pBD
                where t.Responsable.Nombre == _usuario.Nombre 
                select t;

                return resultado;
        }
    }
}
