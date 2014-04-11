using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Core.Intefaces
{
    public interface IValidadorEntidad<Entidad>
    {
        IResultadoValidacion Validar(Entidad entidad);
    }
}
