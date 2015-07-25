using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;
using System.Linq;

namespace Bugzzinga.Api
{
    public class PerfilesController : ApiController
    {
        private readonly IFactory objectFactory;

        public PerfilesController( IFactory objectFactory )
        {
            this.objectFactory = objectFactory;
        }

        // GET api/<controller>
        public IEnumerable<Rol> Get()
        {
            var perfiles = new List<Rol>();

            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                perfiles = bugzzinga.Perfiles.ToList();
            }

            return perfiles;
        }

        //Trae el perfil para un usuario
        public Rol Get(int codigoUsuario)
        {
            throw new NotImplementedException();
        }

        public Rol Put(Rol perfilDto)
        {
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                bugzzinga.ModificarPerfil ( perfilDto );
            }

            return perfilDto;
        }

        public Rol Post(Rol perfilDto)
        {
            using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            {
                bugzzinga.RegistrarPerfil( perfilDto );
            }

            return perfilDto;
        }

        public bool Delete(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}