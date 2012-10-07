using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Security
{
    public class ContextoSeguridadDesktop:IContextoSeguridad 
    {
        private string _nombreUsuarioActual;
        
        public string NombreUsuarioActual
        {
            get
            {
                return _nombreUsuarioActual;
            }
            set
            {
                _nombreUsuarioActual = value;
            }
        }
    }
}
