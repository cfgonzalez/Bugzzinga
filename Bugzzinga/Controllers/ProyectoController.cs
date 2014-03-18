using System.Net;
using System.Web.Mvc;
using Bugzzinga.Dominio;

namespace Bugzzinga.Controllers
{
    public class ProyectoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guardar(Proyecto proyecto)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
