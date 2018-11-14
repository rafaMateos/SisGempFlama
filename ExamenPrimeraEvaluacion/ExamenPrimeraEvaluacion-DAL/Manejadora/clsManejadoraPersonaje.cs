using ExamenPrimeraEvaluacion_DAL.Conexion;
using ExamenPrimeraEvaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_DAL.Manejadora
{
    public class clsManejadoraPersonaje
    {

        /// <summary>
        /// Funcion la cual nos busca una persona por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersonaje BuscarPerPorID_DAL(int id) {

            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersonaje oPer = new clsPersonaje();
            clsMyConnection connection = new clsMyConnection();


            miConexion = connection.getConnection();

            miComando.CommandText = "SELECT * FROM personajes where idPersonaje = @id";
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;


            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();

           

            
              if (miLector.HasRows)
            {

                miLector.Read();
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

            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return oPer;


        }

        /// <summary>
        /// Metodo el cual nos actualiza un personaje
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Nimero de filas afectadas</returns>
        public int ActualizarPersonaje(clsPersonaje p) {

            int filas;

            SqlConnection miConexion;

            SqlCommand miComando = new SqlCommand();

            clsMyConnection connection = new clsMyConnection();

            miConexion = connection.getConnection();
            miComando.CommandText = "update personajes set nombre = @nombre ,alias = @alias ,vida = @vida,regeneracion = @rege,danno = @dano,armadura = @arma,velAtaque = velAtaque,resistencia = @resist,velMovimiento = @velMo,idCategoria = @idCat where IDPersona = @id";
            miComando.Connection = miConexion;

            SqlParameter param;
            param = new SqlParameter();


            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = p.idPersonaje;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = p.nombrePersonaje;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = p.alias;
            miComando.Parameters.Add("@vida", System.Data.SqlDbType.Float).Value = p.vida;
            miComando.Parameters.Add("@rege", System.Data.SqlDbType.Float).Value = p.regeneracion;
            miComando.Parameters.Add("@dano", System.Data.SqlDbType.Float).Value = p.danno;
            miComando.Parameters.Add("@arma", System.Data.SqlDbType.Float).Value = p.armadura;
            miComando.Parameters.Add("@velAtaque", System.Data.SqlDbType.Float).Value = p.velAtaque;
            miComando.Parameters.Add("@resist", System.Data.SqlDbType.Float).Value = p.resistencia;
            miComando.Parameters.Add("@velMo", System.Data.SqlDbType.Float).Value = p.velMovimiento;
            miComando.Parameters.Add("@idCat", System.Data.SqlDbType.Float).Value = p.idCategoria;
           

            //Tener en cuenta ExecuteNonQuery porque devuelve filas
            filas = miComando.ExecuteNonQuery();

            return filas;


        }
    }
}
