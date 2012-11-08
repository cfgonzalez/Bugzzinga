using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class PrioridadTarea : Bugzzinga.Model.Business.IPrioridadTarea
    {
        /// <summary>
        /// Denominación con la que se identifica a la prioridad de la tarea
        /// </summary>
        public string Denominacion { get; set; }
        /// <summary>
        /// Descripción del tipo de tarea
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Orden que se aplica a la prioridad de la tarea al ordenarla
        /// </summary>
        public int Orden { get; set; }
        /// <summary>
        /// Path del Icono utilizado para la prioridad de la tarea
        /// </summary>
        public string PathIcono { get; set; }
    }
}
