using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Dominio.ModeloPersistente.Administradores
{
    internal class AdministradorPerfiles: AdministradorEntidad<Perfil>
    {

        public override void RegistrarNuevo( Perfil entidad )
        {
            Perfil p = this.ObtenerPorNombre( entidad.Nombre );

            if ( p == null )
            {
                entidad.Validar();
                base.RegistrarNuevo( entidad );
            }
            else
            {
                string mensajeError = String.Format( "Ya existe un perfil registrado previamente con el nombre {0}. Debe elegir otro nombre", entidad.Nombre );
                throw new BugzzingaException(mensajeError);
            }
        }

        public override Perfil ObtenerPorNombre( string nombre )
        {
            Perfil resultado = (from Perfil p in base.ContenedorObjetos
                                      where p.Nombre.Equals( nombre, StringComparison.InvariantCultureIgnoreCase )
                                      select p).SingleOrDefault();

            return resultado;
        }
    }
}
