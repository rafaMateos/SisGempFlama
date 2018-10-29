using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace _04_PasarDatosAlControlador.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Editar()
        {
            Models.clsPersona p = new Models.clsPersona();

            p.nombre = "Rafa";
            p.Apellidos = "Mateos";
            p.direccion = "No me importa";
            p.fechaNacimiento = new DateTime(2010,10,10);
            p.telefono = "66666666";

            return View(p);
        }

        
        [HttpPost]
        public ActionResult Editar(Models.clsPersona persona){
        
            return View("PersonaModificada", persona);
            
        }
        
    }
}