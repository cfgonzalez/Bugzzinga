using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class DominioException : ApplicationException
    {
        private ErroresValidacion _erroresValidacion=null;

        private int _codigo;
        /// <summary>
        /// Constructor predeterminado
        /// </summary>
        public DominioException()
        {
        }

        /// <summary>
        /// Constructor que acepta un mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepción</param>
        public DominioException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor que acepta un mensaje y una excepción que será envuelta dentro
        /// de la excepción creada
        /// </summary>
        /// <param name="message">Mensaje de la excepción</param>
        /// <param name="inner">Excepción a envolver</param>
        public DominioException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public DominioException(string message, ErroresValidacion erroresValidacion):base(message)
        {
            _erroresValidacion = erroresValidacion;
        }

        public DominioException(string message, Exception inner, int codigo)
            : base(message, inner)
        {
            _codigo = codigo;
        }

        public int Codigo { get { return _codigo; } }

        public ErroresValidacion ErroresValidacion
        {
            get
            {
                return _erroresValidacion;
            }
        }

    }
}
