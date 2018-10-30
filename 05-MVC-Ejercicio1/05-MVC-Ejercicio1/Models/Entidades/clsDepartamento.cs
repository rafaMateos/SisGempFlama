using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_MVC_Ejercicio1.Models
{
    public class clsDepartamento
    {
        #region Atributos
        public int Id { get; set; }
        public String Nombre { get; set; }
        #endregion

        #region Contructor
        public clsDepartamento(int Id,String Nombre){

            this.Id = Id;
            this.Nombre = Nombre;
    }
        #endregion


    }
}