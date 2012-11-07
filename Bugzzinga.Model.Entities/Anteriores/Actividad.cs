using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Entities
{
    public class Actividad:LogTarea 
    {
        /// <summary>
        /// Estado en el que se encontraba la tarea al crear el log
        /// </summary>
        public string EstadoTarea { get; set; }
    }
}
