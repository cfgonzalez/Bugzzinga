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
using System.Linq;

namespace Bugzzinga.Dominio.ModeloPersistente
{
    public class BugTrackerPersistente: IBugtracker
    {
        private readonly IFactory objectFactory;

        private IAdministradorEntidad<Perfil> _administradorPerfiles;
        private IAdministradorEntidad<Usuario> _administradorUsuarios;

        public BugTrackerPersistente() {}

        public BugTrackerPersistente(IFactory objectFactory)
        {
            this.objectFactory = objectFactory;

            _administradorPerfiles = this.objectFactory.Create<IAdministradorEntidad<Perfil>>();
            _administradorUsuarios = this.objectFactory.Create<IAdministradorEntidad<Usuario>>();
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

        public void ModificarProyecto( Proyecto proyecto )
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

        public Proyecto ObtenerProyectoPorCodigo( string codigoProyecto )
        {
            Proyecto proyecto = (from Proyecto p in this.ContenedorObjetos
                                 where p.Codigo.ToUpper() == codigoProyecto.ToUpper()
                                 select p).SingleOrDefault();
            return proyecto;
        }

        public Proyecto ObtenerProyecto( string nombreProyecto )
        {
            Proyecto proyecto = (from Proyecto p in this.ContenedorObjetos
                                    where p.Nombre.ToUpper() == nombreProyecto.ToUpper()
                                    select p).SingleOrDefault();
            return proyecto;
        }

        public void QuitarTipoItemDeProyecto( string codigoProyecto, string nombreTipoItem )
        {
            Proyecto proyecto = this.ObtenerProyectoPorCodigo( codigoProyecto );
            TipoItem tipoItem = proyecto.GetTipoItem( nombreTipoItem );

            proyecto.QuitarTipoDeItem( tipoItem );
            
            this.ContenedorObjetos.Delete( tipoItem );
            this.ContenedorObjetos.Store( proyecto );

            this.ContenedorObjetos.Commit();
        }


        #endregion

        #region "Usuarios"


        public Usuario NuevoUsuario()
        {
            return new Usuario();
        }

        public void RegistrarUsuario( Usuario usuario )
        {
            this._administradorUsuarios.RegistrarNuevo( usuario );
        }

        public void ModificarUsuario( Usuario usuario )
        {
            this._administradorUsuarios.Modificar( usuario );
        }


        public IEnumerable<Usuario> Usuarios
        {
            get 
            {
                return this._administradorUsuarios.ListarTodos();
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

        public void ModificarPerfil( Perfil perfil )
        {
           this._administradorPerfiles.Modificar( perfil );
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
            //bool isInException = Marshal.GetExceptionPointers() != IntPtr.Zero || Marshal.GetExceptionCode() != 0;

            //if ( isInException )
            //{
            //    this.ContenedorObjetos.Rollback();
            //}
            //else
            //{
            //    this.ContenedorObjetos.Commit();
            //}

            this.ContenedorObjetos.Close();
        }        

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }     
    }
}
