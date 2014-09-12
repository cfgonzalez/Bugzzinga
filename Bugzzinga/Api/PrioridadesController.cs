using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class PrioridadesController : ApiController
    {
        //Trae los usuarios para un proyecto 
        public IEnumerable<Prioridad> Get()
        {
            //Devuelve una sublista dummy del total de prioridades
            var lista = TraerListaPrioridadesDummy();

            return lista;
        }

        private List<Prioridad> TraerListaPrioridadesDummy()
        {
            var listaPrioridades = new List<Prioridad>();

            for (var i = 1; i < 8; i++)
            {
                listaPrioridades.Add(new Prioridad("P" + i.ToString(), "Prioridad" + i.ToString()));
            }

            return listaPrioridades;
        }
    }
}

