using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class Actividad:LogTarea, Bugzzinga.Model.Business.IActividad 
    {
        /// <summary>
        /// Estado en el que se encontraba la tarea al crear el log
        /// </summary>
        public string EstadoTarea { get; set; }
    }
}
