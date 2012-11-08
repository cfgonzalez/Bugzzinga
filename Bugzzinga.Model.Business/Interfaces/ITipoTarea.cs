using System;
namespace Bugzzinga.Model.Business
{
    public interface ITipoTarea
    {
        string Denominacion { get; set; }
        string Descripcion { get; set; }
        string PathIcono { get; set; }
    }
}
