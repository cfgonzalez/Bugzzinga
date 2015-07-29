using System;
using System.Collections.Generic;
using System.Linq;
using Bugzzinga.Core;
using Bugzzinga.Core.Atributos;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    [Persisted]
    public  class Bugtracker:IBugtracker
    {

        private ArrayList4<Proyecto> _proyectos;
        private ArrayList4<Usuario> _usuarios;
        private ArrayList4<Rol> _roles;
        private ArrayList4<PlantillaProyecto> _plantillas;    
        
        public Bugtracker()
        {
            this._proyectos = new ArrayList4<Proyecto>();
            this._usuarios = new ArrayList4<Usuario>();
            this._roles = new ArrayList4<Rol>();
            this._plantillas = new ArrayList4<PlantillaProyecto>();
        }


        public IEnumerable<Proyecto> Proyectos { get { return this._proyectos; } }
        public IEnumerable<Usuario> Usuarios { get { return this._usuarios; } }
        public IEnumerable<Rol> Roles { get { return this._roles; } }
        public IEnumerable<PlantillaProyecto> Plantillas { get { return this._plantillas; } }
        
        public Proyecto NuevoProyecto()
        {
            return new Proyecto();
        }


        public void AgregarProyecto(Proyecto proyecto)
        {
            if(this.ObtenerProyecto(proyecto.Nombre) == null)
            {
                this._proyectos.Add(proyecto);
            }
            else
            {
                string mensaje = String.Format("Ya existe un proyecto registrado con el nombre {0}. No se puede regsitrar el proyecto.", proyecto.Nombre);
                throw new BugzzingaException(mensaje);
            }
        }

        public Proyecto ObtenerProyectoPorCodigo( string codigoProyecto )
        {
            return this.Proyectos.Where( x => x.Codigo.Equals( codigoProyecto, StringComparison.InvariantCultureIgnoreCase ) ).SingleOrDefault();
        }

        public Proyecto ObtenerProyecto(string nombreProyecto)
        {
            return this.Proyectos.Where(x => x.Nombre.ToUpper() == nombreProyecto.ToUpper()).SingleOrDefault();
        }


        public Usuario NuevoUsuario()
        {
            return new Usuario();
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBugtracker Members


     
        #endregion

        #region IBugtracker Members


        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
