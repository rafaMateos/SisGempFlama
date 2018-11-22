
using _07_ApiRestPersona_DAL.Listados;
using _07_ApiRestPersona_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ApiRestPersona_BL.Listados
{ 
    public class clsListadoPersonas_BL
    {
        public List<clsPersona> ListadoPersonas_BL()
        {
            List<clsPersona> lista = new List<clsPersona>();

            clsListadoPersonas_DAL listado = new clsListadoPersonas_DAL();

            lista = listado.listadoCompletoPersonas();

            return lista;

        }
    }
}
