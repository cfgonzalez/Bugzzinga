using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Data.DB4o.Common;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Data.Querys
{
    public class QueryPerfilesPorNombre : QueryDB4o<IList<Perfil>>
    {
        private string _nombre;

        public QueryPerfilesPorNombre(string nombre)
        {
            _nombre = nombre;
        }

        public override IList<Perfil> Ejecutar(Db4objects.Db4o.IObjectContainer pBD)
        {
            IList<Perfil> resultado =
                (from Perfil p in pBD
                where p.Nombre == _nombre
                select p).ToList();

                return resultado;
        }
    }
}
