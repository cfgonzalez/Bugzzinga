using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;

namespace Bugzzinga.Api
{
    public class ItemsController : ApiController
    {
        private readonly IFactory objectFactory;

        public ItemsController( IFactory ObjectFactory )
        {
            this.objectFactory = ObjectFactory;
        }

        //Trae los items para un proyecto 
        public IEnumerable<Item> Get(string codigoProyecto)
        {
            var items =  new List<Item>();
            
            using ( IBugtracker bugzzinga = this.objectFactory.Create<IBugtracker>() )
            {
                Proyecto proyecto = bugzzinga.ObtenerProyectoPorCodigo( codigoProyecto );
                items = proyecto.Items.ToList();
            }

            return items;
        }
        
        public Item Put(string codigoProyecto, Item itemDto)
        {
            return itemDto;
        }

        public Item Post(string codigoProyecto, Item itemDto)
        {

            using ( IBugtracker bugzzinga = this.objectFactory.Create<IBugtracker>() )
            {
                Proyecto proyecto = bugzzinga.ObtenerProyectoPorCodigo( codigoProyecto );
                proyecto.AgregarItem( itemDto );
                bugzzinga.ModificarProyecto( proyecto );
            }

            return itemDto;
        }

        public bool Delete(string codigoProyecto, int codigoItem)
        {
            return true;
        }
    }
}
