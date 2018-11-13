using _EjercicioRezosYPlegarias_Entidades.Complejas;
using EjercicioRezosYPlegarias_Entidades.Persistencia;
using EjerciciosRezosYPlegarias_BL.Listados;
using EjerciciosRezosYPlegarias_BL.Manejadoras;
using Lavida_EjerciciosPreExamenRezosYPlegarias_UI.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lavida_EjerciciosPreExamenRezosYPlegarias_UI.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index(int id = 0)
        {

            clsListadoPersonaConListadoDepartamento listadoDep = new clsListadoPersonaConListadoDepartamento();

            List<clsPersona> listadoPersona = new List<clsPersona>();
            List<clsDepartamento> listadodepartamento = new List<clsDepartamento>();

            clsListadoPersonas_BL listPer = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL listado = new clsListadoDepartamentos_BL();

            if (id == 0)
            {

                listadodepartamento = listado.listadoDept_BL();
                listadoDep.listadoDept = listadodepartamento;
                listadoDep.listadoPersonaPorDept = listadoPersona;

            }
            else {

                //Cuidao que no le llega na neneeeeeeeeeeeeeeeeeee
                listadodepartamento = listado.listadoDept_BL();
                listadoDep.listadoDept = listadodepartamento;
                listadoDep.DepSelect = id;
                listadoDep.listadoPersonaPorDept = listPer.ListadoPersonasPordep_BL(listadoDep.DepSelect);
               

            }
            
            return View(listadoDep);
        }


        [HttpPost]
        public ActionResult Index(clsListadoPersonaConListadoDepartamento model) {

            clsListadoDepartamentos_BL listado = new clsListadoDepartamentos_BL();

            clsListadoPersonas_BL listPer = new clsListadoPersonas_BL();

            model.listadoDept = listado.listadoDept_BL();
            model.listadoPersonaPorDept = listPer.ListadoPersonasPordep_BL(model.DepSelect);

            return View(model);
        }


        public ActionResult Edit(int id) {

            clsManejadoraPersona_BL BL = new clsManejadoraPersona_BL();

            clsPersonaConNombreDeDepartamento oPer = new clsPersonaConNombreDeDepartamento(); ;

            try
            {
                oPer = BL.PersonaConDept_BL(id);

            }
            catch(Exception e) {

            }
            return View(oPer);

        }

        [HttpPost]
        public ActionResult Edit(clsPersonaConNombreDeDepartamento NPersona)
        {
            clsManejadoraPersona_BL majedora = new clsManejadoraPersona_BL();

            try
            {
                majedora.ActualizarPersona_BL(NPersona);
                ViewData["Actualizar"] = "Actualizado Correctamente";
            }
            catch (Exception e) {

                ViewData["Actualizar"] = "Errore";
            }
            return View(NPersona);

        }
    }
}