using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_MVC_Ejercicio1.Models.ViewModels
{
    public class clsPersonaConNombreDeDepartamento: _04_PasarDatosAlControlador.Models.clsPersona
   
    {
        #region Atributos
        public string nombreDepartamento { get; set; }
        #endregion

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