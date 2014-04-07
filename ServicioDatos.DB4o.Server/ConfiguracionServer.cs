using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioDatos.DB4o.Server
{
    /// <summary>
    /// contiene los parámetros de configuración para el servidor de base de datos.
    /// </summary>
    public class ConfiguracionServer
    {
        /// <summary>
        /// Nombre del host en el que se encuentra el servidor de base de datos.
        /// </summary>
        public string NombreHost { get; set; }
        /// <summary>
        /// Nombre del directorio donde se encuentra el archivo de la base de datos
        /// </summary>
        public string RutaArchivos { get; set; }

        /// <summary>
        /// Nombre de la base de datos a utilizar.
        /// </summary>
        public string NombreArchivoBD { get; set; }
        /// <summary>
        /// Puerto del servidor de base de datos
        /// </summary>
        public int Puerto { get; set; }
        /// <summary>
        /// Nombre del usuario a utilizar para la conexión.
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Contraseña del usuario que se conecta al servidor.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Indica si la persistencia transparente se encuentra habilitada
        /// </summary>
        public bool PersistenciaTransparente { get; set; }


        /// <summary>
        /// Indica si la activación transparente se encuentra habilitada
        /// </summary>
        public bool ActivacionTransparente { get; set; }

    }
}
