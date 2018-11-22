

using _07_ApiRestPersona_DAL.Listados;
using _07_ApiRestPersona_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ApiRestPersona_BL.Listados
{
   public class clsListadoDept_BL
    {

        public List<clsDepartamento> ListadoPersonas_BL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            clsListadoDept listado = new clsListadoDept();

            lista = listado.listadoCompletoPersonasConNombreDept();

            return lista;

        }
    }
}
