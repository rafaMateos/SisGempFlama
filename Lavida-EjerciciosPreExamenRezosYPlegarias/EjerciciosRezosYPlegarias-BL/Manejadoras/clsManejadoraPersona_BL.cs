using _EjercicioRezosYPlegarias_Entidades.Complejas;
using EjercicioRezosYPlegarias_Entidades.Persistencia;
using EjerciciosRezosYPlegarias_DAL.Manejadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRezosYPlegarias_BL.Manejadoras
{
   public class clsManejadoraPersona_BL
    {


        public clsPersona PersonaPorId_BL(int id) {

            clsManejadoraPersona_DAL gestora = new clsManejadoraPersona_DAL();
            clsPersona oPersona;
            oPersona = gestora.PersonaPorId_DAL(id);
            return oPersona;

        }


        public clsPersonaConNombreDeDepartamento PersonaConDept_BL(int id) {

            clsPersonaConNombreDeDepartamento ret = new clsPersonaConNombreDeDepartamento();
            clsManejadoraPersona_DAL gestora = new clsManejadoraPersona_DAL();
            ret = gestora.PersonaConDept_DAL(id);
            return ret;

        }

        public int ActualizarPersona_BL(clsPersonaConNombreDeDepartamento nPersona) {

            int filas;

            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();
            filas = manejadora.ActualizarPersona_Dal(nPersona);

            return filas;

        }
    }
}
