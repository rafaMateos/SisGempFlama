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
        public clsPersona PersonaPorId_BL(int id) {

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
        public int BorrarPersonaPorId_BL(int id) {

            int filas;
            clsManejadoraPersonaDal manejadora = new clsManejadoraPersonaDal();

            filas = manejadora.BorrarPersonaPorId_DAL(id);

            return filas;

        }
    }
}
