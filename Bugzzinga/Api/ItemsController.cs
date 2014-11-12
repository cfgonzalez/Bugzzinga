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
            return TraerListaItemsDummy(); ;
        }

        //Trae los items para un proyecto 
        public IEnumerable<Item> Get(int codigoProyecto)
        {
            //Devuelve una sublista dummy del total de usuarios
            var lista = TraerListaItemsDummy();

            lista.RemoveAt(1);

            return lista;
        }

        private List<Item> TraerListaItemsDummy()
        {
            var listaItems = new List<Item>();

            for (var i = 0; i < 3; i++)
            {
                var tipo = new TipoItem("t1", "TipoItem1");

                var prioridad = new Prioridad("P1", "Prioridad 1");

                var item = new Item("Nombre" + (i + 1).ToString(), "Descripcion" + (i + 1).ToString(), tipo, prioridad);

                item.Responsable = new Usuario();

                item.Responsable.Codigo = 2;

                item.Codigo = (i + 1);

                item.Estado = new Estado("Creado", "Creado");
                
                listaItems.Add(item);
            }

            return listaItems;
        }
        public Item Put(Item item)
        {
            return item;
        }

        public Item Post(Item item)
        {
            return item;
        }

        public bool Delete(int codigo)
        {
            return true;
        }
    }
}
