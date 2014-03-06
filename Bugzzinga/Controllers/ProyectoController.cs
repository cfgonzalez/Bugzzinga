using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bugzzinga.Dominio;

namespace Bugzzinga.Controllers
{
    public class ProyectoController : Controller
    {
        //
        // GET: /Proyecto/

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        public ActionResult Index()
        {

            //Proyecto p = new Proyecto();
            //p.Id = 1;
            //p.Nombre = "puto !";

            //Bugtracker.NuevoProyecto(p);

            //var r = Bugtracker.CargarProyecto(1);


            return View();
        }

    }
}
