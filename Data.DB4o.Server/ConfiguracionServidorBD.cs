using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DB4o.Server
{

    /// <summary>
    /// contiene los parámetros de configuración para el servidor de base de datos.
    /// </summary>
    public class ConfiguracionServidorBD
    {
        /// <summary>
		/// Nombre del host en el que se encuentra el servidor de base de datos.
		/// </summary>
        private string _host;
		/// <summary>
		/// Puerto del servidor de base de datos
		/// </summary>
        private int _puerto;
		/// <summary>
		/// Nombre de la base de datos a utilizar.
		/// </summary>
        private string _bd;
		/// <summary>
		/// Nombre del usuario a utilizar para la conexión.
		/// </summary>
        private string _usuario;
		/// <summary>
		/// Contraseña del usuario que se conecta al servidor.
		/// </summary>
        private string _password;

        /// <summary>
        /// Devuelve o establece el nombre del Host
        /// </summary>
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        /// <summary>
        /// Devuelve o establece el nombre de la base de datos
        /// </summary>
        public string Bd
        {
            get { return _bd; }
            set { _bd = value; }
        }

        /// <summary>
        /// Devuelve o establece el puerto
        /// </summary>
        public int Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }

        /// <summary>
        /// devuelve o establece el nombre del usuario
        /// </summary>
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        /// <summary>
        /// Devuelve o establece la contraseña del usuario.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

    }


}
