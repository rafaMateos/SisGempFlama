using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_MVC_Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()

        {
            Models.clsListadoDepartamento p = new Models.clsListadoDepartamento();
            

            Models.ViewModels.clsPersonaConListadoDeDepartamentos persona = new Models.ViewModels.clsPersonaConListadoDeDepartamentos(1, 3, "Rafael", "Mateos", new DateTime(2010, 10, 10), "Pepe", "66666",p.ObtenerListado());
            
            return View(persona);
        }

        [HttpPost]
        public ActionResult Index(Models.ViewModels.clsPersonaConListadoDeDepartamentos persona)
        {
            string nombreDep = " ";

            nombreDep = persona.lista[persona.IdDept - 1].Nombre.ToString();

            Models.ViewModels.clsPersonaConNombreDeDepartamento personaDep = 
                new Models.ViewModels.clsPersonaConNombreDeDepartamento
                (persona.idPersona, persona.IdDept, persona.nombre, persona.Apellidos, persona.fechaNacimiento, persona.direccion, persona.telefono, nombreDep);

            return View("PersonaModificada", personaDep);

          
        }

    }
}