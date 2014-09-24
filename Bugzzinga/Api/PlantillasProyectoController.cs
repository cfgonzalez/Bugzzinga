﻿using System.Collections.Generic;
using System.Web.Http;

namespace Bugzzinga.Api
{
    using Bugzzinga.Dominio;

    public class PlantillasProyectoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<PlantillaProyecto> Get()
        {
            var p1 = new PlantillaProyecto() { Nombre = "plantilla1" };

            var p2 = new PlantillaProyecto() { Nombre = "plantilla2" };

            var p3 = new PlantillaProyecto() { Nombre = "plantilla3" };

            return new List<PlantillaProyecto>() { p1, p2, p3 };
        }

        public PlantillaProyecto Put(PlantillaProyecto plantillaProyecto)
        {
            return plantillaProyecto;
        }

        public PlantillaProyecto Post(PlantillaProyecto plantillaProyecto)
        {
            return plantillaProyecto;
        }

        public bool Delete(string nombre)
        {
            return true;
        }
    }
}
