using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

            base.CargarReferencias( entidad );

            this.ContenedorObjetos.Store( entidad );
            this.ContenedorObjetos.Commit();
        }

        public override Usuario ObtenerPorNombre( string nombre )
        {
            throw new NotImplementedException();
        }

        public override void Modificar( Usuario entidad )
        {

            DomainObject usuario = base.CargarReferencias( entidad );
            Mapper.Map( entidad, usuario );
            this.ContenedorObjetos.Store( usuario );
            this.ContenedorObjetos.Commit();
        }

        
    }
}
