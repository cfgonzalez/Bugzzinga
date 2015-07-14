using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.Intefaces
{
    public interface IBugtracker: IDisposable
    {
        /// <summary>
        /// Retorna los proyectos registrados en el bugtracker
        /// </summary>
        IEnumerable<Proyecto> Proyectos { get; }
      

        /// <summary>
        /// Devuelve una nueva instancia de Proyecto
        /// </summary>
        /// <returns></returns>
        Proyecto NuevoProyecto();

        /// <summary>
        /// Registra un nuevo proyecto en el bugtracker
        /// </summary>
        /// <param name="proyecto"></param>
        void RegistrarProyecto( Proyecto proyecto );

        /// <summary>
        /// Modifica un proyecto existente en el bugtracker
        /// </summary>
        /// <param name="proyecto"></param>
        void ModificarProyecto( Proyecto proyecto );

        /// <summary>
        /// Devuelve una instancia de proyecto en base a su nombre
        /// </summary>
        /// <param name="nombreProyecto">Nombre del proyecto</param>
        /// <returns></returns>
        Proyecto ObtenerProyecto( string nombreProyecto );

        /// <summary>
        /// Devuelde una instancia de proyecto en base a su codigo
        /// </summary>
        /// <param name="codigoProyecto"></param>
        /// <returns></returns>
        Proyecto ObtenerProyectoPorCodigo( string codigoProyecto );

        #region "Usuarios"

        /// <summary>
        /// Retorna los usuarios registrados en el bugtracker
        /// </summary>
        IEnumerable<Usuario> Usuarios { get; }

        /// <summary>
        /// Devuelve una nueva instancia de un usuario
        /// </summary>
        /// <returns></returns>
        Usuario NuevoUsuario();

        /// <summary>
        /// Modifica los datos de un usuario en el sistema
        /// </summary>
        /// <param name="usuario"></param>
        void ModificarUsuario( Usuario usuario );
        
        void RegistrarUsuario(Usuario usuario);

        #endregion

        #region "Perfiles"

        Perfil NuevoPerfil();
        void RegistrarPerfil( Perfil perfil );

        void ModificarPerfil( Perfil perfil );

        Perfil ObtenerPerfil( string nombrePerfil );

        IEnumerable<Perfil> Perfiles { get; }



        #endregion

        /// <summary>
        /// Registra los cambios en el sistema
        /// </summary>
        void GuardarCambios();
    }
}
