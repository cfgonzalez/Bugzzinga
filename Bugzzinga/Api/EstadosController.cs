using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bugzzinga.Api
{
    using Bugzzinga.Dominio;

    public class EstadosController : ApiController
    {
        public IEnumerable<Estado> Get()
        {
            return TraerListaEstadosDummy();
        }

        //Trae los estados para un tipo de item
        public IEnumerable<Estado> Get(string nombreTipoItem)
        {
            var lista = TraerListaEstadosDummy().ToList();

            lista.RemoveAt(1);
            lista.RemoveAt(2);

            return lista;
        }
       
        private IEnumerable<Estado> TraerListaEstadosDummy()
        {
            var estados = new List<Estado>();

            estados.Add(new Estado("Creado", "Creado"));
            estados.Add(new Estado("Desarrollo", "Desarrollo"));
            estados.Add(new Estado("Validación", "Validación"));
            estados.Add(new Estado("Terminado", "Terminado"));

            return estados;
        }

        public Estado Put(Estado estado)
        {
            return estado;
        }

        public Estado Post(Estado estado)
        {
            return estado;
        }

        public bool Delete(string nombre)
        {
            return true;
        }

    }
}
