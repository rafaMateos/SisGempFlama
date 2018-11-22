using _07_ApiRestPersona_BL.Listados;
using _07_ApiRestPersona_BL.Manejadoras;
using _07_ApiRestPersona_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _07_Apirest_Persona_Api.Controllers
{
    public class PersonasController : ApiController
    {
        /// <summary>
        /// Verbo get para peticiones de un listado completo de personas
        /// </summary>
        /// <returns>List--Listado completo de personas</returns>
        public List<clsPersona> Get() {

            clsListadoPersonas_BL listado = new clsListadoPersonas_BL();
            return listado.ListadoPersonas_BL();

        }


        /// <summary>
        /// Verbo get con parametro para poder buscar una persona en concreto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un objeto persona</returns>
        public clsPersona Get(int id) {

            clsManejadoraPersona_BL maneja = new clsManejadoraPersona_BL();
            return maneja.PersonaPorId_BL(id);

        }

    }
}
