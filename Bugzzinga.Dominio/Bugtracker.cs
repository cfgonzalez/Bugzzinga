using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Core;

namespace Bugzzinga.Dominio
{
    public  class Bugtracker: IBugtracker
    {

        //public static void NuevoProyecto(Proyecto proyecto)
        //{
        //    IObjectContainer xx = Db4oFactory.OpenFile(@"C:\Desarrollo\TPBDLAP\Bugzzinga\Bugzzinga.yap");

        //    xx.Store(proyecto);
        //    xx.Commit();

        //}

        //public static Proyecto CargarProyecto(int id)
        //{

        //    IObjectContainer xx = Db4oFactory.OpenFile(@"C:\Desarrollo\TPBDLAP\Bugzzinga\Bugzzinga.yap");

        //    var proyecto = (from Proyecto p in xx
        //                    where p.Id == id
        //                    select p).SingleOrDefault();

        //    return proyecto;
        //}

        //public static IList<Proyecto> ListarProyectos()
        //{
        //    return null;
        //}

        private IList<IProyecto> _proyectos;
        private IList<IUsuario> _usuarios;

        public Bugtracker()
        {
            this._proyectos = new List<IProyecto>();
            this._usuarios = new List<IUsuario>();
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
