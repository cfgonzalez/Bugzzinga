using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.ModeloPersistente.Interfaces
{
    internal interface IAdministradorEntidad<Entidad>
    {

        Entidad Nuevo();

        void RegistrarNuevo(Entidad entidad);

        List<Entidad> ListarTodos();

        Entidad ObtenerPorNombre(string nombre);
    }
}
