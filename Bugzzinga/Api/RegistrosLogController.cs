using System;
using System.Collections.Generic;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class RegistrosLogController : ApiController
    {
        public IEnumerable<LogItem> Get(string nombreItem)
        {
            //Devuelve una sublista dummy de Registros de log
            var lista = TraerListaRegistrosLogDUmmy();

            return lista;
        }

        private List<LogItem> TraerListaRegistrosLogDUmmy()
        { 
            //
            var listaLog = new List<LogItem>(); 

            for (int i = 0; i < 12; i++)
            {
                var log = new LogItem();

                log.Comentarios = "Comentario " + i;
                log.Estado = new Estado("Estado " + i.ToString(), "Descripcion" + i.ToString());
                log.Fecha = DateTime.Now;
                log.Responsable = new Usuario();
                log.Responsable.Codigo = i;
                log.Responsable.Nombre = "Juan " + i;
                log.Responsable.Apellido = "García" + i;

                listaLog.Add(log);
            }

            return listaLog;
        }
    }
}
