using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Entities
{
    public class Proyecto
    {
        public string CodigoProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string PathIcono { get; set; }

        public Usuario Responsable { get; set; }

        private IList<Usuario> _integrantes = null;

        private IList<Version> _versiones = null;


        public void AgregarVersion(Version version)
        {
            if (_versiones == null)
            {
                _versiones = new List<Version>();
            }

            _versiones.Add(version);
        }

        public IEnumerable<Version> Versiones()
        {
            return (IEnumerable<Version>)_versiones;
        }

        public void AgregarIntegrante(Usuario  integrante)
        {
            if (_integrantes == null)
            {
                _integrantes = new List<Usuario>();
            }
            _integrantes.Add(integrante);
        }

        public IEnumerable<Usuario> Integrantes()
        {
            return (IEnumerable<Usuario>) _integrantes;
        }


    }
}
