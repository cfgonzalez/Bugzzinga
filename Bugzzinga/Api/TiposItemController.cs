using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Bugzzinga.Contexto.IoC;
using Bugzzinga.Dominio;
using Bugzzinga.Dominio.Intefaces;

namespace Bugzzinga.Api
{
    public class TiposItemController : ApiController
    {
         private readonly IFactory objectFactory;

         public TiposItemController( IFactory objectFactory )
        {
            this.objectFactory = objectFactory;
        }

        //*** Lo vamos a implementar luego, si es que dejamos las plantillas de proyecto
        //Trae los tipos de item para una plantilla de proyecto
        //public IEnumerable<TipoItem> Get(string nombrePlantillaProyecto)
        //{
        //    //Devuelve una sublista dummy del total de de tipos de item
        //    var lista = TraerListaTiposItemDummy();

        //    lista.RemoveAt(0);

        //    return lista;
        //}

        public IEnumerable<TipoItem> Get(string codigoProyecto)
        {

            //List<TipoItem> tiposItem = new List<TipoItem>();

            //using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            //{
            //    Proyecto proyecto = bugzzinga.ObtenerProyectoPorCodigo( codigoProyecto );
            //    tiposItem = proyecto.TiposDeItem.ToList();
            //}

            //return tiposItem;

            throw new NotImplementedException();
        }

        public TipoItem Put(string codigoProyecto, TipoItem TipoItemDTO)
        {
            throw new NotImplementedException();
        }

        public TipoItem Post(string codigoProyecto, TipoItem tipoItem)
        {

            throw new NotImplementedException();
        }

        public bool Delete(string codigoProyecto, string nombreTipoItem)
        {
            //using ( IBugtracker bugzzinga = objectFactory.Create<IBugtracker>() )
            //{
            //    bugzzinga.QuitarTipoItemDeProyecto( codigoProyecto, nombreTipoItem );
            //}

            //return true;

            throw new NotImplementedException();
        }
    }
}