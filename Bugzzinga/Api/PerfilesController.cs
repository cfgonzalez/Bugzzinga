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

        //Trae el perfil para un usuario
        public Perfil Get(int codigoUsuario)
        {
            return new Perfil() { Nombre = "p2", Descripcion = "Perfil2" }; ;
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
    }
}