using System;
namespace Bugzzinga.Model.Business
{
    public interface IArchivoAdjunto
    {
        string Descripcion { get; set; }
        string NombreArchivo { get; set; }
        string Path { get; set; }
    }
}
