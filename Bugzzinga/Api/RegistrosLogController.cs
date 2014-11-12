using System;
using System.Collections.Generic;
using System.Web.Http;
using Bugzzinga.Dominio;

namespace Bugzzinga.Api
{
    public class RegistrosLogController : ApiController
    {
        public IEnumerable<RegistroLog> Get(string nombreItem)
        {
            //Devuelve una sublista dummy de Registros de log
            var lista = TraerListaRegistrosLogDUmmy();

            return lista;
        }

        private List<RegistroLog> TraerListaRegistrosLogDUmmy()
        { 
            //
            var listaLog = new List<RegistroLog>(); 

            for (int i = 0; i < 12; i++)
            {
                var log = new RegistroLog();

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
