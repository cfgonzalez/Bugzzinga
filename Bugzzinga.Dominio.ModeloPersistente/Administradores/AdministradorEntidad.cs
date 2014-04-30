﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Contexto.Interfaces;
using Bugzzinga.Dominio.ModeloPersistente.Interfaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using StructureMap;

namespace Bugzzinga.Dominio.ModeloPersistente.Administradores
{
    internal abstract class AdministradorEntidad<Entidad> : IAdministradorEntidad<Entidad> where Entidad : new()
    {
        protected IObjectContainer ContenedorObjetos
        {
            get
            {
                IContextoProceso contextoProceso = ObjectFactory.GetInstance<IContextoProceso>();
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

        public List<Entidad> ListarTodos()
        {

            List<Entidad> resultado = (from Entidad e in this.ContenedorObjetos
                                       select e).ToList();

            return resultado;
        }

        public abstract Entidad ObtenerPorNombre( string nombre );
      
        #endregion
    }
}