using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_ApiRestPersona_Entidades.Persistencia
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

        public clsDepartamento()
        {


        }
        #endregion


    }
}