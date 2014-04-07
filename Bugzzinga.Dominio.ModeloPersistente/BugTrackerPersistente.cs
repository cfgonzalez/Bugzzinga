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

        #region IBugtracker Members

        #region "Proyectos"

        public IEnumerable<IProyecto> Proyectos
        {
            get 
            {
                IList<IProyecto> proyectos = (from IProyecto p in this._contenedor select p).ToList<IProyecto>();

                return proyectos;
            }
        }


        public IProyecto NuevoProyecto()
        {
            return new Proyecto();
        }

        public void RegistrarProyecto( IProyecto proyecto )
        {
            this._contenedor.Store( proyecto );
            this._contenedor.Commit();
        }

        public IProyecto ObtenerProyecto( string nombreProyecto )
        {
            IProyecto proyecto = (from IProyecto p in this._contenedor 
                                    where p.Nombre.ToUpper() == nombreProyecto.ToUpper()
                                    select p).SingleOrDefault();
            return proyecto;
        }

        #endregion

        #region "Usuarios"
        public IEnumerable<IUsuario> Usuarios
        {
            get { throw new NotImplementedException(); }
        }

        public IUsuario NuevoUsuario()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this._servidor.FinalizarConexion( this._contenedor );
            this._servidor.Finalizar();
        }

        #endregion

        #region IBugtracker Members


        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
