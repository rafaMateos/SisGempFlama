using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_HelloWorld_MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos

            /// <summary>
            /// Accion controlador producto que devuelve la vista listado
            /// </summary>
            /// <returns></returns>
        public ActionResult Listado()
        {
            return View();
            
        }
    }
}