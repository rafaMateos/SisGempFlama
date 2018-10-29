using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld_WebFornms.Entidades
{
    /*
     Nombre: clsPersona
     Atributos: Nombre --> String C/M
                Apellido --> String C/M

    Metodos

    
         */
    public class clsPersona
    {
        //barra baja para atributos privados de la clase
        #region "Atributos"
        private string _nombre;
        //private string _apellidos;
        #endregion

        #region "Propiedades publicas"
        public string nombre
        {
            get
            {

                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        //forma cortita cuando no queremos validar (set)
        public string apellidos { get; set; }

        #endregion
        
        
        
        
        //Forma largita
        /*
        public string apellidos
        {
            get
            {
                return apellidos;
            }
            set 
            {
                apellidos = value;

            }
        }
        */



    }
}
