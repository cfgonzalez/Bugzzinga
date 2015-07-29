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
        private IBugtracker _bugtracker;

        public BugTrackerPersistente() {}

        public BugTrackerPersistente(IFactory objectFactory)
        {
            this.objectFactory = objectFactory;
        }

        private IObjectContainer ContenedorObjetos
        {
            get
            {
                IContextoProceso contextoProceso = objectFactory.Create<IContextoProceso>();
                return contextoProceso.ContenedorObjetos;
            }
        }

        private IBugtracker Bugtracker
        {   
            get
            {
                if ( this._bugtracker == null )
                {
                    this._bugtracker =  (IBugtracker)(from Bugtracker b in this.ContenedorObjetos select b).SingleOrDefault();
                }

                if ( this._bugtracker == null )
                {
                    this._bugtracker = new Bugtracker();
                    this.ContenedorObjetos.Store( this._bugtracker );
                }

                return this._bugtracker;                         
            }
        }


        #region "Proyectos"        

        public Proyecto NuevoProyecto()
        {
            return new Proyecto();
        }

        public void AgregarProyecto( Proyecto proyecto )
        {
            IBugtracker bugtracker = this.Bugtracker;
            bugtracker.AgregarProyecto( proyecto );            
        }
               

        public IEnumerable<Proyecto> Proyectos
        {
            get 
            {
                IBugtracker bugtracker = this.Bugtracker;
                this.ContenedorObjetos.Ext().Activate( bugtracker, 3 );
                return bugtracker.Proyectos.ToList();                
            }
        }

        public Proyecto ObtenerProyectoPorCodigo( string codigoProyecto )
        {
            return this.Bugtracker.ObtenerProyectoPorCodigo( codigoProyecto );
          
        }

        public Proyecto ObtenerProyecto( string nombreProyecto )
        {
            //Proyecto proyecto = (from Proyecto p in this.ContenedorObjetos
            //                        where p.Nombre.ToUpper() == nombreProyecto.ToUpper()
            //                        select p).SingleOrDefault();
            //return proyecto;
            throw new NotImplementedException();
        }

        #endregion

        #region "Usuarios"


        public Usuario NuevoUsuario()
        {
            return new Usuario();
        }

        public void AgregarUsuario( Usuario usuario )
        {
            //this._administradorUsuarios.RegistrarNuevo( usuario );
        }

        public void ModificarUsuario( Usuario usuario )
        {
           // this._administradorUsuarios.Modificar( usuario );
        }


        public IEnumerable<Usuario> Usuarios
        {
            get 
            {
                return null;
               // return this._administradorUsuarios.ListarTodos();
            }
        }



        public Usuario ObtenerUsuario( string nombreUsuario )
        {
            //Usuario usuario = (from Usuario u in this.ContenedorObjetos
            //                    where u.Nombre.ToUpper() == nombreUsuario.ToUpper()
            //                    select u).SingleOrDefault();
            //return usuario;
            throw new NotImplementedException();
        }

        #endregion

        #region "Perfiles"

        public Rol NuevoRol()
        {
            return null;
            
        }

        public void AgregarRol( Rol perfil)
        {
            
        }

        public void ModificarPerfil( Rol perfil )
        {
         
        }

        public IEnumerable<Rol> Roles 
        {
            get
            {
                return null;
               // return this._administradorPerfiles.ListarTodos();
            }
        }

        public Rol ObtenerRol(string nombrePerfil)
        {
            return null;
            //return this._administradorPerfiles.ObtenerPorNombre( nombrePerfil );
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

            this.ContenedorObjetos.Close();
        }        

    }
}
