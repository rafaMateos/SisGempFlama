using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenPrimeraEvaluacion_UI.Models.ViewModel {

    public class clsViewModel
    {
        #region Atributos
        public List<clsPersonaje> ListadoPersonajes { get; set; }
        public List<clsCategoria> listadoCategorias { get; set; }
        public clsPersonaje personajeCategoria { get; set; }
        public int perSelect { get; set; }

        public int CatSelect { get; set; }
        #endregion

        #region constructores

        public clsViewModel() {


        }

        public clsViewModel(List<clsPersonaje> listadoPer, List<clsCategoria> listadoCateg, clsPersonaje personaje, int perSelect,int catselect) {

            this.ListadoPersonajes = listadoPer;
            this.listadoCategorias = listadoCategorias;
            this.personajeCategoria = personaje;
            this.perSelect = perSelect;
            this.CatSelect = catselect;

        }

        #endregion

    }

}

   
