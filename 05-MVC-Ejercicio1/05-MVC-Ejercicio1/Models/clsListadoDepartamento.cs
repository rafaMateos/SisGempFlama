using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_MVC_Ejercicio1.Models
{
    public class clsListadoDepartamento
    {

        public List<Models.clsDepartamento> ObtenerListado() {

            List<Models.clsDepartamento> list = new List<clsDepartamento>();

            Models.clsDepartamento dep1 = new Models.clsDepartamento(1,"Informatica");
            Models.clsDepartamento dep2 = new Models.clsDepartamento(2,"Marketing");
            Models.clsDepartamento dep3 = new Models.clsDepartamento(3,"Recursos Humanos");
            Models.clsDepartamento dep4 = new Models.clsDepartamento(4,"Medecina");

            list.Add(dep1);
            list.Add(dep2);
            list.Add(dep3);
            list.Add(dep4);

            return list;
        }
    }
}