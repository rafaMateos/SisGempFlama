using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_CRUDPersonas_UI.ViewModels
{
    public class clsPersonaConNombreDeDepartamento: clsPersona
   
    {
        #region Atributos
        public string nombreDepartamento { get; set; }
        #endregion

        public clsPersonaConNombreDeDepartamento() {



        }

        #region Contructores
        public clsPersonaConNombreDeDepartamento(int idPersona, int idDepartamento, string nombre, string apellidos,
                              DateTime fechaNacimiento, String direccion, String telefono, string nombreDep)
        {

            this.idPersona = idPersona;
            this.IdDept = idDepartamento;
            this.nombre = nombre;
            this.Apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.nombreDepartamento = nombreDep;


        }

        #endregion
    }
}