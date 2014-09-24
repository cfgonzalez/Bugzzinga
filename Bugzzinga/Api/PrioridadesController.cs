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

        //Trae las prioridades de una plantilla de proyecto
        public IEnumerable<Prioridad> Get(string nombrePlantillaProyecto)
        {
            //Devuelve una sublista dummy del total de usuarios
            var lista = TraerListaPrioridadesDummy();

            lista.RemoveAt(1);
            lista.RemoveAt(2); 
            lista.RemoveAt(3);

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

