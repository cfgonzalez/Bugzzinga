using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bugzzinga.ViewModels;
using Bugzzinga.Mappers;

namespace Bugzzinga.Controllers
{
    public class IncidenciaDetalleController : Controller
    {
        public ActionResult Index(int Id)
        {
            IncidenciaViewModel model = IncidenciaMapper.MapearIncidenciaViewModel(Id);            
            return View(model);
        }

        public ActionResult Guardar(IncidenciaViewModel model)
        {
            //TODO: persistir el model

            return RedirectToAction("Index", "Home");
        }

        public ActionResult CargarFoto()
        {
            return PartialView("PartialImagenPerfil");
        }
    }
}
