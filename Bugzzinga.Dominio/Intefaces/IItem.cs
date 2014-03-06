using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface IItem
    {
        int Codigo { get;  }
        string Nombre { get; set; }
        string Descripcion { get; set; }

        IPrioridad Prioridad { get;  }
        IEnumerable<IRegistroLog> RegistrosLog { get; }
        ITipoItem Tipo { get;  }
        IUsuario Responsable { get;  }
    }
}
