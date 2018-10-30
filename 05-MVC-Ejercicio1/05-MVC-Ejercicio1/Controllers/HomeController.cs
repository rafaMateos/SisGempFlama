using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_MVC_Ejercicio1.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Action index home controles 
        /// </summary>
        /// <returns> Instancia de clsPersonaConListadoDeDepartamentos</returns>
        // GET: Home
        public ActionResult Index()

        {
            Models.clsListadoDepartamento p = new Models.clsListadoDepartamento();
            

            Models.ViewModels.clsPersonaConListadoDeDepartamentos persona = new Models.ViewModels.clsPersonaConListadoDeDepartamentos(1, 3, "Rafael", "Mateos", new DateTime(2010, 10, 10), "Pepe", "66666",p.ObtenerListado());
            
            return View(persona);
        }


        /// <summary>
        /// Action index httpPost Home controller
        /// </summary>
        /// <param name="persona"></param>
        /// <returns> Una nueva vista y una instancia de clsPersonaConNombreDeDepartamento </returns>
        [HttpPost]
        public ActionResult Index(Models.ViewModels.clsPersonaConListadoDeDepartamentos persona)
        {
            string nombreDep = " ";

            //Cambiar a bucle.
            nombreDep = persona.lista[persona.IdDept - 1].Nombre.ToString();

            Models.ViewModels.clsPersonaConNombreDeDepartamento personaDep = 
                new Models.ViewModels.clsPersonaConNombreDeDepartamento
                (persona.idPersona, persona.IdDept, persona.nombre, persona.Apellidos, persona.fechaNacimiento, persona.direccion, persona.telefono, nombreDep);

            return View("PersonaModificada", personaDep);

          
        }

    }
}