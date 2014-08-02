using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class PerfilesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Perfil> Get()
        {
            var p1 = new Perfil() { Nombre = "p1", Descripcion = "Perfil1"};

            var p2 = new Perfil() { Nombre = "p2", Descripcion = "Perfil2" };

            return new List<Perfil>() { p1, p2 };
        }

        // GET api/<controller>/5
        public string Get( int id )
        {
            return "value";
        }

        // POST api/<controller>
        public void Post( [FromBody]string value )
        {
        }

        // PUT api/<controller>/5
        public void Put( int id, [FromBody]string value )
        {
        }

        // DELETE api/<controller>/5
        public void Delete( int id )
        {
        }
    }
}