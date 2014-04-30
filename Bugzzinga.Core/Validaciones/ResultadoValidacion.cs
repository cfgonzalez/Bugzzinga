using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Intefaces;

namespace Bugzzinga.Core.Validaciones
{
    public class ResultadoValidacion: IResultadoValidacion
    {
        private List<ErrorValidacion> _erroresValidacion = new List<ErrorValidacion>();

        public bool Ok 
        { 
            get 
            {
                if ( this._erroresValidacion.Count == 0 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }

        public IEnumerable<ErrorValidacion> ErroresValidacion { get { return this._erroresValidacion; } }

        public void AgregarError( string mensajeError )
        {
            this._erroresValidacion.Add( new ErrorValidacion(mensajeError) );
        }
    }
}
