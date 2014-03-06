using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface IRegistroLog
    {
        DateTime Fecha { get; }
        string Comentarios { get; set; }

        IEstado Estado { get; }
        IUsuario Responsable { get; set; }
    }
}
