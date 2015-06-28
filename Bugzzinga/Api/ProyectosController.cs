using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using Bugzzinga.Dominio.ModeloPersistente;
using StructureMap;

namespace Bugzzinga.Api
{
    public class ProyectosController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Proyecto> Get()
        {           

            IEnumerable<Proyecto> proyectos = new List<Proyecto>();

            using ( IBugtracker bugzzinga = ObjectFactory.GetInstance<IBugtracker>() )
            {
                proyectos = bugzzinga.Proyectos;
            }

            return proyectos;
        }

        public Proyecto Put(Proyecto proyectoDto)
        {
            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                bugzzinga.RegistrarProyecto( proyectoDto );
            }

            return proyectoDto;
        }

        public Proyecto Post(Proyecto proyectoDto)
        {
            Proyecto proyecto = new Proyecto();
            
            using ( IBugtracker bugzzinga = new BugTrackerPersistente() )
            {
                proyecto = bugzzinga.ObtenerProyecto( proyectoDto.Nombre );
                //mapear proyecto a proyectoBD
                Mapper.Map( proyectoDto, proyecto );
                //pedirle a bugtrackter NADA hay persistencia transparente
            }

            return proyecto;
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