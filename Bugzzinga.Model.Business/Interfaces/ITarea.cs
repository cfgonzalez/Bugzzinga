using System;
namespace Bugzzinga.Model.Business
{
    public interface ITarea
    {
        void AgregarArchivoAdjunto(ArchivoAdjunto archivo);
        void AgregarLogTarea(LogTarea log);
        void AgregarSubTarea(Tarea subTarea);
        string CodigoTarea { get; set; }
        string Comentarios { get; set; }
        string Descripcion { get; set; }
        EstadoTarea EstadoActual { get; set; }
        DateTime FechaAlta { get; set; }
        DateTime FechaFinalizacion { get; set; }
        PrioridadTarea Prioridad { get; set; }
        void QuitarArchivoAdjunto(ArchivoAdjunto archivo);
        void QuitarLogTarea(LogTarea log);
        void QuitarSubTarea(Tarea subTarea);
        Usuario Responsable { get; set; }
        System.Collections.Generic.IEnumerable<Tarea> SubTareas { get; }
        TipoTarea TipoTarea { get; set; }
    }
}
