using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface IUsuario
    {
        int Codigo { get; }
        string Nombre { get; set; }
        string Apellido { get; set; }

        IPerfil Perfil { get; set; }
    }
}
