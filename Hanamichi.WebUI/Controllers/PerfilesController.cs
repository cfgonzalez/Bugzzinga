using System;
using System.Collections.Generic;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Hanamichi.WebUI.Controllers
{
    public class PerfilesController : ApiController
    {
        public IEnumerable<Perfil> Get()
        {
            List<Perfil> perfiles = new List<Perfil>();

            perfiles.Add( new Perfil() { Nombre = "Perfil1", Descripcion = "Descripcion del perfil1" } );
            perfiles.Add( new Perfil() { Nombre = "Perfil2", Descripcion = "Descripcion del perfil2" } );
            perfiles.Add( new Perfil() { Nombre = "Perfil3", Descripcion = "Descripcion del perfil3" } );
            perfiles.Add( new Perfil() { Nombre = "Perfil4", Descripcion = "Descripcion del perfil4" } );

            return perfiles;
        }

        public Perfil Get( string nombrePerfil )
        {
            Perfil perfil = new Perfil()
            {
                Nombre = nombrePerfil,
                Descripcion = String.Format( "Descripcion del perfil {0}", nombrePerfil )
            };

            return perfil;
        }

        public void Post( Perfil perfil )
        { 
            
        }

        public void Put( Perfil perfil )
        { 
        }

        public void Delete( Perfil perfil )
        { 
        
        }
    }
}
