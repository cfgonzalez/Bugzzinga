﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;using Bugzzinga.Dominio;

using Bugzzinga.Contexto.IoC;using Bugzzinga.Dominio.Intefaces;
using Db4objects.Db4o.Internal;
using Bugzzinga.Dominio.ModeloPersistente;
namespace Bugzzinga.Api
{
    public class ProyectosController : ApiController
    {
        private readonly IFactory objectFactory;

        public ProyectosController(IFactory objectFactory)
        {
            this.objectFactory = objectFactory;
        }

        // GET api/<controller>
        public IEnumerable<Proyecto> Get()
        {
            IEnumerable<Proyecto> proyectos = new List<Proyecto>();

            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                proyectos = bugzzinga.Proyectos;
                
            }

            return proyectos;
        }


        public Proyecto Post( Proyecto proyectoDto )
        {
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                bugzzinga.AgregarProyecto( proyectoDto );
            }

            return proyectoDto;
        }

        public Proyecto Put(Proyecto proyectoDto)
        {
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                Proyecto proyectoBd = bugzzinga.ObtenerProyectoPorCodigo( proyectoDto.Codigo );
                Mapper.Map( proyectoDto, proyectoBd );
            }

            return proyectoDto;
        }


        public bool Delete(string codigo)
        {
            /*
             using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                proyecto = bugzzinga.ObtenerProyecto( proyectoDto.Nombre );
                //mapear proyecto a proyectoBD
                Mapper.Map( proyectoDto, proyecto );
                //pedirle a bugtrackter NADA hay persistencia transparente
            }
             * */

            return true;
        }

        #region Construcción dummy de objetos

        //private Proyecto BuildProyectoDummy(int codigo)
        //{
        //    var tipoItem = new TipoItem(Nombre<TipoItem>(codigo), Descripcion<TipoItem>(codigo));

        //    //var prioridad = new Prioridad(Nombre<Prioridad>(codigo), Descripcion<Prioridad>(codigo));

        //    var proyecto = new Proyecto();

        //    proyecto.Codigo = codigo.ToString();

        //    proyecto.Nombre = Nombre<Proyecto>(codigo);

        //    proyecto.Descripcion = Descripcion<Proyecto>(codigo);

        //    proyecto.FechaInicio = DateTime.Now;

        //    return proyecto;
        //}

        //private string Nombre<T>(int codigo)
        //{
        //    return typeof(T).Name + " " + "Nombre" + codigo;
        //}

        //private string Descripcion<T>(int codigo)
        //{
        //    return typeof(T).Name + " " + "Descripción " + codigo;
        //}

        #endregion
    }
}