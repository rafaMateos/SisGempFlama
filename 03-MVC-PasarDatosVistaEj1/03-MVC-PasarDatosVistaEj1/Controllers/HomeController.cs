using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_MVC_PasarDatosVistaEj1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action Index home controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            //Declaracion variables
            String saludo;
            Models.clsPersona persona = new Models.clsPersona();
            


            //Saludamos
            saludo = Saludo();
            ViewData["Saludo"] = saludo;

            //Mostramos la fecha actual
            ViewBag.FechaActual = DateTime.Now.ToLongDateString();



            //Damos valores al objeto
            persona.nombre = "Rafa";
            persona.Apellidos = "Mateos";
            persona.idPersona = 1;
            persona.telefono = "6666666666";
            persona.direccion = "Calle no me importa";
            persona.fechaNacimiento = new DateTime(1996, 10, 10);


            

            return View(persona);



        }

        /// <summary>
        /// Action Index ListadoPersonas controller
        /// </summary>
        /// <returns></returns>
        public ActionResult ListadoPersonas() {

            Models.ListadoPersona listarPer = new Models.ListadoPersona();

            //Puedes devolver el objeto 
            //return View(listaper);

            return View(listarPer.listadoPersona());
        }




        /// <summary>
        /// metodo el cual te devuelve un saludo segun la hora del dia
        /// </summary>
        /// <returns>String asociado al nombre con el saludo correspondiente</returns>
        string Saludo()
        {

            string saludo = " ";

            if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 18){

                saludo = "Buenas tardes";
            }
            else if (DateTime.Now.Hour >= 19 && DateTime.Now.Hour <= 24){

                saludo = "Buenas noches";
            }
            else{

                saludo = "Buenas Dias";
            }

            return saludo;

        }

    }
}