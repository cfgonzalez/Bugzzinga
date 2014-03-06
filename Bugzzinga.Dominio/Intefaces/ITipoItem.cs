using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface ITipoItem
    {
        string Nombre { get;}
        string Descripcion { get; set; }

        IEnumerable<IEstado> EstadosDisponibles { get; }
    }
}
