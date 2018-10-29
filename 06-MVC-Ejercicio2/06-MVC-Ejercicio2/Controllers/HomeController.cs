using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_MVC_Ejercicio2.Controllers
{
    public class HomeController : Controller
    {
       

        /// <summary>
        /// ActionResul de la vista Index
        /// </summary>
        /// <returns>Objeto de la Entidad clsSesion</returns>
        public ActionResult Index()
        {
             Models.clsSesion sesion = new Models.clsSesion();
            return View(sesion);
        }

        /// <summary>
        /// ActionResul de la vista Index al enviar el formulario, el cual nos cambia a sesion iniciada
        /// </summary>
        /// <returns>Objeto de la Entidad clsSesion</returns>
        [HttpPost]
        public ActionResult Index(Models.clsSesion p)
        {
            p.IsLoged = true;

            return View(p);
        }





    }

}