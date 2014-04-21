using Bugzzinga.Dominio.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Atributos;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public class Usuario
    {       
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //public Perfil Perfil { get; set; }
    }
}
