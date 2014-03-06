using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface IEstado
    {
        string Descripcion { get; set; }
        string Nombre { get; }
        IEnumerable<Bugzzinga.Dominio.Intefaces.IEstado> ProximosEstadosValidos { get; set; }
    }
}
