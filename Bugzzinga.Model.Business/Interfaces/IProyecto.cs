using System;
namespace Bugzzinga.Model.Business
{
    interface IProyecto
    {
        void AgregarIntegrante(Usuario integrante);
        void AgregarVersion(Version version);
        string CodigoProyecto { get; set; }
        string Descripcion { get; set; }
        string FechaInicio { get; set; }
        System.Collections.Generic.IEnumerable<Usuario> Integrantes();
        string Nombre { get; set; }
        string PathIcono { get; set; }
        Usuario Responsable { get; set; }
        System.Collections.Generic.IEnumerable<Version> Versiones();
    }
}
