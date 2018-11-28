using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _07_CRUDPersonas_Entidades
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
        public clsPersona(int IdDept, int idPersona, string nombre, string apellidos, DateTime fechaNacimiento, string telefono, string direccion) {

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

        [Display()]
        public int idPersona { get; set; }

        [Required(ErrorMessage ="Tu ere tonto o q? Introduce tu nombre")]
        public String nombre { get; set; }

        [MaxLength(50),Required(ErrorMessage = "Tu ere tonto o q? Introduce tu nombre")]
        public String Apellidos { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [MaxLength(50)]
        public String direccion { get; set; }

        [RegularExpression("@/^[9|6|7][0-9]{8}$/",ErrorMessage ="Formato invalido// 999999999")]
        public String telefono { get; set; }


        public int IdDept { get; set; }


        #endregion
    }
}