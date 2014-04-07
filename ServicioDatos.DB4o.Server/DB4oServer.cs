
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.TA;
using ServicioDatos.DB4o.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServicioDatos.DB4o.Server
{
    /// <summary>
    /// Servidor de base de datos.
    /// </summary>
    public class DB4oServer:IDB4oServer
    {

        /// <summary>
        /// Representa la instancia del servidor de base de datos.
        /// </summary>
        private  IObjectServer _servidor = null;

        /// <summary>
        /// Inicia al servidor de base de datos.
        /// </summary>
        /// <param name="configuracion">Configuración a utilizar para iniciar el servidor.
        /// </param>
        public void Iniciar(ConfiguracionServer configuracion)
        {
            string pathBD = Path.Combine(configuracion.RutaArchivos, configuracion.NombreArchivoBD);
            var db4oConfig = Db4oClientServer.NewServerConfiguration();
            
            if(configuracion.ActivacionTransparente)
            {             
                db4oConfig.Common.Add(new TransparentActivationSupport());
            }

            if(configuracion.PersistenciaTransparente)
            {
                db4oConfig.Common.Add(new TransparentPersistenceSupport());
            }

            this._servidor =  Db4oClientServer.OpenServer(db4oConfig, pathBD, 0);            
        }

        /// <summary>
        /// Finaliza el servidor de base de datos.
        /// </summary>
        public void Finalizar()
        {
            _servidor.Close();
        }

        /// <summary>
        /// Crea una y retorna nueva conexión al servidor de base de datos.
        /// </summary>
        public  IObjectContainer CrearConexion()
        {
            return this._servidor.OpenClient();
        }

        /// <summary>
        /// Elimina una conexión al servidor de base de datos.
        /// </summary>
        /// <param name="cliente"></param>
        public void FinalizarConexion(IObjectContainer cliente)
        {
            cliente.Close();
        }

        public void Dispose()
        {
            this.Finalizar();
        }
    }
}
