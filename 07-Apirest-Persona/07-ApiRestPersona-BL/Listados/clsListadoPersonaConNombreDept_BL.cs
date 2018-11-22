

using _07_ApiRestPersona_DAL.Listados;
using _07_ApiRestPersona_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ApiRestPersona_BL.Listados
{
    public class clsListadoPersonaConNombreDept_BL
    {
        public List<clsPersonaConNombreDeDepartamento> listadoCompletoPersonasConNombreDept_BL() {

            List<clsPersonaConNombreDeDepartamento> listado = new List<clsPersonaConNombreDeDepartamento>();
            clsListadoPersonaConNombreDep_DAL m = new clsListadoPersonaConNombreDep_DAL();

            listado = m.listadoCompletoPersonasConNombreDept();

            return listado;

        }
    }
}
