using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Core
{
    public class BugzzingaException:Exception
    {
        public BugzzingaException()
            : base()
        { }

        public BugzzingaException(string message)
            : base(message)
        { }

        public BugzzingaException(string message, Exception inner)
        { 
        }

    }
}
