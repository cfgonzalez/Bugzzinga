using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bugzzinga.Model.Business;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TraerProyectosJson(string sidx, string sord, int page, int rows)
        {          
            List<ITarea> proyectos = ServicioNegocio.TraerTareas();
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = proyectos.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (
                from tarea in proyectos
                select new
                {
                    id = tarea.FechaAlta,
                    cell = new string[] 
                    {
                      tarea.FechaAlta.ToString(), 
                      tarea.Descripcion.ToString() 
                    }
                }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }   
}
