using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class MiembroProyecto
    {

        public MiembroProyecto()
        {

        }

        public MiembroProyecto(Usuario usuario, Rol rol)
        {
            this.Usuario = usuario;
            this.Rol = rol;
        }

        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
    }
}
