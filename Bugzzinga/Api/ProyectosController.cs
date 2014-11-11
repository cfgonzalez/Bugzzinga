using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class ProyectosController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Proyecto> Get()
        {
            var proyectos = new List<Proyecto>();

            for (int i = 1; i < 6; i++)
            {
                proyectos.Add(this.BuildProyectoDummy(i));
            }

            return proyectos;
        }

        public Proyecto Put(Proyecto proyecto)
        {
            return proyecto;
        }

        public Proyecto Post(Proyecto proyecto)
        {
            return proyecto;
        }

        public bool Delete(string codigo)
        {
            return true;
        }

        #region Construcción dummy de objetos

        private Proyecto BuildProyectoDummy(int codigo)
        {
            var tipoItem = new TipoItem(Nombre<TipoItem>(codigo), Descripcion<TipoItem>(codigo));

            //var prioridad = new Prioridad(Nombre<Prioridad>(codigo), Descripcion<Prioridad>(codigo));

            var proyecto = new Proyecto();

            proyecto.Codigo = codigo.ToString();

            proyecto.Nombre = Nombre<Proyecto>(codigo);

            proyecto.Descripcion = Descripcion<Proyecto>(codigo);

            proyecto.FechaInicio = DateTime.Now;

            return proyecto;
        }

        private string Nombre<T>(int codigo)
        {
            return typeof(T).Name + " " + "Nombre" + codigo;
        }

        private string Descripcion<T>(int codigo)
        {
            return typeof(T).Name + " " + "Descripción " + codigo;
        }

        #endregion
    }
}