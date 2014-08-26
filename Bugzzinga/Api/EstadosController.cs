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
        //Trae los estados para un tipo de item
        public IEnumerable<Estado> Get(string tipoItemNombre)
        {
            return TraerListaEstadosDummy();
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
    }
}
