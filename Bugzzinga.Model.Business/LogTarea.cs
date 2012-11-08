using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class LogTarea : Bugzzinga.Model.Business.ILogTarea
    {
        /// <summary>
        /// Fecha en la que se genera el log para la tarea
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Comentarios que el usuario registra en el log
        /// </summary>
        public string Comentarios { get; set; }
      
        /// <summary>
        /// Usuario que genera el log de la tarea
        /// </summary>
        public Usuario Usuiario { get; set; }

        public LogTarea()
        { }

        /// <summary>
        /// Instancia un nuevo log para la tarea
        /// </summary>
        /// <param name="fecha">Fecha del log.</param>
        /// <param name="usuario">Usuario que registra el log.</param>
        /// <param name="comentarios">Comentarios registrados en el log.</param>
        public LogTarea( Usuario usuario, string comentarios)
        {
            this.Fecha = DateTime.Now;
            this.Usuiario = usuario;
            this.Comentarios = comentarios;
        }

    }
}
