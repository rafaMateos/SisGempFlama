﻿using EjercicioRezosYPlegarias_Entidades.Persistencia;
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
        public ActionResult Index(int? id)
        {
            clsListadoPersonaConListadoDepartamento listadoDep = new clsListadoPersonaConListadoDepartamento();

            List<clsPersona> listadoPersona = new List<clsPersona>();
            List<clsDepartamento> listadodepartamento = new List<clsDepartamento>();

            clsListadoPersonas_BL listPer = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL listado = new clsListadoDepartamentos_BL();

            listadodepartamento = listado.listadoDept_BL();

            listadoDep.listadoDept = listadodepartamento;
            listadoDep.listadoPersonaPorDept = listadoPersona;

            return View(listadoDep);
        }


        [HttpPost]
        public ActionResult Index(clsListadoPersonaConListadoDepartamento model) {

            clsListadoDepartamentos_BL listado = new clsListadoDepartamentos_BL();
            model.listadoDept = listado.listadoDept_BL();

            clsListadoPersonas_BL listPer = new clsListadoPersonas_BL();
            model.listadoPersonaPorDept = listPer.ListadoPersonasPordep_BL(model.DepSelect);

            return View(model);
        }

        public ActionResult Edit(int id) {

            clsManejadoraPersona_BL BL = new clsManejadoraPersona_BL();
            clsPersona oPer;
            oPer = BL.PersonaPorId_BL(id);
            return View(oPer);

        }
    }
}