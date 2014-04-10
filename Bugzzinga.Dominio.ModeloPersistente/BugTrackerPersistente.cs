using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;

namespace Bugzzinga.Dominio.ModeloPersistente
{
    public class BugTrackerPersistente: IBugtracker
    {

        private IObjectContainer ContenedorObjetos
        {
            get
            {
                IContextoProceso contextoProceso = ObjectFactory.GetInstance<IContextoProceso>();
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
            return new Perfil();
        }

        public void RegistrarPerfil( Perfil perfil)
        {
            this.ContenedorObjetos.Store( perfil );
            this.ContenedorObjetos.Commit();
        }

        public IEnumerable<Perfil> Perfiles 
        { 
            get 
            {
                return (from Perfil p in this.ContenedorObjetos select p).ToList<Perfil>();
            }
        }

        public Perfil ObtenerPerfil(string nombrePerfil)
        {
            Perfil perfil = (from Perfil p in this.ContenedorObjetos 
                                    where p.Nombre.ToUpper() == nombrePerfil.ToUpper()
                                    select p).SingleOrDefault();
            return perfil;
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
