using System;
namespace Bugzzinga.Data
{
    public interface IDataMapper<Entidad>
    {
        void Eliminar(Entidad entidad);
        System.Collections.Generic.IList<Entidad> ListarTodos();
        void Modificar(Entidad entidad);
        void Registrar(Entidad entidad);
    }
}
