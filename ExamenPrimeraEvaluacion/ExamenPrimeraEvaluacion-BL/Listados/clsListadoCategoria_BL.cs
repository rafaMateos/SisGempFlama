using ExamenPrimeraEvaluacion_DAL.Listado;
using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_BL.Listados
{
   public class clsListadoCategoria_BL
    {

        /// <summary>
        /// Funcion la cual nos devolvera un listado de categorias 
        /// </summary>
        /// <returns>List catgeorias</returns>
        public List<clsCategoria> listadoCat_BL() {

            List<clsCategoria> ret = new List<clsCategoria>();
            clsListadoCategoria_DAL gestora = new clsListadoCategoria_DAL();

            ret = gestora.listadoCat_DAL();

            return ret;

        }
    }
}
