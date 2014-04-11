using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Validaciones;

namespace Bugzzinga.Core.Intefaces
{
    public interface IResultadoValidacion
    {
        void AgregarError( string mensajeError );
        IEnumerable<ErrorValidacion> ErroresValidacion { get; }
        bool Ok { get; }
    }
}
