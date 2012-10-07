using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class ErroresValidacion
    {
        private List<string> _errores;


        public ErroresValidacion()
        {
            _errores = new List<string>();
        }

        public void Agregar(string error)
        {
            _errores.Add(error);
        }
        
        public IEnumerable<string> GetErrores()
        {
            return (IEnumerable<string>)_errores;
        }

        public bool HayErrores()
        {
            if (_errores.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
