using _07_CRUDPersonas_DAL.Listado;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_BL.Listados
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
