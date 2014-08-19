using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    using FizzWare.NBuilder;

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

        public Perfil Put(Perfil perfil)
        {
            return perfil;
        }

        public Perfil Post(Perfil perfil)
        {
            return perfil;
        }

        public bool Delete(string nombre)
        {
            return true;
        }

        #region Construcción dummy de objetos

        private Proyecto BuildProyectoDummy(int codigo)
        {
            var tipoItem = new TipoItem(Nombre<TipoItem>(codigo), Descripcion<TipoItem>(codigo));

            var prioridad = new Prioridad(Nombre<Prioridad>(codigo), Descripcion<Prioridad>(codigo));

            var usuario = new Usuario();

            usuario.Nombre = Nombre<Usuario>(codigo);

            usuario.Apellido = Descripcion<Usuario>(codigo);

            usuario.Codigo = codigo;

            var proyecto = new Proyecto();

            proyecto.Codigo = codigo.ToString();

            proyecto.Nombre = Nombre<Proyecto>(codigo);

            proyecto.Descripcion = Descripcion<Proyecto>(codigo);

            proyecto.FechaInicio = DateTime.Now;

            for (int j = 1; j < 4; j++)
            {
                proyecto.AgregarItem(new Item(Nombre<Item>(codigo), Descripcion<Item>(codigo), tipoItem, prioridad));

                proyecto.AgregarMiembro(usuario);
            }

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