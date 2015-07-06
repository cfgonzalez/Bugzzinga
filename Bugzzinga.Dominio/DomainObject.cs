using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio
{
    public class DomainObject
    {
        private string _id = Guid.NewGuid().ToString("D").ToUpper();

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    
}
