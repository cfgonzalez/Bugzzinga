using Bugzzinga.Contexto.Interfaces;
using Db4objects.Db4o;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;

namespace Bugzzinga.Contexto
{
    public class ContextoProcesoDesktop:IContextoProceso
    {        
        private IObjectContainer _contenedorObjetos;

        private IDB4oServer Servidor { get { return  ObjectFactory.GetInstance<IDB4oServer>(); } }

        public IObjectContainer ContenedorObjetos
        {
            get
            {
                if ( this._contenedorObjetos == null )
                {
                    this._contenedorObjetos = this.Servidor.CrearConexion();
                }

                return this._contenedorObjetos;
            }
        }
    }
}
