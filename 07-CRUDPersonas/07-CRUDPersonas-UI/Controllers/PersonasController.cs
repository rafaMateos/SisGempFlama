using _07_CRUDPersonas_BL.Listados;
using _07_CRUDPersonas_BL.Manejadoras;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_CRUDPersonas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas

        public ActionResult ListadoCompleto()
        {
            clsListadoPersonas_BL gestora = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();

            try//Cuidado conex bd
            {
                lista = gestora.ListadoPersonas_BL();
            }
            catch (Exception e)
            {

                //TODO: Error vista


            }

            return View(lista);
        }

        /// <summary>
        /// Action resul de borrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {

            clsPersona oPersona = new clsPersona();
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();

            try
            {
                oPersona = manejadora.PersonaPorId_BL(id);
            }
            catch (Exception e)
            {

                ViewData["Error"] = "Error no controlado";

            }


            return View(oPersona);

        }

        /// <summary>
        /// ActionResult Post delete person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            int filas;
            clsManejadoraPersona_BL gestora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL gestoraListado = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();

            try
            {
                filas = gestora.BorrarPersonaPorId_BL(id);
                ViewData["FilasAfectadas"] = $"Filas afectadas:{filas}";
                lista = gestoraListado.ListadoPersonas_BL();

            }
            catch (Exception e)
            {

                ViewData["Error"] = "No puedo borrar";

            }


            return View("ListadoCompleto", lista);

        }

        public ActionResult Create()
        {

            return View();

        }

        /// <summary>
        /// ActionResult Create a person
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(clsPersona p)
        {
            int filas;
            clsManejadoraPersona_BL gestora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL gestoraListado = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();


            try
            {
                filas = gestora.CrearPersona_BL(p);
                ViewData["FilasAfectadas"] = $"Filas afectadas:{filas}";
                lista = gestoraListado.ListadoPersonas_BL();
            }
            catch (Exception e)
            {

                ViewData["Error"] = "No puedo crear";

            }

            return View("ListadoCompleto", lista);

        }

        public ActionResult Edit(int id)
        {

            clsPersona Per = new clsPersona();
            clsManejadoraPersona_BL gestora = new clsManejadoraPersona_BL();
            Per = gestora.PersonaPorId_BL(id);


            return View(Per);

        }

        /// <summary>
        /// Update a persona nene
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(clsPersona p)
        {
            int filas;
            clsManejadoraPersona_BL gestora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL gestoraListado = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();


            try
            {
                filas = gestora.ActualizarPersona_BL(p);
                ViewData["FilasAfectadas"] = $"Filas afectadas:{filas}";
                lista = gestoraListado.ListadoPersonas_BL();
            }
            catch (Exception e)
            {

                ViewData["Error"] = "No puedo Actualiza";

            }

            return View("ListadoCompleto", lista);


        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            clsManejadoraPersona_BL gestora = new clsManejadoraPersona_BL();
            clsPersona oPersonaDetails = null;


            try//Cuidado conex bd
            {
              oPersonaDetails=gestora.PersonaPorId_BL(id);
            }
            catch (Exception e)
            {
                //TODO: Error vista
            }

            return View(oPersonaDetails);
        }

    }
}