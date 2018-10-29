using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace _05_MVC_Ejercicio1.Models.ViewModels
{

    public class clsPersonaConListadoDeDepartamentos: _04_PasarDatosAlControlador.Models.clsPersona
    {

        public List<clsDepartamento> lista { get; set; }


        public clsPersonaConListadoDeDepartamentos() : base()
        {

            clsListadoDepartamento crearListado = new clsListadoDepartamento();

            this.lista = crearListado.ObtenerListado();

        }

        public clsPersonaConListadoDeDepartamentos(int idPersona, int idDepartamento, string nombre, string apellidos,
                               DateTime fechaNacimiento, String direccion, String telefono, List<clsDepartamento> listado)
        {

            this.idPersona = idPersona;
            this.IdDept = idDepartamento;
            this.nombre = nombre;
            this.Apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.lista = listado;

        }

    }
}