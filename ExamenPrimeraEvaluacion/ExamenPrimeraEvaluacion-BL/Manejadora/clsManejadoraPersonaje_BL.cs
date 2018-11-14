using ExamenPrimeraEvaluacion_DAL.Manejadora;
using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_BL.Manejadora
{


    public class clsManejadoraPersonaje_BL
    {
        /// <summary>
        /// Funcion la cual nos devolvera un personaje en concreto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un personaje</returns>
        public clsPersonaje BuscarPerPorID_BL(int id) {

            clsManejadoraPersonaje per = new clsManejadoraPersonaje();
            clsPersonaje ret = new clsPersonaje();

           
            ret = per.BuscarPerPorID_DAL(id);
           

            return ret;
        }

        /// <summary>
        /// Funcion la cual nos actualizara una persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int ActualizarPersonaje_BL(clsPersonaje p) {

            int filas;
            clsManejadoraPersonaje ges = new clsManejadoraPersonaje();
            filas = ges.ActualizarPersonaje(p);
            return filas;

        }

    }
}
