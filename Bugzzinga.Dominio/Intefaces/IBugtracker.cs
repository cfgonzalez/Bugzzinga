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


        #region "Proyectos"

        /// <summary>
        /// Devuelve una nueva instancia de Proyecto
        /// </summary>
        /// <returns></returns>
        Proyecto NuevoProyecto();

        /// <summary>
        /// Registra un nuevo proyecto en el bugtracker
        /// </summary>
        /// <param name="proyecto"></param>
        void AgregarProyecto( Proyecto proyecto );
              

        /// <summary>
        /// Devuelve una instancia de proyecto en base a su nombre
        /// </summary>
        /// <param name="nombreProyecto">Nombre del proyecto</param>
        /// <returns></returns>
        //Proyecto ObtenerProyecto( string nombreProyecto );

         ///<summary>
         ///Devuelde una instancia de proyecto en base a su codigo
         ///</summary>
         ///<param name="codigoProyecto"></param>
         ///<returns></returns>
        Proyecto ObtenerProyectoPorCodigo( string codigoProyecto );

        #endregion


        #region "Usuarios"

        /// <summary>
        ///// Retorna los usuarios registrados en el bugtracker
        ///// </summary>
        //IEnumerable<Usuario> Usuarios { get; }

        ///// <summary>
        ///// Devuelve una nueva instancia de un usuario
        ///// </summary>
        ///// <returns></returns>
        //Usuario NuevoUsuario();

        
        //void AgregarUsuario(Usuario usuario);

        #endregion

        #region "Perfiles"

        //Rol NuevoRol();
        //void AgregarRol( Rol perfil );

        

        //Rol ObtenerRol( string nombrePerfil );

        //IEnumerable<Rol> Roles { get; }



        #endregion

        /// <summary>
        /// Registra los cambios en el sistema
        /// </summary>

    }
}
