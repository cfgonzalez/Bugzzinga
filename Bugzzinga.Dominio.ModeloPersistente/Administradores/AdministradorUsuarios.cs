using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Contexto.IoC;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Dominio.ModeloPersistente.Administradores
{
    public class AdministradorUsuarios : AdministradorEntidad<Usuario>
    {
        public AdministradorUsuarios( IFactory objectFactory ) :  
            base (objectFactory)
        {

        }

        public override void RegistrarNuevo( Usuario entidad )
        {
            Perfil p = (Perfil)this.ContenedorObjetos.QueryByExample( entidad.Perfil )[0];
            entidad.Perfil = p;

            this.ContenedorObjetos.Store( entidad );
            this.ContenedorObjetos.Commit();
        }

        public override Usuario ObtenerPorNombre( string nombre )
        {
            throw new NotImplementedException();
        }

        public override void Modificar( Usuario entidad )
        {
            var usuario = base.ObtenerPorId( entidad.Id );

            var p = base.ObtenerPorId( entidad.Perfil.Id );
            ((Usuario) usuario).Perfil = (Perfil) p;

            this.ContenedorObjetos.Store( usuario );
            this.ContenedorObjetos.Commit();
        }

        
    }
}
