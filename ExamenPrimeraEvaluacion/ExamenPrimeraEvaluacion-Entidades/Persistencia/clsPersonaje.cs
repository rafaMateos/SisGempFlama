using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_Entidades.Persistencia
{
    public class clsPersonaje
    {
        #region propiedades
        public int idPersonaje { get; set; }
        public string nombrePersonaje { get; set; }
        public string alias { get; set; }
        public double vida { get; set; }
        public double regeneracion { get; set; }
        public double danno { get; set; }
        public double armadura { get; set; }
        public double velAtaque { get; set; }
        public double resistencia { get; set; }
        public double velMovimiento { get; set; }
        public int idCategoria { get; set; }
        #endregion

        #region constructores

        public clsPersonaje() {

        }

        public clsPersonaje(int idPersonaje,string nombrePersonaje,string alias, double vida, double regeneracion, double danoo
            , double armadura, double velAtaque, double resistencia, double velMovimiento, int idCategoria)
        {

            this.idPersonaje = idPersonaje;
            this.nombrePersonaje = nombrePersonaje;
            this.alias = alias;
            this.vida = vida;
            this.regeneracion = regeneracion;
            this.danno = danoo;
            this.armadura = armadura;
            this.velAtaque = velAtaque;
            this.resistencia = resistencia;
            this.velMovimiento = velMovimiento;
            this.idCategoria = idCategoria;
            this.idCategoria = idCategoria;

        }

        #endregion

    }
}
