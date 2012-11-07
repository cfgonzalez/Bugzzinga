using System;
namespace Bugzzinga.Model.Business
{
    interface IEstadoTarea
    {
        void AgregarProximoEstado(EstadoTarea estado);
        string Denominacion { get; set; }
        string Descripcion { get; set; }
        string PathIcono { get; set; }
        System.Collections.Generic.IEnumerable<EstadoTarea> ProximosEstados { get; }
        void QuitarProximoEstado(EstadoTarea estado);
    }
}