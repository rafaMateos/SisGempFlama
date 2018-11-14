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
    public class clsListadoCategoria_DAL
    {

        /// <summary>
        /// Funcion la cual nos devolvera un listado de categorias
        /// </summary>
        /// <returns>List Categorias</returns>
        /// 
        public List<clsCategoria> listadoCat_DAL() {

            SqlConnection miConexion;
            List<clsCategoria> ret = new List<clsCategoria>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsCategoria oPer;
            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM categorias";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {
                    oPer = new clsCategoria();
                    oPer.idCategoria = (int)miLector["idCategoria"];
                    oPer.nombreCategoria = (string)miLector["nombreCategoria"];
                    ret.Add(oPer);
                }
            }

            miLector.Close();
            connection.closeConnection(ref miConexion);

            return ret;

        }
    }
}
