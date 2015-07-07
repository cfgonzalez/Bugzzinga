using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Dominio.ModeloPersistente.Interfaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using StructureMap;

namespace Bugzzinga.Dominio.ModeloPersistente.Administradores
{
    public abstract class AdministradorEntidad<Entidad> : IAdministradorEntidad<Entidad> where Entidad : new()
    {

        private readonly IFactory objectFactory;

        public AdministradorEntidad( IFactory objectFactory )
        {
            this.objectFactory = objectFactory;
        }

        protected IObjectContainer ContenedorObjetos
        {
            get
            {
                IContextoProceso contextoProceso = this.objectFactory.Create<IContextoProceso>();
                return contextoProceso.ContenedorObjetos;
            }
        }

        #region IAdministradorEntidad<Entidad> Members

        public virtual Entidad Nuevo()
        {
            return new Entidad();
        }

        public virtual void RegistrarNuevo( Entidad entidad )
        {
            this.ContenedorObjetos.Store( entidad );
            this.ContenedorObjetos.Commit();
        }

        public virtual void Modificar( Entidad entidad )
        {
            this.ContenedorObjetos.Store( entidad );
            this.ContenedorObjetos.Commit();
        }

        public virtual void Eliminar( Entidad entidad )
        {
            this.ContenedorObjetos.Delete( entidad );
            this.ContenedorObjetos.Commit();
        }

        public List<Entidad> ListarTodos()
        {

            List<Entidad> resultado = (from Entidad e in this.ContenedorObjetos
                                       select e).ToList();

            return resultado;
        }

        public abstract Entidad ObtenerPorNombre( string nombre );

        protected DomainObject ObtenerPorId( string id )
        {
            DomainObject resultado;
            
            resultado =   (from DomainObject u in this.ContenedorObjetos
                                    where u.Id == id
                                    select u).SingleOrDefault();

            return resultado;
        }

        #endregion


        #region "Gestion de referencias"

        

        protected DomainObject CargarReferencias( DomainObject entidad )
        {
            DomainObject entidadBD = this.ObtenerPorId( entidad.Id );

            List<string> referencias = new List<string>();
            Type tipoObjeto = entidad.GetType();

            foreach ( var propiedad in tipoObjeto.GetProperties() )
            {
                if ( propiedad.PropertyType.FullName.StartsWith( "Bugzzinga.Dominio" ) )
                    referencias.Add( propiedad.Name );
            }

            if ( entidadBD == null )
            { 
                //No existia en la BD
                entidadBD = entidad;
            }

            entidadBD = this.CargarReferenciaDesdeBD( entidad, entidadBD, referencias );

            return entidadBD;
            
        }

        private DomainObject  CargarReferenciaDesdeBD( DomainObject entidad, DomainObject entidadBD, List<string> subEntidades )
        {
            foreach ( var nombreSubEntidad in subEntidades )
            {
                DomainObject subEntidad = null;
                subEntidad = (DomainObject) entidad.GetType().GetProperty( nombreSubEntidad ).GetValue(entidad);

                DomainObject subEntidadBD =   this.ObtenerPorId( subEntidad.Id );
                entidadBD.GetType().GetProperty( nombreSubEntidad ).SetValue( entidadBD, subEntidadBD );
            }

            return entidadBD;
        }

        #endregion

    }
}
