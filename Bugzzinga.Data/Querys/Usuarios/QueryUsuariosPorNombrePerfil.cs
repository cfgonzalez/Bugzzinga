using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

using Data.DB4o.Repository;
using Data.DB4o.Common;
using Bugzzinga.Model.Entities;

namespace Bugzzinga.Data.Querys
{
    public class QueryUsuariosPorNombrePerfil : QueryDB4o<IList<Usuario>>
    {

        Perfil _perfil;


        public QueryUsuariosPorNombrePerfil(Perfil perfil)
        {
            _perfil = perfil;
     
        }

        public override IList<Usuario> Ejecutar(IObjectContainer pBD)
        {
            IList<Usuario> resultado =
               (from Usuario u in pBD
               where u.Perfiles.Contains(_perfil)
               select u).ToList();

            return null;
        }

    }
}
