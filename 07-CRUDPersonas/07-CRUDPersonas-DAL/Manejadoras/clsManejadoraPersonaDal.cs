using _07_CRUD_Personas_DAL.Conexion;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_DAL.Manejadoras
{
    public class clsManejadoraPersonaDal
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona PersonaPorId_DAL(int id)
        {

            SqlConnection miConexion;
            List<clsPersona> ret = new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona = null;
            clsMyConnection connection = new clsMyConnection();

            
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM personas where IDPersona = @id";
            miComando.Connection = miConexion;
            

            //Preparamos el parametro.
            SqlParameter param;
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = id;
            miComando.Parameters.Add(param);

            miLector = miComando.ExecuteReader();

            //Preparamos el parametro 2 forma
            //miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            if (miLector.HasRows)
            {

                miLector.Read();

                oPersona = new clsPersona();
                oPersona.idPersona = (int)miLector["IDPersona"];
                oPersona.nombre = (String)miLector["nombrePersona"];
                oPersona.Apellidos = (String)miLector["apellidosPersona"];
                oPersona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                //oPersona.telefono = (String)miLector["telefono"];
                oPersona.direccion = (String)miLector["direccion"];
                oPersona.IdDept = (int)miLector["IDDepartamento"];


            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return oPersona;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int BorrarPersonaPorId_DAL(int id)
        {

            SqlConnection miConexion;

            SqlCommand miComando = new SqlCommand();
            int filas;
            clsMyConnection connection = new clsMyConnection();

            miConexion = connection.getConnection();
            miComando.CommandText = "DELETE FROM personas where IDPersona = @id";
            miComando.Connection = miConexion;

            SqlParameter param;
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = id;
            miComando.Parameters.Add(param);

            //Tener en cuenta ExecuteNonQuery porque devuelve filas
            filas = miComando.ExecuteNonQuery();

            return filas;




        }

    }

    
}
