using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bugzzinga.Model.Entities;
using Bugzzinga.Data;
using Bugzzinga.Data.Querys;

using Services.Security;
using Services.Exceptions;


namespace Bugzzinga.Model.Business
{

    public interface IGestorUsuarios : IGestorABM<Usuario>
    { 
    }

    public class GestorUsuarios:GestorABM<Usuario>,IGestorUsuarios
    {
        public GestorUsuarios(IDMUsuario dataMapper, IServicioExcepcionesDominio gestorExcepciones, IServicioAutorizacion servicioAutorizacion, IContextoSeguridad contextoSeguridad)
            : base(dataMapper,  gestorExcepciones,  servicioAutorizacion,  contextoSeguridad)
        { 
        
        }


        public void AsignarPerfil(Usuario usuario, Perfil perfil)
        {
            usuario.AgregarPerfil(perfil);
            Modificar(usuario);
        }

        public void QuitarPerfil(Usuario usuario, Perfil perfil)
        {
            usuario.QuitarPerfil(perfil);
            Modificar(usuario);
        }


        protected override void ValidarBaja(Usuario usuario)
        {
            //TODO: Validar que no tenga tareas asignadas


            //TODO: Validar que el usuario no tenga proyectos asignados
            throw new NotImplementedException();
        }

        protected override void ValidarDatosGenerales(Usuario usuario)
        {

            ErroresValidacion errores = new ErroresValidacion();

            //El LoginName de usuario no puede quedar en blanco
            if (usuario.LoginName == string.Empty)
            {
                errores.Agregar("El nombre de la cuenta del usuario no puede estar en blanco");
            }


            //El LoginName de usuario debe ser unico
            IList<Usuario> usuarios = null; //new QueryUsuariosPorLoginName(usuario.LoginName).EjecutarQuery();
            if (usuarios != null)
            {
                if (usuarios.Count > 0 && !Object.ReferenceEquals(usuarios.FirstOrDefault(), usuario))
                {
                    errores.Agregar(String.Format("Ya existe un cuenta registrada con el nombre: {0}, el nombre de usuario debe ser único", usuario.LoginName));
                }
            }


            //El nombre no puede quedar vacio
            if (usuario.Nombre == string.Empty)
            {
                errores.Agregar("El nombre del usuario no puede estar en blanco");
            }

            //El apellido no puede quedar vacio
            if (usuario.Apellido == string.Empty)
            {
                errores.Agregar("El apellido del usuario no puede estar en blanco");
            }
            

            if (errores.HayErrores())
            {
                throw new DominioException("Errores de validacion en el usuario", errores);
            }
        }
    }
}
