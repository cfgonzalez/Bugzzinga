using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class TiposItemController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<TipoItem> Get()
        {
            return this.TraerListaTiposItemDummy();
        }

        //Trae los tipos de item para una plantilla de proyecto
        //Trae las prioridades de una plantilla de proyecto
        public IEnumerable<TipoItem> Get(string nombrePlantillaProyecto)
        {
            //Devuelve una sublista dummy del total de usuarios
            var lista = TraerListaTiposItemDummy();

            lista.RemoveAt(0);

            return lista;
        }

        public TipoItem Put(TipoItem TipoItem)
        {
            return TipoItem;
        }

        public TipoItem Post(TipoItem TipoItem)
        {
            return TipoItem;
        }

        public bool Delete(string nombre)
        {
            return true;
        }

        private List<TipoItem> TraerListaTiposItemDummy()
        {
            var p1 = new TipoItem("t1", "TipoItem1");
            var p2 = new TipoItem("t2", "TipoItem2");

            return new List<TipoItem>() { p1, p2 };
        }
    }
}