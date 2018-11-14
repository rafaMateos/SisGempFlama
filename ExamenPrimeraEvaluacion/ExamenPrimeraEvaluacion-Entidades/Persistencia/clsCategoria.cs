using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_Entidades.Persistencia
{
    public class clsCategoria
    {
        #region propiedades
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        #endregion

        #region Constructores
        public clsCategoria() {

        }

        public clsCategoria(int idCategoria,string nombreCategoria) {

            this.idCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;

        }

        #endregion

    }
}
