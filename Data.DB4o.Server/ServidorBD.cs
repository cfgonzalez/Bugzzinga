using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Db4objects.Db4o;

namespace Data.DB4o.Server
{

    public  class ServidorBD
    {
        /// <summary>
        /// Representa la instancia del servidor de base de datos.
        /// </summary>
        private static IObjectServer _servidor = null;
        private static readonly ServidorBD _instancia = new ServidorBD();


        public static ServidorBD Instancia()
        {
            return _instancia;
        }

        /// <summary>
        /// Inicia al servidor de base de datos.
        /// </summary>
        /// <param name="configuracion">Configuración a utilizar para iniciar el servidor.
        /// </param>
        public  void IniciarServidor(ConfiguracionServidorBD configuracion)
        {

            _servidor = Db4oFactory.OpenServer(configuracion.Bd, configuracion.Puerto);
        }
        /// <summary>
        /// Finaliza el servidor de base de datos.
        /// </summary>
        public  void FinalizarServidor()
        {
            _servidor.Close();
        }
        /// <summary>
        /// Crea una y retorna nueva conexión al servidor de base de datos.
        /// </summary>
        public  IObjectContainer CrearConexion()
        {
            return _servidor.OpenClient();
        }
        /// <summary>
        /// Elimina una conexión al servidor de base de datos.
        /// </summary>
        /// <param name="pCliente"></param>
        public  void EliminarConexion(IObjectContainer pCliente)
        {
            pCliente.Close();
        }
    }
 
}
