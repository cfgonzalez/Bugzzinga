using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class ItemsController : ApiController
    {
        //Trae los usuarios para un proyecto 
        public IEnumerable<Item> Get()
        {
            return new List<Item>();
        }

        //Trae los items para un proyecto 
        public IEnumerable<Item> Get(int codigoProyecto)
        {
            //Devuelve una sublista dummy del total de usuarios
            //var lista = TraerListaItemsDummy();

//            lista.RemoveAt(1);

            return new List<Item>();
        }
        
        public Item Put(string codigoProyecto, Item itemDto)
        {
            return itemDto;
        }

        public Item Post(string codigoProyecto, Item itemDto)
        {
            return itemDto;
        }

        public bool Delete(string codigoProyecto, int codigoItem)
        {
            return true;
        }
    }
}
