using System;
using System.Runtime.InteropServices;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Contexto.IoC;
using Db4objects.Db4o;
using ServicioDatos.DB4o.Server.Interfaces;

namespace Bugzzinga.Contexto
{
    public class ContextoProceso : IContextoProceso
    {
        private IFactory objectFactory;

        private IObjectContainer _contenedorObjetos;

        private IDB4oServer Servidor { get { return objectFactory.Create<IDB4oServer>(); } }

        public ContextoProceso(IFactory objectFactory)
        {
            this.objectFactory = objectFactory;
        }

        public IObjectContainer ContenedorObjetos
        {
            get
            {
                if ( this._contenedorObjetos == null || this._contenedorObjetos.Ext().IsClosed() )
                {
                    this._contenedorObjetos = this.Servidor.CrearConexion();
                }

                return this._contenedorObjetos;
            }
        }

        public void ResetearContenedorObjetos()
        {
            if ( this._contenedorObjetos != null )
            {
                this._contenedorObjetos.Close();
                this._contenedorObjetos = this.Servidor.CrearConexion();
            }
        }

        public void Dispose()
        {
            this.ContenedorObjetos.Close();

            //bool isInException = Marshal.GetExceptionPointers() != IntPtr.Zero || Marshal.GetExceptionCode() != 0;

            //if ( isInException )
            //{
            //    this.ContenedorObjetos.Rollback();
            //}
            //else
            //{
            //    this.ContenedorObjetos.Commit();
            //}

            //this.ContenedorObjetos.Close();

        }
    }
}
