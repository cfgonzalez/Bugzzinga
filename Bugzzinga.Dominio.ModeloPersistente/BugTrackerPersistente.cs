using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente.Interfaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Dominio.ModeloPersistente
{
    public class BugTrackerPersistente: IBugtracker
    {
        private readonly IFactory objectFactory;

        private IAdministradorEntidad<Perfil> _administradorPerfiles;

        public BugTrackerPersistente() {}

        public BugTrackerPersistente(IFactory objectFactory)
        {
            this.objectFactory = objectFactory;

            _administradorPerfiles = this.objectFactory.Create<IAdministradorEntidad<Perfil>>();
        }

        private IObjectContainer ContenedorObjetos
        {
            get
            {
                IContextoProceso contextoProceso = objectFactory.Create<IContextoProceso>();
                return contextoProceso.ContenedorObjetos;
            }
        }

        #region "Proyectos"        

        public Proyecto NuevoProyecto()
        {
            return new Proyecto();
        }

        public void RegistrarProyecto( Proyecto proyecto )
        {
            this.ContenedorObjetos.Store( proyecto );
            this.ContenedorObjetos.Commit();
        }

        public IEnumerable<Proyecto> Proyectos
        {
            get 
            {
                return (from Proyecto p in this.ContenedorObjetos select p).ToList<Proyecto>();                
            }
        }
        public Proyecto ObtenerProyecto( string nombreProyecto )
        {
            Proyecto proyecto = (from Proyecto p in this.ContenedorObjetos
                                    where p.Nombre.ToUpper() == nombreProyecto.ToUpper()
                                    select p).SingleOrDefault();
            return proyecto;
        }

        #endregion

        #region "Usuarios"


        public Usuario NuevoUsuario()
        {
            return new Usuario();
        }

        public void RegistrarUsuario( Usuario usuario )
        {
            this.ContenedorObjetos.Store( usuario );
            this.ContenedorObjetos.Commit();
        }

        public IEnumerable<Usuario> Usuarios
        {
            get 
            {
                return (from Usuario u in this.ContenedorObjetos select u).ToList<Usuario>();
            }
        }

        public Usuario ObtenerUsuario( string nombreUsuario )
        {
            Usuario usuario = (from Usuario u in this.ContenedorObjetos
                                where u.Nombre.ToUpper() == nombreUsuario.ToUpper()
                                select u).SingleOrDefault();
            return usuario;
        }

        #endregion

        #region "Perfiles"

        public Perfil NuevoPerfil()
        {
            return this._administradorPerfiles.Nuevo();
        }

        public void RegistrarPerfil( Perfil perfil)
        {
            this._administradorPerfiles.RegistrarNuevo( perfil );
        }

        public IEnumerable<Perfil> Perfiles 
        {
            get
            {
                return this._administradorPerfiles.ListarTodos();
            }
        }

        public Perfil ObtenerPerfil(string nombrePerfil)
        {
            return this._administradorPerfiles.ObtenerPorNombre( nombrePerfil );
        }

        #endregion
        
        public void Dispose()
        {
            bool isInException = Marshal.GetExceptionPointers() != IntPtr.Zero || Marshal.GetExceptionCode() != 0;

            if ( isInException )
            {
                this.ContenedorObjetos.Rollback();
            }
            else
            {
                this.ContenedorObjetos.Commit();
            }

            //this._contenedor.Close();
        }        

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }     
    }
}
