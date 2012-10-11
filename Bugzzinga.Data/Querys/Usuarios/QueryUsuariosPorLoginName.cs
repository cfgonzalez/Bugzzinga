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
    public class QueryUsuariosPorLoginName : QueryDB4o<IList<Usuario>>
    {

        string _loginName;


        public QueryUsuariosPorLoginName(string loginName)
        {
            _loginName = loginName;
     
        }

        public override IList<Usuario> Ejecutar(IObjectContainer pBD)
        {
            IList<Usuario> resultado =
               (from Usuario u in pBD
               where u.LoginName  == _loginName 
               select u).ToList();

            return resultado;
        }

    }
}
