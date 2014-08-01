using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Bugzzinga.Core;

namespace Bugzzinga.Atributos
{
    public class AtributoGestorExcepciones : ExceptionFilterAttribute 
    {
        public override void OnException( HttpActionExecutedContext context )
        {
            if ( context.Exception is BugzzingaException )
            {
                var resp = new HttpResponseMessage( HttpStatusCode.BadRequest )
                {
                    Content = new StringContent( context.Exception.Message ),
                    ReasonPhrase = "Error en el sistema"
                };
                throw new HttpResponseException( resp );
            }
            else
            {
                var resp = new HttpResponseMessage( HttpStatusCode.InternalServerError )
                {
                    Content = new StringContent( context.Exception.Message ),
                    ReasonPhrase = "Error no contemplado en el sistema"
                };
                throw new HttpResponseException( resp );
            }
        }
    }
}