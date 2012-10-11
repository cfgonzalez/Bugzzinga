using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Data.DB4o.Server;
using Data.DB4o.Common;
using Services.Exceptions;

namespace Data.DB4o.Repository
{
    /// <summary>
    /// Repositorio para persistencia de los objetos de la aplicación.
    /// </summary>
    public class Repositorio : Data.DB4o.Repository.IRepositorio 
    {      

        /// <summary>
        /// Instancia del contenedor de objetos
        /// </summary>
        private IObjectContainer _bd;
        /// <summary>
        /// Interfaz del servicio de gestión de excepciones
        /// </summary>
        private IServicioExcepcionesPersistencia _gestorExcepciones;
        /// <summary>
        /// Interfaz del conexto que maneja el servidor de persistencia
        /// </summary>
        private IContextoContenedor _contexto;

        /// <summary>
        /// Constructor predeterminado. Se codifica como privado para ocultarlo a los clientes
        /// De esta forma se logra que solamente puedan utilizar la clase como un Singleton
        /// </summary>
        /*
        private Repositorio()
        {

        }
        */


        public Repositorio(IContextoContenedor contexto, IConfiguracionEntidadesPersistentes configuracionEntidades, IServicioExcepcionesPersistencia gestorExcepciones)
        {
            _contexto = contexto;
            _gestorExcepciones = gestorExcepciones;
            _bd = _contexto.GetContenedor();

            ConfigurarEntidadesPersistentes(configuracionEntidades);
        }

        public void ConfigurarEntidadesPersistentes(IConfiguracionEntidadesPersistentes configuracionEntidades)
        {
            configuracionEntidades.ConfigurarEntidades();
        }

        /// <summary>
        /// Libera la instancia actual del repositorio.
        /// </summary>
        public  void EliminarInstancia()
        {
            _contexto.LiberarContenedor();
        }
        /// <summary>
        /// Crea una nueva conexion al repositorio.
        /// </summary>
        public void Conectar()
        {
            try
            {
                if (_bd == null)
                {
                    _bd = ServidorBD.Instancia().CrearConexion();
                    _contexto.SetContenedor(_bd);
                }

                
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }
        /// <summary>
        /// Se desconecta del repositorio.
        /// </summary>
        public void Desconectar()
        {
            try
            {
                _contexto.LiberarContenedor();
                ServidorBD.Instancia().EliminarConexion(_bd);
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }
        /// <summary>
        /// Finaliza una transacción confirmando todos los cambios, luego inicia una nueva
        /// transacción.
        /// </summary>
        public void FinalizarTransaccion()
        {
            try
            {
                _bd.Commit();
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }
        /// <summary>
        /// Cancela todos los cambios de la transacción e inicia una nueva transacción.
        /// </summary>
        public void CancelarTransaccion()
        {
            try
            {
                _bd.Rollback();
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }


        /// <summary>
        /// Devuelve el ID de objeto dentro del repositorio para una instancia que se
        /// recibe como parámetro.
        /// </summary>
        /// <param name="pObjeto">Instancia de la cual se debe obtener el ID.</param>
        public long GetId(object pObjeto)
        {
            long resultado = long.MinValue;

            try
            {
                resultado = _bd.Ext().GetID(pObjeto);
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }

            return resultado;
        }
        /// <summary>
        /// Persiste una instancia en el repositorio.
        /// </summary>
        /// <param name="pObjeto">Instancia que se almacenará en el repositorio.</param>
        public void Registrar(object pObjeto)
        {
            try
            {
                _bd.Store(pObjeto);
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }
        /// <summary>
        /// Modifica los datos de una instancia en el repositorio.
        /// </summary>
        /// <param name="pObjeto">Instancia que debe ser modificada en el repositorio.
        /// </param>
        public void Modificar(object pObjeto)
        {
            try
            {
                _bd.Store(pObjeto);
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }
        /// <summary>
        /// Elimina una instancia en el repositorio.
        /// </summary>
        /// <param name="pObjeto">Instancia a eliminar en el repositorio.</param>
        public void Eliminar(object pObjeto)
        {
            try
            {
                _bd.Delete(pObjeto);
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }
        /// <summary>
        /// Actualiza el estado de una instancia que se encuentra en memoria
        /// con la version almacenada en el repositorio
        /// </summary>
        /// <param name="pObjeto">Instancia que se debe recuperar del repositorio</param>
        /// <param name="pProfundidad">Profundidad del arbol de objetos que se debe tener en cuenta para la actualización</param>
        /// 
        public void RefrescarInstancia(object pObjeto, int pProfundidad)
        {
            try
            {
                if (pObjeto != null)
                {
                    _bd.Ext().Refresh(pObjeto, pProfundidad);
                }
            }
            catch (Exception ex)
            {
                _gestorExcepciones.GestionarExcepcion(ex);
            }
        }


        public T Ejecutar <T> (IQuery<T>  pQuery)
        {
            var resultado = pQuery.Ejecutar(_bd);

            RefrescarInstancia(resultado, 100);

            return resultado;
        }


        public IEnumerable<Entidad> ListarTodos<Entidad>()
        {

            IEnumerable<Entidad> resultado =
                from Entidad e in _bd
                select e;

            return resultado;
        }

       /*
        /// <summary>
        /// Devuelve la primer instancia que cumple con los criterios indicados en Query.
        /// </summary>
        /// <param name="pQuery">Define los criterios que debe cumplir la instancia a
        /// retornar.</param>
        public T GetInstancia<T>(Querys.IQuery pQuery)
        {
            T resultado = default(T);
            IEnumerable<T> listado = null;

            try
            {
                listado = (IEnumerable<T>)pQuery.Ejecutar<T>(_bd);
            }
            catch (Exception ex)
            {
                Servicios.GestionExcepciones.GestionarExcepcion(ex);
            }

            if (listado.Count<T>() > 0)
            {
                resultado = listado.ElementAt<T>(0);
            }

            this.RefrescarInstancia(resultado, 100);
            return resultado;
        }
        /// <summary>
        /// Devuelve la primer instancia registra en el repositorio para el tipo indicado.
        /// </summary>
        /// <typeparam name="T">Tipo de instancia a retornar</typeparam>
        /// <returns></returns>        
        public T GetInstancia<T>()
        {

            T resultado;
            IEnumerable<T> listado = null;

            try
            {
                listado =
                from T instancia in _bd
                select instancia;
            }
            catch (Exception ex)
            {
                Servicios.GestionExcepciones.GestionarExcepcion(ex);
            }

            if (listado.Count<T>() > 0)
            {
                resultado = listado.ElementAt<T>(0);
            }
            else
            {
                resultado = default(T);
            }

            this.RefrescarInstancia(resultado, 100);
            return resultado;
        }

        /// <summary>
        /// Retonar un valor escalar en base a un query. Utilizado generalmente
        /// para retornar resultados de funciones de agregación como promedios o totales.
        /// </summary>
        /// <typeparam name="T">Tipo de valor a retornar</typeparam>
        /// <param name="pQuery">Query a utilizar para calcular el valor de retorno</param>
        /// <returns>Resultado de la ejecución del query</returns>
        public T GetEscalar<T>(Querys.IQuery pQuery)
        {
            T resultado = default(T);

            try
            {
                resultado = (T)pQuery.EjecutarEscalar<T>(_bd);
            }
            catch (Exception ex)
            {
                Servicios.GestionExcepciones.GestionarExcepcion(ex);
            }

            return resultado;

        }
        */
    }
}
