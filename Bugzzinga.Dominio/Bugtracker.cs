using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Core;
using Db4objects.Db4o.Collections;

namespace Bugzzinga.Dominio
{
    public  class Bugtracker: IBugtracker
    {

        private ArrayList4<IProyecto> _proyectos;
        private ArrayList4<IUsuario> _usuarios;     
        
        public Bugtracker()
        {
            this._proyectos = new ArrayList4<IProyecto>();
            this._usuarios = new ArrayList4<IUsuario>();
        }


        public IEnumerable<IProyecto> Proyectos { get { return this._proyectos; } }
        public IEnumerable<IUsuario> Usuarios { get { return this._usuarios; } }
        
        public IProyecto NuevoProyecto()
        {
            return new Proyecto();
        }


        public void RegistrarProyecto(IProyecto proyecto)
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


        public IProyecto ObtenerProyecto(string nombreProyecto)
        {
            return this.Proyectos.Where(x => x.Nombre.ToUpper() == nombreProyecto.ToUpper()).SingleOrDefault();
        }


        public IUsuario NuevoUsuario()
        {
            return new Usuario();
        }
    }
}
