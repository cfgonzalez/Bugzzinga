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

        //Trae los anteriores y próximos estados válidos para un estado
        public IEnumerable<Estado> Get(string nombreEstado, string tipo)
        {
           var lista = TraerListaEstadosDummy();

            //Esto está medio feo. ¿Vale la pena hacer otro controller para traer diferentes colecciones de la misma entidad?
            if (tipo.Contains("anteriores"))
            {
                //Una lista dummy de anteriores estados validos
                lista.RemoveAt(1);
                lista.RemoveAt(2);
            }
            else if (tipo.Contains("proximos"))
            {
                //Una lista dummy de proximos estados validos
                lista.RemoveAt(0);
            }

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
