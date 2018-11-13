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
    }
}
