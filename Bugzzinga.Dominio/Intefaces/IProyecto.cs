using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface IProyecto
    {
        //IEnumerable<IUsuario> Miembros { get; }
        //IEnumerable<ITipoItem> TiposDeItem { get; }
        //IEnumerable<IItem> Items { get; }


        string Codigo { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }
        DateTime FechaInicio { get; set; }
    }
}
