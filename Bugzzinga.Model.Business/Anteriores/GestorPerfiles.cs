using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Services.Exceptions;
using Services.Security;

using Bugzzinga.Data;
using Bugzzinga.Data.Querys;

namespace Bugzzinga.Model.Business
{

    public interface IGestorPerfiles : IGestorABM<Perfil>
    { 
    }
    
    public class GestorPerfiles:GestorABM<Perfil>,IGestorPerfiles 
    {

        public GestorPerfiles(IDMPerfil dataMapper, IServicioExcepcionesDominio gestorExcepciones, IServicioAutorizacion servicioAutorizacion, IContextoSeguridad contextoSeguridad)
            : base(dataMapper,  gestorExcepciones,  servicioAutorizacion,  contextoSeguridad)
        { 
        
        }

        protected override void ValidarBaja(Perfil perfil)
        {           

            if (new QueryUsuariosPorNombrePerfil(perfil).EjecutarQuery().Count() > 0)
            {
                throw new DominioException(String.Format("El perfil: {0}  tiene usuarios asignados. Debe quitar todos los usuarios asignados al perfil para poder darlo de baja", perfil.Nombre));
            }            
            
        }

        protected override void ValidarDatosGenerales(Perfil perfil)
        {

            ErroresValidacion errores = new ErroresValidacion();

            //El nombre no puede estar en blanco
            if (perfil.Nombre == string.Empty)
            {
                errores.Agregar("El nombre del perfil no puede estar vacio");
            }

            //El nombre del perfil debe ser unico
            IList<Perfil> perfiles = new QueryPerfilesPorNombre(perfil.Nombre).EjecutarQuery().ToList();
            
            if ( perfiles.Count > 0 && !Object.ReferenceEquals(perfiles.FirstOrDefault(),perfil))
            {
                errores.Agregar(String.Format("Ya existe otro perfil registrado con el nombre: {0}, el nombre del perfil debe ser único", perfil.Nombre));
            }


            if (errores.HayErrores())
            {
                throw new DominioException("Errores de validacion en el perfil", errores);
            }
        }

    }
}
