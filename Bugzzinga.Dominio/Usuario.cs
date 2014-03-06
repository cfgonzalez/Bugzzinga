using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio
{
    public class Usuario:IUsuario
    {
        public Usuario()
        { 
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public IPerfil Perfil { get; set; }
    }
}
