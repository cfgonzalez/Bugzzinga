using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class Tarea : Bugzzinga.Model.Business.ITarea
    {
        /// <summary>
        /// Código que permite identificar a la tarea de forma única dentro del sistema
        /// </summary>
        public string CodigoTarea { get; set; }
        /// <summary>
        /// fecha en la cual se da de alta la tarea
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Fecha en la que se registra el fin de la tarea
        /// </summary>
        public DateTime FechaFinalizacion { get; set; }
        /// <summary>
        /// Descripción de la tarea
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Comentarios asociados a la tarea
        /// </summary>
        public string Comentarios { get; set; }

        /// <summary>
        /// Tipo de tarea
        /// </summary>
        private TipoTarea _tipoTarea;
        /// <summary>
        /// Prioridad de la tarea
        /// </summary>
        private PrioridadTarea _prioridadTarea;
        /// <summary>
        /// Estado actual en el que se encuentra la tarea
        /// </summary>
        private EstadoTarea _estadoActual;
        /// <summary>
        /// Archivos adjuntos a la tarea
        /// </summary>
        private IList<ArchivoAdjunto> _archivosAdjuntos = new List<ArchivoAdjunto>();
        /// <summary>
        /// Logs relacionados a la tarea
        /// </summary>
        private IList<LogTarea> _logs = new List<LogTarea>();

        private IList<Tarea> _subTareas = new List<Tarea>();

        /// <summary>
        /// Usuario responsable de llevar a cabo la tarea
        /// </summary>
        private Usuario _responsable;
        
        public TipoTarea TipoTarea
        {
            get 
            {
                return _tipoTarea;
            }
            set 
            {
                _tipoTarea = value;
            }        
        }

        public PrioridadTarea Prioridad
        {
            get
            {
                return _prioridadTarea;
            }
            set
            {
                _prioridadTarea = value;
            }
        }

        public EstadoTarea EstadoActual
        {
            get
            {
                return _estadoActual;
            }
            set
            {
                _estadoActual = value;
            }
        
        }

        public Usuario Responsable
        {
            get
            {
                return _responsable;
            }
            set
            {
                _responsable = value;
            }

        }

        public void AgregarArchivoAdjunto(ArchivoAdjunto archivo)
        {
            _archivosAdjuntos.Add(archivo);
        }

        public void QuitarArchivoAdjunto(ArchivoAdjunto archivo)
        {
            _archivosAdjuntos.Remove(archivo);
        }


        public void AgregarLogTarea(LogTarea log)
        {
        
        }

        public void QuitarLogTarea(LogTarea log)
        { 
        
        }


        public void AgregarSubTarea(Tarea subTarea)
        {
            _subTareas.Add(subTarea);
        }

        public void QuitarSubTarea(Tarea subTarea)
        {
            _subTareas.Remove(subTarea);
        }

        public IEnumerable<Tarea> SubTareas
        { 
            get
            {
                return (IEnumerable<Tarea>) _subTareas;
            }
        }

    }
}
