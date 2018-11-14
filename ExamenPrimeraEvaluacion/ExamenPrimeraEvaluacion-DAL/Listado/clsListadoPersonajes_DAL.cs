using ExamenPrimeraEvaluacion_DAL.Conexion;
using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_DAL.Listado
{
    public class clsListadoPersonajes_DAL
    {

        /// <summary>
        /// Funcion la cual nos devolvera un listado de personajes
        /// </summary>
        /// <returns>Listado Personajes</returns>
        public List<clsPersonaje> ListadoPer_DAL() {

            SqlConnection miConexion;
            List<clsPersonaje> ret = new List<clsPersonaje>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersonaje oPer;
            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM personajes";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    oPer = new clsPersonaje();
                    oPer.idPersonaje = (int)miLector["idPersonaje"];
                    oPer.nombrePersonaje = (string)miLector["nombre"];
                    oPer.alias = (string)miLector["alias"];
                    oPer.vida = (double)miLector["vida"];
                    oPer.regeneracion = (double)miLector["regeneracion"];
                    oPer.danno = (double)miLector["danno"];
                    oPer.armadura = (double)miLector["armadura"];
                    oPer.velAtaque = (double)miLector["velAtaque"];
                    oPer.resistencia = (double)miLector["resistencia"];
                    oPer.velMovimiento = (double)miLector["velMovimiento"];
                    oPer.idCategoria = (int)miLector["idCategoria"];
                    ret.Add(oPer);

                }
            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return ret;

        }

    }
}
