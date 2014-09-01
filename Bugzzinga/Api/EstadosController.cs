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

        //Trae los próximos estados válidos para un estado
        public IEnumerable<Estado> Get(string nombre)
        {
            //Devuelve una sublista dummy del total de estados disponibles
            var lista = TraerListaEstadosDummy();

            lista.RemoveAt(1);
            lista.RemoveAt(2);

            return lista;
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

        private List<Estado> TraerListaEstadosDummy()
        {
            var estados = new List<Estado>();

            estados.Add(new Estado("Creado", "Creado"));
            estados.Add(new Estado("Desarrollo", "Desarrollo"));
            estados.Add(new Estado("Validación", "Validación"));
            estados.Add(new Estado("Terminado", "Terminado"));

            return estados;
        }
    }
}
