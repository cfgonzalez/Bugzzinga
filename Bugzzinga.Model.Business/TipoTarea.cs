using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class TipoTarea : Bugzzinga.Model.Business.ITipoTarea
    {
        
        /// <summary>
        /// Denominación con la que se identifica al tipo de tarea
        /// </summary>
        public string Denominacion { get; set; }
        /// <summary>
        /// Descripción del tipo de tarea
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Path del icono que se utiliza para identificar al tipo de tarea
        /// </summary>
        public string PathIcono { get; set; }

    }
}
