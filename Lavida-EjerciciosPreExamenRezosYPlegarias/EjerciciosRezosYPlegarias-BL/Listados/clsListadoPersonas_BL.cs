
using EjercicioRezosYPlegarias_Entidades.Persistencia;
using EjerciciosRezosYPlegarias_DAL.Listado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRezosYPlegarias_BL.Listados
{
    public class clsListadoPersonas_BL
    {

        /// <summary>
        /// Listado Personas BL
        /// </summary>
        /// <returns>List Personas</returns>
        public List<clsPersona> ListadoPersonas_BL()
        {
            List<clsPersona> lista = new List<clsPersona>();

            clsListadoPersonas_DAL listado = new clsListadoPersonas_DAL();

            lista = listado.listadoCompletoPersonas();

            return lista;

        }

        /// <summary>
        /// Funcion la cual nos devolvera un listado de personas por dept
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<clsPersona> ListadoPersonasPordep_BL(int id)
        {
            List<clsPersona> lista = new List<clsPersona>();

            clsListadoPersonas_DAL listado = new clsListadoPersonas_DAL();

            lista = listado.listadoCompletoPersonasPorDep(id);

            return lista;

        }
    }
}
