using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Persistencia.Interfaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.ModeloPersistente
{
    public class BugtrackerPersistente: DecoradorPersistente, IBugtracker
    {

        private readonly IBugtracker _inner;
       

        public BugtrackerPersistente(IBugtracker inner)
        {
            this._inner = inner;
        }

        public IEnumerable<IProyecto> Proyectos
        {
            get 
            {
                return this._inner.Proyectos;
            }
        }

        public IEnumerable<IUsuario> Usuarios
        {
            get { throw new NotImplementedException(); }
        }

        public IProyecto NuevoProyecto()
        {
            return this._inner.NuevoProyecto();
        }

        public void RegistrarProyecto(IProyecto proyecto)
        {        
            this._inner.RegistrarProyecto(proyecto);

            if(this.ObtenerProyecto(proyecto.Nombre) == null)
            {
                this.BD.Store(proyecto);
                this.BD.Commit();       
            }
                             
        }

        public IProyecto ObtenerProyecto(string nombreProyecto)
        {
            var proyecto = (from IProyecto p in this.BD
                             where p.Nombre.ToUpper() == nombreProyecto.ToUpper()
                             select p).SingleOrDefault();

            return proyecto;
        }

        public IUsuario NuevoUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
