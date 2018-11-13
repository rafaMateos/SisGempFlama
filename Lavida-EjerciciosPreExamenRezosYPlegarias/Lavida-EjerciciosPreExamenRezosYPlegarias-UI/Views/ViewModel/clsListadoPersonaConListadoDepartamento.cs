using EjercicioRezosYPlegarias_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lavida_EjerciciosPreExamenRezosYPlegarias_UI.Views.ViewModel
{
    public class clsListadoPersonaConListadoDepartamento
    {
        
        public List<clsPersona> listadoPersonaPorDept { get; set; }
        public List<clsDepartamento> listadoDept { get; set; }
        public int DepSelect { get; set; }


        public clsListadoPersonaConListadoDepartamento() {


        }

        public clsListadoPersonaConListadoDepartamento(List<clsPersona> listadoPersona, List<clsDepartamento> listadoDept) {

            this.listadoPersonaPorDept = listadoPersona;
            this.listadoDept = listadoDept;
        }


        
    }
}