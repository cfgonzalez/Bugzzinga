using Bugzzinga.Persistencia.Interfaces;
using Db4objects.Db4o;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Persistencia
{
    public class Repositorio : IDisposable, IRepositorio
    {

        protected string _pathArchivo = string.Empty;
        protected IObjectContainer _contenedor = null;

        public Repositorio(string pathArchivo)
        {
            this._pathArchivo = pathArchivo;
        }

        public IObjectContainer ContenedorObjetos
        {
            get
            {
                return ObtenerContenedor();
            }
        }

        protected IObjectContainer ObtenerContenedor()
        {

            if (this._contenedor == null)
            {
                this._contenedor = Db4oFactory.OpenFile(this._pathArchivo);
            }

            return this._contenedor;
        }


        public void Dispose()
        {
            if (this._contenedor != null)
            {
                this._contenedor.Close();
                this._contenedor = null;
            }
        }
    }
}
