using ExamenPrimeraEvaluacion_DAL.Listado;
using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_BL.Listados
{
    public class clsListadoPersonajes_BL
    {
        /// <summary>
        /// Funcion la cal nos devuelve un listado de personajes
        /// </summary>
        /// <returns>ListadoPersonajes</returns>
        public List<clsPersonaje> ListadoPer_BL() {

            List<clsPersonaje> listadoPer = new List<clsPersonaje>();

            clsListadoPersonajes_DAL lista = new clsListadoPersonajes_DAL();

            try {

                listadoPer = lista.ListadoPer_DAL();
            }
            catch (Exception e) {

                //TODO
            }
            

            return listadoPer;


        }

    }
}
