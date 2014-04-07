using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using System.Linq;

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

        public IEnumerable<IProyecto> Proyectos
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public IEnumerable<IUsuario> Usuarios
        {
            get { throw new NotImplementedException(); }
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
            IProyecto proyecto = (  from Proyecto p in this._contenedor 
                                    where p.Nombre.ToUpper() == nombreProyecto.ToUpper()
                                    select p).SingleOrDefault();
            return proyecto;
        }

        public IUsuario NuevoUsuario()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this._servidor.FinalizarConexion( this._contenedor );
            this._servidor.Finalizar();
        }

        #endregion
    }
}
