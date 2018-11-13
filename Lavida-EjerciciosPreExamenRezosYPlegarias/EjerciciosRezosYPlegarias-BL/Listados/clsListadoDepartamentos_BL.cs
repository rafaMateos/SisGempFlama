using EjercicioRezosYPlegarias_Entidades.Persistencia;
using EjerciciosRezosYPlegarias_DAL.Listado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRezosYPlegarias_BL.Listados
{

    public class clsListadoDepartamentos_BL
    {
        public List<clsDepartamento> listadoDept_BL() {

            List<clsDepartamento> Listado = new List<clsDepartamento>();

            clsListadoDepartamentos_DAL list = new clsListadoDepartamentos_DAL();

            Listado = list.listadoDept_DAL();

        
            return Listado;

        }
    }
}
