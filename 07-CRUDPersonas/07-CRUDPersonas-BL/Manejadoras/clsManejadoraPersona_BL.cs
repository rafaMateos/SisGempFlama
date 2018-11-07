using _07_CRUDPersonas_DAL.Manejadoras;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_BL.Manejadoras
{
    public class clsManejadoraPersona_BL
    {
        public clsPersona PersonaPorId_BL(int id)
        {

            clsManejadoraPersonaDal manejadora = new clsManejadoraPersonaDal();
            clsPersona m = new clsPersona();
            m = manejadora.PersonaPorId_DAL(id);

            return m;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int BorrarPersonaPorId_BL(int id)
        {

            int filas;
            clsManejadoraPersonaDal manejadora = new clsManejadoraPersonaDal();

            filas = manejadora.BorrarPersonaPorId_DAL(id);

            return filas;

        }

        /// <summary>
        /// Funcion la cual nos creara una persona y nos devolvera el numero de filas
        /// </summary>
        /// <param name="nPersona"></param>
        /// <returns>int</returns>
        public int CrearPersona_BL(clsPersona nPersona)
        {
            int filas;

            clsManejadoraPersonaDal gestora = new clsManejadoraPersonaDal();
            filas = gestora.CrearPersona_DAL(nPersona);

            return filas;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int ActualizarPersona_BL(clsPersona p){

            int filas;

            clsManejadoraPersonaDal gestora = new clsManejadoraPersonaDal();
            filas = gestora.ActualizarPersona_DAL(p);

            return filas;

        }
    }
}
