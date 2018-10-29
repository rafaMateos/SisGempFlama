using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_PasarDatosAlControlador.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class clsPersona
    {
        #region Constructor PD
        public clsPersona() {
            //Por defecto
        }
        #endregion

        #region Constructor PP
        public clsPersona(int IdDept, int idPersona,string nombre,string apellidos,DateTime fechaNacimiento,string telefono,string direccion ) {

            this.idPersona = idPersona;
            this.nombre = nombre;
            this.Apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.direccion = direccion;
            this.IdDept = IdDept;

        }

        #endregion
        #region atributos y propiedades
        public int idPersona { get; set; }
        public String nombre { get; set; }
        public String Apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public int IdDept { get; set; }


        #endregion
    }
}