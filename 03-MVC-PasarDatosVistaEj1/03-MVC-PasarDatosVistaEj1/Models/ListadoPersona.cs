using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_PasarDatosVistaEj1.Models
{
    public class ListadoPersona
    {

        /// <summary>
        /// Funcion que nos devolvera un lista de personas
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> listadoPersona() {

            List<clsPersona> listado = new List<clsPersona>();

            listado.Add(new clsPersona(1, "Rafa", "Mateos", new DateTime(2010, 10, 10), "66666666", "Calle perfe"));
            listado.Add(new clsPersona(2, "Fernando", "Galiana", new DateTime(2010, 10, 10), "66666666", "Calle perfe"));
            listado.Add(new clsPersona(3, "Jorgue", "Obando", new DateTime(2010, 10, 10), "66666666", "Calle perfe"));


            return listado;
        }
       
    }
}