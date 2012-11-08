using System;
namespace Bugzzinga.Model.Business
{
    public interface IUsuario
    {
        void AgregarPerfil(Perfil perfil);
        string Apellido { get; set; }
        string Email { get; set; }
        string LoginName { get; set; }
        string Nombre { get; set; }
        System.Collections.Generic.IEnumerable<Perfil> Perfiles { get; }
        void QuitarPerfil(Perfil perfil);
    }
}
