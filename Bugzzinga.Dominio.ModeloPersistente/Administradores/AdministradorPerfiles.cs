﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Core;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Bugzzinga.Dominio.ModeloPersistente.Administradores
{
    public class AdministradorPerfiles: AdministradorEntidad<Rol>
    {

        public AdministradorPerfiles( IFactory objectFactory ) :  
            base (objectFactory)
        {

        }

        public override void RegistrarNuevo( Rol entidad )
        {

            base.RegistrarNuevo( entidad );

            //Ejemplo de exception para mejorar la implementacion luego
            //Perfil p = this.ObtenerPorNombre( entidad.Nombre );

            //if ( p == null )
            //{
            //    //entidad.Validar();
            //    base.RegistrarNuevo( entidad );
            //}
            //else
            //{
            //    string mensajeError = String.Format( "Ya existe un perfil registrado previamente con el nombre {0}. Debe elegir otro nombre", entidad.Nombre );
            //    throw new BugzzingaException(mensajeError);
            //}
        }

        //public override void Modificar( Rol entidad )
        //{
        //    DomainObject perfilBD = base.ObtenerPorId( entidad.Id  );

        //    Mapper.Map( entidad, perfilBD );

        //    this.ContenedorObjetos.Store( perfilBD );
        //    this.ContenedorObjetos.Commit();
        //}

        public override Rol ObtenerPorNombre( string nombre )
        {
            Rol resultado = (from Rol p in base.ContenedorObjetos
                                      where p.Nombre.Equals( nombre, StringComparison.InvariantCultureIgnoreCase )
                                      select p).SingleOrDefault();

            return resultado;
        }
    }
}
