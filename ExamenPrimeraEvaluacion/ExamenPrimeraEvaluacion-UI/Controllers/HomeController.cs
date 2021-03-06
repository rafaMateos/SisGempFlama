﻿using ExamenPrimeraEvaluacion_BL.Listados;
using ExamenPrimeraEvaluacion_BL.Manejadora;
using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using ExamenPrimeraEvaluacion_UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenPrimeraEvaluacion_UI.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home

            /// <summary>
            /// Action resul de la vista Index
            /// </summary>
            /// <returns></returns>
        public ActionResult Index()
        {

            clsViewModel model = new clsViewModel();

            clsListadoPersonajes_BL gestoraList = new clsListadoPersonajes_BL();

            try {

                model.ListadoPersonajes = gestoraList.ListadoPer_BL();
                ViewData["Result"] = "Listado Correcto";
            }
            catch (Exception e) {

                ViewData["Result"] = "No se puede mostrar el listado personas";
            }

            return View(model);
        }

        /// <summary>
        /// Action result Boton Edit 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Modelo de la vista</returns>
        [HttpPost]
        public ActionResult Index(clsViewModel model)
        {
            clsManejadoraPersonaje_BL gestora = new clsManejadoraPersonaje_BL();
            clsListadoCategoria_BL gestoraCat = new clsListadoCategoria_BL();
            clsPersonaje ret = new clsPersonaje();
            clsListadoPersonajes_BL gestoraList = new clsListadoPersonajes_BL();

            //No se hacer los botones, pero supongo que de alguna forma pondremos un iff
            //y segun el valor guardaremos o mostraremos el campeon. El codigo de guardar esta terminado.

            try {

                model.personajeCategoria = gestora.BuscarPerPorID_BL(model.personajeCategoria.idPersonaje);
                model.listadoCategorias = gestoraCat.listadoCat_BL();
                model.ListadoPersonajes = gestoraList.ListadoPer_BL();
               
            }
            catch (Exception e) {

                ViewData["Result"] = "Algo ha salido mal";

            }

            return View(model);
        }

        
        
    }
}