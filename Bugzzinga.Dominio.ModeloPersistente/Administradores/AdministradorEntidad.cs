using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        //protected DomainObject ObtenerPorId( string id )
        //{
        //    DomainObject resultado;
            
        //    resultado =   (from DomainObject u in this.ContenedorObjetos
        //                            where u.Id == id
        //                            select u).SingleOrDefault();

        //    return resultado;
        //}

        #endregion


        #region "Gestion de referencias"

        

        //protected DomainObject CargarReferencias( DomainObject entidadDto )
        //{
        //    //Cargamos la entidad raiz 
        //    DomainObject entidadBD = this.ObtenerPorId( entidadDto.Id );

        //    if ( entidadBD == null )
        //    {
        //        entidadBD = entidadDto;
        //    }

        //    //Mapeamos los atributos de la entidad raiz
        //    this.MapearEntidadRaiz( entidadDto, entidadBD );           
        //    //Obtenemos el listado de referencias a objetos simples
        //    List<string> referencias = this.ObtenerReferenciasSimples( entidadDto );
        //    //Obtenemos el listado de referencias a listas de objetos
        //    // -- TODO

        //    //Cargamos las referencias a entidades desde la base de datos
        //    entidadBD = this.CargarReferenciaDesdeBD( entidadDto, entidadBD, referencias );

        //    return entidadBD;            
        //}

        //private void MapearEntidadRaiz( DomainObject entidadDto, DomainObject entidadBD )
        //{
        //    if ( entidadBD == null )
        //    {
        //        //No existia en la BD
        //        entidadBD = entidadDto;
        //    }
        //    else
        //    {
        //        //Existe en la BD
        //        Mapper.Map( entidadDto, entidadBD );
        //    }

        //}

        //private List<string> ObtenerReferenciasSimples( DomainObject entidadDto )
        //{
        //    List<string> referencias = new List<string>();

        //    Type tipoObjeto = entidadDto.GetType();

        //    foreach ( var propiedad in tipoObjeto.GetProperties() )
        //    {
        //        if ( propiedad.PropertyType.FullName.StartsWith( "Bugzzinga.Dominio" ) )
        //            referencias.Add( propiedad.Name );
        //    }

        //    return referencias;
        //}

        //private DomainObject  CargarReferenciaDesdeBD( DomainObject entidadDto, DomainObject entidadBD, List<string> referencias )
        //{
        //    foreach ( var nombreReferencia in referencias )
        //    {
        //        DomainObject subEntidad = null;
        //        subEntidad = (DomainObject) entidadDto.GetType().GetProperty( nombreReferencia ).GetValue(entidadDto);

        //        if ( subEntidad != null )
        //        {
        //            DomainObject subEntidadBD = this.ObtenerPorId( subEntidad.Id );
        //            entidadBD.GetType().GetProperty( nombreReferencia ).SetValue( entidadBD, subEntidadBD );
        //        }
        //    }

        //    return entidadBD;
        //}

        #endregion

    }
}
