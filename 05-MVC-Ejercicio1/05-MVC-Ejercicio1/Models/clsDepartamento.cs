using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_MVC_Ejercicio1.Models
{
    public class clsDepartamento
    {

        public clsDepartamento(int Id,String Nombre){

            this.Id = Id;
            this.Nombre = Nombre;
    }

        public int Id { get; set; }
        public String Nombre { get; set; }
    }
}