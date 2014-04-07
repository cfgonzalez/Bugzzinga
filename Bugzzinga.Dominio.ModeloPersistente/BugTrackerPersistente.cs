using System;
using System.Collections.Generic;
using System.Linq;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Bugzzinga.Dominio.ModeloPersistente
{
    public class BugTrackerPersistente: IBugtracker
    {
        private string _directorioBD = String.Concat( AppDomain.CurrentDomain.BaseDirectory, @"\..\..\..\BD\BDTest" );
        private string _nombreBD = "BugzzingaTest.yap";

        private IDB4oServer _servidor;
        private IObjectContainer _contenedor;

        public BugTrackerPersistente()
        {      
            ConfiguracionServer configuracion = new ConfiguracionServer();

            string path = AppDomain.CurrentDomain.BaseDirectory;
            configuracion.RutaArchivos = _directorioBD;
            configuracion.NombreArchivoBD = _nombreBD;
            configuracion.Puerto = 0;
            configuracion.PersistenciaTransparente = true;
            configuracion.ActivacionTransparente = true;

            this._servidor = new DB4oServer();
            this._servidor.Iniciar( configuracion );
            this._contenedor = this._servidor.CrearConexion();
        }

        #region "Proyectos"        

        public Proyecto NuevoProyecto()
        {
            return new Proyecto();
        }

        public void RegistrarProyecto( Proyecto proyecto )
        {
            this._contenedor.Store( proyecto );
            this._contenedor.Commit();
        }

        public IEnumerable<Proyecto> Proyectos
        {
            get 
            {
                return  (from Proyecto p in this._contenedor select p).ToList<Proyecto>();                
            }
        }
        public Proyecto ObtenerProyecto( string nombreProyecto )
        {
            Proyecto proyecto = (from Proyecto p in this._contenedor 
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
            this._contenedor.Store( usuario );
            this._contenedor.Commit();
        }

        public IEnumerable<Usuario> Usuarios
        {
            get 
            {
                return (from Usuario u in this._contenedor select u).ToList<Usuario>();
            }
        }

        public Usuario ObtenerUsuario( string nombreUsuario )
        {
            Usuario usuario = ( from Usuario u in this._contenedor
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
            this._contenedor.Store(perfil);
            this._contenedor.Commit();
        }

        public IEnumerable<Perfil> Perfiles 
        { 
            get 
            {
                return (from Perfil p in this._contenedor select p).ToList<Perfil>();
            }
        }

        public Perfil ObtenerPerfil(string nombrePerfil)
        {
             Perfil perfil = (from Perfil p in this._contenedor 
                                    where p.Nombre.ToUpper() == nombrePerfil.ToUpper()
                                    select p).SingleOrDefault();
            return perfil;
        }

        #endregion
        
        public void Dispose()
        {
            this._servidor.FinalizarConexion( this._contenedor );
            this._servidor.Finalizar();
        }        

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }     
    }
}
