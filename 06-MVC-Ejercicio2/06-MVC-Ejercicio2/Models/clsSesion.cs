using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_MVC_Ejercicio2.Models
{
    public class clsSesion
    {
        #region Atributos
        public Boolean IsLoged { get; set; }
        public string nonbreSesion { get; set; }
        #endregion

        #region constructores
        public clsSesion() {

            this.IsLoged = false;
            this.nonbreSesion = " ";

        }

        public clsSesion(Boolean isLoged,string nombreSesion) {

            this.IsLoged = isLoged;
            this.nonbreSesion = nombreSesion;

        }
        #endregion 


    }
}