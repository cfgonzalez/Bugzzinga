using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
               
        public ActionResult Autenticar(string usuario, string clave)
        {           
            //Autenticar
            return RedirectToAction("Index", "Home");             
        }
    }
}
