using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class ArchivoAdjunto : Bugzzinga.Model.Business.IArchivoAdjunto
    {
        /// <summary>
        /// Descripcion del archivo que se adjunta
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Path donde se encuentra fisicamente el archivo
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        public string NombreArchivo { get; set; }

        public ArchivoAdjunto(string nombreArchivo, string descripcion, string path)
        {
            this.NombreArchivo = nombreArchivo;
            this.Descripcion = descripcion;
            this.Path = path;
        }
    }
}
