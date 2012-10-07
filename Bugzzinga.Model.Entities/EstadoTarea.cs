using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Entities
{
    public class EstadoTarea
    {
        /// <summary>
        /// Denominación con la que se identifica al estado de la tarea
        /// </summary>
        public string Denominacion { get; set; }
        /// <summary>
        /// Descripción del estado de la tarea
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Path del icono del estado de la tarea
        /// </summary>
        public string PathIcono { get; set; }

        /// <summary>
        /// Diccionario que almacena los próximos estados válidos
        /// </summary>
        private IDictionary<string, EstadoTarea> _proximosEstados=null;

        /// <summary>
        /// Agrega un proximo estado válido
        /// </summary>
        /// <param name="estado"></param>
        public void AgregarProximoEstado(EstadoTarea estado)
        {
            _proximosEstados.Add(estado.Denominacion, estado);            
        }


        /// <summary>
        /// Quita un próximo estado válido
        /// </summary>
        /// <param name="estado"></param>
        public void QuitarProximoEstado(EstadoTarea estado)
        {
            _proximosEstados.Remove(estado.Denominacion);
        }



    }
}
