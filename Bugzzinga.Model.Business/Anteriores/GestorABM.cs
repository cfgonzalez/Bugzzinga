using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Bugzzinga.Data;
using Services.Security;
using Services.Exceptions;

namespace Bugzzinga.Model.Business
{
    public interface IGestorABM<Entidad>
    {
        void Registrar(Entidad entidad);
        void Modificar(Entidad entidad);
        void Eliminar(Entidad entidad);
        IList<Entidad> ListarTodos();
    }

    public abstract class GestorABM<Entidad> : IGestorABM<Entidad> 
    {

        protected  IDataMapper<Entidad> _dataMapper;
        protected IServicioExcepcionesDominio _gestorExcepciones;
        protected IServicioAutorizacion _servicioAutorizacion;
        protected IContextoSeguridad _contextoSeguridad;

        public GestorABM(IDataMapper<Entidad> dataMapper, IServicioExcepcionesDominio gestorExcepciones, IServicioAutorizacion servicioAutorizacion, IContextoSeguridad contextoSeguridad)
        {
            _dataMapper = dataMapper;
            _gestorExcepciones = gestorExcepciones;
            _servicioAutorizacion = servicioAutorizacion;
            _contextoSeguridad = contextoSeguridad;
        }


        public void Registrar(Entidad entidad)
        {

            try
            {
                _servicioAutorizacion.AutorizacionAccion(_contextoSeguridad.NombreUsuarioActual, eAcciones.Alta);

                ValidarAlta(entidad);
                _dataMapper.Registrar(entidad);
                

            }
            catch (Exception ex)
            {

                _gestorExcepciones.GestionarExcepcion(ex);
            }         

        }

        public void Modificar(Entidad entidad)
        {
            try
            {
                _servicioAutorizacion.AutorizacionAccion(_contextoSeguridad.NombreUsuarioActual, eAcciones.Modificacion);

                ValidarDatosGenerales(entidad);
                _dataMapper.Registrar(entidad);
                

            }
            catch (Exception ex)
            {

                _gestorExcepciones.GestionarExcepcion(ex);
            }         
        }

        public void Eliminar(Entidad entidad)
        {
            try
            {
                _servicioAutorizacion.AutorizacionAccion(_contextoSeguridad.NombreUsuarioActual, eAcciones.Baja);

                ValidarBaja(entidad);
                _dataMapper.Registrar(entidad);


            }
            catch (Exception ex)
            {

                _gestorExcepciones.GestionarExcepcion(ex);
            }         
        }

        public  IList<Entidad> ListarTodos()
        {
            IList<Entidad> resultado = null;

            try
            {
                _servicioAutorizacion.AutorizacionAccion(_contextoSeguridad.NombreUsuarioActual, eAcciones.Baja);

                resultado = _dataMapper.ListarTodos();
            }
            catch (Exception ex)
            {

                _gestorExcepciones.GestionarExcepcion(ex);
            }

            return resultado;
        }

        protected  void ValidarAlta(Entidad entidad)
        {
            ValidarDatosGenerales(entidad);
        }

        protected abstract void ValidarBaja(Entidad entidad);
        protected abstract void ValidarDatosGenerales(Entidad entidad);
    }
}
