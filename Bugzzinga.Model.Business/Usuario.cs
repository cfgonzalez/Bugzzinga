using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Services.Exceptions;

namespace Bugzzinga.Model.Business
{
    public class Usuario : Bugzzinga.Model.Business.IUsuario
    {
        public string LoginName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        private IList<Perfil> _perfiles = new List<Perfil>();

        public void AgregarPerfil(Perfil perfil)
        {
            // Solamente lo agrego si no estaba asignado
            if (!_perfiles.Contains(perfil)) 
            {
                _perfiles.Add(perfil);
            }
        }

        public void QuitarPerfil(Perfil perfil)
        {
            _perfiles.Remove(perfil);
        }

        public IEnumerable<Perfil> Perfiles
        { 

            get
            {
                return (IEnumerable<Perfil>)_perfiles;
            }
            
        }

    }
}
