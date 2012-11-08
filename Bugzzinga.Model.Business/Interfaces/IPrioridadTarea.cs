using System;
namespace Bugzzinga.Model.Business
{
    public interface IPrioridadTarea
    {
        string Denominacion { get; set; }
        string Descripcion { get; set; }
        int Orden { get; set; }
        string PathIcono { get; set; }
    }
}
