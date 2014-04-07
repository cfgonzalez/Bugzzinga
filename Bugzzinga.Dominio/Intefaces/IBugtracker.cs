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
        IEnumerable<IProyecto> Proyectos { get ;}
        /// <summary>
        /// Retorna los usuarios registrados en el bugtracker
        /// </summary>
        IEnumerable<IUsuario> Usuarios { get ; }

        /// <summary>
        /// Devuelve una nueva instancia de Proyecto
        /// </summary>
        /// <returns></returns>
        IProyecto NuevoProyecto();

        /// <summary>
        /// Registra un nuevo proyecto en el bugtracker
        /// </summary>
        /// <param name="proyecto"></param>
        void RegistrarProyecto(IProyecto proyecto);        

        /// <summary>
        /// Devuelve una instancia de proyecto en base a su nombre
        /// </summary>
        /// <param name="nombreProyecto">Nombre del proyecto</param>
        /// <returns></returns>
        IProyecto ObtenerProyecto(string nombreProyecto);

        /// <summary>
        /// Devuelve una nueva instancia de un usuario
        /// </summary>
        /// <returns></returns>
        IUsuario NuevoUsuario();
    }
}
