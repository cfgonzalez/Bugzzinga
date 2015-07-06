using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.ModeloPersistente.Interfaces
{
    public interface IAdministradorEntidad<Entidad>
    {

        Entidad Nuevo();

        void RegistrarNuevo(Entidad entidad);

        void Modificar( Entidad entidad );

        void Eliminar( Entidad entidad );

        List<Entidad> ListarTodos();

        Entidad ObtenerPorNombre(string nombre);
    }
}
