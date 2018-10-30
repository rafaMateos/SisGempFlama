using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_Ejercicio2.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index(Boolean esMiprimeraVez = true)
        {
            if (!esMiprimeraVez)
            {
                ViewData["Frase"] = "No es tu primera ve";
            }
            else {
                ViewData["Frase"] = "Es tu primera ve";
            }
            
            return View();
        }

      
    }
}
